using getbiz_cloud_file_storage_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.User_Apps_Data_Folder_Id
{
    public interface IUserAppsDataFolderIdRepository
    {
        Response AddUserAppsDataFolderId(user_apps_data_folder_id user_apps_data_folder_id);
    }
}
