Imports System
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports System.Xml


Public Class Class_fnc_generales
    Function gfnc_nulo(ByVal expresion, ByVal valor_nulo) As Object
        'Response.Write expresion
        'Response.end
        If IsDBNull(expresion) Or IsNothing(expresion) Then
            gfnc_nulo = valor_nulo
        ElseIf IsDate(expresion) Then
            gfnc_nulo = expresion
        ElseIf IsNumeric(expresion) Then
            gfnc_nulo = expresion
        ElseIf expresion = "" Then
            gfnc_nulo = expresion
        ElseIf CStr(expresion) = "&nbsp" Then
            gfnc_nulo = valor_nulo
        Else
            gfnc_nulo = expresion
        End If
    End Function

    Function gfnc_decode(ByVal a_valor, ByVal a_comp_1, ByVal a_ret_true, ByVal a_ret_false) As Object
        Dim lretorno

        If IsDBNull(a_valor) And IsDBNull(a_comp_1) Then
            lretorno = a_ret_true
        ElseIf IsDBNull(a_valor) Then
            a_valor = ""
            If a_valor.ToString = a_comp_1.ToString Then
                lretorno = a_ret_true
            Else
                lretorno = a_ret_false
            End If
        ElseIf a_valor.ToString = a_comp_1.ToString Then
            lretorno = a_ret_true
        Else
            lretorno = a_ret_false
        End If

        'If IsNumeric(a_valor) Then
        '    If IsNumeric(a_comp_1) Then
        '        If CDbl(a_valor) = CDbl(a_comp_1) Then
        '            lretorno = a_ret_true
        '        Else
        '            lretorno = a_ret_false
        '        End If
        '    ElseIf IsDate(a_comp_1) Then
        '        lretorno = a_ret_false
        '    Else
        '        If a_valor.ToString = a_comp_1.ToString Then
        '            lretorno = a_ret_true
        '        Else
        '            lretorno = a_ret_false
        '        End If
        '    End If
        'ElseIf IsDate(a_valor) Then
        '    If IsDate(a_comp_1) Then
        '        If a_valor = a_comp_1 Then
        '            lretorno = a_ret_true
        '        Else
        '            lretorno = a_ret_false
        '        End If
        '    Else
        '        If a_valor.ToString = a_comp_1.ToString Then
        '            lretorno = a_ret_true
        '        Else
        '            lretorno = a_ret_false
        '        End If
        '    End If
        'Else

        '    If a_valor.ToString = a_comp_1.ToString Then
        '        lretorno = a_ret_true
        '    Else
        '        lretorno = a_ret_false
        '    End If
        'End If
        gfnc_decode = lretorno
    End Function

    Function gfnc_ConectarBD(ByRef a_cnn As Oracle.ManagedDataAccess.Client.OracleConnection, ByRef ao_descripcion_error As String) As Long
        Dim ll_retorno As Long = 0
        Try
            a_cnn = New Oracle.ManagedDataAccess.Client.OracleConnection


            'Dim oradb As String = "Data Source=(DESCRIPTION=" _
            '           + "(ADDRESS=(PROTOCOL=TCP)(HOST=mssxlb01-vip)(PORT=1521))" _
            '           + "(ADDRESS=(PROTOCOL=TCP)(HOST=MSSXLB02-VIP)(PORT=1521))" _
            '           + "(LOAD_BALANCE = yes)" _
            '           + "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=segcer)));" _
            '           + "User Id=adhesion;Password=adhesion;"

            Dim oradb As String
            oradb = System.Configuration.ConfigurationManager.AppSettings("BDConnectString")

            'a_cnn.ConnectionString = "Data Source=SEGCER;User ID=prodssi;Password=zoyohezus;"

            a_cnn.ConnectionString = oradb
            a_cnn.Open()
        Catch ex As Exception
            ao_descripcion_error = ex.Message
            ll_retorno = Err.Number
        End Try
        gfnc_ConectarBD = ll_retorno
    End Function


    Function formato_fecha(ByVal xfecha, ByVal xformato) As String
        Dim xdia, xmes, xano, xhora, xminuto, xsegundo

        If IsDate(xfecha) Then
            xdia = CStr(Day(xfecha))
            xmes = CStr(Month(xfecha))
            xano = CStr(Year(xfecha))

            xhora = CStr(Hour(xfecha))
            xminuto = CStr(Minute(xfecha))
            xsegundo = CStr(Second(xfecha))
            Select Case xformato
                Case 1
                    If Len(xdia) < 2 Then xdia = "0" & xdia
                    If Len(xmes) < 2 Then xmes = "0" & xmes

                    xfecha = xdia & "/" & xmes & "/" & xano
                Case 2
                    If Len(xdia) < 2 Then xdia = "0" & xdia
                    If Len(xmes) < 2 Then xmes = "0" & xmes
                    If Len(xhora) < 2 Then xhora = "0" & xhora
                    If Len(xminuto) < 2 Then xminuto = "0" & xminuto
                    If Len(xsegundo) < 2 Then xsegundo = "0" & xsegundo

                    'xfecha = xdia & "/" & xmes & "/" & xano & " " &	xhora & ":" & xminuto
                    xfecha = xdia & "/" & xmes & "/" & xano & " " & xhora & ":" & xminuto & ":" & xsegundo
                Case 3
                    If Len(xdia) < 2 Then xdia = "0" & xdia
                    If Len(xmes) < 2 Then xmes = "0" & xmes
                    If Len(xhora) < 2 Then xhora = "0" & xhora
                    If Len(xminuto) < 2 Then xminuto = "0" & xminuto

                    xfecha = xdia & "/" & xmes & "/" & xano & " " & xhora & ":" & xminuto
                Case 4 'HH:MM
                    If Len(xdia) < 2 Then xdia = "0" & xdia
                    If Len(xmes) < 2 Then xmes = "0" & xmes
                    If Len(xhora) < 2 Then xhora = "0" & xhora
                    If Len(xminuto) < 2 Then xminuto = "0" & xminuto

                    xfecha = xhora & ":" & xminuto
                Case 5
                    If Len(xmes) < 2 Then xmes = "0" & xmes
                    xfecha = xmes & "/" & xano
                Case 6 'ddmmyyyy
                    If Len(xdia) < 2 Then xdia = "0" & xdia
                    If Len(xmes) < 2 Then xmes = "0" & xmes

                    xfecha = xdia & xmes & xano
                Case 7 'ddmmyyyy_hhmm
                    If Len(xdia) < 2 Then xdia = "0" & xdia
                    If Len(xmes) < 2 Then xmes = "0" & xmes
                    If Len(xhora) < 2 Then xhora = "0" & xhora
                    If Len(xminuto) < 2 Then xminuto = "0" & xminuto
                    If Len(xsegundo) < 2 Then xsegundo = "0" & xsegundo

                    xfecha = xdia & xmes & xano & "_" & xhora & xminuto
            End Select
            formato_fecha = xfecha
        Else
            formato_fecha = ""
        End If
    End Function

    Function fecha_nombre_DiaSemana(ByVal fecha As Date) As String
        Dim dia = fecha.DayOfWeek
        Select Case dia
            Case 1
                fecha_nombre_DiaSemana = "Lunes"
            Case 2
                fecha_nombre_DiaSemana = "Martes"
            Case 3
                fecha_nombre_DiaSemana = "Miercoles"
            Case 4
                fecha_nombre_DiaSemana = "Jueves"
            Case 5
                fecha_nombre_DiaSemana = "Viernes"
            Case 6
                fecha_nombre_DiaSemana = "Sabado"
            Case 0
                fecha_nombre_DiaSemana = "Domingo"
            Case Else
                fecha_nombre_DiaSemana = dia
        End Select
    End Function


    Function fecha_nombre_mes(ByVal fecha) As String
        Dim mes
        mes = Month(fecha)
        Select Case mes
            Case 1
                fecha_nombre_mes = "Enero"
            Case 2
                fecha_nombre_mes = "Febrero"
            Case 3
                fecha_nombre_mes = "Marzo"
            Case 4
                fecha_nombre_mes = "Abril"
            Case 5
                fecha_nombre_mes = "Mayo"
            Case 6
                fecha_nombre_mes = "Junio"
            Case 7
                fecha_nombre_mes = "Julio"
            Case 8
                fecha_nombre_mes = "Agosto"
            Case 9
                fecha_nombre_mes = "Septiembre"
            Case 10
                fecha_nombre_mes = "Octubre"
            Case 11
                fecha_nombre_mes = "Noviembre"
            Case 12
                fecha_nombre_mes = "Diciembre"
            Case Else
                fecha_nombre_mes = fecha
        End Select
    End Function

    Function vbString2JSString(ByVal expresion)
        vbString2JSString = expresion
        If Not IsDBNull(expresion) Or Trim(expresion) <> "" Then
            vbString2JSString = Replace(vbString2JSString, Chr(34), "'")
            vbString2JSString = Replace(vbString2JSString, "'", "\'")
            vbString2JSString = Replace(vbString2JSString, Chr(13), "")
            vbString2JSString = Replace(vbString2JSString, Chr(10), "\n")
        End If
    End Function

    'Function InvokeWebService(ByVal strSoap, ByVal strSOAPAction, ByVal strURL, ByRef xmlResponse)
    '    '*****************************************************************************
    '    ' Descripción: Invoca un WebService y obtiene su resultado.
    '    '
    '    ' Inputs:
    '    '	strSoap:		Petición HTTP a enviar, en formato SOAP. Contiene la	
    '    '				llamada al WebMethod y sus parámetros 
    '    '				correspondientes.
    '    '	strSOAPAction:	Namespace y nombre del WebMethod a utilizar.
    '    '	strURL:		URL del WebService.
    '    '
    '    ' Returns:
    '    '	La función retornará False si ha fallado la ejecución del WebService o si
    '    '	ha habido error en la comunicación con el servidor remoto. De lo contrario
    '    '	retornará True.
    '    '
    '    '	xmlResponse:	Respuesta obtenida desde el WebService, parseada 
    '    '				por el MSXML.
    '    '*****************************************************************************

    '    Dim xmlhttp As New MSXML2.XMLHTTP60
    '    Dim blnSuccess As Boolean

    '    'Creamos el objeto ServerXMLHTTP
    '    '	Set xmlhttp = Server.CreateObject("Msxml2.ServerXMLHTTP")
    '    'Abrimos la conexión con el método POST, ya que estamos enviando una
    '    'petición.

    '    xmlhttp.open("GET", strURL)

    '    'Agregamos encabezados HTTP requeridos por el WebService
    '    'xmlhttp.setRequestHeader("Man", "GET " & strURL & " HTTP/1.1")
    '    'xmlhttp.setRequestHeader("Content-Type", "text/xml; charset=utf-8")
    '    'xmlhttp.setRequestHeader("SOAPAction", strSOAPAction)

    '    xmlhttp.setRequestHeader("Man", "POST " & strURL & " HTTP/1.1")
    '    xmlhttp.setRequestHeader("SOAPAction", strSOAPAction)
    '    xmlhttp.setRequestHeader("Content-Type", "text/xml; charset=utf-8")
    '    xmlhttp.setRequestHeader("Host", "wsnet.mutual.cl")
    '    xmlhttp.setRequestHeader("Connection", "Keep(-Alive)")
    '    xmlhttp.setRequestHeader("User-Agent", "Apache-HttpClient/4.1.1 (java 1.5)")

    '    'El SOAPAction es importante ya que el WebService lo utilizará para
    '    'verificar qué WebMethod estamos usando en la operación.
    '    Try
    '        'Enviamos la petición
    '        xmlhttp.send(strSoap)
    '    Catch ex As Exception

    '    End Try

    '    'Verificamos el estado de la comunicación
    '    If xmlhttp.Status = 200 Then
    '        'El código 200 implica que la comunicación se puedo establecer y que
    '        'el WebService se ejecutó con éxito.
    '        blnSuccess = True
    '    Else
    '        'Si el código es distinto de 200, la comunicación falló o el
    '        'WebService provocó un Error.
    '        blnSuccess = False
    '    End If

    '    'Obtenemos la respuesta del servidor remoto, parseada por el MSXML.
    '    xmlResponse = xmlhttp.responseXML
    '    InvokeWebService = blnSuccess

    '    'Destruimos el objeto, acá no hay GarbageCollector ;)
    '    xmlhttp = Nothing
    'End Function

    Function limpiar_rut(rut)
        Dim i
        If gfnc_nulo(rut, "") = "" Then
            limpiar_rut = ""
        Else
            For i = 1 To Len(rut)
                If Mid(rut, i, 1) <> "-" Then
                    If IsNumeric(Mid(rut, i, 1)) Then
                        limpiar_rut = limpiar_rut & Mid(rut, i, 1)
                    End If
                Else
                    Exit For
                End If
            Next
        End If
    End Function

End Class
