﻿Imports FDA_DRUG_HERB.Graph3DMultiple
Imports System.Web.Script.Serialization
Public Class FRM_E_TRACKING_GROUP_GRAPH
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'bind_graph()
            bind_graph_new2()
            If Request.QueryString("g") <> "" Then
                Select Case Request.QueryString("g")
                    Case "1"
                        Label1.Text = "ทะเบียนยาเคมี"
                    Case "2"
                        Label1.Text = "ทะเบียนยาชีววัตถุ"
                    Case "3"
                        Label1.Text = "ทะเบียนยาโบราณ"
                    Case "4"
                        Label1.Text = "โฆษณายา"
                    Case "5"
                        Label1.Text = "ใบอนุญาตสถานที่"
                    Case "6"
                        Label1.Text = "บัญชีหลัก"

                End Select


            End If
        End If
    End Sub
    Public Sub bind_graph_new2()
        Dim bao_real As New BAO.ClsDBSqlcommand
        Dim dt1 As New DataTable
        dt1 = bao_real.SP_E_TRACKING_WORK_BASE_DATE_REAL_NULL()
        For Each dr As DataRow In dt1.Rows
            Dim ws As New WS_GETDATE_WORKING.BasicHttpBinding_IService1
            Dim date_result As Date
            Dim work_day As Integer = 0
            Try
                work_day = dr("WORK_DAYS")
            Catch ex As Exception

            End Try
            ws.GETDATE_WORKING(CDate(dr("rcvdate")), True, dr("WORK_DAYS"), True, date_result, True)

            Dim bao_2 As New BAO.ClsDBSqlcommand
            bao_2.SP_UPDATE_E_TRACKING_REAL_DATE(dr("IDA"), date_result.ToShortDateString())

            'Dim dao1 As New DAO_DRUG.TB_E_TRACKING_BASE
            'dao1.GetDataby_IDA(dr("IDA"))
            'Try
            '    dao1.fields.date_real_cp = date_result
            '    dao1.update()
            'Catch ex As Exception

            'End Try

            'dr("date_last") = date_result
        Next


        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        'dt = bao.SP_E_TRACKING_WORK_GROUP()
        dt = bao.SP_E_TRACKING_WORK_GROUP_BY_GROUP(Request.QueryString("g"))

        Dim bao_list As New BAO.ClsDBSqlcommand
        Dim dt_list As New DataTable
        dt_list = bao_list.SP_E_TRACKING_WORK_LIST_ALL_BY_GROUP(Request.QueryString("g"))
        dt_list.Columns.Add("date_last", GetType(Date))
        dt_list.Columns.Add("day_cal", GetType(Integer))



        For Each dr As DataRow In dt_list.Rows
           
            Dim days As Double = 0
            Dim date_t As Date
            Try
                If Year(CDate(dr("date_real_cp"))) > 3000 Then
                    date_t = CDate(dr("date_real_cp")).AddYears(-543)
                Else
                    date_t = CDate(dr("date_real_cp"))
                End If
            Catch ex As Exception

            End Try
            Try
                days = DateDiff(DateInterval.Day, date_t, CDate(dr("appdate")))
            Catch ex As Exception
                days = DateDiff(DateInterval.Day, date_t, Date.Now)
            End Try

            dr("day_cal") = days
        Next

        Dim bao2 As New BAO.ClsDBSqlcommand
        Dim dt2 As New DataTable
        Dim dao As New DAO_DRUG.TB_MAS_E_TRACKING_GAP
        dao.GetDataAll()
        Try
            dt2 = bao2.TBL_E_TRACKING_GAP(dao.fields.GAP_SET)
        Catch ex As Exception
            dt2 = bao2.TBL_E_TRACKING_GAP(120)
        End Try

        For Each dr As DataRow In dt.Rows


            'dt_list.Select("day_cal > '" & dt(0)("max_gap") & "'")
            dr("less120") = dt_list.Compute("count(IDA)", "day_cal > '" & dt2(0)("max_gap") & "' and wrkuntcd='" & dr("wrkuntcd") & "'")
            dr("less60_to_120") = dt_list.Compute("count(IDA)", "day_cal > '" & dt2(1)("gap") & "' and day_cal <= '" & dt2(1)("max_gap") & "' and wrkuntcd='" & dr("wrkuntcd") & "'")
            dr("less0_to_60") = dt_list.Compute("count(IDA)", "day_cal >= '" & dt2(2)("gap") & "' and day_cal < '" & dt2(2)("max_gap") & "' and wrkuntcd='" & dr("wrkuntcd") & "'")
            dr("more0_to_60") = dt_list.Compute("count(IDA)", "day_cal >= '" & dt2(3)("max_gap") & "' and day_cal < '" & dt2(3)("gap") & "' and wrkuntcd='" & dr("wrkuntcd") & "'")
            dr("more60_to_120") = dt_list.Compute("count(IDA)", "day_cal < '" & dt2(4)("gap") & "' and day_cal >= '" & dt2(4)("max_gap") & "' and wrkuntcd='" & dr("wrkuntcd") & "'")
            dr("more120") = dt_list.Compute("count(IDA)", "day_cal < '" & dt2(5)("max_gap") & "' and wrkuntcd='" & dr("wrkuntcd") & "'")


        Next
        For i As Integer = dt.Rows.Count - 1 To 0 Step -1
            Dim dr As DataRow = dt.Rows(i)
            If dr("less120") = "0" And dr("less60_to_120") = "0" And dr("less0_to_60") = "0" And dr("more0_to_60") = "0" And dr("more60_to_120") = "0" And dr("more120") = "0" Then
                'dr.Delete()
                dt.Rows.RemoveAt(i)
            End If
        Next
        If dt.Rows.Count > 0 Then
            Dim rootobject As New Graph3DMultiple.Rootobject ' Rootobject

            Dim cha As New Graph3DMultiple.Chart
            cha.caption = "รายงานคำขอรายกลุ่มงานทั้งหมด"
            cha.yaxisname = ""
            cha.canvasbgcolor = "FEFEFE"
            cha.canvasbasecolor = "FEFEFE"
            cha.tooltipbgcolor = "DEDEBE"
            cha.tooltipborder = "889E6D"
            cha.divlinecolor = "999999"
            cha.showcolumnshadow = "0"
            cha.divlineisdashed = "1"
            cha.divlinedashlen = "1"
            cha.divlinedashgap = "2"
            cha.numberprefix = ""
            cha.numbersuffix = ""
            cha.showborder = "0"
            cha.formatnumberscale = "0"
            rootobject.chart = cha

            Dim category As New Category
            For Each dr As DataRow In dt.Rows
                Dim cat As New Category1
                cat.label = dr("wrkuntnm")
                category.category.Add(cat)
            Next

            rootobject.categories.Add(category)

            Dim datase As New Dataset
            datase.seriesname = "จำนวนคำขอเหลือวันมากกว่า " & dt2(0)("max_gap") & "วันขึ้นไป"
            datase.color = "189100"

            Dim datase2 As New Dataset
            datase2.seriesname = "จำนวนคำขอเหลือวันตั้งแต่ " & dt2(1)("gap") & "-" & dt2(1)("max_gap") & "วัน"
            datase2.color = "2ccf0c"

            Dim datase3 As New Dataset
            datase3.seriesname = "จำนวนคำขอเหลือวันตั้งแต่ 1-60 วัน"
            datase3.color = "a2ff00"

            Dim datase4 As New Dataset
            datase4.seriesname = "จำนวนคำขอรออนุมัติ " & dt2(2)("gap") & "-" & dt2(2)("max_gap") & " วัน"
            datase4.color = "f2fa0d"

            Dim datase5 As New Dataset
            datase5.seriesname = "จำนวนคำขอรออนุมัติ " & dt2(2)("gap") & "-" & dt2(2)("max_gap") & " วัน"
            datase5.color = "ffbc2d"

            Dim datase6 As New Dataset
            datase6.seriesname = "จำนวนคำขอรออนุมัติมากกว่า " & dt2(0)("max_gap") & "วันขึ้นไป"
            datase6.color = "ff2d2d"

            For Each dr As DataRow In dt.Rows
                Dim datum As New Datum
                datum.value = dr("less120")
                datum.link = "../E_TRACKING/FRM_E_TRACKING_SUB_WORK_GRAPH.aspx?gid=" & dr("wrkuntcd") & "&t=1&g=" & Request.QueryString("g")
                datase.data.Add(datum)

                Dim datum2 As New Datum
                datum2.value = dr("less60_to_120")
                datum2.link = "../E_TRACKING/FRM_E_TRACKING_SUB_WORK_GRAPH.aspx?gid=" & dr("wrkuntcd") & "&t=2&g=" & Request.QueryString("g")
                datase2.data.Add(datum2)

                Dim datum3 As New Datum
                datum3.value = dr("less0_to_60")
                datum3.link = "../E_TRACKING/FRM_E_TRACKING_SUB_WORK_GRAPH.aspx?gid=" & dr("wrkuntcd") & "&t=3&g=" & Request.QueryString("g")
                datase3.data.Add(datum3)

                Dim datum4 As New Datum
                datum4.value = dr("more0_to_60")
                datum4.link = "../E_TRACKING/FRM_E_TRACKING_SUB_WORK_GRAPH.aspx?gid=" & dr("wrkuntcd") & "&t=4&g=" & Request.QueryString("g")
                datase4.data.Add(datum4)

                Dim datum5 As New Datum
                datum5.value = dr("more60_to_120")
                datum5.link = "../E_TRACKING/FRM_E_TRACKING_SUB_WORK_GRAPH.aspx?gid=" & dr("wrkuntcd") & "&t=5&g=" & Request.QueryString("g")
                datase5.data.Add(datum5)

                Dim datum6 As New Datum
                datum6.value = dr("more120")
                datum6.link = "../E_TRACKING/FRM_E_TRACKING_SUB_WORK_GRAPH.aspx?gid=" & dr("wrkuntcd") & "&t=6&g=" & Request.QueryString("g")
                datase6.data.Add(datum6)
            Next

            rootobject.dataset.Add(datase)
            rootobject.dataset.Add(datase2)
            rootobject.dataset.Add(datase3)
            rootobject.dataset.Add(datase4)
            rootobject.dataset.Add(datase5)
            rootobject.dataset.Add(datase6)

            Dim serializer As New JavaScriptSerializer()
            Dim serializedResult = serializer.Serialize(rootobject)

            HiddenField1.Value = serializedResult
        Else
            HiddenField1.Value = ""
        End If
    End Sub
    Public Sub bind_graph_new()
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        dt = bao.SP_E_TRACKING_WORK_GROUP()


        Dim bao_list As New BAO.ClsDBSqlcommand
        Dim dt_list As New DataTable
        dt_list = bao_list.SP_E_TRACKING_WORK_LIST_ALL()
        dt_list.Columns.Add("date_last", GetType(Date))
        dt_list.Columns.Add("day_cal", GetType(Integer))



        For Each dr As DataRow In dt_list.Rows
            Dim ws As New WS_GETDATE_WORKING.BasicHttpBinding_IService1
            Dim date_result As Date
            Dim work_day As Integer = 0
            Try
                work_day = dr("WORK_DAYS")
            Catch ex As Exception

            End Try
            ws.GETDATE_WORKING(CDate(dr("rcvdate")), True, dr("WORK_DAYS"), True, date_result, True)
            'date_result = date_result.ToLongDateString()
            dr("date_last") = date_result
            Dim days As Double = 0

            Try
                days = DateDiff(DateInterval.Day, date_result, CDate(dr("appdate")))
            Catch ex As Exception
                days = DateDiff(DateInterval.Day, date_result, Date.Now)
            End Try

            dr("day_cal") = days
        Next
        
        Dim bao2 As New BAO.ClsDBSqlcommand
        Dim dt2 As New DataTable
        Dim dao As New DAO_DRUG.TB_MAS_E_TRACKING_GAP
        dao.GetDataAll()
        Try
            dt2 = bao2.TBL_E_TRACKING_GAP(dao.fields.GAP_SET)
        Catch ex As Exception
            dt2 = bao2.TBL_E_TRACKING_GAP(120)
        End Try

        For Each dr As DataRow In dt.Rows


            'dt_list.Select("day_cal > '" & dt(0)("max_gap") & "'")
            dr("less120") = dt_list.Compute("count(IDA)", "day_cal > '" & dt2(0)("max_gap") & "' and wrkuntcd='" & dr("wrkuntcd") & "'")
            dr("less60_to_120") = dt_list.Compute("count(IDA)", "day_cal > '" & dt2(1)("gap") & "' and day_cal <= '" & dt2(1)("max_gap") & "' and wrkuntcd='" & dr("wrkuntcd") & "'")
            dr("less0_to_60") = dt_list.Compute("count(IDA)", "day_cal >= '" & dt2(2)("gap") & "' and day_cal < '" & dt2(2)("max_gap") & "' and wrkuntcd='" & dr("wrkuntcd") & "'")
            dr("more0_to_60") = dt_list.Compute("count(IDA)", "day_cal >= '" & dt2(3)("max_gap") & "' and day_cal < '" & dt2(3)("gap") & "' and wrkuntcd='" & dr("wrkuntcd") & "'")
            dr("more60_to_120") = dt_list.Compute("count(IDA)", "day_cal < '" & dt2(4)("gap") & "' and day_cal >= '" & dt2(4)("max_gap") & "' and wrkuntcd='" & dr("wrkuntcd") & "'")
            dr("more120") = dt_list.Compute("count(IDA)", "day_cal < '" & dt2(5)("max_gap") & "' and wrkuntcd='" & dr("wrkuntcd") & "'")


        Next

        If dt.Rows.Count > 0 Then
            Dim rootobject As New Graph3DMultiple.Rootobject ' Rootobject

            Dim cha As New Graph3DMultiple.Chart
            cha.caption = "รายงานคำขอรายกลุ่มงานทั้งหมด"
            cha.yaxisname = ""
            cha.canvasbgcolor = "FEFEFE"
            cha.canvasbasecolor = "FEFEFE"
            cha.tooltipbgcolor = "DEDEBE"
            cha.tooltipborder = "889E6D"
            cha.divlinecolor = "999999"
            cha.showcolumnshadow = "0"
            cha.divlineisdashed = "1"
            cha.divlinedashlen = "1"
            cha.divlinedashgap = "2"
            cha.numberprefix = ""
            cha.numbersuffix = ""
            cha.showborder = "0"
            cha.formatnumberscale = "0"
            rootobject.chart = cha

            Dim category As New Category
            For Each dr As DataRow In dt.Rows
                Dim cat As New Category1
                cat.label = dr("wrkuntnm")
                category.category.Add(cat)
            Next

            rootobject.categories.Add(category)

            Dim datase As New Dataset
            datase.seriesname = "จำนวนคำขอเหลือวันมากกว่า " & dt2(0)("max_gap") & "วันขึ้นไป"
            datase.color = "189100"

            Dim datase2 As New Dataset
            datase2.seriesname = "จำนวนคำขอเหลือวันตั้งแต่ " & dt2(1)("gap") & "-" & dt2(1)("max_gap") & "วัน"
            datase2.color = "2ccf0c"

            Dim datase3 As New Dataset
            datase3.seriesname = "จำนวนคำขอเหลือวันตั้งแต่ 1-60 วัน"
            datase3.color = "a2ff00"

            Dim datase4 As New Dataset
            datase4.seriesname = "จำนวนคำขอรออนุมัติ " & dt2(2)("gap") & "-" & dt2(2)("max_gap") & " วัน"
            datase4.color = "f2fa0d"

            Dim datase5 As New Dataset
            datase5.seriesname = "จำนวนคำขอรออนุมัติ " & dt2(2)("gap") & "-" & dt2(2)("max_gap") & " วัน"
            datase5.color = "ffbc2d"

            Dim datase6 As New Dataset
            datase6.seriesname = "จำนวนคำขอรออนุมัติมากกว่า " & dt2(0)("max_gap") & "วันขึ้นไป"
            datase6.color = "ff2d2d"

            For Each dr As DataRow In dt.Rows
                Dim datum As New Datum
                datum.value = dr("less120")
                datum.link = "../E_TRACKING/FRM_E_TRACKING_SUB_WORK_GRAPH.aspx?gid=" & dr("wrkuntcd") & "&t=1"
                datase.data.Add(datum)

                Dim datum2 As New Datum
                datum2.value = dr("less60_to_120")
                datum2.link = "../E_TRACKING/FRM_E_TRACKING_SUB_WORK_GRAPH.aspx?gid=" & dr("wrkuntcd") & "&t=2"
                datase2.data.Add(datum2)

                Dim datum3 As New Datum
                datum3.value = dr("less0_to_60")
                datum3.link = "../E_TRACKING/FRM_E_TRACKING_SUB_WORK_GRAPH.aspx?gid=" & dr("wrkuntcd") & "&t=3"
                datase3.data.Add(datum3)

                Dim datum4 As New Datum
                datum4.value = dr("more0_to_60")
                datum4.link = "../E_TRACKING/FRM_E_TRACKING_SUB_WORK_GRAPH.aspx?gid=" & dr("wrkuntcd") & "&t=4"
                datase4.data.Add(datum4)

                Dim datum5 As New Datum
                datum5.value = dr("more60_to_120")
                datum5.link = "../E_TRACKING/FRM_E_TRACKING_SUB_WORK_GRAPH.aspx?gid=" & dr("wrkuntcd") & "&t=5"
                datase5.data.Add(datum5)

                Dim datum6 As New Datum
                datum6.value = dr("more120")
                datum6.link = "../E_TRACKING/FRM_E_TRACKING_SUB_WORK_GRAPH.aspx?gid=" & dr("wrkuntcd") & "&t=6"
                datase6.data.Add(datum6)
            Next

            rootobject.dataset.Add(datase)
            rootobject.dataset.Add(datase2)
            rootobject.dataset.Add(datase3)
            rootobject.dataset.Add(datase4)
            rootobject.dataset.Add(datase5)
            rootobject.dataset.Add(datase6)

            Dim serializer As New JavaScriptSerializer()
            Dim serializedResult = serializer.Serialize(rootobject)

            HiddenField1.Value = serializedResult
        Else
            HiddenField1.Value = ""
        End If
    End Sub
    Sub bind_grid()

        'Dim bao As New BAO.ClsDBSqlcommand
        'dt = bao.SP_E_TRACKING_WORK_GROUP_ALL
        ''If dt.Rows.Count = 0 Then
        ''    HiddenField1.Value = ""
        ''    Response.Write("<script type='text/javascript'>alert('ไม่พบข้อมูล');</script> ")
        ''Else
        'RadGrid1.DataSource = dt
        'RadGrid1.Rebind()

        bind_graph()

    End Sub
    Sub bind_graph()
        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_E_TRACKING_WORK_GROUP_ALL
        If dt.Rows.Count > 0 Then
            Dim rootobject As New Graph3DMultiple.Rootobject ' Rootobject

            Dim cha As New Graph3DMultiple.Chart
            cha.caption = "รายงานคำขอรายกลุ่มงานทั้งหมด"
            cha.yaxisname = ""
            cha.canvasbgcolor = "FEFEFE"
            cha.canvasbasecolor = "FEFEFE"
            cha.tooltipbgcolor = "DEDEBE"
            cha.tooltipborder = "889E6D"
            cha.divlinecolor = "999999"
            cha.showcolumnshadow = "0"
            cha.divlineisdashed = "1"
            cha.divlinedashlen = "1"
            cha.divlinedashgap = "2"
            cha.numberprefix = ""
            cha.numbersuffix = ""
            cha.showborder = "0"
            cha.formatnumberscale = "0"
            rootobject.chart = cha

            Dim category As New Category
            For Each dr As DataRow In dt.Rows
                Dim cat As New Category1
                cat.label = dr("wrkuntnm")
                category.category.Add(cat)
            Next

            rootobject.categories.Add(category)

            Dim datase As New Dataset
            datase.seriesname = "จำนวนคำขอเหลือวันมากกว่า 120 วันขึ้นไป"
            datase.color = "189100"

            Dim datase2 As New Dataset
            datase2.seriesname = "จำนวนคำขอเหลือวันตั้งแต่ 60-120 วัน"
            datase2.color = "2ccf0c"

            Dim datase3 As New Dataset
            datase3.seriesname = "จำนวนคำขอเหลือวันตั้งแต่ 1-60 วัน"
            datase3.color = "a2ff00"

            Dim datase4 As New Dataset
            datase4.seriesname = "จำนวนคำขอรออนุมัติ 1-60 วัน"
            datase4.color = "f2fa0d"

            Dim datase5 As New Dataset
            datase5.seriesname = "จำนวนคำขอรออนุมัติ 60-120 วัน"
            datase5.color = "ffbc2d"

            Dim datase6 As New Dataset
            datase6.seriesname = "จำนวนคำขอรออนุมัติมากกว่า 120 วัน"
            datase6.color = "ff2d2d"

            For Each dr As DataRow In dt.Rows
                Dim datum As New Datum
                datum.value = dr("less120")
                datum.link = "../E_TRACKING/FRM_E_TRACKING_SUB_WORK_GRAPH.aspx?gid=" & dr("wrkuntcd") & "&t=1"
                datase.data.Add(datum)

                Dim datum2 As New Datum
                datum2.value = dr("less60_to_120")
                datum2.link = "../E_TRACKING/FRM_E_TRACKING_SUB_WORK_GRAPH.aspx?gid=" & dr("wrkuntcd") & "&t=2"
                datase2.data.Add(datum2)

                Dim datum3 As New Datum
                datum3.value = dr("less0_to_60")
                datum3.link = "../E_TRACKING/FRM_E_TRACKING_SUB_WORK_GRAPH.aspx?gid=" & dr("wrkuntcd") & "&t=3"
                datase3.data.Add(datum3)

                Dim datum4 As New Datum
                datum4.value = dr("more0_to_60")
                datum4.link = "../E_TRACKING/FRM_E_TRACKING_SUB_WORK_GRAPH.aspx?gid=" & dr("wrkuntcd") & "&t=4"
                datase4.data.Add(datum4)

                Dim datum5 As New Datum
                datum5.value = dr("more60_to_120")
                datum5.link = "../E_TRACKING/FRM_E_TRACKING_SUB_WORK_GRAPH.aspx?gid=" & dr("wrkuntcd") & "&t=5"
                datase5.data.Add(datum5)

                Dim datum6 As New Datum
                datum6.value = dr("more120")
                datum6.link = "../E_TRACKING/FRM_E_TRACKING_SUB_WORK_GRAPH.aspx?gid=" & dr("wrkuntcd") & "&t=6"
                datase6.data.Add(datum6)
            Next

            rootobject.dataset.Add(datase)
            rootobject.dataset.Add(datase2)
            rootobject.dataset.Add(datase3)
            rootobject.dataset.Add(datase4)
            rootobject.dataset.Add(datase5)
            rootobject.dataset.Add(datase6)

            Dim serializer As New JavaScriptSerializer()
            Dim serializedResult = serializer.Serialize(rootobject)

            HiddenField1.Value = serializedResult
        Else
            HiddenField1.Value = ""
        End If

    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim dt_list As New DataTable
        Dim bao_list As New BAO.ClsDBSqlcommand
        dt_list = bao_list.SP_E_TRACKING_WORK_LIST_ALL_BY_GROUP(Request.QueryString("g"))

        RadGrid1.DataSource = dt_list
    End Sub
End Class