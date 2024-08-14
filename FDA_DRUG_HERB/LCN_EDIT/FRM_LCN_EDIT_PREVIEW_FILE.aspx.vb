Public Class FRM_LCN_EDIT_PREVIEW_FILE
    Inherits System.Web.UI.Page


    Private _file_ida As Integer
    Private _lcn_ida As Integer


    Private Sub get_querystring()

        _file_ida = Request.QueryString("file_id")
        _lcn_ida = Request.QueryString("lcn_ida")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        get_querystring()
        If Not IsPostBack Then
            bind_file(_file_ida, _lcn_ida)
        End If

    End Sub

    Private Sub bind_file(ByVal file_id As Integer, ByVal lcn As Integer)
        'Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        'dao.GetdatabyID_IDA(_id)

        Dim dao1 As New DAO_LCN.TB_LCN_APPROVE_EDIT_UPLOAD_FILE
        dao1.GET_DATA_BY_FILE_NUMBER(file_id, lcn)

        Dim FILENAME_XML As String = dao1.fields.NAME_FAKE
        Dim bao As New BAO.AppSettings

        Dim paths As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_SMP3")
        'Dim paths As String = bao._PATH_DEFAULT


        Dim PATH_XML As String
        PATH_XML = paths & "FILE_UPLOAD\" & FILENAME_XML
        'PATH_XML = paths & "\upload\" & "DA-120-2021-220969-36.pdf"

        Dim clsds As New ClassDataset
        Dim output As Byte()
        output = clsds.UpLoadImageByte(PATH_XML)

        Response.Clear()
        Response.ContentType = "application/pdf"
        Response.BinaryWrite(output)
        Response.Flush()
        Response.End()

    End Sub

End Class