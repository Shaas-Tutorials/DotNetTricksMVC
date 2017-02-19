// shopping cart
function shoppingCart(cartName) {
    this.cartName = cartName;
    this.clearCart = false;
    this.Items = [];
    this.Total = 0;
    this.Discount = 0;
    this.Tax = 15;
    this.GrandTotal = 0;

    this.UserId = 0;

    // load Items from local storage when initializing
    this.loadItems();

    // save Items to local storage when unloading
    var self = this;
    $(window).unload(function () {
        if (self.clearCart) {
            self.clearItems();
        }
        self.saveItems();
        self.clearCart = false;
    });
}

// shopping cart item
function cartItem(ProductId, Name, UnitPrice, Quantity) {
    this.ProductId = ProductId;
    this.Name = Name;
    this.UnitPrice = UnitPrice * 1;
    this.Quantity = Quantity * 1;
    this.Total = this.UnitPrice * this.Quantity;
}

// load Items from local storage
shoppingCart.prototype.loadItems = function () {
    var Items = localStorage != null ? localStorage[this.cartName + "_items"] : null;
    if (Items != null && JSON != null) {
        try {
            Items = JSON.parse(Items);
            for (var i = 0; i < Items.length; i++) {
                var item = Items[i];
                if (item.ProductId != null && item.Name != null && item.UnitPrice != null && item.Quantity != null) {
                    item = new cartItem(item.ProductId, item.Name, item.UnitPrice, item.Quantity);
                    this.Items.push(item);
                }
            }
        }
        catch (err) {
            // ignore errors while loading...
        }
    }
};

// save Items to local storage
shoppingCart.prototype.saveItems = function () {
    if (localStorage != null && JSON != null) {
        localStorage[this.cartName + "_items"] = JSON.stringify(this.Items);
    }
};

// adds an item to the cart
shoppingCart.prototype.addItem = function (ProductId, Name, UnitPrice, Quantity) {
    Quantity = this.toNumber(Quantity);
    if (Quantity != 0) {
        // update Quantity for existing item
        var found = false;
        for (var i = 0; i < this.Items.length && !found; i++) {
            var item = this.Items[i];
            if (item.ProductId == ProductId) {
                found = true;
                item.Quantity = this.toNumber(item.Quantity + Quantity);
                if (item.Quantity <= 0) {
                    this.Items.splice(i, 1);
                }
            }
        }
        // new item, add now
        if (!found) {
            var item = new cartItem(ProductId, Name, UnitPrice, Quantity);
            this.Items.push(item);
        }
        // save changes
        this.saveItems();
    }
}

// clear the cart
shoppingCart.prototype.clearItems = function () {
    this.Items = [];
    this.saveItems();
}

//convert into number
shoppingCart.prototype.toNumber = function (value) {
    value = value * 1;
    return isNaN(value) ? 0 : value;
}
// get the total UnitPrice for all Items currently in the cart
shoppingCart.prototype.getTotalPrice = function (ProductId) {
    var total = 0;
    for (var i = 0; i < this.Items.length; i++) {
        var item = this.Items[i];
        if (ProductId == null || item.ProductId == ProductId) {
            total += this.toNumber(item.Quantity * item.UnitPrice);
        }
    }

    var tax = this.toNumber((this.Total * this.Tax) / 100);

    this.Total = total;
    this.GrandTotal = this.Total + tax;
    this.PayableAmount = this.GrandTotal - this.Discount;

    return total;
}

// get the total Items currently in the cart
shoppingCart.prototype.getTotalCount = function (ProductId) {
    var count = 0;
    for (var i = 0; i < this.Items.length; i++) {
        var item = this.Items[i];
        if (ProductId == null || item.ProductId == ProductId) {
            count += this.toNumber(item.Quantity);
        }
    }
    return count;
}

//checkout using payumoney
shoppingCart.prototype.checkoutPayUmoney = function (cartId) {
    /*
       Test Card Name: any name
       Test Card Number: 5123456789012346
       Test CVV: 123
       Test Expiry: May 2017
     */
   
    var params = {
        url: "https://test.payu.in/_payment",
        options: {
            key: "gtKFFx",
            salt: "eCwWELxi",
            txnid: (Math.random() * 10000000000).toFixed(0), //with 10 numbers
            amount: this.PayableAmount,
            productinfo: this.cartName + "_" + this.getTotalCount(),
            firstname: authInfo.firstname,
            email: authInfo.email,
            phone: authInfo.phone,
            surl: "http://localhost:50849/app/Success",
            furl: "http://localhost:50849/app/Success",
            service_provider: "",
            hash: "",
            udf1: cartId
        }
    };

    var str = params.options.key + "|" + params.options.txnid + "|" + params.options.amount + "|" + params.options.productinfo + "|" + params.options.firstname + "|" + params.options.email + "|" + params.options.udf1 + "||||||||||" + params.options.salt;

    console.log(str);
    params.options.hash = CryptoJS.SHA512(str).toString();

    // build form
    var form = $('<form/></form>');
    form.attr("action", params.url);
    form.attr("method", "POST");
    form.attr("style", "display:none;");
    this.addFormFields(form, params.options);
    $("body").append(form);

    // submit form
    this.clearCart = true;// clearCart == null || clearCart;

    form.submit();
    form.remove();
}

// adding hidden fields to form
shoppingCart.prototype.addFormFields = function (form, data) {
    if (data != null) {
        $.each(data, function (Name, value) {
            if (value != null) {
                var input = $("<input></input>").attr("type", "hidden").attr("Name", Name).val(value);
                form.append(input);
            }
        });
    }
}