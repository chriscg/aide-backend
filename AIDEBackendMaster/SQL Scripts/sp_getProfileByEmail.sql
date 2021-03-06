USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_getProfileByEmail]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getProfileByEmail](
	-- Add the parameters for the stored procedure here
	@EMAILADDRESS varchar(max)

)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT			dbo.EMPLOYEE.EMP_ID, 
					dbo.EMPLOYEE.WS_EMP_ID,
				    dbo.DEPARTMENT.DEPT_ID, 
					dbo.EMPLOYEE.LAST_NAME, 
					dbo.EMPLOYEE.FIRST_NAME, 
					dbo.EMPLOYEE.MIDDLE_NAME, 
					dbo.EMPLOYEE.NICK_NAME, 
                    dbo.EMPLOYEE.BIRTHDATE, 
					dbo.EMPLOYEE.DATE_HIRED, 
					dbo.EMPLOYEE.IMAGE_PATH, 
					dbo.DEPARTMENT.DESCR AS DEPARTMENT, 
					dbo.DIVISION.DESCR AS DIVISION, 
					dbo.POSITION.DESCR AS POSITION, 
                    dbo.CONTACTS.EMAIL_ADDRESS, 
					dbo.CONTACTS.EMAIL_ADDRESS2, 
					dbo.CONTACTS.LOCATION, 
					dbo.CONTACTS.CEL_NO, 
					dbo.CONTACTS.LOCAL, 
					dbo.CONTACTS.HOMEPHONE, 
					dbo.CONTACTS.OTHER_PHONE, 
                    dbo.CONTACTS.DT_REVIEWED, 
					dbo.PERMISSION_GROUP.DESCR AS PERMISSION, 
					dbo.STATUS.DESCR AS CIVILSTATUS,
					dbo.EMPLOYEE.SHIFT_STATUS

	FROM            dbo.EMPLOYEE INNER JOIN dbo.CONTACTS 
					ON dbo.EMPLOYEE.EMP_ID = dbo.CONTACTS.EMP_ID 
					INNER JOIN dbo.DEPARTMENT 
					ON dbo.EMPLOYEE.DEPT_ID = dbo.DEPARTMENT.DEPT_ID 
					INNER JOIN  dbo.DIVISION
					ON dbo.EMPLOYEE.DIV_ID = dbo.DIVISION.DIV_ID 
					INNER JOIN dbo.POSITION 
					ON dbo.EMPLOYEE.POS_ID = dbo.POSITION.POS_ID 
					INNER JOIN dbo.PERMISSION_GROUP 
					ON dbo.EMPLOYEE.GRP_ID = dbo.PERMISSION_GROUP.GRP_ID 
					INNER JOIN dbo.STATUS 
					ON dbo.EMPLOYEE.STATUS = dbo.STATUS.STATUS 

	WHERE dbo.CONTACTS.EMAIL_ADDRESS = @EMAILADDRESS 
		  AND dbo.STATUS.STATUS_ID = 1
END



GO
