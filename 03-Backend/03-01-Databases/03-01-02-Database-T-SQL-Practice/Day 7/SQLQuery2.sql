USE [ITI]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 8/21/2022 6:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[Crs_Id] [int] NOT NULL,
	[Crs_Name] [nvarchar](50) NULL,
	[Crs_Duration] [int] NULL,
	[Top_Id] [int] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Crs_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stud_Course]    Script Date: 8/21/2022 6:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stud_Course](
	[Crs_Id] [int] NOT NULL,
	[St_Id] [int] NOT NULL,
	[Grade] [int] NULL,
 CONSTRAINT [PK_Stud_Course] PRIMARY KEY CLUSTERED 
(
	[Crs_Id] ASC,
	[St_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 8/21/2022 6:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[St_Id] [int] NOT NULL,
	[St_Fname] [nvarchar](50) NULL,
	[St_Lname] [nchar](10) NULL,
	[St_Address] [nvarchar](100) NULL,
	[St_Age] [int] NULL,
	[Dept_Id] [int] NULL,
	[St_super] [int] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[St_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VstudCrs]    Script Date: 8/21/2022 6:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[VstudCrs]
as
	select concat(s.St_Fname,' ',s.St_Lname) fullName, c.Crs_Name
	from student s inner join Stud_Course sc on s.St_Id = sc.St_Id
	and sc.Grade > 50
	inner join Course c on c.Crs_Id = sc.Crs_Id
GO
/****** Object:  Table [dbo].[Topic]    Script Date: 8/21/2022 6:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topic](
	[Top_Id] [int] NOT NULL,
	[Top_Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Topic] PRIMARY KEY CLUSTERED 
(
	[Top_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ins_Course]    Script Date: 8/21/2022 6:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ins_Course](
	[Ins_Id] [int] NOT NULL,
	[Crs_Id] [int] NOT NULL,
	[Evaluation] [nvarchar](50) NULL,
 CONSTRAINT [PK_Ins_Course] PRIMARY KEY CLUSTERED 
(
	[Ins_Id] ASC,
	[Crs_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Instructor]    Script Date: 8/21/2022 6:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instructor](
	[Ins_Id] [int] NOT NULL,
	[Ins_Name] [nvarchar](50) NULL,
	[Ins_Degree] [nvarchar](50) NULL,
	[Salary] [money] NULL,
	[Dept_Id] [int] NULL,
 CONSTRAINT [PK_Instructor] PRIMARY KEY CLUSTERED 
(
	[Ins_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 8/21/2022 6:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Dept_Id] [int] NOT NULL,
	[Dept_Name] [nvarchar](50) NULL,
	[Dept_Desc] [nvarchar](100) NULL,
	[Dept_Location] [nvarchar](50) NULL,
	[Dept_Manager] [int] NULL,
	[Manager_hiredate] [date] NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Dept_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VMngTopic]    Script Date: 8/21/2022 6:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[VMngTopic] (Manager, Topic)
--with encryption
as
	select distinct i.Ins_Name, t.Top_Name
	from Department d inner join Instructor i on i.Ins_Id = d.Dept_Manager
	inner join Ins_Course ic on i.Ins_Id = ic.Ins_Id
	inner join Course c on c.Crs_Id = ic.Crs_Id
	inner join Topic t on t.Top_Id = c.Top_Id
GO
/****** Object:  View [dbo].[VInsDept]    Script Date: 8/21/2022 6:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[VInsDept] (Ins_name, Dept_name)
as
	select i.Ins_Name, d.Dept_Name
	from Department d inner join Instructor i
	on d.Dept_Id = i.Dept_Id and d.Dept_Name in ('SD','Java')
	with check option
GO
/****** Object:  View [dbo].[V1]    Script Date: 8/21/2022 6:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[V1]
as
	select * from Student
	where St_Address in ('Alex','Cairo')
	with check option
GO
/****** Object:  Table [dbo].[DailyTransactions]    Script Date: 8/21/2022 6:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DailyTransactions](
	[id] [int] NULL,
	[amount] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LastTransactions]    Script Date: 8/21/2022 6:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LastTransactions](
	[id] [int] NULL,
	[amount] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SimpleDemo]    Script Date: 8/21/2022 6:02:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SimpleDemo](
	[Node] [hierarchyid] NOT NULL,
	[Geographical Name] [nvarchar](30) NOT NULL,
	[Geographical Type] [nvarchar](9) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Topic] FOREIGN KEY([Top_Id])
REFERENCES [dbo].[Topic] ([Top_Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Topic]
GO
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_Department_Instructor] FOREIGN KEY([Dept_Manager])
REFERENCES [dbo].[Instructor] ([Ins_Id])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_Department_Instructor]
GO
ALTER TABLE [dbo].[Ins_Course]  WITH CHECK ADD  CONSTRAINT [FK_Ins_Course_Course] FOREIGN KEY([Crs_Id])
REFERENCES [dbo].[Course] ([Crs_Id])
GO
ALTER TABLE [dbo].[Ins_Course] CHECK CONSTRAINT [FK_Ins_Course_Course]
GO
ALTER TABLE [dbo].[Ins_Course]  WITH CHECK ADD  CONSTRAINT [FK_Ins_Course_Instructor] FOREIGN KEY([Ins_Id])
REFERENCES [dbo].[Instructor] ([Ins_Id])
GO
ALTER TABLE [dbo].[Ins_Course] CHECK CONSTRAINT [FK_Ins_Course_Instructor]
GO
ALTER TABLE [dbo].[Instructor]  WITH CHECK ADD  CONSTRAINT [FK_Instructor_Department] FOREIGN KEY([Dept_Id])
REFERENCES [dbo].[Department] ([Dept_Id])
GO
ALTER TABLE [dbo].[Instructor] CHECK CONSTRAINT [FK_Instructor_Department]
GO
ALTER TABLE [dbo].[Stud_Course]  WITH CHECK ADD  CONSTRAINT [FK_Stud_Course_Course] FOREIGN KEY([Crs_Id])
REFERENCES [dbo].[Course] ([Crs_Id])
GO
ALTER TABLE [dbo].[Stud_Course] CHECK CONSTRAINT [FK_Stud_Course_Course]
GO
ALTER TABLE [dbo].[Stud_Course]  WITH CHECK ADD  CONSTRAINT [FK_Stud_Course_Student] FOREIGN KEY([St_Id])
REFERENCES [dbo].[Student] ([St_Id])
GO
ALTER TABLE [dbo].[Stud_Course] CHECK CONSTRAINT [FK_Stud_Course_Student]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Department] FOREIGN KEY([Dept_Id])
REFERENCES [dbo].[Department] ([Dept_Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Department]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Student] FOREIGN KEY([St_super])
REFERENCES [dbo].[Student] ([St_Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Student]
GO
