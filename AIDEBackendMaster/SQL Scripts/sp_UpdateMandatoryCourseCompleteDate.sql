USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateMandatoryCourseCompleteDate]    Script Date: 6/17/2019 7:31:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateMandatoryCourseCompleteDate] 
	-- Add the parameters for the stored procedure here
	@EMP_ID INT,
	@DATE_COMPLETED DATE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE MANDATORY_COURSES SET DATE_COMPLETED = @DATE_COMPLETED
	WHERE ASSIGNED_TO = @EMP_ID
END

GO
