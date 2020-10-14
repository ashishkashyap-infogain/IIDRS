USE [IDRS]
GO

/****** Object:  Table [dbo].[M_CUST_SURVEY]    Script Date: 29-09-2020 00:34:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[M_CUST_SURVEY](
	[ROW_ID] [varchar](50) NOT NULL,
	[SURVEY_ID] [varchar](50) NOT NULL,
	[PAR_ROW_ID] [varchar](50) NULL,
	[CUST_SURVEY_NAME] [varchar](100) NULL,
	[SURVEY_QUESTION_NAME] [varchar](100) NULL,
	[SURVEY_QUESTION_DESC] [varchar](400) NULL,
	[SURVEY_FLG] [varchar](50) NULL,
	[CREATED_DT] [datetime] NULL,
	[CREATED_BY] [varchar](50) NULL,
	[LAST_UPD_DT] [datetime] NULL,
	[LAST_UPD_BY] [varchar](50) NULL,
 CONSTRAINT [PK_M_CUST_SURVEY] PRIMARY KEY CLUSTERED 
(
	[SURVEY_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


