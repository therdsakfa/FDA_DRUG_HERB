Public Class XML_DATA

    ' เลขรหัสผู้ประกอบการ
    Private _SYSLCNSIDs As New syslcnsid
    Public Property SYSLCNSIDs() As syslcnsid
        Get
            Return _SYSLCNSIDs
        End Get
        Set(ByVal value As syslcnsid)
            _SYSLCNSIDs = value
        End Set
    End Property

    ' ตารางชื่อนาม
    Private _SYSLCNSNMs As New syslcnsnm
    Public Property SYSLCNSNMs() As syslcnsnm
        Get
            Return _SYSLCNSNMs
        End Get
        Set(ByVal value As syslcnsnm)
            _SYSLCNSNMs = value
        End Set
    End Property

    ''' <summary>
    ''' ที่อยู่
    ''' </summary>
    Private _SYSLCTADDRs As New syslctaddr
    Public Property SYSLCTADDRs() As syslctaddr
        Get
            Return _SYSLCTADDRs
        End Get
        Set(ByVal value As syslctaddr)
            _SYSLCTADDRs = value
        End Set
    End Property

    'Private _PERSON_IDEMs As New PERSON_IDEM
    'Public Property PERSON_IDEMs() As PERSON_IDEM
    '    Get
    '        Return _PERSON_IDEMs
    '    End Get
    '    Set(ByVal value As PERSON_IDEM)
    '        _PERSON_IDEMs = value
    '    End Set
    'End Property

    Private _EMAIL As String
    Public Property EMAIL() As String
        Get
            Return _EMAIL
        End Get
        Set(ByVal value As String)
            _EMAIL = value
        End Set
    End Property
    Private _TEL As String
    Public Property TEL() As String
        Get
            Return _TEL
        End Get
        Set(ByVal value As String)
            _TEL = value
        End Set
    End Property

    Private _FIELDS_MSGs As String
    Public Property FIELDS_MSGs() As String
        Get
            Return _FIELDS_MSGs
        End Get
        Set(ByVal value As String)
            _FIELDS_MSGs = value
        End Set
    End Property
End Class
