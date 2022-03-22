using getbiz_cloud_file_storage_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.Userapp_New_User_Default_Storage_Limit
{
    public interface IUserappNewUserDefaultStorageLimitRepository
    {

        Response UpdateUserAppNewUserDefaultStorageLimit(userapp_new_user_default_storage_limit obj_userapp_new_user_default_storage_limit);
        Response GetUserAppNewUserDefaultStorageLimit(string CustId );
    }
}
