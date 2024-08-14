Imports System.Data
Imports System.Data.SqlClient
Imports System.Web

Namespace BAO_LCN
    Public Class connection_db
        Public Function Queryds(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("LGT_DRUGConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
    End Class

    Public Class Dropdown
        Inherits connection_db

        Public Function SP_LCN_APPROVE_EDIT_GET_DATA(ByVal lcn As Integer, ByVal staff_type As Integer) As DataTable

            Dim sql As String = "exec SP_LCN_APPROVE_EDIT_GET_DATA @IDA= " & lcn & ",@STAFF_TYPE=" & staff_type
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function

        Public Function SP_LCN_EDIT_STATUS(ByVal s_sub_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_LCN_EDIT_STATUS @STATUS_GROUP_SUB=" & s_sub_id
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_MAS_STAFF_NAME_HERB() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_STAFF_NAME_HERB"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_TABEAN_DRUGGROUP_JJ() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_DRUGGROUP_JJ"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_TABEAN_DRUGGROUPTYPE_JJ() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_DRUGGROUPTYPE_JJ"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_LCN_APPROVE_EDIT_GET_DDL_REASON() As DataTable

            Dim sql As String = "exec SP_LCN_APPROVE_EDIT_GET_DDL_REASON "
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function

        Public Function SP_LCN_APPROVE_EDIT_GET_DDL_REASON_SUB(ByVal fk_ida As Integer) As DataTable

            Dim sql As String = "exec SP_LCN_APPROVE_EDIT_GET_DDL_REASON_SUB @IDA= " & fk_ida
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function
        Public Function SP_LCN_APPROVE_EDIT_GET_MAS_UPLOAD_FILE(ByVal dd1 As Integer, ByVal dd2 As Integer) As DataTable

            Dim sql As String = "exec SP_LCN_APPROVE_EDIT_GET_MAS_UPLOAD_FILE @dd1=" & dd1 & ",@dd2=" & dd2
            Dim dta As New DataTable
            dta = Queryds(sql)
            Return dta
        End Function

    End Class
    Public Class TABLE_VIEW
        Inherits connection_db
        Public Function SP_LCN_APPROVE_EDIT_GET_DATA(ByVal lcn As Integer, ByVal staff As Integer) As DataTable

            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_LCN_APPROVE_EDIT_GET_DATA @IDA=" & lcn & ",@STAFF_TYPE=" & staff
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_LCN_APPROVE_EDIT_GET_DATA_FILE_UPLOAD_FOR_UPDATE(ByVal lcn As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal typeCre As Integer, ByVal year As String) As DataTable

            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_LCN_APPROVE_EDIT_GET_DATA_FILE_UPLOAD_FOR_UPDATE @LCN_IDA=" & lcn & ",@DDL1=" & ddl1 & ",@DDL2=" & ddl2 & ",@TYPE_CREATE=" & typeCre & ",@YEAR='" & year & "'"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_LCN_APPROVE_EDIT_GET_UPLOAD_FILE(ByVal type As Integer) As DataTable

            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_LCN_APPROVE_EDIT_GET_UPLOAD_FILE @REASON_TYPE= " & type
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_LCN_APPROVE_EDIT_GET_TRANSACTION_RQ_NUMBER() As DataTable

            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_LCN_APPROVE_EDIT_GET_TRANSACTION_RQ_NUMBER"
            dt = Queryds(qstr)

            Return dt
        End Function
    End Class

    Public Class BIND_DT_XML
        Inherits connection_db
        Public Function SP_LCN_APPROVE_EDIT_GET_DATA_XML1(ByVal ida As Integer, ByVal year As Integer) As DataTable

            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_LCN_APPROVE_EDIT_GET_DATA_XML1 @IDA= " & ida & ",@YEAR=" & year
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_LCN_APPROVE_EDIT_GET_DATA_XML2(ByVal ida As Integer, ByVal year As Integer) As DataTable

            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_LCN_APPROVE_EDIT_GET_DATA_XML2 @IDA= " & ida & ",@YEAR=" & year
            dt = Queryds(qstr)

            Return dt
        End Function
    End Class


End Namespace

