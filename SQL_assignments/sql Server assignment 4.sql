--Exercise 4.
-----------
--Create a function that takes as inputs a SalesOrderID, a Currency Code, and a date,
--and returns a table of all the SalesOrderDetail rows for that Sales Order 
--including Quantity, ProductID, UnitPrice, and
--the unit price converted to the target currency based on the end of day rate for the date provided. 
--Exchange rates can be found in the Sales.CurrencyRate table. ( Use AdventureWorks)



CREATE FUNCTION Sales.userFunctionForGettingValues(@SalesOrderID int, @CurrencyCode varchar(20) ,@CurrencyRateDate datetime)
	RETURNS TABLE 
AS
	RETURN
	WITH Products
	AS (
		SELECT *
		FROM Sales.SalesOrderDetail AS SaleOrdDetail
		WHERE SaleOrdDetail.SalesOrderID = @SalesOrderID
	)
	SELECT prod.ProductID, prod.OrderQty, prod.UnitPrice, prod.UnitPrice*CurrRate.EndOfDayRate AS 'Price'
	FROM Products AS prod, Sales.CurrencyRate AS CurrRate
	WHERE CurrRate.ToCurrencyCode = @CurrencyCode
		AND CurrRate.CurrencyRateDate = @CurrencyRateDate


SELECT * FROM Sales.userFunctionForGettingValues(43659, 'CNY', '2011-06-01 00:00:00.000');

