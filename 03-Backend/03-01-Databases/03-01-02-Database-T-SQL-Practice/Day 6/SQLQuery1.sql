--1
create function GetMonth(@date datetime)
returns Varchar(10)
	begin
		declare @mon varchar(10)=datename(m,@date)
		return @mon	
	end
select dbo.GetMonth(getdate())
--2
create function GetValues(@x int, @y int)
returns @t table
			(
			 num int
			)
as
	begin
		select @x += 1
		while @x < @y
			begin
				insert into @t
				select @x				
				select @x += 1
			end
		return 
	end
select * from GetValues(2,7)
--3
Create function GetStInfo(@id int)
returns table
	as
	return
	(
	 select s.St_Fname+' '+s.St_Lname [full name], d.Dept_Name 
	 from Student s, Department d
	 where d.Dept_Id = s.Dept_Id and s.St_Id = @id	
	)
select * from GetStInfo(3)
--4
create function IsNullName(@id int)
returns Varchar(40)
	begin
		declare @fName varchar(30)
		declare @lName varchar(30)
		select @fName=St_Fname, @lName=St_Lname from Student where St_Id = @id
		declare @msg varchar(40)
		if @fName is null and @lName is null
			select @msg = 'First name & last name are  null'
		else if @fName is null
			select @msg = 'First name is null'
		else if @lName is null
			select @msg = 'last name is null'
		else
			select @msg = 'First name & last name are not null'
		return @msg
	end
select dbo.IsNullName(21)
--5
Create function GetInsInfo(@id int)
returns table
	as
	return
	(
	 select d.Dept_Name, i.Ins_Name,d.Manager_hiredate from Instructor i, Department d
	 where i.Ins_Id = d.Dept_Manager  and d.Dept_Manager = @id
	)
select * from GetInsInfo(11)
--6
create function GetStuds(@format varchar(20))
returns @t table
			(
			 id int,
			 sname varchar(20)
			)
as
	begin
		if @format='first name'
			insert into @t
			select st_id,isnull(st_fname,'no name') from Student
		else if @format='last name'
			insert into @t
			select st_id,isnull(st_Lname,'no name') from Student
		else if @format='full name'
			insert into @t 
			select st_id,concat(st_fname,' ',st_lname) name from Student
		return 
	end
select * from getStuds('last name')
--7
select St_Id, substring(St_Fname,1,len(St_Fname)-1) fName
from Student
--8
delete from Stud_Course
where St_Id in(
	select St_Id from student where Dept_Id =
		(select Dept_Id from Department where Dept_Name = 'SD'))
--9
Merge into  LastTransactions as T  
using DailyTransactions as S		
on T.id=S.id
when matched then
	update 
		Set T.amount=S.amount
when not matched then
	insert 
	values(S.id,S.amount)
select * from LastTransactions
--Bonus
-- create a table with hierarchyid data type column
-- and two other columns
create table SimpleDemo  
(Node hierarchyid not null,  
[Geographical Name] nvarchar(30) not null,  
[Geographical Type] nvarchar(9) NULL);
 
insert SimpleDemo  
values
-- root level data
('/', 'Earth', 'Planet') 
-- first level data
,('/1/','Asia','Continent')
,('/2/','Africa','Continent')
,('/3/','Oceania','Continent')
-- second level data 
,('/1/1/','China','Country')
,('/1/2/','Japan','Country')
,('/1/3/','South Korea','Country')
,('/2/1/','South Africa','Country')
,('/2/2/','Egypt','Country')
,('/3/1/','Australia','Country')
-- third level data
,('/1/1/1/','Beijing','City')
,('/1/2/1/','Tokyo','City')
,('/1/3/1/','Seoul','City')
,('/2/1/1/','Pretoria','City')
,('/2/2/1/','Cairo','City')
,('/3/1/1/','Canberra','City')
 

-- display without sort order returns 
-- rows in input order
select 
 Node.ToString() AS [Node Text]
,Node.GetLevel() [Node Level]
,[Geographical Name]
,[Geographical Type]   
from SimpleDemo	
order by Node.ToString()