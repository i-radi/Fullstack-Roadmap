--1
select SalesOrderID, ShipDate 
from Sales.SalesOrderHeader
where ShipDate between '7/28/2002' and '7/29/2014'
--2
select ProductID, Name
from Production.Product
where StandardCost < 110
--3
select ProductID, Name
from Production.Product
where Weight is null
--4
select *
from Production.Product
where color in('Black','Silver','Red')
--5
select *
from Production.Product
where Name like 'B%'
--6
UPDATE Production.ProductDescription
SET Description = 'Chromoly steel_High of defects'
WHERE ProductDescriptionID = 3

select *
from Production.ProductDescription
where Description like '%[_]%'
--7
select sum(TotalDue) TotalDue, OrderDate
from Sales.SalesOrderHeader 
where OrderDate between '7/1/2001' and '7/31/2014'
group by OrderDate
-- or
-- having OrderDate between '7/1/2001' and '7/31/2014'
--8
select distinct HireDate
from HumanResources.Employee
--9
select avg(ListPrice)
from(select distinct ListPrice from Production.Product) as newtable
--10
--select 'The ['+name+'] is only! ['+convert(varchar(20),ListPrice)+']' as"The [product name] is only! [List price]"
select concat('The [',name,'] is only! [',ListPrice,']') as"The [product name] is only! [List price]"
from Production.Product
where ListPrice between  100 and 120
order by ListPrice
--11
select rowguid ,Name, SalesPersonID, Demographics into store_Archive
from Sales.Store

select rowguid ,Name, SalesPersonID, Demographics into store_Archive2
from Sales.Store where 1=2

select * from store_Archive
select * from store_Archive2
--12
select format(getdate(),'dd-MM-yyyy')
union
select format(getdate(),'dddd MMMM yyyy')
union
select format(getdate(),'ddd MMM yy')
union
select format(getdate(),'dd-MM-yyyy hh:mm:ss')
union
select format(getdate(),'dd-MM-yyyy hh:mm:ss tt')








