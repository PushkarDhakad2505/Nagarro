--exercise 1
------------
--	question 1.1:-
	-----------
	--1.	Display the number of records in the [SalesPerson] table. (Schema(s) involved: Sales)
	SELECT count(*) as NumberOfRecordfrom 
	fROM Sales.SalesPerson;
--	question 1.2:-
	-----------
	--2.Select both the FirstName and LastName of records from the Person table where the FirstName begins with the letter ‘B’. 
	SELECT FirstName,LastName
	FROM Person.Person
	WHERE FirstName  like 'B%' or  FirstName  like 'b%'
--	question 1.3:-
	-----------
	--3.	Select a list of FirstName and LastName for employees
	--		where Title is one of Design Engineer, Tool Designer or Marketing Assistant
	SELECT Person.FirstName,Person.LastName
	FROM Person.Person
	INNER JOIN
	HumanResources.Employee
	ON Person.Person.BusinessEntityID=HumanResources.Employee.BusinessEntityID
	AND Employee.JobTitle IN ('Design Engineer','Tool Designer','Marketing Assistant')


--	question 1.4:-
	-----------
	--Display the Name and Color of the Product with the maximum weight
	sELECT name,color
	FROM Production.Product 
	WHERE Weight=(SELECT max(Weight) 
					FROM Production.Product  );


					
--	question 1.5:-
	-----------
	--Display Description and MaxQty fields from the SpecialOffer table. 
	--Some of the MaxQty values are NULL, in this case display the value 0.00 instead

	SELECT description,COALESCE(MaxQty,0.00)
	FROM Sales.SpecialOffer

					
--	question 1.6:-
	-----------
	--Display the overall Average of the [CurrencyRate].
	--[AverageRate] values for the exchange rate ‘USD’ to ‘GBP’ for the year 2005
	--i.e. FromCurrencyCode = ‘USD’ and ToCurrencyCode = ‘GBP’. 
	SELECT avg(AverageRate)
	from Sales.CurrencyRate
	where FromCurrencyCode = 'USD'
		and ToCurrencyCode = 'GBP'
		and  YEAR(CurrencyRateDate)=2012

					
--	question 1.7:-
	-----------
	--7. Display the FirstName and LastName of records from the Person table 
	--where FirstName contains the letters ‘ss’.
	--Display an additional column with sequential numbers for each row 
	--returned beginning at integer 1.

	SELECT row_number () over (order by firstName) as serialNumber ,
	firstName,lastName
	FROM person.Person
	WHERE FirstName like '%SS%' or FirstName like '%ss%'

	--	question 1.8:-
	-----------
	--8.Sales people receive various commission rates that belong to 1 of 4 bands. (Schema(s) involved: Sales)
		--CommissionPct	Commission Band
		--0.00	Band 0
		--Up To 1%	Band 1
		--Up To 1.5%	Band 2
		--Greater 1.5%	Band 3

		--Display the [SalesPersonID] with an additional column entitled ‘Commission Band’ indicating the appropriate band as above.

	select BusinessEntityID ,
	CASE
		When commissionPct=0.00 then 'BAND 0'
		When commissionPct>0.00 AND commissionPct<=0.01 then 'BAND 1'
		When commissionPct>0.01 AND commissionPct<=0.015 then 'BAND 2'
		When commissionPct>0.015 then 'BAND 3'
	END
	as CommissionBand
	from Sales.SalesPerson

	
	--	question 1.9:-
	-----------
	--9.	Display the managerial hierarchy from Ruth Ellerbrock (person type – EM) up to CEO Ken Sanchez.
	-- Hint: use [uspGetEmployeeManagers] (Schema(s) involved: [Person], [HumanResources]) 
	declare @identityNumber int;
	select @identityNumber=BusinessEntityID
	from Person.Person 
	where FirstName='Ruth' and 
		  LastName='Ellerbrock' and
		  PersonType='Em'

	EXECUTE uspGetEmployeeManagers @BusinessEntityID=@identityNumber
	

	--	question 1.10:-
	-----------
	--Display the ProductId of the product with the largest stock level.
	--Hint: Use the Scalar-valued function [dbo]. [UfnGetStock].
	--(Schema(s) involved: Production)
	select Max(dbo.UfnGetStock(ProductID)) as maximumStrockProductID
	from Production.Product 
