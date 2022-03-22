using getbiz_cloud_file_storage_app.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Getbiz_DbContext
{
    public class UserFoldersFilesGetSetDatabase
    {
            // string user_id,
        public Response AddUserFoldersFiles(string user_folder_file_storage_tree_id, bool file_or_folder,int file_or_folder_id, string Counder)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            string connection = "Server=localhost;User ID=root;Password=mysql;Database=cloudfilestorageappdb; Allow User Variables=true";
            MySqlParameter[] param = new MySqlParameter[3];

            using MySqlConnection con = new MySqlConnection(connection);
            try
            {
                param[0] = new MySqlParameter("p_userfolderfilestoragetreeId", MySqlDbType.VarChar);
                param[0].Value = user_folder_file_storage_tree_id;

                param[1] = new MySqlParameter("p_fileorFolder", MySqlDbType.Bool);
                param[1].Value = file_or_folder;

                param[2] = new MySqlParameter("p_fileorfolderId", MySqlDbType.Int32);
                param[2].Value = file_or_folder_id;

                param[3] = new MySqlParameter("p_Counder", MySqlDbType.VarChar);
                param[3].Value = Counder;

                ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_CreateCloudFileStorageAppDynamicDb", param);
            }

            catch (Exception ex)
            {
                                   
            }
            return response;
        }
    }
}