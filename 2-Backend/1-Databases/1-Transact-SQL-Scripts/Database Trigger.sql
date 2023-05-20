create trigger PreventDDL
on database
for
create_table,alter_table,drop_table
as
print 'you can not create ,alter and drop table in this database'
rollback;

create table testTrigger (id int)
--------------------------------------------------------------------

create trigger PreventDML
on demo.Managers
for
insert,update,delete
as
print 'you can not insert ,update and delete table in this database'
rollback;
--------------------------------------------------------------------

create trigger DetectInsert
on demo.Managers
after insert
as 
begin
insert into Companies values(1,'Radi')
end
--------------------------------------------------------------------

create table Attendence (Id int Identity(1,1) primary key ,FirstName nvarchar(50),attendTime time)
create table Absense (Id int Identity(1,1) primary key ,FirstName nvarchar(50),attendTime time)
--------------------------------------------------------------------

create trigger RecordAsAbsense
on Attendence
instead of insert
as 
begin 
insert into Absense
select inserted.FirstName,inserted.attendTime
from inserted
where cast(attendTime as time) > '08:00:00'

insert into Attendence
select inserted.FirstName,inserted.attendTime
from inserted
where cast(attendTime as time) <= '08:00:00'
end
--------------------------------------------------------------------

insert into Attendence values ('mohamed' , '07:50:22')
insert into Attendence values ('mohamed' , '08:05:02')