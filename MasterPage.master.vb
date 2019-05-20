
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load
        If Session("sysSeguridad_CuentaUsuario") <> "" Then
            If IsPostBack Then
                If UrlPagina.Value <> "" Then
                    Session("sysAplicacion_TituloAPL") = TituloPagina.Value
                    Response.Redirect(UrlPagina.Value.ToString)
                End If
            End If

            If Session("sysAplicacion_TituloAPL") <> "" Then
                TituloAPL.InnerText = Session("sysAplicacion_TituloAPL")
            End If

            CuentaUsuario.InnerText = Session("sysSeguridad_CuentaUsuario")
        Else
            Response.Redirect("~\Enlace.aspx")
        End If
    End Sub

End Class

