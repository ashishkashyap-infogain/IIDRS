USE [IDRS]
GO

/****** Object:  Table [dbo].[M_ORG_EXT]    Script Date: 29-09-2020 00:33:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[M_ORG_EXT](
	[ROW_ID] [varchar](50) NOT NULL,
	[NAME] [varchar](50) NULL,
	[LOC] [varchar](50) NULL,
	[BU_ID] [varchar](50) NULL,
	[ACCNT_FLG] [varchar](50) NULL,
	[ACTIVE_FLG] [varchar](50) NULL,
	[PAR_ROW_ID] [varchar](50) NULL,
	[CUST_END_DT] [datetime] NULL,
	[CUST_SINCE_DT] [datetime] NULL,
	[PAR_BU_ID] [varchar](50) NULL,
	[PARTNER_FLG] [varchar](50) NULL,
	[PAR_DIVN_ID] [varchar](50) NULL,
	[PR_ADDR_ID] [varchar](50) NULL,
	[PR_ADDR_PER_ID] [varchar](50) NULL,
	[PR_BL_ADDR_ID] [varchar](50) NULL,
	[PR_BL_PER_ID] [varchar](50) NULL,
	[PR_CON_ID] [varchar](50) NULL,
	[PR_POSTN_ID] [varchar](50) NULL,
	[SURVEY_ID] [varchar](50) NULL,
	[RATING] [varchar](50) NULL,
	[ZIPCODE] [varchar](50) NULL,
	[CREATED_DT] [datetime] NULL,
	[CREATED_BY] [varchar](50) NULL,
	[LAST_UPD_DT] [datetime] NULL,
	[LAST_UPD_BY] [varchar](50) NULL,
 CONSTRAINT [PK_M_ORG_EXT] PRIMARY KEY CLUSTERED 
(
	[ROW_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


