Public Class CLS_TABEAN_HERB_JJ
    Inherits CLASS_CENTER

#Region "SHOW"
    Private _DT_SHOW As New CLS_SHOW
    Public Property DT_SHOW() As CLS_SHOW
        Get
            Return _DT_SHOW
        End Get
        Set(ByVal value As CLS_SHOW)
            _DT_SHOW = value
        End Set
    End Property
#End Region

#Region "MASTER"
    Private _DT_MASTER As New CLS_MASTER
    Public Property DT_MASTER() As CLS_MASTER
        Get
            Return _DT_MASTER
        End Get
        Set(ByVal value As CLS_MASTER)
            _DT_MASTER = value
        End Set
    End Property
#End Region

    Private _TABEAN_JJ As New TABEAN_JJ
    Public Property TABEAN_JJ() As TABEAN_JJ
        Get
            Return _TABEAN_JJ
        End Get
        Set(ByVal value As TABEAN_JJ)
            _TABEAN_JJ = value
        End Set
    End Property

    Private _list_tabean_jj As New List(Of String)
    Public Property list_tabean_jj() As List(Of String)
        Get
            Return _list_tabean_jj
        End Get
        Set(ByVal value As List(Of String))
            _list_tabean_jj = value
        End Set
    End Property

    Private _TABEAN_SUBPACKAGE As New List(Of TABEAN_JJ_SUB_PACKSIZE)
    Public Property TABEAN_SUBPACKAGE() As List(Of TABEAN_JJ_SUB_PACKSIZE)
        Get
            Return _TABEAN_SUBPACKAGE
        End Get
        Set(ByVal value As List(Of TABEAN_JJ_SUB_PACKSIZE))
            _TABEAN_SUBPACKAGE = value
        End Set
    End Property

    Private _list_subpackage As New List(Of String)
    Public Property list_subpackage() As List(Of String)
        Get
            Return _list_subpackage
        End Get
        Set(ByVal value As List(Of String))
            _list_subpackage = value
        End Set
    End Property

    Private _date_approve_day As String
    Public Property date_approve_day() As String
        Get
            Return _date_approve_day
        End Get
        Set(ByVal value As String)
            _date_approve_day = value
        End Set
    End Property

    Private _date_approve_month As String
    Public Property date_approve_month() As String
        Get
            Return _date_approve_month
        End Get
        Set(ByVal value As String)
            _date_approve_month = value
        End Set
    End Property

    Private _date_approve_year As String
    Public Property date_approve_year() As String
        Get
            Return _date_approve_year
        End Get
        Set(ByVal value As String)
            _date_approve_year = value
        End Set
    End Property

    Private _date_approve_day_end As String
    Public Property date_approve_day_end() As String
        Get
            Return _date_approve_day_end
        End Get
        Set(ByVal value As String)
            _date_approve_day_end = value
        End Set
    End Property

    Private _date_approve_month_end As String
    Public Property date_approve_month_end() As String
        Get
            Return _date_approve_month_end
        End Get
        Set(ByVal value As String)
            _date_approve_month_end = value
        End Set
    End Property

    Private _date_approve_year_end As String
    Public Property date_approve_year_end() As String
        Get
            Return _date_approve_year_end
        End Get
        Set(ByVal value As String)
            _date_approve_year_end = value
        End Set
    End Property

    Private _date_req_day As String
    Public Property date_req_day() As String
        Get
            Return _date_req_day
        End Get
        Set(ByVal value As String)
            _date_req_day = value
        End Set
    End Property

    Private _date_req_month As String
    Public Property date_req_month() As String
        Get
            Return _date_req_month
        End Get
        Set(ByVal value As String)
            _date_req_month = value
        End Set
    End Property

    Private _date_req_year As String
    Public Property date_req_year() As String
        Get
            Return _date_req_year
        End Get
        Set(ByVal value As String)
            _date_req_year = value
        End Set
    End Property

    Private _date_req_full As String
    Public Property date_req_full() As String
        Get
            Return _date_req_full
        End Get
        Set(ByVal value As String)
            _date_req_full = value
        End Set
    End Property

    Private _TYPE_PERSON_1 As String
    Public Property TYPE_PERSON_1() As String
        Get
            Return _TYPE_PERSON_1
        End Get
        Set(ByVal value As String)
            _TYPE_PERSON_1 = value
        End Set
    End Property

    Private _TYPE_PERSON_99 As String
    Public Property TYPE_PERSON_99() As String
        Get
            Return _TYPE_PERSON_99
        End Get
        Set(ByVal value As String)
            _TYPE_PERSON_99 = value
        End Set
    End Property

    Private _PROCESS_NAME As String
    Public Property PROCESS_NAME() As String
        Get
            Return _PROCESS_NAME
        End Get
        Set(ByVal value As String)
            _PROCESS_NAME = value
        End Set
    End Property

    Private _LCNNO_DISPLAY_NEW As String
    Public Property LCNNO_DISPLAY_NEW() As String
        Get
            Return _LCNNO_DISPLAY_NEW
        End Get
        Set(ByVal value As String)
            _LCNNO_DISPLAY_NEW = value
        End Set
    End Property

    Private _RCVNO_FULL As String
    Public Property RCVNO_FULL() As String
        Get
            Return _RCVNO_FULL
        End Get
        Set(ByVal value As String)
            _RCVNO_FULL = value
        End Set
    End Property

    Private _NAME_THAI_NAME_PLACE As String
    Public Property NAME_THAI_NAME_PLACE() As String
        Get
            Return _NAME_THAI_NAME_PLACE
        End Get
        Set(ByVal value As String)
            _NAME_THAI_NAME_PLACE = value
        End Set
    End Property

End Class
