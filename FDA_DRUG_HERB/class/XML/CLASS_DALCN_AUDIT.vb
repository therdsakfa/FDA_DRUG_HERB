Public Class CLASS_DALCN_AUDIT
    Inherits CLASS_CENTER
    Public DALCN_AUDIT_IN As New DALCN_AUDIT_IN
    Public DALCN_AUDIT_OUT As New DALCN_AUDIT_OUT

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
    Private _CNSDATE_FULL_TH As String
    Public Property CNSDATE_FULL_TH() As String
        Get
            Return _CNSDATE_FULL_TH
        End Get
        Set(ByVal value As String)
            _CNSDATE_FULL_TH = value
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


#Region "cb"
    Private _DT1_1 As DataTable
    Public Property DT1_1() As DataTable
        Get
            Return _DT1_1
        End Get
        Set(ByVal value As DataTable)
            _DT1_1 = value
        End Set
    End Property
    Private _DT1_2 As DataTable
    Public Property DT1_2() As DataTable
        Get
            Return _DT1_2
        End Get
        Set(ByVal value As DataTable)
            _DT1_2 = value
        End Set
    End Property
    Private _DT1_3 As DataTable
    Public Property DT1_3() As DataTable
        Get
            Return _DT1_3
        End Get
        Set(ByVal value As DataTable)
            _DT1_3 = value
        End Set
    End Property
    Private _DT1_4 As DataTable
    Public Property DT1_4() As DataTable
        Get
            Return _DT1_4
        End Get
        Set(ByVal value As DataTable)
            _DT1_4 = value
        End Set
    End Property
    Private _DT1_5 As DataTable
    Public Property DT1_5() As DataTable
        Get
            Return _DT1_5
        End Get
        Set(ByVal value As DataTable)
            _DT1_5 = value
        End Set
    End Property
    Private _DT1_6 As DataTable
    Public Property DT1_6() As DataTable
        Get
            Return _DT1_6
        End Get
        Set(ByVal value As DataTable)
            _DT1_6 = value
        End Set
    End Property
    Private _DT1_7 As DataTable
    Public Property DT1_7() As DataTable
        Get
            Return _DT1_7
        End Get
        Set(ByVal value As DataTable)
            _DT1_7 = value
        End Set
    End Property
    Private _DT1_8 As DataTable
    Public Property DT1_8() As DataTable
        Get
            Return _DT1_8
        End Get
        Set(ByVal value As DataTable)
            _DT1_8 = value
        End Set
    End Property
    Private _DT1_9 As DataTable
    Public Property DT1_9() As DataTable
        Get
            Return _DT1_9
        End Get
        Set(ByVal value As DataTable)
            _DT1_9 = value
        End Set
    End Property
    Private _DT1_10 As DataTable
    Public Property DT1_10() As DataTable
        Get
            Return _DT1_10
        End Get
        Set(ByVal value As DataTable)
            _DT1_10 = value
        End Set
    End Property
    Private _DT1_11 As DataTable
    Public Property DT1_11() As DataTable
        Get
            Return _DT1_11
        End Get
        Set(ByVal value As DataTable)
            _DT1_11 = value
        End Set
    End Property
    Private _DT1_12 As DataTable
    Public Property DT1_12() As DataTable
        Get
            Return _DT1_12
        End Get
        Set(ByVal value As DataTable)
            _DT1_12 = value
        End Set
    End Property
    Private _DT1_13 As DataTable
    Public Property DT1_13() As DataTable
        Get
            Return _DT1_13
        End Get
        Set(ByVal value As DataTable)
            _DT1_13 = value
        End Set
    End Property
    Private _DT1_14 As DataTable
    Public Property DT1_14() As DataTable
        Get
            Return _DT1_14
        End Get
        Set(ByVal value As DataTable)
            _DT1_14 = value
        End Set
    End Property
    Private _DT1_15 As DataTable
    Public Property DT1_15() As DataTable
        Get
            Return _DT1_15
        End Get
        Set(ByVal value As DataTable)
            _DT1_15 = value
        End Set
    End Property
    Private _DT1_16 As DataTable
    Public Property DT1_16() As DataTable
        Get
            Return _DT1_16
        End Get
        Set(ByVal value As DataTable)
            _DT1_16 = value
        End Set
    End Property
    Private _DT1_17 As DataTable
    Public Property DT1_17() As DataTable
        Get
            Return _DT1_17
        End Get
        Set(ByVal value As DataTable)
            _DT1_17 = value
        End Set
    End Property
    Private _DT1_18 As DataTable
    Public Property DT1_18() As DataTable
        Get
            Return _DT1_18
        End Get
        Set(ByVal value As DataTable)
            _DT1_18 = value
        End Set
    End Property
    Private _DT1_19 As DataTable
    Public Property DT1_19() As DataTable
        Get
            Return _DT1_19
        End Get
        Set(ByVal value As DataTable)
            _DT1_19 = value
        End Set
    End Property
    Private _DT1_20 As DataTable
    Public Property DT1_20() As DataTable
        Get
            Return _DT1_20
        End Get
        Set(ByVal value As DataTable)
            _DT1_20 = value
        End Set
    End Property
    Private _DT1_21 As DataTable
    Public Property DT1_21() As DataTable
        Get
            Return _DT1_21
        End Get
        Set(ByVal value As DataTable)
            _DT1_21 = value
        End Set
    End Property
#End Region
End Class
