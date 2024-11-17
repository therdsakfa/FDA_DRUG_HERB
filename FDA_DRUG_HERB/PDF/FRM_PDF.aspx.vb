Imports System.Net
Imports System.IO
Imports iTextSharp.text.pdf
Imports System.Xml.Serialization
Imports FDA_DRUG_HERB.XML_CENTER

Public Class WebForm1
    Inherits System.Web.UI.Page
    Private _FileName As String
    Sub runQuery()
        _FileName = Request.QueryString("FileName")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
        Try
            If String.IsNullOrEmpty(_FileName) Then
                ' ถ้า _FileName เป็นค่าว่าง
                load_pdf(_FileName)
            ElseIf _FileName.Contains("543-0") Then
                ' ถ้า _FileName มี "543-0"
                System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "Codeblock", "alert('ขณะนี้ระบบการแสดงข้อมูลผ่าน qr code มีปัญหา ท่านสามารถตรวจสอบข้อมูล ใบอนุญาตผลิตภัณฑ์สมุนไพรได้ที่ https://porta.fda.moph.go.th/fda_search_all/main/search_center_main.aspx การค้นหา เลือกหัวข้อสืบค้นสถานที่สมุนไพร โดยใช้ชื่อ หรือ เลขที่ใบอนุญาต');window.location.href = 'https://porta.fda.moph.go.th/fda_search_all/main/search_center_main.aspx';", True)

            Else
                ' ถ้า _FileName ไม่เป็นค่าว่างและไม่มี "543-0"
                load_pdf(_FileName)
            End If

        Catch ex As Exception
            If ex.Message.Contains("another") Then
                Response.Write("<script type='text/javascript'>alert('ขออภัย ขณะนี้เจ้าหน้าที่กำลังเปิด pdf นี้อยู่');parent.close_modal();</script> ")
            Else
                Response.Write("<script type='text/javascript'>alert('เกิดข้อผิดพลาดบางประการ');parent.close_modal();</script> ")
            End If
        End Try

    End Sub

    'Private Sub load_pdf(ByVal FilePath As String)
    '    Response.ContentType = "Application/pdf"
    '    Response.WriteFile(FilePath)
    '    Response.End()
    'End Sub

    Private Sub load_pdf(ByVal FilePath As String)


        '  Response.ContentType = "Application/pdf"

        Dim clsds As New ClassDataset

        Dim bb As Byte()
        Try
            If String.IsNullOrEmpty(_FileName) Then
                bb = Session("PDFFile")
            Else
                bb = clsds.UpLoadImageByte(FilePath)
            End If

        Catch ex As Exception
            bb = Session("PDFFile")
        End Try

        Dim ws_F As New WS_FLATTEN.WS_FLATTEN
        Dim b_o As Byte()
        'If Request.QueryString("status") = "1" Then
        '    b_o = ws_F.PDF_DIGITAL_SIGN(bb)
        'Else
        b_o = ws_F.FlattenPDF_DIGITAL(bb)
        'End If

        Response.Clear()
        Response.ContentType = "application/pdf"
        Response.AddHeader("content-length", b_o.Length.ToString())
        Response.BinaryWrite(b_o)



        'Response.Clear()
        'Response.ContentType = "application/pdf"
        'Response.AddHeader("Content-Disposition", "attachment;filename=abc.pdf")

        'Response.BinaryWrite(clsds.UpLoadImageByte(FilePath))

        'Response.Flush()

        Response.End()
    End Sub


    Public Function UpLoadImageByte(ByVal info As String) As Byte()
        Dim stream As New FileStream(info.Replace("/", "\"), FileMode.Open)
        Dim reader As New BinaryReader(stream)
        Dim imgBin() As Byte
        Try
            imgBin = reader.ReadBytes(stream.Length)
        Catch ex As Exception
        Finally
            stream.Close()
            reader.Close()
        End Try
        Return imgBin
    End Function
End Class