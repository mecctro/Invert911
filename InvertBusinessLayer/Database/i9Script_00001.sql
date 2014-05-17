USE [master]
GO
/****** Object:  Database [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF]    Script Date: 11/25/2012 15:35:52 ******/
CREATE DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] ON  PRIMARY 
( NAME = N'Invert911Database', FILENAME = N'C:\Dev\Invert911\Invert911_RMS\InvertBusinessLayer\Database\Invert911Database.mdf' , SIZE = 32256KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Invert911Database_log', FILENAME = N'C:\Dev\Invert911\Invert911_RMS\InvertBusinessLayer\Database\Invert911Database_log.ldf' , SIZE = 26816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET ANSI_NULLS OFF
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET ANSI_PADDING OFF
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET ARITHABORT OFF
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET AUTO_CLOSE ON
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET AUTO_SHRINK ON
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET  DISABLE_BROKER
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET  READ_WRITE
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET RECOVERY SIMPLE
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET  MULTI_USER
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF] SET DB_CHAINING OFF
GO
USE [C:\DEV\INVERT911\INVERT911_RMS\INVERTBUSINESSLAYER\DATABASE\INVERT911DATABASE.MDF]
GO
/****** Object:  Table [dbo].[i9CADUnit]    Script Date: 11/25/2012 15:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9CADUnit](
	[AgencyCode] [varchar](100) NULL,
	[UnitNBR] [varchar](100) NULL,
	[i9CADUnitID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9CADUnit] PRIMARY KEY CLUSTERED 
(
	[i9CADUnitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9CADServiceCallNarrative]    Script Date: 11/25/2012 15:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9CADServiceCallNarrative](
	[NarrativeText] [varchar](100) NULL,
	[NarrativeType] [varchar](100) NULL,
	[i9CADServiceCallNarrativeID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9CADServiceCallNarrative] PRIMARY KEY CLUSTERED 
(
	[i9CADServiceCallNarrativeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9DynamicEntry]    Script Date: 11/25/2012 15:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9DynamicEntry](
	[ModuleSection] [varchar](50) NOT NULL,
	[ModuleSectionDesc] [varchar](50) NOT NULL,
	[DynamicEntryTable] [varchar](50) NULL,
	[LastUpdate] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9Attachment]    Script Date: 11/25/2012 15:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9Attachment](
	[AttachmentName] [varchar](100) NULL,
	[AttachmentNotes] [varchar](100) NULL,
	[Capturedate] [varchar](100) NULL,
	[ImageTypeCode] [varchar](100) NULL,
	[ImageTypeText] [varchar](100) NULL,
	[i9AttachmentID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9Attachment] PRIMARY KEY CLUSTERED 
(
	[i9AttachmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9ArrestReport]    Script Date: 11/25/2012 15:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[i9ArrestReport](
	[i9ArrestReportID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9ArrestReport] PRIMARY KEY CLUSTERED 
(
	[i9ArrestReportID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[HTMLTableSchema_Get]    Script Date: 11/25/2012 15:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[HTMLTableSchema_Get]
	(
	@table varchar(50)
	)	
AS

--sp_help information_schema.columns


DECLARE @TableName VARCHAR(50) -- database name  
DECLARE @ColumnName VARCHAR(50)
DECLARE @DataType VARCHAR(50)
DECLARE @MaxLength VARCHAR(50)
--DECLARE IsPrimaryKey VARCHAR(50)


DECLARE db_cursor2 CURSOR FOR  

SELECT c.table_name As TableName, 
	c.column_name As ColumnName, 
	c.data_type As DataType, 
	c.character_maximum_length As MaxLength  --,
    --COALESCE (
    --( SELECT 
    --    CASE cu.column_name
    --        WHEN null THEN 0
    --        ELSE 1
    --    END
    --FROM information_schema.constraint_column_usage cu
    --INNER join information_schema.table_constraints ct
    --ON ct.constraint_name = cu.constraint_name
    --WHERE 
    --ct.constraint_type = 'PRIMARY KEY' 
    --AND ct.table_name = c.table_name
    --AND cu.column_name = c.column_name 
    --),0) AS IsPrimaryKey
FROM information_schema.columns c
	INNER JOIN information_schema.tables t
		ON c.table_name = t.table_name
WHERE  t.table_name = @table AND
	  (t.table_type = 'BASE TABLE' and not 
	  (t.table_name = 'dtproperties') and not 
	  (t.table_name = 'sysdiagrams'))
ORDER BY c.table_name, c.column_name


OPEN db_cursor2   
FETCH NEXT FROM db_cursor2 INTO @TableName, @ColumnName , @DataType, @MaxLength 


WHILE @@FETCH_STATUS = 0   
BEGIN   
	   if(@MaxLength is null)
			Print '<li>' + @ColumnName + '  ' + @DataType + '  ' + isnull(@MaxLength , '') + ' </li>'
       else
			Print '<li>' + @ColumnName + '  ' + @DataType + '(' + isnull(@MaxLength , '') + ') </li>'
       
       FETCH NEXT FROM db_cursor2 INTO @TableName, @ColumnName , @DataType , @MaxLength 
END   

CLOSE db_cursor2   
DEALLOCATE db_cursor2
GO
/****** Object:  StoredProcedure [dbo].[CreateUniqueidentifierID]    Script Date: 11/25/2012 15:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateUniqueidentifierID]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;





	--SELECT name FROM sys.Tables WHERE name not like  'NIEM%' order by name
	--SELECT  so.name FROM sysobjects so WHERE  so.xtype = 'PK' AND  so.parent_obj = OBJECT_ID()

	DECLARE @SQL VARCHAR(8000)
	DECLARE @FK_SQL VARCHAR(8000)
	SET @FK_SQL = ''
	DECLARE @TableName VARCHAR(50) -- database name
	DECLARE @FKName VARCHAR(50) -- FK name
	
	
	DECLARE db_PrimaryCursor CURSOR FOR
	SELECT name FROM sys.Tables WHERE name not like  'NIEM%' order by name
	OPEN db_PrimaryCursor
	FETCH NEXT FROM db_PrimaryCursor INTO @TableName
	WHILE @@FETCH_STATUS = 0
	BEGIN
			--print  's'
			DECLARE db_FKCursor CURSOR FOR
			SELECT name FROM sysobjects  WHERE xtype = 'F' AND parent_obj = OBJECT_ID(@TableName)
			OPEN db_FKCursor
			FETCH NEXT FROM db_FKCursor INTO @FKName
			WHILE @@FETCH_STATUS = 0
			BEGIN	
					--DECLARE @SQL VARCHAR(4000)
					SET @SQL = ''
					
					SET @SQL = 'ALTER TABLE ' + @TableName + ' DROP CONSTRAINT |ConstraintName| '
					SET @SQL =  REPLACE(@SQL, '|ConstraintName|',  @FKName )

					print ''
					--print 'Name: ' + @name
					print @SQL

					DECLARE @FTableName VARCHAR(50)
					set @FTableName = (SELECT PARSENAME(REPLACE(@FKName, '_', '.'), 1))
					
					set @FK_SQL = @FK_SQL + ''
					set @FK_SQL = @FK_SQL + 'ALTER TABLE ' +  @TableName	+ CHAR(13)
					set @FK_SQL = @FK_SQL + 'ADD CONSTRAINT fk_' + @TableName + '_i9Agency'	+ CHAR(13)
					set @FK_SQL = @FK_SQL + 'FOREIGN KEY (i9' + @TableName +  'ID' + ')'	+ CHAR(13)
					set @FK_SQL = @FK_SQL + 'REFERENCES ' + @FTableName + '(' + @TableName +  'ID)'	+ CHAR(13)
					set @FK_SQL = @FK_SQL + CHAR(13)

					
					
					FETCH NEXT FROM db_FKCursor INTO @FKName
			END
			
			
			
			
			CLOSE db_FKCursor
			DEALLOCATE db_FKCursor
	

		   FETCH NEXT FROM db_PrimaryCursor INTO @TableName

	 END
	 
	
	
	CLOSE db_PrimaryCursor
	DEALLOCATE db_PrimaryCursor
	
	
	

	--SELECT name FROM sys.Tables WHERE name not like  'NIEM%' order by name
	--SELECT  so.name FROM sysobjects so WHERE  so.xtype = 'PK' AND  so.parent_obj = OBJECT_ID()

	
	DECLARE @name VARCHAR(50) -- database name
	DECLARE db_cursor CURSOR FOR

	SELECT name FROM sys.Tables WHERE name not like  'NIEM%' order by name

	OPEN db_cursor
	FETCH NEXT FROM db_cursor INTO @name

	 WHILE @@FETCH_STATUS = 0
	 BEGIN

		   if( exists( SELECT name FROM sysobjects  WHERE xtype = 'PK' AND parent_obj = OBJECT_ID(@Name) ) )
		   BEGIN
				 DECLARE @PrimarySQL VARCHAR(8000)

				 SET @PrimarySQL = 'ALTER TABLE ' + @name + ' DROP CONSTRAINT |ConstraintName| '

				 SET @PrimarySQL =  REPLACE(@PrimarySQL, '|ConstraintName|', (SELECT name FROM sysobjects  WHERE xtype = 'PK' AND parent_obj = OBJECT_ID(@Name)))
				 --EXEC (@SQL)

				 print  ''
				 print @PrimarySQL
		   END
		   
		   print  ''
		   print  'alter table ' + @name
		   print  '    drop column ' + @name + 'ID'
		   print  ''
		   print  'alter table ' + @name
		   print  '    Add ' + @name + 'ID uniqueidentifier not null '

		   print  ''
		   print  'ALTER TABLE ' + @name
		   print  '    ADD CONSTRAINT pk_' + @name  + ' PRIMARY KEY (' + @name + 'ID)'

		FETCH NEXT FROM db_cursor INTO @name

	 END

     CLOSE db_cursor
	 DEALLOCATE db_cursor	
	
	
print  ''
	print  ''
	print @FK_SQL 



END
GO
/****** Object:  Table [dbo].[i9AttachmentLink]    Script Date: 11/25/2012 15:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9AttachmentLink](
	[AttachmentURI] [varchar](100) NULL,
	[Description] [varchar](100) NULL,
	[ViewableIndicator] [varchar](100) NULL,
	[i9AttachmentLinkID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9AttachmentLink] PRIMARY KEY CLUSTERED 
(
	[i9AttachmentLinkID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9Agency]    Script Date: 11/25/2012 15:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9Agency](
	[AgencyName] [varchar](60) NULL,
	[AgencyDesc] [varchar](100) NULL,
	[AgencyID] [varchar](100) NULL,
	[Address1] [varchar](80) NULL,
	[Address2] [varchar](80) NULL,
	[City] [varchar](60) NULL,
	[State] [varchar](40) NULL,
	[Zip] [varchar](20) NULL,
	[PhoneNumber] [varchar](30) NULL,
	[FaxNumber] [varchar](30) NULL,
	[i9AgencyID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9Agency] PRIMARY KEY CLUSTERED 
(
	[i9AgencyID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9LawIncidentReport]    Script Date: 11/25/2012 15:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[i9LawIncidentReport](
	[LastUpdated] [datetime] NULL,
	[i9LawIncidentReportID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9LawIncidentReport] PRIMARY KEY CLUSTERED 
(
	[i9LawIncidentReportID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[i9EmailModule]    Script Date: 11/25/2012 15:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9EmailModule](
	[ToEmailAddress] [varchar](max) NOT NULL,
	[CCEmailAddress] [varchar](max) NULL,
	[BCCEmailAddress] [varchar](max) NULL,
	[FromEmailAddress] [varchar](255) NOT NULL,
	[Subject] [varchar](max) NOT NULL,
	[Body] [varchar](max) NOT NULL,
	[EmailStatusFlag] [tinyint] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
	[InsertENTUserAccountId] [int] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateENTUserAccountId] [int] NOT NULL,
	[Version] [timestamp] NOT NULL,
	[i9EmailModuleID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9EmailModule] PRIMARY KEY CLUSTERED 
(
	[i9EmailModuleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9EmailAddress]    Script Date: 11/25/2012 15:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9EmailAddress](
	[EmailAddress] [varchar](100) NULL,
	[EmailType] [varchar](10) NULL,
	[i9EmailAddressID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9EmailAddress] PRIMARY KEY CLUSTERED 
(
	[i9EmailAddressID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9DynamicEntryRule]    Script Date: 11/25/2012 15:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9DynamicEntryRule](
	[i9DynanicEntryConfigID] [bigint] NOT NULL,
	[i9DynanicEntryConfigID2] [bigint] NULL,
	[RuleType] [varchar](50) NULL,
	[MinValue] [varchar](50) NULL,
	[MaxValue] [varchar](50) NULL,
	[LastUpdate] [datetime] NULL,
	[i9DynamicEntryRuleID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9DynamicEntryRule] PRIMARY KEY CLUSTERED 
(
	[i9DynamicEntryRuleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9DynamicEntryCtrlType]    Script Date: 11/25/2012 15:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9DynamicEntryCtrlType](
	[CtrlTypeName] [varchar](50) NOT NULL,
	[CtrlTypeDesc] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9PackageMetadata]    Script Date: 11/25/2012 15:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9PackageMetadata](
	[PackageMetadataName] [varchar](30) NULL,
	[i9PackageMetadataID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9PackageMetadata] PRIMARY KEY CLUSTERED 
(
	[i9PackageMetadataID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9Package]    Script Date: 11/25/2012 15:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9Package](
	[PackageName] [varchar](30) NULL,
	[i9PackageID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9Package] PRIMARY KEY CLUSTERED 
(
	[i9PackageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9OtherInvolvedPerson]    Script Date: 11/25/2012 15:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9OtherInvolvedPerson](
	[OtherInvolvedPerson] [varchar](100) NULL,
	[OtherInvolvedPersonSequenceNumber] [varchar](100) NULL,
	[i9OtherInvolvedPersonID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9OtherInvolvedPerson] PRIMARY KEY CLUSTERED 
(
	[i9OtherInvolvedPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9OtherContactInformation]    Script Date: 11/25/2012 15:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9OtherContactInformation](
	[ContactAddress] [varchar](100) NULL,
	[ContactOtherAddressType] [varchar](100) NULL,
	[i9OtherContactInformationID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9OtherContactInformation] PRIMARY KEY CLUSTERED 
(
	[i9OtherContactInformationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9ModuleReportNumber]    Script Date: 11/25/2012 15:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9ModuleReportNumber](
	[i9ModuleID] [varchar](50) NOT NULL,
	[ReportNumber] [bigint] NOT NULL,
	[NumberPrefix] [varchar](15) NULL,
	[NumberSubFix] [varchar](15) NULL,
	[Length] [int] NULL,
	[LastUpdate] [datetime] NOT NULL,
	[ResetReportNumber] [varchar](10) NOT NULL,
	[StartNumber] [int] NOT NULL,
	[EndNumber] [int] NOT NULL,
	[NumberLength] [int] NOT NULL,
	[i9ModuleReportNumberID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9ModuleReportNumber] PRIMARY KEY CLUSTERED 
(
	[i9ModuleReportNumberID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9Module]    Script Date: 11/25/2012 15:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9Module](
	[ClassName] [varchar](100) NOT NULL,
	[ModuleName] [varchar](50) NOT NULL,
	[Section] [varchar](50) NOT NULL,
	[PopupPage] [bit] NOT NULL,
	[DesktopEnabled] [bit] NOT NULL,
	[MobileEnabled] [bit] NOT NULL,
	[ModuleType] [varchar](10) NOT NULL,
	[FileName] [varchar](100) NOT NULL,
	[LastUpdate] [datetime] NULL,
	[i9ModuleID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9Module] PRIMARY KEY CLUSTERED 
(
	[i9ModuleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9EventType]    Script Date: 11/25/2012 15:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9EventType](
	[EventDesc] [varchar](30) NULL,
	[i9EventType] [varchar](20) NOT NULL,
 CONSTRAINT [pk_i9EventType] PRIMARY KEY CLUSTERED 
(
	[i9EventType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9SolvabilityFactor]    Script Date: 11/25/2012 15:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[i9SolvabilityFactor](
	[SolvabilityFactorTotal] [bigint] NOT NULL,
	[i9SolvabilityFactorID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9SolvabilityFactor] PRIMARY KEY CLUSTERED 
(
	[i9SolvabilityFactorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[i9ClientTableKey]    Script Date: 11/25/2012 15:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9ClientTableKey](
	[TableName] [varchar](50) NOT NULL,
	[KeyValue] [bigint] NOT NULL,
	[LastUpdate] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9Permission]    Script Date: 11/25/2012 15:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9Permission](
	[PermissionName] [varchar](100) NULL,
	[Description] [varchar](510) NULL,
	[i9PermissionID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9Permission] PRIMARY KEY CLUSTERED 
(
	[i9PermissionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9PhoneNumber]    Script Date: 11/25/2012 15:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9PhoneNumber](
	[CountryCode] [varchar](100) NULL,
	[CityCode] [varchar](100) NULL,
	[NumberAreaCode] [varchar](100) NULL,
	[ExchangeID] [varchar](100) NULL,
	[NumberSubscriberID] [varchar](100) NULL,
	[Suffix] [varchar](100) NULL,
	[NumberFull] [varchar](100) NULL,
	[NumberType] [varchar](100) NULL,
	[i9PhoneNumberID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9PhoneNumber] PRIMARY KEY CLUSTERED 
(
	[i9PhoneNumberID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[XMLTableSchema_Get]    Script Date: 11/25/2012 15:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[XMLTableSchema_Get]
	(
	@table varchar(50)
	)	
AS

--sp_help information_schema.columns


DECLARE @TableName VARCHAR(50) -- database name  
DECLARE @ColumnName VARCHAR(50)
DECLARE @DataType VARCHAR(50)
DECLARE @MaxLength VARCHAR(50)
--DECLARE IsPrimaryKey VARCHAR(50)


DECLARE db_cursor2 CURSOR FOR  

SELECT c.table_name As TableName, 
	c.column_name As ColumnName, 
	c.data_type As DataType, 
	c.character_maximum_length As MaxLength  --,
    --COALESCE (
    --( SELECT 
    --    CASE cu.column_name
    --        WHEN null THEN 0
    --        ELSE 1
    --    END
    --FROM information_schema.constraint_column_usage cu
    --INNER join information_schema.table_constraints ct
    --ON ct.constraint_name = cu.constraint_name
    --WHERE 
    --ct.constraint_type = 'PRIMARY KEY' 
    --AND ct.table_name = c.table_name
    --AND cu.column_name = c.column_name 
    --),0) AS IsPrimaryKey
FROM information_schema.columns c
	INNER JOIN information_schema.tables t
		ON c.table_name = t.table_name
WHERE  t.table_name = @table AND
	  (t.table_type = 'BASE TABLE' and not 
	  (t.table_name = 'dtproperties') and not 
	  (t.table_name = 'sysdiagrams'))
ORDER BY c.table_name, c.column_name


OPEN db_cursor2   
FETCH NEXT FROM db_cursor2 INTO @TableName, @ColumnName , @DataType, @MaxLength 

Print '<GroupBox DockPanel.Dock="Top" Header="General" Name="GeneralGroupBox" >'
Print '    <ScrollViewer VerticalScrollBarVisibility="Auto">'
Print '        <WrapPanel Name="MainWrapPanel">'


WHILE @@FETCH_STATUS = 0   
BEGIN   
	  -- if(@MaxLength is null)
			--Print '<li>' + @ColumnName + '  ' + @DataType + '  ' + isnull(@MaxLength , '') + ' </li>'
   --    else
			--Print '<li>' + @ColumnName + '  ' + @DataType + '(' + isnull(@MaxLength , '') + ') </li>'
       
Print '            <StackPanel Margin="0,0,4,0" Orientation="Vertical" >'
Print '                <sg:i9Label x:Name="' + @ColumnName + 'Label" >' + @ColumnName + '</sg:i9Label>'
Print '                <sg:i9TextBox x:Name="' + @ColumnName + 'TextBox" MinWidth="100" Width="{Binding ElementName=' + @ColumnName + 'Label, Path=ActualWidth}"  Text="{Binding Path=' + @ColumnName + '}" />'
Print '            </StackPanel>'
       
       FETCH NEXT FROM db_cursor2 INTO @TableName, @ColumnName , @DataType , @MaxLength 
END   

            
Print '        </WrapPanel>'
Print '    </ScrollViewer>'
Print '</GroupBox>'


CLOSE db_cursor2   
DEALLOCATE db_cursor2
GO
/****** Object:  StoredProcedure [dbo].[TableSchemas_Get]    Script Date: 11/25/2012 15:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TableSchemas_Get]
	--(
	--@table varchar(50)
	--)	
AS
SELECT 
c.table_name As TableName, 
c.column_name As ColumnName, 
c.data_type As DataType, 
c.character_maximum_length As MaxLength
    --COALESCE (
    --( SELECT 
    --    CASE cu.column_name
    --        WHEN null THEN 0
    --        ELSE 1
    --    END
    --FROM information_schema.constraint_column_usage cu
    --INNER join information_schema.table_constraints ct
    --ON ct.constraint_name = cu.constraint_name
    --WHERE 
    --ct.constraint_type = 'PRIMARY KEY' 
    --AND ct.table_name = c.table_name
    --AND cu.column_name = c.column_name 
    --),0) AS IsPrimaryKey
FROM information_schema.columns c
INNER JOIN information_schema.tables t
ON c.table_name = t.table_name
WHERE --@table = t.table_name and 
	   t.table_name Not LIKE 'NIEM%' AND
	   t.table_name Not LIKE 'i9AVL%' AND
	   t.table_name Not LIKE 'i9CAD%' AND
	   t.table_name != 'i9Code_BK' AND
	   t.table_name != 'i9Code_Temp' AND
	   t.table_name != 'i9DynamicEntry_Temp' AND
	  (t.table_type = 'BASE TABLE' and not 
	  (t.table_name = 'dtproperties') and not 
	  (t.table_name = 'sysdiagrams'))
ORDER BY c.table_name, c.ordinal_position
GO
/****** Object:  StoredProcedure [dbo].[TableSchema_Get]    Script Date: 11/25/2012 15:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TableSchema_Get]
	(
	@table varchar(50)
	)	
AS

SELECT 
c.table_name As TableName, 
c.column_name As ColumnName, 
c.data_type As DataType, 
c.character_maximum_length As MaxLength,
    COALESCE (
    ( SELECT 
        CASE cu.column_name
            WHEN null THEN 0
            ELSE 1
        END
    FROM information_schema.constraint_column_usage cu
    INNER join information_schema.table_constraints ct
    ON ct.constraint_name = cu.constraint_name
    WHERE 
    ct.constraint_type = 'PRIMARY KEY' 
    AND ct.table_name = c.table_name
    AND cu.column_name = c.column_name 
    ),0) AS IsPrimaryKey
FROM information_schema.columns c
INNER JOIN information_schema.tables t
ON c.table_name = t.table_name
WHERE  @table = t.table_name and 
	  (t.table_type = 'BASE TABLE' and not 
	  (t.table_name = 'dtproperties') and not 
	  (t.table_name = 'sysdiagrams'))
ORDER BY c.table_name, c.ordinal_position
GO
/****** Object:  StoredProcedure [dbo].[TableNames_Get]    Script Date: 11/25/2012 15:35:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TableNames_Get]

AS

	SELECT 
		c.table_name As TableName
	FROM information_schema.columns c
	INNER JOIN information_schema.tables t
	ON c.table_name = t.table_name
	WHERE  --@table = t.table_name and 
		   --t.table_name Not LIKE 'NIEM%' AND
		   --t.table_name Not LIKE 'TEMP_%' AND
		  (t.table_type = 'BASE TABLE' and not 
		  (t.table_name = 'dtproperties') and not 
		  (t.table_name = 'sysdiagrams'))
	GROUP BY c.table_name
	ORDER BY c.table_name
GO
/****** Object:  StoredProcedure [dbo].[SQLSnipits]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SQLSnipits]

AS


--INSERT INTO i9CodeSet ([CodeSetName], [CodeSetDesc], LastUpdate)
--SELECT [CodeName], [CodeName], GETDATE()
--FROM [i9Code]
--group by [CodeName]

--SELECT * FROM i9CodeSet order by CodeSetName

---------------------------------------------------------------
-- FOREIGN KEY
---------------------------------------------------------------

--ALTER TABLE i9Warrant
--   add i9AgencyID BigInt not  null

--ALTER TABLE i9Warrant
-- ADD CONSTRAINT fk_i9Warrant_i9Agency
-- FOREIGN KEY (i9AgencyID)
-- REFERENCES i9Agency(i9AgencyID)
 
---------------------------------------------------------------
-- 
---------------------------------------------------------------
   
--update i9CodeSet SET i9AgencyID = 1
--SELECT * FROM i9CodeSet

---------------------------------------------------------------
-- PRIMARY KEY
---------------------------------------------------------------
   
--ALTER TABLE i9Warrant
--ADD CONSTRAINT pk_i9Warrant
--PRIMARY KEY(i9WarrantID)

---------------------------------------------------------------
-- 
---------------------------------------------------------------


--ALTER TABLE i9ModuleReportNumber
-- ADD CONSTRAINT fk_i9ModuleReportNumber_i9Module
-- FOREIGN KEY (i9ModuleID)
-- REFERENCES i9Module(i9ModuleID)
	
----------------------------------------------------------


--DROP TABLE i9Agency
--DROP TABLE i9Arrest
--DROP TABLE i9ArrestReport
--DROP TABLE i9Attachment
--DROP TABLE i9AttachmentData
--DROP TABLE i9AttachmentLink
--DROP TABLE i9AVL
--DROP TABLE i9AVLEvent
--DROP TABLE i9AVLHistory
--DROP TABLE i9CADServiceCall
--DROP TABLE i9CADServiceCallNarrative
--DROP TABLE i9CADUnit
--DROP TABLE i9Citation
--DROP TABLE i9Code
--DROP TABLE i9CodeSet
--DROP TABLE i9ConfigurationSetting
--DROP TABLE i9DynamicEntry
--DROP TABLE i9DynamicEntryConfig
--DROP TABLE i9DynamicEntryRule
--DROP TABLE i9EmailAddress
--DROP TABLE i9EmailModule
--DROP TABLE i9Event
--DROP TABLE i9EventType
--DROP TABLE i9FieldContact
--DROP TABLE i9Gang
--DROP TABLE i9LawIncident
--DROP TABLE i9LawIncidentReport
--DROP TABLE i9Location
--DROP TABLE i9MessageInbox
--DROP TABLE i9Module
--DROP TABLE i9ModuleReportNumber
--DROP TABLE i9ModusOperandi
--DROP TABLE i9Offense
--DROP TABLE i9Organization
--DROP TABLE i9OtherContactInformation
--DROP TABLE i9OtherInvolvedPerson
--DROP TABLE i9Package
--DROP TABLE i9PackageMetadata
--DROP TABLE i9Pawn
--DROP TABLE i9Permission
--DROP TABLE i9Person
--DROP TABLE i9PersonAKA
--DROP TABLE i9PersonArrestee
--DROP TABLE i9PersonMissing
--DROP TABLE i9PersonPhoto
--DROP TABLE i9PersonRelated
--DROP TABLE i9PersonSMT
--DROP TABLE i9PersonSubject
--DROP TABLE i9PersonVehicle
--DROP TABLE i9PersonVictim
--DROP TABLE i9PhoneNumber
--DROP TABLE i9Property
--DROP TABLE i9PropertyEvidence
--DROP TABLE i9PropertyExplosive
--DROP TABLE i9PropertyFirearm
--DROP TABLE i9PropertyHazardousMaterial
--DROP TABLE i9PropertyImage
--DROP TABLE i9PropertySecurities
--DROP TABLE i9RelatedRecord
--DROP TABLE i9Structure
--DROP TABLE i9SysPersonnel
--DROP TABLE i9SysPersonnelAddress
--DROP TABLE i9SysPersonnelAssignment
--DROP TABLE i9SysPersonnelPhone
--DROP TABLE i9TableKey
--DROP TABLE i9Vehicle
--DROP TABLE i9Warrant
--DROP TABLE NIEM_Facet
--DROP TABLE NIEM_Namespace
--DROP TABLE NIEM_Property
--DROP TABLE NIEM_Type
--DROP TABLE NIEM_TypeContainsProperty
--DROP TABLE TEMP_ForeignKey
--DROP TABLE TEMP_i9Code
--DROP TABLE TEMP_i9Code2
--DROP TABLE TEMP_i9DynamicEntry
--DROP TABLE TEMP_PrimaryKey
GO
/****** Object:  Table [dbo].[NIEM_TypeContainsProperty]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NIEM_TypeContainsProperty](
	[TypeNamespacePrefix] [nvarchar](255) NULL,
	[TypeName] [nvarchar](255) NULL,
	[QualifiedType] [nvarchar](255) NULL,
	[PropertyNamespacePrefix] [nvarchar](255) NULL,
	[PropertyName] [nvarchar](255) NULL,
	[QualifiedProperty] [nvarchar](255) NULL,
	[IsContent] [bit] NOT NULL,
	[IsReference] [bit] NOT NULL,
	[MinOccurs] [nvarchar](50) NULL,
	[MaxOccurs] [nvarchar](50) NULL,
	[Definition] [nvarchar](max) NULL,
	[SequenceNumber] [smallint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NIEM_Type]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NIEM_Type](
	[TypeNamespacePrefix] [nvarchar](255) NULL,
	[TypeName] [nvarchar](255) NULL,
	[QualifiedType] [nvarchar](255) NULL,
	[ContentStyle] [nvarchar](5) NULL,
	[IsMetadata] [bit] NOT NULL,
	[IsAdapter] [bit] NOT NULL,
	[IsAugmentation] [bit] NOT NULL,
	[NSTag] [nvarchar](50) NULL,
	[Keywords] [nvarchar](max) NULL,
	[ExampleContent] [nvarchar](max) NULL,
	[UsageInfo] [nvarchar](max) NULL,
	[Definition] [nvarchar](max) NULL,
	[SimpleTypeNamespacePrefix] [nvarchar](255) NULL,
	[SimpleTypeName] [nvarchar](255) NULL,
	[SimpleQualifiedType] [nvarchar](255) NULL,
	[ParentTypeNamespacePrefix] [nvarchar](255) NULL,
	[ParentTypeName] [nvarchar](255) NULL,
	[ParentQualifiedType] [nvarchar](255) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NIEM_Property]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NIEM_Property](
	[PropertyNamespacePrefix] [nvarchar](255) NULL,
	[PropertyName] [nvarchar](255) NULL,
	[QualifiedProperty] [nvarchar](255) NULL,
	[IsElement] [bit] NOT NULL,
	[IsAbstract] [bit] NOT NULL,
	[IsContent] [bit] NOT NULL,
	[IsReference] [bit] NOT NULL,
	[NSTag] [nvarchar](50) NULL,
	[Keywords] [nvarchar](max) NULL,
	[ExampleContent] [nvarchar](max) NULL,
	[UsageInfo] [nvarchar](max) NULL,
	[Definition] [nvarchar](max) NULL,
	[TypeNamespacePrefix] [nvarchar](255) NULL,
	[TypeName] [nvarchar](255) NULL,
	[QualifiedType] [nvarchar](255) NULL,
	[SubstitutionGroupPropertyNamespacePrefix] [nvarchar](255) NULL,
	[SubstitutionGroupPropertyName] [nvarchar](255) NULL,
	[SubstitutionGroupQualifiedProperty] [nvarchar](255) NULL,
	[AppliesToTypeNamespacePrefix] [nvarchar](255) NULL,
	[AppliesToTypeName] [nvarchar](255) NULL,
	[AppliesToQualifiedType] [nvarchar](255) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NIEM_Namespace]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NIEM_Namespace](
	[NamespacePrefix] [nvarchar](255) NULL,
	[NamespaceFile] [nvarchar](255) NULL,
	[VersionURI] [nvarchar](255) NULL,
	[VersionReleaseNumber] [nvarchar](255) NULL,
	[NamespaceStyle] [nvarchar](50) NULL,
	[NamespaceIsExternallyGenerated] [bit] NOT NULL,
	[IsConformant] [bit] NOT NULL,
	[Definition] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NIEM_Facet]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NIEM_Facet](
	[TypeNamespacePrefix] [nvarchar](255) NULL,
	[TypeName] [nvarchar](255) NULL,
	[QualifiedType] [nvarchar](255) NULL,
	[FacetName] [nvarchar](20) NULL,
	[FacetValue] [nvarchar](100) NULL,
	[Definition] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[i9TableKey]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[i9TableKey](
	[TableName] [varchar](50) NOT NULL,
	[KeyValue] [bigint] NOT NULL,
	[LastUpdate] [datetime] NULL,
	[i9TableKeyID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9TableKey] PRIMARY KEY CLUSTERED 
(
	[i9TableKeyID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9AVL]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9AVL](
	[VehicleID] [varchar](20) NULL,
	[PositionDateTime] [datetime] NULL,
	[Latitude] [varchar](18) NULL,
	[Longitude] [varchar](20) NULL,
	[Velocity] [numeric](18, 0) NULL,
	[Heading] [numeric](18, 0) NULL,
	[Disconnect] [numeric](18, 0) NULL,
	[MapX] [float] NULL,
	[MapY] [float] NULL,
	[i9AVLID] [uniqueidentifier] NOT NULL,
	[i9AgencyID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9AVL] PRIMARY KEY CLUSTERED 
(
	[i9AVLID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9SysPersonnel]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9SysPersonnel](
	[Officer] [varchar](100) NULL,
	[OfficerActivityTypeCode] [varchar](100) NULL,
	[OfficerActivityTypeText] [varchar](100) NULL,
	[OfficerAssignmentTypeCode] [varchar](100) NULL,
	[OfficerAssignmentTypeText] [varchar](100) NULL,
	[OfficerLEOKATypeCode] [varchar](100) NULL,
	[OfficerORI] [varchar](100) NULL,
	[BadgeNumber] [varchar](100) NULL,
	[FirstName] [varchar](200) NULL,
	[LastName] [varchar](200) NULL,
	[MiddleName] [varchar](200) NULL,
	[Password] [varchar](200) NULL,
	[Enabled] [bit] NULL,
	[LastUpdate] [datetime] NULL,
	[i9SysPersonnelID] [uniqueidentifier] NOT NULL,
	[i9AgencyID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9SysPersonnel] PRIMARY KEY CLUSTERED 
(
	[i9SysPersonnelID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9Event]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9Event](
	[i9EventType] [varchar](20) NOT NULL,
	[i9EventID] [uniqueidentifier] NOT NULL,
	[i9AgencyID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9Event] PRIMARY KEY CLUSTERED 
(
	[i9EventID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9MessageInbox]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[i9MessageInbox](
	[i9MessageInboxID] [uniqueidentifier] NOT NULL,
	[i9AgencyID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9MessageInbox] PRIMARY KEY CLUSTERED 
(
	[i9MessageInboxID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[i9DynamicEntryConfig]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9DynamicEntryConfig](
	[ModuleSection] [varchar](50) NOT NULL,
	[Enabled] [int] NULL,
	[LabelText] [varchar](50) NULL,
	[CtrlWidth] [varchar](50) NULL,
	[CtrlHeight] [varchar](50) NULL,
	[CtrlFont] [varchar](50) NULL,
	[CtrlForGroundColor] [varchar](50) NULL,
	[CtrlBackGroundColor] [varchar](50) NULL,
	[PrintEnabled] [int] NULL,
	[TableName] [varchar](50) NULL,
	[ColumnName] [varchar](50) NULL,
	[MaxLength] [int] NULL,
	[LastUpdate] [datetime] NULL,
	[ToolPopup] [varchar](50) NULL,
	[DataType] [varchar](50) NULL,
	[CtrlTypeName] [varchar](50) NULL,
	[i9DynamicEntryConfigID] [uniqueidentifier] NOT NULL,
	[i9AgencyID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9DynamicEntryConfig] PRIMARY KEY CLUSTERED 
(
	[i9DynamicEntryConfigID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[HTMLTableSchemas_Get]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[HTMLTableSchemas_Get]
	
AS

DECLARE @TableName VARCHAR(50) -- database name  
DECLARE db_cursor CURSOR FOR  

SELECT c.table_name As TableName
FROM information_schema.columns c
	INNER JOIN information_schema.tables t
		ON c.table_name = t.table_name
WHERE 
	   t.table_name Not LIKE 'NIEM%' AND
	   t.table_name Not LIKE 'i9AVL%' AND
	   t.table_name Not LIKE 'i9CAD%' AND
	   t.table_name Not LIKE 'TEMP_%' AND
	  (t.table_type = 'BASE TABLE' and not 
	  (t.table_name = 'dtproperties') and not 
	  (t.table_name = 'sysdiagrams'))
GROUP BY c.table_name
ORDER BY c.table_name


OPEN db_cursor   
FETCH NEXT FROM db_cursor INTO @TableName
    
WHILE @@FETCH_STATUS = 0   
BEGIN   
		Print ' <br/>'
		Print @TableName + ': <br/>'
		Print '<ul>'
		exec HTMLTableSchema_Get @TableName
		Print '</ul>'

       FETCH NEXT FROM db_cursor INTO @TableName   
END   

CLOSE db_cursor   
DEALLOCATE db_cursor
GO
/****** Object:  Table [dbo].[i9AttachmentData]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[i9AttachmentData](
	[Data] [image] NOT NULL,
	[i9AttachmentDataID] [uniqueidentifier] NOT NULL,
	[i9AttachmentID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9AttachmentData] PRIMARY KEY CLUSTERED 
(
	[i9AttachmentDataID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[i9ConfigurationSetting]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9ConfigurationSetting](
	[ConfigurationSettingSection] [varchar](100) NULL,
	[ConfigurationSettingName] [varchar](100) NULL,
	[ConfigurationSettingValue] [varchar](100) NULL,
	[i9ConfigurationSettingID] [uniqueidentifier] NOT NULL,
	[i9AgencyID] [uniqueidentifier] NULL,
 CONSTRAINT [pk_i9ConfigurationSetting] PRIMARY KEY CLUSTERED 
(
	[i9ConfigurationSettingID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9CodeSet]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9CodeSet](
	[CodeSetName] [varchar](50) NOT NULL,
	[CodeSetDesc] [varchar](100) NULL,
	[LastUpdate] [datetime] NOT NULL,
	[i9CodeSetID] [uniqueidentifier] NOT NULL,
	[i9AgencyID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9CodeSet] PRIMARY KEY CLUSTERED 
(
	[i9CodeSetID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9Code]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9Code](
	[CodeSetName] [varchar](50) NULL,
	[Code] [varchar](200) NULL,
	[CodeText] [varchar](2000) NULL,
	[LastUpdate] [datetime] NULL,
	[Enabled] [int] NOT NULL,
	[i9CodeID] [uniqueidentifier] NOT NULL,
	[i9AgencyID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9Code] PRIMARY KEY CLUSTERED 
(
	[i9CodeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9AVLHistory]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9AVLHistory](
	[VehicleID] [varchar](20) NULL,
	[GPSTime] [numeric](18, 0) NULL,
	[ReceiveTime] [datetime] NULL,
	[Latitude] [varchar](18) NULL,
	[Longitude] [varchar](20) NULL,
	[Velocity] [numeric](18, 0) NULL,
	[Heading] [numeric](18, 0) NULL,
	[Source] [varchar](2) NULL,
	[Unit] [varchar](16) NULL,
	[Sector] [varchar](4) NULL,
	[PSUtcDateTime] [datetime] NULL,
	[i9AVLHistoryID] [uniqueidentifier] NOT NULL,
	[i9AgencyID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9AVLHistory] PRIMARY KEY CLUSTERED 
(
	[i9AVLHistoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9CADServiceCall]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9CADServiceCall](
	[ActivityCategory] [varchar](100) NULL,
	[ServiceCallORI] [varchar](100) NULL,
	[ServiceCallDate] [varchar](100) NULL,
	[ServiceCallTime] [varchar](100) NULL,
	[PriorityCode] [varchar](100) NULL,
	[SourceCode] [varchar](100) NULL,
	[SourceText] [varchar](100) NULL,
	[ServiceCaller] [varchar](100) NULL,
	[Operator] [varchar](100) NULL,
	[CADDispatcher] [varchar](100) NULL,
	[TelephoneNumber] [varchar](100) NULL,
	[EmailAddress] [varchar](100) NULL,
	[ServiceCallOtherContactAddress] [varchar](100) NULL,
	[DispatchLocation] [varchar](100) NULL,
	[DispatchLocationOwnerName] [varchar](100) NULL,
	[i9CADServiceCallID] [uniqueidentifier] NOT NULL,
	[i9AgencyID] [uniqueidentifier] NOT NULL,
	[i9EventID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9CADServiceCall] PRIMARY KEY CLUSTERED 
(
	[i9CADServiceCallID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9AVLEvent]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9AVLEvent](
	[EventID] [varchar](16) NULL,
	[Score] [float] NULL,
	[Mapx] [float] NULL,
	[Mapy] [float] NULL,
	[Intersection] [numeric](18, 0) NULL,
	[Parfll] [varchar](2) NULL,
	[Sucess] [numeric](18, 0) NULL,
	[Latitude] [varchar](18) NULL,
	[Longitude] [varchar](20) NULL,
	[i9AVLEventID] [uniqueidentifier] NOT NULL,
	[i9AgencyID] [uniqueidentifier] NOT NULL,
	[i9EventID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9AVLEvent] PRIMARY KEY CLUSTERED 
(
	[i9AVLEventID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9Arrest]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9Arrest](
	[ActivityCategory] [varchar](100) NULL,
	[TransactionNumber] [varchar](100) NULL,
	[ORI_OriginatingAgencyIdentifier] [varchar](100) NULL,
	[ArrestDate] [varchar](100) NULL,
	[NarrativeAccountDescription] [varchar](100) NULL,
	[NarrativeAccountDescriptionDate] [varchar](100) NULL,
	[ArrestTypeCode] [varchar](100) NULL,
	[Arrestee] [varchar](100) NULL,
	[ArrestingOfficer] [varchar](100) NULL,
	[i9ArrestID] [uniqueidentifier] NOT NULL,
	[i9EventID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9Arrest] PRIMARY KEY CLUSTERED 
(
	[i9ArrestID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9LawIncident]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9LawIncident](
	[ActivityCategory] [varchar](50) NULL,
	[IncidentNumber] [varchar](20) NOT NULL,
	[ORI] [varchar](30) NULL,
	[IncidentReportDate] [varchar](100) NULL,
	[BeginDate] [varchar](100) NULL,
	[BeginTime] [varchar](100) NULL,
	[EndDate] [varchar](100) NULL,
	[EndTime] [varchar](100) NULL,
	[NarrativeAccountDescription] [varchar](100) NULL,
	[StatusCode] [varchar](100) NULL,
	[StatusText] [varchar](100) NULL,
	[StatusDate] [varchar](100) NULL,
	[EvidenceHeldIndicator] [varchar](100) NULL,
	[FactorCode] [varchar](100) NULL,
	[FactorText] [varchar](100) NULL,
	[ExceptionalClearanceCode] [varchar](100) NULL,
	[ExceptionalClearanceDate] [varchar](100) NULL,
	[WeatherCode] [varchar](100) NULL,
	[WeatherText] [varchar](100) NULL,
	[IncidentLightingCode] [varchar](100) NULL,
	[IncidentLightingText] [varchar](100) NULL,
	[AgencyNotificationIndicator] [varchar](100) NULL,
	[IncidentDisseminationLevelCode] [varchar](100) NULL,
	[InvolvedProperty] [varchar](100) NULL,
	[Evidence] [varchar](100) NULL,
	[IncidentSubject] [varchar](100) NULL,
	[IncidentVictim] [varchar](100) NULL,
	[IncidentWitness] [varchar](100) NULL,
	[IncidentOtherInvolvedPerson] [varchar](100) NULL,
	[IncidentOffense] [varchar](100) NULL,
	[IncidentServiceCall] [varchar](100) NULL,
	[ReportingOfficer] [varchar](100) NULL,
	[SupplementNumber] [int] NOT NULL,
	[Summary] [varchar](10) NULL,
	[i9LawIncidentID] [uniqueidentifier] NOT NULL,
	[i9AgencyID] [uniqueidentifier] NOT NULL,
	[i9EventID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9LawIncident] PRIMARY KEY CLUSTERED 
(
	[i9LawIncidentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [uc_PersonID_IncNum_SuppNum] UNIQUE NONCLUSTERED 
(
	[IncidentNumber] ASC,
	[SupplementNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9Gang]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9Gang](
	[GangType] [varchar](10) NULL,
	[GangName] [varchar](30) NULL,
	[GangDesc] [varchar](30) NULL,
	[i9GangID] [uniqueidentifier] NOT NULL,
	[i9EventID] [uniqueidentifier] NOT NULL,
	[i9AgencyID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9Gang] PRIMARY KEY CLUSTERED 
(
	[i9GangID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9FieldContact]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[i9FieldContact](
	[i9FieldContactID] [uniqueidentifier] NOT NULL,
	[i9AgencyID] [uniqueidentifier] NOT NULL,
	[i9EventID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9FieldContact] PRIMARY KEY CLUSTERED 
(
	[i9FieldContactID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[i9Location]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9Location](
	[LocationMVI] [bigint] NOT NULL,
	[LocationTypeCode] [varchar](100) NULL,
	[LocationTypeText] [varchar](100) NULL,
	[FullStreetAddress] [varchar](100) NULL,
	[StreetNumber] [varchar](100) NULL,
	[StreetName] [varchar](100) NULL,
	[StreetType] [varchar](100) NULL,
	[StreetPredirection] [varchar](100) NULL,
	[StreetPostdirection] [varchar](100) NULL,
	[Apartment] [varchar](100) NULL,
	[City] [varchar](100) NULL,
	[StateCode] [varchar](100) NULL,
	[StateText] [varchar](100) NULL,
	[LotNumber] [varchar](100) NULL,
	[ZipCode] [varchar](100) NULL,
	[ZipCodeExtension] [varchar](100) NULL,
	[County] [varchar](100) NULL,
	[CountryCode] [varchar](100) NULL,
	[CountryText] [varchar](100) NULL,
	[Highway] [varchar](100) NULL,
	[MileMarker] [varchar](100) NULL,
	[Latitude] [varchar](100) NULL,
	[Longitude] [varchar](100) NULL,
	[i9LocationID] [uniqueidentifier] NOT NULL,
	[i9AgencyID] [uniqueidentifier] NOT NULL,
	[i9EventID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9Location] PRIMARY KEY CLUSTERED 
(
	[i9LocationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9Organization]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9Organization](
	[OrganizationTypeCode] [varchar](100) NULL,
	[OrganizationTypeText] [varchar](100) NULL,
	[Description] [varchar](100) NULL,
	[OrganizationName] [varchar](100) NULL,
	[OrganizationIDValue] [varchar](100) NULL,
	[IDEffectiveDate] [varchar](100) NULL,
	[IDExpirationDate] [varchar](100) NULL,
	[IDIssuingAuthority] [varchar](100) NULL,
	[IDStatus] [varchar](100) NULL,
	[IDType] [varchar](100) NULL,
	[OrganizationTaxID] [varchar](100) NULL,
	[FederalFirearmLicenseID] [varchar](100) NULL,
	[i9OrganizationID] [uniqueidentifier] NOT NULL,
	[i9EventID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9Organization] PRIMARY KEY CLUSTERED 
(
	[i9OrganizationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9Warrant]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[i9Warrant](
	[i9WarrantID] [uniqueidentifier] NOT NULL,
	[i9AgencyID] [uniqueidentifier] NOT NULL,
	[i9EventID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9Warrant] PRIMARY KEY CLUSTERED 
(
	[i9WarrantID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[i9Vehicle]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9Vehicle](
	[VehicleMVI] [bigint] NOT NULL,
	[VIN] [varchar](100) NULL,
	[ModelYear] [varchar](100) NULL,
	[MakeCode] [varchar](100) NULL,
	[ModelCode] [varchar](100) NULL,
	[StyleCode] [varchar](100) NULL,
	[ColorCode] [varchar](100) NULL,
	[VehicleDescription] [varchar](100) NULL,
	[LicenseNumber] [varchar](100) NULL,
	[LicenseJurisdictionCode] [varchar](100) NULL,
	[LicenseJurisdictionText] [varchar](100) NULL,
	[LicenseYear] [varchar](100) NULL,
	[LicenseTypeCode] [varchar](100) NULL,
	[TailNumber] [varchar](100) NULL,
	[FuselageColor] [varchar](100) NULL,
	[WingColor] [varchar](100) NULL,
	[EngineQuantity] [varchar](100) NULL,
	[HomeAirportID] [varchar](100) NULL,
	[HomeAirportName] [varchar](100) NULL,
	[BoatTypeCode] [varchar](100) NULL,
	[BoatTypeText] [varchar](100) NULL,
	[SerialNumber] [varchar](100) NULL,
	[BoatName] [varchar](100) NULL,
	[OverallLength] [varchar](100) NULL,
	[OverallLengthMeasureCode] [varchar](100) NULL,
	[BoatPropulsionCode] [varchar](100) NULL,
	[BoatPropulsionText] [varchar](100) NULL,
	[BoatHomePort] [varchar](100) NULL,
	[CoastGuardDocumentNumber] [varchar](100) NULL,
	[BoatPartCategoryCode] [varchar](100) NULL,
	[BoatPartCategoryText] [varchar](100) NULL,
	[BoatEnginePowerDisplacement] [varchar](100) NULL,
	[BoatEnginePowerDisplacementMeasureCode] [varchar](100) NULL,
	[BoatHullShape] [varchar](100) NULL,
	[BoatOuterHullMaterial] [varchar](100) NULL,
	[i9VehicleID] [uniqueidentifier] NOT NULL,
	[i9EventID] [uniqueidentifier] NOT NULL,
	[i9AgencyID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9Vehicle] PRIMARY KEY CLUSTERED 
(
	[i9VehicleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9SysPersonnelPhone]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9SysPersonnelPhone](
	[PhoneNumber] [varchar](30) NULL,
	[PhoneType] [varchar](30) NULL,
	[i9SysPersonnelPhoneID] [uniqueidentifier] NOT NULL,
	[i9SysPersonnelID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9SysPersonnelPhone] PRIMARY KEY CLUSTERED 
(
	[i9SysPersonnelPhoneID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9SysPersonnelAssignment]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9SysPersonnelAssignment](
	[JobID] [bigint] NOT NULL,
	[AssignmentTitle] [varchar](100) NULL,
	[AssignmentNote] [ntext] NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NOT NULL,
	[i9SysPersonnelAssignmentID] [uniqueidentifier] NOT NULL,
	[i9SysPersonnelID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9SysPersonnelAssignment] PRIMARY KEY CLUSTERED 
(
	[i9SysPersonnelAssignmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9SysPersonnelAddress]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9SysPersonnelAddress](
	[AddressType] [varchar](20) NULL,
	[Address1] [varchar](80) NULL,
	[Address2] [varchar](80) NULL,
	[City] [varchar](60) NULL,
	[State] [varchar](40) NULL,
	[Zip] [varchar](20) NULL,
	[i9SysPersonnelAddressID] [uniqueidentifier] NOT NULL,
	[i9SysPersonnelID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9SysPersonnelAddress] PRIMARY KEY CLUSTERED 
(
	[i9SysPersonnelAddressID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9Structure]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9Structure](
	[StructureTypeCode] [varchar](100) NULL,
	[StructureTypeText] [varchar](100) NULL,
	[StructureOccupiedCode] [varchar](100) NULL,
	[StructureOccupiedText] [varchar](100) NULL,
	[i9StructureID] [uniqueidentifier] NOT NULL,
	[i9EventID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9Structure] PRIMARY KEY CLUSTERED 
(
	[i9StructureID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9Person]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9Person](
	[PersonMNI] [bigint] NOT NULL,
	[PersonPotentialMatchID] [varchar](100) NULL,
	[Prefix] [varchar](100) NULL,
	[FirstName] [varchar](100) NULL,
	[MiddleName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[Suffix] [varchar](100) NULL,
	[FullName] [varchar](100) NULL,
	[PersonNameTypeCode] [varchar](100) NULL,
	[SexCode] [varchar](100) NULL,
	[RaceCode] [varchar](100) NULL,
	[EthnicityCode] [varchar](100) NULL,
	[BirthDate] [varchar](100) NULL,
	[SSN] [varchar](100) NULL,
	[FBINumber] [varchar](100) NULL,
	[DriverLicenseNumber] [varchar](100) NULL,
	[DriverLicenseExpirationDate] [varchar](100) NULL,
	[DriverLicenseIssuingAuthorityCode] [varchar](100) NULL,
	[DriverLicenseIssuingAuthorityText] [varchar](100) NULL,
	[StateID] [varchar](100) NULL,
	[StateIDIssuingAuthorityCode] [varchar](100) NULL,
	[StateIDIssuingAuthorityText] [varchar](100) NULL,
	[PassportID] [varchar](100) NULL,
	[PassportIssuingCountryCode] [varchar](100) NULL,
	[PassportExpirationDate] [varchar](100) NULL,
	[AlienNumber] [varchar](100) NULL,
	[USMarshalServiceFugitiveID] [varchar](100) NULL,
	[RegisteredOffenderIndicator] [varchar](100) NULL,
	[RegisteredOffenderNumber] [varchar](100) NULL,
	[RegisteredOffenderIssuingAuthorityCode] [varchar](100) NULL,
	[RegisteredOffenderIssuingAuthorityText] [varchar](100) NULL,
	[PersonIdentificationNumberPID] [varchar](100) NULL,
	[PIDTypeCode] [varchar](100) NULL,
	[PIDIssuingAuthorityCode] [varchar](100) NULL,
	[PIDIssuingAuthorityText] [varchar](100) NULL,
	[PIDEffectiveDate] [varchar](100) NULL,
	[PIDExpirationDate] [varchar](100) NULL,
	[DNACollectionIndicator] [varchar](100) NULL,
	[DNACollectionStatusText] [varchar](100) NULL,
	[ResidentStatusCode] [varchar](100) NULL,
	[OccupationCode] [varchar](100) NULL,
	[OccupationText] [varchar](100) NULL,
	[CitizenshipCode] [varchar](100) NULL,
	[DigitalImage] [varchar](100) NULL,
	[PersonPhysicalFeatureCode] [varchar](100) NULL,
	[PhysicalFeatureDescription] [varchar](100) NULL,
	[PhysicalFeatureImage] [varchar](100) NULL,
	[PersonHeight] [varchar](100) NULL,
	[MinimumHeight] [varchar](100) NULL,
	[MaximumHeight] [varchar](100) NULL,
	[HeightUnitCode] [varchar](100) NULL,
	[Weight] [varchar](100) NULL,
	[MinimumWeight] [varchar](100) NULL,
	[MaximumWeight] [varchar](100) NULL,
	[WeightUnitCode] [varchar](100) NULL,
	[Age] [varchar](100) NULL,
	[MinimumAge] [varchar](100) NULL,
	[MaximumAge] [varchar](100) NULL,
	[AgeUnitCode] [varchar](100) NULL,
	[EyeColorCode] [varchar](100) NULL,
	[HairColorCode] [varchar](100) NULL,
	[HairLengthCode] [varchar](100) NULL,
	[HairLengthText] [varchar](100) NULL,
	[HairStyleCode] [varchar](100) NULL,
	[HairStyleText] [varchar](100) NULL,
	[HairDescription] [varchar](100) NULL,
	[BuildCode] [varchar](100) NULL,
	[BuildText] [varchar](100) NULL,
	[EyewearCode] [varchar](100) NULL,
	[EyewearText] [varchar](100) NULL,
	[PersonHandednessCode] [varchar](100) NULL,
	[DentalCharacteristicCode] [varchar](100) NULL,
	[DentalCharacteristicText] [varchar](100) NULL,
	[SpeechCode] [varchar](100) NULL,
	[SpeechText] [varchar](100) NULL,
	[FacialHairCode] [varchar](100) NULL,
	[FacialHairText] [varchar](100) NULL,
	[SkinToneCode] [varchar](100) NULL,
	[CautionInformationCode] [varchar](100) NULL,
	[CautionInformationText] [varchar](100) NULL,
	[PersonCriminalInvolvementCode] [varchar](100) NULL,
	[PersonMaritalStatus] [varchar](100) NULL,
	[SequenceNumber] [int] NOT NULL,
	[i9PersonID] [uniqueidentifier] NOT NULL,
	[i9EventID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9Person] PRIMARY KEY CLUSTERED 
(
	[i9PersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9Property]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9Property](
	[PropertyMPI] [bigint] NOT NULL,
	[PropertyStatusCode] [varchar](100) NULL,
	[PropertyTypeCode] [varchar](100) NULL,
	[PropertyTypeText] [varchar](100) NULL,
	[PropertyValue] [varchar](100) NULL,
	[PropertyValueTypeCode] [varchar](100) NULL,
	[PropertyValueTypeText] [varchar](100) NULL,
	[DispositionDate] [varchar](100) NULL,
	[DigitalImage] [varchar](100) NULL,
	[SerialNumber] [varchar](100) NULL,
	[PropertyDescription] [varchar](100) NULL,
	[Make] [varchar](100) NULL,
	[Model] [varchar](100) NULL,
	[PropertyRFID] [varchar](100) NULL,
	[KnifeTypeCode] [varchar](100) NULL,
	[KnifeTypeText] [varchar](100) NULL,
	[HouseholdGoodsTypeCode] [varchar](100) NULL,
	[HouseholdGoodsTypeText] [varchar](100) NULL,
	[LivestockPetTypeCode] [varchar](100) NULL,
	[LivestockPetTypeText] [varchar](100) NULL,
	[GrainTypeCode] [varchar](100) NULL,
	[GrainTypeText] [varchar](100) NULL,
	[CreditBankIDCardTypeCode] [varchar](100) NULL,
	[CreditBankIDCardTypeText] [varchar](100) NULL,
	[ConsumableGoodsTypeCode] [varchar](100) NULL,
	[ConsumableGoodsTypeText] [varchar](100) NULL,
	[ConstructionMaterialTypeCode] [varchar](100) NULL,
	[ConstructionMaterialTypeText] [varchar](100) NULL,
	[ElectronicEquipmentTypeCode] [varchar](100) NULL,
	[ElectronicEquipmentTypeText] [varchar](100) NULL,
	[ClothingTypeCode] [varchar](100) NULL,
	[ClothingTypeText] [varchar](100) NULL,
	[DeviceTypeCode] [varchar](100) NULL,
	[DeviceTypeText] [varchar](100) NULL,
	[DeviceStoredText] [varchar](100) NULL,
	[DeviceAssignedTelephoneNumber] [varchar](100) NULL,
	[DeviceEmailAddress] [varchar](100) NULL,
	[DeviceOtherContactAddress] [varchar](100) NULL,
	[DeviceElectronicSerialNumber_ESN] [varchar](100) NULL,
	[DeviceInternationalMobileEquipmentIdentity_IMEI] [varchar](100) NULL,
	[DrugTypeCode] [varchar](100) NULL,
	[DrugTypeText] [varchar](100) NULL,
	[DrugQuantity] [varchar](100) NULL,
	[DrugMeasureCode] [varchar](100) NULL,
	[DrugContainerDescription] [varchar](100) NULL,
	[DrugSubstanceForm] [varchar](100) NULL,
	[DrugFoundDescription] [varchar](100) NULL,
	[JewelryTypeCode] [varchar](100) NULL,
	[JewelryTypeText] [varchar](100) NULL,
	[i9PropertyID] [uniqueidentifier] NOT NULL,
	[i9AgencyID] [uniqueidentifier] NOT NULL,
	[i9EventID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9Property] PRIMARY KEY CLUSTERED 
(
	[i9PropertyID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9Pawn]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[i9Pawn](
	[i9PawnID] [uniqueidentifier] NOT NULL,
	[i9EventID] [uniqueidentifier] NOT NULL,
	[i9AgencyID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9Pawn] PRIMARY KEY CLUSTERED 
(
	[i9PawnID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[i9Citation]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[i9Citation](
	[i9CitationID] [uniqueidentifier] NOT NULL,
	[i9EventID] [uniqueidentifier] NOT NULL,
	[i9AgencyID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9Citation] PRIMARY KEY CLUSTERED 
(
	[i9CitationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[i9RelatedRecord]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9RelatedRecord](
	[RecordType] [varchar](100) NULL,
	[RecordAgency] [varchar](100) NULL,
	[RecordID] [varchar](100) NULL,
	[Agency] [varchar](100) NULL,
	[RelatedRecordType] [varchar](100) NULL,
	[RelatedRecordAG] [varchar](100) NULL,
	[RelatedRecordRecordID] [varchar](100) NULL,
	[RelatedAGENCY] [varchar](100) NULL,
	[i9RelatedRecordID] [uniqueidentifier] NOT NULL,
	[i9EventID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9RelatedRecord] PRIMARY KEY CLUSTERED 
(
	[i9RelatedRecordID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9PropertySecurities]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9PropertySecurities](
	[SecuritiesTypeCode] [varchar](100) NULL,
	[SecuritiesTypeText] [varchar](100) NULL,
	[SerialNumber] [varchar](100) NULL,
	[Denomination] [varchar](100) NULL,
	[Issuer] [varchar](100) NULL,
	[SecurityOwner] [varchar](100) NULL,
	[DateOrSeriesYear] [varchar](100) NULL,
	[MaturityDate] [varchar](100) NULL,
	[CollectionStartDate] [varchar](100) NULL,
	[CollectionEndDate] [varchar](100) NULL,
	[SecuritiesRansomMoneyIndicatorCode] [varchar](100) NULL,
	[i9PropertySecuritiesID] [uniqueidentifier] NOT NULL,
	[i9PropertyID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9PropertySecurities] PRIMARY KEY CLUSTERED 
(
	[i9PropertySecuritiesID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9PropertyImage]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9PropertyImage](
	[PhotoName] [varchar](20) NULL,
	[PhotoType] [varchar](40) NULL,
	[PropertyImage] [image] NULL,
	[i9PropertyImageID] [uniqueidentifier] NOT NULL,
	[i9PropertyID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9PropertyImage] PRIMARY KEY CLUSTERED 
(
	[i9PropertyImageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9PropertyHazardousMaterial]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9PropertyHazardousMaterial](
	[HazardousMaterialCode] [varchar](100) NULL,
	[HazardousMaterialText] [varchar](100) NULL,
	[HazardousMaterialQuantity] [varchar](100) NULL,
	[HazardousMaterialMeasureCode] [varchar](100) NULL,
	[HazardousMaterialContainerDescription] [varchar](100) NULL,
	[HazardousMaterialSubstanceForm] [varchar](100) NULL,
	[i9PropertyHazardousMaterialID] [uniqueidentifier] NOT NULL,
	[i9PropertyID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9PropertyHazardousMaterial] PRIMARY KEY CLUSTERED 
(
	[i9PropertyHazardousMaterialID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9PropertyFirearm]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9PropertyFirearm](
	[SerialNumber] [varchar](100) NULL,
	[FirearmTypeCode] [varchar](100) NULL,
	[FirearmTypeText] [varchar](100) NULL,
	[FirearmDescriptionCode] [varchar](100) NULL,
	[FirearmDescription] [varchar](100) NULL,
	[FirearmMakeCode] [varchar](100) NULL,
	[FirearmFinishCode] [varchar](100) NULL,
	[CaliberCode] [varchar](100) NULL,
	[BarrelLength] [varchar](100) NULL,
	[BarrelLengthMeasureCode] [varchar](100) NULL,
	[COMMENTS] [varchar](510) NULL,
	[i9PropertyFirearmID] [uniqueidentifier] NOT NULL,
	[i9PropertyID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9PropertyFirearm] PRIMARY KEY CLUSTERED 
(
	[i9PropertyFirearmID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9PropertyExplosive]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9PropertyExplosive](
	[ComponentCode] [varchar](100) NULL,
	[ComponentText] [varchar](100) NULL,
	[ContainerCode] [varchar](100) NULL,
	[ContainerText] [varchar](100) NULL,
	[FillerCode] [varchar](100) NULL,
	[FillerText] [varchar](100) NULL,
	[ExplosiveIgnitionCode] [varchar](100) NULL,
	[ExplosiveIgnitionText] [varchar](100) NULL,
	[i9PropertyExplosiveID] [uniqueidentifier] NOT NULL,
	[i9PropertyID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9PropertyExplosive] PRIMARY KEY CLUSTERED 
(
	[i9PropertyExplosiveID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9PropertyEvidence]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9PropertyEvidence](
	[EvidenceReceiptID] [varchar](100) NULL,
	[EvidenceProperty] [varchar](100) NULL,
	[i9PropertyEvidenceID] [uniqueidentifier] NOT NULL,
	[i9PropertyID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9PropertyEvidence] PRIMARY KEY CLUSTERED 
(
	[i9PropertyEvidenceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9PersonVictim]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9PersonVictim](
	[VictimOrganization] [varchar](100) NULL,
	[VictimPerson] [varchar](100) NULL,
	[VictimSequenceNumber] [varchar](100) NULL,
	[ModusOperandiVictimActionCode] [varchar](100) NULL,
	[ModusOperandiVictimActionText] [varchar](100) NULL,
	[VictimTypeCode] [varchar](100) NULL,
	[VictimTypeText] [varchar](100) NULL,
	[AggravatedAssaultHomicideCircumstanceCode] [varchar](100) NULL,
	[AggravatedAssaultHomicideCircumstanceText] [varchar](100) NULL,
	[AdditionalJustifiableHomicideCode] [varchar](100) NULL,
	[InjuryTypeCode] [varchar](100) NULL,
	[InjuryTypeText] [varchar](100) NULL,
	[i9PersonVictimID] [uniqueidentifier] NOT NULL,
	[i9PersonID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9PersonVictim] PRIMARY KEY CLUSTERED 
(
	[i9PersonVictimID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9PersonVehicle]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9PersonVehicle](
	[Involvement] [varchar](160) NULL,
	[InvolvementDate] [datetime] NULL,
	[i9PersonVehicleID] [uniqueidentifier] NOT NULL,
	[i9PersonID] [uniqueidentifier] NOT NULL,
	[i9VehicleID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9PersonVehicle] PRIMARY KEY CLUSTERED 
(
	[i9PersonVehicleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9PersonSubject]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9PersonSubject](
	[SubjectPerson] [varchar](100) NULL,
	[Organization] [varchar](100) NULL,
	[SequenceNumber] [varchar](100) NULL,
	[ModusOperandiSubjectActionCode] [varchar](100) NULL,
	[ModusOperandiSubjectActionText] [varchar](100) NULL,
	[ModusOperandiObservationCode] [varchar](100) NULL,
	[ModusOperandiObservationText] [varchar](100) NULL,
	[i9PersonSubjectID] [uniqueidentifier] NOT NULL,
	[i9PersonID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9PersonSubject] PRIMARY KEY CLUSTERED 
(
	[i9PersonSubjectID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9PersonSMT]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9PersonSMT](
	[SMTCode] [varchar](100) NULL,
	[SMTDescription] [varchar](100) NULL,
	[SMTLocation] [varchar](100) NULL,
	[Feature] [varchar](100) NULL,
	[i9PersonSMTID] [uniqueidentifier] NOT NULL,
	[i9PersonID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9PersonSMT] PRIMARY KEY CLUSTERED 
(
	[i9PersonSMTID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9PersonRelated]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9PersonRelated](
	[RecordedDate] [datetime] NULL,
	[InvolvementCode] [varchar](60) NULL,
	[i9PersonRelatedID] [uniqueidentifier] NOT NULL,
	[i9PersonID] [uniqueidentifier] NOT NULL,
	[i9PersonIDRelated] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9PersonRelated] PRIMARY KEY CLUSTERED 
(
	[i9PersonRelatedID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9PersonPhoto]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[i9PersonPhoto](
	[Photo] [image] NULL,
	[PhotoThumb] [image] NULL,
	[i9PersonPhotoID] [uniqueidentifier] NOT NULL,
	[i9PersonID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9PersonPhoto] PRIMARY KEY CLUSTERED 
(
	[i9PersonPhotoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[i9PersonMissing]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9PersonMissing](
	[MissingPerson] [varchar](100) NULL,
	[MissingPersonCircumstanceCode] [varchar](100) NULL,
	[MissingPersonCircumstanceText] [varchar](100) NULL,
	[MissingPersonDeclarationDate] [varchar](100) NULL,
	[MissingPersonDeclarationTime] [varchar](100) NULL,
	[MissingPersonFoundDate] [varchar](100) NULL,
	[MissingPersonFoundTime] [varchar](100) NULL,
	[MissingPersonFoundIndicator] [varchar](100) NULL,
	[MissingPersonLastSeenDate] [varchar](100) NULL,
	[MissingPersonLastSeenTime] [varchar](100) NULL,
	[i9PersonMissingID] [uniqueidentifier] NOT NULL,
	[i9PersonID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9PersonMissing] PRIMARY KEY CLUSTERED 
(
	[i9PersonMissingID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9PersonArrestee]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9PersonArrestee](
	[Arrestee] [varchar](100) NULL,
	[CountCode] [varchar](100) NULL,
	[JuvenileDispositionCode] [varchar](100) NULL,
	[ArresteeWeapon] [varchar](100) NULL,
	[OffenseID] [bigint] NOT NULL,
	[ArresteeViolatedStatuteNumber] [varchar](100) NULL,
	[ArresteeViolatedStatuteDescription] [varchar](100) NULL,
	[ArresteeSequenceNumber] [varchar](100) NULL,
	[i9PersonArresteeID] [uniqueidentifier] NOT NULL,
	[i9PersonID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9PersonArrestee] PRIMARY KEY CLUSTERED 
(
	[i9PersonArresteeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9PersonAKA]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9PersonAKA](
	[Prefix] [varchar](100) NULL,
	[FirstName] [varchar](100) NULL,
	[MiddleName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[NameSuffix] [varchar](100) NULL,
	[FullName] [varchar](100) NULL,
	[i9PersonAKAID] [uniqueidentifier] NOT NULL,
	[i9PersonID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9PersonAKA] PRIMARY KEY CLUSTERED 
(
	[i9PersonAKAID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9Offense]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9Offense](
	[ActivityCategory] [varchar](100) NULL,
	[OffenseCode] [varchar](100) NULL,
	[OffenseText] [varchar](100) NULL,
	[OffenseDescriptionText] [varchar](100) NULL,
	[OffenseViolatedStatuteNumber] [varchar](100) NULL,
	[OffenseViolatedStatuteDescription] [varchar](100) NULL,
	[OffenseAttemptedCompletedCode] [varchar](100) NULL,
	[OffenseBiasMotivationCode] [varchar](100) NULL,
	[OffenseBiasMotivationText] [varchar](100) NULL,
	[OffenseBiasMotivationCauseCode] [varchar](100) NULL,
	[OffenseBiasMotivationCauseText] [varchar](100) NULL,
	[OffenseNumberofPremisesEntered] [varchar](100) NULL,
	[OffenseForcedEntryCode] [varchar](100) NULL,
	[OffensePointofEntryCode] [varchar](100) NULL,
	[OffensePointofEntryText] [varchar](100) NULL,
	[OffenseMethodofEntryCode] [varchar](100) NULL,
	[OffenseMethodofEntryText] [varchar](100) NULL,
	[OffenseSecurityTypeEntryCode] [varchar](100) NULL,
	[OffenseSecurityTypeEntryText] [varchar](100) NULL,
	[OffenseSecuritySystemsStatusEntryCode] [varchar](100) NULL,
	[OffenseForcedExitCode] [varchar](100) NULL,
	[OffensePointofExitCode] [varchar](100) NULL,
	[OffensePointofExitText] [varchar](100) NULL,
	[OffenseMethodofExitCode] [varchar](100) NULL,
	[OffenseMethodofExitText] [varchar](100) NULL,
	[OffenseSecurityTypeExitCode] [varchar](100) NULL,
	[OffenseSecurityTypeExitText] [varchar](100) NULL,
	[OffenseSecuritySystemsStatusExitCode] [varchar](100) NULL,
	[OffenseLocation] [varchar](100) NULL,
	[OffenseCriminalActivityCode] [varchar](100) NULL,
	[OffenseCriminalActivityText] [varchar](100) NULL,
	[OffenseForceUsedCode] [varchar](100) NULL,
	[OffenseForceUsedText] [varchar](100) NULL,
	[OffenseWeapon] [varchar](100) NULL,
	[i9OffenseID] [uniqueidentifier] NOT NULL,
	[i9LawIncidentID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9Offense] PRIMARY KEY CLUSTERED 
(
	[i9OffenseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[i9ModusOperandi]    Script Date: 11/25/2012 15:35:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[i9ModusOperandi](
	[ModusOperandiCode] [varchar](15) NOT NULL,
	[ModusOperandiText] [varchar](50) NOT NULL,
	[i9ModusOperandiID] [uniqueidentifier] NOT NULL,
	[i9LawIncidentID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [pk_i9ModusOperandi] PRIMARY KEY CLUSTERED 
(
	[i9ModusOperandiID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF__i9CADUnit__i9CAD__3D7E1B63]    Script Date: 11/25/2012 15:35:54 ******/
ALTER TABLE [dbo].[i9CADUnit] ADD  DEFAULT (newid()) FOR [i9CADUnitID]
GO
/****** Object:  Default [DF__i9CADServ__i9CAD__3B95D2F1]    Script Date: 11/25/2012 15:35:54 ******/
ALTER TABLE [dbo].[i9CADServiceCallNarrative] ADD  DEFAULT (newid()) FOR [i9CADServiceCallNarrativeID]
GO
/****** Object:  Default [DF__i9Attachm__i9Att__2E3BD7D3]    Script Date: 11/25/2012 15:35:54 ******/
ALTER TABLE [dbo].[i9Attachment] ADD  DEFAULT (newid()) FOR [i9AttachmentID]
GO
/****** Object:  Default [DF__i9ArrestR__i9Arr__2C538F61]    Script Date: 11/25/2012 15:35:54 ******/
ALTER TABLE [dbo].[i9ArrestReport] ADD  DEFAULT (newid()) FOR [i9ArrestReportID]
GO
/****** Object:  Default [DF__i9Attachm__i9Att__320C68B7]    Script Date: 11/25/2012 15:35:55 ******/
ALTER TABLE [dbo].[i9AttachmentLink] ADD  DEFAULT (newid()) FOR [i9AttachmentLinkID]
GO
/****** Object:  Default [DF__i9Agency__i9Agen__2882FE7D]    Script Date: 11/25/2012 15:35:55 ******/
ALTER TABLE [dbo].[i9Agency] ADD  DEFAULT (newid()) FOR [i9AgencyID]
GO
/****** Object:  Default [DF__i9LawInci__i9Law__5649C92D]    Script Date: 11/25/2012 15:35:55 ******/
ALTER TABLE [dbo].[i9LawIncidentReport] ADD  DEFAULT (newid()) FOR [i9LawIncidentReportID]
GO
/****** Object:  Default [DF__i9EmailMo__i9Ema__4CC05EF3]    Script Date: 11/25/2012 15:35:55 ******/
ALTER TABLE [dbo].[i9EmailModule] ADD  DEFAULT (newid()) FOR [i9EmailModuleID]
GO
/****** Object:  Default [DF__i9EmailAd__i9Ema__4AD81681]    Script Date: 11/25/2012 15:35:55 ******/
ALTER TABLE [dbo].[i9EmailAddress] ADD  DEFAULT (newid()) FOR [i9EmailAddressID]
GO
/****** Object:  Default [DF__i9Dynamic__i9Dyn__48EFCE0F]    Script Date: 11/25/2012 15:35:55 ******/
ALTER TABLE [dbo].[i9DynamicEntryRule] ADD  DEFAULT (newid()) FOR [i9DynamicEntryRuleID]
GO
/****** Object:  Default [DF__i9Package__i9Pac__6B44E613]    Script Date: 11/25/2012 15:35:55 ******/
ALTER TABLE [dbo].[i9PackageMetadata] ADD  DEFAULT (newid()) FOR [i9PackageMetadataID]
GO
/****** Object:  Default [DF__i9Package__i9Pac__695C9DA1]    Script Date: 11/25/2012 15:35:55 ******/
ALTER TABLE [dbo].[i9Package] ADD  DEFAULT (newid()) FOR [i9PackageID]
GO
/****** Object:  Default [DF__i9OtherIn__i9Oth__6774552F]    Script Date: 11/25/2012 15:35:55 ******/
ALTER TABLE [dbo].[i9OtherInvolvedPerson] ADD  DEFAULT (newid()) FOR [i9OtherInvolvedPersonID]
GO
/****** Object:  Default [DF__i9OtherCo__i9Oth__658C0CBD]    Script Date: 11/25/2012 15:35:55 ******/
ALTER TABLE [dbo].[i9OtherContactInformation] ADD  DEFAULT (newid()) FOR [i9OtherContactInformationID]
GO
/****** Object:  Default [DF__i9ModuleR__i9Mod__5DEAEAF5]    Script Date: 11/25/2012 15:35:55 ******/
ALTER TABLE [dbo].[i9ModuleReportNumber] ADD  DEFAULT (newid()) FOR [i9ModuleReportNumberID]
GO
/****** Object:  Default [DF__i9Module__i9Modu__5C02A283]    Script Date: 11/25/2012 15:35:55 ******/
ALTER TABLE [dbo].[i9Module] ADD  DEFAULT (newid()) FOR [i9ModuleID]
GO
/****** Object:  Default [DF__i9Solvabi__i9Sol__153B1FDF]    Script Date: 11/25/2012 15:35:55 ******/
ALTER TABLE [dbo].[i9SolvabilityFactor] ADD  DEFAULT (newid()) FOR [i9SolvabilityFactorID]
GO
/****** Object:  Default [DF__i9Permiss__i9Per__6F1576F7]    Script Date: 11/25/2012 15:35:55 ******/
ALTER TABLE [dbo].[i9Permission] ADD  DEFAULT (newid()) FOR [i9PermissionID]
GO
/****** Object:  Default [DF__i9PhoneNu__i9Pho__041093DD]    Script Date: 11/25/2012 15:35:55 ******/
ALTER TABLE [dbo].[i9PhoneNumber] ADD  DEFAULT (newid()) FOR [i9PhoneNumberID]
GO
/****** Object:  Default [DF__i9TableKe__i9Tab__20ACD28B]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9TableKey] ADD  DEFAULT (newid()) FOR [i9TableKeyID]
GO
/****** Object:  Default [DF__i9AVL__i9AVLID__33F4B129]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9AVL] ADD  DEFAULT (newid()) FOR [i9AVLID]
GO
/****** Object:  Default [DF__i9SysPers__i9Sys__190BB0C3]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9SysPersonnel] ADD  DEFAULT (newid()) FOR [i9SysPersonnelID]
GO
/****** Object:  Default [DF__i9Event__i9Event__4EA8A765]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Event] ADD  DEFAULT (newid()) FOR [i9EventID]
GO
/****** Object:  Default [DF__i9Message__i9Mes__5A1A5A11]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9MessageInbox] ADD  DEFAULT (newid()) FOR [i9MessageInboxID]
GO
/****** Object:  Default [DF__i9Dynamic__i9Dyn__4707859D]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9DynamicEntryConfig] ADD  DEFAULT (newid()) FOR [i9DynamicEntryConfigID]
GO
/****** Object:  Default [DF__i9Attachm__i9Att__30242045]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9AttachmentData] ADD  DEFAULT (newid()) FOR [i9AttachmentDataID]
GO
/****** Object:  Default [DF__i9Configu__i9Con__451F3D2B]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9ConfigurationSetting] ADD  DEFAULT (newid()) FOR [i9ConfigurationSettingID]
GO
/****** Object:  Default [DF__i9CodeSet__i9Cod__4336F4B9]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9CodeSet] ADD  DEFAULT (newid()) FOR [i9CodeSetID]
GO
/****** Object:  Default [DF__i9Code__i9CodeID__414EAC47]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Code] ADD  DEFAULT (newid()) FOR [i9CodeID]
GO
/****** Object:  Default [DF__i9AVLHist__i9AVL__37C5420D]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9AVLHistory] ADD  DEFAULT (newid()) FOR [i9AVLHistoryID]
GO
/****** Object:  Default [DF__i9CADServ__i9CAD__39AD8A7F]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9CADServiceCall] ADD  DEFAULT (newid()) FOR [i9CADServiceCallID]
GO
/****** Object:  Default [DF__i9AVLEven__i9AVL__35DCF99B]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9AVLEvent] ADD  DEFAULT (newid()) FOR [i9AVLEventID]
GO
/****** Object:  Default [DF__i9Arrest__i9Arre__2A6B46EF]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Arrest] ADD  DEFAULT (newid()) FOR [i9ArrestID]
GO
/****** Object:  Default [DF__i9LawInci__i9Law__546180BB]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9LawIncident] ADD  DEFAULT (newid()) FOR [i9LawIncidentID]
GO
/****** Object:  Default [DF__i9Gang__i9GangID__52793849]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Gang] ADD  DEFAULT (newid()) FOR [i9GangID]
GO
/****** Object:  Default [DF__i9FieldCo__i9Fie__5090EFD7]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9FieldContact] ADD  DEFAULT (newid()) FOR [i9FieldContactID]
GO
/****** Object:  Default [DF__i9Locatio__i9Loc__5832119F]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Location] ADD  DEFAULT (newid()) FOR [i9LocationID]
GO
/****** Object:  Default [DF__i9Organiz__i9Org__63A3C44B]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Organization] ADD  DEFAULT (newid()) FOR [i9OrganizationID]
GO
/****** Object:  Default [DF__i9Warrant__i9War__247D636F]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Warrant] ADD  DEFAULT (newid()) FOR [i9WarrantID]
GO
/****** Object:  Default [DF__i9Vehicle__i9Veh__22951AFD]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Vehicle] ADD  DEFAULT (newid()) FOR [i9VehicleID]
GO
/****** Object:  Default [DF__i9SysPers__i9Sys__1EC48A19]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9SysPersonnelPhone] ADD  DEFAULT (newid()) FOR [i9SysPersonnelPhoneID]
GO
/****** Object:  Default [DF__i9SysPers__i9Sys__1CDC41A7]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9SysPersonnelAssignment] ADD  DEFAULT (newid()) FOR [i9SysPersonnelAssignmentID]
GO
/****** Object:  Default [DF__i9SysPers__i9Sys__1AF3F935]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9SysPersonnelAddress] ADD  DEFAULT (newid()) FOR [i9SysPersonnelAddressID]
GO
/****** Object:  Default [DF__i9Structu__i9Str__17236851]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Structure] ADD  DEFAULT (newid()) FOR [i9StructureID]
GO
/****** Object:  Default [DF__i9Person__i9Pers__70FDBF69]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Person] ADD  DEFAULT (newid()) FOR [i9PersonID]
GO
/****** Object:  Default [DF__i9Propert__i9Pro__05F8DC4F]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Property] ADD  DEFAULT (newid()) FOR [i9PropertyID]
GO
/****** Object:  Default [DF__i9Pawn__i9PawnID__6D2D2E85]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Pawn] ADD  DEFAULT (newid()) FOR [i9PawnID]
GO
/****** Object:  Default [DF__i9Citatio__i9Cit__3F6663D5]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Citation] ADD  DEFAULT (newid()) FOR [i9CitationID]
GO
/****** Object:  Default [DF__i9Related__i9Rel__1352D76D]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9RelatedRecord] ADD  DEFAULT (newid()) FOR [i9RelatedRecordID]
GO
/****** Object:  Default [DF__i9Propert__i9Pro__116A8EFB]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PropertySecurities] ADD  DEFAULT (newid()) FOR [i9PropertySecuritiesID]
GO
/****** Object:  Default [DF__i9Propert__i9Pro__0F824689]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PropertyImage] ADD  DEFAULT (newid()) FOR [i9PropertyImageID]
GO
/****** Object:  Default [DF__i9Propert__i9Pro__0D99FE17]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PropertyHazardousMaterial] ADD  DEFAULT (newid()) FOR [i9PropertyHazardousMaterialID]
GO
/****** Object:  Default [DF__i9Propert__i9Pro__0BB1B5A5]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PropertyFirearm] ADD  DEFAULT (newid()) FOR [i9PropertyFirearmID]
GO
/****** Object:  Default [DF__i9Propert__i9Pro__09C96D33]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PropertyExplosive] ADD  DEFAULT (newid()) FOR [i9PropertyExplosiveID]
GO
/****** Object:  Default [DF__i9Propert__i9Pro__07E124C1]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PropertyEvidence] ADD  DEFAULT (newid()) FOR [i9PropertyEvidenceID]
GO
/****** Object:  Default [DF__i9PersonV__i9Per__02284B6B]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PersonVictim] ADD  DEFAULT (newid()) FOR [i9PersonVictimID]
GO
/****** Object:  Default [DF__i9PersonV__i9Per__004002F9]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PersonVehicle] ADD  DEFAULT (newid()) FOR [i9PersonVehicleID]
GO
/****** Object:  Default [DF__i9PersonS__i9Per__7E57BA87]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PersonSubject] ADD  DEFAULT (newid()) FOR [i9PersonSubjectID]
GO
/****** Object:  Default [DF__i9PersonS__i9Per__7C6F7215]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PersonSMT] ADD  DEFAULT (newid()) FOR [i9PersonSMTID]
GO
/****** Object:  Default [DF__i9PersonR__i9Per__7A8729A3]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PersonRelated] ADD  DEFAULT (newid()) FOR [i9PersonRelatedID]
GO
/****** Object:  Default [DF__i9PersonP__i9Per__789EE131]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PersonPhoto] ADD  DEFAULT (newid()) FOR [i9PersonPhotoID]
GO
/****** Object:  Default [DF__i9PersonM__i9Per__76B698BF]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PersonMissing] ADD  DEFAULT (newid()) FOR [i9PersonMissingID]
GO
/****** Object:  Default [DF__i9PersonA__i9Per__74CE504D]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PersonArrestee] ADD  DEFAULT (newid()) FOR [i9PersonArresteeID]
GO
/****** Object:  Default [DF__i9PersonA__i9Per__72E607DB]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PersonAKA] ADD  DEFAULT (newid()) FOR [i9PersonAKAID]
GO
/****** Object:  Default [DF__i9Offense__i9Off__61BB7BD9]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Offense] ADD  DEFAULT (newid()) FOR [i9OffenseID]
GO
/****** Object:  Default [DF__i9ModusOp__i9Mod__5FD33367]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9ModusOperandi] ADD  DEFAULT (newid()) FOR [i9ModusOperandiID]
GO
/****** Object:  Check [chk_i9ModuleReportNumber_ResetReportNumber]    Script Date: 11/25/2012 15:35:55 ******/
ALTER TABLE [dbo].[i9ModuleReportNumber]  WITH CHECK ADD  CONSTRAINT [chk_i9ModuleReportNumber_ResetReportNumber] CHECK  (([ResetReportNumber]='DAY' OR [ResetReportNumber]='YEAR'))
GO
ALTER TABLE [dbo].[i9ModuleReportNumber] CHECK CONSTRAINT [chk_i9ModuleReportNumber_ResetReportNumber]
GO
/****** Object:  ForeignKey [fk_i9AVL_i9Agency]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9AVL]  WITH CHECK ADD  CONSTRAINT [fk_i9AVL_i9Agency] FOREIGN KEY([i9AgencyID])
REFERENCES [dbo].[i9Agency] ([i9AgencyID])
GO
ALTER TABLE [dbo].[i9AVL] CHECK CONSTRAINT [fk_i9AVL_i9Agency]
GO
/****** Object:  ForeignKey [fk_i9SysPersonnel_i9Agency]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9SysPersonnel]  WITH CHECK ADD  CONSTRAINT [fk_i9SysPersonnel_i9Agency] FOREIGN KEY([i9AgencyID])
REFERENCES [dbo].[i9Agency] ([i9AgencyID])
GO
ALTER TABLE [dbo].[i9SysPersonnel] CHECK CONSTRAINT [fk_i9SysPersonnel_i9Agency]
GO
/****** Object:  ForeignKey [fk_i9Event_i9Agency]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Event]  WITH CHECK ADD  CONSTRAINT [fk_i9Event_i9Agency] FOREIGN KEY([i9AgencyID])
REFERENCES [dbo].[i9Agency] ([i9AgencyID])
GO
ALTER TABLE [dbo].[i9Event] CHECK CONSTRAINT [fk_i9Event_i9Agency]
GO
/****** Object:  ForeignKey [fk_i9Event_i9EventType]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Event]  WITH CHECK ADD  CONSTRAINT [fk_i9Event_i9EventType] FOREIGN KEY([i9EventType])
REFERENCES [dbo].[i9EventType] ([i9EventType])
GO
ALTER TABLE [dbo].[i9Event] CHECK CONSTRAINT [fk_i9Event_i9EventType]
GO
/****** Object:  ForeignKey [fk_i9MessageInbox_i9Agency]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9MessageInbox]  WITH CHECK ADD  CONSTRAINT [fk_i9MessageInbox_i9Agency] FOREIGN KEY([i9AgencyID])
REFERENCES [dbo].[i9Agency] ([i9AgencyID])
GO
ALTER TABLE [dbo].[i9MessageInbox] CHECK CONSTRAINT [fk_i9MessageInbox_i9Agency]
GO
/****** Object:  ForeignKey [fk_i9DynamicEntryConfig_i9Agency]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9DynamicEntryConfig]  WITH CHECK ADD  CONSTRAINT [fk_i9DynamicEntryConfig_i9Agency] FOREIGN KEY([i9AgencyID])
REFERENCES [dbo].[i9Agency] ([i9AgencyID])
GO
ALTER TABLE [dbo].[i9DynamicEntryConfig] CHECK CONSTRAINT [fk_i9DynamicEntryConfig_i9Agency]
GO
/****** Object:  ForeignKey [fk_i9AttachmentData_i9Attachment]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9AttachmentData]  WITH CHECK ADD  CONSTRAINT [fk_i9AttachmentData_i9Attachment] FOREIGN KEY([i9AttachmentID])
REFERENCES [dbo].[i9Attachment] ([i9AttachmentID])
GO
ALTER TABLE [dbo].[i9AttachmentData] CHECK CONSTRAINT [fk_i9AttachmentData_i9Attachment]
GO
/****** Object:  ForeignKey [fk_i9ConfigurationSetting_i9Agency]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9ConfigurationSetting]  WITH CHECK ADD  CONSTRAINT [fk_i9ConfigurationSetting_i9Agency] FOREIGN KEY([i9AgencyID])
REFERENCES [dbo].[i9Agency] ([i9AgencyID])
GO
ALTER TABLE [dbo].[i9ConfigurationSetting] CHECK CONSTRAINT [fk_i9ConfigurationSetting_i9Agency]
GO
/****** Object:  ForeignKey [fk_i9CodeSet_i9Agency]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9CodeSet]  WITH CHECK ADD  CONSTRAINT [fk_i9CodeSet_i9Agency] FOREIGN KEY([i9AgencyID])
REFERENCES [dbo].[i9Agency] ([i9AgencyID])
GO
ALTER TABLE [dbo].[i9CodeSet] CHECK CONSTRAINT [fk_i9CodeSet_i9Agency]
GO
/****** Object:  ForeignKey [fk_i9Code_i9Agency]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Code]  WITH CHECK ADD  CONSTRAINT [fk_i9Code_i9Agency] FOREIGN KEY([i9AgencyID])
REFERENCES [dbo].[i9Agency] ([i9AgencyID])
GO
ALTER TABLE [dbo].[i9Code] CHECK CONSTRAINT [fk_i9Code_i9Agency]
GO
/****** Object:  ForeignKey [fk_i9AVLHistory_i9Agency]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9AVLHistory]  WITH CHECK ADD  CONSTRAINT [fk_i9AVLHistory_i9Agency] FOREIGN KEY([i9AgencyID])
REFERENCES [dbo].[i9Agency] ([i9AgencyID])
GO
ALTER TABLE [dbo].[i9AVLHistory] CHECK CONSTRAINT [fk_i9AVLHistory_i9Agency]
GO
/****** Object:  ForeignKey [fk_i9CADServiceCall_i9Agency]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9CADServiceCall]  WITH CHECK ADD  CONSTRAINT [fk_i9CADServiceCall_i9Agency] FOREIGN KEY([i9AgencyID])
REFERENCES [dbo].[i9Agency] ([i9AgencyID])
GO
ALTER TABLE [dbo].[i9CADServiceCall] CHECK CONSTRAINT [fk_i9CADServiceCall_i9Agency]
GO
/****** Object:  ForeignKey [fk_i9CADServiceCall_i9Event]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9CADServiceCall]  WITH CHECK ADD  CONSTRAINT [fk_i9CADServiceCall_i9Event] FOREIGN KEY([i9EventID])
REFERENCES [dbo].[i9Event] ([i9EventID])
GO
ALTER TABLE [dbo].[i9CADServiceCall] CHECK CONSTRAINT [fk_i9CADServiceCall_i9Event]
GO
/****** Object:  ForeignKey [fk_i9AVLEvent_i9Agency]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9AVLEvent]  WITH CHECK ADD  CONSTRAINT [fk_i9AVLEvent_i9Agency] FOREIGN KEY([i9AgencyID])
REFERENCES [dbo].[i9Agency] ([i9AgencyID])
GO
ALTER TABLE [dbo].[i9AVLEvent] CHECK CONSTRAINT [fk_i9AVLEvent_i9Agency]
GO
/****** Object:  ForeignKey [fk_i9AVLEvent_i9Event]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9AVLEvent]  WITH CHECK ADD  CONSTRAINT [fk_i9AVLEvent_i9Event] FOREIGN KEY([i9EventID])
REFERENCES [dbo].[i9Event] ([i9EventID])
GO
ALTER TABLE [dbo].[i9AVLEvent] CHECK CONSTRAINT [fk_i9AVLEvent_i9Event]
GO
/****** Object:  ForeignKey [fk_i9Arrest_i9Event]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Arrest]  WITH CHECK ADD  CONSTRAINT [fk_i9Arrest_i9Event] FOREIGN KEY([i9EventID])
REFERENCES [dbo].[i9Event] ([i9EventID])
GO
ALTER TABLE [dbo].[i9Arrest] CHECK CONSTRAINT [fk_i9Arrest_i9Event]
GO
/****** Object:  ForeignKey [fk_i9LawIncident_i9Agency]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9LawIncident]  WITH CHECK ADD  CONSTRAINT [fk_i9LawIncident_i9Agency] FOREIGN KEY([i9AgencyID])
REFERENCES [dbo].[i9Agency] ([i9AgencyID])
GO
ALTER TABLE [dbo].[i9LawIncident] CHECK CONSTRAINT [fk_i9LawIncident_i9Agency]
GO
/****** Object:  ForeignKey [fk_i9LawIncident_i9Event]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9LawIncident]  WITH CHECK ADD  CONSTRAINT [fk_i9LawIncident_i9Event] FOREIGN KEY([i9EventID])
REFERENCES [dbo].[i9Event] ([i9EventID])
GO
ALTER TABLE [dbo].[i9LawIncident] CHECK CONSTRAINT [fk_i9LawIncident_i9Event]
GO
/****** Object:  ForeignKey [fk_i9Gang_i9Agency]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Gang]  WITH CHECK ADD  CONSTRAINT [fk_i9Gang_i9Agency] FOREIGN KEY([i9AgencyID])
REFERENCES [dbo].[i9Agency] ([i9AgencyID])
GO
ALTER TABLE [dbo].[i9Gang] CHECK CONSTRAINT [fk_i9Gang_i9Agency]
GO
/****** Object:  ForeignKey [fk_i9Gang_i9Event]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Gang]  WITH CHECK ADD  CONSTRAINT [fk_i9Gang_i9Event] FOREIGN KEY([i9EventID])
REFERENCES [dbo].[i9Event] ([i9EventID])
GO
ALTER TABLE [dbo].[i9Gang] CHECK CONSTRAINT [fk_i9Gang_i9Event]
GO
/****** Object:  ForeignKey [fk_i9FieldContact_i9Agency]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9FieldContact]  WITH CHECK ADD  CONSTRAINT [fk_i9FieldContact_i9Agency] FOREIGN KEY([i9AgencyID])
REFERENCES [dbo].[i9Agency] ([i9AgencyID])
GO
ALTER TABLE [dbo].[i9FieldContact] CHECK CONSTRAINT [fk_i9FieldContact_i9Agency]
GO
/****** Object:  ForeignKey [fk_i9FieldContact_i9Event]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9FieldContact]  WITH CHECK ADD  CONSTRAINT [fk_i9FieldContact_i9Event] FOREIGN KEY([i9EventID])
REFERENCES [dbo].[i9Event] ([i9EventID])
GO
ALTER TABLE [dbo].[i9FieldContact] CHECK CONSTRAINT [fk_i9FieldContact_i9Event]
GO
/****** Object:  ForeignKey [fk_i9Location_i9Agency]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Location]  WITH CHECK ADD  CONSTRAINT [fk_i9Location_i9Agency] FOREIGN KEY([i9AgencyID])
REFERENCES [dbo].[i9Agency] ([i9AgencyID])
GO
ALTER TABLE [dbo].[i9Location] CHECK CONSTRAINT [fk_i9Location_i9Agency]
GO
/****** Object:  ForeignKey [fk_i9Location_i9Event]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Location]  WITH CHECK ADD  CONSTRAINT [fk_i9Location_i9Event] FOREIGN KEY([i9EventID])
REFERENCES [dbo].[i9Event] ([i9EventID])
GO
ALTER TABLE [dbo].[i9Location] CHECK CONSTRAINT [fk_i9Location_i9Event]
GO
/****** Object:  ForeignKey [fk_i9Organization_i9Event]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Organization]  WITH CHECK ADD  CONSTRAINT [fk_i9Organization_i9Event] FOREIGN KEY([i9EventID])
REFERENCES [dbo].[i9Event] ([i9EventID])
GO
ALTER TABLE [dbo].[i9Organization] CHECK CONSTRAINT [fk_i9Organization_i9Event]
GO
/****** Object:  ForeignKey [fk_i9Warrant_i9Agency]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Warrant]  WITH CHECK ADD  CONSTRAINT [fk_i9Warrant_i9Agency] FOREIGN KEY([i9AgencyID])
REFERENCES [dbo].[i9Agency] ([i9AgencyID])
GO
ALTER TABLE [dbo].[i9Warrant] CHECK CONSTRAINT [fk_i9Warrant_i9Agency]
GO
/****** Object:  ForeignKey [fk_i9Warrant_i9Event]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Warrant]  WITH CHECK ADD  CONSTRAINT [fk_i9Warrant_i9Event] FOREIGN KEY([i9EventID])
REFERENCES [dbo].[i9Event] ([i9EventID])
GO
ALTER TABLE [dbo].[i9Warrant] CHECK CONSTRAINT [fk_i9Warrant_i9Event]
GO
/****** Object:  ForeignKey [fk_i9Vehicle_i9Agency]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Vehicle]  WITH CHECK ADD  CONSTRAINT [fk_i9Vehicle_i9Agency] FOREIGN KEY([i9AgencyID])
REFERENCES [dbo].[i9Agency] ([i9AgencyID])
GO
ALTER TABLE [dbo].[i9Vehicle] CHECK CONSTRAINT [fk_i9Vehicle_i9Agency]
GO
/****** Object:  ForeignKey [fk_i9Vehicle_i9Event]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Vehicle]  WITH CHECK ADD  CONSTRAINT [fk_i9Vehicle_i9Event] FOREIGN KEY([i9EventID])
REFERENCES [dbo].[i9Event] ([i9EventID])
GO
ALTER TABLE [dbo].[i9Vehicle] CHECK CONSTRAINT [fk_i9Vehicle_i9Event]
GO
/****** Object:  ForeignKey [fk_i9SysPersonnelPhone_i9SysPersonnel]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9SysPersonnelPhone]  WITH CHECK ADD  CONSTRAINT [fk_i9SysPersonnelPhone_i9SysPersonnel] FOREIGN KEY([i9SysPersonnelID])
REFERENCES [dbo].[i9SysPersonnel] ([i9SysPersonnelID])
GO
ALTER TABLE [dbo].[i9SysPersonnelPhone] CHECK CONSTRAINT [fk_i9SysPersonnelPhone_i9SysPersonnel]
GO
/****** Object:  ForeignKey [fk_i9SysPersonnelAssignment_i9SysPersonnel]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9SysPersonnelAssignment]  WITH CHECK ADD  CONSTRAINT [fk_i9SysPersonnelAssignment_i9SysPersonnel] FOREIGN KEY([i9SysPersonnelID])
REFERENCES [dbo].[i9SysPersonnel] ([i9SysPersonnelID])
GO
ALTER TABLE [dbo].[i9SysPersonnelAssignment] CHECK CONSTRAINT [fk_i9SysPersonnelAssignment_i9SysPersonnel]
GO
/****** Object:  ForeignKey [fk_i9SysPersonnelAddress_i9SysPersonnel]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9SysPersonnelAddress]  WITH CHECK ADD  CONSTRAINT [fk_i9SysPersonnelAddress_i9SysPersonnel] FOREIGN KEY([i9SysPersonnelID])
REFERENCES [dbo].[i9SysPersonnel] ([i9SysPersonnelID])
GO
ALTER TABLE [dbo].[i9SysPersonnelAddress] CHECK CONSTRAINT [fk_i9SysPersonnelAddress_i9SysPersonnel]
GO
/****** Object:  ForeignKey [fk_i9Structure_i9Event]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Structure]  WITH CHECK ADD  CONSTRAINT [fk_i9Structure_i9Event] FOREIGN KEY([i9EventID])
REFERENCES [dbo].[i9Event] ([i9EventID])
GO
ALTER TABLE [dbo].[i9Structure] CHECK CONSTRAINT [fk_i9Structure_i9Event]
GO
/****** Object:  ForeignKey [fk_i9Person_i9Event]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Person]  WITH CHECK ADD  CONSTRAINT [fk_i9Person_i9Event] FOREIGN KEY([i9EventID])
REFERENCES [dbo].[i9Event] ([i9EventID])
GO
ALTER TABLE [dbo].[i9Person] CHECK CONSTRAINT [fk_i9Person_i9Event]
GO
/****** Object:  ForeignKey [fk_i9Property_i9Agency]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Property]  WITH CHECK ADD  CONSTRAINT [fk_i9Property_i9Agency] FOREIGN KEY([i9AgencyID])
REFERENCES [dbo].[i9Agency] ([i9AgencyID])
GO
ALTER TABLE [dbo].[i9Property] CHECK CONSTRAINT [fk_i9Property_i9Agency]
GO
/****** Object:  ForeignKey [fk_i9Property_i9Event]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Property]  WITH CHECK ADD  CONSTRAINT [fk_i9Property_i9Event] FOREIGN KEY([i9EventID])
REFERENCES [dbo].[i9Event] ([i9EventID])
GO
ALTER TABLE [dbo].[i9Property] CHECK CONSTRAINT [fk_i9Property_i9Event]
GO
/****** Object:  ForeignKey [fk_i9Pawn_i9Agency]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Pawn]  WITH CHECK ADD  CONSTRAINT [fk_i9Pawn_i9Agency] FOREIGN KEY([i9AgencyID])
REFERENCES [dbo].[i9Agency] ([i9AgencyID])
GO
ALTER TABLE [dbo].[i9Pawn] CHECK CONSTRAINT [fk_i9Pawn_i9Agency]
GO
/****** Object:  ForeignKey [fk_i9Pawn_i9Event]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Pawn]  WITH CHECK ADD  CONSTRAINT [fk_i9Pawn_i9Event] FOREIGN KEY([i9EventID])
REFERENCES [dbo].[i9Event] ([i9EventID])
GO
ALTER TABLE [dbo].[i9Pawn] CHECK CONSTRAINT [fk_i9Pawn_i9Event]
GO
/****** Object:  ForeignKey [fk_i9Citation_i9Agency]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Citation]  WITH CHECK ADD  CONSTRAINT [fk_i9Citation_i9Agency] FOREIGN KEY([i9AgencyID])
REFERENCES [dbo].[i9Agency] ([i9AgencyID])
GO
ALTER TABLE [dbo].[i9Citation] CHECK CONSTRAINT [fk_i9Citation_i9Agency]
GO
/****** Object:  ForeignKey [fk_i9Citation_i9Event]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Citation]  WITH CHECK ADD  CONSTRAINT [fk_i9Citation_i9Event] FOREIGN KEY([i9EventID])
REFERENCES [dbo].[i9Event] ([i9EventID])
GO
ALTER TABLE [dbo].[i9Citation] CHECK CONSTRAINT [fk_i9Citation_i9Event]
GO
/****** Object:  ForeignKey [fk_i9RelatedRecord_i9Event]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9RelatedRecord]  WITH CHECK ADD  CONSTRAINT [fk_i9RelatedRecord_i9Event] FOREIGN KEY([i9EventID])
REFERENCES [dbo].[i9Event] ([i9EventID])
GO
ALTER TABLE [dbo].[i9RelatedRecord] CHECK CONSTRAINT [fk_i9RelatedRecord_i9Event]
GO
/****** Object:  ForeignKey [fk_i9PropertySecurities_i9Property]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PropertySecurities]  WITH CHECK ADD  CONSTRAINT [fk_i9PropertySecurities_i9Property] FOREIGN KEY([i9PropertyID])
REFERENCES [dbo].[i9Property] ([i9PropertyID])
GO
ALTER TABLE [dbo].[i9PropertySecurities] CHECK CONSTRAINT [fk_i9PropertySecurities_i9Property]
GO
/****** Object:  ForeignKey [fk_i9PropertyImage_i9Property]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PropertyImage]  WITH CHECK ADD  CONSTRAINT [fk_i9PropertyImage_i9Property] FOREIGN KEY([i9PropertyID])
REFERENCES [dbo].[i9Property] ([i9PropertyID])
GO
ALTER TABLE [dbo].[i9PropertyImage] CHECK CONSTRAINT [fk_i9PropertyImage_i9Property]
GO
/****** Object:  ForeignKey [fk_i9PropertyHazardousMaterial_i9Property]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PropertyHazardousMaterial]  WITH CHECK ADD  CONSTRAINT [fk_i9PropertyHazardousMaterial_i9Property] FOREIGN KEY([i9PropertyID])
REFERENCES [dbo].[i9Property] ([i9PropertyID])
GO
ALTER TABLE [dbo].[i9PropertyHazardousMaterial] CHECK CONSTRAINT [fk_i9PropertyHazardousMaterial_i9Property]
GO
/****** Object:  ForeignKey [fk_i9PropertyFirearm_i9Property]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PropertyFirearm]  WITH CHECK ADD  CONSTRAINT [fk_i9PropertyFirearm_i9Property] FOREIGN KEY([i9PropertyID])
REFERENCES [dbo].[i9Property] ([i9PropertyID])
GO
ALTER TABLE [dbo].[i9PropertyFirearm] CHECK CONSTRAINT [fk_i9PropertyFirearm_i9Property]
GO
/****** Object:  ForeignKey [fk_i9PropertyExplosive_i9Property]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PropertyExplosive]  WITH CHECK ADD  CONSTRAINT [fk_i9PropertyExplosive_i9Property] FOREIGN KEY([i9PropertyID])
REFERENCES [dbo].[i9Property] ([i9PropertyID])
GO
ALTER TABLE [dbo].[i9PropertyExplosive] CHECK CONSTRAINT [fk_i9PropertyExplosive_i9Property]
GO
/****** Object:  ForeignKey [fk_i9PropertyEvidence_i9Property]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PropertyEvidence]  WITH CHECK ADD  CONSTRAINT [fk_i9PropertyEvidence_i9Property] FOREIGN KEY([i9PropertyID])
REFERENCES [dbo].[i9Property] ([i9PropertyID])
GO
ALTER TABLE [dbo].[i9PropertyEvidence] CHECK CONSTRAINT [fk_i9PropertyEvidence_i9Property]
GO
/****** Object:  ForeignKey [fk_i9PersonVictim_i9Person]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PersonVictim]  WITH CHECK ADD  CONSTRAINT [fk_i9PersonVictim_i9Person] FOREIGN KEY([i9PersonID])
REFERENCES [dbo].[i9Person] ([i9PersonID])
GO
ALTER TABLE [dbo].[i9PersonVictim] CHECK CONSTRAINT [fk_i9PersonVictim_i9Person]
GO
/****** Object:  ForeignKey [fk_i9PersonVehicle_i9Person]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PersonVehicle]  WITH CHECK ADD  CONSTRAINT [fk_i9PersonVehicle_i9Person] FOREIGN KEY([i9PersonID])
REFERENCES [dbo].[i9Person] ([i9PersonID])
GO
ALTER TABLE [dbo].[i9PersonVehicle] CHECK CONSTRAINT [fk_i9PersonVehicle_i9Person]
GO
/****** Object:  ForeignKey [fk_i9PersonVehicle_i9Vehicle]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PersonVehicle]  WITH CHECK ADD  CONSTRAINT [fk_i9PersonVehicle_i9Vehicle] FOREIGN KEY([i9VehicleID])
REFERENCES [dbo].[i9Vehicle] ([i9VehicleID])
GO
ALTER TABLE [dbo].[i9PersonVehicle] CHECK CONSTRAINT [fk_i9PersonVehicle_i9Vehicle]
GO
/****** Object:  ForeignKey [fk_i9PersonSubject_i9Person]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PersonSubject]  WITH CHECK ADD  CONSTRAINT [fk_i9PersonSubject_i9Person] FOREIGN KEY([i9PersonID])
REFERENCES [dbo].[i9Person] ([i9PersonID])
GO
ALTER TABLE [dbo].[i9PersonSubject] CHECK CONSTRAINT [fk_i9PersonSubject_i9Person]
GO
/****** Object:  ForeignKey [fk_i9PersonSMT_i9Person]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PersonSMT]  WITH CHECK ADD  CONSTRAINT [fk_i9PersonSMT_i9Person] FOREIGN KEY([i9PersonID])
REFERENCES [dbo].[i9Person] ([i9PersonID])
GO
ALTER TABLE [dbo].[i9PersonSMT] CHECK CONSTRAINT [fk_i9PersonSMT_i9Person]
GO
/****** Object:  ForeignKey [fk_i9PersonRelated_i9Person]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PersonRelated]  WITH CHECK ADD  CONSTRAINT [fk_i9PersonRelated_i9Person] FOREIGN KEY([i9PersonID])
REFERENCES [dbo].[i9Person] ([i9PersonID])
GO
ALTER TABLE [dbo].[i9PersonRelated] CHECK CONSTRAINT [fk_i9PersonRelated_i9Person]
GO
/****** Object:  ForeignKey [fk_i9PersonRelated_i9Person_i9PersonIDRelated]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PersonRelated]  WITH CHECK ADD  CONSTRAINT [fk_i9PersonRelated_i9Person_i9PersonIDRelated] FOREIGN KEY([i9PersonIDRelated])
REFERENCES [dbo].[i9Person] ([i9PersonID])
GO
ALTER TABLE [dbo].[i9PersonRelated] CHECK CONSTRAINT [fk_i9PersonRelated_i9Person_i9PersonIDRelated]
GO
/****** Object:  ForeignKey [fk_i9PersonPhoto_i9Person]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PersonPhoto]  WITH CHECK ADD  CONSTRAINT [fk_i9PersonPhoto_i9Person] FOREIGN KEY([i9PersonID])
REFERENCES [dbo].[i9Person] ([i9PersonID])
GO
ALTER TABLE [dbo].[i9PersonPhoto] CHECK CONSTRAINT [fk_i9PersonPhoto_i9Person]
GO
/****** Object:  ForeignKey [fk_i9PersonMissing_i9Person]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PersonMissing]  WITH CHECK ADD  CONSTRAINT [fk_i9PersonMissing_i9Person] FOREIGN KEY([i9PersonID])
REFERENCES [dbo].[i9Person] ([i9PersonID])
GO
ALTER TABLE [dbo].[i9PersonMissing] CHECK CONSTRAINT [fk_i9PersonMissing_i9Person]
GO
/****** Object:  ForeignKey [fk_i9PersonArrestee_i9Person]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PersonArrestee]  WITH CHECK ADD  CONSTRAINT [fk_i9PersonArrestee_i9Person] FOREIGN KEY([i9PersonID])
REFERENCES [dbo].[i9Person] ([i9PersonID])
GO
ALTER TABLE [dbo].[i9PersonArrestee] CHECK CONSTRAINT [fk_i9PersonArrestee_i9Person]
GO
/****** Object:  ForeignKey [fk_i9PersonAKA_i9Person]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9PersonAKA]  WITH CHECK ADD  CONSTRAINT [fk_i9PersonAKA_i9Person] FOREIGN KEY([i9PersonID])
REFERENCES [dbo].[i9Person] ([i9PersonID])
GO
ALTER TABLE [dbo].[i9PersonAKA] CHECK CONSTRAINT [fk_i9PersonAKA_i9Person]
GO
/****** Object:  ForeignKey [fk_i9Offense_i9LawIncident]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9Offense]  WITH CHECK ADD  CONSTRAINT [fk_i9Offense_i9LawIncident] FOREIGN KEY([i9LawIncidentID])
REFERENCES [dbo].[i9LawIncident] ([i9LawIncidentID])
GO
ALTER TABLE [dbo].[i9Offense] CHECK CONSTRAINT [fk_i9Offense_i9LawIncident]
GO
/****** Object:  ForeignKey [fk_i9ModusOperandi_i9LawIncident]    Script Date: 11/25/2012 15:35:56 ******/
ALTER TABLE [dbo].[i9ModusOperandi]  WITH CHECK ADD  CONSTRAINT [fk_i9ModusOperandi_i9LawIncident] FOREIGN KEY([i9LawIncidentID])
REFERENCES [dbo].[i9LawIncident] ([i9LawIncidentID])
GO
ALTER TABLE [dbo].[i9ModusOperandi] CHECK CONSTRAINT [fk_i9ModusOperandi_i9LawIncident]
GO
