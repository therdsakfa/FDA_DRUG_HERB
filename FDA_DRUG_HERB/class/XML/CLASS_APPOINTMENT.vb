Public Class CLASS_APPOINTMENT
    Private _process_id As String
    Public Property process_id() As String
        Get
            Return _process_id
        End Get
        Set(ByVal value As String)
            _process_id = value
        End Set
    End Property

    Private _process_name As String
    Public Property process_name() As String
        Get
            Return _process_name
        End Get
        Set(ByVal value As String)
            _process_name = value
        End Set
    End Property

    Private _product_name As String
    Public Property product_name() As String
        Get
            Return _product_name
        End Get
        Set(ByVal value As String)
            _product_name = value
        End Set
    End Property

    Private _dalcnno As String
    Public Property dalcnno() As String
        Get
            Return _dalcnno
        End Get
        Set(ByVal value As String)
            _dalcnno = value
        End Set
    End Property

    Private _rcvno As String
    Public Property rcvno() As String
        Get
            Return _rcvno
        End Get
        Set(ByVal value As String)
            _rcvno = value
        End Set
    End Property

    Private _rcvdate As String
    Public Property rcvdate() As String
        Get
            Return _rcvdate
        End Get
        Set(ByVal value As String)
            _rcvdate = value
        End Set
    End Property

    Private _appointment_date As String
    Public Property appointment_date() As String
        Get
            Return _appointment_date
        End Get
        Set(ByVal value As String)
            _appointment_date = value
        End Set
    End Property

    Private _name_req As String
    Public Property name_req() As String
        Get
            Return _name_req
        End Get
        Set(ByVal value As String)
            _name_req = value
        End Set
    End Property

    Private _tel_req As String
    Public Property tel_req() As String
        Get
            Return _tel_req
        End Get
        Set(ByVal value As String)
            _tel_req = value
        End Set
    End Property

    Private _name_contact As String
    Public Property name_contact() As String
        Get
            Return _name_contact
        End Get
        Set(ByVal value As String)
            _name_contact = value
        End Set
    End Property
    Private _COMPLICATE_NAME As String
    Public Property COMPLICATE_NAME() As String
        Get
            Return _COMPLICATE_NAME
        End Get
        Set(ByVal value As String)
            _COMPLICATE_NAME = value
        End Set
    End Property

    Private _tel_callback As String
    Public Property tel_callback() As String
        Get
            Return _tel_callback
        End Get
        Set(ByVal value As String)
            _tel_callback = value
        End Set
    End Property

    Private _email As String
    Public Property email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Private _group_assign As String
    Public Property group_assign() As String
        Get
            Return _group_assign
        End Get
        Set(ByVal value As String)
            _group_assign = value
        End Set
    End Property
    Private _TR_ID As String
    Public Property TR_ID() As String
        Get
            Return _TR_ID
        End Get
        Set(ByVal value As String)
            _TR_ID = value
        End Set
    End Property
    Private _DISCOUNT_DETAIL As String
    Public Property DISCOUNT_DETAIL() As String
        Get
            Return _DISCOUNT_DETAIL
        End Get
        Set(ByVal value As String)
            _DISCOUNT_DETAIL = value
        End Set
    End Property
    Private _estimate_date As String
    Public Property estimate_date() As String
        Get
            Return _estimate_date
        End Get
        Set(ByVal value As String)
            _estimate_date = value
        End Set
    End Property
    Private _estimate_date_max As String
    Public Property estimate_date_max() As String
        Get
            Return _estimate_date_max
        End Get
        Set(ByVal value As String)
            _estimate_date_max = value
        End Set
    End Property
End Class
