--Assignment 5
--Write a Procedure supplying name information from the Person.Person table and accepting a filter for the first name. 
--Alter the above Store Procedure to supply Default Values if user does not enter any value.( Use AdventureWorks)
alter procedure sp_Person_name @fname varchar(20)='Sharon'
as
BEGIN
	select * from Person.Person where FirstName=@fname
END
exec sp_Person_name 
exec sp_person_name 'mike'
