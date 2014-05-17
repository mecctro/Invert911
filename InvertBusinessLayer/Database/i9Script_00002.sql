
INSERT [i9DynamicEntry] ([ModuleSection], [ModuleSectionDesc], [DynamicEntryTable], [LastUpdate]) 
VALUES (N'Incident.Person.Name', N'Incident Person Name', N'i9Person', CAST(0x0000A175015BB4A2 AS DateTime))

INSERT [i9DynamicEntry] ([ModuleSection], [ModuleSectionDesc], [DynamicEntryTable], [LastUpdate]) 
VALUES (N'Incident.Person.AKA', N'Incident Person AKA', N'i9PersonAKA', CAST(0x0000A175015BB4A2 AS DateTime))

INSERT [i9DynamicEntry] ([ModuleSection], [ModuleSectionDesc], [DynamicEntryTable], [LastUpdate]) 
VALUES (N'Incident.Person.SMT', N'Incident.Person.SMT', N'i9PersonSMT', CAST(0x0000A175015BB4A2 AS DateTime))

INSERT [i9DynamicEntry] ([ModuleSection], [ModuleSectionDesc], [DynamicEntryTable], [LastUpdate]) 
VALUES (N'Incident.Person.Arrest', N'Incident.Person.Arrest', N'i9PersonArrestee', CAST(0x0000A175015BB4A2 AS DateTime))

INSERT [i9DynamicEntry] ([ModuleSection], [ModuleSectionDesc], [DynamicEntryTable], [LastUpdate]) 
VALUES (N'Incident.Person.MissingPerson', N'Incident.Person.MissingPerson', N'i9PersonMissing', CAST(0x0000A175015BB4A2 AS DateTime))

INSERT [i9DynamicEntry] ([ModuleSection], [ModuleSectionDesc], [DynamicEntryTable], [LastUpdate]) 
VALUES (N'Incident.Vehicle.General', N'Incident.Vehicle.General', N'i9Vehicle', CAST(0x0000A175015BB4A2 AS DateTime))

INSERT [i9DynamicEntry] ([ModuleSection], [ModuleSectionDesc], [DynamicEntryTable], [LastUpdate]) 
VALUES (N'Incident.Vehicle.Recovery', N'Incident.Vehicle.Recovery', N'i9VehicleRecovery', CAST(0x0000A175015BB4A2 AS DateTime))

INSERT [i9DynamicEntry] ([ModuleSection], [ModuleSectionDesc], [DynamicEntryTable], [LastUpdate]) 
VALUES (N'Incident.Vehicle.Towed', N'Incident.Vehicle.Towed', N'i9VehicleTowed', CAST(0x0000A175015BB4A2 AS DateTime))

INSERT [i9DynamicEntry] ([ModuleSection], [ModuleSectionDesc], [DynamicEntryTable], [LastUpdate]) 
VALUES (N'Incident.Property.General', N'Incident.Property.General', N'i9Property', CAST(0x0000A175015BB4A2 AS DateTime))

INSERT [i9DynamicEntry] ([ModuleSection], [ModuleSectionDesc], [DynamicEntryTable], [LastUpdate]) 
VALUES (N'Incident.Arrest.General', N'Incident.Arrest.General', N'i9PersonArrestee', CAST(0x0000A175015BB4A2 AS DateTime))

INSERT [i9DynamicEntry] ([ModuleSection], [ModuleSectionDesc], [DynamicEntryTable], [LastUpdate]) 
VALUES (N'Incident.Arrest.Charges', N'Incident.Arrest.Charges', N'i9Charge', CAST(0x0000A175015BB4A2 AS DateTime))

INSERT [i9DynamicEntry] ([ModuleSection], [ModuleSectionDesc], [DynamicEntryTable], [LastUpdate]) 
VALUES (N'Incident.Offense.General', N'Incident.Offense.General', N'i9Offense', CAST(0x0000A175015BB4A2 AS DateTime))

INSERT [i9DynamicEntry] ([ModuleSection], [ModuleSectionDesc], [DynamicEntryTable], [LastUpdate]) 
VALUES (N'Location', N'Location', N'i9Location', CAST(0x0000A175015BB4A2 AS DateTime))

--INSERT [i9DynamicEntry] ([ModuleSection], [ModuleSectionDesc], [DynamicEntryTable], [LastUpdate]) 
--VALUES (N'Incident.Person.Employment', N'Incident.Person.Employment', N'i9LawIncident', CAST(0x0000A175015BB4A2 AS DateTime))

--INSERT [i9DynamicEntry] ([ModuleSection], [ModuleSectionDesc], [DynamicEntryTable], [LastUpdate]) 
--VALUES (N'Incident.Person.School', N'Incident.Person.School', N'i9LawIncident', CAST(0x0000A175015BB4A2 AS DateTime))

--INSERT [i9DynamicEntry] ([ModuleSection], [ModuleSectionDesc], [DynamicEntryTable], [LastUpdate]) 
--VALUES (N'Incident.Person.Citation', N'Incident.Person.Citation', N'i9LawIncident', CAST(0x0000A175015BB4A2 AS DateTime))

--INSERT [i9DynamicEntry] ([ModuleSection], [ModuleSectionDesc], [DynamicEntryTable], [LastUpdate]) 
--VALUES (N'Incident.Person.DUI', N'Incident.Person.DUI', N'i9LawIncident', CAST(0x0000A175015BB4A2 AS DateTime))

--INSERT [i9DynamicEntry] ([ModuleSection], [ModuleSectionDesc], [DynamicEntryTable], [LastUpdate]) 
--VALUES (N'Incident.Person.Medical', N'Incident.Person.Medical', N'i9LawIncident', CAST(0x0000A175015BB4A2 AS DateTime))

--INSERT [i9DynamicEntry] ([ModuleSection], [ModuleSectionDesc], [DynamicEntryTable], [LastUpdate]) 
--VALUES (N'Incident.Person.Appearance', N'Incident.Person.Appearance', N'i9LawIncident', CAST(0x0000A175015BB4A2 AS DateTime))



alter table i9Location
	add i9ModuleSectionID varchar(25) not null 


ALTER TABLE i9Location
ADD CONSTRAINT fk_i9Location_i9ModuleSection
FOREIGN KEY (i9ModuleSectionID)
REFERENCES i9ModuleSection(i9ModuleSectionID)


alter table i9Location
	add LocationRemarks varchar(100) null 

	
alter table i9Location
	add Beat varchar(20) null 



---------------------------------------------------------------------------------
--  Don't Need any more:
---------------------------------------------------------------------------------
CREATE TABLE [i9PersonLocation](
	[i9PersonLocationID] [uniqueidentifier] NOT NULL,
	[i9PersonID] [uniqueidentifier] NOT NULL,
	[i9LocationID] [uniqueidentifier] NOT NULL
)

ALTER TABLE i9PersonLocation
 ADD CONSTRAINT pk_i9PersonLocationID PRIMARY KEY (i9PersonLocationId)

ALTER TABLE i9PersonLocation
ADD CONSTRAINT fk_i9PersonLocation_i9Person
FOREIGN KEY (i9PersonID)
REFERENCES i9Person(i9PersonID)

ALTER TABLE i9PersonLocation
ADD CONSTRAINT fk_i9PersonLocation_i9Location
FOREIGN KEY (i9LocationID)
REFERENCES i9Location(i9LocationID)	
	

Drop table i9PersonLocation


---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------

alter table i9Location
	add [i9PersonID] [uniqueidentifier] NULL


ALTER TABLE i9Location
ADD CONSTRAINT fk_i9Location_i9Person
FOREIGN KEY (i9PersonID)
REFERENCES i9Person(i9PersonID)


---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------

alter table i9Person
	add [i9AgencyID] [uniqueidentifier] NULL


ALTER TABLE i9Person
ADD CONSTRAINT fk_i9Person_i9Agency
FOREIGN KEY (i9AgencyID)
REFERENCES i9Agency(i9AgencyID)

update i9Person set i9AgencyID = '53A05F38-FC9C-4260-B939-CB1F3998C4D4'

alter table i9Person
	alter column [i9AgencyID] [uniqueidentifier] NOT NULL

	
---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------


alter table i9VehicleRecovery
	add [i9EventID] [uniqueidentifier] NOT NULL


ALTER TABLE i9VehicleRecovery
ADD CONSTRAINT fk_i9VehicleRecovery_i9Event
FOREIGN KEY (i9EventID)
REFERENCES i9Event(i9EventID)


alter table i9VehicleTowed
	add [i9EventID] [uniqueidentifier] NOT NULL


ALTER TABLE i9VehicleTowed
ADD CONSTRAINT fk_i9VehicleTowed_i9Event
FOREIGN KEY (i9EventID)
REFERENCES i9Event(i9EventID)

---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------

alter table i9VehicleTowed
	add [i9VehicleID] [uniqueidentifier] NOT NULL


ALTER TABLE i9VehicleTowed
ADD CONSTRAINT fk_i9VehicleTowed_i9Vehicle
FOREIGN KEY (i9VehicleID)
REFERENCES i9Vehicle(i9VehicleID)


alter table i9VehicleRecovery
	add [i9VehicleID] [uniqueidentifier] NOT NULL

ALTER TABLE i9VehicleRecovery
ADD CONSTRAINT fk_i9VehicleRecovery_i9Vehicle
FOREIGN KEY (i9VehicleID)
REFERENCES i9Vehicle(i9VehicleID)


---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------

alter table i9Attachment
	add [i9EventID] [uniqueidentifier] NOT NULL

ALTER TABLE i9Attachment
ADD CONSTRAINT fk_i9Attachment_i9Event
FOREIGN KEY (i9EventID)
REFERENCES i9Event(i9EventID)


alter table i9AttachmentData
	add [i9EventID] [uniqueidentifier] NOT NULL

ALTER TABLE i9AttachmentData
ADD CONSTRAINT fk_i9AttachmentData_i9Event
FOREIGN KEY (i9EventID)
REFERENCES i9Event(i9EventID)


alter table i9AttachmentLink
	add [i9EventID] [uniqueidentifier] NOT NULL

ALTER TABLE i9AttachmentLink
ADD CONSTRAINT fk_i9AttachmentLink_i9Event
FOREIGN KEY (i9EventID)
REFERENCES i9Event(i9EventID)


---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------

alter table i9VehicleRecovery
	add Notes varchar(100) null 

alter table i9VehicleRecovery
	add Condition varchar(50) null 



---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------

alter table i9Location
	add [i9VehicleID] [uniqueidentifier] NULL

ALTER TABLE i9Location
ADD CONSTRAINT fk_i9Location_i9Vehicle
FOREIGN KEY (i9VehicleID)
REFERENCES i9Vehicle(i9VehicleID)

---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------

alter table i9VehicleTowed
	add Notes varchar(100) null 

alter table i9VehicleTowed
	add TowedDate varchar(100) null 

alter table i9VehicleTowed
	add Condition varchar(50) null 

---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------

CREATE TABLE [i9Narrative](
	[i9NarrativeID] [uniqueidentifier] NOT NULL,
	[i9EventID] [uniqueidentifier] NOT NULL,
	[SummaryNarrative] [Text] NULL,
	[Narrative] [Text] NULL
)

ALTER TABLE i9Narrative
 ADD CONSTRAINT pk_i9NarrativeID PRIMARY KEY (i9NarrativeID)

ALTER TABLE i9Narrative
ADD CONSTRAINT fk_i9Narrative_i9Event
FOREIGN KEY (i9EventID)
REFERENCES i9Event(i9EventID)

ALTER TABLE i9Narrative
 ADD SummaryNarrativeFormat Text NULL

ALTER TABLE i9Narrative
 ADD NarrativeFormat Text NULL

---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------

ALTER TABLE i9DynamicEntryConfig
 ADD DisplayOrder Decimal(20) NULL
 

 ---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------

ALTER TABLE i9DynamicEntryConfig
 ADD DisplayOrder real NULL
 

---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------

alter table i9Person
	add i9ModuleSectionID varchar(25) null 


ALTER TABLE i9Person
ADD CONSTRAINT fk_i9Person_i9ModuleSection
FOREIGN KEY (i9ModuleSectionID)
REFERENCES i9ModuleSection(i9ModuleSectionID)

update i9Person set i9ModuleSectionID = 'LawIncidentPerson'


INSERT [i9DynamicEntry] ([ModuleSection], [ModuleSectionDesc], [DynamicEntryTable], [LastUpdate]) 
VALUES (N'Incident.Person.PersonAKA', N'Incident.Person.PersonAKA', N'i9Person', CAST(0x0000A175015BB4A2 AS DateTime))


alter table i9Person
	alter column i9ModuleSectionID varchar(25) not null 

---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------

alter table i9Person
	add [i9PersonAKAID] [uniqueidentifier] NULL

ALTER TABLE i9Person
ADD CONSTRAINT fk_i9Person_i9Person
FOREIGN KEY (i9PersonAKAID)
REFERENCES i9Person(i9PersonID)

---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------

alter table i9PersonSMT
	add [i9EventID] [uniqueidentifier] NOT NULL


ALTER TABLE i9PersonSMT
ADD CONSTRAINT fk_i9PersonSMT_i9Event
FOREIGN KEY (i9EventID)
REFERENCES i9Event(i9EventID)

---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------

alter table i9Attachment
    alter column Capturedate datetime null


alter table i9Attachment
    Add AttachmentData image null

---------------------------------------------------------------------------------
-- i9SysLog
---------------------------------------------------------------------------------

alter table i9SysLog
	add [i9AgencyID] [uniqueidentifier] NULL

ALTER TABLE i9SysLog
  ADD CONSTRAINT fk_i9SysLog_i9Agency
  FOREIGN KEY (i9AgencyID)
  REFERENCES i9Agency(i9AgencyID)

alter table i9SysLog
	add [BadgeNumber] varchar(25) null 

alter table i9SysLog
	add [LogType] varchar(25) null 

alter table i9SysLog
	add [AgencyName] varchar(60) null 

alter table i9SysLog
	alter column [LogDescription] varchar(1000) null



---------------------------------------------------------------------------------
--  Security Groups
---------------------------------------------------------------------------------
Drop Table i9SecurityGroups

CREATE TABLE [i9SecurityGroup](
	[i9SecurityGroupID] [uniqueidentifier] NOT NULL,
	[i9AgencyID] [uniqueidentifier] NOT NULL,
	[SecurityGroupName] varchar(50) NULL,
	[SecurityGroupDesc] varchar(100) NULL
)

ALTER TABLE i9SecurityGroup
ADD CONSTRAINT fk_i9SecurityGroup_i9Agency
FOREIGN KEY (i9AgencyID)
REFERENCES i9Agency(i9AgencyID)

ALTER TABLE i9SecurityGroup
 ADD CONSTRAINT pk_i9SecurityGroup PRIMARY KEY (i9SecurityGroupId)


---------------------------------------------------------------------------------
--  Security Task
---------------------------------------------------------------------------------
CREATE TABLE [i9SecurityTask](
	[i9SecurityTaskID] [uniqueidentifier] NOT NULL,
	[TaskName] varchar(50) NOT NULL,
	[TaskDesc] varchar(100) NOT NULL,
	[Enable] [int] NOT NULL
)

ALTER TABLE i9SecurityTask
 ADD CONSTRAINT pk_i9SecurityTask PRIMARY KEY (i9SecurityTaskID)

---------------------------------------------------------------------------------
--  Security Groups Module
---------------------------------------------------------------------------------
CREATE TABLE [i9SecurityGroupModule](
	[i9SecurityGroupModuleID] [uniqueidentifier] NOT NULL,
	[i9SecurityGroupID] [uniqueidentifier] NOT NULL,
	[i9ModuleID] [uniqueidentifier] NOT NULL
)

ALTER TABLE i9SecurityGroupModule
ADD CONSTRAINT fk_i9SecurityGroupModule_i9SecurityGroup
FOREIGN KEY (i9SecurityGroupID)
REFERENCES i9SecurityGroup(i9SecurityGroupID)

ALTER TABLE i9SecurityGroupModule
ADD CONSTRAINT fk_i9SecurityGroupModule_i9Module
FOREIGN KEY (i9ModuleID)
REFERENCES i9Module(i9ModuleID)

ALTER TABLE i9SecurityGroupModule
 ADD CONSTRAINT pk_i9SecurityGroupModule PRIMARY KEY (i9SecurityGroupModuleID)

---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------

CREATE TABLE [i9SecurityGroupTask](
	[i9SecurityGroupTaskID] [uniqueidentifier] NOT NULL,
	[i9SecurityGroupID] [uniqueidentifier] NOT NULL,
	[i9SecurityTaskID] [uniqueidentifier] NOT NULL
)

ALTER TABLE i9SecurityGroupTask
ADD CONSTRAINT fk_i9SecurityGroupTask_i9SecurityGroup
FOREIGN KEY (i9SecurityGroupID)
REFERENCES i9SecurityGroup(i9SecurityGroupID)

ALTER TABLE i9SecurityGroupTask
ADD CONSTRAINT fk_i9SecurityGroupTask_i9SecurityTask
FOREIGN KEY (i9SecurityTaskID)
REFERENCES i9SecurityTask(i9SecurityTaskID)

ALTER TABLE i9SecurityGroupTask
 ADD CONSTRAINT pk_i9SecurityGroupTask PRIMARY KEY (i9SecurityGroupTaskID)

---------------------------------------------------------------------------------
-- 
---------------------------------------------------------------------------------



