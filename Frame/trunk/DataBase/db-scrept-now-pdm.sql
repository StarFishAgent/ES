/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2017                    */
/* Created on:     2021/7/26 13:48:31                           */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BarcodeInfo') and o.name = 'FK_BARCODEI_REFERENCE_USERINFO')
alter table BarcodeInfo
   drop constraint FK_BARCODEI_REFERENCE_USERINFO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ExamInfo') and o.name = 'FK_EXAMINFO_REFERENCE_EXAMTYPE')
alter table ExamInfo
   drop constraint FK_EXAMINFO_REFERENCE_EXAMTYPE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ExamSubjectInfo') and o.name = 'FK_EXAMSUBJ_REFERENCE_EXAMINFO')
alter table ExamSubjectInfo
   drop constraint FK_EXAMSUBJ_REFERENCE_EXAMINFO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LogInfo') and o.name = 'FK_LOGINFO_REFERENCE_BARCODEI')
alter table LogInfo
   drop constraint FK_LOGINFO_REFERENCE_BARCODEI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SubjectChildInfo') and o.name = 'FK_SUBJECTC_REFERENCE_EXAMSUBJ')
alter table SubjectChildInfo
   drop constraint FK_SUBJECTC_REFERENCE_EXAMSUBJ
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SubjectChildOptionInfo') and o.name = 'FK_SUBJECTC_REFERENCE_SUBJECTC')
alter table SubjectChildOptionInfo
   drop constraint FK_SUBJECTC_REFERENCE_SUBJECTC
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BarcodeInfo')
            and   type = 'U')
   drop table BarcodeInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ExamInfo')
            and   type = 'U')
   drop table ExamInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ExamSubjectInfo')
            and   type = 'U')
   drop table ExamSubjectInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ExamTypeInfo')
            and   type = 'U')
   drop table ExamTypeInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LogInfo')
            and   type = 'U')
   drop table LogInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SubjectChildInfo')
            and   type = 'U')
   drop table SubjectChildInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SubjectChildOptionInfo')
            and   type = 'U')
   drop table SubjectChildOptionInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('UserInfo')
            and   type = 'U')
   drop table UserInfo
go

/*==============================================================*/
/* Table: BarcodeInfo                                           */
/*==============================================================*/
create table BarcodeInfo (
   ruid                 bigint               identity,
   guid                 nvarchar(36)         not null default newid(),
   barcode              nvarchar(36)         null,
   user_guid            nvarchar(36)         null,
   constraint PK_BARCODEINFO primary key (guid)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('BarcodeInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'BarcodeInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '二维码信息表', 
   'user', @CurrentUser, 'table', 'BarcodeInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('BarcodeInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ruid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'BarcodeInfo', 'column', 'ruid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '自增长',
   'user', @CurrentUser, 'table', 'BarcodeInfo', 'column', 'ruid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('BarcodeInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'guid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'BarcodeInfo', 'column', 'guid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键',
   'user', @CurrentUser, 'table', 'BarcodeInfo', 'column', 'guid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('BarcodeInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'barcode')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'BarcodeInfo', 'column', 'barcode'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '二维码',
   'user', @CurrentUser, 'table', 'BarcodeInfo', 'column', 'barcode'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('BarcodeInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_guid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'BarcodeInfo', 'column', 'user_guid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户guid',
   'user', @CurrentUser, 'table', 'BarcodeInfo', 'column', 'user_guid'
go

/*==============================================================*/
/* Table: ExamInfo                                              */
/*==============================================================*/
create table ExamInfo (
   ruid                 bigint               identity,
   guid                 nvarchar(36)         not null default newid(),
   exam_name            nvarchar(50)         not null,
   exam_time            nvarchar(50)         not null default '',
   exam_type_guid       nvarchar(36)         not null default '',
   constraint PK_EXAMINFO primary key (guid)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('ExamInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'ExamInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '历年考试信息', 
   'user', @CurrentUser, 'table', 'ExamInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ruid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamInfo', 'column', 'ruid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '自增长',
   'user', @CurrentUser, 'table', 'ExamInfo', 'column', 'ruid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'guid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamInfo', 'column', 'guid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键',
   'user', @CurrentUser, 'table', 'ExamInfo', 'column', 'guid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'exam_name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamInfo', 'column', 'exam_name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '考试名称',
   'user', @CurrentUser, 'table', 'ExamInfo', 'column', 'exam_name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'exam_time')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamInfo', 'column', 'exam_time'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '考试时间',
   'user', @CurrentUser, 'table', 'ExamInfo', 'column', 'exam_time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'exam_type_guid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamInfo', 'column', 'exam_type_guid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '考试类型',
   'user', @CurrentUser, 'table', 'ExamInfo', 'column', 'exam_type_guid'
go

/*==============================================================*/
/* Table: ExamSubjectInfo                                       */
/*==============================================================*/
create table ExamSubjectInfo (
   ruid                 bigint               identity,
   guid                 nvarchar(36)         not null default newid(),
   exam_guid            nvarchar(36)         not null default '',
   subject_no           nvarchar(10)         not null default '',
   subject_content      nvarchar(4000)       not null default '',
   subject_content2     image                null,
   constraint PK_EXAMSUBJECTINFO primary key (guid)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('ExamSubjectInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'ExamSubjectInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '考试题目', 
   'user', @CurrentUser, 'table', 'ExamSubjectInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamSubjectInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ruid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamSubjectInfo', 'column', 'ruid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '自增长',
   'user', @CurrentUser, 'table', 'ExamSubjectInfo', 'column', 'ruid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamSubjectInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'guid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamSubjectInfo', 'column', 'guid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键',
   'user', @CurrentUser, 'table', 'ExamSubjectInfo', 'column', 'guid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamSubjectInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'exam_guid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamSubjectInfo', 'column', 'exam_guid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '考试代号',
   'user', @CurrentUser, 'table', 'ExamSubjectInfo', 'column', 'exam_guid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamSubjectInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'subject_no')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamSubjectInfo', 'column', 'subject_no'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '题号',
   'user', @CurrentUser, 'table', 'ExamSubjectInfo', 'column', 'subject_no'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamSubjectInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'subject_content')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamSubjectInfo', 'column', 'subject_content'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '题目内容',
   'user', @CurrentUser, 'table', 'ExamSubjectInfo', 'column', 'subject_content'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamSubjectInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'subject_content2')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamSubjectInfo', 'column', 'subject_content2'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '题目内容2',
   'user', @CurrentUser, 'table', 'ExamSubjectInfo', 'column', 'subject_content2'
go

/*==============================================================*/
/* Table: ExamTypeInfo                                          */
/*==============================================================*/
create table ExamTypeInfo (
   ruid                 bigint               identity,
   guid                 nvarchar(36)         not null default newid(),
   exam_type            nvarchar(50)         not null default '',
   constraint PK_EXAMTYPEINFO primary key (guid)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('ExamTypeInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'ExamTypeInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '考试类型', 
   'user', @CurrentUser, 'table', 'ExamTypeInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamTypeInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ruid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamTypeInfo', 'column', 'ruid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '自增长',
   'user', @CurrentUser, 'table', 'ExamTypeInfo', 'column', 'ruid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamTypeInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'guid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamTypeInfo', 'column', 'guid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键',
   'user', @CurrentUser, 'table', 'ExamTypeInfo', 'column', 'guid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamTypeInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'exam_type')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamTypeInfo', 'column', 'exam_type'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '考试类型',
   'user', @CurrentUser, 'table', 'ExamTypeInfo', 'column', 'exam_type'
go

/*==============================================================*/
/* Table: LogInfo                                               */
/*==============================================================*/
create table LogInfo (
   ruid                 bigint               identity,
   guid                 nvarchar(36)         not null default newid(),
   barcode_guid         nvarchar(36)         null,
   user_guid            nvarchar(36)         null,
   log_type             nvarchar(8)          null,
   constraint PK_LOGINFO primary key (guid)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('LogInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'LogInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '登录信息表', 
   'user', @CurrentUser, 'table', 'LogInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LogInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ruid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LogInfo', 'column', 'ruid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '自增长',
   'user', @CurrentUser, 'table', 'LogInfo', 'column', 'ruid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LogInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'guid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LogInfo', 'column', 'guid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键',
   'user', @CurrentUser, 'table', 'LogInfo', 'column', 'guid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LogInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'barcode_guid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LogInfo', 'column', 'barcode_guid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '二维码guid',
   'user', @CurrentUser, 'table', 'LogInfo', 'column', 'barcode_guid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LogInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_guid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LogInfo', 'column', 'user_guid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户guid',
   'user', @CurrentUser, 'table', 'LogInfo', 'column', 'user_guid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LogInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'log_type')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LogInfo', 'column', 'log_type'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '登录类型',
   'user', @CurrentUser, 'table', 'LogInfo', 'column', 'log_type'
go

/*==============================================================*/
/* Table: SubjectChildInfo                                      */
/*==============================================================*/
create table SubjectChildInfo (
   ruid                 bigint               identity,
   guid                 nvarchar(36)         not null default newid(),
   subject_guid         nvarchar(36)         not null default '',
   subject_child_no     nvarchar(50)         not null default '',
   subject_child_answer nvarchar(4000)       not null default '',
   subject_child_answer2 image                null,
   subject_child_analysis nvarchar(4000)       not null default '',
   subject_child_analysis2 image                null,
   subject_child_type   int                  not null default 0,
   constraint PK_SUBJECTCHILDINFO primary key (guid)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('SubjectChildInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'SubjectChildInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '子题信息', 
   'user', @CurrentUser, 'table', 'SubjectChildInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SubjectChildInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ruid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SubjectChildInfo', 'column', 'ruid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '自增长',
   'user', @CurrentUser, 'table', 'SubjectChildInfo', 'column', 'ruid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SubjectChildInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'guid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SubjectChildInfo', 'column', 'guid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键',
   'user', @CurrentUser, 'table', 'SubjectChildInfo', 'column', 'guid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SubjectChildInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'subject_guid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SubjectChildInfo', 'column', 'subject_guid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '题目代号',
   'user', @CurrentUser, 'table', 'SubjectChildInfo', 'column', 'subject_guid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SubjectChildInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'subject_child_no')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SubjectChildInfo', 'column', 'subject_child_no'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '子题号',
   'user', @CurrentUser, 'table', 'SubjectChildInfo', 'column', 'subject_child_no'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SubjectChildInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'subject_child_answer')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SubjectChildInfo', 'column', 'subject_child_answer'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '子题答案',
   'user', @CurrentUser, 'table', 'SubjectChildInfo', 'column', 'subject_child_answer'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SubjectChildInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'subject_child_answer2')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SubjectChildInfo', 'column', 'subject_child_answer2'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '子题答案2',
   'user', @CurrentUser, 'table', 'SubjectChildInfo', 'column', 'subject_child_answer2'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SubjectChildInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'subject_child_analysis')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SubjectChildInfo', 'column', 'subject_child_analysis'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '子题解析',
   'user', @CurrentUser, 'table', 'SubjectChildInfo', 'column', 'subject_child_analysis'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SubjectChildInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'subject_child_analysis2')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SubjectChildInfo', 'column', 'subject_child_analysis2'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '子题解析2',
   'user', @CurrentUser, 'table', 'SubjectChildInfo', 'column', 'subject_child_analysis2'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SubjectChildInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'subject_child_type')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SubjectChildInfo', 'column', 'subject_child_type'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '子题目类型（0：单选题；1：多选题；2：判断题；3：填空题；4：问答题）',
   'user', @CurrentUser, 'table', 'SubjectChildInfo', 'column', 'subject_child_type'
go

/*==============================================================*/
/* Table: SubjectChildOptionInfo                                */
/*==============================================================*/
create table SubjectChildOptionInfo (
   ruid                 bigint               identity,
   guid                 nvarchar(36)         not null default newid(),
   subject_child_guid   nvarchar(36)         not null default '',
   option_no            nvarchar(50)         not null default '',
   option_content       nvarchar(4000)       not null default '',
   option_content2      image                null,
   constraint PK_SUBJECTCHILDOPTIONINFO primary key (guid)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('SubjectChildOptionInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'SubjectChildOptionInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '子题目选项', 
   'user', @CurrentUser, 'table', 'SubjectChildOptionInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SubjectChildOptionInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ruid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SubjectChildOptionInfo', 'column', 'ruid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '自增长',
   'user', @CurrentUser, 'table', 'SubjectChildOptionInfo', 'column', 'ruid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SubjectChildOptionInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'guid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SubjectChildOptionInfo', 'column', 'guid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键',
   'user', @CurrentUser, 'table', 'SubjectChildOptionInfo', 'column', 'guid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SubjectChildOptionInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'subject_child_guid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SubjectChildOptionInfo', 'column', 'subject_child_guid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '子题目代号',
   'user', @CurrentUser, 'table', 'SubjectChildOptionInfo', 'column', 'subject_child_guid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SubjectChildOptionInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'option_no')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SubjectChildOptionInfo', 'column', 'option_no'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '选项代号',
   'user', @CurrentUser, 'table', 'SubjectChildOptionInfo', 'column', 'option_no'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SubjectChildOptionInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'option_content')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SubjectChildOptionInfo', 'column', 'option_content'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '选项内容',
   'user', @CurrentUser, 'table', 'SubjectChildOptionInfo', 'column', 'option_content'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SubjectChildOptionInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'option_content2')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SubjectChildOptionInfo', 'column', 'option_content2'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '选项内容2',
   'user', @CurrentUser, 'table', 'SubjectChildOptionInfo', 'column', 'option_content2'
go

/*==============================================================*/
/* Table: UserInfo                                              */
/*==============================================================*/
create table UserInfo (
   ruid                 bigint               identity,
   guid                 nvarchar(36)         not null default newid(),
   user_no              nvarchar(50)         not null default '',
   user_nickname        nvarchar(50)         not null default '',
   user_name            nvarchar(50)         not null default '',
   user_pwd             nvarchar(50)         not null default '',
   sex                  int                  not null default 0,
   card_no              nvarchar(50)         not null default '',
   user_type            int                  not null default 0,
   user_yn              int                  not null default 0,
   qq_no                nvarchar(50)         not null default '',
   qq_token             nvarchar(50)         not null default '',
   webchat_no           nvarchar(50)         not null default '',
   webchat_token        nvarchar(50)         not null default '',
   mobile               nvarchar(50)         not null default '',
   idcard_no            nvarchar(50)         not null default '',
   photo                image                null,
   constraint PK_USERINFO primary key (guid)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('UserInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'UserInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '用户信息管理', 
   'user', @CurrentUser, 'table', 'UserInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ruid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'ruid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '自增长',
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'ruid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'guid')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'guid'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '主键',
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'guid'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_no')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'user_no'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户名',
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'user_no'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_nickname')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'user_nickname'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户昵称',
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'user_nickname'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'user_name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户姓名',
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'user_name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_pwd')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'user_pwd'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '用户密码',
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'user_pwd'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'sex')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'sex'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '性别（0：男；1：女）',
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'sex'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'card_no')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'card_no'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '卡号',
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'card_no'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_type')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'user_type'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '角色（0：普通用户；1：管理员）',
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'user_type'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'user_yn')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'user_yn'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '是否启用（0：禁用；1：启用）',
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'user_yn'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'qq_no')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'qq_no'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'QQ号',
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'qq_no'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'qq_token')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'qq_token'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'QQ令牌',
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'qq_token'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'webchat_no')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'webchat_no'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '微信号',
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'webchat_no'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'webchat_token')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'webchat_token'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '微信令牌',
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'webchat_token'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'mobile')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'mobile'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '联系电话',
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'mobile'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'idcard_no')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'idcard_no'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '身份证号',
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'idcard_no'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('UserInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'photo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'photo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '头像',
   'user', @CurrentUser, 'table', 'UserInfo', 'column', 'photo'
go

alter table BarcodeInfo
   add constraint FK_BARCODEI_REFERENCE_USERINFO foreign key (user_guid)
      references UserInfo (guid)
go

alter table ExamInfo
   add constraint FK_EXAMINFO_REFERENCE_EXAMTYPE foreign key (exam_type_guid)
      references ExamTypeInfo (guid)
go

alter table ExamSubjectInfo
   add constraint FK_EXAMSUBJ_REFERENCE_EXAMINFO foreign key (exam_guid)
      references ExamInfo (guid)
go

alter table LogInfo
   add constraint FK_LOGINFO_REFERENCE_BARCODEI foreign key (barcode_guid)
      references BarcodeInfo (guid)
go

alter table SubjectChildInfo
   add constraint FK_SUBJECTC_REFERENCE_EXAMSUBJ foreign key (subject_guid)
      references ExamSubjectInfo (guid)
go

alter table SubjectChildOptionInfo
   add constraint FK_SUBJECTC_REFERENCE_SUBJECTC foreign key (subject_child_guid)
      references SubjectChildInfo (guid)
go

