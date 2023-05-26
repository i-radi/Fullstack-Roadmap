--1
create view VstudCrs
as
	select concat(s.St_Fname,' ',s.St_Lname) fullName, c.Crs_Name
	from student s inner join Stud_Course sc on s.St_Id = sc.St_Id
	and sc.Grade > 50
	inner join Course c on c.Crs_Id = sc.Crs_Id
select * from VstudCrs
--2
create view VMngTopic (Manager, Topic)
with encryption
as
	select distinct i.Ins_Name, t.Top_Name
	from Department d inner join Instructor i on i.Ins_Id = d.Dept_Manager
	inner join Ins_Course ic on i.Ins_Id = ic.Ins_Id
	inner join Course c on c.Crs_Id = ic.Crs_Id
	inner join Topic t on t.Top_Id = c.Top_Id
select * from VMngTopic 
--sp_helptext 'VMngTopic'
--3
create view VInsDept (Ins_name, Dept_name)
as
	select i.Ins_Name, d.Dept_Name
	from Department d inner join Instructor i
	on d.Dept_Id = i.Dept_Id and d.Dept_Name in ('SD','Java')
	with check option
select * from VInsDept
--4
create view V1
as
	select * from Student
	where St_Address in ('Alex','Cairo')
	with check option
select * from V1
--5
use CompanyDB
go
create view Vproj
as
	select p.PNAME, w.ESSN
	from PROJECT p inner join WORKS_ON w on p.PNUMBER = w.PNO 
select * from Vproj
--6
Create Schema Company 
alter schema Company transfer department

Create Schema [Human Resource] 
alter schema [Human Resource]  transfer employee
--7
use ITI
go
create clustered index i1        --Error  : Find PK (clustered index)
on Department(manager_Hiredate)
create nonclustered index i2     --Done
on Department(manager_Hiredate)
--8
create unique index i3           --Error  : Find Duplicated Value
on student(st_age) 
create nonclustered index i4     --Done
on student(st_age)
--9
use CompanyDB
go
declare c1 Cursor
for select salary
	from [Human Resource].Employee
for update
declare @sal int
open c1
fetch c1 into @sal
while @@fetch_status=0
	begin
		if @sal < 3000
			update [Human Resource].Employee
				set salary=@sal*1.10
			where current of c1
		else
			update [Human Resource].Employee
				set Salary=@sal*1.20
			where current of c1
		fetch c1 into @sal
	end
close c1
deallocate c1

select * from [Human Resource].EMPLOYEE
--10
Declare C1 Cursor
for select d.dept_name, i.ins_name from department d 
		inner join instructor i on d.dept_manager = i.ins_Id 
for read only
declare @dept_name varchar(20),@ins_name varchar(20)
open C1
Fetch C1 into @dept_name,@ins_name
while @@FETCH_STATUS=0
	begin
		select @dept_name,@ins_name
		Fetch C1 into @dept_name,@ins_name
	end
close C1
Deallocate C1
--11
use ITI
go
declare c1 cursor
for select Ins_Name
	from Instructor
	where Ins_Name is not null
for read only

declare @name varchar(20),@all_names varchar(300)=''
open c1
fetch c1 into @name
while @@FETCH_STATUS=0
	begin
		set @all_names=concat(@all_names,',',@name)
		fetch c1 into @name 
	end
select @all_names
close c1
deallocate C1
--12
--View VMngTopic is encrypted
--in another file









