Public Class CLASS_DALCN_PHR
    Inherits CLASS_CENTER
    Public DALCN_PHR As New DALCN_PHR
    Public DALCN_PHR_ADDR_BSN As New DALCN_PHR_ADDR_BSN
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
    Private _PHR_TYPE As String
    Public Property PHR_TYPE() As String
        Get
            Return _PHR_TYPE
        End Get
        Set(ByVal value As String)
            _PHR_TYPE = value
        End Set
    End Property
    Private _qualification_VETERINARY As String
    Public Property qualification_v() As String
        Get
            Return _qualification_VETERINARY
        End Get
        Set(ByVal value As String)
            _qualification_VETERINARY = value
        End Set
    End Property
    Private _qualification As String
    Public Property qualification() As String
        Get
            Return _qualification
        End Get
        Set(ByVal value As String)
            _qualification = value
        End Set
    End Property
    Private _qualification_branch As String
    Public Property qualification_branch() As String
        Get
            Return _qualification_branch
        End Get
        Set(ByVal value As String)
            _qualification_branch = value
        End Set
    End Property
    Private _qualification_Year As String
    Public Property qualification_year() As String
        Get
            Return _qualification_Year
        End Get
        Set(ByVal value As String)
            _qualification_Year = value
        End Set
    End Property
    Private __Pharmacy_license_branch As String
    Public Property Pharmacy_license_branch() As String
        Get
            Return __Pharmacy_license_branch
        End Get
        Set(ByVal value As String)
            __Pharmacy_license_branch = value
        End Set
    End Property
    Private _Pharmacy_license_number As String
    Public Property Pharmacy_license_number() As String
        Get
            Return _Pharmacy_license_number
        End Get
        Set(ByVal value As String)
            _Pharmacy_license_number = value
        End Set
    End Property
    Private _Pharmacy_license_date As String
    Public Property Pharmacy_license_date() As String
        Get
            Return _Pharmacy_license_date
        End Get
        Set(ByVal value As String)
            _Pharmacy_license_date = value
        End Set
    End Property
End Class
