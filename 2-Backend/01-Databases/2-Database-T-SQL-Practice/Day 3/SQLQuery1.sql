	--1.	Display the Department id, name and id and the name of its manager.
select
	d.Dnum,
	d.Dname,
	e.SSN SSNmanager,
	e.Fname + ' ' + e.Lname [manager name]
from
	Departments d
	inner join Employee e on e.SSN = d.MGRSSN 
	--2.	Display the name of the departments and the name of the projects under its control.
select
	d.Dname,
	p.Pname
from
	Departments d
	inner join Project p on d.Dnum = p.Dnum 
	--3.	Display the full data about all the dependence associated with the name of the employee they depend on him/her.
select
	e.Fname + ' ' + e.Lname Ename,
	d.*
from
	Employee e
	right join Dependent d on e.SSN = d.ESSN 
	--4.	Display the Id, name and location of the projects in Cairo or Alex city.
select
	Pnumber,
	Pname,
	Plocation
from
	Project
where
	City in ('Cairo', 'Alex') 
	--5.	Display the Projects full data of the projects with a name starts with "a" letter.
select
	*
from
	Project
where
	Pname like 'a%' 
	--6.	display all the employees in department 30 whose salary from 1000 to 2000 LE monthly
select
	*
from
	Employee
where
	Dno = 30
	and Salary between 1000
	and 2000 
	--7.	Retrieve the names of all employees in department 10 who works more than or equal10 hours per week on "AL Rabwah" project.
select
	e.Fname + ' ' + e.Lname name
from
	Employee e
	inner join Works_for w on e.SSN = w.ESSn
	and e.Dno = 10
	and w.Hours >= 10
	inner join Project p on p.Pnumber = w.Pno
	and p.Pname = 'AL Rabwah' 
	--8.	Find the names of the employees who directly supervised with Kamel Mohamed.
select
	e.Fname + ' ' + e.Lname name
from
	Employee e,
	Employee s
where
	s.SSN = e.Superssn
	and s.Fname = 'Kamel'
	and s.Lname = 'Mohamed' 
	--9.	Retrieve the names of all employees and the names of the projects they are working on, sorted by the project name.
select
	e.Fname + ' ' + e.Lname name,
	p.Pname
from
	Employee e
	inner join Works_for w on e.SSN = w.ESSn
	inner join Project p on p.Pnumber = w.Pno
order by
	(p.Pname) 
	--10.	For each project located in Cairo City , find the project number, the controlling department name ,the department manager last name ,address and birthdate.
select
	p.Pname,
	d.Dname,
	e.Lname,
	e.Address,
	e.Bdate
from
	Project p
	inner join Departments d on d.Dnum = p.Dnum
	and p.City = 'Cairo'
	inner join Employee e on e.SSN = d.MGRSSN 
	--11.	Display All Data of the managers
select
	e.*
from
	Departments d
	inner join Employee e on e.SSN = d.MGRSSN 
	--12.	Display All Employees data and the data of their dependents even if they have no dependents
select
	*
from
	Employee e
	left join Dependent d on e.SSN = d.ESSN 
	--13.	Insert your personal data to the employee table as a new employee in department number 30, SSN = 102672, Superssn = 112233, salary=3000.
insert into
	Employee
values
	(
		'Ibrahim',
		'Radi',
		102672,
		'01-01-1990',
		'alex',
		'M',
		3000,
		112233,
		30
	) 
	--14.	Insert another employee with personal data your friend as new employee in department number 30, SSN = 102660, but don�t enter any value for salary or supervisor number to him.
insert into
	Employee (Fname, Lname, SSN, Bdate, Address, Sex, Dno)
values
	(
		'Hamada',
		'A.',
		102660,
		'01-01-1990',
		'alex',
		'M',
		30
	) 
	--15.	Upgrade your salary by 20 % of its last value.
update
	Employee
set
	Salary *= 1.2
where
	Fname = 'Ibrahim'