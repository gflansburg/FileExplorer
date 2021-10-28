/*
' Copyright (c) 2021  Gafware
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;

namespace Gafware.Modules.FileExplorer
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Settings class manages Module Settings
    /// 
    /// Typically your settings control would be used to manage settings for your module.
    /// There are two types of settings, ModuleSettings, and TabModuleSettings.
    /// 
    /// ModuleSettings apply to all "copies" of a module on a site, no matter which page the module is on. 
    /// 
    /// TabModuleSettings apply only to the current module on the current page, if you copy that module to
    /// another page the settings are not transferred.
    /// 
    /// If you happen to save both TabModuleSettings and ModuleSettings, TabModuleSettings overrides ModuleSettings.
    /// 
    /// Below we have some examples of how to access these settings but you will need to uncomment to use.
    /// 
    /// Because the control inherits from FileExplorerSettingsBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class Settings : FileExplorerModuleSettingsBase
    {
        #region Base Method Implementations

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// LoadSettings loads the settings from the Database and displays them
        /// </summary>
        /// -----------------------------------------------------------------------------
        
        public override void LoadSettings()
        {
            try
            {
                if (Page.IsPostBack == false)
                {
                    //Check for existing settings and use those on this page
                    //Settings["SettingName"]

                    if (Settings.Contains("RootFolder"))
                        tbRootDirectory.Text = Settings["RootFolder"].ToString();

                    if (Settings.Contains("AddressBook"))
                        visibleControls.Items[0].Selected = Convert.ToBoolean(Settings["AddressBook"].ToString());
                    
                    if (Settings.Contains("Grid"))
                        visibleControls.Items[1].Selected = Convert.ToBoolean(Settings["Grid"].ToString());
                    
                    if (Settings.Contains("ListView"))
                        visibleControls.Items[2].Selected = Convert.ToBoolean(Settings["ListView"].ToString());
                    
                    if (Settings.Contains("Toolbar"))
                        visibleControls.Items[3].Selected = Convert.ToBoolean(Settings["Toolbar"].ToString());
                    
                    if (Settings.Contains("TreeView"))
                        visibleControls.Items[4].Selected = Convert.ToBoolean(Settings["TreeView"].ToString());
                    
                    if (Settings.Contains("ContextMenus"))
                        visibleControls.Items[5].Selected = Convert.ToBoolean(Settings["ContextMenus"].ToString());

                    if (Settings.Contains("OpenFile"))
                        enableOpenFile.Checked = Convert.ToBoolean(Settings["OpenFile"].ToString());
                    
                    if (Settings.Contains("DisplayUpFolder"))
                        displayUpFolder.Checked = Convert.ToBoolean(Settings["DisplayUpFolder"].ToString());
                    
                    if (Settings.Contains("AllowPaging"))
                        allowPaging.Checked = Convert.ToBoolean(Settings["AllowPaging"].ToString());
                    
                    if (Settings.Contains("CreateNewFolder"))
                        enableCreateNewFolder.Checked = Convert.ToBoolean(Settings["CreateNewFolder"].ToString());
                    
                    if (Settings.Contains("Upload"))
                        enableUpload.Checked = Convert.ToBoolean(Settings["Upload"].ToString());

                    if (Settings.Contains("Delete"))
                        enableDelete.Checked = Convert.ToBoolean(Settings["Delete"].ToString());

                    if (Settings.Contains("Preview"))
                        enablePreview.Checked = Convert.ToBoolean(Settings["Preview"].ToString());

                    if (Settings.Contains("ShowHiddenFiles"))
                        showHiddenFiles.Checked = Convert.ToBoolean(Settings["ShowHiddenFiles"].ToString());

                    if (Settings.Contains("ShowSystemFiles"))
                        showSystemFiles.Checked = Convert.ToBoolean(Settings["ShowSystemFiles"].ToString());

                    if (Settings.Contains("Height"))
                        tbHeight.Value = Convert.ToDouble(Settings["Height"].ToString());
                    else
                        tbHeight.Value = 520;

                    if (Settings.Contains("Skin"))
                        ddlSkin.SelectedValue = Settings["Skin"].ToString();

                    if (Settings.Contains("SearchPatterns"))
                        tbSearchPatterns.Text = Settings["SearchPatterns"].ToString();
                }
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpdateSettings saves the modified settings to the Database
        /// </summary>
        /// -----------------------------------------------------------------------------
        public override void UpdateSettings()
        {
            try
            {
                var modules = new ModuleController();

                //the following are two sample Module Settings, using the text boxes that are commented out in the ASCX file.
                //module settings
                //modules.UpdateModuleSetting(ModuleId, "Setting1", txtSetting1.Text);
                //modules.UpdateModuleSetting(ModuleId, "Setting2", txtSetting2.Text);

                //tab module settings
                modules.UpdateTabModuleSetting(TabModuleId, "RootFolder",  tbRootDirectory.Text);
                modules.UpdateTabModuleSetting(TabModuleId, "AddressBook",  visibleControls.Items[0].Selected.ToString());
                modules.UpdateTabModuleSetting(TabModuleId, "Grid",  visibleControls.Items[1].Selected.ToString());
                modules.UpdateTabModuleSetting(TabModuleId, "ListView",  visibleControls.Items[2].Selected.ToString());
                modules.UpdateTabModuleSetting(TabModuleId, "Toolbar",  visibleControls.Items[3].Selected.ToString());
                modules.UpdateTabModuleSetting(TabModuleId, "TreeView",  visibleControls.Items[4].Selected.ToString());
                modules.UpdateTabModuleSetting(TabModuleId, "ContextMenus",  visibleControls.Items[5].Selected.ToString());
                modules.UpdateTabModuleSetting(TabModuleId, "OpenFile",  enableOpenFile.Checked.ToString());
                modules.UpdateTabModuleSetting(TabModuleId, "DisplayUpFolder",  displayUpFolder.Checked.ToString());
                modules.UpdateTabModuleSetting(TabModuleId, "AllowPaging",  allowPaging.Checked.ToString());
                modules.UpdateTabModuleSetting(TabModuleId, "CreateNewFolder",  enableCreateNewFolder.Checked.ToString());
                modules.UpdateTabModuleSetting(TabModuleId, "Upload",  enableUpload.Checked.ToString());
                modules.UpdateTabModuleSetting(TabModuleId, "Delete",  enableDelete.Checked.ToString());
                modules.UpdateTabModuleSetting(TabModuleId, "Preview",  enablePreview.Checked.ToString());
                modules.UpdateTabModuleSetting(TabModuleId, "ShowHiddenFiles",  showHiddenFiles.Checked.ToString());
                modules.UpdateTabModuleSetting(TabModuleId, "ShowSystemFiles",  showSystemFiles.Checked.ToString());
                modules.UpdateTabModuleSetting(TabModuleId, "Height",  tbHeight.Value.ToString());
                modules.UpdateTabModuleSetting(TabModuleId, "Skin",  ddlSkin.SelectedValue);
                modules.UpdateTabModuleSetting(TabModuleId, "SearchPatterns",  tbSearchPatterns.Text);
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        #endregion
    }
}