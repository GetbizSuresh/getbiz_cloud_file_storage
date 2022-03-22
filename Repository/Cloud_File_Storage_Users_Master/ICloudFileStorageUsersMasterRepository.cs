using getbiz_cloud_file_storage_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.Cloud_File_Storage_Users_Master
{
    public interface ICloudFileStorageUsersMasterRepository
    {
        Response AddCloudFileStorageUsersMaster(cloud_file_storage_users_master obj_cloud_file_storage_users_master);
        Response GetAllCloudFileStorageUsersMaster(string CustId, int UserId);
        Response DeleteCloudFileStorageUsersMaster(string CustId, int UserId);
        Response UpdateCloudFileStorageUsersMaster(cloud_file_storage_users_master obj_cloud_file_storage_users_master);
    }
}

