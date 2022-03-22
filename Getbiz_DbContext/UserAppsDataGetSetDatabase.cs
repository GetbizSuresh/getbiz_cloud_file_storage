using getbiz_cloud_file_storage_app.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Getbiz_DbContext
{
    public class UserAppsDataGetSetDatabase
    {
        public Response AddUserAppsData(int user_apps_data_folder_id, int app_id, bool user_app_or_custom_app, DateTime folder_created_timestamp,
            bool can_delete_folder, bool can_delete_files, bool can_copy_files)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            string connection = "Server=localhost;User ID=root;Password=mysql;Database=cloudfilestorageappdb; Allow User Variables=true";
            MySqlParameter[] param = new MySqlParameter[7];

            using MySqlConnection con = new MySqlConnection(connection);
            try
            {
                param[0] = new MySqlParameter("p_userappsdatafolderId", MySqlDbType.Int64);
                param[0].Value = user_apps_data_folder_id;

                param[1] = new MySqlParameter("p_appId", MySqlDbType.Int64);
                param[1].Value = app_id;

                param[2] = new MySqlParameter("p_userapporcustomApp", MySqlDbType.Bool);
                param[2].Value = user_app_or_custom_app;

                param[3] = new MySqlParameter("p_foldercreatedTimestamp", MySqlDbType.DateTime);
                param[3].Value = folder_created_timestamp;

                param[4] = new MySqlParameter("p_candeleteFolder", MySqlDbType.Bool);
                param[4].Value = can_delete_folder;

                param[5] = new MySqlParameter("p_candeleteFiles", MySqlDbType.Bool);
                param[5].Value = can_delete_files;

                param[6] = new MySqlParameter("p_cancopyFiles", MySqlDbType.Bool);
                param[6].Value = can_copy_files;

                ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_CreateCloudFileStorageAppDynamicDb", param);
            }

            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
