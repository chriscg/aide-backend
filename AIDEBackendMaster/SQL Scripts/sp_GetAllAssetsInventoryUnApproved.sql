USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllAssetsInventoryUnApproved]    Script Date: 06/28/2019 5:16:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetAllAssetsInventoryUnApproved]
	-- Add the parameters for the stored procedure here
	@EMP_ID INT
AS

DECLARE @DEPT_ID INT = (SELECT DEPT_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID),
		@DIV_ID INT = (SELECT DIV_ID FROM EMPLOYEE WHERE EMP_ID = @EMP_ID)

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT CONCAT(E.FIRST_NAME, ' ', E.LAST_NAME) AS FULL_NAME, 
			D.DESCR AS DEPARTMENT, 
			I.ASSET_ID,
			I.EMP_ID,
			A.ASSET_DESC, 
			A.MANUFACTURER, 
			A.MODEL_NO, 
			A.SERIAL_NO, 
			A.ASSET_TAG,
			A.DATE_PURCHASED,
			I.DATE_ASSIGNED,
			I.COMMENTS,
			I.STATUS,
			I.APPROVAL
	FROM ASSETS A
	INNER JOIN ASSETS_INVENTORY I
	ON A.ASSET_ID = I.ASSET_ID
	INNER JOIN STATUS B
	ON A.STATUS = B.STATUS
	INNER JOIN EMPLOYEE E
	ON I.EMP_ID = E.EMP_ID
	INNER JOIN DEPARTMENT D
	ON E.DEPT_ID = D.DEPT_ID
	WHERE E.DEPT_ID = @DEPT_ID AND E.DIV_ID = @DIV_ID
	AND I.APPROVAL = 0
	AND B.STATUS_ID = 10
	AND B.STATUS IN (3,4) --PARTIALLY ASSIGNED/UNASSIGNED

END
