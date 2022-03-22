using getbiz_cloud_file_storage_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.File_Users_List_Permissions
{
    public interface IFileUsersListPermissionsRepository
    {
        public Response AddFilePermissions(file_users_list_permissions obj_file_permissions);
        public Response UpdateFilePermissions(file_users_list_permissions obj_file_permissions);
        public Response GetFilePermissions(string CustId, int FileId, int UserId);
        public Response DeleteUserForFilePermissionsById(string CustId, int FileId, int UserId);
    }
}
