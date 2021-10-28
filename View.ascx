<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Gafware.Modules.FileExplorer.View" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<script language="javascript" type="text/javascript">
    function OnClientItemSelected(sender, args) {
         if(!args.get_item().isDirectory())
              previewImage(args.get_path());
    }
    function OnClientDelete(explorer, args) {
         previewImage("");
    }
 
    function previewImage(src) {
         var isImageSrc = src.match(/\.(gif|jpg|png)$/gi);
 
         var pvwImage = $get("pvwImage");
         pvwImage.src = src;
         pvwImage.style.display = isImageSrc ? "" : "none";
         pvwImage.alt = src.substring(src.lastIndexOf('/') + 1);
    }
</script>
<div id="divExplorer" runat="server" style="width: 66%; float: left">
    <telerik:RadFileExplorer runat="server" ID="FileExplorer1" Width="100%" Height="520px" />
</div>
<div id="divPreview" runat="server" style="width: 33%; float: right">
    <fieldset style="width: 100%; height: 220px; border: 1px solid gray; padding: 5px;">
        <legend>Preview</legend>
        <img id="pvwImage" src="" alt="" style="display: none; width: auto; height: 180px; vertical-align: middle;" />
    </fieldset>
</div>
<br style="clear: both" />