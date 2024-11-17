Public Class CLASS_DR_INFORM
    Inherits CLASS_CENTER
    Public TABEAN_INFORM As New TABEAN_JR

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

    Private _RCVDATE_FULL_TH As String
    Public Property RCVDATE_FULL_THAI() As String
        Get
            Return _RCVDATE_FULL_TH
        End Get
        Set(ByVal value As String)
            _RCVDATE_FULL_TH = value
        End Set
    End Property

    Private _WRITEDATE_FULL_TH As String
    Public Property WRITEDATE_FULL_THAI() As String
        Get
            Return _WRITEDATE_FULL_TH
        End Get
        Set(ByVal value As String)
            _WRITEDATE_FULL_TH = value
        End Set
    End Property
    Private _APPDATE_FULL_TH As String
    Public Property APPDATE_FULL_THAI() As String
        Get
            Return _APPDATE_FULL_TH
        End Get
        Set(ByVal value As String)
            _APPDATE_FULL_TH = value
        End Set
    End Property
    Private _BSN_THAINAME As String
    Public Property BSN_THAINAME() As String
        Get
            Return _BSN_THAINAME
        End Get
        Set(ByVal value As String)
            _BSN_THAINAME = value
        End Set
    End Property
    Private _THANM_THAIFULLNAME As String
    Public Property THANM_THAIFULLNAME() As String
        Get
            Return _THANM_THAIFULLNAME
        End Get
        Set(ByVal value As String)
            _THANM_THAIFULLNAME = value
        End Set
    End Property
    Private _THANM As String
    Public Property THANM_FULL() As String
        Get
            Return _THANM
        End Get
        Set(ByVal value As String)
            _THANM = value
        End Set
    End Property
    Private _DATE_APP_DAY As String
    Public Property DATE_APP_DAY() As String
        Get
            Return _DATE_APP_DAY
        End Get
        Set(ByVal value As String)
            _DATE_APP_DAY = value
        End Set
    End Property
    Private _DATE_APP_MONTH As String
    Public Property DATE_APP_MONTH() As String
        Get
            Return _DATE_APP_MONTH
        End Get
        Set(ByVal value As String)
            _DATE_APP_MONTH = value
        End Set
    End Property
    Private _DATE_APP_YEAR As String
    Public Property DATE_APP_YEAR() As String
        Get
            Return _DATE_APP_YEAR
        End Get
        Set(ByVal value As String)
            _DATE_APP_YEAR = value
        End Set
    End Property
    Private _date_exdate_day As String
    Public Property date_exdate_day() As String
        Get
            Return _date_exdate_day
        End Get
        Set(ByVal value As String)
            _date_exdate_day = value
        End Set
    End Property
    Private _date_exdate_month As String
    Public Property date_exdate_month() As String
        Get
            Return _date_exdate_month
        End Get
        Set(ByVal value As String)
            _date_exdate_month = value
        End Set
    End Property
    Private _date_exdate_year As String
    Public Property date_exdate_year() As String
        Get
            Return _date_exdate_year
        End Get
        Set(ByVal value As String)
            _date_exdate_year = value
        End Set
    End Property
End Class
