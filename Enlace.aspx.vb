
Partial Class Enlace
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim ls_CuentaUsuario
            ls_CuentaUsuario = Request("CuentaUsuario")

            If ls_CuentaUsuario = "" Then
                ls_CuentaUsuario = "TestCodificacion"
            End If

            If ls_CuentaUsuario = "" Then
                    Dim ls_url_ori
                    ls_url_ori = System.Configuration.ConfigurationManager.AppSettings("UrlOrigen")

                    If ls_url_ori <> "" Then
                        'Response.Write(ls_url_ori)
                        'Response.Redirect(ls_url_ori)
                        Response.Write("<html><head><body></body></head></html>")
                    Else
                        Response.Write("<html><head><body></body></head></html>")

                    End If
                Else
                    Session("sysSeguridad_CuentaUsuario") = ls_CuentaUsuario
                    Response.Redirect("Panel.aspx")
                End If
            End If
    End Sub
End Class
