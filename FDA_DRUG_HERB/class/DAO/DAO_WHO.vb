Namespace DAO_WHO
    Public MustInherit Class MAINCONTEXT        'ประกาศเพื่อใช้เป็น Class แม่
        Public db As New linq_whoDataContext    'ประกาศเพื่อใช้เป็น Class LINQ DataTable
        Public datas                            'ประกาศเ

    End Class

    Public Class TB_WHO_DALCN
        Inherits MAINCONTEXT

        Public fields As New WHO_DALCN

        Public Sub insert()
            db.WHO_DALCNs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.WHO_DALCNs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.WHO_DALCNs Select p)
        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.WHO_DALCNs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_IDEN(ByVal IDEN As String)
            datas = From p In db.WHO_DALCNs Where p.IDENTIFY = IDEN Select p
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetdatabyID_FK_LCN(ByVal FK_LCN As Integer)
            datas = From p In db.WHO_DALCNs Where p.FK_LCN = FK_LCN Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_FK_LCN_IDEN(ByVal FK_LCN As Integer, ByVal IDEN As String)
            datas = From p In db.WHO_DALCNs Where p.FK_LCN = FK_LCN And p.IDENTIFY = IDEN Select p

            For Each Me.fields In datas

            Next
        End Sub
        'Public Sub GetdatabyID_IDA_LCN_ID_AND_TR_ID(ByVal IDA As Integer, ByVal TR_ID As Integer, ByVal LCN_ID As Integer)
        '    datas = From p In db.TABEAN_JJs Where p.IDA = IDA And p.TR_ID_JJ = TR_ID And p.IDA_LCN = LCN_ID Select p

        '    For Each Me.fields In datas

        '    Next
        'End Sub

    End Class

End Namespace
