Imports System.IO
Imports System.Xml.Serialization

Public Class TEST
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim XML As New CLS_TEST_XML
        'Xml.JJ_1 = 1

        'Dim dt As DataTable
        'Dim bao As New BAO_TABEAN_HERB.tb_dd
        'dt = bao.SP_DD_MAS_TABEAN_HERB_NAME_JJ()
        'dt.TableName = "SP_DD_MAS_TABEAN_HERB_NAME_JJ"
        'XML.DT_SHOW.DT1 = dt


        'Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_DEFALUT") 'path
        ''Dim Path_XML As String = _PATH_FILE & "cmt_chemical.xml" 'ชื่อไฟล์
        'Dim Path_XML As String = _PATH_FILE & NAME_UPLOAD_XML("HB", "789", Date.Now.Year, "1") 'ชื่อไฟล์

        ''Dim name_xml As String = "cmt_chemical.xml"

        'Dim objStreamWriter As New StreamWriter(Path_XML)
        'Dim x As New XmlSerializer(XML.GetType) 'ส่ง class ไป
        'x.Serialize(objStreamWriter, XML)
        'objStreamWriter.Close()



    End Sub

End Class