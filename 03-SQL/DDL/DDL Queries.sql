----------- DDL -----------
CREATE DATABASE pmdb;

 

use pmdb;

 


CREATE SCHEMA pm;

 


CREATE Table pm.Compaines(
Id int primary key Identity(1,1) --Auto Increment seed 1 increment 1
Name varchar(50) not null
)

--Edit Column Name
EXEC sp_rename 'pm.Compaines.Id', 'CRNNO', 'COLUMN';

--Make a default value for a column
Alter Table pm.Compaines
Add Constraint Default_Value Default 'N/N' For Name



CREATE Table pm.Managers(
Id int not null,
Name varchar(50) not null,
Email varchar(100)  not null,
Primary Key(Id)
)

--Edit datatype of exists col
Alter Table pm.Managers
Alter column Name varchar(100) null
 

--Add Unique Constraint
Alter Table pm.Managers
Add	Constraint Unique_Email UNIQUE(Email)

 

CREATE TABLE pm.Projects(
PRJNO int primary key ,
Title varchar(50) not null,
ManagerId INT NOT NULL REFERENCES pm.Managers(Id) --FOREIGN KEY (ManagerId) REFERENCES pm.Manager(Id)
);

--Add new column
Alter TABLE pm.Projects
Add Parked int null


--Edit Column Name
EXEC sp_rename 'pm.Projects.CompainesID', 'CRNNO', 'COLUMN';

 

CREATE TABLE pm.Technology( 
Id INT PRIMARY KEY,
Name varchar(50) not null
);

 


CREATE TABLE pm.ProjectTechnology(
PRJNO INT NOT NULL REFERENCES pm.Projects(PRJNO),
Id INT NOT NULL REFERENCES pm.Technology(Id),
PRIMARY KEY(PRJNO,Id)
)
EXEC sp_rename 'pm.ProjectTechnology.Id','TechnologyId','Column' 
 

--Add Column in Exist Table
ALTER TABLE PM.Projects
ADD InitialCost decimal(15,2) not null

--Add Column in Exist Table
ALTER TABLE PM.Projects
ADD CompainesID INT NOT NULL REFERENCES pm.Compaines

--Edit Column Datatype
ALTER TABLE PM.Projects
Alter Column Title varchar(100) not null

--Remove column
ALTER TABLE TableNAme
DROP Column columnNAme

--Remove Table
DROP TABLE tableName;

--Remove DB
DROP DATABASE DB_Name	


-- 1. Create a new table with IDENTITY
CREATE TABLE pm.Companies_New(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL
);

-- 2. Copy data (do NOT insert Id)
INSERT INTO pm.Companies_New(Name)
SELECT Name FROM pm.Compaines;

-- 3. Drop old table
DROP TABLE pm.Compaines;

-- 4. Rename new table
EXEC sp_rename 'pm.Companies_New', 'Compaines';




Alter Table pm.Projects
Add StartDate DATETIME2 not null   






 
