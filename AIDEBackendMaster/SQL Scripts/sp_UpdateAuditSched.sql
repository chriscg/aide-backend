USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateAuditSched]    Script Date: 6/17/2019 7:31:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateAuditSched]
	-- Add the parameters for the stored procedure here
	@AUDIT_SCHED_ID INT,
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
    -- Insert statements for procedure here
	SET @FIRSTMONTH = CAST('4/1/' + Cast(@YEAR as varchar) AS DATE)
	SET @LASTMONTH = CAST('3/31/' + Cast(@YEAR + 1 as varchar) AS DATE)

	UPDATE [dbo].[WORKPLACE_AUDIT_SCHEDULE]
	SET [PERIOD_START] = @PERIOD_START,
		[PERIOD_END] = @PERIOD_END, 
		[DAILY] = @DAILY,
		[WEEKLY] = @WEEKLY,
		[MONTHLY] = @MONTHLY,
		[FY_START] = @FIRSTMONTH,
		[FY_END] = @LASTMONTH
	WHERE [AUDIT_SCHED_ID] = @AUDIT_SCHED_ID

END

GO
