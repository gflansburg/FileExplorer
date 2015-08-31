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
using DotNetNuke.Entities.Modules;

namespace OUHR.Modules.FileExplorer
{
    public class FileExplorerModuleBase : PortalModuleBase
    {
        public string RootFolder
        {
            get
            {
                if (Settings.Contains("RootFolder"))
                    return Settings["RootFolder"].ToString();
                return "~/";
            }
        }

        public bool AddressBook
        {
            get
            {
                if (Settings.Contains("AddressBook"))
                    return Convert.ToBoolean(Settings["AddressBook"].ToString());
                return false;
            }
        }

        public bool Grid
        {
            get
            {
                if (Settings.Contains("Grid"))
                    return Convert.ToBoolean(Settings["Grid"].ToString());
                return false;
            }
        }

        public bool ListView
        {
            get
            {
                if (Settings.Contains("ListView"))
                    return Convert.ToBoolean(Settings["ListView"].ToString());
                return false;
            }
        }


        public bool Toolbar
        {
            get
            {
                if (Settings.Contains("Toolbar"))
                    return Convert.ToBoolean(Settings["Toolbar"].ToString());
                return false;
            }
        }

        public bool TreeView
        {
            get
            {
                if (Settings.Contains("TreeView"))
                    return Convert.ToBoolean(Settings["TreeView"].ToString());
                return false;
            }
        }

        public bool ContextMenus
        {
            get
            {
                if (Settings.Contains("ContextMenus"))
                    return Convert.ToBoolean(Settings["ContextMenus"].ToString());
                return false;
            }
        }

        public bool OpenFile
        {
            get
            {
                if (Settings.Contains("OpenFile"))
                    return Convert.ToBoolean(Settings["OpenFile"].ToString());
                return false;
            }
        }

        public bool DisplayUpFolder
        {
            get
            {
                if (Settings.Contains("DisplayUpFolder"))
                    return Convert.ToBoolean(Settings["DisplayUpFolder"].ToString());
                return false;
            }
        }

        public bool AllowPaging
        {
            get
            {
                if (Settings.Contains("AllowPaging"))
                    return Convert.ToBoolean(Settings["AllowPaging"].ToString());
                return false;
            }
        }

        public bool CreateNewFolder
        {
            get
            {
                if (Settings.Contains("CreateNewFolder"))
                    return Convert.ToBoolean(Settings["CreateNewFolder"].ToString());
                return false;
            }
        }

        public bool Upload
        {
            get
            {
                if (Settings.Contains("Upload"))
                    return Convert.ToBoolean(Settings["Upload"].ToString());
                return false;
            }
        }

        public bool Delete
        {
            get
            {
                if (Settings.Contains("Delete"))
                    return Convert.ToBoolean(Settings["Delete"].ToString());
                return false;
            }
        }

        public bool Preview
        {
            get
            {
                if (Settings.Contains("Preview"))
                    return Convert.ToBoolean(Settings["Preview"].ToString());
                return false;
            }
        }

        public bool ShowHiddenFiles
        {
            get
            {
                if (Settings.Contains("ShowHiddenFiles"))
                    return Convert.ToBoolean(Settings["ShowHiddenFiles"].ToString());
                return false;
            }
        }

        public bool ShowSystemFiles
        {
            get
            {
                if (Settings.Contains("ShowSystemFiles"))
                    return Convert.ToBoolean(Settings["ShowSystemFiles"].ToString());
                return false;
            }
        }

        public int Height
        {
            get
            {
                if (Settings.Contains("Height"))
                    return  (int)(Convert.ToDouble(Settings["Height"].ToString()));
                return 520;
            }
        }

        public string Skin
        {
            get
            {
                if (Settings.Contains("Skin"))
                    return  Settings["Skin"].ToString();
                return "Default";
            }
        }

        public string SearchPatterns
        {
            get
            {
                if (Settings.Contains("SearchPatterns"))
                    return Settings["SearchPatterns"].ToString();
                return "*.*";
            }
        }
    }
}