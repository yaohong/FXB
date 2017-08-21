USE [MFXB]
GO
/****** Object:  Table [dbo].[qttaskindex]    Script Date: 08/21/2017 18:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[qttaskindex](
	[qtkey] [nvarchar](50) NOT NULL,
	[closing] [bit] NOT NULL,
	[rootqtdepartmentid] [bigint] NOT NULL,
 CONSTRAINT [PK_qttaskindex] PRIMARY KEY CLUSTERED 
(
	[qtkey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[qttaskdata]    Script Date: 08/21/2017 18:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[qttaskdata](
	[qtdepartmentid] [bigint] NOT NULL,
	[qtlevel] [int] NOT NULL,
	[ownerjobnumber] [nvarchar](50) NOT NULL,
	[parentdepartmentid] [bigint] NOT NULL,
	[needcompletetaskamount] [float] NOT NULL,
	[qtkey] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
CREATE UNIQUE CLUSTERED INDEX [key_id] ON [dbo].[qttaskdata] 
(
	[qtkey] ASC,
	[qtdepartmentid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[project]    Script Date: 08/21/2017 18:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[project](
	[code] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[address] [nvarchar](100) NOT NULL,
	[comment] [nvarchar](100) NULL,
	[availbale] [bit] NOT NULL,
 CONSTRAINT [PK_project] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[project] ([code], [name], [address], [comment], [availbale]) VALUES (N'A002', N'桂林苑', N'徐家汇001', N'dasdasd', 1)
INSERT [dbo].[project] ([code], [name], [address], [comment], [availbale]) VALUES (N'A003', N'粤绣小区', N'静安区平型关路', N'dsdsd', 1)
/****** Object:  Table [dbo].[jobgrade]    Script Date: 08/21/2017 18:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[jobgrade](
	[levelName] [nvarchar](50) NOT NULL,
	[xuLie] [nvarchar](50) NOT NULL,
	[baseSalary] [int] NOT NULL,
	[comment] [nvarchar](300) NULL,
 CONSTRAINT [PK_jobgrade] PRIMARY KEY CLUSTERED 
(
	[levelName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[jobgrade] ([levelName], [xuLie], [baseSalary], [comment]) VALUES (N'M2', N'高级营销经理', 3100, N'测试备注')
INSERT [dbo].[jobgrade] ([levelName], [xuLie], [baseSalary], [comment]) VALUES (N'Z2', N'高级营销顾问', 1800, N'哈哈111111')
INSERT [dbo].[jobgrade] ([levelName], [xuLie], [baseSalary], [comment]) VALUES (N'总经理', N'总经理', 0, N'总经理级别')
/****** Object:  Table [dbo].[employee]    Script Date: 08/21/2017 18:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee](
	[gonghao] [nvarchar](50) NOT NULL,
	[name] [nvarchar](25) NOT NULL,
	[qtlevel] [int] NOT NULL,
	[departmentId] [bigint] NOT NULL,
	[isOwner] [bit] NOT NULL,
	[zhiji] [nvarchar](50) NOT NULL,
	[dianhua] [nvarchar](50) NOT NULL,
	[ruzhiTime] [int] NOT NULL,
	[jobState] [bit] NOT NULL,
	[lizhiTime] [int] NOT NULL,
	[comment] [nvarchar](200) NOT NULL,
	[shenfenzheng] [nvarchar](50) NOT NULL,
	[shengriTime] [int] NOT NULL,
	[sex] [bit] NOT NULL,
	[mingzujiguan] [nvarchar](50) NOT NULL,
	[juzhuaddress] [nvarchar](50) NOT NULL,
	[xueli] [nvarchar](50) NOT NULL,
	[biyexuexiao] [nvarchar](50) NOT NULL,
	[zhuanye] [nvarchar](50) NOT NULL,
	[jjlianxiren] [nvarchar](50) NOT NULL,
	[jjdianhua] [nvarchar](50) NOT NULL,
	[jieshaoren] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_employee] PRIMARY KEY CLUSTERED 
(
	[gonghao] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[employee] ([gonghao], [name], [qtlevel], [departmentId], [isOwner], [zhiji], [dianhua], [ruzhiTime], [jobState], [lizhiTime], [comment], [shenfenzheng], [shengriTime], [sex], [mingzujiguan], [juzhuaddress], [xueli], [biyexuexiao], [zhuanye], [jjlianxiren], [jjdianhua], [jieshaoren]) VALUES (N'FXB-WH-001', N'姚鸿', 2, 10006, 1, N'Z2', N'13816294107', 1502905591, 1, 1502905591, N'', N'421081198610050632', 1502905591, 1, N'', N'上海', N'', N'', N'', N'黄平', N'13816294107', N'')
INSERT [dbo].[employee] ([gonghao], [name], [qtlevel], [departmentId], [isOwner], [zhiji], [dianhua], [ruzhiTime], [jobState], [lizhiTime], [comment], [shenfenzheng], [shengriTime], [sex], [mingzujiguan], [juzhuaddress], [xueli], [biyexuexiao], [zhuanye], [jjlianxiren], [jjdianhua], [jieshaoren]) VALUES (N'fxb-wh-002', N'黃萍', 4, 10003, 1, N'总经理', N'13816294107', 1502905837, 1, 1502905837, N'', N'5698422355', 1502819437, 0, N'', N'傷害', N'', N'', N'', N'555', N'555', N'')
INSERT [dbo].[employee] ([gonghao], [name], [qtlevel], [departmentId], [isOwner], [zhiji], [dianhua], [ruzhiTime], [jobState], [lizhiTime], [comment], [shenfenzheng], [shengriTime], [sex], [mingzujiguan], [juzhuaddress], [xueli], [biyexuexiao], [zhuanye], [jjlianxiren], [jjdianhua], [jieshaoren]) VALUES (N'FXB-WH-004', N'姚鸿(正式)', 0, 10039, 1, N'M2', N'13872432688', 1502909692, 0, 1503600892, N'dasdasdadasd', N'421081198610050632', 528836092, 1, N'湖北-汉族', N'上海市', N'本科', N'武汉大学', N'计算机通信', N'姚喜松', N'13872432688', N'黄平')
INSERT [dbo].[employee] ([gonghao], [name], [qtlevel], [departmentId], [isOwner], [zhiji], [dianhua], [ruzhiTime], [jobState], [lizhiTime], [comment], [shenfenzheng], [shengriTime], [sex], [mingzujiguan], [juzhuaddress], [xueli], [biyexuexiao], [zhuanye], [jjlianxiren], [jjdianhua], [jieshaoren]) VALUES (N'FXB-WH-005', N'黄平', 4, 10043, 1, N'总经理', N'13816294107', 1503514852, 0, 1502910052, N'我媳妇儿', N'421081198610050931', 648673252, 0, N'湖北-汉族', N'鄂州市', N'本科', N'核电学院', N'核电', N'姚鸿', N'13816294107', N'石头哥哥')
INSERT [dbo].[employee] ([gonghao], [name], [qtlevel], [departmentId], [isOwner], [zhiji], [dianhua], [ruzhiTime], [jobState], [lizhiTime], [comment], [shenfenzheng], [shengriTime], [sex], [mingzujiguan], [juzhuaddress], [xueli], [biyexuexiao], [zhuanye], [jjlianxiren], [jjdianhua], [jieshaoren]) VALUES (N'FXB-WH-006', N'白忠凯', 6, 10038, 1, N'总经理', N'13816294107', 1502935511, 1, 1503540311, N'', N'421081198610050632', 1502935511, 1, N'维族', N'兰州', N'本科', N'复旦大学', N'计算机', N'XXX', N'133224123123', N'姚鸿')
INSERT [dbo].[employee] ([gonghao], [name], [qtlevel], [departmentId], [isOwner], [zhiji], [dianhua], [ruzhiTime], [jobState], [lizhiTime], [comment], [shenfenzheng], [shengriTime], [sex], [mingzujiguan], [juzhuaddress], [xueli], [biyexuexiao], [zhuanye], [jjlianxiren], [jjdianhua], [jieshaoren]) VALUES (N'FXB-WH-007', N'张超', 0, 10041, 0, N'M2', N'13816294107', 1502775300, 1, 1502948100, N'同事', N'421081198610050632', 1502948100, 1, N'汉族', N'上海1', N'本科', N'华中科技大学1', N'计算机通信11', N'姚鸿11', N'13872432688', N'姚鸿123')
/****** Object:  Table [dbo].[department]    Script Date: 08/21/2017 18:02:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[department](
	[id] [bigint] IDENTITY(10000,1) NOT NULL,
	[nid] [bigint] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[owner] [nvarchar](50) NULL,
	[qtlevel] [int] NOT NULL,
 CONSTRAINT [PK_department] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[department] ON
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10001, 0, N'房小白', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10002, 10001, N'执行一部', N'', 4)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10003, 10001, N'执行二部', N'', 4)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10005, 10002, N'A组11111', N'', 3)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10006, 10005, N'A1小主管', N'', 2)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10007, 10005, N'A2', N'', 2)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10008, 10005, N'A3', N'', 2)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10010, 10005, N'A4', N'', 2)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10011, 10003, N'A', N'', 3)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10017, 10005, N'A5', N'', 2)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10024, 10002, N'B组', N'', 3)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10025, 10024, N'B组1', N'', 2)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10028, 10003, N'D组1', N'', 3)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10029, 10011, N'A1', N'', 2)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10032, 10002, N'A1', N'', 3)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10036, 10001, N'驻场AAAA', N'', 7)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10038, 10036, N'1-1', N'', 6)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10039, 10001, N'后勤', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10040, 10028, N'D1', N'', 2)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10041, 10039, N'后勤1', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10042, 10005, N'ssssss122', N'', 2)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10043, 10001, N'd1111', N'', 4)
SET IDENTITY_INSERT [dbo].[department] OFF
