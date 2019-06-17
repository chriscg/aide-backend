USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTasksSummaryWeekly]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetTasksSummaryWeekly] 
	-- Add the parameters for the stored procedure here

 @EMP_ID INTEGER,	
 @DATE_STARTED DATE


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM TASKS WHERE DATEPART(WEEK, DATE_STARTED) = DATEPART(WEEK, @DATE_STARTED) AND EMP_ID = @EMP_ID
END





GO
