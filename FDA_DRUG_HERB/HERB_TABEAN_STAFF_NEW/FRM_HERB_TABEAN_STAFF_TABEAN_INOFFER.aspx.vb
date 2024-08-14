Imports System.Globalization
Imports Telerik.Web.UI

Public Class FRM_HERB_TABEAN_STAFF_TABEAN_INOFFER
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Private _IDA As String
    Private _TR_ID As String
    Private _ProcessID As String
    Private _IDA_LCN As String

    Sub RunSession()
        _ProcessID = Request.QueryString("process")
        _IDA = Request.QueryString("IDA")
        _TR_ID = Request.QueryString("TR_ID")
        _IDA_LCN = Request.QueryString("IDA_LCN")
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            'lr_preview.Text = "<iframe id='iframe1'  style='height:1500px;width:100%;' src='../PDF/FRM_REPORT_RDLC.aspx?IDA=" & _IDA & "&rpt=1' ></iframe>"
            'lr_preview.Text = "<iframe id='iframe1'  style='height:1500px;width:100%;' src='../PDF/จจ๑.pdf'></iframe>"
            Run_Pdf_Tabean_Herb_6()
            'Run_Pdf_Tabean_Herb()
            bind_SALE_CHANNEL()
            bind_data()
            bind_dd()
            bind_mas_staff()
            bind_data_rgtno()
            bind_mas_ml()
            bind_dd_discount()
            bind_dd_syndrome()
            bind_dd_syndrome2()
            bind_dd_manufac()
            bind_mas_cancel()


            UC_officer_che.bind_unit1()
            UC_officer_che.bind_unit2()
            UC_officer_che.bind_unit3()
            UC_officer_che.bind_unit4()
            UC_officer_che.get_data_drgperunit()
            UC_officer_che.bind_unit_each()
            UC_officer_che.bind_lbl()
            ' UC_recipe.bind_ddl_atc()            UC_officer_che.bind_unit_head()
            UC_officer_che.bind_unit()

            UC_ATTACH1.NAME = "เอกสารแนบ"
            UC_ATTACH1.BindData("เอกสารแนบ", 1, "pdf", "0", "77")
        End If
    End Sub
    Public Sub bind_mas_cancel()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_STATUS_CANCEL_TABEAN_HERB(2)
        'dt = bao.SP_MAS_DDL_SECTION_CANCEL()

        DDL_CANCLE_REMARK.DataSource = dt
        DDL_CANCLE_REMARK.DataBind()
        DDL_CANCLE_REMARK.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub

    Public Sub Run_Pdf_Tabean_Herb()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_dq As New DAO_DRUG.ClsDBdrrqt
        dao_dq.GetDataby_IDA(_IDA)
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(_ProcessID, dao_dq.fields.STATUS_ID, "ทบ1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path

        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", _ProcessID, dao_dq.fields.DATE_YEAR, dao_dq.fields.TR_ID, _IDA, dao_dq.fields.STATUS_ID)

        lr_preview.Text = "<iframe id='iframe1'  style='height:1500px;width:100%;' src='../PDF/FRM_PDF.aspx?fileName=" & PATH_PDF_OUTPUT & "' ></iframe>"


    End Sub

    Public Sub bind_mas_staff()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_STAFF_NAME_HERB()

        DD_OFF_OFFER.DataSource = dt
        DD_OFF_OFFER.DataBind()
        DD_OFF_OFFER.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub

    Public Sub bind_mas_ml()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        'dt = bao.SP_MAS_TABEAN_HERB_ML()
        dt = bao.SP_MAS_TABEAN_HERB_ML_PROCESSID(_ProcessID)

        DD_ML_ID.DataSource = dt
        DD_ML_ID.DataBind()
        DD_ML_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Public Sub bind_data()
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_IDA)
        lbl_create_by.Text = dao.fields.CREATE_BY
        lbl_create_date.Text = dao.fields.CREATE_DATE
        If dao.fields.RCVNO_NEW = "" Then
            RCVNO_FULL.Text = dao.fields.RCVNO_OLD
        Else
            RCVNO_FULL.Text = dao.fields.RCVNO_NEW
        End If
        DD_OFF_OFFER.Text = _CLS.NAME
        DATE_OFFER.Text = Date.Now.ToString("dd/MM/yyyy")
        Dim dao_t As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao_t.GetdatabyID_FK_IDA_DQ(_IDA)
        Try
            If dao_t.fields.SYNDROME_ID IsNot Nothing Then
                DD_SYNDROME_ID.SelectedValue = dao_t.fields.SYNDROME_ID
            End If
        Catch ex As Exception

        End Try
        Try
            If dao_t.fields.SYNDROME_ID2 IsNot Nothing Then
                DD_SYNDROME_ID2.SelectedValue = dao_t.fields.SYNDROME_ID2
            End If
        Catch ex As Exception

        End Try
        Try
            If dao_t.fields.SALE_CHANNEL_ID IsNot Nothing Then
                DD_SALE_CHANNEL.SelectedValue = dao_t.fields.SALE_CHANNEL_ID
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub bind_data_rgtno()
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_IDA)
        If dao.fields.RGTNO_NEW Is Nothing Or dao.fields.RGTNO_NEW = "" Then
            If dao.fields.HerbFromNarcotics_ID Is Nothing = False Then
                If dao.fields.HerbFromNarcotics_ID = 1 Then
                    Dim str_no As String = ""
                    'str_no = Bind_RGTNO80K(dao.fields.DATE_YEAR, dao.fields.pvncd, dao.fields.rgttpcd, dao.fields.IDA, dao.fields.drgtpcd)
                    str_no = Bind_RGTNO80K(con_year(Date.Now.Year), dao.fields.pvncd, dao.fields.rgttpcd, dao.fields.IDA, dao.fields.drgtpcd)
                ElseIf dao.fields.HerbFromNarcotics_ID = 2 Then
                    'Bind_RGTNO158K(dao.fields.DATE_YEAR, dao.fields.pvncd, dao.fields.rgttpcd, dao.fields.IDA, dao.fields.drgtpcd, dao.fields.HerbFromNarcotics_ID)
                    Bind_RGTNO158K(con_year(Date.Now.Year), dao.fields.pvncd, dao.fields.rgttpcd, dao.fields.IDA, dao.fields.drgtpcd, dao.fields.HerbFromNarcotics_ID)

                Else
                    Try
                        'BIND_RGTNO_NEW(dao.fields.DATE_YEAR, dao.fields.pvncd, dao.fields.rgttpcd, dao.fields.IDA, dao.fields.PROCESS_ID, dao.fields.drgtpcd)
                        BIND_RGTNO_NEW(con_year(Date.Now.Year), dao.fields.pvncd, dao.fields.rgttpcd, dao.fields.IDA, dao.fields.PROCESS_ID, dao.fields.drgtpcd)
                    Catch ex As Exception

                    End Try
                End If
            Else
                'BIND_RGTNO_NEW(dao.fields.DATE_YEAR, dao.fields.pvncd, dao.fields.rgttpcd, dao.fields.IDA, dao.fields.PROCESS_ID, dao.fields.drgtpcd)
                BIND_RGTNO_NEW(con_year(Date.Now.Year), dao.fields.pvncd, dao.fields.rgttpcd, dao.fields.IDA, dao.fields.PROCESS_ID, dao.fields.drgtpcd)
            End If
        Else
            RGTNO_FULL.Text = dao.fields.RGTNO_NEW
        End If
    End Sub
    'Public Sub bind_data_rgtno()
    '    Dim dao As New DAO_DRUG.ClsDBdrrqt
    '    dao.GetDataby_IDA(_IDA)
    '    'If dao.fields.RGTNO_FULL = "" Then
    '    Dim int_no As Integer
    '    If dao.fields.RGTNO_NEW Is Nothing Then
    '        'Dim RG As String = GEN_RGTNO(dao.fields.rgttpcd)
    '        Dim dao_maxrgt_dq As New DAO_DRUG.ClsDBdrrqt
    '        dao_maxrgt_dq.GET_RGTNO_NEW_BYTPCD(dao.fields.rgttpcd)
    '        Dim dict = New Dictionary(Of String, Object)
    '        Dim tempb = Convert.ToInt32(DateTime.Now.Year.ToString()) + 543
    '        If dao.fields.DATE_YEAR IsNot Nothing Then tempb = dao.fields.DATE_YEAR
    '        tempb = tempb.ToString().Substring(2, 2)
    '        dict(tempb) = 0
    '        For Each item In dao_maxrgt_dq.datas
    '            Dim str = item.ToString.Substring(2).Split("/")
    '            Dim n = CInt(str(0))
    '            Dim y = CInt(str(1))
    '            If dict(tempb) < n Then
    '                dict(tempb) = (n)
    '            End If
    '        Next
    '        Dim num As Integer = dict(tempb)
    '        num += 1
    '        'Dim str_no = String.Format("{0:50000}", num.ToString("50000"))
    '        RGTNO_FULL.Text = dao.fields.rgttpcd & " " & num.ToString & "/" & tempb.ToString()
    '        'dao.fields.RGTNO_FULL = RGTNO_FULL.Text
    '        'dao.Update()

    '        Dim Year As String = ""
    '        Year = dao.fields.DATE_YEAR
    '        Dim str_no As String = int_no.ToString()
    '        str_no = String.Format("{0:00000}", num.ToString("00000"))
    '        str_no = Year.Substring(2, 2) & str_no

    '        dao.fields.rgtno = str_no
    '        dao.update()

    '    Else
    '        RGTNO_FULL.Text = dao.fields.RGTNO_NEW
    '    End If
    '    'RGTNO_FULL.Text = dao.fields.RGTNO_FULL
    'End Sub

    Private Function GEN_RGTNO(ByVal rgttpcd As String) As String

        'Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_IDA)

        Dim str_no As String = ""

        If dao.fields.IDA = 1 And dao.fields.DATE_YEAR = con_year(Date.Now.Year) Then
            Dim max_no As Integer = 0
            Try
                max_no = CInt("00002")
                max_no += 1

            Catch ex As Exception

            End Try

            str_no = max_no.ToString()
            str_no = String.Format("{0:50000}", max_no.ToString("50000"))
            dao.fields.rgtno = dao.fields.DATE_YEAR.Substring(2, 2) & str_no
            dao.update()
            'str_no = dao.fields.DATE_YEAR.Substring(2, 2) & str_no
            str_no = str_no & "/" & dao.fields.DATE_YEAR.Substring(2, 2)
        Else
            Dim max_no As Integer = 0

            Dim dt As New DataTable
            Dim bao_max As New BAO_TABEAN_HERB.tb_main
            Dim _YEAR As String
            _YEAR = con_year(Date.Now.Year)
            dt = bao_max.SP_TABEAN_HERB_GET_MAX_RGTNO_JJ(rgttpcd, _YEAR.Substring(2, 2))
            Try
                max_no = dt(0)("MAX_ID")
                max_no += 1
            Catch ex As Exception

            End Try

            str_no = max_no.ToString()
            str_no = String.Format("{0:50000}", max_no.ToString("50000"))
            If dao.fields.DATE_YEAR IsNot Nothing Then
                dao.fields.rgtno = dao.fields.DATE_YEAR.Substring(2, 2) & str_no
            Else
                Dim tempb = Convert.ToInt32(DateTime.Now.Year.ToString()) + 543
                dao.fields.rgtno = tempb.ToString().Substring(2, 2) & str_no
            End If
            dao.update()
            str_no = str_no & "/" & _YEAR.Substring(2, 2)
            'str_no = _YEAR.Substring(2, 2) & str_no
        End If

        Return str_no
    End Function

    Public Function GEN_RGTNO50K(ByVal IDA As String) As String
        Dim int_no As Integer
        Dim subString As String = ""
        Dim dao As New DAO_DRUG.ClsDBdrrqt  '
        dao.GetDataby_IDA(IDA)

        If IsNothing(dao.fields.RGTNO_NEW) = False Then
            Dim RGTNO As String = Right(dao.fields.RGTNO_NEW, 5)
            int_no = Left(RGTNO, 2)
        End If
        'int_no = int_no + 1
        Dim Year As String = ""
        Year = dao.fields.DATE_YEAR
        Dim str_no As String = int_no.ToString()
        str_no = String.Format("{0:50000}", int_no.ToString("00000"))
        str_no = Year.Substring(2, 2) & str_no
        dao.fields.rgtno = str_no
        dao.update()
        Return str_no
    End Function
    Public Function GEN_RGTNO158K(ByVal YEAR As String, ByVal PVNCD As String, ByVal RGTTPCD As String, ByVal FK_IDA As Integer, ByVal drgtpcd As String, ByVal Condition As String) As String
        Dim int_no As Integer
        Dim str_no As String = int_no.ToString()
        Dim str_no2 As String = int_no.ToString()
        'Dim dao As New DAO_DRUG.clsDBGEN_NO_01
        Dim dao As New DAO_TABEAN_HERB.TB_GEN_NO_TBN_FronNarcotic
        Dim dao2 As New DAO_TABEAN_HERB.TB_GEN_NO_TBN_FronNarcotic
        dao.GetDataby_Condition_MAX(YEAR, RGTTPCD, drgtpcd, Condition)
        Dim dao_type As New DAO_DRUG.ClsDBdrdrgtype
        dao_type.GetDataby_drgtpcd(drgtpcd)
        ' dao.GetDataby_RGTNO_MAX(YEAR, PVNCD, RGTTPCD, FK_IDA)
        dao2.GetDataby_FK_IDA(FK_IDA)
        If IsNothing(dao.fields.GENNO) = True Then
            int_no = 0
        Else
            int_no = dao.fields.GENNO
        End If
        If dao2.fields.IDA = Nothing Then
            int_no = int_no + 1
            str_no = String.Format("{0:15800}", int_no.ToString("15800"))
            str_no2 = YEAR.Substring(2, 2) & str_no

            dao = New DAO_TABEAN_HERB.TB_GEN_NO_TBN_FronNarcotic
            dao.fields.YEAR = YEAR
            dao.fields.PVCODE = PVNCD
            dao.fields.GENNO = int_no
            dao.fields.TYPE = RGTTPCD
            dao.fields.REF_IDA = FK_IDA
            dao.fields.RGTNO = str_no2
            dao.fields.GROUP_NO = drgtpcd
            dao.fields.DESCRIPTION = str_no
            dao.fields.Condition = Condition
            dao.fields.FORMAT = RGTTPCD & " " & str_no.ToString() & "/" & YEAR.Substring(2, 2) & dao_type.fields.engdrgtpnm
            dao.insert()
        Else
            str_no = String.Format("{0:15800}", int_no.ToString("15800"))
            str_no2 = YEAR.Substring(2, 2) & str_no
        End If
        Dim full_rgtno As String = ""
        full_rgtno = RGTTPCD & " " & str_no.ToString() & "/" & YEAR.Substring(2, 2) & dao_type.fields.engdrgtpnm
        'RGTNO_FULL.Text = RGTTPCD & " " & str_no.ToString() & "/" & YEAR.Substring(2, 2) & dao_type.fields.engdrgtpnm
        Dim dao_ty As New DAO_DRUG.ClsDBdrdrgtype
        Try
            dao_ty.GetDataby_drgtpcd(drgtpcd)
            RGTNO_FULL.Text = full_rgtno & "" & dao_ty.fields.engdrgtpnm
        Catch ex As Exception

        End Try

        Return str_no2
    End Function
    Public Function Bind_RGTNO158K(ByVal YEAR As String, ByVal PVNCD As String, ByVal RGTTPCD As String, ByVal FK_IDA As Integer, ByVal drgtpcd As String, ByVal Condition As String) As String
        Dim int_no As Integer
        Dim str_no As String = int_no.ToString()
        Dim str_no2 As String = int_no.ToString()
        'Dim dao As New DAO_DRUG.clsDBGEN_NO_01
        Dim dao As New DAO_TABEAN_HERB.TB_GEN_NO_TBN_FronNarcotic
        Dim dao2 As New DAO_TABEAN_HERB.TB_GEN_NO_TBN_FronNarcotic
        dao.GetDataby_Condition_MAX(YEAR, RGTTPCD, drgtpcd, Condition)
        Dim dao_type As New DAO_DRUG.ClsDBdrdrgtype
        dao_type.GetDataby_drgtpcd(drgtpcd)
        ' dao.GetDataby_RGTNO_MAX(YEAR, PVNCD, RGTTPCD, FK_IDA)
        dao2.GetDataby_FK_IDA(FK_IDA)
        If IsNothing(dao.fields.GENNO) = True Then
            int_no = 0
        Else
            int_no = dao.fields.GENNO

        End If
        Dim full_rgtno As String = ""
        int_no = int_no + 1
        str_no = String.Format("{0:15800}", int_no.ToString("15800"))
        str_no2 = YEAR.Substring(2, 2) & str_no
        full_rgtno = RGTTPCD & " " & str_no.ToString() & "/" & YEAR.Substring(2, 2) & dao_type.fields.engdrgtpnm
        Dim dao_ty As New DAO_DRUG.ClsDBdrdrgtype
        Try
            dao_ty.GetDataby_drgtpcd(drgtpcd)
            RGTNO_FULL.Text = full_rgtno & "" & dao_ty.fields.engdrgtpnm
        Catch ex As Exception

        End Try

        Return str_no2
    End Function
    Public Function Bind_RGTNO80K(ByVal YEAR As String, ByVal PVNCD As String, ByVal RGTTPCD As String, ByVal FK_IDA As Integer, ByVal drgtpcd As String) As String
        Dim int_no As Integer
        Dim full_rgtno As String = ""
        Dim str_no As String = int_no.ToString()
        Dim str_no2 As String = int_no.ToString()
        'Dim dao As New DAO_DRUG.clsDBGEN_NO_01
        Dim dao As New DAO_TABEAN_HERB.TB_GEN_NO_TBN_FronNarcotic
        Dim dao2 As New DAO_TABEAN_HERB.TB_GEN_NO_TBN_FronNarcotic
        dao.GetDataby_RGTTPCD_MAX(YEAR, RGTTPCD, drgtpcd)
        Dim dao_type As New DAO_DRUG.ClsDBdrdrgtype
        dao_type.GetDataby_drgtpcd(drgtpcd)
        ' dao.GetDataby_RGTNO_MAX(YEAR, PVNCD, RGTTPCD, FK_IDA)
        dao2.GetDataby_FK_IDA(FK_IDA)
        If IsNothing(dao.fields.GENNO) = True Then
            int_no = 0
        Else
            int_no = dao.fields.GENNO

        End If
        int_no = int_no + 1
        str_no = String.Format("{0:80000}", int_no.ToString("80000"))
        str_no2 = YEAR.Substring(2, 2) & str_no
        full_rgtno = RGTTPCD & " " & str_no.ToString() & "/" & YEAR.Substring(2, 2)
        'RGTNO_FULL.Text = RGTTPCD & " " & str_no.ToString() & "/" & YEAR.Substring(2, 2) & dao_type.fields.engdrgtpnm
        Dim dao_ty As New DAO_DRUG.ClsDBdrdrgtype
        Try
            dao_ty.GetDataby_drgtpcd(drgtpcd)
            RGTNO_FULL.Text = full_rgtno & "" & dao_ty.fields.engdrgtpnm
        Catch ex As Exception

        End Try

        Return str_no2
    End Function
    Public Function GEN_RGTNO80K(ByVal YEAR As String, ByVal PVNCD As String, ByVal RGTTPCD As String, ByVal FK_IDA As Integer, ByVal drgtpcd As String) As String
        Dim int_no As Integer
        Dim str_no As String = int_no.ToString()
        Dim str_no2 As String = int_no.ToString()
        'Dim dao As New DAO_DRUG.clsDBGEN_NO_01
        Dim dao As New DAO_TABEAN_HERB.TB_GEN_NO_TBN_FronNarcotic
        Dim dao2 As New DAO_TABEAN_HERB.TB_GEN_NO_TBN_FronNarcotic
        dao.GetDataby_RGTTPCD_MAX(YEAR, RGTTPCD, drgtpcd)
        Dim dao_type As New DAO_DRUG.ClsDBdrdrgtype
        dao_type.GetDataby_drgtpcd(drgtpcd)
        ' dao.GetDataby_RGTNO_MAX(YEAR, PVNCD, RGTTPCD, FK_IDA)
        dao2.GetDataby_FK_IDA(FK_IDA)
        If IsNothing(dao.fields.GENNO) = True Then
            int_no = 0
        Else
            int_no = dao.fields.GENNO
        End If
        If dao2.fields.IDA = Nothing Then
            int_no = int_no + 1
            str_no = String.Format("{0:80000}", int_no.ToString("80000"))
            str_no2 = YEAR.Substring(2, 2) & str_no

            dao = New DAO_TABEAN_HERB.TB_GEN_NO_TBN_FronNarcotic
            dao.fields.YEAR = YEAR
            dao.fields.PVCODE = PVNCD
            dao.fields.GENNO = int_no
            dao.fields.TYPE = RGTTPCD
            dao.fields.REF_IDA = FK_IDA
            dao.fields.RGTNO = str_no2
            dao.fields.GROUP_NO = drgtpcd
            dao.fields.DESCRIPTION = str_no
            dao.fields.FORMAT = RGTTPCD & " " & str_no.ToString() & "/" & YEAR.Substring(2, 2) & dao_type.fields.engdrgtpnm
            dao.insert()
        Else
            str_no = String.Format("{0:80000}", int_no.ToString("80000"))
            str_no2 = YEAR.Substring(2, 2) & str_no
        End If
        Dim full_rgtno As String = ""
        full_rgtno = RGTTPCD & " " & str_no.ToString() & "/" & YEAR.Substring(2, 2)
        'RGTNO_FULL.Text = RGTTPCD & " " & str_no.ToString() & "/" & YEAR.Substring(2, 2) & dao_type.fields.engdrgtpnm
        Dim dao_ty As New DAO_DRUG.ClsDBdrdrgtype
        Try
            dao_ty.GetDataby_drgtpcd(drgtpcd)
            RGTNO_FULL.Text = full_rgtno & "" & dao_ty.fields.engdrgtpnm
        Catch ex As Exception

        End Try

        Return str_no2
    End Function
    Public Function BIND_RGTNO_NEW(ByVal YEAR As String, ByVal PVNCD As String, ByVal RGTTPCD As String, ByVal FK_IDA As Integer, ByVal PROCESS_ID As Integer, ByVal drgtpcd As String) As String
        Dim int_no As Integer
        Dim str_no As String = int_no.ToString()
        Dim str_no2 As String = int_no.ToString()
        Dim dao_ty As New DAO_DRUG.ClsDBdrdrgtype
        'Dim dao As New DAO_DRUG.clsDBGEN_NO_01
        Dim dao As New DAO_TABEAN_HERB.TB_GEN_NO_TBN_NEW
        Dim dao2 As New DAO_TABEAN_HERB.TB_GEN_NO_TBN_NEW
        Dim dao_dr As New DAO_DRUG.ClsDBdrdrgtype
        dao_dr.GetDataby_drgtpcd(drgtpcd)
        dao.GetDataby_RGTNO_MAX(YEAR, PVNCD, RGTTPCD, FK_IDA, PROCESS_ID, drgtpcd)
        ' dao.GetDataby_RGTNO_MAX(YEAR, PVNCD, RGTTPCD, FK_IDA)
        dao2.GetDataby_FK_IDA(FK_IDA)
        If IsNothing(dao.fields.GENNO) = True Then
            int_no = 0
        Else
            int_no = dao.fields.GENNO
        End If
        Dim full_rgtno As String = ""
        int_no = int_no + 1
        str_no = String.Format("{0:00000}", int_no.ToString("00000"))
        str_no2 = YEAR.Substring(2, 2) & str_no

        If drgtpcd = 3 Then
            full_rgtno = RGTTPCD & " " & int_no.ToString() & "/" & YEAR.Substring(2, 2)
            ' RGTNO_FULL.Text = RGTTPCD & " " & int_no.ToString() & "/" & YEAR.Substring(2, 2) & dao_dr.fields.engdrgtpnm
            Try
                dao_ty.GetDataby_drgtpcd(drgtpcd)
                RGTNO_FULL.Text = full_rgtno & "" & dao_ty.fields.engdrgtpnm
            Catch ex As Exception

            End Try
        Else
            full_rgtno = RGTTPCD & " " & int_no.ToString() & "/" & YEAR.Substring(2, 2)
            'RGTNO_FULL.Text = RGTTPCD & " " & int_no.ToString() & "/" & YEAR.Substring(2, 2)
            Try
                dao_ty.GetDataby_drgtpcd(drgtpcd)
                RGTNO_FULL.Text = full_rgtno & "" & dao_ty.fields.engdrgtpnm
            Catch ex As Exception

            End Try
        End If

        Return str_no2
    End Function
    Public Function GEN_RGTNO_NEW(ByVal YEAR As String, ByVal PVNCD As String, ByVal RGTTPCD As String, ByVal FK_IDA As Integer, ByVal PROCESS_ID As Integer, ByVal drgtpcd As String) As String
        Dim int_no As Integer
        Dim str_no As String = int_no.ToString()
        Dim str_no2 As String = int_no.ToString()
        'Dim dao As New DAO_DRUG.clsDBGEN_NO_01
        Dim dao As New DAO_TABEAN_HERB.TB_GEN_NO_TBN_NEW
        Dim dao2 As New DAO_TABEAN_HERB.TB_GEN_NO_TBN_NEW
        Dim dao_dr As New DAO_DRUG.ClsDBdrdrgtype
        dao_dr.GetDataby_drgtpcd(drgtpcd)
        dao.GetDataby_RGTNO_MAX(YEAR, PVNCD, RGTTPCD, FK_IDA, PROCESS_ID, drgtpcd)
        ' dao.GetDataby_RGTNO_MAX(YEAR, PVNCD, RGTTPCD, FK_IDA)
        dao2.GetDataby_FK_IDA(FK_IDA)
        If IsNothing(dao.fields.GENNO) = True Then
            int_no = 0
        Else
            int_no = dao.fields.GENNO
        End If
        If dao2.fields.IDA = Nothing Then
            int_no = int_no + 1
            str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no2 = YEAR.Substring(2, 2) & str_no

            dao = New DAO_TABEAN_HERB.TB_GEN_NO_TBN_NEW
            dao.fields.YEAR = YEAR
            dao.fields.PVCODE = PVNCD
            dao.fields.GENNO = int_no
            dao.fields.TYPE = RGTTPCD
            dao.fields.REF_IDA = FK_IDA
            dao.fields.RGTNO = str_no2
            dao.fields.DESCRIPTION = int_no
            dao.fields.PROCESS_ID = PROCESS_ID
            dao.fields.GROUP_NO = drgtpcd
            If drgtpcd = 3 Then
                dao.fields.FORMAT = RGTTPCD & " " & int_no.ToString() & "/" & YEAR.Substring(2, 2) & dao_dr.fields.engdrgtpnm
            Else
                dao.fields.FORMAT = RGTTPCD & " " & int_no.ToString() & "/" & YEAR.Substring(2, 2)
            End If

            dao.insert()
        Else
            str_no = String.Format("{0:00000}", int_no.ToString("00000"))
            str_no2 = YEAR.Substring(2, 2) & str_no
        End If

        If drgtpcd = 3 Then
            RGTNO_FULL.Text = RGTTPCD & " " & int_no.ToString() & "/" & YEAR.Substring(2, 2) & dao_dr.fields.engdrgtpnm
        End If


        Return str_no2
    End Function
    Public Sub bind_dd()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_STATUS_TABEAN(3)

        DD_STATUS.DataSource = dt
        DD_STATUS.DataBind()
        DD_STATUS.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub

    Function bind_data_uploadfile()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 7, _ProcessID, _IDA)

        Return dt
    End Function
    Function bind_data_uploadfile_edit2()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 12, _ProcessID, _IDA)

        Return dt
    End Function

    Private Sub RadGrid4_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid4.NeedDataSource
        RadGrid4.DataSource = bind_data_uploadfile_edit2()
    End Sub
    Private Sub RadGrid4_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid4.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_NEW/FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        RadGrid1.DataSource = bind_data_uploadfile()
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_NEW/FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If

    End Sub

    Function bind_data_uploadfile_edit()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 10, _ProcessID, _IDA)

        Return dt
    End Function

    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource
        RadGrid2.DataSource = bind_data_uploadfile_edit()
    End Sub

    Private Sub RadGrid2_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid2.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_NEW/FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If
    End Sub

    Protected Sub DD_STATUS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_STATUS.SelectedIndexChanged
        If DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก เลือกประเภททะเบียน');", True)
        ElseIf DD_STATUS.SelectedValue = 6 Then
            P12.Visible = True
            p2.Visible = False
        ElseIf DD_STATUS.SelectedValue = 77 Or DD_STATUS.SelectedValue = 78 Or DD_STATUS.SelectedValue = 79 Or DD_STATUS.SelectedValue = 7 _
            Or DD_STATUS.SelectedValue = 9 Or DD_STATUS.SelectedValue = 10 Then
            p2.Visible = True
            P12.Visible = False
        Else
            P12.Visible = False
            p2.Visible = False
        End If
    End Sub

    Protected Sub btn_sumit_Click(sender As Object, e As EventArgs) Handles btn_sumit.Click
        Dim dao As New DAO_DRUG.ClsDBdrrqt
        dao.GetDataby_IDA(_IDA)

        Dim dao_tabean_herb As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao_tabean_herb.GetdatabyID_FK_IDA_DQ(_IDA)

        If DD_STATUS.SelectedValue = 24 Then
            dao.fields.STATUS_ID = DD_STATUS.SelectedValue
            dao.update()

            Dim bao_tran As New BAO_TRANSECTION
            bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, DD_STATUS.SelectedValue)
            dao.fields.STATUS_ID = DD_STATUS.SelectedValue
            dao.update()

            dao_tabean_herb.fields.STATUS_ID = DD_STATUS.SelectedValue
            dao_tabean_herb.Update()

            Run_Pdf_Tabean_Herb_6()
            'Run_Pdf_Tabean_Herb_6_2()
            AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
        ElseIf DD_STATUS.SelectedValue = 10 Then
            dao.fields.STATUS_ID = DD_STATUS.SelectedValue
            dao.update()

            Dim bao_tran As New BAO_TRANSECTION
            bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, DD_STATUS.SelectedValue)
            dao.fields.STATUS_ID = DD_STATUS.SelectedValue
            dao.fields.REMARK = NOTE_CANCLE.Text
            dao.update()


            dao_tabean_herb.fields.NOTE_CANCEL = NOTE_CANCLE.Text
            dao_tabean_herb.fields.DD_CANCEL_NM = DDL_CANCLE_REMARK.SelectedItem.Text
            Try
                dao_tabean_herb.fields.DD_CANCEL_ID = DDL_CANCLE_REMARK.SelectedValue
            Catch ex As Exception

            End Try
            dao_tabean_herb.fields.cancel_date = Date.Now
            dao_tabean_herb.fields.cancel_by = _CLS.THANM
            dao_tabean_herb.fields.cancel_iden = _CLS.CITIZEN_ID
            dao_tabean_herb.fields.STATUS_ID = DD_STATUS.SelectedValue
            dao_tabean_herb.Update()

            UC_ATTACH1.insert_TBN(_TR_ID, _ProcessID, dao.fields.IDA, 77)
            Run_Pdf_Tabean_Herb_6()
            'Run_Pdf_Tabean_Herb_6_2()

            AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
        Else
            If DD_STATUS.SelectedValue = "-- กรุณาเลือก --" Or DD_OFF_OFFER.SelectedValue = "-- กรุณาเลือก --" _
            Or DD_ML_ID.SelectedValue = "-- กรุณาเลือก --" Or TXT_SUM.Text = "" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก เลือกสถานะ ประเภท ยอดสุทธิ หรือ เลือกเจ้าหน้าที่');", True)
            ElseIf DD_SYNDROME_ID.SelectedValue = "-- กรุณาเลือก --" Or DD_SALE_CHANNEL.SelectedValue = "-- กรุณาเลือก --" Then
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก เลือกช่องทางการขาย หรือกลุ่มอาการ');", True)
            ElseIf DD_STATUS.SelectedValue = 6 Then
                Try
                    dao.fields.CONSIDER_DATE = DateTime.ParseExact(DATE_OFFER.Text, "dd/MM/yyyy", New CultureInfo("th-TH").DateTimeFormat)
                Catch ex As Exception
                    dao.fields.CONSIDER_DATE = Date.Now
                End Try
                dao.fields.REMARK = NOTE_OFFER.Text
                dao.fields.FK_STAFF_OFFER_IDA = DD_OFF_OFFER.SelectedValue
                dao.fields.STAFF_OFFER_NAME = DD_OFF_OFFER.SelectedItem.Text
                dao.fields.RGTNO_NEW = RGTNO_FULL.Text
                dao.fields.STATUS_ID = DD_STATUS.SelectedValue
                dao.fields.RGTNO_NEW = RGTNO_FULL.Text
                Dim RGTNO As String = ""
                If dao.fields.HerbFromNarcotics_ID Is Nothing = False Then
                    If dao.fields.HerbFromNarcotics_ID = 1 Then
                        Dim str_no As String = ""
                        'RGTNO = GEN_RGTNO80K(dao.fields.DATE_YEAR, dao.fields.pvncd, dao.fields.rgttpcd, dao.fields.IDA, dao.fields.drgtpcd)
                        RGTNO = GEN_RGTNO80K(con_year(Date.Now.Year), dao.fields.pvncd, dao.fields.rgttpcd, dao.fields.IDA, dao.fields.drgtpcd)
                    ElseIf dao.fields.HerbFromNarcotics_ID = 2 Then
                        'RGTNO = GEN_RGTNO158K(dao.fields.DATE_YEAR, dao.fields.pvncd, dao.fields.rgttpcd, dao.fields.IDA, dao.fields.drgtpcd, dao.fields.HerbFromNarcotics_ID)
                        RGTNO = GEN_RGTNO158K(con_year(Date.Now.Year), dao.fields.pvncd, dao.fields.rgttpcd, dao.fields.IDA, dao.fields.drgtpcd, dao.fields.HerbFromNarcotics_ID)
                    Else
                        Try
                            RGTNO = GEN_RGTNO_NEW(con_year(Date.Now.Year), dao.fields.pvncd, dao.fields.rgttpcd, dao.fields.IDA, dao.fields.PROCESS_ID, dao.fields.drgtpcd)
                            'RGTNO = GEN_RGTNO_NEW(dao.fields.DATE_YEAR, dao.fields.pvncd, dao.fields.rgttpcd, dao.fields.IDA, dao.fields.PROCESS_ID, dao.fields.drgtpcd)
                        Catch ex As Exception

                        End Try
                    End If
                Else
                    'RGTNO = GEN_RGTNO_NEW(dao.fields.DATE_YEAR, dao.fields.pvncd, dao.fields.rgttpcd, dao.fields.IDA, dao.fields.PROCESS_ID, dao.fields.drgtpcd)
                    RGTNO = GEN_RGTNO_NEW(con_year(Date.Now.Year), dao.fields.pvncd, dao.fields.rgttpcd, dao.fields.IDA, dao.fields.PROCESS_ID, dao.fields.drgtpcd)
                End If
                dao.fields.rgtno = RGTNO


                dao_tabean_herb.fields.ML_ID = DD_ML_ID.SelectedValue
                dao_tabean_herb.fields.ML_NAME = DD_ML_ID.SelectedItem.Text

                Try
                    dao_tabean_herb.fields.ML_PAY = TXT_BATH.Text
                    'dao_tabean_herb.fields.ML_MINUS = TXT_MINUS.Text
                    dao_tabean_herb.fields.ML_MINUS = DDL_DISCOUNT.SelectedItem.Text
                Catch ex As Exception

                End Try
                Try
                    dao_tabean_herb.fields.SYNDROME_ID = DD_SYNDROME_ID.SelectedValue
                    dao_tabean_herb.fields.SYNDROME_NAME = DD_SYNDROME_ID.SelectedItem.Text
                Catch ex As Exception

                End Try
                Try
                    dao_tabean_herb.fields.SYNDROME_ID2 = DD_SYNDROME_ID2.SelectedValue
                    dao_tabean_herb.fields.SYNDROME_NAME2 = DD_SYNDROME_ID2.SelectedItem.Text
                Catch ex As Exception

                End Try
                Try
                    dao_tabean_herb.fields.SALE_CHANNEL_ID = DD_SALE_CHANNEL.SelectedValue
                    dao_tabean_herb.fields.SALE_CHANNEL_NAME = DD_SALE_CHANNEL.SelectedItem.Text
                Catch ex As Exception

                End Try
                If TXT_SUM.Text = 0 Then
                    dao_tabean_herb.fields.ML_SUM = TXT_SUM.Text
                    dao_tabean_herb.fields.STATUS_ID = 21
                    dao.fields.STATUS_ID = 21

                Else
                    dao_tabean_herb.fields.ML_SUM = TXT_SUM.Text
                    dao_tabean_herb.fields.STATUS_ID = DD_STATUS.SelectedValue
                    dao.fields.STATUS_ID = DD_STATUS.SelectedValue
                End If

                dao_tabean_herb.fields.ML_KEY_NAME = _CLS.THANM
                dao_tabean_herb.fields.ML_KEY_DATE = Date.Now
                dao.update()
                dao_tabean_herb.Update()

                AddLogStatus(dao.fields.STATUS_ID, _ProcessID, _CLS.CITIZEN_ID, _IDA)
                'Dim bao_tran As New BAO_TRANSECTION
                'bao_tran.insert_transection_jj(_ProcessID, dao.fields.IDA, DD_STATUS.SelectedValue)
                'GEN_RGTNO50K(_IDA)

                Run_Pdf_Tabean_Herb_6()
                Run_Pdf_Tabean_Herb_6_2()
                Run_Pdf_Tabean_Herb_6_2_Long()
                'Run_Pdf_Tabean_Herb_APPROVE_2_11_12()   
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('บันทึกเรียบร้อย');parent.close_modal();", True)
            End If
        End If

    End Sub

    Public Sub Run_Pdf_Tabean_Herb_6()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA)

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA)

        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_TBN
        TBN_NEW = XML.gen_xml_tbn(dao.fields.IDA, _IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(_ProcessID, dao_deeqt.fields.STATUS_ID, "ทบ1", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TBN_1\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", _ProcessID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA, dao_deeqt.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TBN("HB_XML", _ProcessID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA, dao_deeqt.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML

    End Sub
    Public Sub Run_Pdf_Tabean_Herb_6_2()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA)

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA)

        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_TBN
        TBN_NEW = XML.gen_xml_tbn_2(dao.fields.IDA, _IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(_ProcessID, dao_deeqt.fields.STATUS_ID, "ทบ2", 0)


        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TBN_2\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", _ProcessID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA, dao_deeqt.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TBN("HB_XML", _ProcessID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA, dao_deeqt.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML

    End Sub

    Public Sub Run_Pdf_Tabean_Herb_APPROVE_2_11_12()
        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA)
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA)
        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_TBN
        TBN_NEW = XML.gen_xml_approve(dao.fields.IDA, _IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(_ProcessID, dao_deeqt.fields.STATUS_ID, "APPROVE_TBN_2", 0)

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_APPROVE") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_APPROVE\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", _ProcessID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA, dao_deeqt.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TBN("HB_XML", _ProcessID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA, dao_deeqt.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        lr_preview.Text = "<iframe id='iframe1'  style='height:1500px;width:100%;' src='../PDF/FRM_PDF.aspx?FileName=" & PATH_PDF_OUTPUT & "' ></iframe>"

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML
    End Sub
    Public Sub Run_Pdf_Tabean_Herb_6_2_Long()
        Dim bao_app As New BAO.AppSettings
        bao_app.RunAppSettings()

        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA)

        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA)

        Dim XML As New CLASS_GEN_XML.TABEAN_HERB_TBN
        TBN_NEW = XML.gen_xml_tbn_2(dao.fields.IDA, _IDA, _IDA_LCN)

        Dim dao_pdftemplate As New DAO_DRUG.ClsDB_MAS_TEMPLATE_PROCESS
        dao_pdftemplate.GETDATA_TABEAN_HERB_TBN_TEMPLAETE1(_ProcessID, dao_deeqt.fields.STATUS_ID, "ทบ2", 1)


        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN") 'path
        Dim PATH_PDF_TEMPLATE As String = _PATH_FILE & "PDF_TBN_2\" & dao_pdftemplate.fields.PDF_TEMPLATE
        Dim PATH_PDF_OUTPUT As String = _PATH_FILE & dao_pdftemplate.fields.PDF_OUTPUT & "\" & NAME_PDF_TBN("HB_PDF", _ProcessID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA, dao_deeqt.fields.STATUS_ID)
        Dim Path_XML As String = _PATH_FILE & dao_pdftemplate.fields.XML_PATH & "\" & NAME_XML_TBN("HB_XML", _ProcessID, dao_deeqt.fields.DATE_YEAR, dao_deeqt.fields.TR_ID, _IDA, dao_deeqt.fields.STATUS_ID)

        LOAD_XML_PDF(Path_XML, PATH_PDF_TEMPLATE, _ProcessID, PATH_PDF_OUTPUT)

        _CLS.FILENAME_PDF = PATH_PDF_OUTPUT
        _CLS.PDFNAME = PATH_PDF_OUTPUT
        _CLS.FILENAME_XML = Path_XML

    End Sub

    Protected Sub btn_preview_tb2_Click(sender As Object, e As EventArgs) Handles btn_preview_tb2.Click
        Dim Url As String = "FRM_HERB_TABEAN_STAFF_TABEAN_PREVIEW_TABEAN2.aspx?IDA=" & _IDA & "&SLDDL=" & DDL_TB2_SELECT.SelectedValue
        Response.Write("<script>window.open('" & Url & "','_blank')</script>")
        'load_PDF(_CLS.PDFNAME, _CLS.FILENAME_PDF)
    End Sub

    Private Sub load_PDF(ByVal path As String, ByVal fileName As String)
        Dim bao As New BAO.AppSettings
        Dim clsds As New ClassDataset

        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & fileName)
        Response.BinaryWrite(clsds.UpLoadImageByte(path)) '"C:\path\PDF_XML_CLASS\"

        Response.Flush()
        Response.Close()
        Response.End()

    End Sub

    Function bind_data_uploadfile_6()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 6, _ProcessID, _IDA)

        Return dt
    End Function

    Private Sub RadGrid3_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid3.NeedDataSource
        RadGrid3.DataSource = bind_data_uploadfile_6()
    End Sub

    Private Sub RadGrid3_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid3.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_NEW/FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If
    End Sub

    Function bind_data_uploadfile_8()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_main

        dt = bao.SP_TABEAN_HERB_UPLOAD_FILE_JJ(_TR_ID, 8, _ProcessID, _IDA)

        Return dt
    End Function

    Private Sub RadGrid5_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid5.NeedDataSource
        RadGrid5.DataSource = bind_data_uploadfile_8()
    End Sub

    Private Sub RadGrid5_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid5.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim IDA As Integer = item("IDA").Text

            Dim H As HyperLink = e.Item.FindControl("PV_SELECT")
            H.Target = "_blank"
            H.NavigateUrl = "../HERB_TABEAN_NEW/FRM_HERB_TABEAN_DETAIL_PREVIEW_FILE.aspx?ida=" & IDA

        End If
    End Sub

    Protected Sub DD_ML_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DD_ML_ID.SelectedIndexChanged
        Dim dao_ml As New DAO_TABEAN_HERB.TB_TABEAN_HERB_ML

        If DD_ML_ID.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก ประเภทค่าธรรมเนียม');", True)
        Else
            dao_ml.GetdatabyID_IDA(DD_ML_ID.SelectedValue)

            TXT_BATH.Text = dao_ml.fields.ML_PAY
            DDL_DISCOUNT.ClearSelection()
            TXT_SUM.Text = ""
            'TXT_MINUS.Text = ""
            'TXT_SUM.Text = ""
        End If

    End Sub

    Public Sub bind_dd_discount()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_DISCOUNT_TABEAN()

        DDL_DISCOUNT.DataSource = dt
        DDL_DISCOUNT.DataBind()
        DDL_DISCOUNT.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub
    Protected Sub DDL_DISCOUNT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DDL_DISCOUNT.SelectedIndexChanged
        Dim dao_ml As New DAO_TABEAN_HERB.TB_TABEAN_HERB_ML

        If DDL_DISCOUNT.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก ประเภทค่าธรรมเนียม');", True)
        Else
            Dim number1 As Integer = 0
            Dim number2 As Integer = 0
            Dim number3 As Integer = 100
            Dim answer1 As Decimal
            Dim sum1 As Integer
            Dim sum2 As Integer

            number1 = TXT_BATH.Text
            number2 = DDL_DISCOUNT.SelectedItem.Text
            sum1 = number1 * number2
            sum2 = sum1 / number3
            answer1 = number1 - sum2
            TXT_SUM.Text = answer1
        End If

    End Sub
    Protected Sub btn_add_muc_add_Click(sender As Object, e As EventArgs) Handles btn_add_muc_add.Click
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_MANUFACTRUE

        dao.fields.FK_IDA_DQ = _IDA
        dao.fields.NO_ID = NO_ID.Text
        If DD_MANUFAC_ID.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือก ประเภทกระบวนการ');", True)
        Else
            dao.fields.MENUFAC_ID = DD_MANUFAC_ID.SelectedValue
            dao.fields.MENUFAC_NAME = DD_MANUFAC_ID.SelectedItem.Text

            dao.fields.ACTIVEFACT = 1
            dao.fields.CREATE_DATE = Date.Now
            dao.fields.CREATE_USER = _CLS.THANM

            dao.insert()
        End If

        DD_MANUFAC_ID.ClearSelection()
        NO_ID.Text = ""

        RadGrid6.Rebind()
    End Sub
    Private Sub bind_manu()
        Dim dao_manu As New DAO_TABEAN_HERB.TB_TABEAN_HERB_MANUFACTRUE
        dao_manu.GetdatabyID_FK_IDA_DQ2(_IDA)

        RadGrid6.DataSource = dao_manu.datas

    End Sub

    Private Sub RadGrid6_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid6.NeedDataSource
        bind_manu()
    End Sub
    Private Sub RadGrid6_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid6.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim IDA As Integer = 0
            If e.CommandName = "result_delete" Then
                IDA = item("IDA").Text

                Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_MANUFACTRUE
                dao.GetdatabyID_IDA(IDA)
                dao.fields.ACTIVEFACT = 0
                dao.Update()
                RadGrid6.Rebind()
            End If
        End If
    End Sub
    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA)
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB
        dao.GetdatabyID_FK_IDA_DQ(_IDA)
        If DD_SYNDROME_ID.SelectedValue = "-- กรุณาเลือก --" Or DD_SALE_CHANNEL.SelectedValue = "-- กรุณาเลือก --" Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณากรอกข้อมูลให้ครับถ้วน');", True)
        Else
            Try
                dao.fields.SYNDROME_ID = DD_SYNDROME_ID.SelectedValue
                dao.fields.SYNDROME_NAME = DD_SYNDROME_ID.SelectedItem.Text
            Catch ex As Exception

            End Try
            Try
                dao.fields.SYNDROME_ID2 = DD_SYNDROME_ID2.SelectedValue
                dao.fields.SYNDROME_NAME2 = DD_SYNDROME_ID2.SelectedItem.Text
            Catch ex As Exception

            End Try
            Try
                dao.fields.SALE_CHANNEL_ID = DD_SALE_CHANNEL.SelectedValue
                dao.fields.SALE_CHANNEL_NAME = DD_SALE_CHANNEL.SelectedItem.Text
            Catch ex As Exception

            End Try

        End If
        dao.Update()
    End Sub
    Public Sub bind_dd_syndrome()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_SYNDROME_JJ()

        DD_SYNDROME_ID.DataSource = dt
        DD_SYNDROME_ID.DataBind()
        DD_SYNDROME_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub
    Public Sub bind_dd_syndrome2()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_SYNDROME_JJ()

        DD_SYNDROME_ID2.DataSource = dt
        DD_SYNDROME_ID2.DataBind()
        DD_SYNDROME_ID2.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub
    Public Sub bind_dd_manufac()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_DD_MAS_TABEAN_HERB_MENUFACTRUE()

        DD_MANUFAC_ID.DataSource = dt
        DD_MANUFAC_ID.DataBind()
        DD_MANUFAC_ID.Items.Insert(0, "-- กรุณาเลือก --")

    End Sub
    Public Sub bind_SALE_CHANNEL()
        Dim dt As DataTable
        Dim bao As New BAO_TABEAN_HERB.tb_dd
        dt = bao.SP_MAS_TABEAN_HERB_SALE()

        DD_SALE_CHANNEL.DataSource = dt
        DD_SALE_CHANNEL.DataBind()
        DD_SALE_CHANNEL.Items.Insert(0, "-- กรุณาเลือก --")
    End Sub
    Private Sub bind_size()
        Dim dao_size As New DAO_TABEAN_HERB.TB_TABEAN_HERB_SIZE_PACK_FST
        dao_size.GetdatabyID_FK_IDA_DQ2(_IDA)

        RadGrid7.DataSource = dao_size.datas

    End Sub

    Private Sub RadGrid7_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid7.NeedDataSource
        bind_size()
    End Sub
    'Protected Sub BTN_Add_Contains_Click(sender As Object, e As EventArgs) Handles BTN_Add_Contains.Click
    '    Response.Redirect("POPUP_TABEAN_STAFF_ADD_CONTAINS.aspx?IDA=" & _IDA & "&TR_ID=" & _TR_ID & "&process=" & _ProcessID & "&IDA_LCN=" & _IDA_LCN)
    'End Sub
    Protected Sub btn_dbd_Click(sender As Object, e As EventArgs) Handles btn_dbd.Click
        Dim dao_deeqt As New DAO_DRUG.ClsDBdrrqt
        dao_deeqt.GetDataby_IDA(_IDA)
        Dim IDENTIFY As String = _CLS.CITIZEN_ID
        Dim COMPANY_INDENTIFY As String = dao_deeqt.fields.CITIZEN_ID_AUTHORIZE
        Dim TOKEN As String = _CLS.TOKEN
        Dim TR_ID As String = "" 'รอพี่บิ๊กกำหนดชื่อตัวแปรอีกที
        Dim ORG As String = "HERB"
        TR_ID = "HB-" & _ProcessID & "-" & dao_deeqt.fields.DATE_YEAR & "-" & _TR_ID
        Dim URL As String = DBD_LINK(IDENTIFY, COMPANY_INDENTIFY, TR_ID, TOKEN)
        'Response.Redirect(URL)
        Response.Write("<script language='javascript'>window.open('" & URL & "','_blank','');")
        Response.Write("</script>")
    End Sub

    Protected Sub btn_Closed_Click(sender As Object, e As EventArgs) Handles btn_Closed.Click
        Response.Write("<script type='text/javascript'>parent.close_modal();</script> ")
    End Sub
End Class