﻿Public Interface IWeeklyReport

#Region "Database Field Map"

    Property WK_ID As Integer
    Property WK_RANGE_ID As Integer
    Property PROJ_ID As Short
    Property REWORK As Short
    Property REF_ID As String
    Property SUBJECT As String
    Property SEVERITY As Short
    Property INC_TYPE As Short
    Property EMP_ID As Integer
    Property PHASE As Short
    Property STATUS As Short
    Property DATE_STARTED As DateTime
    Property DATE_TARGET As DateTime
    Property DATE_FINISHED As DateTime
    Property DATE_CREATED As DateTime
    Property EFFORT_EST As Double
    Property ACT_EFFORT_WK As Double
    Property ACT_EFFORT As Double
    Property COMMENTS As String
    Property INBOUND_CONTACTS As Short

    'Function getMyTasks(ByVal empId As Integer) As List(Of WeeklyReportSet)
    'Function getTaskDetailByTaskId(ByVal taskID As Integer) As WeeklyReportSet
    'Function getTaskSummaryWeekly(ByVal empId As Integer, dateStart As DateTime) As List(Of WeeklyReportSet)
    Function InsertWeeklyReport(ByVal weeklyReport As WeeklyReportSet) As Boolean
    Function UpdateWeeklyReport(ByVal weeklyReport As WeeklyReportSet) As Boolean
    Function GetWeeklyReportsByWeekRangeID(ByVal weekRange As Integer, ByVal empID As Integer) As List(Of WeeklyReportSet)
    'Function GetAllTasks() As List(Of WeeklyReportSet)
#End Region

End Interface