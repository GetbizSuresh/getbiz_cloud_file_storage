using getbiz_cloud_file_storage_app.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Getbiz_DbContext
{
    public class UserNotificationsGetSetDatabase
    {
            public Response AddUserNotifications(bool file_or_folder, int file_or_folder_id,int user_id,string user_activity, DateTime activity_timestamp)
            {
            Response response = new Response();
            DataSet ds = new DataSet();

            string connection = "Server=localhost;User ID=root;Password=mysql;Database=cloudfilestorageappdb; Allow User Variables=true";
            MySqlParameter[] param = new MySqlParameter[5];

            using MySqlConnection con = new MySqlConnection(connection);
            try
            {
                param[0] = new MySqlParameter("p_fileorFolder", MySqlDbType.Bool);  
                param[0].Value = file_or_folder;

                param[1] = new MySqlParameter("p_fileorfolderId", MySqlDbType.Int64);
                param[1].Value = file_or_folder_id;

                param[2] = new MySqlParameter("p_userId", MySqlDbType.Int64);
                param[2].Value = user_id;

                param[3] = new MySqlParameter("p_userActivity", MySqlDbType.VarChar);
                param[3].Value = user_activity;

               

                param[4] = new MySqlParameter("p_activityTimestamp", MySqlDbType.DateTime);
                param[4].Value = activity_timestamp;


                ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_CreateCloudFileStorageAppDynamicDb", param);
            }

            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
