USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateContacts]    Script Date: 6/17/2019 7:31:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateContacts] 
	-- Add the parameters for the stored procedure here
	@EMAIL_ADDRESS VARCHAR(50),
	@DT_REVIEWED DATE,
	@EMAIL_ADDRESS2 VARCHAR(50),
	@LOCATION VARCHAR(50),
	@HOMEPHONE VARCHAR(50),
	@OTHERPHONE VARCHAR(50),
	@CEL_NO VARCHAR(50),
	@LOCAL INT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @EMP_ID INT = (SELECT EMP_ID FROM CONTACTS WHERE EMAIL_ADDRESS = @EMAIL_ADDRESS)

    -- Insert statements for procedure here
	UPDATE [dbo].[CONTACTS]
	SET [EMAIL_ADDRESS2] = @EMAIL_ADDRESS2,
		[LOCATION] = @LOCATION,
		[CEL_NO] = @CEL_NO,
		[HOMEPHONE] = ISNULL(@HOMEPHONE, [HOMEPHONE]),
		[OTHER_PHONE] = ISNULL(@OTHERPHONE, [OTHER_PHONE]),
		[LOCAL] = ISNULL(@LOCAL, [LOCAL]),
		[DT_REVIEWED] = @DT_REVIEWED
	WHERE EMAIL_ADDRESS = @EMAIL_ADDRESS

	--To mark as Onsite
	IF @LOCATION != 'Eco Tower, BGC' AND @LOCATION != 'Net Square, BGC'
		BEGIN
			exec dbo.[sp_UpdateResourcePlanner] @from = @DT_REVIEWED, @to = @DT_REVIEWED, @EMP_ID = @EMP_ID, @STATUS = 1 
		END
	ELSE IF @LOCATION = 'Eco Tower, BGC' OR @LOCATION = 'Net Square, BGC'
		BEGIN
			exec dbo.[sp_UpdateResourcePlanner] @from = @DT_REVIEWED, @to = @DT_REVIEWED, @EMP_ID = @EMP_ID, @STATUS = 2 
		END
END

GO
