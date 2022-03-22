using getbiz_cloud_file_storage_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.User_Apps_Data
{
    public interface IUserappFolderDetailsForBusinessAppsRepository
    {
        Response AddUserappFolderDetailsForBusinessApps(userapp_folder_details_for_business_apps obj_userapp_folder_details_for_business_apps);
        Response InsertUserappFolderDetailsForBusinessApps(userapp_folder_details_for_business_apps obj_userapp_folder_details_for_business_apps);

        //     Response UpdateUserappFolderDetailsForBusinessApps(userapp_folder_details_for_business_apps obj_userapp_folder_details_for_business_apps);

        Response GetUserappFolderDetailsForBusinessAppsbyMappingParentBase(string CustId, Int64 UserId, Int64 AppId, string Mapping_Id);

        Response DeleteUserappFolderDetailsForBusinessAppsbyId(string CustId, Int64 UserId, Int64 AppId, Int64 UserAppsDataFolderId);
        
        }
}
