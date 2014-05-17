



---------------------------------------------------------------------------------
-- i9SecurityGroupPersonnel
---------------------------------------------------------------------------------

CREATE TABLE [i9SecurityGroupPersonnel](
	[i9SecurityGroupPersonnelID] [uniqueidentifier] NOT NULL,
	[i9AgencyID] [uniqueidentifier] NOT NULL,
	[i9SysPersonnelID] [uniqueidentifier] NOT NULL,
	[i9SecurityGroupID] [uniqueidentifier] NOT NULL
)

ALTER TABLE i9SecurityGroupPersonnel
 ADD CONSTRAINT pk_i9SecurityGroupPersonnel PRIMARY KEY (i9SecurityGroupPersonnelID)

ALTER TABLE i9SecurityGroupPersonnel
ADD CONSTRAINT fk_i9SecurityGroupPersonnel_i9Agency
FOREIGN KEY (i9AgencyID)
REFERENCES i9Agency(i9AgencyID)

ALTER TABLE i9SecurityGroupPersonnel
ADD CONSTRAINT fk_i9SecurityGroupPersonnel_i9SysPersonnel
FOREIGN KEY (i9SysPersonnelID)
REFERENCES i9SysPersonnel(i9SysPersonnelID)

ALTER TABLE i9SecurityGroupPersonnel
ADD CONSTRAINT fk_i9SecurityGroupPersonnel_i9SecurityGroup
FOREIGN KEY (i9SecurityGroupID)
REFERENCES i9SecurityGroup(i9SecurityGroupID)

---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------

alter table i9SecurityTask
 drop column i9SecurityTaskID


---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------
 
INSERT INTO [i9SecurityTask] (TaskName, TaskDesc, Enabled) VALUES ('Admin_Login', '', 1)

INSERT INTO [i9SecurityTask] (TaskName, TaskDesc, Enabled) VALUES ('Admin_Personnel_New', '', 1)
INSERT INTO [i9SecurityTask] (TaskName, TaskDesc, Enabled) VALUES ('Admin_Personnel_Edit', '', 1)
INSERT INTO [i9SecurityTask] (TaskName, TaskDesc, Enabled) VALUES ('Admin_Personnel_Delete', '', 1)

INSERT INTO [i9SecurityTask] (TaskName, TaskDesc, Enabled) VALUES ('Admin_DynamicEntry_New', '', 1)
INSERT INTO [i9SecurityTask] (TaskName, TaskDesc, Enabled) VALUES ('Admin_DynamicEntry_Edit', '', 1)
INSERT INTO [i9SecurityTask] (TaskName, TaskDesc, Enabled) VALUES ('Admin_DynamicEntry_Delete', '', 1)

INSERT INTO [i9SecurityTask] (TaskName, TaskDesc, Enabled) VALUES ('Admin_Code_New', '', 1)
INSERT INTO [i9SecurityTask] (TaskName, TaskDesc, Enabled) VALUES ('Admin_Code_Edit', '', 1)
INSERT INTO [i9SecurityTask] (TaskName, TaskDesc, Enabled) VALUES ('Admin_Code_Delete', '', 1)

INSERT INTO [i9SecurityTask] (TaskName, TaskDesc, Enabled) VALUES ('Admin_SystemPerson_New', '', 1)
INSERT INTO [i9SecurityTask] (TaskName, TaskDesc, Enabled) VALUES ('Admin_SystemPerson_Edit', '', 1)
INSERT INTO [i9SecurityTask] (TaskName, TaskDesc, Enabled) VALUES ('Admin_SystemPerson_Delete', '', 1)

INSERT INTO [i9SecurityTask] (TaskName, TaskDesc, Enabled) VALUES ('Admin_Agency_New', '', 1)
INSERT INTO [i9SecurityTask] (TaskName, TaskDesc, Enabled) VALUES ('Admin_Agency_Edit', '', 1)
INSERT INTO [i9SecurityTask] (TaskName, TaskDesc, Enabled) VALUES ('Admin_Agency_Delete', '', 1)

INSERT INTO [i9SecurityTask] (TaskName, TaskDesc, Enabled) VALUES ('Admin_Security_New', '', 1)
INSERT INTO [i9SecurityTask] (TaskName, TaskDesc, Enabled) VALUES ('Admin_Security_Edit', '', 1)
INSERT INTO [i9SecurityTask] (TaskName, TaskDesc, Enabled) VALUES ('Admin_Security_Delete', '', 1)

INSERT INTO [i9SecurityTask] (TaskName, TaskDesc, Enabled) VALUES ('Admin_PersonnelGroups_New', '', 1)
INSERT INTO [i9SecurityTask] (TaskName, TaskDesc, Enabled) VALUES ('Admin_PersonnelGroups_Edit', '', 1)
INSERT INTO [i9SecurityTask] (TaskName, TaskDesc, Enabled) VALUES ('Admin_PersonnelGroups_Delete', '', 1)

INSERT INTO [i9SecurityTask] (TaskName, TaskDesc, Enabled) VALUES ('Law_Incident_New', '', 1)
INSERT INTO [i9SecurityTask] (TaskName, TaskDesc, Enabled) VALUES ('Law_Incident_Edit', '', 1)
INSERT INTO [i9SecurityTask] (TaskName, TaskDesc, Enabled) VALUES ('Law_Incident_Delete', '', 1)
INSERT INTO [i9SecurityTask] (TaskName, TaskDesc, Enabled) VALUES ('Law_Incident_Search', '', 1)
    


	
---------------------------------------------------------------------------------
-- PersonnelGroupsPage
---------------------------------------------------------------------------------

DELETE FROM [i9Module] WHERE [ModuleKey] = 'PersonnelGroups'
DELETE FROM [i9SecurityGroupModule] WHERE ModuleName = 'PersonnelGroups'


INSERT INTO [i9Module]
           ([ClassName]
           ,[ModuleName]
           ,[Section]
           ,[PopupPage]
           ,[DesktopEnabled]
           ,[MobileEnabled]
           ,[ModuleType]
           ,[FileName]
           ,[LastUpdate]
           ,[i9ModuleID]
           ,[ModuleKey])
     VALUES
           ('Invert911.InvertCommon.Modules.Admin.PersonnelGroupsPage'
           ,'Personnel Groups'
           ,'Administration'
           ,0
           ,1
           ,0
           ,'Page'
           ,'Invert911.InvertCommon.dll'
           ,null
           ,NEWID()
           ,'PersonnelGroups')


Insert INTO  [i9SecurityGroupModule] 
(  i9SecurityGroupModuleID,	i9AgencyID,	SecurityGroupName,	ModuleName )
VALUES
(
NEWID() , 
'53A05F38-FC9C-4260-B939-CB1F3998C4D4',	
'PoliceAdmin',
'Personnel Groups')



