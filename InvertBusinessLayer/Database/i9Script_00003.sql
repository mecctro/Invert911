

---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------

drop TABLE i9SecurityGroupModule

drop TABLE i9SecurityGroupTask
 
---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------

ALTER TABLE i9Module
	DROP CONSTRAINT pk_i9Module

ALTER TABLE i9Module
 ADD CONSTRAINT pk_i9Module PRIMARY KEY (ModuleName)

---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------

SELECT name
FROM sys.key_constraints
WHERE type = 'PK' AND OBJECT_NAME(parent_object_id) = N'i9SecurityTask';


ALTER TABLE i9SecurityTask
   drop CONSTRAINT pk_i9SecurityTask
   
ALTER TABLE i9SecurityTask
   ADD CONSTRAINT pk_i9SecurityTask PRIMARY KEY (TaskName)


---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------


CREATE TABLE [i9SecurityGroupTask](
	[i9SecurityGroupTaskID] [uniqueidentifier] NOT NULL,
	[i9AgencyID] [uniqueidentifier] NOT NULL,
	[SecurityGroupName] varchar(50) NOT NULL,
	[TaskName] varchar(50) NOT NULL
)


ALTER TABLE i9SecurityGroupTask
 ADD CONSTRAINT pk_i9SecurityGroupTask PRIMARY KEY (i9SecurityGroupTaskID)


ALTER TABLE i9SecurityGroupTask
ADD CONSTRAINT fk_i9SecurityGroupTask_i9Agency
FOREIGN KEY (i9AgencyID)
REFERENCES i9Agency(i9AgencyID)


--ALTER TABLE i9SecurityGroupTask
--ADD CONSTRAINT fk_i9SecurityGroupTask_i9SecurityGroup
--FOREIGN KEY (SecurityGroupName)
--REFERENCES i9SecurityGroup(SecurityGroupName)



---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------


CREATE TABLE [i9SecurityGroupModule](
	[i9SecurityGroupModuleID] [uniqueidentifier] NOT NULL,
	[i9AgencyID] [uniqueidentifier] NOT NULL,
	[SecurityGroupName] varchar(50) NOT NULL,
	[ModuleName] varchar(50) NOT NULL
)


ALTER TABLE i9SecurityGroupModule
ADD CONSTRAINT fk_i9SecurityGroupModule_i9Agency
FOREIGN KEY (i9AgencyID)
REFERENCES i9Agency(i9AgencyID)


ALTER TABLE i9SecurityGroupModule
 ADD CONSTRAINT pk_i9SecurityGroupModule PRIMARY KEY (i9SecurityGroupModuleID)
 

 --ALTER TABLE i9SecurityGroupModule
--ADD CONSTRAINT fk_i9SecurityGroupTask_i9Module
--FOREIGN KEY (ModuleName)
--REFERENCES i9Module(ModuleName)

--INSERT INTO i9SecurityTask ([i9SecurityTaskID],[TaskName],[TaskDesc],[Enabled]) VALUES (NEWID(),'LawIncidentAdd', '', 1)


---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------

ALTER TABLE i9DynamicEntryConfig
    ADD IsReadOnly int null

Update i9DynamicEntryConfig set IsReadOnly = 0

ALTER TABLE i9DynamicEntryConfig
    alter column IsReadOnly int not null

---------------------------------------------------------------------------------
--  Adding Email to the Personnel Table 
---------------------------------------------------------------------------------

ALTER TABLE i9SysPersonnel
   Add Email varchar(100) null
  
update i9SysPersonnel set Email = 'eric@Invert911.com'
  
ALTER TABLE i9SysPersonnel
   alter column Email varchar(100) not null 

---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------

ALTER TABLE i9SysPersonnel
   Add DateTimeInserted DateTime null

ALTER TABLE i9SysPersonnel
   Add DateTimeUpdated DateTime null
     
update i9SysPersonnel set DateTimeInserted = CURRENT_TIMESTAMP, DateTimeUpdated = CURRENT_TIMESTAMP
  
ALTER TABLE i9SysPersonnel
   Alter Column DateTimeInserted DateTime not null

ALTER TABLE i9SysPersonnel
   Alter Column DateTimeUpdated DateTime not null

---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------

ALTER TABLE i9SysPersonnel
   Add DemoUser int null
   
Update i9SysPersonnel set DemoUser = 1
   
ALTER TABLE i9SysPersonnel
   Alter Column DemoUser int not null
      
---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------

ALTER TABLE i9SysPersonnel
   Add ActivationGuid [uniqueidentifier] null

---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------

drop table i9AVL
drop table i9AVLEvent
drop table i9AVLHistory

---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------

ALTER TABLE i9DynamicEntryConfig
   Add CodeSetName varchar(100) null
