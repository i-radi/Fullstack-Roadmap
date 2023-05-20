--1
select Fname+' '+Lname fullname, e.sex
from Employee e ,Dependent d 
where e.SSN = d.ESSN
and e.Sex = 'F' and d.Sex = 'F'
union
select Fname+' '+Lname fullname, e.sex
from Employee e ,Dependent d 
where e.SSN = d.ESSN
and e.Sex = 'M' and d.Sex = 'M'
--2
select p.Pname, sum(w.Hours) [total hours/week ]
from Project p inner join Works_for w
on p.Pnumber = w.Pno
group by p.Pname
--3
select *
from Departments where Dnum in
	(select top 1 Dno from Employee ORDER BY SSN)
	--or
select d.*
from Departments d,Employee e where d.Dnum = e.Dno and SSN =
	(select min(ssn) from Employee )
--4
select d.Dname, max(e.salary) max, min(e.salary) min, avg(e.salary) avg
from Employee e inner join Departments d on d.Dnum = e.Dno
group by d.dname
--5
select e.Fname+' '+e.Lname fullname
from Employee e inner join Departments d
on e.SSN = d.MGRSSN and e.SSN not in (select ESSN from Dependent )
--6
select d.Dnum, d.Dname, count(*) [# of employees]
from Departments d inner join Employee e
on d.Dnum = e.Dno
group by d.Dname,d.Dnum
having avg(e.salary) < (select AVG(salary)from Employee) 
--7
select e.Fname+' '+e.Lname fullname, p.Pname
from Employee e inner join Works_for w on e.SSN = w.ESSn
inner join Project p on p.Pnumber = w.Pno
order by e.Dno, e.Lname, e.Fname
--8
select top 2 Fname+' '+Lname fullname, salary
from Employee
order by salary desc
	--or
select Salary
from Employee where SSN in (select top 2 ssn from Employee order by Salary desc)
--9
select Fname+' '+Lname fullname
from Employee
intersect
select Dependent_name
from Dependent
--10
select SSN, Fname+' '+Lname fullname
from Employee
where EXISTS (select d.ESSN from Dependent d where Employee.SSN = d.ESSN)
--11
insert into Departments
(dname,dnum,MGRSSN,[MGRStart Date])
values('DEPT IT',100,112233,'11-1-2006')
--12
update Employee
set Dno = 100
where ssn = 968574

update Employee
set Dno = 20
where ssn = 102672

update Employee
set Superssn = 102672
where ssn = 102660 
--13
delete from Dependent where ESSN = 223344

update Departments
set MGRSSN = 102672
where MGRSSN = 223344

update Employee
set Superssn = 102672
where Superssn = 223344

update Works_for
set ESSn = 102672
where ESSn = 223344

delete from Employee where SSN = 223344
--14
update Employee
set Salary *= 1.3
where ssn in (select ssn from Employee e inner join Works_for w 
				on e.SSN = w.ESSn inner join Project p 
				on p.Pnumber = w.Pno and p.Pname = 'Al Rabwah')
