USE [master]
GO
/****** Object:  Database [NitrilonDB]    Script Date: 15-04-2024 11:12:46 ******/
CREATE DATABASE [NitrilonDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NitrilonDB', FILENAME = N'C:\data\NitrilonDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NitrilonDB_log', FILENAME = N'C:\data\NitrilonDB.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [NitrilonDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NitrilonDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NitrilonDB] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [NitrilonDB] SET ANSI_NULLS ON 
GO
ALTER DATABASE [NitrilonDB] SET ANSI_PADDING ON 
GO
ALTER DATABASE [NitrilonDB] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [NitrilonDB] SET ARITHABORT ON 
GO
ALTER DATABASE [NitrilonDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NitrilonDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NitrilonDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NitrilonDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NitrilonDB] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [NitrilonDB] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [NitrilonDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NitrilonDB] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [NitrilonDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NitrilonDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NitrilonDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NitrilonDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NitrilonDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NitrilonDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NitrilonDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NitrilonDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NitrilonDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NitrilonDB] SET RECOVERY FULL 
GO
ALTER DATABASE [NitrilonDB] SET  MULTI_USER 
GO
ALTER DATABASE [NitrilonDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NitrilonDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NitrilonDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NitrilonDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NitrilonDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NitrilonDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [NitrilonDB] SET QUERY_STORE = OFF
GO
USE [NitrilonDB]
GO
/****** Object:  Table [dbo].[EventRatings]    Script Date: 15-04-2024 11:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventRatings](
	[EventRatingId] [int] IDENTITY(1,1) NOT NULL,
	[EventId] [int] NOT NULL,
	[RatingId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EventRatingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 15-04-2024 11:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Attendees] [int] NULL,
	[Description] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 15-04-2024 11:12:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ratings](
	[RatingId] [int] IDENTITY(1,1) NOT NULL,
	[Value] [tinyint] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RatingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[EventRatings] ON 

INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (1, 1, 3)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (2, 1, 3)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (3, 1, 2)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (4, 1, 1)
INSERT [dbo].[EventRatings] ([EventRatingId], [EventId], [RatingId]) VALUES (5, 1, 3)
SET IDENTITY_INSERT [dbo].[EventRatings] OFF
GO
SET IDENTITY_INSERT [dbo].[Events] ON 

INSERT [dbo].[Events] ([EventId], [Date], [Name], [Attendees], [Description]) VALUES (1, CAST(N'2024-04-06' AS Date), N'NITRICON 2024', 300, N'Nitrilons event of 2024')
INSERT [dbo].[Events] ([EventId], [Date], [Name], [Attendees], [Description]) VALUES (1001, CAST(N'2024-04-11' AS Date), N'string', 0, N'string')
INSERT [dbo].[Events] ([EventId], [Date], [Name], [Attendees], [Description]) VALUES (2001, CAST(N'2024-04-12' AS Date), N'Test', -1, N'Dette event har endnu ingen beskrivelse.')
INSERT [dbo].[Events] ([EventId], [Date], [Name], [Attendees], [Description]) VALUES (2002, CAST(N'2024-04-12' AS Date), N'Test', -1, N'Dette event har endnu ingen beskrivelse.')
INSERT [dbo].[Events] ([EventId], [Date], [Name], [Attendees], [Description]) VALUES (2003, CAST(N'2024-04-12' AS Date), N'Test', -1, N'Dette event har endnu ingen beskrivelse.')
INSERT [dbo].[Events] ([EventId], [Date], [Name], [Attendees], [Description]) VALUES (2004, CAST(N'2024-04-12' AS Date), N'Test', -1, N'Dette event har endnu ingen beskrivelse.')
INSERT [dbo].[Events] ([EventId], [Date], [Name], [Attendees], [Description]) VALUES (2005, CAST(N'2024-04-12' AS Date), N'Test', -1, N'Dette event har endnu ingen beskrivelse.')
INSERT [dbo].[Events] ([EventId], [Date], [Name], [Attendees], [Description]) VALUES (2006, CAST(N'2024-04-12' AS Date), N'string', 0, N'string')
INSERT [dbo].[Events] ([EventId], [Date], [Name], [Attendees], [Description]) VALUES (2007, CAST(N'2024-04-12' AS Date), N'string', 0, N'string')
INSERT [dbo].[Events] ([EventId], [Date], [Name], [Attendees], [Description]) VALUES (2008, CAST(N'2024-04-12' AS Date), N'string', 0, N'string')
SET IDENTITY_INSERT [dbo].[Events] OFF
GO
SET IDENTITY_INSERT [dbo].[Ratings] ON 

INSERT [dbo].[Ratings] ([RatingId], [Value], [Description]) VALUES (1, 1, N'Bad')
INSERT [dbo].[Ratings] ([RatingId], [Value], [Description]) VALUES (2, 2, N'Neutral')
INSERT [dbo].[Ratings] ([RatingId], [Value], [Description]) VALUES (3, 3, N'Good')
SET IDENTITY_INSERT [dbo].[Ratings] OFF
GO
ALTER TABLE [dbo].[Events] ADD  DEFAULT ((-1)) FOR [Attendees]
GO
ALTER TABLE [dbo].[Events] ADD  DEFAULT ('Dette event har endnu ingen beskrivelse.') FOR [Description]
GO
ALTER TABLE [dbo].[EventRatings]  WITH CHECK ADD  CONSTRAINT [FK_EventRatings_Events] FOREIGN KEY([EventId])
REFERENCES [dbo].[Events] ([EventId])
GO
ALTER TABLE [dbo].[EventRatings] CHECK CONSTRAINT [FK_EventRatings_Events]
GO
ALTER TABLE [dbo].[EventRatings]  WITH CHECK ADD  CONSTRAINT [FK_EventRatings_Ratings] FOREIGN KEY([RatingId])
REFERENCES [dbo].[Ratings] ([RatingId])
GO
ALTER TABLE [dbo].[EventRatings] CHECK CONSTRAINT [FK_EventRatings_Ratings]
GO
USE [master]
GO
ALTER DATABASE [NitrilonDB] SET  READ_WRITE 
GO
