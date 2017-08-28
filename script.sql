USE [MFXB]
GO
/****** Object:  Table [dbo].[dxduplicate]    Script Date: 08/28/2017 20:23:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dxduplicate](
	[jobnumber] [nvarchar](50) NOT NULL,
	[basicsalary] [float] NOT NULL,
	[dxkey] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
CREATE UNIQUE CLUSTERED INDEX [key_jobnumber] ON [dbo].[dxduplicate] 
(
	[dxkey] ASC,
	[jobnumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'ddddddd', 3100, N'2017-07')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'FXB-WH-001', 1800, N'2017-07')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'fxb-wh-002', 1800, N'2017-07')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'FXB-WH-004', 3100, N'2017-07')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'FXB-WH-005', 0, N'2017-07')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'FXB-WH-006', 0, N'2017-07')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'FXB-WH-007', 3100, N'2017-07')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'FXB-WH-019', 3100, N'2017-07')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'FXB-WH-001', 1800, N'2017-08')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'fxb-wh-002', 0, N'2017-08')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'FXB-WH-004', 3100, N'2017-08')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'FXB-WH-005', 0, N'2017-08')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'FXB-WH-006', 0, N'2017-08')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'FXB-WH-007', 3100, N'2017-08')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'FXB-WH-019', 3100, N'2017-08')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'FXB-WH-001', 1800, N'2017-09')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'fxb-wh-002', 1800, N'2017-09')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'FXB-WH-004', 3100, N'2017-09')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'FXB-WH-005', 0, N'2017-09')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'FXB-WH-006', 0, N'2017-09')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'FXB-WH-007', 3100, N'2017-09')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'FXB-WH-019', 3100, N'2017-09')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'FXB-WH-001', 1800, N'2017-10')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'fxb-wh-002', 1800, N'2017-10')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'FXB-WH-004', 3100, N'2017-10')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'FXB-WH-005', 0, N'2017-10')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'FXB-WH-006', 0, N'2017-10')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'FXB-WH-007', 3100, N'2017-10')
INSERT [dbo].[dxduplicate] ([jobnumber], [basicsalary], [dxkey]) VALUES (N'FXB-WH-019', 3100, N'2017-10')
/****** Object:  Table [dbo].[department]    Script Date: 08/28/2017 20:23:30 ******/
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
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10044, 10043, N'1111', N'', 3)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10045, 10044, N'1', N'', 2)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10046, 10044, N'2', N'', 2)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10047, 10044, N'3', N'', 2)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10048, 10001, N'd22222', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10049, 10048, N'11111', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10050, 10049, N'111', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10051, 10049, N'222', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10052, 10049, N'333', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10053, 10049, N'444', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10054, 10049, N'5555', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10055, 10049, N'6666', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10056, 10049, N'7777', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10057, 10001, N'dddd', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10058, 10057, N'111', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10059, 10057, N'222', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10060, 10057, N'333', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10061, 10058, N'1111', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10062, 10058, N'2222', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10063, 10058, N'3333', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10064, 10058, N'4444', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10065, 10059, N'1111', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10066, 10059, N'2222', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10067, 10059, N'3333', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10068, 10059, N'444', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10069, 10060, N'1111', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10070, 10060, N'111', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10071, 10060, N'22222', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10072, 10060, N'33333', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10073, 10060, N'3333', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10074, 10060, N'333', N'', 0)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10075, 10011, N'33333', N'', 2)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10076, 10011, N'4444', N'', 2)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10077, 10011, N'44444', N'', 2)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10078, 10011, N'55555', N'', 2)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10079, 10011, N'666', N'', 2)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10080, 10011, N'77777', N'', 2)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10081, 10011, N'8888', N'', 2)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10082, 10011, N'9999', N'', 2)
INSERT [dbo].[department] ([id], [nid], [name], [owner], [qtlevel]) VALUES (10083, 10011, N'00000', N'', 2)
SET IDENTITY_INSERT [dbo].[department] OFF
/****** Object:  Table [dbo].[project]    Script Date: 08/28/2017 20:23:31 ******/
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
/****** Object:  Table [dbo].[jobgrade]    Script Date: 08/28/2017 20:23:31 ******/
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
/****** Object:  Table [dbo].[qttaskindex]    Script Date: 08/28/2017 20:23:31 ******/
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
INSERT [dbo].[qttaskindex] ([qtkey], [closing], [rootqtdepartmentid]) VALUES (N'2017-08', 0, 10001)
INSERT [dbo].[qttaskindex] ([qtkey], [closing], [rootqtdepartmentid]) VALUES (N'2017-09', 0, 10001)
INSERT [dbo].[qttaskindex] ([qtkey], [closing], [rootqtdepartmentid]) VALUES (N'2017-10', 0, 10001)
/****** Object:  Table [dbo].[qttaskorder]    Script Date: 08/28/2017 20:23:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[qttaskorder](
	[id] [bigint] IDENTITY(100000,1) NOT NULL,
	[generatetime] [int] NOT NULL,
	[commissionamount] [float] NOT NULL,
	[customername] [nvarchar](50) NOT NULL,
	[projectcode] [nvarchar](50) NOT NULL,
	[roomnumber] [nvarchar](50) NOT NULL,
	[closingthedealnoney] [float] NOT NULL,
	[yxconsultantjobnumber] [nvarchar](50) NOT NULL,
	[yxqtdepartmentid] [bigint] NOT NULL,
	[kyfconsultanjobnumber] [nvarchar](50) NOT NULL,
	[kyfqtdepartmentid] [bigint] NOT NULL,
	[zc1jobnumber] [nvarchar](50) NOT NULL,
	[zc1qtdepartmentid] [bigint] NOT NULL,
	[zc2jobnumber] [nvarchar](50) NOT NULL,
	[zc2qtdepartmentid] [bigint] NOT NULL,
	[checkstate] [bit] NOT NULL,
	[checkpersonjobnumber] [nvarchar](50) NOT NULL,
	[checktime] [int] NOT NULL,
	[ifchargeback] [bit] NOT NULL,
	[cbjobnumber] [nvarchar](50) NOT NULL,
	[cbtime] [int] NOT NULL,
	[entrypersonjobnumber] [nvarchar](50) NOT NULL,
	[comment] [nvarchar](512) NOT NULL,
	[buytime] [int] NOT NULL,
	[customerphone] [nvarchar](50) NOT NULL,
	[customeridcard] [nvarchar](50) NOT NULL,
	[receipt] [nvarchar](50) NOT NULL,
	[roomarea] [float] NOT NULL,
	[contractstate] [nvarchar](50) NOT NULL,
	[paymentmethod] [nvarchar](50) NOT NULL,
	[loansmoney] [float] NOT NULL,
	[isreceivereward] [bit] NOT NULL,
	[qtkey] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_qttaskorder] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[qttaskorder] ON
INSERT [dbo].[qttaskorder] ([id], [generatetime], [commissionamount], [customername], [projectcode], [roomnumber], [closingthedealnoney], [yxconsultantjobnumber], [yxqtdepartmentid], [kyfconsultanjobnumber], [kyfqtdepartmentid], [zc1jobnumber], [zc1qtdepartmentid], [zc2jobnumber], [zc2qtdepartmentid], [checkstate], [checkpersonjobnumber], [checktime], [ifchargeback], [cbjobnumber], [cbtime], [entrypersonjobnumber], [comment], [buytime], [customerphone], [customeridcard], [receipt], [roomarea], [contractstate], [paymentmethod], [loansmoney], [isreceivereward], [qtkey]) VALUES (100000, 1503890980, 78000.32, N'姚鸿', N'A002', N'1556', 7800000, N'FXB-TEST', 10040, N'fxb-wh-002', 10003, N'FXB-TEST2', 10038, N'', 0, 0, N'', 0, 0, N'', 0, N'owner', N'', 1503804580, N'姚鸿', N'421081198610050632', N'收据', 156.65, N'合同状态', N'付款方式', 789000.65, 0, N'2017-08')
INSERT [dbo].[qttaskorder] ([id], [generatetime], [commissionamount], [customername], [projectcode], [roomnumber], [closingthedealnoney], [yxconsultantjobnumber], [yxqtdepartmentid], [kyfconsultanjobnumber], [kyfqtdepartmentid], [zc1jobnumber], [zc1qtdepartmentid], [zc2jobnumber], [zc2qtdepartmentid], [checkstate], [checkpersonjobnumber], [checktime], [ifchargeback], [cbjobnumber], [cbtime], [entrypersonjobnumber], [comment], [buytime], [customerphone], [customeridcard], [receipt], [roomarea], [contractstate], [paymentmethod], [loansmoney], [isreceivereward], [qtkey]) VALUES (100001, 1503891220, 65400.22, N'姚鸿', N'A002', N'1556', 1800000, N'FXB-WH-001', 10006, N'FXB-WH-007', 10008, N'FXB-TEST2', 10038, N'', 0, 0, N'', 0, 0, N'', 0, N'owner', N'', 1503804820, N'姚鸿', N'421081198610050632', N'收据', 89.63, N'合同状态', N'付款方式', 780000, 0, N'2017-08')
INSERT [dbo].[qttaskorder] ([id], [generatetime], [commissionamount], [customername], [projectcode], [roomnumber], [closingthedealnoney], [yxconsultantjobnumber], [yxqtdepartmentid], [kyfconsultanjobnumber], [kyfqtdepartmentid], [zc1jobnumber], [zc1qtdepartmentid], [zc2jobnumber], [zc2qtdepartmentid], [checkstate], [checkpersonjobnumber], [checktime], [ifchargeback], [cbjobnumber], [cbtime], [entrypersonjobnumber], [comment], [buytime], [customerphone], [customeridcard], [receipt], [roomarea], [contractstate], [paymentmethod], [loansmoney], [isreceivereward], [qtkey]) VALUES (100002, 1501749305, 89600, N'姚鸿', N'A002', N'1005', 1800000, N'ddddddd', 10011, N'FXB-TEST', 10040, N'FXB-TEST2', 10038, N'', 0, 0, N'', 0, 0, N'', 0, N'owner', N'', 1503822905, N'姚鸿', N'421081198610050632', N'收据', 63.55, N'合同状态', N'付款方式1', 698880, 0, N'2017-08')
INSERT [dbo].[qttaskorder] ([id], [generatetime], [commissionamount], [customername], [projectcode], [roomnumber], [closingthedealnoney], [yxconsultantjobnumber], [yxqtdepartmentid], [kyfconsultanjobnumber], [kyfqtdepartmentid], [zc1jobnumber], [zc1qtdepartmentid], [zc2jobnumber], [zc2qtdepartmentid], [checkstate], [checkpersonjobnumber], [checktime], [ifchargeback], [cbjobnumber], [cbtime], [entrypersonjobnumber], [comment], [buytime], [customerphone], [customeridcard], [receipt], [roomarea], [contractstate], [paymentmethod], [loansmoney], [isreceivereward], [qtkey]) VALUES (100003, 1503909914, 65000.63, N'姚鸿', N'A002', N'10009', 1800000, N'FXB-WH-001', 10006, N'FXB-TEST', 10040, N'FXB-TEST2', 10038, N'', 0, 0, N'', 0, 0, N'', 0, N'owner', N'', 1503823514, N'姚鸿', N'421081198610050632', N'收据', 96.36, N'合同状态', N'付款方式', 680000, 0, N'2017-08')
SET IDENTITY_INSERT [dbo].[qttaskorder] OFF
/****** Object:  Table [dbo].[qttaskemployee]    Script Date: 08/28/2017 20:23:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[qttaskemployee](
	[jobnumber] [nvarchar](50) NOT NULL,
	[jobgradename] [nvarchar](50) NOT NULL,
	[departmentid] [bigint] NOT NULL,
	[qtlevel] [int] NOT NULL,
	[isowner] [bit] NOT NULL,
	[qtkey] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
CREATE UNIQUE CLUSTERED INDEX [key_jobnumber] ON [dbo].[qttaskemployee] 
(
	[qtkey] ASC,
	[jobnumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
INSERT [dbo].[qttaskemployee] ([jobnumber], [jobgradename], [departmentid], [qtlevel], [isowner], [qtkey]) VALUES (N'ddddddd', N'M2', 10011, 3, 1, N'2017-08')
INSERT [dbo].[qttaskemployee] ([jobnumber], [jobgradename], [departmentid], [qtlevel], [isowner], [qtkey]) VALUES (N'FXB-WH-001', N'Z2', 10006, 2, 1, N'2017-08')
INSERT [dbo].[qttaskemployee] ([jobnumber], [jobgradename], [departmentid], [qtlevel], [isowner], [qtkey]) VALUES (N'fxb-wh-002', N'Z2', 10003, 4, 1, N'2017-08')
INSERT [dbo].[qttaskemployee] ([jobnumber], [jobgradename], [departmentid], [qtlevel], [isowner], [qtkey]) VALUES (N'FXB-WH-005', N'总经理', 10043, 4, 1, N'2017-08')
INSERT [dbo].[qttaskemployee] ([jobnumber], [jobgradename], [departmentid], [qtlevel], [isowner], [qtkey]) VALUES (N'FXB-WH-006', N'总经理', 10038, 6, 1, N'2017-08')
INSERT [dbo].[qttaskemployee] ([jobnumber], [jobgradename], [departmentid], [qtlevel], [isowner], [qtkey]) VALUES (N'FXB-WH-007', N'M2', 10008, 1, 0, N'2017-08')
INSERT [dbo].[qttaskemployee] ([jobnumber], [jobgradename], [departmentid], [qtlevel], [isowner], [qtkey]) VALUES (N'ddddddd', N'M2', 10011, 3, 1, N'2017-09')
INSERT [dbo].[qttaskemployee] ([jobnumber], [jobgradename], [departmentid], [qtlevel], [isowner], [qtkey]) VALUES (N'FXB-TEST', N'M2', 10040, 2, 1, N'2017-09')
INSERT [dbo].[qttaskemployee] ([jobnumber], [jobgradename], [departmentid], [qtlevel], [isowner], [qtkey]) VALUES (N'FXB-WH-001', N'Z2', 10006, 2, 1, N'2017-09')
INSERT [dbo].[qttaskemployee] ([jobnumber], [jobgradename], [departmentid], [qtlevel], [isowner], [qtkey]) VALUES (N'fxb-wh-002', N'Z2', 10003, 4, 1, N'2017-09')
INSERT [dbo].[qttaskemployee] ([jobnumber], [jobgradename], [departmentid], [qtlevel], [isowner], [qtkey]) VALUES (N'FXB-WH-005', N'总经理', 10043, 4, 1, N'2017-09')
INSERT [dbo].[qttaskemployee] ([jobnumber], [jobgradename], [departmentid], [qtlevel], [isowner], [qtkey]) VALUES (N'FXB-WH-006', N'总经理', 10038, 6, 1, N'2017-09')
INSERT [dbo].[qttaskemployee] ([jobnumber], [jobgradename], [departmentid], [qtlevel], [isowner], [qtkey]) VALUES (N'FXB-WH-007', N'M2', 10008, 1, 0, N'2017-09')
INSERT [dbo].[qttaskemployee] ([jobnumber], [jobgradename], [departmentid], [qtlevel], [isowner], [qtkey]) VALUES (N'ddddddd', N'M2', 10011, 3, 1, N'2017-10')
INSERT [dbo].[qttaskemployee] ([jobnumber], [jobgradename], [departmentid], [qtlevel], [isowner], [qtkey]) VALUES (N'FXB-TEST', N'M2', 10040, 1, 0, N'2017-10')
INSERT [dbo].[qttaskemployee] ([jobnumber], [jobgradename], [departmentid], [qtlevel], [isowner], [qtkey]) VALUES (N'FXB-TEST2', N'Z2', 10038, 5, 0, N'2017-10')
INSERT [dbo].[qttaskemployee] ([jobnumber], [jobgradename], [departmentid], [qtlevel], [isowner], [qtkey]) VALUES (N'FXB-WH-001', N'Z2', 10006, 2, 1, N'2017-10')
INSERT [dbo].[qttaskemployee] ([jobnumber], [jobgradename], [departmentid], [qtlevel], [isowner], [qtkey]) VALUES (N'fxb-wh-002', N'Z2', 10003, 4, 1, N'2017-10')
INSERT [dbo].[qttaskemployee] ([jobnumber], [jobgradename], [departmentid], [qtlevel], [isowner], [qtkey]) VALUES (N'FXB-WH-005', N'总经理', 10043, 4, 1, N'2017-10')
INSERT [dbo].[qttaskemployee] ([jobnumber], [jobgradename], [departmentid], [qtlevel], [isowner], [qtkey]) VALUES (N'FXB-WH-006', N'总经理', 10038, 6, 1, N'2017-10')
INSERT [dbo].[qttaskemployee] ([jobnumber], [jobgradename], [departmentid], [qtlevel], [isowner], [qtkey]) VALUES (N'FXB-WH-007', N'M2', 10008, 1, 0, N'2017-10')
/****** Object:  Table [dbo].[qttaskdepartment]    Script Date: 08/28/2017 20:23:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[qttaskdepartment](
	[qtdepartmentid] [bigint] NOT NULL,
	[qtlevel] [int] NOT NULL,
	[ownerjobnumber] [nvarchar](50) NOT NULL,
	[qtdepartmentname] [nvarchar](50) NOT NULL,
	[parentdepartmentid] [bigint] NOT NULL,
	[needcompletetaskamount] [float] NOT NULL,
	[qtkey] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
CREATE UNIQUE CLUSTERED INDEX [key_id] ON [dbo].[qttaskdepartment] 
(
	[qtkey] ASC,
	[qtdepartmentid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10001, 0, N'', N'房小白', 0, 50000, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10002, 4, N'', N'执行一部', 10001, 20000, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10003, 4, N'fxb-wh-002', N'执行二部', 10001, 20000, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10005, 3, N'', N'A组11111', 10002, 20000, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10006, 2, N'FXB-WH-001', N'A1小主管', 10005, 10000, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10007, 2, N'', N'A2', 10005, 0, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10008, 2, N'', N'A3', 10005, 10000, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10010, 2, N'', N'A4', 10005, 0, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10011, 3, N'ddddddd', N'A', 10003, 10000, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10017, 2, N'', N'A5', 10005, 0, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10024, 3, N'', N'B组', 10002, 0, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10025, 2, N'', N'B组1', 10024, 0, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10028, 3, N'', N'D组1', 10003, 0, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10029, 2, N'', N'A1', 10011, 0, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10032, 3, N'', N'A1', 10002, 0, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10036, 7, N'', N'驻场AAAA', 10001, 0, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10038, 6, N'FXB-WH-006', N'1-1', 10036, 0, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10040, 2, N'', N'D1', 10028, 0, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10042, 2, N'', N'ssssss122', 10005, 0, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10043, 4, N'FXB-WH-005', N'd1111', 10001, 10000, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10044, 3, N'', N'1111', 10043, 0, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10045, 2, N'', N'1', 10044, 0, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10046, 2, N'', N'2', 10044, 0, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10047, 2, N'', N'3', 10044, 0, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10075, 2, N'', N'33333', 10011, 0, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10076, 2, N'', N'4444', 10011, 0, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10077, 2, N'', N'44444', 10011, 0, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10078, 2, N'', N'55555', 10011, 0, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10079, 2, N'', N'666', 10011, 0, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10080, 2, N'', N'77777', 10011, 0, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10081, 2, N'', N'8888', 10011, 0, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10082, 2, N'', N'9999', 10011, 0, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10083, 2, N'', N'00000', 10011, 0, N'2017-08')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10001, 0, N'', N'房小白', 0, 60000, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10002, 4, N'', N'执行一部', 10001, 20000, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10003, 4, N'fxb-wh-002', N'执行二部', 10001, 30000, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10005, 3, N'', N'A组11111', 10002, 20000, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10006, 2, N'FXB-WH-001', N'A1小主管', 10005, 10000, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10007, 2, N'', N'A2', 10005, 0, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10008, 2, N'', N'A3', 10005, 10000, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10010, 2, N'', N'A4', 10005, 0, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10011, 3, N'ddddddd', N'A', 10003, 10000, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10017, 2, N'', N'A5', 10005, 0, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10024, 3, N'', N'B组', 10002, 0, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10025, 2, N'', N'B组1', 10024, 0, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10028, 3, N'', N'D组1', 10003, 10000, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10029, 2, N'', N'A1', 10011, 0, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10032, 3, N'', N'A1', 10002, 0, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10036, 7, N'', N'驻场AAAA', 10001, 0, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10038, 6, N'FXB-WH-006', N'1-1', 10036, 0, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10040, 2, N'FXB-TEST', N'D1', 10028, 10000, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10042, 2, N'', N'ssssss122', 10005, 0, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10043, 4, N'FXB-WH-005', N'd1111', 10001, 10000, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10044, 3, N'', N'1111', 10043, 0, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10045, 2, N'', N'1', 10044, 0, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10046, 2, N'', N'2', 10044, 0, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10047, 2, N'', N'3', 10044, 0, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10075, 2, N'', N'33333', 10011, 0, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10076, 2, N'', N'4444', 10011, 0, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10077, 2, N'', N'44444', 10011, 0, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10078, 2, N'', N'55555', 10011, 0, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10079, 2, N'', N'666', 10011, 0, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10080, 2, N'', N'77777', 10011, 0, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10081, 2, N'', N'8888', 10011, 0, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10082, 2, N'', N'9999', 10011, 0, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10083, 2, N'', N'00000', 10011, 0, N'2017-09')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10001, 0, N'', N'房小白', 0, 60000, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10002, 4, N'', N'执行一部', 10001, 20000, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10003, 4, N'fxb-wh-002', N'执行二部', 10001, 30000, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10005, 3, N'', N'A组11111', 10002, 20000, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10006, 2, N'FXB-WH-001', N'A1小主管', 10005, 10000, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10007, 2, N'', N'A2', 10005, 0, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10008, 2, N'', N'A3', 10005, 10000, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10010, 2, N'', N'A4', 10005, 0, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10011, 3, N'ddddddd', N'A', 10003, 10000, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10017, 2, N'', N'A5', 10005, 0, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10024, 3, N'', N'B组', 10002, 0, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10025, 2, N'', N'B组1', 10024, 0, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10028, 3, N'', N'D组1', 10003, 10000, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10029, 2, N'', N'A1', 10011, 0, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10032, 3, N'', N'A1', 10002, 0, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10036, 7, N'', N'驻场AAAA', 10001, 0, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10038, 6, N'FXB-WH-006', N'1-1', 10036, 0, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10040, 2, N'', N'D1', 10028, 10000, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10042, 2, N'', N'ssssss122', 10005, 0, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10043, 4, N'FXB-WH-005', N'd1111', 10001, 10000, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10044, 3, N'', N'1111', 10043, 0, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10045, 2, N'', N'1', 10044, 0, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10046, 2, N'', N'2', 10044, 0, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10047, 2, N'', N'3', 10044, 0, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10075, 2, N'', N'33333', 10011, 0, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10076, 2, N'', N'4444', 10011, 0, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10077, 2, N'', N'44444', 10011, 0, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10078, 2, N'', N'55555', 10011, 0, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10079, 2, N'', N'666', 10011, 0, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10080, 2, N'', N'77777', 10011, 0, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10081, 2, N'', N'8888', 10011, 0, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10082, 2, N'', N'9999', 10011, 0, N'2017-10')
INSERT [dbo].[qttaskdepartment] ([qtdepartmentid], [qtlevel], [ownerjobnumber], [qtdepartmentname], [parentdepartmentid], [needcompletetaskamount], [qtkey]) VALUES (10083, 2, N'', N'00000', 10011, 0, N'2017-10')
/****** Object:  Table [dbo].[employee]    Script Date: 08/28/2017 20:23:31 ******/
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
INSERT [dbo].[employee] ([gonghao], [name], [qtlevel], [departmentId], [isOwner], [zhiji], [dianhua], [ruzhiTime], [jobState], [lizhiTime], [comment], [shenfenzheng], [shengriTime], [sex], [mingzujiguan], [juzhuaddress], [xueli], [biyexuexiao], [zhuanye], [jjlianxiren], [jjdianhua], [jieshaoren]) VALUES (N'ddddddd', N'ddddd', 3, 10011, 1, N'M2', N'13816294107', 1503468395, 1, 1503468395, N'', N'', 1503468395, 0, N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[employee] ([gonghao], [name], [qtlevel], [departmentId], [isOwner], [zhiji], [dianhua], [ruzhiTime], [jobState], [lizhiTime], [comment], [shenfenzheng], [shengriTime], [sex], [mingzujiguan], [juzhuaddress], [xueli], [biyexuexiao], [zhuanye], [jjlianxiren], [jjdianhua], [jieshaoren]) VALUES (N'FXB-TEST', N'樊哥', 1, 10040, 0, N'M2', N'13816294107', 1503633978, 1, 1503633978, N'', N'', 1503633978, 0, N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[employee] ([gonghao], [name], [qtlevel], [departmentId], [isOwner], [zhiji], [dianhua], [ruzhiTime], [jobState], [lizhiTime], [comment], [shenfenzheng], [shengriTime], [sex], [mingzujiguan], [juzhuaddress], [xueli], [biyexuexiao], [zhuanye], [jjlianxiren], [jjdianhua], [jieshaoren]) VALUES (N'FXB-TEST2', N'小万', 5, 10038, 0, N'Z2', N'133331133', 1503641894, 1, 1503641894, N'', N'', 1503641894, 0, N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[employee] ([gonghao], [name], [qtlevel], [departmentId], [isOwner], [zhiji], [dianhua], [ruzhiTime], [jobState], [lizhiTime], [comment], [shenfenzheng], [shengriTime], [sex], [mingzujiguan], [juzhuaddress], [xueli], [biyexuexiao], [zhuanye], [jjlianxiren], [jjdianhua], [jieshaoren]) VALUES (N'FXB-WH-001', N'姚鸿', 2, 10006, 1, N'Z2', N'13816294107', 1502905591, 1, 1502905591, N'', N'421081198610050632', 1502905591, 1, N'', N'上海', N'', N'', N'', N'黄平', N'13816294107', N'')
INSERT [dbo].[employee] ([gonghao], [name], [qtlevel], [departmentId], [isOwner], [zhiji], [dianhua], [ruzhiTime], [jobState], [lizhiTime], [comment], [shenfenzheng], [shengriTime], [sex], [mingzujiguan], [juzhuaddress], [xueli], [biyexuexiao], [zhuanye], [jjlianxiren], [jjdianhua], [jieshaoren]) VALUES (N'fxb-wh-002', N'黃萍', 4, 10003, 1, N'Z2', N'13816294107', 1502905837, 1, 1502905837, N'', N'5698422355', 1502819437, 0, N'', N'傷害', N'', N'', N'', N'555', N'555', N'')
INSERT [dbo].[employee] ([gonghao], [name], [qtlevel], [departmentId], [isOwner], [zhiji], [dianhua], [ruzhiTime], [jobState], [lizhiTime], [comment], [shenfenzheng], [shengriTime], [sex], [mingzujiguan], [juzhuaddress], [xueli], [biyexuexiao], [zhuanye], [jjlianxiren], [jjdianhua], [jieshaoren]) VALUES (N'FXB-WH-004', N'姚鸿(正式)', 0, 10039, 1, N'M2', N'13872432688', 1502909692, 0, 1503600892, N'dasdasdadasd', N'421081198610050632', 528836092, 1, N'湖北-汉族', N'上海市', N'本科', N'武汉大学', N'计算机通信', N'姚喜松', N'13872432688', N'黄平')
INSERT [dbo].[employee] ([gonghao], [name], [qtlevel], [departmentId], [isOwner], [zhiji], [dianhua], [ruzhiTime], [jobState], [lizhiTime], [comment], [shenfenzheng], [shengriTime], [sex], [mingzujiguan], [juzhuaddress], [xueli], [biyexuexiao], [zhuanye], [jjlianxiren], [jjdianhua], [jieshaoren]) VALUES (N'FXB-WH-005', N'黄平', 4, 10043, 1, N'总经理', N'13816294107', 1503514852, 0, 1502910052, N'我媳妇儿', N'421081198610050931', 648673252, 0, N'湖北-汉族', N'鄂州市', N'本科', N'核电学院', N'核电', N'姚鸿', N'13816294107', N'石头哥哥')
INSERT [dbo].[employee] ([gonghao], [name], [qtlevel], [departmentId], [isOwner], [zhiji], [dianhua], [ruzhiTime], [jobState], [lizhiTime], [comment], [shenfenzheng], [shengriTime], [sex], [mingzujiguan], [juzhuaddress], [xueli], [biyexuexiao], [zhuanye], [jjlianxiren], [jjdianhua], [jieshaoren]) VALUES (N'FXB-WH-006', N'白忠凯', 7, 10036, 1, N'总经理', N'13816294107', 1502935511, 1, 1503540311, N'', N'421081198610050632', 1502935511, 1, N'维族', N'兰州', N'本科', N'复旦大学', N'计算机', N'XXX', N'133224123123', N'姚鸿')
INSERT [dbo].[employee] ([gonghao], [name], [qtlevel], [departmentId], [isOwner], [zhiji], [dianhua], [ruzhiTime], [jobState], [lizhiTime], [comment], [shenfenzheng], [shengriTime], [sex], [mingzujiguan], [juzhuaddress], [xueli], [biyexuexiao], [zhuanye], [jjlianxiren], [jjdianhua], [jieshaoren]) VALUES (N'FXB-WH-007', N'张超', 1, 10008, 0, N'M2', N'13816294107', 1502775300, 1, 1502948100, N'同事', N'421081198610050632', 1502948100, 1, N'汉族', N'上海1', N'本科', N'华中科技大学1', N'计算机通信11', N'姚鸿11', N'13872432688', N'姚鸿123')
INSERT [dbo].[employee] ([gonghao], [name], [qtlevel], [departmentId], [isOwner], [zhiji], [dianhua], [ruzhiTime], [jobState], [lizhiTime], [comment], [shenfenzheng], [shengriTime], [sex], [mingzujiguan], [juzhuaddress], [xueli], [biyexuexiao], [zhuanye], [jjlianxiren], [jjdianhua], [jieshaoren]) VALUES (N'FXB-WH-019', N'小万', 0, 10041, 1, N'M2', N'13872432688', 1503315694, 1, 1503315694, N'', N'421081198610050632', 1503315694, 0, N'', N'上海市', N'', N'', N'', N'TEST', N'13816294107', N'')
/****** Object:  ForeignKey [FK_employee_department]    Script Date: 08/28/2017 20:23:31 ******/
ALTER TABLE [dbo].[employee]  WITH CHECK ADD  CONSTRAINT [FK_employee_department] FOREIGN KEY([departmentId])
REFERENCES [dbo].[department] ([id])
GO
ALTER TABLE [dbo].[employee] CHECK CONSTRAINT [FK_employee_department]
GO
/****** Object:  ForeignKey [FK_qttaskdepartment_qttaskindex]    Script Date: 08/28/2017 20:23:31 ******/
ALTER TABLE [dbo].[qttaskdepartment]  WITH CHECK ADD  CONSTRAINT [FK_qttaskdepartment_qttaskindex] FOREIGN KEY([qtkey])
REFERENCES [dbo].[qttaskindex] ([qtkey])
GO
ALTER TABLE [dbo].[qttaskdepartment] CHECK CONSTRAINT [FK_qttaskdepartment_qttaskindex]
GO
/****** Object:  ForeignKey [FK_qttaskemployee_qttaskindex]    Script Date: 08/28/2017 20:23:31 ******/
ALTER TABLE [dbo].[qttaskemployee]  WITH CHECK ADD  CONSTRAINT [FK_qttaskemployee_qttaskindex] FOREIGN KEY([qtkey])
REFERENCES [dbo].[qttaskindex] ([qtkey])
GO
ALTER TABLE [dbo].[qttaskemployee] CHECK CONSTRAINT [FK_qttaskemployee_qttaskindex]
GO
/****** Object:  ForeignKey [FK_qttaskorder_qttaskindex]    Script Date: 08/28/2017 20:23:31 ******/
ALTER TABLE [dbo].[qttaskorder]  WITH CHECK ADD  CONSTRAINT [FK_qttaskorder_qttaskindex] FOREIGN KEY([qtkey])
REFERENCES [dbo].[qttaskindex] ([qtkey])
GO
ALTER TABLE [dbo].[qttaskorder] CHECK CONSTRAINT [FK_qttaskorder_qttaskindex]
GO
