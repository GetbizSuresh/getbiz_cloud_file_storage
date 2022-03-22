using getbiz_cloud_file_storage_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.User_Userapp_List_Of_Files_For_User_Apps_Folder_Id
{
    public interface IUserUserappListOfFilesForUserAppsFolderIdRepository
    {

        Response AddUserUserappListOfFilesForUserAppsFolderId(userapp_files_details_for_business_apps obj_userapp_files_details_for_business_apps, userapp_files_details_for_business_apps mainobj);
        Response GetAllUserappFilesDetailsForBusinessApps(string Cust_Id, Int64 User_Id, int App_Id, int User_Apps_Data_Folder_Id, string Mapping_Id);
        //  Response UpdateUserUserappListOfFilesForUserAppsFolderId(userapp_files_details_for_business_apps obj_userapp_files_details_for_business_apps);
        Response DeleteUserUserappListOfFilesForUserAppsFolderId(string Cust_Id, Int64 User_Id, Int64 App_Id, Int64 User_Apps_Data_Folder_Id, Int64 File_Id);
    }
}
