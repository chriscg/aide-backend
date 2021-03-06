USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertAuditSched]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertAuditSched]
	-- Add the parameters for the stored procedure here
	@EMP_ID INT,
	@PERIOD_START DATE,
	@PERIOD_END DATE,
	@DAILY VARCHAR(15),
	@WEEKLY VARCHAR(15),
	@MONTHLY VARCHAR(15),
	@YEAR INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @FIRSTMONTH DATE, @LASTMONTH DATE
	DECLARE @FY_WEEK INT
    -- Insert statements for procedure here
	SET @FIRSTMONTH = CAST('4/1/' + Cast(@YEAR as varchar) AS DATE)
	SET @LASTMONTH = CAST('3/31/' + Cast(@YEAR + 1 as varchar) AS DATE)

	SELECT @FY_WEEK = dbo.FiscalYearMonth(@PERIOD_START)

	INSERT INTO WORKPLACE_AUDIT_SCHEDULE
	VALUES(@EMP_ID,@FY_WEEK, @PERIOD_START, @PERIOD_END, @DAILY, @WEEKLY, @MONTHLY, @FIRSTMONTH, @LASTMONTH)
END

GO
