/****** Object:  Database [kuade-Exam]    Script Date: 2021/11/16 14:06:52 ******/
CREATE DATABASE [kuade-Exam]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'kuade-Exam', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\kuade-Exam.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'kuade-Exam_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\kuade-Exam_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [kuade-Exam] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [kuade-Exam].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [kuade-Exam] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [kuade-Exam] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [kuade-Exam] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [kuade-Exam] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [kuade-Exam] SET ARITHABORT OFF 
GO
ALTER DATABASE [kuade-Exam] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [kuade-Exam] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [kuade-Exam] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [kuade-Exam] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [kuade-Exam] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [kuade-Exam] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [kuade-Exam] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [kuade-Exam] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [kuade-Exam] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [kuade-Exam] SET  DISABLE_BROKER 
GO
ALTER DATABASE [kuade-Exam] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [kuade-Exam] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [kuade-Exam] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [kuade-Exam] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [kuade-Exam] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [kuade-Exam] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [kuade-Exam] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [kuade-Exam] SET RECOVERY FULL 
GO
ALTER DATABASE [kuade-Exam] SET  MULTI_USER 
GO
ALTER DATABASE [kuade-Exam] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [kuade-Exam] SET DB_CHAINING OFF 
GO
ALTER DATABASE [kuade-Exam] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [kuade-Exam] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [kuade-Exam] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [kuade-Exam] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'kuade-Exam', N'ON'
GO
ALTER DATABASE [kuade-Exam] SET QUERY_STORE = OFF
GO
/****** Object:  Table [BarcodeInfo]    Script Date: 2021/11/16 14:06:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [BarcodeInfo](
	[ruid] [bigint] IDENTITY(1,1) NOT NULL,
	[guid] [nvarchar](36) NOT NULL,
	[barcode] [nvarchar](36) NULL,
	[user_guid] [nvarchar](36) NULL,
 CONSTRAINT [PK_BARCODEINFO] PRIMARY KEY CLUSTERED 
(
	[guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ExamInfo]    Script Date: 2021/11/16 14:06:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ExamInfo](
	[ruid] [bigint] IDENTITY(1,1) NOT NULL,
	[guid] [nvarchar](36) NOT NULL,
	[exam_name] [nvarchar](50) NOT NULL,
	[exam_time] [nvarchar](50) NOT NULL,
	[exam_type_guid] [nvarchar](36) NOT NULL,
 CONSTRAINT [PK_EXAMINFO] PRIMARY KEY CLUSTERED 
(
	[guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [ExamSubjectInfo]    Script Date: 2021/11/16 14:06:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ExamSubjectInfo](
	[ruid] [bigint] IDENTITY(1,1) NOT NULL,
	[guid] [nvarchar](36) NOT NULL,
	[exam_guid] [nvarchar](36) NOT NULL,
	[subject_no] [nvarchar](10) NOT NULL,
	[subject_content] [nvarchar](4000) NOT NULL,
	[subject_content2] [image] NULL,
 CONSTRAINT [PK_EXAMSUBJECTINFO] PRIMARY KEY CLUSTERED 
(
	[guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [ExamTypeInfo]    Script Date: 2021/11/16 14:06:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ExamTypeInfo](
	[ruid] [bigint] IDENTITY(1,1) NOT NULL,
	[guid] [nvarchar](36) NOT NULL,
	[exam_type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EXAMTYPEINFO] PRIMARY KEY CLUSTERED 
(
	[guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [LogInfo]    Script Date: 2021/11/16 14:06:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LogInfo](
	[ruid] [bigint] IDENTITY(1,1) NOT NULL,
	[guid] [nvarchar](36) NOT NULL,
	[barcode_guid] [nvarchar](36) NULL,
	[user_guid] [nvarchar](36) NULL,
	[log_type] [nvarchar](8) NULL,
 CONSTRAINT [PK_LOGINFO] PRIMARY KEY CLUSTERED 
(
	[guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [SubjectChildInfo]    Script Date: 2021/11/16 14:06:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SubjectChildInfo](
	[ruid] [bigint] IDENTITY(1,1) NOT NULL,
	[guid] [nvarchar](36) NOT NULL,
	[subject_guid] [nvarchar](36) NOT NULL,
	[subject_child_no] [nvarchar](50) NOT NULL,
	[subject_child_answer] [nvarchar](4000) NOT NULL,
	[subject_child_answer2] [image] NULL,
	[subject_child_analysis] [nvarchar](4000) NOT NULL,
	[subject_child_analysis2] [image] NULL,
	[subject_child_type] [int] NOT NULL,
 CONSTRAINT [PK_SUBJECTCHILDINFO] PRIMARY KEY CLUSTERED 
(
	[guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [SubjectChildOptionInfo]    Script Date: 2021/11/16 14:06:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [SubjectChildOptionInfo](
	[ruid] [bigint] IDENTITY(1,1) NOT NULL,
	[guid] [nvarchar](36) NOT NULL,
	[subject_child_guid] [nvarchar](36) NOT NULL,
	[option_no] [nvarchar](50) NOT NULL,
	[option_content] [nvarchar](4000) NOT NULL,
	[option_content2] [image] NULL,
	[is_correct] [bit] NULL,
 CONSTRAINT [PK_SUBJECTCHILDOPTIONINFO] PRIMARY KEY CLUSTERED 
(
	[guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [UserInfo]    Script Date: 2021/11/16 14:06:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [UserInfo](
	[ruid] [bigint] IDENTITY(1,1) NOT NULL,
	[guid] [nvarchar](36) NOT NULL,
	[user_no] [nvarchar](50) NOT NULL,
	[user_nickname] [nvarchar](50) NOT NULL,
	[user_name] [nvarchar](50) NOT NULL,
	[user_pwd] [nvarchar](50) NOT NULL,
	[sex] [int] NOT NULL,
	[card_no] [nvarchar](50) NOT NULL,
	[user_type] [int] NOT NULL,
	[user_yn] [int] NOT NULL,
	[qq_no] [nvarchar](50) NOT NULL,
	[qq_token] [nvarchar](50) NOT NULL,
	[webchat_no] [nvarchar](50) NOT NULL,
	[webchat_token] [nvarchar](50) NOT NULL,
	[mobile] [nvarchar](50) NOT NULL,
	[idcard_no] [nvarchar](50) NOT NULL,
	[photo] [image] NULL,
 CONSTRAINT [PK_USERINFO] PRIMARY KEY CLUSTERED 
(
	[guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [BarcodeInfo] ADD  DEFAULT (newid()) FOR [guid]
GO
ALTER TABLE [ExamInfo] ADD  DEFAULT (newid()) FOR [guid]
GO
ALTER TABLE [ExamInfo] ADD  DEFAULT ('') FOR [exam_time]
GO
ALTER TABLE [ExamInfo] ADD  DEFAULT ('') FOR [exam_type_guid]
GO
ALTER TABLE [ExamSubjectInfo] ADD  DEFAULT (newid()) FOR [guid]
GO
ALTER TABLE [ExamSubjectInfo] ADD  DEFAULT ('') FOR [exam_guid]
GO
ALTER TABLE [ExamSubjectInfo] ADD  DEFAULT ('') FOR [subject_no]
GO
ALTER TABLE [ExamSubjectInfo] ADD  DEFAULT ('') FOR [subject_content]
GO
ALTER TABLE [ExamTypeInfo] ADD  DEFAULT (newid()) FOR [guid]
GO
ALTER TABLE [ExamTypeInfo] ADD  DEFAULT ('') FOR [exam_type]
GO
ALTER TABLE [LogInfo] ADD  DEFAULT (newid()) FOR [guid]
GO
ALTER TABLE [SubjectChildInfo] ADD  DEFAULT (newid()) FOR [guid]
GO
ALTER TABLE [SubjectChildInfo] ADD  DEFAULT ('') FOR [subject_guid]
GO
ALTER TABLE [SubjectChildInfo] ADD  DEFAULT ('') FOR [subject_child_no]
GO
ALTER TABLE [SubjectChildInfo] ADD  DEFAULT ('') FOR [subject_child_answer]
GO
ALTER TABLE [SubjectChildInfo] ADD  DEFAULT ('') FOR [subject_child_analysis]
GO
ALTER TABLE [SubjectChildInfo] ADD  DEFAULT ((0)) FOR [subject_child_type]
GO
ALTER TABLE [SubjectChildOptionInfo] ADD  DEFAULT (newid()) FOR [guid]
GO
ALTER TABLE [SubjectChildOptionInfo] ADD  DEFAULT ('') FOR [subject_child_guid]
GO
ALTER TABLE [SubjectChildOptionInfo] ADD  DEFAULT ('') FOR [option_no]
GO
ALTER TABLE [SubjectChildOptionInfo] ADD  DEFAULT ('') FOR [option_content]
GO
ALTER TABLE [UserInfo] ADD  DEFAULT (newid()) FOR [guid]
GO
ALTER TABLE [UserInfo] ADD  DEFAULT ('') FOR [user_no]
GO
ALTER TABLE [UserInfo] ADD  DEFAULT ('') FOR [user_nickname]
GO
ALTER TABLE [UserInfo] ADD  DEFAULT ('') FOR [user_name]
GO
ALTER TABLE [UserInfo] ADD  DEFAULT ('') FOR [user_pwd]
GO
ALTER TABLE [UserInfo] ADD  DEFAULT ((0)) FOR [sex]
GO
ALTER TABLE [UserInfo] ADD  DEFAULT ('') FOR [card_no]
GO
ALTER TABLE [UserInfo] ADD  DEFAULT ((0)) FOR [user_type]
GO
ALTER TABLE [UserInfo] ADD  DEFAULT ((0)) FOR [user_yn]
GO
ALTER TABLE [UserInfo] ADD  DEFAULT ('') FOR [qq_no]
GO
ALTER TABLE [UserInfo] ADD  DEFAULT ('') FOR [qq_token]
GO
ALTER TABLE [UserInfo] ADD  DEFAULT ('') FOR [webchat_no]
GO
ALTER TABLE [UserInfo] ADD  DEFAULT ('') FOR [webchat_token]
GO
ALTER TABLE [UserInfo] ADD  DEFAULT ('') FOR [mobile]
GO
ALTER TABLE [UserInfo] ADD  DEFAULT ('') FOR [idcard_no]
GO
ALTER TABLE [BarcodeInfo]  WITH CHECK ADD  CONSTRAINT [FK_BARCODEI_REFERENCE_USERINFO] FOREIGN KEY([user_guid])
REFERENCES [UserInfo] ([guid])
GO
ALTER TABLE [BarcodeInfo] CHECK CONSTRAINT [FK_BARCODEI_REFERENCE_USERINFO]
GO
ALTER TABLE [ExamInfo]  WITH CHECK ADD  CONSTRAINT [FK_EXAMINFO_REFERENCE_EXAMTYPE] FOREIGN KEY([exam_type_guid])
REFERENCES [ExamTypeInfo] ([guid])
GO
ALTER TABLE [ExamInfo] CHECK CONSTRAINT [FK_EXAMINFO_REFERENCE_EXAMTYPE]
GO
ALTER TABLE [ExamSubjectInfo]  WITH CHECK ADD  CONSTRAINT [FK_EXAMSUBJ_REFERENCE_EXAMINFO] FOREIGN KEY([exam_guid])
REFERENCES [ExamInfo] ([guid])
GO
ALTER TABLE [ExamSubjectInfo] CHECK CONSTRAINT [FK_EXAMSUBJ_REFERENCE_EXAMINFO]
GO
ALTER TABLE [LogInfo]  WITH CHECK ADD  CONSTRAINT [FK_LOGINFO_REFERENCE_BARCODEI] FOREIGN KEY([barcode_guid])
REFERENCES [BarcodeInfo] ([guid])
GO
ALTER TABLE [LogInfo] CHECK CONSTRAINT [FK_LOGINFO_REFERENCE_BARCODEI]
GO
ALTER TABLE [SubjectChildInfo]  WITH CHECK ADD  CONSTRAINT [FK_SUBJECTC_REFERENCE_EXAMSUBJ] FOREIGN KEY([subject_guid])
REFERENCES [ExamSubjectInfo] ([guid])
GO
ALTER TABLE [SubjectChildInfo] CHECK CONSTRAINT [FK_SUBJECTC_REFERENCE_EXAMSUBJ]
GO
ALTER TABLE [SubjectChildOptionInfo]  WITH CHECK ADD  CONSTRAINT [FK_SUBJECTC_REFERENCE_SUBJECTC] FOREIGN KEY([subject_child_guid])
REFERENCES [SubjectChildInfo] ([guid])
GO
ALTER TABLE [SubjectChildOptionInfo] CHECK CONSTRAINT [FK_SUBJECTC_REFERENCE_SUBJECTC]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增长' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BarcodeInfo', @level2type=N'COLUMN',@level2name=N'ruid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BarcodeInfo', @level2type=N'COLUMN',@level2name=N'guid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'二维码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BarcodeInfo', @level2type=N'COLUMN',@level2name=N'barcode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户guid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BarcodeInfo', @level2type=N'COLUMN',@level2name=N'user_guid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'二维码信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BarcodeInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增长' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExamInfo', @level2type=N'COLUMN',@level2name=N'ruid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExamInfo', @level2type=N'COLUMN',@level2name=N'guid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考试名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExamInfo', @level2type=N'COLUMN',@level2name=N'exam_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考试时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExamInfo', @level2type=N'COLUMN',@level2name=N'exam_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考试类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExamInfo', @level2type=N'COLUMN',@level2name=N'exam_type_guid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'历年考试信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExamInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增长' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExamSubjectInfo', @level2type=N'COLUMN',@level2name=N'ruid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExamSubjectInfo', @level2type=N'COLUMN',@level2name=N'guid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考试代号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExamSubjectInfo', @level2type=N'COLUMN',@level2name=N'exam_guid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'题号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExamSubjectInfo', @level2type=N'COLUMN',@level2name=N'subject_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'题目内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExamSubjectInfo', @level2type=N'COLUMN',@level2name=N'subject_content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'题目内容2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExamSubjectInfo', @level2type=N'COLUMN',@level2name=N'subject_content2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考试题目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExamSubjectInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增长' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExamTypeInfo', @level2type=N'COLUMN',@level2name=N'ruid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExamTypeInfo', @level2type=N'COLUMN',@level2name=N'guid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考试类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExamTypeInfo', @level2type=N'COLUMN',@level2name=N'exam_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'考试类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExamTypeInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增长' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LogInfo', @level2type=N'COLUMN',@level2name=N'ruid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LogInfo', @level2type=N'COLUMN',@level2name=N'guid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'二维码guid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LogInfo', @level2type=N'COLUMN',@level2name=N'barcode_guid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户guid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LogInfo', @level2type=N'COLUMN',@level2name=N'user_guid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LogInfo', @level2type=N'COLUMN',@level2name=N'log_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LogInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增长' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SubjectChildInfo', @level2type=N'COLUMN',@level2name=N'ruid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SubjectChildInfo', @level2type=N'COLUMN',@level2name=N'guid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'题目代号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SubjectChildInfo', @level2type=N'COLUMN',@level2name=N'subject_guid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'子题号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SubjectChildInfo', @level2type=N'COLUMN',@level2name=N'subject_child_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'子题答案' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SubjectChildInfo', @level2type=N'COLUMN',@level2name=N'subject_child_answer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'子题答案2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SubjectChildInfo', @level2type=N'COLUMN',@level2name=N'subject_child_answer2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'子题解析' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SubjectChildInfo', @level2type=N'COLUMN',@level2name=N'subject_child_analysis'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'子题解析2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SubjectChildInfo', @level2type=N'COLUMN',@level2name=N'subject_child_analysis2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'子题目类型（0：单选题；1：多选题；2：判断题；3：填空题；4：问答题）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SubjectChildInfo', @level2type=N'COLUMN',@level2name=N'subject_child_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'子题信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SubjectChildInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增长' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SubjectChildOptionInfo', @level2type=N'COLUMN',@level2name=N'ruid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SubjectChildOptionInfo', @level2type=N'COLUMN',@level2name=N'guid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'子题目代号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SubjectChildOptionInfo', @level2type=N'COLUMN',@level2name=N'subject_child_guid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'选项代号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SubjectChildOptionInfo', @level2type=N'COLUMN',@level2name=N'option_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'选项内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SubjectChildOptionInfo', @level2type=N'COLUMN',@level2name=N'option_content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'选项内容2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SubjectChildOptionInfo', @level2type=N'COLUMN',@level2name=N'option_content2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'子题目选项' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SubjectChildOptionInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增长' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'ruid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'guid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'user_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'user_nickname'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'user_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'user_pwd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别（0：男；1：女）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卡号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'card_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色（0：普通用户；1：管理员）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'user_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用（0：禁用；1：启用）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'user_yn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'QQ号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'qq_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'QQ令牌' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'qq_token'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'微信号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'webchat_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'微信令牌' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'webchat_token'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'mobile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份证号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'idcard_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'头像' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'photo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户信息管理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo'
GO
ALTER DATABASE [kuade-Exam] SET  READ_WRITE 
GO
