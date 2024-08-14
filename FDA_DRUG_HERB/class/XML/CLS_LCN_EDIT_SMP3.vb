Public Class CLS_LCN_EDIT_SMP3
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

    'Private _LCN_APPROVE_EDIT As New LCN_APPROVE_EDIT
    'Public Property LCN_APPROVE_EDIT() As LCN_APPROVE_EDIT
    '    Get
    '        Return _LCN_APPROVE_EDIT
    '    End Get
    '    Set(ByVal value As LCN_APPROVE_EDIT)
    '        _LCN_APPROVE_EDIT = value
    '    End Set
    'End Property



End Class
