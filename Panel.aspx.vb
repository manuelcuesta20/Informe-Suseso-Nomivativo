Imports System
Imports System.Data
Imports Oracle.ManagedDataAccess.Client
Imports Oracle.ManagedDataAccess.Types

Imports Constantes

Partial Class Panel
    Inherits System.Web.UI.Page

    Private Function lfnc_RecuperaPanelPerfilUsuario() As Long
        'Funciones generales--------------------------
        Dim lfnc_generales As New Class_fnc_generales
        'Store procedures-----------------------------
        'Dim lsp_VENTA_REFERIDOS As New Class_sp_VENTA_REFERIDOS
        '---------------------------------------------
        Dim lv_input(), lv_output()
        Dim ll_numero_error As Long = 0
        Dim ls_descripcion_error As String = ""

        Dim l_cursor As Oracle.ManagedDataAccess.Client.OracleDataReader = Nothing
        '---------------------------------------------
        Dim cnn As Oracle.ManagedDataAccess.Client.OracleConnection
        '---------------------------------------------
        ll_numero_error = lfnc_generales.gfnc_ConectarBD(cnn, ls_descripcion_error)

        If ll_numero_error = 0 Then

            Dim ls_html = ""
            ls_html = ls_html & "<table width=""350"" border=""0"" cellpadding=""0"" cellspacing=""1"" bordercolor=""#FFFFFF"">" & vbCrLf

            ls_html = ls_html & "<tr>" & vbCrLf
            ls_html = ls_html & "<td height=""34"" class=""txt_menu""><a href=""javascript:jsOpcionMenu(1);"">Generación Sisesat</a></td>" & vbCrLf
            ls_html = ls_html & "</tr>" & vbCrLf

            ls_html = ls_html & "<tr>" & vbCrLf
            ls_html = ls_html & "<td height=""34"" class=""txt_menu""><a href=""javascript:jsOpcionMenu(2);"">Revisión Nominativo</a></td>" & vbCrLf
            ls_html = ls_html & "</tr>" & vbCrLf

            ls_html = ls_html & "<tr>" & vbCrLf
            ls_html = ls_html & "<td height=""34"" class=""txt_menu""><a href=""javascript:jsOpcionMenu(3);"">Consulta Nomina</a></td>" & vbCrLf
            ls_html = ls_html & "</tr>" & vbCrLf

            ls_html = ls_html & "<tr>" & vbCrLf
            ls_html = ls_html & "<td>&nbsp;</td>" & vbCrLf
            ls_html = ls_html & "</tr>" & vbCrLf
            ls_html = ls_html & "</table>" & vbCrLf

            If ls_html <> "" Then
                area_Menu.InnerHtml = ls_html
            End If

        End If

        cnn.Close()
        lfnc_generales = Nothing
        cnn = Nothing
        lfnc_RecuperaPanelPerfilUsuario = ll_numero_error
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim lobj_TituloAPL As HtmlControl = Page.Master.FindControl("TituloAPL")
        ' Manipulate properties of control on master page
        ' with code on content page
        'lobj_TituloAPL.Attributes.Add("text", "Busqueda RECA")
        DirectCast(lobj_TituloAPL, System.Web.UI.HtmlControls.HtmlGenericControl).InnerHtml = "Panel SUSESO Nominativo"

        'Funciones generales--------------------------
        Dim lfnc_generales As New Class_fnc_generales
        '---------------------------------------------
        Dim ll_numero_error As Long = 0
        Dim ls_descripcion_error As String = ""
        Dim ls_mensaje As String = ""
        Dim ls_mensaje_colaborador As String = ""
        '---------------------------------------------
        Session.LCID = 1034

        If Session("sysSeguridad_CuentaUsuario") <> "" Then
            lfnc_RecuperaPanelPerfilUsuario()
        End If

        lfnc_generales = Nothing
    End Sub
End Class
