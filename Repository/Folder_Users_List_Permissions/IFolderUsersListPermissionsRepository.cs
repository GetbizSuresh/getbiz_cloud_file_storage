using getbiz_cloud_file_storage_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace getbiz_cloud_file_storage_app.Repository.Folder_Users_List_Permissions
{
    public interface IFolderUsersListPermissionsRepository
    {
      
        Response AddFolderPermissions(folder_users_list_permissions obj_folder_users_list_permissions);
        Response UpdateFolderPermissions(folder_users_list_permissions obj_folder_permissions);
        Response GetFolderPermissions(string CustId, int FolerId,int UserId);
        Response DeleteUserForFolderPermissionsById(string CustId, int UserId,int FolderId);



    }
}
