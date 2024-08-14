Public Class CLASS_DRRQT
    Inherits CLASS_CENTER
    Public DRRQT As New drrqt

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

    Private _PROCESS_NAME As String
    Public Property PROCESS_NAME() As String
        Get
            Return _PROCESS_NAME
        End Get
        Set(ByVal value As String)
            _PROCESS_NAME = value
        End Set
    End Property

    Private _RCVNO_DATE As String
    Public Property RCVNO_DATE() As String
        Get
            Return _RCVNO_DATE
        End Get
        Set(ByVal value As String)
            _RCVNO_DATE = value
        End Set
    End Property

    Private _RGTNO_DATE As String
    Public Property RGTNO_DATE() As String
        Get
            Return _RGTNO_DATE
        End Get
        Set(ByVal value As String)
            _RGTNO_DATE = value
        End Set
    End Property

    Private _RGTNO_DATE_END As String
    Public Property RGTNO_DATE_END() As String
        Get
            Return _RGTNO_DATE_END
        End Get
        Set(ByVal value As String)
            _RGTNO_DATE_END = value
        End Set
    End Property

    Private _date_rgt_day As String
    Public Property date_rgt_day() As String
        Get
            Return _date_rgt_day
        End Get
        Set(ByVal value As String)
            _date_rgt_day = value
        End Set
    End Property

    Private _date_rgt_month As String
    Public Property date_rgt_month() As String
        Get
            Return _date_rgt_month
        End Get
        Set(ByVal value As String)
            _date_rgt_month = value
        End Set
    End Property

    Private _date_rgt_year As String
    Public Property date_rgt_year() As String
        Get
            Return _date_rgt_year
        End Get
        Set(ByVal value As String)
            _date_rgt_year = value
        End Set
    End Property

    Private _date_rgt_exdate_day As String
    Public Property date_rgt_exdate_day() As String
        Get
            Return _date_rgt_exdate_day
        End Get
        Set(ByVal value As String)
            _date_rgt_exdate_day = value
        End Set
    End Property

    Private _date_rgt_exdate_month As String
    Public Property date_rgt_exdate_month() As String
        Get
            Return _date_rgt_exdate_month
        End Get
        Set(ByVal value As String)
            _date_rgt_exdate_month = value
        End Set
    End Property

    Private _date_rgt_exdate_year As String
    Public Property date_rgt_exdate_year() As String
        Get
            Return _date_rgt_exdate_year
        End Get
        Set(ByVal value As String)
            _date_rgt_exdate_year = value
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
    Private _BSN_THAIFULLNAME As String
    Public Property BSN_THAIFULLNAME() As String
        Get
            Return _BSN_THAIFULLNAME
        End Get
        Set(ByVal value As String)
            _BSN_THAIFULLNAME = value
        End Set
    End Property
    Private _NATIONALITY_PERSON As String
    Public Property NATIONALITY_PERSON() As String
        Get
            Return _NATIONALITY_PERSON
        End Get
        Set(ByVal value As String)
            _NATIONALITY_PERSON = value
        End Set
    End Property

End Class
