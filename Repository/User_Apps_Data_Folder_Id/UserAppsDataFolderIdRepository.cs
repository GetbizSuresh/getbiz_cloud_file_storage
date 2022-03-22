using getbiz_cloud_file_storage_app.Getbiz_DbContext;
using getbiz_cloud_file_storage_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.User_Apps_Data_Folder_Id
{
    public class UserAppsDataFolderIdRepository : IUserAppsDataFolderIdRepository
    {
        public readonly CloudFileStorageAppDB_DbContext _DbContext;
        public UserAppsDataFolderIdRepository(CloudFileStorageAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response AddUserAppsDataFolderId(user_apps_data_folder_id user_apps_data_folder_id)
        {
            Response response = new Response();
            try
            {
                UserAppsDataFolderIdGetSetDatabase userAppsDataFolderIdGetSetDatabase = new UserAppsDataFolderIdGetSetDatabase();
                var result = userAppsDataFolderIdGetSetDatabase.AddUserAppsDataFolderId(user_apps_data_folder_id.file_id, user_apps_data_folder_id.file_name,
                   user_apps_data_folder_id.file_type, DateTime.Now, user_apps_data_folder_id.file_storage_url);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error! While saving data";
            }
            return response;
        }
    }
}
