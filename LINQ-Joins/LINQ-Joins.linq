<Query Kind="Statements">
  <Connection>
    <ID>2002ee93-85fb-4710-ac5d-11ac326a7552</ID>
    <Persist>true</Persist>
    <Server>SHAILENDRA</Server>
    <SqlSecurity>true</SqlSecurity>
    <Database>LINQ-Joins</Database>
    <NoPluralization>true</NoPluralization>
    <NoCapitalization>true</NoCapitalization>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAmf/ZCXElXEiayYIh9+DDKwAAAAACAAAAAAAQZgAAAAEAACAAAABInJpou1k/TkzRAX74yNF6PrIUKBONukfvcX9Hv8cxvgAAAAAOgAAAAAIAACAAAACt9EnAiqWy7l0v8PQC1Qlhe4pmY78m3+E9nID6xaGzfhAAAABuJpaeRcmGGT8qVKY/cGyTQAAAANqmAg+yFlLlL+WV7h4ych3Suz+IYNFY819n8hbo57t5o+eKOodRwgteS9kfjRhQwo983nPC01RpOQ066xXszrE=</Password>
  </Connection>
</Query>

//Select * from Customer

//1. Query based Syntax
//2. Method based Syntax

//Query based Syntax
//from cust in Customer
//where cust.CustID > 2
//select cust

//Method based Syntax
//Customer.Select(c=>c)
//Customer.Where(c=>c.CustID>2)

//var q=from cust in Customer
//	where cust.CustID > 2
//	select new{
//		cust.Name,
//		cust.Address
//	}; //deferred execution

//query execution
//1. Deferred execution
//2. Immediate execution

//var q=(from cust in Customer
//	where cust.CustID > 2
//	select new{
//		cust.Name,
//		cust.Address
//	}).ToList(); //immediate execution

//var q0=from cust in Customer
//	where cust.CustID > 2
//	select new{ //anonymous type
//		cust.Name,
//		cust.Address
//	};
//
//List<Customer> q=(from cust in Customer
//	where cust.CustID > 2
//	select new Customer{ //anonymous type
//		Name=cust.Name,
//		Address=cust.Address
//	}).ToList();
//	
//List<Customer> q1=(from cust in Customer
//	where cust.CustID > 2
//	select cust).ToList();
//	
//IQueryable<Customer> q2=(from cust in Customer
//	where cust.CustID > 2
//	select cust);
//	
//IEnumerable<Customer> q3=(from cust in Customer
//	where cust.CustID > 2
//	select cust).ToList();

//////////// LINQ Join //////////////////	
//1. Inner join
//2. Group Join
//3. Left Join
//4. Cross Join

////// Inner join
//var q= from cust in Customer
//	   join ord in Order
//	   on cust.CustID equals ord.CustomerID
//	   select new {
//	   		cust.Name,
//			cust.Address,
//			ord.OrderID,
//			ord.Quantity			
//	   };

//inner join
//var q= from cust in Customer
//	   join ord in Order
//	   on cust.CustID equals ord.CustomerID
//	   join prd in Product
//	   on ord.ProductID equals prd.ProductID
//	   select new {
//	   		cust.Name,
//			cust.Address,
//			ord.OrderID,
//			ord.Quantity,
//			prd.ProductID,
//			ProductName=prd.Name //alias
//	   };

//var q= from cust in Customer
//	   join ord in Order
//	   on new{a=cust.CustID,cust.ContactNo} equals new{a=(int)ord.CustomerID,ord.ContactNo}
//	   select new {
//	   		cust.Name,
//			cust.Address,
//			ord.OrderID,
//			ord.Quantity
//	   };

///////// Group Join ///////
//var q= from cust in Customer
//	   join ord in Order
//	   on cust.CustID equals ord.CustomerID
//	   into gp
//	   select new {
//	   		cust.Name,
//			cust.Address,
//			gp
//	   };

//////////// Left join ////////
//var q= from cust in Customer
//	   join ord in Order
//	   on cust.CustID equals ord.CustomerID
//	   into gp
//	   from g in gp.DefaultIfEmpty()
//	   select new {
//	   		cust.Name,
//			cust.Address,
//			OrderID=(int?)g.OrderID,
//			g.Quantity,
//			g.Price
//	   };

//////// cross join ///////////
var q= from cust in Customer
	   from ord in Order
	   select new {
	   		cust.Name,
			cust.Address,
			ord.OrderID,
			ord.Quantity			
	   };

q.Dump();

//1. Eager Loading 
//2. Deferred Loading








