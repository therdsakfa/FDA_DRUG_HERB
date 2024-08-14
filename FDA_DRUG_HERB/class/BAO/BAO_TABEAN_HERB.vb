Imports System.Data
Imports System.Data.SqlClient
Imports System.Web

Namespace BAO_TABEAN_HERB
    Public Class connection_db
        Public Function Queryds(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("LGT_DRUGConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
    End Class

    Public Class tb_dd
        Inherits connection_db

        Public Function SP_DD_MAS_TABEAN_HERB_NAME_JJ(ByVal P_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_MAS_TABEAN_HERB_NAME_JJ @PROCESS_ID=" & P_ID
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_DD_MAS_TABEAN_HERB_HEALTH_NAME_JJ() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_MAS_TABEAN_HERB_HEALTH_NAME_JJ"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_MAS_DD_HERB_JR() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_DD_HERB_JR "
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_MAS_DDL_SECTION_CANCEL() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_DDL_SECTION_CANCEL"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_MAS_STATUS_CANCEL_TABEAN_HERB(ByVal IDgroup As String) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_STATUS_CANCEL_TABEAN_HERB @IDgroup=" & IDgroup
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_INSERT_DRUG_PAYMENT_CENTER_L44(ByVal identify As String, ByVal IDA As Integer, ByVal Process_ID As String) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_INSERT_DRUG_PAYMENT_CENTER_L44 @identify='" & identify & "',@IDA=" & IDA & ",@process_id='" & Process_ID & "'"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_MAS_STATUS_CANCEL_LCN_HERB(ByVal IDgroup As String) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_STATUS_CANCEL_LCN_HERB @IDgroup=" & IDgroup
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_MAS_DDL_STAFF_REMARK_CANCEL() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_DDL_STAFF_REMARK_CANCEL"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_DD_STATUS_JJ_EDIT(ByVal s_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_STATUS_JJ_EDIT @s_id=" & s_id
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_MAS_DDL_TABEAN_JJ_EDIT_REQUEST() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_DDL_TABEAN_JJ_EDIT_REQUEST"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_MAS_PRICE_TABEAN_EDIT_TEMPOLARY() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_PRICE_TABEAN_EDIT_TEMPOLARY"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_MAS_STAFF_NAME_HERB() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_STAFF_NAME_HERB"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_MAS_TABEAN_HERB_SALE() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_TABEAN_HERB_SALE"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_DD_STATUS_TABEAN_EX(ByVal s_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_STATUS_TABEAN_EX @s_id=" & s_id
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_MAS_TABEAN_HERB_ML() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_TABEAN_HERB_ML"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_DD_MAS_TABEAN_HERB_TYPE_PRODUCK() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_MAS_TABEAN_HERB_TYPE_PRODUCK"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_MAS_PRICE_DISCOUNT_DALCN_HERB() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_PRICE_DISCOUNT_DALCN_HERB "
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_MAS_STAFF_POSITION_NAME() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_STAFF_POSITION_NAME"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_MAS_OTHER_REQUEST_NAME() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_OTHER_REQUEST_NAME"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_MAS_DD_HERB(ByVal P_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_DD_HERB @r_id=" & P_ID
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_MAS_PRICE_DISCOUNT_TABEAN_HERB() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_PRICE_DISCOUNT_TABEAN_HERB "
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_DD_PRICE_ESTIMATE_REQUEST(ByVal P_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_PRICE_ESTIMATE_REQUEST @PROCESS_ID=" & P_ID
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_TR_ID_RESIDUE_DRR() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TR_ID_RESIDUE_DRR"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_MAS_TABEAN_HERB_SYNDROME_JJ() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_TABEAN_HERB_SYNDROME_JJ"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_MAS_TABEAN_HERB_ML_PROCESSID(ByVal P_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_TABEAN_HERB_ML_PROCESSID @PROCESS_ID=" & P_ID
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_DD_STATUS_TABEAN(ByVal s_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_STATUS_TABEAN @s_id=" & s_id
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_DD_DISCOUNT_TABEAN() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_DISCOUNT_TABEAN"
            dt = Queryds(qstr)

            Return dt
        End Function

        'Public Function SP_DD_STATUS_JJ() As DataTable
        '    Dim dt As New DataTable
        '    Dim qstr As String = ""

        '    qstr = "exec SP_DD_STATUS_JJ"
        '    dt = Queryds(qstr)

        '    Return dt
        'End Function

        Public Function SP_DD_STATUS_JJ(ByVal s_id As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_STATUS_JJ @s_id=" & s_id
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_DD_MAS_TABEAN_HERB_PRODUCT_AGE_JJ() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_MAS_TABEAN_HERB_PRODUCT_AGE_JJ"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_DD_MAS_TABEAN_HERB_WARNING() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_MAS_TABEAN_HERB_WARNING"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_DD_MAS_TABEAN_HERB_WARNING_SUB(ByVal FK_IDA As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_MAS_TABEAN_HERB_WARNING_SUB @FK_IDA=" & FK_IDA
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_DD_MAS_TABEAN_HERB_SYNDROME_JJ() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_MAS_TABEAN_HERB_SYNDROME_JJ"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_MAS_TABEAN_HERB_SYNDROME_DETAIL_JJ(ByVal DD_HERB_NAME_ID As Integer, ByVal P_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_TABEAN_HERB_SYNDROME_DETAIL_JJ @DD_HERB_NAME_ID=" & DD_HERB_NAME_ID & ",@PROCESS_ID=" & P_ID
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_MAS_TABEAN_HERB_MENUFACTRUE_DETAIL_JJ(ByVal DD_HERB_NAME_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_TABEAN_HERB_MENUFACTRUE_DETAIL_JJ @DD_HERB_NAME_ID=" & DD_HERB_NAME_ID
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_MAS_TABEAN_HERB_HOW_USE_JJ(ByVal DD_HERB_NAME_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_TABEAN_HERB_HOW_USE_JJ @DD_HERB_NAME_ID=" & DD_HERB_NAME_ID
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_DD_MAS_TABEAN_HERB_STYPE_JJ() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_MAS_TABEAN_HERB_STYPE_JJ"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_DD_MAS_TABEAN_HERB_EATTING_JJ() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_MAS_TABEAN_HERB_EATTING_JJ"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_DD_MAS_TABEAN_HERB_EATTING_CONDITION() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_MAS_TABEAN_HERB_EATTING_CONDITION"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_DD_MAS_TABEAN_HERB_PACK_PRIMARY() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_MAS_TABEAN_HERB_PACK_PRIMARY"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_DD_MAS_TABEAN_HERB_PACK_SECONDARY() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_MAS_TABEAN_HERB_PACK_SECONDARY"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_DD_MAS_TABEAN_HERB_PACK_TERTIRY() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_MAS_TABEAN_HERB_PACK_TERTIRY"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_DD_MAS_TABEAN_HERB_UNIT_PRIMARY() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_MAS_TABEAN_HERB_UNIT_PRIMARY"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_DD_MAS_TABEAN_HERB_UNIT_SCONDARY() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_MAS_TABEAN_HERB_UNIT_SCONDARY"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_DD_MAS_TABEAN_HERB_UNIT_TERTIARY() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_MAS_TABEAN_HERB_UNIT_TERTIARY"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_DD_MAS_TABEAN_HERB_MENUFACTRUE() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_MAS_TABEAN_HERB_MENUFACTRUE"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_DD_MAS_TABEAN_HERB_STORAGE_JJ() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DD_MAS_TABEAN_HERB_STORAGE_JJ"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_TABEAN_DRUGGROUP_JJ() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_DRUGGROUP_JJ"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_TABEAN_DRUGGROUPTYPE_JJ() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_DRUGGROUPTYPE_JJ"
            dt = Queryds(qstr)

            Return dt
        End Function

    End Class

    Public Class tb_main
        Inherits connection_db

        Public Function SP_DRRGT_TABEAN_STAFF_NEW() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DRRGT_TABEAN_STAFF_NEW "
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_TABEAN_HERB_GET_MAX_RGTNO_JJ(ByVal rgttpcd As String, ByVal _YEAR As String) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_HERB_GET_MAX_RGTNO_JJ @rgttpcd=" & rgttpcd & ",@year= '" & _YEAR & "'"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_TRANSFER_DRR_TO_TABEAN_HERB_INSERT(ByVal IDA As String) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DRR_TO_TABEAN_HERB_INSERT @IDA=" & IDA
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_TABEAN_LOG_EDIT_DETAIL_BY_IDA_G(ByVal IDA_G As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_LOG_EDIT_DETAIL_BY_IDA_G @IDA=" & IDA_G
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_DRUG_DRRQT_MAIN_STAFF_NEW() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DRUG_DRRQT_MAIN_STAFF_NEW "
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_TABEAN_OFFICER_JJ_EDIT_REQUEST() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_OFFICER_JJ_EDIT_REQUEST"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_TABEAN_HERB_EX_BY_FK_IDA_LCN(ByVal IDA_LCN As String) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_HERB_EX_BY_FK_IDA_LCN @IDA= '" & IDA_LCN & "'"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_TABEAN_HERB_EX_STAFF() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_HERB_EX_STAFF"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_XML_TABEAN_EDIT_REQUEST_BY_IDA(ByVal IDA As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_XML_TABEAN_EDIT_REQUEST_BY_IDA @IDA=" & IDA
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_XML_TABEAN_EDIT_REQUEST_CHK_LIST(ByVal IDA As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_XML_TABEAN_EDIT_REQUEST_CHK_LIST @IDA=" & IDA
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_TABEAN_HERB_UPLOAD_FILE_EX(ByVal TR_ID As Integer, ByVal TYPE_ID As Integer, ByVal P_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_HERB_UPLOAD_FILE_EX @TR_ID=" & TR_ID & ",@TYPE_ID= '" & TYPE_ID & "',@PROCESS_ID= '" & P_ID & "'"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_DALCN_EDIT_UPLOAD_FILE(ByVal TR_ID As Integer, ByVal TYPE_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_DALCN_EDIT_UPLOAD_FILE @TR_ID=" & TR_ID & ",@TYPE_ID=" & TYPE_ID
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_XML_DRUG_DRSMR(ByVal _IDA_EX As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_XML_DRUG_DRSMR @IDA=" & _IDA_EX
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_XML_DRUG_DRSMR_PACKAGE_SIZE_BY_FK(ByVal _IDA_EX As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_XML_DRUG_DRSMR_PACKAGE_SIZE_BY_FK @FK_IDA=" & _IDA_EX
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_TABEAN_INFORM_STAFF() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_INFORM_STAFF"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_XML_DRUG_DRSMR_PACKAGE_SIZE(ByVal _IDA_EX As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_XML_DRUG_DRSMR_PACKAGE_SIZE @FK_IDA=" & _IDA_EX
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_TABEAN_INFORM_BY_FK_IDA_LCN_AND_IDEN(ByVal IDA_LCN As Integer, ByVal IDEN As String) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_INFORM_BY_FK_IDA_LCN_AND_IDEN @FK_LCN=" & IDA_LCN & ",@IDEN='" & IDEN & "'"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_MAS_TABEAN_HERB_UPLOADFILE_BY_TYPE(ByVal TYPE_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_TABEAN_HERB_UPLOADFILE_BY_TYPE @TYPE_ID=" & TYPE_ID
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_XML_TABEAN_JJ_EDIT(ByVal IDEN As String) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_XML_TABEAN_JJ_EDIT @IDENTIFY= '" & IDEN & "'"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_XML_TABEAN_JJ_EDIT_REQUEST(ByVal IDEN As String, ByVal FK_IDA As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_XML_TABEAN_JJ_EDIT_REQUEST @IDENTIFY= '" & IDEN & "'" & ",@FK_IDA=" & FK_IDA
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_TABEAN_EDIT_REQUEST_CUSTOMER(ByVal IDEN As String, ByVal FK_IDA As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_EDIT_REQUEST_CUSTOMER @IDENTIFY= '" & IDEN & "'" & ",@FK_IDA=" & FK_IDA
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_TABEAN_HERB_UPLOAD_FILE_EX_NO() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_HERB_UPLOAD_FILE_EX_NO "
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_TABEAN_HERB_UPLOAD_FILE_JJ_FK_IDA_LCN_V2(ByVal TR_ID_JJ As Integer, ByVal TYPE_ID As Integer, ByVal P_ID As Integer, ByVal LCN_IDA As String) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_HERB_UPLOAD_FILE_JJ_FK_IDA_LCN_V2 @TR_ID_JJ=" & TR_ID_JJ & ",@TYPE_ID= '" & TYPE_ID & "',@PROCESS_ID= '" & P_ID & "',@FK_IDA_LCN= '" & LCN_IDA & "'"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_MAS_TABEAN_HERB_EDIT_UPLOADFILE(ByVal FK_IDA As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_TABEAN_HERB_EDIT_UPLOADFILE @FK_IDA= " & FK_IDA
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_TABEAN_JJ_EDIT_SUB_PACKSIZE(ByVal fk_ida As Integer, ByVal P_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_JJ_EDIT_SUB_PACKSIZE @fk_ida=" & fk_ida & ",@PROCESS_ID=" & P_ID
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_TABEAN_HERB_UPLOAD_FILE_JJ_EDIT(ByVal TR_ID_JJ As Integer, ByVal TYPE_ID As Integer, ByVal P_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_HERB_UPLOAD_FILE_JJ_EDIT @TR_ID_JJ=" & TR_ID_JJ & ",@TYPE_ID= '" & TYPE_ID & "',@PROCESS_ID= '" & P_ID & "'"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_TABEAN_HERB_UPLOAD_FILE_JJ_EDIT_V2(ByVal TR_ID_JJ As Integer, ByVal TYPE_ID As Integer, ByVal P_ID As Integer, ByVal IDA As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_HERB_UPLOAD_FILE_JJ_EDIT_V2 @TR_ID_JJ=" & TR_ID_JJ & ",@TYPE_ID= '" & TYPE_ID & "',@PROCESS_ID= '" & P_ID & "' ,@IDA=" & IDA
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_TABEAN_HERB_UPLOAD_FILE_TBN_NO() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_HERB_UPLOAD_FILE_TBN_NO "
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_TABEAN_JR_CAS(ByVal FK_IDA As String) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_JR_CAS @FK_IDA='" & FK_IDA & "'"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_XML_TABEAN_JR_DETAIL(ByVal FK_IDA As String) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_XML_TABEAN_JR_DETAIL @FK_IDA='" & FK_IDA & "'"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_TABEAN_OFFICER_JJ() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_OFFICER_JJ"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_drdrgtype_Tabean_New() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_drdrgtype_Tabean_New"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_TABEAN_JJ(ByVal IDA_LCN As String) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_JJ @IDA_LCN= '" & IDA_LCN & "'"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_RQ_TABEAN_BY_FK_IDA_LCN(ByVal IDA_LCN As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_RQ_TABEAN_BY_FK_IDA_LCN @IDA=" & IDA_LCN
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_TABEAN_HERB_BY_FK_IDA_LCN(ByVal IDA_LCN As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_HERB_BY_FK_IDA_LCN @IDA=" & IDA_LCN
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_TABEAN_HERB_WHO(ByVal IDA_LCN As String, ByVal CITIEN_ID As String) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_HERB_WHO @IDA_LCN= '" & IDA_LCN & "' " & ",@CITIZEN_ID='" & CITIEN_ID & "'"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_XML_DRUG_DRRQT(ByVal _IDA_DQ As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_XML_DRUG_DRRQT @IDA=" & _IDA_DQ
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_TABEAN_JJ_SUB_PACKSIZE(ByVal fk_ida As Integer, ByVal P_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_JJ_SUB_PACKSIZE @fk_ida=" & fk_ida & ",@PROCESS_ID=" & P_ID
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_TABEAN_HERB_UPLOAD_FILE_JJ_FK_IDA_LCN(ByVal TR_ID_JJ As Integer, ByVal TYPE_ID As Integer, ByVal P_ID As Integer, ByVal LCN_IDA As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_HERB_UPLOAD_FILE_JJ_FK_IDA_LCN @TR_ID_JJ=" & TR_ID_JJ & ",@TYPE_ID= '" & TYPE_ID & "',@PROCESS_ID= '" & P_ID & "',@FK_IDA_LCN= '" & LCN_IDA & "'"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_TABEAN_HERB_UPLOAD_FILE_JJ_FK_IDA_LCN_STAFF(ByVal TR_ID_JJ As Integer, ByVal TYPE_ID As Integer, ByVal P_ID As Integer, ByVal LCN_IDA As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_HERB_UPLOAD_FILE_JJ_FK_IDA_LCN_STAFF @TR_ID_JJ=" & TR_ID_JJ & ",@TYPE_ID= '" & TYPE_ID & "',@PROCESS_ID= '" & P_ID & "',@FK_IDA_LCN= '" & LCN_IDA & "'"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_MAS_TABEAN_HERB_RECIPE_PRODUCT_JJ(ByVal DD_HERB_NAME_PRODUCT_ID As Integer, ByVal P_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_TABEAN_HERB_RECIPE_PRODUCT_JJ @DD_HERB_NAME_PRODUCT_ID=" & DD_HERB_NAME_PRODUCT_ID & ",@PROCESS_ID=" & P_ID
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_TABEAN_HERB_UPLOAD_FILE_JJ(ByVal TR_ID_JJ As Integer, ByVal TYPE_ID As Integer, ByVal P_ID As Integer, ByVal FK_ID As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_HERB_UPLOAD_FILE_JJ @TR_ID_JJ=" & TR_ID_JJ & ",@TYPE_ID= '" & TYPE_ID & "',@PROCESS_ID= '" & P_ID & "'" & ",@FK_IDA= '" & FK_ID & "'"
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_TABEAN_HERB_UPLOAD_FILE_JJ_FK_IDA(ByVal TR_ID_JJ As Integer, ByVal TYPE_ID As Integer, ByVal P_ID As Integer, ByVal FK_IDA As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec TABEAN_HERB_UPLOAD_FILE_JJ @TR_ID_JJ=" & TR_ID_JJ & ",@TYPE_ID= '" & TYPE_ID & "',@PROCESS_ID= '" & P_ID & "',@FK_IDA= '" & FK_IDA & "'"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_TABEAN_HERB_UPLOAD_FILE_JJ_NO() As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_TABEAN_HERB_UPLOAD_FILE_JJ_NO"
            dt = Queryds(qstr)

            Return dt
        End Function

        Public Function SP_XML_WHO_DALCN(ByVal FK_IDA As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_XML_WHO_DALCN @FK_IDA=" & FK_IDA
            dt = Queryds(qstr)

            Return dt
        End Function
    End Class

    Public Class tb_xml
        Inherits connection_db

        Public Function SP_XML_TABEAN_JJ(ByVal IDA As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_XML_TABEAN_JJ @IDA=" & IDA
            dt = Queryds(qstr)

            Return dt
        End Function
        Public Function SP_XML_TABEAN_JJ_EDIT_REQUES_V2(ByVal IDA As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_XML_TABEAN_JJ_EDIT_REQUES_V2 @IDA=" & IDA
            dt = Queryds(qstr)

            Return dt
        End Function
    End Class
    Public Class tb_xml_jj_Edit
        Inherits connection_db

        Public Function SP_XML_TABEAN_JJ_EDIT_BY_IDA(ByVal IDA As Integer) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_XML_TABEAN_JJ_EDIT_BY_IDA @IDA=" & IDA
            dt = Queryds(qstr)

            Return dt
        End Function
    End Class
    Public Class master_jj
        Inherits connection_db

        Public Function SP_MAS_TABEAN_HERB_NAME_JJ(ByVal PROCESS_ID As String) As DataTable
            Dim dt As New DataTable
            Dim qstr As String = ""

            qstr = "exec SP_MAS_TABEAN_HERB_NAME_JJ @PROCESS_ID=" & PROCESS_ID
            dt = Queryds(qstr)

            Return dt
        End Function


    End Class

End Namespace

