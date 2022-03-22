using getbiz_cloud_file_storage_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.User_Notifications
{
    public interface IUserNotificationsRepository
    {
     
        Response GetUserNotificationsById(string CustId, Int64 UserId);
        Response GetUserNotificationsCountById(string CustId, Int64 UserId);

        Response UpdateNotificationStatus(user_notifications obj_user_notifications);
    }
}
