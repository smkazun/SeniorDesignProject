--INSERT 1

GO
SET ANSI_PADDING OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blogs](
	[BlogRowId] [int] IDENTITY(1,1) NOT NULL,
	[BlogId] [uniqueidentifier] NOT NULL,
	[BlogName] [nvarchar](255) NOT NULL,
	[Hostname] [nvarchar](255) NOT NULL,
	[IsAnyTextBeforeHostnameAccepted] [bit] NOT NULL,
	[StorageContainerName] [nvarchar](255) NOT NULL,
	[VirtualPath] [nvarchar](255) NOT NULL,
	[IsPrimary] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsSiteAggregation] [bit] NOT NULL,
 CONSTRAINT [PK_Blogs] PRIMARY KEY CLUSTERED 
(
	[BlogRowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
) 

GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryRowId] [int] IDENTITY(1,1) NOT NULL,
	[BlogId] [uniqueidentifier] NOT NULL,
	[CategoryId] [uniqueidentifier] DEFAULT newid()  NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
	[ParentId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryRowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
) 

--INSERT 2

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pages](
	[PageRowId] [int] IDENTITY(1,1) NOT NULL,
	[BlogId] [uniqueidentifier] NOT NULL,
	[PageId] [uniqueidentifier] DEFAULT newid()  NOT NULL,
	[Title] [nvarchar](255) NULL,
	[Description] [nvarchar](max) NULL,
	[PageContent] [nvarchar](max) NULL,
	[Keywords] [nvarchar](max) NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL,
	[IsPublished] [bit] NULL,
	[IsFrontPage] [bit] NULL,
	[Parent] [uniqueidentifier] NULL,
	[ShowInList] [bit] NULL,
	[Slug] [nvarchar](255) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Pages] PRIMARY KEY CLUSTERED 
(
	[PageRowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
) 

--INSERT 3

GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostCategory](
	[PostCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[BlogId] [uniqueidentifier] NOT NULL,
	[PostId] [uniqueidentifier] NOT NULL,
	[CategoryId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_PostCategory_1] PRIMARY KEY CLUSTERED 
(
	[PostCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
) 

GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostComment](
	[PostCommentRowId] [int] IDENTITY(1,1) NOT NULL,
	[BlogId] [uniqueidentifier] NOT NULL,
	[PostCommentId] [uniqueidentifier] DEFAULT newid()  NOT NULL,
	[PostId] [uniqueidentifier] NOT NULL,
	[ParentCommentId] [uniqueidentifier] NOT NULL,
	[CommentDate] [datetime] NOT NULL,
	[Author] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[Website] [nvarchar](255) NULL,
	[Comment] [nvarchar](max) NULL,
	[Country] [nvarchar](255) NULL,
	[IP] [nvarchar](50) NULL,
	[IsApproved] [bit] NULL,
	[ModeratedBy] [nvarchar](100) NULL,
	[Avatar] [nvarchar](255) NULL,
	[IsSpam] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_PostComment] PRIMARY KEY CLUSTERED 
(
	[PostCommentRowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
) 

GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostNotify](
	[PostNotifyId] [int] IDENTITY(1,1) NOT NULL,
	[BlogId] [uniqueidentifier] NOT NULL,
	[PostId] [uniqueidentifier] NOT NULL,
	[NotifyAddress] [nvarchar](255) NULL,
 CONSTRAINT [idx_PostCategory_BlogId_PostId] PRIMARY KEY CLUSTERED 
(
	[PostNotifyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
) 

GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[PostRowId] [int] IDENTITY(1,1) NOT NULL,
	[BlogId] [uniqueidentifier] NOT NULL,
	[PostId] [uniqueidentifier] DEFAULT newid()  NOT NULL,
	[Title] [nvarchar](255) NULL,
	[Description] [nvarchar](max) NULL,
	[PostContent] [nvarchar](max) NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL,
	[Author] [nvarchar](50) NULL,
	[IsPublished] [bit] NULL,
	[IsCommentEnabled] [bit] NULL,
	[Raters] [int] NULL,
	[Rating] [real] NULL,
	[Slug] [nvarchar](255) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[PostRowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
) 

GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostTag](
	[PostTagId] [int] IDENTITY(1,1) NOT NULL,
	[BlogId] [uniqueidentifier] NOT NULL,
	[PostId] [uniqueidentifier] NOT NULL,
	[Tag] [nvarchar](50) NULL,
 CONSTRAINT [PK_PostTag] PRIMARY KEY CLUSTERED 
(
	[PostTagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
) 

GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profiles](
	[ProfileId] [int] IDENTITY(1,1) NOT NULL,
	[BlogId] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](100) NULL,
	[SettingName] [nvarchar](200) NULL,
	[SettingValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_Profiles] PRIMARY KEY CLUSTERED 
(
	[ProfileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
) 

--INSERT 4

GO
SET ANSI_PADDING OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RightRoles](
	[RightRoleRowId] [int] IDENTITY(1,1) NOT NULL,
	[BlogId] [uniqueidentifier] NOT NULL,
	[RightName] [nvarchar](100) NOT NULL,
	[Role] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_RightRoles] PRIMARY KEY CLUSTERED 
(
	[RightRoleRowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
) 

GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rights](
	[RightRowId] [int] IDENTITY(1,1) NOT NULL,
	[BlogId] [uniqueidentifier] NOT NULL,
	[RightName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Rights] PRIMARY KEY CLUSTERED 
(
	[RightRowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
) 

ALTER TABLE dbo.Rights
ADD CONSTRAINT AK_RightName UNIQUE (BlogId, RightName)

GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settings](
	[SettingRowId] [int] IDENTITY(1,1) NOT NULL,
	[BlogId] [uniqueidentifier] NOT NULL,
	[SettingName] [nvarchar](50) NOT NULL,
	[SettingValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[SettingRowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
) 

ALTER TABLE dbo.Settings
ADD CONSTRAINT AK_SettingName UNIQUE (BlogId, SettingName)

GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StopWords](
	[StopWordRowId] [int] IDENTITY(1,1) NOT NULL,
	[BlogId] [uniqueidentifier] NOT NULL,
	[StopWord] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_StopWords] PRIMARY KEY CLUSTERED 
(
	[StopWordRowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
) 

GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataStoreSettings](
	[DataStoreSettingRowId] [int] IDENTITY(1,1) NOT NULL,
	[BlogId] [uniqueidentifier] NOT NULL,
	[ExtensionType] [nvarchar](50) NOT NULL,
	[ExtensionId] [nvarchar](100) NOT NULL,
	[Settings] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DataStoreSettings] PRIMARY KEY CLUSTERED 
(
	[DataStoreSettingRowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
) 

--Insert initial values into Blogs
GO
SET IDENTITY_INSERT [dbo].[Blogs] ON 
GO
INSERT [dbo].[Blogs] ([BlogRowId], [BlogId], [BlogName], [Hostname], [IsAnyTextBeforeHostnameAccepted], [StorageContainerName], [VirtualPath], [IsPrimary], [IsActive], [IsSiteAggregation]) VALUES (1, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'Primary', N'', 0, N'', N'~/', 1, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Blogs] OFF

--Insert initial values into Categories
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([CategoryRowId], [BlogId], [CategoryId], [CategoryName], [Description], [ParentId]) VALUES (1, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'75afb678-cd5d-4428-b37e-095e3bd89db3', N'General', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF

--Insert initial post
GO
SET IDENTITY_INSERT [dbo].[Posts] ON 
GO
INSERT [dbo].[Posts] ([PostRowID], [BlogID], [PostID], [Title], [Description], [PostContent], [DateCreated], [DateModified], [Author], [IsPublished], [IsCommentEnabled], [Raters], [Rating], [Slug], [IsDeleted]) VALUES (1, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'f50d9b47-ed25-4925-a03a-3dab5fd45b28', N'Welcome to BlogEngine.NET using Microsoft SQL Server', N'The description is used as the meta description as well as shown in the related posts. It is recommended that you write a description, but not mandatory', 
N'<p>If you see this post it means that BlogEngine.NET is running and the hard part of creating your own blog is done. There is only a few things left to do.</p>
<h2>Write Permissions</h2>
<p>To be able to log in, write posts and customize blog, you need to enable write permissions on the App_Data and Custom folders. If your blog is hosted at a hosting provider, you can either log into your account’s admin page or call the support.<br></p>
<p>If you wish to use a database to store your blog data, we still encourage you to enable this write access for an images you may wish to store for your blog posts.&nbsp; If you are interested in using Microsoft SQL Server, MySQL, SQL CE, or other databases, please see the <a href="http://dnbe.net/docs">BlogEngine docs</a> to get started.</p>
<h2>Security</h2>
<p>When you`ve got write permissions set, you need to change the username and password. Find the sign-in link located either at the bottom or top of the page depending on your current theme and click it. Now enter "admin" in both the username and password fields and click the button. You will now see an admin menu appear. It has a link to the "Users" admin page. From there you can change password, create new users and set roles and permissions. Passwords are hashed by default so you better configure email in settings for password recovery to work or <a target="_blank" href="http://dnbe.net/docs/post/frequently-asked-questions#HowdoIresetlostadminpassword">learn how to do it manually</a>.<br></p>
<h2>Configuration and Profile</h2>
<p>Now that you have your blog secured, take a look through the settings and give your new blog a title.&nbsp; BlogEngine.NET is set up to take full advantage of many semantic formats and technologies such as FOAF, SIOC and APML. It means that the content stored in your BlogEngine.NET installation will be fully portable and auto-discoverable.&nbsp; Be sure to fill in your author profile to take better advantage of this.</p>
<h2>Themes, Widgets &amp; Extensions</h2>
<p>One last thing to consider is customizing the look and behavior of your blog. We have themes, widgets and extensions available right out of the box. You can install more right from admin panel under Custom/Gallery.</p>
<h2>On the web</h2>
<p>You can find news about BlogEngine.NET on the <a href="https://blogengine.io">official website</a>. For tutorials, documentation, tips and tricks visit our <a target="_blank" href="http://dnbe.net/docs">docs site</a>. The ongoing development of BlogEngine.NET can be followed at <a href="http://blogengine.codeplex.com/">CodePlex</a> where the daily builds will be published for anyone to download.<br></p>
<p>Good luck and happy writing.</p>
<p>The BlogEngine.NET team</p>', GETDATE(), NULL, N'admin', 1, NULL, NULL, NULL, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Posts] OFF
GO
SET IDENTITY_INSERT [dbo].[PostTag] ON 
GO
INSERT [dbo].[PostTag] ([PostTagID], [BlogID], [PostID], [Tag]) VALUES (1, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'f50d9b47-ed25-4925-a03a-3dab5fd45b28', N'blog')
GO
INSERT [dbo].[PostTag] ([PostTagID], [BlogID], [PostID], [Tag]) VALUES (2, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'f50d9b47-ed25-4925-a03a-3dab5fd45b28', N'welcome')
GO
SET IDENTITY_INSERT [dbo].[PostTag] OFF

--Insert initial values into RightRoles
GO
SET IDENTITY_INSERT [dbo].[RightRoles] ON 
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2200, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewDetailedErrorMessages', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2201, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'AccessAdminPages', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2202, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'AccessAdminPages', N'Editors')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2203, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'AccessAdminSettingsPages', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2204, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewPublicComments', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2205, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewPublicComments', N'Users')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2206, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewPublicComments', N'Editors')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2207, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewUnmoderatedComments', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2208, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewUnmoderatedComments', N'Editors')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2209, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'CreateComments', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2210, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'CreateComments', N'Users')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2211, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'CreateComments', N'Editors')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2212, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ModerateComments', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2213, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ModerateComments', N'Editors')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2214, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewPublicPosts', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2215, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewPublicPosts', N'Users')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2216, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewPublicPosts', N'Editors')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2217, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewUnpublishedPosts', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2218, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewUnpublishedPosts', N'Editors')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2219, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'CreateNewPosts', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2220, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'CreateNewPosts', N'Editors')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2221, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'EditPosts', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2222, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'EditPosts', N'Editors')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2223, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'DeletePosts', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2224, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'DeletePosts', N'Editors')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2225, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'PublishPosts', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2226, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'PublishPosts', N'Editors')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2227, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewPublicPages', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2228, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewPublicPages', N'Users')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2229, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewPublicPages', N'Editors')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2230, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewUnpublishedPages', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2231, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewUnpublishedPages', N'Editors')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2232, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'CreateNewPages', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2233, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'CreateNewPages', N'Editors')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2234, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'EditOwnPages', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2235, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'EditOwnPages', N'Editors')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2236, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewRoles', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2237, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'CreateNewRoles', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2238, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'EditRoles', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2239, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'DeleteRoles', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2240, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'EditOwnRoles', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2241, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'EditOtherUsersRoles', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2242, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'CreateNewUsers', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2243, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'DeleteUserSelf', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2244, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'DeleteUsersOtherThanSelf', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2245, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'EditOwnUser', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2246, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'EditOwnUser', N'Editors')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2247, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'EditOtherUsers', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2248, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewDashboard', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2249, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ManageThemes', N'Administrators')
GO
INSERT [dbo].[RightRoles] ([RightRoleRowId], [BlogId], [RightName], [Role]) VALUES (2250, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ManagePackages', N'Administrators')
GO
SET IDENTITY_INSERT [dbo].[RightRoles] OFF

--Insert initial values into Rights
GO
SET IDENTITY_INSERT [dbo].[Rights] ON 
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1200, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'None')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1201, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewDetailedErrorMessages')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1202, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'AccessAdminPages')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1203, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'AccessAdminSettingsPages')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1204, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewPublicComments')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1205, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewUnmoderatedComments')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1206, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'CreateComments')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1207, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ModerateComments')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1208, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewPublicPosts')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1209, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewUnpublishedPosts')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1210, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'CreateNewPosts')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1211, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'EditPosts')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1212, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'DeletePosts')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1213, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'PublishPosts')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1214, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewPublicPages')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1215, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewUnpublishedPages')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1216, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'CreateNewPages')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1217, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'EditOwnPages')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1218, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewRoles')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1219, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'CreateNewRoles')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1220, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'EditRoles')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1221, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'DeleteRoles')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1222, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'EditOwnRoles')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1223, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'EditOtherUsersRoles')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1224, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'CreateNewUsers')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1225, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'DeleteUserSelf')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1226, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'DeleteUsersOtherThanSelf')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1227, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'EditOwnUser')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1228, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'EditOtherUsers')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1229, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ViewDashboard')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1230, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ManageThemes')
GO
INSERT [dbo].[Rights] ([RightRowId], [BlogId], [RightName]) VALUES (1231, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'ManagePackages')
GO
SET IDENTITY_INSERT [dbo].[Rights] OFF
GO

--Create NONCLUSTERED indexes
GO
CREATE UNIQUE NONCLUSTERED INDEX [idx_Categories_BlogId_CategoryId] ON [dbo].[Categories]
(
	[BlogId] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
GO
SET ANSI_PADDING ON

GO
CREATE NONCLUSTERED INDEX [idx_Pages_BlogId_PageId] ON [dbo].[Pages]
(
	[BlogId] ASC,
	[PageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
GO
CREATE NONCLUSTERED INDEX [idx_PostCategory_BlogId_CategoryId] ON [dbo].[PostCategory]
(
	[BlogId] ASC,
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
GO
CREATE NONCLUSTERED INDEX [idx_PostCategory_BlogId_PostId] ON [dbo].[PostCategory]
(
	[BlogId] ASC,
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
GO
CREATE NONCLUSTERED INDEX [idx_PostComment_BlogId_PostId] ON [dbo].[PostComment]
(
	[BlogId] ASC,
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
CREATE NONCLUSTERED INDEX [FK_PostId] ON [dbo].[PostNotify]
(
	[BlogId] ASC,
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
GO
CREATE UNIQUE NONCLUSTERED INDEX [Posts_BlogId_PostId] ON [dbo].[Posts]
(
	[BlogId] ASC,
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
GO
CREATE NONCLUSTERED INDEX [idx_PostTag_BlogId_PostId] ON [dbo].[PostTag]
(
	[BlogId] ASC,
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
GO
SET ANSI_PADDING ON

GO
CREATE NONCLUSTERED INDEX [idx_Profiles_BlogId_UserName] ON [dbo].[Profiles]
(
	[BlogId] ASC,
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
GO
SET ANSI_PADDING ON

GO
CREATE NONCLUSTERED INDEX [idx_RightRoles_BlogId] ON [dbo].[RightRoles]
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
GO
CREATE NONCLUSTERED INDEX [idx_Rights_BlogId] ON [dbo].[Rights]
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
GO
SET ANSI_PADDING ON

GO
CREATE NONCLUSTERED INDEX [idx_Settings_BlogId] ON [dbo].[Settings]
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 
GO
CREATE NONCLUSTERED INDEX [idx_StopWords_BlogId] ON [dbo].[StopWords]
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) 

GO
SET IDENTITY_INSERT [dbo].[DataStoreSettings] ON 

GO
INSERT [dbo].[DataStoreSettings] ([DataStoreSettingRowId], [BlogId], [ExtensionType], [ExtensionId], [Settings]) VALUES (1, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'1', N'WIDGET_ZONE', N'<?xml version="1.0" encoding="utf-16"?>
<WidgetData xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Settings>&lt;widgets&gt;&lt;widget id="d9ada63d-3462-4c72-908e-9d35f0acce40" title="TextBox" showTitle="True"&gt;TextBox&lt;/widget&gt;&lt;widget id="19baa5f6-49d4-4828-8f7f-018535c35f94" title="Administration" showTitle="True"&gt;Administration&lt;/widget&gt;&lt;widget id="d81c5ae3-e57e-4374-a539-5cdee45e639f" title="Search" showTitle="True"&gt;Search&lt;/widget&gt;&lt;widget id="77142800-6dff-4016-99ca-69b5c5ebac93" title="Tag Cloud" showTitle="True"&gt;TagCloud&lt;/widget&gt;&lt;widget id="4ce68ae7-c0c8-4bf8-b50f-a67b582b0d2e" title="Post List" showTitle="True"&gt;PostList&lt;/widget&gt;&lt;/widgets&gt;</Settings>
</WidgetData>')
GO
INSERT [dbo].[DataStoreSettings] ([DataStoreSettingRowId], [BlogId], [ExtensionType], [ExtensionId], [Settings]) VALUES (113, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'0', N'MetaExtension', N'<?xml version="1.0" encoding="utf-16"?>
<ManagedExtension xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" Name="MetaExtension">
  <AdminPage />
  <Author>BlogEngine.net</Author>
  <Description>Meta extension</Description>
  <Enabled>true</Enabled>
  <Priority>0</Priority>
  <Settings>
    <Delimiter>44</Delimiter>
    <Help />
    <Hidden>false</Hidden>
    <Index>0</Index>
    <IsScalar>false</IsScalar>
    <KeyField>ID</KeyField>
    <Name>BeCommentFilters</Name>
    <Parameters>
      <KeyField>true</KeyField>
      <Label>ID</Label>
      <MaxLength>20</MaxLength>
      <Name>ID</Name>
      <ParamType>Integer</ParamType>
      <Required>true</Required>
      <SelectedValue />
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Action</Label>
      <MaxLength>100</MaxLength>
      <Name>Action</Name>
      <ParamType>String</ParamType>
      <Required>false</Required>
      <SelectedValue />
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Subject</Label>
      <MaxLength>100</MaxLength>
      <Name>Subject</Name>
      <ParamType>String</ParamType>
      <Required>false</Required>
      <SelectedValue />
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Operator</Label>
      <MaxLength>100</MaxLength>
      <Name>Operator</Name>
      <ParamType>String</ParamType>
      <Required>false</Required>
      <SelectedValue />
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Filter</Label>
      <MaxLength>100</MaxLength>
      <Name>Filter</Name>
      <ParamType>String</ParamType>
      <Required>false</Required>
      <SelectedValue />
    </Parameters>
    <ShowAdd>true</ShowAdd>
    <ShowDelete>true</ShowDelete>
    <ShowEdit>true</ShowEdit>
  </Settings>
  <Settings>
    <Delimiter>44</Delimiter>
    <Help />
    <Hidden>false</Hidden>
    <Index>1</Index>
    <IsScalar>false</IsScalar>
    <KeyField>FullName</KeyField>
    <Name>BeCustomFilters</Name>
    <Parameters>
      <KeyField>true</KeyField>
      <Label>Name</Label>
      <MaxLength>100</MaxLength>
      <Name>FullName</Name>
      <ParamType>String</ParamType>
      <Required>true</Required>
      <SelectedValue />
      <Values>App_Code.Extensions.TypePadFilter</Values>
      <Values>App_Code.Extensions.StopForumSpam</Values>
      <Values>App_Code.Extensions.AkismetFilter</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Name</Label>
      <MaxLength>100</MaxLength>
      <Name>Name</Name>
      <ParamType>String</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>TypePadFilter</Values>
      <Values>StopForumSpam</Values>
      <Values>AkismetFilter</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Checked</Label>
      <MaxLength>100</MaxLength>
      <Name>Checked</Name>
      <ParamType>String</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>0</Values>
      <Values>0</Values>
      <Values>0</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Cought</Label>
      <MaxLength>100</MaxLength>
      <Name>Cought</Name>
      <ParamType>String</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>0</Values>
      <Values>0</Values>
      <Values>0</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Reported</Label>
      <MaxLength>100</MaxLength>
      <Name>Reported</Name>
      <ParamType>String</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>0</Values>
      <Values>0</Values>
      <Values>0</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Priority</Label>
      <MaxLength>100</MaxLength>
      <Name>Priority</Name>
      <ParamType>String</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>0</Values>
      <Values>0</Values>
      <Values>0</Values>
    </Parameters>
    <ShowAdd>true</ShowAdd>
    <ShowDelete>true</ShowDelete>
    <ShowEdit>true</ShowEdit>
  </Settings>
  <ShowSettings>true</ShowSettings>
  <Version>1.0</Version>
</ManagedExtension>')
GO
INSERT [dbo].[DataStoreSettings] ([DataStoreSettingRowId], [BlogId], [ExtensionType], [ExtensionId], [Settings]) VALUES (114, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'0', N'SyntaxHighlighter', N'<?xml version="1.0" encoding="utf-16"?>
<ManagedExtension xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" Name="SyntaxHighlighter">
  <AdminPage />
  <Author>&lt;a target="_blank" href="https://blogengine.io/"&gt;BlogEngine.NET&lt;/a&gt;</Author>
  <Description>Adds &lt;a target="_blank" href="http://alexgorbatchev.com/wiki/SyntaxHighlighter"&gt;Alex Gorbatchev''s&lt;/a&gt; source code formatter</Description>
  <Enabled>true</Enabled>
  <Priority>0</Priority>
  <Settings>
    <Delimiter>44</Delimiter>
    <Help>&lt;p&gt;This extension implements excellent Alex Gorbatchev''s syntax highlighter JS library for source code formatting. Please refer to &lt;a target="_blank" href="http://alexgorbatchev.com/wiki/SyntaxHighlighter:Usage"&gt;this site&lt;/a&gt; for usage.&lt;/p&gt;
&lt;p&gt;&lt;b&gt;auto-links&lt;/b&gt;: Allows you to turn detection of links in the highlighted element on and off. If the option is turned off, URLs won''t be clickable.&lt;/p&gt;
&lt;p&gt;&lt;b&gt;collapse&lt;/b&gt;: Allows you to force highlighted elements on the page to be collapsed by default.&lt;/p&gt;
&lt;p&gt;&lt;b&gt;gutter&lt;/b&gt;:	Allows you to turn gutter with line numbers on and off.&lt;/p&gt;
&lt;p&gt;&lt;b&gt;light&lt;/b&gt;: Allows you to disable toolbar and gutter with a single property.&lt;/p&gt;
&lt;p&gt;&lt;b&gt;smart-tabs&lt;/b&gt;:	Allows you to turn smart tabs feature on and off.&lt;/p&gt;
&lt;p&gt;&lt;b&gt;tab-size&lt;/b&gt;: Allows you to adjust tab size.&lt;/p&gt;
&lt;p&gt;&lt;b&gt;toolbar&lt;/b&gt;: Toggles toolbar on/off.&lt;/p&gt;
&lt;p&gt;&lt;b&gt;wrap-lines&lt;/b&gt;: Allows you to turn line wrapping feature on and off.&lt;/p&gt;
&lt;p&gt;&lt;a target="_blank" href="http://alexgorbatchev.com/wiki/SyntaxHighlighter:Configuration"&gt;more...&lt;/a&gt;&lt;/p&gt;
</Help>
    <Hidden>false</Hidden>
    <Index>0</Index>
    <IsScalar>true</IsScalar>
    <KeyField>gutter</KeyField>
    <Name>Options</Name>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Gutter</Label>
      <MaxLength>100</MaxLength>
      <Name>gutter</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>True</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Smart tabs</Label>
      <MaxLength>100</MaxLength>
      <Name>smart-tabs</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>True</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Auto links</Label>
      <MaxLength>100</MaxLength>
      <Name>auto-links</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>True</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Collapse</Label>
      <MaxLength>100</MaxLength>
      <Name>collapse</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>False</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Light</Label>
      <MaxLength>100</MaxLength>
      <Name>light</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>False</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Tab size</Label>
      <MaxLength>100</MaxLength>
      <Name>tab-size</Name>
      <ParamType>Integer</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>4</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Toolbar</Label>
      <MaxLength>100</MaxLength>
      <Name>toolbar</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>True</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Wrap lines</Label>
      <MaxLength>100</MaxLength>
      <Name>wrap-lines</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>True</Values>
    </Parameters>
    <ShowAdd>true</ShowAdd>
    <ShowDelete>true</ShowDelete>
    <ShowEdit>true</ShowEdit>
  </Settings>
  <Settings>
    <Delimiter>44</Delimiter>
    <Help />
    <Hidden>false</Hidden>
    <Index>1</Index>
    <IsScalar>true</IsScalar>
    <KeyField>shBrushBash</KeyField>
    <Name>Brushes</Name>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Bash (bash, shell)</Label>
      <MaxLength>100</MaxLength>
      <Name>shBrushBash</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>False</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>C++ (cpp, c)</Label>
      <MaxLength>100</MaxLength>
      <Name>shBrushCpp</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>False</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>C# (c-sharp, csharp)</Label>
      <MaxLength>100</MaxLength>
      <Name>shBrushCSharp</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>True</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Css (css)</Label>
      <MaxLength>100</MaxLength>
      <Name>shBrushCss</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>True</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Delphi (delphi, pas, pascal)</Label>
      <MaxLength>100</MaxLength>
      <Name>shBrushDelphi</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>False</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Diff (diff, patch)</Label>
      <MaxLength>100</MaxLength>
      <Name>shBrushDiff</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>False</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Groovy (groovy)</Label>
      <MaxLength>100</MaxLength>
      <Name>shBrushGroovy</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>False</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Java (java)</Label>
      <MaxLength>100</MaxLength>
      <Name>shBrushJava</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>False</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>JScript (js, jscript, javascript)</Label>
      <MaxLength>100</MaxLength>
      <Name>shBrushJScript</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>True</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>PHP (php)</Label>
      <MaxLength>100</MaxLength>
      <Name>shBrushPhp</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>False</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Plain (plain, text)</Label>
      <MaxLength>100</MaxLength>
      <Name>shBrushPlain</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>True</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Python (py, python)</Label>
      <MaxLength>100</MaxLength>
      <Name>shBrushPython</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>False</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Ruby (rails, ror, ruby)</Label>
      <MaxLength>100</MaxLength>
      <Name>shBrushRuby</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>False</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Scala (scala)</Label>
      <MaxLength>100</MaxLength>
      <Name>shBrushScala</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>False</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>SQL (sql)</Label>
      <MaxLength>100</MaxLength>
      <Name>shBrushSql</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>True</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>VB (vb, vbnet)</Label>
      <MaxLength>100</MaxLength>
      <Name>shBrushVb</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>True</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>XML (xml, xhtml, xslt, html, xhtml)</Label>
      <MaxLength>100</MaxLength>
      <Name>shBrushXml</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>True</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Cold Fusion (cf, coldfusion)</Label>
      <MaxLength>100</MaxLength>
      <Name>shBrushColdFusion</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>False</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Erlang (erlang, erl)</Label>
      <MaxLength>100</MaxLength>
      <Name>shBrushErlang</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>False</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>JavaFX (jfx, javafx)</Label>
      <MaxLength>100</MaxLength>
      <Name>shBrushJavaFX</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>False</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Perl (perl, pl)</Label>
      <MaxLength>100</MaxLength>
      <Name>shBrushPerl</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>False</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>PowerSell (ps, powershell)</Label>
      <MaxLength>100</MaxLength>
      <Name>shBrushPowerShell</Name>
      <ParamType>Boolean</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>False</Values>
    </Parameters>
    <ShowAdd>true</ShowAdd>
    <ShowDelete>true</ShowDelete>
    <ShowEdit>true</ShowEdit>
  </Settings>
  <Settings>
    <Delimiter>44</Delimiter>
    <Help />
    <Hidden>false</Hidden>
    <Index>2</Index>
    <IsScalar>true</IsScalar>
    <KeyField>SelectedTheme</KeyField>
    <Name>Themes</Name>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Themes</Label>
      <MaxLength>20</MaxLength>
      <Name>SelectedTheme</Name>
      <ParamType>ListBox</ParamType>
      <Required>false</Required>
      <SelectedValue>Default</SelectedValue>
      <Values>Default</Values>
      <Values>Django</Values>
      <Values>Eclipse</Values>
      <Values>Emacs</Values>
      <Values>FadeToGrey</Values>
      <Values>MDUltra</Values>
      <Values>Midnight</Values>
      <Values>Dark</Values>
    </Parameters>
    <ShowAdd>true</ShowAdd>
    <ShowDelete>true</ShowDelete>
    <ShowEdit>true</ShowEdit>
  </Settings>
  <ShowSettings>true</ShowSettings>
  <Version>2.5</Version>
</ManagedExtension>')
GO
INSERT [dbo].[DataStoreSettings] ([DataStoreSettingRowId], [BlogId], [ExtensionType], [ExtensionId], [Settings]) VALUES (115, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'0', N'BBCode', N'<?xml version="1.0" encoding="utf-16"?>
<ManagedExtension xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" Name="BBCode">
  <AdminPage />
  <Author>&lt;a href="https://blogengine.io"&gt;BlogEngine.NET&lt;/a&gt;</Author>
  <Description>Converts BBCode to XHTML in the comments</Description>
  <Enabled>true</Enabled>
  <Priority>0</Priority>
  <ShowSettings>true</ShowSettings>
  <Version>1.0</Version>
</ManagedExtension>')
GO
INSERT [dbo].[DataStoreSettings] ([DataStoreSettingRowId], [BlogId], [ExtensionType], [ExtensionId], [Settings]) VALUES (116, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'0', N'Logger', N'<?xml version="1.0" encoding="utf-16"?>
<ManagedExtension xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" Name="Logger">
  <AdminPage />
  <Author>BlogEngine.NET</Author>
  <Description>Subscribes to Log events and records the events in a file.</Description>
  <Enabled>true</Enabled>
  <Priority>0</Priority>
  <ShowSettings>true</ShowSettings>
  <Version>1.0</Version>
</ManagedExtension>')
GO
INSERT [dbo].[DataStoreSettings] ([DataStoreSettingRowId], [BlogId], [ExtensionType], [ExtensionId], [Settings]) VALUES (117, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'0', N'TypePadFilter', N'<?xml version="1.0" encoding="utf-16"?>
<ManagedExtension xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" Name="TypePadFilter">
  <AdminPage />
  <Author>&lt;a href="http://lucsiferre.net"&gt;By Chris Nicola&lt;/a&gt;</Author>
  <Description>TypePad anti-spam comment filter (based on AkismetFilter)</Description>
  <Enabled>false</Enabled>
  <Priority>0</Priority>
  <Settings>
    <Delimiter>44</Delimiter>
    <Help />
    <Hidden>false</Hidden>
    <Index>0</Index>
    <IsScalar>true</IsScalar>
    <KeyField>SiteURL</KeyField>
    <Name>TypePadFilter</Name>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Site URL</Label>
      <MaxLength>100</MaxLength>
      <Name>SiteURL</Name>
      <ParamType>String</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>http://example.com/blog</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>API Key</Label>
      <MaxLength>100</MaxLength>
      <Name>ApiKey</Name>
      <ParamType>String</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>123456789</Values>
    </Parameters>
    <ShowAdd>true</ShowAdd>
    <ShowDelete>true</ShowDelete>
    <ShowEdit>true</ShowEdit>
  </Settings>
  <ShowSettings>true</ShowSettings>
  <Version>1.0</Version>
</ManagedExtension>')
GO
INSERT [dbo].[DataStoreSettings] ([DataStoreSettingRowId], [BlogId], [ExtensionType], [ExtensionId], [Settings]) VALUES (118, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'0', N'MediaElementPlayer', N'<?xml version="1.0" encoding="utf-16"?>
<ManagedExtension xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" Name="MediaElementPlayer">
  <AdminPage />
  <Author>&lt;a href="http://johndyer.me/"&gt;John Dyer&lt;/a&gt;</Author>
  <Description>HTML5 Video/Audio Player</Description>
  <Enabled>true</Enabled>
  <Priority>0</Priority>
  <Settings>
    <Delimiter>44</Delimiter>
    <Help>
&lt;p&gt;Build on &lt;a href="http://mediaelement.js.com/"&gt;MediaElement.js&lt;/a&gt;, the HTML5 video/audio player.&lt;/p&gt;

&lt;ol&gt;
	&lt;li&gt;Upload media files to your /media/ folder&lt;/li&gt;
	&lt;li&gt;Add short code to your media: [video src="myfile.mp4"] for video and [audio src="myfile.mp3"] for audio&lt;/li&gt;
	&lt;li&gt;Customize with the following parameters:
		&lt;ul&gt;
			&lt;li&gt;&lt;b&gt;width&lt;/b&gt;: The exact width of the video&lt;/li&gt;
			&lt;li&gt;&lt;b&gt;height&lt;/b&gt;: The exact height of the video&lt;/li&gt;
			&lt;li&gt;&lt;b&gt;autoplay&lt;/b&gt;: Plays the video as soon as the webpage loads&lt;/li&gt;
		&lt;/ul&gt;
	&lt;/li&gt;
	&lt;li&gt;You can also specify multiple file formats and codecs 
		&lt;ul&gt;
			&lt;li&gt;&lt;b&gt;mp4&lt;/b&gt;: H.264 encoded MP4 file&lt;/li&gt;
			&lt;li&gt;&lt;b&gt;webm&lt;/b&gt;: VP8/WebM encoded file&lt;/li&gt;
			&lt;li&gt;&lt;b&gt;ogg&lt;/b&gt;: Theora/Vorbis encoded file&lt;/li&gt;
		&lt;/ul&gt;
	&lt;/li&gt;
&lt;/ol&gt;

&lt;p&gt;A complete example:&lt;br /&gt;
[code mp4="myfile.mp4" webm="myfile.webm" ogg="myfile.ogg" width="480" height="360"]
&lt;/p&gt;

&lt;p&gt;Supported formats&lt;/p&gt;
&lt;ul&gt;
	&lt;li&gt;&lt;b&gt;MP4/MP3&lt;/b&gt;: Native HTML5 for IE9, Safari, Chrome; Flash in IE8, Firefox, Opera&lt;/li&gt;
	&lt;li&gt;&lt;b&gt;WebM&lt;/b&gt;: HTML5 for IE9, Chrome, Firefox, Opera; Flash in IE8 (coming in Flash 11)&lt;/li&gt;
	&lt;li&gt;&lt;b&gt;FLV&lt;/b&gt;: Flash fallback&lt;/li&gt;
	&lt;li&gt;&lt;b&gt;WMV/WMA&lt;/b&gt;: Silverlight fallback&lt;/li&gt;
&lt;/ul&gt;
</Help>
    <Hidden>false</Hidden>
    <Index>0</Index>
    <IsScalar>true</IsScalar>
    <KeyField>width</KeyField>
    <Name>MediaElementPlayer</Name>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Default Width</Label>
      <MaxLength>100</MaxLength>
      <Name>width</Name>
      <ParamType>String</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>480</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Default Height</Label>
      <MaxLength>100</MaxLength>
      <Name>height</Name>
      <ParamType>String</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>360</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Folder for Media (MP4, MP3, WMV, Ogg, WebM, etc.)</Label>
      <MaxLength>100</MaxLength>
      <Name>folder</Name>
      <ParamType>String</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>media</Values>
    </Parameters>
    <ShowAdd>true</ShowAdd>
    <ShowDelete>true</ShowDelete>
    <ShowEdit>true</ShowEdit>
  </Settings>
  <ShowSettings>true</ShowSettings>
  <Version>1.5</Version>
</ManagedExtension>')
GO
INSERT [dbo].[DataStoreSettings] ([DataStoreSettingRowId], [BlogId], [ExtensionType], [ExtensionId], [Settings]) VALUES (119, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'0', N'ResolveLinks', N'<?xml version="1.0" encoding="utf-16"?>
<ManagedExtension xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" Name="ResolveLinks">
  <AdminPage />
  <Author>BlogEngine.NET</Author>
  <Description>Auto resolves URLs in the comments and turn them into valid hyperlinks.</Description>
  <Enabled>true</Enabled>
  <Priority>0</Priority>
  <ShowSettings>true</ShowSettings>
  <Version>1.5</Version>
</ManagedExtension>')
GO
INSERT [dbo].[DataStoreSettings] ([DataStoreSettingRowId], [BlogId], [ExtensionType], [ExtensionId], [Settings]) VALUES (120, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'0', N'SendPings', N'<?xml version="1.0" encoding="utf-16"?>
<ManagedExtension xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" Name="SendPings">
  <AdminPage />
  <Author>BlogEngine.NET</Author>
  <Description>Pings all the ping services specified on the PingServices admin page and send track- and pingbacks</Description>
  <Enabled>true</Enabled>
  <Priority>0</Priority>
  <ShowSettings>true</ShowSettings>
  <Version>1.3</Version>
</ManagedExtension>')
GO
INSERT [dbo].[DataStoreSettings] ([DataStoreSettingRowId], [BlogId], [ExtensionType], [ExtensionId], [Settings]) VALUES (121, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'0', N'BreakPost', N'<?xml version="1.0" encoding="utf-16"?>
<ManagedExtension xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" Name="BreakPost">
  <AdminPage />
  <Author>BlogEngine.NET</Author>
  <Description>Breaks a post where [more] is found in the body and adds a link to full post</Description>
  <Enabled>true</Enabled>
  <Priority>0</Priority>
  <ShowSettings>true</ShowSettings>
  <Version>1.4</Version>
</ManagedExtension>')
GO
INSERT [dbo].[DataStoreSettings] ([DataStoreSettingRowId], [BlogId], [ExtensionType], [ExtensionId], [Settings]) VALUES (122, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'0', N'AkismetFilter', N'<?xml version="1.0" encoding="utf-16"?>
<ManagedExtension xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" Name="AkismetFilter">
  <AdminPage />
  <Author>&lt;a href="https://blogengine.io"&gt;BlogEngine.NET&lt;/a&gt;</Author>
  <Description>Akismet anti-spam comment filter</Description>
  <Enabled>false</Enabled>
  <Priority>0</Priority>
  <Settings>
    <Delimiter>44</Delimiter>
    <Help />
    <Hidden>false</Hidden>
    <Index>0</Index>
    <IsScalar>true</IsScalar>
    <KeyField>SiteURL</KeyField>
    <Name>AkismetFilter</Name>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Site URL</Label>
      <MaxLength>100</MaxLength>
      <Name>SiteURL</Name>
      <ParamType>String</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>http://example.com/blog</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>API Key</Label>
      <MaxLength>100</MaxLength>
      <Name>ApiKey</Name>
      <ParamType>String</ParamType>
      <Required>false</Required>
      <SelectedValue />
      <Values>123456789</Values>
    </Parameters>
    <ShowAdd>true</ShowAdd>
    <ShowDelete>true</ShowDelete>
    <ShowEdit>true</ShowEdit>
  </Settings>
  <ShowSettings>true</ShowSettings>
  <Version>1.0</Version>
</ManagedExtension>')
GO
INSERT [dbo].[DataStoreSettings] ([DataStoreSettingRowId], [BlogId], [ExtensionType], [ExtensionId], [Settings]) VALUES (123, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'0', N'SendCommentMail', N'<?xml version="1.0" encoding="utf-16"?>
<ManagedExtension xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" Name="SendCommentMail">
  <AdminPage />
  <Author>BlogEngine.NET</Author>
  <Description>Sends an e-mail to the blog owner whenever a comment is added</Description>
  <Enabled>true</Enabled>
  <Priority>0</Priority>
  <ShowSettings>true</ShowSettings>
  <Version>1.3</Version>
</ManagedExtension>')
GO
INSERT [dbo].[DataStoreSettings] ([DataStoreSettingRowId], [BlogId], [ExtensionType], [ExtensionId], [Settings]) VALUES (124, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'0', N'Smilies', N'<?xml version="1.0" encoding="utf-16"?>
<ManagedExtension xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" Name="Smilies">
  <AdminPage />
  <Author>BlogEngine.NET</Author>
  <Description>Converts ASCII smilies into real smilies in the comments</Description>
  <Enabled>true</Enabled>
  <Priority>0</Priority>
  <ShowSettings>true</ShowSettings>
  <Version>1.3</Version>
</ManagedExtension>')
GO
INSERT [dbo].[DataStoreSettings] ([DataStoreSettingRowId], [BlogId], [ExtensionType], [ExtensionId], [Settings]) VALUES (125, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'0', N'CodeFormatterExtension', N'<?xml version="1.0" encoding="utf-16"?>
<ManagedExtension xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" Name="CodeFormatterExtension">
  <AdminPage />
  <Author>www.manoli.net</Author>
  <Description>Converts text to formatted syntax highlighted code (beta).</Description>
  <Enabled>true</Enabled>
  <Priority>0</Priority>
  <ShowSettings>true</ShowSettings>
  <Version>0.1</Version>
</ManagedExtension>')
GO
INSERT [dbo].[DataStoreSettings] ([DataStoreSettingRowId], [BlogId], [ExtensionType], [ExtensionId], [Settings]) VALUES (126, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'0', N'SimpleCaptcha', N'<?xml version="1.0" encoding="utf-16"?>
<ManagedExtension xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" Name="SimpleCaptcha">
  <AdminPage />
  <Author>&lt;a href="http://www.aaronstannard.com"&gt;Aaron Stannard&lt;/a&gt;</Author>
  <Description>Settings for the SimpleCaptcha control</Description>
  <Enabled>false</Enabled>
  <Priority>0</Priority>
  <Settings>
    <Delimiter>44</Delimiter>
    <Help>To get started with SimpleCaptcha, just provide some captcha instructions for your users in the &lt;b&gt;CaptchaLabel&lt;/b&gt;
                                field and the value you require from your users in order to post a comment in the &lt;b&gt;CaptchaAnswer&lt;/b&gt; field.</Help>
    <Hidden>false</Hidden>
    <Index>0</Index>
    <IsScalar>true</IsScalar>
    <KeyField>CaptchaLabel</KeyField>
    <Name>SimpleCaptcha</Name>
    <Parameters>
      <KeyField>true</KeyField>
      <Label>Your captcha''s label</Label>
      <MaxLength>30</MaxLength>
      <Name>CaptchaLabel</Name>
      <ParamType>String</ParamType>
      <Required>true</Required>
      <SelectedValue />
      <Values>5+5 = </Values>
    </Parameters>
    <Parameters>
      <KeyField>true</KeyField>
      <Label>Your captcha''s expected value</Label>
      <MaxLength>30</MaxLength>
      <Name>CaptchaAnswer</Name>
      <ParamType>String</ParamType>
      <Required>true</Required>
      <SelectedValue />
      <Values>10</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Show Captcha For Authenticated Users</Label>
      <MaxLength>1</MaxLength>
      <Name>ShowForAuthenticatedUsers</Name>
      <ParamType>Boolean</ParamType>
      <Required>true</Required>
      <SelectedValue />
      <Values>False</Values>
    </Parameters>
    <ShowAdd>true</ShowAdd>
    <ShowDelete>true</ShowDelete>
    <ShowEdit>true</ShowEdit>
  </Settings>
  <ShowSettings>true</ShowSettings>
  <Version>1.0</Version>
</ManagedExtension>')
GO
INSERT [dbo].[DataStoreSettings] ([DataStoreSettingRowId], [BlogId], [ExtensionType], [ExtensionId], [Settings]) VALUES (127, N'71acc52b-040c-4456-8820-dd21f6122fbc', N'0', N'Recaptcha', N'<?xml version="1.0" encoding="utf-16"?>
<ManagedExtension xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" Name="Recaptcha">
  <AdminPage />
  <Author>&lt;a href="http://www.bloodforge.com"&gt;Bloodforge.com&lt;/a&gt;</Author>
  <Description>Settings for the Recaptcha control</Description>
  <Enabled>false</Enabled>
  <Priority>0</Priority>
  <Settings>
    <Delimiter>44</Delimiter>
    <Help>
&lt;script type=''text/javascript''&gt;
function showRecaptchaLog() {
        window.scrollTo(0, 0);
        var width = document.documentElement.clientWidth + document.documentElement.scrollLeft;
        var height = document.documentElement.clientHeight + document.documentElement.scrollTop;

        var layer = document.createElement(''div'');
        layer.style.zIndex = 1002;
        layer.id = ''RecaptchaLogLayer'';
        layer.style.position = ''absolute'';
        layer.style.top = ''0px'';
        layer.style.left = ''0px'';
        layer.style.height = document.documentElement.scrollHeight + ''px'';
        layer.style.width = width + ''px'';
        layer.style.backgroundColor = ''black'';
        layer.style.opacity = ''.6'';
        layer.style.filter += (''progid:DXImageTransform.Microsoft.Alpha(opacity=60)'');
        document.body.style.position = ''static'';
        document.body.appendChild(layer);

        var size = { ''height'': 500, ''width'': 750 };
        var iframe = document.createElement(''iframe'');
        iframe.name = ''Recaptcha Log Viewer'';
        iframe.id = ''RecaptchaLogDetails'';
        iframe.src = ''../Pages/RecaptchaLogViewer.aspx'';
        iframe.style.height = size.height + ''px'';
        iframe.style.width = size.width + ''px'';
        iframe.style.position = ''fixed'';
        iframe.style.zIndex = 1003;
        iframe.style.backgroundColor = ''white'';
        iframe.style.border = ''4px solid silver'';
        iframe.frameborder = ''0'';

        iframe.style.top = ((height + document.documentElement.scrollTop) / 2) - (size.height / 2) + ''px'';
        iframe.style.left = (width / 2) - (size.width / 2) + ''px'';

        document.body.appendChild(iframe);
        return false;
    }
&lt;/script&gt;
You can create your own public key at &lt;a href=''http://www.Recaptcha.net''&gt;http://www.Recaptcha.net&lt;/a&gt;. This is used for communication between your website and the recapcha server.&lt;br /&gt;&lt;br /&gt;Please rememeber you need to &lt;span style="color:red"&gt;enable extension&lt;/span&gt; for reCaptcha to show up on the comments form.&lt;br /&gt;&lt;br /&gt;You can see some statistics on Captcha solving by storing successful attempts. If you''re getting spam, this should also confirm that the spammers are at least solving the captcha.&lt;br /&gt;&lt;br /&gt;&lt;a href=''../Pages/RecaptchaLogViewer.aspx'' target=''_blank'' onclick=''return showRecaptchaLog()''&gt;Click here to view the log&lt;/a&gt;</Help>
    <Hidden>false</Hidden>
    <Index>0</Index>
    <IsScalar>true</IsScalar>
    <KeyField>PublicKey</KeyField>
    <Name>Recaptcha</Name>
    <Parameters>
      <KeyField>true</KeyField>
      <Label>Public Key</Label>
      <MaxLength>50</MaxLength>
      <Name>PublicKey</Name>
      <ParamType>String</ParamType>
      <Required>true</Required>
      <SelectedValue />
      <Values>YOURPUBLICKEY</Values>
    </Parameters>
    <Parameters>
      <KeyField>true</KeyField>
      <Label>Private Key</Label>
      <MaxLength>50</MaxLength>
      <Name>PrivateKey</Name>
      <ParamType>String</ParamType>
      <Required>true</Required>
      <SelectedValue />
      <Values>YOURPRIVATEKEY</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Show Captcha For Authenticated Users</Label>
      <MaxLength>1</MaxLength>
      <Name>ShowForAuthenticatedUsers</Name>
      <ParamType>Boolean</ParamType>
      <Required>true</Required>
      <SelectedValue />
      <Values>False</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Logging: Maximum successful recaptcha attempts to store (set to 0 to disable logging)</Label>
      <MaxLength>4</MaxLength>
      <Name>MaxLogEntries</Name>
      <ParamType>Integer</ParamType>
      <Required>true</Required>
      <SelectedValue />
      <Values>50</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Theme</Label>
      <MaxLength>20</MaxLength>
      <Name>Theme</Name>
      <ParamType>DropDown</ParamType>
      <Required>true</Required>
      <SelectedValue>white</SelectedValue>
      <Values>red</Values>
      <Values>white</Values>
      <Values>blackglass</Values>
      <Values>clean</Values>
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Language</Label>
      <MaxLength>5</MaxLength>
      <Name>Language</Name>
      <ParamType>DropDown</ParamType>
      <Required>true</Required>
      <SelectedValue>en</SelectedValue>
      <Values>en|English</Values>
      <Values>nl|Dutch</Values>
      <Values>fr|French</Values>
      <Values>de|German</Values>
      <Values>pt|Portuguese</Values>
      <Values>ru|Russian</Values>
      <Values>es|Spanish</Values>
      <Values>tr|Turkish</Values>
    </Parameters>
    <ShowAdd>true</ShowAdd>
    <ShowDelete>true</ShowDelete>
    <ShowEdit>true</ShowEdit>
  </Settings>
  <Settings>
    <Delimiter>44</Delimiter>
    <Help />
    <Hidden>true</Hidden>
    <Index>1</Index>
    <IsScalar>false</IsScalar>
    <KeyField>Response</KeyField>
    <Name>RecaptchaLog</Name>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Response</Label>
      <MaxLength>100</MaxLength>
      <Name>Response</Name>
      <ParamType>String</ParamType>
      <Required>false</Required>
      <SelectedValue />
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Challenge</Label>
      <MaxLength>100</MaxLength>
      <Name>Challenge</Name>
      <ParamType>String</ParamType>
      <Required>false</Required>
      <SelectedValue />
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>CommentID</Label>
      <MaxLength>100</MaxLength>
      <Name>CommentID</Name>
      <ParamType>String</ParamType>
      <Required>false</Required>
      <SelectedValue />
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>TimeToComment</Label>
      <MaxLength>100</MaxLength>
      <Name>TimeToComment</Name>
      <ParamType>String</ParamType>
      <Required>false</Required>
      <SelectedValue />
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>TimeToSolveCapcha</Label>
      <MaxLength>100</MaxLength>
      <Name>TimeToSolveCapcha</Name>
      <ParamType>String</ParamType>
      <Required>false</Required>
      <SelectedValue />
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>NumberOfAttempts</Label>
      <MaxLength>100</MaxLength>
      <Name>NumberOfAttempts</Name>
      <ParamType>String</ParamType>
      <Required>false</Required>
      <SelectedValue />
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Enabled</Label>
      <MaxLength>100</MaxLength>
      <Name>Enabled</Name>
      <ParamType>String</ParamType>
      <Required>false</Required>
      <SelectedValue />
    </Parameters>
    <Parameters>
      <KeyField>false</KeyField>
      <Label>Necessary</Label>
      <MaxLength>100</MaxLength>
      <Name>Necessary</Name>
      <ParamType>String</ParamType>
      <Required>false</Required>
      <SelectedValue />
    </Parameters>
    <ShowAdd>true</ShowAdd>
    <ShowDelete>true</ShowDelete>
    <ShowEdit>true</ShowEdit>
  </Settings>
  <ShowSettings>true</ShowSettings>
  <Version>1.1</Version>
</ManagedExtension>')
GO
SET IDENTITY_INSERT [dbo].[DataStoreSettings] OFF