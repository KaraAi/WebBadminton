USE [master]
GO
/****** Object:  Database [David_Badminton]    Script Date: 28/09/2024 11:37:34 CH ******/
CREATE DATABASE [David_Badminton]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'David_Badminton', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\David_Badminton.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'David_Badminton_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\David_Badminton_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [David_Badminton] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [David_Badminton].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [David_Badminton] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [David_Badminton] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [David_Badminton] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [David_Badminton] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [David_Badminton] SET ARITHABORT OFF 
GO
ALTER DATABASE [David_Badminton] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [David_Badminton] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [David_Badminton] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [David_Badminton] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [David_Badminton] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [David_Badminton] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [David_Badminton] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [David_Badminton] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [David_Badminton] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [David_Badminton] SET  DISABLE_BROKER 
GO
ALTER DATABASE [David_Badminton] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [David_Badminton] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [David_Badminton] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [David_Badminton] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [David_Badminton] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [David_Badminton] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [David_Badminton] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [David_Badminton] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [David_Badminton] SET  MULTI_USER 
GO
ALTER DATABASE [David_Badminton] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [David_Badminton] SET DB_CHAINING OFF 
GO
ALTER DATABASE [David_Badminton] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [David_Badminton] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [David_Badminton] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [David_Badminton] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [David_Badminton] SET QUERY_STORE = OFF
GO
USE [David_Badminton]
GO
/****** Object:  Table [dbo].[Coachs]    Script Date: 28/09/2024 11:37:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coachs](
	[CoachID] [int] IDENTITY(1,1) NOT NULL,
	[CoachName] [nvarchar](500) NOT NULL,
	[Images] [nvarchar](500) NULL,
	[FacilityID] [int] NOT NULL,
	[TypeUserID] [int] NOT NULL,
	[GenderID] [int] NOT NULL,
	[Email] [nvarchar](500) NOT NULL,
	[Birthday] [datetime] NOT NULL,
	[Password] [nvarchar](500) NOT NULL,
	[Phone] [nvarchar](500) NOT NULL,
	[StatusID] [int] NOT NULL,
	[Education] [int] NOT NULL,
	[Experience] [nvarchar](500) NOT NULL,
	[Level] [int] NOT NULL,
	[TaxCode] [nvarchar](500) NOT NULL,
	[BankName] [nvarchar](500) NOT NULL,
	[BankNumber] [nvarchar](500) NOT NULL,
	[WorkingStart] [datetime] NOT NULL,
	[HealthCondition] [nvarchar](500) NOT NULL,
	[CCCD] [nvarchar](500) NOT NULL,
	[PlaceOfOrigin] [nvarchar](500) NOT NULL,
	[PlaceOfResidence] [nvarchar](500) NOT NULL,
	[Salary] [numeric](18, 0) NULL,
	[MaritalStatus] [int] NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[NamePerson] [nvarchar](500) NOT NULL,
	[Relationship] [nvarchar](500) NOT NULL,
	[PhoneNumber] [nvarchar](500) NOT NULL,
	[UserCreated] [nvarchar](500) NOT NULL,
	[UserUpdated] [nvarchar](500) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_Coachs] PRIMARY KEY CLUSTERED 
(
	[CoachID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facilitys]    Script Date: 28/09/2024 11:37:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facilitys](
	[FacilityID] [int] IDENTITY(1,1) NOT NULL,
	[FacilityName] [nvarchar](500) NOT NULL,
	[Address] [nvarchar](500) NOT NULL,
	[Longtitude] [numeric](18, 2) NOT NULL,
	[Latitude] [numeric](18, 2) NOT NULL,
	[UserCreated] [nvarchar](500) NOT NULL,
	[UserUpdated] [nvarchar](500) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_Facilitys] PRIMARY KEY CLUSTERED 
(
	[FacilityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LearningProcess]    Script Date: 28/09/2024 11:37:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LearningProcess](
	[LearningProcessID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NOT NULL,
	[TimeStart] [datetime] NOT NULL,
	[TimeEnd] [datetime] NOT NULL,
	[CoachID] [int] NOT NULL,
	[LearningOutComes] [nvarchar](500) NOT NULL,
	[Comment] [nvarchar](500) NOT NULL,
	[Feedback] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_LearningProcess] PRIMARY KEY CLUSTERED 
(
	[LearningProcessID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModuleAccess]    Script Date: 28/09/2024 11:37:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModuleAccess](
	[ModuleID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
	[UserCreated] [nvarchar](500) NOT NULL,
	[UserUpdated] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_ModuleAccess] PRIMARY KEY CLUSTERED 
(
	[ModuleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RollCalls]    Script Date: 28/09/2024 11:37:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RollCalls](
	[RollCallID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NOT NULL,
	[CoachID] [int] NOT NULL,
	[isCheck] [int] NOT NULL,
	[StatusID] [int] NOT NULL,
	[UserCreated] [nvarchar](500) NOT NULL,
	[UserUpdated] [nvarchar](500) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_RollCall] PRIMARY KEY CLUSTERED 
(
	[RollCallID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 28/09/2024 11:37:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[FacilityID] [int] NOT NULL,
	[CoachID] [int] NOT NULL,
	[TimeID] [int] NOT NULL,
	[TypeUserID] [int] NOT NULL,
	[StudentName] [nvarchar](500) NOT NULL,
	[Images] [nvarchar](500) NOT NULL,
	[GenderID] [int] NULL,
	[Birthday] [datetime] NOT NULL,
	[Phone] [nvarchar](500) NOT NULL,
	[StatusID] [int] NOT NULL,
	[Address] [nvarchar](500) NOT NULL,
	[Password] [nvarchar](500) NOT NULL,
	[Level] [int] NULL,
	[Email] [nvarchar](500) NOT NULL,
	[Tuitions] [numeric](18, 0) NULL,
	[StudyStart] [datetime] NOT NULL,
	[HealthCondition] [nvarchar](500) NOT NULL,
	[Height] [nvarchar](500) NOT NULL,
	[Weight] [nvarchar](500) NOT NULL,
	[GuardianName] [nvarchar](500) NOT NULL,
	[Relationship] [nvarchar](500) NOT NULL,
	[GuardianPhone] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[UserCreated] [nvarchar](500) NOT NULL,
	[UserUpdated] [nvarchar](500) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Time]    Script Date: 28/09/2024 11:37:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Time](
	[TimeID] [int] IDENTITY(1,1) NOT NULL,
	[TimeName] [nvarchar](500) NOT NULL,
	[UserCreated] [nvarchar](500) NOT NULL,
	[UserUpdated] [nvarchar](500) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_Time] PRIMARY KEY CLUSTERED 
(
	[TimeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeUsers]    Script Date: 28/09/2024 11:37:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeUsers](
	[TypeUserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](500) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_TypeUsers] PRIMARY KEY CLUSTERED 
(
	[TypeUserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserModules]    Script Date: 28/09/2024 11:37:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserModules](
	[UserModuleID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[ModuleID] [numeric](18, 0) NOT NULL,
	[CoachID] [int] NOT NULL,
	[IsView] [int] NOT NULL,
	[IsInsert] [int] NOT NULL,
	[IsDelete] [int] NOT NULL,
	[IsUpdate] [int] NOT NULL,
 CONSTRAINT [PK_UserModules] PRIMARY KEY CLUSTERED 
(
	[UserModuleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Coachs] ON 

INSERT [dbo].[Coachs] ([CoachID], [CoachName], [Images], [FacilityID], [TypeUserID], [GenderID], [Email], [Birthday], [Password], [Phone], [StatusID], [Education], [Experience], [Level], [TaxCode], [BankName], [BankNumber], [WorkingStart], [HealthCondition], [CCCD], [PlaceOfOrigin], [PlaceOfResidence], [Salary], [MaritalStatus], [Description], [NamePerson], [Relationship], [PhoneNumber], [UserCreated], [UserUpdated], [DateCreated], [DateUpdated]) VALUES (1, N'Administrator', N'', 4, 2, 1, N'dangkhoaplatinum@gmail.com', CAST(N'2020-01-01T00:00:00.000' AS DateTime), N'E10ADC3949BA59ABBE56E057F20F883E', N'123456789', 0, 0, N'', 1, N'654356', N'VietCombank', N'1017371097', CAST(N'2024-09-19T00:00:00.000' AS DateTime), N'', N'072837161626', N'', N'', CAST(100000 AS Numeric(18, 0)), 1, N'', N'', N'', N'809138', N'Administrator', N'Administrator', CAST(N'2024-09-19T00:00:00.000' AS DateTime), CAST(N'2024-09-27T10:26:19.347' AS DateTime))
INSERT [dbo].[Coachs] ([CoachID], [CoachName], [Images], [FacilityID], [TypeUserID], [GenderID], [Email], [Birthday], [Password], [Phone], [StatusID], [Education], [Experience], [Level], [TaxCode], [BankName], [BankNumber], [WorkingStart], [HealthCondition], [CCCD], [PlaceOfOrigin], [PlaceOfResidence], [Salary], [MaritalStatus], [Description], [NamePerson], [Relationship], [PhoneNumber], [UserCreated], [UserUpdated], [DateCreated], [DateUpdated]) VALUES (2, N'Dư Anh Khoa', N'~/Images/upload/logo_25.png', 4, 1, 1, N'kara.nttn@gmail.com', CAST(N'2020-01-01T00:00:00.000' AS DateTime), N'E10ADC3949BA59ABBE56E057F20F883E', N'124124123', 0, 2, N'4 năm', 1, N'123123', N'VietComBank', N'1017291089', CAST(N'2022-01-01T00:00:00.000' AS DateTime), N'', N'123124123123', N'', N'', CAST(120231231 AS Numeric(18, 0)), 1, N'', N'', N'', N'123124123', N'Administrator', N'Administrator', CAST(N'2024-09-21T13:49:12.203' AS DateTime), CAST(N'2024-09-27T12:07:46.653' AS DateTime))
INSERT [dbo].[Coachs] ([CoachID], [CoachName], [Images], [FacilityID], [TypeUserID], [GenderID], [Email], [Birthday], [Password], [Phone], [StatusID], [Education], [Experience], [Level], [TaxCode], [BankName], [BankNumber], [WorkingStart], [HealthCondition], [CCCD], [PlaceOfOrigin], [PlaceOfResidence], [Salary], [MaritalStatus], [Description], [NamePerson], [Relationship], [PhoneNumber], [UserCreated], [UserUpdated], [DateCreated], [DateUpdated]) VALUES (6, N'Lâm Nhựt Đình', N'', 4, 1, 1, N'kara.nttn@gmail.com', CAST(N'2020-01-01T00:00:00.000' AS DateTime), N'E10ADC3949BA59ABBE56E057F20F883E', N'12345678911', 0, 2, N'4 năm', 2, N'123123', N'VietCombank', N'101918281', CAST(N'2022-01-01T00:00:00.000' AS DateTime), N'Tốtt', N'123123123', N'Bến tre', N'77 Sư Vạn Hạnh', CAST(2000000 AS Numeric(18, 0)), 0, N'', N'', N'', N'1231231', N'Administrator', N'Administrator', CAST(N'2024-09-22T13:59:45.440' AS DateTime), CAST(N'2024-09-27T14:24:26.953' AS DateTime))
SET IDENTITY_INSERT [dbo].[Coachs] OFF
GO
SET IDENTITY_INSERT [dbo].[Facilitys] ON 

INSERT [dbo].[Facilitys] ([FacilityID], [FacilityName], [Address], [Longtitude], [Latitude], [UserCreated], [UserUpdated], [DateCreated], [DateUpdated]) VALUES (2, N'Sân cầu lông Đức Kim', N'Hẻm 02 Hẻm 338 Nguyễn Văn Quá, Đông Hưng Thuận, Quận 12, Hồ Chí Minh', CAST(107.00 AS Numeric(18, 2)), CAST(11.00 AS Numeric(18, 2)), N'Administrator', N'Administrator', CAST(N'2024-09-20T00:00:00.000' AS DateTime), CAST(N'2024-09-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Facilitys] ([FacilityID], [FacilityName], [Address], [Longtitude], [Latitude], [UserCreated], [UserUpdated], [DateCreated], [DateUpdated]) VALUES (4, N'Sân cầu lông Quang Vinh', N'1/109 Đ. Đông Hưng Thuận 10B, P, Quận 12, Hồ Chí Minh', CAST(107.00 AS Numeric(18, 2)), CAST(11.00 AS Numeric(18, 2)), N'Administrator', N'Administrator', CAST(N'2024-09-20T17:58:58.700' AS DateTime), CAST(N'2024-09-27T22:36:28.010' AS DateTime))
INSERT [dbo].[Facilitys] ([FacilityID], [FacilityName], [Address], [Longtitude], [Latitude], [UserCreated], [UserUpdated], [DateCreated], [DateUpdated]) VALUES (11, N'Sân cầu lông Minh Tâm', N'412/17 Đ. Nguyễn Văn Quá, P, Quận 12, Hồ Chí Minh', CAST(108.00 AS Numeric(18, 2)), CAST(12.00 AS Numeric(18, 2)), N'Administrator', N'Administrator', CAST(N'2024-09-26T11:47:32.387' AS DateTime), CAST(N'2024-09-27T22:36:40.707' AS DateTime))
SET IDENTITY_INSERT [dbo].[Facilitys] OFF
GO
SET IDENTITY_INSERT [dbo].[ModuleAccess] ON 

INSERT [dbo].[ModuleAccess] ([ModuleID], [Name], [Description], [DateCreated], [DateUpdated], [UserCreated], [UserUpdated]) VALUES (CAST(1 AS Numeric(18, 0)), N'Bộ Quyền', N'Xem, Thêm, Xoá , Sửa', CAST(N'2024-09-22T14:50:14.103' AS DateTime), CAST(N'2024-09-22T14:50:14.103' AS DateTime), N'Administrator', N'Administrator')
INSERT [dbo].[ModuleAccess] ([ModuleID], [Name], [Description], [DateCreated], [DateUpdated], [UserCreated], [UserUpdated]) VALUES (CAST(2 AS Numeric(18, 0)), N'Ca học', N'Xem, Thêm, Xoá , Sửa', CAST(N'2024-09-22T14:50:32.163' AS DateTime), CAST(N'2024-09-22T14:50:32.163' AS DateTime), N'Administrator', N'Administrator')
INSERT [dbo].[ModuleAccess] ([ModuleID], [Name], [Description], [DateCreated], [DateUpdated], [UserCreated], [UserUpdated]) VALUES (CAST(3 AS Numeric(18, 0)), N'Cơ sở', N'Xem, Thêm , Xoá , Sửa', CAST(N'2024-09-22T14:50:45.053' AS DateTime), CAST(N'2024-09-22T14:50:45.053' AS DateTime), N'Administrator', N'Administrator')
INSERT [dbo].[ModuleAccess] ([ModuleID], [Name], [Description], [DateCreated], [DateUpdated], [UserCreated], [UserUpdated]) VALUES (CAST(4 AS Numeric(18, 0)), N'Huấn Luyện Viên', N'Xem, Thêm, Xoá , Sửa', CAST(N'2024-09-22T14:50:59.273' AS DateTime), CAST(N'2024-09-22T14:50:59.273' AS DateTime), N'Administrator', N'Administrator')
INSERT [dbo].[ModuleAccess] ([ModuleID], [Name], [Description], [DateCreated], [DateUpdated], [UserCreated], [UserUpdated]) VALUES (CAST(5 AS Numeric(18, 0)), N'Học Viên', N'Xem, Thêm, Xoá , Sửa', CAST(N'2024-09-22T14:57:17.577' AS DateTime), CAST(N'2024-09-22T14:57:17.577' AS DateTime), N'Administrator', N'Administrator')
SET IDENTITY_INSERT [dbo].[ModuleAccess] OFF
GO
SET IDENTITY_INSERT [dbo].[RollCalls] ON 

INSERT [dbo].[RollCalls] ([RollCallID], [StudentID], [CoachID], [isCheck], [StatusID], [UserCreated], [UserUpdated], [DateCreated], [DateUpdated]) VALUES (9, 16, 6, 1, 1, N'Administrator', N'Administrator', CAST(N'2024-09-26T15:18:24.523' AS DateTime), CAST(N'2024-09-26T15:18:24.523' AS DateTime))
INSERT [dbo].[RollCalls] ([RollCallID], [StudentID], [CoachID], [isCheck], [StatusID], [UserCreated], [UserUpdated], [DateCreated], [DateUpdated]) VALUES (10, 16, 6, 0, 1, N'Administrator', N'Administrator', CAST(N'2024-09-26T15:20:15.427' AS DateTime), CAST(N'2024-09-26T15:20:15.427' AS DateTime))
INSERT [dbo].[RollCalls] ([RollCallID], [StudentID], [CoachID], [isCheck], [StatusID], [UserCreated], [UserUpdated], [DateCreated], [DateUpdated]) VALUES (11, 16, 6, 1, 1, N'Administrator', N'Administrator', CAST(N'2024-09-26T15:20:29.200' AS DateTime), CAST(N'2024-09-26T15:20:29.200' AS DateTime))
INSERT [dbo].[RollCalls] ([RollCallID], [StudentID], [CoachID], [isCheck], [StatusID], [UserCreated], [UserUpdated], [DateCreated], [DateUpdated]) VALUES (12, 16, 6, 1, 1, N'Administrator', N'Administrator', CAST(N'2024-09-26T15:26:01.517' AS DateTime), CAST(N'2024-09-26T15:26:01.517' AS DateTime))
INSERT [dbo].[RollCalls] ([RollCallID], [StudentID], [CoachID], [isCheck], [StatusID], [UserCreated], [UserUpdated], [DateCreated], [DateUpdated]) VALUES (13, 18, 2, 1, 1, N'Administrator', N'Administrator', CAST(N'2024-09-27T13:34:47.363' AS DateTime), CAST(N'2024-09-27T13:34:47.363' AS DateTime))
INSERT [dbo].[RollCalls] ([RollCallID], [StudentID], [CoachID], [isCheck], [StatusID], [UserCreated], [UserUpdated], [DateCreated], [DateUpdated]) VALUES (14, 19, 2, 1, 1, N'Administrator', N'Administrator', CAST(N'2024-09-27T14:32:36.220' AS DateTime), CAST(N'2024-09-27T14:32:36.220' AS DateTime))
SET IDENTITY_INSERT [dbo].[RollCalls] OFF
GO
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentID], [FacilityID], [CoachID], [TimeID], [TypeUserID], [StudentName], [Images], [GenderID], [Birthday], [Phone], [StatusID], [Address], [Password], [Level], [Email], [Tuitions], [StudyStart], [HealthCondition], [Height], [Weight], [GuardianName], [Relationship], [GuardianPhone], [Description], [UserCreated], [UserUpdated], [DateCreated], [DateUpdated]) VALUES (16, 4, 6, 5, 3, N'Phạm Đình Trung', N'', 1, CAST(N'2002-11-19T00:00:00.000' AS DateTime), N'1234567891', 3, N'77 Sư vạn hạnh', N'E10ADC3949BA59ABBE56E057F20F883E', 4, N'kara.nttn@gmail.com', CAST(15000000 AS Numeric(18, 0)), CAST(N'2022-09-20T00:00:00.000' AS DateTime), N'da', N'23', N'32', N'da', N'', N'12312411241', N'da', N'Administrator', N'Administrator', CAST(N'2024-09-25T11:42:12.210' AS DateTime), CAST(N'2024-09-25T11:42:12.210' AS DateTime))
INSERT [dbo].[Students] ([StudentID], [FacilityID], [CoachID], [TimeID], [TypeUserID], [StudentName], [Images], [GenderID], [Birthday], [Phone], [StatusID], [Address], [Password], [Level], [Email], [Tuitions], [StudyStart], [HealthCondition], [Height], [Weight], [GuardianName], [Relationship], [GuardianPhone], [Description], [UserCreated], [UserUpdated], [DateCreated], [DateUpdated]) VALUES (18, 11, 2, 8, 3, N'Đỗ Tuấn Đình', N'~/Images/upload/logo_30.png', 1, CAST(N'2020-08-11T00:00:00.000' AS DateTime), N'081237123', 3, N'77 Sư vạn hạnh', N'25F9E794323B453885F5181F1B624D0B', 4, N'kara.nttn@gmail.com', CAST(15000000 AS Numeric(18, 0)), CAST(N'2022-09-20T00:00:00.000' AS DateTime), N'', N'', N'', N'da', N'', N'12312411241', N'', N'Administrator', N'Administrator', CAST(N'2024-09-27T13:29:23.170' AS DateTime), CAST(N'2024-09-27T14:16:30.740' AS DateTime))
INSERT [dbo].[Students] ([StudentID], [FacilityID], [CoachID], [TimeID], [TypeUserID], [StudentName], [Images], [GenderID], [Birthday], [Phone], [StatusID], [Address], [Password], [Level], [Email], [Tuitions], [StudyStart], [HealthCondition], [Height], [Weight], [GuardianName], [Relationship], [GuardianPhone], [Description], [UserCreated], [UserUpdated], [DateCreated], [DateUpdated]) VALUES (19, 2, 2, 3, 3, N'Phạm Long', N'', 1, CAST(N'2012-09-27T00:00:00.000' AS DateTime), N'1234567891', 3, N'77 Sư vạn hạnh', N'E10ADC3949BA59ABBE56E057F20F883E', 4, N'kara.nttn@gmail.com', CAST(15000000 AS Numeric(18, 0)), CAST(N'2020-09-27T00:00:00.000' AS DateTime), N'', N'', N'', N'', N'', N'', N'', N'Administrator', N'Administrator', CAST(N'2024-09-27T14:31:50.370' AS DateTime), CAST(N'2024-09-27T14:32:03.583' AS DateTime))
SET IDENTITY_INSERT [dbo].[Students] OFF
GO
SET IDENTITY_INSERT [dbo].[Time] ON 

INSERT [dbo].[Time] ([TimeID], [TimeName], [UserCreated], [UserUpdated], [DateCreated], [DateUpdated]) VALUES (1, N'Ca 1: 2-4-6 - 18H', N'Administrator', N'Administrator', CAST(N'2024-09-20T20:33:09.710' AS DateTime), CAST(N'2024-09-20T20:52:54.753' AS DateTime))
INSERT [dbo].[Time] ([TimeID], [TimeName], [UserCreated], [UserUpdated], [DateCreated], [DateUpdated]) VALUES (2, N'Ca 2: 2-4-6 - 20H', N'Administrator', N'Administrator', CAST(N'2024-09-20T20:33:24.610' AS DateTime), CAST(N'2024-09-20T20:33:24.610' AS DateTime))
INSERT [dbo].[Time] ([TimeID], [TimeName], [UserCreated], [UserUpdated], [DateCreated], [DateUpdated]) VALUES (3, N'Ca 1: 3-5-7 - 18H', N'Administrator', N'Administrator', CAST(N'2024-09-20T20:33:29.623' AS DateTime), CAST(N'2024-09-20T20:33:29.623' AS DateTime))
INSERT [dbo].[Time] ([TimeID], [TimeName], [UserCreated], [UserUpdated], [DateCreated], [DateUpdated]) VALUES (4, N'Ca 2: 3-5-7 -20H', N'Administrator', N'Administrator', CAST(N'2024-09-20T20:33:33.310' AS DateTime), CAST(N'2024-09-20T20:33:33.310' AS DateTime))
INSERT [dbo].[Time] ([TimeID], [TimeName], [UserCreated], [UserUpdated], [DateCreated], [DateUpdated]) VALUES (5, N'Ca 1: 7-CN - 6H30', N'Administrator', N'Administrator', CAST(N'2024-09-20T20:33:37.693' AS DateTime), CAST(N'2024-09-20T20:33:37.693' AS DateTime))
INSERT [dbo].[Time] ([TimeID], [TimeName], [UserCreated], [UserUpdated], [DateCreated], [DateUpdated]) VALUES (6, N'Ca 2: 7-CN - 8H', N'Administrator', N'Administrator', CAST(N'2024-09-20T20:33:41.247' AS DateTime), CAST(N'2024-09-20T20:33:41.247' AS DateTime))
INSERT [dbo].[Time] ([TimeID], [TimeName], [UserCreated], [UserUpdated], [DateCreated], [DateUpdated]) VALUES (7, N'Ca 3: 7-CN - 10H', N'Administrator', N'Administrator', CAST(N'2024-09-20T20:33:44.853' AS DateTime), CAST(N'2024-09-20T20:33:44.853' AS DateTime))
INSERT [dbo].[Time] ([TimeID], [TimeName], [UserCreated], [UserUpdated], [DateCreated], [DateUpdated]) VALUES (8, N'Ca 4: 7-CN - 14H', N'Administrator', N'Administrator', CAST(N'2024-09-20T20:33:48.023' AS DateTime), CAST(N'2024-09-24T18:46:00.337' AS DateTime))
INSERT [dbo].[Time] ([TimeID], [TimeName], [UserCreated], [UserUpdated], [DateCreated], [DateUpdated]) VALUES (9, N'Ca 5: 7-CN - 16H', N'Administrator', N'Lâm Nhựt Đình', CAST(N'2024-09-20T20:33:51.150' AS DateTime), CAST(N'2024-09-22T15:18:56.667' AS DateTime))
INSERT [dbo].[Time] ([TimeID], [TimeName], [UserCreated], [UserUpdated], [DateCreated], [DateUpdated]) VALUES (14, N'Ca 6: 7-CN -18H', N'Administrator', N'Administrator', CAST(N'2024-09-24T22:04:20.407' AS DateTime), CAST(N'2024-09-24T22:04:20.407' AS DateTime))
SET IDENTITY_INSERT [dbo].[Time] OFF
GO
SET IDENTITY_INSERT [dbo].[TypeUsers] ON 

INSERT [dbo].[TypeUsers] ([TypeUserID], [UserName], [Description], [DateCreated], [DateUpdated]) VALUES (1, N'HLV', N'HLV', CAST(N'2024-09-19T00:00:00.000' AS DateTime), CAST(N'2024-09-19T00:00:00.000' AS DateTime))
INSERT [dbo].[TypeUsers] ([TypeUserID], [UserName], [Description], [DateCreated], [DateUpdated]) VALUES (2, N'Administrator', N'Administrator', CAST(N'2024-09-19T00:00:00.000' AS DateTime), CAST(N'2024-09-19T00:00:00.000' AS DateTime))
INSERT [dbo].[TypeUsers] ([TypeUserID], [UserName], [Description], [DateCreated], [DateUpdated]) VALUES (3, N'HocVien', N'HocVien', CAST(N'2024-09-19T00:00:00.000' AS DateTime), CAST(N'2024-09-19T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[TypeUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[UserModules] ON 

INSERT [dbo].[UserModules] ([UserModuleID], [ModuleID], [CoachID], [IsView], [IsInsert], [IsDelete], [IsUpdate]) VALUES (CAST(1 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), 1, 0, 0, 0, 0)
INSERT [dbo].[UserModules] ([UserModuleID], [ModuleID], [CoachID], [IsView], [IsInsert], [IsDelete], [IsUpdate]) VALUES (CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), 1, 1, 1, 1, 1)
INSERT [dbo].[UserModules] ([UserModuleID], [ModuleID], [CoachID], [IsView], [IsInsert], [IsDelete], [IsUpdate]) VALUES (CAST(3 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), 1, 1, 1, 1, 1)
INSERT [dbo].[UserModules] ([UserModuleID], [ModuleID], [CoachID], [IsView], [IsInsert], [IsDelete], [IsUpdate]) VALUES (CAST(4 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), 1, 1, 1, 1, 1)
INSERT [dbo].[UserModules] ([UserModuleID], [ModuleID], [CoachID], [IsView], [IsInsert], [IsDelete], [IsUpdate]) VALUES (CAST(5 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), 1, 1, 1, 1, 1)
INSERT [dbo].[UserModules] ([UserModuleID], [ModuleID], [CoachID], [IsView], [IsInsert], [IsDelete], [IsUpdate]) VALUES (CAST(6 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), 2, 0, 0, 0, 0)
INSERT [dbo].[UserModules] ([UserModuleID], [ModuleID], [CoachID], [IsView], [IsInsert], [IsDelete], [IsUpdate]) VALUES (CAST(7 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), 2, 1, 0, 0, 0)
INSERT [dbo].[UserModules] ([UserModuleID], [ModuleID], [CoachID], [IsView], [IsInsert], [IsDelete], [IsUpdate]) VALUES (CAST(8 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), 2, 1, 0, 0, 0)
INSERT [dbo].[UserModules] ([UserModuleID], [ModuleID], [CoachID], [IsView], [IsInsert], [IsDelete], [IsUpdate]) VALUES (CAST(9 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), 2, 1, 0, 1, 1)
INSERT [dbo].[UserModules] ([UserModuleID], [ModuleID], [CoachID], [IsView], [IsInsert], [IsDelete], [IsUpdate]) VALUES (CAST(10 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), 2, 1, 0, 1, 1)
INSERT [dbo].[UserModules] ([UserModuleID], [ModuleID], [CoachID], [IsView], [IsInsert], [IsDelete], [IsUpdate]) VALUES (CAST(11 AS Numeric(18, 0)), CAST(1 AS Numeric(18, 0)), 6, 0, 0, 0, 0)
INSERT [dbo].[UserModules] ([UserModuleID], [ModuleID], [CoachID], [IsView], [IsInsert], [IsDelete], [IsUpdate]) VALUES (CAST(12 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), 6, 0, 0, 0, 0)
INSERT [dbo].[UserModules] ([UserModuleID], [ModuleID], [CoachID], [IsView], [IsInsert], [IsDelete], [IsUpdate]) VALUES (CAST(13 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), 6, 0, 0, 0, 0)
INSERT [dbo].[UserModules] ([UserModuleID], [ModuleID], [CoachID], [IsView], [IsInsert], [IsDelete], [IsUpdate]) VALUES (CAST(14 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), 6, 1, 0, 0, 0)
INSERT [dbo].[UserModules] ([UserModuleID], [ModuleID], [CoachID], [IsView], [IsInsert], [IsDelete], [IsUpdate]) VALUES (CAST(15 AS Numeric(18, 0)), CAST(5 AS Numeric(18, 0)), 6, 1, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[UserModules] OFF
GO
ALTER TABLE [dbo].[Coachs]  WITH CHECK ADD  CONSTRAINT [FK_Coachs_Facilitys] FOREIGN KEY([FacilityID])
REFERENCES [dbo].[Facilitys] ([FacilityID])
GO
ALTER TABLE [dbo].[Coachs] CHECK CONSTRAINT [FK_Coachs_Facilitys]
GO
ALTER TABLE [dbo].[Coachs]  WITH CHECK ADD  CONSTRAINT [FK_Coachs_TypeUsers] FOREIGN KEY([TypeUserID])
REFERENCES [dbo].[TypeUsers] ([TypeUserID])
GO
ALTER TABLE [dbo].[Coachs] CHECK CONSTRAINT [FK_Coachs_TypeUsers]
GO
ALTER TABLE [dbo].[RollCalls]  WITH CHECK ADD  CONSTRAINT [FK_RollCall_Students] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([StudentID])
GO
ALTER TABLE [dbo].[RollCalls] CHECK CONSTRAINT [FK_RollCall_Students]
GO
ALTER TABLE [dbo].[RollCalls]  WITH CHECK ADD  CONSTRAINT [FK_RollCalls_Coachs] FOREIGN KEY([CoachID])
REFERENCES [dbo].[Coachs] ([CoachID])
GO
ALTER TABLE [dbo].[RollCalls] CHECK CONSTRAINT [FK_RollCalls_Coachs]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Time] FOREIGN KEY([TimeID])
REFERENCES [dbo].[Time] ([TimeID])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Time]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_TypeUsers] FOREIGN KEY([TypeUserID])
REFERENCES [dbo].[TypeUsers] ([TypeUserID])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_TypeUsers]
GO
ALTER TABLE [dbo].[UserModules]  WITH CHECK ADD  CONSTRAINT [FK_UserModules_Coachs] FOREIGN KEY([CoachID])
REFERENCES [dbo].[Coachs] ([CoachID])
GO
ALTER TABLE [dbo].[UserModules] CHECK CONSTRAINT [FK_UserModules_Coachs]
GO
ALTER TABLE [dbo].[UserModules]  WITH CHECK ADD  CONSTRAINT [FK_UserModules_ModuleAccess] FOREIGN KEY([ModuleID])
REFERENCES [dbo].[ModuleAccess] ([ModuleID])
GO
ALTER TABLE [dbo].[UserModules] CHECK CONSTRAINT [FK_UserModules_ModuleAccess]
GO
/****** Object:  StoredProcedure [dbo].[getCheckedStudentsByDateAndCoach]    Script Date: 28/09/2024 11:37:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getCheckedStudentsByDateAndCoach]
	@dateSelected DATE = '2024-09-26' ,        
    @coachID INT = 6
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SELECT 
		 
		    rc.RollCallID,          
        rc.StudentID,          
        st.StudentName,       
        rc.CoachID,             
        co.CoachName,           
        rc.isCheck,             
        rc.StatusID,   
		rc.UserCreated,
        rc.DateCreated          
    FROM RollCalls rc
    INNER JOIN Students st ON rc.StudentID = st.StudentID
    INNER JOIN Coachs co ON rc.CoachID = co.CoachID
    WHERE 
        rc.isCheck = 1                         
        AND rc.CoachID = @coachID              
        AND CAST(rc.DateCreated AS DATE) = @dateSelected  
    ORDER BY rc.DateCreated DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[getCountRolCall]    Script Date: 28/09/2024 11:37:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getCountRolCall]
	@dateSelected DATE = '2024-09-26',
	@dateEND date ='2024-09-28'
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SELECT 
		 
		       
        rc.StudentID,          
        st.StudentName,       
		Count(rc.RollCallID) as totalClass
    FROM RollCalls rc
     inner JOIN Students st ON rc.StudentID = st.StudentID
    WHERE 
        rc.isCheck = 1                         
        AND CAST(rc.DateCreated As date) >= @dateSelected           
        AND CAST(rc.DateCreated AS DATE) <=  @dateEND
    Group by
	rc.StudentID,st.StudentName
END
GO
/****** Object:  StoredProcedure [dbo].[getModuleAccessUser]    Script Date: 28/09/2024 11:37:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getModuleAccessUser]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SELECT 
		  0 as 'UserMoudleID'
		  ,ModuleID
		  ,Name
		  ,Description
		  ,0 as 'IsView'
		  ,0 as 'IsInsert'
		  ,0 as 'IsDelete'
		  ,0 as 'IsUpdate'
		  ,DateCreated
		  ,DateUpdated
		  ,UserCreated
		  ,UserUpdated
	FROM [dbo].[ModuleAccess]

END
GO
/****** Object:  StoredProcedure [dbo].[getStudentByCoachID]    Script Date: 28/09/2024 11:37:35 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getStudentByCoachID]
	-- Add the parameters for the stored procedure here
	@facilityid int = 0,
	@coachid int = 0,
	@timeid int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SELECT 
		 
		  st.CoachID
		  ,co.CoachName
		  ,st.StudentID
		  ,st.StudentName
		  ,te.TimeID
		  ,te.TimeName
		  ,fa.FacilityID
		  ,fa.FacilityName
		  ,0 as 'isCheck'
	FROM [dbo].[Coachs] co inner join Students st on co.CoachID = st.CoachID
						   inner join Time te on te.TimeID = st.TimeID
						   inner join Facilitys fa on st.FacilityID = fa.FacilityID
				where (@coachid = 0 or co.CoachID = @coachid) and (@timeid = 0 or te.TimeID = @timeid) and (@facilityid = 0 or fa.FacilityID = @facilityid)		
END		
GO
USE [master]
GO
ALTER DATABASE [David_Badminton] SET  READ_WRITE 
GO
