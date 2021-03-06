<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="Gafware.Modules.FileExplorer.Settings" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!-- uncomment the code below to start using the DNN Form pattern to create and update settings -->
<%@ Register TagName="label" TagPrefix="dnn" Src="~/controls/labelcontrol.ascx" %>
<h2 id="dnnSitePanel-BasicSettings" class="dnnFormSectionHead"><a href="" class="dnnSectionExpanded">Folder Settings</a></h2>
<fieldset>
    <div class="dnnFormItem">
        <dnn:Label ID="lblRootDirectory" runat="server" ResourceKey="lblRootDirectory" ControlName="tbRootDirectory" Suffix=":" /> 
        <asp:TextBox ID="tbRootDirectory" runat="server"></asp:TextBox>
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblSearchPatterns" runat="server" ResourceKey="lblSearchPatterns" ControlName="tbSearchPatterns" Suffix=":" /> 
        <asp:TextBox ID="tbSearchPatterns" TextMode="MultiLine" Rows="5" runat="server"></asp:TextBox>
    </div>
</fieldset>
<h2 id="dnnSitePanel-ExplorerControls" class="dnnFormSectionHead"><a href="" class="dnnSectionExpanded">Explorer Controls</a></h2>
<fieldset>
    <div class="dnnFormItem">
        <dnn:Label ID="lblVisibleControls" runat="server" ResourceKey="lblVisibleControls" ControlName="visibleControls" Suffix=":" /> 
        <asp:CheckBoxList Width="140px" ID="visibleControls" CellSpacing="0" runat="server">
            <asp:ListItem Selected="false" Text="Address Box" Value="AddressBox"></asp:ListItem>
            <asp:ListItem Selected="false" Text="Grid" Value="Grid"></asp:ListItem>
            <asp:ListItem Selected="false" Text="ListView" Value="ListView"></asp:ListItem>
            <asp:ListItem Selected="false" Text="Toolbar" Value="Toolbar"></asp:ListItem>
            <asp:ListItem Selected="false" Text="TreeView" Value="TreeView"></asp:ListItem>
            <asp:ListItem Selected="false" Text="Context Menus" Value="ContextMenus"></asp:ListItem>
        </asp:CheckBoxList>
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblHeight" runat="server" ResourceKey="lblHeight" ControlName="tbHeight" Suffix=":" /> 
        <telerik:RadNumericTextBox ID="tbHeight" MaxValue="9999" MinValue="50" runat="server" Width="50px" NumberFormat-DecimalDigits="0" />
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblSkin" runat="server" ResourceKey="lblSkin" ControlName="ddlSkin" Suffix=":" />
        <asp:DropDownList ID="ddlSkin" runat="server">
            <asp:ListItem Text="Default" Value="Default" Selected="True" />
            <asp:ListItem Text="Black" Value="Black" />
            <asp:ListItem Text="Sunset" Value="Sunset" />
            <asp:ListItem Text="Hay" Value="Hay" />
            <asp:ListItem Text="Forest" Value="Forest" />
            <asp:ListItem Text="Vista" Value="Vista" />
            <asp:ListItem Text="Metro" Value="Metro" />
            <asp:ListItem Text="MetroTouch" Value="MetroTouch" />
            <asp:ListItem Text="BlackMetroTouch" Value="BlackMetroTouch" />
            <asp:ListItem Text="Silk" Value="Silk" />
            <asp:ListItem Text="Glow" Value="Glow" />
            <asp:ListItem Text="Office2007" Value="Office2007" />
            <asp:ListItem Text="Office2010Black" Value="Office2010Black" />
            <asp:ListItem Text="Office2010Blue" Value="Office2010Blue" />
            <asp:ListItem Text="Office2010Silver" Value="Office2010Silver" />
            <asp:ListItem Text="Outlook" Value="Outlook" />
            <asp:ListItem Text="Simple" Value="Simple" />
            <asp:ListItem Text="Sitefinity" Value="Sitefinity" />
            <asp:ListItem Text="Telerik" Value="Telerik" />
            <asp:ListItem Text="Transparent" Value="Transparent" />
            <asp:ListItem Text="Web20" Value="Web20" />
            <asp:ListItem Text="WebBlue" Value="WebBlue" />
            <asp:ListItem Text="Windows7" Value="Windows7" />
        </asp:DropDownList>
    </div>
</fieldset>
<h2 id="dnnSitePanel-ControlBehavior" class="dnnFormSectionHead"><a href="" class="dnnSectionExpanded">Control Behavior</a></h2>
<fieldset>
    <div class="dnnFormItem">
        <dnn:Label ID="lblEnableUpload" runat="server" ResourceKey="lblEnableUpload" ControlName="enableUpload" />
        <asp:CheckBox ID="enableUpload" Width="130px" Checked="false" runat="server" Style="margin-left: 3px"></asp:CheckBox>
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblEnableDelete" runat="server" ResourceKey="lblEnableDelete" ControlName="enableDelete" />
        <asp:CheckBox ID="enableDelete" Width="130px" Checked="false" runat="server" Style="margin-left: 3px"></asp:CheckBox>
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblEnablePreview" runat="server" ResourceKey="lblEnablePreview" ControlName="enablePreview" />
        <asp:CheckBox ID="enablePreview" Width="130px" Checked="false" runat="server" Style="margin-left: 3px"></asp:CheckBox>
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblEnableCreateNewFolder" runat="server" ResourceKey="lblEnableCreateNewFolder" ControlName="enableCreateNewFolder" />
        <asp:CheckBox ID="enableCreateNewFolder" Width="130px" Checked="false" runat="server" Style="margin-left: 3px"></asp:CheckBox>
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblDisplayUpFolder" runat="server" ResourceKey="lblDisplayUpFolder" ControlName="displayUpFolder" />
        <asp:CheckBox ID="displayUpFolder" Width="160px" Checked="false" runat="server" Style="margin-left: 3px"></asp:CheckBox>
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblEnableOpenFile" runat="server" ResourceKey="lblEnableOpenFile" ControlName="enableOpenFile" />
        <asp:CheckBox ID="enableOpenFile" Width="165px" Checked="false" runat="server" Style="margin-left: 3px"></asp:CheckBox>
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblAllowPaging" runat="server" ResourceKey="lblAllowPaging" ControlName="allowPaging" />
        <asp:CheckBox ID="allowPaging" Width="165px" Checked="false" runat="server" Style="margin-left: 3px"></asp:CheckBox>
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblShowHiddenFiles" runat="server" ResourceKey="lblShowHiddenFiles" ControlName="showHiddenFiles" />
        <asp:CheckBox ID="showHiddenFiles" Width="165px" Checked="false" runat="server" Style="margin-left: 3px"></asp:CheckBox>
    </div>
    <div class="dnnFormItem">
        <dnn:Label ID="lblShowSystemFiles" runat="server" ResourceKey="lblShowSystemFiles" ControlName="showSystemFiles" />
        <asp:CheckBox ID="showSystemFiles" Width="165px" Checked="false" runat="server" Style="margin-left: 3px"></asp:CheckBox>
    </div>
</fieldset>
