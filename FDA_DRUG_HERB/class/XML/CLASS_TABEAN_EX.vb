Public Class CLASS_TABEAN_EX
    Inherits CLASS_CENTER
    Public TABEAN_EX As New TABEAN_HERB

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
    Private _phr_name As String
    Public Property PHR_NAME_FULL() As String
        Get
            Return _phr_name
        End Get
        Set(ByVal value As String)
            _phr_name = value
        End Set
    End Property
    Private _date_confirm_full As String
    Public Property date_confirm_full() As String
        Get
            Return _date_confirm_full
        End Get
        Set(ByVal value As String)
            _date_confirm_full = value
        End Set
    End Property
    Private _date_write_day As String
    Public Property date_write_day() As String
        Get
            Return _date_write_day
        End Get
        Set(ByVal value As String)
            _date_write_day = value
        End Set
    End Property
    Private _date_write_month As String
    Public Property date_write_month() As String
        Get
            Return _date_write_month
        End Get
        Set(ByVal value As String)
            _date_write_month = value
        End Set
    End Property
    Private _date_write_year As String
    Public Property date_write_year() As String
        Get
            Return _date_write_year
        End Get
        Set(ByVal value As String)
            _date_write_year = value
        End Set
    End Property
    Private _date_write_full As String
    Public Property date_write_full() As String
        Get
            Return _date_write_full
        End Get
        Set(ByVal value As String)
            _date_write_full = value
        End Set
    End Property

    Private _date_rcv_full As String
    Public Property date_rcv_full() As String
        Get
            Return _date_rcv_full
        End Get
        Set(ByVal value As String)
            _date_rcv_full = value
        End Set
    End Property
End Class
