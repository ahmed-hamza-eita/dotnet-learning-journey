USE PMDB


--Insert
Insert Into pm.Compaines (CRNNO,Name) Values(101,N'Company A');
Insert Into pm.Compaines Values(102,N'Company B'),
							   (103,N'Company C'),
							   (104,N'Company D'),
							   (105,N'Company E'),
							   (106,N'Company F');
													

INSERT INTO PM.Managers (Id ,Email) VALUES (201, 'Ahmed@fake.com');
INSERT INTO PM.Managers (Id ,Email) VALUES (202, 'hamza@fake.com');
INSERT INTO PM.Managers (Id ,Email) VALUES (203, 'iman@fake.com');
INSERT INTO PM.Managers (Id ,Email) VALUES (204, 'eita@fake.com'); 													

INSERT INTO PM.Technology(Id , Name) VALUES (301, 'SQL SERVER');
INSERT INTO PM.Technology(Id , Name) VALUES (302, 'ASP NET CORE');
INSERT INTO PM.Technology(Id , Name) VALUES (303, 'ANGULAR');
INSERT INTO PM.Technology(Id , Name) VALUES (304, 'REACT');
INSERT INTO PM.Technology(Id , Name) VALUES (305, 'WPF');
INSERT INTO PM.Technology(Id , Name) VALUES (306, 'ANDROID');
INSERT INTO PM.Technology(Id , Name) VALUES (307, 'ORACLE');
INSERT INTO PM.Technology(Id , Name) VALUES (308, 'PHP'); 


INSERT INTO PM.Projects ( PRJNO, Title , ManagerId, StartDate, InitialCost,  CRNNO)
     VALUES ( 401, 'CMS', 201, '2022-01-01', 15000000, 101),
            ( 402, 'ERP', 202, '2022-02-01', 20000000,   102),
            ( 403, 'CMS', 203, '2022-03-01', 15000000,   105),
            ( 404, 'Authenticator', 204, '2022-04-01', 150000,   101),
            ( 405, 'CRM-DESKTOP', 203, '2022-05-01', 20000000,   104),
            ( 406, 'ERP', 204, '2022-06-01', 20000000,   105),
            ( 407, 'HUB', 204, '2022-06-01', 20000000,   104);



UPDATE pm.Projects
SET Parked =0;

UPDATE pm.Projects
SET Parked =1
WHERE InitialCost >= 20000000; 

INSERT INTO PM.ProjectTechnology (PRJNO, TechnologyId) VALUES 
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



-- SELECT
select * from [pm].[Projects]

SELECT *
FROM PM.Projects;

SELECT PRJNO, Title
FROM PM.Projects;


---Where 
select * from [pm].[Projects]
where InitialCost >=20000000.00 and Title = 'ERP'

--Like --> copmare data based on patterns
  -- LIKE xx% starts with
SELECT * FROM PM.Projects WHERE Title like 'C%'
  -- LIKE %xx ends with
SELECT * FROM PM.Projects WHERE Title like '%P'
   -- LIKE %xx% contains 
SELECT * FROM PM.Projects WHERE Title like '%DESK%'
   -- LIKE _R%
SELECT * FROM PM.Projects WHERE Title like '_R_';
SELECT * FROM PM.Projects WHERE InitialCost like '_5%';
SELECT * FROM PM.Projects WHERE Title like '___';


--Top
select top 2 * from [pm].[Projects]
select top 3 Percent * from [pm].[Projects]


--order by
select * from [pm].[Projects]
where InitialCost >=20000000.00
order by CRNNO DESC

--Group by

select title from [pm].[Projects] 
group by title

SELECT Title FROM pm.Projects
WHERE InitialCost >= 20000000.00
GROUP BY Title
ORDER BY Title DESC;

select title, count (*) as NumOfTitles from [pm].[Projects] 
group by title


select
	ManagerId , count(*)
from pm.Projects 
	where parked =0
group by ManagerId
	HAVING count(*) <2


--Distict 
select Distinct  title from [pm].[Projects] 

--Cartisian Product
Select PRJNO ,Title , Email from [pm].[Projects],pm.managers   

--Joins
SELECT p.PRJNO ,p.Title , m.Email FROM pm.Projects as p, pm.Managers as m
where p.ManagerId = m.Id

SELECT p.PRJNO ,p.Title , m.Email FROM pm.Projects AS p
LEFT JOIN 
pm.managers AS m
ON p.ManagerId = m.Id

--subquery
select * from pm.Projects
select * from pm.ProjectTechnology
select * from pm.Technology

update pm.Projects 
set InitialCost = InitialCost *1.05 where PRJNO in (
	select PRJNO from pm.ProjectTechnology where  TechnologyId = (
			select id from pm.Technology where name ='ORACLE'
		)
	)
