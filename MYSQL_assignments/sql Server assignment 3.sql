--Exercise 3.
-----------
--Show the most recent five orders that were purchased from account numbers 
--that have spent more than $70,000 with AdventureWorks.
SELECT TOP 5 salesOrderID,AccountNumber,OrderDate
FROM Sales.SalesOrderHeader
Where AccountNumber
IN(SELECT AccountNumber 
	from Sales.SalesOrderHeader 
	group by AccountNumber 
	having sum(SubTotal)>70000)
order by OrderDate desc;