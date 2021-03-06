USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAttendanceToday]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_GetAttendanceToday]
	-- Add the parameters for the stored procedure here
	@EMAIL_ADDRESS varchar(max)
AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select c.EMP_ID, c.LAST_NAME + ', ' + c.FIRST_NAME + ' ' + SUBSTRING(c.MIDDLE_NAME,1,1) + '' AS EMPLOYEE_NAME, 
	D.DESCR, a.DATE_ENTRY,a.STATUS, c.IMAGE_PATH
	from ATTENDANCE a inner join EMPLOYEE b on a.EMP_ID = b.EMP_ID inner join EMPLOYEE c on a.EMP_ID = c.EMP_ID
	INNER JOIN DIVISION D ON B.DIV_ID = D.DIV_ID
	where CONVERT(DATE,A.DATE_ENTRY) = CONVERT(DATE,GETDATE())
	and b.DEPT_ID = (SELECT A.DEPT_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
					ON A.EMP_ID = B.EMP_ID
					WHERE B.EMAIL_ADDRESS = @EMAIL_ADDRESS)
	and b.DIV_ID = (SELECT A.DIV_ID FROM EMPLOYEE A INNER JOIN CONTACTS B
					ON A.EMP_ID = B.EMP_ID
					WHERE B.EMAIL_ADDRESS = @EMAIL_ADDRESS)
	order by a.STATUS, b.LAST_NAME
END



GO
