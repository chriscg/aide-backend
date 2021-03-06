USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCommendationsBySearch]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetCommendationsBySearch]
	-- Add the parameters for the stored procedure here
	@EMP_ID INT,
	@MONTH int,
	@YEAR int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @DEPT_ID VARCHAR(MAX) = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @Emp_ID)
	DECLARE @DIV_ID VARCHAR(MAX) = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @Emp_ID)

	SELECT a.COMMEND_ID,a.EMPLOYEE,a.PROJECT,a.SENT_BY ,a.DATE_SENT,a.REASON
	FROM COMMENDATIONS A
	INNER JOIN [dbo].[EMPLOYEE] B 
	on A.EMP_ID = B.EMP_ID 
	WHERE B.DEPT_ID = @DEPT_ID AND B.DIV_ID = @DIV_ID
		  AND Month(A.DATE_SENT) = @MONTH AND Year(A.DATE_SENT) = @YEAR 
END

GO
