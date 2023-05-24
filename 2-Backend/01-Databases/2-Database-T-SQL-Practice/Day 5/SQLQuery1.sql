--1
select count(*) st_numbers 
from Student
where St_Age is not null
--2
select distinct Ins_Name
from Instructor
--3
select St_Id[Student ID],  isnull(St_Fname+' '+St_Lname,'no name')[Student Full Name], d.Dept_Name [Department name]
from Student s right join  Department d on d.Dept_Id=s.Dept_Id
--4
select i.Ins_Name, d.Dept_Name
from Department d right join Instructor i
on d.Dept_Id = i.Dept_Id
--5
select s.St_Fname+' '+s.St_Lname [Student Full Name], c.Crs_Name
from Student s inner join Stud_Course sc
on s.St_Id = sc.St_Id and sc.Grade is not null
inner join Course c
on c.Crs_Id = sc.Crs_Id
--6
select t.Top_Name,count(c.Crs_Id) [Course number]
from Topic t, Course c
where t.Top_Id = c.Top_Id
group by t.Top_Name
--7
select min(Salary)[min salary], max(Salary)[max salary]from Instructor
--8
select *
from Instructor where Salary <= (select avg(isnull(Salary,0))from Instructor)
--9
select Dept_Name from Department where Dept_Id = 
			(select Dept_Id from Instructor where salary = 
					(select min(Salary)from Instructor))
--10
select distinct top 2 Salary
from Instructor
order by Salary desc
--11
select Ins_Name, COALESCE(convert(varchar(20),salary),'bonus') salary
from Instructor
--12
select st.St_Fname, sp.St_Fname+' '+sp.St_Lname[supervisor name], sp.St_Address [supervisor Address], sp.St_Age [supervisor Age]
from Student st inner join Student sp
on sp.St_Id = st.St_super
--13
Select Salary
From (select *,Row_number() over(partition by dept_id order by salary desc) as DR
	  from Instructor) as Newtable
where DR in (1,2) and Salary is not null and Dept_Id is not null
--14
Select St_Fname+' '+St_Lname [st for each dept]
From (select *,Row_number() over(partition by dept_id order by newid()) as RN
	  from Student) as Newtable
where RN = 1
--15
delete from Stud_Course
where St_Id in(
	select St_Id from student where Dept_Id =
		(select Dept_Id from Department where Dept_Name = 'SD'))
--16
Merge into  LastTransactions as T  
using DailyTransactions as S		
on T.id=S.id
when matched then
	update 
		Set T.amount=S.amount
when not matched then
	insert 
	values(S.id,S.amount);

select * from LastTransactions

