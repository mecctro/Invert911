
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 01/08/2014 20:51:16
-- Generated from EDMX file: C:\Dev\PoliceRecords\InvertCommon\DataTypes\DataClasses\i9Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [i9database];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[fk_i9Arrest_i9Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Arrest] DROP CONSTRAINT [fk_i9Arrest_i9Event];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Attachment_i9Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Attachment] DROP CONSTRAINT [fk_i9Attachment_i9Event];
GO
IF OBJECT_ID(N'[dbo].[fk_i9AttachmentData_i9Attachment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9AttachmentData] DROP CONSTRAINT [fk_i9AttachmentData_i9Attachment];
GO
IF OBJECT_ID(N'[dbo].[fk_i9AttachmentData_i9Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9AttachmentData] DROP CONSTRAINT [fk_i9AttachmentData_i9Event];
GO
IF OBJECT_ID(N'[dbo].[fk_i9AttachmentLink_i9Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9AttachmentLink] DROP CONSTRAINT [fk_i9AttachmentLink_i9Event];
GO
IF OBJECT_ID(N'[dbo].[fk_i9AVL_i9Agency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9AVL] DROP CONSTRAINT [fk_i9AVL_i9Agency];
GO
IF OBJECT_ID(N'[dbo].[fk_i9AVLEvent_i9Agency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9AVLEvent] DROP CONSTRAINT [fk_i9AVLEvent_i9Agency];
GO
IF OBJECT_ID(N'[dbo].[fk_i9AVLEvent_i9Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9AVLEvent] DROP CONSTRAINT [fk_i9AVLEvent_i9Event];
GO
IF OBJECT_ID(N'[dbo].[fk_i9AVLHistory_i9Agency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9AVLHistory] DROP CONSTRAINT [fk_i9AVLHistory_i9Agency];
GO
IF OBJECT_ID(N'[dbo].[fk_i9CADServiceCall_i9Agency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9CADServiceCall] DROP CONSTRAINT [fk_i9CADServiceCall_i9Agency];
GO
IF OBJECT_ID(N'[dbo].[fk_i9CADServiceCall_i9Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9CADServiceCall] DROP CONSTRAINT [fk_i9CADServiceCall_i9Event];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Citation_i9Agency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Citation] DROP CONSTRAINT [fk_i9Citation_i9Agency];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Citation_i9Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Citation] DROP CONSTRAINT [fk_i9Citation_i9Event];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Code_i9Agency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Code] DROP CONSTRAINT [fk_i9Code_i9Agency];
GO
IF OBJECT_ID(N'[dbo].[fk_i9CodeSet_i9Agency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9CodeSet] DROP CONSTRAINT [fk_i9CodeSet_i9Agency];
GO
IF OBJECT_ID(N'[dbo].[fk_i9ConfigurationSetting_i9Agency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9ConfigurationSetting] DROP CONSTRAINT [fk_i9ConfigurationSetting_i9Agency];
GO
IF OBJECT_ID(N'[dbo].[fk_i9DynamicEntryConfig_i9Agency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9DynamicEntryConfig] DROP CONSTRAINT [fk_i9DynamicEntryConfig_i9Agency];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Event_i9Agency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Event] DROP CONSTRAINT [fk_i9Event_i9Agency];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Event_i9EventType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Event] DROP CONSTRAINT [fk_i9Event_i9EventType];
GO
IF OBJECT_ID(N'[dbo].[fk_i9FieldContact_i9Agency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9FieldContact] DROP CONSTRAINT [fk_i9FieldContact_i9Agency];
GO
IF OBJECT_ID(N'[dbo].[fk_i9FieldContact_i9Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9FieldContact] DROP CONSTRAINT [fk_i9FieldContact_i9Event];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Gang_i9Agency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Gang] DROP CONSTRAINT [fk_i9Gang_i9Agency];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Gang_i9Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Gang] DROP CONSTRAINT [fk_i9Gang_i9Event];
GO
IF OBJECT_ID(N'[dbo].[fk_i9LawIncident_i9Agency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9LawIncident] DROP CONSTRAINT [fk_i9LawIncident_i9Agency];
GO
IF OBJECT_ID(N'[dbo].[fk_i9LawIncident_i9Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9LawIncident] DROP CONSTRAINT [fk_i9LawIncident_i9Event];
GO
IF OBJECT_ID(N'[dbo].[FK_i9LawIncident_i9ModuleSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9LawIncident] DROP CONSTRAINT [FK_i9LawIncident_i9ModuleSection];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Location_i9Agency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Location] DROP CONSTRAINT [fk_i9Location_i9Agency];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Location_i9Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Location] DROP CONSTRAINT [fk_i9Location_i9Event];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Location_i9ModuleSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Location] DROP CONSTRAINT [fk_i9Location_i9ModuleSection];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Location_i9Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Location] DROP CONSTRAINT [fk_i9Location_i9Person];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Location_i9Vehicle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Location] DROP CONSTRAINT [fk_i9Location_i9Vehicle];
GO
IF OBJECT_ID(N'[dbo].[fk_i9MessageInbox_i9Agency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9MessageInbox] DROP CONSTRAINT [fk_i9MessageInbox_i9Agency];
GO
IF OBJECT_ID(N'[dbo].[fk_i9ModusOperandi_i9LawIncident]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9ModusOperandi] DROP CONSTRAINT [fk_i9ModusOperandi_i9LawIncident];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Narrative_i9Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Narrative] DROP CONSTRAINT [fk_i9Narrative_i9Event];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Offense_i9LawIncident]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Offense] DROP CONSTRAINT [fk_i9Offense_i9LawIncident];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Organization_i9Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Organization] DROP CONSTRAINT [fk_i9Organization_i9Event];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Pawn_i9Agency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Pawn] DROP CONSTRAINT [fk_i9Pawn_i9Agency];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Pawn_i9Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Pawn] DROP CONSTRAINT [fk_i9Pawn_i9Event];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Person_i9Agency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Person] DROP CONSTRAINT [fk_i9Person_i9Agency];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Person_i9Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Person] DROP CONSTRAINT [fk_i9Person_i9Event];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Person_i9ModuleSection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Person] DROP CONSTRAINT [fk_i9Person_i9ModuleSection];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Person_i9Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Person] DROP CONSTRAINT [fk_i9Person_i9Person];
GO
IF OBJECT_ID(N'[dbo].[fk_i9PersonArrestee_i9Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9PersonArrestee] DROP CONSTRAINT [fk_i9PersonArrestee_i9Person];
GO
IF OBJECT_ID(N'[dbo].[fk_i9PersonMissing_i9Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9PersonMissing] DROP CONSTRAINT [fk_i9PersonMissing_i9Person];
GO
IF OBJECT_ID(N'[dbo].[fk_i9PersonPhoto_i9Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9PersonPhoto] DROP CONSTRAINT [fk_i9PersonPhoto_i9Person];
GO
IF OBJECT_ID(N'[dbo].[fk_i9PersonRelated_i9Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9PersonRelated] DROP CONSTRAINT [fk_i9PersonRelated_i9Person];
GO
IF OBJECT_ID(N'[dbo].[fk_i9PersonRelated_i9Person_i9PersonIDRelated]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9PersonRelated] DROP CONSTRAINT [fk_i9PersonRelated_i9Person_i9PersonIDRelated];
GO
IF OBJECT_ID(N'[dbo].[fk_i9PersonSMT_i9Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9PersonSMT] DROP CONSTRAINT [fk_i9PersonSMT_i9Event];
GO
IF OBJECT_ID(N'[dbo].[fk_i9PersonSMT_i9Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9PersonSMT] DROP CONSTRAINT [fk_i9PersonSMT_i9Person];
GO
IF OBJECT_ID(N'[dbo].[fk_i9PersonSubject_i9Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9PersonSubject] DROP CONSTRAINT [fk_i9PersonSubject_i9Person];
GO
IF OBJECT_ID(N'[dbo].[fk_i9PersonVehicle_i9Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9PersonVehicle] DROP CONSTRAINT [fk_i9PersonVehicle_i9Person];
GO
IF OBJECT_ID(N'[dbo].[fk_i9PersonVehicle_i9Vehicle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9PersonVehicle] DROP CONSTRAINT [fk_i9PersonVehicle_i9Vehicle];
GO
IF OBJECT_ID(N'[dbo].[fk_i9PersonVictim_i9Person]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9PersonVictim] DROP CONSTRAINT [fk_i9PersonVictim_i9Person];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Property_i9Agency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Property] DROP CONSTRAINT [fk_i9Property_i9Agency];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Property_i9Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Property] DROP CONSTRAINT [fk_i9Property_i9Event];
GO
IF OBJECT_ID(N'[dbo].[fk_i9PropertyEvidence_i9Property]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9PropertyEvidence] DROP CONSTRAINT [fk_i9PropertyEvidence_i9Property];
GO
IF OBJECT_ID(N'[dbo].[fk_i9PropertyExplosive_i9Property]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9PropertyExplosive] DROP CONSTRAINT [fk_i9PropertyExplosive_i9Property];
GO
IF OBJECT_ID(N'[dbo].[fk_i9PropertyFirearm_i9Property]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9PropertyFirearm] DROP CONSTRAINT [fk_i9PropertyFirearm_i9Property];
GO
IF OBJECT_ID(N'[dbo].[fk_i9PropertyHazardousMaterial_i9Property]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9PropertyHazardousMaterial] DROP CONSTRAINT [fk_i9PropertyHazardousMaterial_i9Property];
GO
IF OBJECT_ID(N'[dbo].[fk_i9PropertyImage_i9Property]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9PropertyImage] DROP CONSTRAINT [fk_i9PropertyImage_i9Property];
GO
IF OBJECT_ID(N'[dbo].[fk_i9PropertySecurities_i9Property]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9PropertySecurities] DROP CONSTRAINT [fk_i9PropertySecurities_i9Property];
GO
IF OBJECT_ID(N'[dbo].[fk_i9RelatedRecord_i9Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9RelatedRecord] DROP CONSTRAINT [fk_i9RelatedRecord_i9Event];
GO
IF OBJECT_ID(N'[dbo].[fk_i9SecurityGroup_i9Agency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9SecurityGroup] DROP CONSTRAINT [fk_i9SecurityGroup_i9Agency];
GO
IF OBJECT_ID(N'[dbo].[fk_i9SecurityGroupModule_i9Agency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9SecurityGroupModule] DROP CONSTRAINT [fk_i9SecurityGroupModule_i9Agency];
GO
IF OBJECT_ID(N'[dbo].[fk_i9SecurityGroupTask_i9Agency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9SecurityGroupTask] DROP CONSTRAINT [fk_i9SecurityGroupTask_i9Agency];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Structure_i9Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Structure] DROP CONSTRAINT [fk_i9Structure_i9Event];
GO
IF OBJECT_ID(N'[i9databaseModelStoreContainer].[fk_i9SysLog_i9Agency]', 'F') IS NOT NULL
    ALTER TABLE [i9databaseModelStoreContainer].[i9SysLog] DROP CONSTRAINT [fk_i9SysLog_i9Agency];
GO
IF OBJECT_ID(N'[dbo].[fk_i9SysPersonnel_i9Agency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9SysPersonnel] DROP CONSTRAINT [fk_i9SysPersonnel_i9Agency];
GO
IF OBJECT_ID(N'[dbo].[fk_i9SysPersonnelAddress_i9SysPersonnel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9SysPersonnelAddress] DROP CONSTRAINT [fk_i9SysPersonnelAddress_i9SysPersonnel];
GO
IF OBJECT_ID(N'[dbo].[fk_i9SysPersonnelAssignment_i9SysPersonnel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9SysPersonnelAssignment] DROP CONSTRAINT [fk_i9SysPersonnelAssignment_i9SysPersonnel];
GO
IF OBJECT_ID(N'[dbo].[fk_i9SysPersonnelPhone_i9SysPersonnel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9SysPersonnelPhone] DROP CONSTRAINT [fk_i9SysPersonnelPhone_i9SysPersonnel];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Vehicle_i9Agency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Vehicle] DROP CONSTRAINT [fk_i9Vehicle_i9Agency];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Vehicle_i9Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Vehicle] DROP CONSTRAINT [fk_i9Vehicle_i9Event];
GO
IF OBJECT_ID(N'[dbo].[fk_i9VehicleRecovery_i9Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9VehicleRecovery] DROP CONSTRAINT [fk_i9VehicleRecovery_i9Event];
GO
IF OBJECT_ID(N'[dbo].[fk_i9VehicleRecovery_i9Vehicle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9VehicleRecovery] DROP CONSTRAINT [fk_i9VehicleRecovery_i9Vehicle];
GO
IF OBJECT_ID(N'[dbo].[fk_i9VehicleTowed_i9Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9VehicleTowed] DROP CONSTRAINT [fk_i9VehicleTowed_i9Event];
GO
IF OBJECT_ID(N'[dbo].[fk_i9VehicleTowed_i9Vehicle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9VehicleTowed] DROP CONSTRAINT [fk_i9VehicleTowed_i9Vehicle];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Warrant_i9Agency]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Warrant] DROP CONSTRAINT [fk_i9Warrant_i9Agency];
GO
IF OBJECT_ID(N'[dbo].[fk_i9Warrant_i9Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[i9Warrant] DROP CONSTRAINT [fk_i9Warrant_i9Event];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[i9Agency]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9Agency];
GO
IF OBJECT_ID(N'[dbo].[i9Arrest]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9Arrest];
GO
IF OBJECT_ID(N'[dbo].[i9ArrestReport]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9ArrestReport];
GO
IF OBJECT_ID(N'[dbo].[i9Attachment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9Attachment];
GO
IF OBJECT_ID(N'[dbo].[i9AttachmentData]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9AttachmentData];
GO
IF OBJECT_ID(N'[dbo].[i9AttachmentLink]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9AttachmentLink];
GO
IF OBJECT_ID(N'[dbo].[i9AVL]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9AVL];
GO
IF OBJECT_ID(N'[dbo].[i9AVLEvent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9AVLEvent];
GO
IF OBJECT_ID(N'[dbo].[i9AVLHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9AVLHistory];
GO
IF OBJECT_ID(N'[dbo].[i9CADServiceCall]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9CADServiceCall];
GO
IF OBJECT_ID(N'[dbo].[i9CADServiceCallNarrative]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9CADServiceCallNarrative];
GO
IF OBJECT_ID(N'[dbo].[i9CADUnit]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9CADUnit];
GO
IF OBJECT_ID(N'[dbo].[i9Charge]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9Charge];
GO
IF OBJECT_ID(N'[dbo].[i9Citation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9Citation];
GO
IF OBJECT_ID(N'[i9databaseModelStoreContainer].[i9ClientTableKey]', 'U') IS NOT NULL
    DROP TABLE [i9databaseModelStoreContainer].[i9ClientTableKey];
GO
IF OBJECT_ID(N'[dbo].[i9Code]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9Code];
GO
IF OBJECT_ID(N'[dbo].[i9CodeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9CodeSet];
GO
IF OBJECT_ID(N'[dbo].[i9ConfigurationSetting]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9ConfigurationSetting];
GO
IF OBJECT_ID(N'[i9databaseModelStoreContainer].[i9DynamicEntry]', 'U') IS NOT NULL
    DROP TABLE [i9databaseModelStoreContainer].[i9DynamicEntry];
GO
IF OBJECT_ID(N'[dbo].[i9DynamicEntryConfig]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9DynamicEntryConfig];
GO
IF OBJECT_ID(N'[i9databaseModelStoreContainer].[i9DynamicEntryCtrlType]', 'U') IS NOT NULL
    DROP TABLE [i9databaseModelStoreContainer].[i9DynamicEntryCtrlType];
GO
IF OBJECT_ID(N'[dbo].[i9DynamicEntryRule]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9DynamicEntryRule];
GO
IF OBJECT_ID(N'[dbo].[i9EmailAddress]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9EmailAddress];
GO
IF OBJECT_ID(N'[dbo].[i9EmailModule]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9EmailModule];
GO
IF OBJECT_ID(N'[dbo].[i9Event]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9Event];
GO
IF OBJECT_ID(N'[dbo].[i9EventType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9EventType];
GO
IF OBJECT_ID(N'[dbo].[i9FieldContact]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9FieldContact];
GO
IF OBJECT_ID(N'[dbo].[i9Gang]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9Gang];
GO
IF OBJECT_ID(N'[dbo].[i9LawIncident]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9LawIncident];
GO
IF OBJECT_ID(N'[dbo].[i9LawIncidentReport]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9LawIncidentReport];
GO
IF OBJECT_ID(N'[dbo].[i9Location]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9Location];
GO
IF OBJECT_ID(N'[dbo].[i9MessageInbox]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9MessageInbox];
GO
IF OBJECT_ID(N'[dbo].[i9Module]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9Module];
GO
IF OBJECT_ID(N'[dbo].[i9ModuleReportNumber]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9ModuleReportNumber];
GO
IF OBJECT_ID(N'[dbo].[i9ModuleSection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9ModuleSection];
GO
IF OBJECT_ID(N'[dbo].[i9ModusOperandi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9ModusOperandi];
GO
IF OBJECT_ID(N'[dbo].[i9Narrative]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9Narrative];
GO
IF OBJECT_ID(N'[dbo].[i9Offense]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9Offense];
GO
IF OBJECT_ID(N'[dbo].[i9Organization]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9Organization];
GO
IF OBJECT_ID(N'[dbo].[i9OtherContactInformation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9OtherContactInformation];
GO
IF OBJECT_ID(N'[dbo].[i9OtherInvolvedPerson]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9OtherInvolvedPerson];
GO
IF OBJECT_ID(N'[dbo].[i9Package]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9Package];
GO
IF OBJECT_ID(N'[dbo].[i9PackageMetadata]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9PackageMetadata];
GO
IF OBJECT_ID(N'[dbo].[i9Pawn]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9Pawn];
GO
IF OBJECT_ID(N'[dbo].[i9Permission]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9Permission];
GO
IF OBJECT_ID(N'[dbo].[i9Person]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9Person];
GO
IF OBJECT_ID(N'[dbo].[i9PersonArrestee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9PersonArrestee];
GO
IF OBJECT_ID(N'[dbo].[i9PersonMissing]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9PersonMissing];
GO
IF OBJECT_ID(N'[dbo].[i9PersonPhoto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9PersonPhoto];
GO
IF OBJECT_ID(N'[dbo].[i9PersonRelated]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9PersonRelated];
GO
IF OBJECT_ID(N'[dbo].[i9PersonSMT]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9PersonSMT];
GO
IF OBJECT_ID(N'[dbo].[i9PersonSubject]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9PersonSubject];
GO
IF OBJECT_ID(N'[dbo].[i9PersonVehicle]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9PersonVehicle];
GO
IF OBJECT_ID(N'[dbo].[i9PersonVictim]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9PersonVictim];
GO
IF OBJECT_ID(N'[dbo].[i9PhoneNumber]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9PhoneNumber];
GO
IF OBJECT_ID(N'[dbo].[i9Property]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9Property];
GO
IF OBJECT_ID(N'[dbo].[i9PropertyEvidence]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9PropertyEvidence];
GO
IF OBJECT_ID(N'[dbo].[i9PropertyExplosive]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9PropertyExplosive];
GO
IF OBJECT_ID(N'[dbo].[i9PropertyFirearm]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9PropertyFirearm];
GO
IF OBJECT_ID(N'[dbo].[i9PropertyHazardousMaterial]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9PropertyHazardousMaterial];
GO
IF OBJECT_ID(N'[dbo].[i9PropertyImage]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9PropertyImage];
GO
IF OBJECT_ID(N'[dbo].[i9PropertySecurities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9PropertySecurities];
GO
IF OBJECT_ID(N'[dbo].[i9RelatedRecord]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9RelatedRecord];
GO
IF OBJECT_ID(N'[dbo].[i9SecurityGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9SecurityGroup];
GO
IF OBJECT_ID(N'[dbo].[i9SecurityGroupModule]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9SecurityGroupModule];
GO
IF OBJECT_ID(N'[dbo].[i9SecurityGroupTask]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9SecurityGroupTask];
GO
IF OBJECT_ID(N'[dbo].[i9SecurityTask]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9SecurityTask];
GO
IF OBJECT_ID(N'[dbo].[i9SolvabilityFactor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9SolvabilityFactor];
GO
IF OBJECT_ID(N'[dbo].[i9Structure]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9Structure];
GO
IF OBJECT_ID(N'[i9databaseModelStoreContainer].[i9SysLog]', 'U') IS NOT NULL
    DROP TABLE [i9databaseModelStoreContainer].[i9SysLog];
GO
IF OBJECT_ID(N'[dbo].[i9SysPersonnel]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9SysPersonnel];
GO
IF OBJECT_ID(N'[dbo].[i9SysPersonnelAddress]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9SysPersonnelAddress];
GO
IF OBJECT_ID(N'[dbo].[i9SysPersonnelAssignment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9SysPersonnelAssignment];
GO
IF OBJECT_ID(N'[dbo].[i9SysPersonnelPhone]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9SysPersonnelPhone];
GO
IF OBJECT_ID(N'[dbo].[i9TableKey]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9TableKey];
GO
IF OBJECT_ID(N'[dbo].[i9Vehicle]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9Vehicle];
GO
IF OBJECT_ID(N'[dbo].[i9VehicleRecovery]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9VehicleRecovery];
GO
IF OBJECT_ID(N'[dbo].[i9VehicleTowed]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9VehicleTowed];
GO
IF OBJECT_ID(N'[dbo].[i9Warrant]', 'U') IS NOT NULL
    DROP TABLE [dbo].[i9Warrant];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'i9Agency'
CREATE TABLE [dbo].[i9Agency] (
    [AgencyName] varchar(60)  NULL,
    [AgencyDesc] varchar(100)  NULL,
    [Address1] varchar(80)  NULL,
    [Address2] varchar(80)  NULL,
    [City] varchar(60)  NULL,
    [State] varchar(40)  NULL,
    [Zip] varchar(20)  NULL,
    [PhoneNumber] varchar(30)  NULL,
    [FaxNumber] varchar(30)  NULL,
    [i9AgencyID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9Arrest'
CREATE TABLE [dbo].[i9Arrest] (
    [ActivityCategory] varchar(100)  NULL,
    [TransactionNumber] varchar(100)  NULL,
    [ORI_OriginatingAgencyIdentifier] varchar(100)  NULL,
    [ArrestDate] varchar(100)  NULL,
    [NarrativeAccountDescription] varchar(100)  NULL,
    [NarrativeAccountDescriptionDate] varchar(100)  NULL,
    [ArrestTypeCode] varchar(100)  NULL,
    [Arrestee] varchar(100)  NULL,
    [ArrestingOfficer] varchar(100)  NULL,
    [i9ArrestID] uniqueidentifier  NOT NULL,
    [i9EventID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9ArrestReport'
CREATE TABLE [dbo].[i9ArrestReport] (
    [i9ArrestReportID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9Attachment'
CREATE TABLE [dbo].[i9Attachment] (
    [AttachmentName] varchar(100)  NULL,
    [AttachmentNotes] varchar(100)  NULL,
    [Capturedate] datetime  NULL,
    [ImageTypeCode] varchar(100)  NULL,
    [ImageTypeText] varchar(100)  NULL,
    [i9AttachmentID] uniqueidentifier  NOT NULL,
    [i9EventID] uniqueidentifier  NOT NULL,
    [AttachmentFile] varbinary(max)  NULL
);
GO

-- Creating table 'i9AttachmentData'
CREATE TABLE [dbo].[i9AttachmentData] (
    [Data] varbinary(max)  NOT NULL,
    [i9AttachmentDataID] uniqueidentifier  NOT NULL,
    [i9AttachmentID] uniqueidentifier  NOT NULL,
    [i9EventID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9AttachmentLink'
CREATE TABLE [dbo].[i9AttachmentLink] (
    [AttachmentURI] varchar(100)  NULL,
    [Description] varchar(100)  NULL,
    [ViewableIndicator] varchar(100)  NULL,
    [i9AttachmentLinkID] uniqueidentifier  NOT NULL,
    [i9EventID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9AVL'
CREATE TABLE [dbo].[i9AVL] (
    [VehicleID] varchar(20)  NULL,
    [PositionDateTime] datetime  NULL,
    [Latitude] varchar(18)  NULL,
    [Longitude] varchar(20)  NULL,
    [Velocity] decimal(18,0)  NULL,
    [Heading] decimal(18,0)  NULL,
    [Disconnect] decimal(18,0)  NULL,
    [MapX] float  NULL,
    [MapY] float  NULL,
    [i9AVLID] uniqueidentifier  NOT NULL,
    [i9AgencyID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9AVLEvent'
CREATE TABLE [dbo].[i9AVLEvent] (
    [EventID] varchar(16)  NULL,
    [Score] float  NULL,
    [Mapx] float  NULL,
    [Mapy] float  NULL,
    [Intersection] decimal(18,0)  NULL,
    [Parfll] varchar(2)  NULL,
    [Sucess] decimal(18,0)  NULL,
    [Latitude] varchar(18)  NULL,
    [Longitude] varchar(20)  NULL,
    [i9AVLEventID] uniqueidentifier  NOT NULL,
    [i9AgencyID] uniqueidentifier  NOT NULL,
    [i9EventID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9AVLHistory'
CREATE TABLE [dbo].[i9AVLHistory] (
    [VehicleID] varchar(20)  NULL,
    [GPSTime] decimal(18,0)  NULL,
    [ReceiveTime] datetime  NULL,
    [Latitude] varchar(18)  NULL,
    [Longitude] varchar(20)  NULL,
    [Velocity] decimal(18,0)  NULL,
    [Heading] decimal(18,0)  NULL,
    [Source] varchar(2)  NULL,
    [Unit] varchar(16)  NULL,
    [Sector] varchar(4)  NULL,
    [PSUtcDateTime] datetime  NULL,
    [i9AVLHistoryID] uniqueidentifier  NOT NULL,
    [i9AgencyID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9CADServiceCall'
CREATE TABLE [dbo].[i9CADServiceCall] (
    [ActivityCategory] varchar(100)  NULL,
    [ServiceCallORI] varchar(100)  NULL,
    [ServiceCallDate] varchar(100)  NULL,
    [ServiceCallTime] varchar(100)  NULL,
    [PriorityCode] varchar(100)  NULL,
    [SourceCode] varchar(100)  NULL,
    [SourceText] varchar(100)  NULL,
    [ServiceCaller] varchar(100)  NULL,
    [Operator] varchar(100)  NULL,
    [CADDispatcher] varchar(100)  NULL,
    [TelephoneNumber] varchar(100)  NULL,
    [EmailAddress] varchar(100)  NULL,
    [ServiceCallOtherContactAddress] varchar(100)  NULL,
    [DispatchLocation] varchar(100)  NULL,
    [DispatchLocationOwnerName] varchar(100)  NULL,
    [i9CADServiceCallID] uniqueidentifier  NOT NULL,
    [i9AgencyID] uniqueidentifier  NOT NULL,
    [i9EventID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9CADServiceCallNarrative'
CREATE TABLE [dbo].[i9CADServiceCallNarrative] (
    [NarrativeText] varchar(100)  NULL,
    [NarrativeType] varchar(100)  NULL,
    [i9CADServiceCallNarrativeID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9CADUnit'
CREATE TABLE [dbo].[i9CADUnit] (
    [AgencyCode] varchar(100)  NULL,
    [UnitNBR] varchar(100)  NULL,
    [i9CADUnitID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9Charge'
CREATE TABLE [dbo].[i9Charge] (
    [i9ChargeID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9Citation'
CREATE TABLE [dbo].[i9Citation] (
    [i9CitationID] uniqueidentifier  NOT NULL,
    [i9EventID] uniqueidentifier  NOT NULL,
    [i9AgencyID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9ClientTableKey'
CREATE TABLE [dbo].[i9ClientTableKey] (
    [TableName] varchar(50)  NOT NULL,
    [KeyValue] bigint  NOT NULL,
    [LastUpdate] datetime  NULL
);
GO

-- Creating table 'i9Code'
CREATE TABLE [dbo].[i9Code] (
    [CodeSetName] varchar(50)  NULL,
    [Code] varchar(200)  NULL,
    [CodeText] varchar(2000)  NULL,
    [LastUpdate] datetime  NULL,
    [Enabled] int  NOT NULL,
    [i9CodeID] uniqueidentifier  NOT NULL,
    [i9AgencyID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9CodeSet'
CREATE TABLE [dbo].[i9CodeSet] (
    [CodeSetName] varchar(50)  NOT NULL,
    [CodeSetDesc] varchar(100)  NULL,
    [LastUpdate] datetime  NOT NULL,
    [i9CodeSetID] uniqueidentifier  NOT NULL,
    [i9AgencyID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9ConfigurationSetting'
CREATE TABLE [dbo].[i9ConfigurationSetting] (
    [ConfigurationSettingSection] varchar(100)  NULL,
    [ConfigurationSettingName] varchar(100)  NULL,
    [ConfigurationSettingValue] varchar(100)  NULL,
    [i9ConfigurationSettingID] uniqueidentifier  NOT NULL,
    [i9AgencyID] uniqueidentifier  NULL
);
GO

-- Creating table 'i9DynamicEntry'
CREATE TABLE [dbo].[i9DynamicEntry] (
    [ModuleSection] varchar(50)  NOT NULL,
    [ModuleSectionDesc] varchar(50)  NOT NULL,
    [DynamicEntryTable] varchar(50)  NULL,
    [LastUpdate] datetime  NULL
);
GO

-- Creating table 'i9DynamicEntryConfig'
CREATE TABLE [dbo].[i9DynamicEntryConfig] (
    [ModuleSection] varchar(50)  NOT NULL,
    [Enabled] int  NULL,
    [LabelText] varchar(50)  NULL,
    [CtrlWidth] varchar(50)  NULL,
    [CtrlHeight] varchar(50)  NULL,
    [CtrlFont] varchar(50)  NULL,
    [CtrlForGroundColor] varchar(50)  NULL,
    [CtrlBackGroundColor] varchar(50)  NULL,
    [PrintEnabled] int  NULL,
    [TableName] varchar(50)  NULL,
    [ColumnName] varchar(50)  NULL,
    [MaxLength] int  NULL,
    [LastUpdate] datetime  NULL,
    [ToolPopup] varchar(50)  NULL,
    [DataType] varchar(50)  NULL,
    [CtrlTypeName] varchar(50)  NULL,
    [i9DynamicEntryConfigID] uniqueidentifier  NOT NULL,
    [i9AgencyID] uniqueidentifier  NOT NULL,
    [DisplayOrder] real  NULL,
    [IsReadOnly] int  NOT NULL
);
GO

-- Creating table 'i9DynamicEntryCtrlType'
CREATE TABLE [dbo].[i9DynamicEntryCtrlType] (
    [CtrlTypeName] varchar(50)  NOT NULL,
    [CtrlTypeDesc] varchar(50)  NOT NULL,
    [LastUpdate] datetime  NULL
);
GO

-- Creating table 'i9DynamicEntryRule'
CREATE TABLE [dbo].[i9DynamicEntryRule] (
    [i9DynanicEntryConfigID] bigint  NOT NULL,
    [i9DynanicEntryConfigID2] bigint  NULL,
    [RuleType] varchar(50)  NULL,
    [MinValue] varchar(50)  NULL,
    [MaxValue] varchar(50)  NULL,
    [LastUpdate] datetime  NULL,
    [i9DynamicEntryRuleID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9EmailAddress'
CREATE TABLE [dbo].[i9EmailAddress] (
    [EmailAddress] varchar(100)  NULL,
    [EmailType] varchar(10)  NULL,
    [i9EmailAddressID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9EmailModule'
CREATE TABLE [dbo].[i9EmailModule] (
    [ToEmailAddress] varchar(max)  NOT NULL,
    [CCEmailAddress] varchar(max)  NULL,
    [BCCEmailAddress] varchar(max)  NULL,
    [FromEmailAddress] varchar(255)  NOT NULL,
    [Subject] varchar(max)  NOT NULL,
    [Body] varchar(max)  NOT NULL,
    [EmailStatusFlag] tinyint  NOT NULL,
    [InsertDate] datetime  NOT NULL,
    [InsertENTUserAccountId] int  NOT NULL,
    [UpdateDate] datetime  NOT NULL,
    [UpdateENTUserAccountId] int  NOT NULL,
    [Version] binary(8)  NOT NULL,
    [i9EmailModuleID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9Event'
CREATE TABLE [dbo].[i9Event] (
    [i9EventType] varchar(20)  NOT NULL,
    [i9EventID] uniqueidentifier  NOT NULL,
    [i9AgencyID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9EventType'
CREATE TABLE [dbo].[i9EventType] (
    [EventDesc] varchar(30)  NULL,
    [i9EventType1] varchar(20)  NOT NULL
);
GO

-- Creating table 'i9FieldContact'
CREATE TABLE [dbo].[i9FieldContact] (
    [i9FieldContactID] uniqueidentifier  NOT NULL,
    [i9AgencyID] uniqueidentifier  NOT NULL,
    [i9EventID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9Gang'
CREATE TABLE [dbo].[i9Gang] (
    [GangType] varchar(10)  NULL,
    [GangName] varchar(30)  NULL,
    [GangDesc] varchar(30)  NULL,
    [i9GangID] uniqueidentifier  NOT NULL,
    [i9EventID] uniqueidentifier  NOT NULL,
    [i9AgencyID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9LawIncident'
CREATE TABLE [dbo].[i9LawIncident] (
    [ActivityCategory] varchar(50)  NULL,
    [IncidentNumber] varchar(20)  NOT NULL,
    [ORI] varchar(30)  NULL,
    [IncidentReportDate] varchar(100)  NULL,
    [BeginDate] varchar(100)  NULL,
    [BeginTime] varchar(100)  NULL,
    [EndDate] varchar(100)  NULL,
    [EndTime] varchar(100)  NULL,
    [NarrativeAccountDescription] varchar(100)  NULL,
    [StatusCode] varchar(100)  NULL,
    [StatusText] varchar(100)  NULL,
    [StatusDate] varchar(100)  NULL,
    [EvidenceHeldIndicator] varchar(100)  NULL,
    [FactorCode] varchar(100)  NULL,
    [FactorText] varchar(100)  NULL,
    [ExceptionalClearanceCode] varchar(100)  NULL,
    [ExceptionalClearanceDate] varchar(100)  NULL,
    [WeatherCode] varchar(100)  NULL,
    [WeatherText] varchar(100)  NULL,
    [IncidentLightingCode] varchar(100)  NULL,
    [IncidentLightingText] varchar(100)  NULL,
    [AgencyNotificationIndicator] varchar(100)  NULL,
    [IncidentDisseminationLevelCode] varchar(100)  NULL,
    [InvolvedProperty] varchar(100)  NULL,
    [Evidence] varchar(100)  NULL,
    [IncidentSubject] varchar(100)  NULL,
    [IncidentVictim] varchar(100)  NULL,
    [IncidentWitness] varchar(100)  NULL,
    [IncidentOtherInvolvedPerson] varchar(100)  NULL,
    [IncidentOffense] varchar(100)  NULL,
    [IncidentServiceCall] varchar(100)  NULL,
    [ReportingOfficer] varchar(100)  NULL,
    [SupplementNumber] int  NOT NULL,
    [Summary] varchar(10)  NULL,
    [i9LawIncidentID] uniqueidentifier  NOT NULL,
    [i9AgencyID] uniqueidentifier  NOT NULL,
    [i9EventID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9LawIncidentReport'
CREATE TABLE [dbo].[i9LawIncidentReport] (
    [LastUpdated] datetime  NULL,
    [i9LawIncidentReportID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9Location'
CREATE TABLE [dbo].[i9Location] (
    [LocationMVI] bigint  NOT NULL,
    [LocationTypeCode] varchar(100)  NULL,
    [LocationTypeText] varchar(100)  NULL,
    [FullStreetAddress] varchar(100)  NULL,
    [StreetNumber] varchar(100)  NULL,
    [StreetName] varchar(100)  NULL,
    [StreetType] varchar(100)  NULL,
    [StreetPredirection] varchar(100)  NULL,
    [StreetPostdirection] varchar(100)  NULL,
    [Apartment] varchar(100)  NULL,
    [City] varchar(100)  NULL,
    [StateCode] varchar(100)  NULL,
    [StateText] varchar(100)  NULL,
    [LotNumber] varchar(100)  NULL,
    [ZipCode] varchar(100)  NULL,
    [ZipCodeExtension] varchar(100)  NULL,
    [County] varchar(100)  NULL,
    [CountryCode] varchar(100)  NULL,
    [CountryText] varchar(100)  NULL,
    [Highway] varchar(100)  NULL,
    [MileMarker] varchar(100)  NULL,
    [Latitude] varchar(100)  NULL,
    [Longitude] varchar(100)  NULL,
    [i9LocationID] uniqueidentifier  NOT NULL,
    [i9AgencyID] uniqueidentifier  NOT NULL,
    [i9EventID] uniqueidentifier  NOT NULL,
    [i9ModuleSectionID] varchar(25)  NOT NULL,
    [LocationRemarks] varchar(100)  NULL,
    [Beat] varchar(20)  NULL,
    [i9PersonID] uniqueidentifier  NULL,
    [i9VehicleID] uniqueidentifier  NULL
);
GO

-- Creating table 'i9MessageInbox'
CREATE TABLE [dbo].[i9MessageInbox] (
    [i9MessageInboxID] uniqueidentifier  NOT NULL,
    [i9AgencyID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9Module'
CREATE TABLE [dbo].[i9Module] (
    [ClassName] varchar(100)  NOT NULL,
    [ModuleName] varchar(50)  NOT NULL,
    [Section] varchar(50)  NOT NULL,
    [PopupPage] bit  NOT NULL,
    [DesktopEnabled] bit  NOT NULL,
    [MobileEnabled] bit  NOT NULL,
    [ModuleType] varchar(10)  NOT NULL,
    [FileName] varchar(100)  NOT NULL,
    [LastUpdate] datetime  NULL,
    [i9ModuleID] uniqueidentifier  NOT NULL,
    [ModuleKey] varchar(75)  NOT NULL
);
GO

-- Creating table 'i9ModuleReportNumber'
CREATE TABLE [dbo].[i9ModuleReportNumber] (
    [i9ModuleID] varchar(50)  NOT NULL,
    [ReportNumber] bigint  NOT NULL,
    [NumberPrefix] varchar(15)  NULL,
    [NumberSubFix] varchar(15)  NULL,
    [Length] int  NULL,
    [LastUpdate] datetime  NOT NULL,
    [ResetReportNumber] varchar(10)  NOT NULL,
    [StartNumber] int  NOT NULL,
    [EndNumber] int  NOT NULL,
    [NumberLength] int  NOT NULL,
    [i9ModuleReportNumberID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9ModuleSection'
CREATE TABLE [dbo].[i9ModuleSection] (
    [i9ModuleSectionID] varchar(25)  NOT NULL,
    [ModuleSectionDesc] varchar(50)  NOT NULL
);
GO

-- Creating table 'i9ModusOperandi'
CREATE TABLE [dbo].[i9ModusOperandi] (
    [ModusOperandiCode] varchar(15)  NOT NULL,
    [ModusOperandiText] varchar(50)  NOT NULL,
    [i9ModusOperandiID] uniqueidentifier  NOT NULL,
    [i9LawIncidentID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9Narrative'
CREATE TABLE [dbo].[i9Narrative] (
    [i9NarrativeID] uniqueidentifier  NOT NULL,
    [i9EventID] uniqueidentifier  NOT NULL,
    [SummaryNarrative] varchar(max)  NULL,
    [Narrative] varchar(max)  NULL,
    [SummaryNarrativeFormat] varchar(max)  NULL,
    [NarrativeFormat] varchar(max)  NULL
);
GO

-- Creating table 'i9Offense'
CREATE TABLE [dbo].[i9Offense] (
    [ActivityCategory] varchar(100)  NULL,
    [OffenseCode] varchar(100)  NULL,
    [OffenseText] varchar(100)  NULL,
    [OffenseDescriptionText] varchar(100)  NULL,
    [OffenseViolatedStatuteNumber] varchar(100)  NULL,
    [OffenseViolatedStatuteDescription] varchar(100)  NULL,
    [OffenseAttemptedCompletedCode] varchar(100)  NULL,
    [OffenseBiasMotivationCode] varchar(100)  NULL,
    [OffenseBiasMotivationText] varchar(100)  NULL,
    [OffenseBiasMotivationCauseCode] varchar(100)  NULL,
    [OffenseBiasMotivationCauseText] varchar(100)  NULL,
    [OffenseNumberofPremisesEntered] varchar(100)  NULL,
    [OffenseForcedEntryCode] varchar(100)  NULL,
    [OffensePointofEntryCode] varchar(100)  NULL,
    [OffensePointofEntryText] varchar(100)  NULL,
    [OffenseMethodofEntryCode] varchar(100)  NULL,
    [OffenseMethodofEntryText] varchar(100)  NULL,
    [OffenseSecurityTypeEntryCode] varchar(100)  NULL,
    [OffenseSecurityTypeEntryText] varchar(100)  NULL,
    [OffenseSecuritySystemsStatusEntryCode] varchar(100)  NULL,
    [OffenseForcedExitCode] varchar(100)  NULL,
    [OffensePointofExitCode] varchar(100)  NULL,
    [OffensePointofExitText] varchar(100)  NULL,
    [OffenseMethodofExitCode] varchar(100)  NULL,
    [OffenseMethodofExitText] varchar(100)  NULL,
    [OffenseSecurityTypeExitCode] varchar(100)  NULL,
    [OffenseSecurityTypeExitText] varchar(100)  NULL,
    [OffenseSecuritySystemsStatusExitCode] varchar(100)  NULL,
    [OffenseLocation] varchar(100)  NULL,
    [OffenseCriminalActivityCode] varchar(100)  NULL,
    [OffenseCriminalActivityText] varchar(100)  NULL,
    [OffenseForceUsedCode] varchar(100)  NULL,
    [OffenseForceUsedText] varchar(100)  NULL,
    [OffenseWeapon] varchar(100)  NULL,
    [i9OffenseID] uniqueidentifier  NOT NULL,
    [i9LawIncidentID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9Organization'
CREATE TABLE [dbo].[i9Organization] (
    [OrganizationTypeCode] varchar(100)  NULL,
    [OrganizationTypeText] varchar(100)  NULL,
    [Description] varchar(100)  NULL,
    [OrganizationName] varchar(100)  NULL,
    [OrganizationIDValue] varchar(100)  NULL,
    [IDEffectiveDate] varchar(100)  NULL,
    [IDExpirationDate] varchar(100)  NULL,
    [IDIssuingAuthority] varchar(100)  NULL,
    [IDStatus] varchar(100)  NULL,
    [IDType] varchar(100)  NULL,
    [OrganizationTaxID] varchar(100)  NULL,
    [FederalFirearmLicenseID] varchar(100)  NULL,
    [i9OrganizationID] uniqueidentifier  NOT NULL,
    [i9EventID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9OtherContactInformation'
CREATE TABLE [dbo].[i9OtherContactInformation] (
    [ContactAddress] varchar(100)  NULL,
    [ContactOtherAddressType] varchar(100)  NULL,
    [i9OtherContactInformationID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9OtherInvolvedPerson'
CREATE TABLE [dbo].[i9OtherInvolvedPerson] (
    [OtherInvolvedPerson] varchar(100)  NULL,
    [OtherInvolvedPersonSequenceNumber] varchar(100)  NULL,
    [i9OtherInvolvedPersonID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9Package'
CREATE TABLE [dbo].[i9Package] (
    [PackageName] varchar(30)  NULL,
    [i9PackageID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9PackageMetadata'
CREATE TABLE [dbo].[i9PackageMetadata] (
    [PackageMetadataName] varchar(30)  NULL,
    [i9PackageMetadataID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9Pawn'
CREATE TABLE [dbo].[i9Pawn] (
    [i9PawnID] uniqueidentifier  NOT NULL,
    [i9EventID] uniqueidentifier  NOT NULL,
    [i9AgencyID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9Permission'
CREATE TABLE [dbo].[i9Permission] (
    [PermissionName] varchar(100)  NULL,
    [Description] varchar(510)  NULL,
    [i9PermissionID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9Person'
CREATE TABLE [dbo].[i9Person] (
    [PersonMNI] bigint  NOT NULL,
    [PersonPotentialMatchID] varchar(100)  NULL,
    [Prefix] varchar(100)  NULL,
    [FirstName] varchar(100)  NULL,
    [MiddleName] varchar(100)  NULL,
    [LastName] varchar(100)  NULL,
    [Suffix] varchar(100)  NULL,
    [FullName] varchar(100)  NULL,
    [PersonNameTypeCode] varchar(100)  NULL,
    [SexCode] varchar(100)  NULL,
    [RaceCode] varchar(100)  NULL,
    [EthnicityCode] varchar(100)  NULL,
    [BirthDate] varchar(100)  NULL,
    [SSN] varchar(100)  NULL,
    [FBINumber] varchar(100)  NULL,
    [DriverLicenseNumber] varchar(100)  NULL,
    [DriverLicenseExpirationDate] varchar(100)  NULL,
    [DriverLicenseIssuingAuthorityCode] varchar(100)  NULL,
    [DriverLicenseIssuingAuthorityText] varchar(100)  NULL,
    [StateID] varchar(100)  NULL,
    [StateIDIssuingAuthorityCode] varchar(100)  NULL,
    [StateIDIssuingAuthorityText] varchar(100)  NULL,
    [PassportID] varchar(100)  NULL,
    [PassportIssuingCountryCode] varchar(100)  NULL,
    [PassportExpirationDate] varchar(100)  NULL,
    [AlienNumber] varchar(100)  NULL,
    [USMarshalServiceFugitiveID] varchar(100)  NULL,
    [RegisteredOffenderIndicator] varchar(100)  NULL,
    [RegisteredOffenderNumber] varchar(100)  NULL,
    [RegisteredOffenderIssuingAuthorityCode] varchar(100)  NULL,
    [RegisteredOffenderIssuingAuthorityText] varchar(100)  NULL,
    [PersonIdentificationNumberPID] varchar(100)  NULL,
    [PIDTypeCode] varchar(100)  NULL,
    [PIDIssuingAuthorityCode] varchar(100)  NULL,
    [PIDIssuingAuthorityText] varchar(100)  NULL,
    [PIDEffectiveDate] varchar(100)  NULL,
    [PIDExpirationDate] varchar(100)  NULL,
    [DNACollectionIndicator] varchar(100)  NULL,
    [DNACollectionStatusText] varchar(100)  NULL,
    [ResidentStatusCode] varchar(100)  NULL,
    [OccupationCode] varchar(100)  NULL,
    [OccupationText] varchar(100)  NULL,
    [CitizenshipCode] varchar(100)  NULL,
    [DigitalImage] varchar(100)  NULL,
    [PersonPhysicalFeatureCode] varchar(100)  NULL,
    [PhysicalFeatureDescription] varchar(100)  NULL,
    [PhysicalFeatureImage] varchar(100)  NULL,
    [PersonHeight] varchar(100)  NULL,
    [MinimumHeight] varchar(100)  NULL,
    [MaximumHeight] varchar(100)  NULL,
    [HeightUnitCode] varchar(100)  NULL,
    [Weight] varchar(100)  NULL,
    [MinimumWeight] varchar(100)  NULL,
    [MaximumWeight] varchar(100)  NULL,
    [WeightUnitCode] varchar(100)  NULL,
    [Age] varchar(100)  NULL,
    [MinimumAge] varchar(100)  NULL,
    [MaximumAge] varchar(100)  NULL,
    [AgeUnitCode] varchar(100)  NULL,
    [EyeColorCode] varchar(100)  NULL,
    [HairColorCode] varchar(100)  NULL,
    [HairLengthCode] varchar(100)  NULL,
    [HairLengthText] varchar(100)  NULL,
    [HairStyleCode] varchar(100)  NULL,
    [HairStyleText] varchar(100)  NULL,
    [HairDescription] varchar(100)  NULL,
    [BuildCode] varchar(100)  NULL,
    [BuildText] varchar(100)  NULL,
    [EyewearCode] varchar(100)  NULL,
    [EyewearText] varchar(100)  NULL,
    [PersonHandednessCode] varchar(100)  NULL,
    [DentalCharacteristicCode] varchar(100)  NULL,
    [DentalCharacteristicText] varchar(100)  NULL,
    [SpeechCode] varchar(100)  NULL,
    [SpeechText] varchar(100)  NULL,
    [FacialHairCode] varchar(100)  NULL,
    [FacialHairText] varchar(100)  NULL,
    [SkinToneCode] varchar(100)  NULL,
    [CautionInformationCode] varchar(100)  NULL,
    [CautionInformationText] varchar(100)  NULL,
    [PersonCriminalInvolvementCode] varchar(100)  NULL,
    [PersonMaritalStatus] varchar(100)  NULL,
    [SequenceNumber] int  NOT NULL,
    [i9PersonID] uniqueidentifier  NOT NULL,
    [i9EventID] uniqueidentifier  NOT NULL,
    [i9AgencyID] uniqueidentifier  NOT NULL,
    [i9ModuleSectionID] varchar(25)  NOT NULL,
    [i9PersonAKAID] uniqueidentifier  NULL
);
GO

-- Creating table 'i9PersonArrestee'
CREATE TABLE [dbo].[i9PersonArrestee] (
    [Arrestee] varchar(100)  NULL,
    [CountCode] varchar(100)  NULL,
    [JuvenileDispositionCode] varchar(100)  NULL,
    [ArresteeWeapon] varchar(100)  NULL,
    [OffenseID] bigint  NOT NULL,
    [ArresteeViolatedStatuteNumber] varchar(100)  NULL,
    [ArresteeViolatedStatuteDescription] varchar(100)  NULL,
    [ArresteeSequenceNumber] varchar(100)  NULL,
    [i9PersonArresteeID] uniqueidentifier  NOT NULL,
    [i9PersonID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9PersonMissing'
CREATE TABLE [dbo].[i9PersonMissing] (
    [MissingPerson] varchar(100)  NULL,
    [MissingPersonCircumstanceCode] varchar(100)  NULL,
    [MissingPersonCircumstanceText] varchar(100)  NULL,
    [MissingPersonDeclarationDate] varchar(100)  NULL,
    [MissingPersonDeclarationTime] varchar(100)  NULL,
    [MissingPersonFoundDate] varchar(100)  NULL,
    [MissingPersonFoundTime] varchar(100)  NULL,
    [MissingPersonFoundIndicator] varchar(100)  NULL,
    [MissingPersonLastSeenDate] varchar(100)  NULL,
    [MissingPersonLastSeenTime] varchar(100)  NULL,
    [i9PersonMissingID] uniqueidentifier  NOT NULL,
    [i9PersonID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9PersonPhoto'
CREATE TABLE [dbo].[i9PersonPhoto] (
    [Photo] varbinary(max)  NULL,
    [PhotoThumb] varbinary(max)  NULL,
    [i9PersonPhotoID] uniqueidentifier  NOT NULL,
    [i9PersonID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9PersonRelated'
CREATE TABLE [dbo].[i9PersonRelated] (
    [RecordedDate] datetime  NULL,
    [InvolvementCode] varchar(60)  NULL,
    [i9PersonRelatedID] uniqueidentifier  NOT NULL,
    [i9PersonID] uniqueidentifier  NOT NULL,
    [i9PersonIDRelated] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9PersonSMT'
CREATE TABLE [dbo].[i9PersonSMT] (
    [SMTCode] varchar(100)  NULL,
    [SMTDescription] varchar(100)  NULL,
    [SMTLocation] varchar(100)  NULL,
    [Feature] varchar(100)  NULL,
    [i9PersonSMTID] uniqueidentifier  NOT NULL,
    [i9PersonID] uniqueidentifier  NOT NULL,
    [i9EventID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9PersonSubject'
CREATE TABLE [dbo].[i9PersonSubject] (
    [SubjectPerson] varchar(100)  NULL,
    [Organization] varchar(100)  NULL,
    [SequenceNumber] varchar(100)  NULL,
    [ModusOperandiSubjectActionCode] varchar(100)  NULL,
    [ModusOperandiSubjectActionText] varchar(100)  NULL,
    [ModusOperandiObservationCode] varchar(100)  NULL,
    [ModusOperandiObservationText] varchar(100)  NULL,
    [i9PersonSubjectID] uniqueidentifier  NOT NULL,
    [i9PersonID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9PersonVehicle'
CREATE TABLE [dbo].[i9PersonVehicle] (
    [Involvement] varchar(160)  NULL,
    [InvolvementDate] datetime  NULL,
    [i9PersonVehicleID] uniqueidentifier  NOT NULL,
    [i9PersonID] uniqueidentifier  NOT NULL,
    [i9VehicleID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9PersonVictim'
CREATE TABLE [dbo].[i9PersonVictim] (
    [VictimOrganization] varchar(100)  NULL,
    [VictimPerson] varchar(100)  NULL,
    [VictimSequenceNumber] varchar(100)  NULL,
    [ModusOperandiVictimActionCode] varchar(100)  NULL,
    [ModusOperandiVictimActionText] varchar(100)  NULL,
    [VictimTypeCode] varchar(100)  NULL,
    [VictimTypeText] varchar(100)  NULL,
    [AggravatedAssaultHomicideCircumstanceCode] varchar(100)  NULL,
    [AggravatedAssaultHomicideCircumstanceText] varchar(100)  NULL,
    [AdditionalJustifiableHomicideCode] varchar(100)  NULL,
    [InjuryTypeCode] varchar(100)  NULL,
    [InjuryTypeText] varchar(100)  NULL,
    [i9PersonVictimID] uniqueidentifier  NOT NULL,
    [i9PersonID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9PhoneNumber'
CREATE TABLE [dbo].[i9PhoneNumber] (
    [CountryCode] varchar(100)  NULL,
    [CityCode] varchar(100)  NULL,
    [NumberAreaCode] varchar(100)  NULL,
    [ExchangeID] varchar(100)  NULL,
    [NumberSubscriberID] varchar(100)  NULL,
    [Suffix] varchar(100)  NULL,
    [NumberFull] varchar(100)  NULL,
    [NumberType] varchar(100)  NULL,
    [i9PhoneNumberID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9Property'
CREATE TABLE [dbo].[i9Property] (
    [PropertyMPI] bigint  NOT NULL,
    [PropertyStatusCode] varchar(100)  NULL,
    [PropertyTypeCode] varchar(100)  NULL,
    [PropertyTypeText] varchar(100)  NULL,
    [PropertyValue] varchar(100)  NULL,
    [PropertyValueTypeCode] varchar(100)  NULL,
    [PropertyValueTypeText] varchar(100)  NULL,
    [DispositionDate] varchar(100)  NULL,
    [DigitalImage] varchar(100)  NULL,
    [SerialNumber] varchar(100)  NULL,
    [PropertyDescription] varchar(100)  NULL,
    [Make] varchar(100)  NULL,
    [Model] varchar(100)  NULL,
    [PropertyRFID] varchar(100)  NULL,
    [KnifeTypeCode] varchar(100)  NULL,
    [KnifeTypeText] varchar(100)  NULL,
    [HouseholdGoodsTypeCode] varchar(100)  NULL,
    [HouseholdGoodsTypeText] varchar(100)  NULL,
    [LivestockPetTypeCode] varchar(100)  NULL,
    [LivestockPetTypeText] varchar(100)  NULL,
    [GrainTypeCode] varchar(100)  NULL,
    [GrainTypeText] varchar(100)  NULL,
    [CreditBankIDCardTypeCode] varchar(100)  NULL,
    [CreditBankIDCardTypeText] varchar(100)  NULL,
    [ConsumableGoodsTypeCode] varchar(100)  NULL,
    [ConsumableGoodsTypeText] varchar(100)  NULL,
    [ConstructionMaterialTypeCode] varchar(100)  NULL,
    [ConstructionMaterialTypeText] varchar(100)  NULL,
    [ElectronicEquipmentTypeCode] varchar(100)  NULL,
    [ElectronicEquipmentTypeText] varchar(100)  NULL,
    [ClothingTypeCode] varchar(100)  NULL,
    [ClothingTypeText] varchar(100)  NULL,
    [DeviceTypeCode] varchar(100)  NULL,
    [DeviceTypeText] varchar(100)  NULL,
    [DeviceStoredText] varchar(100)  NULL,
    [DeviceAssignedTelephoneNumber] varchar(100)  NULL,
    [DeviceEmailAddress] varchar(100)  NULL,
    [DeviceOtherContactAddress] varchar(100)  NULL,
    [DeviceElectronicSerialNumber_ESN] varchar(100)  NULL,
    [DeviceInternationalMobileEquipmentIdentity_IMEI] varchar(100)  NULL,
    [DrugTypeCode] varchar(100)  NULL,
    [DrugTypeText] varchar(100)  NULL,
    [DrugQuantity] varchar(100)  NULL,
    [DrugMeasureCode] varchar(100)  NULL,
    [DrugContainerDescription] varchar(100)  NULL,
    [DrugSubstanceForm] varchar(100)  NULL,
    [DrugFoundDescription] varchar(100)  NULL,
    [JewelryTypeCode] varchar(100)  NULL,
    [JewelryTypeText] varchar(100)  NULL,
    [i9PropertyID] uniqueidentifier  NOT NULL,
    [i9AgencyID] uniqueidentifier  NOT NULL,
    [i9EventID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9PropertyEvidence'
CREATE TABLE [dbo].[i9PropertyEvidence] (
    [EvidenceReceiptID] varchar(100)  NULL,
    [EvidenceProperty] varchar(100)  NULL,
    [i9PropertyEvidenceID] uniqueidentifier  NOT NULL,
    [i9PropertyID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9PropertyExplosive'
CREATE TABLE [dbo].[i9PropertyExplosive] (
    [ComponentCode] varchar(100)  NULL,
    [ComponentText] varchar(100)  NULL,
    [ContainerCode] varchar(100)  NULL,
    [ContainerText] varchar(100)  NULL,
    [FillerCode] varchar(100)  NULL,
    [FillerText] varchar(100)  NULL,
    [ExplosiveIgnitionCode] varchar(100)  NULL,
    [ExplosiveIgnitionText] varchar(100)  NULL,
    [i9PropertyExplosiveID] uniqueidentifier  NOT NULL,
    [i9PropertyID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9PropertyFirearm'
CREATE TABLE [dbo].[i9PropertyFirearm] (
    [SerialNumber] varchar(100)  NULL,
    [FirearmTypeCode] varchar(100)  NULL,
    [FirearmTypeText] varchar(100)  NULL,
    [FirearmDescriptionCode] varchar(100)  NULL,
    [FirearmDescription] varchar(100)  NULL,
    [FirearmMakeCode] varchar(100)  NULL,
    [FirearmFinishCode] varchar(100)  NULL,
    [CaliberCode] varchar(100)  NULL,
    [BarrelLength] varchar(100)  NULL,
    [BarrelLengthMeasureCode] varchar(100)  NULL,
    [COMMENTS] varchar(510)  NULL,
    [i9PropertyFirearmID] uniqueidentifier  NOT NULL,
    [i9PropertyID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9PropertyHazardousMaterial'
CREATE TABLE [dbo].[i9PropertyHazardousMaterial] (
    [HazardousMaterialCode] varchar(100)  NULL,
    [HazardousMaterialText] varchar(100)  NULL,
    [HazardousMaterialQuantity] varchar(100)  NULL,
    [HazardousMaterialMeasureCode] varchar(100)  NULL,
    [HazardousMaterialContainerDescription] varchar(100)  NULL,
    [HazardousMaterialSubstanceForm] varchar(100)  NULL,
    [i9PropertyHazardousMaterialID] uniqueidentifier  NOT NULL,
    [i9PropertyID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9PropertyImage'
CREATE TABLE [dbo].[i9PropertyImage] (
    [PhotoName] varchar(20)  NULL,
    [PhotoType] varchar(40)  NULL,
    [PropertyImage] varbinary(max)  NULL,
    [i9PropertyImageID] uniqueidentifier  NOT NULL,
    [i9PropertyID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9PropertySecurities'
CREATE TABLE [dbo].[i9PropertySecurities] (
    [SecuritiesTypeCode] varchar(100)  NULL,
    [SecuritiesTypeText] varchar(100)  NULL,
    [SerialNumber] varchar(100)  NULL,
    [Denomination] varchar(100)  NULL,
    [Issuer] varchar(100)  NULL,
    [SecurityOwner] varchar(100)  NULL,
    [DateOrSeriesYear] varchar(100)  NULL,
    [MaturityDate] varchar(100)  NULL,
    [CollectionStartDate] varchar(100)  NULL,
    [CollectionEndDate] varchar(100)  NULL,
    [SecuritiesRansomMoneyIndicatorCode] varchar(100)  NULL,
    [i9PropertySecuritiesID] uniqueidentifier  NOT NULL,
    [i9PropertyID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9RelatedRecord'
CREATE TABLE [dbo].[i9RelatedRecord] (
    [RecordType] varchar(100)  NULL,
    [RecordAgency] varchar(100)  NULL,
    [RecordID] varchar(100)  NULL,
    [Agency] varchar(100)  NULL,
    [RelatedRecordType] varchar(100)  NULL,
    [RelatedRecordAG] varchar(100)  NULL,
    [RelatedRecordRecordID] varchar(100)  NULL,
    [RelatedAGENCY] varchar(100)  NULL,
    [i9RelatedRecordID] uniqueidentifier  NOT NULL,
    [i9EventID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9SecurityGroup'
CREATE TABLE [dbo].[i9SecurityGroup] (
    [i9SecurityGroupID] uniqueidentifier  NOT NULL,
    [i9AgencyID] uniqueidentifier  NOT NULL,
    [SecurityGroupName] varchar(50)  NULL,
    [SecurityGroupDesc] varchar(100)  NULL
);
GO

-- Creating table 'i9SecurityGroupModule'
CREATE TABLE [dbo].[i9SecurityGroupModule] (
    [i9SecurityGroupModuleID] uniqueidentifier  NOT NULL,
    [i9AgencyID] uniqueidentifier  NOT NULL,
    [SecurityGroupName] varchar(50)  NOT NULL,
    [ModuleName] varchar(50)  NOT NULL
);
GO

-- Creating table 'i9SecurityGroupTask'
CREATE TABLE [dbo].[i9SecurityGroupTask] (
    [i9SecurityGroupTaskID] uniqueidentifier  NOT NULL,
    [i9AgencyID] uniqueidentifier  NOT NULL,
    [SecurityGroupName] varchar(50)  NOT NULL,
    [TaskName] varchar(50)  NOT NULL
);
GO

-- Creating table 'i9SecurityTask'
CREATE TABLE [dbo].[i9SecurityTask] (
    [i9SecurityTaskID] uniqueidentifier  NOT NULL,
    [TaskName] varchar(50)  NOT NULL,
    [TaskDesc] varchar(100)  NOT NULL,
    [Enabled] int  NOT NULL
);
GO

-- Creating table 'i9SolvabilityFactor'
CREATE TABLE [dbo].[i9SolvabilityFactor] (
    [SolvabilityFactorTotal] bigint  NOT NULL,
    [i9SolvabilityFactorID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9Structure'
CREATE TABLE [dbo].[i9Structure] (
    [StructureTypeCode] varchar(100)  NULL,
    [StructureTypeText] varchar(100)  NULL,
    [StructureOccupiedCode] varchar(100)  NULL,
    [StructureOccupiedText] varchar(100)  NULL,
    [i9StructureID] uniqueidentifier  NOT NULL,
    [i9EventID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9SysLog'
CREATE TABLE [dbo].[i9SysLog] (
    [i9SysLogID] int IDENTITY(1,1) NOT NULL,
    [LogDateTime] datetime  NOT NULL,
    [LogDescription] varchar(1000)  NULL,
    [i9AgencyID] uniqueidentifier  NULL,
    [BadgeNumber] varchar(25)  NULL,
    [LogType] varchar(25)  NULL,
    [AgencyName] varchar(60)  NULL
);
GO

-- Creating table 'i9SysPersonnel'
CREATE TABLE [dbo].[i9SysPersonnel] (
    [Officer] varchar(100)  NULL,
    [OfficerActivityTypeCode] varchar(100)  NULL,
    [OfficerActivityTypeText] varchar(100)  NULL,
    [OfficerAssignmentTypeCode] varchar(100)  NULL,
    [OfficerAssignmentTypeText] varchar(100)  NULL,
    [OfficerLEOKATypeCode] varchar(100)  NULL,
    [OfficerORI] varchar(100)  NULL,
    [BadgeNumber] varchar(100)  NULL,
    [FirstName] varchar(200)  NULL,
    [LastName] varchar(200)  NULL,
    [MiddleName] varchar(200)  NULL,
    [Password] varchar(200)  NULL,
    [Enabled] bit  NULL,
    [LastUpdate] datetime  NULL,
    [i9SysPersonnelID] uniqueidentifier  NOT NULL,
    [i9AgencyID] uniqueidentifier  NOT NULL,
    [Email] varchar(100)  NOT NULL,
    [DateTimeInserted] datetime  NOT NULL,
    [DateTimeUpdated] datetime  NOT NULL,
    [ActivationGuid] uniqueidentifier  NULL
);
GO

-- Creating table 'i9SysPersonnelAddress'
CREATE TABLE [dbo].[i9SysPersonnelAddress] (
    [AddressType] varchar(20)  NULL,
    [Address1] varchar(80)  NULL,
    [Address2] varchar(80)  NULL,
    [City] varchar(60)  NULL,
    [State] varchar(40)  NULL,
    [Zip] varchar(20)  NULL,
    [i9SysPersonnelAddressID] uniqueidentifier  NOT NULL,
    [i9SysPersonnelID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9SysPersonnelAssignment'
CREATE TABLE [dbo].[i9SysPersonnelAssignment] (
    [JobID] bigint  NOT NULL,
    [AssignmentTitle] varchar(100)  NULL,
    [AssignmentNote] nvarchar(max)  NULL,
    [StartDateTime] datetime  NOT NULL,
    [EndDateTime] datetime  NOT NULL,
    [i9SysPersonnelAssignmentID] uniqueidentifier  NOT NULL,
    [i9SysPersonnelID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9SysPersonnelPhone'
CREATE TABLE [dbo].[i9SysPersonnelPhone] (
    [PhoneNumber] varchar(30)  NULL,
    [PhoneType] varchar(30)  NULL,
    [i9SysPersonnelPhoneID] uniqueidentifier  NOT NULL,
    [i9SysPersonnelID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9TableKey'
CREATE TABLE [dbo].[i9TableKey] (
    [TableName] varchar(50)  NOT NULL,
    [KeyValue] bigint  NOT NULL,
    [LastUpdate] datetime  NULL,
    [i9TableKeyID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9Vehicle'
CREATE TABLE [dbo].[i9Vehicle] (
    [VehicleMVI] bigint  NOT NULL,
    [VIN] varchar(100)  NULL,
    [ModelYear] varchar(100)  NULL,
    [MakeCode] varchar(100)  NULL,
    [ModelCode] varchar(100)  NULL,
    [StyleCode] varchar(100)  NULL,
    [ColorCode] varchar(100)  NULL,
    [VehicleDescription] varchar(100)  NULL,
    [LicenseNumber] varchar(100)  NULL,
    [LicenseJurisdictionCode] varchar(100)  NULL,
    [LicenseJurisdictionText] varchar(100)  NULL,
    [LicenseYear] varchar(100)  NULL,
    [LicenseTypeCode] varchar(100)  NULL,
    [TailNumber] varchar(100)  NULL,
    [FuselageColor] varchar(100)  NULL,
    [WingColor] varchar(100)  NULL,
    [EngineQuantity] varchar(100)  NULL,
    [HomeAirportID] varchar(100)  NULL,
    [HomeAirportName] varchar(100)  NULL,
    [BoatTypeCode] varchar(100)  NULL,
    [BoatTypeText] varchar(100)  NULL,
    [SerialNumber] varchar(100)  NULL,
    [BoatName] varchar(100)  NULL,
    [OverallLength] varchar(100)  NULL,
    [OverallLengthMeasureCode] varchar(100)  NULL,
    [BoatPropulsionCode] varchar(100)  NULL,
    [BoatPropulsionText] varchar(100)  NULL,
    [BoatHomePort] varchar(100)  NULL,
    [CoastGuardDocumentNumber] varchar(100)  NULL,
    [BoatPartCategoryCode] varchar(100)  NULL,
    [BoatPartCategoryText] varchar(100)  NULL,
    [BoatEnginePowerDisplacement] varchar(100)  NULL,
    [BoatEnginePowerDisplacementMeasureCode] varchar(100)  NULL,
    [BoatHullShape] varchar(100)  NULL,
    [BoatOuterHullMaterial] varchar(100)  NULL,
    [i9VehicleID] uniqueidentifier  NOT NULL,
    [i9EventID] uniqueidentifier  NOT NULL,
    [i9AgencyID] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'i9VehicleRecovery'
CREATE TABLE [dbo].[i9VehicleRecovery] (
    [i9VehicleRecoveryID] uniqueidentifier  NOT NULL,
    [i9EventID] uniqueidentifier  NOT NULL,
    [i9VehicleID] uniqueidentifier  NOT NULL,
    [Notes] varchar(100)  NULL,
    [Condition] varchar(50)  NULL
);
GO

-- Creating table 'i9VehicleTowed'
CREATE TABLE [dbo].[i9VehicleTowed] (
    [i9VehicleTowedID] uniqueidentifier  NOT NULL,
    [i9EventID] uniqueidentifier  NOT NULL,
    [i9VehicleID] uniqueidentifier  NOT NULL,
    [Notes] varchar(100)  NULL,
    [TowedDate] varchar(100)  NULL,
    [Condition] varchar(50)  NULL
);
GO

-- Creating table 'i9Warrant'
CREATE TABLE [dbo].[i9Warrant] (
    [i9WarrantID] uniqueidentifier  NOT NULL,
    [i9AgencyID] uniqueidentifier  NOT NULL,
    [i9EventID] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [i9AgencyID] in table 'i9Agency'
ALTER TABLE [dbo].[i9Agency]
ADD CONSTRAINT [PK_i9Agency]
    PRIMARY KEY CLUSTERED ([i9AgencyID] ASC);
GO

-- Creating primary key on [i9ArrestID] in table 'i9Arrest'
ALTER TABLE [dbo].[i9Arrest]
ADD CONSTRAINT [PK_i9Arrest]
    PRIMARY KEY CLUSTERED ([i9ArrestID] ASC);
GO

-- Creating primary key on [i9ArrestReportID] in table 'i9ArrestReport'
ALTER TABLE [dbo].[i9ArrestReport]
ADD CONSTRAINT [PK_i9ArrestReport]
    PRIMARY KEY CLUSTERED ([i9ArrestReportID] ASC);
GO

-- Creating primary key on [i9AttachmentID] in table 'i9Attachment'
ALTER TABLE [dbo].[i9Attachment]
ADD CONSTRAINT [PK_i9Attachment]
    PRIMARY KEY CLUSTERED ([i9AttachmentID] ASC);
GO

-- Creating primary key on [i9AttachmentDataID] in table 'i9AttachmentData'
ALTER TABLE [dbo].[i9AttachmentData]
ADD CONSTRAINT [PK_i9AttachmentData]
    PRIMARY KEY CLUSTERED ([i9AttachmentDataID] ASC);
GO

-- Creating primary key on [i9AttachmentLinkID] in table 'i9AttachmentLink'
ALTER TABLE [dbo].[i9AttachmentLink]
ADD CONSTRAINT [PK_i9AttachmentLink]
    PRIMARY KEY CLUSTERED ([i9AttachmentLinkID] ASC);
GO

-- Creating primary key on [i9AVLID] in table 'i9AVL'
ALTER TABLE [dbo].[i9AVL]
ADD CONSTRAINT [PK_i9AVL]
    PRIMARY KEY CLUSTERED ([i9AVLID] ASC);
GO

-- Creating primary key on [i9AVLEventID] in table 'i9AVLEvent'
ALTER TABLE [dbo].[i9AVLEvent]
ADD CONSTRAINT [PK_i9AVLEvent]
    PRIMARY KEY CLUSTERED ([i9AVLEventID] ASC);
GO

-- Creating primary key on [i9AVLHistoryID] in table 'i9AVLHistory'
ALTER TABLE [dbo].[i9AVLHistory]
ADD CONSTRAINT [PK_i9AVLHistory]
    PRIMARY KEY CLUSTERED ([i9AVLHistoryID] ASC);
GO

-- Creating primary key on [i9CADServiceCallID] in table 'i9CADServiceCall'
ALTER TABLE [dbo].[i9CADServiceCall]
ADD CONSTRAINT [PK_i9CADServiceCall]
    PRIMARY KEY CLUSTERED ([i9CADServiceCallID] ASC);
GO

-- Creating primary key on [i9CADServiceCallNarrativeID] in table 'i9CADServiceCallNarrative'
ALTER TABLE [dbo].[i9CADServiceCallNarrative]
ADD CONSTRAINT [PK_i9CADServiceCallNarrative]
    PRIMARY KEY CLUSTERED ([i9CADServiceCallNarrativeID] ASC);
GO

-- Creating primary key on [i9CADUnitID] in table 'i9CADUnit'
ALTER TABLE [dbo].[i9CADUnit]
ADD CONSTRAINT [PK_i9CADUnit]
    PRIMARY KEY CLUSTERED ([i9CADUnitID] ASC);
GO

-- Creating primary key on [i9ChargeID] in table 'i9Charge'
ALTER TABLE [dbo].[i9Charge]
ADD CONSTRAINT [PK_i9Charge]
    PRIMARY KEY CLUSTERED ([i9ChargeID] ASC);
GO

-- Creating primary key on [i9CitationID] in table 'i9Citation'
ALTER TABLE [dbo].[i9Citation]
ADD CONSTRAINT [PK_i9Citation]
    PRIMARY KEY CLUSTERED ([i9CitationID] ASC);
GO

-- Creating primary key on [TableName], [KeyValue] in table 'i9ClientTableKey'
ALTER TABLE [dbo].[i9ClientTableKey]
ADD CONSTRAINT [PK_i9ClientTableKey]
    PRIMARY KEY CLUSTERED ([TableName], [KeyValue] ASC);
GO

-- Creating primary key on [i9CodeID] in table 'i9Code'
ALTER TABLE [dbo].[i9Code]
ADD CONSTRAINT [PK_i9Code]
    PRIMARY KEY CLUSTERED ([i9CodeID] ASC);
GO

-- Creating primary key on [i9CodeSetID] in table 'i9CodeSet'
ALTER TABLE [dbo].[i9CodeSet]
ADD CONSTRAINT [PK_i9CodeSet]
    PRIMARY KEY CLUSTERED ([i9CodeSetID] ASC);
GO

-- Creating primary key on [i9ConfigurationSettingID] in table 'i9ConfigurationSetting'
ALTER TABLE [dbo].[i9ConfigurationSetting]
ADD CONSTRAINT [PK_i9ConfigurationSetting]
    PRIMARY KEY CLUSTERED ([i9ConfigurationSettingID] ASC);
GO

-- Creating primary key on [ModuleSection], [ModuleSectionDesc] in table 'i9DynamicEntry'
ALTER TABLE [dbo].[i9DynamicEntry]
ADD CONSTRAINT [PK_i9DynamicEntry]
    PRIMARY KEY CLUSTERED ([ModuleSection], [ModuleSectionDesc] ASC);
GO

-- Creating primary key on [i9DynamicEntryConfigID] in table 'i9DynamicEntryConfig'
ALTER TABLE [dbo].[i9DynamicEntryConfig]
ADD CONSTRAINT [PK_i9DynamicEntryConfig]
    PRIMARY KEY CLUSTERED ([i9DynamicEntryConfigID] ASC);
GO

-- Creating primary key on [CtrlTypeName], [CtrlTypeDesc] in table 'i9DynamicEntryCtrlType'
ALTER TABLE [dbo].[i9DynamicEntryCtrlType]
ADD CONSTRAINT [PK_i9DynamicEntryCtrlType]
    PRIMARY KEY CLUSTERED ([CtrlTypeName], [CtrlTypeDesc] ASC);
GO

-- Creating primary key on [i9DynamicEntryRuleID] in table 'i9DynamicEntryRule'
ALTER TABLE [dbo].[i9DynamicEntryRule]
ADD CONSTRAINT [PK_i9DynamicEntryRule]
    PRIMARY KEY CLUSTERED ([i9DynamicEntryRuleID] ASC);
GO

-- Creating primary key on [i9EmailAddressID] in table 'i9EmailAddress'
ALTER TABLE [dbo].[i9EmailAddress]
ADD CONSTRAINT [PK_i9EmailAddress]
    PRIMARY KEY CLUSTERED ([i9EmailAddressID] ASC);
GO

-- Creating primary key on [i9EmailModuleID] in table 'i9EmailModule'
ALTER TABLE [dbo].[i9EmailModule]
ADD CONSTRAINT [PK_i9EmailModule]
    PRIMARY KEY CLUSTERED ([i9EmailModuleID] ASC);
GO

-- Creating primary key on [i9EventID] in table 'i9Event'
ALTER TABLE [dbo].[i9Event]
ADD CONSTRAINT [PK_i9Event]
    PRIMARY KEY CLUSTERED ([i9EventID] ASC);
GO

-- Creating primary key on [i9EventType1] in table 'i9EventType'
ALTER TABLE [dbo].[i9EventType]
ADD CONSTRAINT [PK_i9EventType]
    PRIMARY KEY CLUSTERED ([i9EventType1] ASC);
GO

-- Creating primary key on [i9FieldContactID] in table 'i9FieldContact'
ALTER TABLE [dbo].[i9FieldContact]
ADD CONSTRAINT [PK_i9FieldContact]
    PRIMARY KEY CLUSTERED ([i9FieldContactID] ASC);
GO

-- Creating primary key on [i9GangID] in table 'i9Gang'
ALTER TABLE [dbo].[i9Gang]
ADD CONSTRAINT [PK_i9Gang]
    PRIMARY KEY CLUSTERED ([i9GangID] ASC);
GO

-- Creating primary key on [i9LawIncidentID] in table 'i9LawIncident'
ALTER TABLE [dbo].[i9LawIncident]
ADD CONSTRAINT [PK_i9LawIncident]
    PRIMARY KEY CLUSTERED ([i9LawIncidentID] ASC);
GO

-- Creating primary key on [i9LawIncidentReportID] in table 'i9LawIncidentReport'
ALTER TABLE [dbo].[i9LawIncidentReport]
ADD CONSTRAINT [PK_i9LawIncidentReport]
    PRIMARY KEY CLUSTERED ([i9LawIncidentReportID] ASC);
GO

-- Creating primary key on [i9LocationID] in table 'i9Location'
ALTER TABLE [dbo].[i9Location]
ADD CONSTRAINT [PK_i9Location]
    PRIMARY KEY CLUSTERED ([i9LocationID] ASC);
GO

-- Creating primary key on [i9MessageInboxID] in table 'i9MessageInbox'
ALTER TABLE [dbo].[i9MessageInbox]
ADD CONSTRAINT [PK_i9MessageInbox]
    PRIMARY KEY CLUSTERED ([i9MessageInboxID] ASC);
GO

-- Creating primary key on [ModuleName] in table 'i9Module'
ALTER TABLE [dbo].[i9Module]
ADD CONSTRAINT [PK_i9Module]
    PRIMARY KEY CLUSTERED ([ModuleName] ASC);
GO

-- Creating primary key on [i9ModuleReportNumberID] in table 'i9ModuleReportNumber'
ALTER TABLE [dbo].[i9ModuleReportNumber]
ADD CONSTRAINT [PK_i9ModuleReportNumber]
    PRIMARY KEY CLUSTERED ([i9ModuleReportNumberID] ASC);
GO

-- Creating primary key on [i9ModuleSectionID] in table 'i9ModuleSection'
ALTER TABLE [dbo].[i9ModuleSection]
ADD CONSTRAINT [PK_i9ModuleSection]
    PRIMARY KEY CLUSTERED ([i9ModuleSectionID] ASC);
GO

-- Creating primary key on [i9ModusOperandiID] in table 'i9ModusOperandi'
ALTER TABLE [dbo].[i9ModusOperandi]
ADD CONSTRAINT [PK_i9ModusOperandi]
    PRIMARY KEY CLUSTERED ([i9ModusOperandiID] ASC);
GO

-- Creating primary key on [i9NarrativeID] in table 'i9Narrative'
ALTER TABLE [dbo].[i9Narrative]
ADD CONSTRAINT [PK_i9Narrative]
    PRIMARY KEY CLUSTERED ([i9NarrativeID] ASC);
GO

-- Creating primary key on [i9OffenseID] in table 'i9Offense'
ALTER TABLE [dbo].[i9Offense]
ADD CONSTRAINT [PK_i9Offense]
    PRIMARY KEY CLUSTERED ([i9OffenseID] ASC);
GO

-- Creating primary key on [i9OrganizationID] in table 'i9Organization'
ALTER TABLE [dbo].[i9Organization]
ADD CONSTRAINT [PK_i9Organization]
    PRIMARY KEY CLUSTERED ([i9OrganizationID] ASC);
GO

-- Creating primary key on [i9OtherContactInformationID] in table 'i9OtherContactInformation'
ALTER TABLE [dbo].[i9OtherContactInformation]
ADD CONSTRAINT [PK_i9OtherContactInformation]
    PRIMARY KEY CLUSTERED ([i9OtherContactInformationID] ASC);
GO

-- Creating primary key on [i9OtherInvolvedPersonID] in table 'i9OtherInvolvedPerson'
ALTER TABLE [dbo].[i9OtherInvolvedPerson]
ADD CONSTRAINT [PK_i9OtherInvolvedPerson]
    PRIMARY KEY CLUSTERED ([i9OtherInvolvedPersonID] ASC);
GO

-- Creating primary key on [i9PackageID] in table 'i9Package'
ALTER TABLE [dbo].[i9Package]
ADD CONSTRAINT [PK_i9Package]
    PRIMARY KEY CLUSTERED ([i9PackageID] ASC);
GO

-- Creating primary key on [i9PackageMetadataID] in table 'i9PackageMetadata'
ALTER TABLE [dbo].[i9PackageMetadata]
ADD CONSTRAINT [PK_i9PackageMetadata]
    PRIMARY KEY CLUSTERED ([i9PackageMetadataID] ASC);
GO

-- Creating primary key on [i9PawnID] in table 'i9Pawn'
ALTER TABLE [dbo].[i9Pawn]
ADD CONSTRAINT [PK_i9Pawn]
    PRIMARY KEY CLUSTERED ([i9PawnID] ASC);
GO

-- Creating primary key on [i9PermissionID] in table 'i9Permission'
ALTER TABLE [dbo].[i9Permission]
ADD CONSTRAINT [PK_i9Permission]
    PRIMARY KEY CLUSTERED ([i9PermissionID] ASC);
GO

-- Creating primary key on [i9PersonID] in table 'i9Person'
ALTER TABLE [dbo].[i9Person]
ADD CONSTRAINT [PK_i9Person]
    PRIMARY KEY CLUSTERED ([i9PersonID] ASC);
GO

-- Creating primary key on [i9PersonArresteeID] in table 'i9PersonArrestee'
ALTER TABLE [dbo].[i9PersonArrestee]
ADD CONSTRAINT [PK_i9PersonArrestee]
    PRIMARY KEY CLUSTERED ([i9PersonArresteeID] ASC);
GO

-- Creating primary key on [i9PersonMissingID] in table 'i9PersonMissing'
ALTER TABLE [dbo].[i9PersonMissing]
ADD CONSTRAINT [PK_i9PersonMissing]
    PRIMARY KEY CLUSTERED ([i9PersonMissingID] ASC);
GO

-- Creating primary key on [i9PersonPhotoID] in table 'i9PersonPhoto'
ALTER TABLE [dbo].[i9PersonPhoto]
ADD CONSTRAINT [PK_i9PersonPhoto]
    PRIMARY KEY CLUSTERED ([i9PersonPhotoID] ASC);
GO

-- Creating primary key on [i9PersonRelatedID] in table 'i9PersonRelated'
ALTER TABLE [dbo].[i9PersonRelated]
ADD CONSTRAINT [PK_i9PersonRelated]
    PRIMARY KEY CLUSTERED ([i9PersonRelatedID] ASC);
GO

-- Creating primary key on [i9PersonSMTID] in table 'i9PersonSMT'
ALTER TABLE [dbo].[i9PersonSMT]
ADD CONSTRAINT [PK_i9PersonSMT]
    PRIMARY KEY CLUSTERED ([i9PersonSMTID] ASC);
GO

-- Creating primary key on [i9PersonSubjectID] in table 'i9PersonSubject'
ALTER TABLE [dbo].[i9PersonSubject]
ADD CONSTRAINT [PK_i9PersonSubject]
    PRIMARY KEY CLUSTERED ([i9PersonSubjectID] ASC);
GO

-- Creating primary key on [i9PersonVehicleID] in table 'i9PersonVehicle'
ALTER TABLE [dbo].[i9PersonVehicle]
ADD CONSTRAINT [PK_i9PersonVehicle]
    PRIMARY KEY CLUSTERED ([i9PersonVehicleID] ASC);
GO

-- Creating primary key on [i9PersonVictimID] in table 'i9PersonVictim'
ALTER TABLE [dbo].[i9PersonVictim]
ADD CONSTRAINT [PK_i9PersonVictim]
    PRIMARY KEY CLUSTERED ([i9PersonVictimID] ASC);
GO

-- Creating primary key on [i9PhoneNumberID] in table 'i9PhoneNumber'
ALTER TABLE [dbo].[i9PhoneNumber]
ADD CONSTRAINT [PK_i9PhoneNumber]
    PRIMARY KEY CLUSTERED ([i9PhoneNumberID] ASC);
GO

-- Creating primary key on [i9PropertyID] in table 'i9Property'
ALTER TABLE [dbo].[i9Property]
ADD CONSTRAINT [PK_i9Property]
    PRIMARY KEY CLUSTERED ([i9PropertyID] ASC);
GO

-- Creating primary key on [i9PropertyEvidenceID] in table 'i9PropertyEvidence'
ALTER TABLE [dbo].[i9PropertyEvidence]
ADD CONSTRAINT [PK_i9PropertyEvidence]
    PRIMARY KEY CLUSTERED ([i9PropertyEvidenceID] ASC);
GO

-- Creating primary key on [i9PropertyExplosiveID] in table 'i9PropertyExplosive'
ALTER TABLE [dbo].[i9PropertyExplosive]
ADD CONSTRAINT [PK_i9PropertyExplosive]
    PRIMARY KEY CLUSTERED ([i9PropertyExplosiveID] ASC);
GO

-- Creating primary key on [i9PropertyFirearmID] in table 'i9PropertyFirearm'
ALTER TABLE [dbo].[i9PropertyFirearm]
ADD CONSTRAINT [PK_i9PropertyFirearm]
    PRIMARY KEY CLUSTERED ([i9PropertyFirearmID] ASC);
GO

-- Creating primary key on [i9PropertyHazardousMaterialID] in table 'i9PropertyHazardousMaterial'
ALTER TABLE [dbo].[i9PropertyHazardousMaterial]
ADD CONSTRAINT [PK_i9PropertyHazardousMaterial]
    PRIMARY KEY CLUSTERED ([i9PropertyHazardousMaterialID] ASC);
GO

-- Creating primary key on [i9PropertyImageID] in table 'i9PropertyImage'
ALTER TABLE [dbo].[i9PropertyImage]
ADD CONSTRAINT [PK_i9PropertyImage]
    PRIMARY KEY CLUSTERED ([i9PropertyImageID] ASC);
GO

-- Creating primary key on [i9PropertySecuritiesID] in table 'i9PropertySecurities'
ALTER TABLE [dbo].[i9PropertySecurities]
ADD CONSTRAINT [PK_i9PropertySecurities]
    PRIMARY KEY CLUSTERED ([i9PropertySecuritiesID] ASC);
GO

-- Creating primary key on [i9RelatedRecordID] in table 'i9RelatedRecord'
ALTER TABLE [dbo].[i9RelatedRecord]
ADD CONSTRAINT [PK_i9RelatedRecord]
    PRIMARY KEY CLUSTERED ([i9RelatedRecordID] ASC);
GO

-- Creating primary key on [i9SecurityGroupID] in table 'i9SecurityGroup'
ALTER TABLE [dbo].[i9SecurityGroup]
ADD CONSTRAINT [PK_i9SecurityGroup]
    PRIMARY KEY CLUSTERED ([i9SecurityGroupID] ASC);
GO

-- Creating primary key on [i9SecurityGroupModuleID] in table 'i9SecurityGroupModule'
ALTER TABLE [dbo].[i9SecurityGroupModule]
ADD CONSTRAINT [PK_i9SecurityGroupModule]
    PRIMARY KEY CLUSTERED ([i9SecurityGroupModuleID] ASC);
GO

-- Creating primary key on [i9SecurityGroupTaskID] in table 'i9SecurityGroupTask'
ALTER TABLE [dbo].[i9SecurityGroupTask]
ADD CONSTRAINT [PK_i9SecurityGroupTask]
    PRIMARY KEY CLUSTERED ([i9SecurityGroupTaskID] ASC);
GO

-- Creating primary key on [TaskName] in table 'i9SecurityTask'
ALTER TABLE [dbo].[i9SecurityTask]
ADD CONSTRAINT [PK_i9SecurityTask]
    PRIMARY KEY CLUSTERED ([TaskName] ASC);
GO

-- Creating primary key on [i9SolvabilityFactorID] in table 'i9SolvabilityFactor'
ALTER TABLE [dbo].[i9SolvabilityFactor]
ADD CONSTRAINT [PK_i9SolvabilityFactor]
    PRIMARY KEY CLUSTERED ([i9SolvabilityFactorID] ASC);
GO

-- Creating primary key on [i9StructureID] in table 'i9Structure'
ALTER TABLE [dbo].[i9Structure]
ADD CONSTRAINT [PK_i9Structure]
    PRIMARY KEY CLUSTERED ([i9StructureID] ASC);
GO

-- Creating primary key on [i9SysLogID], [LogDateTime] in table 'i9SysLog'
ALTER TABLE [dbo].[i9SysLog]
ADD CONSTRAINT [PK_i9SysLog]
    PRIMARY KEY CLUSTERED ([i9SysLogID], [LogDateTime] ASC);
GO

-- Creating primary key on [i9SysPersonnelID] in table 'i9SysPersonnel'
ALTER TABLE [dbo].[i9SysPersonnel]
ADD CONSTRAINT [PK_i9SysPersonnel]
    PRIMARY KEY CLUSTERED ([i9SysPersonnelID] ASC);
GO

-- Creating primary key on [i9SysPersonnelAddressID] in table 'i9SysPersonnelAddress'
ALTER TABLE [dbo].[i9SysPersonnelAddress]
ADD CONSTRAINT [PK_i9SysPersonnelAddress]
    PRIMARY KEY CLUSTERED ([i9SysPersonnelAddressID] ASC);
GO

-- Creating primary key on [i9SysPersonnelAssignmentID] in table 'i9SysPersonnelAssignment'
ALTER TABLE [dbo].[i9SysPersonnelAssignment]
ADD CONSTRAINT [PK_i9SysPersonnelAssignment]
    PRIMARY KEY CLUSTERED ([i9SysPersonnelAssignmentID] ASC);
GO

-- Creating primary key on [i9SysPersonnelPhoneID] in table 'i9SysPersonnelPhone'
ALTER TABLE [dbo].[i9SysPersonnelPhone]
ADD CONSTRAINT [PK_i9SysPersonnelPhone]
    PRIMARY KEY CLUSTERED ([i9SysPersonnelPhoneID] ASC);
GO

-- Creating primary key on [i9TableKeyID] in table 'i9TableKey'
ALTER TABLE [dbo].[i9TableKey]
ADD CONSTRAINT [PK_i9TableKey]
    PRIMARY KEY CLUSTERED ([i9TableKeyID] ASC);
GO

-- Creating primary key on [i9VehicleID] in table 'i9Vehicle'
ALTER TABLE [dbo].[i9Vehicle]
ADD CONSTRAINT [PK_i9Vehicle]
    PRIMARY KEY CLUSTERED ([i9VehicleID] ASC);
GO

-- Creating primary key on [i9VehicleRecoveryID] in table 'i9VehicleRecovery'
ALTER TABLE [dbo].[i9VehicleRecovery]
ADD CONSTRAINT [PK_i9VehicleRecovery]
    PRIMARY KEY CLUSTERED ([i9VehicleRecoveryID] ASC);
GO

-- Creating primary key on [i9VehicleTowedID] in table 'i9VehicleTowed'
ALTER TABLE [dbo].[i9VehicleTowed]
ADD CONSTRAINT [PK_i9VehicleTowed]
    PRIMARY KEY CLUSTERED ([i9VehicleTowedID] ASC);
GO

-- Creating primary key on [i9WarrantID] in table 'i9Warrant'
ALTER TABLE [dbo].[i9Warrant]
ADD CONSTRAINT [PK_i9Warrant]
    PRIMARY KEY CLUSTERED ([i9WarrantID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [i9AgencyID] in table 'i9AVL'
ALTER TABLE [dbo].[i9AVL]
ADD CONSTRAINT [fk_i9AVL_i9Agency]
    FOREIGN KEY ([i9AgencyID])
    REFERENCES [dbo].[i9Agency]
        ([i9AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9AVL_i9Agency'
CREATE INDEX [IX_fk_i9AVL_i9Agency]
ON [dbo].[i9AVL]
    ([i9AgencyID]);
GO

-- Creating foreign key on [i9AgencyID] in table 'i9AVLEvent'
ALTER TABLE [dbo].[i9AVLEvent]
ADD CONSTRAINT [fk_i9AVLEvent_i9Agency]
    FOREIGN KEY ([i9AgencyID])
    REFERENCES [dbo].[i9Agency]
        ([i9AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9AVLEvent_i9Agency'
CREATE INDEX [IX_fk_i9AVLEvent_i9Agency]
ON [dbo].[i9AVLEvent]
    ([i9AgencyID]);
GO

-- Creating foreign key on [i9AgencyID] in table 'i9AVLHistory'
ALTER TABLE [dbo].[i9AVLHistory]
ADD CONSTRAINT [fk_i9AVLHistory_i9Agency]
    FOREIGN KEY ([i9AgencyID])
    REFERENCES [dbo].[i9Agency]
        ([i9AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9AVLHistory_i9Agency'
CREATE INDEX [IX_fk_i9AVLHistory_i9Agency]
ON [dbo].[i9AVLHistory]
    ([i9AgencyID]);
GO

-- Creating foreign key on [i9AgencyID] in table 'i9CADServiceCall'
ALTER TABLE [dbo].[i9CADServiceCall]
ADD CONSTRAINT [fk_i9CADServiceCall_i9Agency]
    FOREIGN KEY ([i9AgencyID])
    REFERENCES [dbo].[i9Agency]
        ([i9AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9CADServiceCall_i9Agency'
CREATE INDEX [IX_fk_i9CADServiceCall_i9Agency]
ON [dbo].[i9CADServiceCall]
    ([i9AgencyID]);
GO

-- Creating foreign key on [i9AgencyID] in table 'i9Citation'
ALTER TABLE [dbo].[i9Citation]
ADD CONSTRAINT [fk_i9Citation_i9Agency]
    FOREIGN KEY ([i9AgencyID])
    REFERENCES [dbo].[i9Agency]
        ([i9AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Citation_i9Agency'
CREATE INDEX [IX_fk_i9Citation_i9Agency]
ON [dbo].[i9Citation]
    ([i9AgencyID]);
GO

-- Creating foreign key on [i9AgencyID] in table 'i9Code'
ALTER TABLE [dbo].[i9Code]
ADD CONSTRAINT [fk_i9Code_i9Agency]
    FOREIGN KEY ([i9AgencyID])
    REFERENCES [dbo].[i9Agency]
        ([i9AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Code_i9Agency'
CREATE INDEX [IX_fk_i9Code_i9Agency]
ON [dbo].[i9Code]
    ([i9AgencyID]);
GO

-- Creating foreign key on [i9AgencyID] in table 'i9CodeSet'
ALTER TABLE [dbo].[i9CodeSet]
ADD CONSTRAINT [fk_i9CodeSet_i9Agency]
    FOREIGN KEY ([i9AgencyID])
    REFERENCES [dbo].[i9Agency]
        ([i9AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9CodeSet_i9Agency'
CREATE INDEX [IX_fk_i9CodeSet_i9Agency]
ON [dbo].[i9CodeSet]
    ([i9AgencyID]);
GO

-- Creating foreign key on [i9AgencyID] in table 'i9ConfigurationSetting'
ALTER TABLE [dbo].[i9ConfigurationSetting]
ADD CONSTRAINT [fk_i9ConfigurationSetting_i9Agency]
    FOREIGN KEY ([i9AgencyID])
    REFERENCES [dbo].[i9Agency]
        ([i9AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9ConfigurationSetting_i9Agency'
CREATE INDEX [IX_fk_i9ConfigurationSetting_i9Agency]
ON [dbo].[i9ConfigurationSetting]
    ([i9AgencyID]);
GO

-- Creating foreign key on [i9AgencyID] in table 'i9DynamicEntryConfig'
ALTER TABLE [dbo].[i9DynamicEntryConfig]
ADD CONSTRAINT [fk_i9DynamicEntryConfig_i9Agency]
    FOREIGN KEY ([i9AgencyID])
    REFERENCES [dbo].[i9Agency]
        ([i9AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9DynamicEntryConfig_i9Agency'
CREATE INDEX [IX_fk_i9DynamicEntryConfig_i9Agency]
ON [dbo].[i9DynamicEntryConfig]
    ([i9AgencyID]);
GO

-- Creating foreign key on [i9AgencyID] in table 'i9Event'
ALTER TABLE [dbo].[i9Event]
ADD CONSTRAINT [fk_i9Event_i9Agency]
    FOREIGN KEY ([i9AgencyID])
    REFERENCES [dbo].[i9Agency]
        ([i9AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Event_i9Agency'
CREATE INDEX [IX_fk_i9Event_i9Agency]
ON [dbo].[i9Event]
    ([i9AgencyID]);
GO

-- Creating foreign key on [i9AgencyID] in table 'i9FieldContact'
ALTER TABLE [dbo].[i9FieldContact]
ADD CONSTRAINT [fk_i9FieldContact_i9Agency]
    FOREIGN KEY ([i9AgencyID])
    REFERENCES [dbo].[i9Agency]
        ([i9AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9FieldContact_i9Agency'
CREATE INDEX [IX_fk_i9FieldContact_i9Agency]
ON [dbo].[i9FieldContact]
    ([i9AgencyID]);
GO

-- Creating foreign key on [i9AgencyID] in table 'i9Gang'
ALTER TABLE [dbo].[i9Gang]
ADD CONSTRAINT [fk_i9Gang_i9Agency]
    FOREIGN KEY ([i9AgencyID])
    REFERENCES [dbo].[i9Agency]
        ([i9AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Gang_i9Agency'
CREATE INDEX [IX_fk_i9Gang_i9Agency]
ON [dbo].[i9Gang]
    ([i9AgencyID]);
GO

-- Creating foreign key on [i9AgencyID] in table 'i9LawIncident'
ALTER TABLE [dbo].[i9LawIncident]
ADD CONSTRAINT [fk_i9LawIncident_i9Agency]
    FOREIGN KEY ([i9AgencyID])
    REFERENCES [dbo].[i9Agency]
        ([i9AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9LawIncident_i9Agency'
CREATE INDEX [IX_fk_i9LawIncident_i9Agency]
ON [dbo].[i9LawIncident]
    ([i9AgencyID]);
GO

-- Creating foreign key on [i9AgencyID] in table 'i9Location'
ALTER TABLE [dbo].[i9Location]
ADD CONSTRAINT [fk_i9Location_i9Agency]
    FOREIGN KEY ([i9AgencyID])
    REFERENCES [dbo].[i9Agency]
        ([i9AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Location_i9Agency'
CREATE INDEX [IX_fk_i9Location_i9Agency]
ON [dbo].[i9Location]
    ([i9AgencyID]);
GO

-- Creating foreign key on [i9AgencyID] in table 'i9MessageInbox'
ALTER TABLE [dbo].[i9MessageInbox]
ADD CONSTRAINT [fk_i9MessageInbox_i9Agency]
    FOREIGN KEY ([i9AgencyID])
    REFERENCES [dbo].[i9Agency]
        ([i9AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9MessageInbox_i9Agency'
CREATE INDEX [IX_fk_i9MessageInbox_i9Agency]
ON [dbo].[i9MessageInbox]
    ([i9AgencyID]);
GO

-- Creating foreign key on [i9AgencyID] in table 'i9Pawn'
ALTER TABLE [dbo].[i9Pawn]
ADD CONSTRAINT [fk_i9Pawn_i9Agency]
    FOREIGN KEY ([i9AgencyID])
    REFERENCES [dbo].[i9Agency]
        ([i9AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Pawn_i9Agency'
CREATE INDEX [IX_fk_i9Pawn_i9Agency]
ON [dbo].[i9Pawn]
    ([i9AgencyID]);
GO

-- Creating foreign key on [i9AgencyID] in table 'i9Person'
ALTER TABLE [dbo].[i9Person]
ADD CONSTRAINT [fk_i9Person_i9Agency]
    FOREIGN KEY ([i9AgencyID])
    REFERENCES [dbo].[i9Agency]
        ([i9AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Person_i9Agency'
CREATE INDEX [IX_fk_i9Person_i9Agency]
ON [dbo].[i9Person]
    ([i9AgencyID]);
GO

-- Creating foreign key on [i9AgencyID] in table 'i9Property'
ALTER TABLE [dbo].[i9Property]
ADD CONSTRAINT [fk_i9Property_i9Agency]
    FOREIGN KEY ([i9AgencyID])
    REFERENCES [dbo].[i9Agency]
        ([i9AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Property_i9Agency'
CREATE INDEX [IX_fk_i9Property_i9Agency]
ON [dbo].[i9Property]
    ([i9AgencyID]);
GO

-- Creating foreign key on [i9AgencyID] in table 'i9SecurityGroup'
ALTER TABLE [dbo].[i9SecurityGroup]
ADD CONSTRAINT [fk_i9SecurityGroup_i9Agency]
    FOREIGN KEY ([i9AgencyID])
    REFERENCES [dbo].[i9Agency]
        ([i9AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9SecurityGroup_i9Agency'
CREATE INDEX [IX_fk_i9SecurityGroup_i9Agency]
ON [dbo].[i9SecurityGroup]
    ([i9AgencyID]);
GO

-- Creating foreign key on [i9AgencyID] in table 'i9SecurityGroupModule'
ALTER TABLE [dbo].[i9SecurityGroupModule]
ADD CONSTRAINT [fk_i9SecurityGroupModule_i9Agency]
    FOREIGN KEY ([i9AgencyID])
    REFERENCES [dbo].[i9Agency]
        ([i9AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9SecurityGroupModule_i9Agency'
CREATE INDEX [IX_fk_i9SecurityGroupModule_i9Agency]
ON [dbo].[i9SecurityGroupModule]
    ([i9AgencyID]);
GO

-- Creating foreign key on [i9AgencyID] in table 'i9SecurityGroupTask'
ALTER TABLE [dbo].[i9SecurityGroupTask]
ADD CONSTRAINT [fk_i9SecurityGroupTask_i9Agency]
    FOREIGN KEY ([i9AgencyID])
    REFERENCES [dbo].[i9Agency]
        ([i9AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9SecurityGroupTask_i9Agency'
CREATE INDEX [IX_fk_i9SecurityGroupTask_i9Agency]
ON [dbo].[i9SecurityGroupTask]
    ([i9AgencyID]);
GO

-- Creating foreign key on [i9AgencyID] in table 'i9SysLog'
ALTER TABLE [dbo].[i9SysLog]
ADD CONSTRAINT [fk_i9SysLog_i9Agency]
    FOREIGN KEY ([i9AgencyID])
    REFERENCES [dbo].[i9Agency]
        ([i9AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9SysLog_i9Agency'
CREATE INDEX [IX_fk_i9SysLog_i9Agency]
ON [dbo].[i9SysLog]
    ([i9AgencyID]);
GO

-- Creating foreign key on [i9AgencyID] in table 'i9SysPersonnel'
ALTER TABLE [dbo].[i9SysPersonnel]
ADD CONSTRAINT [fk_i9SysPersonnel_i9Agency]
    FOREIGN KEY ([i9AgencyID])
    REFERENCES [dbo].[i9Agency]
        ([i9AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9SysPersonnel_i9Agency'
CREATE INDEX [IX_fk_i9SysPersonnel_i9Agency]
ON [dbo].[i9SysPersonnel]
    ([i9AgencyID]);
GO

-- Creating foreign key on [i9AgencyID] in table 'i9Vehicle'
ALTER TABLE [dbo].[i9Vehicle]
ADD CONSTRAINT [fk_i9Vehicle_i9Agency]
    FOREIGN KEY ([i9AgencyID])
    REFERENCES [dbo].[i9Agency]
        ([i9AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Vehicle_i9Agency'
CREATE INDEX [IX_fk_i9Vehicle_i9Agency]
ON [dbo].[i9Vehicle]
    ([i9AgencyID]);
GO

-- Creating foreign key on [i9AgencyID] in table 'i9Warrant'
ALTER TABLE [dbo].[i9Warrant]
ADD CONSTRAINT [fk_i9Warrant_i9Agency]
    FOREIGN KEY ([i9AgencyID])
    REFERENCES [dbo].[i9Agency]
        ([i9AgencyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Warrant_i9Agency'
CREATE INDEX [IX_fk_i9Warrant_i9Agency]
ON [dbo].[i9Warrant]
    ([i9AgencyID]);
GO

-- Creating foreign key on [i9EventID] in table 'i9Arrest'
ALTER TABLE [dbo].[i9Arrest]
ADD CONSTRAINT [fk_i9Arrest_i9Event]
    FOREIGN KEY ([i9EventID])
    REFERENCES [dbo].[i9Event]
        ([i9EventID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Arrest_i9Event'
CREATE INDEX [IX_fk_i9Arrest_i9Event]
ON [dbo].[i9Arrest]
    ([i9EventID]);
GO

-- Creating foreign key on [i9EventID] in table 'i9Attachment'
ALTER TABLE [dbo].[i9Attachment]
ADD CONSTRAINT [fk_i9Attachment_i9Event]
    FOREIGN KEY ([i9EventID])
    REFERENCES [dbo].[i9Event]
        ([i9EventID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Attachment_i9Event'
CREATE INDEX [IX_fk_i9Attachment_i9Event]
ON [dbo].[i9Attachment]
    ([i9EventID]);
GO

-- Creating foreign key on [i9AttachmentID] in table 'i9AttachmentData'
ALTER TABLE [dbo].[i9AttachmentData]
ADD CONSTRAINT [fk_i9AttachmentData_i9Attachment]
    FOREIGN KEY ([i9AttachmentID])
    REFERENCES [dbo].[i9Attachment]
        ([i9AttachmentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9AttachmentData_i9Attachment'
CREATE INDEX [IX_fk_i9AttachmentData_i9Attachment]
ON [dbo].[i9AttachmentData]
    ([i9AttachmentID]);
GO

-- Creating foreign key on [i9EventID] in table 'i9AttachmentData'
ALTER TABLE [dbo].[i9AttachmentData]
ADD CONSTRAINT [fk_i9AttachmentData_i9Event]
    FOREIGN KEY ([i9EventID])
    REFERENCES [dbo].[i9Event]
        ([i9EventID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9AttachmentData_i9Event'
CREATE INDEX [IX_fk_i9AttachmentData_i9Event]
ON [dbo].[i9AttachmentData]
    ([i9EventID]);
GO

-- Creating foreign key on [i9EventID] in table 'i9AttachmentLink'
ALTER TABLE [dbo].[i9AttachmentLink]
ADD CONSTRAINT [fk_i9AttachmentLink_i9Event]
    FOREIGN KEY ([i9EventID])
    REFERENCES [dbo].[i9Event]
        ([i9EventID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9AttachmentLink_i9Event'
CREATE INDEX [IX_fk_i9AttachmentLink_i9Event]
ON [dbo].[i9AttachmentLink]
    ([i9EventID]);
GO

-- Creating foreign key on [i9EventID] in table 'i9AVLEvent'
ALTER TABLE [dbo].[i9AVLEvent]
ADD CONSTRAINT [fk_i9AVLEvent_i9Event]
    FOREIGN KEY ([i9EventID])
    REFERENCES [dbo].[i9Event]
        ([i9EventID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9AVLEvent_i9Event'
CREATE INDEX [IX_fk_i9AVLEvent_i9Event]
ON [dbo].[i9AVLEvent]
    ([i9EventID]);
GO

-- Creating foreign key on [i9EventID] in table 'i9CADServiceCall'
ALTER TABLE [dbo].[i9CADServiceCall]
ADD CONSTRAINT [fk_i9CADServiceCall_i9Event]
    FOREIGN KEY ([i9EventID])
    REFERENCES [dbo].[i9Event]
        ([i9EventID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9CADServiceCall_i9Event'
CREATE INDEX [IX_fk_i9CADServiceCall_i9Event]
ON [dbo].[i9CADServiceCall]
    ([i9EventID]);
GO

-- Creating foreign key on [i9EventID] in table 'i9Citation'
ALTER TABLE [dbo].[i9Citation]
ADD CONSTRAINT [fk_i9Citation_i9Event]
    FOREIGN KEY ([i9EventID])
    REFERENCES [dbo].[i9Event]
        ([i9EventID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Citation_i9Event'
CREATE INDEX [IX_fk_i9Citation_i9Event]
ON [dbo].[i9Citation]
    ([i9EventID]);
GO

-- Creating foreign key on [i9EventType] in table 'i9Event'
ALTER TABLE [dbo].[i9Event]
ADD CONSTRAINT [fk_i9Event_i9EventType]
    FOREIGN KEY ([i9EventType])
    REFERENCES [dbo].[i9EventType]
        ([i9EventType1])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Event_i9EventType'
CREATE INDEX [IX_fk_i9Event_i9EventType]
ON [dbo].[i9Event]
    ([i9EventType]);
GO

-- Creating foreign key on [i9EventID] in table 'i9FieldContact'
ALTER TABLE [dbo].[i9FieldContact]
ADD CONSTRAINT [fk_i9FieldContact_i9Event]
    FOREIGN KEY ([i9EventID])
    REFERENCES [dbo].[i9Event]
        ([i9EventID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9FieldContact_i9Event'
CREATE INDEX [IX_fk_i9FieldContact_i9Event]
ON [dbo].[i9FieldContact]
    ([i9EventID]);
GO

-- Creating foreign key on [i9EventID] in table 'i9Gang'
ALTER TABLE [dbo].[i9Gang]
ADD CONSTRAINT [fk_i9Gang_i9Event]
    FOREIGN KEY ([i9EventID])
    REFERENCES [dbo].[i9Event]
        ([i9EventID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Gang_i9Event'
CREATE INDEX [IX_fk_i9Gang_i9Event]
ON [dbo].[i9Gang]
    ([i9EventID]);
GO

-- Creating foreign key on [i9EventID] in table 'i9LawIncident'
ALTER TABLE [dbo].[i9LawIncident]
ADD CONSTRAINT [fk_i9LawIncident_i9Event]
    FOREIGN KEY ([i9EventID])
    REFERENCES [dbo].[i9Event]
        ([i9EventID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9LawIncident_i9Event'
CREATE INDEX [IX_fk_i9LawIncident_i9Event]
ON [dbo].[i9LawIncident]
    ([i9EventID]);
GO

-- Creating foreign key on [i9EventID] in table 'i9Location'
ALTER TABLE [dbo].[i9Location]
ADD CONSTRAINT [fk_i9Location_i9Event]
    FOREIGN KEY ([i9EventID])
    REFERENCES [dbo].[i9Event]
        ([i9EventID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Location_i9Event'
CREATE INDEX [IX_fk_i9Location_i9Event]
ON [dbo].[i9Location]
    ([i9EventID]);
GO

-- Creating foreign key on [i9EventID] in table 'i9Narrative'
ALTER TABLE [dbo].[i9Narrative]
ADD CONSTRAINT [fk_i9Narrative_i9Event]
    FOREIGN KEY ([i9EventID])
    REFERENCES [dbo].[i9Event]
        ([i9EventID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Narrative_i9Event'
CREATE INDEX [IX_fk_i9Narrative_i9Event]
ON [dbo].[i9Narrative]
    ([i9EventID]);
GO

-- Creating foreign key on [i9EventID] in table 'i9Organization'
ALTER TABLE [dbo].[i9Organization]
ADD CONSTRAINT [fk_i9Organization_i9Event]
    FOREIGN KEY ([i9EventID])
    REFERENCES [dbo].[i9Event]
        ([i9EventID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Organization_i9Event'
CREATE INDEX [IX_fk_i9Organization_i9Event]
ON [dbo].[i9Organization]
    ([i9EventID]);
GO

-- Creating foreign key on [i9EventID] in table 'i9Pawn'
ALTER TABLE [dbo].[i9Pawn]
ADD CONSTRAINT [fk_i9Pawn_i9Event]
    FOREIGN KEY ([i9EventID])
    REFERENCES [dbo].[i9Event]
        ([i9EventID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Pawn_i9Event'
CREATE INDEX [IX_fk_i9Pawn_i9Event]
ON [dbo].[i9Pawn]
    ([i9EventID]);
GO

-- Creating foreign key on [i9EventID] in table 'i9Person'
ALTER TABLE [dbo].[i9Person]
ADD CONSTRAINT [fk_i9Person_i9Event]
    FOREIGN KEY ([i9EventID])
    REFERENCES [dbo].[i9Event]
        ([i9EventID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Person_i9Event'
CREATE INDEX [IX_fk_i9Person_i9Event]
ON [dbo].[i9Person]
    ([i9EventID]);
GO

-- Creating foreign key on [i9EventID] in table 'i9PersonSMT'
ALTER TABLE [dbo].[i9PersonSMT]
ADD CONSTRAINT [fk_i9PersonSMT_i9Event]
    FOREIGN KEY ([i9EventID])
    REFERENCES [dbo].[i9Event]
        ([i9EventID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9PersonSMT_i9Event'
CREATE INDEX [IX_fk_i9PersonSMT_i9Event]
ON [dbo].[i9PersonSMT]
    ([i9EventID]);
GO

-- Creating foreign key on [i9EventID] in table 'i9Property'
ALTER TABLE [dbo].[i9Property]
ADD CONSTRAINT [fk_i9Property_i9Event]
    FOREIGN KEY ([i9EventID])
    REFERENCES [dbo].[i9Event]
        ([i9EventID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Property_i9Event'
CREATE INDEX [IX_fk_i9Property_i9Event]
ON [dbo].[i9Property]
    ([i9EventID]);
GO

-- Creating foreign key on [i9EventID] in table 'i9RelatedRecord'
ALTER TABLE [dbo].[i9RelatedRecord]
ADD CONSTRAINT [fk_i9RelatedRecord_i9Event]
    FOREIGN KEY ([i9EventID])
    REFERENCES [dbo].[i9Event]
        ([i9EventID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9RelatedRecord_i9Event'
CREATE INDEX [IX_fk_i9RelatedRecord_i9Event]
ON [dbo].[i9RelatedRecord]
    ([i9EventID]);
GO

-- Creating foreign key on [i9EventID] in table 'i9Structure'
ALTER TABLE [dbo].[i9Structure]
ADD CONSTRAINT [fk_i9Structure_i9Event]
    FOREIGN KEY ([i9EventID])
    REFERENCES [dbo].[i9Event]
        ([i9EventID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Structure_i9Event'
CREATE INDEX [IX_fk_i9Structure_i9Event]
ON [dbo].[i9Structure]
    ([i9EventID]);
GO

-- Creating foreign key on [i9EventID] in table 'i9Vehicle'
ALTER TABLE [dbo].[i9Vehicle]
ADD CONSTRAINT [fk_i9Vehicle_i9Event]
    FOREIGN KEY ([i9EventID])
    REFERENCES [dbo].[i9Event]
        ([i9EventID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Vehicle_i9Event'
CREATE INDEX [IX_fk_i9Vehicle_i9Event]
ON [dbo].[i9Vehicle]
    ([i9EventID]);
GO

-- Creating foreign key on [i9EventID] in table 'i9VehicleRecovery'
ALTER TABLE [dbo].[i9VehicleRecovery]
ADD CONSTRAINT [fk_i9VehicleRecovery_i9Event]
    FOREIGN KEY ([i9EventID])
    REFERENCES [dbo].[i9Event]
        ([i9EventID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9VehicleRecovery_i9Event'
CREATE INDEX [IX_fk_i9VehicleRecovery_i9Event]
ON [dbo].[i9VehicleRecovery]
    ([i9EventID]);
GO

-- Creating foreign key on [i9EventID] in table 'i9VehicleTowed'
ALTER TABLE [dbo].[i9VehicleTowed]
ADD CONSTRAINT [fk_i9VehicleTowed_i9Event]
    FOREIGN KEY ([i9EventID])
    REFERENCES [dbo].[i9Event]
        ([i9EventID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9VehicleTowed_i9Event'
CREATE INDEX [IX_fk_i9VehicleTowed_i9Event]
ON [dbo].[i9VehicleTowed]
    ([i9EventID]);
GO

-- Creating foreign key on [i9EventID] in table 'i9Warrant'
ALTER TABLE [dbo].[i9Warrant]
ADD CONSTRAINT [fk_i9Warrant_i9Event]
    FOREIGN KEY ([i9EventID])
    REFERENCES [dbo].[i9Event]
        ([i9EventID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Warrant_i9Event'
CREATE INDEX [IX_fk_i9Warrant_i9Event]
ON [dbo].[i9Warrant]
    ([i9EventID]);
GO

-- Creating foreign key on [i9LawIncidentID] in table 'i9LawIncident'
ALTER TABLE [dbo].[i9LawIncident]
ADD CONSTRAINT [FK_i9LawIncident_i9ModuleSection]
    FOREIGN KEY ([i9LawIncidentID])
    REFERENCES [dbo].[i9LawIncident]
        ([i9LawIncidentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [i9LawIncidentID] in table 'i9ModusOperandi'
ALTER TABLE [dbo].[i9ModusOperandi]
ADD CONSTRAINT [fk_i9ModusOperandi_i9LawIncident]
    FOREIGN KEY ([i9LawIncidentID])
    REFERENCES [dbo].[i9LawIncident]
        ([i9LawIncidentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9ModusOperandi_i9LawIncident'
CREATE INDEX [IX_fk_i9ModusOperandi_i9LawIncident]
ON [dbo].[i9ModusOperandi]
    ([i9LawIncidentID]);
GO

-- Creating foreign key on [i9LawIncidentID] in table 'i9Offense'
ALTER TABLE [dbo].[i9Offense]
ADD CONSTRAINT [fk_i9Offense_i9LawIncident]
    FOREIGN KEY ([i9LawIncidentID])
    REFERENCES [dbo].[i9LawIncident]
        ([i9LawIncidentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Offense_i9LawIncident'
CREATE INDEX [IX_fk_i9Offense_i9LawIncident]
ON [dbo].[i9Offense]
    ([i9LawIncidentID]);
GO

-- Creating foreign key on [i9ModuleSectionID] in table 'i9Location'
ALTER TABLE [dbo].[i9Location]
ADD CONSTRAINT [fk_i9Location_i9ModuleSection]
    FOREIGN KEY ([i9ModuleSectionID])
    REFERENCES [dbo].[i9ModuleSection]
        ([i9ModuleSectionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Location_i9ModuleSection'
CREATE INDEX [IX_fk_i9Location_i9ModuleSection]
ON [dbo].[i9Location]
    ([i9ModuleSectionID]);
GO

-- Creating foreign key on [i9PersonID] in table 'i9Location'
ALTER TABLE [dbo].[i9Location]
ADD CONSTRAINT [fk_i9Location_i9Person]
    FOREIGN KEY ([i9PersonID])
    REFERENCES [dbo].[i9Person]
        ([i9PersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Location_i9Person'
CREATE INDEX [IX_fk_i9Location_i9Person]
ON [dbo].[i9Location]
    ([i9PersonID]);
GO

-- Creating foreign key on [i9VehicleID] in table 'i9Location'
ALTER TABLE [dbo].[i9Location]
ADD CONSTRAINT [fk_i9Location_i9Vehicle]
    FOREIGN KEY ([i9VehicleID])
    REFERENCES [dbo].[i9Vehicle]
        ([i9VehicleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Location_i9Vehicle'
CREATE INDEX [IX_fk_i9Location_i9Vehicle]
ON [dbo].[i9Location]
    ([i9VehicleID]);
GO

-- Creating foreign key on [i9ModuleSectionID] in table 'i9Person'
ALTER TABLE [dbo].[i9Person]
ADD CONSTRAINT [fk_i9Person_i9ModuleSection]
    FOREIGN KEY ([i9ModuleSectionID])
    REFERENCES [dbo].[i9ModuleSection]
        ([i9ModuleSectionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Person_i9ModuleSection'
CREATE INDEX [IX_fk_i9Person_i9ModuleSection]
ON [dbo].[i9Person]
    ([i9ModuleSectionID]);
GO

-- Creating foreign key on [i9PersonAKAID] in table 'i9Person'
ALTER TABLE [dbo].[i9Person]
ADD CONSTRAINT [fk_i9Person_i9Person]
    FOREIGN KEY ([i9PersonAKAID])
    REFERENCES [dbo].[i9Person]
        ([i9PersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9Person_i9Person'
CREATE INDEX [IX_fk_i9Person_i9Person]
ON [dbo].[i9Person]
    ([i9PersonAKAID]);
GO

-- Creating foreign key on [i9PersonID] in table 'i9PersonArrestee'
ALTER TABLE [dbo].[i9PersonArrestee]
ADD CONSTRAINT [fk_i9PersonArrestee_i9Person]
    FOREIGN KEY ([i9PersonID])
    REFERENCES [dbo].[i9Person]
        ([i9PersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9PersonArrestee_i9Person'
CREATE INDEX [IX_fk_i9PersonArrestee_i9Person]
ON [dbo].[i9PersonArrestee]
    ([i9PersonID]);
GO

-- Creating foreign key on [i9PersonID] in table 'i9PersonMissing'
ALTER TABLE [dbo].[i9PersonMissing]
ADD CONSTRAINT [fk_i9PersonMissing_i9Person]
    FOREIGN KEY ([i9PersonID])
    REFERENCES [dbo].[i9Person]
        ([i9PersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9PersonMissing_i9Person'
CREATE INDEX [IX_fk_i9PersonMissing_i9Person]
ON [dbo].[i9PersonMissing]
    ([i9PersonID]);
GO

-- Creating foreign key on [i9PersonID] in table 'i9PersonPhoto'
ALTER TABLE [dbo].[i9PersonPhoto]
ADD CONSTRAINT [fk_i9PersonPhoto_i9Person]
    FOREIGN KEY ([i9PersonID])
    REFERENCES [dbo].[i9Person]
        ([i9PersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9PersonPhoto_i9Person'
CREATE INDEX [IX_fk_i9PersonPhoto_i9Person]
ON [dbo].[i9PersonPhoto]
    ([i9PersonID]);
GO

-- Creating foreign key on [i9PersonID] in table 'i9PersonRelated'
ALTER TABLE [dbo].[i9PersonRelated]
ADD CONSTRAINT [fk_i9PersonRelated_i9Person]
    FOREIGN KEY ([i9PersonID])
    REFERENCES [dbo].[i9Person]
        ([i9PersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9PersonRelated_i9Person'
CREATE INDEX [IX_fk_i9PersonRelated_i9Person]
ON [dbo].[i9PersonRelated]
    ([i9PersonID]);
GO

-- Creating foreign key on [i9PersonIDRelated] in table 'i9PersonRelated'
ALTER TABLE [dbo].[i9PersonRelated]
ADD CONSTRAINT [fk_i9PersonRelated_i9Person_i9PersonIDRelated]
    FOREIGN KEY ([i9PersonIDRelated])
    REFERENCES [dbo].[i9Person]
        ([i9PersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9PersonRelated_i9Person_i9PersonIDRelated'
CREATE INDEX [IX_fk_i9PersonRelated_i9Person_i9PersonIDRelated]
ON [dbo].[i9PersonRelated]
    ([i9PersonIDRelated]);
GO

-- Creating foreign key on [i9PersonID] in table 'i9PersonSMT'
ALTER TABLE [dbo].[i9PersonSMT]
ADD CONSTRAINT [fk_i9PersonSMT_i9Person]
    FOREIGN KEY ([i9PersonID])
    REFERENCES [dbo].[i9Person]
        ([i9PersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9PersonSMT_i9Person'
CREATE INDEX [IX_fk_i9PersonSMT_i9Person]
ON [dbo].[i9PersonSMT]
    ([i9PersonID]);
GO

-- Creating foreign key on [i9PersonID] in table 'i9PersonSubject'
ALTER TABLE [dbo].[i9PersonSubject]
ADD CONSTRAINT [fk_i9PersonSubject_i9Person]
    FOREIGN KEY ([i9PersonID])
    REFERENCES [dbo].[i9Person]
        ([i9PersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9PersonSubject_i9Person'
CREATE INDEX [IX_fk_i9PersonSubject_i9Person]
ON [dbo].[i9PersonSubject]
    ([i9PersonID]);
GO

-- Creating foreign key on [i9PersonID] in table 'i9PersonVehicle'
ALTER TABLE [dbo].[i9PersonVehicle]
ADD CONSTRAINT [fk_i9PersonVehicle_i9Person]
    FOREIGN KEY ([i9PersonID])
    REFERENCES [dbo].[i9Person]
        ([i9PersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9PersonVehicle_i9Person'
CREATE INDEX [IX_fk_i9PersonVehicle_i9Person]
ON [dbo].[i9PersonVehicle]
    ([i9PersonID]);
GO

-- Creating foreign key on [i9PersonID] in table 'i9PersonVictim'
ALTER TABLE [dbo].[i9PersonVictim]
ADD CONSTRAINT [fk_i9PersonVictim_i9Person]
    FOREIGN KEY ([i9PersonID])
    REFERENCES [dbo].[i9Person]
        ([i9PersonID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9PersonVictim_i9Person'
CREATE INDEX [IX_fk_i9PersonVictim_i9Person]
ON [dbo].[i9PersonVictim]
    ([i9PersonID]);
GO

-- Creating foreign key on [i9VehicleID] in table 'i9PersonVehicle'
ALTER TABLE [dbo].[i9PersonVehicle]
ADD CONSTRAINT [fk_i9PersonVehicle_i9Vehicle]
    FOREIGN KEY ([i9VehicleID])
    REFERENCES [dbo].[i9Vehicle]
        ([i9VehicleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9PersonVehicle_i9Vehicle'
CREATE INDEX [IX_fk_i9PersonVehicle_i9Vehicle]
ON [dbo].[i9PersonVehicle]
    ([i9VehicleID]);
GO

-- Creating foreign key on [i9PropertyID] in table 'i9PropertyEvidence'
ALTER TABLE [dbo].[i9PropertyEvidence]
ADD CONSTRAINT [fk_i9PropertyEvidence_i9Property]
    FOREIGN KEY ([i9PropertyID])
    REFERENCES [dbo].[i9Property]
        ([i9PropertyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9PropertyEvidence_i9Property'
CREATE INDEX [IX_fk_i9PropertyEvidence_i9Property]
ON [dbo].[i9PropertyEvidence]
    ([i9PropertyID]);
GO

-- Creating foreign key on [i9PropertyID] in table 'i9PropertyExplosive'
ALTER TABLE [dbo].[i9PropertyExplosive]
ADD CONSTRAINT [fk_i9PropertyExplosive_i9Property]
    FOREIGN KEY ([i9PropertyID])
    REFERENCES [dbo].[i9Property]
        ([i9PropertyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9PropertyExplosive_i9Property'
CREATE INDEX [IX_fk_i9PropertyExplosive_i9Property]
ON [dbo].[i9PropertyExplosive]
    ([i9PropertyID]);
GO

-- Creating foreign key on [i9PropertyID] in table 'i9PropertyFirearm'
ALTER TABLE [dbo].[i9PropertyFirearm]
ADD CONSTRAINT [fk_i9PropertyFirearm_i9Property]
    FOREIGN KEY ([i9PropertyID])
    REFERENCES [dbo].[i9Property]
        ([i9PropertyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9PropertyFirearm_i9Property'
CREATE INDEX [IX_fk_i9PropertyFirearm_i9Property]
ON [dbo].[i9PropertyFirearm]
    ([i9PropertyID]);
GO

-- Creating foreign key on [i9PropertyID] in table 'i9PropertyHazardousMaterial'
ALTER TABLE [dbo].[i9PropertyHazardousMaterial]
ADD CONSTRAINT [fk_i9PropertyHazardousMaterial_i9Property]
    FOREIGN KEY ([i9PropertyID])
    REFERENCES [dbo].[i9Property]
        ([i9PropertyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9PropertyHazardousMaterial_i9Property'
CREATE INDEX [IX_fk_i9PropertyHazardousMaterial_i9Property]
ON [dbo].[i9PropertyHazardousMaterial]
    ([i9PropertyID]);
GO

-- Creating foreign key on [i9PropertyID] in table 'i9PropertyImage'
ALTER TABLE [dbo].[i9PropertyImage]
ADD CONSTRAINT [fk_i9PropertyImage_i9Property]
    FOREIGN KEY ([i9PropertyID])
    REFERENCES [dbo].[i9Property]
        ([i9PropertyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9PropertyImage_i9Property'
CREATE INDEX [IX_fk_i9PropertyImage_i9Property]
ON [dbo].[i9PropertyImage]
    ([i9PropertyID]);
GO

-- Creating foreign key on [i9PropertyID] in table 'i9PropertySecurities'
ALTER TABLE [dbo].[i9PropertySecurities]
ADD CONSTRAINT [fk_i9PropertySecurities_i9Property]
    FOREIGN KEY ([i9PropertyID])
    REFERENCES [dbo].[i9Property]
        ([i9PropertyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9PropertySecurities_i9Property'
CREATE INDEX [IX_fk_i9PropertySecurities_i9Property]
ON [dbo].[i9PropertySecurities]
    ([i9PropertyID]);
GO

-- Creating foreign key on [i9SysPersonnelID] in table 'i9SysPersonnelAddress'
ALTER TABLE [dbo].[i9SysPersonnelAddress]
ADD CONSTRAINT [fk_i9SysPersonnelAddress_i9SysPersonnel]
    FOREIGN KEY ([i9SysPersonnelID])
    REFERENCES [dbo].[i9SysPersonnel]
        ([i9SysPersonnelID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9SysPersonnelAddress_i9SysPersonnel'
CREATE INDEX [IX_fk_i9SysPersonnelAddress_i9SysPersonnel]
ON [dbo].[i9SysPersonnelAddress]
    ([i9SysPersonnelID]);
GO

-- Creating foreign key on [i9SysPersonnelID] in table 'i9SysPersonnelAssignment'
ALTER TABLE [dbo].[i9SysPersonnelAssignment]
ADD CONSTRAINT [fk_i9SysPersonnelAssignment_i9SysPersonnel]
    FOREIGN KEY ([i9SysPersonnelID])
    REFERENCES [dbo].[i9SysPersonnel]
        ([i9SysPersonnelID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9SysPersonnelAssignment_i9SysPersonnel'
CREATE INDEX [IX_fk_i9SysPersonnelAssignment_i9SysPersonnel]
ON [dbo].[i9SysPersonnelAssignment]
    ([i9SysPersonnelID]);
GO

-- Creating foreign key on [i9SysPersonnelID] in table 'i9SysPersonnelPhone'
ALTER TABLE [dbo].[i9SysPersonnelPhone]
ADD CONSTRAINT [fk_i9SysPersonnelPhone_i9SysPersonnel]
    FOREIGN KEY ([i9SysPersonnelID])
    REFERENCES [dbo].[i9SysPersonnel]
        ([i9SysPersonnelID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9SysPersonnelPhone_i9SysPersonnel'
CREATE INDEX [IX_fk_i9SysPersonnelPhone_i9SysPersonnel]
ON [dbo].[i9SysPersonnelPhone]
    ([i9SysPersonnelID]);
GO

-- Creating foreign key on [i9VehicleID] in table 'i9VehicleRecovery'
ALTER TABLE [dbo].[i9VehicleRecovery]
ADD CONSTRAINT [fk_i9VehicleRecovery_i9Vehicle]
    FOREIGN KEY ([i9VehicleID])
    REFERENCES [dbo].[i9Vehicle]
        ([i9VehicleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9VehicleRecovery_i9Vehicle'
CREATE INDEX [IX_fk_i9VehicleRecovery_i9Vehicle]
ON [dbo].[i9VehicleRecovery]
    ([i9VehicleID]);
GO

-- Creating foreign key on [i9VehicleID] in table 'i9VehicleTowed'
ALTER TABLE [dbo].[i9VehicleTowed]
ADD CONSTRAINT [fk_i9VehicleTowed_i9Vehicle]
    FOREIGN KEY ([i9VehicleID])
    REFERENCES [dbo].[i9Vehicle]
        ([i9VehicleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_i9VehicleTowed_i9Vehicle'
CREATE INDEX [IX_fk_i9VehicleTowed_i9Vehicle]
ON [dbo].[i9VehicleTowed]
    ([i9VehicleID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------