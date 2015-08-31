using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Web.UI.Widgets;

namespace OUHR.Modules.FileExplorer
{
    public class DNNFileSystemContentProvider : Telerik.Web.UI.Widgets.FileSystemContentProvider
    {
        public DNNFileSystemContentProvider(HttpContext context, string[] searchPatterns, string[] viewPaths, string[] uploadPaths, string[] deletePaths, string selectedUrl, string selectedItemTag)
            : base(context, searchPatterns, viewPaths, uploadPaths, deletePaths, selectedUrl, selectedItemTag)
        { }

        public override DirectoryItem ResolveDirectory(string path)  
        {  
            DirectoryItem originalFolder = base.ResolveDirectory(path);  
            FileItem[] originalFiles = originalFolder.Files;  
            List<FileItem> filteredFiles = new List<FileItem>();  
 
            // Filter the files  
            foreach (FileItem originalFile in originalFiles)  
            {  
                if (!this.IsFiltered(originalFolder, originalFile))  
                {  
                    filteredFiles.Add(originalFile);  
                }  
            }  
 
            DirectoryItem newFolder = new DirectoryItem(originalFolder.Name, originalFolder.Location, originalFolder.FullPath, originalFolder.Tag, originalFolder.Permissions, filteredFiles.ToArray(), originalFolder.Directories);  
 
            return newFolder;  
        }

        public override DirectoryItem ResolveRootDirectoryAsTree(string path)  
        {  
            DirectoryItem originalFolder = base.ResolveRootDirectoryAsTree(path);  
            DirectoryItem[] originalDirectories = originalFolder.Directories;  
            List<DirectoryItem> filteredDirectories = new List<DirectoryItem>();  
 
            // Filter the folders   
            foreach (DirectoryItem originalDir in originalDirectories)  
            {  
                if (!this.IsFiltered(originalFolder, originalDir))  
                {  
                    filteredDirectories.Add(originalDir);  
                }  
            }  
            DirectoryItem newFolder = new DirectoryItem(originalFolder.Name, originalFolder.Location, originalFolder.FullPath, originalFolder.Tag, originalFolder.Permissions, originalFolder.Files, filteredDirectories.ToArray());  
 
            return newFolder;  
        } 

        private bool IsFiltered(DirectoryItem oldItem, FileItem fileItem)  
        {  
            System.IO.FileInfo fInfo = new System.IO.FileInfo(Context.Server.MapPath(VirtualPathUtility.AppendTrailingSlash(oldItem.Path) + fileItem.Name));
            if ((fInfo.Attributes & System.IO.FileAttributes.System) == System.IO.FileAttributes.System)  
            {  
                return true;  
            }  
            if ((fInfo.Attributes & System.IO.FileAttributes.Hidden) == System.IO.FileAttributes.Hidden)
            {
                return true;
            }
            // else  
            return false;  
        } 

        private bool IsFiltered(DirectoryItem oldItem, DirectoryItem directoryItem)  
        {
            System.IO.FileInfo fInfo = new System.IO.FileInfo(Context.Server.MapPath(VirtualPathUtility.AppendTrailingSlash(oldItem.Path) + directoryItem.Name));
            if (!FileExplorerController.ShowSystemFiles)
            {
                if ((fInfo.Attributes & System.IO.FileAttributes.System) == System.IO.FileAttributes.System)
                {
                    return true;
                }
            }
            if (!FileExplorerController.ShowHiddenFiles)
            {
                if ((fInfo.Attributes & System.IO.FileAttributes.Hidden) == System.IO.FileAttributes.Hidden)
                {
                    return true;
                }
            }
            // else  
            return false;  
        } 
    }
}