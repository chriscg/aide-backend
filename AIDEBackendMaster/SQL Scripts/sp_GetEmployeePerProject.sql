USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEmployeePerProject]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetEmployeePerProject]
	-- Add the parameters for the stored procedure here
	@EMP_ID INT,
	@PROJ_ID INT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT DISTINCT A.EMP_ID, CONCAT(B.FIRST_NAME, ' ', B.LAST_NAME) AS 'NICK_NAME'
	FROM ASSIGNED_PROJECTS A INNER JOIN EMPLOYEE B
	ON A.EMP_ID = B.EMP_ID
	WHERE a.PROJ_ID = @PROJ_ID
	AND B.DEPT_ID = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)
	AND B.DIV_ID = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)
		
END
GO
