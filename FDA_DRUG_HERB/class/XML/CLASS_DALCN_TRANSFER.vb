Public Class CLASS_DALCN_TRANSFER
    Inherits CLASS_CENTER
    Public DALCN_TRANSFER As New DALCN_TRANSFER

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
    Private _CNSDATE_FULL_TH As String
    Public Property CNSDATE_FULL_THAI() As String
        Get
            Return _CNSDATE_FULL_TH
        End Get
        Set(ByVal value As String)
            _CNSDATE_FULL_TH = value
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
    Private _WRITE_DATE_FULL_TH As String
    Public Property WRITE_DATE_FULL_TH() As String
        Get
            Return _WRITE_DATE_FULL_TH
        End Get
        Set(ByVal value As String)
            _WRITE_DATE_FULL_TH = value
        End Set
    End Property

    Private _OPENTIME_FULL_TH As String
    Public Property OPENTIME_FULL_THAI() As String
        Get
            Return _OPENTIME_FULL_TH
        End Get
        Set(ByVal value As String)
            _OPENTIME_FULL_TH = value
        End Set
    End Property
    Private _PASSPORT_EXPIRE_FULL_TH As String
    Public Property PASSPORT_EXPIRE_FULL_THAI() As String
        Get
            Return _PASSPORT_EXPIRE_FULL_TH
        End Get
        Set(ByVal value As String)
            _PASSPORT_EXPIRE_FULL_TH = value
        End Set
    End Property
    Private _WORK_PERMIT_EXPIRE_FULL_TH As String
    Public Property WORK_PERMIT_EXPIRE_FULL_THAI() As String
        Get
            Return _WORK_PERMIT_EXPIRE_FULL_TH
        End Get
        Set(ByVal value As String)
            _WORK_PERMIT_EXPIRE_FULL_TH = value
        End Set
    End Property
    Private _TRANSFER_DATE_FULL_TH As String
    Public Property TRANSFER_DATE_FULL_THAI() As String
        Get
            Return _TRANSFER_DATE_FULL_TH
        End Get
        Set(ByVal value As String)
            _TRANSFER_DATE_FULL_TH = value
        End Set
    End Property
End Class
