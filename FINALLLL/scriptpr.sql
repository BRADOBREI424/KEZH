USE [master]
GO
/****** Object:  Database [ProizvodPrektika]    Script Date: 02.06.2021 10:19:31 ******/
CREATE DATABASE [ProizvodPrektika]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProizvodPrektika', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ProizvodPrektika.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProizvodPrektika_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ProizvodPrektika_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProizvodPrektika] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProizvodPrektika].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProizvodPrektika] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProizvodPrektika] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProizvodPrektika] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProizvodPrektika] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProizvodPrektika] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProizvodPrektika] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProizvodPrektika] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProizvodPrektika] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProizvodPrektika] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProizvodPrektika] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProizvodPrektika] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProizvodPrektika] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProizvodPrektika] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProizvodPrektika] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProizvodPrektika] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProizvodPrektika] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProizvodPrektika] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProizvodPrektika] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProizvodPrektika] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProizvodPrektika] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProizvodPrektika] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProizvodPrektika] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProizvodPrektika] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProizvodPrektika] SET  MULTI_USER 
GO
ALTER DATABASE [ProizvodPrektika] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProizvodPrektika] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProizvodPrektika] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProizvodPrektika] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProizvodPrektika] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProizvodPrektika] SET QUERY_STORE = OFF
GO
USE [ProizvodPrektika]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[IdGroup] [int] IDENTITY(1,1) NOT NULL,
	[NameGroup] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[IdGroup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[IdStudent] [int] IDENTITY(1,1) NOT NULL,
	[IdPassport] [int] NOT NULL,
	[IdGroup] [int] NOT NULL,
	[SNILS] [nvarchar](15) NOT NULL,
	[INN] [float] NOT NULL,
	[IdAddress] [int] NOT NULL,
	[NumberPhone] [nvarchar](20) NOT NULL,
	[IdFamily] [int] NOT NULL,
	[IdFamilyStatus] [int] NOT NULL,
	[Email] [nvarchar](45) NOT NULL,
	[IdMom] [int] NULL,
	[IdDad] [int] NULL,
	[HospitalPolice] [float] NOT NULL,
	[IdStatus] [int] NOT NULL,
	[IdImage] [int] NULL,
	[IdTemporaryRegistration] [int] NULL,
	[IdMomGuradian] [int] NULL,
	[IdDadGuardina] [int] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[IdStudent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[IdCity] [int] IDENTITY(1,1) NOT NULL,
	[NameCity] [nvarchar](60) NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[IdCity] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Street]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Street](
	[IdStreet] [int] IDENTITY(1,1) NOT NULL,
	[NameStreet] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Street] PRIMARY KEY CLUSTERED 
(
	[IdStreet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TemporaryRegistration]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TemporaryRegistration](
	[IdTemporaryRegistration] [int] IDENTITY(1,1) NOT NULL,
	[Postcode] [int] NOT NULL,
	[IdCity] [int] NOT NULL,
	[IdStreet] [int] NOT NULL,
	[House] [nvarchar](10) NOT NULL,
	[Enclosure] [nvarchar](10) NOT NULL,
	[Appartment] [int] NOT NULL,
 CONSTRAINT [PK_TemporaryRegistration] PRIMARY KEY CLUSTERED 
(
	[IdTemporaryRegistration] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration](
	[IdRegistration] [int] IDENTITY(1,1) NOT NULL,
	[Postcode] [int] NOT NULL,
	[IdCity] [int] NOT NULL,
	[IdStreet] [int] NOT NULL,
	[House] [nvarchar](10) NOT NULL,
	[Enclosure] [nvarchar](10) NOT NULL,
	[Appartment] [int] NOT NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[IdRegistration] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[IdAddress] [int] IDENTITY(1,1) NOT NULL,
	[Postcode] [int] NOT NULL,
	[IdCity] [int] NOT NULL,
	[IdStreet] [int] NOT NULL,
	[House] [nvarchar](10) NOT NULL,
	[Enclosure] [nvarchar](10) NOT NULL,
	[Appartment] [int] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[IdAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[IdImage] [int] NOT NULL,
	[Title] [nvarchar](10) NOT NULL,
	[Photo] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[IdImage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passport]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passport](
	[IdPassport] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](55) NOT NULL,
	[FirstName] [nvarchar](55) NOT NULL,
	[MiddleName] [nvarchar](55) NULL,
	[Series] [int] NOT NULL,
	[Number] [int] NOT NULL,
	[IdIssuedByWhom] [int] NOT NULL,
	[DateOfIssue] [date] NOT NULL,
	[CodeDivision] [nvarchar](7) NOT NULL,
	[IdGender] [int] NOT NULL,
	[DateOfBorn] [date] NOT NULL,
	[IdPlaceOfBorn] [int] NOT NULL,
	[FamilyPosition] [bit] NOT NULL,
	[IdRegistration] [int] NOT NULL,
 CONSTRAINT [PK_Passport] PRIMARY KEY CLUSTERED 
(
	[IdPassport] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mom]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mom](
	[IdMom] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](60) NOT NULL,
	[FirstName] [nvarchar](60) NOT NULL,
	[MiddleName] [nvarchar](60) NULL,
	[NumberPhone] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Mom] PRIMARY KEY CLUSTERED 
(
	[IdMom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GuardianMom]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GuardianMom](
	[IdGuardianMom] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](60) NOT NULL,
	[FirstName] [nvarchar](60) NOT NULL,
	[MiddleName] [nvarchar](60) NULL,
	[NumberPhone] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_GuardianMom] PRIMARY KEY CLUSTERED 
(
	[IdGuardianMom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dad]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dad](
	[IdDad] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](60) NOT NULL,
	[FirstName] [nvarchar](60) NOT NULL,
	[MiddleName] [nvarchar](60) NULL,
	[NumberPhone] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Dad] PRIMARY KEY CLUSTERED 
(
	[IdDad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GuardianDad]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GuardianDad](
	[IdGuardianDad] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](60) NOT NULL,
	[FirstName] [nvarchar](60) NOT NULL,
	[MiddleName] [nvarchar](60) NULL,
	[NumberPhone] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_GuardianDad] PRIMARY KEY CLUSTERED 
(
	[IdGuardianDad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Family]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Family](
	[IdFamily] [int] IDENTITY(1,1) NOT NULL,
	[NameFamily] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Family] PRIMARY KEY CLUSTERED 
(
	[IdFamily] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FamilyStatus]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamilyStatus](
	[IdFamilyStatus] [int] IDENTITY(1,1) NOT NULL,
	[NameFamilyStatus] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_FamilyStatus] PRIMARY KEY CLUSTERED 
(
	[IdFamilyStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[IdStatus] [int] IDENTITY(1,1) NOT NULL,
	[NameStatus] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[IdStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IssuedByWhom]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IssuedByWhom](
	[IdAuthority] [int] IDENTITY(1,1) NOT NULL,
	[NameAuthority] [int] NOT NULL,
 CONSTRAINT [PK_IssuedByWhom] PRIMARY KEY CLUSTERED 
(
	[IdAuthority] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[IdGender] [int] IDENTITY(1,1) NOT NULL,
	[NameGender] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[IdGender] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlaceOfBorn]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaceOfBorn](
	[IdPlaceOfBorn] [int] IDENTITY(1,1) NOT NULL,
	[NamePlaceOfBorn] [nvarchar](60) NOT NULL,
 CONSTRAINT [PK_PlaceOfBorn] PRIMARY KEY CLUSTERED 
(
	[IdPlaceOfBorn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ViewStudent]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewStudent]
AS
SELECT        dbo.Passport.LastName, dbo.Passport.FirstName, dbo.Passport.MiddleName, dbo.Passport.Series, dbo.Passport.Number, dbo.IssuedByWhom.NameAuthority, dbo.Passport.DateOfIssue, dbo.Passport.CodeDivision, 
                         dbo.Gender.NameGender, dbo.Passport.DateOfBorn, dbo.PlaceOfBorn.NamePlaceOfBorn, dbo.Passport.FamilyPosition, dbo.Registration.Postcode AS RegPostcode, City_1.NameCity AS RegCity, 
                         dbo.Street.NameStreet AS RegStreet, dbo.Registration.House AS RegHouse, dbo.Registration.Enclosure AS RegEnclosure, dbo.Registration.Appartment AS RegAppartment, dbo.[Group].NameGroup, Student_1.SNILS, 
                         Student_1.INN, dbo.Address.Postcode AS RealPostcode, dbo.City.NameCity AS RealCity, Street_1.NameStreet AS RealStreet, dbo.Address.House AS RealHouse, dbo.Address.Enclosure AS RealEnclosure, 
                         dbo.Address.Appartment AS RealAppartment, Student_1.NumberPhone, dbo.Family.NameFamily, dbo.FamilyStatus.NameFamilyStatus, Student_1.Email, dbo.Mom.LastName AS MomLastName, 
                         dbo.Mom.FirstName AS MomFirstName, dbo.Mom.MiddleName AS MomMiddleName, dbo.Mom.NumberPhone AS MomNumberPhone, dbo.Dad.LastName AS DadLastName, dbo.Dad.FirstName AS DadFirstName, 
                         dbo.Dad.MiddleName AS DadMiddleName, dbo.Dad.NumberPhone AS DadNumberPhone, Student_1.HospitalPolice, dbo.Status.NameStatus, dbo.Image.Title, dbo.Image.Photo, 
                         dbo.TemporaryRegistration.Postcode AS TempPostcode, City_2.NameCity AS TempCity, Street_2.NameStreet AS TempStreet, dbo.TemporaryRegistration.House AS TempHouse, 
                         dbo.TemporaryRegistration.Enclosure AS TempEnclosure, dbo.TemporaryRegistration.Appartment AS TempAppartment, dbo.GuardianMom.LastName AS GuardMomLastName, 
                         dbo.GuardianMom.FirstName AS GuardMomFirstName, dbo.GuardianMom.MiddleName AS GuardMomMiddleName, dbo.GuardianMom.NumberPhone AS GuardMomNumberPhone, 
                         dbo.GuardianDad.LastName AS GuardDadLastName, dbo.GuardianDad.FirstName AS GuardDadFirstName, dbo.GuardianDad.MiddleName AS GuardDadMiddleName, 
                         dbo.GuardianDad.NumberPhone AS GuardDadNumberPhone
FROM            dbo.City INNER JOIN
                         dbo.City AS City_2 INNER JOIN
                         dbo.Address INNER JOIN
                         dbo.City AS City_1 ON dbo.Address.IdCity = City_1.IdCity INNER JOIN
                         dbo.Registration ON City_1.IdCity = dbo.Registration.IdCity INNER JOIN
                         dbo.Street ON dbo.Registration.IdStreet = dbo.Street.IdStreet ON City_2.IdCity = dbo.Registration.IdCity INNER JOIN
                         dbo.Street AS Street_1 ON dbo.Registration.IdStreet = Street_1.IdStreet ON dbo.City.IdCity = dbo.Registration.IdCity INNER JOIN
                         dbo.Street AS Street_2 ON dbo.Registration.IdStreet = Street_2.IdStreet CROSS JOIN
                         dbo.Family CROSS JOIN
                         dbo.Student AS Student_1 INNER JOIN
                         dbo.TemporaryRegistration ON Student_1.IdTemporaryRegistration = dbo.TemporaryRegistration.IdTemporaryRegistration CROSS JOIN
                         dbo.[Group] CROSS JOIN
                         dbo.Dad CROSS JOIN
                         dbo.Status CROSS JOIN
                         dbo.Passport INNER JOIN
                         dbo.Gender ON dbo.Passport.IdGender = dbo.Gender.IdGender INNER JOIN
                         dbo.PlaceOfBorn ON dbo.Passport.IdPlaceOfBorn = dbo.PlaceOfBorn.IdPlaceOfBorn CROSS JOIN
                         dbo.GuardianDad CROSS JOIN
                         dbo.GuardianMom CROSS JOIN
                         dbo.Image CROSS JOIN
                         dbo.IssuedByWhom CROSS JOIN
                         dbo.FamilyStatus CROSS JOIN
                         dbo.Mom
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[IdAttendance] [int] IDENTITY(1,1) NOT NULL,
	[DateAttendance] [date] NOT NULL,
	[IdStatusAttendance] [int] NOT NULL,
	[IdStudent] [int] NOT NULL,
 CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED 
(
	[IdAttendance] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discipline]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discipline](
	[IdDiscipline] [int] IDENTITY(1,1) NOT NULL,
	[Cypher] [nvarchar](10) NOT NULL,
	[NameDiscipline] [nvarchar](max) NOT NULL,
	[IdGroup] [int] NOT NULL,
 CONSTRAINT [PK_Discipline] PRIMARY KEY CLUSTERED 
(
	[IdDiscipline] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FinalMark]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FinalMark](
	[IdFinalMark] [int] IDENTITY(1,1) NOT NULL,
	[IdStudent] [int] NOT NULL,
	[IdDiscipline] [int] NOT NULL,
	[IdMark] [int] NOT NULL,
	[IdSemestr] [int] NOT NULL,
	[IdGroup] [int] NOT NULL,
 CONSTRAINT [PK_FinallMark] PRIMARY KEY CLUSTERED 
(
	[IdFinalMark] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mark]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mark](
	[IdMark] [int] IDENTITY(1,1) NOT NULL,
	[NumberMark] [int] NOT NULL,
	[NameMark] [nvarchar](55) NOT NULL,
 CONSTRAINT [PK_Mark] PRIMARY KEY CLUSTERED 
(
	[IdMark] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[IdRole] [int] IDENTITY(1,1) NOT NULL,
	[NameRole] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[IdRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Semestr]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semestr](
	[IdSemester] [int] IDENTITY(1,1) NOT NULL,
	[NumberSemester] [int] NOT NULL,
 CONSTRAINT [PK_Semestr] PRIMARY KEY CLUSTERED 
(
	[IdSemester] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusAttendance]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusAttendance](
	[IdStatusAttendance] [int] IDENTITY(1,1) NOT NULL,
	[NameStusAttendance] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_StatusAttendance] PRIMARY KEY CLUSTERED 
(
	[IdStatusAttendance] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 02.06.2021 10:19:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](55) NOT NULL,
	[Password] [nvarchar](55) NOT NULL,
	[IdGroup] [int] NOT NULL,
	[Email] [nvarchar](60) NOT NULL,
	[IdRole] [int] NOT NULL,
	[SecretCode] [int] NULL,
	[UserName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Group] ON 

INSERT [dbo].[Group] ([IdGroup], [NameGroup]) VALUES (1, N'1')
SET IDENTITY_INSERT [dbo].[Group] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([IdRole], [NameRole]) VALUES (1, N'Админ')
INSERT [dbo].[Role] ([IdRole], [NameRole]) VALUES (2, N'Преподователь')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([IdUser], [Login], [Password], [IdGroup], [Email], [IdRole], [SecretCode], [UserName]) VALUES (1, N'1', N'1', 1, N'andrey2003_12@mail.ru', 1, 321803, N'Admin')
INSERT [dbo].[User] ([IdUser], [Login], [Password], [IdGroup], [Email], [IdRole], [SecretCode], [UserName]) VALUES (3, N'2', N'2', 1, N'1', 2, 1, N'Teacher')
SET IDENTITY_INSERT [dbo].[User] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Dad_NumberPhone]    Script Date: 02.06.2021 10:19:32 ******/
ALTER TABLE [dbo].[Dad] ADD  CONSTRAINT [UQ_Dad_NumberPhone] UNIQUE NONCLUSTERED 
(
	[NumberPhone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_GuardianDad_NumberPhone]    Script Date: 02.06.2021 10:19:32 ******/
ALTER TABLE [dbo].[GuardianDad] ADD  CONSTRAINT [UQ_GuardianDad_NumberPhone] UNIQUE NONCLUSTERED 
(
	[NumberPhone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_GuardianMom_NumberPhone]    Script Date: 02.06.2021 10:19:32 ******/
ALTER TABLE [dbo].[GuardianMom] ADD  CONSTRAINT [UQ_GuardianMom_NumberPhone] UNIQUE NONCLUSTERED 
(
	[NumberPhone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Mom_NumberPhone]    Script Date: 02.06.2021 10:19:32 ******/
ALTER TABLE [dbo].[Mom] ADD  CONSTRAINT [UQ_Mom_NumberPhone] UNIQUE NONCLUSTERED 
(
	[NumberPhone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_Passport_Number]    Script Date: 02.06.2021 10:19:32 ******/
ALTER TABLE [dbo].[Passport] ADD  CONSTRAINT [UQ_Passport_Number] UNIQUE NONCLUSTERED 
(
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Student_Email]    Script Date: 02.06.2021 10:19:32 ******/
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [UQ_Student_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_Student_HospitalPolice]    Script Date: 02.06.2021 10:19:32 ******/
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [UQ_Student_HospitalPolice] UNIQUE NONCLUSTERED 
(
	[HospitalPolice] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_Student_IdPassport]    Script Date: 02.06.2021 10:19:32 ******/
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [UQ_Student_IdPassport] UNIQUE NONCLUSTERED 
(
	[IdPassport] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ_Student_INN]    Script Date: 02.06.2021 10:19:32 ******/
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [UQ_Student_INN] UNIQUE NONCLUSTERED 
(
	[INN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Student_NumberPhone]    Script Date: 02.06.2021 10:19:32 ******/
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [UQ_Student_NumberPhone] UNIQUE NONCLUSTERED 
(
	[NumberPhone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Student_SNILS]    Script Date: 02.06.2021 10:19:32 ******/
ALTER TABLE [dbo].[Student] ADD  CONSTRAINT [UQ_Student_SNILS] UNIQUE NONCLUSTERED 
(
	[SNILS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_User_Login]    Script Date: 02.06.2021 10:19:32 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UQ_User_Login] UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_City] FOREIGN KEY([IdCity])
REFERENCES [dbo].[City] ([IdCity])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_City]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Street] FOREIGN KEY([IdStreet])
REFERENCES [dbo].[Street] ([IdStreet])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Street]
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_StatusAttendance] FOREIGN KEY([IdStatusAttendance])
REFERENCES [dbo].[StatusAttendance] ([IdStatusAttendance])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_StatusAttendance]
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_Student] FOREIGN KEY([IdStudent])
REFERENCES [dbo].[Student] ([IdStudent])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_Student]
GO
ALTER TABLE [dbo].[FinalMark]  WITH CHECK ADD  CONSTRAINT [FK_FinalMark_Discipline] FOREIGN KEY([IdDiscipline])
REFERENCES [dbo].[Discipline] ([IdDiscipline])
GO
ALTER TABLE [dbo].[FinalMark] CHECK CONSTRAINT [FK_FinalMark_Discipline]
GO
ALTER TABLE [dbo].[FinalMark]  WITH CHECK ADD  CONSTRAINT [FK_FinalMark_Group] FOREIGN KEY([IdGroup])
REFERENCES [dbo].[Group] ([IdGroup])
GO
ALTER TABLE [dbo].[FinalMark] CHECK CONSTRAINT [FK_FinalMark_Group]
GO
ALTER TABLE [dbo].[FinalMark]  WITH CHECK ADD  CONSTRAINT [FK_FinalMark_Mark] FOREIGN KEY([IdMark])
REFERENCES [dbo].[Mark] ([IdMark])
GO
ALTER TABLE [dbo].[FinalMark] CHECK CONSTRAINT [FK_FinalMark_Mark]
GO
ALTER TABLE [dbo].[FinalMark]  WITH CHECK ADD  CONSTRAINT [FK_FinalMark_Semestr] FOREIGN KEY([IdSemestr])
REFERENCES [dbo].[Semestr] ([IdSemester])
GO
ALTER TABLE [dbo].[FinalMark] CHECK CONSTRAINT [FK_FinalMark_Semestr]
GO
ALTER TABLE [dbo].[FinalMark]  WITH CHECK ADD  CONSTRAINT [FK_FinalMark_Student] FOREIGN KEY([IdStudent])
REFERENCES [dbo].[Student] ([IdStudent])
GO
ALTER TABLE [dbo].[FinalMark] CHECK CONSTRAINT [FK_FinalMark_Student]
GO
ALTER TABLE [dbo].[Passport]  WITH CHECK ADD  CONSTRAINT [FK_Passport_Gender] FOREIGN KEY([IdGender])
REFERENCES [dbo].[Gender] ([IdGender])
GO
ALTER TABLE [dbo].[Passport] CHECK CONSTRAINT [FK_Passport_Gender]
GO
ALTER TABLE [dbo].[Passport]  WITH CHECK ADD  CONSTRAINT [FK_Passport_IssuedByWhom] FOREIGN KEY([IdIssuedByWhom])
REFERENCES [dbo].[IssuedByWhom] ([IdAuthority])
GO
ALTER TABLE [dbo].[Passport] CHECK CONSTRAINT [FK_Passport_IssuedByWhom]
GO
ALTER TABLE [dbo].[Passport]  WITH CHECK ADD  CONSTRAINT [FK_Passport_PlaceOfBorn] FOREIGN KEY([IdPlaceOfBorn])
REFERENCES [dbo].[PlaceOfBorn] ([IdPlaceOfBorn])
GO
ALTER TABLE [dbo].[Passport] CHECK CONSTRAINT [FK_Passport_PlaceOfBorn]
GO
ALTER TABLE [dbo].[Passport]  WITH CHECK ADD  CONSTRAINT [FK_Passport_Registration] FOREIGN KEY([IdRegistration])
REFERENCES [dbo].[Registration] ([IdRegistration])
GO
ALTER TABLE [dbo].[Passport] CHECK CONSTRAINT [FK_Passport_Registration]
GO
ALTER TABLE [dbo].[Registration]  WITH CHECK ADD  CONSTRAINT [FK_Registration_City] FOREIGN KEY([IdCity])
REFERENCES [dbo].[City] ([IdCity])
GO
ALTER TABLE [dbo].[Registration] CHECK CONSTRAINT [FK_Registration_City]
GO
ALTER TABLE [dbo].[Registration]  WITH CHECK ADD  CONSTRAINT [FK_Registration_Street] FOREIGN KEY([IdStreet])
REFERENCES [dbo].[Street] ([IdStreet])
GO
ALTER TABLE [dbo].[Registration] CHECK CONSTRAINT [FK_Registration_Street]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Address] FOREIGN KEY([IdAddress])
REFERENCES [dbo].[Address] ([IdAddress])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Address]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Dad] FOREIGN KEY([IdDad])
REFERENCES [dbo].[Dad] ([IdDad])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Dad]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Family] FOREIGN KEY([IdFamily])
REFERENCES [dbo].[Family] ([IdFamily])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Family]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_FamilyStatus] FOREIGN KEY([IdFamilyStatus])
REFERENCES [dbo].[FamilyStatus] ([IdFamilyStatus])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_FamilyStatus]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_GuardianDad] FOREIGN KEY([IdDadGuardina])
REFERENCES [dbo].[GuardianDad] ([IdGuardianDad])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_GuardianDad]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_GuardianMom] FOREIGN KEY([IdMomGuradian])
REFERENCES [dbo].[GuardianMom] ([IdGuardianMom])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_GuardianMom]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Image] FOREIGN KEY([IdImage])
REFERENCES [dbo].[Image] ([IdImage])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Image]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Mom] FOREIGN KEY([IdMom])
REFERENCES [dbo].[Mom] ([IdMom])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Mom]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Passport] FOREIGN KEY([IdPassport])
REFERENCES [dbo].[Passport] ([IdPassport])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Passport]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Status] FOREIGN KEY([IdStatus])
REFERENCES [dbo].[Status] ([IdStatus])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Status]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_TemporaryRegistration] FOREIGN KEY([IdTemporaryRegistration])
REFERENCES [dbo].[TemporaryRegistration] ([IdTemporaryRegistration])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_TemporaryRegistration]
GO
ALTER TABLE [dbo].[TemporaryRegistration]  WITH CHECK ADD  CONSTRAINT [FK_TemporaryRegistration_City] FOREIGN KEY([IdCity])
REFERENCES [dbo].[City] ([IdCity])
GO
ALTER TABLE [dbo].[TemporaryRegistration] CHECK CONSTRAINT [FK_TemporaryRegistration_City]
GO
ALTER TABLE [dbo].[TemporaryRegistration]  WITH CHECK ADD  CONSTRAINT [FK_TemporaryRegistration_Street] FOREIGN KEY([IdStreet])
REFERENCES [dbo].[Street] ([IdStreet])
GO
ALTER TABLE [dbo].[TemporaryRegistration] CHECK CONSTRAINT [FK_TemporaryRegistration_Street]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Group] FOREIGN KEY([IdGroup])
REFERENCES [dbo].[Group] ([IdGroup])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Group]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Role] ([IdRole])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[51] 4[19] 2[12] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "City"
            Begin Extent = 
               Top = 294
               Left = 1332
               Bottom = 390
               Right = 1502
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "City_2"
            Begin Extent = 
               Top = 198
               Left = 1332
               Bottom = 294
               Right = 1502
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Address"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "City_1"
            Begin Extent = 
               Top = 8
               Left = 313
               Bottom = 104
               Right = 483
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Registration"
            Begin Extent = 
               Top = 312
               Left = 455
               Bottom = 442
               Right = 625
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Street"
            Begin Extent = 
               Top = 402
               Left = 663
               Bottom = 498
               Right = 833
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Street_1"
            Begin Extent = 
               Top = 234
               Left = 247
               Bottom = 330
               Right = 417
            End
            DisplayFlags ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewStudent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'= 280
            TopColumn = 0
         End
         Begin Table = "Street_2"
            Begin Extent = 
               Top = 330
               Left = 38
               Bottom = 426
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Family"
            Begin Extent = 
               Top = 6
               Left = 1102
               Bottom = 102
               Right = 1272
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Student_1"
            Begin Extent = 
               Top = 444
               Left = 38
               Bottom = 574
               Right = 257
            End
            DisplayFlags = 280
            TopColumn = 9
         End
         Begin Table = "TemporaryRegistration"
            Begin Extent = 
               Top = 444
               Left = 295
               Bottom = 574
               Right = 514
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "Group"
            Begin Extent = 
               Top = 108
               Left = 246
               Bottom = 204
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Dad"
            Begin Extent = 
               Top = 6
               Left = 684
               Bottom = 136
               Right = 854
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Status"
            Begin Extent = 
               Top = 366
               Left = 881
               Bottom = 462
               Right = 1051
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Passport"
            Begin Extent = 
               Top = 270
               Left = 662
               Bottom = 400
               Right = 843
            End
            DisplayFlags = 280
            TopColumn = 10
         End
         Begin Table = "Gender"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 234
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PlaceOfBorn"
            Begin Extent = 
               Top = 270
               Left = 881
               Bottom = 366
               Right = 1068
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "GuardianDad"
            Begin Extent = 
               Top = 138
               Left = 702
               Bottom = 268
               Right = 872
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "GuardianMom"
            Begin Extent = 
               Top = 138
               Left = 910
               Bottom = 268
               Right = 1086
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Image"
            Begin Extent = 
               Top = 198
               Left = 454
               Bottom = 311
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "IssuedByWhom"
            Begin Extent = 
               Top = 234
               Left = 38
               Bottom = 330
               Right = 209
            End
            DisplayFlags = 280
            TopColumn = 0
         En' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewStudent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane3', @value=N'd
         Begin Table = "FamilyStatus"
            Begin Extent = 
               Top = 102
               Left = 476
               Bottom = 198
               Right = 664
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Mom"
            Begin Extent = 
               Top = 234
               Left = 1124
               Bottom = 364
               Right = 1294
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 58
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewStudent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=3 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewStudent'
GO
USE [master]
GO
ALTER DATABASE [ProizvodPrektika] SET  READ_WRITE 
GO
