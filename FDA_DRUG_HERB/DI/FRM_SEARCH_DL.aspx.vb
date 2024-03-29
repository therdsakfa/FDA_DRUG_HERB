﻿Imports System.IO
Imports System.Xml.Serialization
Imports FDA_DRUG_HERB.XML_CENTER
Imports Telerik.Web.UI
Public Class FRM_SEARCH_DL
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION             'ประกาศชื่อตัวแปรของ   CLS_SESSION 
    Private _process As String = ""                'ประกาศชื่อตัวแปร _process
    Private _lcn_ida As String = ""
    Private _lct_ida As String = ""
    Private _type As String
    Private _process_for As String

    ''' <summary>
    ''' ฟังก์ชันเรียกใช้ Session
    ''' </summary>
    ''' <remarks></remarks>
    Sub RunSession()

        Try
            _CLS = Session("CLS")
            ''นำค่า Session ใส่ ในตัวแปร _CLS
            _process = Request.QueryString("process")           'เรียก Process ที่เราเรียก
            '_lct_ida = Request.QueryString("lct_ida")
            '_type = Request.QueryString("type")
            '_process_for = Request.QueryString("process_for")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")  'เกิด  ERROR  จะเกิดกลับมาหน้า privus
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()                'ให้รันฟังก์ชั่นลำดับที่ 1
        If Not IsPostBack Then      'ให้รันฟังก์ชั่นลำดับที่ 2

            load_ddl()
            'load_lbl_name()         'ให้รันฟังก์ชั่นลำดับที่ 4
            load_HL()

        End If
        'UC_INFMT1.Shows(_lct_ida)
    End Sub
    Private Sub load_ddl()
        Dim dao As New DAO_DRUG.ClsDBDRUG_REGISTRATION
        dao.GetDataby_FK_IDA2(Request.QueryString("lcn_ida"))
        'Dim item As New ListItem("---กรุณาเลือก---", "0")

        rcb_search.DataSource = dao.Details 'dao.datas
        rcb_search.DataTextField = "RCVNO_DISPLAY"
        rcb_search.DataValueField = "IDA"
        rcb_search.DataBind()
        Dim item As New RadComboBoxItem
        item.Text = "---กรุณาเลือก---"
        item.Value = "0"
        rcb_search.Items.Insert(0, item)
    End Sub
    Private Sub load_HL()
        'hl_pay.NavigateUrl = "https://platba.FDA.MOPH.GO.TH/FDA_FEE/MAIN/check_token.aspx?Token=" & _CLS.TOKEN & "&system=drug&ida_location=" & 0
    End Sub


    Sub OpenPopupName(ByVal url As String)
        Dim strPopup As String = " window.open('" + url + "', 'popup', 'width=600,height=330,left=250,top=140,toolbar=1,status=1');"
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strPopup, True)
    End Sub



#Region "GRIDVIEW"



#End Region



    Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>alert('" + text + "');</script> ") 'จาวาคำสั่ง Alert
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadPdf()
    End Sub
    Private Sub LoadPdf() 'ทำการดาวห์โหลดลงเครื่อง
        Dim bao As New BAO.AppSettings
        bao.RunAppSettings()
        Dim clsds As New ClassDataset
        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & _CLS.PDFNAME)
        Response.BinaryWrite(clsds.UpLoadImageByte(_CLS.FILENAME_PDF)) '"C:\path\PDF_XML_CLASS\"
        Response.Flush()
        Response.Close()
        Response.End()
    End Sub

    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        If rcb_search.SelectedValue <> "0" Then
            Dim url As String = ""
            Dim NYM As String = ""
            If _process = "1026" Or _process = "1027" Or _process = "1028" Or _process = "1029" Or _process = "1030" Then
                Select Case _process
                    Case "1027"
                        NYM = "2"
                    Case "1028"
                        NYM = "3"
                    Case "1029"
                        NYM = "4"
                    Case "1030"
                        NYM = "5"
                End Select
                url = "http://164.115.20.224/FDA_DRUG_IMPORT/AUTHEN/AUTHEN_GATEWAY?TOKEN=" & _CLS.TOKEN & "&DL=" & rcb_search.SelectedValue & "&NYM=" & NYM
                Response.Redirect(url)
            End If
        Else
            alert("กรุณาเลือกเลขบัญชีรายการยา")
        End If

    End Sub
End Class