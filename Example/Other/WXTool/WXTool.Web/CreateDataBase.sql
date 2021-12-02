SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserCode] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NULL,
	[UserPassword] [varbinary](50) NULL,
	[IsValid] [bit] NOT NULL,
	[CreateUserCode] [varchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyUserCode] [varchar](50) NULL,
	[ModifyTime] [datetime] NULL,
	[DeleteUserCode] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users] ADD PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((1)) FOR [IsValid]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户标识主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户代码（用户名）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'UserCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'UserPassword'
GO






--insert into users([UserCode],[UserName]) values('hdf','黄德富')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleCode] [varchar](200) NULL,
	[RoleName] [varchar](200) NULL,
	[IsValid] [bit] NOT NULL,
	[CreateUserCode] [varchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyUserCode] [varchar](50) NULL,
	[ModifyTime] [datetime] NULL,
	[DeleteUserCode] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Roles] ADD PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT ((1)) FOR [IsValid]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色标识主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Roles', @level2type=N'COLUMN',@level2name=N'RoleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Roles', @level2type=N'COLUMN',@level2name=N'RoleCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Roles', @level2type=N'COLUMN',@level2name=N'RoleName'
GO





SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menus](
	[MenuId] [int] IDENTITY(1,1) NOT NULL,
	[MenuCode] [varchar](200) NULL,
	[MenuName] [varchar](200) NULL,
	[ParentId] [int] NULL,
	[IsValid] [bit] NOT NULL,
	[CreateUserCode] [varchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyUserCode] [varchar](50) NULL,
	[ModifyTime] [datetime] NULL,
	[DeleteUserCode] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Menus] ADD PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Menus] ADD  DEFAULT ((1)) FOR [IsValid]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单标识主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'MenuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'MenuCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'MenuName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父级菜单标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menus', @level2type=N'COLUMN',@level2name=N'ParentId'
GO







SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[RoleId] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserRoles] ADD PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO







SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMenus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NULL,
	[MenuId] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[RoleMenus] ADD PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO














SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [varchar](200) NULL,
	[PMID] [varchar](200) NULL,
	[DOI] [varchar](200) NULL,
	[LongUrl] [varchar](500) NULL,
	[ShortUrl] [varchar](500) NULL,
	[ShortUrlCreateTime] [datetime] NULL,
	[Author] [varchar](200) NULL,
	[Source] [varchar](200) NULL,
	[OuterChain1] [varchar](500) NULL,
	[OuterChain2] [varchar](500) NULL,
	[OuterChain3] [varchar](500) NULL,
	[IsValid] [bit] NOT NULL,
	[CreateUserCode] [varchar](50) NULL,
	[CreateTime] [datetime] NULL,
	[ModifyUserCode] [varchar](50) NULL,
	[ModifyTime] [datetime] NULL,
	[DeleteUserCode] [varchar](50) NULL,
	[DeleteTime] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Books] ADD PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Books] ADD  DEFAULT ((1)) FOR [IsValid]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文献标识主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Books', @level2type=N'COLUMN',@level2name=N'BookId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文献名称标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Books', @level2type=N'COLUMN',@level2name=N'BookName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联文件长链' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Books', @level2type=N'COLUMN',@level2name=N'LongUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时效短链' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Books', @level2type=N'COLUMN',@level2name=N'ShortUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'短链创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Books', @level2type=N'COLUMN',@level2name=N'ShortUrlCreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'作者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Books', @level2type=N'COLUMN',@level2name=N'Author'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'来源' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Books', @level2type=N'COLUMN',@level2name=N'Source'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外链1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Books', @level2type=N'COLUMN',@level2name=N'OuterChain1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外链2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Books', @level2type=N'COLUMN',@level2name=N'OuterChain2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外链3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Books', @level2type=N'COLUMN',@level2name=N'OuterChain3'
GO






