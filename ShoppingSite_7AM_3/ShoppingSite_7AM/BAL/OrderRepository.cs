using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BAL
{
   public class OrderRepository : IOrderRepository
    {
       DatabaseContext db = new DatabaseContext();
        public int SaveCart(CartViewModel model)
        {
            Cart cart = new Cart();
            cart.CreatedDate = DateTime.Now;

            cart.Total = model.Total;
            cart.PayableAmount = model.PayableAmount;
            cart.Discount = model.Discount;
            cart.GrandTotal = model.GrandTotal;

            cart.Tax = model.Tax;
            cart.UserId = model.UserId;
            foreach (var item in model.Items)
            {
                CartItem obj = new CartItem();
                obj.ProductId = item.ProductId;
                obj.Quantity = item.Quantity;
                obj.Total = item.Total;
                obj.UnitPrice = item.UnitPrice;

                cart.Items.Add(obj);
            }
            db.Carts.Add(cart);
            db.SaveChanges();
            return cart.CartId;
        }

        public bool PlaceOrder(TransactionViewModel model)
        {
            try
            {
                Transaction tran = new Transaction();
                tran.Amount = model.Amount;
                tran.CartId = model.CartId;
                tran.Tran_Id = model.TransactionId;
                tran.CreatedDate = DateTime.Now;
                tran.PaymentType = model.PaymentType;
                tran.Status = model.Status;

                Cart cart = db.Carts.Find(model.CartId);
                Order ord = new Order();

                ord.CartId = cart.CartId;
                ord.PayableAmount = cart.PayableAmount;
                ord.CreatedDate = DateTime.Now;
                ord.CustomerName = model.Name;
                ord.Discount = cart.Discount;
                ord.GrandTotal = cart.GrandTotal;
                ord.ShippingAddress = model.Address;
                ord.Tax = cart.Tax;
                ord.Total = cart.Total;
                ord.UserId = cart.UserId;

                foreach (var item in cart.Items)
                {
                    OrderItem obj = new OrderItem();
                    obj.ProductId = item.ProductId;
                    obj.Quantity = item.Quantity;
                    obj.Total = item.Total;
                    obj.UnitPrice = item.UnitPrice;

                    ord.Items.Add(obj);
                }

                tran.UserId = cart.UserId;
                db.Transactions.Add(tran);
                db.Orders.Add(ord);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
