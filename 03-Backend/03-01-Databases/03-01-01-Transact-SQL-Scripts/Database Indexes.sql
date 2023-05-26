-- flush the plan cache
dbcc freeproccache
dbcc freeproccache

-- get execution time dowm to millisocends
set statistics time, IO on

-- column index
create index managers_email_IX
on demo.Managers(Email);

-- multi column index
create index projects_date_cost_IX
on demo.Projects(StartDate,InitialCost);

-- drop multi column index
drop index projects_date_cost_IX on demo.Projects;

-- create index with include
create index projects_date_cost_IX
on demo.Projects(StartDate)
include (InitialCost);