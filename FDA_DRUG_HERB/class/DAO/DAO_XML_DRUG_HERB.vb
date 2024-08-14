Namespace DAO_XML_DRUG_HERB
    Public MustInherit Class MAINCONTEXT2      'ประกาศเพื่อใช้เป็น Class แม่
        Public db As New LINQ_FDA_XML_DRUG_HERBDataContext   'ประกาศเพื่อใช้เป็น Class LINQ DataTable


        Public datas                            'ประกาศเ

    End Class
    Public Class TB_XML_SEARCH_DRUG_LCN_HERB
        Inherits MAINCONTEXT2 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New XML_SEARCH_DRUG_LCN_HERB

        Public Sub insert()
            db.XML_SEARCH_DRUG_LCN_HERBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_SEARCH_DRUG_LCN_HERBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataby_LCN_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_SEARCH_DRUG_LCN_HERBs Where p.IDA_dalcn = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_SEARCH_DRUG_LCN_HERBs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        '
        Public Sub GetDataby_identify(ByVal iden As String)

            datas = (From p In db.XML_SEARCH_DRUG_LCN_HERBs Where p.CITIZEN_AUTHORIZE = iden Select p)
            For Each Me.fields In datas
            Next
        End Sub
        '
        Public Sub GetDataby_lcnsid(ByVal lcnsid As String)

            datas = (From p In db.XML_SEARCH_DRUG_LCN_HERBs Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataALL()

            datas = (From p In db.XML_SEARCH_DRUG_LCN_HERBs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_u1(ByVal u1 As String)

            datas = (From p In db.XML_SEARCH_DRUG_LCN_HERBs Where p.Newcode_not = u1 Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_pvnlcncd(ByVal pvncd As Integer, ByVal lcntpcd As String, ByVal lcnno As Integer)
            datas = (From p In db.XML_SEARCH_DRUG_LCN_HERBs Where p.pvncd = pvncd And p.lcntpcd = lcntpcd And p.lcnno = lcnno Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_lcnno_no(ByVal lcnno_no As String)

            datas = (From p In db.XML_SEARCH_DRUG_LCN_HERBs Where p.lcnno_no = lcnno_no Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnno_no_New(ByVal lcnno_no As String)

            datas = (From p In db.XML_SEARCH_DRUG_LCN_HERBs Where p.lcnno_display_new = lcnno_no Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_PRODUCT_HERB
        Inherits MAINCONTEXT2 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New XML_DRUG_PRODUCT_HERB

        Public Sub insert()
            db.XML_DRUG_PRODUCT_HERBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_DRUG_PRODUCT_HERBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_DRUG_PRODUCT_HERBs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        '
        Public Sub GetDataby_identify(ByVal iden As String)

            datas = (From p In db.XML_DRUG_PRODUCT_HERBs Where p.CITIZEN_AUTHORIZE = iden Select p)
            For Each Me.fields In datas
            Next
        End Sub
        '
        Public Sub GetDataby_IDA_drrgt(ByVal IDA As Integer)

            datas = (From p In db.XML_DRUG_PRODUCT_HERBs Where p.IDA_drrgt = IDA And p.frn_no = "1" Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_NEWCODE(ByVal u1 As String)

            datas = (From p In db.XML_DRUG_PRODUCT_HERBs Where p.Newcode_U = u1 And p.frn_no = "1" Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetData_by_NEWCODE(ByVal NewCode As String)
            datas = (From p In db.XML_DRUG_PRODUCT_HERBs Where p.Newcode = NewCode Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_4Key(ByVal rgtno As String, ByVal rgttpcd As String, ByVal drgtpcd As String, ByVal pvncd As String)

            datas = (From p In db.XML_DRUG_PRODUCT_HERBs Where p.rgtno = rgtno And p.rgttpcd = rgttpcd And p.pvncd = pvncd And p.drgtpcd = drgtpcd And p.frn_no = "1" Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataALL()

            datas = (From p In db.XML_DRUG_PRODUCT_HERBs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_u1(ByVal u1 As String)

            datas = (From p In db.XML_DRUG_PRODUCT_HERBs Where p.Newcode_U = u1 Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_u1_frn_no(ByVal u1 As String)

            datas = (From p In db.XML_DRUG_PRODUCT_HERBs Where p.Newcode_U = u1 And p.frn_no = "1" Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_FRGN_HERB
        Inherits MAINCONTEXT2 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New XML_DRUG_FRGN_HERB

        Public Sub insert()
            db.XML_DRUG_FRGN_HERBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_DRUG_FRGN_HERBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_DRUG_FRGN_HERBs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        '
        Public Sub GetDataALL()

            datas = (From p In db.XML_DRUG_FRGN_HERBs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_u1(ByVal u1 As String)
            datas = (From p In db.XML_DRUG_FRGN_HERBs Where p.Newcode_U = u1 Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_u1_and_funcd(ByVal u1 As String, ByVal funccd As String)
            datas = (From p In db.XML_DRUG_FRGN_HERBs Where p.Newcode_U = u1 And p.funccd = funccd Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_IOW_HERB
        Inherits MAINCONTEXT2 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New XML_DRUG_IOW_HERB
        Private _Details As New List(Of XML_DRUG_IOW_HERB)
        Public Property Details() As List(Of XML_DRUG_IOW_HERB)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_IOW_HERB))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_IOW_HERB
        End Sub
        Public Sub insert()
            db.XML_DRUG_IOW_HERBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_DRUG_IOW_HERBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.XML_DRUG_IOW_HERBs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_DRUG_IOW_HERBs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        'Public Sub GetDataby_IDA_ORDER(ByVal IDA As Integer, ByVal FK_SET As Integer)

        '    datas = (From p In db.XML_DRUG_IOWs Where p.IDA = IDA And p.FK_SET = FK_SET Select p Order By p.ROWS Ascending)
        '    For Each Me.fields In datas

        '    Next
        'End Sub
        'Public Sub GetDataby_FK_IDA_ORDER(ByVal FK_IDA As Integer, ByVal FK_SET As Integer)

        '    datas = (From p In db.XML_DRUG_IOWs Where p.FK_IDA = FK_IDA And p.FK_SET = FK_SET Select p Order By CInt(p.ROWS) Ascending)
        '    For Each Me.fields In datas

        '    Next
        'End Sub
        'Public Sub GetDataby_ROWs_AND_FK_SET(ByVal ROWs As Integer, ByVal FK_SET As Integer)

        '    datas = (From p In db.XML_DRUG_IOWs Where p.FK_SET = FK_SET And p.ROWS = ROWs Select p)
        '    For Each Me.fields In datas

        '    Next
        'End Sub
        'Public Sub GetDataby_IDA_AND_ROWs(ByVal IDA As Integer, ByVal ROWs As Integer)

        '    datas = (From p In db.XML_DRUG_IOWs Where p.IDA = IDA And p.ROWS = ROWs Select p)
        '    For Each Me.fields In datas

        '    Next
        'End Sub
        Public Sub GetDataby_Newcode_U(ByVal Newcode_U As String)
            datas = (From p In db.XML_DRUG_IOW_HERBs Where p.Newcode_U = Newcode_U Select p)
            For Each Me.fields In datas

            Next
        End Sub

        'Public Function COUNTDataby_FKIDA(ByVal IDA As Integer) As Integer
        '    Dim i As Integer = 0
        '    datas = (From p In db.XML_DRUG_IOWs Where p.FK_IDA = IDA Select p)
        '    For Each Me.fields In datas

        '    Next
        '    Return i
        'End Function
        'Public Sub GET_MAX_ROWS_ID(ByVal FK_IDA As Integer)
        '    datas = (From p In db.XML_DRUG_IOWs Where p.FK_IDA = FK_IDA Order By CInt(p.ROWS) Descending Select p).Take(1)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        'Public Sub GET_MAX_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
        '    datas = (From p In db.XML_DRUG_IOWs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Descending Select p).Take(1)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        'Public Sub GET_MIN_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
        '    datas = (From p In db.XML_DRUG_IOWs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Ascending Select p).Take(1)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
    End Class
    Public Class TB_XML_SEARCH_DRUG_LCN_LICEN_HERB
        Inherits MAINCONTEXT2 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New XML_SEARCH_DRUG_LCN_LICEN_HERB

        Public Sub insert()
            db.XML_SEARCH_DRUG_LCN_LICEN_HERBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_SEARCH_DRUG_LCN_LICEN_HERBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_SEARCH_DRUG_LCN_LICEN_HERBs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_LCN_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_SEARCH_DRUG_LCN_LICEN_HERBs Where p.IDA_dalcn = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        '
        Public Sub GetDataby_identify(ByVal iden As String)

            datas = (From p In db.XML_SEARCH_DRUG_LCN_LICEN_HERBs Where p.CITIZEN_AUTHORIZE = iden Select p)
            For Each Me.fields In datas
            Next
        End Sub
        '
        Public Sub GetDataby_lcnsid(ByVal lcnsid As String)

            datas = (From p In db.XML_SEARCH_DRUG_LCN_LICEN_HERBs Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataALL()

            datas = (From p In db.XML_SEARCH_DRUG_LCN_LICEN_HERBs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_u1(ByVal u1 As String)

            datas = (From p In db.XML_SEARCH_DRUG_LCN_LICEN_HERBs Where p.Newcode_not = u1 Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnno_no(ByVal lcnno_no As String)

            datas = (From p In db.XML_SEARCH_DRUG_LCN_LICEN_HERBs Where p.lcnno_no = lcnno_no Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_lcnno_no_New(ByVal lcnno_no As String)

            datas = (From p In db.XML_SEARCH_DRUG_LCN_LICEN_HERBs Where p.lcnno_display_new = lcnno_no Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_pvnlcncd(ByVal pvncd As Integer, ByVal lcntpcd As String, ByVal lcnno As String)
            datas = (From p In db.XML_SEARCH_DRUG_LCN_LICEN_HERBs Where p.pvncd = pvncd And p.lcntpcd = lcntpcd And p.lcnno = lcnno Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_IOW_EQ_HERB
        Inherits MAINCONTEXT2 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New XML_DRUG_IOW_EQ_HERB
        Private _Details As New List(Of XML_DRUG_IOW_EQ_HERB)
        Public Property Details() As List(Of XML_DRUG_IOW_EQ_HERB)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_IOW_EQ_HERB))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_IOW_EQ_HERB
        End Sub
        Public Sub insert()
            db.XML_DRUG_IOW_EQ_HERBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_DRUG_IOW_EQ_HERBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.XML_DRUG_IOW_EQ_HERBs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_DRUG_IOW_EQ_HERBs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Newcode_rid_flineno(ByVal newcode_rid As String, ByVal flineno As String)

            datas = (From p In db.XML_DRUG_IOW_EQ_HERBs Where p.Newcode_rid = newcode_rid Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal newcode As String)

            datas = (From p In db.XML_DRUG_IOW_EQ_HERBs Where p.Newcode = newcode Select p)
            For Each Me.fields In datas

            Next
        End Sub
        'Public Sub GetDataby_FK_IDA(ByVal IDA As Integer)

        '    datas = (From p In db.XML_DRUG_IOW_EQs Where p.FK_IDA = IDA Select p)
        '    For Each Me.fields In datas

        '    Next
        'End Sub
        'Public Sub GetDataby_FK_DRRQT_IDA(ByVal IDA As Integer)

        '    datas = (From p In db.XML_DRUG_IOW_EQs Where p.FK_DRRQT_IDA = IDA Select p)
        '    For Each Me.fields In datas

        '    Next
        'End Sub
        'Public Sub GET_MAX_ROWS_ID(ByVal FK_IDA As Integer)
        '    datas = (From p In db.XML_DRUG_IOW_EQs Where p.FK_IDA = FK_IDA Order By CInt(p.ROWS) Descending Select p).Take(1)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        'Public Sub GET_MAX_ROWS_ID_SET(ByVal FK_IDA As Integer, ByVal _set As Integer)
        '    datas = (From p In db.XML_DRUG_IOW_EQs Where p.FK_IDA = FK_IDA And p.FK_SET = _set Order By CInt(p.ROWS) Descending Select p).Take(1)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
    End Class
    '
    Public Class TB_XML_DRUG_RECIPE_GROUP_HERB
        Inherits MAINCONTEXT2 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New XML_DRUG_RECIPE_GROUP_HERB
        Private _Details As New List(Of XML_DRUG_RECIPE_GROUP_HERB)
        Public Property Details() As List(Of XML_DRUG_RECIPE_GROUP_HERB)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_RECIPE_GROUP_HERB))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_RECIPE_GROUP_HERB
        End Sub
        Public Sub insert()
            db.XML_DRUG_RECIPE_GROUP_HERBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_DRUG_RECIPE_GROUP_HERBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.XML_DRUG_RECIPE_GROUP_HERBs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_DRUG_RECIPE_GROUP_HERBs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal newcode As String)

            datas = (From p In db.XML_DRUG_RECIPE_GROUP_HERBs Where p.Newcode = newcode Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_COLOR_HERB
        Inherits MAINCONTEXT2 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New XML_DRUG_COLOR_HERB
        Private _Details As New List(Of XML_DRUG_COLOR_HERB)
        Public Property Details() As List(Of XML_DRUG_COLOR_HERB)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_COLOR_HERB))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_COLOR_HERB
        End Sub
        Public Sub insert()
            db.XML_DRUG_COLOR_HERBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_DRUG_COLOR_HERBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.XML_DRUG_COLOR_HERBs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_DRUG_COLOR_HERBs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal newcode As String)

            datas = (From p In db.XML_DRUG_COLOR_HERBs Where p.Newcode = newcode Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_STOWAGR_HERB
        Inherits MAINCONTEXT2 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New XML_DRUG_STOWAGR_HERB
        Private _Details As New List(Of XML_DRUG_STOWAGR_HERB)
        Public Property Details() As List(Of XML_DRUG_STOWAGR_HERB)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_STOWAGR_HERB))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_STOWAGR_HERB
        End Sub
        Public Sub insert()
            db.XML_DRUG_STOWAGR_HERBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_DRUG_STOWAGR_HERBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.XML_DRUG_STOWAGR_HERBs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_DRUG_STOWAGR_HERBs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal newcode As String)

            datas = (From p In db.XML_DRUG_STOWAGR_HERBs Where p.Newcode = newcode Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_CONTAIN_HERB
        Inherits MAINCONTEXT2 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New XML_DRUG_CONTAIN_HERB
        Private _Details As New List(Of XML_DRUG_CONTAIN_HERB)
        Public Property Details() As List(Of XML_DRUG_CONTAIN_HERB)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_CONTAIN_HERB))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_CONTAIN_HERB
        End Sub
        Public Sub insert()
            db.XML_DRUG_CONTAIN_HERBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_DRUG_CONTAIN_HERBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.XML_DRUG_CONTAIN_HERBs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_DRUG_CONTAIN_HERBs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal newcode As String)

            datas = (From p In db.XML_DRUG_CONTAIN_HERBs Where p.Newcode = newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_ANIMAL_HERB
        Inherits MAINCONTEXT2 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New XML_DRUG_ANIMAL_HERB
        Private _Details As New List(Of XML_DRUG_ANIMAL_HERB)
        Public Property Details() As List(Of XML_DRUG_ANIMAL_HERB)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_ANIMAL_HERB))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_ANIMAL_HERB
        End Sub
        Public Sub insert()
            db.XML_DRUG_ANIMAL_HERBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_DRUG_ANIMAL_HERBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.XML_DRUG_ANIMAL_HERBs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_DRUG_ANIMAL_HERBs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal newcode As String)

            datas = (From p In db.XML_DRUG_ANIMAL_HERBs Where p.Newcode = newcode Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_ANIMAL_CONSUME_HERB
        Inherits MAINCONTEXT2 'เรียก Class แม่มาใช้เพื่อให้รู้จักว่าเป็น Table ไหน

        Public fields As New XML_DRUG_ANIMAL_CONSUME_HERB
        Private _Details As New List(Of XML_DRUG_ANIMAL_CONSUME_HERB)
        Public Property Details() As List(Of XML_DRUG_ANIMAL_CONSUME_HERB)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_ANIMAL_CONSUME_HERB))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_ANIMAL_CONSUME_HERB
        End Sub
        Public Sub insert()
            db.XML_DRUG_ANIMAL_CONSUME_HERBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_DRUG_ANIMAL_CONSUME_HERBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()

            datas = (From p In db.XML_DRUG_ANIMAL_CONSUME_HERBs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_IDA(ByVal IDA As Integer)

            datas = (From p In db.XML_DRUG_ANIMAL_CONSUME_HERBs Where p.IDA = IDA Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal newcode As String)

            datas = (From p In db.XML_DRUG_ANIMAL_CONSUME_HERBs Where p.Newcode = newcode Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
End Namespace
