Imports System.IO
Public Class FRM_HERB_TABEAN_MASTER_PREVIEW_FILE
    Inherits System.Web.UI.Page

    Private _id As Integer

    Private Sub get_querystring()
        _id = Request.QueryString("ida")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        get_querystring()
        If Not IsPostBack Then
            'load_pdf()
            bind_file()
            'load_pdf2()
        End If

    End Sub

    Private Sub bind_file()
        Dim dao As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_RECIPE_PRODUCT_JJ
        dao.GetdatabyID_IDA(_id)

        Dim FILENAME_XML As String = dao.fields.NAME_FAKE
        Dim bao As New BAO.AppSettings

        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ_MASTER")
        path_XML = "D:\XML_PDF_TABEAN_JJ\FILE_JJ_RECIPE_PRODUCT\" & FILENAME_XML

        Dim clsds As New ClassDataset
        Dim output As Byte()
        output = clsds.UpLoadImageByte(path_XML)

        Response.Clear()
        Response.ContentType = "application/pdf"
        Response.BinaryWrite(output)
        Response.Flush()
        Response.End()

    End Sub
    Private Sub load_pdf2()
        Dim dao As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_RECIPE_PRODUCT_JJ
        dao.GetdatabyID_IDA(_id)

        Dim FILENAME_XML As String = dao.fields.NAME_FAKE
        Dim bao As New BAO.AppSettings
        Dim FilePath As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ_MASTER")


        Dim filename = "D:\XML_PDF_TABEAN_JJ\FILE_JJ_RECIPE_PRODUCT\" & FILENAME_XML
        If filename.ToUpper.Contains(".PDF") Then
            filename = filename.Replace(".pdf", "")
        End If
        Try
            'Dim filepath = _CLS.FILENAME_PDF
            filepath = "D:\XML_PDF_TABEAN_JJ\FILE_JJ_RECIPE_PRODUCT\" & FILENAME_XML
            'Dim filepath = _CLS.PATH_PDF & "\" & filename & ".pdf"
            ' Dim filepath = bao_app._PATH_PDF_TEMPLATE & filename & ".pdf"
            Dim clsds As New ClassDataset
            load_pdf2(filepath)
        Catch ex As Exception
            Try
                'Dim filepath = "D:\path\XML_PDF_CER\PDF_TEMPLATE\" & filename & ".pdf"
                'Dim filepath = "D:\path\XML_PDF_CER\PDF_TEMPLATE\" & filename & ".pdf"
                FilePath = "D:\XML_PDF_TABEAN_JJ\FILE_JJ_RECIPE_PRODUCT\" & FILENAME_XML
                Dim clsds As New ClassDataset
                load_pdf2(filepath)
            Catch ex2 As Exception

            End Try
        End Try
    End Sub
    Private Sub load_pdf(ByVal FilePath As String)
        Dim clsds As New ClassDataset


        Dim bb As Byte()
        bb = clsds.UpLoadImageByte(FilePath)

        Dim ws_F As New WS_FLATTEN.WS_FLATTEN
        Dim b_o As Byte()
        b_o = ws_F.FlattenPDF_DIGITAL(bb)

        Response.Clear()
        Response.ContentType = "application/pdf"
        Response.AddHeader("content-length", b_o.Length.ToString())
        Response.BinaryWrite(b_o)
        Response.End()
    End Sub
    Private Sub load_pdf2(ByVal FilePath As String)

        Dim clsds As New ClassDataset
        Dim ws_F As New WS_FLATTEN.WS_FLATTEN
        Dim b_o As Byte()
        Dim bb As Byte()
        bb = clsds.UpLoadImageByte(FilePath)

        b_o = ws_F.FlattenPDF_DIGITAL(bb)
        Response.Clear()
        Response.ContentType = "Application/pdf"
        Response.BinaryWrite(b_o)
        Response.Flush()
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