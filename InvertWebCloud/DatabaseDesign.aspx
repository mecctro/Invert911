<%@ Page Title="Invert911 - DB Design" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DatabaseDesign.aspx.cs" Inherits="Invert911_WebSite.DatabaseDesign" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <h2>
        Database Design<br/>
        </h2>
        <p>
Below is a list of database tables that are used in the invert911 application.&nbsp; 
I also use a couple of store procedures that are not listed here.&nbsp;
</p>

         <br/>
         <br/>
        i9Agency: <br/>
        <ul>
        <li>Address1  varchar(80) </li>
        <li>Address2  varchar(80) </li>
        <li>AgencyDesc  varchar(100) </li>
        <li>AgencyName  varchar(60) </li>
        <li>City  varchar(60) </li>
        <li>FaxNumber  varchar(30) </li>
        <li>i9AgencyID  uniqueidentifier   </li>
        <li>PhoneNumber  varchar(30) </li>
        <li>State  varchar(40) </li>
        <li>Zip  varchar(20) </li>
        </ul>
         <br/>
        i9Arrest: <br/>
        <ul>
        <li>ActivityCategory  varchar(100) </li>
        <li>ArrestDate  varchar(100) </li>
        <li>Arrestee  varchar(100) </li>
        <li>ArrestingOfficer  varchar(100) </li>
        <li>ArrestTypeCode  varchar(100) </li>
        <li>i9ArrestID  uniqueidentifier   </li>
        <li>i9EventID  uniqueidentifier   </li>
        <li>NarrativeAccountDescription  varchar(100) </li>
        <li>NarrativeAccountDescriptionDate  varchar(100) </li>
        <li>ORI_OriginatingAgencyIdentifier  varchar(100) </li>
        <li>TransactionNumber  varchar(100) </li>
        </ul>
         <br/>
        i9ArrestReport: <br/>
        <ul>
        <li>i9ArrestReportID  uniqueidentifier   </li>
        </ul>
         <br/>
        i9Attachment: <br/>
        <ul>
        <li>AttachmentFile  image(2147483647) </li>
        <li>AttachmentName  varchar(100) </li>
        <li>AttachmentNotes  varchar(100) </li>
        <li>Capturedate  datetime   </li>
        <li>i9AttachmentID  uniqueidentifier   </li>
        <li>i9EventID  uniqueidentifier   </li>
        <li>ImageTypeCode  varchar(100) </li>
        <li>ImageTypeText  varchar(100) </li>
        </ul>
         <br/>
        i9AttachmentData: <br/>
        <ul>
        <li>Data  image(2147483647) </li>
        <li>i9AttachmentDataID  uniqueidentifier   </li>
        <li>i9AttachmentID  uniqueidentifier   </li>
        <li>i9EventID  uniqueidentifier   </li>
        </ul>
         <br/>
        i9AttachmentLink: <br/>
        <ul>
        <li>AttachmentURI  varchar(100) </li>
        <li>Description  varchar(100) </li>
        <li>i9AttachmentLinkID  uniqueidentifier   </li>
        <li>i9EventID  uniqueidentifier   </li>
        <li>ViewableIndicator  varchar(100) </li>
        </ul>
         <br/>
        i9Charge: <br/>
        <ul>
        <li>i9ChargeID  uniqueidentifier   </li>
        </ul>
         <br/>
        i9Citation: <br/>
        <ul>
        <li>i9AgencyID  uniqueidentifier   </li>
        <li>i9CitationID  uniqueidentifier   </li>
        <li>i9EventID  uniqueidentifier   </li>
        </ul>
         <br/>
        i9ClientTableKey: <br/>
        <ul>
        <li>KeyValue  bigint   </li>
        <li>LastUpdate  datetime   </li>
        <li>TableName  varchar(50) </li>
        </ul>
         <br/>
        i9Code: <br/>
        <ul>
        <li>Code  varchar(200) </li>
        <li>CodeSetName  varchar(50) </li>
        <li>CodeText  varchar(2000) </li>
        <li>Enabled  int   </li>
        <li>i9AgencyID  uniqueidentifier   </li>
        <li>i9CodeID  uniqueidentifier   </li>
        <li>LastUpdate  datetime   </li>
        </ul>
         <br/>
        i9CodeSet: <br/>
        <ul>
        <li>CodeSetDesc  varchar(100) </li>
        <li>CodeSetName  varchar(50) </li>
        <li>i9AgencyID  uniqueidentifier   </li>
        <li>i9CodeSetID  uniqueidentifier   </li>
        <li>LastUpdate  datetime   </li>
        </ul>
         <br/>
        i9ConfigurationSetting: <br/>
        <ul>
        <li>ConfigurationSettingName  varchar(100) </li>
        <li>ConfigurationSettingSection  varchar(100) </li>
        <li>ConfigurationSettingValue  varchar(100) </li>
        <li>i9AgencyID  uniqueidentifier   </li>
        <li>i9ConfigurationSettingID  uniqueidentifier   </li>
        </ul>
         <br/>
        i9DynamicEntry: <br/>
        <ul>
        <li>DynamicEntryTable  varchar(50) </li>
        <li>LastUpdate  datetime   </li>
        <li>ModuleSection  varchar(50) </li>
        <li>ModuleSectionDesc  varchar(50) </li>
        </ul>
         <br/>
        i9DynamicEntryConfig: <br/>
        <ul>
        <li>ColumnName  varchar(50) </li>
        <li>CtrlBackGroundColor  varchar(50) </li>
        <li>CtrlFont  varchar(50) </li>
        <li>CtrlForGroundColor  varchar(50) </li>
        <li>CtrlHeight  varchar(50) </li>
        <li>CtrlTypeName  varchar(50) </li>
        <li>CtrlWidth  varchar(50) </li>
        <li>DataType  varchar(50) </li>
        <li>DisplayOrder  real   </li>
        <li>Enabled  int   </li>
        <li>i9AgencyID  uniqueidentifier   </li>
        <li>i9DynamicEntryConfigID  uniqueidentifier   </li>
        <li>IsReadOnly  int   </li>
        <li>LabelText  varchar(50) </li>
        <li>LastUpdate  datetime   </li>
        <li>MaxLength  int   </li>
        <li>ModuleSection  varchar(50) </li>
        <li>PrintEnabled  int   </li>
        <li>TableName  varchar(50) </li>
        <li>ToolPopup  varchar(50) </li>
        </ul>
         <br/>
        i9DynamicEntryCtrlType: <br/>
        <ul>
        <li>CtrlTypeDesc  varchar(50) </li>
        <li>CtrlTypeName  varchar(50) </li>
        <li>LastUpdate  datetime   </li>
        </ul>
         <br/>
        i9DynamicEntryRule: <br/>
        <ul>
        <li>i9DynamicEntryRuleID  uniqueidentifier   </li>
        <li>i9DynanicEntryConfigID  bigint   </li>
        <li>i9DynanicEntryConfigID2  bigint   </li>
        <li>LastUpdate  datetime   </li>
        <li>MaxValue  varchar(50) </li>
        <li>MinValue  varchar(50) </li>
        <li>RuleType  varchar(50) </li>
        </ul>
         <br/>
        i9EmailAddress: <br/>
        <ul>
        <li>EmailAddress  varchar(100) </li>
        <li>EmailType  varchar(10) </li>
        <li>i9EmailAddressID  uniqueidentifier   </li>
        </ul>
         <br/>
        i9EmailModule: <br/>
        <ul>
        <li>BCCEmailAddress  varchar(-1) </li>
        <li>Body  varchar(-1) </li>
        <li>CCEmailAddress  varchar(-1) </li>
        <li>EmailStatusFlag  tinyint   </li>
        <li>FromEmailAddress  varchar(255) </li>
        <li>i9EmailModuleID  uniqueidentifier   </li>
        <li>InsertDate  datetime   </li>
        <li>InsertENTUserAccountId  int   </li>
        <li>Subject  varchar(-1) </li>
        <li>ToEmailAddress  varchar(-1) </li>
        <li>UpdateDate  datetime   </li>
        <li>UpdateENTUserAccountId  int   </li>
        <li>Version  timestamp   </li>
        </ul>
         <br/>
        i9Event: <br/>
        <ul>
        <li>i9AgencyID  uniqueidentifier   </li>
        <li>i9EventID  uniqueidentifier   </li>
        <li>i9EventType  varchar(20) </li>
        </ul>
         <br/>
        i9EventType: <br/>
        <ul>
        <li>EventDesc  varchar(30) </li>
        <li>i9EventType  varchar(20) </li>
        </ul>
         <br/>
        i9FieldContact: <br/>
        <ul>
        <li>i9AgencyID  uniqueidentifier   </li>
        <li>i9EventID  uniqueidentifier   </li>
        <li>i9FieldContactID  uniqueidentifier   </li>
        </ul>
         <br/>
        i9Gang: <br/>
        <ul>
        <li>GangDesc  varchar(30) </li>
        <li>GangName  varchar(30) </li>
        <li>GangType  varchar(10) </li>
        <li>i9AgencyID  uniqueidentifier   </li>
        <li>i9EventID  uniqueidentifier   </li>
        <li>i9GangID  uniqueidentifier   </li>
        </ul>
         <br/>
        i9LawIncident: <br/>
        <ul>
        <li>ActivityCategory  varchar(50) </li>
        <li>AgencyNotificationIndicator  varchar(100) </li>
        <li>BeginDate  varchar(100) </li>
        <li>BeginTime  varchar(100) </li>
        <li>EndDate  varchar(100) </li>
        <li>EndTime  varchar(100) </li>
        <li>Evidence  varchar(100) </li>
        <li>EvidenceHeldIndicator  varchar(100) </li>
        <li>ExceptionalClearanceCode  varchar(100) </li>
        <li>ExceptionalClearanceDate  varchar(100) </li>
        <li>FactorCode  varchar(100) </li>
        <li>FactorText  varchar(100) </li>
        <li>i9AgencyID  uniqueidentifier   </li>
        <li>i9EventID  uniqueidentifier   </li>
        <li>i9LawIncidentID  uniqueidentifier   </li>
        <li>IncidentDisseminationLevelCode  varchar(100) </li>
        <li>IncidentLightingCode  varchar(100) </li>
        <li>IncidentLightingText  varchar(100) </li>
        <li>IncidentNumber  varchar(20) </li>
        <li>IncidentOffense  varchar(100) </li>
        <li>IncidentOtherInvolvedPerson  varchar(100) </li>
        <li>IncidentReportDate  varchar(100) </li>
        <li>IncidentServiceCall  varchar(100) </li>
        <li>IncidentSubject  varchar(100) </li>
        <li>IncidentVictim  varchar(100) </li>
        <li>IncidentWitness  varchar(100) </li>
        <li>InvolvedProperty  varchar(100) </li>
        <li>NarrativeAccountDescription  varchar(100) </li>
        <li>ORI  varchar(30) </li>
        <li>ReportingOfficer  varchar(100) </li>
        <li>StatusCode  varchar(100) </li>
        <li>StatusDate  varchar(100) </li>
        <li>StatusText  varchar(100) </li>
        <li>Summary  varchar(10) </li>
        <li>SupplementNumber  int   </li>
        <li>WeatherCode  varchar(100) </li>
        <li>WeatherText  varchar(100) </li>
        </ul>
         <br/>
        i9LawIncidentReport: <br/>
        <ul>
        <li>i9LawIncidentReportID  uniqueidentifier   </li>
        <li>LastUpdated  datetime   </li>
        </ul>
         <br/>
        i9Location: <br/>
        <ul>
        <li>Apartment  varchar(100) </li>
        <li>Beat  varchar(20) </li>
        <li>City  varchar(100) </li>
        <li>CountryCode  varchar(100) </li>
        <li>CountryText  varchar(100) </li>
        <li>County  varchar(100) </li>
        <li>FullStreetAddress  varchar(100) </li>
        <li>Highway  varchar(100) </li>
        <li>i9AgencyID  uniqueidentifier   </li>
        <li>i9EventID  uniqueidentifier   </li>
        <li>i9LocationID  uniqueidentifier   </li>
        <li>i9ModuleSectionID  varchar(25) </li>
        <li>i9PersonID  uniqueidentifier   </li>
        <li>i9VehicleID  uniqueidentifier   </li>
        <li>Latitude  varchar(100) </li>
        <li>LocationMVI  bigint   </li>
        <li>LocationRemarks  varchar(100) </li>
        <li>LocationTypeCode  varchar(100) </li>
        <li>LocationTypeText  varchar(100) </li>
        <li>Longitude  varchar(100) </li>
        <li>LotNumber  varchar(100) </li>
        <li>MileMarker  varchar(100) </li>
        <li>StateCode  varchar(100) </li>
        <li>StateText  varchar(100) </li>
        <li>StreetName  varchar(100) </li>
        <li>StreetNumber  varchar(100) </li>
        <li>StreetPostdirection  varchar(100) </li>
        <li>StreetPredirection  varchar(100) </li>
        <li>StreetType  varchar(100) </li>
        <li>ZipCode  varchar(100) </li>
        <li>ZipCodeExtension  varchar(100) </li>
        </ul>
         <br/>
        i9MessageInbox: <br/>
        <ul>
        <li>i9AgencyID  uniqueidentifier   </li>
        <li>i9MessageInboxID  uniqueidentifier   </li>
        </ul>
         <br/>
        i9Module: <br/>
        <ul>
        <li>ClassName  varchar(100) </li>
        <li>DesktopEnabled  bit   </li>
        <li>FileName  varchar(100) </li>
        <li>i9ModuleID  uniqueidentifier   </li>
        <li>LastUpdate  datetime   </li>
        <li>MobileEnabled  bit   </li>
        <li>ModuleKey  varchar(75) </li>
        <li>ModuleName  varchar(50) </li>
        <li>ModuleType  varchar(10) </li>
        <li>PopupPage  bit   </li>
        <li>Section  varchar(50) </li>
        </ul>
         <br/>
        i9ModuleReportNumber: <br/>
        <ul>
        <li>EndNumber  int   </li>
        <li>i9ModuleID  varchar(50) </li>
        <li>i9ModuleReportNumberID  uniqueidentifier   </li>
        <li>LastUpdate  datetime   </li>
        <li>Length  int   </li>
        <li>NumberLength  int   </li>
        <li>NumberPrefix  varchar(15) </li>
        <li>NumberSubFix  varchar(15) </li>
        <li>ReportNumber  bigint   </li>
        <li>ResetReportNumber  varchar(10) </li>
        <li>StartNumber  int   </li>
        </ul>
         <br/>
        i9ModuleSection: <br/>
        <ul>
        <li>i9ModuleSectionID  varchar(25) </li>
        <li>ModuleSectionDesc  varchar(50) </li>
        </ul>
         <br/>
        i9ModusOperandi: <br/>
        <ul>
        <li>i9LawIncidentID  uniqueidentifier   </li>
        <li>i9ModusOperandiID  uniqueidentifier   </li>
        <li>ModusOperandiCode  varchar(15) </li>
        <li>ModusOperandiText  varchar(50) </li>
        </ul>
         <br/>
        i9Narrative: <br/>
        <ul>
        <li>i9EventID  uniqueidentifier   </li>
        <li>i9NarrativeID  uniqueidentifier   </li>
        <li>Narrative  text(2147483647) </li>
        <li>NarrativeFormat  text(2147483647) </li>
        <li>SummaryNarrative  text(2147483647) </li>
        <li>SummaryNarrativeFormat  text(2147483647) </li>
        </ul>
         <br/>
        i9Offense: <br/>
        <ul>
        <li>ActivityCategory  varchar(100) </li>
        <li>i9LawIncidentID  uniqueidentifier   </li>
        <li>i9OffenseID  uniqueidentifier   </li>
        <li>OffenseAttemptedCompletedCode  varchar(100) </li>
        <li>OffenseBiasMotivationCauseCode  varchar(100) </li>
        <li>OffenseBiasMotivationCauseText  varchar(100) </li>
        <li>OffenseBiasMotivationCode  varchar(100) </li>
        <li>OffenseBiasMotivationText  varchar(100) </li>
        <li>OffenseCode  varchar(100) </li>
        <li>OffenseCriminalActivityCode  varchar(100) </li>
        <li>OffenseCriminalActivityText  varchar(100) </li>
        <li>OffenseDescriptionText  varchar(100) </li>
        <li>OffenseForcedEntryCode  varchar(100) </li>
        <li>OffenseForcedExitCode  varchar(100) </li>
        <li>OffenseForceUsedCode  varchar(100) </li>
        <li>OffenseForceUsedText  varchar(100) </li>
        <li>OffenseLocation  varchar(100) </li>
        <li>OffenseMethodofEntryCode  varchar(100) </li>
        <li>OffenseMethodofEntryText  varchar(100) </li>
        <li>OffenseMethodofExitCode  varchar(100) </li>
        <li>OffenseMethodofExitText  varchar(100) </li>
        <li>OffenseNumberofPremisesEntered  varchar(100) </li>
        <li>OffensePointofEntryCode  varchar(100) </li>
        <li>OffensePointofEntryText  varchar(100) </li>
        <li>OffensePointofExitCode  varchar(100) </li>
        <li>OffensePointofExitText  varchar(100) </li>
        <li>OffenseSecuritySystemsStatusEntryCode  varchar(100) </li>
        <li>OffenseSecuritySystemsStatusExitCode  varchar(100) </li>
        <li>OffenseSecurityTypeEntryCode  varchar(100) </li>
        <li>OffenseSecurityTypeEntryText  varchar(100) </li>
        <li>OffenseSecurityTypeExitCode  varchar(100) </li>
        <li>OffenseSecurityTypeExitText  varchar(100) </li>
        <li>OffenseText  varchar(100) </li>
        <li>OffenseViolatedStatuteDescription  varchar(100) </li>
        <li>OffenseViolatedStatuteNumber  varchar(100) </li>
        <li>OffenseWeapon  varchar(100) </li>
        </ul>
         <br/>
        i9Organization: <br/>
        <ul>
        <li>Description  varchar(100) </li>
        <li>FederalFirearmLicenseID  varchar(100) </li>
        <li>i9EventID  uniqueidentifier   </li>
        <li>i9OrganizationID  uniqueidentifier   </li>
        <li>IDEffectiveDate  varchar(100) </li>
        <li>IDExpirationDate  varchar(100) </li>
        <li>IDIssuingAuthority  varchar(100) </li>
        <li>IDStatus  varchar(100) </li>
        <li>IDType  varchar(100) </li>
        <li>OrganizationIDValue  varchar(100) </li>
        <li>OrganizationName  varchar(100) </li>
        <li>OrganizationTaxID  varchar(100) </li>
        <li>OrganizationTypeCode  varchar(100) </li>
        <li>OrganizationTypeText  varchar(100) </li>
        </ul>
         <br/>
        i9OtherContactInformation: <br/>
        <ul>
        <li>ContactAddress  varchar(100) </li>
        <li>ContactOtherAddressType  varchar(100) </li>
        <li>i9OtherContactInformationID  uniqueidentifier   </li>
        </ul>
         <br/>
        i9OtherInvolvedPerson: <br/>
        <ul>
        <li>i9OtherInvolvedPersonID  uniqueidentifier   </li>
        <li>OtherInvolvedPerson  varchar(100) </li>
        <li>OtherInvolvedPersonSequenceNumber  varchar(100) </li>
        </ul>
         <br/>
        i9Package: <br/>
        <ul>
        <li>i9PackageID  uniqueidentifier   </li>
        <li>PackageName  varchar(30) </li>
        </ul>
         <br/>
        i9PackageMetadata: <br/>
        <ul>
        <li>i9PackageMetadataID  uniqueidentifier   </li>
        <li>PackageMetadataName  varchar(30) </li>
        </ul>
         <br/>
        i9Pawn: <br/>
        <ul>
        <li>i9AgencyID  uniqueidentifier   </li>
        <li>i9EventID  uniqueidentifier   </li>
        <li>i9PawnID  uniqueidentifier   </li>
        </ul>
         <br/>
        i9Permission: <br/>
        <ul>
        <li>Description  varchar(510) </li>
        <li>i9PermissionID  uniqueidentifier   </li>
        <li>PermissionName  varchar(100) </li>
        </ul>
         <br/>
        i9Person: <br/>
        <ul>
        <li>Age  varchar(100) </li>
        <li>AgeUnitCode  varchar(100) </li>
        <li>AlienNumber  varchar(100) </li>
        <li>BirthDate  varchar(100) </li>
        <li>BuildCode  varchar(100) </li>
        <li>BuildText  varchar(100) </li>
        <li>CautionInformationCode  varchar(100) </li>
        <li>CautionInformationText  varchar(100) </li>
        <li>CitizenshipCode  varchar(100) </li>
        <li>DentalCharacteristicCode  varchar(100) </li>
        <li>DentalCharacteristicText  varchar(100) </li>
        <li>DigitalImage  varchar(100) </li>
        <li>DNACollectionIndicator  varchar(100) </li>
        <li>DNACollectionStatusText  varchar(100) </li>
        <li>DriverLicenseExpirationDate  varchar(100) </li>
        <li>DriverLicenseIssuingAuthorityCode  varchar(100) </li>
        <li>DriverLicenseIssuingAuthorityText  varchar(100) </li>
        <li>DriverLicenseNumber  varchar(100) </li>
        <li>EthnicityCode  varchar(100) </li>
        <li>EyeColorCode  varchar(100) </li>
        <li>EyewearCode  varchar(100) </li>
        <li>EyewearText  varchar(100) </li>
        <li>FacialHairCode  varchar(100) </li>
        <li>FacialHairText  varchar(100) </li>
        <li>FBINumber  varchar(100) </li>
        <li>FirstName  varchar(100) </li>
        <li>FullName  varchar(100) </li>
        <li>HairColorCode  varchar(100) </li>
        <li>HairDescription  varchar(100) </li>
        <li>HairLengthCode  varchar(100) </li>
        <li>HairLengthText  varchar(100) </li>
        <li>HairStyleCode  varchar(100) </li>
        <li>HairStyleText  varchar(100) </li>
        <li>HeightUnitCode  varchar(100) </li>
        <li>i9AgencyID  uniqueidentifier   </li>
        <li>i9EventID  uniqueidentifier   </li>
        <li>i9ModuleSectionID  varchar(25) </li>
        <li>i9PersonAKAID  uniqueidentifier   </li>
        <li>i9PersonID  uniqueidentifier   </li>
        <li>LastName  varchar(100) </li>
        <li>MaximumAge  varchar(100) </li>
        <li>MaximumHeight  varchar(100) </li>
        <li>MaximumWeight  varchar(100) </li>
        <li>MiddleName  varchar(100) </li>
        <li>MinimumAge  varchar(100) </li>
        <li>MinimumHeight  varchar(100) </li>
        <li>MinimumWeight  varchar(100) </li>
        <li>OccupationCode  varchar(100) </li>
        <li>OccupationText  varchar(100) </li>
        <li>PassportExpirationDate  varchar(100) </li>
        <li>PassportID  varchar(100) </li>
        <li>PassportIssuingCountryCode  varchar(100) </li>
        <li>PersonCriminalInvolvementCode  varchar(100) </li>
        <li>PersonHandednessCode  varchar(100) </li>
        <li>PersonHeight  varchar(100) </li>
        <li>PersonIdentificationNumberPID  varchar(100) </li>
        <li>PersonMaritalStatus  varchar(100) </li>
        <li>PersonMNI  bigint   </li>
        <li>PersonNameTypeCode  varchar(100) </li>
        <li>PersonPhysicalFeatureCode  varchar(100) </li>
        <li>PersonPotentialMatchID  varchar(100) </li>
        <li>PhysicalFeatureDescription  varchar(100) </li>
        <li>PhysicalFeatureImage  varchar(100) </li>
        <li>PIDEffectiveDate  varchar(100) </li>
        <li>PIDExpirationDate  varchar(100) </li>
        <li>PIDIssuingAuthorityCode  varchar(100) </li>
        <li>PIDIssuingAuthorityText  varchar(100) </li>
        <li>PIDTypeCode  varchar(100) </li>
        <li>Prefix  varchar(100) </li>
        <li>RaceCode  varchar(100) </li>
        <li>RegisteredOffenderIndicator  varchar(100) </li>
        <li>RegisteredOffenderIssuingAuthorityCode  varchar(100) </li>
        <li>RegisteredOffenderIssuingAuthorityText  varchar(100) </li>
        <li>RegisteredOffenderNumber  varchar(100) </li>
        <li>ResidentStatusCode  varchar(100) </li>
        <li>SequenceNumber  int   </li>
        <li>SexCode  varchar(100) </li>
        <li>SkinToneCode  varchar(100) </li>
        <li>SpeechCode  varchar(100) </li>
        <li>SpeechText  varchar(100) </li>
        <li>SSN  varchar(100) </li>
        <li>StateID  varchar(100) </li>
        <li>StateIDIssuingAuthorityCode  varchar(100) </li>
        <li>StateIDIssuingAuthorityText  varchar(100) </li>
        <li>Suffix  varchar(100) </li>
        <li>USMarshalServiceFugitiveID  varchar(100) </li>
        <li>Weight  varchar(100) </li>
        <li>WeightUnitCode  varchar(100) </li>
        </ul>
         <br/>
        i9PersonArrestee: <br/>
        <ul>
        <li>Arrestee  varchar(100) </li>
        <li>ArresteeSequenceNumber  varchar(100) </li>
        <li>ArresteeViolatedStatuteDescription  varchar(100) </li>
        <li>ArresteeViolatedStatuteNumber  varchar(100) </li>
        <li>ArresteeWeapon  varchar(100) </li>
        <li>CountCode  varchar(100) </li>
        <li>i9PersonArresteeID  uniqueidentifier   </li>
        <li>i9PersonID  uniqueidentifier   </li>
        <li>JuvenileDispositionCode  varchar(100) </li>
        <li>OffenseID  bigint   </li>
        </ul>
         <br/>
        i9PersonMissing: <br/>
        <ul>
        <li>i9PersonID  uniqueidentifier   </li>
        <li>i9PersonMissingID  uniqueidentifier   </li>
        <li>MissingPerson  varchar(100) </li>
        <li>MissingPersonCircumstanceCode  varchar(100) </li>
        <li>MissingPersonCircumstanceText  varchar(100) </li>
        <li>MissingPersonDeclarationDate  varchar(100) </li>
        <li>MissingPersonDeclarationTime  varchar(100) </li>
        <li>MissingPersonFoundDate  varchar(100) </li>
        <li>MissingPersonFoundIndicator  varchar(100) </li>
        <li>MissingPersonFoundTime  varchar(100) </li>
        <li>MissingPersonLastSeenDate  varchar(100) </li>
        <li>MissingPersonLastSeenTime  varchar(100) </li>
        </ul>
         <br/>
        i9PersonPhoto: <br/>
        <ul>
        <li>i9PersonID  uniqueidentifier   </li>
        <li>i9PersonPhotoID  uniqueidentifier   </li>
        <li>Photo  image(2147483647) </li>
        <li>PhotoThumb  image(2147483647) </li>
        </ul>
         <br/>
        i9PersonRelated: <br/>
        <ul>
        <li>i9PersonID  uniqueidentifier   </li>
        <li>i9PersonIDRelated  uniqueidentifier   </li>
        <li>i9PersonRelatedID  uniqueidentifier   </li>
        <li>InvolvementCode  varchar(60) </li>
        <li>RecordedDate  datetime   </li>
        </ul>
         <br/>
        i9PersonSMT: <br/>
        <ul>
        <li>Feature  varchar(100) </li>
        <li>i9EventID  uniqueidentifier   </li>
        <li>i9PersonID  uniqueidentifier   </li>
        <li>i9PersonSMTID  uniqueidentifier   </li>
        <li>SMTCode  varchar(100) </li>
        <li>SMTDescription  varchar(100) </li>
        <li>SMTLocation  varchar(100) </li>
        </ul>
         <br/>
        i9PersonSubject: <br/>
        <ul>
        <li>i9PersonID  uniqueidentifier   </li>
        <li>i9PersonSubjectID  uniqueidentifier   </li>
        <li>ModusOperandiObservationCode  varchar(100) </li>
        <li>ModusOperandiObservationText  varchar(100) </li>
        <li>ModusOperandiSubjectActionCode  varchar(100) </li>
        <li>ModusOperandiSubjectActionText  varchar(100) </li>
        <li>Organization  varchar(100) </li>
        <li>SequenceNumber  varchar(100) </li>
        <li>SubjectPerson  varchar(100) </li>
        </ul>
         <br/>
        i9PersonVehicle: <br/>
        <ul>
        <li>i9PersonID  uniqueidentifier   </li>
        <li>i9PersonVehicleID  uniqueidentifier   </li>
        <li>i9VehicleID  uniqueidentifier   </li>
        <li>Involvement  varchar(160) </li>
        <li>InvolvementDate  datetime   </li>
        </ul>
         <br/>
        i9PersonVictim: <br/>
        <ul>
        <li>AdditionalJustifiableHomicideCode  varchar(100) </li>
        <li>AggravatedAssaultHomicideCircumstanceCode  varchar(100) </li>
        <li>AggravatedAssaultHomicideCircumstanceText  varchar(100) </li>
        <li>i9PersonID  uniqueidentifier   </li>
        <li>i9PersonVictimID  uniqueidentifier   </li>
        <li>InjuryTypeCode  varchar(100) </li>
        <li>InjuryTypeText  varchar(100) </li>
        <li>ModusOperandiVictimActionCode  varchar(100) </li>
        <li>ModusOperandiVictimActionText  varchar(100) </li>
        <li>VictimOrganization  varchar(100) </li>
        <li>VictimPerson  varchar(100) </li>
        <li>VictimSequenceNumber  varchar(100) </li>
        <li>VictimTypeCode  varchar(100) </li>
        <li>VictimTypeText  varchar(100) </li>
        </ul>
         <br/>
        i9PhoneNumber: <br/>
        <ul>
        <li>CityCode  varchar(100) </li>
        <li>CountryCode  varchar(100) </li>
        <li>ExchangeID  varchar(100) </li>
        <li>i9PhoneNumberID  uniqueidentifier   </li>
        <li>NumberAreaCode  varchar(100) </li>
        <li>NumberFull  varchar(100) </li>
        <li>NumberSubscriberID  varchar(100) </li>
        <li>NumberType  varchar(100) </li>
        <li>Suffix  varchar(100) </li>
        </ul>
         <br/>
        i9Property: <br/>
        <ul>
        <li>ClothingTypeCode  varchar(100) </li>
        <li>ClothingTypeText  varchar(100) </li>
        <li>ConstructionMaterialTypeCode  varchar(100) </li>
        <li>ConstructionMaterialTypeText  varchar(100) </li>
        <li>ConsumableGoodsTypeCode  varchar(100) </li>
        <li>ConsumableGoodsTypeText  varchar(100) </li>
        <li>CreditBankIDCardTypeCode  varchar(100) </li>
        <li>CreditBankIDCardTypeText  varchar(100) </li>
        <li>DeviceAssignedTelephoneNumber  varchar(100) </li>
        <li>DeviceElectronicSerialNumber_ESN  varchar(100) </li>
        <li>DeviceEmailAddress  varchar(100) </li>
        <li>DeviceInternationalMobileEquipmentIdentity_IMEI  varchar(100) </li>
        <li>DeviceOtherContactAddress  varchar(100) </li>
        <li>DeviceStoredText  varchar(100) </li>
        <li>DeviceTypeCode  varchar(100) </li>
        <li>DeviceTypeText  varchar(100) </li>
        <li>DigitalImage  varchar(100) </li>
        <li>DispositionDate  varchar(100) </li>
        <li>DrugContainerDescription  varchar(100) </li>
        <li>DrugFoundDescription  varchar(100) </li>
        <li>DrugMeasureCode  varchar(100) </li>
        <li>DrugQuantity  varchar(100) </li>
        <li>DrugSubstanceForm  varchar(100) </li>
        <li>DrugTypeCode  varchar(100) </li>
        <li>DrugTypeText  varchar(100) </li>
        <li>ElectronicEquipmentTypeCode  varchar(100) </li>
        <li>ElectronicEquipmentTypeText  varchar(100) </li>
        <li>GrainTypeCode  varchar(100) </li>
        <li>GrainTypeText  varchar(100) </li>
        <li>HouseholdGoodsTypeCode  varchar(100) </li>
        <li>HouseholdGoodsTypeText  varchar(100) </li>
        <li>i9AgencyID  uniqueidentifier   </li>
        <li>i9EventID  uniqueidentifier   </li>
        <li>i9PropertyID  uniqueidentifier   </li>
        <li>JewelryTypeCode  varchar(100) </li>
        <li>JewelryTypeText  varchar(100) </li>
        <li>KnifeTypeCode  varchar(100) </li>
        <li>KnifeTypeText  varchar(100) </li>
        <li>LivestockPetTypeCode  varchar(100) </li>
        <li>LivestockPetTypeText  varchar(100) </li>
        <li>Make  varchar(100) </li>
        <li>Model  varchar(100) </li>
        <li>PropertyDescription  varchar(100) </li>
        <li>PropertyMPI  bigint   </li>
        <li>PropertyRFID  varchar(100) </li>
        <li>PropertyStatusCode  varchar(100) </li>
        <li>PropertyTypeCode  varchar(100) </li>
        <li>PropertyTypeText  varchar(100) </li>
        <li>PropertyValue  varchar(100) </li>
        <li>PropertyValueTypeCode  varchar(100) </li>
        <li>PropertyValueTypeText  varchar(100) </li>
        <li>SerialNumber  varchar(100) </li>
        </ul>
         <br/>
        i9PropertyEvidence: <br/>
        <ul>
        <li>EvidenceProperty  varchar(100) </li>
        <li>EvidenceReceiptID  varchar(100) </li>
        <li>i9PropertyEvidenceID  uniqueidentifier   </li>
        <li>i9PropertyID  uniqueidentifier   </li>
        </ul>
         <br/>
        i9PropertyExplosive: <br/>
        <ul>
        <li>ComponentCode  varchar(100) </li>
        <li>ComponentText  varchar(100) </li>
        <li>ContainerCode  varchar(100) </li>
        <li>ContainerText  varchar(100) </li>
        <li>ExplosiveIgnitionCode  varchar(100) </li>
        <li>ExplosiveIgnitionText  varchar(100) </li>
        <li>FillerCode  varchar(100) </li>
        <li>FillerText  varchar(100) </li>
        <li>i9PropertyExplosiveID  uniqueidentifier   </li>
        <li>i9PropertyID  uniqueidentifier   </li>
        </ul>
         <br/>
        i9PropertyFirearm: <br/>
        <ul>
        <li>BarrelLength  varchar(100) </li>
        <li>BarrelLengthMeasureCode  varchar(100) </li>
        <li>CaliberCode  varchar(100) </li>
        <li>COMMENTS  varchar(510) </li>
        <li>FirearmDescription  varchar(100) </li>
        <li>FirearmDescriptionCode  varchar(100) </li>
        <li>FirearmFinishCode  varchar(100) </li>
        <li>FirearmMakeCode  varchar(100) </li>
        <li>FirearmTypeCode  varchar(100) </li>
        <li>FirearmTypeText  varchar(100) </li>
        <li>i9PropertyFirearmID  uniqueidentifier   </li>
        <li>i9PropertyID  uniqueidentifier   </li>
        <li>SerialNumber  varchar(100) </li>
        </ul>
         <br/>
        i9PropertyHazardousMaterial: <br/>
        <ul>
        <li>HazardousMaterialCode  varchar(100) </li>
        <li>HazardousMaterialContainerDescription  varchar(100) </li>
        <li>HazardousMaterialMeasureCode  varchar(100) </li>
        <li>HazardousMaterialQuantity  varchar(100) </li>
        <li>HazardousMaterialSubstanceForm  varchar(100) </li>
        <li>HazardousMaterialText  varchar(100) </li>
        <li>i9PropertyHazardousMaterialID  uniqueidentifier   </li>
        <li>i9PropertyID  uniqueidentifier   </li>
        </ul>
         <br/>
        i9PropertyImage: <br/>
        <ul>
        <li>i9PropertyID  uniqueidentifier   </li>
        <li>i9PropertyImageID  uniqueidentifier   </li>
        <li>PhotoName  varchar(20) </li>
        <li>PhotoType  varchar(40) </li>
        <li>PropertyImage  image(2147483647) </li>
        </ul>
         <br/>
        i9PropertySecurities: <br/>
        <ul>
        <li>CollectionEndDate  varchar(100) </li>
        <li>CollectionStartDate  varchar(100) </li>
        <li>DateOrSeriesYear  varchar(100) </li>
        <li>Denomination  varchar(100) </li>
        <li>i9PropertyID  uniqueidentifier   </li>
        <li>i9PropertySecuritiesID  uniqueidentifier   </li>
        <li>Issuer  varchar(100) </li>
        <li>MaturityDate  varchar(100) </li>
        <li>SecuritiesRansomMoneyIndicatorCode  varchar(100) </li>
        <li>SecuritiesTypeCode  varchar(100) </li>
        <li>SecuritiesTypeText  varchar(100) </li>
        <li>SecurityOwner  varchar(100) </li>
        <li>SerialNumber  varchar(100) </li>
        </ul>
         <br/>
        i9RelatedRecord: <br/>
        <ul>
        <li>Agency  varchar(100) </li>
        <li>i9EventID  uniqueidentifier   </li>
        <li>i9RelatedRecordID  uniqueidentifier   </li>
        <li>RecordAgency  varchar(100) </li>
        <li>RecordID  varchar(100) </li>
        <li>RecordType  varchar(100) </li>
        <li>RelatedAGENCY  varchar(100) </li>
        <li>RelatedRecordAG  varchar(100) </li>
        <li>RelatedRecordRecordID  varchar(100) </li>
        <li>RelatedRecordType  varchar(100) </li>
        </ul>
         <br/>
        i9SecurityGroup: <br/>
        <ul>
        <li>i9AgencyID  uniqueidentifier   </li>
        <li>i9SecurityGroupID  uniqueidentifier   </li>
        <li>SecurityGroupDesc  varchar(100) </li>
        <li>SecurityGroupName  varchar(50) </li>
        </ul>
         <br/>
        i9SecurityGroupModule: <br/>
        <ul>
        <li>i9AgencyID  uniqueidentifier   </li>
        <li>i9SecurityGroupModuleID  uniqueidentifier   </li>
        <li>ModuleName  varchar(50) </li>
        <li>SecurityGroupName  varchar(50) </li>
        </ul>
         <br/>
        i9SecurityGroupTask: <br/>
        <ul>
        <li>i9AgencyID  uniqueidentifier   </li>
        <li>i9SecurityGroupTaskID  uniqueidentifier   </li>
        <li>SecurityGroupName  varchar(50) </li>
        <li>TaskName  varchar(50) </li>
        </ul>
         <br/>
        i9SecurityTask: <br/>
        <ul>
        <li>Enabled  int   </li>
        <li>i9SecurityTaskID  uniqueidentifier   </li>
        <li>TaskDesc  varchar(100) </li>
        <li>TaskName  varchar(50) </li>
        </ul>
         <br/>
        i9SolvabilityFactor: <br/>
        <ul>
        <li>i9SolvabilityFactorID  uniqueidentifier   </li>
        <li>SolvabilityFactorTotal  bigint   </li>
        </ul>
         <br/>
        i9Structure: <br/>
        <ul>
        <li>i9EventID  uniqueidentifier   </li>
        <li>i9StructureID  uniqueidentifier   </li>
        <li>StructureOccupiedCode  varchar(100) </li>
        <li>StructureOccupiedText  varchar(100) </li>
        <li>StructureTypeCode  varchar(100) </li>
        <li>StructureTypeText  varchar(100) </li>
        </ul>
         <br/>
        i9SysLog: <br/>
        <ul>
        <li>AgencyName  varchar(60) </li>
        <li>BadgeNumber  varchar(25) </li>
        <li>i9AgencyID  uniqueidentifier   </li>
        <li>i9SysLogID  int   </li>
        <li>LogDateTime  datetime   </li>
        <li>LogDescription  varchar(1000) </li>
        <li>LogType  varchar(25) </li>
        </ul>
         <br/>
        i9SysPersonnel: <br/>
        <ul>
        <li>ActivationGuid  uniqueidentifier   </li>
        <li>BadgeNumber  varchar(100) </li>
        <li>DateTimeInserted  datetime   </li>
        <li>DateTimeUpdated  datetime   </li>
        <li>Email  varchar(100) </li>
        <li>Enabled  bit   </li>
        <li>FirstName  varchar(200) </li>
        <li>i9AgencyID  uniqueidentifier   </li>
        <li>i9SysPersonnelID  uniqueidentifier   </li>
        <li>LastName  varchar(200) </li>
        <li>LastUpdate  datetime   </li>
        <li>MiddleName  varchar(200) </li>
        <li>Officer  varchar(100) </li>
        <li>OfficerActivityTypeCode  varchar(100) </li>
        <li>OfficerActivityTypeText  varchar(100) </li>
        <li>OfficerAssignmentTypeCode  varchar(100) </li>
        <li>OfficerAssignmentTypeText  varchar(100) </li>
        <li>OfficerLEOKATypeCode  varchar(100) </li>
        <li>OfficerORI  varchar(100) </li>
        <li>Password  varchar(200) </li>
        </ul>
         <br/>
        i9SysPersonnelAddress: <br/>
        <ul>
        <li>Address1  varchar(80) </li>
        <li>Address2  varchar(80) </li>
        <li>AddressType  varchar(20) </li>
        <li>City  varchar(60) </li>
        <li>i9SysPersonnelAddressID  uniqueidentifier   </li>
        <li>i9SysPersonnelID  uniqueidentifier   </li>
        <li>State  varchar(40) </li>
        <li>Zip  varchar(20) </li>
        </ul>
         <br/>
        i9SysPersonnelAssignment: <br/>
        <ul>
        <li>AssignmentNote  ntext(1073741823) </li>
        <li>AssignmentTitle  varchar(100) </li>
        <li>EndDateTime  datetime   </li>
        <li>i9SysPersonnelAssignmentID  uniqueidentifier   </li>
        <li>i9SysPersonnelID  uniqueidentifier   </li>
        <li>JobID  bigint   </li>
        <li>StartDateTime  datetime   </li>
        </ul>
         <br/>
        i9SysPersonnelPhone: <br/>
        <ul>
        <li>i9SysPersonnelID  uniqueidentifier   </li>
        <li>i9SysPersonnelPhoneID  uniqueidentifier   </li>
        <li>PhoneNumber  varchar(30) </li>
        <li>PhoneType  varchar(30) </li>
        </ul>
         <br/>
        i9TableKey: <br/>
        <ul>
        <li>i9TableKeyID  uniqueidentifier   </li>
        <li>KeyValue  bigint   </li>
        <li>LastUpdate  datetime   </li>
        <li>TableName  varchar(50) </li>
        </ul>
         <br/>
        i9Vehicle: <br/>
        <ul>
        <li>BoatEnginePowerDisplacement  varchar(100) </li>
        <li>BoatEnginePowerDisplacementMeasureCode  varchar(100) </li>
        <li>BoatHomePort  varchar(100) </li>
        <li>BoatHullShape  varchar(100) </li>
        <li>BoatName  varchar(100) </li>
        <li>BoatOuterHullMaterial  varchar(100) </li>
        <li>BoatPartCategoryCode  varchar(100) </li>
        <li>BoatPartCategoryText  varchar(100) </li>
        <li>BoatPropulsionCode  varchar(100) </li>
        <li>BoatPropulsionText  varchar(100) </li>
        <li>BoatTypeCode  varchar(100) </li>
        <li>BoatTypeText  varchar(100) </li>
        <li>CoastGuardDocumentNumber  varchar(100) </li>
        <li>ColorCode  varchar(100) </li>
        <li>EngineQuantity  varchar(100) </li>
        <li>FuselageColor  varchar(100) </li>
        <li>HomeAirportID  varchar(100) </li>
        <li>HomeAirportName  varchar(100) </li>
        <li>i9AgencyID  uniqueidentifier   </li>
        <li>i9EventID  uniqueidentifier   </li>
        <li>i9VehicleID  uniqueidentifier   </li>
        <li>LicenseJurisdictionCode  varchar(100) </li>
        <li>LicenseJurisdictionText  varchar(100) </li>
        <li>LicenseNumber  varchar(100) </li>
        <li>LicenseTypeCode  varchar(100) </li>
        <li>LicenseYear  varchar(100) </li>
        <li>MakeCode  varchar(100) </li>
        <li>ModelCode  varchar(100) </li>
        <li>ModelYear  varchar(100) </li>
        <li>OverallLength  varchar(100) </li>
        <li>OverallLengthMeasureCode  varchar(100) </li>
        <li>SerialNumber  varchar(100) </li>
        <li>StyleCode  varchar(100) </li>
        <li>TailNumber  varchar(100) </li>
        <li>VehicleDescription  varchar(100) </li>
        <li>VehicleMVI  bigint   </li>
        <li>VIN  varchar(100) </li>
        <li>WingColor  varchar(100) </li>
        </ul>
         <br/>
        i9VehicleRecovery: <br/>
        <ul>
        <li>Condition  varchar(50) </li>
        <li>i9EventID  uniqueidentifier   </li>
        <li>i9VehicleID  uniqueidentifier   </li>
        <li>i9VehicleRecoveryID  uniqueidentifier   </li>
        <li>Notes  varchar(100) </li>
        </ul>
         <br/>
        i9VehicleTowed: <br/>
        <ul>
        <li>Condition  varchar(50) </li>
        <li>i9EventID  uniqueidentifier   </li>
        <li>i9VehicleID  uniqueidentifier   </li>
        <li>i9VehicleTowedID  uniqueidentifier   </li>
        <li>Notes  varchar(100) </li>
        <li>TowedDate  varchar(100) </li>
        </ul>
         <br/>
        i9Warrant: <br/>
        <ul>
        <li>i9AgencyID  uniqueidentifier   </li>
        <li>i9EventID  uniqueidentifier   </li>
        <li>i9WarrantID  uniqueidentifier   </li>
        </ul>
         <br/>
        OLD_i9Code: <br/>
        <ul>
        <li>Code  varchar(200) </li>
        <li>CodeSetName  varchar(50) </li>
        <li>CodeText  varchar(2000) </li>
        <li>Enabled  int   </li>
        <li>i9AgencyID  uniqueidentifier   </li>
        <li>i9CodeID  uniqueidentifier   </li>
        <li>LastUpdate  datetime   </li>
        </ul>
         <br/>
        OLD_i9PersonAKA: <br/>
        <ul>
        <li>FirstName  varchar(100) </li>
        <li>FullName  varchar(100) </li>
        <li>i9PersonAKAID  uniqueidentifier   </li>
        <li>i9PersonID  uniqueidentifier   </li>
        <li>LastName  varchar(100) </li>
        <li>MiddleName  varchar(100) </li>
        <li>NameSuffix  varchar(100) </li>
        <li>Prefix  varchar(100) </li>
        </ul>


</asp:Content>
