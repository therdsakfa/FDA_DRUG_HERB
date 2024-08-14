Public Class WebForm39
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub BTN_GEN_XML_JJ1_Click(sender As Object, e As EventArgs) Handles BTN_GEN_XML_JJ1.Click
        Dim log As New DAO_TABEAN_HERB.TB_LOG_GEN_XML
        Dim IDA As Integer = txt_IDA_jj.Text
        Dim iden As String = txt_iden_jj.Text
        Dim LCN_IDA As Integer = txt_IDA_LCN_JJ.Text
        Dim TR_ID As Integer = txt_tr_id_jj.Text
        Dim DES As String = txt_detail_jj.Text
        Dim PROCESS_ID As Integer = txt_PROCESS_ID_JJ.Text
        Try

            Dim bao_app As New BAO.AppSettings
            bao_app.RunAppSettings()

            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
            Try
                dao.GetdatabyID_IDA_LCN_ID_AND_TR_ID(IDA, TR_ID, LCN_IDA)
            Catch ex As Exception
                dao.GetdatabyID_IDA(IDA)
            End Try
            'dao.GetdatabyID_IDA(IDA)

            Dim XML As New CLASS_GEN_XML.TABEAN_HERB_JJ
            TB_JJ = XML.gen_xml(IDA, LCN_IDA)

            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(dao.fields.DDHERB, dao.fields.STATUS_ID, "จจ1", 0)

            Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ") 'path
            Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_JJ1\" & dao_pdftemplate.fields.PDF_TEMPLATE
            Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_JJ("HB_PDF", dao.fields.DDHERB, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, IDA, dao.fields.STATUS_ID)
            Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_JJ("HB_XML", dao.fields.DDHERB, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, IDA, dao.fields.STATUS_ID)

            LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, dao.fields.DDHERB, PATH_PDF_OUTPUT)


            log.fields.FK_IDA = IDA
            log.fields.IDENTIFY = iden
            log.fields.LCN_IDA = LCN_IDA
            log.fields.TR_ID = TR_ID
            log.fields.PROCESS_ID = PROCESS_ID
            log.fields.DESCRIPTION = DES
            log.fields.SUBMIT_DATE = Date.Now
            log.fields.log_btn = BTN_GEN_XML_JJ1.Text
            log.fields.log_error = "SUCCESS"
            log.insert()
            alert("SUCCESS")
        Catch ex As Exception
            Dim ex_txt As String = ""
            log.fields.FK_IDA = IDA
            log.fields.IDENTIFY = iden
            log.fields.LCN_IDA = LCN_IDA
            log.fields.TR_ID = TR_ID
            log.fields.PROCESS_ID = PROCESS_ID
            log.fields.DESCRIPTION = DES
            log.fields.SUBMIT_DATE = Date.Now
            log.fields.log_btn = BTN_GEN_XML_JJ1.Text
            log.fields.log_error = ex_txt
            log.insert()
            ex_txt = ex.Message
            alert("เกิดข้อผิดพลาด")
        End Try

    End Sub

    Protected Sub BTN_GEN_XML_JJ2_Click(sender As Object, e As EventArgs) Handles BTN_GEN_XML_JJ2.Click
        Dim log As New DAO_TABEAN_HERB.TB_LOG_GEN_XML
        Dim IDA As Integer = txt_IDA_jj.Text
        Dim iden As String = txt_iden_jj.Text
        Dim LCN_IDA As Integer = txt_IDA_LCN_JJ.Text
        Dim TR_ID As Integer = txt_tr_id_jj.Text
        Dim DES As String = txt_detail_jj.Text
        Dim PROCESS_ID As Integer = txt_PROCESS_ID_JJ.Text
        Try
            Dim bao_app As New BAO.AppSettings
            bao_app.RunAppSettings()

            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
            dao.GetdatabyID_IDA(IDA)

            Dim XML As New CLASS_GEN_XML.TABEAN_HERB_JJ
            TB_JJ = XML.gen_xml_2(IDA, LCN_IDA)

            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(PROCESS_ID, dao.fields.STATUS_ID, "จจ2", 0)

            Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ") 'path
            Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_JJ2\" & dao_pdftemplate.fields.PDF_TEMPLATE
            Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_JJ("HB_PDF", PROCESS_ID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, IDA, dao.fields.STATUS_ID)
            Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_JJ("HB_XML", PROCESS_ID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, IDA, dao.fields.STATUS_ID)

            LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, PROCESS_ID, PATH_PDF_OUTPUT)


            log.fields.FK_IDA = IDA
            log.fields.IDENTIFY = iden
            log.fields.LCN_IDA = LCN_IDA
            log.fields.TR_ID = TR_ID
            log.fields.PROCESS_ID = PROCESS_ID
            log.fields.DESCRIPTION = DES
            log.fields.SUBMIT_DATE = Date.Now
            log.fields.log_btn = BTN_GEN_XML_JJ2.Text
            log.fields.log_error = "SUCCESS"
            log.insert()
            alert("SUCCESS")
        Catch ex As Exception
            Dim ex_txt As String = ""
            log.fields.FK_IDA = IDA
            log.fields.IDENTIFY = iden
            log.fields.LCN_IDA = LCN_IDA
            log.fields.TR_ID = TR_ID
            log.fields.PROCESS_ID = PROCESS_ID
            log.fields.DESCRIPTION = DES
            log.fields.SUBMIT_DATE = Date.Now
            log.fields.log_btn = BTN_GEN_XML_JJ2.Text
            log.fields.log_error = ex_txt
            log.insert()
            ex_txt = ex.Message
            alert("เกิดข้อผิดพลาด")
        End Try
    End Sub
    Protected Sub BTN_GEN_XML_JJ3_Click(sender As Object, e As EventArgs) Handles BTN_GEN_XML_JJ3.Click
        Dim log As New DAO_TABEAN_HERB.TB_LOG_GEN_XML
        Dim IDA As Integer = txt_IDA_jj.Text
        Dim iden As String = txt_iden_jj.Text
        Dim LCN_IDA As Integer = txt_IDA_LCN_JJ.Text
        Dim TR_ID As Integer = txt_tr_id_jj.Text
        Dim DES As String = txt_detail_jj.Text
        Dim PROCESS_ID As Integer = txt_PROCESS_ID_JJ.Text
        Try
            Dim bao_app As New BAO.AppSettings
            bao_app.RunAppSettings()

            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ_EDIT_REQUEST
            dao.GetdatabyID_IDA(IDA)

            Dim XML As New CLASS_GEN_XML.TABEAN_HERB_JJ_EDIT
            TB_JJ_EDIT = XML.Gen_XML_JJ3_Edit(IDA, LCN_IDA)

            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(PROCESS_ID, dao.fields.STATUS_ID, "จจ3", 0)

            Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ_EDIT") 'path
            Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TEMPLATE\" & dao_pdftemplate.fields.PDF_TEMPLATE
            Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_JJ("HB_PDF", PROCESS_ID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, IDA, dao.fields.STATUS_ID)
            Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_JJ("HB_XML", PROCESS_ID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, IDA, dao.fields.STATUS_ID)

            LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, PROCESS_ID, PATH_PDF_OUTPUT)

            log.fields.FK_IDA = IDA
            log.fields.IDENTIFY = iden
            log.fields.LCN_IDA = LCN_IDA
            log.fields.TR_ID = TR_ID
            log.fields.PROCESS_ID = PROCESS_ID
            log.fields.DESCRIPTION = DES
            log.fields.SUBMIT_DATE = Date.Now
            log.fields.log_btn = BTN_GEN_XML_JJ2.Text
            log.fields.log_error = "SUCCESS"
            log.insert()
            alert("SUCCESS")
        Catch ex As Exception
            Dim ex_txt As String = ""
            log.fields.FK_IDA = IDA
            log.fields.IDENTIFY = iden
            log.fields.LCN_IDA = LCN_IDA
            log.fields.TR_ID = TR_ID
            log.fields.PROCESS_ID = PROCESS_ID
            log.fields.DESCRIPTION = DES
            log.fields.SUBMIT_DATE = Date.Now
            log.fields.log_btn = BTN_GEN_XML_JJ2.Text
            log.fields.log_error = ex_txt
            log.insert()
            ex_txt = ex.Message
            alert("เกิดข้อผิดพลาด")
        End Try
    End Sub
    Private Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ")
    End Sub
    Public Function insert_LOG_XML(ByVal IDA As Integer, ByVal LCN_IDA As Integer, ByVal PROCESS_ID As Integer, ByVal TR_ID As Integer, ByVal DES As String, ByVal iden As String, ByVal btn_name As String, ByVal mg_error As String) As Integer
        Dim log As New DAO_TABEAN_HERB.TB_LOG_GEN_XML
        log.fields.FK_IDA = IDA
        log.fields.IDENTIFY = iden
        log.fields.LCN_IDA = LCN_IDA
        log.fields.TR_ID = TR_ID
        log.fields.PROCESS_ID = PROCESS_ID
        log.fields.DESCRIPTION = DES
        log.fields.SUBMIT_DATE = Date.Now
        log.fields.log_btn = btn_name
        log.fields.log_error = mg_error
        log.insert() 'ปรับเป็น update
        Return log.fields.IDA

    End Function

    Protected Sub BTN_GEN_XML_TBN1_Click(sender As Object, e As EventArgs) Handles BTN_GEN_XML_TBN1.Click
        Dim log As New DAO_TABEAN_HERB.TB_LOG_GEN_XML
        Dim IDA As Integer = txt_IDA_TBN.Text
        Dim iden As String = txt_iden_TBN.Text
        Dim LCN_IDA As Integer = txt_IDA_LCN_TBN.Text
        Dim IDA_DQ As Integer = txt_IDA_TBN.Text
        Dim TR_ID As Integer = txt_tr_id_TBN.Text
        Dim DES As String = txt_detail_TBN.Text
        Dim PROCESS_ID As Integer = txt_PROCESS_ID_TBN.Text
        Dim BTN_NAME As String = BTN_GEN_XML_TBN1.Text
        Dim ex_Message As String = ""
        Try
            Dim bao_app As New BAO.AppSettings
            bao_app.RunAppSettings()

            Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
            dao_deeqt.GetDataby_IDA(IDA)

            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
            dao.GetdatabyID_FK_IDA_DQ(IDA)

            Dim XML As New CLASS_GEN_XML.TABEAN_HERB_TBN
            TBN_NEW = XML.gen_xml_tbn(dao.fields.IDA, IDA_DQ, LCN_IDA)

            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(PROCESS_ID, dao_deeqt.fields.STATUS_ID, "ทบ1", 0)

            Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path
            Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TBN_1\" & dao_pdftemplate.fields.PDF_TEMPLATE
            Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", PROCESS_ID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, IDA, dao_deeqt.fields.STATUS_ID)
            Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TBN("HB_XML", PROCESS_ID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, IDA, dao_deeqt.fields.STATUS_ID)

            LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, PROCESS_ID, PATH_PDF_OUTPUT)
            insert_LOG_XML(IDA, LCN_IDA, PROCESS_ID, TR_ID, DES, iden, BTN_NAME, "SUCCESS")
        Catch ex As Exception
            ex_Message = ex.Message
            insert_LOG_XML(IDA, LCN_IDA, PROCESS_ID, TR_ID, DES, iden, BTN_NAME, ex_Message)
            alert("เกิดข้อผิดพลาด")
        End Try

    End Sub

    Protected Sub BTN_GEN_XML_TBN2_Click(sender As Object, e As EventArgs) Handles BTN_GEN_XML_TBN2.Click
        Dim log As New DAO_TABEAN_HERB.TB_LOG_GEN_XML
        Dim IDA As Integer = txt_IDA_TBN.Text
        Dim iden As String = txt_iden_TBN.Text
        Dim LCN_IDA As Integer = txt_IDA_LCN_TBN.Text
        Dim IDA_DQ As Integer = txt_IDA_TBN.Text
        Dim TR_ID As Integer = txt_tr_id_TBN.Text
        Dim DES As String = txt_detail_TBN.Text
        Dim PROCESS_ID As Integer = txt_PROCESS_ID_TBN.Text
        Dim BTN_NAME As String = BTN_GEN_XML_TBN2.Text
        Dim ex_Message As String = ""
        Try
            Dim bao_app As New BAO.AppSettings
            bao_app.RunAppSettings()

            Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
            dao_deeqt.GetDataby_IDA(IDA_DQ)

            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
            dao.GetdatabyID_FK_IDA_DQ(IDA_DQ)

            Dim XML As New CLASS_GEN_XML.TABEAN_HERB_TBN
            TBN_NEW = XML.gen_xml_tbn_2(dao.fields.IDA, IDA_DQ, LCN_IDA)

            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(PROCESS_ID, dao_deeqt.fields.STATUS_ID, "ทบ2", 0)


            Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path
            Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TBN_2\" & dao_pdftemplate.fields.PDF_TEMPLATE
            Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", PROCESS_ID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, IDA_DQ, dao_deeqt.fields.STATUS_ID)
            Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TBN("HB_XML", PROCESS_ID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, IDA_DQ, dao_deeqt.fields.STATUS_ID)

            LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, PROCESS_ID, PATH_PDF_OUTPUT)
            insert_LOG_XML(IDA, LCN_IDA, PROCESS_ID, TR_ID, DES, iden, BTN_NAME, "SUCCESS")
        Catch ex As Exception
            ex_Message = ex.Message
            insert_LOG_XML(IDA, LCN_IDA, PROCESS_ID, TR_ID, DES, iden, BTN_NAME, ex_Message)
            alert("เกิดข้อผิดพลาด")
        End Try
    End Sub

    Protected Sub BTN_GEN_XML_JJ2_L_Click(sender As Object, e As EventArgs) Handles BTN_GEN_XML_JJ2_L.Click
        Dim log As New DAO_TABEAN_HERB.TB_LOG_GEN_XML
        Dim IDA As Integer = txt_IDA_jj.Text
        Dim iden As String = txt_iden_jj.Text
        Dim LCN_IDA As Integer = txt_IDA_LCN_JJ.Text
        Dim TR_ID As Integer = txt_tr_id_jj.Text
        Dim DES As String = txt_detail_jj.Text
        Dim PROCESS_ID As Integer = txt_PROCESS_ID_JJ.Text
        Try

            Dim bao_app As New BAO.AppSettings
            bao_app.RunAppSettings()

            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
            dao.GetdatabyID_IDA(IDA)

            Dim XML As New CLASS_GEN_XML.TABEAN_HERB_JJ
            TB_JJ = XML.gen_xml_2(IDA, LCN_IDA)

            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GETDATA_TABEAN_HERB_JJ_TEMPLAETE1(PROCESS_ID, dao.fields.STATUS_ID, "จจ2", 1)

            Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ") 'path
            Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_JJ2\" & dao_pdftemplate.fields.PDF_TEMPLATE
            Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_JJ("HB_PDF", PROCESS_ID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, IDA, dao.fields.STATUS_ID)
            Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_JJ("HB_XML", PROCESS_ID, dao.fields.DATE_YEAR, dao.fields.TR_ID_JJ, IDA, dao.fields.STATUS_ID)

            LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, PROCESS_ID, PATH_PDF_OUTPUT)

            log.fields.FK_IDA = IDA
            log.fields.IDENTIFY = iden
            log.fields.LCN_IDA = LCN_IDA
            log.fields.TR_ID = TR_ID
            log.fields.PROCESS_ID = PROCESS_ID
            log.fields.DESCRIPTION = DES
            log.fields.SUBMIT_DATE = Date.Now
            log.fields.log_btn = BTN_GEN_XML_JJ2_L.Text
            log.insert()
            alert("SUCCESS")
        Catch ex As Exception
            Dim ex_txt As String = ""
            log.fields.FK_IDA = IDA
            log.fields.IDENTIFY = iden
            log.fields.LCN_IDA = LCN_IDA
            log.fields.TR_ID = TR_ID
            log.fields.PROCESS_ID = PROCESS_ID
            log.fields.DESCRIPTION = DES
            log.fields.SUBMIT_DATE = Date.Now
            log.fields.log_btn = BTN_GEN_XML_JJ2_L.Text
            log.fields.log_error = ex_txt
            log.insert()
            ex_txt = ex.Message
            alert("เกิดข้อผิดพลาด")
        End Try
    End Sub

    Protected Sub BTN_GEN_XML_TBN2_L_Click(sender As Object, e As EventArgs) Handles BTN_GEN_XML_TBN2_L.Click
        Dim log As New DAO_TABEAN_HERB.TB_LOG_GEN_XML
        Dim IDA As Integer = txt_IDA_TBN.Text
        Dim iden As String = txt_iden_TBN.Text
        Dim LCN_IDA As Integer = txt_IDA_LCN_TBN.Text
        Dim IDA_DQ As Integer = txt_IDA_TBN.Text
        Dim TR_ID As Integer = txt_tr_id_TBN.Text
        Dim DES As String = txt_detail_TBN.Text
        Dim PROCESS_ID As Integer = txt_PROCESS_ID_TBN.Text
        Dim BTN_NAME As String = BTN_GEN_XML_TBN2_L.Text
        Dim ex_Message As String = ""
        Try
            Dim bao_app As New BAO.AppSettings
            bao_app.RunAppSettings()

            Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
            dao_deeqt.GetDataby_IDA(IDA_DQ)

            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
            dao.GetdatabyID_FK_IDA_DQ(IDA_DQ)

            Dim XML As New CLASS_GEN_XML.TABEAN_HERB_TBN
            TBN_NEW = XML.gen_xml_tbn_2(dao.fields.IDA, IDA_DQ, LCN_IDA)

            Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
            dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(PROCESS_ID, dao_deeqt.fields.STATUS_ID, "ทบ2", 1)


            Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path
            Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TBN_2\" & dao_pdftemplate.fields.PDF_TEMPLATE
            Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", PROCESS_ID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, IDA_DQ, dao_deeqt.fields.STATUS_ID)
            Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TBN("HB_XML", PROCESS_ID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, IDA_DQ, dao_deeqt.fields.STATUS_ID)

            LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, PROCESS_ID, PATH_PDF_OUTPUT)
            insert_LOG_XML(IDA, LCN_IDA, PROCESS_ID, TR_ID, DES, iden, BTN_NAME, "SUCCESS")
        Catch ex As Exception
            ex_Message = ex.Message
            insert_LOG_XML(IDA, LCN_IDA, PROCESS_ID, TR_ID, DES, iden, BTN_NAME, ex_Message)
            alert("เกิดข้อผิดพลาด")
        End Try
    End Sub
    Protected Sub BTN_SWPM_CF_Click(sender As Object, e As EventArgs) Handles BTN_SWPM_CF.Click
        Dim log As New DAO_TABEAN_HERB.TB_LOG_GEN_XML
        Dim IDA As Integer = SWPM_IDA.Text
        Dim iden As String = SWPM_IDEN.Text
        Dim PROCESS_ID As Integer = SWPM_PROCESS.Text
        Dim REF01 As String = SWPM_REF01.Text
        Dim REF02 As String = SWPM_REF02.Text
        Dim BTN_NAME As String = BTN_SWPM_CF.Text
        Dim DETAIL As String = SWPM_DETAIL.Text
        Dim sw As New SW_HERB_PAYMENT.SW_LCN_EDIT_PAYMENT
        Dim ex_Message As String = ""
        Try
            sw.HERB_PAYMENT(IDA, PROCESS_ID, REF01, REF02)

            insert_LOG_XML(IDA, 0, PROCESS_ID, 0, DETAIL, iden, BTN_NAME, "SUCCESS")
        Catch ex As Exception
            ex_Message = ex.Message
            insert_LOG_XML(IDA, 0, PROCESS_ID, 0, DETAIL, iden, BTN_NAME, ex_Message)
            alert("เกิดข้อผิดพลาด")
        End Try

    End Sub

    Protected Sub BTN_Q_To_G_Click(sender As Object, e As EventArgs) Handles BTN_Q_To_G.Click
        Try
            Dim bao_insert As New BAO.ClsDBSqlcommand
            bao_insert.Insert_Tabean_Sub_New(Txt_IDA_QT.Text)
            alert("SUCCESS")
        Catch ex As Exception
            alert("เกิดข้อผิดพลาด")
        End Try
    End Sub
    Protected Sub BTN_JJ_TO_124_Click(sender As Object, e As EventArgs) Handles BTN_JJ_TO_124.Click
        Try
            Dim bao As New BAO.ClsDBSqlcommand
            bao.SP_DRUG_HERB_PRODUCT_JJHERB(txt_IDA_JJ_To_124.Text)
            alert("SUCCESS")
        Catch ex As Exception
            alert("เกิดข้อผิดพลาด")
        End Try
    End Sub

    Protected Sub BTN_GEN_XML124_Click(sender As Object, e As EventArgs) Handles BTN_GEN_XML124.Click
        Try
            Dim pvncd As String = PVN_CD.Text
            Dim rgttpcd As String = RGTTP_CD.Text
            Dim drgtpcd As String = DRGTP_CD.Text
            Dim rgtno As String = RGT_NO.Text
            Dim remark As String = REMARK_TXT.Text
            Dim iden_edit As String = IDEN_TXT.Text
            Dim system As String = "HERB"

            Dim ws_drug As New WS_DRUG.WS_DRUG
            ws_drug.HERB_UPDATE_XML_PRODUCT(pvncd, rgttpcd, drgtpcd, rgtno, remark, iden_edit, system)
            alert("SUCCESS")
        Catch ex As Exception
            alert("เกิดข้อผิดพลาด")
        End Try

    End Sub

    Protected Sub BTN_CREATE_FILE_JJ_Click(sender As Object, e As EventArgs) Handles BTN_CREATE_FILE_JJ.Click
        Dim IDA As Integer = IDA_JJ.Text
        Dim IDENTIFY As String = IDEN_JJ.Text
        'Dim TR_ID As Integer = TR_ID_JJ.Text
        Dim PROCESS_ID As Integer = PROCESS_JJ.Text
        Try
            Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
            dao.GetdatabyID_IDA(IDA)
            Dim TR_ID As Integer = dao.fields.TR_ID_JJ
            Dim IDA_LCN As Integer = dao.fields.IDA_LCN
            Dim dao_upc As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
            dao_upc.GetdatabyID_TR_ID_FK_IDA_PROCESS_ID(TR_ID, IDA, PROCESS_ID)
            If dao_upc.fields.IDA = 0 Then
                Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
                dao_up_mas.GetdatabyID_TYPE(1)
                For Each dao_up_mas.fields In dao_up_mas.datas
                    Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                    dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                    dao_up.fields.TR_ID = TR_ID
                    dao_up.fields.FK_IDA = dao.fields.IDA
                    dao_up.fields.PROCESS_ID = PROCESS_ID
                    dao_up.fields.FK_IDA_LCN = IDA_LCN
                    dao_up.fields.TYPE = 1
                    dao_up.insert()
                Next

                Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri
                Dim log As New DAO_DRUG.TB_LOG_EDIT_MIGRATE
                log.fields.CREATEDATE = Date.Now
                log.fields.CITIZEN_ID = IDENTIFY
                log.fields.ACTION_DESCRIPTION = "เพิ่มแนบไฟล์ระบบจดแจ้ง " & REMARK_JJ.Text
                log.fields.FK_IDA = IDA
                log.fields.URL = url
                log.insert()
                alert("SUCCESS")
            Else
                alert("มีไฟล์แนบของคำข้อนี้อยู่แล้ว")
            End If
        Catch ex As Exception
            alert("เกิดข้อผิดพลาด")
        End Try
    End Sub

    Protected Sub BTN_CREATE_FILE_JJ_ALL_Click(sender As Object, e As EventArgs) Handles BTN_CREATE_FILE_JJ_ALL.Click
        Try
            Dim bao As New BAO.ClsDBSqlcommand
            Dim dt As New DataTable
            dt = bao.SP_TABEAN_JJ_NO_UP()
            Dim IDA As Integer = 0
            Dim PROCESS_ID As String = 0
            Dim IDENTIFY As String = IDEN_JJ.Text
            For Each dr As DataRow In dt.Rows
                IDA = dr("IDA")
                PROCESS_ID = dr("DDHERB")
                Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_JJ
                dao.GetdatabyID_IDA(IDA)
                Dim TR_ID As Integer = dao.fields.TR_ID_JJ
                Dim IDA_LCN As Integer = dao.fields.IDA_LCN
                Dim dao_upc As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                dao_upc.GetdatabyID_TR_ID_FK_IDA_PROCESS_ID(TR_ID, IDA, PROCESS_ID)
                If dao_upc.fields.IDA = 0 Then
                    Dim dao_up_mas As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_UPLOADFILE_JJ
                    dao_up_mas.GetdatabyID_TYPE(1)
                    For Each dao_up_mas.fields In dao_up_mas.datas
                        Dim dao_up As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
                        dao_up.fields.DUCUMENT_NAME = dao_up_mas.fields.DUCUMENT_NAME
                        dao_up.fields.TR_ID = TR_ID
                        dao_up.fields.FK_IDA = dao.fields.IDA
                        dao_up.fields.PROCESS_ID = PROCESS_ID
                        dao_up.fields.FK_IDA_LCN = IDA_LCN
                        dao_up.fields.TYPE = 1
                        dao_up.insert()
                    Next

                    Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri
                    Dim log As New DAO_DRUG.TB_LOG_EDIT_MIGRATE
                    log.fields.CREATEDATE = Date.Now
                    log.fields.CITIZEN_ID = IDENTIFY
                    log.fields.ACTION_DESCRIPTION = "เพิ่มแนบไฟล์ระบบจดแจ้ง " & REMARK_JJ.Text
                    log.fields.FK_IDA = IDA
                    log.fields.URL = url
                    log.insert()
                    alert("SUCCESS")
                Else
                    alert("มีไฟล์แนบของคำข้อนี้อยู่แล้ว")
                End If
            Next
            alert("SUCCESS")
        Catch ex As Exception
            alert("เกิดข้อผิดพลาด")
        End Try
    End Sub

    Protected Sub BTN_GEN_XMLSMP3_Click(sender As Object, e As EventArgs) Handles BTN_GEN_XMLSMP3.Click
        Dim Identify As String = SMP3_IDEN_TXT.Text
        Dim TR_ID As String = SMP3_TR_ID.Text
        Dim DES As String = SMP3_REMARK_TXT.Text
        Dim dao_update As New DAO_LCN.TB_LCN_APPROVE_EDIT
        Dim ex_Message As String
        Dim IDA As Integer
        Dim LCN_IDA As Integer
        Dim PROCESS_ID As Integer
        Dim BTN_NAME As String = BTN_GEN_XML_TBN1.Text
        Try
            dao_update.GetDataby_TR_ID(TR_ID, True)
            LCN_IDA = dao_update.fields.FK_LCN_IDA
            'Dim dao_lcn As New DAO_DRUG.ClsDBdalcn

            'dao_lcn.GetDataby_IDA(LCN_IDA)
            'Dim PVNCD As Integer = 0
            'Try
            '    PVNCD = dao_lcn.fields.pvncd
            'Catch ex As Exception

            'End Try
            ''เลขรับคำขอ รันใหม่
            'Dim RQ_NUM As Integer = 0

            'Dim bao_gen As New BAO.GenNumber

            'RQ_NUM = GEN_NO_INTAKE(con_year(Date.Now.Year), dao_update.fields.LCN_PROCESS_ID, LCN_IDA)
            ''RQ_NUM = insert_transection_lcn_edit(_ProcessID, _LCN_IDA)

            'Dim RQ_YEAR As String = con_year(Date.Now().Year()).Substring(2, 2)



            'PROCESS_ID = 10201
            ''รันเลขรับคำขอ EX* HB 10-10201-64-1
            ''Dim RCVNO_FULL As String = "HB" & " " & dao.fields.PVNCD & "-" & _ProcessID & "-" & DATE_YEAR & "-" & RUN_ID

            'dao_update.fields.STAFF_RQ_NUMBER = "HB " & PVNCD & "-" & PROCESS_ID.ToString & "-" & RQ_YEAR & "-" & RQ_NUM.ToString

            IDA = dao_update.fields.IDA
            PROCESS_ID = dao_update.fields.LCN_PROCESS_ID
            'dao_update.update()
            bind_pdf_xml_11(dao_update.fields.IDA, dao_update.fields.FK_LCN_IDA, dao_update.fields.LCN_PROCESS_ID, dao_update.fields.STATUS_ID, dao_update.fields.DATE_YEAR, dao_update.fields.TR_ID)
            insert_LOG_XML(IDA, LCN_IDA, PROCESS_ID, TR_ID, DES, Identify, BTN_NAME, "SUCCESS")
            alert("SUCCESS")
        Catch ex As Exception
            ex_Message = ex.Message
            insert_LOG_XML(IDA, LCN_IDA, PROCESS_ID, TR_ID, DES, Identify, BTN_NAME, ex_Message)
            alert("เกิดข้อผิดพลาด (" & ex_Message & ")")
        End Try
    End Sub
    Function GEN_NO_INTAKE(ByVal YEAR As String, ByVal PROCESS_ID As Integer, ByVal LCN_IDA As Integer)
        Dim int_no As Integer

        Dim dao1 As New DAO_LCN.TB_LCN_APPROVE_EDIT_TRANSACTION_RQ_NUMBER
        dao1.GetDataby_GEN(YEAR, PROCESS_ID, LCN_IDA)
        If IsNothing(dao1.fields.GEN_NO) = True Then
            int_no = 0
        Else
            int_no = dao1.fields.GEN_NO
        End If

        int_no = int_no + 1
        Dim str_no As String = int_no

        Dim dao2 As New DAO_LCN.TB_LCN_APPROVE_EDIT_TRANSACTION_RQ_NUMBER
        dao2.fields.PROCESS_ID = PROCESS_ID
        dao2.fields.FK_IDA_LCN = LCN_IDA
        dao2.fields.GEN_NO = str_no
        dao2.fields.STATUS = 1
        dao2.fields.UPLOAD_DATE = Date.Now()
        dao2.fields.YEAR = con_year(Date.Now().Year())
        dao2.insert()

        Return str_no
    End Function
    Public Sub bind_pdf_xml_11(ByVal _IDA As Integer, ByVal LCN_IDA As Integer, ByVal _ProcessID As Integer, ByVal _StatusID As Integer, ByVal _YEAR As String, ByVal _tr_id_xml As String)
        Dim XML As New CLASS_GEN_XML.LCN_EDIT_SMP3
        TB_SMP3 = XML.gen_xml(_IDA, LCN_IDA, _YEAR)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_LCN_EDIT_TEMPLAETE(_ProcessID, _StatusID, "สมพ3", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_SMP3") 'path

        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_SMP3\" & dao_pdftemplate.fields.PDF_TEMPLATE

        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_SMP3("HB_PDF", _ProcessID, _YEAR, _tr_id_xml, _IDA, _StatusID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_SMP3("HB_XML", _ProcessID, _YEAR, _tr_id_xml, _IDA, _StatusID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)
    End Sub

    Protected Sub btn_Insert_Payment_Click(sender As Object, e As EventArgs) Handles btn_Insert_Payment.Click
        Try
            Dim sw As New SW_HERB_PAYMENT.SW_LCN_EDIT_PAYMENT
            Dim IDENTIFY As String = l44_IDENTIFY.Text
            Dim IDA As Integer = l44_IDA.Text
            Dim PROCESS_ID As String = l44_PROCESS.Text
            sw.INSERT_HERB_PAYMENT_CENTER_L44(IDENTIFY, IDA, PROCESS_ID)
            alert("SUCCESS")
        Catch ex As Exception
            alert("เกิดข้อผิดพลาด (" & ex.Message & ")")
        End Try

    End Sub

    Protected Sub btn_search_tr_id_Click(sender As Object, e As EventArgs) Handles btn_search_tr_id.Click
        Dim dt As New DataTable
        Dim bao As New BAO.ClsDBSqlcommand
        Dim TR_ID As Integer = S_TR_ID.Text
        Dim PROCESS_ID As String = S_Process.Text
        dt = bao.SP_SEARCH_ID_BY_PROCESS_AND_TR_ID(TR_ID, PROCESS_ID)
        For Each dr As DataRow In dt.Rows
            lbl_IDA.Text = dr("IDA")
            lbl_IDA.Visible = True
            Try
                lbl_IDEN.Text = dr("CITIZEN_ID_AUTHORIZE")
            Catch ex As Exception
                lbl_IDEN.Text = dr("IDENTIFY")
            End Try

        Next
    End Sub
End Class