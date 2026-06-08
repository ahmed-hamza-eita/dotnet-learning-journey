CREATE INDEX PROJECT_TECHNOLOGY_IX
ON PM.ProjectTechnology(PRJNO);

SELECT PRJNO from  PM.ProjectTechnology

--Multi coulmn index
CREATE INDEX PROJECT_TECHNOLOGIES_IX
ON PM.ProjectTechnology(PRJNO,TechnologyId);

SELECT * from  PM.ProjectTechnology