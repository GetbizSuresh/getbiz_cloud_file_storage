using getbiz_cloud_file_storage_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.Userapp_Folder_Path
{
    public interface IUserappFolderPathRepository
    {


        Response UpdateFolderPath(userapp_folder_path obj_userapp_folder_path);
        Response GetUserAppFolderPath(string UserId);
    }
}
