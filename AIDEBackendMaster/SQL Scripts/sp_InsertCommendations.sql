USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertCommendations]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertCommendations]
	-- Add the parameters for the stored procedure here
	--@COMMEND_ID INT,
	@EMP_ID INT,
	@EMPLOYEE VARCHAR(MAX),
	@PROJECT VARCHAR(20),
	@DATE_SENT DATE,
	@SENT_BY VARCHAR(MAX),
	@REASON VARCHAR(MAX)
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].COMMENDATIONS (EMPLOYEE, PROJECT, DATE_SENT, SENT_BY, REASON, EMP_ID)
	VALUES(	@EMPLOYEE,
			@PROJECT,
			@DATE_SENT,
			@SENT_BY,
			@REASON,
			@EMP_ID)
END 

GO
