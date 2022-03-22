using getbiz_cloud_file_storage_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.User_Folders_Files
{
    public interface IUserFoldersFilesRepository
    {
        Response AddUserFoldersFiles(user_folders_files obj_user_folders_files);
        Response UpdateUserFoldersFiles(user_folders_files obj_user_folders_files);
        Response GetUserFolderFiles(string CustId, Int64 UserId, Int64 FileOrFolderId, Int64 FileId, Int64 FolderId);  
    }
}
