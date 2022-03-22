using getbiz_cloud_file_storage_app.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Getbiz_DbContext
{
    public class UserRecentFilesGetSetDatabase
    {
        public Response AddUserRecentFiles(user_recent_files user_recent_files)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            string connection = "Server=localhost;User ID=root;Password=mysql;Database=cloudfilestorageappdb; Allow User Variables=true";
            MySqlParameter[] param = new MySqlParameter[2];

            using MySqlConnection con = new MySqlConnection(connection);
            try
            {
                param[0] = new MySqlParameter("p_fileId", MySqlDbType.VarChar);
                param[0].Value = user_recent_files.file_id;

                param[1] = new MySqlParameter("p_activityTimestamp", MySqlDbType.DateTime);
                param[1].Value = user_recent_files.activity_timestamp;


                ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_CreateCloudFileStorageAppDynamicDb", param);
            }

            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
