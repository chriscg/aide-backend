USE [AIDE]
GO

/****** Object:  Table [dbo].[WEEK_RANGE]    Script Date: 5/14/2019 11:11:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WEEKLY_REPORT](
	[WR_ID] [int] IDENTITY(1,1) NOT NULL,
	[WR_WEEK_RANGE_ID] INT NOT NULL,
	[WR_PROJ_ID] SMALLINT NOT NULL,
	[WR_REWORK] SMALLINT,
	[WR_REF_ID] VARCHAR(10),
	[WR_SUBJECT] VARCHAR(MAX),
	[WR_SEVERITY] SMALLINT,
	[WR_INC_TYPE] SMALLINT,
	[WR_EMP_ID] INT NOT NULL,
	[WR_PHASE] SMALLINT,
	[WR_STATUS] SMALLINT NOT NULL,
	[WR_DATE_STARTED] DATE,
	[WR_DATE_TARGET] DATE,
	[WR_DATE_FINISHED] DATE,
	[WR_DATE_CREATED] DATE,
	[WR_EFFORT_EST] FLOAT,
	[WR_ACT_EFFORT_WK] FLOAT NOT NULL,
	[WR_ACT_EFFORT] FLOAT,
	[WR_COMMENTS] TEXT,
	[WR_INBOUND_CONTACTS] SMALLINT
 CONSTRAINT [PK_WEEKLY_REPORT] PRIMARY KEY CLUSTERED 
(
	[WR_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


