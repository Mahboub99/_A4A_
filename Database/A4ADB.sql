USE [master]
GO

/****** Object:  Database [A4A]    Script Date: 07-Dec-19 1:50:22 AM ******/
CREATE DATABASE [A4A]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'A4A', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.AASHRAFH\MSSQL\DATA\A4A.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'A4A_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.AASHRAFH\MSSQL\DATA\A4A_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [A4A].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [A4A] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [A4A] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [A4A] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [A4A] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [A4A] SET ARITHABORT OFF 
GO

ALTER DATABASE [A4A] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [A4A] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [A4A] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [A4A] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [A4A] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [A4A] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [A4A] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [A4A] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [A4A] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [A4A] SET  ENABLE_BROKER 
GO

ALTER DATABASE [A4A] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [A4A] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [A4A] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [A4A] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [A4A] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [A4A] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [A4A] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [A4A] SET RECOVERY FULL 
GO

ALTER DATABASE [A4A] SET  MULTI_USER 
GO

ALTER DATABASE [A4A] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [A4A] SET DB_CHAINING OFF 
GO

ALTER DATABASE [A4A] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [A4A] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [A4A] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [A4A] SET QUERY_STORE = OFF
GO

ALTER DATABASE [A4A] SET  READ_WRITE 
GO

