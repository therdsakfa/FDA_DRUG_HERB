Public Class Main_PPK
    Inherits System.Web.UI.MasterPage
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            _CLS = Session("CLS")
            '_thanm_customer = Session("thanm_customer")
            '    _thanm = Session("thanm")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()

        Try
            If Request.QueryString("FK_IDA") <> "" Then
                'HyperLink1.NavigateUrl = "../LOCATION/FRM_LCN_LCT.aspx?FK_IDA=" & Request.QueryString("FK_IDA")
            Else
                'HyperLink1.NavigateUrl = "../LOCATION/FRM_LCN_LCT.aspx"
            End If
        Catch ex As Exception

        End Try

        If Not IsPostBack Then
            run_nav_new()
            Try
                hl_name.Text = "ชื่อผู้ใช้" & " " & _CLS.THANM 'รับค่า ชื่อผู้ใช้
                hl_organization.Text = "ชื่อผู้ได้รับอนุญาต" & " " & _CLS.THANM_CUSTOMER 'รับค่า ชื่อผู้ได้รับอนุญาต
            Catch ex As Exception

            End Try

        End If
        'UC_NODE_AUTO.group = 6
    End Sub

    Public Sub run_nav_new()
        Dim dao_h As New DAO_DRUG.TB_MAS_ADMIN_GROUP_BUTTON
        Dim gg As String = ""
        Try
            gg = _CLS.SYSTEM_ID
        Catch ex As Exception

        End Try
        If gg <> "" Then
            Try
                dao_h.GetData_By_Group_Order_By_Seq(gg)
            Catch ex As Exception

            End Try

            Dim str_all As String = ""
            'For Each dao_h.fields In dao_h.datas
            If str_all = "" Then
                If _CLS.BTN_GROUPS = 1 Then
                    str_all = "<h4 class='text-center'><strong>" & "ระบบสร้างคำขอทะเบียน" & "</strong></h4>"

                Else
                    str_all = "<h4 class='text-center'><strong>" & "คำขออื่นๆ" & "</strong></h4>"

                End If
                Dim p_name As String = ""
                Try
                    p_name = get_page_name()
                Catch ex As Exception

                End Try
                Dim aa As Integer = 0

                Try
                    aa = _CLS.GROUPS
                Catch ex As Exception

                End Try
                Dim _group As Integer = 0
                If aa = 9819 Then
                    _CLS.BTN_GROUPS = 1
                ElseIf _CLS.SYSTEM_ID = "11251" Then
                    _group = 3
                Else
                    '_CLS.BTN_GROUPS = 2
                    _group = 2
                End If
                '_group = 2
                Dim sm As Integer = 0
                Try
                    sm = _CLS.SYSTEM_ID
                Catch ex As Exception

                End Try
                If sm = 10986 Then
                    sm = 10986
                End If
                Dim dao_g As New DAO_TABEAN_HERB.TB_MAS_CUSTOMER_BUTTON
                'dao_g.GetDataby_Btn_Group_and_IdGroup(_CLS.BTN_GROUPS, sm)
                dao_g.GetDataby_Btn_Group_and_IdGroup(_group, _CLS.SYSTEM_ID)

                str_all &= "<ul class='nav nav-pills nav-stacked'>"
                For Each dao_g.fields In dao_g.datas
                    Dim dao_u As New DAO_TABEAN_HERB.TB_MAS_CUSTOMER_BUTTON
                    Dim i As Integer = 0
                    If p_name <> "" Then
                        'i = dao_u.Check_Page(p_name, _CLS.Groups)
                        Try
                            If CStr(dao_g.fields.BTN_URL).Contains(p_name) Then
                                i += 1
                            End If
                        Catch ex As Exception

                        End Try

                    End If
                    If i = 0 Then
                        str_all &= "<li>"
                    Else
                        str_all &= "<li class='active'>"
                    End If
                    If dao_g.fields.BTN_URL.Contains("TOKEN") Or dao_g.fields.BTN_URL.Contains("AUTHEN") Then
                        str_all &= "<a href='" & dao_g.fields.BTN_URL & "?Token=" & _CLS.TOKEN & "' target='_blank'>" & dao_g.fields.BTN_NAME & "</a>"
                    Else
                        str_all &= "<a href='" & dao_g.fields.BTN_URL & "' target='" & dao_g.fields.TARGET & "'>" & dao_g.fields.BTN_NAME & "</a>"
                    End If

                    str_all &= "</li>"
                    'i += 1
                Next
                str_all &= "</ul><br/>"

            Else
                str_all &= "<h4 class='text-center'><strong>" & dao_h.fields.GROUP_NAME & "</strong></h4>"
                Dim p_name As String = ""
                Try
                    p_name = get_page_name()
                Catch ex As Exception

                End Try
                Dim aa As Integer = 0

                Try
                    aa = _CLS.GROUPS
                Catch ex As Exception

                End Try
                Dim _group As Integer = 0
                If aa = 9819 Then
                    _group = 1
                ElseIf _CLS.SYSTEM_ID = "11251" Then
                    _group = 3
                Else
                    _group = 2
                End If
                '_group = 2
                Dim sm As Integer = 0
                Try
                    sm = _CLS.SYSTEM_ID
                Catch ex As Exception

                End Try
                If sm = 9819 Or sm = 10986 Then
                    sm = 10986
                End If
                Dim dao_g As New DAO_TABEAN_HERB.TB_MAS_CUSTOMER_BUTTON
                'dao_g.GetDataby_Btn_Group_and_IdGroup(_CLS.BTN_GROUPS, sm)
                dao_g.GetDataby_Btn_Group_and_IdGroup(_group, _CLS.SYSTEM_ID)

                str_all &= "<ul class='nav nav-pills nav-stacked'>"
                For Each dao_g.fields In dao_g.datas
                    Dim dao_u As New DAO_TABEAN_HERB.TB_MAS_CUSTOMER_BUTTON
                    Dim i As Integer = 0
                    If p_name <> "" Then
                        'i = dao_u.Check_Page(p_name, _CLS.Groups)
                        Try
                            If CStr(dao_g.fields.BTN_URL).Contains(p_name) Then
                                i += 1
                            End If
                        Catch ex As Exception

                        End Try

                    End If
                    If i = 0 Then
                        str_all &= "<li>"
                    Else
                        str_all &= "<li class='active'>"
                    End If
                    If dao_g.fields.BTN_URL.Contains("TOKEN") Or dao_g.fields.BTN_URL.Contains("AUTHEN") Then
                        str_all &= "<a href='" & dao_g.fields.BTN_URL & "?Token=" & _CLS.TOKEN & "' target='_blank'>" & dao_g.fields.BTN_NAME & "</a>"
                    Else
                        str_all &= "<a href='" & dao_g.fields.BTN_URL & "' target='" & dao_g.fields.TARGET & "'>" & dao_g.fields.BTN_NAME & "</a>"
                    End If

                    str_all &= "</li>"
                    'i += 1
                Next
                str_all &= "</ul><br/>"
            End If
            Literal1.Text = str_all
            'Next
        End If

    End Sub
    Public Function get_page_name()
        Dim p_name As String = ""
        p_name = System.IO.Path.GetFileName(Request.Url.AbsolutePath)
        Return p_name
    End Function
End Class