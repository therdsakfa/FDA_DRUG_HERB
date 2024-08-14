Public Class UC_ATTACH
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private _NAME As String
    Public Property NAME() As String
        Get
            Return _NAME
        End Get
        Set(ByVal value As String)
            _NAME = value
        End Set
    End Property


    Public Sub BindData(ByVal name As String, ByVal piority As Integer, ByVal extension As String, ByVal lcntpcd As String, ByVal type As String)
        Label1.Text = name
        HiddenField1.Value = piority
        HiddenField2.Value = lcntpcd
        H_TYPE.Value = type
    End Sub

    Public Function insert(ByVal TR_ID As Integer) As Boolean
        Dim result As Boolean = True
        If HiddenField1.Value = 0 Then ' ไม่จำเป็นต้องมี
            If FileUpload1.HasFile Then

                insert_file(TR_ID)
            End If
        Else 'จำเป็นต้องแนบ
            If FileUpload1.HasFile Then
                insert_file(TR_ID)
            Else
                NAME = Label1.Text
                result = False
            End If
        End If
        Return result
    End Function

    'Sub get_label(ByVal text As String)
    '    Label1.Text = text ' ชื่อของ  label
    'End Sub

    Public Function insert_TB(ByVal TR_ID As Integer, ByVal PROCESS_ID As Integer, ByVal IDA_DR As Integer, ByVal TYPE_ID As Integer) As Boolean
        Dim result As Boolean = True
        If HiddenField1.Value = 0 Then ' ไม่จำเป็นต้องมี
            If FileUpload1.HasFile Then

                insert_file_TB(TR_ID, PROCESS_ID, IDA_DR, TYPE_ID)
            End If
        Else 'จำเป็นต้องแนบ
            If FileUpload1.HasFile Then
                insert_file_TB(TR_ID, PROCESS_ID, IDA_DR, TYPE_ID)
            Else
                NAME = Label1.Text
                result = False
            End If
        End If
        Return result
    End Function

    Public Function insert_TBN(ByVal TR_ID As Integer, ByVal PROCESS_ID As Integer, ByVal IDA_DR As Integer, ByVal TYPE_ID As Integer) As Boolean
        Dim result As Boolean = True
        If HiddenField1.Value = 0 Then ' ไม่จำเป็นต้องมี
            If FileUpload1.HasFile Then

                insert_file_TBN(TR_ID, PROCESS_ID, IDA_DR, TYPE_ID)
            End If
        Else 'จำเป็นต้องแนบ
            If FileUpload1.HasFile Then
                insert_file_TBN(TR_ID, PROCESS_ID, IDA_DR, TYPE_ID)
            Else
                NAME = Label1.Text
                result = False
            End If
        End If
        Return result
    End Function
    Public Function insert_TBN_Edit(ByVal TR_ID As Integer, ByVal PROCESS_ID As Integer, ByVal IDA_DR As Integer, ByVal TYPE_ID As Integer) As Boolean
        Dim result As Boolean = True
        If HiddenField1.Value = 0 Then ' ไม่จำเป็นต้องมี
            If FileUpload1.HasFile Then

                insert_file_TBN_Edit(TR_ID, PROCESS_ID, IDA_DR, TYPE_ID)
            End If
        Else 'จำเป็นต้องแนบ
            If FileUpload1.HasFile Then
                insert_file_TBN_Edit(TR_ID, PROCESS_ID, IDA_DR, TYPE_ID)
            Else
                NAME = Label1.Text
                result = False
            End If
        End If
        Return result
    End Function
    Public Function insert_JJ_EDIT(ByVal TR_ID As Integer, ByVal PROCESS_ID As Integer, ByVal IDA_DR As Integer, ByVal TYPE_ID As Integer) As Boolean
        Dim result As Boolean = True
        If HiddenField1.Value = 0 Then ' ไม่จำเป็นต้องมี
            If FileUpload1.HasFile Then

                insert_file_JJ_EDIT(TR_ID, PROCESS_ID, IDA_DR, TYPE_ID)
            End If
        Else 'จำเป็นต้องแนบ
            If FileUpload1.HasFile Then
                insert_file_JJ_EDIT(TR_ID, PROCESS_ID, IDA_DR, TYPE_ID)
            Else
                NAME = Label1.Text
                result = False
            End If
        End If
        Return result
    End Function
    Public Function insert_JJ2(ByVal TR_ID As Integer, ByVal PROCESS_ID As Integer, ByVal IDA_DR As Integer, ByVal TYPE_ID As Integer) As Boolean
        Dim result As Boolean = True
        If HiddenField1.Value = 0 Then ' ไม่จำเป็นต้องมี
            If FileUpload1.HasFile Then

                insert_file_JJ2(TR_ID, PROCESS_ID, IDA_DR, TYPE_ID)
            End If
        Else 'จำเป็นต้องแนบ
            If FileUpload1.HasFile Then
                insert_file_JJ2(TR_ID, PROCESS_ID, IDA_DR, TYPE_ID)
            Else
                NAME = Label1.Text
                result = False
            End If
        End If
        Return result
    End Function
    Public Function insert_JJ3(ByVal TR_ID As Integer, ByVal PROCESS_ID As Integer, ByVal IDA_DR As Integer, ByVal TYPE_ID As Integer) As Boolean
        Dim result As Boolean = True
        If HiddenField1.Value = 0 Then ' ไม่จำเป็นต้องมี
            If FileUpload1.HasFile Then

                insert_file_JJ3(TR_ID, PROCESS_ID, IDA_DR, TYPE_ID)
            End If
        Else 'จำเป็นต้องแนบ
            If FileUpload1.HasFile Then
                insert_file_JJ3(TR_ID, PROCESS_ID, IDA_DR, TYPE_ID)
            Else
                NAME = Label1.Text
                result = False
            End If
        End If
        Return result
    End Function
    Public Function insert_TBN_NEW(ByVal TR_ID As Integer, ByVal PROCESS_ID As Integer, ByVal IDA_DR As Integer, ByVal TYPE_ID As Integer) As Boolean
        Dim result As Boolean = True
        If HiddenField1.Value = 0 Then ' ไม่จำเป็นต้องมี
            If FileUpload1.HasFile Then

                insert_file_TBN_NEW(TR_ID, PROCESS_ID, IDA_DR, TYPE_ID)
            End If
        Else 'จำเป็นต้องแนบ
            If FileUpload1.HasFile Then
                insert_file_TBN_NEW(TR_ID, PROCESS_ID, IDA_DR, TYPE_ID)
            Else
                NAME = Label1.Text
                result = False
            End If
        End If
        Return result
    End Function
    Public Function insert_TBNTEMPO(ByVal TR_ID As Integer, ByVal PROCESS_ID As Integer, ByVal IDA_DR As Integer, ByVal TYPE_ID As Integer) As Boolean
        Dim result As Boolean = True
        If HiddenField1.Value = 0 Then ' ไม่จำเป็นต้องมี
            If FileUpload1.HasFile Then

                insert_file_TBNPEMPO(TR_ID, PROCESS_ID, IDA_DR, TYPE_ID)
            End If
        Else 'จำเป็นต้องแนบ
            If FileUpload1.HasFile Then
                insert_file_TBNPEMPO(TR_ID, PROCESS_ID, IDA_DR, TYPE_ID)
            Else
                NAME = Label1.Text
                result = False
            End If
        End If
        Return result
    End Function
    Public Function insert_lcn(ByVal TR_ID As Integer, ByVal PROCESS_ID As Integer, ByVal IDA_DR As Integer, ByVal TYPE_ID As Integer) As Boolean
        Dim result As Boolean = True
        If HiddenField1.Value = 0 Then ' ไม่จำเป็นต้องมี
            If FileUpload1.HasFile Then
                insert_file(TR_ID)
                'insert_file_lcn(TR_ID, PROCESS_ID, IDA_DR, TYPE_ID)
            End If
        Else 'จำเป็นต้องแนบ
            If FileUpload1.HasFile Then
                insert_file(TR_ID)
                'insert_file_lcn(TR_ID, PROCESS_ID, IDA_DR, TYPE_ID)
            Else
                NAME = Label1.Text
                result = False
            End If
        End If
        Return result
    End Function
    Public Function insert_master_flie_jj(ByVal PROCESS_ID As Integer, ByVal HERB_ID As Integer, ByVal TYPE_ID As Integer) As Boolean
        Dim result As Boolean = True
        If HiddenField1.Value = 0 Then ' ไม่จำเป็นต้องมี
            If FileUpload1.HasFile Then

                insert_master_flie(PROCESS_ID, HERB_ID, TYPE_ID)
            End If
        Else 'จำเป็นต้องแนบ
            If FileUpload1.HasFile Then
                insert_master_flie(PROCESS_ID, HERB_ID, TYPE_ID)
            Else
                NAME = Label1.Text
                result = False
            End If
        End If
        Return result
    End Function
    Public Function insert_TBN_RENEW(ByVal TR_ID As Integer, ByVal PROCESS_ID As Integer, ByVal IDA_DR As Integer, ByVal TYPE_ID As Integer) As Boolean
        Dim result As Boolean = True
        If HiddenField1.Value = 0 Then ' ไม่จำเป็นต้องมี
            If FileUpload1.HasFile Then

                insert_file_TBN_RENEW(TR_ID, PROCESS_ID, IDA_DR, TYPE_ID)
            End If
        Else 'จำเป็นต้องแนบ
            If FileUpload1.HasFile Then
                insert_file_TBN_RENEW(TR_ID, PROCESS_ID, IDA_DR, TYPE_ID)
            Else
                NAME = Label1.Text
                result = False
            End If
        End If
        Return result
    End Function
    Public Function insert_TBN_JR(ByVal TR_ID As Integer, ByVal PROCESS_ID As Integer, ByVal IDA_DR As Integer, ByVal TYPE_ID As Integer) As Boolean
        Dim result As Boolean = True
        If HiddenField1.Value = 0 Then ' ไม่จำเป็นต้องมี
            If FileUpload1.HasFile Then

                insert_file_TBN_JR(TR_ID, PROCESS_ID, IDA_DR, TYPE_ID)
            End If
        Else 'จำเป็นต้องแนบ
            If FileUpload1.HasFile Then
                insert_file_TBN_JR(TR_ID, PROCESS_ID, IDA_DR, TYPE_ID)
            Else
                NAME = Label1.Text
                result = False
            End If
        End If
        Return result
    End Function
    Private Sub insert_master_flie(ByVal PROCESS_ID As Integer, ByVal HERB_ID As Integer, ByVal TYPE_ID As Integer)
        Dim extensionname As String = GetExtension(FileUpload1.FileName)
        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ_MASTER")
        'FileUpload1.SaveAs(_PATH_FILE & "/FILE_UPLOAD/" & "HB_PDF-" & PROCESS_ID & "_" & con_year(Date.Now.Year) & "_" & TR_ID & "_" & TYPE_ID & "." & extensionname)
        If NAME = "" Then
            FileUpload1.SaveAs(_PATH_FILE & "/" & HERB_ID & ". " & FileUpload1.FileName & "." & extensionname)
        Else
            FileUpload1.SaveAs(_PATH_FILE & "/" & HERB_ID & ". " & NAME & "." & extensionname)
        End If

        '& "HB_PDF_MASTER_JJ_" & PROCESS_ID & "_" & con_year(Date.Now.Year) & "_" & HERB_ID & ". " & Label1.Text & "." & extensionname)

        Dim dao_file As New DAO_TABEAN_HERB.TB_MAS_TABEAN_HERB_RECIPE_PRODUCT_JJ
        dao_file.GetdatabyID_DD_HERB_NAME_PRODUCT_ID_AND_PROCESS_AND_TYPE(HERB_ID, PROCESS_ID, TYPE_ID)
        If dao_file.fields.IDA = 0 Then
            dao_file.fields.NAME_FAKE = HERB_ID & ". " & NAME & "." & extensionname
            dao_file.fields.NAME_REAL = FileUpload1.FileName
            dao_file.fields.DUCUMENT_NAME = HERB_ID & ". " & NAME
            dao_file.fields.TYPE = TYPE_ID
            dao_file.fields.PROCESS_ID = PROCESS_ID
            dao_file.fields.ACTIVE = 1
            dao_file.fields.CREATE_DATE = Date.Now
            dao_file.fields.DD_HERB_NAME_PRODUCT_ID = HERB_ID
            dao_file.insert()
        Else
            dao_file.fields.NAME_FAKE = HERB_ID & ". " & NAME & "." & extensionname
            dao_file.fields.NAME_REAL = FileUpload1.FileName
            dao_file.fields.DUCUMENT_NAME = HERB_ID & ". " & NAME
            dao_file.fields.TYPE = TYPE_ID
            dao_file.fields.PROCESS_ID = PROCESS_ID
            dao_file.fields.ACTIVE = 1
            dao_file.fields.CREATE_DATE = Date.Now
            dao_file.fields.DD_HERB_NAME_PRODUCT_ID = HERB_ID
            dao_file.Update()
        End If

    End Sub
    Private Sub insert_file(ByVal TR_ID As Integer)
        Dim extensionname As String = GetExtension(FileUpload1.FileName)
        FileUpload1.SaveAs(_PATH_DEFALUT & "/upload/" & TR_ID & "_" & H_TYPE.Value & "." & extensionname)
        Dim dao_file As New DAO_DRUG.ClsDBFILE_ATTACH


        dao_file.fields.NAME_FAKE = TR_ID & "_" & H_TYPE.Value & "." & extensionname
        dao_file.fields.NAME_REAL = FileUpload1.FileName
        'dao_file.fields.CREATE_DATE = Date.Now
        dao_file.fields.Description = Label1.Text
        'dao_file.fields.EXTENSION = extensionname
        'dao_file.fields.PATH = "upload"
        'dao_file.fields.UPDATE_DATE = Date.Now
        dao_file.fields.TYPE = H_TYPE.Value
        'dao_file.fields.LCNTPCD = HiddenField2.Value
        dao_file.fields.TRANSACTION_ID = TR_ID
        dao_file.insert()
    End Sub
    Private Sub insert_file_TBN_NEW(ByVal TR_ID As Integer, ByVal PROCESS_ID As Integer, ByVal IDA_DR As Integer, ByVal TYPE_ID As Integer)
        Dim extensionname As String = GetExtension(FileUpload1.FileName)
        Dim _PATH_FILE As String = ""
        If PROCESS_ID = 20910 Then
            _PATH_FILE = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_ANALYZE")
        ElseIf PROCESS_ID = 21010 Then
            _PATH_FILE = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_EXHIBITION")
        ElseIf PROCESS_ID = 21110 Then
            _PATH_FILE = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_DONATE")
        End If
        Dim dao_file As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        FileUpload1.SaveAs(_PATH_FILE & "/FILE_UPLOAD/" & "HB_PDF-" & PROCESS_ID & "_" & con_year(Date.Now.Year) & "_" & TR_ID & "_" & TYPE_ID & "." & extensionname)

        'dao_file.fields.NAME_FAKE = "HB_PDF" & TR_ID & "_" & H_TYPE.Value & "." & extensionname
        dao_file.fields.NAME_FAKE = "HB_PDF-" & PROCESS_ID & "_" & con_year(Date.Now.Year) & "_" & TR_ID & "_" & TYPE_ID & "." & extensionname
        dao_file.fields.NAME_REAL = FileUpload1.FileName
        dao_file.fields.DUCUMENT_NAME = Label1.Text
        dao_file.fields.TYPE = H_TYPE.Value
        dao_file.fields.TR_ID = TR_ID
        dao_file.fields.FK_IDA = IDA_DR
        dao_file.fields.PROCESS_ID = PROCESS_ID
        dao_file.fields.ACTIVE = 1
        dao_file.fields.CREATE_DATE = Date.Now

        dao_file.insert()
    End Sub
    Private Sub insert_file_TB(ByVal TR_ID As Integer, ByVal PROCESS_ID As Integer, ByVal IDA_DR As Integer, ByVal TYPE_ID As Integer)
        Dim extensionname As String = GetExtension(FileUpload1.FileName)
        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TB")
        'FileUpload1.SaveAs(_PATH_FILE & "/UPLOAD_FILE_JJ/" & TR_ID & "_" & H_TYPE.Value & "." & extensionname)
        FileUpload1.SaveAs(_PATH_FILE & "/UPLOAD_PDF_TABEAN_TB/" & "HB_PDF-" & PROCESS_ID & "_" & con_year(Date.Now.Year) & "_" & TR_ID & "_" & TYPE_ID & "_" & H_TYPE.Value & "." & extensionname)
        Dim dao_file As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ

        'dao_file.fields.NAME_FAKE = "HB_PDF" & TR_ID & "_" & H_TYPE.Value & "." & extensionname
        dao_file.fields.NAME_FAKE = "HB_PDF-" & PROCESS_ID & "_" & con_year(Date.Now.Year) & "_" & TR_ID & "_" & TYPE_ID & "_" & H_TYPE.Value & "." & extensionname
        dao_file.fields.NAME_REAL = FileUpload1.FileName
        dao_file.fields.DUCUMENT_NAME = Label1.Text
        dao_file.fields.TYPE = H_TYPE.Value
        dao_file.fields.TR_ID = TR_ID
        dao_file.fields.FK_IDA = IDA_DR
        dao_file.fields.PROCESS_ID = PROCESS_ID
        dao_file.fields.ACTIVE = 1
        dao_file.fields.CREATE_DATE = Date.Now

        dao_file.insert()
    End Sub
    Private Sub insert_file_JJ_EDIT(ByVal TR_ID As Integer, ByVal PROCESS_ID As Integer, ByVal IDA_DR As Integer, ByVal TYPE_ID As Integer)
        Dim extensionname As String = GetExtension(FileUpload1.FileName)
        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ_EDIT")
        'FileUpload1.SaveAs(_PATH_FILE & "/UPLOAD_FILE_JJ/" & TR_ID & "_" & H_TYPE.Value & "." & extensionname)
        FileUpload1.SaveAs(_PATH_FILE & "/FILE_UPLOAD/" & "HB_PDF-" & PROCESS_ID & "_" & con_year(Date.Now.Year) & "_" & TR_ID & "_" & TYPE_ID & "_" & H_TYPE.Value & "." & extensionname)
        Dim dao_file As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ

        'dao_file.fields.NAME_FAKE = "HB_PDF" & TR_ID & "_" & H_TYPE.Value & "." & extensionname
        dao_file.fields.NAME_FAKE = "HB_PDF-" & PROCESS_ID & "_" & con_year(Date.Now.Year) & "_" & TR_ID & "_" & TYPE_ID & "." & extensionname
        dao_file.fields.NAME_REAL = FileUpload1.FileName
        dao_file.fields.DUCUMENT_NAME = Label1.Text
        dao_file.fields.TYPE = H_TYPE.Value
        dao_file.fields.TR_ID = TR_ID
        dao_file.fields.FK_IDA = IDA_DR
        dao_file.fields.PROCESS_ID = PROCESS_ID
        dao_file.fields.ACTIVE = 1
        dao_file.fields.CREATE_DATE = Date.Now

        dao_file.insert()
    End Sub
    Private Sub insert_file_TBN(ByVal TR_ID As Integer, ByVal PROCESS_ID As Integer, ByVal IDA_DR As Integer, ByVal TYPE_ID As Integer)
        Dim extensionname As String = GetExtension(FileUpload1.FileName)
        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TBN")
        'FileUpload1.SaveAs(_PATH_FILE & "/UPLOAD_FILE_JJ/" & TR_ID & "_" & H_TYPE.Value & "." & extensionname)
        FileUpload1.SaveAs(_PATH_FILE & "/UPLOAD_PDF_TABEAN_TBN/" & "HB_PDF-" & PROCESS_ID & "_" & con_year(Date.Now.Year) & "_" & TR_ID & "_" & TYPE_ID & "_" & H_TYPE.Value & "." & extensionname)
        Dim dao_file As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ

        'dao_file.fields.NAME_FAKE = "HB_PDF" & TR_ID & "_" & H_TYPE.Value & "." & extensionname
        dao_file.fields.NAME_FAKE = "HB_PDF-" & PROCESS_ID & "_" & con_year(Date.Now.Year) & "_" & TR_ID & "_" & TYPE_ID & "_" & H_TYPE.Value & "." & extensionname
        dao_file.fields.NAME_REAL = FileUpload1.FileName
        dao_file.fields.DUCUMENT_NAME = Label1.Text
        dao_file.fields.TYPE = H_TYPE.Value
        dao_file.fields.TR_ID = TR_ID
        dao_file.fields.FK_IDA = IDA_DR
        dao_file.fields.PROCESS_ID = PROCESS_ID
        dao_file.fields.ACTIVE = 1
        dao_file.fields.CREATE_DATE = Date.Now

        dao_file.insert()
    End Sub
    Private Sub insert_file_TBNPEMPO(ByVal TR_ID As Integer, ByVal PROCESS_ID As Integer, ByVal IDA_DR As Integer, ByVal TYPE_ID As Integer)
        Dim extensionname As String = GetExtension(FileUpload1.FileName)
        Dim _PATH_FILE As String = ""
        _PATH_FILE = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_TEMPO")

        Dim dao_file As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ
        FileUpload1.SaveAs(_PATH_FILE & "/FILE_UPLOAD/" & "HB-" & PROCESS_ID & "_" & con_year(Date.Now.Year) & "_" & TR_ID & "." & extensionname)

        'dao_file.fields.NAME_FAKE = "HB_PDF" & TR_ID & "_" & H_TYPE.Value & "." & extensionname
        dao_file.fields.NAME_FAKE = "HB-" & PROCESS_ID & "_" & con_year(Date.Now.Year) & "_" & TR_ID & "." & extensionname
        dao_file.fields.NAME_REAL = FileUpload1.FileName
        dao_file.fields.DUCUMENT_NAME = Label1.Text
        dao_file.fields.TYPE = H_TYPE.Value
        dao_file.fields.TR_ID = TR_ID
        dao_file.fields.FK_IDA = IDA_DR
        dao_file.fields.PROCESS_ID = PROCESS_ID
        dao_file.fields.ACTIVE = 1
        dao_file.fields.CREATE_DATE = Date.Now

        dao_file.insert()
    End Sub
    Private Sub insert_file_TBN_Edit(ByVal TR_ID As Integer, ByVal PROCESS_ID As Integer, ByVal IDA_DR As Integer, ByVal TYPE_ID As Integer)
        Dim extensionname As String = GetExtension(FileUpload1.FileName)
        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_EDIT")
        'FileUpload1.SaveAs(_PATH_FILE & "/UPLOAD_FILE_JJ/" & TR_ID & "_" & H_TYPE.Value & "." & extensionname)
        FileUpload1.SaveAs(_PATH_FILE & "/FILE_UPLOAD/" & "HB_PDF-" & PROCESS_ID & "_" & con_year(Date.Now.Year) & "_" & TR_ID & "_" & TYPE_ID & "_" & H_TYPE.Value & "." & extensionname)
        Dim dao_file As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ

        'dao_file.fields.NAME_FAKE = "HB_PDF" & TR_ID & "_" & H_TYPE.Value & "." & extensionname
        dao_file.fields.NAME_FAKE = "HB_PDF-" & PROCESS_ID & "_" & con_year(Date.Now.Year) & "_" & TR_ID & "_" & TYPE_ID & "_" & H_TYPE.Value & "." & extensionname
        dao_file.fields.NAME_REAL = FileUpload1.FileName
        dao_file.fields.DUCUMENT_NAME = Label1.Text
        dao_file.fields.TYPE = H_TYPE.Value
        dao_file.fields.TR_ID = TR_ID
        dao_file.fields.FK_IDA = IDA_DR
        dao_file.fields.PROCESS_ID = PROCESS_ID
        dao_file.fields.ACTIVE = 1
        dao_file.fields.CREATE_DATE = Date.Now

        dao_file.insert()
    End Sub
    Private Sub insert_file_TBN_RENEW(ByVal TR_ID As Integer, ByVal PROCESS_ID As Integer, ByVal IDA_DR As Integer, ByVal TYPE_ID As Integer)
        Dim extensionname As String = GetExtension(FileUpload1.FileName)
        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_RENEW")
        'FileUpload1.SaveAs(_PATH_FILE & "/UPLOAD_FILE_JJ/" & TR_ID & "_" & H_TYPE.Value & "." & extensionname)
        FileUpload1.SaveAs(_PATH_FILE & "/FILE_UPLOAD/" & "HB_PDF-" & PROCESS_ID & "_" & con_year(Date.Now.Year) & "_" & TR_ID & "_" & TYPE_ID & "_" & H_TYPE.Value & "." & extensionname)
        Dim dao_file As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ

        'dao_file.fields.NAME_FAKE = "HB_PDF" & TR_ID & "_" & H_TYPE.Value & "." & extensionname
        dao_file.fields.NAME_FAKE = "HB_PDF-" & PROCESS_ID & "_" & con_year(Date.Now.Year) & "_" & TR_ID & "_" & TYPE_ID & "." & extensionname
        dao_file.fields.NAME_REAL = FileUpload1.FileName
        dao_file.fields.DUCUMENT_NAME = Label1.Text
        dao_file.fields.TYPE = H_TYPE.Value
        dao_file.fields.TR_ID = TR_ID
        dao_file.fields.FK_IDA = IDA_DR
        dao_file.fields.PROCESS_ID = PROCESS_ID
        dao_file.fields.ACTIVE = 1
        dao_file.fields.CREATE_DATE = Date.Now

        dao_file.insert()
    End Sub
    Private Sub insert_file_TBN_JR(ByVal TR_ID As Integer, ByVal PROCESS_ID As Integer, ByVal IDA_DR As Integer, ByVal TYPE_ID As Integer)
        Dim extensionname As String = GetExtension(FileUpload1.FileName)
        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_INFORM")
        'FileUpload1.SaveAs(_PATH_FILE & "/UPLOAD_FILE_JJ/" & TR_ID & "_" & H_TYPE.Value & "." & extensionname)
        FileUpload1.SaveAs(_PATH_FILE & "/FILE_UPLOAD/" & "HB_PDF-" & PROCESS_ID & "_" & con_year(Date.Now.Year) & "_" & TR_ID & "_" & TYPE_ID & "_" & H_TYPE.Value & "." & extensionname)
        Dim dao_file As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ

        'dao_file.fields.NAME_FAKE = "HB_PDF" & TR_ID & "_" & H_TYPE.Value & "." & extensionname
        dao_file.fields.NAME_FAKE = "HB_PDF-" & PROCESS_ID & "_" & con_year(Date.Now.Year) & "_" & TR_ID & "_" & TYPE_ID & "." & extensionname
        dao_file.fields.NAME_REAL = FileUpload1.FileName
        dao_file.fields.DUCUMENT_NAME = Label1.Text
        dao_file.fields.TYPE = H_TYPE.Value
        dao_file.fields.TR_ID = TR_ID
        dao_file.fields.FK_IDA = IDA_DR
        dao_file.fields.PROCESS_ID = PROCESS_ID
        dao_file.fields.ACTIVE = 1
        dao_file.fields.CREATE_DATE = Date.Now

        dao_file.insert()
    End Sub
    Private Sub insert_file_JJ2(ByVal TR_ID As Integer, ByVal PROCESS_ID As Integer, ByVal IDA_DR As Integer, ByVal TYPE_ID As Integer)
        Dim extensionname As String = GetExtension(FileUpload1.FileName)
        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ")
        FileUpload1.SaveAs(_PATH_FILE & "/UPLOAD_FILE_JJ/" & "HB_PDF-" & PROCESS_ID & "_" & con_year(Date.Now.Year) & "_" & TR_ID & "_" & TYPE_ID & "_" & H_TYPE.Value & "." & extensionname)

        Dim dao_file As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ

        'dao_file.fields.NAME_FAKE = "HB_PDF" & TR_ID & "_" & H_TYPE.Value & "." & extensionname
        dao_file.fields.NAME_FAKE = "HB_PDF-" & PROCESS_ID & "_" & con_year(Date.Now.Year) & "_" & TR_ID & "_" & TYPE_ID & "_" & H_TYPE.Value & "." & extensionname
        dao_file.fields.NAME_REAL = FileUpload1.FileName
        dao_file.fields.DUCUMENT_NAME = Label1.Text
        dao_file.fields.TYPE = H_TYPE.Value
        dao_file.fields.TR_ID = TR_ID
        dao_file.fields.FK_IDA = IDA_DR
        dao_file.fields.PROCESS_ID = PROCESS_ID
        dao_file.fields.ACTIVE = 1
        dao_file.fields.CREATE_DATE = Date.Now

        dao_file.insert()

    End Sub
    Private Sub insert_file_JJ3(ByVal TR_ID As Integer, ByVal PROCESS_ID As Integer, ByVal IDA_DR As Integer, ByVal TYPE_ID As Integer)
        Dim extensionname As String = GetExtension(FileUpload1.FileName)
        Dim _PATH_FILE As String = System.Configuration.ConfigurationManager.AppSettings("PATH_XML_PDF_TABEAN_JJ_EDIT")
        FileUpload1.SaveAs(_PATH_FILE & "/FILE_UPLOAD/" & "HB_PDF-" & PROCESS_ID & "_" & con_year(Date.Now.Year) & "_" & TR_ID & "_" & TYPE_ID & "." & extensionname)

        Dim dao_file As New DAO_TABEAN_HERB.TB_TABEAN_HERB_UPLOAD_FILE_JJ

        'dao_file.fields.NAME_FAKE = "HB_PDF" & TR_ID & "_" & H_TYPE.Value & "." & extensionname
        dao_file.fields.NAME_FAKE = "HB_PDF-" & PROCESS_ID & "_" & con_year(Date.Now.Year) & "_" & TR_ID & "_" & TYPE_ID & "." & extensionname
        dao_file.fields.NAME_REAL = FileUpload1.FileName
        dao_file.fields.DUCUMENT_NAME = Label1.Text
        dao_file.fields.TYPE = H_TYPE.Value
        dao_file.fields.TR_ID = TR_ID
        dao_file.fields.FK_IDA = IDA_DR
        dao_file.fields.PROCESS_ID = PROCESS_ID
        dao_file.fields.ACTIVE = 1
        dao_file.fields.CREATE_DATE = Date.Now

        dao_file.insert()

    End Sub
    Public Function CHK_TBN()
        Dim result As Boolean = True
        If FileUpload1.HasFile = False Then
            result = False
        End If
        Return result
    End Function

    Public Function CHK_JJ()
        Dim result As Boolean = True
        If FileUpload1.HasFile = False Then
            result = False
        End If
        Return result
    End Function
    Public Function CHK_MASTER_FILE_JJ()
        Dim result As Boolean = True
        If FileUpload1.HasFile = False Then
            result = False
        End If
        Return result
    End Function
End Class