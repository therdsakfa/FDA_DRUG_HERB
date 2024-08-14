Imports System.Data.SqlClient

Namespace BAO_WHO
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

    Public Class tb_who
        Inherits connection_db
        Public Function SP_WHO_DALCN(ByVal _CID As String) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_WHO_DALCN @iden= '" & _CID & "'"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_WHO_DALCN_BY_IDEN_AND_FK_IDA(ByVal _CID As String, ByVal FK_IDA As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_WHO_DALCN_BY_IDEN_AND_FK_IDA @iden= '" & _CID & "' " & ",@FK_IDA=" & FK_IDA
            dt = Queryds(qstr)

            Return dt
        End Function

    End Class

End Namespace


