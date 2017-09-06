/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     05/09/2017 22:07:45                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DOCUMENTO_IDENTIFICACAO_TB') and o.name = 'FK_DOCUMENT_RL_PESSOA_PESSOA_T')
alter table DOCUMENTO_IDENTIFICACAO_TB
   drop constraint FK_DOCUMENT_RL_PESSOA_PESSOA_T
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ENDERECO_TB') and o.name = 'FK_ENDERECO_RELATIONS_PESSOA_T')
alter table ENDERECO_TB
   drop constraint FK_ENDERECO_RELATIONS_PESSOA_T
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ORDEM_SERVICO_TB') and o.name = 'FK_ORDEM_SE_RELATIONS_PESSOA_T')
alter table ORDEM_SERVICO_TB
   drop constraint FK_ORDEM_SE_RELATIONS_PESSOA_T
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TELEFONE_TB') and o.name = 'FK_TELEFONE_RL_PESSOA_PESSOA_T')
alter table TELEFONE_TB
   drop constraint FK_TELEFONE_RL_PESSOA_PESSOA_T
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('USUARIO_SETOR_TB') and o.name = 'FK_USUARIO__RELATIONS_USUARIO_')
alter table USUARIO_SETOR_TB
   drop constraint FK_USUARIO__RELATIONS_USUARIO_
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('USUARIO_TB') and o.name = 'FK_USUARIO__RL_PESSOA_PESSOA_T')
alter table USUARIO_TB
   drop constraint FK_USUARIO__RL_PESSOA_PESSOA_T
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DOCUMENTO_IDENTIFICACAO_TB')
            and   name  = 'RL_PESSOA_DOCUMENTO_IDENTIFICACAO_FK'
            and   indid > 0
            and   indid < 255)
   drop index DOCUMENTO_IDENTIFICACAO_TB.RL_PESSOA_DOCUMENTO_IDENTIFICACAO_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DOCUMENTO_IDENTIFICACAO_TB')
            and   type = 'U')
   drop table DOCUMENTO_IDENTIFICACAO_TB
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ENDERECO_TB')
            and   name  = 'RELATIONSHIP_4_FK'
            and   indid > 0
            and   indid < 255)
   drop index ENDERECO_TB.RELATIONSHIP_4_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ENDERECO_TB')
            and   type = 'U')
   drop table ENDERECO_TB
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ORDEM_SERVICO_TB')
            and   name  = 'RELATIONSHIP_13_FK'
            and   indid > 0
            and   indid < 255)
   drop index ORDEM_SERVICO_TB.RELATIONSHIP_13_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ORDEM_SERVICO_TB')
            and   type = 'U')
   drop table ORDEM_SERVICO_TB
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PESSOA_TB')
            and   type = 'U')
   drop table PESSOA_TB
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TELEFONE_TB')
            and   name  = 'RL_PESSOA_TELEFONE_FK'
            and   indid > 0
            and   indid < 255)
   drop index TELEFONE_TB.RL_PESSOA_TELEFONE_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TELEFONE_TB')
            and   type = 'U')
   drop table TELEFONE_TB
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('USUARIO_SETOR_TB')
            and   name  = 'RELATIONSHIP_12_FK'
            and   indid > 0
            and   indid < 255)
   drop index USUARIO_SETOR_TB.RELATIONSHIP_12_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('USUARIO_SETOR_TB')
            and   type = 'U')
   drop table USUARIO_SETOR_TB
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('USUARIO_TB')
            and   name  = 'RL_PESSOA_USUARIO_FK'
            and   indid > 0
            and   indid < 255)
   drop index USUARIO_TB.RL_PESSOA_USUARIO_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('USUARIO_TB')
            and   type = 'U')
   drop table USUARIO_TB
go

/*==============================================================*/
/* Table: DOCUMENTO_IDENTIFICACAO_TB                            */
/*==============================================================*/
create table DOCUMENTO_IDENTIFICACAO_TB (
   ID_PESSOA            int                  not null,
   ID_DOCUMENTO_IDENTIFICACAO int                  identity,
   constraint PK_DOCUMENTO_IDENTIFICACAO_TB primary key nonclustered (ID_DOCUMENTO_IDENTIFICACAO)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('DOCUMENTO_IDENTIFICACAO_TB') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'DOCUMENTO_IDENTIFICACAO_TB' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Representa os documentos de identificacao que a pessoa tem', 
   'user', @CurrentUser, 'table', 'DOCUMENTO_IDENTIFICACAO_TB'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DOCUMENTO_IDENTIFICACAO_TB')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_PESSOA')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DOCUMENTO_IDENTIFICACAO_TB', 'column', 'ID_PESSOA'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador da pessoa',
   'user', @CurrentUser, 'table', 'DOCUMENTO_IDENTIFICACAO_TB', 'column', 'ID_PESSOA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DOCUMENTO_IDENTIFICACAO_TB')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_DOCUMENTO_IDENTIFICACAO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DOCUMENTO_IDENTIFICACAO_TB', 'column', 'ID_DOCUMENTO_IDENTIFICACAO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador do documento de identificação',
   'user', @CurrentUser, 'table', 'DOCUMENTO_IDENTIFICACAO_TB', 'column', 'ID_DOCUMENTO_IDENTIFICACAO'
go

/*==============================================================*/
/* Index: RL_PESSOA_DOCUMENTO_IDENTIFICACAO_FK                  */
/*==============================================================*/
create index RL_PESSOA_DOCUMENTO_IDENTIFICACAO_FK on DOCUMENTO_IDENTIFICACAO_TB (
ID_PESSOA ASC
)
go

/*==============================================================*/
/* Table: ENDERECO_TB                                           */
/*==============================================================*/
create table ENDERECO_TB (
   ID_ENDERECO          int                  identity,
   ID_MUNICIPIO         int                  not null,
   ID_ESTADO            int                  not null,
   ID_PESSOA            int                  not null,
   LOGRADOURO           varchar(255)         not null,
   CEP                  varchar(8)           not null,
   BAIRRO               varchar(255)         not null,
   constraint PK_ENDERECO_TB primary key nonclustered (ID_ENDERECO)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('ENDERECO_TB') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'ENDERECO_TB' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Representa o endereço registrado no cadastro', 
   'user', @CurrentUser, 'table', 'ENDERECO_TB'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ENDERECO_TB')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_PESSOA')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ENDERECO_TB', 'column', 'ID_PESSOA'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador da pessoa',
   'user', @CurrentUser, 'table', 'ENDERECO_TB', 'column', 'ID_PESSOA'
go

/*==============================================================*/
/* Index: RELATIONSHIP_4_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_4_FK on ENDERECO_TB (
ID_PESSOA ASC
)
go

/*==============================================================*/
/* Table: ORDEM_SERVICO_TB                                      */
/*==============================================================*/
create table ORDEM_SERVICO_TB (
   IDENTIFICADOR_ORDEM_SERVICO int                  identity,
   ID_PESSOA            int                  not null,
   DATA_REGISTRO        datetime             not null,
   DATA_FIM_VIGENCIA    datetime             null,
   DESCRICAO            varchar(255)         null,
   VALOR                decimal(15)          not null default 0
      constraint CKC_VALOR_ORDEM_SE check (VALOR >= 0),
   constraint PK_ORDEM_SERVICO_TB primary key nonclustered (IDENTIFICADOR_ORDEM_SERVICO)
)
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ORDEM_SERVICO_TB')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_PESSOA')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ORDEM_SERVICO_TB', 'column', 'ID_PESSOA'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador da pessoa',
   'user', @CurrentUser, 'table', 'ORDEM_SERVICO_TB', 'column', 'ID_PESSOA'
go

/*==============================================================*/
/* Index: RELATIONSHIP_13_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_13_FK on ORDEM_SERVICO_TB (
ID_PESSOA ASC
)
go

/*==============================================================*/
/* Table: PESSOA_TB                                             */
/*==============================================================*/
create table PESSOA_TB (
   ID_PESSOA            int                  identity,
   CODIGO_TIPO_SEXO     int                  not null,
   NOME_PESSOA          varchar(50)          not null,
   SOBRENOME_PESSOA     varchar(200)         null,
   EMAIL_PESSOA         varchar(100)         null,
   DATA_NASCIMENTO      datetime             null,
   DATA_REGISTRO        datetime             not null,
   constraint PK_PESSOA_TB primary key nonclustered (ID_PESSOA)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('PESSOA_TB') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'PESSOA_TB' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Representa uma pessoa (Funcionário ou cliente) que usará o sistema', 
   'user', @CurrentUser, 'table', 'PESSOA_TB'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PESSOA_TB')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_PESSOA')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PESSOA_TB', 'column', 'ID_PESSOA'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador da pessoa',
   'user', @CurrentUser, 'table', 'PESSOA_TB', 'column', 'ID_PESSOA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PESSOA_TB')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NOME_PESSOA')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PESSOA_TB', 'column', 'NOME_PESSOA'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Nome da pessoa cadastrada',
   'user', @CurrentUser, 'table', 'PESSOA_TB', 'column', 'NOME_PESSOA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PESSOA_TB')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SOBRENOME_PESSOA')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PESSOA_TB', 'column', 'SOBRENOME_PESSOA'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Sobrenome da pessoa registrada',
   'user', @CurrentUser, 'table', 'PESSOA_TB', 'column', 'SOBRENOME_PESSOA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PESSOA_TB')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EMAIL_PESSOA')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PESSOA_TB', 'column', 'EMAIL_PESSOA'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Email da pessoa',
   'user', @CurrentUser, 'table', 'PESSOA_TB', 'column', 'EMAIL_PESSOA'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PESSOA_TB')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DATA_NASCIMENTO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PESSOA_TB', 'column', 'DATA_NASCIMENTO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Data de nascimento da pessoa registrada',
   'user', @CurrentUser, 'table', 'PESSOA_TB', 'column', 'DATA_NASCIMENTO'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PESSOA_TB')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DATA_REGISTRO')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PESSOA_TB', 'column', 'DATA_REGISTRO'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Data em que pessoa foi registrada no sistema',
   'user', @CurrentUser, 'table', 'PESSOA_TB', 'column', 'DATA_REGISTRO'
go

/*==============================================================*/
/* Table: TELEFONE_TB                                           */
/*==============================================================*/
create table TELEFONE_TB (
   ID_TELEFONE          int                  identity,
   ID_PESSOA            int                  null,
   PREFIXO_TELEFONE     varchar(10)          not null,
   NUMERO_TELEFONE      varchar(50)          not null,
   OBSERVACAO           varchar(255)         null,
   constraint PK_TELEFONE_TB primary key nonclustered (ID_TELEFONE)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TELEFONE_TB') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TELEFONE_TB' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Representa os telefones registrados no registro', 
   'user', @CurrentUser, 'table', 'TELEFONE_TB'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TELEFONE_TB')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_PESSOA')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TELEFONE_TB', 'column', 'ID_PESSOA'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador da pessoa',
   'user', @CurrentUser, 'table', 'TELEFONE_TB', 'column', 'ID_PESSOA'
go

/*==============================================================*/
/* Index: RL_PESSOA_TELEFONE_FK                                 */
/*==============================================================*/
create index RL_PESSOA_TELEFONE_FK on TELEFONE_TB (
ID_PESSOA ASC
)
go

/*==============================================================*/
/* Table: USUARIO_SETOR_TB                                      */
/*==============================================================*/
create table USUARIO_SETOR_TB (
   ID_USUARIO_SETOR     int                  identity,
   ID_FUNCAO_FUNCIONARIO int                  null,
   IDENTIFICADOR_SETOR_FUNCIONARIO int                  null,
   ID_USUARIO           int                  null,
   constraint PK_USUARIO_SETOR_TB primary key nonclustered (ID_USUARIO_SETOR)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_12_FK                                    */
/*==============================================================*/
create index RELATIONSHIP_12_FK on USUARIO_SETOR_TB (
ID_USUARIO ASC
)
go

/*==============================================================*/
/* Table: USUARIO_TB                                            */
/*==============================================================*/
create table USUARIO_TB (
   ID_USUARIO           int                  identity,
   ID_PESSOA            int                  not null,
   ID_TIPO_USUARIO      int                  not null,
   DESATIVADO           tinyint              not null default 0,
   DESCRICAO_DESATIVACAO varchar(255)         null,
   SENHA                varchar(15)          not null,
   ALTERACAO_SENHA      tinyint              not null default 1,
   constraint PK_USUARIO_TB primary key nonclustered (ID_USUARIO)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('USUARIO_TB') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'USUARIO_TB' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Representa um usuário do sistema
   - Um funcionário que registra uma ordem de serviço
   - Um cliente que pede uma ordem de serviço', 
   'user', @CurrentUser, 'table', 'USUARIO_TB'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('USUARIO_TB')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ID_PESSOA')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'USUARIO_TB', 'column', 'ID_PESSOA'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Identificador da pessoa',
   'user', @CurrentUser, 'table', 'USUARIO_TB', 'column', 'ID_PESSOA'
go

/*==============================================================*/
/* Index: RL_PESSOA_USUARIO_FK                                  */
/*==============================================================*/
create index RL_PESSOA_USUARIO_FK on USUARIO_TB (
ID_PESSOA ASC
)
go

alter table DOCUMENTO_IDENTIFICACAO_TB
   add constraint FK_DOCUMENT_RL_PESSOA_PESSOA_T foreign key (ID_PESSOA)
      references PESSOA_TB (ID_PESSOA)
go

alter table ENDERECO_TB
   add constraint FK_ENDERECO_RELATIONS_PESSOA_T foreign key (ID_PESSOA)
      references PESSOA_TB (ID_PESSOA)
go

alter table ORDEM_SERVICO_TB
   add constraint FK_ORDEM_SE_RELATIONS_PESSOA_T foreign key (ID_PESSOA)
      references PESSOA_TB (ID_PESSOA)
go

alter table TELEFONE_TB
   add constraint FK_TELEFONE_RL_PESSOA_PESSOA_T foreign key (ID_PESSOA)
      references PESSOA_TB (ID_PESSOA)
go

alter table USUARIO_SETOR_TB
   add constraint FK_USUARIO__RELATIONS_USUARIO_ foreign key (ID_USUARIO)
      references USUARIO_TB (ID_USUARIO)
go

alter table USUARIO_TB
   add constraint FK_USUARIO__RL_PESSOA_PESSOA_T foreign key (ID_PESSOA)
      references PESSOA_TB (ID_PESSOA)
go

