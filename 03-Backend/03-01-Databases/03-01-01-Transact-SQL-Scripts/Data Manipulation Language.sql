USE DemoDB;
GO

INSERT INTO demo.Companies (CompanyId, CompanyName) VALUES (101, N'Company A');

INSERT INTO demo.Companies (CompanyName, CompanyId) VALUES (N'Company B', 102);

INSERT INTO demo.Companies  VALUES (103, N'Company C');

INSERT INTO demo.Companies  VALUES 
           (104, N'Company D'),
           (105, N'Company E'),
           (106, N'Company F'),
           (107, N'Company G');
GO


INSERT INTO demo.Managers (ManagerId ,Email) VALUES (201, 'peter@fake.com');
INSERT INTO demo.Managers (ManagerId ,Email) VALUES (202, 'mike@fake.com');
INSERT INTO demo.Managers (ManagerId ,Email) VALUES (203, 'reem@fake.com');
INSERT INTO demo.Managers (ManagerId ,Email) VALUES (204, 'salah@fake.com'); 

GO
INSERT INTO demo.Technology(TechnologyId , Name) VALUES (301, 'SQL SERVER');
INSERT INTO demo.Technology(TechnologyId , Name) VALUES (302, 'ASP NET CORE');
INSERT INTO demo.Technology(TechnologyId , Name) VALUES (303, 'ANGULAR');
INSERT INTO demo.Technology(TechnologyId , Name) VALUES (304, 'REACT');
INSERT INTO demo.Technology(TechnologyId , Name) VALUES (305, 'WPF');
INSERT INTO demo.Technology(TechnologyId , Name) VALUES (306, 'ANDROID');
INSERT INTO demo.Technology(TechnologyId , Name) VALUES (307, 'ORACLE');
INSERT INTO demo.Technology(TechnologyId , Name) VALUES (308, 'PHP'); 

GO

INSERT INTO demo.Projects ( ProjectId, Title, ManegerId, StartDate, InitialCost, Parked, CompanyId)
     VALUES ( 401, 'CMS', 201, '2022-01-01', 15000000, 0, 101),
            ( 402, 'ERP', 202, '2022-02-01', 20000000, 0, 102),
            ( 403, 'CMS', 203, '2022-03-01', 15000000, 0, 105),
            ( 404, 'Authenticator', 204, '2022-04-01', 150000, 0, 101),
            ( 405, 'CRM-DESKTOP', 203, '2022-05-01', 20000000, 0, 104),
            ( 406, 'ERP', 204, '2022-06-01', 20000000, 0, 105),
            ( 407, 'HUB', 204, '2022-06-01', 20000000, 1, 104);

GO

INSERT INTO demo.ProjectTechnology (ProjectId, TechnologyId) VALUES 
        ( 401, 301), 
        ( 401, 302),
		( 401, 303),
		( 402, 301), 
        ( 402, 302),
		( 402, 304),
		( 403, 301), 
        ( 403, 302),
		( 403, 308),
		( 404, 306),
		( 405, 307),
		( 405, 305),
		( 406, 307),
		( 406, 308);
GO

-- SELECT

SELECT ProjectId, Title, ManegerId, StartDate, InitialCost, Parked, CompanyId
FROM demo.Projects;

SELECT *
FROM demo.Projects;

SELECT ProjectId, Title
FROM demo.Projects;

-- WHERE 
SELECT * FROM demo.Projects WHERE InitialCost >= 1000000;
SELECT * FROM demo.Projects WHERE NOT InitialCost >= 1000000;
SELECT * FROM demo.Projects WHERE InitialCost >= 1000000 AND StartDate >= '2022-03-01';
SELECT * FROM demo.Projects WHERE InitialCost >= 1000000 OR StartDate >= '2022-03-01';

-- LIKE (%, _)
 -- LIKE xx% starts with
 SELECT * FROM demo.Projects WHERE Title like 'C%'
  -- LIKE %xx ends with
 SELECT * FROM demo.Projects WHERE Title like '%P'
   -- LIKE %xx% contains 
 SELECT * FROM demo.Projects WHERE Title like '%DESK%'
   -- LIKE _R%
    SELECT * FROM demo.Projects WHERE Title like '_R_';
    SELECT * FROM demo.Projects WHERE InitialCost like '_5%';

-- TOP
   SELECT TOP 3 * From demo.Projects
   SELECT TOP 2 PERCENT *  From demo.Projects

-- ORDER BY
SELECT * FROM demo.Projects ORDER BY StartDate;
SELECT * FROM demo.Projects ORDER BY StartDate DESC;
SELECT * FROM demo.Projects ORDER BY InitialCost, StartDate DESC;

-- GROUP BY

SELECT Title, COUNT(*)  FROM demo.Projects GROUP BY Title;

SELECT ManegerId, COUNT(*) 
     FROM demo.Projects
	  WHERE Parked = 0 
	 GROUP BY ManegerId 
	  HAVING COUNT(*) >= 2;
 
 -- DISTINT 
 SELECT DISTINCT Title  FROM demo.Projects
  SELECT DISTINCT InitialCost  FROM demo.Projects

-- Tables JOIN

SELECT * FROM demo.Projects;
SELECT * FROM demo.Managers;

-- ProjectId,  TITLE, Manager_Email
SELECT * FROM demo.Projects, demo.Managers;
SELECT ProjectId, Title, Email FROM demo.Projects, demo.Managers; -- Cartisian Product
SELECT ProjectId, Title, Email, demo.Managers.ManagerId, demo.Projects.ManegerId FROM demo.Projects, demo.Managers 
WHERE demo.Projects.ManegerId = demo.Managers.ManagerId;

-- INNET JOIN Match in two tables


SELECT 
  (P.ProjectId) AS N'رقم المشروع'
, (P.Title) AS N'عنوان المشروع'
, (M.Email) AS N'البريد الالكتروني لمدير المشروع' FROM 
demo.Projects AS P INNER JOIN demo.Managers AS M 
ON P.ManegerId = M.ManagerId;

-- LEFT JOIN ( ALL ROWS FROM LEFT TABLE EVEN NO MATCH

SELECT * FROM demo.COMPANIES;
SELECT * FROM demo.Projects;

SELECT 
  (P.ProjectId)
, (P.Title)
, (C.CompanyName) FROM 
demo.Projects AS P LEFT JOIN demo.Companies AS C 
ON P.CompanyId = C.CompanyId;

SELECT 
  (P.ProjectId)
, (P.Title)
, (C.CompanyId)
, (C.CompanyName) FROM 
 demo.Companies AS C LEFT JOIN  demo.Projects AS P
ON P.CompanyId = C.CompanyId;

-- LEFT JOIN ( ALL ROWS FROM RIGHT TABLE EVEN NO MATCH
SELECT 
  (P.ProjectId)
, (P.Title)
, (C.CompanyName) FROM 
demo.Projects AS P RIGHT JOIN demo.Companies AS C 
ON P.CompanyId = C.CompanyId;

-- LEFT JOIN ( ALL ROWS FROM RIGHT TABLE EVEN NO MATCH
SELECT 
  (P.ProjectId)
, (P.Title)
, (C.CompanyName) FROM 
demo.Projects AS P FULL JOIN demo.Companies AS C 
ON P.CompanyId = C.CompanyId;


-- UPDATE
UPDATE demo.Projects 
SET StartDate = '2022-07-10'
WHERE ProjectId = 407;

-- DELETE 

DELETE FROM demo.Projects WHERE ProjectId = 406;

DROP TABLE demo.PROJECTS;
TRUNCATE TABLE demo.PROJECTS;

-- SUBQUERY
SELECT * FROM demo.Projects;
SELECT * FROM demo.ProjectTechnology;
SELECT * FROM demo.Technology;


UPDATE demo.Projects SET InitialCost = InitialCost * 1.05 
WHERE 
ProjectId IN ( SELECT ProjectId FROM demo.ProjectTechnology 
WHERE TechnologyId = (SELECT TechnologyId FROM demo.Technology WHERE Name = 'ORACLE'));