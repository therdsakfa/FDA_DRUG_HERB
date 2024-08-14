Namespace XML_CENTER
    Public Class CLASS_DALCN
        Inherits CLASS_CENTER
        Public dalcns As New dalcn
        Public dalcns_new As New dalcn
#Region "SHOW"
        Private _DT_SHOW As New CLS_SHOW
        Public Property DT_SHOW() As CLS_SHOW
            Get
                Return _DT_SHOW
            End Get
            Set(ByVal value As CLS_SHOW)
                _DT_SHOW = value
            End Set
        End Property
#End Region

#Region "MASTER"
        Private _DT_MASTER As New CLS_MASTER
        Public Property DT_MASTER() As CLS_MASTER
            Get
                Return _DT_MASTER
            End Get
            Set(ByVal value As CLS_MASTER)
                _DT_MASTER = value
            End Set
        End Property
#End Region

#Region "DataBase"

#Region "dakeplctnm"
        Private _dakeplctnm As New List(Of dakeplctnm)
        Public Property dakeplctnms As List(Of dakeplctnm)
            Get
                Return _dakeplctnm
            End Get
            Set(ByVal Value As List(Of dakeplctnm))
                _dakeplctnm = Value
            End Set
        End Property
#End Region

#Region "dalcnctg"
        Private _dalcnctg As New List(Of dalcnctg)
        Public Property dalcnctgs As List(Of dalcnctg)
            Get
                Return _dalcnctg
            End Get
            Set(ByVal Value As List(Of dalcnctg))
                _dalcnctg = Value
            End Set
        End Property
#End Region

#Region "dalcnphr"
        Private _dalcnphr As New List(Of dalcnphr)
        Public Property dalcnphrs As List(Of dalcnphr)
            Get
                Return _dalcnphr
            End Get
            Set(ByVal Value As List(Of dalcnphr))
                _dalcnphr = Value
            End Set
        End Property
#End Region

#Region "dacnphdtl"
        Private _dacnphdtl As New List(Of dacnphdtl)
        Public Property dacnphdtls As List(Of dacnphdtl)
            Get
                Return _dacnphdtl
            End Get
            Set(ByVal Value As List(Of dacnphdtl))
                _dacnphdtl = Value
            End Set
        End Property
#End Region

#Region "dacncphr"
        Private _dacncphr As New List(Of dacncphr)
        Public Property dacncphrs As List(Of dacncphr)
            Get
                Return _dacncphr
            End Get
            Set(ByVal Value As List(Of dacncphr))
                _dacncphr = Value
            End Set
        End Property
#End Region

#Region "dalcnkep"
        Private _dalcnkep As New List(Of dalcnkep)
        Public Property dalcnkeps As List(Of dalcnkep)
            Get
                Return _dalcnkep
            End Get
            Set(ByVal Value As List(Of dalcnkep))
                _dalcnkep = Value
            End Set
        End Property
#End Region

#Region "darqt"
        Private _darqt As New List(Of darqt)
        Public Property darqts As List(Of darqt)
            Get
                Return _darqt
            End Get
            Set(ByVal Value As List(Of darqt))
                _darqt = Value
            End Set
        End Property
#End Region

#Region "DALCN_KEP"
        Private _DALCN_KEP As New List(Of DALCN_KEP)
        Public Property DALCN_KEPs As List(Of DALCN_KEP)
            Get
                Return _DALCN_KEP
            End Get
            Set(ByVal Value As List(Of DALCN_KEP))
                _DALCN_KEP = Value
            End Set
        End Property
#End Region

#Region "DALCN_PHR"
        Private _DALCN_PHR As New List(Of DALCN_PHR)
        Public Property DALCN_PHRs As List(Of DALCN_PHR)
            Get
                Return _DALCN_PHR
            End Get
            Set(ByVal Value As List(Of DALCN_PHR))
                _DALCN_PHR = Value
            End Set
        End Property
#End Region

#Region "DALCN_PHR_2"
        ''' <summary>
        ''' xml สำหรับเภสัชกรอีกประเภท
        ''' </summary>
        ''' <remarks></remarks>
        Private _DALCN_PHR_2 As New List(Of DALCN_PHR)
        Public Property DALCN_PHR_2s As List(Of DALCN_PHR)
            Get
                Return _DALCN_PHR_2
            End Get
            Set(ByVal Value As List(Of DALCN_PHR))
                _DALCN_PHR_2 = Value
            End Set
        End Property
#End Region
#Region "DALCN_PHR_3"
        ''' <summary>
        ''' xml สำหรับเภสัชกรอีกประเภท
        ''' </summary>
        ''' <remarks></remarks>
        Private _DALCN_PHR_3 As New List(Of DALCN_PHR)
        Public Property DALCN_PHR_3s As List(Of DALCN_PHR)
            Get
                Return _DALCN_PHR_3
            End Get
            Set(ByVal Value As List(Of DALCN_PHR))
                _DALCN_PHR_3 = Value
            End Set
        End Property
#End Region
#Region "DALCN_WORKTIME"
        Private _DALCN_WORKTIME As New List(Of DALCN_WORKTIME)
        Public Property DALCN_WORKTIMEs As List(Of DALCN_WORKTIME)
            Get
                Return _DALCN_WORKTIME
            End Get
            Set(ByVal Value As List(Of DALCN_WORKTIME))
                _DALCN_WORKTIME = Value
            End Set
        End Property
#End Region

#Region "sysplace"
        Private _sysplace As New List(Of sysplace)
        Public Property sysplaces As List(Of sysplace)
            Get
                Return _sysplace
            End Get
            Set(ByVal Value As List(Of sysplace))
                _sysplace = Value
            End Set
        End Property
#End Region

#Region "dalcnaddr"
        Private _dalcnaddr As New List(Of dalcnaddr)
        Public Property dalcnaddrs As List(Of dalcnaddr)
            Get
                Return _dalcnaddr
            End Get
            Set(ByVal Value As List(Of dalcnaddr))
                _dalcnaddr = Value
            End Set
        End Property
#End Region

#Region "DALCN_DETAIL_LOCATION_KEEP"
        Private _DALCN_DETAIL_LOCATION_KEEP As New List(Of DALCN_DETAIL_LOCATION_KEEP)
        Public Property DALCN_DETAIL_LOCATION_KEEPs As List(Of DALCN_DETAIL_LOCATION_KEEP)
            Get
                Return _DALCN_DETAIL_LOCATION_KEEP
            End Get
            Set(ByVal Value As List(Of DALCN_DETAIL_LOCATION_KEEP))
                _DALCN_DETAIL_LOCATION_KEEP = Value
            End Set
        End Property
#End Region

#End Region

#Region "additional"

        Private _EXP_YEAR As String
        Public Property EXP_YEAR() As String
            Get
                Return _EXP_YEAR
            End Get
            Set(ByVal value As String)
                _EXP_YEAR = value
            End Set
        End Property

        Private _LCNNO_SHOW As String
        Public Property LCNNO_SHOW() As String
            Get
                Return _LCNNO_SHOW
            End Get
            Set(ByVal value As String)
                _LCNNO_SHOW = value
            End Set
        End Property

        Private _LCNNO_SHOW_NEW As String
        Public Property LCNNO_SHOW_NEW() As String
            Get
                Return _LCNNO_SHOW_NEW
            End Get
            Set(ByVal value As String)
                _LCNNO_SHOW_NEW = value
            End Set
        End Property
        Private _LCNNO_SHOW_NUMTHAI As String
        Public Property LCNNO_SHOW_NUMTHAI() As String
            Get
                Return _LCNNO_SHOW_NUMTHAI
            End Get
            Set(ByVal value As String)
                _LCNNO_SHOW_NUMTHAI = value
            End Set
        End Property
        Private _LCNNO_TYPE As String
        Public Property LCNNO_TYPE() As String
            Get
                Return _LCNNO_TYPE
            End Get
            Set(ByVal value As String)
                _LCNNO_TYPE = value
            End Set
        End Property
        Private _LCNNO_SHOW_NEW_NUMTHAI As String
        Public Property LCNNO_SHOW_NEW_NUMTHAI() As String
            Get
                Return _LCNNO_SHOW_NEW_NUMTHAI
            End Get
            Set(ByVal value As String)
                _LCNNO_SHOW_NEW_NUMTHAI = value
            End Set
        End Property

        Private _RCVDAY As String
        Public Property RCVDAY() As String
            Get
                Return _RCVDAY
            End Get
            Set(ByVal value As String)
                _RCVDAY = value
            End Set
        End Property
        Private _PROCESS_ID As String
        Public Property PROCESS_ID() As String
            Get
                Return _PROCESS_ID
            End Get
            Set(ByVal value As String)
                _PROCESS_ID = value
            End Set
        End Property
        Private _RCVMONTH As String
        Public Property RCVMONTH() As String
            Get
                Return _RCVMONTH
            End Get
            Set(ByVal value As String)
                _RCVMONTH = value
            End Set
        End Property

        Private _RCVYEAR As String
        Public Property RCVYEAR() As String
            Get
                Return _RCVYEAR
            End Get
            Set(ByVal value As String)
                _RCVYEAR = value
            End Set
        End Property

        Private _RCVDAY_NUMTHAI As String
        Public Property RCVDAY_NUMTHAI() As String
            Get
                Return _RCVDAY_NUMTHAI
            End Get
            Set(ByVal value As String)
                _RCVDAY_NUMTHAI = value
            End Set
        End Property

        Private _RCVMONTH_NUMTHAI As String
        Public Property RCVMONTH_NUMTHAI() As String
            Get
                Return _RCVMONTH_NUMTHAI
            End Get
            Set(ByVal value As String)
                _RCVMONTH_NUMTHAI = value
            End Set
        End Property

        Private _RCVYEAR_NUMTHAI As String
        Public Property RCVYEAR_NUMTHAI() As String
            Get
                Return _RCVYEAR_NUMTHAI
            End Get
            Set(ByVal value As String)
                _RCVYEAR_NUMTHAI = value
            End Set
        End Property
        Private _RCVDAY_NEW As String
        Public Property RCVDAY_NEW() As String
            Get
                Return _RCVDAY_NEW
            End Get
            Set(ByVal value As String)
                _RCVDAY_NEW = value
            End Set
        End Property

        Private _RCVMONTH_NEW As String
        Public Property RCVMONTH_NEW() As String
            Get
                Return _RCVMONTH_NEW
            End Get
            Set(ByVal value As String)
                _RCVMONTH_NEW = value
            End Set
        End Property

        Private _RCVYEAR_NEW As String
        Public Property RCVYEAR_NEW() As String
            Get
                Return _RCVYEAR_NEW
            End Get
            Set(ByVal value As String)
                _RCVYEAR_NEW = value
            End Set
        End Property

        Private _RCVDAY_NUMTHAI_NEW As String
        Public Property RCVDAY_NUMTHAI_NEW() As String
            Get
                Return _RCVDAY_NUMTHAI_NEW
            End Get
            Set(ByVal value As String)
                _RCVDAY_NUMTHAI_NEW = value
            End Set
        End Property

        Private _RCVMONTH_NUMTHAI_NEW As String
        Public Property RCVMONTH_NUMTHAI_NEW() As String
            Get
                Return _RCVMONTH_NUMTHAI_NEW
            End Get
            Set(ByVal value As String)
                _RCVMONTH_NUMTHAI_NEW = value
            End Set
        End Property

        Private _RCVYEAR_NUMTHAI_NEW As String
        Public Property RCVYEAR_NUMTHAI_NEW() As String
            Get
                Return _RCVYEAR_NUMTHAI_NEW
            End Get
            Set(ByVal value As String)
                _RCVYEAR_NUMTHAI_NEW = value
            End Set
        End Property

        Private _CHK_VALUE As String
        Public Property CHK_VALUE() As String
            Get
                Return _CHK_VALUE
            End Get
            Set(ByVal value As String)
                _CHK_VALUE = value
            End Set
        End Property

        Private _phr_medical_type As String
        Public Property phr_medical_type() As String
            Get
                Return _phr_medical_type
            End Get
            Set(ByVal value As String)
                _phr_medical_type = value
            End Set
        End Property
        Private _BSN_IDENTIFY As String
        Public Property BSN_IDENTIFY() As String
            Get
                Return _BSN_IDENTIFY
            End Get
            Set(ByVal value As String)
                _BSN_IDENTIFY = value
            End Set
        End Property
        Private _COUNT_PHESAJ1 As String
        Public Property COUNT_PHESAJ1() As String
            Get
                Return _COUNT_PHESAJ1
            End Get
            Set(ByVal value As String)
                _COUNT_PHESAJ1 = value
            End Set
        End Property
        Private _COUNT_PHESAJ2 As String
        Public Property COUNT_PHESAJ2() As String
            Get
                Return _COUNT_PHESAJ2
            End Get
            Set(ByVal value As String)
                _COUNT_PHESAJ2 = value
            End Set
        End Property
        Private _COUNT_PHESAJ3 As String
        Public Property COUNT_PHESAJ3() As String
            Get
                Return _COUNT_PHESAJ3
            End Get
            Set(ByVal value As String)
                _COUNT_PHESAJ3 = value
            End Set
        End Property
        Private _ALLOW_NAME As String
        Public Property ALLOW_NAME() As String
            Get
                Return _ALLOW_NAME
            End Get
            Set(ByVal value As String)
                _ALLOW_NAME = value
            End Set
        End Property

        Private _QR_CODE As String
        Public Property QR_CODE() As String
            Get
                Return _QR_CODE
            End Get
            Set(ByVal value As String)
                _QR_CODE = value
            End Set
        End Property
        Private _EMAIL As String
        Public Property EMAIL() As String
            Get
                Return _EMAIL
            End Get
            Set(ByVal value As String)
                _EMAIL = value
            End Set
        End Property
        Private _HEAD_LCNNO_NCT As String
        Public Property HEAD_LCNNO_NCT() As String
            Get
                Return _HEAD_LCNNO_NCT
            End Get
            Set(ByVal value As String)
                _HEAD_LCNNO_NCT = value
            End Set
        End Property
        Private _CHILD_LCNNO_NCT As String
        Public Property CHILD_LCNNO_NCT() As String
            Get
                Return _CHILD_LCNNO_NCT
            End Get
            Set(ByVal value As String)
                _CHILD_LCNNO_NCT = value
            End Set
        End Property


        Private _syslctaddr_thaaddr As String
        Public Property syslctaddr_thaaddr() As String
            Get
                Return _syslctaddr_thaaddr
            End Get
            Set(ByVal value As String)
                _syslctaddr_thaaddr = value
            End Set
        End Property
        Private _syslctaddr_engaddr As String
        Public Property syslctaddr_engaddr() As String
            Get
                Return _syslctaddr_engaddr
            End Get
            Set(ByVal value As String)
                _syslctaddr_engaddr = value
            End Set
        End Property
        Private _syslctaddr_room As String
        Public Property syslctaddr_room() As String
            Get
                Return _syslctaddr_room
            End Get
            Set(ByVal value As String)
                _syslctaddr_room = value
            End Set
        End Property
        Private _syslctaddr_mu As String
        Public Property syslctaddr_mu() As String
            Get
                Return _syslctaddr_mu
            End Get
            Set(ByVal value As String)
                _syslctaddr_mu = value
            End Set
        End Property
        Private _syslctaddr_floor As String
        Public Property syslctaddr_floor() As String
            Get
                Return _syslctaddr_floor
            End Get
            Set(ByVal value As String)
                _syslctaddr_floor = value
            End Set
        End Property
        Private _syslctaddr_thasoi As String
        Public Property syslctaddr_thasoi() As String
            Get
                Return _syslctaddr_thasoi
            End Get
            Set(ByVal value As String)
                _syslctaddr_thasoi = value
            End Set
        End Property

        Private _LCN_TYPE As String
        Public Property LCN_TYPE() As String
            Get
                Return _LCN_TYPE
            End Get
            Set(ByVal value As String)
                _LCN_TYPE = value
            End Set
        End Property

        Private _MASTRA As String
        Public Property MASTRA() As String
            Get
                Return _MASTRA
            End Get
            Set(ByVal value As String)
                _MASTRA = value
            End Set
        End Property
        Private _MASTRA_NO As String
        Public Property MASTRA_NO() As String
            Get
                Return _MASTRA_NO
            End Get
            Set(ByVal value As String)
                _MASTRA_NO = value
            End Set
        End Property
        Private _MASTRA_NUMTHAI As String
        Public Property MASTRA_NUMTHAI() As String
            Get
                Return _MASTRA_NUMTHAI
            End Get
            Set(ByVal value As String)
                _MASTRA_NUMTHAI = value
            End Set
        End Property
        Private _MASTRA_NO_NUMTHAI As String
        Public Property MASTRA_NO_NUMTHAI() As String
            Get
                Return _MASTRA_NO_NUMTHAI
            End Get
            Set(ByVal value As String)
                _MASTRA_NO_NUMTHAI = value
            End Set
        End Property

        Private _DRUG_GROUP_TYPE As String
        Public Property DRUG_GROUP_TYPE() As String
            Get
                Return _DRUG_GROUP_TYPE
            End Get
            Set(ByVal value As String)
                _DRUG_GROUP_TYPE = value
            End Set
        End Property

        Private _LCN_TYPE_ID As String
        Public Property LCN_TYPE_ID() As String
            Get
                Return _LCN_TYPE_ID
            End Get
            Set(ByVal value As String)
                _LCN_TYPE_ID = value
            End Set
        End Property

        Private _EXPDAY As String
        Public Property EXPDAY() As String
            Get
                Return _EXPDAY
            End Get
            Set(ByVal value As String)
                _EXPDAY = value
            End Set
        End Property

        Private _EXPMONTH As String
        Public Property EXPMONTH() As String
            Get
                Return _EXPMONTH
            End Get
            Set(ByVal value As String)
                _EXPMONTH = value
            End Set
        End Property

        Private _EXPYEAR As String
        Public Property EXPYEAR() As String
            Get
                Return _EXPYEAR
            End Get
            Set(ByVal value As String)
                _EXPYEAR = value
            End Set
        End Property
        Private _RCVNO_FORMAT As String
        Public Property RCVNO_FORMAT() As String
            Get
                Return _RCVNO_FORMAT
            End Get
            Set(ByVal value As String)
                _RCVNO_FORMAT = value
            End Set
        End Property
        Private _RCVDATE_DISPLAY As String
        Public Property RCVDATE_DISPLAY() As String
            Get
                Return _RCVDATE_DISPLAY
            End Get
            Set(ByVal value As String)
                _RCVDATE_DISPLAY = value
            End Set
        End Property
        Private _OPEN_TIME As String
        Public Property OPEN_TIME() As String
            Get
                Return _OPEN_TIME
            End Get
            Set(ByVal value As String)
                _OPEN_TIME = value
            End Set
        End Property
        Private _TRANSFER_NAME As String
        Public Property TRANSFER_NAME() As String
            Get
                Return _TRANSFER_NAME
            End Get
            Set(ByVal value As String)
                _TRANSFER_NAME = value
            End Set
        End Property
        Private _TRANSFER_NAME_NEW As String
        Public Property TRANSFER_NAME_NEW() As String
            Get
                Return _TRANSFER_NAME_NEW
            End Get
            Set(ByVal value As String)
                _TRANSFER_NAME_NEW = value
            End Set
        End Property
        Private _TRANSFER_DATE As String
        Public Property TRANSFER_DATE() As String
            Get
                Return _TRANSFER_DATE
            End Get
            Set(ByVal value As String)
                _TRANSFER_DATE = value
            End Set
        End Property
        Private _LCNNO_OLD As String
        Public Property LCNNO_DISPAY_OLD() As String
            Get
                Return _LCNNO_OLD
            End Get
            Set(ByVal value As String)
                _LCNNO_OLD = value
            End Set
        End Property
#End Region

#Region "chk_smp"
        Private _chk_smp1 As String
        Public Property chk_smp1() As String
            Get
                Return _chk_smp1
            End Get
            Set(ByVal value As String)
                _chk_smp1 = value
            End Set
        End Property
        Private _chk_smp1_1 As String
        Public Property chk_smp1_1() As String
            Get
                Return _chk_smp1_1
            End Get
            Set(ByVal value As String)
                _chk_smp1_1 = value
            End Set
        End Property
        Private _chk_smp1_2 As String
        Public Property chk_smp1_2() As String
            Get
                Return _chk_smp1_2
            End Get
            Set(ByVal value As String)
                _chk_smp1_2 = value
            End Set
        End Property
        Private _chk_smp1_3 As String
        Public Property chk_smp1_3() As String
            Get
                Return _chk_smp1_3
            End Get
            Set(ByVal value As String)
                _chk_smp1_3 = value
            End Set
        End Property
        Private _chk_smp1_4 As String
        Public Property chk_smp1_4() As String
            Get
                Return _chk_smp1_4
            End Get
            Set(ByVal value As String)
                _chk_smp1_4 = value
            End Set
        End Property
        Private _chk_smp1_5 As String
        Public Property chk_smp1_5() As String
            Get
                Return _chk_smp1_5
            End Get
            Set(ByVal value As String)
                _chk_smp1_5 = value
            End Set
        End Property
        Private _chk_smp1_6 As String
        Public Property chk_smp1_6() As String
            Get
                Return _chk_smp1_6
            End Get
            Set(ByVal value As String)
                _chk_smp1_6 = value
            End Set
        End Property
        Private _chk_smp1_7 As String
        Public Property chk_smp1_7() As String
            Get
                Return _chk_smp1_7
            End Get
            Set(ByVal value As String)
                _chk_smp1_7 = value
            End Set
        End Property
        Private _chk_smp1_8 As String
        Public Property chk_smp1_8() As String
            Get
                Return _chk_smp1_8
            End Get
            Set(ByVal value As String)
                _chk_smp1_8 = value
            End Set
        End Property
        Private _chk_smp1_9 As String
        Public Property chk_smp1_9() As String
            Get
                Return _chk_smp1_9
            End Get
            Set(ByVal value As String)
                _chk_smp1_9 = value
            End Set

        End Property
        Private _chk_smp1_10 As String
        Public Property chk_smp1_10() As String
            Get
                Return _chk_smp1_10
            End Get
            Set(ByVal value As String)
                _chk_smp1_10 = value
            End Set

        End Property
        Private _chk_smp1_11 As String
        Public Property chk_smp1_11() As String
            Get
                Return _chk_smp1_11
            End Get
            Set(ByVal value As String)
                _chk_smp1_11 = value
            End Set

        End Property
        Private _chk_smp2 As String
        Public Property chk_smp2() As String
            Get
                Return _chk_smp2
            End Get
            Set(ByVal value As String)
                _chk_smp2 = value
            End Set
        End Property
        Private _chk_smp2_1 As String
        Public Property chk_smp2_1() As String
            Get
                Return _chk_smp2_1
            End Get
            Set(ByVal value As String)
                _chk_smp2_1 = value
            End Set
        End Property
        Private _chk_smp2_2 As String
        Public Property chk_smp2_2() As String
            Get
                Return _chk_smp2_2
            End Get
            Set(ByVal value As String)
                _chk_smp2_2 = value
            End Set
        End Property
        Private _chk_smp2_3 As String
        Public Property chk_smp2_3() As String
            Get
                Return _chk_smp2_3
            End Get
            Set(ByVal value As String)
                _chk_smp2_3 = value
            End Set
        End Property
        Private _chk_smp2_4 As String
        Public Property chk_smp2_4() As String
            Get
                Return _chk_smp2_4
            End Get
            Set(ByVal value As String)
                _chk_smp2_4 = value
            End Set
        End Property
        Private _chk_smp2_5 As String
        Public Property chk_smp2_5() As String
            Get
                Return _chk_smp2_5
            End Get
            Set(ByVal value As String)
                _chk_smp2_5 = value
            End Set
        End Property
        Private _chk_smp2_6 As String
        Public Property chk_smp2_6() As String
            Get
                Return _chk_smp2_6
            End Get
            Set(ByVal value As String)
                _chk_smp2_6 = value
            End Set
        End Property
        Private _chk_smp2_7 As String
        Public Property chk_smp2_7() As String
            Get
                Return _chk_smp2_7
            End Get
            Set(ByVal value As String)
                _chk_smp2_7 = value
            End Set
        End Property
        Private _chk_smp2_8 As String
        Public Property chk_smp2_8() As String
            Get
                Return _chk_smp2_8
            End Get
            Set(ByVal value As String)
                _chk_smp2_8 = value
            End Set
        End Property
        Private _chk_smp2_9 As String
        Public Property chk_smp2_9() As String
            Get
                Return _chk_smp2_9
            End Get
            Set(ByVal value As String)
                _chk_smp2_9 = value
            End Set
        End Property
        Private _chk_smp2_10 As String
        Public Property chk_smp2_10() As String
            Get
                Return _chk_smp2_10
            End Get
            Set(ByVal value As String)
                _chk_smp2_10 = value
            End Set
        End Property
        Private _chk_smp2_11 As String
        Public Property chk_smp2_11() As String
            Get
                Return _chk_smp2_11
            End Get
            Set(ByVal value As String)
                _chk_smp2_11 = value
            End Set
        End Property
        Private _chk_smp2_12 As String
        Public Property chk_smp2_12() As String
            Get
                Return _chk_smp2_12
            End Get
            Set(ByVal value As String)
                _chk_smp2_12 = value
            End Set
        End Property
        Private _chk_smp3 As String
        Public Property chk_smp3() As String
            Get
                Return _chk_smp3
            End Get
            Set(ByVal value As String)
                _chk_smp3 = value
            End Set
        End Property
        Private _chk_smp3_1 As String
        Public Property chk_smp3_1() As String
            Get
                Return _chk_smp3_1
            End Get
            Set(ByVal value As String)
                _chk_smp3_1 = value
            End Set
        End Property
        Private _chk_smp3_2 As String
        Public Property chk_smp3_2() As String
            Get
                Return _chk_smp3_2
            End Get
            Set(ByVal value As String)
                _chk_smp3_2 = value
            End Set
        End Property
        Private _chk_smp3_3 As String
        Public Property chk_smp3_3() As String
            Get
                Return _chk_smp3_3
            End Get
            Set(ByVal value As String)
                _chk_smp3_3 = value
            End Set
        End Property
        Private _chk_smp3_4 As String
        Public Property chk_smp3_4() As String
            Get
                Return _chk_smp3_4
            End Get
            Set(ByVal value As String)
                _chk_smp3_4 = value
            End Set
        End Property
        Private _chk_smp3_5 As String
        Public Property chk_smp3_5() As String
            Get
                Return _chk_smp3_5
            End Get
            Set(ByVal value As String)
                _chk_smp3_5 = value
            End Set
        End Property
        Private _chk_smp3_6 As String
        Public Property chk_smp3_6() As String
            Get
                Return _chk_smp3_6
            End Get
            Set(ByVal value As String)
                _chk_smp3_6 = value
            End Set
        End Property
        Private _chk_smp3_7 As String
        Public Property chk_smp3_7() As String
            Get
                Return _chk_smp3_7
            End Get
            Set(ByVal value As String)
                _chk_smp3_7 = value
            End Set
        End Property
        Private _chk_smp3_8 As String
        Public Property chk_smp3_8() As String
            Get
                Return _chk_smp3_8
            End Get
            Set(ByVal value As String)
                _chk_smp3_8 = value
            End Set
        End Property
        Private _chk_smp3_9 As String
        Public Property chk_smp3_9() As String
            Get
                Return _chk_smp3_9
            End Get
            Set(ByVal value As String)
                _chk_smp3_9 = value
            End Set
        End Property
        Private _chk_smp3_10 As String
        Public Property chk_smp3_10() As String
            Get
                Return _chk_smp3_10
            End Get
            Set(ByVal value As String)
                _chk_smp3_10 = value
            End Set
        End Property
        Private _chk_smp3_11 As String
        Public Property chk_smp3_11() As String
            Get
                Return _chk_smp3_11
            End Get
            Set(ByVal value As String)
                _chk_smp3_11 = value
            End Set
        End Property
        Private _chk_smp3_12 As String
        Public Property chk_smp3_12() As String
            Get
                Return _chk_smp3_12
            End Get
            Set(ByVal value As String)
                _chk_smp3_12 = value
            End Set
        End Property
        Private _chk_smp4 As String
        Public Property chk_smp4() As String
            Get
                Return _chk_smp4
            End Get
            Set(ByVal value As String)
                _chk_smp4 = value
            End Set
        End Property
        Private _chk_smp4_1 As String
        Public Property chk_smp4_1() As String
            Get
                Return _chk_smp4_1
            End Get
            Set(ByVal value As String)
                _chk_smp4_1 = value
            End Set
        End Property
        Private _chk_smp4_1_1 As String
        Public Property chk_smp4_1_1() As String
            Get
                Return _chk_smp4_1_1
            End Get
            Set(ByVal value As String)
                _chk_smp4_1_1 = value
            End Set
        End Property
        Private _chk_smp4_1_2 As String
        Public Property chk_smp4_1_2() As String
            Get
                Return _chk_smp4_1_2
            End Get
            Set(ByVal value As String)
                _chk_smp4_1_2 = value
            End Set
        End Property
        Private _chk_smp4_2 As String
        Public Property chk_smp4_2() As String
            Get
                Return _chk_smp4_2
            End Get
            Set(ByVal value As String)
                _chk_smp4_2 = value
            End Set
        End Property
        Private _chk_smp4_3 As String
        Public Property chk_smp4_3() As String
            Get
                Return _chk_smp4_3
            End Get
            Set(ByVal value As String)
                _chk_smp4_3 = value
            End Set
        End Property
        Private _CHK_SMP1_SELL_1 As String
        Public Property CHK_SMP1_SELL_1() As String
            Get
                Return _CHK_SMP1_SELL_1
            End Get
            Set(ByVal value As String)
                _CHK_SMP1_SELL_1 = value
            End Set
        End Property
        Private _CHK_SMP1_SELL_2 As String
        Public Property CHK_SMP1_SELL_2() As String
            Get
                Return _CHK_SMP1_SELL_2
            End Get
            Set(ByVal value As String)
                _CHK_SMP1_SELL_2 = value
            End Set
        End Property
        Private _CHK_SMP1_SELL_3 As String
        Public Property CHK_SMP1_SELL_3() As String
            Get
                Return _CHK_SMP1_SELL_3
            End Get
            Set(ByVal value As String)
                _CHK_SMP1_SELL_3 = value
            End Set
        End Property
        Private _CHK_SMP1_SELL_4 As String
        Public Property CHK_SMP1_SELL_4() As String
            Get
                Return _CHK_SMP1_SELL_4
            End Get
            Set(ByVal value As String)
                _CHK_SMP1_SELL_4 = value
            End Set
        End Property
        Private _DDL_MENU_DRUG_GROUP_3_1 As String
        Public Property DDL_MENU_DRUG_GROUP_3_1() As String
            Get
                Return _DDL_MENU_DRUG_GROUP_3_1
            End Get
            Set(ByVal value As String)
                _DDL_MENU_DRUG_GROUP_3_1 = value
            End Set
        End Property
        Private _DDL_MENU_DRUG_GROUP_3_2 As String
        Public Property DDL_MENU_DRUG_GROUP_3_2() As String
            Get
                Return _DDL_MENU_DRUG_GROUP_3_2
            End Get
            Set(ByVal value As String)
                _DDL_MENU_DRUG_GROUP_3_2 = value
            End Set
        End Property
        Private _DDL_MENU_DRUG_GROUP_3_3 As String
        Public Property DDL_MENU_DRUG_GROUP_3_3() As String
            Get
                Return _DDL_MENU_DRUG_GROUP_3_3
            End Get
            Set(ByVal value As String)
                _DDL_MENU_DRUG_GROUP_3_3 = value
            End Set
        End Property
        Private _DDL_MENU_DRUG_GROUP_3_4 As String
        Public Property DDL_MENU_DRUG_GROUP_3_4() As String
            Get
                Return _DDL_MENU_DRUG_GROUP_3_4
            End Get
            Set(ByVal value As String)
                _DDL_MENU_DRUG_GROUP_3_4 = value
            End Set
        End Property
        Private _DDL_MENU_DRUG_GROUP_3_5 As String
        Public Property DDL_MENU_DRUG_GROUP_3_5() As String
            Get
                Return _DDL_MENU_DRUG_GROUP_3_5
            End Get
            Set(ByVal value As String)
                _DDL_MENU_DRUG_GROUP_3_5 = value
            End Set
        End Property
        Private _DDL_MENU_DRUG_GROUP_3_6 As String
        Public Property DDL_MENU_DRUG_GROUP_3_6() As String
            Get
                Return _DDL_MENU_DRUG_GROUP_3_6
            End Get
            Set(ByVal value As String)
                _DDL_MENU_DRUG_GROUP_3_6 = value
            End Set
        End Property
        Private _DDL_MENU_DRUG_GROUP_3_7 As String
        Public Property DDL_MENU_DRUG_GROUP_3_7() As String
            Get
                Return _DDL_MENU_DRUG_GROUP_3_7
            End Get
            Set(ByVal value As String)
                _DDL_MENU_DRUG_GROUP_3_7 = value
            End Set
        End Property
        Private _DDL_MENU_DRUG_GROUP_3_8 As String
        Public Property DDL_MENU_DRUG_GROUP_3_8() As String
            Get
                Return _DDL_MENU_DRUG_GROUP_3_8
            End Get
            Set(ByVal value As String)
                _DDL_MENU_DRUG_GROUP_3_8 = value
            End Set
        End Property
        Private _DDL_MENU_DRUG_GROUP_3_9 As String
        Public Property DDL_MENU_DRUG_GROUP_3_9() As String
            Get
                Return _DDL_MENU_DRUG_GROUP_3_9
            End Get
            Set(ByVal value As String)
                _DDL_MENU_DRUG_GROUP_3_9 = value
            End Set
        End Property
        Private _DDL_MENU_DRUG_GROUP_3_10 As String
        Public Property DDL_MENU_DRUG_GROUP_3_10() As String
            Get
                Return _DDL_MENU_DRUG_GROUP_3_10
            End Get
            Set(ByVal value As String)
                _DDL_MENU_DRUG_GROUP_3_10 = value
            End Set
        End Property
        Private _DDL_MENU_DRUG_GROUP_3_11 As String
        Public Property DDL_MENU_DRUG_GROUP_3_11() As String
            Get
                Return _DDL_MENU_DRUG_GROUP_3_11
            End Get
            Set(ByVal value As String)
                _DDL_MENU_DRUG_GROUP_3_11 = value
            End Set
        End Property
        Private _DDL_MENU_DRUG_GROUP_3_12 As String
        Public Property DDL_MENU_DRUG_GROUP_3_12() As String
            Get
                Return _DDL_MENU_DRUG_GROUP_3_12
            End Get
            Set(ByVal value As String)
                _DDL_MENU_DRUG_GROUP_3_12 = value
            End Set
        End Property

#End Region
    End Class
End Namespace

