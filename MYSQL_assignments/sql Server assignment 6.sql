--Exercise 6.
-----------
--Write a trigger for the Product table to ensure the list price can never be raised more than 15 Percent in a single change.
--Modify the above trigger to execute its check code only if the ListPrice column is   updated (Use AdventureWorks Database).

CREATE TRIGGER TriggerTOCheckPriceRise
ON Production.Product
AFTER UPDATE
AS
BEGIN
	IF UPDATE(ListPrice)
		BEGIN
			UPDATE Production.Product
			SET ListPrice = IIF((ins.ListPrice - del.ListPrice) > del.ListPrice*0.15, del.ListPrice, ins.ListPrice)
			FROM deleted AS del, Production.Product AS prod
			INNER JOIN inserted AS ins ON ins.ProductID = prod.ProductID
		END
END
UPDATE Production.Product SET ListPrice = 2000 WHERE ProductID = 420
