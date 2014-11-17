USE [master]
GO
/****** Object:  Database [CatalogueSystemDB]    Script Date: 17.11.2014 г. 14:08:17 ******/
CREATE DATABASE [CatalogueSystemDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CatalogueSystemDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CatalogueSystemDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CatalogueSystemDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CatalogueSystemDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CatalogueSystemDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CatalogueSystemDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CatalogueSystemDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CatalogueSystemDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CatalogueSystemDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CatalogueSystemDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CatalogueSystemDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CatalogueSystemDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CatalogueSystemDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CatalogueSystemDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CatalogueSystemDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CatalogueSystemDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CatalogueSystemDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CatalogueSystemDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CatalogueSystemDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CatalogueSystemDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CatalogueSystemDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CatalogueSystemDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CatalogueSystemDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CatalogueSystemDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CatalogueSystemDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CatalogueSystemDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CatalogueSystemDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CatalogueSystemDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CatalogueSystemDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CatalogueSystemDB] SET  MULTI_USER 
GO
ALTER DATABASE [CatalogueSystemDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CatalogueSystemDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CatalogueSystemDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CatalogueSystemDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CatalogueSystemDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CatalogueSystemDB]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 17.11.2014 г. 14:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ParentCategoryID] [int] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comments]    Script Date: 17.11.2014 г. 14:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[CommentID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Text] [nvarchar](1000) NOT NULL,
	[TimeStamp] [datetime2](7) NOT NULL,
	[ProductID] [int] NOT NULL,
	[ParentCommentID] [int] NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Images]    Script Date: 17.11.2014 г. 14:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Images](
	[ImageID] [int] IDENTITY(1,1) NOT NULL,
	[Value] [varbinary](max) NOT NULL,
	[ImageName] [nvarchar](100) NOT NULL,
	[ProductID] [int] NOT NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[ImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LikeDislike]    Script Date: 17.11.2014 г. 14:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LikeDislike](
	[LikeDislikeID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[IsLike] [bit] NOT NULL,
 CONSTRAINT [PK_LikeDislike] PRIMARY KEY CLUSTERED 
(
	[LikeDislikeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Manufacturers]    Script Date: 17.11.2014 г. 14:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturers](
	[ManufacturersID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Manufacturers] PRIMARY KEY CLUSTERED 
(
	[ManufacturersID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 17.11.2014 г. 14:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[ProductCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[ProductCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 17.11.2014 г. 14:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductsID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](160) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[ManufacturerID] [int] NOT NULL,
	[ProductYear] [date] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[RatingID] [int] NOT NULL,
	[TagsID] [int] NOT NULL,
	[LikeDislikeID] [int] NOT NULL,
	[WishlistID] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductsTags]    Script Date: 17.11.2014 г. 14:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductsTags](
	[ProductTagsID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[TagID] [int] NOT NULL,
 CONSTRAINT [PK_ProductsTags] PRIMARY KEY CLUSTERED 
(
	[ProductTagsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 17.11.2014 г. 14:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ratings](
	[RatingID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Value] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
 CONSTRAINT [PK_Ratings] PRIMARY KEY CLUSTERED 
(
	[RatingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tags]    Script Date: 17.11.2014 г. 14:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[TagID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Tags__657CFA4C14E5EF12] PRIMARY KEY CLUSTERED 
(
	[TagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 17.11.2014 г. 14:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1000,1) NOT NULL,
	[UserName] [nvarchar](30) NOT NULL,
	[PasswordHash] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[SecurityStamp] NVARCHAR (100) NULL,
	[PhoneNumber] [nvarchar](25) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NULL,
	[BirthDate] [date] NULL,
	[Gender] [smallint] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
    [LockoutEndDateUtc] [datetime] NULL,
    [LockoutEnabled] [bit] NOT NULL,
	[WishlistID] [int] NOT NULL,
	[AccessFailedCount] INT NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserID] ASC),
 CONSTRAINT [UK_Users_UserName] UNIQUE NONCLUSTERED ([UserName] ASC));
CREATE TABLE [dbo].[UserRole]
(
    [RoleID] INT          NOT NULL,
    [Name]   NVARCHAR(50) NOT NULL,

    CONSTRAINT [PK_UserRole_RoleID] PRIMARY KEY CLUSTERED ([RoleID] ASC),
    CONSTRAINT [UK_UserRole_Name] UNIQUE NONCLUSTERED ([Name] ASC)
)

CREATE TABLE [dbo].[UserUserRole]
(
    [UserID] INT NOT NULL,
    [RoleID] INT NOT NULL,

    CONSTRAINT [PK_UserUserRole_UserID_RoleID] PRIMARY KEY CLUSTERED ([UserID] ASC, [RoleID] ASC),
    CONSTRAINT [FK_UserUserRole_User] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserUserRole_UserRole] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[UserRole] ([RoleID]) ON DELETE CASCADE
);

GO
CREATE NONCLUSTERED INDEX [IX_UserUserRole_UserID]
    ON [dbo].[UserUserRole] ([UserID] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_UserUserRole_RoleID]
    ON [dbo].[UserUserRole] ([RoleID] ASC);

CREATE TABLE [dbo].[UserClaim]
(
    [UserID]     INT                   NOT NULL,
    [ClaimID]    INT IDENTITY (1000,1) NOT NULL,
    [ClaimType]  NVARCHAR (MAX)        NULL,
    [ClaimValue] NVARCHAR (MAX)        NULL,

    CONSTRAINT [PK_UserClaim_ClaimID] PRIMARY KEY CLUSTERED ([ClaimID] ASC),
    CONSTRAINT [FK_UserClaim_User] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID]) ON DELETE CASCADE
);

GO
CREATE NONCLUSTERED INDEX [IX_UserClaim_UserID]
    ON [dbo].[UserClaim] ([UserID] ASC);

CREATE TABLE [dbo].[UserLogin]
(
    [UserID]        INT            NOT NULL,
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [ProviderKey]   NVARCHAR (128) NOT NULL,

    CONSTRAINT [PK_UserLogin_UserID_LoginProvider_ProviderKey] PRIMARY KEY CLUSTERED ([UserID] ASC, [LoginProvider] ASC, [ProviderKey] ASC),
    CONSTRAINT [FK_UserLogin_User] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID]) ON DELETE CASCADE
);

GO
CREATE NONCLUSTERED INDEX [IX_UserLogin_UserID]
    ON [dbo].[UserLogin] ([UserID] ASC);
GO
/****** Object:  Table [dbo].[Wishlist]    Script Date: 17.11.2014 г. 14:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wishlist](
	[WishlistID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
 CONSTRAINT [PK_WishlistProducts] PRIMARY KEY CLUSTERED 
(
	[WishlistID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories] FOREIGN KEY([ParentCategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Categories]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Comments] FOREIGN KEY([ParentCommentID])
REFERENCES [dbo].[Comments] ([CommentID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Comments]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductsID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Products]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users]
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductsID])
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_Products]
GO
ALTER TABLE [dbo].[LikeDislike]  WITH CHECK ADD  CONSTRAINT [FK_LikeDislike_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[LikeDislike] CHECK CONSTRAINT [FK_LikeDislike_Users]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_Categories]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductsID])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_Products]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_LikeDislike] FOREIGN KEY([LikeDislikeID])
REFERENCES [dbo].[LikeDislike] ([LikeDislikeID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_LikeDislike]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Manufacturers] FOREIGN KEY([ManufacturerID])
REFERENCES [dbo].[Manufacturers] ([ManufacturersID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Manufacturers]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Ratings] FOREIGN KEY([RatingID])
REFERENCES [dbo].[Ratings] ([RatingID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Ratings]
GO
ALTER TABLE [dbo].[ProductsTags]  WITH CHECK ADD  CONSTRAINT [FK_ProductsTags_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductsID])
GO
ALTER TABLE [dbo].[ProductsTags] CHECK CONSTRAINT [FK_ProductsTags_Products]
GO
ALTER TABLE [dbo].[ProductsTags]  WITH CHECK ADD  CONSTRAINT [FK_ProductsTags_Tags] FOREIGN KEY([TagID])
REFERENCES [dbo].[Tags] ([TagID])
GO
ALTER TABLE [dbo].[ProductsTags] CHECK CONSTRAINT [FK_ProductsTags_Tags]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK_Ratings_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductsID])
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_Ratings_Products]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK_Ratings_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_Ratings_Users]
GO
ALTER TABLE [dbo].[Wishlist]  WITH CHECK ADD  CONSTRAINT [FK_Wishlist_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Wishlist] CHECK CONSTRAINT [FK_Wishlist_Users]
GO
ALTER TABLE [dbo].[Wishlist]  WITH CHECK ADD  CONSTRAINT [FK_WishlistProducts_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductsID])
GO
ALTER TABLE [dbo].[Wishlist] CHECK CONSTRAINT [FK_WishlistProducts_Products]
GO
USE [master]
GO
ALTER DATABASE [CatalogueSystemDB] SET  READ_WRITE 
GO