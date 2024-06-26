USE [master]
GO
/****** Object:  Database [ExampleApp]    Script Date: 17.04.2024 16:31:09 ******/
CREATE DATABASE [ExampleApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ExampleApp', FILENAME = N'C:\Users\Денис\ExampleApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ExampleApp_log', FILENAME = N'C:\Users\Денис\ExampleApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ExampleApp] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ExampleApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ExampleApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ExampleApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ExampleApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ExampleApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ExampleApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [ExampleApp] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ExampleApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ExampleApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ExampleApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ExampleApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ExampleApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ExampleApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ExampleApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ExampleApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ExampleApp] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ExampleApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ExampleApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ExampleApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ExampleApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ExampleApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ExampleApp] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ExampleApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ExampleApp] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ExampleApp] SET  MULTI_USER 
GO
ALTER DATABASE [ExampleApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ExampleApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ExampleApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ExampleApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ExampleApp] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ExampleApp] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ExampleApp] SET QUERY_STORE = OFF
GO
USE [ExampleApp]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 17.04.2024 16:31:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 17.04.2024 16:31:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 17.04.2024 16:31:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Login] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240416194547_CreateBase', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240416223927_UpdateUsers', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240417125637_updateroles', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240417125846_updaterole', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240417125939_updaterol', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240417131634_update', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240417131705_updat', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240417131930_nullable', N'8.0.3')
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Name]) VALUES (1, N'Администратор')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (2, N'Сотрудник')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [Login], [Password], [RoleId]) VALUES (1, N'string', N'oleg', N'12345', 1)
INSERT [dbo].[Users] ([Id], [Name], [Login], [Password], [RoleId]) VALUES (3, N'Andrey', N'andrey', N'123', 2)
INSERT [dbo].[Users] ([Id], [Name], [Login], [Password], [RoleId]) VALUES (9, N'string', N'oleg', N'12345', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_Users_RoleId]    Script Date: 17.04.2024 16:31:09 ******/
CREATE NONCLUSTERED INDEX [IX_Users_RoleId] ON [dbo].[Users]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles_RoleId]
GO
USE [master]
GO
ALTER DATABASE [ExampleApp] SET  READ_WRITE 
GO
