﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
'
Namespace WS_ETDA_SERVICE
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="WS_ETDA_SERVICESoap", [Namespace]:="http://tempuri.org/")>  _
    Partial Public Class WS_ETDA_SERVICE
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private CONNECT_PDF_ECTDOperationCompleted As System.Threading.SendOrPostCallback
        
        Private TESTOperationCompleted As System.Threading.SendOrPostCallback
        
        Private GET_TRANOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.FDA_DRUG_HERB.My.MySettings.Default.FDA_DRUG_HERB_WS_ETDA_SERVICE_WS_ETDA_SERVICE
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event CONNECT_PDF_ECTDCompleted As CONNECT_PDF_ECTDCompletedEventHandler
        
        '''<remarks/>
        Public Event TESTCompleted As TESTCompletedEventHandler
        
        '''<remarks/>
        Public Event GET_TRANCompleted As GET_TRANCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CONNECT_PDF_ECTD", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function CONNECT_PDF_ECTD(ByVal B64 As String, ByVal FILENAME As String, ByVal ORG_CODE As String) As CLS_RESULT
            Dim results() As Object = Me.Invoke("CONNECT_PDF_ECTD", New Object() {B64, FILENAME, ORG_CODE})
            Return CType(results(0),CLS_RESULT)
        End Function
        
        '''<remarks/>
        Public Overloads Sub CONNECT_PDF_ECTDAsync(ByVal B64 As String, ByVal FILENAME As String, ByVal ORG_CODE As String)
            Me.CONNECT_PDF_ECTDAsync(B64, FILENAME, ORG_CODE, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub CONNECT_PDF_ECTDAsync(ByVal B64 As String, ByVal FILENAME As String, ByVal ORG_CODE As String, ByVal userState As Object)
            If (Me.CONNECT_PDF_ECTDOperationCompleted Is Nothing) Then
                Me.CONNECT_PDF_ECTDOperationCompleted = AddressOf Me.OnCONNECT_PDF_ECTDOperationCompleted
            End If
            Me.InvokeAsync("CONNECT_PDF_ECTD", New Object() {B64, FILENAME, ORG_CODE}, Me.CONNECT_PDF_ECTDOperationCompleted, userState)
        End Sub
        
        Private Sub OnCONNECT_PDF_ECTDOperationCompleted(ByVal arg As Object)
            If (Not (Me.CONNECT_PDF_ECTDCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent CONNECT_PDF_ECTDCompleted(Me, New CONNECT_PDF_ECTDCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/TEST", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function TEST(ByVal PATH_FILE As String, ByVal FILENAME As String) As CLS_RESULT
            Dim results() As Object = Me.Invoke("TEST", New Object() {PATH_FILE, FILENAME})
            Return CType(results(0),CLS_RESULT)
        End Function
        
        '''<remarks/>
        Public Overloads Sub TESTAsync(ByVal PATH_FILE As String, ByVal FILENAME As String)
            Me.TESTAsync(PATH_FILE, FILENAME, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub TESTAsync(ByVal PATH_FILE As String, ByVal FILENAME As String, ByVal userState As Object)
            If (Me.TESTOperationCompleted Is Nothing) Then
                Me.TESTOperationCompleted = AddressOf Me.OnTESTOperationCompleted
            End If
            Me.InvokeAsync("TEST", New Object() {PATH_FILE, FILENAME}, Me.TESTOperationCompleted, userState)
        End Sub
        
        Private Sub OnTESTOperationCompleted(ByVal arg As Object)
            If (Not (Me.TESTCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent TESTCompleted(Me, New TESTCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GET_TRAN", RequestNamespace:="http://tempuri.org/", ResponseNamespace:="http://tempuri.org/", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GET_TRAN(ByVal TR_ID As String) As CLS_RESULT
            Dim results() As Object = Me.Invoke("GET_TRAN", New Object() {TR_ID})
            Return CType(results(0),CLS_RESULT)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GET_TRANAsync(ByVal TR_ID As String)
            Me.GET_TRANAsync(TR_ID, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GET_TRANAsync(ByVal TR_ID As String, ByVal userState As Object)
            If (Me.GET_TRANOperationCompleted Is Nothing) Then
                Me.GET_TRANOperationCompleted = AddressOf Me.OnGET_TRANOperationCompleted
            End If
            Me.InvokeAsync("GET_TRAN", New Object() {TR_ID}, Me.GET_TRANOperationCompleted, userState)
        End Sub
        
        Private Sub OnGET_TRANOperationCompleted(ByVal arg As Object)
            If (Not (Me.GET_TRANCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GET_TRANCompleted(Me, New GET_TRANCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/")>  _
    Partial Public Class CLS_RESULT
        
        Private cODEField As String
        
        Private fILENAMEField As String
        
        Private cHECK_RESULTField As String
        
        Private cHECK_RESULT_MSGField As String
        
        Private rEF_IDField As String
        
        '''<remarks/>
        Public Property CODE() As String
            Get
                Return Me.cODEField
            End Get
            Set
                Me.cODEField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property FILENAME() As String
            Get
                Return Me.fILENAMEField
            End Get
            Set
                Me.fILENAMEField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property CHECK_RESULT() As String
            Get
                Return Me.cHECK_RESULTField
            End Get
            Set
                Me.cHECK_RESULTField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property CHECK_RESULT_MSG() As String
            Get
                Return Me.cHECK_RESULT_MSGField
            End Get
            Set
                Me.cHECK_RESULT_MSGField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property REF_ID() As String
            Get
                Return Me.rEF_IDField
            End Get
            Set
                Me.rEF_IDField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")>  _
    Public Delegate Sub CONNECT_PDF_ECTDCompletedEventHandler(ByVal sender As Object, ByVal e As CONNECT_PDF_ECTDCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class CONNECT_PDF_ECTDCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As CLS_RESULT
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),CLS_RESULT)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")>  _
    Public Delegate Sub TESTCompletedEventHandler(ByVal sender As Object, ByVal e As TESTCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class TESTCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As CLS_RESULT
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),CLS_RESULT)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")>  _
    Public Delegate Sub GET_TRANCompletedEventHandler(ByVal sender As Object, ByVal e As GET_TRANCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GET_TRANCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As CLS_RESULT
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),CLS_RESULT)
            End Get
        End Property
    End Class
End Namespace