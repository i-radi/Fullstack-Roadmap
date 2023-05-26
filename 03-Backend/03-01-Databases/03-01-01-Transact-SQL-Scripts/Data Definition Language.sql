--Comments
create database DemoDB;
go

use DemoDB;
go

create schema demo;
go

create table demo.Companies
(
	CompanyId int primary key identity(1,1),
	CompanyName varchar(50) not null
);
go

alter table demo.Companies
alter column CompanyName varchar(60);

alter table demo.Companies
add CompanyPhone varchar(11);

alter table demo.Companies
drop column CompanyPhone;

create table demo.Managers
(
	ManagerId int not null ,
	Email varchar(100) not null,
	primary key(ManagerId)

);
go

-- Add Unique constraint
alter table demo.Managers
add constraint unique_email unique(Email);

create table demo.Projects
(
	ProjectId int primary key ,
	Title varchar(100) not null,
	ManegerId int foreign key references demo.Managers(ManagerId) not null,
	StartDate datetime2 not null,
	InitialCost decimal(18,2) not null, --9999.99
	Parked bit not null,
	CompanyId int not null,
	foreign key (CompanyId) references demo.Companies(CompanyId)
);
go

alter table demo.Projects
add constraint default_parked default 0 for Parked;

create table demo.Technology
(
	TechnologyId int primary key ,
	Name varchar(100) not null
);
go

create table demo.ProjectTechnology
(
	ProjectId int foreign key references demo.Projects(ProjectId) not null,
	TechnologyId int foreign key references demo.Technology(TechnologyId) not null,
	primary key (ProjectId,TechnologyId)
	
);
go

create table demo.blablabla
(
	blablablaId int primary key ,
	Name varchar(100) not null
);
go

drop table blablabla;

use master
go
drop database DemoDB