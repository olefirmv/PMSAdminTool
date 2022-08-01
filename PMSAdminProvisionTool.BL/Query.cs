using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMSAdminProvisionTool.BL
{
    public class Query
    {
        public static string CreatePMSDBQuery()
        {
            return @"
CREATE DATABASE [PMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'testDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\testDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'testDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\testDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )

";
        }

        public static string CreateComponentQuery()
        {
            return @"USE [PMS]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Component](
	[ComponentID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[SectionNum] [int] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Cipher] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Component] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC,
	[SectionNum] ASC,
	[ComponentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Component] ADD  CONSTRAINT [DF_Component_ProjectID]  DEFAULT ((0)) FOR [ProjectID]
GO

ALTER TABLE [dbo].[Component] ADD  CONSTRAINT [DF_Component_SectionID]  DEFAULT ((0)) FOR [SectionNum]
GO

ALTER TABLE [dbo].[Component]  WITH CHECK ADD  CONSTRAINT [FK_Component_Project] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
ON DELETE SET DEFAULT
GO

ALTER TABLE [dbo].[Component] CHECK CONSTRAINT [FK_Component_Project]
GO

ALTER TABLE [dbo].[Component]  WITH CHECK ADD  CONSTRAINT [FK_Component_Section] FOREIGN KEY([ProjectID], [SectionNum])
REFERENCES [dbo].[Section] ([ProjectID], [SectionNum])
GO

ALTER TABLE [dbo].[Component] CHECK CONSTRAINT [FK_Component_Section]
GO


";
        }

        public static string CreateDocumentQuery()
        {
            return @"USE [PMS]
GO

/****** Object:  Table [dbo].[Document]    Script Date: 27.05.2022 19:53:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Document](
	[DocumentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Agrees] [nvarchar](100) NOT NULL,
	[Claims] [nvarchar](100) NOT NULL,
	[Develops] [nvarchar](100) NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[FormID] [int] NOT NULL,
	[SectionNum] [int] NOT NULL,
	[StageNum] [int] NOT NULL,
 CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED 
(
	[DocumentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Document] ADD  CONSTRAINT [DF_Document_FormID]  DEFAULT ((0)) FOR [FormID]
GO

ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_Form] FOREIGN KEY([FormID])
REFERENCES [dbo].[Form] ([FormID])
ON DELETE SET DEFAULT
GO

ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_Form]
GO


";
        }

        public static string CreateEmployeeQuery()
        {
            return @"USE [PMS]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 27.05.2022 19:53:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[SecondName] [nvarchar](20) NOT NULL,
	[Patronymic] [nvarchar](20) NOT NULL,
	[Mail] [nvarchar](30) NOT NULL,
	[Login] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Credential] FOREIGN KEY([Login])
REFERENCES [dbo].[Credential] ([Login])
GO

ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Credential]
GO


";
        }

        public static string CreateCredentialQuery()
        {
            return @"USE [PMS]
GO

/****** Object:  Table [dbo].[Credential]    Script Date: 27.05.2022 19:53:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Credential](
	[Login] [nvarchar](10) NOT NULL,
	[Password] [nvarchar](44) NOT NULL,
 CONSTRAINT [PK_Credential] PRIMARY KEY CLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


";
        }

        public static string CreateFormQuery()
        {
            return @"USE [PMS]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Form](
	[FormID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Form] PRIMARY KEY CLUSTERED 
(
	[FormID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


";
        }

        public static string CreateMemberQuery()
        {
            return @"USE [PMS]
GO

/****** Object:  Table [dbo].[Member]    Script Date: 27.05.2022 19:54:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Member](
	[MemberID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[ProjectID] [int] NOT NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Member] ADD  CONSTRAINT [DF_Member_ProjectID]  DEFAULT ((0)) FOR [ProjectID]
GO

ALTER TABLE [dbo].[Member]  WITH CHECK ADD  CONSTRAINT [FK_Member_Project1] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
ON DELETE SET DEFAULT
GO

ALTER TABLE [dbo].[Member] CHECK CONSTRAINT [FK_Member_Project1]
GO


";
        }

        public static string CreatePrivelegeQuery()
        {
            return @"USE [PMS]
GO

/****** Object:  Table [dbo].[Privelege]    Script Date: 27.05.2022 19:54:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Privelege](
	[PrivelegeID] [int] IDENTITY(1,1) NOT NULL,
	[ReadOne] [bit] NOT NULL,
	[ReadFull] [bit] NOT NULL,
	[EditOne] [bit] NOT NULL,
	[EditFull] [bit] NOT NULL,
 CONSTRAINT [PK_Privelege] PRIMARY KEY CLUSTERED 
(
	[PrivelegeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


";
        }

        public static string CreateProjectQuery()
        {
            return @"USE [PMS]
GO

/****** Object:  Table [dbo].[Project]    Script Date: 27.05.2022 19:55:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Project](
	[ProjectID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[CreateDateTime] [datetime] NOT NULL,
	[ModifyDateTime] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Project] ADD  CONSTRAINT [DF_Project_CreationDate]  DEFAULT (getdate()) FOR [CreateDateTime]
GO


";
        }

        public static string CreateProjectEmployeeQuery()
        {
            return @"USE [PMS]
GO

/****** Object:  Table [dbo].[ProjectEmployee]    Script Date: 27.05.2022 19:55:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProjectEmployee](
	[ProjectID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[PrivelegeID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectEmployee] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC,
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProjectEmployee] ADD  CONSTRAINT [DF_ProjectEmployee_ProjectID]  DEFAULT ((0)) FOR [ProjectID]
GO

ALTER TABLE [dbo].[ProjectEmployee] ADD  CONSTRAINT [DF_ProjectEmployee_EmployeeID]  DEFAULT ((0)) FOR [EmployeeID]
GO

ALTER TABLE [dbo].[ProjectEmployee] ADD  CONSTRAINT [DF_ProjectEmployee_PrivelegeID]  DEFAULT ((0)) FOR [PrivelegeID]
GO

ALTER TABLE [dbo].[ProjectEmployee]  WITH CHECK ADD  CONSTRAINT [FK_ProjectEmployee_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
ON DELETE SET DEFAULT
GO

ALTER TABLE [dbo].[ProjectEmployee] CHECK CONSTRAINT [FK_ProjectEmployee_Employee]
GO

ALTER TABLE [dbo].[ProjectEmployee]  WITH CHECK ADD  CONSTRAINT [FK_ProjectEmployee_Privelege] FOREIGN KEY([PrivelegeID])
REFERENCES [dbo].[Privelege] ([PrivelegeID])
ON DELETE SET DEFAULT
GO

ALTER TABLE [dbo].[ProjectEmployee] CHECK CONSTRAINT [FK_ProjectEmployee_Privelege]
GO

ALTER TABLE [dbo].[ProjectEmployee]  WITH CHECK ADD  CONSTRAINT [FK_ProjectEmployee_Project] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
ON DELETE SET DEFAULT
GO

ALTER TABLE [dbo].[ProjectEmployee] CHECK CONSTRAINT [FK_ProjectEmployee_Project]
GO


";
        }

        public static string CreateProjectRoleQuery()
        {
            return @"USE [PMS]
GO

/****** Object:  Table [dbo].[ProjectRole]    Script Date: 27.05.2022 19:55:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProjectRole](
	[ProjectID] [int] NOT NULL,
	[ComponentID] [int] NOT NULL,
	[MemberID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
	[SectionNum] [int] NOT NULL,
 CONSTRAINT [PK_ProjectRole] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC,
	[SectionNum] ASC,
	[RoleID] ASC,
	[ComponentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProjectRole] ADD  CONSTRAINT [DF_ProjectRole_ProjectID]  DEFAULT ((0)) FOR [ProjectID]
GO

ALTER TABLE [dbo].[ProjectRole] ADD  CONSTRAINT [DF_ProjectRole_ComponentID]  DEFAULT ((0)) FOR [ComponentID]
GO

ALTER TABLE [dbo].[ProjectRole] ADD  CONSTRAINT [DF_ProjectRole_MemberID]  DEFAULT ((0)) FOR [MemberID]
GO

ALTER TABLE [dbo].[ProjectRole] ADD  CONSTRAINT [DF_ProjectRole_RoleID]  DEFAULT ((0)) FOR [RoleID]
GO

ALTER TABLE [dbo].[ProjectRole] ADD  CONSTRAINT [DF_ProjectRole_SectionID]  DEFAULT ((0)) FOR [SectionNum]
GO

ALTER TABLE [dbo].[ProjectRole]  WITH CHECK ADD  CONSTRAINT [FK_ProjectRole_Member] FOREIGN KEY([MemberID])
REFERENCES [dbo].[Member] ([MemberID])
ON DELETE SET DEFAULT
GO

ALTER TABLE [dbo].[ProjectRole] CHECK CONSTRAINT [FK_ProjectRole_Member]
GO

ALTER TABLE [dbo].[ProjectRole]  WITH CHECK ADD  CONSTRAINT [FK_ProjectRole_Project] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
ON DELETE SET DEFAULT
GO

ALTER TABLE [dbo].[ProjectRole] CHECK CONSTRAINT [FK_ProjectRole_Project]
GO

ALTER TABLE [dbo].[ProjectRole]  WITH CHECK ADD  CONSTRAINT [FK_ProjectRole_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO

ALTER TABLE [dbo].[ProjectRole] CHECK CONSTRAINT [FK_ProjectRole_Role]
GO

ALTER TABLE [dbo].[ProjectRole]  WITH CHECK ADD  CONSTRAINT [FK_ProjectRole_Section] FOREIGN KEY([ProjectID], [SectionNum])
REFERENCES [dbo].[Section] ([ProjectID], [SectionNum])
GO

ALTER TABLE [dbo].[ProjectRole] CHECK CONSTRAINT [FK_ProjectRole_Section]
GO


";
        }
        public static string CreateRoleQuery()
        {
            return @"USE [PMS]
GO

/****** Object:  Table [dbo].[Role]    Script Date: 27.05.2022 19:56:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


";
        }

        public static string CreateSectionQuery()
        {
            return @"USE [PMS]
GO

/****** Object:  Table [dbo].[Section]    Script Date: 27.05.2022 19:56:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Section](
	[ProjectID] [int] NOT NULL,
	[SectionNum] [int] NOT NULL,
	[Cipher] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Section_1] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC,
	[SectionNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Section] ADD  CONSTRAINT [DF_Section_ProjectID]  DEFAULT ((0)) FOR [ProjectID]
GO

ALTER TABLE [dbo].[Section]  WITH CHECK ADD  CONSTRAINT [FK_Section_Project] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
ON DELETE SET DEFAULT
GO

ALTER TABLE [dbo].[Section] CHECK CONSTRAINT [FK_Section_Project]
GO


";
        }

        public static string CreateStageQuery()
        {
            return @"USE [PMS]
GO

/****** Object:  Table [dbo].[Stage]    Script Date: 27.05.2022 19:56:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Stage](
	[ProjectID] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[StageNum] [int] NOT NULL,
	[SectionNum] [int] NOT NULL,
 CONSTRAINT [PK_Stage_1] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC,
	[SectionNum] ASC,
	[StageNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Stage] ADD  CONSTRAINT [DF_Stage_ProjectID]  DEFAULT ((0)) FOR [ProjectID]
GO

ALTER TABLE [dbo].[Stage] ADD  CONSTRAINT [DF_Stage_StageNum]  DEFAULT ((0)) FOR [StageNum]
GO

ALTER TABLE [dbo].[Stage] ADD  CONSTRAINT [DF_Stage_SectionNum]  DEFAULT ((0)) FOR [SectionNum]
GO

ALTER TABLE [dbo].[Stage]  WITH CHECK ADD  CONSTRAINT [FK_Stage_Project] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
ON DELETE SET DEFAULT
GO

ALTER TABLE [dbo].[Stage] CHECK CONSTRAINT [FK_Stage_Project]
GO

ALTER TABLE [dbo].[Stage]  WITH CHECK ADD  CONSTRAINT [FK_Stage_Section] FOREIGN KEY([ProjectID], [SectionNum])
REFERENCES [dbo].[Section] ([ProjectID], [SectionNum])
ON DELETE SET DEFAULT
GO

ALTER TABLE [dbo].[Stage] CHECK CONSTRAINT [FK_Stage_Section]
GO


";
        }

        public static string CreateStageLineQuery()
        {
            return @"USE [PMS]
GO

/****** Object:  Table [dbo].[StageLine]    Script Date: 27.05.2022 19:56:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StageLine](
	[StageLineID] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[StageNum] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[DocumentID] [int] NOT NULL,
	[ComponentID] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[ModifyDateTime] [datetime] NOT NULL,
	[SectionNum] [int] NOT NULL,
 CONSTRAINT [PK_StageLine] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC,
	[SectionNum] ASC,
	[StageNum] ASC,
	[StageLineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[StageLine] ADD  CONSTRAINT [DF_StageLine_StageLineID]  DEFAULT ((0)) FOR [StageLineID]
GO

ALTER TABLE [dbo].[StageLine] ADD  CONSTRAINT [DF_StageLine_StageNum]  DEFAULT ((0)) FOR [StageNum]
GO

ALTER TABLE [dbo].[StageLine] ADD  CONSTRAINT [DF_StageLine_DocumentID]  DEFAULT ((0)) FOR [DocumentID]
GO

ALTER TABLE [dbo].[StageLine] ADD  CONSTRAINT [DF_StageLine_ComponentID]  DEFAULT ((0)) FOR [ComponentID]
GO

ALTER TABLE [dbo].[StageLine] ADD  CONSTRAINT [DF_StageLine_ProjectID]  DEFAULT ((0)) FOR [ProjectID]
GO

ALTER TABLE [dbo].[StageLine] ADD  CONSTRAINT [DF_StageLine_EmployeeID]  DEFAULT ((0)) FOR [EmployeeID]
GO

ALTER TABLE [dbo].[StageLine] ADD  CONSTRAINT [DF_StageLine_SectionNum]  DEFAULT ((0)) FOR [SectionNum]
GO

ALTER TABLE [dbo].[StageLine]  WITH CHECK ADD  CONSTRAINT [FK_StageLine_Document] FOREIGN KEY([DocumentID])
REFERENCES [dbo].[Document] ([DocumentID])
ON DELETE SET DEFAULT
GO

ALTER TABLE [dbo].[StageLine] CHECK CONSTRAINT [FK_StageLine_Document]
GO

ALTER TABLE [dbo].[StageLine]  WITH CHECK ADD  CONSTRAINT [FK_StageLine_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
ON DELETE SET DEFAULT
GO

ALTER TABLE [dbo].[StageLine] CHECK CONSTRAINT [FK_StageLine_Employee]
GO

ALTER TABLE [dbo].[StageLine]  WITH CHECK ADD  CONSTRAINT [FK_StageLine_Project] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
ON DELETE SET DEFAULT
GO

ALTER TABLE [dbo].[StageLine] CHECK CONSTRAINT [FK_StageLine_Project]
GO

ALTER TABLE [dbo].[StageLine]  WITH CHECK ADD  CONSTRAINT [FK_StageLine_Section] FOREIGN KEY([ProjectID], [SectionNum])
REFERENCES [dbo].[Section] ([ProjectID], [SectionNum])
ON DELETE SET DEFAULT
GO

ALTER TABLE [dbo].[StageLine] CHECK CONSTRAINT [FK_StageLine_Section]
GO

ALTER TABLE [dbo].[StageLine]  WITH CHECK ADD  CONSTRAINT [FK_StageLine_Stage] FOREIGN KEY([ProjectID], [SectionNum], [StageNum])
REFERENCES [dbo].[Stage] ([ProjectID], [SectionNum], [StageNum])
ON DELETE SET DEFAULT
GO

ALTER TABLE [dbo].[StageLine] CHECK CONSTRAINT [FK_StageLine_Stage]
GO


";
        }
    }
}
