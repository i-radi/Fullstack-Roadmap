--1
create Proc getStNum
as
	select d.Dept_Name, count(s.St_Id) students
	from Student s, Department d where d.Dept_Id = s.Dept_Id
	group by d.Dept_Name
execute getStNum
--2
create function GetDataP1(@Pname varchar(20))
returns table
	as
	return
	(
		select e.SSN ,e.FNAME,e.LNAME from EMPLOYEE e inner join WORKS_ON w on e.SSN = w.ESSN
		inner join PROJECT p on p.PNUMBER = w.PNO and p.PNAME = @Pname
	)

alter proc checkNumEmp
as	
	if (select count(SSN) from GetDataP1('p1')) >= 3
		select 'The number of employees in the project p1 is 3 or more'
			union
		select FNAME+' '+LNAME from GetDataP1('p1')
	else
		select 'The following employees work for the project p1'
			union
		select FNAME+' '+LNAME from GetDataP1('p1')
execute checkNumEmp


--3
create Proc insteadEmp @oldId int, @newId int,@proNum int
as	
	begin try
		update WORKS_ON
		set ESSN = @newId
		where ESSN = @oldId and PNO = @proNum
	end try
	begin catch
		select 'Error'
	end catch


execute insteadEmp 1,2,20
--4
create table Audit 
(ProjectNo int,
UserName int,
ModifiedBate date,
Budget_Old int,
Budget_New int
)

create trigger tBudget
on project
after update
as
	if update(Budget)
		begin
			declare @old int,@new int,@Pno int
			select @Pno=PNUMBER from deleted
			select @old=Budget from deleted
			select @new=Budget from inserted
			insert into Audit
			values(@Pno,suser_name(),getdate(),@old,@new)
		end
--5
create trigger tDepInsert
on Department
instead of insert
as
	select 'not allowed insert a new record in this table'

insert into Department (Dept_Id,Dept_Name) values (50,'Medical')
--6
create trigger tEmpInsert
on employee
instead of insert
as
--or if datename(m,getdate()) = 'March'
	if format(getdate(),'MM')= 3 
		select 'not allowed'
	else
		insert into EMPLOYEE values ((select SSN from inserted ),
		(select FNAME from inserted ),(select LNAME from inserted ),
		(select BDATE from inserted ),(select ADDRESS from inserted ),
		(select SEX from inserted ),(select SALARY from inserted ),
		(select SUPERSSN from inserted ),(select DNO from inserted )
		)
insert into EMPLOYEE (SSN,FNAME) values (110011,'ali')
--7
create table Student_Audit 
(ServerUserName varchar(50),
InsertedDate date,
Note varchar(100)
)

create trigger tStInsert
on student
after insert
as
	declare @x int 
	select @x= St_Id from inserted
	insert into Student_Audit
	values(suser_name(),getdate(),concat(suser_name()
	,' Insert New Row with Key= ',@x,' in table student'))
--8
create trigger tStdelete
on student
instead of delete
as
	declare @x int 
	select @x= St_Id from deleted
	insert into Student_Audit
	values(suser_name(),getdate(),concat(suser_name()
	,' try to delete Row with Key= ',@x))




















