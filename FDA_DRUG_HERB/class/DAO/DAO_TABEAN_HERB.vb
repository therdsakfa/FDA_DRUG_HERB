Namespace DAO_TABEAN_HERB
    Public MustInherit Class MAINCONTEXT        'ประกาศเพื่อใช้เป็น Class แม่
        Public db As New LINQ_TABEAN_HERB_JJDataContext 'ประกาศเพื่อใช้เป็น Class LINQ DataTable
        Public datas                            'ประกาศเ

    End Class

    Public Class TB_TABEAN_JJ
        Inherits MAINCONTEXT

        Public fields As New TABEAN_JJ

        Public Sub insert()
            db.TABEAN_JJs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_JJs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_JJs Select p)

        End Sub
        Public Sub GetdatabyID_TR_ID(ByVal TR_ID As Integer)
            datas = From p In db.TABEAN_JJs Where p.TR_ID_JJ = TR_ID Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_DD_HERB_NAME_ID(ByVal DD_HERB_NAME_ID As Integer)
            datas = From p In db.TABEAN_JJs Where p.DD_HERB_NAME_ID = DD_HERB_NAME_ID Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_JJs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_IDA_DD_HERB_NAME_ID(ByVal IDA As Integer, ByVal DD_HERB_NAME As Integer)
            datas = From p In db.TABEAN_JJs Where p.IDA = IDA And p.DD_HERB_NAME_ID = DD_HERB_NAME Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_IDA_LCN_ID_AND_TR_ID(ByVal IDA As Integer, ByVal TR_ID As Integer, ByVal LCN_ID As Integer)
            datas = From p In db.TABEAN_JJs Where p.IDA = IDA And p.TR_ID_JJ = TR_ID And p.IDA_LCN = LCN_ID Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_IDA_LCN(ByVal IDA_LCN As Integer, ByVal DD_HERB_NAME As Integer)
            datas = From p In db.TABEAN_JJs Where p.LCN_ID = IDA_LCN And p.DD_HERB_NAME_ID = DD_HERB_NAME Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_IDA_PROCESS(ByVal IDA As Integer, ByVal DDHERB As Integer)
            datas = From p In db.TABEAN_JJs Where p.IDA = IDA And p.DDHERB = DDHERB Select p

            For Each Me.fields In datas

            Next
        End Sub

    End Class
    Public Class TB_MAS_PRODUCT_NAME_JJ_HERB_FOR_HEALTH
        Inherits MAINCONTEXT

        Public fields As New MAS_PRODUCT_NAME_JJ_HERB_FOR_HEALTH

        Public Sub insert()
            db.MAS_PRODUCT_NAME_JJ_HERB_FOR_HEALTHs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.MAS_PRODUCT_NAME_JJ_HERB_FOR_HEALTHs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.MAS_PRODUCT_NAME_JJ_HERB_FOR_HEALTHs Select p)

        End Sub

        Public Sub Getdataby_IDA(ByVal IDA As Integer)
            datas = From p In db.MAS_PRODUCT_NAME_JJ_HERB_FOR_HEALTHs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdataby_ID(ByVal ID As Integer)
            datas = From p In db.MAS_PRODUCT_NAME_JJ_HERB_FOR_HEALTHs Where p.ID = ID Select p

            For Each Me.fields In datas

            Next
        End Sub

    End Class
    Public Class TB_TABEAN_SUBPACKAGE
        Inherits MAINCONTEXT

        Public fields As New TABEAN_JJ_SUB_PACKSIZE

        Private _Details As New List(Of TABEAN_JJ_SUB_PACKSIZE)
        Public Property Details() As List(Of TABEAN_JJ_SUB_PACKSIZE)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of TABEAN_JJ_SUB_PACKSIZE))
                _Details = value
            End Set
        End Property

        Public Sub AddDetails()
            Details.Add(fields)
            fields = New TABEAN_JJ_SUB_PACKSIZE
        End Sub

        Public Sub insert()
            db.TABEAN_JJ_SUB_PACKSIZEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_JJ_SUB_PACKSIZEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_JJ_SUB_PACKSIZEs Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub

        Public Sub GetData_ByIDA(ByVal IDA As Integer)
            datas = (From p In db.TABEAN_JJ_SUB_PACKSIZEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetData_ByDD_HERB_NAME_ID(ByVal DD_HERB_NAME_ID As Integer)
            datas = (From p In db.TABEAN_JJ_SUB_PACKSIZEs Where p.IDA = DD_HERB_NAME_ID Select p)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetData_ByFkIDA(ByVal fk_ida As Integer)
            datas = (From p In db.TABEAN_JJ_SUB_PACKSIZEs Where p.FK_IDA = fk_ida Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
    End Class

    Public Class TB_TABEAN_HERB_UPLOAD_FILE_JJ
        Inherits MAINCONTEXT

        Public fields As New TABEAN_HERB_UPLOAD_FILE_JJ

        Private _Details As New List(Of TABEAN_HERB_UPLOAD_FILE_JJ)
        Public Property Details() As List(Of TABEAN_HERB_UPLOAD_FILE_JJ)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of TABEAN_HERB_UPLOAD_FILE_JJ))
                _Details = value
            End Set
        End Property
        Public Sub AddDetails()
            Details.Add(fields)
            fields = New TABEAN_HERB_UPLOAD_FILE_JJ
        End Sub
        Public Sub insert()
            db.TABEAN_HERB_UPLOAD_FILE_JJs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_HERB_UPLOAD_FILE_JJs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_HERB_UPLOAD_FILE_JJs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_HERB_UPLOAD_FILE_JJs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_TR_ID(ByVal TR_ID As String)
            datas = From p In db.TABEAN_HERB_UPLOAD_FILE_JJs Where p.TR_ID = TR_ID Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_TR_ID_PROCESS_ID(ByVal TR_ID As Integer, ByVal PROCESS_ID As String)
            datas = From p In db.TABEAN_HERB_UPLOAD_FILE_JJs Where p.TR_ID = TR_ID And p.PROCESS_ID = PROCESS_ID Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_TR_ID_FK_IDA_PROCESS_ID(ByVal TR_ID As Integer, ByVal FK_IDA As Integer, ByVal PROCESS_ID As String)
            datas = From p In db.TABEAN_HERB_UPLOAD_FILE_JJs Where p.TR_ID = TR_ID And p.FK_IDA = FK_IDA And p.PROCESS_ID = PROCESS_ID Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_TR_ID_FK_IDA_PROCESS_ORDER_ID(ByVal TR_ID As Integer, ByVal FK_IDA As Integer, ByVal PROCESS_ID As String)
            datas = From p In db.TABEAN_HERB_UPLOAD_FILE_JJs Where p.TR_ID = TR_ID And p.FK_IDA = FK_IDA And p.PROCESS_ID = PROCESS_ID Select p Order By p.IDA Ascending

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_TR_ID_PROCESS_TYPE(ByVal TR_ID As Integer, ByVal PROCESS_ID As String, ByVal TYPE_ID As Integer)
            datas = From p In db.TABEAN_HERB_UPLOAD_FILE_JJs Where p.TR_ID = TR_ID And p.PROCESS_ID = PROCESS_ID And p.TYPE = TYPE_ID Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_TR_ID_PROCESS_TYPE_FK_IDA(ByVal TR_ID As Integer, ByVal PROCESS_ID As String, ByVal TYPE_ID As Integer, ByVal IDA As Integer)
            datas = From p In db.TABEAN_HERB_UPLOAD_FILE_JJs Where p.TR_ID = TR_ID And p.PROCESS_ID = PROCESS_ID And p.TYPE = TYPE_ID _
             And p.FK_IDA = IDA Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_TR_ID_FK_IDA_PROCESS_ID_AND_TYPE(ByVal FK_IDA As Integer, ByVal TR_ID As Integer, ByVal PROCESS_ID As String, ByVal TYPE_ID As Integer)
            datas = From p In db.TABEAN_HERB_UPLOAD_FILE_JJs Where p.TR_ID = TR_ID And p.FK_IDA = FK_IDA And p.PROCESS_ID = PROCESS_ID And p.TYPE = TYPE_ID Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_TR_ID_FK_IDA_PROCESS_ID_AND_TYPE_AC(ByVal FK_IDA As Integer, ByVal TR_ID As Integer, ByVal PROCESS_ID As String, ByVal TYPE_ID As Integer)
            datas = From p In db.TABEAN_HERB_UPLOAD_FILE_JJs Where p.TR_ID = TR_ID And p.FK_IDA = FK_IDA And p.PROCESS_ID = PROCESS_ID And p.TYPE = TYPE_ID And p.ACTIVE = True Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_TR_ID_FK_IDA_PROCESS_ID_AND_TYPE_DC2(ByVal FK_IDA As Integer, ByVal TR_ID As Integer, ByVal PROCESS_ID As String, ByVal TYPE_ID As Integer, ByVal DC As String)
            datas = From p In db.TABEAN_HERB_UPLOAD_FILE_JJs Where p.TR_ID = TR_ID And p.FK_IDA = FK_IDA And p.PROCESS_ID = PROCESS_ID And p.TYPE = TYPE_ID And p.DUCUMENT_NAME = DC Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdataby_DUCUMENT_NAME(ByVal DUCUMENT_NAME As String)
            datas = From p In db.MAS_TABEAN_HERB_EDIT_FILEUPLOADs Where p.DUCUMENT_NAME = DUCUMENT_NAME And p.ACTIVEFACT = True Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdataby_DUCUMENT_NAME_AND_FK_IDA_AND_PROCESS(ByVal DUCUMENT_NAME As String, ByVal IDA As Integer, ByVal PROCESS_ID As String)
            datas = From p In db.TABEAN_HERB_UPLOAD_FILE_JJs Where p.DUCUMENT_NAME = DUCUMENT_NAME And p.FK_IDA = IDA And p.PROCESS_ID = PROCESS_ID Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_IDA_TYPE(ByVal FK_IDA As Integer, ByVal TYPE As Integer)
            datas = From p In db.TABEAN_HERB_UPLOAD_FILE_JJs Where p.FK_IDA = FK_IDA And p.TYPE = TYPE Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_TR_ID_PROCESS_ID_ALL(ByVal TR_ID As Integer, ByVal PROCESS_ID As String, ByVal type_id As Integer)
            datas = From p In db.TABEAN_HERB_UPLOAD_FILE_JJs Where p.TR_ID = TR_ID And p.PROCESS_ID = PROCESS_ID And p.TYPE = type_id Select p
        End Sub

    End Class

    Public Class TB_MAS_TABEAN_HERB_RECIPE_PRODUCT_JJ
        Inherits MAINCONTEXT

        Public fields As New MAS_TABEAN_HERB_RECIPE_PRODUCT_JJ

        Public Sub insert()
            db.MAS_TABEAN_HERB_RECIPE_PRODUCT_JJs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.MAS_TABEAN_HERB_RECIPE_PRODUCT_JJs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.MAS_TABEAN_HERB_RECIPE_PRODUCT_JJs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.MAS_TABEAN_HERB_RECIPE_PRODUCT_JJs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_DD_HERB_NAME_PRODUCT_ID(ByVal DD_HERB_NAME_PRODUCT_ID As Integer)
            datas = From p In db.MAS_TABEAN_HERB_RECIPE_PRODUCT_JJs Where p.DD_HERB_NAME_PRODUCT_ID = DD_HERB_NAME_PRODUCT_ID Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_DD_HERB_NAME_PRODUCT_ID_AND_PROCESS(ByVal DD_HERB_NAME_PRODUCT_ID As Integer, ByVal PROCESS_ID As Integer)
            datas = From p In db.MAS_TABEAN_HERB_RECIPE_PRODUCT_JJs Where p.DD_HERB_NAME_PRODUCT_ID = DD_HERB_NAME_PRODUCT_ID And p.PROCESS_ID = PROCESS_ID Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_DD_HERB_NAME_PRODUCT_ID_AND_PROCESS_AND_TYPE(ByVal DD_HERB_NAME_PRODUCT_ID As Integer, ByVal PROCESS_ID As Integer, ByVal TYPE As Integer)
            datas = From p In db.MAS_TABEAN_HERB_RECIPE_PRODUCT_JJs Where p.DD_HERB_NAME_PRODUCT_ID = DD_HERB_NAME_PRODUCT_ID And p.PROCESS_ID = PROCESS_ID And p.TYPE = TYPE Select p

            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_MAS_NAME_HEAD_TABEAN_JR
        Inherits MAINCONTEXT
        Public fields As New MAS_NAME_HEAD_TABEAN_JR

        Public Sub insert()
            db.MAS_NAME_HEAD_TABEAN_JRs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.MAS_NAME_HEAD_TABEAN_JRs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.MAS_NAME_HEAD_TABEAN_JRs Where p.ACTIVE = True Order By CInt(p.SEQ_ID) Descending Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal ID As Integer)
            datas = From p In db.MAS_NAME_HEAD_TABEAN_JRs Where p.ID = ID And p.ACTIVE = True Select p
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_MAS_PRICE_DISCOUNT_TABEAN_HERB
        Inherits MAINCONTEXT

        Public fields As New MAS_PRICE_DISCOUNT_TABEAN_HERB

        Public Sub insert()
            db.MAS_PRICE_DISCOUNT_TABEAN_HERBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.MAS_PRICE_DISCOUNT_TABEAN_HERBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.MAS_PRICE_DISCOUNT_TABEAN_HERBs Select p)

        End Sub
        Public Sub GetdatabyID_ID(ByVal ID As Integer)
            datas = From p In db.MAS_PRICE_DISCOUNT_TABEAN_HERBs Where p.ID = ID Select p
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.MAS_PRICE_DISCOUNT_TABEAN_HERBs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_MAS_PRICE_ESTIMATE_REQUEST_HERB
        Inherits MAINCONTEXT

        Public fields As New MAS_PRICE_ESTIMATE_REQUEST_HERB

        Public Sub insert()
            db.MAS_PRICE_ESTIMATE_REQUEST_HERBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.MAS_PRICE_ESTIMATE_REQUEST_HERBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.MAS_PRICE_ESTIMATE_REQUEST_HERBs Select p)

        End Sub
        Public Sub Getdataby_Process_ID(ByVal Process_ID As Integer)
            datas = From p In db.MAS_PRICE_ESTIMATE_REQUEST_HERBs Where p.Process_ID = Process_ID Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdataby_Process_ID_AND_ID(ByVal Process_ID As Integer, ByVal ID As Integer)
            datas = From p In db.MAS_PRICE_ESTIMATE_REQUEST_HERBs Where p.Process_ID = Process_ID And p.ID = ID Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.MAS_PRICE_ESTIMATE_REQUEST_HERBs Where p.ID = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_MAS_PRICE_REQUEST_HERB
        Inherits MAINCONTEXT

        Public fields As New MAS_PRICE_REQUEST_HERB

        Public Sub insert()
            db.MAS_PRICE_REQUEST_HERBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.MAS_PRICE_REQUEST_HERBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.MAS_PRICE_REQUEST_HERBs Select p)

        End Sub
        Public Sub Getdataby_Process_ID(ByVal Process_ID As Integer)
            datas = From p In db.MAS_PRICE_REQUEST_HERBs Where p.Process_ID = Process_ID Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.MAS_PRICE_REQUEST_HERBs Where p.ID = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_MAS_TYPE_REQUESTS_HERB
        Inherits MAINCONTEXT

        Public fields As New MAS_TYPE_REQUESTS_HERB

        Public Sub insert()
            db.MAS_TYPE_REQUESTS_HERBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.MAS_TYPE_REQUESTS_HERBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.MAS_TYPE_REQUESTS_HERBs Select p)

        End Sub
        Public Sub Getdataby_Process_ID(ByVal Process_ID As Integer)
            datas = From p In db.MAS_TYPE_REQUESTS_HERBs Where p.ProcessID = Process_ID Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.MAS_TYPE_REQUESTS_HERBs Where p.ID = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub
    End Class

    Public Class TB_TABEAN_HERB_EDIT_REQUEST_CHK_LIST
        Inherits MAINCONTEXT

        Public fields As New TABEAN_HERB_EDIT_REQUEST_CHK_LIST

        Public Sub insert()
            db.TABEAN_HERB_EDIT_REQUEST_CHK_LISTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_HERB_EDIT_REQUEST_CHK_LISTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_CHK_LISTs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_HERB_EDIT_REQUEST_CHK_LISTs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_HERB_EDIT_REQUEST_CHK_LISTs Where p.FK_IDA = FK_IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

    End Class
    Public Class TB_TABEAN_INFORM_DETAIL
        Inherits MAINCONTEXT

        Public fields As New TABEAN_JR_DETAIL
        Public Sub insert()
            db.TABEAN_JR_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_JR_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_JR_DETAILs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_JR_DETAILs Where p.IDA = IDA And p.ACTIVEFACT = 1 Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_FK_IDA(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_JR_DETAILs Where p.FK_IDA = FK_IDA Select p
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_TABEAN_INFROM_DETIAL_CAS
        Inherits MAINCONTEXT

        Public fields As New TABEAN_JR_DETIAL_CA
        Private _Details As New List(Of TABEAN_JR_DETIAL_CA)
        Public Property Details() As List(Of TABEAN_JR_DETIAL_CA)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of TABEAN_JR_DETIAL_CA))
                _Details = value
            End Set
        End Property
        Private Sub AddDetails()
            Details.Add(fields)
            fields = New TABEAN_JR_DETIAL_CA
        End Sub
        Public Sub insert()
            db.TABEAN_JR_DETIAL_CAs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_JR_DETIAL_CAs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_JR_DETIAL_CAs Select p)

        End Sub

        Public Sub Getdataby_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_JR_DETIAL_CAs Where p.IDA = IDA And p.ACTIVE = 1 Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdataby_FK_IDA(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_JR_DETIAL_CAs Where p.FK_IDA = FK_IDA And p.ACTIVE = 1 Select p
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub

    End Class
    Public Class TB_TABEAN_HERB_EDIT_REQUEST_DETAIL
        Inherits MAINCONTEXT

        Public fields As New TABEAN_HERB_EDIT_REQUEST_DETAIL

        Public Sub insert()
            db.TABEAN_HERB_EDIT_REQUEST_DETAILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_HERB_EDIT_REQUEST_DETAILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_DETAILs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_HERB_EDIT_REQUEST_DETAILs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_HERB_EDIT_REQUEST_DETAILs Where p.FK_IDA = FK_IDA Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_TR_ID(ByVal TR_ID As Integer)
            datas = From p In db.TABEAN_HERB_EDIT_REQUEST_DETAILs Where p.TR_ID = TR_ID Select p
            For Each Me.fields In datas

            Next
        End Sub
    End Class

    Public Class TB_TABEAN_HERB_EDIT_REQUEST_DETAIL_OLD
        Inherits MAINCONTEXT

        Public fields As New TABEAN_HERB_EDIT_REQUEST_DETAIL_OLD

        Public Sub insert()
            db.TABEAN_HERB_EDIT_REQUEST_DETAIL_OLDs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_HERB_EDIT_REQUEST_DETAIL_OLDs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_DETAIL_OLDs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_HERB_EDIT_REQUEST_DETAIL_OLDs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDAQ(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_HERB_EDIT_REQUEST_DETAIL_OLDs Where p.FK_IDA_DQ = FK_IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

    End Class

    Public Class TB_MAS_TABEAN_HERB_PRODUCT_AGE_JJ
        Inherits MAINCONTEXT

        Public fields As New MAS_TABEAN_HERB_PRODUCT_AGE_JJ

        Public Sub insert()
            db.MAS_TABEAN_HERB_PRODUCT_AGE_JJs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.MAS_TABEAN_HERB_PRODUCT_AGE_JJs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.MAS_TABEAN_HERB_PRODUCT_AGE_JJs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.MAS_TABEAN_HERB_PRODUCT_AGE_JJs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_PRO_AGE(ByVal ID As Integer)
            datas = From p In db.MAS_TABEAN_HERB_PRODUCT_AGE_JJs Where p.PRO_AGE_ID = ID Select p

            For Each Me.fields In datas

            Next
        End Sub

    End Class
    Public Class TB_MAS_TABEAN_HERB_NAME_JJ
        Inherits MAINCONTEXT

        Public fields As New MAS_TABEAN_HERB_NAME_JJ

        Public Sub insert()
            db.MAS_TABEAN_HERB_NAME_JJs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.MAS_TABEAN_HERB_NAME_JJs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.MAS_TABEAN_HERB_NAME_JJs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.MAS_TABEAN_HERB_NAME_JJs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_HEAD_AND_PROCESS(ByVal HEAD_ID As Integer, ByVal PROCESS_ID As Integer)
            datas = From p In db.MAS_TABEAN_HERB_NAME_JJs Where p.HERB_ID = HEAD_ID And p.PROCESS_ID = PROCESS_ID Select p
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub Getdataby_seq(ByVal P_ID As Integer)
            datas = (From p In db.MAS_TABEAN_HERB_NAME_JJs Where p.PROCESS_ID = P_ID Order By CInt(p.SEQ) Descending Select p).Take(1)

            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_MAS_TABEAN_HERB_SYNDROME_DETAIL_JJ
        Inherits MAINCONTEXT

        Public fields As New MAS_TABEAN_HERB_SYNDROME_DETAIL_JJ

        Public Sub insert()
            db.MAS_TABEAN_HERB_SYNDROME_DETAIL_JJs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.MAS_TABEAN_HERB_SYNDROME_DETAIL_JJs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.MAS_TABEAN_HERB_SYNDROME_DETAIL_JJs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.MAS_TABEAN_HERB_SYNDROME_DETAIL_JJs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_PROCESS(ByVal Process_ID As Integer)
            datas = From p In db.MAS_TABEAN_HERB_SYNDROME_DETAIL_JJs Where p.PROCESS_ID = Process_ID Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_DD_HERB_NAME_ID(ByVal DD_HERB_NAME_ID As Integer, ByVal P_ID As Integer)
            datas = From p In db.MAS_TABEAN_HERB_SYNDROME_DETAIL_JJs Where p.DD_HERB_NAME_ID = DD_HERB_NAME_ID And p.PROCESS_ID = P_ID Select p

            For Each Me.fields In datas

            Next
        End Sub

    End Class
    Public Class TB_MAS_TABEAN_HERB_NAME_DETAIL_JJ
        Inherits MAINCONTEXT

        Public fields As New MAS_TABEAN_HERB_NAME_DETAIL_JJ

        Public Sub insert()
            db.MAS_TABEAN_HERB_NAME_DETAIL_JJs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.MAS_TABEAN_HERB_NAME_DETAIL_JJs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.MAS_TABEAN_HERB_NAME_DETAIL_JJs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.MAS_TABEAN_HERB_NAME_DETAIL_JJs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_DD_HERB_NAME_ID(ByVal DD_HERB_NAME_ID As Integer, ByVal P_ID As Integer)
            datas = From p In db.MAS_TABEAN_HERB_NAME_DETAIL_JJs Where p.DD_HERB_NAME_ID = DD_HERB_NAME_ID And p.PROCESS_ID = P_ID Select p

            For Each Me.fields In datas

            Next
        End Sub

    End Class
    Public Class TB_DRSAMP_PACKAGE_SIZE
        Inherits MAINCONTEXT

        Public fields As New DRSAMP_PACKAGE_SIZE

        Public Sub insert()
            db.DRSAMP_PACKAGE_SIZEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.DRSAMP_PACKAGE_SIZEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_HERB_EX_SIZE_PACKs Select p)
        End Sub

        Public Sub Getdataby_IDA(ByVal IDA As Integer)
            datas = From p In db.DRSAMP_PACKAGE_SIZEs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_FK_IDA_PZ(ByVal FK_IDA As Integer)
            datas = From p In db.DRSAMP_PACKAGE_SIZEs Where p.FK_IDA_PZ = FK_IDA Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_FK_IDA_EX(ByVal FK_IDA As Integer)
            datas = From p In db.DRSAMP_PACKAGE_SIZEs Where p.FK_IDA_EX = FK_IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA_EX2(ByVal FK_IDA As Integer)
            datas = From p In db.DRSAMP_PACKAGE_SIZEs Where p.FK_IDA_EX = FK_IDA And p.ACTIVEFACT = 1 Select p

        End Sub
    End Class
    Public Class TB_TABEAN_HERB_EX_SIZE_PACK
        Inherits MAINCONTEXT

        Public fields As New TABEAN_HERB_EX_SIZE_PACK

        Public Sub insert()
            db.TABEAN_HERB_EX_SIZE_PACKs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_HERB_EX_SIZE_PACKs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_HERB_EX_SIZE_PACKs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_HERB_EX_SIZE_PACKs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA_EX(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_HERB_EX_SIZE_PACKs Where p.FK_IDA_EX = FK_IDA Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_FK_IDA_EX_AND_UNIT(ByVal FK_IDA As Integer, ByVal ID_UNIT As Integer)
            datas = From p In db.TABEAN_HERB_EX_SIZE_PACKs Where p.FK_IDA_EX = FK_IDA And p.UNIT_F_ID = ID_UNIT Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA_EX2(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_HERB_EX_SIZE_PACKs Where p.FK_IDA_EX = FK_IDA And p.ACTIVEFACT = 1 Select p

        End Sub
    End Class
    Public Class TB_TABEAN_HERB_EDIT_REQUEST
        Inherits MAINCONTEXT

        Public fields As New TABEAN_HERB_EDIT_REQUEST

        Public Sub insert()
            db.TABEAN_HERB_EDIT_REQUESTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_HERB_EDIT_REQUESTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_HERB_EDIT_REQUESTs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_HERB_EDIT_REQUESTs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_HERB_EDIT_REQUESTs Where p.FK_IDA = FK_IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

    End Class
    Public Class TB_TABEAN_HERB_EDIT_REQUEST_IOWA
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New TABEAN_HERB_EDIT_REQUEST_IOWA
        Private _Details As New List(Of TABEAN_HERB_EDIT_REQUEST_IOWA)
        Public Property Details() As List(Of TABEAN_HERB_EDIT_REQUEST_IOWA)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of TABEAN_HERB_EDIT_REQUEST_IOWA))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New TABEAN_HERB_EDIT_REQUEST_IOWA
        End Sub
        Public Sub insert()
            db.TABEAN_HERB_EDIT_REQUEST_IOWAs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.TABEAN_HERB_EDIT_REQUEST_IOWAs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_IOWAs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_IOWAs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Newcode_U(ByVal Newcode_U As String)
            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_IOWAs Where p.Newcode_U = Newcode_U Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Newcode_U_GROUP(ByVal Newcode_U As String)
            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_IOWAs Where p.Newcode_U = Newcode_U Group p By p.flineno Into Group
                     Select New With {flineno})
        End Sub
        Public Sub GetDataby_Newcode_U_BY_RID(ByVal Newcode_U As String, ByVal flineno As String)
            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_IOWAs Where p.Newcode_U = Newcode_U Select p Order By p.rid)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_TABEAN_HERB_EDIT_REQUEST_IOWA_OLD
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New TABEAN_HERB_EDIT_REQUEST_IOWA_OLD
        Private _Details As New List(Of TABEAN_HERB_EDIT_REQUEST_IOWA_OLD)
        Public Property Details() As List(Of TABEAN_HERB_EDIT_REQUEST_IOWA_OLD)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of TABEAN_HERB_EDIT_REQUEST_IOWA_OLD))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New TABEAN_HERB_EDIT_REQUEST_IOWA_OLD
        End Sub
        Public Sub insert()
            db.TABEAN_HERB_EDIT_REQUEST_IOWA_OLDs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.TABEAN_HERB_EDIT_REQUEST_IOWA_OLDs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_IOWA_OLDs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_IOWA_OLDs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Newcode_U(ByVal Newcode_U As String)
            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_IOWA_OLDs Where p.Newcode_U = Newcode_U Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Newcode_U_GROUP(ByVal Newcode_U As String)
            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_IOWA_OLDs Where p.Newcode_U = Newcode_U Group p By p.flineno Into Group
                     Select New With {flineno})
        End Sub
        Public Sub GetDataby_Newcode_U_BY_RID(ByVal Newcode_U As String, ByVal flineno As String)
            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_IOWA_OLDs Where p.Newcode_U = Newcode_U Select p Order By p.rid)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_TABEAN_HERB_EDIT_EQTO
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New TABEAN_HERB_EDIT_REQUEST_EQTO
        Private _Details As New List(Of TABEAN_HERB_EDIT_REQUEST_EQTO)
        Public Property Details() As List(Of TABEAN_HERB_EDIT_REQUEST_EQTO)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of TABEAN_HERB_EDIT_REQUEST_EQTO))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New TABEAN_HERB_EDIT_REQUEST_EQTO
        End Sub
        Public Sub insert()
            db.TABEAN_HERB_EDIT_REQUEST_EQTOs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.TABEAN_HERB_EDIT_REQUEST_EQTOs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_EQTOs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_EQTOs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_EQTOs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_DRRQT_IDA(ByVal IDA As Integer)

            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_EQTOs Where p.FK_DRRQT_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GET_MAX_ROWS_ID(ByVal FK_IDA As Integer)
            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_EQTOs Where p.FK_IDA = FK_IDA Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_MAX_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_EQTOs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_TABEAN_HERB_EDIT_FILE
        Inherits MAINCONTEXT

        Public fields As New TABEAN_HERB_EDIT_FILE

        Public Sub insert()
            db.TABEAN_HERB_EDIT_FILEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_HERB_EDIT_FILEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_HERB_EDIT_FILEs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_HERB_EDIT_FILEs Where p.IDA = IDA And p.ACTIVEFACT = True Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub Getdataby_FK_IDA(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_HERB_EDIT_FILEs Where p.FK_IDA = FK_IDA And p.ACTIVEFACT = True Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_TYPE(ByVal TYPE_ID As Integer)
            datas = From p In db.TABEAN_HERB_EDIT_FILEs Where p.TYPE_ID = TYPE_ID And p.ACTIVEFACT = True Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_TR_ID_FK_IDA_PROCESS_ID_AND_TYPE_DC(ByVal FK_IDA As Integer, ByVal TYPE_ID As Integer, ByVal DC As String)
            datas = From p In db.TABEAN_HERB_EDIT_FILEs Where p.FK_IDA = FK_IDA And p.TYPE_ID = TYPE_ID And p.DUCUMENT_NAME = DC And p.ACTIVEFACT = 1 Select p
            For Each Me.fields In datas

            Next
        End Sub

    End Class
    Public Class TB_MAS_TABEAN_HERB_EDIT_FILEUPLOAD
        Inherits MAINCONTEXT

        Public fields As New MAS_TABEAN_HERB_EDIT_FILEUPLOAD

        Public Sub insert()
            db.MAS_TABEAN_HERB_EDIT_FILEUPLOADs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.MAS_TABEAN_HERB_EDIT_FILEUPLOADs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.MAS_TABEAN_HERB_EDIT_FILEUPLOADs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.MAS_TABEAN_HERB_EDIT_FILEUPLOADs Where p.ID = IDA And p.ACTIVEFACT = True Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdataby_DUCUMENT_NAME(ByVal DUCUMENT_NAME As String)
            datas = From p In db.MAS_TABEAN_HERB_EDIT_FILEUPLOADs Where p.DUCUMENT_NAME = DUCUMENT_NAME And p.ACTIVEFACT = True Select p
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_TYPE(ByVal TYPE_ID As Integer)
            datas = From p In db.MAS_TABEAN_HERB_EDIT_FILEUPLOADs Where p.TYPE_ID = TYPE_ID And p.ACTIVEFACT = True Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdataby_IDgroup(ByVal ID As Integer)
            datas = From p In db.MAS_TABEAN_HERB_EDIT_FILEUPLOADs Where p.IDgroup = ID And p.ACTIVEFACT = True Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_TR_ID_FK_IDA_PROCESS_ID_AND_TYPE_DC(ByVal FK_IDA As Integer, ByVal TYPE_ID As Integer, ByVal DC As String)
            datas = From p In db.TABEAN_HERB_EDIT_FILEs Where p.FK_IDA = FK_IDA And p.TYPE_ID = TYPE_ID And p.DUCUMENT_NAME = DC And p.ACTIVEFACT = 1 Select p
            For Each Me.fields In datas

            Next
        End Sub

    End Class
    Public Class TB_TABEAN_HERB_EDIT_REQUEST_SIZE_PACK_OLD
        Inherits MAINCONTEXT

        Public fields As New TABEAN_HERB_EDIT_REQUEST_SIZE_PACK_OLD

        Public Sub insert()
            db.TABEAN_HERB_EDIT_REQUEST_SIZE_PACK_OLDs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_HERB_EDIT_REQUEST_SIZE_PACK_OLDs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_HERB_MANUFACTRUEs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_HERB_EDIT_REQUEST_SIZE_PACK_OLDs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA_DQ(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_HERB_EDIT_REQUEST_SIZE_PACK_OLDs Where p.FK_IDA_DQ = FK_IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA_DQ2(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_HERB_EDIT_REQUEST_SIZE_PACK_OLDs Where p.FK_IDA_DQ = FK_IDA And p.ACTIVEFACT = 1 Select p

        End Sub
    End Class
    Public Class TB_TABEAN_HERB_EDIT_REQUEST_SIZE_PACK
        Inherits MAINCONTEXT

        Public fields As New TABEAN_HERB_EDIT_REQUEST_SIZE_PACK

        Public Sub insert()
            db.TABEAN_HERB_EDIT_REQUEST_SIZE_PACKs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_HERB_EDIT_REQUEST_SIZE_PACKs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_HERB_MANUFACTRUEs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_HERB_EDIT_REQUEST_SIZE_PACKs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_FK_IDA(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_HERB_EDIT_REQUEST_SIZE_PACKs Where p.FK_IDA = FK_IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA_DQ(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_HERB_EDIT_REQUEST_SIZE_PACKs Where p.FK_IDA_DQ = FK_IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA_DQ2(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_HERB_EDIT_REQUEST_SIZE_PACKs Where p.FK_IDA_DQ = FK_IDA And p.ACTIVEFACT = 1 Select p

        End Sub
    End Class
    Public Class TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
        Inherits MAINCONTEXT

        Public fields As New MAS_TABEAN_HERB_UPLOADFILE_JJ

        Public Sub insert()
            db.MAS_TABEAN_HERB_UPLOADFILE_JJs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.MAS_TABEAN_HERB_UPLOADFILE_JJs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.MAS_TABEAN_HERB_UPLOADFILE_JJs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.MAS_TABEAN_HERB_UPLOADFILE_JJs Where p.ID = IDA And p.ACTIVEFACT = True Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_TYPE(ByVal TYPE_ID As Integer)
            datas = From p In db.MAS_TABEAN_HERB_UPLOADFILE_JJs Where p.TYPE_ID = TYPE_ID And p.ACTIVEFACT = True Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_TYPE_AND_HEAD_ID(ByVal TYPE_ID As Integer, ByVal HEAD_ID As String)
            datas = From p In db.MAS_TABEAN_HERB_UPLOADFILE_JJs Where p.TYPE_ID = TYPE_ID And p.HEAD_ID = HEAD_ID And p.ACTIVEFACT = True Select p

            For Each Me.fields In datas

            Next
        End Sub

        '    Public Sub Getdataby_TR_ID(ByVal TR_ID As Integer)
        '        datas = From p In db.MAS_TABEAN_HERB_UPLOADFILE_JJs Where p.ID = TR_ID Select p

        '        For Each Me.fields In datas

        '        Next
        '    End Sub

    End Class

    Public Class TB_MAS_TABEAN_HERB_STATUS_JJ
        Inherits MAINCONTEXT

        Public fields As New MAS_TABEAN_HERB_STATUS_JJ

        Public Sub insert()
            db.MAS_TABEAN_HERB_STATUS_JJs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.MAS_TABEAN_HERB_STATUS_JJs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.MAS_TABEAN_HERB_STATUS_JJs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.MAS_TABEAN_HERB_STATUS_JJs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub Getdataby_STATUS_ID(ByVal S_ID As Integer)
            datas = From p In db.MAS_TABEAN_HERB_STATUS_JJs Where p.STATUS_ID = S_ID Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdataby_STATUS_ID_GROUP(ByVal S_ID As Integer, ByVal G_ID As Integer)
            datas = From p In db.MAS_TABEAN_HERB_STATUS_JJs Where p.STATUS_ID = S_ID And p.STATUS_GROUP = G_ID Select p
            For Each Me.fields In datas

            Next
        End Sub

    End Class

    Public Class TB_TTRANSACTION_NO_RESIDUE
        Inherits MAINCONTEXT

        Public fields As New TRANSACTION_NO_RESIDUE

        Public Sub insert()
            db.TRANSACTION_NO_RESIDUEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TRANSACTION_NO_RESIDUEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TRANSACTION_NO_RESIDUEs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TRANSACTION_NO_RESIDUEs Where p.ID = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_REF_NO(ByVal FK_IDA As Integer)
            datas = From p In db.TRANSACTION_NO_RESIDUEs Where p.REF_NO = FK_IDA Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_REF_NO_PROCESS(ByVal FK_IDA As Integer, ByVal PROCESS_ID As Integer)
            datas = From p In db.TRANSACTION_NO_RESIDUEs Where p.REF_NO = FK_IDA And p.PROCESS_ID = PROCESS_ID Select p
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_PROCESS_ID(ByVal PROCESS_ID As Integer)
            datas = From p In db.TRANSACTION_NO_RESIDUEs Where p.PROCESS_ID = PROCESS_ID Select p
            For Each Me.fields In datas

            Next
        End Sub

    End Class
    Public Class TB_TABEAN_TRANSACTION_JJ
        Inherits MAINCONTEXT

        Public fields As New TABEAN_TRANSACTION_JJ

        Public Sub insert()
            db.TABEAN_TRANSACTION_JJs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_TRANSACTION_JJs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_HERB_UPLOAD_FILE_JJs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_TRANSACTION_JJs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA_JJ(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_TRANSACTION_JJs Where p.FK_IDA_JJ = FK_IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

    End Class

    Public Class TB_TABEAN_HERB_ML
        Inherits MAINCONTEXT

        Public fields As New MAS_TABEAN_HERB_ML

        Public Sub insert()
            db.MAS_TABEAN_HERB_MLs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.MAS_TABEAN_HERB_MLs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.MAS_TABEAN_HERB_MLs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.MAS_TABEAN_HERB_MLs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub
    End Class

    Public Class TB_TABEAN_HERB
        Inherits MAINCONTEXT

        Public fields As New TABEAN_HERB

        Public Sub insert()
            db.TABEAN_HERBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_HERBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_HERBs Where p.ACTIVEFACT = True Select p)
        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_HERBs Where p.IDA = IDA And p.ACTIVEFACT = True Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA_DQ(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_HERBs Where p.FK_IDA_DQ = FK_IDA And p.ACTIVEFACT = True Select p

            For Each Me.fields In datas

            Next
        End Sub

    End Class

    Public Class TB_MAS_COMPLEX_DATE_HERB
        Inherits MAINCONTEXT

        Public fields As New MAS_COMPLEX_DATE_HERB

        Public Sub insert()
            db.MAS_COMPLEX_DATE_HERBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.MAS_COMPLEX_DATE_HERBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.MAS_COMPLEX_DATE_HERBs Select p)

        End Sub

        Public Sub GetdatabyID(ByVal ID As Integer)
            datas = From p In db.MAS_COMPLEX_DATE_HERBs Where p.ID = ID Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_PRCESS_ID(ByVal PROCESS_ID As Integer)
            datas = From p In db.MAS_COMPLEX_DATE_HERBs Where p.PROCESS_ID = PROCESS_ID Select p

            For Each Me.fields In datas

            Next
        End Sub

    End Class
    Public Class TB_TABEAN_INFORM
        Inherits MAINCONTEXT

        Public fields As New TABEAN_JR

        Public Sub insert()
            db.TABEAN_JRs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_JRs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_JRs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_JRs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub
        'Public Sub GetdatabyID_FK_IDA(ByVal FK_IDA As Integer)
        '    datas = From p In db.TABEAN_JRs Where p.FK_IDA = FK_IDA Select p
        '    For Each Me.fields In datas
        '    Next
        'End Sub

    End Class
    Public Class TB_TABEAN_HERB_MANUFACTRUE
        Inherits MAINCONTEXT

        Public fields As New TABEAN_HERB_MANUFACTRUE

        Public Sub insert()
            db.TABEAN_HERB_MANUFACTRUEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_HERB_MANUFACTRUEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_HERB_MANUFACTRUEs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_HERB_MANUFACTRUEs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA_DQ(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_HERB_MANUFACTRUEs Where p.FK_IDA_DQ = FK_IDA And p.ACTIVEFACT = 1 Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA_DQ2(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_HERB_MANUFACTRUEs Where p.FK_IDA_DQ = FK_IDA And p.ACTIVEFACT = 1 Select p

        End Sub
    End Class
    Public Class TB_TABEAN_HERB_EDIT_MANUFACTRUE
        Inherits MAINCONTEXT

        Public fields As New TABEAN_HERB_EDIT_MANUFACTRUE

        Public Sub insert()
            db.TABEAN_HERB_EDIT_MANUFACTRUEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_HERB_EDIT_MANUFACTRUEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_HERB_EDIT_MANUFACTRUEs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_HERB_EDIT_MANUFACTRUEs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA_DQ(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_HERB_EDIT_MANUFACTRUEs Where p.FK_IDA_DQ = FK_IDA And p.ACTIVEFACT = 1 Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_FK_IDA(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_HERB_EDIT_MANUFACTRUEs Where p.FK_IDA = FK_IDA And p.ACTIVEFACT = 1 Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA_DQ2(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_HERB_EDIT_MANUFACTRUEs Where p.FK_IDA_DQ = FK_IDA And p.ACTIVEFACT = 1 Select p

        End Sub
    End Class
    Public Class TB_TABEAN_EDIT_DETAIL_CAS
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New TABEAN_EDIT_DETAIL_CA
        Private _Details As New List(Of TABEAN_EDIT_DETAIL_CA)
        Public Property Details() As List(Of TABEAN_EDIT_DETAIL_CA)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of TABEAN_EDIT_DETAIL_CA))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New TABEAN_EDIT_DETAIL_CA
        End Sub
        Public Sub insert()
            db.TABEAN_EDIT_DETAIL_CAs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.TABEAN_EDIT_DETAIL_CAs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.TABEAN_EDIT_DETAIL_CAs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.TABEAN_EDIT_DETAIL_CAs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_IDA_ORDER(ByVal IDA As Integer, ByVal FK_SET As Integer)

            datas = (From p In db.TABEAN_EDIT_DETAIL_CAs Where p.IDA = IDA And p.FK_SET = FK_SET Select p Order By p.ROWS Ascending)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA_ORDER(ByVal FK_IDA As Integer, ByVal FK_SET As Integer)

            datas = (From p In db.TABEAN_EDIT_DETAIL_CAs Where p.FK_IDA = FK_IDA And p.FK_SET = FK_SET Select p Order By CInt(p.ROWS) Ascending)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_ROWs_AND_FK_SET(ByVal ROWs As Integer, ByVal FK_SET As Integer)

            datas = (From p In db.TABEAN_EDIT_DETAIL_CAs Where p.FK_SET = FK_SET And p.ROWS = ROWs Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_IDA_AND_ROWs(ByVal IDA As Integer, ByVal ROWs As Integer)

            datas = (From p In db.TABEAN_EDIT_DETAIL_CAs Where p.IDA = IDA And p.ROWS = ROWs Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)
            datas = (From p In db.TABEAN_EDIT_DETAIL_CAs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub

        Public Function COUNTDataby_FKIDA(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.TABEAN_EDIT_DETAIL_CAs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
            Return i
        End Function
        Public Sub GET_MAX_ROWS_ID(ByVal FK_IDA As Integer)
            datas = (From p In db.TABEAN_EDIT_DETAIL_CAs Where p.FK_IDA = FK_IDA Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_MAX_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
            datas = (From p In db.TABEAN_EDIT_DETAIL_CAs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_MIN_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
            datas = (From p In db.TABEAN_EDIT_DETAIL_CAs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Ascending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_TABEAN_EDIT_DETAIL_CAS_OLD
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New TABEAN_EDIT_DETAIL_CAS_OLD
        Private _Details As New List(Of TABEAN_EDIT_DETAIL_CAS_OLD)
        Public Property Details() As List(Of TABEAN_EDIT_DETAIL_CAS_OLD)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of TABEAN_EDIT_DETAIL_CAS_OLD))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New TABEAN_EDIT_DETAIL_CAS_OLD
        End Sub
        Public Sub insert()
            db.TABEAN_EDIT_DETAIL_CAS_OLDs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.TABEAN_EDIT_DETAIL_CAS_OLDs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.TABEAN_EDIT_DETAIL_CAS_OLDs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.TABEAN_EDIT_DETAIL_CAS_OLDs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_TABEAN_EDIT_REQUEST_EQTO
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New TABEAN_EDIT_REQUEST_EQTO
        Private _Details As New List(Of TABEAN_EDIT_REQUEST_EQTO)
        Public Property Details() As List(Of TABEAN_EDIT_REQUEST_EQTO)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of TABEAN_EDIT_REQUEST_EQTO))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New TABEAN_EDIT_REQUEST_EQTO
        End Sub
        Public Sub insert()
            db.TABEAN_EDIT_REQUEST_EQTOs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.TABEAN_EDIT_REQUEST_EQTOs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.TABEAN_EDIT_REQUEST_EQTOs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.TABEAN_EDIT_REQUEST_EQTOs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Newcode_rid_flineno(ByVal newcode_rid As String, ByVal flineno As String)

            datas = (From p In db.TABEAN_EDIT_REQUEST_EQTOs Where p.Newcode_rid = newcode_rid Select p)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetDataby_Newcode_rid(ByVal newcode_rid As String)

            datas = (From p In db.TABEAN_EDIT_REQUEST_EQTOs Where p.Newcode_rid = newcode_rid Select p)
            For Each Me.fields In datas

            Next
        End Sub
        'Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

        '    datas = (From p In db.TABEAN_EDIT_REQUEST_EQTOs Where p.FK_IDA = IDA Select p)
        '    For Each Me.fields In datas

        '    Next
        'End Sub
        'Public Sub GetDataby_FK_DRRQT_IDA(ByVal IDA As Integer)

        '    datas = (From p In db.TABEAN_EDIT_REQUEST_EQTOs Where p.FK_DRRQT_IDA = IDA Select p)
        '    For Each Me.fields In datas

        '    Next
        'End Sub
        'Public Sub GET_MAX_ROWS_ID(ByVal FK_IDA As Integer)
        '    datas = (From p In db.TABEAN_EDIT_REQUEST_EQTOs Where p.FK_IDA = FK_IDA Order By CInt(p.ROWS) Descending Select p).Take(1)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        'Public Sub GET_MAX_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
        '    datas = (From p In db.TABEAN_EDIT_REQUEST_EQTOs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Descending Select p).Take(1)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
    End Class
    Public Class TB_TABEAN_EDIT_REQUEST_EQTO_OLD
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New TABEAN_EDIT_REQUEST_EQTO_OLD
        Private _Details As New List(Of TABEAN_EDIT_REQUEST_EQTO_OLD)
        Public Property Details() As List(Of TABEAN_EDIT_REQUEST_EQTO_OLD)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of TABEAN_EDIT_REQUEST_EQTO_OLD))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New TABEAN_EDIT_REQUEST_EQTO_OLD
        End Sub
        Public Sub insert()
            db.TABEAN_EDIT_REQUEST_EQTO_OLDs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.TABEAN_EDIT_REQUEST_EQTO_OLDs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.TABEAN_EDIT_REQUEST_EQTO_OLDs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_EQTO_OLDs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Newcode_rid_flineno(ByVal newcode_rid As String, ByVal flineno As String)

            datas = (From p In db.TABEAN_EDIT_REQUEST_EQTO_OLDs Where p.Newcode_rid = newcode_rid Select p)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetDataby_Newcode_rid(ByVal newcode_rid As String)

            datas = (From p In db.TABEAN_EDIT_REQUEST_EQTO_OLDs Where p.Newcode_rid = newcode_rid Select p)
            For Each Me.fields In datas

            Next
        End Sub
        'Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

        '    datas = (From p In db.TABEAN_EDIT_REQUEST_EQTOs Where p.FK_IDA = IDA Select p)
        '    For Each Me.fields In datas

        '    Next
        'End Sub
        'Public Sub GetDataby_FK_DRRQT_IDA(ByVal IDA As Integer)

        '    datas = (From p In db.TABEAN_EDIT_REQUEST_EQTOs Where p.FK_DRRQT_IDA = IDA Select p)
        '    For Each Me.fields In datas

        '    Next
        'End Sub
        'Public Sub GET_MAX_ROWS_ID(ByVal FK_IDA As Integer)
        '    datas = (From p In db.TABEAN_EDIT_REQUEST_EQTOs Where p.FK_IDA = FK_IDA Order By CInt(p.ROWS) Descending Select p).Take(1)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        'Public Sub GET_MAX_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
        '    datas = (From p In db.TABEAN_EDIT_REQUEST_EQTOs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Descending Select p).Take(1)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
    End Class
    Public Class TB_TABEAN_HERB_EDIT_EQTO_OLD
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New TABEAN_HERB_EDIT_REQUEST_EQTO_OLD
        Private _Details As New List(Of TABEAN_HERB_EDIT_REQUEST_EQTO_OLD)
        Public Property Details() As List(Of TABEAN_HERB_EDIT_REQUEST_EQTO_OLD)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of TABEAN_HERB_EDIT_REQUEST_EQTO_OLD))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New TABEAN_HERB_EDIT_REQUEST_EQTO_OLD
        End Sub
        Public Sub insert()
            db.TABEAN_HERB_EDIT_REQUEST_EQTO_OLDs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.TABEAN_HERB_EDIT_REQUEST_EQTO_OLDs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_EQTO_OLDs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_EQTO_OLDs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_EQTO_OLDs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_DRRQT_IDA(ByVal IDA As Integer)

            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_EQTO_OLDs Where p.FK_DRRQT_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GET_MAX_ROWS_ID(ByVal FK_IDA As Integer)
            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_EQTO_OLDs Where p.FK_IDA = FK_IDA Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_MAX_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_EQTO_OLDs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_TABEAN_EDIT_EACH
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน
        Public fields As New TABEAN_EDIT_EACH
        Public Sub insert()
            db.TABEAN_EDIT_EACHes.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.TABEAN_EDIT_EACHes.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.TABEAN_EDIT_EACHes Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.TABEAN_EDIT_EACHes Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)
            datas = (From p In db.TABEAN_EDIT_EACHes Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA_AND_SET(ByVal IDA As Integer, ByVal SET_ As Integer)
            datas = (From p In db.TABEAN_EDIT_EACHes Where p.FK_IDA = IDA And p.FK_SET = SET_ Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Function CountDataby_FK_IDA(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.TABEAN_EDIT_EACHes Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    Public Class TB_TABEAN_HERB_SIZE_PACK_FST
        Inherits MAINCONTEXT

        Public fields As New TABEAN_HERB_SIZE_PACK_FST

        Public Sub insert()
            db.TABEAN_HERB_SIZE_PACK_FSTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_HERB_SIZE_PACK_FSTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_HERB_MANUFACTRUEs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_HERB_SIZE_PACK_FSTs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA_DQ(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_HERB_SIZE_PACK_FSTs Where p.FK_IDA_DQ = FK_IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA_DQ2(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_HERB_SIZE_PACK_FSTs Where p.FK_IDA_DQ = FK_IDA And p.ACTIVEFACT = 1 Select p

        End Sub
    End Class

    Public Class TB_GEN_NO_JJ
        Inherits MAINCONTEXT

        Public fields As New GEN_NO_JJ

        Public Sub insert()
            db.GEN_NO_JJs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.GEN_NO_JJs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.GEN_NO_JJs Select p)

        End Sub

        Public Sub GetDataby_GEN(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal REF_IDA As String, ByVal IDA_LCNNO As String)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_JJs Where p.PVCODE = PVCODE And p.YEAR = YEAR And p.TYPE = TYPE Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_GEN_NOPV(ByVal YEAR As String, ByVal TYPE As String, ByVal REF_IDA As String, ByVal IDA_LCNNO As String)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_JJs Where p.YEAR = YEAR And p.TYPE = TYPE Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_GEN_NO()
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_JJs Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas

            Next
        End Sub

    End Class
    Public Class TB_TABEAN_INFORM_MANUFACTRUE
        Inherits MAINCONTEXT

        Public fields As New TABEAN_JR_MANUFACTRUE

        Public Sub insert()
            db.TABEAN_JR_MANUFACTRUEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_JR_MANUFACTRUEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_HERB_MANUFACTRUEs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_JR_MANUFACTRUEs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_JR_MANUFACTRUEs Where p.FK_IDA = FK_IDA And p.ACTIVEFACT = 1 Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA2(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_JR_MANUFACTRUEs Where p.FK_IDA = FK_IDA And p.ACTIVEFACT = 1 Select p

        End Sub
    End Class
    Public Class TB_TABEAN_INFORM_SIZE_PACK_FST
        Inherits MAINCONTEXT

        Public fields As New TABEAN_JR_SIZE_PACK_FST

        Public Sub insert()
            db.TABEAN_JR_SIZE_PACK_FSTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_JR_SIZE_PACK_FSTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_JR_SIZE_PACK_FSTs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_JR_SIZE_PACK_FSTs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_JR_SIZE_PACK_FSTs Where p.FK_IDA = FK_IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA2(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_JR_SIZE_PACK_FSTs Where p.FK_IDA = FK_IDA And p.ACTIVEFACT = 1 Select p

        End Sub
    End Class
    Public Class TB_GEN_NO_TBN
        Inherits MAINCONTEXT

        Public fields As New GEN_NO_TBN

        Public Sub insert()
            db.GEN_NO_TBNs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.GEN_NO_TBNs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.GEN_NO_TBNs Select p)

        End Sub

        Public Sub GetDataby_GEN(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal REF_IDA As String, ByVal IDA_LCNNO As String)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_TBNs Where p.PVCODE = PVCODE And p.YEAR = YEAR And p.TYPE = TYPE Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_GEN_NOPV(ByVal YEAR As String, ByVal TYPE As String, ByVal REF_IDA As String, ByVal IDA_LCNNO As String)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_TBNs Where p.YEAR = YEAR And p.TYPE = TYPE Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas

            Next
        End Sub

    End Class

    Public Class TB_LOG_GEN_XML
        Inherits MAINCONTEXT

        Public fields As New LOG_GEN_XML

        Public Sub insert()
            db.LOG_GEN_XMLs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.LOG_GEN_XMLs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.LOG_GEN_XMLs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.LOG_GEN_XMLs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_GEN_NO_TBN_FronNarcotic
        Inherits MAINCONTEXT
        Public fields As New GEN_NO_TBN_FronNarcotic
        Public Sub insert()
            db.GEN_NO_TBN_FronNarcotics.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.GEN_NO_TBN_FronNarcotics.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.GEN_NO_TBN_FronNarcotics Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.GEN_NO_TBN_FronNarcotics Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)
            datas = (From p In db.GEN_NO_TBN_FronNarcotics Where p.REF_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_YEAR(ByVal YEAR As Integer)
            datas = (From p In db.GEN_NO_TBN_FronNarcotics Where p.YEAR = YEAR Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_TBN_FronNarcotics Where p.PVCODE = PVCODE And p.YEAR = YEAR And p.TYPE = TYPE Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_RGTNO_MAX_N_NC(ByVal YEAR As String, ByVal PVNCD As String, ByVal IDA As Integer)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_TBN_FronNarcotics Where p.PVCODE = PVNCD And p.YEAR = YEAR And (p.TYPE = "1" Or p.TYPE = "6") Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_RGTNO_MAX_NB_NBC(ByVal YEAR As String, ByVal PVNCD As String, ByVal IDA As Integer)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_TBN_FronNarcotics Where p.PVCODE = PVNCD And p.YEAR = YEAR And (p.TYPE = "7" Or p.TYPE = "B") Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_RGTTPCD_MAX(ByVal YEAR As String, ByVal RGTTPCD As String, ByVal drgtpcd As Integer)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_TBN_FronNarcotics Where p.YEAR = YEAR And p.TYPE = RGTTPCD And p.GROUP_NO = drgtpcd Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Condition_MAX(ByVal YEAR As String, ByVal RGTTPCD As String, ByVal drgtpcd As Integer, ByVal Condition As Integer)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_TBN_FronNarcotics Where p.YEAR = YEAR And p.TYPE = RGTTPCD And p.GROUP_NO = drgtpcd And p.Condition = Condition Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_RGTNO_MAX(ByVal YEAR As String, ByVal PVNCD As String, ByVal RGTTPCD As String, ByVal IDA As Integer)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_TBN_FronNarcotics Where p.PVCODE = PVNCD And p.YEAR = YEAR And p.TYPE = RGTTPCD Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_RGTNO_50KMAX(ByVal YEAR As String, ByVal PVNCD As String, ByVal RGTTPCD As String, ByVal IDA As Integer, ByVal process_id As String)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_TBN_FronNarcotics Where p.PVCODE = PVNCD And p.YEAR = YEAR And p.GROUP_NO = RGTTPCD And p.TYPE = process_id Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_GEN_NO_TBN_NEW
        Inherits MAINCONTEXT
        Public fields As New GEN_NO_TBN_NEW
        Public Sub insert()
            db.GEN_NO_TBN_NEWs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.GEN_NO_TBN_NEWs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.GEN_NO_TBN_NEWs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.GEN_NO_TBN_NEWs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)
            datas = (From p In db.GEN_NO_TBN_NEWs Where p.REF_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_YEAR(ByVal YEAR As Integer)
            datas = (From p In db.GEN_NO_TBN_NEWs Where p.YEAR = YEAR Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_TBN_NEWs Where p.PVCODE = PVCODE And p.YEAR = YEAR And p.TYPE = TYPE Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_RGTNO_MAX_N_NC(ByVal YEAR As String, ByVal PVNCD As String, ByVal IDA As Integer)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_TBN_NEWs Where p.PVCODE = PVNCD And p.YEAR = YEAR And (p.TYPE = "1" Or p.TYPE = "6") Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_RGTNO_MAX_NB_NBC(ByVal YEAR As String, ByVal PVNCD As String, ByVal IDA As Integer)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_TBN_NEWs Where p.PVCODE = PVNCD And p.YEAR = YEAR And (p.TYPE = "7" Or p.TYPE = "B") Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_RGTTPCD_MAX(ByVal YEAR As String, ByVal RGTTPCD As String, ByVal IDA As Integer)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_TBN_NEWs Where p.YEAR = YEAR And p.TYPE = RGTTPCD Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_RGTNO_MAX(ByVal YEAR As String, ByVal PVNCD As String, ByVal RGTTPCD As String, ByVal IDA As Integer, ByVal process_id As Integer, ByVal drgtpcd As String)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_TBN_NEWs Where p.YEAR = YEAR And p.TYPE = RGTTPCD And p.GROUP_NO = drgtpcd Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_RGTNO_NEW_MAX(ByVal YEAR As String, ByVal PVNCD As String, ByVal RGTTPCD As String, ByVal IDA As Integer, ByVal drgtpcd As String)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_TBN_NEWs Where p.YEAR = YEAR And p.TYPE = RGTTPCD And p.GROUP_NO = drgtpcd Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_TABEAN_JJ_EDIT_REQUEST
        Inherits MAINCONTEXT

        Public fields As New TABEAN_JJ_EDIT_REQUEST

        Public Sub insert()
            db.TABEAN_JJ_EDIT_REQUESTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_JJ_EDIT_REQUESTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_JJ_EDIT_REQUESTs Select p)

        End Sub

        Public Sub GetdatabyID_DD_HERB_NAME_ID(ByVal DD_HERB_NAME_ID As Integer)
            datas = From p In db.TABEAN_JJ_EDIT_REQUESTs Where p.DD_HERB_NAME_ID = DD_HERB_NAME_ID Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_JJ_EDIT_REQUESTs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_JJ_EDIT_REQUESTs Where p.FK_IDA = FK_IDA Select p
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetdatabyID_IDA_LCN_ID_AND_TR_ID(ByVal IDA As Integer, ByVal TR_ID As Integer, ByVal LCN_ID As Integer)
            datas = From p In db.TABEAN_JJ_EDIT_REQUESTs Where p.IDA = IDA And p.TR_ID_JJ = TR_ID And p.IDA_LCN = LCN_ID Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_IDA_DD_HERB_NAME_ID(ByVal IDA As Integer, ByVal DD_HERB_NAME As Integer)
            datas = From p In db.TABEAN_JJ_EDIT_REQUESTs Where p.IDA = IDA And p.DD_HERB_NAME_ID = DD_HERB_NAME Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_IDA_LCN(ByVal IDA_LCN As Integer, ByVal DD_HERB_NAME As Integer)
            datas = From p In db.TABEAN_JJ_EDIT_REQUESTs Where p.LCN_ID = IDA_LCN And p.DD_HERB_NAME_ID = DD_HERB_NAME Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_IDA_PROCESS(ByVal IDA As Integer, ByVal DDHERB As Integer)
            datas = From p In db.TABEAN_JJ_EDIT_REQUESTs Where p.IDA = IDA And p.DDHERB = DDHERB Select p

            For Each Me.fields In datas

            Next
        End Sub

    End Class

    Public Class TB_TABEAN_JJ_EDIT_REQUEST_CHECK_EDIT
        Inherits MAINCONTEXT

        Public fields As New TABEAN_JJ_EDIT_REQUEST_CHECK_EDIT

        Public Sub insert()
            db.TABEAN_JJ_EDIT_REQUEST_CHECK_EDITs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_JJ_EDIT_REQUEST_CHECK_EDITs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_JJ_EDIT_REQUEST_CHECK_EDITs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_JJ_EDIT_REQUEST_CHECK_EDITs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_JJ_EDIT_REQUEST_CHECK_EDITs Where p.FK_IDA = FK_IDA Select p
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_GEN_NO_JJ_EDIT
        Inherits MAINCONTEXT

        Public fields As New GEN_NO_JJ_EDIT

        Public Sub insert()
            db.GEN_NO_JJ_EDITs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.GEN_NO_JJ_EDITs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.GEN_NO_JJs Select p)

        End Sub
        Public Sub GetDataby_GEN_NOPV(ByVal YEAR As String, ByVal TYPE As String, ByVal REF_IDA As String, ByVal IDA_LCNNO As String)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_JJ_EDITs Where p.YEAR = YEAR And p.TYPE = TYPE Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_GEN(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal REF_IDA As String, ByVal IDA_LCNNO As String)
            'datas = (From p In db.GEN_NO_01s Where p.IDA = YEAR Order By p.IDA Descending Select p)
            datas = (From p In db.GEN_NO_JJ_EDITs Where p.PVCODE = PVCODE And p.YEAR = YEAR And p.TYPE = TYPE Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas

            Next
        End Sub

    End Class
    Public Class TB_TABEAN_JJ_EDIT_SUBPACKAGE
        Inherits MAINCONTEXT

        Public fields As New TABEAN_JJ_EDIT_SUB_PACKSIZE

        Private _Details As New List(Of TABEAN_JJ_EDIT_SUB_PACKSIZE)
        Public Property Details() As List(Of TABEAN_JJ_EDIT_SUB_PACKSIZE)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of TABEAN_JJ_EDIT_SUB_PACKSIZE))
                _Details = value
            End Set
        End Property

        Public Sub AddDetails()
            Details.Add(fields)
            fields = New TABEAN_JJ_EDIT_SUB_PACKSIZE
        End Sub

        Public Sub insert()
            db.TABEAN_JJ_EDIT_SUB_PACKSIZEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_JJ_EDIT_SUB_PACKSIZEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_JJ_EDIT_SUB_PACKSIZEs Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub

        Public Sub GetData_ByIDA(ByVal IDA As Integer)
            datas = (From p In db.TABEAN_JJ_EDIT_SUB_PACKSIZEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetData_ByDD_HERB_NAME_ID(ByVal DD_HERB_NAME_ID As Integer)
            datas = (From p In db.TABEAN_JJ_EDIT_SUB_PACKSIZEs Where p.IDA = DD_HERB_NAME_ID Select p)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetData_ByFkIDA(ByVal fk_ida As Integer)
            datas = (From p In db.TABEAN_JJ_EDIT_SUB_PACKSIZEs Where p.FK_IDA = fk_ida And p.ACTIVEFACT = 1 Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
    End Class
    Public Class TB_LOG_EDIT_JJ
        Inherits MAINCONTEXT

        Public fields As New log_edit_jj3_addr

        Public Sub insert()
            db.log_edit_jj3_addrs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.log_edit_jj3_addrs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.log_edit_jj3_addrs Select p)

        End Sub

        Public Sub Getdataby_FK_IDA(ByVal FK_IDA As Integer)
            datas = From p In db.log_edit_jj3_addrs Where p.FK_IDA = FK_IDA Select p

            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_MAS_CUSTOMER_BUTTON
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_CUSTOMER_BUTTON

        Public Sub insert()
            db.MAS_CUSTOMER_BUTTONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_CUSTOMER_BUTTONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_CUSTOMER_BUTTONs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_CUSTOMER_BUTTONs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDgroup(ByVal IDgroup As Integer)

            datas = (From p In db.MAS_CUSTOMER_BUTTONs Where p.IDgroup = IDgroup Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Btn_Group_and_Admin_group(ByVal IDgroup As Integer, ByVal a_group As Integer)

            datas = (From p In db.MAS_CUSTOMER_BUTTONs Where p.BTN_GROUP = IDgroup And p.ADMIN_GROUP = a_group Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Btn_Group_and_IdGroup(ByVal BtnGroup As Integer, ByVal idGroup As Integer)

            datas = (From p In db.MAS_CUSTOMER_BUTTONs Where p.BTN_GROUP = BtnGroup And p.IDgroup = idGroup Select p Order By p.SEQ Ascending)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Btn_Group(ByVal IDgroup As Integer)

            datas = (From p In db.MAS_CUSTOMER_BUTTONs Where p.BTN_GROUP = IDgroup Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Function Check_Page(ByVal url As String, ByVal IDgroup As Integer) As Integer
            'BTN_URL
            Dim i As Integer = 0
            datas = (From p In db.MAS_CUSTOMER_BUTTONs Where p.BTN_URL.Contains(url) And p.IDgroup = IDgroup Select p)
            For Each Me.fields In datas
                i += 1
            Next

            Return i
        End Function
    End Class
    Public Class TB_LOG_CUSTOMER_JJ_EDIT
        Inherits MAINCONTEXT

        Public fields As New LOG_CUSTOMER_JJ_EDIT

        Public Sub insert()
            db.LOG_CUSTOMER_JJ_EDITs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.LOG_CUSTOMER_JJ_EDITs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.LOG_CUSTOMER_JJ_EDITs Select p)

        End Sub

        Public Sub Getdataby_IDA(ByVal IDA As Integer)
            datas = From p In db.LOG_CUSTOMER_JJ_EDITs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub Getdataby_FK_IDA(ByVal FK_IDA As Integer)
            datas = From p In db.LOG_CUSTOMER_JJ_EDITs Where p.FK_IDA = FK_IDA Select p
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_TABEAN_HERB_EDIT_REQUEST_TEMPOLARY
        Inherits MAINCONTEXT

        Public fields As New TABEAN_HERB_EDIT_REQUEST_TEMPOLARY

        Public Sub insert()
            db.TABEAN_HERB_EDIT_REQUEST_TEMPOLARies.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_HERB_EDIT_REQUEST_TEMPOLARies.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_HERB_EDIT_REQUEST_TEMPOLARies Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_HERB_EDIT_REQUEST_TEMPOLARies Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

    End Class

    Public Class TB_MAS_PRICE_TABEAN_EDIT_TEMPOLARY
        Inherits MAINCONTEXT

        Public fields As New MAS_PRICE_TABEAN_EDIT_TEMPOLARY

        Public Sub insert()
            db.MAS_PRICE_TABEAN_EDIT_TEMPOLARies.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.MAS_PRICE_TABEAN_EDIT_TEMPOLARies.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.MAS_PRICE_TABEAN_EDIT_TEMPOLARies Select p)

        End Sub

        Public Sub Getdataby_ID(ByVal ID As Integer)
            datas = From p In db.MAS_PRICE_TABEAN_EDIT_TEMPOLARies Where p.ID = ID Select p

            For Each Me.fields In datas

            Next
        End Sub

    End Class

    Public Class TB_TABEAN_ANALYZE
        Inherits MAINCONTEXT

        Public fields As New TABEAN_ANALYZE

        Public Sub insert()
            db.TABEAN_ANALYZEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_ANALYZEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_ANALYZEs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_ANALYZEs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA_DQ(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_ANALYZEs Where p.FK_IDA = FK_IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

    End Class

    Public Class TB_TABEAN_DONATE
        Inherits MAINCONTEXT

        Public fields As New TABEAN_DONATE

        Public Sub insert()
            db.TABEAN_DONATEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_DONATEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_DONATEs Select p)
        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_DONATEs Where p.IDA = IDA Select p
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA_DQ(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_DONATEs Where p.FK_IDA = FK_IDA Select p
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_TABEAN_EXHIBITION
        Inherits MAINCONTEXT

        Public fields As New TABEAN_EXHIBITION

        Public Sub insert()
            db.TABEAN_EXHIBITIONs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_EXHIBITIONs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_EXHIBITIONs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_EXHIBITIONs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetdatabyID_TR_ID(ByVal TR_ID As Integer)
            datas = From p In db.TABEAN_EXHIBITIONs Where p.TR_ID = TR_ID Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA_DQ(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_EXHIBITIONs Where p.FK_IDA = FK_IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

    End Class
    Public Class TB_GEN_NO_NEW
        Inherits MAINCONTEXT
        Public fields As New GEN_NO_NEW
        Public Sub insert()
            db.GEN_NO_NEWs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.GEN_NO_NEWs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.GEN_NO_NEWs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.GEN_NO_NEWs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal FK_IDA As Integer)
            datas = (From p In db.GEN_NO_NEWs Where p.REF_IDA = FK_IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_YEAR(ByVal YEAR As Integer)
            datas = (From p In db.GEN_NO_NEWs Where p.YEAR = YEAR Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GEN(ByVal YEAR As String, ByVal PVCODE As String, ByVal TYPE As String, ByVal LCNNO As String,
                        ByVal FORMAT As String, ByVal GROUP_NO As String, ByVal REF_IDA As String, ByVal DESCRIPTION As String)
            datas = (From p In db.GEN_NO_NEWs Where p.PVCODE = PVCODE And p.YEAR = YEAR And p.TYPE = TYPE Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_RGTNO_MAX_N_NC(ByVal YEAR As String, ByVal PVNCD As String, ByVal IDA As Integer)
            datas = (From p In db.GEN_NO_NEWs Where p.PVCODE = PVNCD And p.YEAR = YEAR And (p.TYPE = "1" Or p.TYPE = "6") Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_RGTNO_MAX_NB_NBC(ByVal YEAR As String, ByVal PVNCD As String, ByVal IDA As Integer)
            datas = (From p In db.GEN_NO_NEWs Where p.PVCODE = PVNCD And p.YEAR = YEAR And (p.TYPE = "7" Or p.TYPE = "B") Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_TYPE_MAX(ByVal YEAR As String, ByVal TYPE As String, ByVal IDA As Integer)
            datas = (From p In db.GEN_NO_NEWs Where p.YEAR = YEAR And p.TYPE = TYPE Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_RGTNO_MAX(ByVal YEAR As String, ByVal PVNCD As String, ByVal RGTTPCD As String, ByVal IDA As Integer, ByVal process_id As Integer, ByVal drgtpcd As String)
            datas = (From p In db.GEN_NO_NEWs Where p.YEAR = YEAR And p.TYPE = RGTTPCD And p.GROUP_NO = drgtpcd Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GROUPNO_MAX(ByVal YEAR As String, ByVal GROUP_NO As String, ByVal IDA As Integer)
            datas = (From p In db.GEN_NO_NEWs Where p.YEAR = YEAR And p.GROUP_NO = GROUP_NO Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_RGTNO_NEW_MAX(ByVal YEAR As String, ByVal PVNCD As String, ByVal RGTTPCD As String, ByVal IDA As Integer, ByVal drgtpcd As String)
            datas = (From p In db.GEN_NO_NEWs Where p.YEAR = YEAR And p.TYPE = RGTTPCD And p.GROUP_NO = drgtpcd Order By CInt(p.GENNO) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_TABEAN_EXH_DETAIL_CAS
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New TABEAN_EXHIBITION_DETAIL_CA
        Private _Details As New List(Of TABEAN_EXHIBITION_DETAIL_CA)
        Public Property Details() As List(Of TABEAN_EXHIBITION_DETAIL_CA)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of TABEAN_EXHIBITION_DETAIL_CA))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New TABEAN_EXHIBITION_DETAIL_CA
        End Sub
        Public Sub insert()
            db.TABEAN_EXHIBITION_DETAIL_CAs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.TABEAN_EXHIBITION_DETAIL_CAs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.TABEAN_EXHIBITION_DETAIL_CAs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.TABEAN_EXHIBITION_DETAIL_CAs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_IDA_ORDER(ByVal IDA As Integer, ByVal FK_SET As Integer)

            datas = (From p In db.TABEAN_EXHIBITION_DETAIL_CAs Where p.IDA = IDA And p.FK_SET = FK_SET Select p Order By p.ROWS Ascending)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA_ORDER(ByVal FK_IDA As Integer, ByVal FK_SET As Integer)

            datas = (From p In db.TABEAN_EXHIBITION_DETAIL_CAs Where p.FK_IDA = FK_IDA And p.FK_SET = FK_SET Select p Order By CInt(p.ROWS) Ascending)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_ROWs_AND_FK_SET(ByVal ROWs As Integer, ByVal FK_SET As Integer)

            datas = (From p In db.TABEAN_EXHIBITION_DETAIL_CAs Where p.FK_SET = FK_SET And p.ROWS = ROWs Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_IDA_AND_ROWs(ByVal IDA As Integer, ByVal ROWs As Integer)

            datas = (From p In db.TABEAN_EXHIBITION_DETAIL_CAs Where p.IDA = IDA And p.ROWS = ROWs Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)
            datas = (From p In db.TABEAN_EXHIBITION_DETAIL_CAs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub

        Public Function COUNTDataby_FKIDA(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.TABEAN_EXHIBITION_DETAIL_CAs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
            Return i
        End Function
        Public Sub GET_MAX_ROWS_ID(ByVal FK_IDA As Integer)
            datas = (From p In db.TABEAN_EXHIBITION_DETAIL_CAs Where p.FK_IDA = FK_IDA Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_MAX_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
            datas = (From p In db.TABEAN_EXHIBITION_DETAIL_CAs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_MIN_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
            datas = (From p In db.TABEAN_EXHIBITION_DETAIL_CAs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Ascending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_TABEAN_EXH_EACH
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน
        Public fields As New TABEAN_EXH_EACH
        Public Sub insert()
            db.TABEAN_EXH_EACHes.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.TABEAN_EXH_EACHes.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.TABEAN_EXH_EACHes Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.TABEAN_EXH_EACHes Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)
            datas = (From p In db.TABEAN_EXH_EACHes Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA_AND_SET(ByVal IDA As Integer, ByVal SET_ As Integer)
            datas = (From p In db.TABEAN_EXH_EACHes Where p.FK_IDA = IDA And p.FK_SET = SET_ Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Function CountDataby_FK_IDA(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.TABEAN_EXH_EACHes Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    Public Class TB_TABEAN_EXH_EQTO
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New TABEAN_EXHIBITION_EQTO
        Private _Details As New List(Of TABEAN_EXHIBITION_EQTO)
        Public Property Details() As List(Of TABEAN_EXHIBITION_EQTO)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of TABEAN_EXHIBITION_EQTO))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New TABEAN_EXHIBITION_EQTO
        End Sub
        Public Sub insert()
            db.TABEAN_EXHIBITION_EQTOs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.TABEAN_EXHIBITION_EQTOs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.TABEAN_EXHIBITION_EQTOs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.TABEAN_EXHIBITION_EQTOs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.TABEAN_EXHIBITION_EQTOs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GET_MAX_ROWS_ID(ByVal FK_IDA As Integer)
            datas = (From p In db.TABEAN_EXHIBITION_EQTOs Where p.FK_IDA = FK_IDA Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_MAX_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
            datas = (From p In db.TABEAN_EXHIBITION_EQTOs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_TABEAN_ANALYZE_PACKING_SIZE
        Inherits MAINCONTEXT

        Public fields As New TABEAN_ANALYZE_PACKING_SIZE

        Public Sub insert()
            db.TABEAN_ANALYZE_PACKING_SIZEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_ANALYZE_PACKING_SIZEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_HERB_MANUFACTRUEs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_ANALYZE_PACKING_SIZEs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_ANALYZE_PACKING_SIZEs Where p.FK_IDA = FK_IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        'Public Sub GetdatabyID_FK_IDA_DQ2(ByVal FK_IDA As Integer)
        '    datas = From p In db.TABEAN_ANALYZE_PACKING_SIZEs Where p.FK_IDA = FK_IDA And p.ac = 1 Select p

        'End Sub
    End Class
    Public Class TB_TABEAN_DONATE_PACKING_SIZE
        Inherits MAINCONTEXT

        Public fields As New TABEAN_DONATE_PACKING_SIZE

        Public Sub insert()
            db.TABEAN_DONATE_PACKING_SIZEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_DONATE_PACKING_SIZEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_HERB_MANUFACTRUEs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_DONATE_PACKING_SIZEs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_DONATE_PACKING_SIZEs Where p.FK_IDA = FK_IDA Select p

            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_TABEAN_EXHIBITION_PACKING_SIZE
        Inherits MAINCONTEXT

        Public fields As New TABEAN_EXHIBITION_PACKING_SIZE

        Public Sub insert()
            db.TABEAN_EXHIBITION_PACKING_SIZEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_EXHIBITION_PACKING_SIZEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_EXHIBITION_PACKING_SIZEs Select p)

        End Sub

        Public Sub GetdatabyID_IDA(ByVal IDA As Integer)
            datas = From p In db.TABEAN_EXHIBITION_PACKING_SIZEs Where p.IDA = IDA Select p

            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetdatabyID_FK_IDA(ByVal FK_IDA As Integer)
            datas = From p In db.TABEAN_EXHIBITION_PACKING_SIZEs Where p.FK_IDA = FK_IDA Select p

            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_TABEAN_JJ_DETAIL_CAS
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New TABEAN_JJ_DETAIL_CA
        Private _Details As New List(Of TABEAN_JJ_DETAIL_CA)
        Public Property Details() As List(Of TABEAN_JJ_DETAIL_CA)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of TABEAN_JJ_DETAIL_CA))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New TABEAN_JJ_DETAIL_CA
        End Sub
        Public Sub insert()
            db.TABEAN_JJ_DETAIL_CAs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.TABEAN_JJ_DETAIL_CAs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.TABEAN_JJ_DETAIL_CAs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.TABEAN_JJ_DETAIL_CAs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_IDA_ORDER(ByVal IDA As Integer, ByVal FK_SET As Integer)

            datas = (From p In db.TABEAN_JJ_DETAIL_CAs Where p.IDA = IDA And p.FK_SET = FK_SET Select p Order By p.ROWS Ascending)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA_ORDER(ByVal FK_IDA As Integer, ByVal FK_SET As Integer)

            datas = (From p In db.TABEAN_JJ_DETAIL_CAs Where p.FK_IDA = FK_IDA And p.FK_SET = FK_SET Select p Order By CInt(p.ROWS) Ascending)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_ROWs_AND_FK_SET(ByVal ROWs As Integer, ByVal FK_SET As Integer)

            datas = (From p In db.TABEAN_JJ_DETAIL_CAs Where p.FK_SET = FK_SET And p.ROWS = ROWs Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_IDA_AND_ROWs(ByVal IDA As Integer, ByVal ROWs As Integer)

            datas = (From p In db.TABEAN_JJ_DETAIL_CAs Where p.IDA = IDA And p.ROWS = ROWs Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)
            datas = (From p In db.TABEAN_JJ_DETAIL_CAs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub

        Public Function COUNTDataby_FKIDA(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.TABEAN_JJ_DETAIL_CAs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
            Return i
        End Function
        Public Sub GET_MAX_ROWS_ID(ByVal FK_IDA As Integer)
            datas = (From p In db.TABEAN_JJ_DETAIL_CAs Where p.FK_IDA = FK_IDA Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_MAX_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
            datas = (From p In db.TABEAN_JJ_DETAIL_CAs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_MIN_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
            datas = (From p In db.TABEAN_JJ_DETAIL_CAs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Ascending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_MAS_TABEAN_JJ_DETAIL_CAS
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_TABEAN_JJ_DETAIL_CA
        Private _Details As New List(Of MAS_TABEAN_JJ_DETAIL_CA)
        Public Property Details() As List(Of MAS_TABEAN_JJ_DETAIL_CA)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of MAS_TABEAN_JJ_DETAIL_CA))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New MAS_TABEAN_JJ_DETAIL_CA
        End Sub
        Public Sub insert()
            db.MAS_TABEAN_JJ_DETAIL_CAs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_TABEAN_JJ_DETAIL_CAs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_TABEAN_JJ_DETAIL_CAs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_TABEAN_JJ_DETAIL_CAs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_IDA_ORDER(ByVal IDA As Integer, ByVal FK_SET As Integer)

            datas = (From p In db.MAS_TABEAN_JJ_DETAIL_CAs Where p.IDA = IDA And p.FK_SET = FK_SET Select p Order By p.ROWS Ascending)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA_ORDER(ByVal FK_IDA As Integer, ByVal FK_SET As Integer)

            datas = (From p In db.MAS_TABEAN_JJ_DETAIL_CAs Where p.FK_IDA = FK_IDA And p.FK_SET = FK_SET Select p Order By CInt(p.ROWS) Ascending)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_ROWs_AND_FK_SET(ByVal ROWs As Integer, ByVal FK_SET As Integer)

            datas = (From p In db.MAS_TABEAN_JJ_DETAIL_CAs Where p.FK_SET = FK_SET And p.ROWS = ROWs Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_IDA_AND_ROWs(ByVal IDA As Integer, ByVal ROWs As Integer)

            datas = (From p In db.MAS_TABEAN_JJ_DETAIL_CAs Where p.IDA = IDA And p.ROWS = ROWs Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FKIDA(ByVal IDA As Integer)
            datas = (From p In db.MAS_TABEAN_JJ_DETAIL_CAs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub

        Public Function COUNTDataby_FKIDA(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.MAS_TABEAN_JJ_DETAIL_CAs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
            Return i
        End Function
        Public Sub GET_MAX_ROWS_ID(ByVal FK_IDA As Integer)
            datas = (From p In db.MAS_TABEAN_JJ_DETAIL_CAs Where p.FK_IDA = FK_IDA Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_MAX_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
            datas = (From p In db.MAS_TABEAN_JJ_DETAIL_CAs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_MIN_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
            datas = (From p In db.MAS_TABEAN_JJ_DETAIL_CAs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Ascending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_TABEAN_JJ_EACH
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน
        Public fields As New TABEAN_JJ_EACH
        Public Sub insert()
            db.TABEAN_JJ_EACHes.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.TABEAN_JJ_EACHes.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.TABEAN_JJ_EACHes Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.TABEAN_JJ_EACHes Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)
            datas = (From p In db.TABEAN_JJ_EACHes Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA_AND_SET(ByVal IDA As Integer, ByVal SET_ As Integer)
            datas = (From p In db.TABEAN_JJ_EACHes Where p.FK_IDA = IDA And p.FK_SET = SET_ Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Function CountDataby_FK_IDA(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.TABEAN_JJ_EACHes Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    Public Class TB_MAS_TABEAN_JJ_EACH
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน
        Public fields As New MAS_TABEAN_JJ_EACH
        Public Sub insert()
            db.MAS_TABEAN_JJ_EACHes.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.MAS_TABEAN_JJ_EACHes.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.MAS_TABEAN_JJ_EACHes Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.MAS_TABEAN_JJ_EACHes Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)
            datas = (From p In db.MAS_TABEAN_JJ_EACHes Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA_AND_SET(ByVal IDA As Integer, ByVal SET_ As Integer)
            datas = (From p In db.MAS_TABEAN_JJ_EACHes Where p.FK_IDA = IDA And p.FK_SET = SET_ Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Function CountDataby_FK_IDA(ByVal IDA As Integer) As Integer
            Dim i As Integer = 0
            datas = (From p In db.MAS_TABEAN_JJ_EACHes Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas
                i += 1
            Next
            Return i
        End Function
    End Class
    Public Class TB_TABEAN_JJ_SUB_PACKSIZE
        Inherits MAINCONTEXT

        Public fields As New TABEAN_JJ_SUB_PACKSIZE

        Private _Details As New List(Of TABEAN_JJ_SUB_PACKSIZE)
        Public Property Details() As List(Of TABEAN_JJ_SUB_PACKSIZE)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of TABEAN_JJ_SUB_PACKSIZE))
                _Details = value
            End Set
        End Property

        Public Sub AddDetails()
            Details.Add(fields)
            fields = New TABEAN_JJ_SUB_PACKSIZE
        End Sub

        Public Sub insert()
            db.TABEAN_JJ_SUB_PACKSIZEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.TABEAN_JJ_SUB_PACKSIZEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.TABEAN_JJ_SUB_PACKSIZEs Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub

        Public Sub GetData_ByIDA(ByVal IDA As Integer)
            datas = (From p In db.TABEAN_JJ_SUB_PACKSIZEs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetData_ByDD_HERB_NAME_ID(ByVal DD_HERB_NAME_ID As Integer)
            datas = (From p In db.TABEAN_JJ_SUB_PACKSIZEs Where p.IDA = DD_HERB_NAME_ID Select p)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GetData_ByFkIDA(ByVal fk_ida As Integer)
            datas = (From p In db.TABEAN_JJ_SUB_PACKSIZEs Where p.FK_IDA = fk_ida And p.ACTIVEFACT = 1 Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
    End Class
    Public Class TB_TABEAN_JJ_EQTO
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New TABEAN_JJ_EQTO
        Private _Details As New List(Of TABEAN_JJ_EQTO)
        Public Property Details() As List(Of TABEAN_JJ_EQTO)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of TABEAN_JJ_EQTO))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New TABEAN_JJ_EQTO
        End Sub
        Public Sub insert()
            db.TABEAN_JJ_EQTOs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.TABEAN_JJ_EQTOs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.TABEAN_JJ_EQTOs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.TABEAN_JJ_EQTOs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.TABEAN_JJ_EQTOs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_HERB_NAME_PRODUCT_ID(ByVal IDA As Integer)

            datas = (From p In db.TABEAN_JJ_EQTOs Where p.FK_HERB_NAME_PRODUCT_ID = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GET_MAX_ROWS_ID(ByVal FK_IDA As Integer)
            datas = (From p In db.TABEAN_JJ_EQTOs Where p.FK_IDA = FK_IDA Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_MAX_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
            datas = (From p In db.TABEAN_JJ_EQTOs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_MAS_TABEAN_JJ_EQTO
        Inherits MAINCONTEXT 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New MAS_TABEAN_JJ_EQTO
        Private _Details As New List(Of MAS_TABEAN_JJ_EQTO)
        Public Property Details() As List(Of MAS_TABEAN_JJ_EQTO)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of MAS_TABEAN_JJ_EQTO))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New MAS_TABEAN_JJ_EQTO
        End Sub
        Public Sub insert()
            db.MAS_TABEAN_JJ_EQTOs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.MAS_TABEAN_JJ_EQTOs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.MAS_TABEAN_JJ_EQTOs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_TABEAN_JJ_EQTOs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

            datas = (From p In db.MAS_TABEAN_JJ_EQTOs Where p.FK_IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_FK_HERB_NAME_PRODUCT_ID(ByVal IDA As Integer)

            datas = (From p In db.MAS_TABEAN_JJ_EQTOs Where p.FK_HERB_NAME_PRODUCT_ID = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GET_MAX_ROWS_ID(ByVal FK_IDA As Integer)
            datas = (From p In db.MAS_TABEAN_JJ_EQTOs Where p.FK_IDA = FK_IDA Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GET_MAX_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
            datas = (From p In db.MAS_TABEAN_JJ_EQTOs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Descending Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class Mas_ASEA
        Inherits MAINCONTEXT

        Public fields As New MAS_ACCESS_SYSTEM_EDIT_ADMIN

        Public Sub insert()
            db.MAS_ACCESS_SYSTEM_EDIT_ADMINs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub Update()
            db.SubmitChanges()
        End Sub

        Public Sub Delete()
            db.MAS_ACCESS_SYSTEM_EDIT_ADMINs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetAll()
            datas = (From p In db.MAS_ACCESS_SYSTEM_EDIT_ADMINs Where p.active = True Select p)

        End Sub

        Public Sub GetDataby_iden(ByVal iden As String)
            datas = (From p In db.MAS_ACCESS_SYSTEM_EDIT_ADMINs Where p.identify = iden And p.active = True Select p).Take(1)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
End Namespace
