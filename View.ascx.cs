/*
' Copyright (c) 2014  University of Oklahoma - Human Resources
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
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;

namespace OUHR.Modules.FileExplorer
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from FileExplorerModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : FileExplorerModuleBase, IActionable
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    FileExplorerController.ShowHiddenFiles = ShowSystemFiles;
                    FileExplorerController.ShowSystemFiles = ShowSystemFiles;
                    if (!ShowHiddenFiles || !ShowSystemFiles)
                    {
                        FileExplorer1.Configuration.ContentProviderTypeName = typeof(DNNFileSystemContentProvider).AssemblyQualifiedName;
                    }
                    FileExplorer1.Configuration.SearchPatterns = SearchPatterns.Split('\n');
                    FileExplorer1.VisibleControls = GetVisibleControls();
                    FileExplorer1.EnableOpenFile = OpenFile;
                    FileExplorer1.DisplayUpFolderItem = DisplayUpFolder;
                    FileExplorer1.AllowPaging = AllowPaging;
                    FileExplorer1.EnableCreateNewFolder = CreateNewFolder;
                    if ((FileExplorer1.VisibleControls & Telerik.Web.UI.FileExplorer.FileExplorerControls.Grid) != 0 && (FileExplorer1.VisibleControls & Telerik.Web.UI.FileExplorer.FileExplorerControls.ListView) == 0)
                        FileExplorer1.ExplorerMode = Telerik.Web.UI.FileExplorer.FileExplorerMode.Thumbnails;
                    else
                        FileExplorer1.ExplorerMode = Telerik.Web.UI.FileExplorer.FileExplorerMode.Default;

                    if (!Upload)
                    {
                        FileExplorer1.Configuration.UploadPaths = new string[0];
                    }
                    else
                    {
                        FileExplorer1.Configuration.UploadPaths = new string[] { ResolveUrl(RootFolder) };
                        FileExplorer1.Configuration.DeletePaths = new string[] { ResolveUrl(RootFolder) };
                    }
                    if (!Delete)
                    {
                        FileExplorer1.Configuration.DeletePaths = new string[0];
                    }
                    else
                    {
                        FileExplorer1.Configuration.DeletePaths = new string[] { ResolveUrl(RootFolder) };
                    }
                    FileExplorer1.Configuration.ViewPaths = new string[] { ResolveUrl(RootFolder) };
                    if (!IsPostBack)
                    {
                        //Set initial folder to open. Note that the path is case sensitive!
                        //FileExplorer1.InitialPath = Page.ResolveUrl("~/FileExplorer/Examples/Overview/Images/Northwind/Flowers/Flower1.jpg");
                    }
                    divPreview.Visible = Preview;
                    divExplorer.Style["width"] = Preview ? "66%" : "100%";
                    FileExplorer1.OnClientItemSelected = Preview ? "OnClientItemSelected" : String.Empty;
                    FileExplorer1.OnClientDelete = Delete ? "OnClientDelete" : String.Empty;
                    FileExplorer1.Height = new System.Web.UI.WebControls.Unit(Height);
                    FileExplorer1.Skin = Skin;
                }                
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        protected Telerik.Web.UI.FileExplorer.FileExplorerControls GetVisibleControls()
        {
            Telerik.Web.UI.FileExplorer.FileExplorerControls explorerControls = 0;
            if (AddressBook)
                explorerControls |= Telerik.Web.UI.FileExplorer.FileExplorerControls.AddressBox;
            if (Grid)
                explorerControls |= Telerik.Web.UI.FileExplorer.FileExplorerControls.Grid;
            if (ListView)
                explorerControls |= Telerik.Web.UI.FileExplorer.FileExplorerControls.ListView;
            if (Toolbar)
                explorerControls |= Telerik.Web.UI.FileExplorer.FileExplorerControls.Toolbar;
            if (TreeView)
                explorerControls |= Telerik.Web.UI.FileExplorer.FileExplorerControls.TreeView;
            if (ContextMenus)
                explorerControls |= Telerik.Web.UI.FileExplorer.FileExplorerControls.ContextMenus;
            return explorerControls;
        }

        public ModuleActionCollection ModuleActions
        {
            get
            {
                return new DotNetNuke.Entities.Modules.Actions.ModuleActionCollection();
            }
        }
    }
}