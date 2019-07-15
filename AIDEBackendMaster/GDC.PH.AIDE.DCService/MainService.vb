﻿Imports GDC.PH.AIDE.BusinessLayer

Public MustInherit Class MainService
    Inherits AMainService

    Private Shared ActionMgmt As ActionManagement
    Private Shared AssetsMgmt As AssetsManagement
    Private Shared BillabilityMgmt As BillabilityManagement
    Private Shared ProfileMgmt As ProfileManagement
    Private Shared ProjectMgmt As ProjectManagement
    Private Shared StatusMgmt As StatusManagement
    Private Shared EmployeeMgmt As EmployeeManagement
    Private Shared AttendanceMgmt As AttendanceManagement
    Private Shared TasksMgmt As TasksManagement
    Private Shared LessonLearntMgmt As LessonLearntManagement
    Private Shared SuccessRegisterMgmt As SuccessRegisterManagement
    Private Shared ContactListMgmt As ContactListManagement
    Private Shared ConcernMgmt As ConcernManagement
    Private Shared SkillsMgmt As SkillsManagement
    Private Shared ResourceMgmt As ResourcePlannerManagement
    Private Shared BirthdayMgmt As BirthdayManagement
    Private Shared CommendationsMgmt As CommendationsManagement
    Private Shared AnnouncementsMgmt As AnnouncementsManagement
    Private Shared LateMgmt As LateManagement
    Private Shared SabaLearningMgmt As SabaLearningManagement
    Private Shared ComcellMgmt As ComcellManagement
    Private Shared ComcellClockMgmt As ComcellClockManagement
	Private Shared WeeklyReportMgmt As WeeklyReportManagement
	Private Shared AuditSchedMgmt As AuditSchedManagement
    Private Shared SendCodeMgmt As SendCodeManagement
    Private Shared MailConfigMgmt As MailConfigManagement
    Private Shared WorkplaceAuditMgmt As WorkplaceAuditManagement
    Private Shared ContributorsMgmt As ContributorsManagement
    Private Shared MessageMgmt As MessageManagement
    Private _getActionLstByMessage As List(Of Action)

    Public Delegate Sub ResponseReceivedEventHandler(sender As Object, e As ResponseReceivedEventArgs)
    Public Event ResponseReceived As ResponseReceivedEventHandler

    Public Sub New()
        ActionMgmt = New ActionManagement()
        AssetsMgmt = New AssetsManagement()
        BillabilityMgmt = New BillabilityManagement()
        ProfileMgmt = New ProfileManagement()
        ProjectMgmt = New ProjectManagement()
        StatusMgmt = New StatusManagement()
        EmployeeMgmt = New EmployeeManagement()
        AttendanceMgmt = New AttendanceManagement()
        TasksMgmt = New TasksManagement()
        LessonLearntMgmt = New LessonLearntManagement()
        SuccessRegisterMgmt = New SuccessRegisterManagement()
        ContactListMgmt = New ContactListManagement()
        ConcernMgmt = New ConcernManagement()
        SkillsMgmt = New SkillsManagement
        ResourceMgmt = New ResourcePlannerManagement()
        BirthdayMgmt = New BirthdayManagement()
        CommendationsMgmt = New CommendationsManagement()
        AnnouncementsMgmt = New AnnouncementsManagement()
        LateMgmt = New LateManagement()
        SabaLearningMgmt = New SabaLearningManagement()
        ComcellMgmt = New ComcellManagement()
		AuditSchedMgmt = New AuditSchedManagement()
        ComcellClockMgmt = New ComcellClockManagement()
		WeeklyReportMgmt = New WeeklyReportManagement()
        SendCodeMgmt = New SendCodeManagement()
        MailConfigMgmt = New MailConfigManagement()
        WorkplaceAuditMgmt = New WorkplaceAuditManagement()
        ContributorsMgmt = New ContributorsManagement()
        MessageMgmt = New MessageManagement()
    End Sub

    Protected Overridable Sub OnReceivedResponse(e As ResponseReceivedEventArgs)
        RaiseEvent ResponseReceived(Me, e)
    End Sub

    Public Overridable Sub ReceivedData(ByVal state As StateData)
        Dim e As New ResponseReceivedEventArgs(state.NotifyType, state)
        OnReceivedResponse(e)
    End Sub

    Public Overrides Function GetMyProfile(emailAddress As String, ByRef objResult As Profile) As Boolean
        Dim state As StateData = ProfileMgmt.GetProfileByEmailAddress(emailAddress)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function GetProfile(empID As String, ByRef objResult As Profile) As Boolean
        Dim state As StateData = ProfileMgmt.GetProfile(empID)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    'Public Overrides Function UpdateProfile(profile As Profile) As Boolean
    '    Dim state As StateData = ProfileMgmt.UpdateProfile(profile)
    '    Dim bSuccess As Boolean = False
    '    If state.NotifyType = NotifyType.IsSuccess Then
    '        bSuccess = True
    '    End If
    '    ReceivedData(state)
    '    Return bSuccess
    'End Function

    Public Overrides Function GetContact(empID As Integer, ByRef objResult As Contact) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Function GetContactsList(ByRef objResult As List(Of Contact)) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Function UpdateContact(contact As Contact) As Boolean
        Throw New NotImplementedException()
    End Function

    

    'Public Overrides Function GetAllEmployees(ByRef objResult As List(Of Employee)) As Boolean
    '    Dim state As StateData = EmployeeMgmt.GetEmployeeList()
    '    Dim bSuccess As Boolean = False
    '    If state.NotifyType = NotifyType.IsSuccess Then
    '        bSuccess = True
    '        objResult = state.Data
    '    End If
    '    ReceivedData(state)
    '    Return bSuccess
    'End Function

    Public Overrides Function GetEmployee(empId As Integer, ByRef objResult As Employee) As Boolean
        Dim state As StateData = EmployeeMgmt.GetEmployee(empId)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function UpdateEmployee(emp As Employee) As Boolean
        Dim state As StateData = EmployeeMgmt.UpdateEmployee(emp)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    'Public Overrides Function CreateNewProject(project As Project, assignProject As List(Of AssignedProject)) As Boolean
    '    Dim state As StateData = ProjectMgmt.CreateNewProject(project, assignProject)
    '    Dim bSuccess As Boolean = False
    '    If state.NotifyType = NotifyType.IsSuccess Then
    '        bSuccess = True
    '    End If
    '    ReceivedData(state)
    '    Return bSuccess
    'End Function

    'Public Overrides Function ViewProjectList(Project As ViewProject, ByRef objResult As List(Of ViewProject)) As Boolean
    'Public Overrides Function ViewProjectList(ByRef objResult As List(Of ViewProject)) As Boolean
    '    Dim state As StateData = ProjectMgmt.ViewProject()
    '    Dim bSuccess As Boolean = False
    '    If state.NotifyType = NotifyType.IsSuccess Then
    '        objResult = state.Data
    '        bSuccess = True
    '    End If
    '    ReceivedData(state)
    '    Return bSuccess
    'End Function

    'Public Overrides Function GetProjectsList(ByRef objResult As List(Of Project)) As Boolean
    '    Throw New NotImplementedException()
    'End Function

    'Public Overrides Function UpdateAssignedProject(project As Project, assignProj As List(Of AssignedProject)) As Boolean
    '    Throw New NotImplementedException()
    'End Function

    'Public Overrides Function AssignProjectToEmployee(Project As AssignedProject) As Boolean
    '    Throw New NotImplementedException()
    'End Function

    Public Function GetGenericStatusList(ByVal GroupID As Short, ByRef objResult As List(Of StatusGroup)) As Boolean
        Dim state As StateData = StatusMgmt.getGenericStatus(GroupID)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

#Region "Action List"

    ''' <summary>
    ''' By Jester Sanchez/ Lemuela Abulencia
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Function InsertActionLst(ByVal _Action As Action) As Boolean
        Dim state As StateData = ActionMgmt.InsertAction(_Action)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function GetActionSummry(ByVal email As String, ByRef objResult As List(Of Action)) As Boolean
        Dim state As StateData = ActionMgmt.GetActionList(email)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = False
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function UpdateActionLst(ByVal _Action As Action) As Boolean
        Dim state As StateData = ActionMgmt.UpdateAction(_Action)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function GetActionLstByMessage(ByVal _Message As String, ByVal email As String, ByRef objResult As List(Of Action)) As Boolean
        Dim state As StateData = ActionMgmt.GetActionByMessage(_Message, email)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = False
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function
#End Region

    ''' <summary>
    ''' By John Harvey Sanchez / Marivic Espino
    ''' </summary>
#Region "Lessons Learnt"
    Public Overrides Function GetAllLessonLearntList(ByRef email As String, ByRef objResult As List(Of LessonLearnt)) As Boolean
        Dim state As StateData = LessonLearntMgmt.GetLessonLearntList(email)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function GetLessonLearntByProblems(ByRef searchProblem As String, ByRef email As String, ByRef objResult As List(Of LessonLearnt)) As Boolean
        Dim state As StateData = LessonLearntMgmt.GetLessonLearntListByProblem(searchProblem, email)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function UpdateLessonLearnt(ByRef lessonLearnt As LessonLearnt) As Boolean
        Dim state As StateData = LessonLearntMgmt.UpdateLessonLearnt(lessonLearnt)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function CreateNewLessonLearnt(ByRef lessonLearnt As LessonLearnt) As Boolean
        Dim state As StateData = LessonLearntMgmt.CreateNewLessonLearnt(lessonLearnt)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function
#End Region

    ''' <summary>
    ''' By Aevan Camille Batongbacal
    ''' </summary>
#Region "Success Register"

    Public Overrides Function CreateSuccessRegister(success As SuccessRegister) As Boolean
        Dim state As StateData = SuccessRegisterMgmt.CreateSuccessRegister(success)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function DeleteSuccessRegister(successID As Integer) As Boolean
        Dim state As StateData = SuccessRegisterMgmt.DeleteSuccessRegister(successID)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function UpdateSuccessRegister(success As SuccessRegister) As Boolean
        Dim state As StateData = SuccessRegisterMgmt.UpdateSuccessRegister(success)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function GetSuccessRegisterBySearch(input As String, email As String) As List(Of SuccessRegister)
        Dim state As StateData = SuccessRegisterMgmt.GetSuccessRegisterBySearch(input, email)
        Dim lstSuccessRegisterList As New List(Of SuccessRegister)

        If Not IsNothing(state.Data) Then
            Dim lstSuccessRegister As List(Of SuccessRegister) = DirectCast(state.Data, List(Of SuccessRegister))
            For Each _list As SuccessRegister In lstSuccessRegister
                Dim item As New SuccessRegister

                item.SuccessID = _list.SuccessID
                item.Emp_ID = _list.Emp_ID
                item.Nick_Name = _list.Nick_Name
                item.DateInput = _list.DateInput
                item.DetailsOfSuccess = _list.DetailsOfSuccess
                item.WhosInvolve = _list.WhosInvolve
                item.AdditionalInformation = _list.AdditionalInformation

                lstSuccessRegisterList.Add(item)
            Next
        End If
        Return lstSuccessRegisterList
    End Function

    Public Overrides Function GetSuccessRegisterByEmpID(email As String) As List(Of SuccessRegister)
        Dim state As StateData = SuccessRegisterMgmt.GetSuccessRegisterByEmpID(email)
        Dim lstSuccessRegisterList As New List(Of SuccessRegister)

        If Not IsNothing(state.Data) Then
            Dim lstSuccessRegister As List(Of SuccessRegister) = DirectCast(state.Data, List(Of SuccessRegister))
            For Each _list As SuccessRegister In lstSuccessRegister
                Dim item As New SuccessRegister

                item.SuccessID = _list.SuccessID
                item.Emp_ID = _list.Emp_ID
                item.Nick_Name = _list.Nick_Name
                item.DateInput = _list.DateInput
                item.DetailsOfSuccess = _list.DetailsOfSuccess
                item.WhosInvolve = _list.WhosInvolve
                item.AdditionalInformation = _list.AdditionalInformation

                lstSuccessRegisterList.Add(item)
            Next
        End If
        Return lstSuccessRegisterList
    End Function

    Public Overrides Function GetSuccessRegisterAll(email As String) As List(Of SuccessRegister)
        Dim state As StateData = SuccessRegisterMgmt.GetSuccessRegisterAll(email)
        Dim lstSuccessRegisterList As New List(Of SuccessRegister)

        If Not IsNothing(state.Data) Then
            Dim lstSuccessRegister As List(Of SuccessRegister) = DirectCast(state.Data, List(Of SuccessRegister))
            For Each _list As SuccessRegister In lstSuccessRegister
                Dim item As New SuccessRegister

                item.SuccessID = _list.SuccessID
                item.Emp_ID = _list.Emp_ID
                item.Nick_Name = _list.Nick_Name
                item.DateInput = _list.DateInput
                item.DetailsOfSuccess = _list.DetailsOfSuccess
                item.WhosInvolve = _list.WhosInvolve
                item.AdditionalInformation = _list.AdditionalInformation

                lstSuccessRegisterList.Add(item)
            Next
        End If
        Return lstSuccessRegisterList
    End Function

    'For the list of Nickname for the combobox
    Public Overrides Function GetNicknameByDeptID(email As String, toDisplay As Integer) As List(Of Nickname)
        Dim state As StateData = SuccessRegisterMgmt.GetNicknameByDeptID(email, toDisplay)
        Dim lstNicknameList As New List(Of Nickname)

        If Not IsNothing(state.Data) Then
            Dim lstNickname As List(Of Nickname) = DirectCast(state.Data, List(Of Nickname))
            For Each _list As Nickname In lstNickname
                Dim item As New Nickname

                item.Emp_ID = _list.Emp_ID
                item.Nick_Name = _list.Nick_Name
                item.First_Name = _list.First_Name
                item.Employee_Name = _list.Employee_Name

                lstNicknameList.Add(item)
            Next
        End If
        Return lstNicknameList
    End Function
#End Region

    ''' <summary>
    ''' By Aevan Camille Batongbacal
    ''' </summary>
#Region "Contact List "
    Public Overrides Function GetContactListAll(email As String, selection As Integer) As List(Of ContactList)
        Dim state As StateData = ContactListMgmt.GetContactListAll(email, selection)
        Dim lstContactList As New List(Of ContactList)

        If Not IsNothing(state.Data) Then
            Dim lstContacts As List(Of ContactList) = DirectCast(state.Data, List(Of ContactList))
            For Each _list As ContactList In lstContacts
                Dim item As New ContactList

                item.EmpID = _list.EmpID
                item.EMADDRESS = _list.EMADDRESS
                item.EMADDRESS2 = _list.EMADDRESS2
                item.POSITION = _list.POSITION
                item.MARITAL_STATUS = _list.MARITAL_STATUS
                item.HOUSEPHONE = _list.HOUSEPHONE
                item.OTHERPHONE = _list.OTHERPHONE
                item.LOC = _list.LOC
                item.lOCAL = _list.lOCAL
                item.CELL_NO = _list.CELL_NO
                item.DateReviewed = _list.DateReviewed
                item.FIRST_NAME = _list.FIRST_NAME
                item.LAST_NAME = _list.LAST_NAME
                item.IMAGE_PATH = _list.IMAGE_PATH
                item.MIDDLE_NAME = _list.MIDDLE_NAME
                item.Nick_Name = _list.Nick_Name
                item.ACTIVE = _list.ACTIVE
                'item.STATUS = _list.STATUS
                item.PERMISSION_GROUP = _list.PERMISSION_GROUP
                item.DEPARTMENT = _list.DEPARTMENT
                item.DIVISION = _list.DIVISION
                item.SHIFT = _list.SHIFT
                item.BIRTHDATE = _list.BIRTHDATE
                item.DT_HIRED = _list.DT_HIRED
                item.MARITAL_STATUS_ID = _list.MARITAL_STATUS_ID
                item.POSITION_ID = _list.POSITION_ID
                item.PERMISSION_GROUP_ID = _list.PERMISSION_GROUP_ID
                item.DEPARTMENT_ID = _list.DEPARTMENT_ID
                item.DIVISION_ID = _list.DIVISION_ID

                lstContactList.Add(item)
            Next
        End If
        Return lstContactList
    End Function
    Public Overrides Function UpdateContactList(contacts As ContactList, selection As Integer) As Boolean
        Dim state As StateData = ContactListMgmt.UpdateContactList(contacts, selection)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function
    Public Overrides Function CreateContact(contacts As ContactList) As Boolean
        Dim state As StateData = ContactListMgmt.CreateContactList(contacts)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function
#End Region

    ''' <summary>
    ''' By Aevan Camille Batongbacal
    ''' </summary>
#Region "Birthday List "
    Public Overrides Function GetBirthdayListAll(email As String) As List(Of BirthdayList)
        Dim state As StateData = BirthdayMgmt.GetBirthdayListAll(email)
        Dim lstBirthdayList As New List(Of BirthdayList)

        If Not IsNothing(state.Data) Then
            Dim lstContacts As List(Of BirthdayList) = DirectCast(state.Data, List(Of BirthdayList))
            For Each _list As BirthdayList In lstContacts
                Dim item As New BirthdayList

                item.EmpID = _list.EmpID
                item.BIRTHDAY = _list.BIRTHDAY
                item.FIRST_NAME = _list.FIRST_NAME
                item.LAST_NAME = _list.LAST_NAME
                item.IMAGE_PATH = _list.IMAGE_PATH

                lstBirthdayList.Add(item)
            Next
        End If
        Return lstBirthdayList
    End Function

    Public Overrides Function GetBirthdayListByMonth(email As String) As List(Of BirthdayList)
        Dim state As StateData = BirthdayMgmt.GetBirthdayListAllByMonth(email)
        Dim lstBirthdayList As New List(Of BirthdayList)

        If Not IsNothing(state.Data) Then
            Dim lstContacts As List(Of BirthdayList) = DirectCast(state.Data, List(Of BirthdayList))
            For Each _list As BirthdayList In lstContacts
                Dim item As New BirthdayList

                item.EmpID = _list.EmpID
                item.BIRTHDAY = _list.BIRTHDAY
                item.FIRST_NAME = _list.FIRST_NAME
                item.LAST_NAME = _list.LAST_NAME
                item.IMAGE_PATH = _list.IMAGE_PATH

                lstBirthdayList.Add(item)
            Next
        End If
        Return lstBirthdayList
    End Function

    Public Overrides Function GetBirthdayListByDay(email As String) As List(Of BirthdayList)
        Dim state As StateData = BirthdayMgmt.GetBirthdayListAllByDay(email)
        Dim lstBirthdayList As New List(Of BirthdayList)

        If Not IsNothing(state.Data) Then
            Dim lstContacts As List(Of BirthdayList) = DirectCast(state.Data, List(Of BirthdayList))
            For Each _list As BirthdayList In lstContacts
                Dim item As New BirthdayList

                item.EmpID = _list.EmpID
                item.BIRTHDAY = _list.BIRTHDAY
                item.FIRST_NAME = _list.FIRST_NAME
                item.LAST_NAME = _list.LAST_NAME
                item.IMAGE_PATH = _list.IMAGE_PATH

                lstBirthdayList.Add(item)
            Next
        End If
        Return lstBirthdayList
    End Function
    '''''''''''''''''''''''''''''''''
    '   AEVAN CAMILLE BATONGBACAL   '
    '           END                 '
    '''''''''''''''''''''''''''''''''
#End Region

#Region "Concern Function"

    ''DISPLAY
    ''' <summary>
    ''' GIANN CALRO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="email"></param>
    ''' <param name="offsetVal"></param>
    ''' <param name="nextVal"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function selectAllConcern(email As String, offsetVal As Integer, nextVal As Integer) As List(Of Concern)
        Dim state As StateData = ConcernMgmt.selectAllConcern(email, offsetVal, nextVal)
        Dim lstConcernList As New List(Of Concern)

        If Not IsNothing(state.Data) Then
            Dim lstConcern As List(Of Concern) = DirectCast(state.Data, List(Of Concern))
            For Each _list As Concern In lstConcern
                Dim item As New Concern

                item.RefID = _list.RefID
                item.Concerns = _list.Concerns
                item.Cause = _list.Cause
                item.CounterMeasure = _list.CounterMeasure
                item.Act_Reference = _list.Act_Reference
                item.Status = _list.Status

                item.Due_Date = _list.Due_Date
                item.EmpID = _list.EmpID
                item.GENERATEDREF_ID = _list.GENERATEDREF_ID
                lstConcernList.Add(item)
            Next
        End If
        Return lstConcernList
    End Function

    ''SEARCH
    ''' <summary>
    ''' GIANN CALRO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="email"></param>
    ''' <param name="_searchKeyWord"></param>
    ''' <param name="offsetVal"></param>
    ''' <param name="nextVal"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function GetResultSearch(email As String, _searchKeyWord As String, offsetVal As Integer, nextVal As Integer) As List(Of Concern)

        Dim state As StateData = ConcernMgmt.GetResultSearch(email, _searchKeyWord, offsetVal, nextVal)
        Dim lstConcernList As New List(Of Concern)

        If Not IsNothing(state.Data) Then
            Dim lstConcern As List(Of Concern) = DirectCast(state.Data, List(Of Concern))
            For Each _list As Concern In lstConcern
                Dim item As New Concern

                item.RefID = _list.RefID
                item.Concerns = _list.Concerns
                item.Cause = _list.Cause
                item.CounterMeasure = _list.CounterMeasure
                item.Act_Reference = _list.Act_Reference
                item.Status = _list.Status

                item.Due_Date = _list.Due_Date
                item.EmpID = _list.EmpID
                item.GENERATEDREF_ID = _list.GENERATEDREF_ID
                lstConcernList.Add(item)
            Next
        End If
        Return lstConcernList
    End Function

    ''INSERT
    ''' <summary>
    ''' ''' GIANN CALRO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="concern"></param>
    ''' <param name="email"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function InsertIntoConcerns(concern As Concern, email As String) As Boolean
        Dim state As StateData = ConcernMgmt.InsertIntoConcerns(concern, email)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    ''GET GENERATED
    ''' <summary>
    ''' ''' GIANN CALRO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="objResult"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function GetGeneratedRefNo(ByRef objResult As Concern) As Boolean
        Dim state As StateData = ConcernMgmt.GetGeneratedRefNo()
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    ''DISPLAY TO LISTVIEW  ACTION LIST
    ''' <summary>
    ''' ''' GIANN CALRO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="Ref_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function GetListOfACtion(Ref_id As String, email As String) As List(Of Concern)
        Dim state As StateData = ConcernMgmt.GetListOfACtion(Ref_id, email)
        Dim lstConcernList As New List(Of Concern)

        If Not IsNothing(state.Data) Then
            Dim lstConcern As List(Of Concern) = DirectCast(state.Data, List(Of Concern))
            For Each _list As Concern In lstConcern
                Dim item As New Concern

                item.ACTREF = _list.ACTREF
                item.ACT_MESSAGE = _list.ACT_MESSAGE
                item.Due_Date = _list.Due_Date
                lstConcernList.Add(item)
            Next
        End If
        Return lstConcernList
    End Function

    ''DISPLAY TO LISTVIEW  ACTION REFERENCES
    ''' <summary>
    ''' ''' GIANN CALRO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="Ref_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function GetListOfACtionsReferences(Ref_id As String) As List(Of Concern)
        Dim state As StateData = ConcernMgmt.GetListOfACtionsReferences(Ref_id)
        Dim lstConcernList As New List(Of Concern)

        If Not IsNothing(state.Data) Then
            Dim lstConcern As List(Of Concern) = DirectCast(state.Data, List(Of Concern))
            For Each _list As Concern In lstConcern
                Dim item As New Concern

                item.ACTION_REFERENCES = _list.ACTION_REFERENCES

                item.ACTREF = _list.ACTREF

                lstConcernList.Add(item)
            Next
        End If
        Return lstConcernList
    End Function

    ''INSERT selected action
    ''' <summary>
    ''' ''' GIANN CALRO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="concern"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function insertAndDeleteSelectedAction(concern As Concern) As Boolean
        Dim state As StateData = ConcernMgmt.insertAndDeleteSelectedAction(concern)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    ''UPDATE selected CONCERN
    ''' <summary>
    ''' ''' GIANN CALRO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="concern"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function UpdateSelectedConcern(concern As Concern) As Boolean
        Dim state As StateData = ConcernMgmt.UpdateSelectedConcern(concern)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    ''DISPLAY between
    ''' <summary>
    ''' ''' GIANN CALRO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="email"></param>
    ''' <param name="offsetVal"></param>
    ''' <param name="nextVal"></param>
    ''' <param name="date1"></param>
    ''' <param name="date2"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function GetBetweenSearchConcern(email As String, offsetVal As Integer, nextVal As Integer, date1 As Date, date2 As Date) As List(Of Concern)
        Dim state As StateData = ConcernMgmt.GetBetweenSearchConcern(email, offsetVal, nextVal, date1, date2)
        Dim lstConcernList As New List(Of Concern)

        If Not IsNothing(state.Data) Then
            Dim lstConcern As List(Of Concern) = DirectCast(state.Data, List(Of Concern))
            For Each _list As Concern In lstConcern
                Dim item As New Concern

                item.RefID = _list.RefID
                item.Concerns = _list.Concerns
                item.Cause = _list.Cause
                item.CounterMeasure = _list.CounterMeasure
                item.Act_Reference = _list.Act_Reference
                item.Status = _list.Status

                item.Due_Date = _list.Due_Date
                item.EmpID = _list.EmpID
                item.GENERATEDREF_ID = _list.GENERATEDREF_ID
                lstConcernList.Add(item)
            Next
        End If
        Return lstConcernList
    End Function

    ''DISPLAY TO LISTVIEW  ACTION LIST VIA SEARCH
    ''' <summary>
    ''' ''' GIANN CALRO CAMILO/CHRISTIAN VALONDO
    ''' </summary>
    ''' <param name="_keywordAction"></param>
    ''' <param name="Ref_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function GetSearchAction(_keywordAction As String, Ref_id As String, email As String) As List(Of Concern)
        Dim state As StateData = ConcernMgmt.GetSearchAction(_keywordAction, Ref_id, email)
        Dim lstConcernList As New List(Of Concern)

        If Not IsNothing(state.Data) Then
            Dim lstConcern As List(Of Concern) = DirectCast(state.Data, List(Of Concern))
            For Each _list As Concern In lstConcern
                Dim item As New Concern

                item.ACTREF = _list.ACTREF
                item.ACT_MESSAGE = _list.ACT_MESSAGE
                item.Due_Date = _list.Due_Date
                lstConcernList.Add(item)
            Next
        End If
        Return lstConcernList
    End Function

#End Region

#Region "Skills"
    ''' <summary>
    ''' By Jhunell G. Barcenas
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GetAllSkillsList() As List(Of Skills)
        Dim state As StateData = SkillsMgmt.GetSkillsList
        Dim skillsLst As New List(Of Skills)

        If Not IsNothing(state.Data) Then
            Dim skills As List(Of Skills) = DirectCast(state.Data, List(Of Skills))
            For Each _list As Skills In skills
                Dim item As New Skills

                item.SkillID = _list.SkillID
                item.DESCR = _list.DESCR

                skillsLst.Add(item)
            Next
        End If
        Return skillsLst
    End Function

    Public Overrides Function GetProfLvlByEmpIDSkillID(id As Integer, skillid As Integer, ByRef objResult As Skills) As Boolean
        Dim state As StateData = SkillsMgmt.GetProfLvlByEmpIDSkillID(id, skillid)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        'ReceivedData(state)
        Return bSuccess
    End Function

    Public Overridable Function GetSkillsProfByEmpID(ByVal id As Integer) As List(Of Skills)
        Dim state As StateData = SkillsMgmt.GetSkillsByEmpID(id)
        Dim skillsLst As New List(Of Skills)

        If Not IsNothing(state.Data) Then
            Dim skills As List(Of Skills) = DirectCast(state.Data, List(Of Skills))
            For Each _list As Skills In skills
                Dim item As New Skills

                item.EmpID = _list.EmpID
                item.NAME = _list.NAME
                item.DESCR = _list.DESCR
                item.Prof_LVL = _list.Prof_LVL
                item.Last_Reviewed = _list.Last_Reviewed

                skillsLst.Add(item)
            Next
        End If
        Return skillsLst
    End Function

    Public Function InsertNewSkills(skills As Skills) As Boolean
        Dim state As StateData = SkillsMgmt.InsertNewSkills(skills)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        'ReceivedData(state)
        Return bSuccess
    End Function

    Public Function UpdateSkills(skills As Skills) As Boolean
        Dim state As StateData = SkillsMgmt.UpdateSkills(skills)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        'ReceivedData(state)
        Return bSuccess
    End Function

    Public Function UpdateAllSkills(skills As Skills) As Boolean
        Dim state As StateData = SkillsMgmt.UpdateAllSkills(skills)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        'ReceivedData(state)
        Return bSuccess
    End Function

    Public Function ViewAllEmpSkills(empID As Integer) As List(Of Skills)
        Dim state As StateData = SkillsMgmt.ViewAllEmpSKills(empID)
        Dim skillsLst As New List(Of Skills)

        If Not IsNothing(state.Data) Then
            Dim skills As List(Of Skills) = DirectCast(state.Data, List(Of Skills))
            For Each _list As Skills In skills
                Dim item As New Skills

                item.EmpID = _list.EmpID
                item.NAME = _list.NAME
                item.DESCR = _list.DESCR
                item.Prof_LVL = _list.Prof_LVL
                item.Last_Reviewed = _list.Last_Reviewed

                skillsLst.Add(item)
            Next
        End If
        Return skillsLst
    End Function

    Public Overrides Function GetSkillsLastReviewByEmpIDSkillID(id As Integer, skillid As Integer, ByRef objResult As Skills) As Boolean
        Dim state As StateData = SkillsMgmt.GetSkillsLastReviewByEmpIDSkillID(id, skillid)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        'ReceivedData(state)
        Return bSuccess
    End Function
#End Region

#Region "Projects"
    Public Overrides Function AssignProjectToEmployee(Project As AssignedProject) As Boolean
        Throw New NotImplementedException()
    End Function
    ''' <summary>
    ''' GIANN CALRO CAMILO/LEMUELA ABULENCIA
    ''' </summary>
    ''' <param name="assignProject"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function CreateNewAssignedProject(assignProject As List(Of AssignedProject)) As Boolean
        Dim state As StateData = ProjectMgmt.CreateNewAssignedProject(assignProject)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function CreateNewProject(project As Project) As Boolean
        Dim state As StateData = ProjectMgmt.CreateNewProject(project)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function GetProjectByProjID(ByVal projID As Integer, ByRef objResult As Project) As Boolean
        Dim state As StateData = ProjectMgmt.GetProjectByID(projID)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function GetProjectsList(ByRef objResult As List(Of Project), ByVal EmpID As Integer) As Boolean
        Dim state As StateData = ProjectMgmt.GetProjectLists(EmpID)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            objResult = state.Data
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function



    ''' <summary>
    ''' LIST OF PROJECT
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function GetAllListOfProject(ByVal EmpID As Integer) As List(Of Project)
        Dim state As StateData = ProjectMgmt.GetProjectLists(EmpID)
        Dim lstConcernList As New List(Of Project)

        If Not IsNothing(state.Data) Then
            Dim lstConcern As List(Of Project) = DirectCast(state.Data, List(Of Project))
            For Each _list As Project In lstConcern
                Dim item As New Project

                item.EmpID = _list.EmpID
                item.ProjectID = _list.ProjectID
                item.ProjectName = _list.ProjectName
                item.Category = _list.Category
                item.Billability = _list.Billability


                lstConcernList.Add(item)
            Next
        End If
        Return lstConcernList

    End Function

    'Public Overrides Function ViewProjectList(Project As ViewProject, ByRef objResult As List(Of ViewProject)) As Boolean
    ''' <summary>
    ''' GIANN CALRO CAMILO/LEMUELA ABULENCIA
    ''' </summary>
    ''' <param name="objResult"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function ViewProjectList(ByRef objResult As List(Of ViewProject)) As Boolean
        Dim state As StateData = ProjectMgmt.ViewProject()
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            objResult = state.Data
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function
    Public Overrides Function UpdateAssignedProject(project As Project) As Boolean
        Dim state As StateData = ProjectMgmt.UpdateProject(project)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    'Public Overrides Function ViewProjectList(Project As ViewProject, ByRef objResult As List(Of ViewProject)) As Boolean
    ''' <summary>
    ''' GIANN CALRO CAMILO/LEMUELA ABULENCIA
    ''' </summary>
    ''' <param name="objResult"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function ViewProjectListofEmployee(ByVal empID As Integer, ByRef objResult As List(Of ViewProject)) As Boolean
        Dim state As StateData = ProjectMgmt.ViewProjectListofEmployee(empID)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            objResult = state.Data
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function


    'For the list of Employee Per Porject for the combobox
    Public Overrides Function GetEmployeePerProject(empID As Integer, projID As Integer) As List(Of Nickname)
        Dim state As StateData = ProjectMgmt.GetEmployeePerProject(empID, projID)
        Dim lstNicknameList As New List(Of Nickname)

        If Not IsNothing(state.Data) Then
            Dim lstNickname As List(Of Nickname) = DirectCast(state.Data, List(Of Nickname))
            For Each _list As Nickname In lstNickname
                Dim item As New Nickname

                item.Emp_ID = _list.Emp_ID
                item.Nick_Name = _list.Nick_Name

                lstNicknameList.Add(item)
            Next
        End If
        Return lstNicknameList
    End Function
#End Region

#Region "Employee"

    Public Overrides Function GetAllEmployees(ByRef objResult As List(Of Employee)) As Boolean
        Dim state As StateData = EmployeeMgmt.GetEmployeeList()
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function GetNicknameByDeptID(ByVal email As String, ByRef objResult As List(Of Employee)) As Boolean
        Dim state As StateData = EmployeeMgmt.GetNicknameByDeptID(email)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function
#End Region

#Region "Tasks"
    Public Overrides Function CreateNewTask(task As Tasks) As Boolean
        Dim state As StateData = TasksMgmt.CreateNewTask(task)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    ' Get this Function
    Public Overrides Function GetTasksAll(ByRef objResult As List(Of Tasks)) As Boolean
        Dim state As StateData = TasksMgmt.GetTasksAll()
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function ViewEmployeeTaskSummry(empId As Integer, Current_Date As Date, ByRef objResult As List(Of TaskSummary)) As Boolean
        Dim state As StateData = TasksMgmt.ViewTaskByEmployee(empId, Current_Date)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    ' Get this Function
    Public Overrides Function ViewTasksSummaryAll(Current_Date As Date, email As String, ByRef objResult As List(Of TaskSummary)) As Boolean
        Dim state As StateData = TasksMgmt.ViewTaskAll(Current_Date, email)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function ViewMyTasks(empId As Integer, ByRef objResult As List(Of Tasks)) As Boolean
        Dim state As StateData = TasksMgmt.ViewMyTasks(empId)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function UpdateEmployeeTask(Task As Tasks) As Boolean
        Dim state As StateData = TasksMgmt.UpdateTask(Task)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function GetTasksByEmpID(ByVal empID As Integer) As List(Of Tasks)
        Dim state As StateData = TasksMgmt.GetTasksByEmpID(empID)
        Dim tasksLst As New List(Of Tasks)

        If Not IsNothing(state.Data) Then
            Dim skills As List(Of Tasks) = DirectCast(state.Data, List(Of Tasks))
            For Each _list As Tasks In skills
                Dim item As New Tasks

                item.TaskID = _list.TaskID
                item.ProjectID = _list.ProjectID
                item.ProjectCode = _list.ProjectCode
                item.Rework = _list.Rework
                item.ReferenceID = _list.ReferenceID
                item.IncidentDescr = _list.IncidentDescr
                item.Severity = _list.Severity
                item.IncidentType = _list.IncidentType
                item.EmpID = _list.EmpID
                item.Phase = _list.Phase
                item.Status = _list.Status
                item.DateStarted = _list.DateStarted
                item.TargetDate = _list.TargetDate
                item.CompletedDate = _list.CompletedDate
                item.DateCreated = _list.DateCreated
                item.EffortEst = _list.EffortEst
                item.ActualEffort = _list.ActualEffort
                item.ActualEffortWk = _list.ActualEffortWk
                item.Comments = _list.Comments
                item.Others1 = _list.Others1
                item.Others2 = _list.Others2
                item.Others3 = _list.Others3

                tasksLst.Add(item)
            Next
        End If
        Return tasksLst
    End Function

#End Region

#Region "Status"

    Public Overrides Function GetAttendanceStatusList(ByRef objResult As List(Of StatusGroup)) As Boolean
        Dim state As StateData = StatusMgmt.getAttendanceStatus()
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function GetCivilStatusList(ByRef objResult As List(Of StatusGroup)) As Boolean
        Dim state As StateData = StatusMgmt.getCivil()
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    ' Get this Function
    Public Overrides Function GetTaskStatusList(ByRef objResult As List(Of StatusGroup)) As Boolean
        Dim state As StateData = StatusMgmt.GetTaskStatus()
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    ' Get this Function
    Public Overrides Function GetTaskCategoriesList(ByRef objResult As List(Of StatusGroup)) As Boolean
        Dim state As StateData = StatusMgmt.GetTaskCategories()
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    ' Get this Function
    Public Overrides Function GetPhaseStatusList(ByRef objResult As List(Of StatusGroup)) As Boolean
        Dim state As StateData = StatusMgmt.GetPhaseStatus()
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    ' Get this Function
    Public Overrides Function GetReworkStatusList(ByRef objResult As List(Of StatusGroup)) As Boolean
        Dim state As StateData = StatusMgmt.GetReworkStatus()
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function
#End Region

#Region "Resource Planner"
    ''' <summary>
    ''' By Jhunell G. Barcenas / John Harvey Sanchez
    ''' </summary>
    ''' <remarks></remarks>
    Public Function UpdateResourcePlanner(resource As ResourcePlanner) As Boolean
        Dim state As StateData = ResourceMgmt.UpdateResourcePlanner(resource)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        'ReceivedData(state)
        Return bSuccess
    End Function

    Public Function InsertResourcePlanner(resource As ResourcePlanner) As Boolean
        Dim state As StateData = ResourceMgmt.InsertResourcePlanner(resource)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        'ReceivedData(state)
        Return bSuccess
    End Function

    Public Function ViewEmpResourcePlanners(email As String) As List(Of ResourcePlanner)
        Dim state As StateData = ResourceMgmt.ViewEmpResourcePlanner(email)
        Dim resourceLst As New List(Of ResourcePlanner)

        If Not IsNothing(state.Data) Then
            Dim resource As List(Of ResourcePlanner) = DirectCast(state.Data, List(Of ResourcePlanner))
            For Each _list As ResourcePlanner In resource
                Dim item As New ResourcePlanner

                item.EmpID = _list.EmpID
                item.NAME = _list.NAME
                item.Image_Path = _list.Image_Path

                resourceLst.Add(item)
            Next
        End If
        Return resourceLst
    End Function

    Public Function GetStatusResourcePlanners() As List(Of ResourcePlanner)
        Dim state As StateData = ResourceMgmt.GetStatusResourcePlanner
        Dim resourceLst As New List(Of ResourcePlanner)

        If Not IsNothing(state.Data) Then
            Dim resource As List(Of ResourcePlanner) = DirectCast(state.Data, List(Of ResourcePlanner))
            For Each _list As ResourcePlanner In resource
                Dim item As New ResourcePlanner

                item.DESCR = _list.DESCR
                item.Status = _list.Status

                resourceLst.Add(item)
            Next
        End If
        Return resourceLst
    End Function

    Public Overrides Function GetResourcePlannerByEmpID(empID As Integer, deptID As Integer, month As Integer, year As Integer) As List(Of ResourcePlanner)
        Dim state As StateData = ResourceMgmt.GetResourcePlannerByEmpID(empID, deptID, month, year)
        Dim resourceLst As New List(Of ResourcePlanner)

        If Not IsNothing(state.Data) Then
            Dim resource As List(Of ResourcePlanner) = DirectCast(state.Data, List(Of ResourcePlanner))
            For Each _list As ResourcePlanner In resource
                Dim item As New ResourcePlanner

                item.DateEntry = _list.DateEntry
                item.Status = _list.Status

                resourceLst.Add(item)
            Next
        End If
        Return resourceLst
    End Function

    Public Overrides Function GetAllEmpResourcePlanner(email As String, month As Integer, year As Integer) As List(Of ResourcePlanner)
        Dim state As StateData = ResourceMgmt.GetAllEmpResourcePlanner(email, month, year)
        Dim resourceLst As New List(Of ResourcePlanner)

        If Not IsNothing(state.Data) Then
            Dim resource As List(Of ResourcePlanner) = DirectCast(state.Data, List(Of ResourcePlanner))
            For Each _list As ResourcePlanner In resource
                Dim item As New ResourcePlanner

                item.EmpID = _list.EmpID
                item.NAME = _list.NAME
                item.DateEntry = _list.DateEntry
                item.Status = _list.Status

                resourceLst.Add(item)
            Next
        End If
        Return resourceLst
    End Function

    Public Overrides Function GetAllEmpResourcePlannerByStatus(email As String, month As Integer, year As Integer, status As Integer) As List(Of ResourcePlanner)
        Dim state As StateData = ResourceMgmt.GetAllEmpResourcePlannerByStatus(email, month, year, status)
        Dim resourceLst As New List(Of ResourcePlanner)

        If Not IsNothing(state.Data) Then
            Dim resource As List(Of ResourcePlanner) = DirectCast(state.Data, List(Of ResourcePlanner))
            For Each _list As ResourcePlanner In resource
                Dim item As New ResourcePlanner

                item.EmpID = _list.EmpID
                item.NAME = _list.NAME
                item.DateEntry = _list.DateEntry
                item.Status = _list.Status

                resourceLst.Add(item)
            Next
        End If
        Return resourceLst
    End Function

    Public Function GetAllStatusResourcePlanners() As List(Of ResourcePlanner)
        Dim state As StateData = ResourceMgmt.GetAllStatusResourcePlanner
        Dim resourceLst As New List(Of ResourcePlanner)

        If Not IsNothing(state.Data) Then
            Dim resource As List(Of ResourcePlanner) = DirectCast(state.Data, List(Of ResourcePlanner))
            For Each _list As ResourcePlanner In resource
                Dim item As New ResourcePlanner

                item.DESCR = _list.DESCR
                item.Status = _list.Status

                resourceLst.Add(item)
            Next
        End If
        Return resourceLst
    End Function

    Public Overrides Function GetResourcePlanner(email As String, status As Integer, toBeDisplayed As Integer, year As Integer) As List(Of ResourcePlanner)
        Dim state As StateData = ResourceMgmt.GetResourcePlanner(email, status, toBeDisplayed, year)
        Dim resourceLst As New List(Of ResourcePlanner)

        If Not IsNothing(state.Data) Then
            Dim resource As List(Of ResourcePlanner) = DirectCast(state.Data, List(Of ResourcePlanner))
            For Each _list As ResourcePlanner In resource
                Dim item As New ResourcePlanner

                item.NAME = _list.NAME
                item.Status = _list.Status
                item.UsedLeaves = _list.UsedLeaves
                item.TotalBalance = _list.TotalBalance
                item.HalfBalance = _list.HalfBalance

                resourceLst.Add(item)
            Next
        End If
        Return resourceLst
    End Function

    Public Overrides Function GetNonBillableHours(email As String, display As Integer, month As Integer, year As Integer) As List(Of ResourcePlanner)
        Dim state As StateData = ResourceMgmt.GetNonBillableHours(email, display, month, year)
        Dim resourceLst As New List(Of ResourcePlanner)

        If Not IsNothing(state.Data) Then
            Dim resource As List(Of ResourcePlanner) = DirectCast(state.Data, List(Of ResourcePlanner))
            For Each _list As ResourcePlanner In resource
                Dim item As New ResourcePlanner

                item.NAME = _list.NAME
                item.holidayHours = _list.holidayHours
                item.vlHours = _list.vlHours
                item.slHours = _list.slHours

                resourceLst.Add(item)
            Next
        End If
        Return resourceLst
    End Function

#End Region

#Region "Attendance"

    Public Overrides Function GetAttendanceAll(ByVal Month As Integer, ByVal Year As Integer, ByRef objResult As List(Of AttendanceSummary)) As Boolean
        Dim state As StateData = AttendanceMgmt.GetAttendanceAll(Month, Year)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function GetAttendanceEmployee(empId As Integer, WeekOf As Date, ByRef objResult As MyAttendance) As Boolean
        Dim state As StateData = AttendanceMgmt.GetAttendanceByEmployee(empId, WeekOf)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function InsertAttendanceByEmp(ByVal _Attendance As AttendanceSummary) As Boolean
        Dim state As StateData = AttendanceMgmt.Insert(_Attendance)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function UpdateAttendanceByEmp(ByVal _Attendance As AttendanceSummary) As Boolean
        Dim state As StateData = AttendanceMgmt.UpdateAttendance(_Attendance)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function UpdateAttendanceByEmp(ByVal empid As Integer, ByVal day As Integer, ByVal attstatus As Integer) As Boolean
        Dim state As StateData = AttendanceMgmt.UpdateAttendance(empid, day, attstatus)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function GetAttendanceToday(email As String) As List(Of MyAttendance)
        Dim state As StateData = AttendanceMgmt.GetAttendanceToday(email)
        Dim attendanceLst As New List(Of MyAttendance)

        If Not IsNothing(state.Data) Then
            Dim attendance As List(Of MyAttendance) = DirectCast(state.Data, List(Of MyAttendance))
            For Each _list As MyAttendance In attendance
                Dim item As New MyAttendance

                item.EmployeeID = _list.EmployeeID
                item.Name = _list.Name
                item.Descr = _list.Descr
                item.DateEntry = _list.DateEntry
                item.Status = _list.Status
                item.Image_Path = _list.Image_Path

                attendanceLst.Add(item)
            Next
        End If
        Return attendanceLst
    End Function

    Public Overrides Function GetAttendanceTodayBySearch(email As String, input As String) As List(Of MyAttendance)
        Dim state As StateData = AttendanceMgmt.GetAttendanceTodayBySearch(email, input)
        Dim attendanceLst As New List(Of MyAttendance)

        If Not IsNothing(state.Data) Then
            Dim attendance As List(Of MyAttendance) = DirectCast(state.Data, List(Of MyAttendance))
            For Each _list As MyAttendance In attendance
                Dim item As New MyAttendance

                item.EmployeeID = _list.EmployeeID
                item.Name = _list.Name
                item.Descr = _list.Descr
                item.DateEntry = _list.DateEntry
                item.Status = _list.Status
                item.Image_Path = _list.Image_Path

                attendanceLst.Add(item)
            Next
        End If
        Return attendanceLst
    End Function
#End Region

#Region "Commendations"
    Public Overrides Function InsertCommendations(commendations As Commendations) As Boolean
        Dim state As StateData = CommendationsMgmt.InsertCommendations(commendations)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function UpdateCommendations(Task As Commendations) As Boolean
        Dim state As StateData = CommendationsMgmt.UpdateCommendations(Task)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function GetCommendations(ByVal deptID As Integer) As List(Of Commendations)
        Dim state As StateData = CommendationsMgmt.GetCommendations(deptID)
        Dim commendationsLst As New List(Of Commendations)

        If Not IsNothing(state.Data) Then
            Dim commendations As List(Of Commendations) = DirectCast(state.Data, List(Of Commendations))
            For Each _list As Commendations In commendations
                Dim item As New Commendations

                item.COMMEND_ID = _list.COMMEND_ID
                item.DEPT_ID = _list.DEPT_ID
                item.EMPLOYEE = _list.EMPLOYEE
                item.PROJECT = _list.PROJECT
                item.DATE_SENT = _list.DATE_SENT
                item.SENT_BY = _list.SENT_BY
                item.REASON = _list.REASON

                commendationsLst.Add(item)
            Next
        End If
        Return commendationsLst
    End Function

    Public Overrides Function GetCommendationsBySearch(ByVal empID As Integer, month As Integer, year As Integer) As List(Of Commendations)
        Dim state As StateData = CommendationsMgmt.GetCommendationsBySearch(empID, month, year)
        Dim commendationsLst As New List(Of Commendations)

        If Not IsNothing(state.Data) Then
            Dim commendations As List(Of Commendations) = DirectCast(state.Data, List(Of Commendations))
            For Each _list As Commendations In commendations
                Dim item As New Commendations

                item.COMMEND_ID = _list.COMMEND_ID
                item.DEPT_ID = _list.DEPT_ID
                item.EMPLOYEE = _list.EMPLOYEE
                item.PROJECT = _list.PROJECT
                item.DATE_SENT = _list.DATE_SENT
                item.SENT_BY = _list.SENT_BY
                item.REASON = _list.REASON

                commendationsLst.Add(item)
            Next
        End If
        Return commendationsLst
    End Function

#End Region

#Region "Assets"
    Public Overrides Function InsertAssets(assets As Assets) As Boolean
        Dim state As StateData = AssetsMgmt.InsertAssets(assets)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function UpdateAssets(assets As Assets) As Boolean
        Dim state As StateData = AssetsMgmt.UpdateAssets(assets)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function GetAllAssetsByEmpID(ByVal empID As Integer) As List(Of Assets)
        Dim state As StateData = AssetsMgmt.GetAllAssetsByEmpID(empID)
        Dim assetsLst As New List(Of Assets)

        If Not IsNothing(state.Data) Then
            Dim assets As List(Of Assets) = DirectCast(state.Data, List(Of Assets))
            For Each _list As Assets In assets
                Dim item As New Assets

                item.ASSET_ID = _list.ASSET_ID
                item.EMP_ID = _list.EMP_ID
                item.ASSET_DESC = _list.ASSET_DESC
                item.MANUFACTURER = _list.MANUFACTURER
                item.MODEL_NO = _list.MODEL_NO
                item.SERIAL_NO = _list.SERIAL_NO
                item.ASSET_TAG = _list.ASSET_TAG
                item.DATE_PURCHASED = _list.DATE_PURCHASED
                item.STATUS = _list.STATUS
                item.OTHER_INFO = _list.OTHER_INFO
                item.DATE_ASSIGNED = _list.DATE_ASSIGNED
                item.COMMENTS = _list.COMMENTS
                item.FULL_NAME = _list.FULL_NAME
                item.DEPARTMENT = _list.DEPARTMENT

                assetsLst.Add(item)
            Next
        End If
        Return assetsLst
    End Function

    Public Overrides Function GetMyAssets(ByVal empID As Integer) As List(Of Assets)
        Dim state As StateData = AssetsMgmt.GetMyAssets(empID)
        Dim assetsLst As New List(Of Assets)

        If Not IsNothing(state.Data) Then
            Dim assets As List(Of Assets) = DirectCast(state.Data, List(Of Assets))
            For Each _list As Assets In assets
                Dim item As New Assets

                item.ASSET_ID = _list.ASSET_ID
                item.EMP_ID = _list.EMP_ID
                item.ASSET_DESC = _list.ASSET_DESC
                item.MANUFACTURER = _list.MANUFACTURER
                item.MODEL_NO = _list.MODEL_NO
                item.SERIAL_NO = _list.SERIAL_NO
                item.ASSET_TAG = _list.ASSET_TAG
                item.DATE_PURCHASED = _list.DATE_PURCHASED
                item.STATUS = _list.STATUS
                item.OTHER_INFO = _list.OTHER_INFO
                item.DATE_ASSIGNED = _list.DATE_ASSIGNED
                item.COMMENTS = _list.COMMENTS
                item.FULL_NAME = _list.FULL_NAME
                item.DEPARTMENT = _list.DEPARTMENT
                item.APPROVAL = _list.APPROVAL

                assetsLst.Add(item)
            Next
        End If
        Return assetsLst
    End Function

    Public Overrides Function GetAllAssetsBySearch(ByVal empID As Integer, ByVal input As String) As List(Of Assets)
        Dim state As StateData = AssetsMgmt.GetAllAssetsBySearch(empID, input)
        Dim assetsLst As New List(Of Assets)

        If Not IsNothing(state.Data) Then
            Dim assets As List(Of Assets) = DirectCast(state.Data, List(Of Assets))
            For Each _list As Assets In assets
                Dim item As New Assets

                item.ASSET_ID = _list.ASSET_ID
                item.EMP_ID = _list.EMP_ID
                item.ASSET_DESC = _list.ASSET_DESC
                item.MANUFACTURER = _list.MANUFACTURER
                item.MODEL_NO = _list.MODEL_NO
                item.SERIAL_NO = _list.SERIAL_NO
                item.ASSET_TAG = _list.ASSET_TAG
                item.DATE_PURCHASED = _list.DATE_PURCHASED
                item.STATUS = _list.STATUS
                item.OTHER_INFO = _list.OTHER_INFO
                item.DATE_ASSIGNED = _list.DATE_ASSIGNED
                item.COMMENTS = _list.COMMENTS
                item.FULL_NAME = _list.FULL_NAME
                item.DEPARTMENT = _list.DEPARTMENT

                assetsLst.Add(item)
            Next
        End If
        Return assetsLst
    End Function

    Public Overrides Function GetAllAssetsInventoryByEmpID(ByVal empID As Integer) As List(Of Assets)
        Dim state As StateData = AssetsMgmt.GetAllAssetsInventoryByEmpID(empID)
        Dim assetsLst As New List(Of Assets)

        If Not IsNothing(state.Data) Then
            Dim assets As List(Of Assets) = DirectCast(state.Data, List(Of Assets))
            For Each _list As Assets In assets
                Dim item As New Assets

                item.ASSET_ID = _list.ASSET_ID
                item.EMP_ID = _list.EMP_ID
                item.ASSET_DESC = _list.ASSET_DESC
                item.MANUFACTURER = _list.MANUFACTURER
                item.MODEL_NO = _list.MODEL_NO
                item.SERIAL_NO = _list.SERIAL_NO
                item.ASSET_TAG = _list.ASSET_TAG
                item.DATE_PURCHASED = _list.DATE_PURCHASED
                item.STATUS = _list.STATUS
                item.OTHER_INFO = _list.OTHER_INFO
                item.DATE_ASSIGNED = _list.DATE_ASSIGNED
                item.COMMENTS = _list.COMMENTS
                item.FULL_NAME = _list.FULL_NAME
                item.DEPARTMENT = _list.DEPARTMENT

                assetsLst.Add(item)
            Next
        End If
        Return assetsLst
    End Function

    Public Overrides Function GetAllAssetsInventoryUnApproved(ByVal empID As Integer) As List(Of Assets)
        Dim state As StateData = AssetsMgmt.GetAllAssetsInventoryUnApproved(empID)
        Dim assetsLst As New List(Of Assets)

        If Not IsNothing(state.Data) Then
            Dim assets As List(Of Assets) = DirectCast(state.Data, List(Of Assets))
            For Each _list As Assets In assets
                Dim item As New Assets

                item.ASSET_ID = _list.ASSET_ID
                item.EMP_ID = _list.EMP_ID
                item.ASSET_DESC = _list.ASSET_DESC
                item.MANUFACTURER = _list.MANUFACTURER
                item.MODEL_NO = _list.MODEL_NO
                item.SERIAL_NO = _list.SERIAL_NO
                item.ASSET_TAG = _list.ASSET_TAG
                item.DATE_PURCHASED = _list.DATE_PURCHASED
                item.STATUS = _list.STATUS
                item.OTHER_INFO = _list.OTHER_INFO
                item.DATE_ASSIGNED = _list.DATE_ASSIGNED
                item.COMMENTS = _list.COMMENTS
                item.FULL_NAME = _list.FULL_NAME
                item.DEPARTMENT = _list.DEPARTMENT

                assetsLst.Add(item)
            Next
        End If
        Return assetsLst
    End Function

    Public Overrides Function InsertAssetsInventory(assets As Assets) As Boolean
        Dim state As StateData = AssetsMgmt.InsertAssetsInventory(assets)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function UpdateAssetsInventory(assets As Assets) As Boolean
        Dim state As StateData = AssetsMgmt.UpdateAssetsInventory(assets)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function UpdateAssetsInventoryApproval(assets As Assets) As Boolean
        Dim state As StateData = AssetsMgmt.UpdateAssetsInventoryApproval(assets)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function UpdateAssetsInventoryCancel(assets As Assets) As Boolean
        Dim state As StateData = AssetsMgmt.UpdateAssetsInventoryCancel(assets)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function GetAllAssetsUnAssigned(ByVal empID As Integer) As List(Of Assets)
        Dim state As StateData = AssetsMgmt.GetAllAssetsUnAssigned(empID)
        Dim assetsLst As New List(Of Assets)

        If Not IsNothing(state.Data) Then
            Dim assets As List(Of Assets) = DirectCast(state.Data, List(Of Assets))
            For Each _list As Assets In assets
                Dim item As New Assets

                item.ASSET_ID = _list.ASSET_ID
                item.EMP_ID = _list.EMP_ID
                item.ASSET_DESC = _list.ASSET_DESC
                item.MANUFACTURER = _list.MANUFACTURER
                item.MODEL_NO = _list.MODEL_NO
                item.SERIAL_NO = _list.SERIAL_NO
                item.ASSET_TAG = _list.ASSET_TAG
                item.DATE_PURCHASED = _list.DATE_PURCHASED
                item.STATUS = _list.STATUS
                item.OTHER_INFO = _list.OTHER_INFO
                item.DATE_ASSIGNED = _list.DATE_ASSIGNED
                item.COMMENTS = _list.COMMENTS
                item.FULL_NAME = _list.FULL_NAME
                item.DEPARTMENT = _list.DEPARTMENT

                assetsLst.Add(item)
            Next
        End If
        Return assetsLst
    End Function

    'For the list of Employee by Group e.g. Manager only or User only
    Public Overrides Function GetAllManagers(empID As Integer) As List(Of Nickname)
        Dim state As StateData = AssetsMgmt.GetAllManagers(empID)
        Dim lstNicknameList As New List(Of Nickname)

        If Not IsNothing(state.Data) Then
            Dim lstNickname As List(Of Nickname) = DirectCast(state.Data, List(Of Nickname))
            For Each _list As Nickname In lstNickname
                Dim item As New Nickname

                item.Emp_ID = _list.Emp_ID
                item.Nick_Name = _list.Nick_Name
                item.First_Name = _list.First_Name
                item.Employee_Name = _list.Employee_Name
                lstNicknameList.Add(item)
            Next
        End If
        Return lstNicknameList
    End Function

    Public Overrides Function GetAllAssetsHistory(ByVal empID As Integer) As List(Of Assets)
        Dim state As StateData = AssetsMgmt.GetAllAssetsHistory(empID)
        Dim assetsLst As New List(Of Assets)

        If Not IsNothing(state.Data) Then
            Dim assets As List(Of Assets) = DirectCast(state.Data, List(Of Assets))
            For Each _list As Assets In assets
                Dim item As New Assets

                item.ASSET_ID = _list.ASSET_ID
                item.FULL_NAME = _list.FULL_NAME
                item.ASSET_DESC = _list.ASSET_DESC
                item.MANUFACTURER = _list.MANUFACTURER
                item.MODEL_NO = _list.MODEL_NO
                item.SERIAL_NO = _list.SERIAL_NO
                item.ASSET_TAG = _list.ASSET_TAG
                item.STATUS_DESCR = _list.STATUS_DESCR
                item.DATE_ASSIGNED = _list.DATE_ASSIGNED

                assetsLst.Add(item)
            Next
        End If
        Return assetsLst
    End Function

    Public Overrides Function GetAllAssetsHistoryBySearch(ByVal empID As Integer, ByVal input As String) As List(Of Assets)
        Dim state As StateData = AssetsMgmt.GetAllAssetsHistoryBySearch(empID, input)
        Dim assetsLst As New List(Of Assets)

        If Not IsNothing(state.Data) Then
            Dim assets As List(Of Assets) = DirectCast(state.Data, List(Of Assets))
            For Each _list As Assets In assets
                Dim item As New Assets

                item.ASSET_ID = _list.ASSET_ID
                item.FULL_NAME = _list.FULL_NAME
                item.ASSET_DESC = _list.ASSET_DESC
                item.MANUFACTURER = _list.MANUFACTURER
                item.MODEL_NO = _list.MODEL_NO
                item.SERIAL_NO = _list.SERIAL_NO
                item.ASSET_TAG = _list.ASSET_TAG
                item.STATUS_DESCR = _list.STATUS_DESCR
                item.DATE_ASSIGNED = _list.DATE_ASSIGNED

                assetsLst.Add(item)
            Next
        End If
        Return assetsLst
    End Function

    Public Overrides Function GetAllAssetsInventoryBySearch(ByVal empID As Integer, ByVal input As String, ByVal page As String) As List(Of Assets)
        Dim state As StateData = AssetsMgmt.GetAllAssetsInventoryBySearch(empID, input, page)
        Dim assetsLst As New List(Of Assets)

        If Not IsNothing(state.Data) Then
            Dim assets As List(Of Assets) = DirectCast(state.Data, List(Of Assets))
            For Each _list As Assets In assets
                Dim item As New Assets

                item.ASSET_ID = _list.ASSET_ID
                item.EMP_ID = _list.EMP_ID
                item.ASSET_DESC = _list.ASSET_DESC
                item.MANUFACTURER = _list.MANUFACTURER
                item.MODEL_NO = _list.MODEL_NO
                item.SERIAL_NO = _list.SERIAL_NO
                item.ASSET_TAG = _list.ASSET_TAG
                item.DATE_PURCHASED = _list.DATE_PURCHASED
                item.STATUS = _list.STATUS
                item.OTHER_INFO = _list.OTHER_INFO
                item.DATE_ASSIGNED = _list.DATE_ASSIGNED
                item.COMMENTS = _list.COMMENTS
                item.FULL_NAME = _list.FULL_NAME
                item.DEPARTMENT = _list.DEPARTMENT
                item.APPROVAL = _list.APPROVAL

                assetsLst.Add(item)
            Next
        End If
        Return assetsLst
    End Function

    Public Overrides Function GetAssetManufacturer() As List(Of Assets)
        Dim state As StateData = AssetsMgmt.GetAssetManufacturer()
        Dim assetsLst As New List(Of Assets)

        If Not IsNothing(state.Data) Then
            Dim assets As List(Of Assets) = DirectCast(state.Data, List(Of Assets))
            For Each _list As Assets In assets
                Dim item As New Assets

                item.ASSET_ID = _list.ASSET_ID
                item.MANUFACTURER = _list.MANUFACTURER

                assetsLst.Add(item)
            Next
        End If
        Return assetsLst
    End Function

    Public Overrides Function GetAssetDescription() As List(Of Assets)
        Dim state As StateData = AssetsMgmt.GetAssetDescription()
        Dim assetsLst As New List(Of Assets)

        If Not IsNothing(state.Data) Then
            Dim assets As List(Of Assets) = DirectCast(state.Data, List(Of Assets))
            For Each _list As Assets In assets
                Dim item As New Assets

                item.ASSET_ID = _list.ASSET_ID
                item.ASSET_DESC = _list.ASSET_DESC

                assetsLst.Add(item)
            Next
        End If
        Return assetsLst
    End Function

#End Region

#Region "Billability"
    Public Overrides Function GetBillableHoursByWeek(empID As Integer, weekID As Integer) As List(Of BillableHours)
        Dim state As StateData = BillabilityMgmt.GetBillableHoursByWeek(empID, weekID)
        Dim billabilityLst As New List(Of BillableHours)

        If Not IsNothing(state.Data) Then
            Dim billables As List(Of BillableHours) = DirectCast(state.Data, List(Of BillableHours))
            For Each _list As BillableHours In billables
                Dim item As New BillableHours

                item.Name = _list.Name
                item.Hours = _list.Hours
                item.Status = _list.Status

                billabilityLst.Add(item)
            Next
        End If
        Return billabilityLst
    End Function

    Public Overrides Function GetBillableHoursByMonth(empID As Integer, month As Integer, year As Integer) As List(Of BillableHours)
        Dim state As StateData = BillabilityMgmt.GetBillableHoursByMonth(empID, month, year)
        Dim billabilityLst As New List(Of BillableHours)

        If Not IsNothing(state.Data) Then
            Dim billables As List(Of BillableHours) = DirectCast(state.Data, List(Of BillableHours))
            For Each _list As BillableHours In billables
                Dim item As New BillableHours

                item.Name = _list.Name
                item.Hours = _list.Hours
                item.Status = _list.Status

                billabilityLst.Add(item)
            Next
        End If
        Return billabilityLst
    End Function
#End Region

#Region "Announcements"
    Public Overrides Function InsertAnnouncements(announcements As Announcements) As Boolean
        Dim state As StateData = AnnouncementsMgmt.InsertAnnouncements(announcements)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function GetAnnouncements(ByVal empID As Integer) As List(Of Announcements)
        Dim state As StateData = AnnouncementsMgmt.GetAnnouncements(empID)
        Dim announcementsLst As New List(Of Announcements)

        If Not IsNothing(state.Data) Then
            Dim announcements As List(Of Announcements) = DirectCast(state.Data, List(Of Announcements))
            For Each _list As Announcements In announcements
                Dim item As New Announcements
                item.ANNOUNCEMENT_ID = _list.ANNOUNCEMENT_ID
                item.EMP_ID = _list.EMP_ID
                item.MESSAGE = _list.MESSAGE
                item.TITLE = _list.TITLE
                item.END_DATE = _list.END_DATE

                announcementsLst.Add(item)
            Next
        End If
        Return announcementsLst
    End Function

    Public Overrides Function UpdateAnnouncements(announcements As Announcements) As Boolean
        Dim state As StateData = AnnouncementsMgmt.UpdateAnnouncements(announcements)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function
#End Region

#Region "Late"
    Public Overrides Function GetLate(ByVal empID As Integer, month As Integer, year As Integer, toDisplay As Integer) As List(Of Late)
        Dim state As StateData = LateMgmt.GetLate(empID, month, year, toDisplay)
        Dim LateLst As New List(Of Late)

        If Not IsNothing(state.Data) Then
            Dim late As List(Of Late) = DirectCast(state.Data, List(Of Late))
            For Each _list As Late In late
                Dim item As New Late

                item.FIRST_NAME = _list.FIRST_NAME
                item.STATUS = _list.STATUS
                item.MONTH = _list.MONTH
                item.NUMBER_OF_LATE = _list.NUMBER_OF_LATE

                LateLst.Add(item)
            Next
        End If
        Return LateLst
    End Function

#End Region

#Region "Saba learning"
    Public Overrides Function GetAllSabaCourses(ByVal empID As Integer) As List(Of SabaLearning)
        Dim state As StateData = SabaLearningMgmt.GetAllSabaCourses(empID)
        Dim sabalearningLst As New List(Of SabaLearning)

        If Not IsNothing(state.Data) Then
            Dim sabalearning As List(Of SabaLearning) = DirectCast(state.Data, List(Of SabaLearning))
            For Each _list As SabaLearning In sabalearning
                Dim item As New SabaLearning
                item.SABA_ID = _list.SABA_ID
                item.EMP_ID = _list.EMP_ID
                item.TITLE = _list.TITLE
                item.END_DATE = _list.END_DATE

                sabalearningLst.Add(item)
            Next
        End If
        Return sabalearningLst
    End Function

    Public Overrides Function GetAllSabaXref(ByVal empID As Integer, ByVal sabaID As Integer) As List(Of SabaLearning)
        Dim state As StateData = SabaLearningMgmt.GetAllSabaXref(empID, sabaID)
        Dim sabalearningLst As New List(Of SabaLearning)

        If Not IsNothing(state.Data) Then
            Dim sabalearning As List(Of SabaLearning) = DirectCast(state.Data, List(Of SabaLearning))
            For Each _list As SabaLearning In sabalearning
                Dim item As New SabaLearning
                item.SABA_ID = _list.SABA_ID
                item.EMP_ID = _list.EMP_ID
                item.DATE_COMPLETED = _list.DATE_COMPLETED
                item.IMAGE_PATH = _list.IMAGE_PATH

                sabalearningLst.Add(item)
            Next
        End If
        Return sabalearningLst
    End Function

    Public Overrides Function InsertSabaCourses(ByVal _obj As SabaLearning) As Boolean
        Dim state As StateData = SabaLearningMgmt.InsertSabaCourses(_obj)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess

    End Function

    Public Overrides Function UpdateSabaCourses(ByVal _obj As SabaLearning) As Boolean
        Dim state As StateData = SabaLearningMgmt.UpdateSabaCourses(_obj)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function UpdateSabaXref(ByVal _obj As SabaLearning) As Boolean
        Dim state As StateData = SabaLearningMgmt.UpdateSabaXref(_obj)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function
    Public Overrides Function GetAllSabaCourseByTitle(ByVal saba_message As String, ByVal empID As Integer) As List(Of SabaLearning)
        Dim state As StateData = SabaLearningMgmt.GetAllSabaCourseByTitle(saba_message, empID)
        Dim sabalearningLst As New List(Of SabaLearning)

        If Not IsNothing(state.Data) Then
            Dim sabalearning As List(Of SabaLearning) = DirectCast(state.Data, List(Of SabaLearning))
            For Each _list As SabaLearning In sabalearning
                Dim item As New SabaLearning
                item.SABA_ID = _list.SABA_ID
                item.EMP_ID = _list.EMP_ID
                item.TITLE = _list.TITLE
                item.END_DATE = _list.END_DATE

                sabalearningLst.Add(item)
            Next
        End If
        Return sabalearningLst
    End Function
#End Region

#Region "Comcell"
    Public Overrides Function InsertComcellMeeting(comcell As Comcell) As Boolean
        Dim state As StateData = ComcellMgmt.Insertcomcell(comcell)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function UpdateComcellMeeting(comcell As Comcell) As Boolean
        Dim state As StateData = ComcellMgmt.UpdateComcell(comcell)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function GetComcellMeeting(ByVal empID As Integer, ByVal year As Integer) As List(Of Comcell)
        Dim state As StateData = ComcellMgmt.GetComcell(empID, year)
        Dim comcellLst As New List(Of Comcell)

        If Not IsNothing(state.Data) Then
            Dim comcell As List(Of Comcell) = DirectCast(state.Data, List(Of Comcell))
            For Each _list As Comcell In comcell
                Dim item As New Comcell

                item.COMCELL_ID = _list.COMCELL_ID
                item.EMP_ID = _list.EMP_ID
                item.MONTH = _list.MONTH
                item.FACILITATOR = _list.FACILITATOR
                item.MINUTES_TAKER = _list.MINUTES_TAKER
                item.SCHEDULE = _list.SCHEDULE
                item.FY_START = _list.FY_START
                item.FY_END = _list.FY_END

                comcellLst.Add(item)
            Next
        End If
        Return comcellLst
    End Function

#End Region

#Region "Comcell Clock"

    ''' <remarks></remarks>

    Public Overrides Function GetClockTimeByEmployee(empID As Integer, ByRef objResult As ComcellClock) As Boolean
        Dim state As StateData = ComcellClockMgmt.GetClockTime(empID)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = False
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function UpdateComcellClock(ComClock As ComcellClock) As Boolean
        Dim state As StateData = ComcellClockMgmt.UpdateClockTime(ComClock)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

#End Region

#Region "WeeklyReport"
    Public Overrides Function CreateWeeklyReport(weeklyReport As List(Of WeeklyReport), weeklyReportXref As WeekRange) As Boolean
        Dim state As StateData = WeeklyReportMgmt.CreateWeeklyReport(weeklyReport, weeklyReportXref)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function UpdateWeeklyReport(weeklyReport As List(Of WeeklyReport), weeklyReportXref As WeekRange) As Boolean
        Dim state As StateData = WeeklyReportMgmt.UpdateWeeklyReport(weeklyReport, weeklyReportXref)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function CreateWeekRange(weekRange As WeekRange) As Boolean
        Dim state As StateData = WeeklyReportMgmt.CreateWeekRange(weekRange)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function GetWeekRange(currentDate As Date, empID As Integer, ByRef objResult As List(Of WeekRange)) As Boolean
        Dim state As StateData = WeeklyReportMgmt.GetWeekRange(currentDate, empID)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function GetWeekRangeByMonthYear(empID As Integer, month As Integer, year As Integer, ByRef objResult As List(Of WeekRange)) As Boolean
        Dim state As StateData = WeeklyReportMgmt.GetWeekRangeByMonthYear(empID, month, year)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function GetWeeklyReportsByEmpID(empID As Integer, month As Integer, year As Integer, ByRef objResult As List(Of WeekRange)) As Boolean
        Dim state As StateData = WeeklyReportMgmt.GetWeeklyReportsByEmpID(empID, month, year)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function GetWeeklyReportsByWeekRangeID(weekRangeID As Integer, empID As Integer, ByRef objResult As List(Of WeeklyReport)) As Boolean
        Dim state As StateData = WeeklyReportMgmt.GetWeeklyReportsByWeekRangeID(weekRangeID, empID)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function GetTasksDataByEmpID(weekRangeID As Integer, empID As Integer, ByRef objResult As List(Of WeeklyReport)) As Boolean
        Dim state As StateData = WeeklyReportMgmt.GetTasksDataByEmpID(weekRangeID, empID)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function GetMissingReportsByEmpID(empID As Integer, currentDate As Date, ByRef objResult As List(Of ContactList)) As Boolean
        Dim state As StateData = WeeklyReportMgmt.GetMissingReportsByEmpID(empID, currentDate)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

#End Region

#Region "Audit Sched"
    Public Overrides Function InsertAuditSched(audtiSched As AuditSched) As Boolean
        Dim state As StateData = AuditSchedMgmt.InsertAuditSched(audtiSched)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function UpdateAuditSched(audtiSched As AuditSched) As Boolean
        Dim state As StateData = AuditSchedMgmt.UpdateAuditSched(audtiSched)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    Public Overrides Function GetAuditSched(ByVal empID As Integer, ByVal year As Integer) As List(Of AuditSched)
        Dim state As StateData = AuditSchedMgmt.GetAuditSched(empID, year)
        Dim audtiSchedLst As New List(Of AuditSched)

        If Not IsNothing(state.Data) Then
            Dim audtiSched As List(Of AuditSched) = DirectCast(state.Data, List(Of AuditSched))
            For Each _list As AuditSched In audtiSched
                Dim item As New AuditSched

                item.AUDIT_SCHED_ID = _list.AUDIT_SCHED_ID
                item.FY_WEEK = _list.FY_WEEK
                item.EMP_ID = _list.EMP_ID
                item.PERIOD_START = _list.PERIOD_START
                item.PERIOD_END = _list.PERIOD_END
                item.DAILY = _list.DAILY
                item.WEEKLY = _list.WEEKLY
                item.MONTHLY = _list.MONTHLY
                item.FY_START = _list.FY_START
                item.FY_END = _list.FY_END

                audtiSchedLst.Add(item)
            Next
        End If
        Return audtiSchedLst
    End Function

#End Region

#Region "Send Code"

    ''' <remarks></remarks>

    Public Overrides Function GetWorkEmailbyEmail(email As String, ByRef objResult As SendCode) As Boolean
        Dim state As StateData = SendCodeMgmt.GetWorkEmailbyEmail(email)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = False
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

#End Region

#Region "Mail Config"

    ''' <remarks></remarks>

    Public Overloads Overrides Function GetMailConfig(ByRef objResult As MailConfig) As Boolean
        Dim state As StateData = MailConfigMgmt.GetMailConfig()
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = False
            objResult = state.Data
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

#End Region

#Region "Workplace Audit"
    Public Overrides Function InsertAuditDaily(workplaceAudit As WorkplaceAudit) As Boolean
        Dim state As StateData = WorkplaceAuditMgmt.InsertAuditDaily(workplaceAudit)
        Dim bSuccess As Boolean = False
        If state.NotifyType = NotifyType.IsSuccess Then
            bSuccess = True
        End If
        ReceivedData(state)
        Return bSuccess
    End Function

    'Public Overrides Function UpdateAuditSched(audtiSched As AuditSched) As Boolean
    '    Dim state As StateData = AuditSchedMgmt.UpdateAuditSched(audtiSched)
    '    Dim bSuccess As Boolean = False
    '    If state.NotifyType = NotifyType.IsSuccess Then
    '        bSuccess = True
    '    End If
    '    ReceivedData(state)
    '    Return bSuccess
    'End Function

    Public Overrides Function GetAuditDaily(ByVal empID As Integer, ByVal parmData As Date) As List(Of WorkplaceAudit)
        Dim state As StateData = WorkplaceAuditMgmt.GetAuditDaily(empID, parmData)
        Dim workplaceAuditLst As New List(Of WorkplaceAudit)

        If Not IsNothing(state.Data) Then
            Dim audtiSched As List(Of WorkplaceAudit) = DirectCast(state.Data, List(Of WorkplaceAudit))
            For Each _list As WorkplaceAudit In audtiSched
                Dim item As New WorkplaceAudit

                item.AUDIT_DAILY_ID = _list.AUDIT_DAILY_ID
                item.FY_WEEK = _list.FY_WEEK
                item.EMP_ID = _list.EMP_ID
                item.AUDIT_QUESTIONS_ID = _list.AUDIT_QUESTIONS_ID
                item.STATUS = _list.STATUS
                item.DT_CHECKED = _list.DT_CHECKED

                workplaceAuditLst.Add(item)
            Next
        End If
        Return workplaceAuditLst
    End Function

    Public Overrides Function GetAuditQuestions(ByVal empID As Integer, ByVal questionsGroup As String) As List(Of WorkplaceAudit)
        Dim state As StateData = WorkplaceAuditMgmt.GetAuditQuestions(empID, questionsGroup)
        Dim workplaceAuditLst As New List(Of WorkplaceAudit)

        If Not IsNothing(state.Data) Then
            Dim audtiSched As List(Of WorkplaceAudit) = DirectCast(state.Data, List(Of WorkplaceAudit))
            For Each _list As WorkplaceAudit In audtiSched
                Dim item As New WorkplaceAudit

                item.AUDIT_QUESTIONS_ID = _list.AUDIT_QUESTIONS_ID
                item.EMP_ID = _list.EMP_ID
                item.AUDIT_QUESTIONS = _list.AUDIT_QUESTIONS
                item.OWNER = _list.OWNER
                item.AUDIT_QUESTIONS_GROUP = _list.AUDIT_QUESTIONS_GROUP

                workplaceAuditLst.Add(item)
            Next
        End If
        Return workplaceAuditLst
    End Function

#End Region

#Region "Contributors"
    Public Overrides Function GetAllContributors(ByVal lvl As Integer) As List(Of Contributors)
        Dim state As StateData = ContributorsMgmt.GetAllContributors(lvl)
        Dim contributorsLst As New List(Of Contributors)

        If Not IsNothing(state.Data) Then
            Dim contrilst As List(Of Contributors) = DirectCast(state.Data, List(Of Contributors))
            For Each objContri As Contributors In contrilst
                contributorsLst.Add(objContri)
            Next
        End If
        Return contributorsLst
    End Function
#End Region

#Region "Contributors"
    Public Overrides Function GetAllMessage(ByVal msgID As Integer, ByVal secID As Integer) As List(Of MessageDetail)
        Dim state As StateData = MessageMgmt.GetAllMessage(msgID, secID)
        Dim MessageLst As New List(Of MessageDetail)

        If Not IsNothing(state.Data) Then
            Dim msglst As List(Of MessageDetail) = DirectCast(state.Data, List(Of MessageDetail))
            For Each objMsg As MessageDetail In msglst
                MessageLst.Add(objMsg)
            Next
        End If
        Return MessageLst
    End Function
#End Region
End Class
