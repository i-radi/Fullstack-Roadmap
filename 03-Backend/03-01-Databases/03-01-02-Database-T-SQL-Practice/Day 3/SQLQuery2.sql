create table Instructor
(
 id int primary key identity,
 fName varchar(20),
 lName varchar(20),
 BoD date,
 overtime int,
 salary int default 3000,
 hiredate date default getdate(),
 address varchar(20) default 'cairo',
 age as(year(getdate())-year(BoD)),
 netsal as(isnull(salary,0)+isnull(overtime,0)),
 constraint c1 check(address in('alex','cairo')),
 constraint c2 check(salary between 1000 and 5000),
 constraint c3 unique(overtime)
)

create table Course
(
 cid int primary key identity,
 cName varchar(20),
 duration varchar(20) unique
)

create table Teach
(
 id int,
 cid int,
 constraint c4 foreign key(id) references Instructor(id)
			on delete cascade on update cascade,
 constraint c5 foreign key(cid) references Course(cid)
			on delete cascade on update cascade
)

create table Lab
(
 cid int,
 lid int identity,
 loc varchar(20),
 capacity varchar(20),
 constraint c6 primary key(cid,lid),
 constraint c7 check(capacity < 20),
 constraint c8 foreign key(cid) references Course(cid)
			on delete cascade on update cascade
)