USE [AIDE]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertLessonLearnt]    Script Date: 6/17/2019 7:31:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_InsertLessonLearnt]
	@REF_NO varchar(20),
	@EMP_ID int ,
	@PROBLEM varchar(max) ,
	@RESOLUTION varchar(max) ,
	@ACTION_NO varchar(20)
AS
BEGIN
	INSERT INTO [dbo].[LESSON_LEARNT]
	(
		[REF_NO],
		[EMP_ID],
		[PROBLEM],
		[RESOLUTION],
		[ACTION_NO]
	)
	VALUES
	(
		@REF_NO,
		@EMP_ID,
		@PROBLEM,
		@RESOLUTION,
		@ACTION_NO
	)
END

GO
