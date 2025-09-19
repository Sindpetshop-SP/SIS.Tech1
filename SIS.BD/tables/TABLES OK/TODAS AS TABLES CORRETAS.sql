USE [SIS_TECH]
GO

CREATE TABLE [dbo].[Arquivos](
	[CodArquivo]	[int]		IDENTITY(1,1)	NOT NULL,
	[Titulo]		[varchar](50)				NULL,
	[Nome]			[varchar](50)				NOT NULL,
	[ContentType]	[varchar](50)				NULL,
	[Arquivo]		[varchar](max)				NULL,
	[Ativo]			[bit]						NOT NULL,	
 CONSTRAINT [PK_dbo.Arquivos] PRIMARY KEY CLUSTERED 
(
	[CodArquivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



CREATE TABLE [dbo].[StatusCCT](
	[CodStatusCCT]	[int] IDENTITY(1,1) NOT NULL,
	[Descricao]		[varchar](100)		NOT NULL,
 CONSTRAINT [PK_dbo.StatusCCT] PRIMARY KEY CLUSTERED 
(
	[CodStatusCCT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[TipoCCT](
	[CodTipoCCT]	[int] IDENTITY(1,1) NOT NULL,
	[Descricao]		[varchar](100)		NOT NULL,
 CONSTRAINT [PK_dbo.TipoCCT] PRIMARY KEY CLUSTERED 
(
	[CodTipoCCT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[TipoContato](
	[CodTipoContato]	[int] IDENTITY(1,1) NOT NULL,
	[Descricao]			[varchar](80)		NOT NULL,
 CONSTRAINT [PK_dbo.TipoContato] PRIMARY KEY CLUSTERED 
(
	[CodTipoContato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[TipoEndereco](
	[CodTipoEndereco]	[int] IDENTITY(1,1) NOT NULL,
	[Descricao]			[varchar](80)		NOT NULL,
 CONSTRAINT [PK_dbo.TipoEndereco] PRIMARY KEY CLUSTERED 
(
	[CodTipoEndereco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[TipoPessoa](
	[CodTipoPessoa] [int] IDENTITY(1,1) NOT NULL,
	[Descricao]		[varchar](80)		NOT NULL,
 CONSTRAINT [PK_dbo.TipoPessoa] PRIMARY KEY CLUSTERED 
(
	[CodTipoPessoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Contato](
	[CodContato]		[int] IDENTITY(1,1) NOT NULL,
	[CodTipoContato]	[int]				NOT NULL,
	[DDD]				[varchar](3)		NOT NULL,
	[Telefone]			[varchar](35)		NOT NULL,
	[Email]				[varchar](300)		NULL,
 CONSTRAINT [PK_dbo.Contato] PRIMARY KEY CLUSTERED 
(
	[CodContato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Contato]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Contato_TipoContato] FOREIGN KEY([CodTipoContato])
REFERENCES [dbo].[TipoContato] ([CodTipoContato])
GO

ALTER TABLE [dbo].[Contato] CHECK CONSTRAINT [FK_dbo.Contato_TipoContato]
GO




CREATE TABLE [dbo].[Endereco](
	[CodEndereco]		[int] IDENTITY(1,1) NOT NULL,
	[CodTipoEndereco]	[int]				NOT NULL,
	[Cep]				[varchar](9)		NOT NULL,
	[Logradouro]		[varchar](350)		NOT NULL,
	[Numero]			[varchar](5)		NOT NULL,
	[Complemento]		[varchar](300)		NULL,
	[Bairro]			[varchar](80)		NULL,
	[Cidade]			[varchar](80)		NULL,
	[Estado]			[varchar](80)		NULL,
 CONSTRAINT [PK_dbo.Endereco] PRIMARY KEY CLUSTERED 
(
	[CodEndereco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Endereco]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Endereco_TipoEndereco] FOREIGN KEY([CodTipoEndereco])
REFERENCES [dbo].[TipoEndereco] ([CodTipoEndereco])
GO

ALTER TABLE [dbo].[Endereco] CHECK CONSTRAINT [FK_dbo.Endereco_TipoEndereco]
GO




CREATE TABLE [dbo].[RamoAtividade](
	[CodRamoAtividade]	[int] IDENTITY(1,1) NOT NULL,
	[Descricao]			[varchar](100)		NOT NULL,
 CONSTRAINT [PK_dbo.RamoAtividade] PRIMARY KEY CLUSTERED 
(
	[CodRamoAtividade] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO





CREATE TABLE [dbo].[LogSistema](
	[CodLog]			[bigint] IDENTITY(1,1)	NOT NULL,
	[CodSistema]		[int]					NOT NULL,
	[NmeTabela]			[varchar](50)			NOT NULL,
	[VlrOriginal]		[xml]					NOT NULL,
	[TpoAcao]			[char](3)				NOT NULL,
	[NmeLoginUsuario]	[varchar](20)			NOT NULL,
	[DtaLog]			[datetime]				NOT NULL,
 CONSTRAINT [PK_LogSistema] PRIMARY KEY CLUSTERED 
(
	[CodLog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[LogSistema]  WITH NOCHECK ADD  CONSTRAINT [CK_LogSistema] CHECK NOT FOR REPLICATION (([TpoAcao]='U' OR [TpoAcao]='D' OR [TpoAcao]='I'))
GO

ALTER TABLE [dbo].[LogSistema] CHECK CONSTRAINT [CK_LogSistema]
GO



 CREATE TABLE [dbo].[Cnae](
	[CodCnae]		[int] IDENTITY(1,1) NOT NULL,
	[NumeroCnae]	[varchar](100)		NOT NULL,
	[Descricao]		[varchar](255)		NOT NULL,
	[Anexo]			[varchar](10)		NOT NULL,
	[Fator]			[bit]				NOT NULL,
	[Aliquota]		[decimal](18, 0)	NOT NULL,
	[Quem]			[varchar](6)		NOT NULL,
	[Quando]		[datetime]			NOT NULL,
 CONSTRAINT [PK_dbo.Cnae] PRIMARY KEY CLUSTERED 
(
	[CodCnae] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[Contabilidade](
	[CodContabilidade] [int] IDENTITY(1,1)	NOT NULL,
	[Nome]				[varchar](150)		NOT NULL,
	[Responsavel]		[varchar](150)		NOT NULL,
	[DataCadastro]		[datetime]			NOT NULL,
	[Ativo]				[bit]				NOT NULL,
	[Observacao]		[varchar](255)		NOT NULL,
	[Cnpj]				[varchar](18)		NULL,
	[Quem]				[varchar](6)		NOT NULL,
	[Quando]			[datetime]			NOT NULL,
 CONSTRAINT [PK_dbo.Contabilidade] PRIMARY KEY CLUSTERED 
(
	[CodContabilidade] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[ContabilidadeContato](
	[CodContabilidade]	[int] NOT NULL,
	[CodContato]		[int] NOT NULL,
 CONSTRAINT [PK_dbo.ContabilidadeContato] PRIMARY KEY CLUSTERED 
(
	[CodContabilidade] ASC,
	[CodContato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ContabilidadeContato]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ContabilidadeContato_Contabilidade] FOREIGN KEY([CodContabilidade])
REFERENCES [dbo].[Contabilidade] ([CodContabilidade])
GO

ALTER TABLE [dbo].[ContabilidadeContato] CHECK CONSTRAINT [FK_dbo.ContabilidadeContato_Contabilidade]
GO

ALTER TABLE [dbo].[ContabilidadeContato]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ContabilidadeContato_Contato] FOREIGN KEY([CodContato])
REFERENCES [dbo].[Contato] ([CodContato])
GO

ALTER TABLE [dbo].[ContabilidadeContato] CHECK CONSTRAINT [FK_dbo.ContabilidadeContato_Contato]
GO



CREATE TABLE [dbo].[ContabilidadeEndereco](
	[CodContabilidade]	[int] NOT NULL,
	[CodEndereco]		[int] NOT NULL,
 CONSTRAINT [PK_dbo.ContabilidadeEndereco] PRIMARY KEY CLUSTERED 
(
	[CodContabilidade] ASC,
	[CodEndereco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ContabilidadeEndereco]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ContabilidadeEndereco_Contabilidade] FOREIGN KEY([CodContabilidade])
REFERENCES [dbo].[Contabilidade] ([CodContabilidade])
GO

ALTER TABLE [dbo].[ContabilidadeEndereco] CHECK CONSTRAINT [FK_dbo.ContabilidadeEndereco_Contabilidade]
GO

ALTER TABLE [dbo].[ContabilidadeEndereco]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ContabilidadeEndereco_Endereco] FOREIGN KEY([CodEndereco])
REFERENCES [dbo].[Endereco] ([CodEndereco])
GO

ALTER TABLE [dbo].[ContabilidadeEndereco] CHECK CONSTRAINT [FK_dbo.ContabilidadeEndereco_Endereco]
GO




CREATE TABLE [dbo].[Convencao](
	[CodConvencao]			[int] IDENTITY(1,1) NOT NULL,
	[CodTipoCCT]			[int]				NOT NULL,
	[CodStatusCCT]			[int]				NOT NULL,
	[NomeConvencao]			[varchar](100)		NOT NULL,
	[AnoVigenciaInicial]	[varchar](4)		NOT NULL,
	[AnoVigenciaFinal]		[varchar](4)		NOT NULL,
	[Observacao]			[varchar](255)		NULL,
	[CCTAssinada]			[bit]				NOT NULL,
	[Ativo]					[bit]				NOT NULL,
	[Quem]					[varchar](6)		NOT NULL,
	[Quando]				[datetime]			NOT NULL,
 CONSTRAINT [PK_dbo.Convencao] PRIMARY KEY CLUSTERED 
(
	[CodConvencao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Convencao]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Convencao_StatusCCT] FOREIGN KEY([CodStatusCCT])
REFERENCES [dbo].[StatusCCT] ([CodStatusCCT])
GO

ALTER TABLE [dbo].[Convencao] CHECK CONSTRAINT [FK_dbo.Convencao_StatusCCT]
GO

ALTER TABLE [dbo].[Convencao]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Convencao_TipoCCT] FOREIGN KEY([CodTipoCCT])
REFERENCES [dbo].[TipoCCT] ([CodTipoCCT])
GO

ALTER TABLE [dbo].[Convencao] CHECK CONSTRAINT [FK_dbo.Convencao_TipoCCT]
GO




CREATE TABLE [dbo].[ConvencaoArquivo](
	[CodConvencao]	 [int] NOT NULL,
	[CodArquivo]	[int]	NOT NULL,	
 CONSTRAINT [PK_dbo.ConvencaoArquivo] PRIMARY KEY CLUSTERED 
(
	[CodConvencao] ASC,
	[CodArquivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ConvencaoArquivo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ConvencaoArquivo_Arquivo] FOREIGN KEY([CodArquivo])
REFERENCES [dbo].[Arquivos] ([CodArquivo])
GO

ALTER TABLE [dbo].[ConvencaoArquivo] CHECK CONSTRAINT [FK_dbo.ConvencaoArquivo_Arquivo]
GO

ALTER TABLE [dbo].[ConvencaoArquivo]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ConvencaoArquivo_Convencao] FOREIGN KEY([CodConvencao])
REFERENCES [dbo].[Convencao] ([CodConvencao])
GO

ALTER TABLE [dbo].[ConvencaoArquivo] CHECK CONSTRAINT [FK_dbo.ConvencaoArquivo_Convencao]
GO





CREATE TABLE [dbo].[Socios](
	[CodSocio]		[int] IDENTITY(1,1) NOT NULL,
	[Nome]			[varchar](150)		NOT NULL,
	[Cpf]			[varchar](14)		NOT NULL,
	[Observacao]	[varchar](255)		NULL,
	[Ativo]			[bit]				NOT NULL,
	[Quem]			[varchar](6)	NOT NULL,
	[Quando]		[datetime]		NOT NULL,
 CONSTRAINT [PK_dbo.Socios] PRIMARY KEY CLUSTERED 
(
	[CodSocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO





CREATE TABLE [dbo].[Empresa](
	[CodEmpresa]				[int] IDENTITY(1,1) NOT NULL,
	[CodTipoPessoa]				[int]				NOT NULL,
	[CodRamoAtividade]			[int]				NOT NULL,
	[Cnpj]						[varchar](18)		NOT NULL,
	[RazaoSocial]				[varchar](150)		NOT NULL,
	[NomeFantasia]				[varchar](150)		NULL,
	[DataCadastro]				[datetime]			NOT NULL,
	[DataAbertura]				[datetime]			NULL,
	[InscricaoEstadual]			[varchar](15)		NULL,
	[InscricaoMunicipal]		[varchar](14)		NULL,
	[Sindicalizada]				[bit]				NOT NULL,
	[EhMatrizFilial]			[bit]				NOT NULL,
	[QuantidadeFUncionarios]	[int]				NOT NULL,
	[ValorTotalFolha]			[decimal](14, 2)	NOT NULL,
	[CapitalSocial]				[decimal](14, 2)	NOT NULL,
	[Observacao]				[varchar](max)		NULL,
	[Ativo]						[bit]				NOT NULL,
	[Quem]						[varchar](6)		NOT NULL,
	[Quando]					[datetime]			NOT NULL,
 CONSTRAINT [PK_dbo.Empresa] PRIMARY KEY CLUSTERED 
(
	[CodEmpresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Empresa_TipoPessoa] FOREIGN KEY([CodTipoPessoa])
REFERENCES [dbo].[TipoPessoa] ([CodTipoPessoa])
GO

ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_dbo.Empresa_TipoPessoa]
GO

ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Pessoa_RamoAtividade] FOREIGN KEY([CodRamoAtividade])
REFERENCES [dbo].[RamoAtividade] ([CodRamoAtividade])
GO

ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_dbo.Pessoa_RamoAtividade]
GO



CREATE TABLE [dbo].[EmpresaCnae](
	[CodEmpresa]	[int]			NOT NULL,
	[CodCnae]		[int]			NOT NULL,
	[Primario]		[bit]			NOT NULL,
	[Secundario]	[bit]			NOT NULL,
	[Quem]			[varchar](6)	NOT NULL,
	[Quando]		[datetime]		NOT NULL,
 CONSTRAINT [PK_dbo.EmpresaCnae] PRIMARY KEY CLUSTERED 
(
	[CodEmpresa] ASC,
	[CodCnae] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EmpresaCnae]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EmpresaCnae_Cnae] FOREIGN KEY([CodCnae])
REFERENCES [dbo].[Cnae] ([CodCnae])
GO

ALTER TABLE [dbo].[EmpresaCnae] CHECK CONSTRAINT [FK_dbo.EmpresaCnae_Cnae]
GO

ALTER TABLE [dbo].[EmpresaCnae]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EmpresaCnae_Empresa] FOREIGN KEY([CodEmpresa])
REFERENCES [dbo].[Empresa] ([CodEmpresa])
GO

ALTER TABLE [dbo].[EmpresaCnae] CHECK CONSTRAINT [FK_dbo.EmpresaCnae_Empresa]
GO




CREATE TABLE [dbo].[EmpresaContabilidade](
	[CodEmpresa]		[int] NOT NULL,
	[CodContabilidade]	[int] NOT NULL,
	[Quem]			[varchar](6)	NOT NULL,
	[Quando]		[datetime]		NOT NULL,
 CONSTRAINT [PK_dbo.EmpresaContabilidade] PRIMARY KEY CLUSTERED 
(
	[CodEmpresa] ASC,
	[CodContabilidade] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EmpresaContabilidade]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EmpresaContabilidade_Contabilidade] FOREIGN KEY([CodContabilidade])
REFERENCES [dbo].[Contabilidade] ([CodContabilidade])
GO

ALTER TABLE [dbo].[EmpresaContabilidade] CHECK CONSTRAINT [FK_dbo.EmpresaContabilidade_Contabilidade]
GO

ALTER TABLE [dbo].[EmpresaContabilidade]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EmpresaContabilidade_Empresa] FOREIGN KEY([CodEmpresa])
REFERENCES [dbo].[Empresa] ([CodEmpresa])
GO

ALTER TABLE [dbo].[EmpresaContabilidade] CHECK CONSTRAINT [FK_dbo.EmpresaContabilidade_Empresa]
GO




CREATE TABLE [dbo].[EmpresaContato](
	[CodEmpresa] [int] NOT NULL,
	[CodContato] [int] NOT NULL,
	[Quem]			[varchar](6)	NOT NULL,
	[Quando]		[datetime]		NOT NULL,
 CONSTRAINT [PK_dbo.EmpresaContato] PRIMARY KEY CLUSTERED 
(
	[CodEmpresa] ASC,
	[CodContato] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EmpresaContato]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EmpresaContato_Contato] FOREIGN KEY([CodContato])
REFERENCES [dbo].[Contato] ([CodContato])
GO

ALTER TABLE [dbo].[EmpresaContato] CHECK CONSTRAINT [FK_dbo.EmpresaContato_Contato]
GO

ALTER TABLE [dbo].[EmpresaContato]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EmpresaContato_Empresa] FOREIGN KEY([CodEmpresa])
REFERENCES [dbo].[Empresa] ([CodEmpresa])
GO

ALTER TABLE [dbo].[EmpresaContato] CHECK CONSTRAINT [FK_dbo.EmpresaContato_Empresa]
GO




CREATE TABLE [dbo].[EmpresaConvencao](
	[CodEmpresa] [int] NOT NULL,
	[CodConvencao] [int] NOT NULL,
	[Quem]			[varchar](6)	NOT NULL,
	[Quando]		[datetime]		NOT NULL,
 CONSTRAINT [PK_dbo.EmpresaConvencao] PRIMARY KEY CLUSTERED 
(
	[CodEmpresa] ASC,
	[CodConvencao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EmpresaConvencao]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EmpresaConvencao_Convencao] FOREIGN KEY([CodConvencao])
REFERENCES [dbo].[Convencao] ([CodConvencao])
GO

ALTER TABLE [dbo].[EmpresaConvencao] CHECK CONSTRAINT [FK_dbo.EmpresaConvencao_Convencao]
GO

ALTER TABLE [dbo].[EmpresaConvencao]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EmpresaConvencao_Empresa] FOREIGN KEY([CodEmpresa])
REFERENCES [dbo].[Empresa] ([CodEmpresa])
GO

ALTER TABLE [dbo].[EmpresaConvencao] CHECK CONSTRAINT [FK_dbo.EmpresaConvencao_Empresa]
GO




CREATE TABLE [dbo].[EmpresaEndereco](
	[CodEmpresa] [int] NOT NULL,
	[CodEndereco] [int] NOT NULL,
	[Quem]			[varchar](6)	NOT NULL,
	[Quando]		[datetime]		NOT NULL,
 CONSTRAINT [PK_dbo.EmpresaEndereco] PRIMARY KEY CLUSTERED 
(
	[CodEmpresa] ASC,
	[CodEndereco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EmpresaEndereco]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EmpresaEndereco_Empresa] FOREIGN KEY([CodEmpresa])
REFERENCES [dbo].[Empresa] ([CodEmpresa])
GO

ALTER TABLE [dbo].[EmpresaEndereco] CHECK CONSTRAINT [FK_dbo.EmpresaEndereco_Empresa]
GO

ALTER TABLE [dbo].[EmpresaEndereco]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EmpresaEndereco_Endereco] FOREIGN KEY([CodEndereco])
REFERENCES [dbo].[Endereco] ([CodEndereco])
GO

ALTER TABLE [dbo].[EmpresaEndereco] CHECK CONSTRAINT [FK_dbo.EmpresaEndereco_Endereco]
GO


CREATE TABLE [dbo].[EmpresaSocios](
	[CodEmpresa]	[int]	NOT NULL,
	[CodSocio]		[int]	NOT NULL,
	[Quem]			[varchar](6)	NOT NULL,
	[Quando]		[datetime]		NOT NULL,
 CONSTRAINT [PK_dbo.EmpresaSocios] PRIMARY KEY CLUSTERED 
(
	[CodEmpresa] ASC,
	[CodSocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EmpresaSocios]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EmpresaSocios_Empresa] FOREIGN KEY([CodEmpresa])
REFERENCES [dbo].[Empresa] ([CodEmpresa])
GO

ALTER TABLE [dbo].[EmpresaSocios] CHECK CONSTRAINT [FK_dbo.EmpresaSocios_Empresa]
GO

ALTER TABLE [dbo].[EmpresaSocios]  WITH CHECK ADD  CONSTRAINT [FK_dbo.EmpresaSocios_Socio] FOREIGN KEY([CodSocio])
REFERENCES [dbo].[Socios] ([CodSocio])
GO

ALTER TABLE [dbo].[EmpresaSocios] CHECK CONSTRAINT [FK_dbo.EmpresaSocios_Socio]
GO




