USE [CatalogueDB]
GO
/****** Object:  StoredProcedure [dbo].[usp_deleteCategories]    Script Date: 11/19/2014 9:31:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_deleteCategories]
@id bigint
as
WITH Nodes ([CategoryID], [ParentCategoryID], [Level]) 
AS (
    SELECT  ct.CategoryID, ct.ParentCategoryID, 0 AS [Level]
    FROM    dbo.Categories as ct
    WHERE   ct.CategoryID = @id

    UNION ALL

    SELECT  ct.CategoryID, ct.ParentCategoryID, N.[Level] + 1
    FROM    dbo.Categories as ct
        INNER JOIN Nodes N ON N.CategoryID = ct.ParentCategoryID
)

DELETE
FROM    dbo.Categories
WHERE   CategoryID IN (
    SELECT  TOP 100 PERCENT N.CategoryID
    FROM    Nodes N
    ORDER BY N.[Level] DESC
	)
GO
/****** Object:  StoredProcedure [dbo].[usp_deleteComments]    Script Date: 11/19/2014 9:31:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_deleteComments] 
@id bigint
as
WITH Nodes ([CommentID], [ParentCommentID], [Level]) 
AS (
    SELECT  cm.CommentID, cm.ParentCommentID, 0 AS [Level]
    FROM    dbo.Comments as cm
    WHERE   cm.CommentID = @id

    UNION ALL

    SELECT  cm.CommentID, cm.ParentCommentID, N.[Level] + 1
    FROM    dbo.Comments as cm
        INNER JOIN Nodes N ON N.CommentID = cm.ParentCommentID
)

DELETE
FROM    dbo.Comments
WHERE   CommentID IN (
    SELECT  TOP 100 PERCENT N.CommentID
    FROM    Nodes N
	)

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 11/19/2014 9:31:33 AM ******/
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
/****** Object:  Table [dbo].[Comments]    Script Date: 11/19/2014 9:31:33 AM ******/
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
/****** Object:  Table [dbo].[Images]    Script Date: 11/19/2014 9:31:33 AM ******/
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
/****** Object:  Table [dbo].[LikesDislikes]    Script Date: 11/19/2014 9:31:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LikesDislikes](
	[LikeDislikeID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[IsLike] [bit] NOT NULL,
	[ProductID] [int] NOT NULL,
 CONSTRAINT [PK_ProductID] PRIMARY KEY CLUSTERED 
(
	[LikeDislikeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Manufacturers]    Script Date: 11/19/2014 9:31:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturers](
	[ManufacturerID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Manufacturers] PRIMARY KEY CLUSTERED 
(
	[ManufacturerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 11/19/2014 9:31:33 AM ******/
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
/****** Object:  Table [dbo].[Products]    Script Date: 11/19/2014 9:31:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](160) NOT NULL,
	[ManufacturerID] [int] NOT NULL,
	[ProductYear] [date] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductsTags]    Script Date: 11/19/2014 9:31:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductsTags](
	[ProductTagID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[TagID] [int] NOT NULL,
 CONSTRAINT [PK_ProductsTags] PRIMARY KEY CLUSTERED 
(
	[ProductTagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 11/19/2014 9:31:33 AM ******/
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
/****** Object:  Table [dbo].[Tags]    Script Date: 11/19/2014 9:31:33 AM ******/
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
/****** Object:  Table [dbo].[UserClaim]    Script Date: 11/19/2014 9:31:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaim](
	[UserID] [int] NOT NULL,
	[ClaimID] [int] IDENTITY(1000,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaim_ClaimID] PRIMARY KEY CLUSTERED 
(
	[ClaimID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 11/19/2014 9:31:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogin](
	[UserID] [int] NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_UserLogin_UserID_LoginProvider_ProviderKey] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 11/19/2014 9:31:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[RoleID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UserRole_RoleID] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_UserRole_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/19/2014 9:31:33 AM ******/
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
	[SecurityStamp] [nvarchar](100) NULL,
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
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Users_UserName] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserUserRole]    Script Date: 11/19/2014 9:31:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserUserRole](
	[UserID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_UserUserRole_UserID_RoleID] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Wishlists]    Script Date: 11/19/2014 9:31:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wishlists](
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
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Products]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users]
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_Products]
GO
ALTER TABLE [dbo].[LikesDislikes]  WITH CHECK ADD  CONSTRAINT [FK_LikesDislikes_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[LikesDislikes] CHECK CONSTRAINT [FK_LikesDislikes_Products]
GO
ALTER TABLE [dbo].[LikesDislikes]  WITH CHECK ADD  CONSTRAINT [FK_LikesDislikes_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[LikesDislikes] CHECK CONSTRAINT [FK_LikesDislikes_Users]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_Categories]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_Products]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Manufacturers] FOREIGN KEY([ManufacturerID])
REFERENCES [dbo].[Manufacturers] ([ManufacturerID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Manufacturers]
GO
ALTER TABLE [dbo].[ProductsTags]  WITH CHECK ADD  CONSTRAINT [FK_ProductsTags_Products2] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[ProductsTags] CHECK CONSTRAINT [FK_ProductsTags_Products2]
GO
ALTER TABLE [dbo].[ProductsTags]  WITH CHECK ADD  CONSTRAINT [FK_ProductsTags_Tags] FOREIGN KEY([TagID])
REFERENCES [dbo].[Tags] ([TagID])
GO
ALTER TABLE [dbo].[ProductsTags] CHECK CONSTRAINT [FK_ProductsTags_Tags]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK_Ratings_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_Ratings_Products]
GO
ALTER TABLE [dbo].[Ratings]  WITH CHECK ADD  CONSTRAINT [FK_Ratings_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Ratings] CHECK CONSTRAINT [FK_Ratings_Users]
GO
ALTER TABLE [dbo].[UserClaim]  WITH CHECK ADD  CONSTRAINT [FK_UserClaim_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserClaim] CHECK CONSTRAINT [FK_UserClaim_User]
GO
ALTER TABLE [dbo].[UserLogin]  WITH CHECK ADD  CONSTRAINT [FK_UserLogin_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLogin] CHECK CONSTRAINT [FK_UserLogin_User]
GO
ALTER TABLE [dbo].[UserUserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserUserRole_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserUserRole] CHECK CONSTRAINT [FK_UserUserRole_User]
GO
ALTER TABLE [dbo].[UserUserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserUserRole_UserRole] FOREIGN KEY([RoleID])
REFERENCES [dbo].[UserRole] ([RoleID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserUserRole] CHECK CONSTRAINT [FK_UserUserRole_UserRole]
GO
ALTER TABLE [dbo].[Wishlists]  WITH CHECK ADD  CONSTRAINT [FK_Wishlist_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Wishlists] CHECK CONSTRAINT [FK_Wishlist_Users]
GO
ALTER TABLE [dbo].[Wishlists]  WITH CHECK ADD  CONSTRAINT [FK_Wishlists_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Wishlists] CHECK CONSTRAINT [FK_Wishlists_Products]
GO
