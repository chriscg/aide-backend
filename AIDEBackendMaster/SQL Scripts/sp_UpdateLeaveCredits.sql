USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateLeaveCredits]    Script Date: 6/17/2019 7:31:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateLeaveCredits]
	-- Add the parameters for the stored procedure here
	@EMP_ID INT,
	@LEAVE_CREDITS FLOAT,
	@STATUS INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE LEAVE_CREDITS SET LEAVE_CREDITS = LEAVE_CREDITS + @LEAVE_CREDITS
	WHERE EMP_ID = @EMP_ID AND STATUS = @STATUS

END

GO
