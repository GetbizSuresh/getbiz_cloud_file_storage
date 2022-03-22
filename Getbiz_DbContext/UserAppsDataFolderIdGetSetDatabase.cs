using getbiz_cloud_file_storage_app.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Getbiz_DbContext
{
    public class UserAppsDataFolderIdGetSetDatabase
    {
        public Response AddUserAppsDataFolderId(int file_id, string file_name, int file_type, DateTime file_created_timestamp, string file_storage_url)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            string connection = "Server=localhost;User ID=root;Password=mysql;Database=cloudfilestorageappdb; Allow User Variables=true";
            MySqlParameter[] param = new MySqlParameter[5];

            using MySqlConnection con = new MySqlConnection(connection);
            try
            {
                param[0] = new MySqlParameter("p_fileorFolder", MySqlDbType.Int64);
                param[0].Value = file_id;

                param[1] = new MySqlParameter("p_fileName", MySqlDbType.VarChar);
                param[1].Value = file_name;

                param[2] = new MySqlParameter("p_fileType", MySqlDbType.Int64);
                param[2].Value = file_type;

                param[3] = new MySqlParameter("p_filestorageUrl", MySqlDbType.VarChar);
                param[3].Value = file_storage_url;

                param[4] = new MySqlParameter("p_filecreatedTimestamp", MySqlDbType.DateTime);
                param[4].Value = file_created_timestamp;



                ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_CreateCloudFileStorageAppDynamicDb", param);
            }

            catch (Exception ex)
            {

            }
            return response;
        }
    }
}
