using getbiz_cloud_file_storage_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.Cloud_File_Storage_App_Registeration
{
    public interface ICloudFileStorageAppRegisterationRepository
    {

        Response CloudFileStorageAppRegisteration(cloud_file_storage_app_registeration obj_cloud_file_storage_app_registeration);
        Response GetAllCloudFileStorageAppRegisteration(string CustId);
        
        }
}
