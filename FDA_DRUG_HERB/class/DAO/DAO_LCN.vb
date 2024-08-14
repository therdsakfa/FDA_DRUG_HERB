Namespace DAO_LCN
    Public MustInherit Class MAINCONTEXT        'ประกาศเพื่อใช้เป็น Class แม่
        Public db As New LINQ_LCNDataContext 'ประกาศเพื่อใช้เป็น Class LINQ DataTable
        'Public db As New 'ประกาศเพื่อใช้เป็น Class LINQ DataTable
        Public datas                            'ประกาศเ

    End Class

    Public Class TB_LCN_APPROVE_EDIT_UPLOAD_FILE
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT_UPLOAD_FILE

        Private _Details As New List(Of LCN_APPROVE_EDIT_UPLOAD_FILE)
        Public Property Details() As List(Of LCN_APPROVE_EDIT_UPLOAD_FILE)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of LCN_APPROVE_EDIT_UPLOAD_FILE))
                _Details = value
            End Set
        End Property
        Public Sub insert()
            db.LCN_APPROVE_EDIT_UPLOAD_FILEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_APPROVE_EDIT_UPLOAD_FILEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_APPROVE_EDIT_UPLOAD_FILEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.LCN_APPROVE_EDIT_UPLOAD_FILEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TR_ID(ByVal TR_ID As Integer)

            datas = (From p In db.LCN_APPROVE_EDIT_UPLOAD_FILEs Where p.TR_ID = TR_ID Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GETDATA_BY_PROCESS_HEAD_ID_TITEL_ID_TR_ID(ByVal PROCESS_ID As Integer, ByVal HEAD_ID As Integer, ByVal TITEL_ID1 As Integer, ByVal TITEL_ID2 As Integer, ByVal TR_ID As String, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_UPLOAD_FILEs Where p.PROCESS_ID = PROCESS_ID And p.HEAD_ID = HEAD_ID And p.FK_TITEL_ID = TITEL_ID1 And p.FK_TITEL_ID2 = TITEL_ID2 And p.TR_ID = TR_ID And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GETDATA_BY_PROCESS_HEAD_ID_TITEL_ID_TR_ID_EDIT_FILE(ByVal PROCESS_ID As Integer, ByVal HEAD_ID As Integer, ByVal TITEL_ID1 As Integer, ByVal TITEL_ID2 As Integer, ByVal TR_ID As String, ByVal type_edit As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_UPLOAD_FILEs Where p.PROCESS_ID = PROCESS_ID And p.HEAD_ID = HEAD_ID And p.FK_TITEL_ID = TITEL_ID1 And p.FK_TITEL_ID2 = TITEL_ID2 And p.TR_ID = TR_ID And p.TYPE = type_edit And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GETDATA_BY_PROCESS_HEAD_ID_TITEL_ID_AND_TYPE_EDIT(ByVal process As Integer, ByVal TITEL_ID1 As Integer, ByVal TITEL_ID2 As Integer, ByVal type_edit As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_UPLOAD_FILEs Where p.PROCESS_ID = process And p.FK_TITEL_ID = TITEL_ID1 And p.FK_TITEL_ID2 = TITEL_ID2 And p.TYPE = type_edit And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_DATA_BY_FILE_NUMBER(ByVal file_id As Integer, ByVal LCN_IDA As Integer)

            datas = (From p In db.LCN_APPROVE_EDIT_UPLOAD_FILEs Where p.FILE_NUMBER_NAME = file_id And p.FK_IDA = LCN_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetdatabyID_TR_ID_PROCESS_ID_ALL(ByVal TR_ID As Integer, ByVal PROCESS_ID As String, ByVal type_id As Integer)
            datas = From p In db.LCN_APPROVE_EDIT_UPLOAD_FILEs Where p.TR_ID = TR_ID And p.PROCESS_ID = PROCESS_ID And p.TYPE = type_id Select p
        End Sub
    End Class



    Public Class TB_LCN_APPROVE_EDIT_TRANSACTION_RQ_NUMBER
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT_TRANSACTION_RQ_NUMBER

        Public Sub insert()
            db.LCN_APPROVE_EDIT_TRANSACTION_RQ_NUMBERs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.LCN_APPROVE_EDIT_TRANSACTION_RQ_NUMBERs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.LCN_APPROVE_EDIT_TRANSACTION_RQ_NUMBERs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.LCN_APPROVE_EDIT_TRANSACTION_RQ_NUMBERs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA_JJ(ByVal FK_IDA As Integer)
            datas = From p In db.LCN_APPROVE_EDIT_TRANSACTION_RQ_NUMBERs Where p.FK_IDA_LCN = FK_IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetDataby_GEN(ByVal YEAR As String, ByVal process As Integer, ByVal FK_IDA_LCN As Integer)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.LCN_APPROVE_EDIT_TRANSACTION_RQ_NUMBERs Where p.YEAR = YEAR And p.PROCESS_ID = process And p.FK_IDA_LCN = FK_IDA_LCN Order By CInt(p.GEN_NO) Descending Select p).Take(1)
            For Each Me.fields In datas

            Next
        End Sub

    End Class
    Public Class TB_MAS_DALCN_PHR_TRAINING
        Inherits MAINCONTEXT

        Public fields As New MAS_DALCN_PHR_TRAINING


        Public Sub insert()
            db.MAS_DALCN_PHR_TRAININGs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_DALCN_PHR_TRAININGs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_DALCN_PHR_TRAININGs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_ID(ByVal ID As Integer)

            datas = (From p In db.MAS_DALCN_PHR_TRAININGs Where p.ID = ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TRAINING_ID(ByVal ID As Integer)

            datas = (From p In db.MAS_DALCN_PHR_TRAININGs Where p.TRAINING_ID = ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_MAS_TYPE_MAJOR
        Inherits MAINCONTEXT

        Public fields As New MAS_TYPE_MAJOR


        Public Sub insert()
            db.MAS_TYPE_MAJORs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_TYPE_MAJORs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_TYPE_MAJORs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_ID(ByVal ID As Integer)

            datas = (From p In db.MAS_TYPE_MAJORs Where p.IDA = ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_MAS_TYPE_QUALIFICATION
        Inherits MAINCONTEXT

        Public fields As New MAS_TYPE_QUALIFICATION


        Public Sub insert()
            db.MAS_TYPE_QUALIFICATIONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_TYPE_QUALIFICATIONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_TYPE_QUALIFICATIONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_ID(ByVal ID As Integer)

            datas = (From p In db.MAS_TYPE_QUALIFICATIONs Where p.IDA = ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_LCN_APPROVE_EDIT
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT

        Public Sub insert()
            db.LCN_APPROVE_EDITs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_APPROVE_EDITs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_APPROVE_EDITs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA_YEAR(ByVal IDA As Integer, ByVal year As String, ByVal active As Integer)

            datas = (From p In db.LCN_APPROVE_EDITs Where p.IDA = IDA And p.DATE_YEAR = year And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.LCN_APPROVE_EDITs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TR_ID(ByVal TR_ID As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDITs Where p.TR_ID = TR_ID And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_LCN_IDA_AND_YEAR_AND_ACTIVE(ByVal IDA As Integer, ByVal year As String, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDITs Where p.FK_LCN_IDA = IDA And p.DATE_YEAR = year And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_LCN_IDA_AND_YEAR_TR_ID_AND_ACTIVE(ByVal IDA As Integer, ByVal year As String, ByVal tr_id As String, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDITs Where p.FK_LCN_IDA = IDA And p.DATE_YEAR = year And p.TR_ID = tr_id And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataBY_LCN_IDA(ByVal lcn As Integer)

            datas = (From p In db.LCN_APPROVE_EDITs Where p.FK_LCN_IDA = lcn Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataBY_IDA_LCN_IDA_LCN_EDIT_REASON_TYPE(ByVal IDA As String, ByVal lcn As Integer, ByVal edit_reason_type As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDITs Where p.FK_LCN_IDA = lcn And p.LCN_EDIT_REASON_TYPE = edit_reason_type And p.IDA = IDA And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataBY_LCN_IDA_LCN_EDIT_REASON_TYPE_YEAR(ByVal lcn As Integer, ByVal edit_reason_type As Integer, ByVal year As String, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDITs Where p.FK_LCN_IDA = lcn And p.LCN_EDIT_REASON_TYPE = edit_reason_type And p.DATE_YEAR = year And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_DALCN_RENEW
        Inherits MAINCONTEXT

        Public fields As New DALCN_RENEW


        Public Sub insert()
            db.DALCN_RENEWs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DALCN_RENEWs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DALCN_RENEWs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_DATA_BY_IDA(ByVal ida As Integer)

            datas = (From p In db.DALCN_RENEWs Where p.IDA = ida Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_DATA_BY_FK_LCN(ByVal ida As Integer, ByVal active As Boolean)

            datas = (From p In db.DALCN_RENEWs Where p.FK_LCN = ida And p.ACTIVEFACT = active Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_LOG_RENEW_HERB
        Inherits MAINCONTEXT

        Public fields As New LOG_RENEW_HERB


        Public Sub insert()
            db.LOG_RENEW_HERBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LOG_RENEW_HERBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LOG_RENEW_HERBs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_DATA_BY_IDA(ByVal ida As Integer)

            datas = (From p In db.LOG_RENEW_HERBs Where p.IDA = ida Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_DALCN_TRANSFER
        Inherits MAINCONTEXT

        Public fields As New DALCN_TRANSFER


        Public Sub insert()
            db.DALCN_TRANSFERs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.DALCN_TRANSFERs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.DALCN_TRANSFERs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_DATA_BY_IDA(ByVal ida As Integer)

            datas = (From p In db.DALCN_TRANSFERs Where p.IDA = ida Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_DATA_BY_FK_LCN(ByVal ida As Integer, ByVal active As Boolean)

            datas = (From p In db.DALCN_TRANSFERs Where p.FK_LCN = ida And p.ACTIVEFACT = active Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_LOG_LOCATION_BSN
        Inherits MAINCONTEXT

        Public fields As New LOG_LOCATION_BSN

        Public Sub insert()
            db.LOG_LOCATION_BSNs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.LOG_LOCATION_BSNs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.LOG_LOCATION_BSNs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.LOG_LOCATION_BSNs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_FK_IDA(ByVal FK_IDA As Integer)
            datas = From p In db.LOG_LOCATION_BSNs Where p.FK_IDA = FK_IDA Select p
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_LOG_STATUS_LCN_EDIT
        Inherits MAINCONTEXT

        Public fields As New LOG_STATUS_LCN_EDIT

        Public Sub insert()
            db.LOG_STATUS_LCN_EDITs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LOG_STATUS_LCN_EDITs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LOG_STATUS_LCN_EDITs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.LCN_APPROVE_EDITs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_MAS_REASON_UPDATE_STATUS
        Inherits MAINCONTEXT

        Public fields As New MAS_REASON_UPDATE_STATUS

        Public Sub insert()
            db.MAS_REASON_UPDATE_STATUS.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_REASON_UPDATE_STATUS.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_REASON_UPDATE_STATUS Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_ID(ByVal ID As String)

            datas = (From p In db.MAS_REASON_UPDATE_STATUS Where p.ID = ID Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_MAS_LCN_APPROVE_EDIT_REASON_UPLOAD_FILE
        Inherits MAINCONTEXT

        Public fields As New MAS_LCN_APPROVE_EDIT_REASON_UPLOAD_FILE

        'Private _Details As New List(Of LCN_APPROVE_EDIT_UPLOAD_FILE)
        'Public Property Details() As List(Of MAS_LCN_APPROVE_EDIT_REASON_UPLOAD_FILE)
        '    Get
        '        Return _Details
        '    End Get
        '    Set(ByVal value As List(Of LCN_APPROVE_EDIT_UPLOAD_FILE))
        '        _Details = value
        '    End Set
        'End Property
        Public Sub insert()
            db.MAS_LCN_APPROVE_EDIT_REASON_UPLOAD_FILEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_LCN_APPROVE_EDIT_REASON_UPLOAD_FILEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_LCN_APPROVE_EDIT_REASON_UPLOAD_FILEs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_ID(ByVal id As Integer)

            datas = (From p In db.MAS_LCN_APPROVE_EDIT_REASON_UPLOAD_FILEs Where p.ID = id Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_DDL(ByVal TITEL_ID As Integer, ByVal TITLE_ID2 As Integer, ByVal active As Boolean)

            datas = (From p In db.MAS_LCN_APPROVE_EDIT_REASON_UPLOAD_FILEs Where p.TITEL_ID = TITEL_ID And p.TITLE_ID2 = TITLE_ID2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub



    End Class
    Public Class TB_MAS_LCN_APPROVE_EDIT_REASON
        Inherits MAINCONTEXT

        Public fields As New MAS_LCN_APPROVE_EDIT_REASON


        Public Sub insert()
            db.MAS_LCN_APPROVE_EDIT_REASONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_LCN_APPROVE_EDIT_REASONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_LCN_APPROVE_EDIT_REASONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_DDL1(ByVal ddl1 As Integer, ByVal active As Boolean)

            datas = (From p In db.MAS_LCN_APPROVE_EDIT_REASONs Where p.LCN_REASON_TYPE = ddl1 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_MAS_LCN_APPROVE_EDIT_REASON_SUB
        Inherits MAINCONTEXT

        Public fields As New MAS_LCN_APPROVE_EDIT_REASON_SUB


        Public Sub insert()
            db.MAS_LCN_APPROVE_EDIT_REASON_SUBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_LCN_APPROVE_EDIT_REASON_SUBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_LCN_APPROVE_EDIT_REASON_SUBs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_DDL2(ByVal ddl2 As Integer, ByVal active As Boolean)

            datas = (From p In db.MAS_LCN_APPROVE_EDIT_REASON_SUBs Where p.SUB_REASON_TYPE = ddl2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class

    Public Class TB_LCN_APPROVE_EDIT_DDL1_REASON
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT_DDL1_REASON


        Public Sub insert()
            db.LCN_APPROVE_EDIT_DDL1_REASONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_APPROVE_EDIT_DDL1_REASONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_APPROVE_EDIT_DDL1_REASONs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_DATA_BY_IDA(ByVal ida As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_DDL1_REASONs Where p.IDA = ida And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_DATA_BY_FK_LCN_IDA(ByVal ida As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_DDL1_REASONs Where p.FK_LCN_IDA = ida And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub



    End Class
    Public Class TB_LCN_APPROVE_EDIT_DDL2_REASON
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT_DDL2_REASON


        Public Sub insert()
            db.LCN_APPROVE_EDIT_DDL2_REASONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_APPROVE_EDIT_DDL2_REASONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_APPROVE_EDIT_DDL2_REASONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCN_IDA(ByVal ida As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_DDL2_REASONs Where p.FK_LCT_IDA = ida And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(ByVal ida As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_DDL2_REASONs Where p.FK_LCT_IDA = ida And p.ddl1 = ddl1 And p.ddl2 = ddl2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub



    End Class
    Public Class TB_LCN_APPROVE_EDIT_DDL3_REASON
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT_DDL3_REASON


        Public Sub insert()
            db.LCN_APPROVE_EDIT_DDL3_REASONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_APPROVE_EDIT_DDL3_REASONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_APPROVE_EDIT_DDL3_REASONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCN_IDA(ByVal ida As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_DDL3_REASONs Where p.FK_LCN_IDA = ida And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(ByVal ida As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_DDL3_REASONs Where p.FK_LCN_IDA = ida And p.ddl1 = ddl1 And p.ddl2 = ddl2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub


    End Class
    Public Class TB_LCN_APPROVE_EDIT_DDL4_REASON
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT_DDL4_REASON


        Public Sub insert()
            db.LCN_APPROVE_EDIT_DDL4_REASONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_APPROVE_EDIT_DDL4_REASONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_APPROVE_EDIT_DDL4_REASONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCN_IDA(ByVal ida As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_DDL4_REASONs Where p.FK_LCN_IDA = ida And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub



    End Class
    Public Class TB_LCN_APPROVE_EDIT_DDL5_REASON
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT_DDL5_REASON


        Public Sub insert()
            db.LCN_APPROVE_EDIT_DDL5_REASONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_APPROVE_EDIT_DDL5_REASONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_APPROVE_EDIT_DDL5_REASONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCN_IDA(ByVal ida As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_DDL5_REASONs Where p.FK_LCT_IDA = ida And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_DATA_BY_FK_LCT_IDA_DDL1_DDL2_ACTIVE(ByVal ida As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_DDL5_REASONs Where p.FK_LCT_IDA = ida And p.ddl1 = ddl1 And p.ddl2 = ddl2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(ByVal ida As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_DDL5_REASONs Where p.FK_LCN_IDA = ida And p.ddl1 = ddl1 And p.ddl2 = ddl2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_DATA_BY_FK_LCN_IDA_IDAROW_DDL1_DDL2_ACTIVE(ByVal ida As Integer, ByVal row As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_DDL5_REASONs Where p.FK_LCN_IDA = ida And p.FK_IDA_CHK_ROW = row And p.ddl1 = ddl1 And p.ddl2 = ddl2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub



    End Class
    Public Class TB_LCN_APPROVE_EDIT_DDL6_REASON
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT_DDL6_REASON


        Public Sub insert()
            db.LCN_APPROVE_EDIT_DDL6_REASONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_APPROVE_EDIT_DDL6_REASONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_APPROVE_EDIT_DDL6_REASONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCT_IDA(ByVal ida As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_DDL6_REASONs Where p.FK_LCT_IDA = ida And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub



    End Class
    Public Class TB_LCN_APPROVE_EDIT_DDL7_REASON
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT_DDL7_REASON


        Public Sub insert()
            db.LCN_APPROVE_EDIT_DDL7_REASONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_APPROVE_EDIT_DDL7_REASONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_APPROVE_EDIT_DDL7_REASONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCN_IDA(ByVal ida As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_DDL7_REASONs Where p.FK_LCN_IDA = ida And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(ByVal ida As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_DDL7_REASONs Where p.FK_LCN_IDA = ida And p.ddl1 = ddl1 And p.ddl2 = ddl2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub


    End Class
    Public Class TB_LCN_APPROVE_EDIT_DDL8_REASON
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT_DDL8_REASON


        Public Sub insert()
            db.LCN_APPROVE_EDIT_DDL8_REASONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_APPROVE_EDIT_DDL8_REASONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_APPROVE_EDIT_DDL8_REASONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCN_IDA(ByVal ida As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_DDL8_REASONs Where p.FK_LCT_IDA = ida And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCT_IDA_DDL1_DDL2_ACTIVE(ByVal ida As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_DDL8_REASONs Where p.FK_LCT_IDA = ida And p.ddl1 = ddl1 And p.ddl2 = ddl2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_LCN_APPROVE_EDIT_DDL9_REASON
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT_DDL9_REASON


        Public Sub insert()
            db.LCN_APPROVE_EDIT_DDL9_REASONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_APPROVE_EDIT_DDL9_REASONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_APPROVE_EDIT_DDL9_REASONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCN_IDA(ByVal ida As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_DDL9_REASONs Where p.FK_LCN_IDA = ida And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(ByVal ida As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_DDL9_REASONs Where p.FK_LCN_IDA = ida And p.ddl1 = ddl1 And p.ddl2 = ddl2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_LCN_APPROVE_EDIT_DDL10_REASON
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT_DDL10_REASON


        Public Sub insert()
            db.LCN_APPROVE_EDIT_DDL10_REASONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_APPROVE_EDIT_DDL10_REASONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_APPROVE_EDIT_DDL10_REASONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCN_IDA(ByVal ida As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_DDL10_REASONs Where p.FK_LCN_IDA = ida And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(ByVal ida As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_DDL10_REASONs Where p.FK_LCN_IDA = ida And p.ddl1 = ddl1 And p.ddl2 = ddl2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_DATA_BY_FK_LCN_IDA_IDAROW_DDL1_DDL2_ACTIVE(ByVal ida As Integer, ByVal row As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_DDL10_REASONs Where p.FK_LCN_IDA = ida And p.FK_IDA_CHK_ROW = row And p.ddl1 = ddl1 And p.ddl2 = ddl2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub



    End Class
    Public Class TB_LCN_APPROVE_EDIT_DDL11_REASON
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT_DDL11_REASON


        Public Sub insert()
            db.LCN_APPROVE_EDIT_DDL11_REASONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_APPROVE_EDIT_DDL11_REASONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_APPROVE_EDIT_DDL11_REASONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCN_IDA(ByVal ida As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_DDL11_REASONs Where p.FK_LCN_IDA = ida And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(ByVal ida As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_DDL11_REASONs Where p.FK_LCN_IDA = ida And p.ddl1 = ddl1 And p.ddl2 = ddl2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_DATA_BY_FK_LCN_IDA_IDAROW_DDL1_DDL2_ACTIVE(ByVal ida As Integer, ByVal row As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_DDL11_REASONs Where p.FK_LCN_IDA = ida And p.FK_IDA_CHK_ROW = row And p.ddl1 = ddl1 And p.ddl2 = ddl2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub


    End Class

    Public Class TB_OLD_LCN_APPROVE_EDIT_DDL1_REASON
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT_OLD_DDL1_REASON


        Public Sub insert()
            db.LCN_APPROVE_EDIT_OLD_DDL1_REASONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_APPROVE_EDIT_OLD_DDL1_REASONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL1_REASONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCN_IDA(ByVal ida As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL1_REASONs Where p.FK_LCN_IDA = ida And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub



    End Class
    Public Class TB_OLD_LCN_APPROVE_EDIT_DDL2_REASON
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT_OLD_DDL2_REASON


        Public Sub insert()
            db.LCN_APPROVE_EDIT_OLD_DDL2_REASONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_APPROVE_EDIT_OLD_DDL2_REASONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL2_REASONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCN_IDA(ByVal ida As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL2_REASONs Where p.FK_LCT_IDA = ida And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(ByVal ida As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL2_REASONs Where p.FK_LCT_IDA = ida And p.ddl1 = ddl1 And p.ddl2 = ddl2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub



    End Class
    Public Class TB_OLD_LCN_APPROVE_EDIT_DDL3_REASON
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT_OLD_DDL3_REASON


        Public Sub insert()
            db.LCN_APPROVE_EDIT_OLD_DDL3_REASONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_APPROVE_EDIT_OLD_DDL3_REASONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL3_REASONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCN_IDA(ByVal ida As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL3_REASONs Where p.FK_LCN_IDA = ida And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(ByVal ida As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL3_REASONs Where p.FK_LCN_IDA = ida And p.ddl1 = ddl1 And p.ddl2 = ddl2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub


    End Class
    Public Class TB_OLD_LCN_APPROVE_EDIT_DDL4_REASON
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT_OLD_DDL4_REASON


        Public Sub insert()
            db.LCN_APPROVE_EDIT_OLD_DDL4_REASONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_APPROVE_EDIT_OLD_DDL4_REASONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL4_REASONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCN_IDA(ByVal ida As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL4_REASONs Where p.FK_LCN_IDA = ida And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub



    End Class
    Public Class TB_OLD_LCN_APPROVE_EDIT_DDL5_REASON
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT_OLD_DDL5_REASON


        Public Sub insert()
            db.LCN_APPROVE_EDIT_OLD_DDL5_REASONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_APPROVE_EDIT_OLD_DDL5_REASONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL5_REASONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCN_IDA(ByVal ida As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL5_REASONs Where p.FK_LCT_IDA = ida And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_DATA_BY_FK_LCT_IDA_DDL1_DDL2_ACTIVE(ByVal ida As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL5_REASONs Where p.FK_LCT_IDA = ida And p.ddl1 = ddl1 And p.ddl2 = ddl2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(ByVal ida As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL5_REASONs Where p.FK_LCN_IDA = ida And p.ddl1 = ddl1 And p.ddl2 = ddl2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_DATA_BY_FK_LCN_IDA_IDAROW_DDL1_DDL2_ACTIVE(ByVal ida As Integer, ByVal row As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL5_REASONs Where p.FK_LCN_IDA = ida And p.FK_IDA_CHK_ROW = row And p.ddl1 = ddl1 And p.ddl2 = ddl2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub



    End Class
    Public Class TB_OLD_LCN_APPROVE_EDIT_DDL6_REASON
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT_OLD_DDL6_REASON


        Public Sub insert()
            db.LCN_APPROVE_EDIT_OLD_DDL6_REASONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_APPROVE_EDIT_OLD_DDL6_REASONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL6_REASONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCT_IDA(ByVal ida As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL6_REASONs Where p.FK_LCT_IDA = ida And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub



    End Class
    Public Class TB_OLD_LCN_APPROVE_EDIT_DDL7_REASON
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT_OLD_DDL7_REASON


        Public Sub insert()
            db.LCN_APPROVE_EDIT_OLD_DDL7_REASONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_APPROVE_EDIT_OLD_DDL7_REASONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL7_REASONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCN_IDA(ByVal ida As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL7_REASONs Where p.FK_LCN_IDA = ida And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(ByVal ida As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL7_REASONs Where p.FK_LCN_IDA = ida And p.ddl1 = ddl1 And p.ddl2 = ddl2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub


    End Class
    Public Class TB_OLD_LCN_APPROVE_EDIT_DDL8_REASON
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT_OLD_DDL8_REASON


        Public Sub insert()
            db.LCN_APPROVE_EDIT_OLD_DDL8_REASONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_APPROVE_EDIT_OLD_DDL8_REASONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL8_REASONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCN_IDA(ByVal ida As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL8_REASONs Where p.FK_LCT_IDA = ida And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCT_IDA_DDL1_DDL2_ACTIVE(ByVal ida As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL8_REASONs Where p.FK_LCT_IDA = ida And p.ddl1 = ddl1 And p.ddl2 = ddl2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_OLD_LCN_APPROVE_EDIT_DDL9_REASON
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT_OLD_DDL9_REASON


        Public Sub insert()
            db.LCN_APPROVE_EDIT_OLD_DDL9_REASONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_APPROVE_EDIT_OLD_DDL9_REASONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL9_REASONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCN_IDA(ByVal ida As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL9_REASONs Where p.FK_LCN_IDA = ida And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(ByVal ida As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL9_REASONs Where p.FK_LCN_IDA = ida And p.ddl1 = ddl1 And p.ddl2 = ddl2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_OLD_LCN_APPROVE_EDIT_DDL10_REASON
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT_OLD_DDL10_REASON


        Public Sub insert()
            db.LCN_APPROVE_EDIT_OLD_DDL10_REASONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_APPROVE_EDIT_OLD_DDL10_REASONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL10_REASONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCN_IDA(ByVal ida As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL10_REASONs Where p.FK_LCN_IDA = ida And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(ByVal ida As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL10_REASONs Where p.FK_LCN_IDA = ida And p.ddl1 = ddl1 And p.ddl2 = ddl2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_DATA_BY_FK_LCN_IDA_IDAROW_DDL1_DDL2_ACTIVE(ByVal ida As Integer, ByVal row As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL10_REASONs Where p.FK_LCN_IDA = ida And p.FK_IDA_CHK_ROW = row And p.ddl1 = ddl1 And p.ddl2 = ddl2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub



    End Class
    Public Class TB_OLD_LCN_APPROVE_EDIT_DDL11_REASON
        Inherits MAINCONTEXT

        Public fields As New LCN_APPROVE_EDIT_OLD_DDL11_REASON


        Public Sub insert()
            db.LCN_APPROVE_EDIT_OLD_DDL11_REASONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.LCN_APPROVE_EDIT_OLD_DDL11_REASONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL11_REASONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCN_IDA(ByVal ida As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL11_REASONs Where p.FK_LCN_IDA = ida And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(ByVal ida As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL11_REASONs Where p.FK_LCN_IDA = ida And p.ddl1 = ddl1 And p.ddl2 = ddl2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_DATA_BY_FK_LCN_IDA_IDAROW_DDL1_DDL2_ACTIVE(ByVal ida As Integer, ByVal row As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal active As Boolean)

            datas = (From p In db.LCN_APPROVE_EDIT_OLD_DDL11_REASONs Where p.FK_LCN_IDA = ida And p.FK_IDA_CHK_ROW = row And p.ddl1 = ddl1 And p.ddl2 = ddl2 And p.ACTIVE = active Select p)
            For Each Me.fields In datas
            Next
        End Sub


    End Class
    Public Class TB_MAS_PRICE_DISCOUNT_DALCN_HERB
        Inherits MAINCONTEXT

        Public fields As New MAS_PRICE_DISCOUNT_DALCN_HERB

        Public Sub insert()
            db.MAS_PRICE_DISCOUNT_DALCN_HERBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.MAS_PRICE_DISCOUNT_DALCN_HERBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.MAS_PRICE_DISCOUNT_DALCN_HERBs Select p)

        End Sub
        Public Sub GetdatabyID_ID(ByVal ID As Integer)
            datas = From p In db.MAS_PRICE_DISCOUNT_DALCN_HERBs Where p.ID = ID Select p
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.MAS_PRICE_DISCOUNT_DALCN_HERBs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next
        End Sub
    End Class

    'Public Class TB_DALCN_CONSIDER_TRANSLATION
    '    Inherits MAINCONTEXT

    '    Public fields As New DALCN_CONSIDER_TRANSLATION


    '    Public Sub insert()
    '        db.DALCN_CONSIDER_TRANSLATIONs.InsertOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub
    '    Public Sub update()
    '        db.SubmitChanges()
    '    End Sub

    '    Public Sub delete()
    '        db.DALCN_CONSIDER_TRANSLATIONs.DeleteOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub

    '    Public Sub GetDataAll()

    '        datas = (From p In db.DALCN_CONSIDER_TRANSLATIONs Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    Public Sub GET_DATA_BY_IDA(ByVal ida As Integer)

    '        datas = (From p In db.DALCN_CONSIDER_TRANSLATIONs Where p.IDA = ida Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    Public Sub GET_DATA_BY_FK_LCN(ByVal ida As Integer, ByVal active As Boolean)

    '        datas = (From p In db.DALCN_CONSIDER_TRANSLATIONs Where p.FK_LCN = ida And p.ACTIVEFACT = active Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub

    'End Class
    'Public Class TB_DALCN_RENEW
    '    Inherits MAINCONTEXT

    '    Public fields As New DALCN_RENEW


    '    Public Sub insert()
    '        db.DALCN_RENEWs.InsertOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub
    '    Public Sub update()
    '        db.SubmitChanges()
    '    End Sub

    '    Public Sub delete()
    '        db.DALCN_RENEWs.DeleteOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub

    '    Public Sub GetDataAll()

    '        datas = (From p In db.DALCN_RENEWs Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    Public Sub GET_DATA_BY_IDA(ByVal ida As Integer)

    '        datas = (From p In db.DALCN_RENEWs Where p.IDA = ida Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    Public Sub GET_DATA_BY_FK_LCN(ByVal ida As Integer, ByVal active As Boolean)

    '        datas = (From p In db.DALCN_RENEWs Where p.FK_LCN = ida And p.ACTIVEFACT = active Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub

    'End Class
    'Public Class TB_LOG_RENEW_HERB
    '    Inherits MAINCONTEXT

    '    Public fields As New LOG_RENEW_HERB


    '    Public Sub insert()
    '        db.LOG_RENEW_HERBs.InsertOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub
    '    Public Sub update()
    '        db.SubmitChanges()
    '    End Sub

    '    Public Sub delete()
    '        db.LOG_RENEW_HERBs.DeleteOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub

    '    Public Sub GetDataAll()

    '        datas = (From p In db.LOG_RENEW_HERBs Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    Public Sub GET_DATA_BY_IDA(ByVal ida As Integer)

    '        datas = (From p In db.LOG_RENEW_HERBs Where p.IDA = ida Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub

    'End Class
    'Public Class TB_DALCN_TRANSFER
    '    Inherits MAINCONTEXT

    '    Public fields As New DALCN_TRANSFER


    '    Public Sub insert()
    '        db.DALCN_TRANSFERs.InsertOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub
    '    Public Sub update()
    '        db.SubmitChanges()
    '    End Sub

    '    Public Sub delete()
    '        db.DALCN_TRANSFERs.DeleteOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub

    '    Public Sub GetDataAll()

    '        datas = (From p In db.DALCN_TRANSFERs Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    Public Sub GET_DATA_BY_IDA(ByVal ida As Integer)

    '        datas = (From p In db.DALCN_TRANSFERs Where p.IDA = ida Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    Public Sub GET_DATA_BY_FK_LCN(ByVal ida As Integer, ByVal active As Boolean)

    '        datas = (From p In db.DALCN_TRANSFERs Where p.FK_LCN = ida And p.ACTIVEFACT = active Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub

    'End Class
    'Public Class TB_DALCN_AUDIT_IN
    '    Inherits MAINCONTEXT

    '    Public fields As New DALCN_AUDIT_IN


    '    Public Sub insert()
    '        db.DALCN_AUDIT_INs.InsertOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub
    '    Public Sub update()
    '        db.SubmitChanges()
    '    End Sub

    '    Public Sub delete()
    '        db.DALCN_AUDIT_INs.DeleteOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub

    '    Public Sub GetDataAll()

    '        datas = (From p In db.DALCN_AUDIT_INs Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    Public Sub GET_DATA_BY_IDA(ByVal ida As Integer)

    '        datas = (From p In db.DALCN_AUDIT_INs Where p.IDA = ida Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    Public Sub GET_DATA_BY_FK_LCN(ByVal ida As Integer, ByVal active As Boolean)

    '        datas = (From p In db.DALCN_AUDIT_INs Where p.FK_LCN = ida And p.ACTIVEFACT = active Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub

    'End Class
    'Public Class TB_DALCN_AUDIT_OUT
    '        Inherits MAINCONTEXT

    '        Public fields As New DALCN_AUDIT_OUT


    '        Public Sub insert()
    '            db.DALCN_AUDIT_OUTs.InsertOnSubmit(fields)
    '            db.SubmitChanges()
    '        End Sub
    '        Public Sub update()
    '            db.SubmitChanges()
    '        End Sub

    '        Public Sub delete()
    '            db.DALCN_AUDIT_OUTs.DeleteOnSubmit(fields)
    '            db.SubmitChanges()
    '        End Sub

    '        Public Sub GetDataAll()

    '            datas = (From p In db.DALCN_AUDIT_OUTs Select p)
    '            For Each Me.fields In datas
    '            Next
    '        End Sub
    '        Public Sub GET_DATA_BY_IDA(ByVal ida As Integer)

    '            datas = (From p In db.DALCN_AUDIT_OUTs Where p.IDA = ida Select p)
    '            For Each Me.fields In datas
    '            Next
    '        End Sub
    '        Public Sub GET_DATA_BY_FK_LCN(ByVal ida As Integer, ByVal active As Boolean)

    '            datas = (From p In db.DALCN_AUDIT_OUTs Where p.FK_LCN = ida And p.ACTIVEFACT = active Select p)
    '            For Each Me.fields In datas
    '            Next
    '        End Sub

    '    End Class

    'Public Class TB_MAS_LCN_AUDIT_DETAIL_GROUP_DRUG
    '    Inherits MAINCONTEXT

    '    Public fields As New MAS_LCN_AUDIT_DETAIL_GROUP_DRUG


    '    Public Sub insert()
    '        db.MAS_LCN_AUDIT_DETAIL_GROUP_DRUGs.InsertOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub
    '    Public Sub update()
    '        db.SubmitChanges()
    '    End Sub

    '    Public Sub delete()
    '        db.MAS_LCN_AUDIT_DETAIL_GROUP_DRUGs.DeleteOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub
    '    Public Sub GetDataAll_DES()

    '        datas = (From p In db.MAS_LCN_AUDIT_DETAIL_GROUP_DRUGs Where p.ACTIVE = 1 Select p Order By p.SEQ Ascending)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    Public Sub GET_DATA_BY_IDA(ByVal ida As Integer)

    '        datas = (From p In db.MAS_LCN_AUDIT_DETAIL_GROUP_DRUGs Where p.IDA = ida Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub

    '    Public Sub GetDataAll()

    '        datas = (From p In db.MAS_LCN_AUDIT_DETAIL_GROUP_DRUGs Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    'Public Sub GET_DATA_BY_FK_LCN(ByVal ida As Integer, ByVal active As Boolean)

    '    '    datas = (From p In db.DALCN_AUDIT_OUTs Where p.FK_LCN = ida And p.ACTIVEFACT = active Select p)
    '    '    For Each Me.fields In datas
    '    '    Next
    '    'End Sub

    'End Class
    'Public Class TB_MAS_LCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUG
    '    Inherits MAINCONTEXT

    '    Public fields As New MAS_LCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUG


    '    Public Sub insert()
    '        db.MAS_LCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUGs.InsertOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub
    '    Public Sub update()
    '        db.SubmitChanges()
    '    End Sub

    '    Public Sub delete()
    '        db.MAS_LCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUGs.DeleteOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub
    '    Public Sub GetDataAll_ASC()

    '        datas = (From p In db.MAS_LCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUGs Where p.ACTIVE = 1 Select p Order By p.SEQ Ascending)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    Public Sub GET_DATA_BY_IDA(ByVal ida As Integer)

    '        datas = (From p In db.MAS_LCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUGs Where p.IDA = ida Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    Public Sub GET_DATA_BY_HEAD_ID(ByVal HEAD_ID As Integer)

    '        datas = (From p In db.MAS_LCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUGs Where p.HEAD_ID = HEAD_ID Select p Order By p.SEQ Ascending)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub

    '    Public Sub GetDataAll()

    '        datas = (From p In db.MAS_LCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUGs Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    'Public Sub GET_DATA_BY_FK_LCN(ByVal ida As Integer, ByVal active As Boolean)

    '    '    datas = (From p In db.DALCN_AUDIT_OUTs Where p.FK_LCN = ida And p.ACTIVEFACT = active Select p)
    '    '    For Each Me.fields In datas
    '    '    Next
    '    'End Sub

    'End Class
    'Public Class TB_DALCN_AUDIT_DETAIL_GROUP_DRUG
    '    Inherits MAINCONTEXT

    '    Public fields As New DALCN_AUDIT_DETAIL_GROUP_DRUG


    '    Public Sub insert()
    '        db.DALCN_AUDIT_DETAIL_GROUP_DRUGs.InsertOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub
    '    Public Sub update()
    '        db.SubmitChanges()
    '    End Sub

    '    Public Sub delete()
    '        db.DALCN_AUDIT_DETAIL_GROUP_DRUGs.DeleteOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub

    '    Public Sub GetDataAll()

    '        datas = (From p In db.DALCN_AUDIT_DETAIL_GROUP_DRUGs Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    Public Sub GET_DATA_BY_IDA(ByVal ida As Integer)

    '        datas = (From p In db.DALCN_AUDIT_DETAIL_GROUP_DRUGs Where p.IDA = ida Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    Public Sub GET_DATA_BY_FK_LCN(ByVal LCN_IDA As Integer)

    '        datas = (From p In db.DALCN_AUDIT_DETAIL_GROUP_DRUGs Where p.LCN_IDA = LCN_IDA Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    Public Sub GET_DATA_BY_FK_IDA(ByVal FK_IDA As Integer)

    '        datas = (From p In db.DALCN_AUDIT_DETAIL_GROUP_DRUGs Where p.FK_IDA = FK_IDA Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    Public Sub GET_DATA_BY_FK_IDA_AND_PROCESS(ByVal FK_IDA As Integer, ByVal Process_ID As String)

    '        datas = (From p In db.DALCN_AUDIT_DETAIL_GROUP_DRUGs Where p.FK_IDA = FK_IDA And p.PROCESS_ID = Process_ID Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub

    'End Class

    'Public Class TB_DALCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUG
    '    Inherits MAINCONTEXT

    '    Public fields As New DALCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUG


    '    Public Sub insert()
    '        db.DALCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUGs.InsertOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub
    '    Public Sub update()
    '        db.SubmitChanges()
    '    End Sub

    '    Public Sub delete()
    '        db.DALCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUGs.DeleteOnSubmit(fields)
    '        db.SubmitChanges()
    '    End Sub

    '    Public Sub GetDataAll()

    '        datas = (From p In db.DALCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUGs Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    Public Sub GET_DATA_BY_IDA(ByVal ida As Integer)

    '        datas = (From p In db.DALCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUGs Where p.IDA = ida Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    Public Sub GET_DATA_BY_FK_LCN(ByVal LCN_IDA As Integer)

    '        datas = (From p In db.DALCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUGs Where p.LCN_IDA = LCN_IDA Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub

    '    Public Sub GET_DATA_BY_FK_IDA_AND_HEAD_ID(ByVal FK_IDA As Integer, ByVal HEAD_ID As Integer)

    '        datas = (From p In db.DALCN_CONSIDER_TRANSLATION_DETAIL_GROUP_DRUGs Where p.FK_IDA = FK_IDA And p.HEAD_ID = HEAD_ID Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    'End Class

End Namespace
