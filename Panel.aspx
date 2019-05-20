<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Panel.aspx.vb" Inherits="Panel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<style type="text/css">
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	overflow: hidden;
}
.Estilo2 {font-size: 14px; font-family: Arial, Helvetica, sans-serif;}
.Estilo5 {font-size: 12px; font-family: Arial, Helvetica, sans-serif; }
.Estilo6 {font-family: Arial, Helvetica, sans-serif}
</style>

<style type="text/css">
a:link {
	text-decoration: none;
	color: #000000;
}
a:visited {
	text-decoration: none;
}
a:hover {
	text-decoration: none;
	color: #FFFFFF;
}
a:active {
	text-decoration: none;
}
</style>

<script type="text/javascript">
    function jsOpcionMenu(a_opc) {
        switch (a_opc) {
            case 1: // Pagina 1
                {
                    document.location.href = 'SusesoNominativo/procesoGeneracionSisesat.aspx';
                    break;
                }
            case 2: // Pagina 2
                {
                    document.location.href = 'SusesoNominativo/procesoRevisionNominativo2.aspx';
                    break;
                }
            case 3: // Pagina 3
                {
                    document.location.href = 'SusesoNominativo/consultaNomina.aspx';
                    break;
                }
        }
    }
</script>

        <div style="position:relative; width:90%; height:500px;" >
            <div id="area_Menu" runat="server">
            </div>
        </div>

</asp:Content>

