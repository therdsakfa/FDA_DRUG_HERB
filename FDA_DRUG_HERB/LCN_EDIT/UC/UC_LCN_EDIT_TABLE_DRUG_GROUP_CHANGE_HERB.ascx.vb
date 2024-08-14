Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO

Imports System.Data
Imports iTextSharp.text
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf

Public Class UC_LCN_EDIT_TABLE_DRUG_GROUP_CHANGE_HERB
    Inherits System.Web.UI.UserControl
    Private _lcn_ida As String
    Private Sub RunQuery()
        _lcn_ida = Request.QueryString("LCN_IDA")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'bind_table(_lcn_ida)
        'bind_type(_lcn_ida)
    End Sub

    Sub bind_type(ByVal IDA As Integer)
        Dim dao As New DAO_DRUG.ClsDBdalcn
        Try
            'dao.GetDataby_IDA(Request.QueryString("ida"))
            dao.GetDataby_IDA(IDA)
            If dao.fields.lcntpcd = "ขสม" Then
                rdl_drug_type.SelectedValue = "1"
            ElseIf dao.fields.lcntpcd = "นสม" Then
                rdl_drug_type.SelectedValue = "2"
            ElseIf dao.fields.lcntpcd = "ผสม" Then
                rdl_drug_type.SelectedValue = "3"
            End If
        Catch ex As Exception

        End Try

    End Sub
    Sub bind_table_ddl5(ByVal _LCN_IDA As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal _detial_type As Integer)
        'Table1.BorderStyle = BorderStyle.Solid
        'Table1.BorderWidth = 1
        bind_head()
        Dim dao As New DAO_DRUG.TB_MAS_DRUG_GROUP_HERB
        dao.GetDataAll()

        For Each dao.fields In dao.datas
            If dao.fields.TYPE_SHOW = 1 Then

                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dc4 As New TableCell
                Dim dc5 As New TableCell
                'Dim dc6 As New TableCell
                'Dim dc7 As New TableCell
                Dim dc8 As New TableCell
                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")
                Dim dr As New TableRow
                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1
                dc4.BorderStyle = BorderStyle.Solid
                dc4.BorderWidth = 1
                dc5.BorderStyle = BorderStyle.Solid
                dc5.BorderWidth = 1
                'dc6.BorderStyle = BorderStyle.Solid
                'dc6.BorderWidth = 1
                'dc7.BorderStyle = BorderStyle.Solid
                'dc7.BorderWidth = 1
                dc8.BorderStyle = BorderStyle.Solid
                dc8.BorderWidth = 1
                dc3.HorizontalAlign = HorizontalAlign.Center
                dc4.HorizontalAlign = HorizontalAlign.Center
                dc5.HorizontalAlign = HorizontalAlign.Center
                'dc6.HorizontalAlign = HorizontalAlign.Center
                'dc7.HorizontalAlign = HorizontalAlign.Center
                dc8.HorizontalAlign = HorizontalAlign.Center

                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                Dim cb1 As New CheckBox
                Dim cb2 As New CheckBox
                Dim cb3 As New CheckBox
                Dim cb4 As New CheckBox
                Dim cb5 As New CheckBox
                'Dim cb6 As New CheckBox
                Dim txt_6 As New HtmlTextArea
                cb1.ID = "cb1_" & dao.fields.IDA
                cb2.ID = "cb2_" & dao.fields.IDA
                cb3.ID = "cb3_" & dao.fields.IDA
                cb4.ID = "cb4_" & dao.fields.IDA
                cb5.ID = "cb5_" & dao.fields.IDA
                'cb6.ID = "cb6_" & dao.fields.IDA
                txt_6.ID = "txt6_" & dao.fields.IDA

                If _detial_type = 0 Then
                    Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL

                    Try
                        dao_det.GetDataby_FKLCN_AND_FK_IDA(_LCN_IDA, dao.fields.IDA)
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL1 <> 0 Then
                            cb1.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL2 <> 0 Then
                            cb2.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL3 <> 0 Then
                            cb3.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL4 <> 0 Then
                            cb4.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 <> 0 Then
                            cb5.Checked = True
                        End If
                    Catch ex As Exception

                    End Try

                    Try
                        If dao_det.fields.COL6 IsNot Nothing Then
                            txt_6.Value = dao_det.fields.COL6
                        End If
                    Catch ex As Exception

                    End Try
                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW


                    If rdl_drug_type.SelectedValue = "3" Then
                        dc3.Controls.Add(cb1)
                        'ElseIf rdl_drug_type.SelectedValue = "2" Then
                        '    dc4.Controls.Add(cb2)
                        'ElseIf rdl_drug_type.SelectedValue = "1" Then
                        '    dc5.Controls.Add(cb3)
                    End If

                    'dc6.Controls.Add(cb4)
                    'dc7.Controls.Add(cb5)
                    'dc8.Controls.Add(txt_6)


                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)

                    'dr.Cells.Add(dc6)
                    'dr.Cells.Add(dc7)
                    'dr.Cells.Add(dc8)
                    dr.Cells.Add(dc4)
                    dr.Cells.Add(dc5)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)
                    Table1.Rows.Add(dr)

                ElseIf _detial_type = 1 Then

                    Dim dao_det As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL5_REASON

                    Try
                        dao_det.GET_DATA_BY_FK_LCN_IDA_IDAROW_DDL1_DDL2_ACTIVE(_LCN_IDA, dao.fields.IDA, ddl1, ddl2, True)
                    Catch ex As Exception

                    End Try

                    Try
                        If dao_det.fields.COL1 <> 0 Then
                            cb1.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL2 <> 0 Then
                            cb2.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL3 <> 0 Then
                            cb3.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL4 <> 0 Then
                            cb4.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 <> 0 Then
                            cb5.Checked = True
                        End If
                    Catch ex As Exception

                    End Try

                    Try
                        If dao_det.fields.COL6 IsNot Nothing Then
                            txt_6.Value = dao_det.fields.COL6
                        End If
                    Catch ex As Exception

                    End Try
                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW


                    If rdl_drug_type.SelectedValue = "3" Then
                        dc3.Controls.Add(cb1)
                        'ElseIf rdl_drug_type.SelectedValue = "2" Then
                        '    dc4.Controls.Add(cb2)
                        'ElseIf rdl_drug_type.SelectedValue = "1" Then
                        '    dc5.Controls.Add(cb3)
                    End If

                    'dc6.Controls.Add(cb4)
                    'dc7.Controls.Add(cb5)
                    'dc8.Controls.Add(txt_6)


                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)

                    'dr.Cells.Add(dc6)
                    'dr.Cells.Add(dc7)
                    'dr.Cells.Add(dc8)
                    dr.Cells.Add(dc4)
                    dr.Cells.Add(dc5)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)
                    Table1.Rows.Add(dr)
                End If


            ElseIf dao.fields.TYPE_SHOW = 2 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dr As New TableRow

                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")

                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1
                dc3.ColumnSpan = 3
                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                Dim txt1 As New HtmlTextArea
                If _detial_type = 0 Then
                    Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL

                    Try
                        dao_det.GetDataby_FKLCN_AND_FK_IDA(_LCN_IDA, dao.fields.IDA)
                    Catch ex As Exception

                    End Try

                    Try
                        If dao_det.fields.COL1 IsNot Nothing Then
                            txt1.Value = dao_det.fields.COL1
                        End If
                    Catch ex As Exception

                    End Try
                    txt1.ID = "txt_" & dao.fields.IDA
                    txt1.Style.Add("width", "99%")
                    txt1.Style.Add("Height", "100px")
                    'txt1.Attributes.Add("TextMode", "MultiLine")
                    dc3.Controls.Add(txt1)
                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW

                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)
                    Table1.Rows.Add(dr)
                ElseIf _detial_type = 1 Then
                    Dim dao_det As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL5_REASON

                    Try
                        dao_det.GET_DATA_BY_FK_LCN_IDA_IDAROW_DDL1_DDL2_ACTIVE(_LCN_IDA, dao.fields.IDA, ddl1, ddl2, True)
                    Catch ex As Exception

                    End Try

                    Try
                        If dao_det.fields.COL1 IsNot Nothing Then
                            txt1.Value = dao_det.fields.COL1
                        End If
                    Catch ex As Exception

                    End Try
                    txt1.ID = "txt_" & dao.fields.IDA
                    txt1.Style.Add("width", "99%")
                    txt1.Style.Add("Height", "100px")
                    'txt1.Attributes.Add("TextMode", "MultiLine")
                    dc3.Controls.Add(txt1)
                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW

                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)
                    Table1.Rows.Add(dr)
                End If

            ElseIf dao.fields.TYPE_SHOW = 3 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dc4 As New TableCell
                Dim dc5 As New TableCell
                Dim dc8 As New TableCell
                Dim dr As New TableRow

                Dim ddl As New DropDownList

                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")

                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1
                dc4.BorderStyle = BorderStyle.Solid
                dc4.BorderWidth = 1
                dc5.BorderStyle = BorderStyle.Solid
                dc5.BorderWidth = 1
                dc8.BorderStyle = BorderStyle.Solid
                dc8.BorderWidth = 1
                dc3.HorizontalAlign = HorizontalAlign.Center
                dc4.HorizontalAlign = HorizontalAlign.Center
                dc5.HorizontalAlign = HorizontalAlign.Center
                'dc6.HorizontalAlign = HorizontalAlign.Center
                'dc7.HorizontalAlign = HorizontalAlign.Center
                dc8.HorizontalAlign = HorizontalAlign.Center
                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2

                Dim dao_dgh As New DAO_DRUG.TB_MAS_DRUG_GROUP_HERB_NO3
                dao_dgh.GetDataAll()
                ddl.DataTextField = "GROUP_NAME"
                ddl.DataValueField = "GROUP_ID"
                ddl.DataSource = dao_dgh.datas
                ddl.DataBind()

                ddl.ID = "ddl1_" & dao.fields.IDA
                DropDownInsertDataFirstRow2(ddl, "-----กรุณาเลือก-----", "0")
                'Dim item As New WebControls.ListItem
                'item.Text = "--กรุณาเลือก--"
                'item.Value = "0"
                'ddl.Items.Insert(0, item)

                Dim txt1 As New HtmlTextArea
                If _detial_type = 0 Then
                    Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL

                    Try
                        dao_det.GetDataby_FKLCN_AND_FK_IDA(_LCN_IDA, dao.fields.IDA)
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL1 IsNot Nothing Then
                            txt1.Value = dao_det.fields.COL1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 IsNot Nothing Then
                            ddl.SelectedValue = dao_det.fields.COL5
                        End If

                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 IsNot Nothing Then

                        End If
                    Catch ex As Exception

                    End Try


                    Dim cb1 As New CheckBox
                    Dim cb2 As New CheckBox
                    Dim cb3 As New CheckBox
                    Dim cb4 As New CheckBox
                    Dim cb5 As New CheckBox
                    'Dim cb6 As New CheckBox
                    Dim txt_6 As New HtmlTextArea
                    cb1.ID = "cb1_" & dao.fields.IDA
                    cb2.ID = "cb2_" & dao.fields.IDA
                    cb3.ID = "cb3_" & dao.fields.IDA
                    cb4.ID = "cb4_" & dao.fields.IDA
                    cb5.ID = "cb5_" & dao.fields.IDA


                    Try
                        If dao_det.fields.COL5 <> 0 Then
                            cb1.Checked = True
                        End If
                    Catch ex As Exception

                    End Try


                    If rdl_drug_type.SelectedValue = "3" Then
                        dc3.Controls.Add(cb1)
                        'ElseIf rdl_drug_type.SelectedValue = "2" Then
                        '    dc4.Controls.Add(cb2)
                        'ElseIf rdl_drug_type.SelectedValue = "1" Then
                        '    dc5.Controls.Add(cb3)
                    End If


                    txt1.ID = "txt_" & dao.fields.IDA
                    txt1.Style.Add("width", "99%")
                    txt1.Style.Add("Height", "100px")
                    'txt1.Attributes.Add("TextMode", "MultiLine")
                    '------------------
                    dc2.Controls.Add(ddl)
                    '------------

                    ' dc3.Controls.Add(txt1)
                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW

                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)
                    dr.Cells.Add(dc4)
                    dr.Cells.Add(dc5)
                    ' dr.Cells.Add(dc8)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)

                    Table1.Rows.Add(dr)
                ElseIf _detial_type = 1 Then
                    Dim dao_det As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL5_REASON

                    Try
                        dao_det.GET_DATA_BY_FK_LCN_IDA_IDAROW_DDL1_DDL2_ACTIVE(_LCN_IDA, dao.fields.IDA, ddl1, ddl2, True)
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL1 IsNot Nothing Then
                            txt1.Value = dao_det.fields.COL1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 IsNot Nothing Then
                            ddl.SelectedValue = dao_det.fields.COL5
                        End If

                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 IsNot Nothing Then

                        End If
                    Catch ex As Exception

                    End Try


                    Dim cb1 As New CheckBox
                    Dim cb2 As New CheckBox
                    Dim cb3 As New CheckBox
                    Dim cb4 As New CheckBox
                    Dim cb5 As New CheckBox
                    'Dim cb6 As New CheckBox
                    Dim txt_6 As New HtmlTextArea
                    cb1.ID = "cb1_" & dao.fields.IDA
                    cb2.ID = "cb2_" & dao.fields.IDA
                    cb3.ID = "cb3_" & dao.fields.IDA
                    cb4.ID = "cb4_" & dao.fields.IDA
                    cb5.ID = "cb5_" & dao.fields.IDA


                    Try
                        If dao_det.fields.COL5 <> 0 Then
                            cb1.Checked = True
                        End If
                    Catch ex As Exception

                    End Try


                    If rdl_drug_type.SelectedValue = "3" Then
                        dc3.Controls.Add(cb1)
                        'ElseIf rdl_drug_type.SelectedValue = "2" Then
                        '    dc4.Controls.Add(cb2)
                        'ElseIf rdl_drug_type.SelectedValue = "1" Then
                        '    dc5.Controls.Add(cb3)
                    End If


                    txt1.ID = "txt_" & dao.fields.IDA
                    txt1.Style.Add("width", "99%")
                    txt1.Style.Add("Height", "100px")
                    'txt1.Attributes.Add("TextMode", "MultiLine")
                    '------------------
                    dc2.Controls.Add(ddl)
                    '------------

                    ' dc3.Controls.Add(txt1)
                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW

                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)
                    dr.Cells.Add(dc4)
                    dr.Cells.Add(dc5)
                    ' dr.Cells.Add(dc8)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)

                    Table1.Rows.Add(dr)
                End If

            ElseIf dao.fields.TYPE_SHOW = 4 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dc4 As New TableCell
                Dim dc5 As New TableCell
                Dim dc7 As New TableCell
                'Dim dc8 As New TableCell
                Dim dr As New TableRow

                Dim ddl As New DropDownList

                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")

                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1
                dc4.BorderStyle = BorderStyle.Solid
                dc4.BorderWidth = 1
                dc5.BorderStyle = BorderStyle.Solid
                dc5.BorderWidth = 1
                'dc3.ColumnSpan = 6
                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                dc4.BorderStyle = BorderStyle.Solid
                dc4.BorderWidth = 1
                dc5.BorderStyle = BorderStyle.Solid
                dc5.BorderWidth = 1
                'dc8.BorderStyle = BorderStyle.Solid
                'dc8.BorderWidth = 1
                dc3.HorizontalAlign = HorizontalAlign.Center
                dc4.HorizontalAlign = HorizontalAlign.Center
                dc5.HorizontalAlign = HorizontalAlign.Center
                'dc6.HorizontalAlign = HorizontalAlign.Center
                'dc7.HorizontalAlign = HorizontalAlign.Center
                ' dc8.HorizontalAlign = HorizontalAlign.Center


                Dim dao_dgh As New DAO_DRUG.TB_MAS_DRUG_GROUP_HERB_NO3
                dao_dgh.GetDataAll()
                ddl.DataSource = dao_dgh.datas
                ddl.DataTextField = "GROUP_NAME"
                ddl.DataValueField = "GROUP_ID"
                ddl.DataBind()
                ddl.ID = "ddl1_" & dao.fields.IDA
                DropDownInsertDataFirstRow2(ddl, "-----กรุณาเลือก-----", "0")
                'DropDownInsertDataFirstRow2(ddl, "-----กรุณาเลือก-----", "0")
                'Dim item As New WebControls.ListItem
                'item.Text = "--กรุณาเลือก--"
                'item.Value = "0"
                'ddl.Items.Insert(0, item)
                Dim cb1 As New CheckBox
                Dim cb2 As New CheckBox
                Dim cb3 As New CheckBox
                'Dim cb6 As New CheckBox
                Dim txt_6 As New HtmlTextArea
                cb1.ID = "cb1_" & dao.fields.IDA
                cb2.ID = "cb2_" & dao.fields.IDA
                cb3.ID = "cb3_" & dao.fields.IDA


                Dim txt1 As New HtmlTextArea
                If _detial_type = 0 Then
                    Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL

                    Try
                        dao_det.GetDataby_FKLCN_AND_FK_IDA(_LCN_IDA, dao.fields.IDA)
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 IsNot Nothing Then
                            ddl.SelectedValue = dao_det.fields.COL5
                        End If

                    Catch ex As Exception

                    End Try

                    Try
                        If dao_det.fields.COL5 <> 0 Then
                            cb1.Checked = True
                        End If
                    Catch ex As Exception

                    End Try

                    Try
                        txt1.Value = dao_det.fields.COL1
                    Catch ex As Exception

                    End Try
                    txt1.ID = "txt_" & dao.fields.IDA
                    txt1.Style.Add("width", "99%")
                    'txt1.Style.Add("Height", "100px")
                    'txt1.Attributes.Add("TextMode", "MultiLine")
                    '------------------
                    dc2.Controls.Add(ddl)
                    dc2.Controls.Add(txt1)
                    '------------


                    'dc3.Controls.Add(txt1)

                    If rdl_drug_type.SelectedValue = "3" Then
                        dc3.Controls.Add(cb1)
                        'ElseIf rdl_drug_type.SelectedValue = "2" Then
                        '    dc4.Controls.Add(cb2)
                        'ElseIf rdl_drug_type.SelectedValue = "1" Then
                        '    dc5.Controls.Add(cb3)
                    End If
                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW

                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)

                    dr.Cells.Add(dc4)
                    dr.Cells.Add(dc5)
                    'dr.Cells.Add(dc7)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)
                    Table1.Rows.Add(dr)
                ElseIf _detial_type = 1 Then
                    Dim dao_det As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL5_REASON

                    Try
                        dao_det.GET_DATA_BY_FK_LCN_IDA_IDAROW_DDL1_DDL2_ACTIVE(_LCN_IDA, dao.fields.IDA, ddl1, ddl2, True)
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 IsNot Nothing Then
                            ddl.SelectedValue = dao_det.fields.COL5
                        End If

                    Catch ex As Exception

                    End Try

                    Try
                        If dao_det.fields.COL5 <> 0 Then
                            cb1.Checked = True
                        End If
                    Catch ex As Exception

                    End Try

                    Try
                        txt1.Value = dao_det.fields.COL1
                    Catch ex As Exception

                    End Try
                    txt1.ID = "txt_" & dao.fields.IDA
                    txt1.Style.Add("width", "99%")
                    'txt1.Style.Add("Height", "100px")
                    'txt1.Attributes.Add("TextMode", "MultiLine")
                    '------------------
                    dc2.Controls.Add(ddl)
                    dc2.Controls.Add(txt1)
                    '------------


                    'dc3.Controls.Add(txt1)

                    If rdl_drug_type.SelectedValue = "3" Then
                        dc3.Controls.Add(cb1)
                        'ElseIf rdl_drug_type.SelectedValue = "2" Then
                        '    dc4.Controls.Add(cb2)
                        'ElseIf rdl_drug_type.SelectedValue = "1" Then
                        '    dc5.Controls.Add(cb3)
                    End If
                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW

                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)

                    dr.Cells.Add(dc4)
                    dr.Cells.Add(dc5)
                    'dr.Cells.Add(dc7)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)
                    Table1.Rows.Add(dr)
                End If


            ElseIf dao.fields.TYPE_SHOW = 0 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dc4 As New TableCell
                Dim dc5 As New TableCell
                Dim dc7 As New TableCell
                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")
                Dim dr As New TableRow
                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1

                dc3.HorizontalAlign = HorizontalAlign.Center
                dc4.BorderStyle = BorderStyle.Solid
                dc4.BorderWidth = 1
                dc5.BorderStyle = BorderStyle.Solid
                dc5.BorderWidth = 1

                dc3.HorizontalAlign = HorizontalAlign.Center
                dc4.HorizontalAlign = HorizontalAlign.Center
                dc5.HorizontalAlign = HorizontalAlign.Center


                Dim cb1 As New CheckBox
                Dim cb2 As New CheckBox
                Dim cb3 As New CheckBox
                Dim cb4 As New CheckBox
                Dim cb5 As New CheckBox
                'Dim cb6 As New CheckBox
                Dim txt_6 As New HtmlTextArea
                cb1.ID = "cb1_" & dao.fields.IDA
                cb2.ID = "cb2_" & dao.fields.IDA
                cb3.ID = "cb3_" & dao.fields.IDA
                cb4.ID = "cb4_" & dao.fields.IDA
                cb5.ID = "cb5_" & dao.fields.IDA


                'dc3.ColumnSpan = 3
                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                dc9.Text = dao.fields.IDA
                dc10.Text = dao.fields.TYPE_SHOW

                If _detial_type = 0 Then
                    Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL

                    Try
                        dao_det.GetDataby_FKLCN_AND_FK_IDA(_LCN_IDA, dao.fields.IDA)
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL1 <> 0 Then
                            cb1.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL2 <> 0 Then
                            cb2.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL3 <> 0 Then
                            cb3.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL4 <> 0 Then
                            cb4.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 <> 0 Then
                            cb5.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    If rdl_drug_type.SelectedValue = "2" Then
                        dc4.Controls.Add(cb2)
                    ElseIf rdl_drug_type.SelectedValue = "1" Then
                        dc5.Controls.Add(cb3)
                    End If

                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW

                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)
                    dr.Cells.Add(dc4)
                    dr.Cells.Add(dc5)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)
                    Table1.Rows.Add(dr)
                ElseIf _detial_type = 1 Then
                    Dim dao_det As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL5_REASON

                    Try
                        dao_det.GET_DATA_BY_FK_LCN_IDA_IDAROW_DDL1_DDL2_ACTIVE(_LCN_IDA, dao.fields.IDA, ddl1, ddl2, True)
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL1 <> 0 Then
                            cb1.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL2 <> 0 Then
                            cb2.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL3 <> 0 Then
                            cb3.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL4 <> 0 Then
                            cb4.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 <> 0 Then
                            cb5.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    If rdl_drug_type.SelectedValue = "2" Then
                        dc4.Controls.Add(cb2)
                    ElseIf rdl_drug_type.SelectedValue = "1" Then
                        dc5.Controls.Add(cb3)
                    End If

                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW

                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)
                    dr.Cells.Add(dc4)
                    dr.Cells.Add(dc5)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)
                    Table1.Rows.Add(dr)
                End If


            End If
        Next
    End Sub
    Sub bind_table_ddl10(ByVal _LCN_IDA As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal _detial_type As Integer)
        'Table1.BorderStyle = BorderStyle.Solid
        'Table1.BorderWidth = 1
        bind_head()
        Dim dao As New DAO_DRUG.TB_MAS_DRUG_GROUP_HERB
        dao.GetDataAll()

        For Each dao.fields In dao.datas
            If dao.fields.TYPE_SHOW = 1 Then

                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dc4 As New TableCell
                Dim dc5 As New TableCell
                'Dim dc6 As New TableCell
                'Dim dc7 As New TableCell
                Dim dc8 As New TableCell
                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")
                Dim dr As New TableRow
                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1
                dc4.BorderStyle = BorderStyle.Solid
                dc4.BorderWidth = 1
                dc5.BorderStyle = BorderStyle.Solid
                dc5.BorderWidth = 1
                'dc6.BorderStyle = BorderStyle.Solid
                'dc6.BorderWidth = 1
                'dc7.BorderStyle = BorderStyle.Solid
                'dc7.BorderWidth = 1
                dc8.BorderStyle = BorderStyle.Solid
                dc8.BorderWidth = 1
                dc3.HorizontalAlign = HorizontalAlign.Center
                dc4.HorizontalAlign = HorizontalAlign.Center
                dc5.HorizontalAlign = HorizontalAlign.Center
                'dc6.HorizontalAlign = HorizontalAlign.Center
                'dc7.HorizontalAlign = HorizontalAlign.Center
                dc8.HorizontalAlign = HorizontalAlign.Center

                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                Dim cb1 As New CheckBox
                Dim cb2 As New CheckBox
                Dim cb3 As New CheckBox
                Dim cb4 As New CheckBox
                Dim cb5 As New CheckBox
                'Dim cb6 As New CheckBox
                Dim txt_6 As New HtmlTextArea
                cb1.ID = "cb1_" & dao.fields.IDA
                cb2.ID = "cb2_" & dao.fields.IDA
                cb3.ID = "cb3_" & dao.fields.IDA
                cb4.ID = "cb4_" & dao.fields.IDA
                cb5.ID = "cb5_" & dao.fields.IDA
                'cb6.ID = "cb6_" & dao.fields.IDA
                txt_6.ID = "txt6_" & dao.fields.IDA

                If _detial_type = 0 Then
                    Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL

                    Try
                        dao_det.GetDataby_FKLCN_AND_FK_IDA(_LCN_IDA, dao.fields.IDA)
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL1 <> 0 Then
                            cb1.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL2 <> 0 Then
                            cb2.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL3 <> 0 Then
                            cb3.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL4 <> 0 Then
                            cb4.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 <> 0 Then
                            cb5.Checked = True
                        End If
                    Catch ex As Exception

                    End Try

                    Try
                        If dao_det.fields.COL6 IsNot Nothing Then
                            txt_6.Value = dao_det.fields.COL6
                        End If
                    Catch ex As Exception

                    End Try
                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW


                    If rdl_drug_type.SelectedValue = "3" Then
                        dc3.Controls.Add(cb1)
                        'ElseIf rdl_drug_type.SelectedValue = "2" Then
                        '    dc4.Controls.Add(cb2)
                        'ElseIf rdl_drug_type.SelectedValue = "1" Then
                        '    dc5.Controls.Add(cb3)
                    End If

                    'dc6.Controls.Add(cb4)
                    'dc7.Controls.Add(cb5)
                    'dc8.Controls.Add(txt_6)


                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)

                    'dr.Cells.Add(dc6)
                    'dr.Cells.Add(dc7)
                    'dr.Cells.Add(dc8)
                    dr.Cells.Add(dc4)
                    dr.Cells.Add(dc5)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)
                    Table1.Rows.Add(dr)

                ElseIf _detial_type = 1 Then

                    Dim dao_det As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL10_REASON

                    Try
                        dao_det.GET_DATA_BY_FK_LCN_IDA_IDAROW_DDL1_DDL2_ACTIVE(_LCN_IDA, dao.fields.IDA, ddl1, ddl2, True)
                    Catch ex As Exception

                    End Try

                    Try
                        If dao_det.fields.COL1 <> 0 Then
                            cb1.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL2 <> 0 Then
                            cb2.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL3 <> 0 Then
                            cb3.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL4 <> 0 Then
                            cb4.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 <> 0 Then
                            cb5.Checked = True
                        End If
                    Catch ex As Exception

                    End Try

                    Try
                        If dao_det.fields.COL6 IsNot Nothing Then
                            txt_6.Value = dao_det.fields.COL6
                        End If
                    Catch ex As Exception

                    End Try
                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW


                    If rdl_drug_type.SelectedValue = "3" Then
                        dc3.Controls.Add(cb1)
                        'ElseIf rdl_drug_type.SelectedValue = "2" Then
                        '    dc4.Controls.Add(cb2)
                        'ElseIf rdl_drug_type.SelectedValue = "1" Then
                        '    dc5.Controls.Add(cb3)
                    End If

                    'dc6.Controls.Add(cb4)
                    'dc7.Controls.Add(cb5)
                    'dc8.Controls.Add(txt_6)


                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)

                    'dr.Cells.Add(dc6)
                    'dr.Cells.Add(dc7)
                    'dr.Cells.Add(dc8)
                    dr.Cells.Add(dc4)
                    dr.Cells.Add(dc5)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)
                    Table1.Rows.Add(dr)
                End If


            ElseIf dao.fields.TYPE_SHOW = 2 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dr As New TableRow

                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")

                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1
                dc3.ColumnSpan = 3
                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                Dim txt1 As New HtmlTextArea
                If _detial_type = 0 Then
                    Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL

                    Try
                        dao_det.GetDataby_FKLCN_AND_FK_IDA(_LCN_IDA, dao.fields.IDA)
                    Catch ex As Exception

                    End Try

                    Try
                        If dao_det.fields.COL1 IsNot Nothing Then
                            txt1.Value = dao_det.fields.COL1
                        End If
                    Catch ex As Exception

                    End Try
                    txt1.ID = "txt_" & dao.fields.IDA
                    txt1.Style.Add("width", "99%")
                    txt1.Style.Add("Height", "100px")
                    'txt1.Attributes.Add("TextMode", "MultiLine")
                    dc3.Controls.Add(txt1)
                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW

                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)
                    Table1.Rows.Add(dr)
                ElseIf _detial_type = 1 Then
                    Dim dao_det As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL10_REASON

                    Try
                        dao_det.GET_DATA_BY_FK_LCN_IDA_IDAROW_DDL1_DDL2_ACTIVE(_LCN_IDA, dao.fields.IDA, ddl1, ddl2, True)
                    Catch ex As Exception

                    End Try

                    Try
                        If dao_det.fields.COL1 IsNot Nothing Then
                            txt1.Value = dao_det.fields.COL1
                        End If
                    Catch ex As Exception

                    End Try
                    txt1.ID = "txt_" & dao.fields.IDA
                    txt1.Style.Add("width", "99%")
                    txt1.Style.Add("Height", "100px")
                    'txt1.Attributes.Add("TextMode", "MultiLine")
                    dc3.Controls.Add(txt1)
                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW

                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)
                    Table1.Rows.Add(dr)
                End If

            ElseIf dao.fields.TYPE_SHOW = 3 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dc4 As New TableCell
                Dim dc5 As New TableCell
                Dim dc8 As New TableCell
                Dim dr As New TableRow

                Dim ddl As New DropDownList

                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")

                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1
                dc4.BorderStyle = BorderStyle.Solid
                dc4.BorderWidth = 1
                dc5.BorderStyle = BorderStyle.Solid
                dc5.BorderWidth = 1
                dc8.BorderStyle = BorderStyle.Solid
                dc8.BorderWidth = 1
                dc3.HorizontalAlign = HorizontalAlign.Center
                dc4.HorizontalAlign = HorizontalAlign.Center
                dc5.HorizontalAlign = HorizontalAlign.Center
                'dc6.HorizontalAlign = HorizontalAlign.Center
                'dc7.HorizontalAlign = HorizontalAlign.Center
                dc8.HorizontalAlign = HorizontalAlign.Center
                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2

                Dim dao_dgh As New DAO_DRUG.TB_MAS_DRUG_GROUP_HERB_NO3
                dao_dgh.GetDataAll()
                ddl.DataTextField = "GROUP_NAME"
                ddl.DataValueField = "GROUP_ID"
                ddl.DataSource = dao_dgh.datas
                ddl.DataBind()

                ddl.ID = "ddl1_" & dao.fields.IDA
                DropDownInsertDataFirstRow2(ddl, "-----กรุณาเลือก-----", "0")
                'Dim item As New WebControls.ListItem
                'item.Text = "--กรุณาเลือก--"
                'item.Value = "0"
                'ddl.Items.Insert(0, item)

                Dim txt1 As New HtmlTextArea
                If _detial_type = 0 Then
                    Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL

                    Try
                        dao_det.GetDataby_FKLCN_AND_FK_IDA(_LCN_IDA, dao.fields.IDA)
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL1 IsNot Nothing Then
                            txt1.Value = dao_det.fields.COL1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 IsNot Nothing Then
                            ddl.SelectedValue = dao_det.fields.COL5
                        End If

                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 IsNot Nothing Then

                        End If
                    Catch ex As Exception

                    End Try


                    Dim cb1 As New CheckBox
                    Dim cb2 As New CheckBox
                    Dim cb3 As New CheckBox
                    Dim cb4 As New CheckBox
                    Dim cb5 As New CheckBox
                    'Dim cb6 As New CheckBox
                    Dim txt_6 As New HtmlTextArea
                    cb1.ID = "cb1_" & dao.fields.IDA
                    cb2.ID = "cb2_" & dao.fields.IDA
                    cb3.ID = "cb3_" & dao.fields.IDA
                    cb4.ID = "cb4_" & dao.fields.IDA
                    cb5.ID = "cb5_" & dao.fields.IDA


                    Try
                        If dao_det.fields.COL5 <> 0 Then
                            cb1.Checked = True
                        End If
                    Catch ex As Exception

                    End Try


                    If rdl_drug_type.SelectedValue = "3" Then
                        dc3.Controls.Add(cb1)
                        'ElseIf rdl_drug_type.SelectedValue = "2" Then
                        '    dc4.Controls.Add(cb2)
                        'ElseIf rdl_drug_type.SelectedValue = "1" Then
                        '    dc5.Controls.Add(cb3)
                    End If


                    txt1.ID = "txt_" & dao.fields.IDA
                    txt1.Style.Add("width", "99%")
                    txt1.Style.Add("Height", "100px")
                    'txt1.Attributes.Add("TextMode", "MultiLine")
                    '------------------
                    dc2.Controls.Add(ddl)
                    '------------

                    ' dc3.Controls.Add(txt1)
                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW

                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)
                    dr.Cells.Add(dc4)
                    dr.Cells.Add(dc5)
                    ' dr.Cells.Add(dc8)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)

                    Table1.Rows.Add(dr)
                ElseIf _detial_type = 1 Then
                    Dim dao_det As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL10_REASON

                    Try
                        dao_det.GET_DATA_BY_FK_LCN_IDA_IDAROW_DDL1_DDL2_ACTIVE(_LCN_IDA, dao.fields.IDA, ddl1, ddl2, True)
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL1 IsNot Nothing Then
                            txt1.Value = dao_det.fields.COL1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 IsNot Nothing Then
                            ddl.SelectedValue = dao_det.fields.COL5
                        End If

                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 IsNot Nothing Then

                        End If
                    Catch ex As Exception

                    End Try


                    Dim cb1 As New CheckBox
                    Dim cb2 As New CheckBox
                    Dim cb3 As New CheckBox
                    Dim cb4 As New CheckBox
                    Dim cb5 As New CheckBox
                    'Dim cb6 As New CheckBox
                    Dim txt_6 As New HtmlTextArea
                    cb1.ID = "cb1_" & dao.fields.IDA
                    cb2.ID = "cb2_" & dao.fields.IDA
                    cb3.ID = "cb3_" & dao.fields.IDA
                    cb4.ID = "cb4_" & dao.fields.IDA
                    cb5.ID = "cb5_" & dao.fields.IDA


                    Try
                        If dao_det.fields.COL5 <> 0 Then
                            cb1.Checked = True
                        End If
                    Catch ex As Exception

                    End Try


                    If rdl_drug_type.SelectedValue = "3" Then
                        dc3.Controls.Add(cb1)
                        'ElseIf rdl_drug_type.SelectedValue = "2" Then
                        '    dc4.Controls.Add(cb2)
                        'ElseIf rdl_drug_type.SelectedValue = "1" Then
                        '    dc5.Controls.Add(cb3)
                    End If


                    txt1.ID = "txt_" & dao.fields.IDA
                    txt1.Style.Add("width", "99%")
                    txt1.Style.Add("Height", "100px")
                    'txt1.Attributes.Add("TextMode", "MultiLine")
                    '------------------
                    dc2.Controls.Add(ddl)
                    '------------

                    ' dc3.Controls.Add(txt1)
                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW

                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)
                    dr.Cells.Add(dc4)
                    dr.Cells.Add(dc5)
                    ' dr.Cells.Add(dc8)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)

                    Table1.Rows.Add(dr)
                End If

            ElseIf dao.fields.TYPE_SHOW = 4 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dc4 As New TableCell
                Dim dc5 As New TableCell
                Dim dc7 As New TableCell
                'Dim dc8 As New TableCell
                Dim dr As New TableRow

                Dim ddl As New DropDownList

                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")

                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1
                dc4.BorderStyle = BorderStyle.Solid
                dc4.BorderWidth = 1
                dc5.BorderStyle = BorderStyle.Solid
                dc5.BorderWidth = 1
                'dc3.ColumnSpan = 6
                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                dc4.BorderStyle = BorderStyle.Solid
                dc4.BorderWidth = 1
                dc5.BorderStyle = BorderStyle.Solid
                dc5.BorderWidth = 1
                'dc8.BorderStyle = BorderStyle.Solid
                'dc8.BorderWidth = 1
                dc3.HorizontalAlign = HorizontalAlign.Center
                dc4.HorizontalAlign = HorizontalAlign.Center
                dc5.HorizontalAlign = HorizontalAlign.Center
                'dc6.HorizontalAlign = HorizontalAlign.Center
                'dc7.HorizontalAlign = HorizontalAlign.Center
                ' dc8.HorizontalAlign = HorizontalAlign.Center


                Dim dao_dgh As New DAO_DRUG.TB_MAS_DRUG_GROUP_HERB_NO3
                dao_dgh.GetDataAll()
                ddl.DataSource = dao_dgh.datas
                ddl.DataTextField = "GROUP_NAME"
                ddl.DataValueField = "GROUP_ID"
                ddl.DataBind()
                ddl.ID = "ddl1_" & dao.fields.IDA
                DropDownInsertDataFirstRow2(ddl, "-----กรุณาเลือก-----", "0")
                'DropDownInsertDataFirstRow2(ddl, "-----กรุณาเลือก-----", "0")
                'Dim item As New WebControls.ListItem
                'item.Text = "--กรุณาเลือก--"
                'item.Value = "0"
                'ddl.Items.Insert(0, item)
                Dim cb1 As New CheckBox
                Dim cb2 As New CheckBox
                Dim cb3 As New CheckBox
                'Dim cb6 As New CheckBox
                Dim txt_6 As New HtmlTextArea
                cb1.ID = "cb1_" & dao.fields.IDA
                cb2.ID = "cb2_" & dao.fields.IDA
                cb3.ID = "cb3_" & dao.fields.IDA


                Dim txt1 As New HtmlTextArea
                If _detial_type = 0 Then
                    Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL

                    Try
                        dao_det.GetDataby_FKLCN_AND_FK_IDA(_LCN_IDA, dao.fields.IDA)
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 IsNot Nothing Then
                            ddl.SelectedValue = dao_det.fields.COL5
                        End If

                    Catch ex As Exception

                    End Try

                    Try
                        If dao_det.fields.COL5 <> 0 Then
                            cb1.Checked = True
                        End If
                    Catch ex As Exception

                    End Try

                    Try
                        txt1.Value = dao_det.fields.COL1
                    Catch ex As Exception

                    End Try
                    txt1.ID = "txt_" & dao.fields.IDA
                    txt1.Style.Add("width", "99%")
                    'txt1.Style.Add("Height", "100px")
                    'txt1.Attributes.Add("TextMode", "MultiLine")
                    '------------------
                    dc2.Controls.Add(ddl)
                    dc2.Controls.Add(txt1)
                    '------------


                    'dc3.Controls.Add(txt1)

                    If rdl_drug_type.SelectedValue = "3" Then
                        dc3.Controls.Add(cb1)
                        'ElseIf rdl_drug_type.SelectedValue = "2" Then
                        '    dc4.Controls.Add(cb2)
                        'ElseIf rdl_drug_type.SelectedValue = "1" Then
                        '    dc5.Controls.Add(cb3)
                    End If
                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW

                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)

                    dr.Cells.Add(dc4)
                    dr.Cells.Add(dc5)
                    'dr.Cells.Add(dc7)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)
                    Table1.Rows.Add(dr)
                ElseIf _detial_type = 1 Then
                    Dim dao_det As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL10_REASON

                    Try
                        dao_det.GET_DATA_BY_FK_LCN_IDA_IDAROW_DDL1_DDL2_ACTIVE(_LCN_IDA, dao.fields.IDA, ddl1, ddl2, True)
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 IsNot Nothing Then
                            ddl.SelectedValue = dao_det.fields.COL5
                        End If

                    Catch ex As Exception

                    End Try

                    Try
                        If dao_det.fields.COL5 <> 0 Then
                            cb1.Checked = True
                        End If
                    Catch ex As Exception

                    End Try

                    Try
                        txt1.Value = dao_det.fields.COL1
                    Catch ex As Exception

                    End Try
                    txt1.ID = "txt_" & dao.fields.IDA
                    txt1.Style.Add("width", "99%")
                    'txt1.Style.Add("Height", "100px")
                    'txt1.Attributes.Add("TextMode", "MultiLine")
                    '------------------
                    dc2.Controls.Add(ddl)
                    dc2.Controls.Add(txt1)
                    '------------


                    'dc3.Controls.Add(txt1)

                    If rdl_drug_type.SelectedValue = "3" Then
                        dc3.Controls.Add(cb1)
                        'ElseIf rdl_drug_type.SelectedValue = "2" Then
                        '    dc4.Controls.Add(cb2)
                        'ElseIf rdl_drug_type.SelectedValue = "1" Then
                        '    dc5.Controls.Add(cb3)
                    End If
                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW

                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)

                    dr.Cells.Add(dc4)
                    dr.Cells.Add(dc5)
                    'dr.Cells.Add(dc7)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)
                    Table1.Rows.Add(dr)
                End If


            ElseIf dao.fields.TYPE_SHOW = 0 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dc4 As New TableCell
                Dim dc5 As New TableCell
                Dim dc7 As New TableCell
                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")
                Dim dr As New TableRow
                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1

                dc3.HorizontalAlign = HorizontalAlign.Center
                dc4.BorderStyle = BorderStyle.Solid
                dc4.BorderWidth = 1
                dc5.BorderStyle = BorderStyle.Solid
                dc5.BorderWidth = 1

                dc3.HorizontalAlign = HorizontalAlign.Center
                dc4.HorizontalAlign = HorizontalAlign.Center
                dc5.HorizontalAlign = HorizontalAlign.Center


                Dim cb1 As New CheckBox
                Dim cb2 As New CheckBox
                Dim cb3 As New CheckBox
                Dim cb4 As New CheckBox
                Dim cb5 As New CheckBox
                'Dim cb6 As New CheckBox
                Dim txt_6 As New HtmlTextArea
                cb1.ID = "cb1_" & dao.fields.IDA
                cb2.ID = "cb2_" & dao.fields.IDA
                cb3.ID = "cb3_" & dao.fields.IDA
                cb4.ID = "cb4_" & dao.fields.IDA
                cb5.ID = "cb5_" & dao.fields.IDA


                'dc3.ColumnSpan = 3
                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                dc9.Text = dao.fields.IDA
                dc10.Text = dao.fields.TYPE_SHOW

                If _detial_type = 0 Then
                    Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL

                    Try
                        dao_det.GetDataby_FKLCN_AND_FK_IDA(_LCN_IDA, dao.fields.IDA)
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL1 <> 0 Then
                            cb1.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL2 <> 0 Then
                            cb2.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL3 <> 0 Then
                            cb3.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL4 <> 0 Then
                            cb4.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 <> 0 Then
                            cb5.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    If rdl_drug_type.SelectedValue = "2" Then
                        dc4.Controls.Add(cb2)
                    ElseIf rdl_drug_type.SelectedValue = "1" Then
                        dc5.Controls.Add(cb3)
                    End If

                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW

                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)
                    dr.Cells.Add(dc4)
                    dr.Cells.Add(dc5)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)
                    Table1.Rows.Add(dr)
                ElseIf _detial_type = 1 Then
                    Dim dao_det As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL10_REASON

                    Try
                        dao_det.GET_DATA_BY_FK_LCN_IDA_IDAROW_DDL1_DDL2_ACTIVE(_LCN_IDA, dao.fields.IDA, ddl1, ddl2, True)
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL1 <> 0 Then
                            cb1.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL2 <> 0 Then
                            cb2.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL3 <> 0 Then
                            cb3.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL4 <> 0 Then
                            cb4.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 <> 0 Then
                            cb5.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    If rdl_drug_type.SelectedValue = "2" Then
                        dc4.Controls.Add(cb2)
                    ElseIf rdl_drug_type.SelectedValue = "1" Then
                        dc5.Controls.Add(cb3)
                    End If

                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW

                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)
                    dr.Cells.Add(dc4)
                    dr.Cells.Add(dc5)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)
                    Table1.Rows.Add(dr)
                End If


            End If
        Next
    End Sub
    Sub bind_table_ddl11(ByVal _LCN_IDA As Integer, ByVal ddl1 As Integer, ByVal ddl2 As Integer, ByVal _detial_type As Integer)
        'Table1.BorderStyle = BorderStyle.Solid
        'Table1.BorderWidth = 1
        bind_head()
        Dim dao As New DAO_DRUG.TB_MAS_DRUG_GROUP_HERB
        dao.GetDataAll()

        For Each dao.fields In dao.datas
            If dao.fields.TYPE_SHOW = 1 Then

                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dc4 As New TableCell
                Dim dc5 As New TableCell
                'Dim dc6 As New TableCell
                'Dim dc7 As New TableCell
                Dim dc8 As New TableCell
                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")
                Dim dr As New TableRow
                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1
                dc4.BorderStyle = BorderStyle.Solid
                dc4.BorderWidth = 1
                dc5.BorderStyle = BorderStyle.Solid
                dc5.BorderWidth = 1
                'dc6.BorderStyle = BorderStyle.Solid
                'dc6.BorderWidth = 1
                'dc7.BorderStyle = BorderStyle.Solid
                'dc7.BorderWidth = 1
                dc8.BorderStyle = BorderStyle.Solid
                dc8.BorderWidth = 1
                dc3.HorizontalAlign = HorizontalAlign.Center
                dc4.HorizontalAlign = HorizontalAlign.Center
                dc5.HorizontalAlign = HorizontalAlign.Center
                'dc6.HorizontalAlign = HorizontalAlign.Center
                'dc7.HorizontalAlign = HorizontalAlign.Center
                dc8.HorizontalAlign = HorizontalAlign.Center

                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                Dim cb1 As New CheckBox
                Dim cb2 As New CheckBox
                Dim cb3 As New CheckBox
                Dim cb4 As New CheckBox
                Dim cb5 As New CheckBox
                'Dim cb6 As New CheckBox
                Dim txt_6 As New HtmlTextArea
                cb1.ID = "cb1_" & dao.fields.IDA
                cb2.ID = "cb2_" & dao.fields.IDA
                cb3.ID = "cb3_" & dao.fields.IDA
                cb4.ID = "cb4_" & dao.fields.IDA
                cb5.ID = "cb5_" & dao.fields.IDA
                'cb6.ID = "cb6_" & dao.fields.IDA
                txt_6.ID = "txt6_" & dao.fields.IDA

                If _detial_type = 0 Then
                    Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL

                    Try
                        dao_det.GetDataby_FKLCN_AND_FK_IDA(_LCN_IDA, dao.fields.IDA)
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL1 <> 0 Then
                            cb1.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL2 <> 0 Then
                            cb2.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL3 <> 0 Then
                            cb3.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL4 <> 0 Then
                            cb4.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 <> 0 Then
                            cb5.Checked = True
                        End If
                    Catch ex As Exception

                    End Try

                    Try
                        If dao_det.fields.COL6 IsNot Nothing Then
                            txt_6.Value = dao_det.fields.COL6
                        End If
                    Catch ex As Exception

                    End Try
                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW


                    If rdl_drug_type.SelectedValue = "3" Then
                        dc3.Controls.Add(cb1)
                        'ElseIf rdl_drug_type.SelectedValue = "2" Then
                        '    dc4.Controls.Add(cb2)
                        'ElseIf rdl_drug_type.SelectedValue = "1" Then
                        '    dc5.Controls.Add(cb3)
                    End If

                    'dc6.Controls.Add(cb4)
                    'dc7.Controls.Add(cb5)
                    'dc8.Controls.Add(txt_6)


                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)

                    'dr.Cells.Add(dc6)
                    'dr.Cells.Add(dc7)
                    'dr.Cells.Add(dc8)
                    dr.Cells.Add(dc4)
                    dr.Cells.Add(dc5)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)
                    Table1.Rows.Add(dr)

                ElseIf _detial_type = 1 Then

                    Dim dao_det As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL11_REASON

                    Try
                        dao_det.GET_DATA_BY_FK_LCN_IDA_IDAROW_DDL1_DDL2_ACTIVE(_LCN_IDA, dao.fields.IDA, ddl1, ddl2, True)
                    Catch ex As Exception

                    End Try

                    Try
                        If dao_det.fields.COL1 <> 0 Then
                            cb1.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL2 <> 0 Then
                            cb2.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL3 <> 0 Then
                            cb3.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL4 <> 0 Then
                            cb4.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 <> 0 Then
                            cb5.Checked = True
                        End If
                    Catch ex As Exception

                    End Try

                    Try
                        If dao_det.fields.COL6 IsNot Nothing Then
                            txt_6.Value = dao_det.fields.COL6
                        End If
                    Catch ex As Exception

                    End Try
                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW


                    If rdl_drug_type.SelectedValue = "3" Then
                        dc3.Controls.Add(cb1)
                        'ElseIf rdl_drug_type.SelectedValue = "2" Then
                        '    dc4.Controls.Add(cb2)
                        'ElseIf rdl_drug_type.SelectedValue = "1" Then
                        '    dc5.Controls.Add(cb3)
                    End If

                    'dc6.Controls.Add(cb4)
                    'dc7.Controls.Add(cb5)
                    'dc8.Controls.Add(txt_6)


                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)

                    'dr.Cells.Add(dc6)
                    'dr.Cells.Add(dc7)
                    'dr.Cells.Add(dc8)
                    dr.Cells.Add(dc4)
                    dr.Cells.Add(dc5)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)
                    Table1.Rows.Add(dr)
                End If


            ElseIf dao.fields.TYPE_SHOW = 2 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dr As New TableRow

                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")

                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1
                dc3.ColumnSpan = 3
                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                Dim txt1 As New HtmlTextArea
                If _detial_type = 0 Then
                    Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL

                    Try
                        dao_det.GetDataby_FKLCN_AND_FK_IDA(_LCN_IDA, dao.fields.IDA)
                    Catch ex As Exception

                    End Try

                    Try
                        If dao_det.fields.COL1 IsNot Nothing Then
                            txt1.Value = dao_det.fields.COL1
                        End If
                    Catch ex As Exception

                    End Try
                    txt1.ID = "txt_" & dao.fields.IDA
                    txt1.Style.Add("width", "99%")
                    txt1.Style.Add("Height", "100px")
                    'txt1.Attributes.Add("TextMode", "MultiLine")
                    dc3.Controls.Add(txt1)
                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW

                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)
                    Table1.Rows.Add(dr)
                ElseIf _detial_type = 1 Then
                    Dim dao_det As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL11_REASON

                    Try
                        dao_det.GET_DATA_BY_FK_LCN_IDA_IDAROW_DDL1_DDL2_ACTIVE(_LCN_IDA, dao.fields.IDA, ddl1, ddl2, True)
                    Catch ex As Exception

                    End Try

                    Try
                        If dao_det.fields.COL1 IsNot Nothing Then
                            txt1.Value = dao_det.fields.COL1
                        End If
                    Catch ex As Exception

                    End Try
                    txt1.ID = "txt_" & dao.fields.IDA
                    txt1.Style.Add("width", "99%")
                    txt1.Style.Add("Height", "100px")
                    'txt1.Attributes.Add("TextMode", "MultiLine")
                    dc3.Controls.Add(txt1)
                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW

                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)
                    Table1.Rows.Add(dr)
                End If

            ElseIf dao.fields.TYPE_SHOW = 3 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dc4 As New TableCell
                Dim dc5 As New TableCell
                Dim dc8 As New TableCell
                Dim dr As New TableRow

                Dim ddl As New DropDownList

                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")

                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1
                dc4.BorderStyle = BorderStyle.Solid
                dc4.BorderWidth = 1
                dc5.BorderStyle = BorderStyle.Solid
                dc5.BorderWidth = 1
                dc8.BorderStyle = BorderStyle.Solid
                dc8.BorderWidth = 1
                dc3.HorizontalAlign = HorizontalAlign.Center
                dc4.HorizontalAlign = HorizontalAlign.Center
                dc5.HorizontalAlign = HorizontalAlign.Center
                'dc6.HorizontalAlign = HorizontalAlign.Center
                'dc7.HorizontalAlign = HorizontalAlign.Center
                dc8.HorizontalAlign = HorizontalAlign.Center
                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2

                Dim dao_dgh As New DAO_DRUG.TB_MAS_DRUG_GROUP_HERB_NO3
                dao_dgh.GetDataAll()
                ddl.DataTextField = "GROUP_NAME"
                ddl.DataValueField = "GROUP_ID"
                ddl.DataSource = dao_dgh.datas
                ddl.DataBind()

                ddl.ID = "ddl1_" & dao.fields.IDA
                DropDownInsertDataFirstRow2(ddl, "-----กรุณาเลือก-----", "0")
                'Dim item As New WebControls.ListItem
                'item.Text = "--กรุณาเลือก--"
                'item.Value = "0"
                'ddl.Items.Insert(0, item)

                Dim txt1 As New HtmlTextArea
                If _detial_type = 0 Then
                    Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL

                    Try
                        dao_det.GetDataby_FKLCN_AND_FK_IDA(_LCN_IDA, dao.fields.IDA)
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL1 IsNot Nothing Then
                            txt1.Value = dao_det.fields.COL1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 IsNot Nothing Then
                            ddl.SelectedValue = dao_det.fields.COL5
                        End If

                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 IsNot Nothing Then

                        End If
                    Catch ex As Exception

                    End Try


                    Dim cb1 As New CheckBox
                    Dim cb2 As New CheckBox
                    Dim cb3 As New CheckBox
                    Dim cb4 As New CheckBox
                    Dim cb5 As New CheckBox
                    'Dim cb6 As New CheckBox
                    Dim txt_6 As New HtmlTextArea
                    cb1.ID = "cb1_" & dao.fields.IDA
                    cb2.ID = "cb2_" & dao.fields.IDA
                    cb3.ID = "cb3_" & dao.fields.IDA
                    cb4.ID = "cb4_" & dao.fields.IDA
                    cb5.ID = "cb5_" & dao.fields.IDA


                    Try
                        If dao_det.fields.COL5 <> 0 Then
                            cb1.Checked = True
                        End If
                    Catch ex As Exception

                    End Try


                    If rdl_drug_type.SelectedValue = "3" Then
                        dc3.Controls.Add(cb1)
                        'ElseIf rdl_drug_type.SelectedValue = "2" Then
                        '    dc4.Controls.Add(cb2)
                        'ElseIf rdl_drug_type.SelectedValue = "1" Then
                        '    dc5.Controls.Add(cb3)
                    End If


                    txt1.ID = "txt_" & dao.fields.IDA
                    txt1.Style.Add("width", "99%")
                    txt1.Style.Add("Height", "100px")
                    'txt1.Attributes.Add("TextMode", "MultiLine")
                    '------------------
                    dc2.Controls.Add(ddl)
                    '------------

                    ' dc3.Controls.Add(txt1)
                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW

                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)
                    dr.Cells.Add(dc4)
                    dr.Cells.Add(dc5)
                    ' dr.Cells.Add(dc8)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)

                    Table1.Rows.Add(dr)
                ElseIf _detial_type = 1 Then
                    Dim dao_det As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL11_REASON

                    Try
                        dao_det.GET_DATA_BY_FK_LCN_IDA_IDAROW_DDL1_DDL2_ACTIVE(_LCN_IDA, dao.fields.IDA, ddl1, ddl2, True)
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL1 IsNot Nothing Then
                            txt1.Value = dao_det.fields.COL1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 IsNot Nothing Then
                            ddl.SelectedValue = dao_det.fields.COL5
                        End If

                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 IsNot Nothing Then

                        End If
                    Catch ex As Exception

                    End Try


                    Dim cb1 As New CheckBox
                    Dim cb2 As New CheckBox
                    Dim cb3 As New CheckBox
                    Dim cb4 As New CheckBox
                    Dim cb5 As New CheckBox
                    'Dim cb6 As New CheckBox
                    Dim txt_6 As New HtmlTextArea
                    cb1.ID = "cb1_" & dao.fields.IDA
                    cb2.ID = "cb2_" & dao.fields.IDA
                    cb3.ID = "cb3_" & dao.fields.IDA
                    cb4.ID = "cb4_" & dao.fields.IDA
                    cb5.ID = "cb5_" & dao.fields.IDA


                    Try
                        If dao_det.fields.COL5 <> 0 Then
                            cb1.Checked = True
                        End If
                    Catch ex As Exception

                    End Try


                    If rdl_drug_type.SelectedValue = "3" Then
                        dc3.Controls.Add(cb1)
                        'ElseIf rdl_drug_type.SelectedValue = "2" Then
                        '    dc4.Controls.Add(cb2)
                        'ElseIf rdl_drug_type.SelectedValue = "1" Then
                        '    dc5.Controls.Add(cb3)
                    End If


                    txt1.ID = "txt_" & dao.fields.IDA
                    txt1.Style.Add("width", "99%")
                    txt1.Style.Add("Height", "100px")
                    'txt1.Attributes.Add("TextMode", "MultiLine")
                    '------------------
                    dc2.Controls.Add(ddl)
                    '------------

                    ' dc3.Controls.Add(txt1)
                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW

                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)
                    dr.Cells.Add(dc4)
                    dr.Cells.Add(dc5)
                    ' dr.Cells.Add(dc8)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)

                    Table1.Rows.Add(dr)
                End If

            ElseIf dao.fields.TYPE_SHOW = 4 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dc4 As New TableCell
                Dim dc5 As New TableCell
                Dim dc7 As New TableCell
                'Dim dc8 As New TableCell
                Dim dr As New TableRow

                Dim ddl As New DropDownList

                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")

                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1
                dc4.BorderStyle = BorderStyle.Solid
                dc4.BorderWidth = 1
                dc5.BorderStyle = BorderStyle.Solid
                dc5.BorderWidth = 1
                'dc3.ColumnSpan = 6
                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                dc4.BorderStyle = BorderStyle.Solid
                dc4.BorderWidth = 1
                dc5.BorderStyle = BorderStyle.Solid
                dc5.BorderWidth = 1
                'dc8.BorderStyle = BorderStyle.Solid
                'dc8.BorderWidth = 1
                dc3.HorizontalAlign = HorizontalAlign.Center
                dc4.HorizontalAlign = HorizontalAlign.Center
                dc5.HorizontalAlign = HorizontalAlign.Center
                'dc6.HorizontalAlign = HorizontalAlign.Center
                'dc7.HorizontalAlign = HorizontalAlign.Center
                ' dc8.HorizontalAlign = HorizontalAlign.Center


                Dim dao_dgh As New DAO_DRUG.TB_MAS_DRUG_GROUP_HERB_NO3
                dao_dgh.GetDataAll()
                ddl.DataSource = dao_dgh.datas
                ddl.DataTextField = "GROUP_NAME"
                ddl.DataValueField = "GROUP_ID"
                ddl.DataBind()
                ddl.ID = "ddl1_" & dao.fields.IDA
                DropDownInsertDataFirstRow2(ddl, "-----กรุณาเลือก-----", "0")
                'DropDownInsertDataFirstRow2(ddl, "-----กรุณาเลือก-----", "0")
                'Dim item As New WebControls.ListItem
                'item.Text = "--กรุณาเลือก--"
                'item.Value = "0"
                'ddl.Items.Insert(0, item)
                Dim cb1 As New CheckBox
                Dim cb2 As New CheckBox
                Dim cb3 As New CheckBox
                'Dim cb6 As New CheckBox
                Dim txt_6 As New HtmlTextArea
                cb1.ID = "cb1_" & dao.fields.IDA
                cb2.ID = "cb2_" & dao.fields.IDA
                cb3.ID = "cb3_" & dao.fields.IDA


                Dim txt1 As New HtmlTextArea
                If _detial_type = 0 Then
                    Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL

                    Try
                        dao_det.GetDataby_FKLCN_AND_FK_IDA(_LCN_IDA, dao.fields.IDA)
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 IsNot Nothing Then
                            ddl.SelectedValue = dao_det.fields.COL5
                        End If

                    Catch ex As Exception

                    End Try

                    Try
                        If dao_det.fields.COL5 <> 0 Then
                            cb1.Checked = True
                        End If
                    Catch ex As Exception

                    End Try

                    Try
                        txt1.Value = dao_det.fields.COL1
                    Catch ex As Exception

                    End Try
                    txt1.ID = "txt_" & dao.fields.IDA
                    txt1.Style.Add("width", "99%")
                    'txt1.Style.Add("Height", "100px")
                    'txt1.Attributes.Add("TextMode", "MultiLine")
                    '------------------
                    dc2.Controls.Add(ddl)
                    dc2.Controls.Add(txt1)
                    '------------


                    'dc3.Controls.Add(txt1)

                    If rdl_drug_type.SelectedValue = "3" Then
                        dc3.Controls.Add(cb1)
                        'ElseIf rdl_drug_type.SelectedValue = "2" Then
                        '    dc4.Controls.Add(cb2)
                        'ElseIf rdl_drug_type.SelectedValue = "1" Then
                        '    dc5.Controls.Add(cb3)
                    End If
                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW

                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)

                    dr.Cells.Add(dc4)
                    dr.Cells.Add(dc5)
                    'dr.Cells.Add(dc7)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)
                    Table1.Rows.Add(dr)
                ElseIf _detial_type = 1 Then
                    Dim dao_det As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL11_REASON

                    Try
                        dao_det.GET_DATA_BY_FK_LCN_IDA_IDAROW_DDL1_DDL2_ACTIVE(_LCN_IDA, dao.fields.IDA, ddl1, ddl2, True)
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 IsNot Nothing Then
                            ddl.SelectedValue = dao_det.fields.COL5
                        End If

                    Catch ex As Exception

                    End Try

                    Try
                        If dao_det.fields.COL5 <> 0 Then
                            cb1.Checked = True
                        End If
                    Catch ex As Exception

                    End Try

                    Try
                        txt1.Value = dao_det.fields.COL1
                    Catch ex As Exception

                    End Try
                    txt1.ID = "txt_" & dao.fields.IDA
                    txt1.Style.Add("width", "99%")
                    'txt1.Style.Add("Height", "100px")
                    'txt1.Attributes.Add("TextMode", "MultiLine")
                    '------------------
                    dc2.Controls.Add(ddl)
                    dc2.Controls.Add(txt1)
                    '------------


                    'dc3.Controls.Add(txt1)

                    If rdl_drug_type.SelectedValue = "3" Then
                        dc3.Controls.Add(cb1)
                        'ElseIf rdl_drug_type.SelectedValue = "2" Then
                        '    dc4.Controls.Add(cb2)
                        'ElseIf rdl_drug_type.SelectedValue = "1" Then
                        '    dc5.Controls.Add(cb3)
                    End If
                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW

                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)

                    dr.Cells.Add(dc4)
                    dr.Cells.Add(dc5)
                    'dr.Cells.Add(dc7)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)
                    Table1.Rows.Add(dr)
                End If


            ElseIf dao.fields.TYPE_SHOW = 0 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dc4 As New TableCell
                Dim dc5 As New TableCell
                Dim dc7 As New TableCell
                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")
                Dim dr As New TableRow
                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1

                dc3.HorizontalAlign = HorizontalAlign.Center
                dc4.BorderStyle = BorderStyle.Solid
                dc4.BorderWidth = 1
                dc5.BorderStyle = BorderStyle.Solid
                dc5.BorderWidth = 1

                dc3.HorizontalAlign = HorizontalAlign.Center
                dc4.HorizontalAlign = HorizontalAlign.Center
                dc5.HorizontalAlign = HorizontalAlign.Center


                Dim cb1 As New CheckBox
                Dim cb2 As New CheckBox
                Dim cb3 As New CheckBox
                Dim cb4 As New CheckBox
                Dim cb5 As New CheckBox
                'Dim cb6 As New CheckBox
                Dim txt_6 As New HtmlTextArea
                cb1.ID = "cb1_" & dao.fields.IDA
                cb2.ID = "cb2_" & dao.fields.IDA
                cb3.ID = "cb3_" & dao.fields.IDA
                cb4.ID = "cb4_" & dao.fields.IDA
                cb5.ID = "cb5_" & dao.fields.IDA


                'dc3.ColumnSpan = 3
                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                dc9.Text = dao.fields.IDA
                dc10.Text = dao.fields.TYPE_SHOW

                If _detial_type = 0 Then
                    Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL

                    Try
                        dao_det.GetDataby_FKLCN_AND_FK_IDA(_LCN_IDA, dao.fields.IDA)
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL1 <> 0 Then
                            cb1.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL2 <> 0 Then
                            cb2.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL3 <> 0 Then
                            cb3.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL4 <> 0 Then
                            cb4.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 <> 0 Then
                            cb5.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    If rdl_drug_type.SelectedValue = "2" Then
                        dc4.Controls.Add(cb2)
                    ElseIf rdl_drug_type.SelectedValue = "1" Then
                        dc5.Controls.Add(cb3)
                    End If

                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW

                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)
                    dr.Cells.Add(dc4)
                    dr.Cells.Add(dc5)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)
                    Table1.Rows.Add(dr)
                ElseIf _detial_type = 1 Then
                    Dim dao_det As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL11_REASON

                    Try
                        dao_det.GET_DATA_BY_FK_LCN_IDA_IDAROW_DDL1_DDL2_ACTIVE(_LCN_IDA, dao.fields.IDA, ddl1, ddl2, True)
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL1 <> 0 Then
                            cb1.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL2 <> 0 Then
                            cb2.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL3 <> 0 Then
                            cb3.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL4 <> 0 Then
                            cb4.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If dao_det.fields.COL5 <> 0 Then
                            cb5.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                    If rdl_drug_type.SelectedValue = "2" Then
                        dc4.Controls.Add(cb2)
                    ElseIf rdl_drug_type.SelectedValue = "1" Then
                        dc5.Controls.Add(cb3)
                    End If

                    dc9.Text = dao.fields.IDA
                    dc10.Text = dao.fields.TYPE_SHOW

                    dr.Cells.Add(dc1)
                    dr.Cells.Add(dc2)
                    dr.Cells.Add(dc3)
                    dr.Cells.Add(dc4)
                    dr.Cells.Add(dc5)
                    dr.Cells.Add(dc9)
                    dr.Cells.Add(dc10)
                    Table1.Rows.Add(dr)
                End If


            End If
        Next
    End Sub
    Sub bind_table_export(ByVal IDA As Integer)
        bind_head()
        Dim dao As New DAO_DRUG.TB_MAS_DRUG_GROUP_HERB
        dao.GetDataAll()
        Dim dao_ih As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL
        'dao_ih.GetDataby_FKIDA(Request.QueryString("ida"))
        dao_ih.GetDataby_FKIDA(IDA)
        'Try
        '    rdl_drug_type.DataBind()
        '    rdl_drug_type.SelectedValue = dao_ih.fields.DRUG_TYPE
        'Catch ex As Exception

        'End Try
        For Each dao.fields In dao.datas
            If dao.fields.TYPE_SHOW = 1 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                'Dim dc4 As New TableCell
                'Dim dc5 As New TableCell
                'Dim dc6 As New TableCell
                'Dim dc7 As New TableCell
                Dim dc8 As New TableCell
                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")
                Dim dr As New TableRow
                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                'style="margin-left:50px;"
                'dc1.Style.Add("margin-left", "50px")
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                'dc2.Style.Add("margin-left", "50px")
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1
                'dc4.BorderStyle = BorderStyle.Solid
                'dc4.BorderWidth = 1
                'dc5.BorderStyle = BorderStyle.Solid
                'dc5.BorderWidth = 1
                'dc6.BorderStyle = BorderStyle.Solid
                'dc6.BorderWidth = 1
                'dc7.BorderStyle = BorderStyle.Solid
                'dc7.BorderWidth = 1
                dc8.BorderStyle = BorderStyle.Solid
                dc8.BorderWidth = 1
                dc3.HorizontalAlign = HorizontalAlign.Center
                'dc4.HorizontalAlign = HorizontalAlign.Center
                'dc5.HorizontalAlign = HorizontalAlign.Center
                'dc6.HorizontalAlign = HorizontalAlign.Center
                'dc7.HorizontalAlign = HorizontalAlign.Center
                dc8.HorizontalAlign = HorizontalAlign.Center

                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_DETAIL2
                Try
                    dao_det.GetDataby_FKLCN_AND_FK_IDA(Request.QueryString("ida"), dao.fields.IDA)
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL1 <> 0 Then
                        'cb1.Checked = True
                        dc3.Text = "&#10003;"
                    End If
                Catch ex As Exception

                End Try
                'Try
                '    If dao_det.fields.COL2 <> 0 Then
                '        'cb2.Checked = True
                '        dc4.Text = "&#10003;"
                '    End If
                'Catch ex As Exception

                'End Try
                'Try
                '    If dao_det.fields.COL3 <> 0 Then
                '        'cb3.Checked = True
                '        dc5.Text = "&#10003;"
                '    End If
                'Catch ex As Exception

                'End Try
                'Try
                '    If dao_det.fields.COL4 <> 0 Then
                '        'cb4.Checked = True
                '        dc6.Text = "&#10003;"
                '    End If
                'Catch ex As Exception

                'End Try
                'Try
                '    If dao_det.fields.COL5 <> 0 Then
                '        'cb5.Checked = True
                '        dc7.Text = "&#10003;"
                '    End If
                'Catch ex As Exception

                'End Try
                Try
                    If dao_det.fields.COL6 <> 0 Then
                        'cb6.Checked = True
                        dc8.Text = "&#10003;"
                    End If
                Catch ex As Exception

                End Try
                dc9.Text = dao.fields.IDA
                dc10.Text = dao.fields.TYPE_SHOW

                'dc3.Controls.Add(cb1)
                'dc4.Controls.Add(cb2)
                'dc5.Controls.Add(cb3)
                'dc6.Controls.Add(cb4)
                'dc7.Controls.Add(cb5)
                'dc8.Controls.Add(cb6)
                dr.Cells.Add(dc1)
                dr.Cells.Add(dc2)
                dr.Cells.Add(dc3)
                'dr.Cells.Add(dc4)
                'dr.Cells.Add(dc5)
                'dr.Cells.Add(dc6)
                'dr.Cells.Add(dc7)
                dr.Cells.Add(dc8)
                dr.Cells.Add(dc9)
                dr.Cells.Add(dc10)
                Table1.Rows.Add(dr)
            ElseIf dao.fields.TYPE_SHOW = 2 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dr As New TableRow

                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")

                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1
                dc3.ColumnSpan = 6
                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                Dim txt1 As New TextBox
                Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL
                Try
                    dao_det.GetDataby_FKLCN_AND_FK_IDA(Request.QueryString("ida"), dao.fields.IDA)
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL1 IsNot Nothing Then
                        txt1.Text = dao_det.fields.COL1
                        dc3.Text = dao_det.fields.COL1
                    End If
                Catch ex As Exception

                End Try
                txt1.ID = "txt_" & dao.fields.IDA
                'txt1.Style.Add("text-decoration-style", "dotted")
                txt1.Style.Add("width", "99%")

                'dc3.Controls.Add(txt1)
                dc9.Text = dao.fields.IDA
                dc10.Text = dao.fields.TYPE_SHOW

                dr.Cells.Add(dc1)
                dr.Cells.Add(dc2)
                dr.Cells.Add(dc3)
                dr.Cells.Add(dc9)
                dr.Cells.Add(dc10)
                Table1.Rows.Add(dr)
            ElseIf dao.fields.TYPE_SHOW = 0 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")
                Dim dr As New TableRow
                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1

                dc3.HorizontalAlign = HorizontalAlign.Center

                dc3.ColumnSpan = 6
                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                dc9.Text = dao.fields.IDA
                dc10.Text = dao.fields.TYPE_SHOW

                dr.Cells.Add(dc1)
                dr.Cells.Add(dc2)
                dr.Cells.Add(dc3)
                dr.Cells.Add(dc9)
                dr.Cells.Add(dc10)
                Table1.Rows.Add(dr)
            End If
        Next
    End Sub
    Sub bind_table_edit()
        'Table1.BorderStyle = BorderStyle.Solid
        'Table1.BorderWidth = 1
        bind_head()
        Dim dao As New DAO_DRUG.TB_MAS_DRUG_GROUP_HERB
        dao.GetDataAll()
        For Each dao.fields In dao.datas
            If dao.fields.TYPE_SHOW = 1 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                'Dim dc4 As New TableCell
                'Dim dc5 As New TableCell
                'Dim dc6 As New TableCell
                'Dim dc7 As New TableCell
                Dim dc8 As New TableCell
                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")
                Dim dr As New TableRow
                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1
                'dc4.BorderStyle = BorderStyle.Solid
                'dc4.BorderWidth = 1
                'dc5.BorderStyle = BorderStyle.Solid
                'dc5.BorderWidth = 1
                'dc6.BorderStyle = BorderStyle.Solid
                'dc6.BorderWidth = 1
                'dc7.BorderStyle = BorderStyle.Solid
                'dc7.BorderWidth = 1
                dc8.BorderStyle = BorderStyle.Solid
                dc8.BorderWidth = 1
                dc3.HorizontalAlign = HorizontalAlign.Center
                'dc4.HorizontalAlign = HorizontalAlign.Center
                'dc5.HorizontalAlign = HorizontalAlign.Center
                'dc6.HorizontalAlign = HorizontalAlign.Center
                'dc7.HorizontalAlign = HorizontalAlign.Center
                dc8.HorizontalAlign = HorizontalAlign.Center

                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                Dim cb1 As New CheckBox
                Dim cb2 As New CheckBox
                Dim cb3 As New CheckBox
                Dim cb4 As New CheckBox
                Dim cb5 As New CheckBox
                Dim cb6 As New CheckBox
                cb1.ID = "cb1_" & dao.fields.IDA
                cb2.ID = "cb2_" & dao.fields.IDA
                cb3.ID = "cb3_" & dao.fields.IDA
                cb4.ID = "cb4_" & dao.fields.IDA
                cb5.ID = "cb5_" & dao.fields.IDA
                cb6.ID = "cb6_" & dao.fields.IDA
                Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL
                Try
                    dao_det.GetDataby_FKLCN_AND_FK_IDA(Request.QueryString("ida"), dao.fields.IDA)
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL1 <> 0 Then
                        cb1.Checked = True
                    End If
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL2 <> 0 Then
                        cb2.Checked = True
                    End If
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL3 <> 0 Then
                        cb3.Checked = True
                    End If
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL4 <> 0 Then
                        cb4.Checked = True
                    End If
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL5 <> 0 Then
                        cb5.Checked = True
                    End If
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL6 <> 0 Then
                        cb6.Checked = True
                    End If
                Catch ex As Exception

                End Try
                dc9.Text = dao.fields.IDA
                dc10.Text = dao.fields.TYPE_SHOW

                dc3.Controls.Add(cb1)
                'dc4.Controls.Add(cb2)
                'dc5.Controls.Add(cb3)
                'dc6.Controls.Add(cb4)
                'dc7.Controls.Add(cb5)
                dc8.Controls.Add(cb6)
                dr.Cells.Add(dc1)
                dr.Cells.Add(dc2)
                dr.Cells.Add(dc3)
                'dr.Cells.Add(dc4)
                'dr.Cells.Add(dc5)
                'dr.Cells.Add(dc6)
                'dr.Cells.Add(dc7)
                dr.Cells.Add(dc8)
                dr.Cells.Add(dc9)
                dr.Cells.Add(dc10)
                Table1.Rows.Add(dr)
            ElseIf dao.fields.TYPE_SHOW = 2 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dr As New TableRow

                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")

                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1
                dc3.ColumnSpan = 6
                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                Dim txt1 As New TextBox
                Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL
                Try
                    dao_det.GetDataby_FKLCN_AND_FK_IDA(Request.QueryString("ida"), dao.fields.IDA)
                Catch ex As Exception

                End Try
                Try
                    If dao_det.fields.COL1 IsNot Nothing Then
                        txt1.Text = dao_det.fields.COL1
                    End If
                Catch ex As Exception

                End Try
                txt1.ID = "txt_" & dao.fields.IDA
                txt1.Style.Add("width", "99%")
                dc3.Controls.Add(txt1)
                dc9.Text = dao.fields.IDA
                dc10.Text = dao.fields.TYPE_SHOW

                dr.Cells.Add(dc1)
                dr.Cells.Add(dc2)
                dr.Cells.Add(dc3)
                dr.Cells.Add(dc9)
                dr.Cells.Add(dc10)
                Table1.Rows.Add(dr)
            ElseIf dao.fields.TYPE_SHOW = 0 Then
                Dim dc1 As New TableCell
                Dim dc2 As New TableCell
                Dim dc3 As New TableCell
                Dim dc9 As New TableCell
                Dim dc10 As New TableCell
                dc9.Style.Add("display", "none")
                dc10.Style.Add("display", "none")
                Dim dr As New TableRow
                dc1.BorderStyle = BorderStyle.Solid
                dc1.BorderWidth = 1
                dc1.Width = 20
                dc2.BorderStyle = BorderStyle.Solid
                dc2.BorderWidth = 1
                dc2.Width = 200
                dc3.BorderStyle = BorderStyle.Solid
                dc3.BorderWidth = 1

                dc3.HorizontalAlign = HorizontalAlign.Center

                dc3.ColumnSpan = 6
                dc1.Text = dao.fields.COL1
                dc2.Text = dao.fields.COL2
                dc9.Text = dao.fields.IDA
                dc10.Text = dao.fields.TYPE_SHOW

                dr.Cells.Add(dc1)
                dr.Cells.Add(dc2)
                dr.Cells.Add(dc3)
                dr.Cells.Add(dc9)
                dr.Cells.Add(dc10)
                Table1.Rows.Add(dr)
            End If
        Next
    End Sub
    Sub bind_head()
        Dim dc1 As New TableCell
        Dim dc2 As New TableCell
        Dim dc3 As New TableCell
        Dim dc4 As New TableCell
        Dim dc5 As New TableCell
        'Dim dc6 As New TableCell
        'Dim dc7 As New TableCell
        Dim dc8 As New TableCell
        Dim dc9 As New TableCell
        Dim dc10 As New TableCell
        Dim dr As New TableRow
        dc1.BorderStyle = BorderStyle.Solid
        dc1.BorderWidth = 1
        dc1.Width = 20
        dc2.BorderStyle = BorderStyle.Solid
        dc2.BorderWidth = 1
        dc2.Width = 300
        dc3.BorderStyle = BorderStyle.Solid
        dc3.BorderWidth = 1
        dc3.HorizontalAlign = HorizontalAlign.Center
        dc4.BorderStyle = BorderStyle.Solid
        dc4.BorderWidth = 1
        dc4.HorizontalAlign = HorizontalAlign.Center
        dc5.BorderStyle = BorderStyle.Solid
        dc5.BorderWidth = 1
        dc5.HorizontalAlign = HorizontalAlign.Center
        'dc6.BorderStyle = BorderStyle.Solid
        'dc6.BorderWidth = 1
        'dc6.HorizontalAlign = HorizontalAlign.Center
        'dc7.BorderStyle = BorderStyle.Solid
        'dc7.BorderWidth = 1
        'dc7.HorizontalAlign = HorizontalAlign.Center
        'dc8.BorderStyle = BorderStyle.Solid
        'dc8.BorderWidth = 1
        'dc8.HorizontalAlign = HorizontalAlign.Center
        dc9.Style.Add("display", "none")
        dc10.Style.Add("display", "none")
        dc2.Text = "รายการ"
        dc3.Text = "ผลิต"
        dc4.Text = "นำเข้า"
        dc5.Text = "ขาย"
        'dc6.Text = "คาร์บาพิแนม"
        'dc7.Text = "ฮอร์โมนเพศ"
        'dc8.Text = "อื่น ๆ"
        dc2.Style.Add("font-weight", "bold")
        dc3.Style.Add("font-weight", "bold")
        dc4.Style.Add("font-weight", "bold")
        dc5.Style.Add("font-weight", "bold")
        'dc6.Style.Add("font-weight", "bold")
        'dc7.Style.Add("font-weight", "bold")
        dc8.Style.Add("font-weight", "bold")
        dr.Cells.Add(dc1)
        dr.Cells.Add(dc2)
        dr.Cells.Add(dc3)
        dr.Cells.Add(dc4)
        dr.Cells.Add(dc5)
        'dr.Cells.Add(dc6)
        'dr.Cells.Add(dc7)
        dr.Cells.Add(dc8)
        dr.Cells.Add(dc9)
        dr.Cells.Add(dc10)
        Table1.Rows.Add(dr)


    End Sub
    Sub save_data_OLD_ddl5(ByVal _LCN_IDA As String, ByVal _ddl1 As Integer, ByVal _ddl2 As Integer)
        Dim dao_get As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL
        Try
            dao_get.GetDataby_FKIDA(_LCN_IDA)
        Catch ex As Exception

        End Try

        Dim dao_update_old As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL5_REASON
        dao_update_old.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_LCN_IDA, _ddl1, _ddl2, True)
        For Each dao_update_old.fields In dao_update_old.datas
            dao_update_old.fields.UPDATE_DATE = System.DateTime.Now
            dao_update_old.fields.UPDATE_BY = ""
            dao_update_old.fields.ACTIVE = 0
            dao_update_old.update()
        Next


        For Each dao_get.fields In dao_get.datas

            Dim GET_1 As Integer = 0
            Dim GET_2 As Integer = 0
            Dim GET_3 As String = ""
            Dim GET_4 As String = ""
            Dim GET_5 As String = ""
            Dim GET_6 As String = ""
            Dim GET_7 As String = ""
            Dim GET_8 As String = ""
            Dim GET_9 As String = ""

            GET_1 = dao_get.fields.FK_IDA
            GET_2 = dao_get.fields.LCN_IDA
            GET_3 = dao_get.fields.COL1
            GET_4 = dao_get.fields.COL2
            GET_5 = dao_get.fields.COL3
            GET_6 = dao_get.fields.COL4
            GET_7 = dao_get.fields.COL5
            GET_8 = dao_get.fields.COL6
            GET_9 = dao_get.fields.COL6_OTHER


            Dim dao_old As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL5_REASON
            dao_old.fields.ddl1 = _ddl1
            dao_old.fields.ddl2 = _ddl2

            dao_old.fields.FK_IDA_CHK_ROW = GET_1
            dao_old.fields.FK_LCN_IDA = GET_2
            dao_old.fields.COL1 = GET_3
            dao_old.fields.COL2 = GET_4
            dao_old.fields.COL3 = GET_5
            dao_old.fields.COL4 = GET_6
            dao_old.fields.COL5 = GET_7
            dao_old.fields.COL6 = GET_8
            dao_old.fields.COL6_OTHER = GET_9

            dao_old.fields.CREATE_DATE = System.DateTime.Now
            dao_old.fields.CREATE_BY = ""
            dao_old.fields.ACTIVE = 1

            dao_old.insert()

        Next
    End Sub


    Sub save_data_ddl5(ByVal _LCN_IDA As String, ByVal _ddl1 As Integer, ByVal _ddl2 As Integer)
        Dim DD_SELECT As Integer = 0

        'If DD_SELECT = 5 Then

        'End If


        'Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL
        Dim dao_det As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL5_REASON
        dao_det.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_LCN_IDA, _ddl1, _ddl2, True)
        For Each dao_det.fields In dao_det.datas
            'dao_det.delete()
            dao_det.fields.ACTIVE = 0
            dao_det.fields.UPDATE_DATE = System.DateTime.Now
            dao_det.update()
        Next
        Dim i As Integer = 0
        For Each tr As TableRow In Table1.Rows
            If i > 0 Then


                Dim FK_IDA_ROW As Integer = tr.Cells(tr.Cells.Count - 2).Text
                Dim TYPE_SHOW As Integer = tr.Cells(tr.Cells.Count - 1).Text
                Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL5_REASON

                dao.fields.FK_LCN_IDA = _LCN_IDA
                dao.fields.FK_IDA_CHK_ROW = FK_IDA_ROW
                dao.fields.ddl1 = _ddl1
                dao.fields.ddl2 = _ddl2
                dao.fields.CREATE_DATE = System.DateTime.Now
                dao.fields.ACTIVE = 1

                If TYPE_SHOW = 1 Then
                    Dim cb1 As New CheckBox
                    Dim cb2 As New CheckBox
                    Dim cb3 As New CheckBox
                    Dim cb4 As New CheckBox
                    Dim cb5 As New CheckBox
                    Dim cb6 As New CheckBox
                    Dim txt6 As New HtmlTextArea
                    cb1 = tr.Cells(2).FindControl("cb1_" & FK_IDA_ROW)
                    cb2 = tr.Cells(3).FindControl("cb2_" & FK_IDA_ROW)
                    cb3 = tr.Cells(4).FindControl("cb3_" & FK_IDA_ROW)
                    If tr.Cells.Count - 1 >= 5 Then
                        cb4 = tr.Cells(5).FindControl("cb4_" & FK_IDA_ROW)
                        cb5 = tr.Cells(6).FindControl("cb5_" & FK_IDA_ROW)
                        'cb6 = tr.Cells(7).FindControl("cb6_" & FK_IDA)
                    End If
                    Dim jj As Integer = 0

                    Try
                        If cb1.Checked Then
                            dao.fields.COL1 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb2.Checked Then
                            dao.fields.COL2 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb3.Checked Then
                            dao.fields.COL3 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb4.Checked Then
                            dao.fields.COL4 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb5.Checked Then
                            dao.fields.COL5 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        'If cb6.Checked Then
                        '    dao.fields.COL6 = 1
                        '    jj += 1
                        'End If
                        If txt6.Value <> "" Then
                            dao.fields.COL6 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    If jj > 0 Then
                        dao.insert()
                    End If

                ElseIf TYPE_SHOW = 2 Then
                    Dim txt As New HtmlTextArea 'TextBox
                    txt = tr.Cells(2).FindControl("txt_" & FK_IDA_ROW)
                    'dao.fields.COL1 = txt.Text
                    dao.fields.COL1 = txt.Value
                    If txt.Value <> "" Then
                        dao.insert()
                    End If
                ElseIf TYPE_SHOW = 0 Then
                    Dim cb1 As New CheckBox
                    Dim cb2 As New CheckBox
                    Dim cb3 As New CheckBox
                    Dim cb4 As New CheckBox
                    Dim cb5 As New CheckBox
                    Dim cb6 As New CheckBox
                    Dim txt6 As New HtmlTextArea
                    cb1 = tr.Cells(2).FindControl("cb1_" & FK_IDA_ROW)
                    cb2 = tr.Cells(3).FindControl("cb2_" & FK_IDA_ROW)
                    cb3 = tr.Cells(4).FindControl("cb3_" & FK_IDA_ROW)
                    If tr.Cells.Count - 1 >= 5 Then
                        cb4 = tr.Cells(5).FindControl("cb4_" & FK_IDA_ROW)
                        cb5 = tr.Cells(6).FindControl("cb5_" & FK_IDA_ROW)
                        'cb6 = tr.Cells(7).FindControl("cb6_" & FK_IDA)
                    End If
                    Dim jj As Integer = 0

                    Try
                        If cb1.Checked Then
                            dao.fields.COL1 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb2.Checked Then
                            dao.fields.COL2 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb3.Checked Then
                            dao.fields.COL3 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb4.Checked Then
                            dao.fields.COL4 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb5.Checked Then
                            dao.fields.COL5 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        'If cb6.Checked Then
                        '    dao.fields.COL6 = 1
                        '    jj += 1
                        'End If
                        If txt6.Value <> "" Then
                            dao.fields.COL6 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    If jj > 0 Then
                        dao.insert()
                    End If

                ElseIf TYPE_SHOW = 3 Then
                    Dim cb1 As New CheckBox
                    Dim cb2 As New CheckBox
                    Dim cb3 As New CheckBox
                    Dim cb4 As New CheckBox
                    Dim cb5 As New CheckBox
                    Dim cb6 As New CheckBox
                    Dim ddl As New DropDownList
                    Dim txt6 As New HtmlTextArea
                    cb1 = tr.Cells(2).FindControl("cb1_" & FK_IDA_ROW)
                    cb2 = tr.Cells(3).FindControl("cb2_" & FK_IDA_ROW)
                    cb3 = tr.Cells(4).FindControl("cb3_" & FK_IDA_ROW)
                    Try
                        ddl = tr.Cells(1).FindControl("ddl1_" & FK_IDA_ROW)
                    Catch ex As Exception

                    End Try
                    If tr.Cells.Count - 1 >= 5 Then
                        cb4 = tr.Cells(5).FindControl("cb4_" & FK_IDA_ROW)
                        cb5 = tr.Cells(6).FindControl("cb5_" & FK_IDA_ROW)
                        'cb6 = tr.Cells(7).FindControl("cb6_" & FK_IDA)
                    End If
                    Dim jj As Integer = 0

                    Try
                        If cb1.Checked Then
                            dao.fields.COL1 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb2.Checked Then
                            dao.fields.COL2 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb3.Checked Then
                            dao.fields.COL3 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb4.Checked Then
                            dao.fields.COL4 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb5.Checked Then
                            dao.fields.COL5 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        'If cb6.Checked Then
                        '    dao.fields.COL6 = 1
                        '    jj += 1
                        'End If
                        If txt6.Value <> "" Then
                            dao.fields.COL6 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If ddl.SelectedValue <> "0" Then
                            dao.fields.COL5 = ddl.SelectedValue
                        End If
                    Catch ex As Exception

                    End Try
                    'Dim txt As New HtmlTextArea 'TextBox
                    'txt = tr.Cells(2).FindControl("txt_" & FK_IDA)
                    ''dao.fields.COL1 = txt.Text
                    'dao.fields.COL1 = txt.Value

                    If jj > 0 Then
                        dao.insert()
                    End If

                ElseIf TYPE_SHOW = 4 Then
                    Dim cb1 As New CheckBox
                    Dim cb2 As New CheckBox
                    Dim cb3 As New CheckBox
                    Dim cb4 As New CheckBox
                    Dim cb5 As New CheckBox
                    Dim cb6 As New CheckBox
                    Dim ddl As New DropDownList
                    Dim txt6 As New HtmlTextArea
                    cb1 = tr.Cells(2).FindControl("cb1_" & FK_IDA_ROW)
                    cb2 = tr.Cells(3).FindControl("cb2_" & FK_IDA_ROW)
                    cb3 = tr.Cells(4).FindControl("cb3_" & FK_IDA_ROW)
                    Try
                        ddl = tr.Cells(1).FindControl("ddl1_" & FK_IDA_ROW)
                    Catch ex As Exception

                    End Try
                    If tr.Cells.Count - 1 >= 5 Then
                        cb4 = tr.Cells(5).FindControl("cb4_" & FK_IDA_ROW)
                        cb5 = tr.Cells(6).FindControl("cb5_" & FK_IDA_ROW)
                        'cb6 = tr.Cells(7).FindControl("cb6_" & FK_IDA)
                    End If
                    Dim jj As Integer = 0

                    Try
                        If cb1.Checked Then
                            dao.fields.COL1 = 1
                            jj += 1
                        Else
                            dao.fields.COL1 = 0
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb2.Checked Then
                            dao.fields.COL2 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb3.Checked Then
                            dao.fields.COL3 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb4.Checked Then
                            dao.fields.COL4 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb5.Checked Then
                            dao.fields.COL5 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If ddl.SelectedValue <> "0" Then
                            dao.fields.COL5 = ddl.SelectedValue
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        'If cb6.Checked Then
                        '    dao.fields.COL6 = 1
                        '    jj += 1
                        'End If
                        If txt6.Value <> "" Then
                            dao.fields.COL6 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Dim txt As New HtmlTextArea 'TextBox
                    txt = tr.Cells(1).FindControl("txt_" & FK_IDA_ROW)
                    'dao.fields.COL1 = txt.Text
                    dao.fields.COL1 = txt.Value

                    If jj > 0 Then
                        dao.insert()
                    End If


                End If
            End If
            i += 1
        Next
    End Sub
    Sub save_data_OLD_ddl10(ByVal _LCN_IDA As String, ByVal _ddl1 As Integer, ByVal _ddl2 As Integer)
        Dim dao_get As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL
        Try
            dao_get.GetDataby_FKIDA(_LCN_IDA)
        Catch ex As Exception

        End Try

        Dim dao_update_old As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL10_REASON
        dao_update_old.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_LCN_IDA, _ddl1, _ddl2, True)
        For Each dao_update_old.fields In dao_update_old.datas
            dao_update_old.fields.UPDATE_DATE = System.DateTime.Now
            dao_update_old.fields.UPDATE_BY = ""
            dao_update_old.fields.ACTIVE = 0
            dao_update_old.update()
        Next


        For Each dao_get.fields In dao_get.datas

            Dim GET_1 As Integer = 0
            Dim GET_2 As Integer = 0
            Dim GET_3 As String = ""
            Dim GET_4 As String = ""
            Dim GET_5 As String = ""
            Dim GET_6 As String = ""
            Dim GET_7 As String = ""
            Dim GET_8 As String = ""
            Dim GET_9 As String = ""

            GET_1 = dao_get.fields.FK_IDA
            GET_2 = dao_get.fields.LCN_IDA
            GET_3 = dao_get.fields.COL1
            GET_4 = dao_get.fields.COL2
            GET_5 = dao_get.fields.COL3
            GET_6 = dao_get.fields.COL4
            GET_7 = dao_get.fields.COL5
            GET_8 = dao_get.fields.COL6
            GET_9 = dao_get.fields.COL6_OTHER


            Dim dao_old As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL10_REASON
            dao_old.fields.ddl1 = _ddl1
            dao_old.fields.ddl2 = _ddl2

            dao_old.fields.FK_IDA_CHK_ROW = GET_1
            dao_old.fields.FK_LCN_IDA = GET_2
            dao_old.fields.COL1 = GET_3
            dao_old.fields.COL2 = GET_4
            dao_old.fields.COL3 = GET_5
            dao_old.fields.COL4 = GET_6
            dao_old.fields.COL5 = GET_7
            dao_old.fields.COL6 = GET_8
            dao_old.fields.COL6_OTHER = GET_9

            dao_old.fields.CREATE_DATE = System.DateTime.Now
            dao_old.fields.CREATE_BY = ""
            dao_old.fields.ACTIVE = 1

            dao_old.insert()

        Next




    End Sub
    Sub save_data_ddl10(ByVal _LCN_IDA As String, ByVal _ddl1 As Integer, ByVal _ddl2 As Integer)
        Dim DD_SELECT As Integer = 0

        'If DD_SELECT = 5 Then

        'End If


        'Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL
        Dim dao_det As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL10_REASON
        dao_det.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_LCN_IDA, _ddl1, _ddl2, True)
        For Each dao_det.fields In dao_det.datas
            'dao_det.delete()
            dao_det.fields.ACTIVE = 0
            dao_det.fields.UPDATE_DATE = System.DateTime.Now
            dao_det.update()
        Next
        Dim i As Integer = 0
        For Each tr As TableRow In Table1.Rows
            If i > 0 Then


                Dim FK_IDA_ROW As Integer = tr.Cells(tr.Cells.Count - 2).Text
                Dim TYPE_SHOW As Integer = tr.Cells(tr.Cells.Count - 1).Text
                Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL10_REASON

                dao.fields.FK_LCN_IDA = _LCN_IDA
                dao.fields.FK_IDA_CHK_ROW = FK_IDA_ROW
                dao.fields.ddl1 = _ddl1
                dao.fields.ddl2 = _ddl2
                dao.fields.CREATE_DATE = System.DateTime.Now
                dao.fields.ACTIVE = 1

                If TYPE_SHOW = 1 Then
                    Dim cb1 As New CheckBox
                    Dim cb2 As New CheckBox
                    Dim cb3 As New CheckBox
                    Dim cb4 As New CheckBox
                    Dim cb5 As New CheckBox
                    Dim cb6 As New CheckBox
                    Dim txt6 As New HtmlTextArea
                    cb1 = tr.Cells(2).FindControl("cb1_" & FK_IDA_ROW)
                    cb2 = tr.Cells(3).FindControl("cb2_" & FK_IDA_ROW)
                    cb3 = tr.Cells(4).FindControl("cb3_" & FK_IDA_ROW)
                    If tr.Cells.Count - 1 >= 5 Then
                        cb4 = tr.Cells(5).FindControl("cb4_" & FK_IDA_ROW)
                        cb5 = tr.Cells(6).FindControl("cb5_" & FK_IDA_ROW)
                        'cb6 = tr.Cells(7).FindControl("cb6_" & FK_IDA)
                    End If
                    Dim jj As Integer = 0

                    Try
                        If cb1.Checked Then
                            dao.fields.COL1 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb2.Checked Then
                            dao.fields.COL2 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb3.Checked Then
                            dao.fields.COL3 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb4.Checked Then
                            dao.fields.COL4 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb5.Checked Then
                            dao.fields.COL5 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        'If cb6.Checked Then
                        '    dao.fields.COL6 = 1
                        '    jj += 1
                        'End If
                        If txt6.Value <> "" Then
                            dao.fields.COL6 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    If jj > 0 Then
                        dao.insert()
                    End If

                ElseIf TYPE_SHOW = 2 Then
                    Dim txt As New HtmlTextArea 'TextBox
                    txt = tr.Cells(2).FindControl("txt_" & FK_IDA_ROW)
                    'dao.fields.COL1 = txt.Text
                    dao.fields.COL1 = txt.Value
                    If txt.Value <> "" Then
                        dao.insert()
                    End If
                ElseIf TYPE_SHOW = 0 Then
                    Dim cb1 As New CheckBox
                    Dim cb2 As New CheckBox
                    Dim cb3 As New CheckBox
                    Dim cb4 As New CheckBox
                    Dim cb5 As New CheckBox
                    Dim cb6 As New CheckBox
                    Dim txt6 As New HtmlTextArea
                    cb1 = tr.Cells(2).FindControl("cb1_" & FK_IDA_ROW)
                    cb2 = tr.Cells(3).FindControl("cb2_" & FK_IDA_ROW)
                    cb3 = tr.Cells(4).FindControl("cb3_" & FK_IDA_ROW)
                    If tr.Cells.Count - 1 >= 5 Then
                        cb4 = tr.Cells(5).FindControl("cb4_" & FK_IDA_ROW)
                        cb5 = tr.Cells(6).FindControl("cb5_" & FK_IDA_ROW)
                        'cb6 = tr.Cells(7).FindControl("cb6_" & FK_IDA)
                    End If
                    Dim jj As Integer = 0

                    Try
                        If cb1.Checked Then
                            dao.fields.COL1 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb2.Checked Then
                            dao.fields.COL2 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb3.Checked Then
                            dao.fields.COL3 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb4.Checked Then
                            dao.fields.COL4 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb5.Checked Then
                            dao.fields.COL5 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        'If cb6.Checked Then
                        '    dao.fields.COL6 = 1
                        '    jj += 1
                        'End If
                        If txt6.Value <> "" Then
                            dao.fields.COL6 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    If jj > 0 Then
                        dao.insert()
                    End If

                ElseIf TYPE_SHOW = 3 Then
                    Dim cb1 As New CheckBox
                    Dim cb2 As New CheckBox
                    Dim cb3 As New CheckBox
                    Dim cb4 As New CheckBox
                    Dim cb5 As New CheckBox
                    Dim cb6 As New CheckBox
                    Dim ddl As New DropDownList
                    Dim txt6 As New HtmlTextArea
                    cb1 = tr.Cells(2).FindControl("cb1_" & FK_IDA_ROW)
                    cb2 = tr.Cells(3).FindControl("cb2_" & FK_IDA_ROW)
                    cb3 = tr.Cells(4).FindControl("cb3_" & FK_IDA_ROW)
                    Try
                        ddl = tr.Cells(1).FindControl("ddl1_" & FK_IDA_ROW)
                    Catch ex As Exception

                    End Try
                    If tr.Cells.Count - 1 >= 5 Then
                        cb4 = tr.Cells(5).FindControl("cb4_" & FK_IDA_ROW)
                        cb5 = tr.Cells(6).FindControl("cb5_" & FK_IDA_ROW)
                        'cb6 = tr.Cells(7).FindControl("cb6_" & FK_IDA)
                    End If
                    Dim jj As Integer = 0

                    Try
                        If cb1.Checked Then
                            dao.fields.COL1 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb2.Checked Then
                            dao.fields.COL2 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb3.Checked Then
                            dao.fields.COL3 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb4.Checked Then
                            dao.fields.COL4 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb5.Checked Then
                            dao.fields.COL5 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        'If cb6.Checked Then
                        '    dao.fields.COL6 = 1
                        '    jj += 1
                        'End If
                        If txt6.Value <> "" Then
                            dao.fields.COL6 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If ddl.SelectedValue <> "0" Then
                            dao.fields.COL5 = ddl.SelectedValue
                        End If
                    Catch ex As Exception

                    End Try
                    'Dim txt As New HtmlTextArea 'TextBox
                    'txt = tr.Cells(2).FindControl("txt_" & FK_IDA)
                    ''dao.fields.COL1 = txt.Text
                    'dao.fields.COL1 = txt.Value

                    If jj > 0 Then
                        dao.insert()
                    End If

                ElseIf TYPE_SHOW = 4 Then
                    Dim cb1 As New CheckBox
                    Dim cb2 As New CheckBox
                    Dim cb3 As New CheckBox
                    Dim cb4 As New CheckBox
                    Dim cb5 As New CheckBox
                    Dim cb6 As New CheckBox
                    Dim ddl As New DropDownList
                    Dim txt6 As New HtmlTextArea
                    cb1 = tr.Cells(2).FindControl("cb1_" & FK_IDA_ROW)
                    cb2 = tr.Cells(3).FindControl("cb2_" & FK_IDA_ROW)
                    cb3 = tr.Cells(4).FindControl("cb3_" & FK_IDA_ROW)
                    Try
                        ddl = tr.Cells(1).FindControl("ddl1_" & FK_IDA_ROW)
                    Catch ex As Exception

                    End Try
                    If tr.Cells.Count - 1 >= 5 Then
                        cb4 = tr.Cells(5).FindControl("cb4_" & FK_IDA_ROW)
                        cb5 = tr.Cells(6).FindControl("cb5_" & FK_IDA_ROW)
                        'cb6 = tr.Cells(7).FindControl("cb6_" & FK_IDA)
                    End If
                    Dim jj As Integer = 0

                    Try
                        If cb1.Checked Then
                            dao.fields.COL1 = 1
                            jj += 1
                        Else
                            dao.fields.COL1 = 0
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb2.Checked Then
                            dao.fields.COL2 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb3.Checked Then
                            dao.fields.COL3 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb4.Checked Then
                            dao.fields.COL4 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb5.Checked Then
                            dao.fields.COL5 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If ddl.SelectedValue <> "0" Then
                            dao.fields.COL5 = ddl.SelectedValue
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        'If cb6.Checked Then
                        '    dao.fields.COL6 = 1
                        '    jj += 1
                        'End If
                        If txt6.Value <> "" Then
                            dao.fields.COL6 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Dim txt As New HtmlTextArea 'TextBox
                    txt = tr.Cells(1).FindControl("txt_" & FK_IDA_ROW)
                    'dao.fields.COL1 = txt.Text
                    dao.fields.COL1 = txt.Value

                    If jj > 0 Then
                        dao.insert()
                    End If


                End If
            End If
            i += 1
        Next
    End Sub
    Sub save_data_OLD_ddl11(ByVal _LCN_IDA As String, ByVal _ddl1 As Integer, ByVal _ddl2 As Integer)
        Dim dao_get As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL
        Try
            dao_get.GetDataby_FKIDA(_LCN_IDA)
        Catch ex As Exception

        End Try

        Dim dao_update_old As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL11_REASON
        dao_update_old.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_LCN_IDA, _ddl1, _ddl2, True)
        For Each dao_update_old.fields In dao_update_old.datas
            dao_update_old.fields.UPDATE_DATE = System.DateTime.Now
            dao_update_old.fields.UPDATE_BY = ""
            dao_update_old.fields.ACTIVE = 0
            dao_update_old.update()
        Next


        For Each dao_get.fields In dao_get.datas

            Dim GET_1 As Integer = 0
            Dim GET_2 As Integer = 0
            Dim GET_3 As String = ""
            Dim GET_4 As String = ""
            Dim GET_5 As String = ""
            Dim GET_6 As String = ""
            Dim GET_7 As String = ""
            Dim GET_8 As String = ""
            Dim GET_9 As String = ""

            GET_1 = dao_get.fields.FK_IDA
            GET_2 = dao_get.fields.LCN_IDA
            GET_3 = dao_get.fields.COL1
            GET_4 = dao_get.fields.COL2
            GET_5 = dao_get.fields.COL3
            GET_6 = dao_get.fields.COL4
            GET_7 = dao_get.fields.COL5
            GET_8 = dao_get.fields.COL6
            GET_9 = dao_get.fields.COL6_OTHER


            Dim dao_old As New DAO_LCN.TB_OLD_LCN_APPROVE_EDIT_DDL11_REASON
            dao_old.fields.ddl1 = _ddl1
            dao_old.fields.ddl2 = _ddl2

            dao_old.fields.FK_IDA_CHK_ROW = GET_1
            dao_old.fields.FK_LCN_IDA = GET_2
            dao_old.fields.COL1 = GET_3
            dao_old.fields.COL2 = GET_4
            dao_old.fields.COL3 = GET_5
            dao_old.fields.COL4 = GET_6
            dao_old.fields.COL5 = GET_7
            dao_old.fields.COL6 = GET_8
            dao_old.fields.COL6_OTHER = GET_9

            dao_old.fields.CREATE_DATE = System.DateTime.Now
            dao_old.fields.CREATE_BY = ""
            dao_old.fields.ACTIVE = 1

            dao_old.insert()

        Next




    End Sub
    Sub save_data_ddl11(ByVal _LCN_IDA As String, ByVal _ddl1 As Integer, ByVal _ddl2 As Integer)
        Dim DD_SELECT As Integer = 0

        'If DD_SELECT = 5 Then

        'End If


        'Dim dao_det As New DAO_DRUG.TB_DALCN_IMPORT_DRUG_GROUP_HERB_DETAIL
        Dim dao_det As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL11_REASON
        dao_det.GET_DATA_BY_FK_LCN_IDA_DDL1_DDL2_ACTIVE(_LCN_IDA, _ddl1, _ddl2, True)
        For Each dao_det.fields In dao_det.datas
            'dao_det.delete()
            dao_det.fields.ACTIVE = 0
            dao_det.fields.UPDATE_DATE = System.DateTime.Now
            dao_det.update()
        Next
        Dim i As Integer = 0
        For Each tr As TableRow In Table1.Rows
            If i > 0 Then


                Dim FK_IDA_ROW As Integer = tr.Cells(tr.Cells.Count - 2).Text
                Dim TYPE_SHOW As Integer = tr.Cells(tr.Cells.Count - 1).Text
                Dim dao As New DAO_LCN.TB_LCN_APPROVE_EDIT_DDL11_REASON

                dao.fields.FK_LCN_IDA = _LCN_IDA
                dao.fields.FK_IDA_CHK_ROW = FK_IDA_ROW
                dao.fields.ddl1 = _ddl1
                dao.fields.ddl2 = _ddl2
                dao.fields.CREATE_DATE = System.DateTime.Now
                dao.fields.ACTIVE = 1

                If TYPE_SHOW = 1 Then
                    Dim cb1 As New CheckBox
                    Dim cb2 As New CheckBox
                    Dim cb3 As New CheckBox
                    Dim cb4 As New CheckBox
                    Dim cb5 As New CheckBox
                    Dim cb6 As New CheckBox
                    Dim txt6 As New HtmlTextArea
                    cb1 = tr.Cells(2).FindControl("cb1_" & FK_IDA_ROW)
                    cb2 = tr.Cells(3).FindControl("cb2_" & FK_IDA_ROW)
                    cb3 = tr.Cells(4).FindControl("cb3_" & FK_IDA_ROW)
                    If tr.Cells.Count - 1 >= 5 Then
                        cb4 = tr.Cells(5).FindControl("cb4_" & FK_IDA_ROW)
                        cb5 = tr.Cells(6).FindControl("cb5_" & FK_IDA_ROW)
                        'cb6 = tr.Cells(7).FindControl("cb6_" & FK_IDA)
                    End If
                    Dim jj As Integer = 0

                    Try
                        If cb1.Checked Then
                            dao.fields.COL1 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb2.Checked Then
                            dao.fields.COL2 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb3.Checked Then
                            dao.fields.COL3 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb4.Checked Then
                            dao.fields.COL4 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb5.Checked Then
                            dao.fields.COL5 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        'If cb6.Checked Then
                        '    dao.fields.COL6 = 1
                        '    jj += 1
                        'End If
                        If txt6.Value <> "" Then
                            dao.fields.COL6 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    If jj > 0 Then
                        dao.insert()
                    End If

                ElseIf TYPE_SHOW = 2 Then
                    Dim txt As New HtmlTextArea 'TextBox
                    txt = tr.Cells(2).FindControl("txt_" & FK_IDA_ROW)
                    'dao.fields.COL1 = txt.Text
                    dao.fields.COL1 = txt.Value
                    If txt.Value <> "" Then
                        dao.insert()
                    End If
                ElseIf TYPE_SHOW = 0 Then
                    Dim cb1 As New CheckBox
                    Dim cb2 As New CheckBox
                    Dim cb3 As New CheckBox
                    Dim cb4 As New CheckBox
                    Dim cb5 As New CheckBox
                    Dim cb6 As New CheckBox
                    Dim txt6 As New HtmlTextArea
                    cb1 = tr.Cells(2).FindControl("cb1_" & FK_IDA_ROW)
                    cb2 = tr.Cells(3).FindControl("cb2_" & FK_IDA_ROW)
                    cb3 = tr.Cells(4).FindControl("cb3_" & FK_IDA_ROW)
                    If tr.Cells.Count - 1 >= 5 Then
                        cb4 = tr.Cells(5).FindControl("cb4_" & FK_IDA_ROW)
                        cb5 = tr.Cells(6).FindControl("cb5_" & FK_IDA_ROW)
                        'cb6 = tr.Cells(7).FindControl("cb6_" & FK_IDA)
                    End If
                    Dim jj As Integer = 0

                    Try
                        If cb1.Checked Then
                            dao.fields.COL1 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb2.Checked Then
                            dao.fields.COL2 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb3.Checked Then
                            dao.fields.COL3 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb4.Checked Then
                            dao.fields.COL4 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb5.Checked Then
                            dao.fields.COL5 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        'If cb6.Checked Then
                        '    dao.fields.COL6 = 1
                        '    jj += 1
                        'End If
                        If txt6.Value <> "" Then
                            dao.fields.COL6 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    If jj > 0 Then
                        dao.insert()
                    End If

                ElseIf TYPE_SHOW = 3 Then
                    Dim cb1 As New CheckBox
                    Dim cb2 As New CheckBox
                    Dim cb3 As New CheckBox
                    Dim cb4 As New CheckBox
                    Dim cb5 As New CheckBox
                    Dim cb6 As New CheckBox
                    Dim ddl As New DropDownList
                    Dim txt6 As New HtmlTextArea
                    cb1 = tr.Cells(2).FindControl("cb1_" & FK_IDA_ROW)
                    cb2 = tr.Cells(3).FindControl("cb2_" & FK_IDA_ROW)
                    cb3 = tr.Cells(4).FindControl("cb3_" & FK_IDA_ROW)
                    Try
                        ddl = tr.Cells(1).FindControl("ddl1_" & FK_IDA_ROW)
                    Catch ex As Exception

                    End Try
                    If tr.Cells.Count - 1 >= 5 Then
                        cb4 = tr.Cells(5).FindControl("cb4_" & FK_IDA_ROW)
                        cb5 = tr.Cells(6).FindControl("cb5_" & FK_IDA_ROW)
                        'cb6 = tr.Cells(7).FindControl("cb6_" & FK_IDA)
                    End If
                    Dim jj As Integer = 0

                    Try
                        If cb1.Checked Then
                            dao.fields.COL1 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb2.Checked Then
                            dao.fields.COL2 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb3.Checked Then
                            dao.fields.COL3 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb4.Checked Then
                            dao.fields.COL4 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb5.Checked Then
                            dao.fields.COL5 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        'If cb6.Checked Then
                        '    dao.fields.COL6 = 1
                        '    jj += 1
                        'End If
                        If txt6.Value <> "" Then
                            dao.fields.COL6 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If ddl.SelectedValue <> "0" Then
                            dao.fields.COL5 = ddl.SelectedValue
                        End If
                    Catch ex As Exception

                    End Try
                    'Dim txt As New HtmlTextArea 'TextBox
                    'txt = tr.Cells(2).FindControl("txt_" & FK_IDA)
                    ''dao.fields.COL1 = txt.Text
                    'dao.fields.COL1 = txt.Value

                    If jj > 0 Then
                        dao.insert()
                    End If

                ElseIf TYPE_SHOW = 4 Then
                    Dim cb1 As New CheckBox
                    Dim cb2 As New CheckBox
                    Dim cb3 As New CheckBox
                    Dim cb4 As New CheckBox
                    Dim cb5 As New CheckBox
                    Dim cb6 As New CheckBox
                    Dim ddl As New DropDownList
                    Dim txt6 As New HtmlTextArea
                    cb1 = tr.Cells(2).FindControl("cb1_" & FK_IDA_ROW)
                    cb2 = tr.Cells(3).FindControl("cb2_" & FK_IDA_ROW)
                    cb3 = tr.Cells(4).FindControl("cb3_" & FK_IDA_ROW)
                    Try
                        ddl = tr.Cells(1).FindControl("ddl1_" & FK_IDA_ROW)
                    Catch ex As Exception

                    End Try
                    If tr.Cells.Count - 1 >= 5 Then
                        cb4 = tr.Cells(5).FindControl("cb4_" & FK_IDA_ROW)
                        cb5 = tr.Cells(6).FindControl("cb5_" & FK_IDA_ROW)
                        'cb6 = tr.Cells(7).FindControl("cb6_" & FK_IDA)
                    End If
                    Dim jj As Integer = 0

                    Try
                        If cb1.Checked Then
                            dao.fields.COL1 = 1
                            jj += 1
                        Else
                            dao.fields.COL1 = 0
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb2.Checked Then
                            dao.fields.COL2 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb3.Checked Then
                            dao.fields.COL3 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb4.Checked Then
                            dao.fields.COL4 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb5.Checked Then
                            dao.fields.COL5 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If ddl.SelectedValue <> "0" Then
                            dao.fields.COL5 = ddl.SelectedValue
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        'If cb6.Checked Then
                        '    dao.fields.COL6 = 1
                        '    jj += 1
                        'End If
                        If txt6.Value <> "" Then
                            dao.fields.COL6 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Dim txt As New HtmlTextArea 'TextBox
                    txt = tr.Cells(1).FindControl("txt_" & FK_IDA_ROW)
                    'dao.fields.COL1 = txt.Text
                    dao.fields.COL1 = txt.Value

                    If jj > 0 Then
                        dao.insert()
                    End If


                End If
            End If
            i += 1
        Next
    End Sub
    Sub save_data_edit()
        Dim dao_t As New DAO_DRUG.TB_DALCN_PRODUCTION_DRUG_TYPE_DETAIL
        dao_t.GetDataby_FKIDA_AND_EDT_ID(Request.QueryString("ida"), Request.QueryString("ida_c"))
        Try
            For Each dao_t.fields In dao_t.datas
                dao_t.delete()
            Next
        Catch ex As Exception

        End Try

        dao_t = New DAO_DRUG.TB_DALCN_PRODUCTION_DRUG_TYPE_DETAIL
        dao_t.fields.FK_IDA = Request.QueryString("ida")
        dao_t.fields.DRUG_TYPE = rdl_drug_type.SelectedValue
        dao_t.fields.FK_EDIT_COUNT = Request.QueryString("ida_c")
        dao_t.fields.EDIT_TYPE = 13
        dao_t.insert()


        Dim dao_det As New DAO_DRUG.TB_DALCN_PRODUCTION_DRUG_TYPE_DETAIL2
        dao_det.GetDataby_FKIDA_AND_EDT_ID(Request.QueryString("ida"), Request.QueryString("ida_c"))
        For Each dao_det.fields In dao_det.datas
            dao_det.delete()
        Next
        Dim i As Integer = 0
        For Each tr As TableRow In Table1.Rows
            If i > 0 Then


                Dim FK_IDA As Integer = tr.Cells(tr.Cells.Count - 2).Text
                Dim TYPE_SHOW As Integer = tr.Cells(tr.Cells.Count - 1).Text
                Dim dao As New DAO_DRUG.TB_DALCN_PRODUCTION_DRUG_TYPE_DETAIL2
                dao.fields.LCN_IDA = Request.QueryString("ida")
                dao.fields.FK_IDA = FK_IDA
                dao.fields.FK_EDIT_COUNT = Request.QueryString("ida_c")
                dao.fields.EDIT_TYPE = 13
                If TYPE_SHOW = 1 Then
                    Dim cb1 As New CheckBox
                    Dim cb2 As New CheckBox
                    Dim cb3 As New CheckBox
                    Dim cb4 As New CheckBox
                    Dim cb5 As New CheckBox
                    Dim cb6 As New CheckBox
                    Dim txt6 As New HtmlTextArea
                    cb1 = tr.Cells(2).FindControl("cb1_" & FK_IDA)
                    cb2 = tr.Cells(3).FindControl("cb2_" & FK_IDA)
                    cb3 = tr.Cells(4).FindControl("cb3_" & FK_IDA)
                    If tr.Cells.Count - 1 >= 5 Then
                        cb4 = tr.Cells(5).FindControl("cb4_" & FK_IDA)
                        cb5 = tr.Cells(6).FindControl("cb5_" & FK_IDA)
                        cb6 = tr.Cells(7).FindControl("cb6_" & FK_IDA)
                    End If


                    Dim jj As Integer = 0

                    Try
                        If cb1.Checked Then
                            dao.fields.COL1 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb2.Checked Then
                            dao.fields.COL2 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb3.Checked Then
                            dao.fields.COL3 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb4.Checked Then
                            dao.fields.COL4 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If cb5.Checked Then
                            dao.fields.COL5 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        'If cb6.Checked Then
                        '    dao.fields.COL6 = 1
                        '    jj += 1
                        'End If
                        If txt6.Value <> "" Then
                            dao.fields.COL6 = 1
                            jj += 1
                        End If
                    Catch ex As Exception

                    End Try
                    If jj > 0 Then
                        dao.insert()
                    End If
                ElseIf TYPE_SHOW = 2 Then
                    Dim txt As New HtmlTextArea 'TextBox
                    txt = tr.Cells(2).FindControl("txt_" & FK_IDA)
                    dao.fields.COL1 = txt.Value 'txt.Text

                    If txt.Value <> "" Then
                        dao.insert()
                    End If

                End If
            End If
            i += 1
        Next
    End Sub
    'Private Sub btn_SAVE_Click(sender As Object, e As EventArgs) Handles btn_SAVE.Click
    '    save_date()
    '    bind_table()
    '    Response.Write("<script type='text/javascript'>alert('บันทึกเรียบร้อย');</script> ")

    'End Sub
    Sub render_pdf()
        Dim tbl As New cls_itextsharp.TableToPdf
        Dim prn As New cls_itextsharp.TableToPdf
        prn.TableToPdf(Table1, "test")
    End Sub
End Class