Public Class CLASS_DR_ANALYZE
    Inherits CLASS_CENTER
    Public TABEAN_ANALYZE As New TABEAN_ANALYZE

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