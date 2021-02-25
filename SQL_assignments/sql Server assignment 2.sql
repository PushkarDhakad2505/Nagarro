
--Exercise 2
-------------
--1.Write separate queries using a join, 
--2.a subquery, 
--3.a CTE,
--4.and then an EXISTS 
--to list all AdventureWorks customers who have not placed an order.

--1 using join
	select customer.CustomerID from Sales.SalesOrderHeader
	right  join
	Sales.Customer
	on
	Customer.CustomerID=SalesOrderHeader.CustomerID
	where SalesOrderHeader.CustomerID is NUll;
	
----2 using subquery
	----------------
	SELECT CustomerID 
	FROM Sales.customer 
	WHERE Sales.customer.CustomerID not in
		(SELECT customerId
			FROM Sales.SalesOrderHeader) 


--3 USING CTE

WITH CustomersWithoutOrder (CustmerID) 
AS 
(
	SELECT cust.CustomerID
	FROM Sales.SalesOrderHeader soheader
	RIGHT JOIN Sales.Customer cust ON soheader.CustomerID = cust.CustomerID
	WHERE SalesOrderID IS NULL
)
SELECT * FROM CustomersWithoutOrder;
	


--4 USING EXIST
SELECT cForcustomer.CustomerID 
from Sales.Customer cForcustomer 
where not exists (SELECT sForSales.customerID
					from Sales.SalesOrderHeader as  sForSales 
					where sForSales.customerId=cForCustomer.customerID)