USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertProject]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertProject]
	@PROJ_ID int ,
	@PROJ_NAME varchar(20) ,
	@CATEGORY smallint ,
	@BILLABILITY smallint 

AS

INSERT [dbo].[PROJECT]
(
	[PROJ_ID],
	[PROJ_NAME],
	[CATEGORY],
	[BILLABILITY]

)
VALUES
(
	@PROJ_ID,
	@PROJ_NAME,
	@CATEGORY,
	@BILLABILITY

)




GO
