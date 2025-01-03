﻿Public Class FRM_HERB_TABEAN_JJ_PREVIEW_JJ2_UPLOAD
    Inherits System.Web.UI.Page
    Private _id As Integer
    Private _TR_ID As Integer
    Private _PROCESS_JJ As Integer

    Private Sub get_querystring()
        _id = Request.QueryString("ida")
        _TR_ID = Request.QueryString("TR_ID")
        _PROCESS_JJ = Request.QueryString("PROCESS_JJ")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        get_querystring()
        If Not IsPostBack Then
            bind_file()
        End If
    End Sub

    Private Sub bind_file()
        Dim dao As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        dao.GetdatabyID_TR_ID_PROCESS_TYPE_FK_IDA(_TR_ID, _PROCESS_JJ, 13, _id)

        Dim FILENAME_XML As String = dao.fields.NAME_FAKE
        Dim bao As New BAO.AppSettings

        Dim paths As String = bao._PATH_XML_PDF_TABEAN_JJ

        Dim PATH_XML As String
        PATH_XML = paths & "UPLOAD_FILE_JJ\" & FILENAME_XML

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