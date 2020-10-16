Public Class UC_HERB
    Inherits System.Web.UI.UserControl
    Private _CLS As New CLS_SESSION

    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
    End Sub
    Sub Set_Label(ByVal _IDA As Integer)
        Dim bao_show As New BAO_SHOW
        Dim dt_lcn As New DataTable
        dt_lcn = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(_CLS.CITIZEN_ID_AUTHORIZE, 0) ' bao_show.SP_LOCATION_BSN_BY_LCN_IDA(_IDA) 'ผู้ดำเนิน
        '
        For Each dr As DataRow In dt_lcn.Rows
            Try
                lbl_lcn_addr.Text = dr("")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_ages.Text = dr("")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_amphor.Text = dr("")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_building.Text = dr("")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_changwat.Text = dr("")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_email.Text = dr("")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_fax.Text = dr("")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_iden.Text = dr("identify")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_iden2.Text = dr("")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_mu.Text = dr("")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_name.Text = dr("thanm")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_nation.Text = dr("")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_road.Text = dr("")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_soi.Text = dr("")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_tambol.Text = dr("")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_tel.Text = dr("")
            Catch ex As Exception

            End Try
            Try
                lbl_lcn_zipcode.Text = dr("")
            Catch ex As Exception

            End Try
        Next


    End Sub
End Class