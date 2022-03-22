using getbiz_cloud_file_storage_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.User_App_New_User_Default_Storage_Log
{
    public interface IUserAppNewUserDefaultStorageLogRepository
    {
        Response GetAllUserAppNewUserDefaultStorageLog(string CustId);
        Response GetByIdUserAppNewUserDefaultStorageLog(string CustId, string UserId);
        Response DeleteByIdUserAppNewUserDefaultStorageLog(string CustId, string UserId);
    }
}
