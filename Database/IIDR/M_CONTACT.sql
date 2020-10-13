USE [IDRS]
GO

/****** Object:  Table [dbo].[M_CONTACT]    Script Date: 29-09-2020 00:34:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[M_CONTACT](
	[ROW_ID] [varchar](50) NOT NULL,
	[PERSON_UID] [varchar](50) NOT NULL,
	[BU_ID] [varchar](50) NULL,
	[ACTIVE_FLG] [varchar](50) NULL,
	[PAR_ROW_ID] [varchar](50) NULL,
	[EMP_FLG] [varchar](50) NULL,
	[FST_NAME] [varchar](50) NULL,
	[LAST_NAME] [varchar](50) NULL,
	[EMAIL_ADDR] [varchar](50) NULL,
	[EMP_ID] [varchar](50) NULL,
	[PHONE_NO] [varchar](50) NULL,
	[CREATED_DT] [datetime] NULL,
	[CREATED_BY] [varchar](50) NULL,
	[LAST_UPD_DT] [datetime] NULL,
	[LAST_UPD_BY] [varchar](50) NULL,
 CONSTRAINT [PK_M_CONTACT] PRIMARY KEY CLUSTERED 
(
	[PERSON_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


