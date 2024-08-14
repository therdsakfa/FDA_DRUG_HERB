Public Class UC_TABEAN_EDIT_SELECT_LIST
    Inherits System.Web.UI.UserControl

    Private _CLS As New CLS_SESSION
    Private _MENU_GROUP As String = ""
    Private _IDA As String = ""
    Private _IDA_DR As String = ""
    Private _IDA_LCN As String = ""
    Private _Process_ID As String = ""
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try

        _MENU_GROUP = Request.QueryString("MENU_GROUP")
        _IDA = Request.QueryString("IDA")
        _IDA_DR = Request.QueryString("IDA_DR")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        _Process_ID = Request.QueryString("PROCESS_ID")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            get_data_tabean()
        End If
    End Sub

    Public Sub get_data_tabean()
        'Dim dao As New DAO_DRUG.ClsDBdrrqt
        'dao.GetDataby_IDA(_IDA_DR)
        Dim dao As New DAO_DRUG.ClsDBdrrgt
        Dim dao_Q As New DAO_DRUG.ClsDBdrrqt
        Dim dao_tn As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        Try
            dao.GetDataby_IDA(_IDA_DR)
            dao_Q.GetDataby_IDA(dao.fields.FK_DRRQT)
            dao_tn.GetdatabyID_FK_IDA_DQ(dao.fields.FK_DRRQT)
        Catch ex As Exception

        End Try
        'txt_rgtno.Text = dao.fields.RGTNO_NEW
        Dim full_rgtno As String = ""
        Try
            full_rgtno = dao.fields.rgttpcd & " " & Integer.Parse(Right(dao.fields.rgtno, 5)).ToString() & "/" & Left(dao.fields.rgtno, 2)
            Dim dao_ty As New DAO_DRUG.ClsDBdrdrgtype
            Try
                dao_ty.GetDataby_drgtpcd(dao.fields.drgtpcd)
                full_rgtno &= " " & dao_ty.fields.engdrgtpnm
            Catch ex As Exception

            End Try
            txt_rgtno.Text = full_rgtno
        Catch ex As Exception
            If dao_Q.fields.RGTNO_NEW = "" Then
                full_rgtno = dao.fields.rgttpcd & " " & Integer.Parse(Right(dao.fields.rgtno, 5)).ToString() & "/" & Left(dao.fields.rgtno, 2)

                Dim dao_ty As New DAO_DRUG.ClsDBdrdrgtype
                Try
                    dao_ty.GetDataby_drgtpcd(dao.fields.drgtpcd)
                    full_rgtno &= " " & dao_ty.fields.engdrgtpnm
                Catch ex2 As Exception

                End Try
                txt_rgtno.Text = full_rgtno
            Else
                txt_rgtno.Text = dao_Q.fields.RGTNO_NEW
            End If
        End Try

        'If dao.fields.RGTNO_NEW = "" Then
        '    full_rgtno = dao.fields.rgttpcd & " " & Integer.Parse(Right(dao.fields.rgtno, 5)).ToString() & "/" & Left(dao.fields.rgtno, 2)
        '    txt_rgtno.Text = full_rgtno
        'Else
        '    txt_rgtno.Text = dao.fields.RGTNO_NEW
        'End If
    End Sub
    Sub SAVE_DATA()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_CHK_LIST
        Try
            dao.GetdatabyID_FK_IDA(_IDA)
        Catch ex As Exception

        End Try
        Dim dao_edit As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST
        dao_edit.GetdatabyID_IDA(_IDA)
        dao_edit.fields.RGTNO_NEW = txt_rgtno.Text
        dao_edit.Update()
        If IsNothing(dao.fields.IDA) = False Then
            dao.fields.NAME_PRODUCT_ID = CB_NAME_PRODUCT_ID.Checked
            dao.fields.SUB_NAME_ENG = CB_NAME_ENG.Checked
            dao.fields.SUB_NAME_OTHER = CB_NAME_OTHER.Checked
            dao.fields.SUB_NAME_EXPORT = CB_NAME_EXPORT.Checked
            dao.fields.NAME_LOCATION_ID = CB_NAME_LOCATION_ID.Checked
            dao.fields.SUB_Location1_ID = CheckBox1.Checked
            dao.fields.SUB_Location2_ID = CheckBox2.Checked
            dao.fields.SUB_Location3_ID = CheckBox3.Checked
            dao.fields.PRODUCT_RECIPE_ID = CB_PRODUCT_RECIPE_ID.Checked
            dao.fields.SubProductRecipe_1 = CheckBox_SubRecipe1.Checked
            dao.fields.SubProductRecipe_1_1 = CheckBox_SubRecipe1_1.Checked
            dao.fields.SubProductRecipe_1_2 = CheckBox_SubRecipe1_2.Checked
            dao.fields.SubProductRecipe_2 = CheckBox_SubRecipe2.Checked
            dao.fields.SubProductRecipe_2_1 = CheckBox_SubRecipe2_1.Checked
            dao.fields.PRODUCTION_PROCESS_ID = CB_PRODUCTION_PROCESS_ID.Checked
            dao.fields.PROPERTIES_ID = CB_PROPERTIES_ID.Checked
            dao.fields.SIZE_USE_ID = CB_SIZE_USE_ID.Checked
            dao.fields.PREPARE_EAT_ID = CB_PREPARE_EAT_ID.Checked
            dao.fields.EAT_CONDITION_ID = CB_EAT_CONDITION_ID.Checked
            dao.fields.STORAGE_ID = CB_STORAGE_ID.Checked
            dao.fields.CONTAINER_PACKING_ID = CB_CONTAINER_PACKING_ID.Checked
            dao.fields.QUALITY_CONTROL_ID = CB_QUALITY_CONTROL_ID.Checked
            dao.fields.CER_LCN_ID = CB_CER_LCN_ID.Checked
            dao.fields.ETIQUETQ_ID = CB_ETIQUETQ_ID.Checked
            'dao.fields.PRODUCT_DOCUMENT_ID = CB_PRODUCT_DOCUMENT_ID.Checked
            dao.fields.CHANNEL_SALE_ID = CB_CHANNEL_SALE_ID.Checked
            dao.fields.FK_IDA = _IDA
            dao.insert()
        Else
            dao.fields.NAME_PRODUCT_ID = CB_NAME_PRODUCT_ID.Checked
            dao.fields.NAME_LOCATION_ID = CB_NAME_LOCATION_ID.Checked
            dao.fields.SUB_Location1_ID = CheckBox1.Checked
            dao.fields.SUB_Location2_ID = CheckBox2.Checked
            dao.fields.SUB_Location3_ID = CheckBox3.Checked
            dao.fields.PRODUCT_RECIPE_ID = CB_PRODUCT_RECIPE_ID.Checked
            dao.fields.SubProductRecipe_1 = CheckBox_SubRecipe1.Checked
            dao.fields.SubProductRecipe_1_1 = CheckBox_SubRecipe1_1.Checked
            dao.fields.SubProductRecipe_1_2 = CheckBox_SubRecipe1_2.Checked
            dao.fields.SubProductRecipe_2 = CheckBox_SubRecipe2.Checked
            dao.fields.SubProductRecipe_2_1 = CheckBox_SubRecipe2_1.Checked
            dao.fields.PRODUCTION_PROCESS_ID = CB_PRODUCTION_PROCESS_ID.Checked
            dao.fields.PROPERTIES_ID = CB_PROPERTIES_ID.Checked
            dao.fields.SIZE_USE_ID = CB_SIZE_USE_ID.Checked
            dao.fields.PREPARE_EAT_ID = CB_PREPARE_EAT_ID.Checked
            dao.fields.EAT_CONDITION_ID = CB_EAT_CONDITION_ID.Checked
            dao.fields.STORAGE_ID = CB_STORAGE_ID.Checked
            dao.fields.CONTAINER_PACKING_ID = CB_CONTAINER_PACKING_ID.Checked
            dao.fields.QUALITY_CONTROL_ID = CB_QUALITY_CONTROL_ID.Checked
            dao.fields.CER_LCN_ID = CB_CER_LCN_ID.Checked
            dao.fields.ETIQUETQ_ID = CB_ETIQUETQ_ID.Checked
            'dao.fields.PRODUCT_DOCUMENT_ID = CB_PRODUCT_DOCUMENT_ID.Checked
            dao.fields.CHANNEL_SALE_ID = CB_CHANNEL_SALE_ID.Checked
            dao.fields.FK_IDA = _IDA
            dao.Update()
        End If
    End Sub
    Sub INSERT_FILEUPLOAD(ByVal TR_ID As Integer)
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_REQUEST_CHK_LIST
        Try
            dao.GetdatabyID_FK_IDA(_IDA)
        Catch ex As Exception

        End Try
        Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_EDIT_FILEUPLOAD
        Dim dao_up2 As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
        If CB_NAME_ENG.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(1)
            dao_up2.GetdatabyID_IDA(_IDA)
            'If dao_up2.fields.IDA = 0 Then
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
            'End If
        End If
        If CB_NAME_OTHER.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(2)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If
        If CB_NAME_EXPORT.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(3)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CheckBox1.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(4)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CheckBox2.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(5)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CheckBox3.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(6)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CheckBox_SubRecipe1_1.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(11)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CheckBox_SubRecipe1_2.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(12)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CheckBox_SubRecipe2_1.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(25)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CB_PRODUCTION_PROCESS_ID.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(13)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CB_PROPERTIES_ID.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(14)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CB_SIZE_USE_ID.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(15)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CB_PREPARE_EAT_ID.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(16)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CB_EAT_CONDITION_ID.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(17)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CB_STORAGE_ID.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(18)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CB_CONTAINER_PACKING_ID.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(19)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CheckBox_SubQuality1.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(20)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If
        If CheckBox_SubQuality2.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(21)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CB_ETIQUETQ_ID.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(23)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        If CB_CHANNEL_SALE_ID.Checked = True Then
            dao_up_mas.Getdataby_IDgroup(24)
            dao_up2.GetdatabyID_IDA(_IDA)
            For Each dao_up_mas.fields In dao_up_mas.datas
                Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_EDIT_FILE
                dao_up.fields.FK_IDA = _IDA
                dao_up.fields.TYPE_ID = dao_up_mas.fields.TYPE_ID
                dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                dao_up.fields.Condition = dao_up_mas.fields.Condition
                dao_up.fields.IDcondition = dao_up_mas.fields.IDcondition
                dao_up.fields.REMARK = dao_up_mas.fields.REMARK
                dao_up.fields.IDgroup = dao_up_mas.fields.IDgroup
                dao_up.fields.SEQ = dao_up_mas.fields.SEQ
                dao_up.fields.ACTIVEFACT = dao_up_mas.fields.ACTIVEFACT
                dao_up.insert()
            Next
        End If

        Dim DT_MASUP As New DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main
        DT_MASUP = bao.SP_MAS_TABEAN_HERB_EDIT_UPLOADFILE(_IDA)
        For Each DR As DataRow In DT_MASUP.Rows
            Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
            dao_up.fields.DUCUMENT_NAME = DR("DUCUMENT_NAME")
            dao_up.fields.TR_ID = TR_ID
            dao_up.fields.FK_IDA = _IDA
            dao_up.fields.PROCESS_ID = _Process_ID
            dao_up.fields.FK_IDA_LCN = _IDA_LCN
            dao_up.fields.TYPE = 1
            dao_up.insert()
        Next
    End Sub
    Protected Sub CB_NAME_PRODUCT_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_NAME_PRODUCT_ID.CheckedChanged
        If CB_NAME_PRODUCT_ID.Checked = True Then
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_LOCATION_ID.Enabled = False
            CB_PRODUCT_RECIPE_ID.Enabled = False
            CB_PRODUCTION_PROCESS_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_SIZE_USE_ID.Enabled = False
            CB_PREPARE_EAT_ID.Enabled = False
            CB_EAT_CONDITION_ID.Enabled = False
            CB_STORAGE_ID.Enabled = False
            CB_QUALITY_CONTROL_ID.Enabled = False
            CB_CONTAINER_PACKING_ID.Enabled = False
            CB_CHANNEL_SALE_ID.Enabled = False
            DV_NAME_SL.Visible = True
        Else
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_LOCATION_ID.Enabled = True
            CB_PRODUCT_RECIPE_ID.Enabled = True
            CB_PRODUCTION_PROCESS_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_SIZE_USE_ID.Enabled = True
            CB_PREPARE_EAT_ID.Enabled = True
            CB_EAT_CONDITION_ID.Enabled = True
            CB_STORAGE_ID.Enabled = True
            CB_QUALITY_CONTROL_ID.Enabled = True
            CB_CONTAINER_PACKING_ID.Enabled = True
            CB_CHANNEL_SALE_ID.Enabled = True
            DV_NAME_SL.Visible = False
        End If
    End Sub

    Protected Sub CB_NAME_LOCATION_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_NAME_LOCATION_ID.CheckedChanged
        If CB_NAME_LOCATION_ID.Checked = True Then
            CB_ETIQUETQ_ID.Enabled = False
            CB_NAME_PRODUCT_ID.Enabled = False
            CB_PRODUCT_RECIPE_ID.Enabled = False
            CB_PRODUCTION_PROCESS_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_SIZE_USE_ID.Enabled = False
            CB_PREPARE_EAT_ID.Enabled = False
            CB_EAT_CONDITION_ID.Enabled = False
            CB_STORAGE_ID.Enabled = False
            CB_QUALITY_CONTROL_ID.Enabled = False
            CB_CONTAINER_PACKING_ID.Enabled = False
            CB_CHANNEL_SALE_ID.Enabled = False
            Div_NAME_LOCATION.Visible = True
        Else
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = True
            CB_PRODUCT_RECIPE_ID.Enabled = True
            CB_PRODUCTION_PROCESS_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_SIZE_USE_ID.Enabled = True
            CB_PREPARE_EAT_ID.Enabled = True
            CB_EAT_CONDITION_ID.Enabled = True
            CB_STORAGE_ID.Enabled = True
            CB_QUALITY_CONTROL_ID.Enabled = True
            CB_CONTAINER_PACKING_ID.Enabled = True
            CB_CHANNEL_SALE_ID.Enabled = True
            Div_NAME_LOCATION.Visible = False
        End If
    End Sub

    Protected Sub CB_PRODUCT_RECIPE_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_PRODUCT_RECIPE_ID.CheckedChanged
        If CB_PRODUCT_RECIPE_ID.Checked = True Then
            CB_ETIQUETQ_ID.Enabled = False
            CB_NAME_PRODUCT_ID.Enabled = False
            CB_NAME_LOCATION_ID.Enabled = False
            CB_PRODUCTION_PROCESS_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = False
            CB_SIZE_USE_ID.Enabled = False
            CB_PREPARE_EAT_ID.Enabled = False
            CB_EAT_CONDITION_ID.Enabled = False
            CB_STORAGE_ID.Enabled = False
            CB_QUALITY_CONTROL_ID.Enabled = False
            CB_CONTAINER_PACKING_ID.Enabled = False
            CB_CHANNEL_SALE_ID.Enabled = False
        Else
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = True
            CB_NAME_LOCATION_ID.Enabled = True
            CB_PRODUCTION_PROCESS_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = True
            CB_SIZE_USE_ID.Enabled = True
            CB_PREPARE_EAT_ID.Enabled = True
            CB_EAT_CONDITION_ID.Enabled = True
            CB_STORAGE_ID.Enabled = True
            CB_QUALITY_CONTROL_ID.Enabled = True
            CB_CONTAINER_PACKING_ID.Enabled = True
            CB_CHANNEL_SALE_ID.Enabled = True
        End If
    End Sub

    Protected Sub CB_PRODUCTION_PROCESS_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_PRODUCTION_PROCESS_ID.CheckedChanged
        If CB_PRODUCTION_PROCESS_ID.Checked = True Then
            CB_ETIQUETQ_ID.Enabled = False
            CB_NAME_PRODUCT_ID.Enabled = False
            CB_NAME_LOCATION_ID.Enabled = False
            CB_PRODUCT_RECIPE_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = False
            CB_SIZE_USE_ID.Enabled = False
            CB_PREPARE_EAT_ID.Enabled = False
            CB_EAT_CONDITION_ID.Enabled = False
            CB_STORAGE_ID.Enabled = False
            CB_QUALITY_CONTROL_ID.Enabled = False
            CB_CONTAINER_PACKING_ID.Enabled = False
            CB_CHANNEL_SALE_ID.Enabled = False
        Else
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = True
            CB_NAME_LOCATION_ID.Enabled = True
            CB_PRODUCT_RECIPE_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = True
            CB_SIZE_USE_ID.Enabled = True
            CB_PREPARE_EAT_ID.Enabled = True
            CB_EAT_CONDITION_ID.Enabled = True
            CB_STORAGE_ID.Enabled = True
            CB_QUALITY_CONTROL_ID.Enabled = True
            CB_CONTAINER_PACKING_ID.Enabled = True
            CB_CHANNEL_SALE_ID.Enabled = True
        End If
    End Sub

    Protected Sub CB_PROPERTIES_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_PROPERTIES_ID.CheckedChanged
        If CB_PROPERTIES_ID.Checked = True Then
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = False
            CB_NAME_LOCATION_ID.Enabled = False
            CB_PRODUCT_RECIPE_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_SIZE_USE_ID.Enabled = False
            CB_PREPARE_EAT_ID.Enabled = False
            CB_EAT_CONDITION_ID.Enabled = False
            CB_STORAGE_ID.Enabled = False
            CB_QUALITY_CONTROL_ID.Enabled = False
            CB_CONTAINER_PACKING_ID.Enabled = False
            CB_CHANNEL_SALE_ID.Enabled = False
        Else
            CB_ETIQUETQ_ID.Enabled = False
            CB_NAME_PRODUCT_ID.Enabled = True
            CB_NAME_LOCATION_ID.Enabled = True
            CB_PRODUCT_RECIPE_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_SIZE_USE_ID.Enabled = True
            CB_PREPARE_EAT_ID.Enabled = True
            CB_EAT_CONDITION_ID.Enabled = True
            CB_STORAGE_ID.Enabled = True
            CB_QUALITY_CONTROL_ID.Enabled = True
            CB_CONTAINER_PACKING_ID.Enabled = True
            CB_CHANNEL_SALE_ID.Enabled = True
        End If
    End Sub

    Protected Sub CB_SIZE_USE_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_SIZE_USE_ID.CheckedChanged
        If CB_SIZE_USE_ID.Checked = True Then
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = False
            CB_NAME_LOCATION_ID.Enabled = False
            CB_PRODUCT_RECIPE_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_PREPARE_EAT_ID.Enabled = False
            CB_EAT_CONDITION_ID.Enabled = False
            CB_STORAGE_ID.Enabled = False
            CB_QUALITY_CONTROL_ID.Enabled = False
            CB_CONTAINER_PACKING_ID.Enabled = False
            CB_CHANNEL_SALE_ID.Enabled = False
        Else
            CB_ETIQUETQ_ID.Enabled = False
            CB_NAME_PRODUCT_ID.Enabled = True
            CB_NAME_LOCATION_ID.Enabled = True
            CB_PRODUCT_RECIPE_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_PREPARE_EAT_ID.Enabled = True
            CB_EAT_CONDITION_ID.Enabled = True
            CB_STORAGE_ID.Enabled = True
            CB_QUALITY_CONTROL_ID.Enabled = True
            CB_CONTAINER_PACKING_ID.Enabled = True
            CB_CHANNEL_SALE_ID.Enabled = True
        End If
    End Sub

    Protected Sub CB_PREPARE_EAT_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_PREPARE_EAT_ID.CheckedChanged
        If CB_PREPARE_EAT_ID.Checked = True Then
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = False
            CB_NAME_LOCATION_ID.Enabled = False
            CB_PRODUCT_RECIPE_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_SIZE_USE_ID.Enabled = False
            CB_EAT_CONDITION_ID.Enabled = False
            CB_STORAGE_ID.Enabled = False
            CB_QUALITY_CONTROL_ID.Enabled = False
            CB_CONTAINER_PACKING_ID.Enabled = False
            CB_CHANNEL_SALE_ID.Enabled = False
        Else
            CB_ETIQUETQ_ID.Enabled = False
            CB_NAME_PRODUCT_ID.Enabled = True
            CB_NAME_LOCATION_ID.Enabled = True
            CB_PRODUCT_RECIPE_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_SIZE_USE_ID.Enabled = True
            CB_EAT_CONDITION_ID.Enabled = True
            CB_STORAGE_ID.Enabled = True
            CB_QUALITY_CONTROL_ID.Enabled = True
            CB_CONTAINER_PACKING_ID.Enabled = True
            CB_CHANNEL_SALE_ID.Enabled = True
        End If
    End Sub

    Protected Sub CB_EAT_CONDITION_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_EAT_CONDITION_ID.CheckedChanged
        If CB_EAT_CONDITION_ID.Checked = True Then
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = False
            CB_NAME_LOCATION_ID.Enabled = False
            CB_PRODUCT_RECIPE_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_SIZE_USE_ID.Enabled = False
            CB_PREPARE_EAT_ID.Enabled = False
            CB_STORAGE_ID.Enabled = False
            CB_QUALITY_CONTROL_ID.Enabled = False
            CB_CONTAINER_PACKING_ID.Enabled = False
            CB_CHANNEL_SALE_ID.Enabled = False
        Else
            CB_ETIQUETQ_ID.Enabled = False
            CB_NAME_PRODUCT_ID.Enabled = True
            CB_NAME_LOCATION_ID.Enabled = True
            CB_PRODUCT_RECIPE_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_SIZE_USE_ID.Enabled = True
            CB_PREPARE_EAT_ID.Enabled = True
            CB_STORAGE_ID.Enabled = True
            CB_QUALITY_CONTROL_ID.Enabled = True
            CB_CONTAINER_PACKING_ID.Enabled = True
            CB_CHANNEL_SALE_ID.Enabled = True
        End If
    End Sub

    Protected Sub CB_STORAGE_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_STORAGE_ID.CheckedChanged
        If CB_STORAGE_ID.Checked = True Then
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = False
            CB_NAME_LOCATION_ID.Enabled = False
            CB_PRODUCT_RECIPE_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_SIZE_USE_ID.Enabled = False
            CB_PREPARE_EAT_ID.Enabled = False
            CB_EAT_CONDITION_ID.Enabled = False
            CB_QUALITY_CONTROL_ID.Enabled = False
            CB_CONTAINER_PACKING_ID.Enabled = False
            CB_CHANNEL_SALE_ID.Enabled = False
        Else
            CB_ETIQUETQ_ID.Enabled = False
            CB_NAME_PRODUCT_ID.Enabled = True
            CB_NAME_LOCATION_ID.Enabled = True
            CB_PRODUCT_RECIPE_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_SIZE_USE_ID.Enabled = True
            CB_PREPARE_EAT_ID.Enabled = True
            CB_EAT_CONDITION_ID.Enabled = True
            CB_QUALITY_CONTROL_ID.Enabled = True
            CB_CONTAINER_PACKING_ID.Enabled = True
            CB_CHANNEL_SALE_ID.Enabled = True
        End If
    End Sub

    Protected Sub CB_CONTAINER_PACKING_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_CONTAINER_PACKING_ID.CheckedChanged
        If CB_CONTAINER_PACKING_ID.Checked = True Then
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = False
            CB_NAME_LOCATION_ID.Enabled = False
            CB_PRODUCT_RECIPE_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_SIZE_USE_ID.Enabled = False
            CB_PREPARE_EAT_ID.Enabled = False
            CB_EAT_CONDITION_ID.Enabled = False
            CB_QUALITY_CONTROL_ID.Enabled = False
            CB_STORAGE_ID.Enabled = False
            CB_CHANNEL_SALE_ID.Enabled = False
        Else
            CB_ETIQUETQ_ID.Enabled = False
            CB_NAME_PRODUCT_ID.Enabled = True
            CB_NAME_LOCATION_ID.Enabled = True
            CB_PRODUCT_RECIPE_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_SIZE_USE_ID.Enabled = True
            CB_PREPARE_EAT_ID.Enabled = True
            CB_EAT_CONDITION_ID.Enabled = True
            CB_QUALITY_CONTROL_ID.Enabled = True
            CB_STORAGE_ID.Enabled = True
            CB_CHANNEL_SALE_ID.Enabled = True
        End If
    End Sub

    Protected Sub CB_QUALITY_CONTROL_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_QUALITY_CONTROL_ID.CheckedChanged
        If CB_QUALITY_CONTROL_ID.Checked = True Then
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = False
            CB_NAME_LOCATION_ID.Enabled = False
            CB_PRODUCT_RECIPE_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_SIZE_USE_ID.Enabled = False
            CB_PREPARE_EAT_ID.Enabled = False
            CB_EAT_CONDITION_ID.Enabled = False
            CB_CONTAINER_PACKING_ID.Enabled = False
            CB_STORAGE_ID.Enabled = False
            CB_CHANNEL_SALE_ID.Enabled = False
        Else
            CB_ETIQUETQ_ID.Enabled = False
            CB_NAME_PRODUCT_ID.Enabled = True
            CB_NAME_LOCATION_ID.Enabled = True
            CB_PRODUCT_RECIPE_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_SIZE_USE_ID.Enabled = True
            CB_PREPARE_EAT_ID.Enabled = True
            CB_EAT_CONDITION_ID.Enabled = True
            CB_CONTAINER_PACKING_ID.Enabled = True
            CB_STORAGE_ID.Enabled = True
            CB_CHANNEL_SALE_ID.Enabled = True
        End If
    End Sub

    Protected Sub CB_CER_LCN_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_CER_LCN_ID.CheckedChanged

    End Sub

    Protected Sub CB_ETIQUETQ_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_ETIQUETQ_ID.CheckedChanged
        If CB_ETIQUETQ_ID.Checked = True Then
            'CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = False
            CB_NAME_LOCATION_ID.Enabled = False
            CB_PRODUCT_RECIPE_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_SIZE_USE_ID.Enabled = False
            CB_PREPARE_EAT_ID.Enabled = False
            CB_EAT_CONDITION_ID.Enabled = False
            CB_QUALITY_CONTROL_ID.Enabled = False
            CB_STORAGE_ID.Enabled = False
            CB_CHANNEL_SALE_ID.Enabled = False
        Else
            'CB_ETIQUETQ_ID.Enabled = False
            CB_NAME_PRODUCT_ID.Enabled = True
            CB_NAME_LOCATION_ID.Enabled = True
            CB_PRODUCT_RECIPE_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_SIZE_USE_ID.Enabled = True
            CB_PREPARE_EAT_ID.Enabled = True
            CB_EAT_CONDITION_ID.Enabled = True
            CB_QUALITY_CONTROL_ID.Enabled = True
            CB_STORAGE_ID.Enabled = True
            CB_CHANNEL_SALE_ID.Enabled = True
        End If
    End Sub
    Protected Sub CB_CHANNEL_SALE_ID_CheckedChanged(sender As Object, e As EventArgs) Handles CB_CHANNEL_SALE_ID.CheckedChanged
        If CB_CHANNEL_SALE_ID.Checked = True Then
            CB_ETIQUETQ_ID.Enabled = True
            CB_NAME_PRODUCT_ID.Enabled = False
            CB_NAME_LOCATION_ID.Enabled = False
            CB_PRODUCT_RECIPE_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_PROPERTIES_ID.Enabled = False
            CB_SIZE_USE_ID.Enabled = False
            CB_PREPARE_EAT_ID.Enabled = False
            CB_EAT_CONDITION_ID.Enabled = False
            CB_QUALITY_CONTROL_ID.Enabled = False
            CB_CONTAINER_PACKING_ID.Enabled = False
            CB_STORAGE_ID.Enabled = False
            CB_CHANNEL_SALE_ID.Enabled = False
        Else
            CB_ETIQUETQ_ID.Enabled = False
            CB_NAME_PRODUCT_ID.Enabled = True
            CB_NAME_LOCATION_ID.Enabled = True
            CB_PRODUCT_RECIPE_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_PROPERTIES_ID.Enabled = True
            CB_SIZE_USE_ID.Enabled = True
            CB_PREPARE_EAT_ID.Enabled = True
            CB_EAT_CONDITION_ID.Enabled = True
            CB_QUALITY_CONTROL_ID.Enabled = True
            CB_CONTAINER_PACKING_ID.Enabled = True
            CB_STORAGE_ID.Enabled = True
            CB_CHANNEL_SALE_ID.Enabled = True
        End If
    End Sub
    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub

    Protected Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged

    End Sub
    Protected Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged

    End Sub
End Class