USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetWeeklyReportByWeekRangeAndEmpID]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetWeeklyReportByWeekRangeAndEmpID]
@WK_RANGE_ID INT,
@EMP_ID INT

AS
BEGIN

SELECT * FROM WEEKLY_REPORT  
WHERE WR_EMP_ID = @EMP_ID 
AND	WR_WEEK_RANGE_ID = @WK_RANGE_ID 

END
 



GO
