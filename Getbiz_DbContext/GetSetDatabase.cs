using getbiz_cloud_file_storage_app.Models;
using Humanizer.Bytes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using MySqlConnector;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Getbiz_DbContext
{
    public class GetSetDatabase
    {
        //  string connection = "Server=localhost;User ID=root;Password=mysql;Database=cloudfilestorageappdb; Allow User Variables=true";

        string connection = "Server=185.252.235.20;User ID=root;Password=GetBizMysqlDatabasePwd2021@;Database=cloudfilestorageappdb; Allow User Variables=true";

        public Response AddUserFoldersFiles(user_folders_files obj_user_folders_files)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[9];

            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_userfolderfilestoragetreeId", MySqlDbType.VarChar);
                    param[0].Value = obj_user_folders_files.user_folder_file_storage_tree_id;

                    param[1] = new MySqlParameter("p_fileorFolder", MySqlDbType.Bool);
                    param[1].Value = obj_user_folders_files.file_or_folder;

                    param[2] = new MySqlParameter("p_fileorfolderId", MySqlDbType.Int32);
                    param[2].Value = obj_user_folders_files.file_or_folder_id;

                    param[3] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                    param[3].Value = "Insert";


                    param[4] = new MySqlParameter("p_mapping_id", MySqlDbType.VarChar);
                    param[4].Value = obj_user_folders_files.mapping_id;

                    param[5] = new MySqlParameter("p_mapping_parent", MySqlDbType.VarChar);
                    param[5].Value = obj_user_folders_files.mapping_parent;

                    param[6] = new MySqlParameter("p_is_folder", MySqlDbType.Bool);
                    param[6].Value = obj_user_folders_files.is_folder;


                    param[7] = new MySqlParameter("p_userId", MySqlDbType.Int64);
                    param[7].Value = obj_user_folders_files.user_id;

                    param[8] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[8].Value = obj_user_folders_files.cust_id;



                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_InsertUserfolderfile", param);

                }
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                        {
                            response.Message = "Insert Userfolderfile  successfully !!";
                            response.Status = true;
                            response.Data = "";
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }
            }



            catch (Exception ex)
            {

            }
            return response;
        }


        public Response UpdateUserFoldersFiles(user_folders_files obj_user_folders_files)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[7];

            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {



                    param[1] = new MySqlParameter("p_fileorFolder", MySqlDbType.Bool);
                    param[1].Value = obj_user_folders_files.file_or_folder;

                    param[2] = new MySqlParameter("p_fileorfolderId", MySqlDbType.Int32);
                    param[2].Value = obj_user_folders_files.file_or_folder_id;

                    param[3] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                    param[3].Value = "Update";

                    param[4] = new MySqlParameter("p_mapping_parent", MySqlDbType.VarChar);
                    param[4].Value = obj_user_folders_files.mapping_parent;


                    param[5] = new MySqlParameter("p_userId", MySqlDbType.Int64);
                    param[5].Value = obj_user_folders_files.user_id;

                    param[6] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[6].Value = obj_user_folders_files.cust_id;



                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateUserfolderfile", param);

                }
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                        {
                            response.Message = "Update Userfolderfile  successfully !!";
                            response.Status = true;
                            response.Data = "";
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }
            }



            catch (Exception ex)
            {

            }
            return response;
        }






        public Response AddUserappFolderDetailsForBusinessApps(userapp_folder_details_for_business_apps obj_userapp_folder_details_for_business_apps)
        {
            Response response = new Response();
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            DataSet ds = new DataSet();
            DataSet di = new DataSet();


            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[0].Value = obj_userapp_folder_details_for_business_apps.created_by_user_id;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = obj_userapp_folder_details_for_business_apps.cust_id;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_GetUserAppsFolderMasterCount", param);
                }

                string Getuser_folders_count = ds.Tables[0].Rows[0]["user_folders_count"].ToString();

                if (Getuser_folders_count == "0")
                {
                   // var uniq_folder_id = Guid.NewGuid().ToString();

                    MySqlParameter[] param1 = new MySqlParameter[14];
                    try
                    {
                        using MySqlConnection con1 = new MySqlConnection(connection);
                        {
                            param1[0] = new MySqlParameter("p_folder_name", MySqlDbType.VarChar);
                            param1[0].Value = obj_userapp_folder_details_for_business_apps.folder_name;

                         

                            param1[1] = new MySqlParameter("p_mapping_id", MySqlDbType.VarChar);
                            param1[1].Value = obj_userapp_folder_details_for_business_apps.mapping_id;

                            param1[2] = new MySqlParameter("p_is_folder", MySqlDbType.Bool);
                            param1[2].Value = obj_userapp_folder_details_for_business_apps.is_folder;

                            param1[3] = new MySqlParameter("p_mapping_parent", MySqlDbType.VarChar);
                            param1[3].Value = obj_userapp_folder_details_for_business_apps.mapping_parent;

                            param1[4] = new MySqlParameter("p_multiuser_folder_access", MySqlDbType.Bool);
                            param1[4].Value = obj_userapp_folder_details_for_business_apps.multiuser_folder_access;

                            param1[5] = new MySqlParameter("p_created_by_user_id", MySqlDbType.Int64);
                            param1[5].Value = obj_userapp_folder_details_for_business_apps.created_by_user_id;

                            param1[6] = new MySqlParameter("p_folder_size", MySqlDbType.Int64);
                            param1[6].Value = obj_userapp_folder_details_for_business_apps.folder_size;

                            param1[7] = new MySqlParameter("p_created_timestamp", MySqlDbType.VarChar);
                            param1[7].Value = obj_userapp_folder_details_for_business_apps.created_timestamp;

                            param1[8] = new MySqlParameter("p_deleted_status", MySqlDbType.Bool);
                            param1[8].Value = obj_userapp_folder_details_for_business_apps.deleted_status;

                            param1[9] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                            param1[9].Value = "User_folders_count_More_Then_Zero";

                            param1[10] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                            param1[10].Value = obj_userapp_folder_details_for_business_apps.cust_id;

                            param1[11] = new MySqlParameter("P_user_apps_data_folder_id", MySqlDbType.Int64);
                            param1[11].Value = obj_userapp_folder_details_for_business_apps.user_apps_data_folder_id;

                            param1[12] = new MySqlParameter("p_shared_user_id", MySqlDbType.Int64);
                            param1[12].Value = obj_userapp_folder_details_for_business_apps.shared_user_id;

                           
                            param1[13] = new MySqlParameter("p_file_or_folder", MySqlDbType.Int64);
                            param1[13].Value = obj_userapp_folder_details_for_business_apps.file_or_folder;


                            ds1 = SqlHelpher.ExecuteDataset(con1, CommandType.StoredProcedure, "SP_InsertUserappFolderDetailsForBusinessApp", param1);
                        }
                    }
                    catch (Exception ex)
                    {


                    }

                    string Get_Max_Id = ds1.Tables[0].Rows[0]["MaxId"].ToString();



                        MySqlParameter[] param2 = new MySqlParameter[15];
                    try
                    {
                        using MySqlConnection con2 = new MySqlConnection(connection);
                        {
                            param2[0] = new MySqlParameter("p_folder_name", MySqlDbType.VarChar);
                            param2[0].Value = obj_userapp_folder_details_for_business_apps.folder_name;



                            param2[1] = new MySqlParameter("p_mapping_id", MySqlDbType.VarChar);
                            param2[1].Value = obj_userapp_folder_details_for_business_apps.mapping_id;

                            param2[2] = new MySqlParameter("p_is_folder", MySqlDbType.Bool);
                            param2[2].Value = obj_userapp_folder_details_for_business_apps.is_folder;

                            param2[3] = new MySqlParameter("p_mapping_parent", MySqlDbType.VarChar);
                            param2[3].Value = obj_userapp_folder_details_for_business_apps.mapping_parent;

                            param2[4] = new MySqlParameter("p_multiuser_folder_access", MySqlDbType.Bool);
                            param2[4].Value = obj_userapp_folder_details_for_business_apps.multiuser_folder_access;

                            param2[5] = new MySqlParameter("p_created_by_user_id", MySqlDbType.Int64);
                            param2[5].Value = obj_userapp_folder_details_for_business_apps.created_by_user_id;

                            param2[6] = new MySqlParameter("p_folder_size", MySqlDbType.Int64);
                            param2[6].Value = obj_userapp_folder_details_for_business_apps.folder_size;

                            param2[7] = new MySqlParameter("p_created_timestamp", MySqlDbType.VarChar);
                            param2[7].Value = obj_userapp_folder_details_for_business_apps.created_timestamp;

                            param2[8] = new MySqlParameter("p_deleted_status", MySqlDbType.Bool);
                            param2[8].Value = obj_userapp_folder_details_for_business_apps.deleted_status;

                            param2[9] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                            param2[9].Value = "User_folders_count_More_Then_Zero";

                            param2[10] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                            param2[10].Value = obj_userapp_folder_details_for_business_apps.cust_id;

                            param2[11] = new MySqlParameter("p_folder_id", MySqlDbType.VarChar);
                            param1[11].Value = obj_userapp_folder_details_for_business_apps.user_apps_data_folder_id;

                            param2[12] = new MySqlParameter("p_shared_user_id", MySqlDbType.Int64);
                            param2[12].Value = obj_userapp_folder_details_for_business_apps.shared_user_id;


                            param2[13] = new MySqlParameter("p_file_or_folder", MySqlDbType.Int64);
                            param2[13].Value = obj_userapp_folder_details_for_business_apps.file_or_folder;

                            param2[14] = new MySqlParameter("p_Max_Id", MySqlDbType.Int64);
                            param2[14].Value = Get_Max_Id;


                            ds2 = SqlHelpher.ExecuteDataset(con2, CommandType.StoredProcedure, "SP_InsertUserappFolderDetailsForBusinessApps", param2);
                        }
                    }
                    catch (Exception ex)
                    {


                    }

                    if (Convert.ToString(ds2.Tables[0].Rows[0]["Message"]) == "200")
                    {

                        response.Data = "";
                        response.Message = "Inserted successfully";
                        response.Status = true;
                    }
                    return response;
                }
                else
                {
                    response.Data = "";
                    response.Message = "User App Data Folder Already Created !!";
                    response.Status = false;
                }
            }

            catch (Exception ex)
            {

            }
            return response;
        }





        public Response Addfoldermaster(folders_master obj_folders_master)
        {
            Response response = new Response();
            DataSet dsetfm = new DataSet();
            DataSet dsetmaxid = new DataSet();
            MySqlParameter[] param = new MySqlParameter[8];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_folder_name", MySqlDbType.VarChar);
                    param[0].Value = obj_folders_master.folder_name;

                    param[1] = new MySqlParameter("p_multiuser_folder_access", MySqlDbType.Bool);
                    param[1].Value = obj_folders_master.multiuser_folder_access;

                    param[2] = new MySqlParameter("p_created_by_user_id", MySqlDbType.Int64);
                    param[2].Value = obj_folders_master.created_by_user_id;

                    param[3] = new MySqlParameter("p_folder_size", MySqlDbType.Int64);
                    param[3].Value = obj_folders_master.folder_size;

                    param[4] = new MySqlParameter("p_created_timestamp", MySqlDbType.VarChar);
                    param[4].Value = obj_folders_master.created_timestamp;

                    param[5] = new MySqlParameter("p_deleted_status", MySqlDbType.Bool);
                    param[5].Value = obj_folders_master.deleted_status;

                    param[6] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                    param[6].Value = "insert";

                    param[7] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[7].Value = obj_folders_master.cust_id;


                    dsetfm = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_InsertFolderMaster", param);

                }



                if (dsetfm.Tables.Count > 0)
                {
                    if (dsetfm.Tables[0].Rows.Count > 0)
                    {
                        MySqlParameter[] param3 = new MySqlParameter[7];

                        string GetMaxId = dsetfm.Tables[0].Rows[0]["MaxId"].ToString();
                        using MySqlConnection con3 = new MySqlConnection(connection);
                        {
                            param3[0] = new MySqlParameter("p_Maxid", MySqlDbType.Int64);
                            param3[0].Value = GetMaxId;

                            param3[1] = new MySqlParameter("p_created_by_user_id", MySqlDbType.Int64);
                            param3[1].Value = obj_folders_master.created_by_user_id;

                            param3[2] = new MySqlParameter("p_created_timestamp", MySqlDbType.VarChar);
                            param3[2].Value = obj_folders_master.created_timestamp;

                            param3[3] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                            param3[3].Value = obj_folders_master.cust_id;


                            param3[4] = new MySqlParameter("p_is_folder", MySqlDbType.Bool);
                            param3[4].Value = obj_folders_master.is_folder;

                            param3[5] = new MySqlParameter("p_mapping_id", MySqlDbType.VarChar);
                            param3[5].Value = obj_folders_master.mapping_id;

                            param3[6] = new MySqlParameter("p_mapping_parent", MySqlDbType.VarChar);
                            param3[6].Value = obj_folders_master.mapping_parent;

                            dsetmaxid = SqlHelpher.ExecuteDataset(con3, CommandType.StoredProcedure, "SP_InsertDynamicFolderUserPermission", param3);
                        }


                        if (Convert.ToString(dsetmaxid.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";
                            response.Message = "Inserted successfully";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(dsetmaxid.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(dsetmaxid.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }
            }

            catch (Exception ex)
            {

            }
            return response;
        }
        public Response AddFilesMaster(files_master obj_files_master, files_master mainobj)
        {
            Response response = new Response();
            DataSet dsetfm = new DataSet();
            DataSet dsetmaxid = new DataSet();

            MySqlParameter[] param = new MySqlParameter[10];
            try
            {
                // var filepath = JsonConvert.SerializeObject(mainobj.file_storage_url);


                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_file_name", MySqlDbType.VarChar); //VarChar
                    param[0].Value = obj_files_master.file_name;

                    param[1] = new MySqlParameter("p_multiuser_file_access", MySqlDbType.Bool);
                    param[1].Value = obj_files_master.multiuser_file_access;

                    param[2] = new MySqlParameter("p_file_type", MySqlDbType.VarChar);
                    param[2].Value = obj_files_master.file_type;

                    param[3] = new MySqlParameter("p_uploaded_created_by_user_id", MySqlDbType.Int64);
                    param[3].Value = obj_files_master.uploaded_created_by_user_id;

                    param[4] = new MySqlParameter("p_file_storage_url", MySqlDbType.VarChar);
                    param[4].Value = mainobj.file_storage_url;

                    param[5] = new MySqlParameter("p_uploaded_created_timestamp", MySqlDbType.VarChar);
                    param[5].Value = obj_files_master.uploaded_created_timestamp;

                    param[6] = new MySqlParameter("p_file_size", MySqlDbType.Decimal);
                    param[6].Value = obj_files_master.file_size;

                    param[7] = new MySqlParameter("p_deleted_status", MySqlDbType.Bool);
                    param[7].Value = obj_files_master.deleted_status;

                    param[8] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                    param[8].Value = "Insert";

                    param[9] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[9].Value = obj_files_master.cust_id;


                    dsetfm = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_InsertFilesMaster", param);

                }
                if (dsetfm.Tables.Count > 0)
                {
                    if (dsetfm.Tables[0].Rows.Count > 0)
                    {
                        MySqlParameter[] param1 = new MySqlParameter[7];

                        string GetMaxId = dsetfm.Tables[0].Rows[0]["MaxId"].ToString();
                        using MySqlConnection con1 = new MySqlConnection(connection);
                        {
                            param1[0] = new MySqlParameter("p_Maxid", MySqlDbType.Int64);
                            param1[0].Value = GetMaxId;

                            param1[1] = new MySqlParameter("p_created_by_user_id", MySqlDbType.Int64);
                            param1[1].Value = obj_files_master.uploaded_created_by_user_id;

                            param1[2] = new MySqlParameter("p_uploaded_created_timestamp", MySqlDbType.VarChar);
                            param1[2].Value = obj_files_master.uploaded_created_timestamp;

                            param1[3] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                            param1[3].Value = obj_files_master.cust_id;

                            param1[4] = new MySqlParameter("p_mapping_id", MySqlDbType.VarChar);
                            param1[4].Value = obj_files_master.mapping_id;

                            param1[5] = new MySqlParameter("P_is_folder", MySqlDbType.Bool);
                            param1[5].Value = obj_files_master.is_folder;

                            param1[6] = new MySqlParameter("p_mapping_parent", MySqlDbType.VarChar);
                            param1[6].Value = obj_files_master.mapping_parent;

                            dsetmaxid = SqlHelpher.ExecuteDataset(con1, CommandType.StoredProcedure, "SP_InsertDynamicFileUserPermission", param1);
                        }
                        if (Convert.ToString(dsetmaxid.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";
                            response.Message = "Inserted successfully";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message ="failure .. !!";
                            response.Status = Convert.ToInt32(dsetmaxid.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }

                    }
                }

                else
                {
                    response.Message = "data faild to insert ..!!";
                }
            }

            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = Convert.ToInt32(dsetmaxid.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
            }
            return response;
        }
        public Response Updatefolderpermissions(folder_users_list_permissions obj_folder_permissions)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[13];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {


                    param[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[0].Value = obj_folder_permissions.user_id;

                    param[1] = new MySqlParameter("p_user_added_timestamp", MySqlDbType.VarChar);
                    param[1].Value = obj_folder_permissions.user_added_timestamp;

                    param[2] = new MySqlParameter("p_user_removed_timestamp", MySqlDbType.VarChar);
                    param[2].Value = obj_folder_permissions.user_removed_timestamp;

                    param[3] = new MySqlParameter("p_folder_admin", MySqlDbType.Bool);
                    param[3].Value = obj_folder_permissions.folder_admin;

                    param[4] = new MySqlParameter("p_access_recent_no_of_files", MySqlDbType.Int64);
                    param[4].Value = obj_folder_permissions.access_recent_no_of_files;

                    param[5] = new MySqlParameter("p_upload_folder", MySqlDbType.Bool);
                    param[5].Value = obj_folder_permissions.upload_folder;

                    param[6] = new MySqlParameter("p_rename_folder", MySqlDbType.Bool);
                    param[6].Value = obj_folder_permissions.rename_folder;

                    param[7] = new MySqlParameter("p_download_folder", MySqlDbType.Bool);
                    param[7].Value = obj_folder_permissions.download_folder;

                    param[8] = new MySqlParameter("p_copy_folder", MySqlDbType.Bool);
                    param[8].Value = obj_folder_permissions.copy_folder;

                    param[9] = new MySqlParameter("p_share_folder", MySqlDbType.Bool);
                    param[9].Value = obj_folder_permissions.share_folder;

                    param[10] = new MySqlParameter("p_folder_activity_notification", MySqlDbType.Bool);
                    param[10].Value = obj_folder_permissions.folder_activity_notification;

                    param[11] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[11].Value = obj_folder_permissions.cust_id;

                    param[12] = new MySqlParameter("p_folder_id", MySqlDbType.Int64);
                    param[12].Value = obj_folder_permissions.folder_id;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_Updatefolderpermissions", param);

                }
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                        {
                            response.Message = "Update  folderpermissions  successfully";
                            response.Status = true;
                            response.Data = "";
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }

            }

            catch (Exception ex)
            {

            }
            return response;
        }
        public Response Updatefilepermissions(file_users_list_permissions obj_file_permissions)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[12];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[0].Value = obj_file_permissions.user_id;

                    param[1] = new MySqlParameter("p_user_added_timestamp", MySqlDbType.VarChar);
                    param[1].Value = obj_file_permissions.user_added_timestamp;

                    param[2] = new MySqlParameter("p_user_removed_timestamp", MySqlDbType.VarChar);
                    param[2].Value = obj_file_permissions.user_removed_timestamp;

                    param[3] = new MySqlParameter("p_file_admin", MySqlDbType.Bool);
                    param[3].Value = obj_file_permissions.file_admin;

                    param[4] = new MySqlParameter("p_edit_file", MySqlDbType.Bool);
                    param[4].Value = obj_file_permissions.edit_file;

                    param[5] = new MySqlParameter("p_rename_file", MySqlDbType.Bool);
                    param[5].Value = obj_file_permissions.rename_file;

                    param[6] = new MySqlParameter("p_download_file", MySqlDbType.Bool);
                    param[6].Value = obj_file_permissions.download_file;

                    param[7] = new MySqlParameter("p_copy_file", MySqlDbType.Bool);
                    param[7].Value = obj_file_permissions.copy_file;

                    param[8] = new MySqlParameter("p_share_file", MySqlDbType.Bool);
                    param[8].Value = obj_file_permissions.share_file;

                    param[9] = new MySqlParameter("p_file_activity_notifications_requested", MySqlDbType.Bool);
                    param[9].Value = obj_file_permissions.file_activity_notifications_requested;

                    param[10] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[10].Value = obj_file_permissions.cust_id;

                    param[11] = new MySqlParameter("p_file_id", MySqlDbType.Int64);
                    param[11].Value = obj_file_permissions.file_id;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_Updatefilepermissions", param);

                }
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //GetAll
                        if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";
                            response.Message = "Update file permissions successfully";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }

            }

            catch (Exception ex)
            {

            }
            return response;
        }
        public Response DeleteFileMaster(files_master obj_files_master)
        {
            Response response = new Response();
            DataSet dsetfm = new DataSet();
            DataSet dsetfm1 = new DataSet();
            DataSet dsetfm2 = new DataSet();


            MySqlParameter[] param = new MySqlParameter[3];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_file_id", MySqlDbType.Int64);
                    param[0].Value = obj_files_master.file_id;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = obj_files_master.cust_id;

                    param[2] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                    param[2].Value = "SelectDeleteFileUserIds";

                    dsetfm = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_SelectDeleteFileUserIds", param);

                }


                // if (ds.Tables[0].Rows.Count > 0)



                if (dsetfm.Tables[0].Rows.Count > 0)
                {
                    string getdata1 = dsetfm.Tables[0].Rows[0]["DeleteFileUserIds"].ToString();
                    if (!string.IsNullOrEmpty(getdata1))
                    {
                        int checkrow = dsetfm.Tables.Count;
                        if (checkrow > 0)
                        {

                            int checkrowcount = dsetfm.Tables[0].Rows.Count;
                            for (int i = 0; i < checkrowcount; i++)

                            {
                                MySqlParameter[] param1 = new MySqlParameter[5];
                                try
                                {
                                    string getdata = dsetfm.Tables[0].Rows[i]["DeleteFileUserIds"].ToString();

                                    using MySqlConnection con1 = new MySqlConnection(connection);
                                    {

                                        param1[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                                        param1[0].Value = obj_files_master.uploaded_created_by_user_id;

                                        param1[1] = new MySqlParameter("p_file_id", MySqlDbType.Int64);
                                        param1[1].Value = obj_files_master.file_id;

                                        param1[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                        param1[2].Value = obj_files_master.cust_id;

                                        param1[3] = new MySqlParameter("p_DeleteFileUserIds", MySqlDbType.VarChar);
                                        param1[3].Value = dsetfm.Tables[0].Rows[i]["DeleteFileUserIds"].ToString();

                                        param1[4] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                                        param1[4].Value = "DeleteFilesAllUserFileAndFolderTable";

                                        dsetfm1 = SqlHelpher.ExecuteDataset(con1, CommandType.StoredProcedure, "SP_DeleteFileMasters", param1);
                                    }

                                    if (dsetfm1.Tables.Count > 0)
                                    {
                                        if (dsetfm1.Tables[0].Rows.Count > 0)
                                        {
                                            if (Convert.ToString(dsetfm1.Tables[0].Rows[0]["Message"]) == "200")
                                            {
                                                response.Data = "";
                                                response.Message = "Deleted successfully";
                                                response.Status = true;
                                            }
                                            else
                                            {
                                                response.Message = Convert.ToString(dsetfm1.Tables[0].Rows[0]["Message"]);
                                                response.Status = Convert.ToInt32(dsetfm1.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                                            }

                                        }
                                    }


                                }
                                catch (Exception ex)
                                {
                                }
                            }
                            return response;
                        }

                    }
                }

                else
                {

                    MySqlParameter[] param2 = new MySqlParameter[4];
                    try
                    {

                        using MySqlConnection con2 = new MySqlConnection(connection);
                        {

                            param2[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                            param2[0].Value = obj_files_master.uploaded_created_by_user_id;

                            param2[1] = new MySqlParameter("p_file_id", MySqlDbType.Int64);
                            param2[1].Value = obj_files_master.file_id;

                            param2[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                            param2[2].Value = obj_files_master.cust_id;


                            param2[3] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                            param2[3].Value = "UpdateFileDeleteStatus";

                            dsetfm2 = SqlHelpher.ExecuteDataset(con2, CommandType.StoredProcedure, "SP_UpdateFileDeleteStatuss", param2);

                        }
                        if (dsetfm2.Tables.Count > 0)
                        {
                            if (dsetfm2.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToString(dsetfm2.Tables[0].Rows[0]["Message"]) == "200")
                                {
                                    response.Data = "";
                                    response.Message = "Deleted successfully";
                                    response.Status = true;
                                }
                                else
                                {
                                    response.Message = Convert.ToString(dsetfm2.Tables[0].Rows[0]["Message"]);
                                    response.Status = Convert.ToInt32(dsetfm2.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                                }

                            }
                        }

                    }
                    catch (Exception ex)
                    {
                    }

                }
            }
            catch (Exception ex)
            {
            }

            return response;
        }


        public Response DeleteFoldersMaster(folders_master obj_folders_master)
        {
            Response response = new Response();
            DataSet dsetfm = new DataSet();
            DataSet dsetfm1 = new DataSet();
            DataSet dsetfm2 = new DataSet();


            MySqlParameter[] param = new MySqlParameter[3];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_folder_id", MySqlDbType.Int64);
                    param[0].Value = obj_folders_master.folder_id;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = obj_folders_master.cust_id;

                    param[2] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                    param[2].Value = "SelectDeleteFolderUserIds";

                    dsetfm = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_SelectDeleteFolderUserIds", param);

                }


                if (dsetfm.Tables[0].Rows.Count > 0)
                {
                    string getdata1 = dsetfm.Tables[0].Rows[0]["DeleteFolderUserIds"].ToString();
                    if (!string.IsNullOrEmpty(getdata1))
                    {
                        int checkrow = dsetfm.Tables.Count;
                        if (checkrow > 0)
                        {

                            int checkrowcount = dsetfm.Tables[0].Rows.Count;
                            for (int i = 0; i < checkrowcount; i++)

                            {
                                MySqlParameter[] param1 = new MySqlParameter[5];
                                try
                                {
                                    string getdata = dsetfm.Tables[0].Rows[i]["DeleteFolderUserIds"].ToString();

                                    using MySqlConnection con1 = new MySqlConnection(connection);
                                    {

                                        param1[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                                        param1[0].Value = obj_folders_master.created_by_user_id;

                                        param1[1] = new MySqlParameter("p_folder_id", MySqlDbType.Int64);
                                        param1[1].Value = obj_folders_master.folder_id;

                                        param1[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                        param1[2].Value = obj_folders_master.cust_id;

                                        param1[3] = new MySqlParameter("p_DeleteFolderUserIds", MySqlDbType.VarChar);
                                        param1[3].Value = dsetfm.Tables[0].Rows[i]["DeleteFolderUserIds"].ToString();

                                        param1[4] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                                        param1[4].Value = "DeleteFoldersAllUserFileAndFolderTable";

                                        dsetfm1 = SqlHelpher.ExecuteDataset(con1, CommandType.StoredProcedure, "SP_DeleteFolderMasters", param1);
                                    }

                                    if (dsetfm1.Tables.Count > 0)
                                    {
                                        if (dsetfm1.Tables[0].Rows.Count > 0)
                                        {
                                            if (Convert.ToString(dsetfm1.Tables[0].Rows[0]["Message"]) == "200")
                                            {
                                                response.Data = "";
                                                response.Message = "Deleted successfully";
                                                response.Status = true;
                                            }
                                            else
                                            {
                                                response.Message = Convert.ToString(dsetfm1.Tables[0].Rows[0]["Message"]);
                                                response.Status = Convert.ToInt32(dsetfm1.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                                            }

                                        }
                                    }


                                }
                                catch (Exception ex)
                                {

                                }

                            }
                            return response;

                        }
                    }
                }

                else
                {

                    MySqlParameter[] param2 = new MySqlParameter[4];
                    try
                    {


                        using MySqlConnection con1 = new MySqlConnection(connection);
                        {

                            param2[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                            param2[0].Value = obj_folders_master.created_by_user_id;

                            param2[1] = new MySqlParameter("p_folder_id", MySqlDbType.Int64);
                            param2[1].Value = obj_folders_master.folder_id;

                            param2[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                            param2[2].Value = obj_folders_master.cust_id;


                            param2[3] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                            param2[3].Value = "UpdateFolderDeleteStatus";

                            dsetfm2 = SqlHelpher.ExecuteDataset(con1, CommandType.StoredProcedure, "SP_UpdateFolderDeleteStatuss", param2);
                        }

                        if (dsetfm2.Tables.Count > 0)
                        {
                            if (dsetfm2.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToString(dsetfm2.Tables[0].Rows[0]["Message"]) == "200")
                                {
                                    response.Data = "";
                                    response.Message = "Deleted successfully";
                                    response.Status = true;
                                }
                                else
                                {
                                    response.Message = Convert.ToString(dsetfm2.Tables[0].Rows[0]["Message"]);
                                    response.Status = Convert.ToInt32(dsetfm2.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                                }

                            }


                        }
                    }
                    catch (Exception ex)
                    {

                    }


                }
            }
            catch (Exception ex)
            {

            }


            return response;
        }



        public DataTable GetAllFileMaster(string CustId, Int64 UserId)
        {
            Response response = new Response();
            DataTable dsetfm = new DataTable();
            MySqlParameter[] param = new MySqlParameter[2];
            try
            {


                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[0].Value = UserId;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = CustId;

                    dsetfm = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetFileMaster", param);
                    return dsetfm;

                }

            }

            catch (Exception ex)
            {

            }
            return dsetfm;
        }
        public DataTable GetAllFolderMaster(string CustId, Int64 UserId)
        {
            Response response = new Response();
            DataTable dsetfm = new DataTable();
            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[0].Value = UserId;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = CustId;

                    dsetfm = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetFolderMaster", param);
                    return dsetfm;

                }

            }

            catch (Exception ex)
            {

            }
            return dsetfm;
        }
        public DataTable GetAllUserRecentFiles(string CustId, Int64 UserId)  //, Int64 FileId
        {
            Response response = new Response();
            DataTable dseturf = new DataTable();
            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[0].Value = UserId;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = CustId;

                    //param[2] = new MySqlParameter("p_file_id", MySqlDbType.Int64);
                    //param[2].Value = FileId;

                    dseturf = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetAllUserRecentFiles", param);
                    return dseturf;
                }
            }
            catch (Exception ex)
            {

            }
            return dseturf;
        }

        //public Response UpdateUserappFolderDetailsForBusinessApps(userapp_folder_details_for_business_apps obj_userapp_folder_details_for_business_apps)
        //{
        //    Response response = new Response();
        //    DataSet ds = new DataSet();

        //    MySqlParameter[] param = new MySqlParameter[12];
        //    try
        //    {
        //        using MySqlConnection con = new MySqlConnection(connection);
        //        {


        //            param[0] = new MySqlParameter("p_user_apps_data_folder_id", MySqlDbType.Int64);
        //            param[0].Value = obj_userapp_folder_details_for_business_apps.user_apps_data_folder_id;



        //            param[1] = new MySqlParameter("p_folder_id", MySqlDbType.Int64);
        //            param[1].Value = obj_userapp_folder_details_for_business_apps.folder_id;

        //            param[2] = new MySqlParameter("p_is_folder", MySqlDbType.Bool);
        //            param[2].Value = obj_userapp_folder_details_for_business_apps.is_folder;

        //            param[3] = new MySqlParameter("p_mapping_id", MySqlDbType.VarChar);
        //            param[3].Value = obj_userapp_folder_details_for_business_apps.mapping_id;

        //            param[4] = new MySqlParameter("p_mapping_parent", MySqlDbType.VarChar);
        //            param[4].Value = obj_userapp_folder_details_for_business_apps.mapping_parent;



        //            param[5] = new MySqlParameter("p_app_id", MySqlDbType.Int64);
        //            param[5].Value = obj_userapp_folder_details_for_business_apps.app_id;

        //            param[6] = new MySqlParameter("p_user_app_or_custom_app", MySqlDbType.Bool);
        //            param[6].Value = obj_userapp_folder_details_for_business_apps.user_app_or_custom_app;

        //            param[7] = new MySqlParameter("p_folder_created_timestamp", MySqlDbType.VarChar);
        //            param[7].Value = obj_userapp_folder_details_for_business_apps.folder_created_timestamp;

        //            param[8] = new MySqlParameter("p_can_delete_folder", MySqlDbType.Bool);
        //            param[8].Value = obj_userapp_folder_details_for_business_apps.can_delete_folder;

        //            param[9] = new MySqlParameter("p_can_delete_files", MySqlDbType.Bool);
        //            param[9].Value = obj_userapp_folder_details_for_business_apps.can_delete_files;

        //            param[9] = new MySqlParameter("p_can_copy_files", MySqlDbType.Bool);
        //            param[9].Value = obj_userapp_folder_details_for_business_apps.can_copy_files;

        //            param[10] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
        //            param[10].Value = obj_userapp_folder_details_for_business_apps.user_id;

        //            param[11] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
        //            param[11].Value = obj_userapp_folder_details_for_business_apps.cust_id;



        //            ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateUserappFolderDetailsForBusinessApps", param);

        //        }
        //        if (ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {

        //                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
        //                {

        //                    response.Data = "";
        //                    response.Message = "Update UserAppsData successfully  !!";
        //                    response.Status = true;
        //                }
        //                else
        //                {
        //                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
        //                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return response;
        //}
        public DataTable GetUserappFolderDetailsForBusinessAppsbyMappingParentBased(string CustId, Int64 UserId, Int64 AppId, string Mapping_Id)
        {
            Response response = new Response();
            DataTable dsetuad = new DataTable();
            MySqlParameter[] param = new MySqlParameter[4];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[0].Value = UserId;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = CustId;

                    param[2] = new MySqlParameter("p_app_id", MySqlDbType.Int64);
                    param[2].Value = AppId;

                    param[3] = new MySqlParameter("p_mapping_id", MySqlDbType.VarChar);
                    param[3].Value = Mapping_Id;

                    dsetuad = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetUserappFolderDetailsForBusinessAppsbyMappingParentBased", param);
                    return dsetuad;
                }
            }

            catch (Exception ex)
            {

            }
            return dsetuad;
        }
        public Response DeleteUserappFolderDetailsForBusinessAppsbyId(string CustId, long UserId, long AppId, long UserAppsDataFolderId)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[4];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_user_apps_data_folder_id", MySqlDbType.Int64);
                    param[0].Value = UserAppsDataFolderId;

                    param[1] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[1].Value = UserId;

                    param[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[2].Value = CustId;


                    param[3] = new MySqlParameter("p_app_id", MySqlDbType.Int64);
                    param[3].Value = AppId;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_DeleteUserappFolderDetailsForBusinessAppsbyId", param);

                }
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";
                            response.Message = "Delete DeleteUserAppsData successfully  !!";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return response;
        }
        public DataSet GetUserFolderFiles(string CustId, Int64 UserId, Int64 FileOrFolderId, Int64 FileId, Int64 FolderId)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[5];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_userId", MySqlDbType.Int64);
                    param[0].Value = UserId;

                    param[1] = new MySqlParameter("p_FileOrFolderId", MySqlDbType.Int64);
                    param[1].Value = FileOrFolderId;

                    param[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[2].Value = CustId;  //p_file_id

                    param[3] = new MySqlParameter("p_file_id", MySqlDbType.Int64);
                    param[3].Value = FileId;  //p_file_id

                    param[4] = new MySqlParameter("p_folder_id", MySqlDbType.Int64);
                    param[4].Value = FolderId;  //p_file_id



                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_GetUserFolderFiles   ", param);
                    return ds;
                }

            }

            catch (Exception ex)
            {

            }
            return ds;
        }
        public Response UpdateFolderMaster(folders_master obj_folders_master)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[11];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_folder_id", MySqlDbType.Int64);
                    param[0].Value = obj_folders_master.folder_id;

                    param[1] = new MySqlParameter("p_folder_name", MySqlDbType.VarChar);
                    param[1].Value = obj_folders_master.folder_name;

                    param[2] = new MySqlParameter("P_multiuser_folder_access", MySqlDbType.Bool);
                    param[2].Value = obj_folders_master.multiuser_folder_access;

                    param[3] = new MySqlParameter("p_created_by_user_id", MySqlDbType.Int64);
                    param[3].Value = obj_folders_master.created_by_user_id;

                    param[4] = new MySqlParameter("p_created_timestamp", MySqlDbType.VarChar);
                    param[4].Value = obj_folders_master.created_timestamp;

                    param[5] = new MySqlParameter("p_folder_size", MySqlDbType.Int64);
                    param[5].Value = obj_folders_master.folder_size;

                    param[6] = new MySqlParameter("p_deleted_status", MySqlDbType.Bool);
                    param[6].Value = obj_folders_master.deleted_status;

                    param[7] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[7].Value = obj_folders_master.cust_id;



                    param[8] = new MySqlParameter("p_is_folder", MySqlDbType.Bool);
                    param[8].Value = obj_folders_master.is_folder;

                    param[9] = new MySqlParameter("p_mapping_id", MySqlDbType.VarChar);
                    param[9].Value = obj_folders_master.mapping_id;

                    param[10] = new MySqlParameter("p_mapping_parent", MySqlDbType.VarChar);
                    param[10].Value = obj_folders_master.mapping_parent;


                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateFolderMaster", param);

                }
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";

                            response.Message = "Data Updated successfully";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }

            }

            catch (Exception ex)
            {

            }
            return response;
        }
        public Response UpdateFilesMaster(files_master obj_files_master)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[10];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_file_id", MySqlDbType.Int64);
                    param[0].Value = obj_files_master.file_id;

                    param[1] = new MySqlParameter("p_file_name", MySqlDbType.VarChar);
                    param[1].Value = obj_files_master.file_name;

                    param[2] = new MySqlParameter("P_multiuser_file_access", MySqlDbType.Bool);
                    param[2].Value = obj_files_master.multiuser_file_access;

                    param[3] = new MySqlParameter("p_file_type", MySqlDbType.VarChar);
                    param[3].Value = obj_files_master.file_type;

                    param[4] = new MySqlParameter("p_uploaded_created_by_user_id", MySqlDbType.Int64);
                    param[4].Value = obj_files_master.uploaded_created_by_user_id;

                    param[5] = new MySqlParameter("p_uploaded_created_timestamp", MySqlDbType.VarChar);
                    param[5].Value = obj_files_master.uploaded_created_timestamp;

                    param[6] = new MySqlParameter("p_file_storage_url", MySqlDbType.VarChar);
                    param[6].Value = obj_files_master.file_storage_url;

                    param[7] = new MySqlParameter("p_file_size", MySqlDbType.Decimal);
                    param[7].Value = obj_files_master.file_size;


                    param[8] = new MySqlParameter("p_deleted_status", MySqlDbType.Bool);
                    param[8].Value = obj_files_master.deleted_status;

                    param[9] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[9].Value = obj_files_master.cust_id;




                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateFilesMaster", param);

                }
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";

                            response.Message = "Data Updated successfully";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }

            }

            catch (Exception ex)
            {

            }
            return response;
        }
        public Response FileRename(files_master obj_files_master)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[5];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_file_id", MySqlDbType.Int64);
                    param[0].Value = obj_files_master.file_id;

                    param[1] = new MySqlParameter("p_file_name", MySqlDbType.VarChar);
                    param[1].Value = obj_files_master.file_name;

                    param[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[2].Value = obj_files_master.cust_id;

                    param[3] = new MySqlParameter("p_uploaded_created_timestamp", MySqlDbType.VarChar);
                    param[3].Value = obj_files_master.uploaded_created_timestamp;// uploaded_created_by_user_id

                    param[4] = new MySqlParameter("p_uploaded_created_by_user_id", MySqlDbType.Int64);
                    param[4].Value = obj_files_master.uploaded_created_by_user_id;// uploaded_created_by_user_id


                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_FileRename", param);

                }
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";
                            response.Message = "FileRenamed successfully  !!";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }

            }

            catch (Exception ex)
            {

            }
            return response;
        }
        public Response FolderRename(folders_master obj_folders_Master)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[5];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_folder_id", MySqlDbType.Int64);
                    param[0].Value = obj_folders_Master.folder_id;

                    param[1] = new MySqlParameter("p_folder_name", MySqlDbType.VarChar);
                    param[1].Value = obj_folders_Master.folder_name;

                    param[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[2].Value = obj_folders_Master.cust_id;

                    param[3] = new MySqlParameter("p_created_timestamp", MySqlDbType.VarChar);
                    param[3].Value = obj_folders_Master.created_timestamp;

                    param[4] = new MySqlParameter("p_created_by_user_id", MySqlDbType.Int64);
                    param[4].Value = obj_folders_Master.created_by_user_id;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_FolderRename", param);

                }
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";

                            response.Message = "FolderRenamed  successfully  !!";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }

            }

            catch (Exception ex)
            {

            }
            return response;
        }
        public Response AddCloudFileStorageUsersMaster(cloud_file_storage_users_master obj_cloud_file_storage_users_master)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[6];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[0].Value = obj_cloud_file_storage_users_master.user_id;

                    param[1] = new MySqlParameter("p_storage_limit_in_mb", MySqlDbType.Int64);
                    param[1].Value = obj_cloud_file_storage_users_master.storage_limit_in_mb;

                    param[2] = new MySqlParameter("p_user_app_joining_timestamp", MySqlDbType.DateTime);
                    param[2].Value = obj_cloud_file_storage_users_master.user_app_joining_timestamp;

                    param[3] = new MySqlParameter("p_block_app_access", MySqlDbType.Bool);
                    param[3].Value = obj_cloud_file_storage_users_master.block_app_access;

                    param[4] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[4].Value = obj_cloud_file_storage_users_master.cust_id;

                    param[5] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                    param[5].Value = "Insert";


                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_InsertCloudFileStorageUsersMaster", param);


                }

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";

                            response.Message = "Insert CloudFileStorageUsersMaster successfully  !!";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }
        public DataTable GetAllCloudFileStorageUsersMaster(string CustId, int UserId)
        {
            Response response = new Response();
            DataTable ds = new DataTable();

            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[0].Value = CustId;

                    param[1] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[1].Value = UserId;

                    ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetAllCloudFileStorageUsersMaster", param);




                    return ds;



                }
            }

            catch (Exception ex)
            {

            }
            return ds;
        }
        public Response DeleteCloudFileStorageUsersMaster(string CustId, Int64 UserId)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[0].Value = UserId;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = CustId;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_DeleteCloudFileStorageUsersMaster", param);
                }


                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";
                            response.Message = "Delete CloudFileStorageUsersMaster successfully  !!";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }


        public Response UpdateCloudFileStorageUsersMaster(cloud_file_storage_users_master obj_cloud_file_storage_users_master)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[5];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[0].Value = obj_cloud_file_storage_users_master.user_id;

                    param[1] = new MySqlParameter("p_storage_limit_in_mb", MySqlDbType.Int64);
                    param[1].Value = obj_cloud_file_storage_users_master.storage_limit_in_mb;

                    param[2] = new MySqlParameter("p_user_app_joining_timestamp", MySqlDbType.DateTime);
                    param[2].Value = obj_cloud_file_storage_users_master.user_app_joining_timestamp;

                    param[3] = new MySqlParameter("p_block_app_access", MySqlDbType.Bool);
                    param[3].Value = obj_cloud_file_storage_users_master.block_app_access;

                    param[4] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[4].Value = obj_cloud_file_storage_users_master.cust_id;


                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateCloudFileStorageUsersMasters", param);

                }
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";
                            response.Message = "Update CloudFileStorageUsersMaster successfully";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }

            }

            catch (Exception ex)
            {

            }
            return response;
        }
        public DataTable GetFolderPermissions(string CustId, int FolerId, int UserId)
        {
            Response response = new Response();
            DataTable dsetfp = new DataTable();
            MySqlParameter[] param = new MySqlParameter[3];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_folder_id", MySqlDbType.Int64);
                    param[0].Value = FolerId;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = CustId;

                    param[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[2].Value = UserId;

                    dsetfp = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetFolderPermissions", param);
                    return dsetfp;
                }
            }

            catch (Exception ex)
            {

            }
            return dsetfp;
        }
        public DataTable GetFilePermissions(string CustId, int FileId, int UserId)
        {
            Response response = new Response();
            DataTable dsetfp = new DataTable();
            MySqlParameter[] param = new MySqlParameter[3];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_file_id", MySqlDbType.Int64);
                    param[0].Value = FileId;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = CustId;

                    param[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[2].Value = UserId;

                    dsetfp = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetFilePermissions", param);
                    return dsetfp;

                }

            }

            catch (Exception ex)
            {

            }
            return dsetfp;
        }
        public DataTable GetFilesActivity(string CustId, Int64 FileId)
        {
            Response response = new Response();
            DataTable dsetfm = new DataTable();
            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_Fileid", MySqlDbType.Int64);
                    param[0].Value = FileId;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = CustId;

                    dsetfm = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetFileActivity", param);
                    return dsetfm;

                }

            }

            catch (Exception ex)
            {

            }
            return dsetfm;
        }
        public DataTable GetFolderActivity(string CustId, Int64 FolderId)
        {
            Response response = new Response();
            DataTable dsetfm = new DataTable();
            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_folder_id", MySqlDbType.Int64);
                    param[0].Value = FolderId;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = CustId;

                    dsetfm = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetFolderActivity", param);
                    return dsetfm;

                }
            }

            catch (Exception ex)
            {

            }
            return dsetfm;
        }
        public DataTable GetUserNotifications(string CustId, Int64 UserId)
        {
            Response response = new Response();
            DataTable ds = new DataTable();
            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[0].Value = UserId;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = CustId;

                    ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetUserNotifications", param);
                    return ds;

                }

            }

            catch (Exception ex)
            {

            }
            return ds;
        }




        // /////////////////////////////////////////
        public Response CloudFileStorageAppRegisteration(cloud_file_storage_app_registeration obj_cloud_file_storage_app_registeration)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            DataSet dsr = new DataSet();
            DataSet dsdsl = new DataSet();
            DataSet dsua = new DataSet();


            MySqlParameter[] param = new MySqlParameter[11];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_userId", MySqlDbType.Int64); //VarChar
                    param[0].Value = obj_cloud_file_storage_app_registeration.user_id;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = obj_cloud_file_storage_app_registeration.cust_id;

                    param[2] = new MySqlParameter("p_mobile_no", MySqlDbType.VarChar);
                    param[2].Value = obj_cloud_file_storage_app_registeration.mobile_no;

                    param[3] = new MySqlParameter("p_user_name", MySqlDbType.VarChar);
                    param[3].Value = obj_cloud_file_storage_app_registeration.user_name;

                    param[4] = new MySqlParameter("p_password", MySqlDbType.VarChar);
                    param[4].Value = obj_cloud_file_storage_app_registeration.password;

                    param[5] = new MySqlParameter("p_photo_id", MySqlDbType.VarChar);
                    param[5].Value = obj_cloud_file_storage_app_registeration.photo_id;

                    param[6] = new MySqlParameter("p_storage_limit_in_mb", MySqlDbType.Int64);
                    param[6].Value = obj_cloud_file_storage_app_registeration.storage_limit_in_mb;

                    param[7] = new MySqlParameter("p_block_app_access", MySqlDbType.Bool);
                    param[7].Value = obj_cloud_file_storage_app_registeration.block_app_access;

                    param[8] = new MySqlParameter("p_entry_type", MySqlDbType.VarChar);
                    param[8].Value = obj_cloud_file_storage_app_registeration.entry_type;  //entry_type

                    param[9] = new MySqlParameter("p_user_category", MySqlDbType.VarChar);
                    param[9].Value = obj_cloud_file_storage_app_registeration.user_category;  //user_category

                    param[10] = new MySqlParameter("p_Authkey", MySqlDbType.VarChar);
                    param[10].Value = obj_cloud_file_storage_app_registeration.Authkey;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_CreateCloudFileStorageAppRegistration", param);

                }

                string Getnew_user_storage_limit = ds.Tables[0].Rows[0]["new_user_storage_limit"].ToString();


                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MySqlParameter[] param1 = new MySqlParameter[11];


                        using MySqlConnection con1 = new MySqlConnection(connection);
                        {
                            param1[0] = new MySqlParameter("p_userId", MySqlDbType.Int64); //VarChar
                            param1[0].Value = obj_cloud_file_storage_app_registeration.user_id;

                            param1[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                            param1[1].Value = obj_cloud_file_storage_app_registeration.cust_id;

                            param1[2] = new MySqlParameter("p_mobile_no", MySqlDbType.VarChar);
                            param1[2].Value = obj_cloud_file_storage_app_registeration.mobile_no;

                            param1[3] = new MySqlParameter("p_user_name", MySqlDbType.VarChar);
                            param1[3].Value = obj_cloud_file_storage_app_registeration.user_name;

                            param1[4] = new MySqlParameter("p_password", MySqlDbType.VarChar);
                            param1[4].Value = obj_cloud_file_storage_app_registeration.password;

                            param1[5] = new MySqlParameter("p_photo_id", MySqlDbType.VarChar);
                            param1[5].Value = obj_cloud_file_storage_app_registeration.photo_id;

                            param1[6] = new MySqlParameter("p_storage_limit_in_mb", MySqlDbType.Int64);
                            param1[6].Value = Getnew_user_storage_limit;

                            param1[7] = new MySqlParameter("p_block_app_access", MySqlDbType.Bool);
                            param1[7].Value = obj_cloud_file_storage_app_registeration.block_app_access;

                            param1[8] = new MySqlParameter("p_entry_type", MySqlDbType.VarChar);
                            param1[8].Value = obj_cloud_file_storage_app_registeration.entry_type;  //entry_type

                            param1[9] = new MySqlParameter("p_user_category", MySqlDbType.VarChar);
                            param1[9].Value = obj_cloud_file_storage_app_registeration.user_category;  //user_category

                            param1[10] = new MySqlParameter("p_Authkey", MySqlDbType.VarChar);
                            param1[10].Value = obj_cloud_file_storage_app_registeration.Authkey;

                            dsr = SqlHelpher.ExecuteDataset(con1, CommandType.StoredProcedure, "SP_InsertCloudFileStorageAppRegistration", param1);
                        }
                        if (dsr.Tables.Count > 0)
                        {
                            if (dsr.Tables[0].Rows.Count > 0)
                            {
                                MySqlParameter[] param3 = new MySqlParameter[5];

                                using MySqlConnection con2 = new MySqlConnection(connection);
                                {
                                    param3[0] = new MySqlParameter("p_userId", MySqlDbType.Int64); // VarChar
                                    param3[0].Value = obj_cloud_file_storage_app_registeration.user_id;

                                    param3[1] = new MySqlParameter("p_user_name", MySqlDbType.VarChar);
                                    param3[1].Value = obj_cloud_file_storage_app_registeration.user_name;

                                    param3[2] = new MySqlParameter("p_entry_type", MySqlDbType.VarChar);
                                    param3[2].Value = obj_cloud_file_storage_app_registeration.entry_type;  //entry_type

                                    param3[3] = new MySqlParameter("p_user_category", MySqlDbType.VarChar);
                                    param3[3].Value = obj_cloud_file_storage_app_registeration.user_category;  //user_categor

                                    param3[4] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                    param3[4].Value = obj_cloud_file_storage_app_registeration.cust_id;


                                    dsua = SqlHelpher.ExecuteDataset(con2, CommandType.StoredProcedure, "SP_InsertUserappAuditTrailForAppAdministrator", param3);
                                }

                                if (Convert.ToString(dsua.Tables[0].Rows[0]["Message"]) == "200")
                                {
                                    response.Data = "";
                                    response.Message = "Inserted UserappAuditTrailForAppAdministrator successfully !!";
                                    response.Status = true;
                                }
                                else
                                {
                                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                                }
                            }
                        }

                        if (dsua.Tables.Count > 0)
                        {
                            if (dsua.Tables[0].Rows.Count > 0)
                            {
                                MySqlParameter[] param2 = new MySqlParameter[1];


                                using MySqlConnection con2 = new MySqlConnection(connection);   
                                {
                                    param2[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                    param2[0].Value = obj_cloud_file_storage_app_registeration.cust_id;

                                    dsdsl = SqlHelpher.ExecuteDataset(con2, CommandType.StoredProcedure, "SP_DynamicInsertUserAppNewUserDefaultStorageLimit", param2);
                                }

                                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                                {

                                    response.Data = "";
                                    response.Message = "Inserted successfully";
                                    response.Status = true;
                                }
                                else
                                {
                                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                                }

                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {

            }
            return response;
        }

        // /////////////////////////////////////////




        public Response AddFilePermissions(file_users_list_permissions obj_file_permissions)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            try
            {

                MySqlParameter[] param = new MySqlParameter[14];

                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[0].Value = obj_file_permissions.user_id;

                    param[1] = new MySqlParameter("p_user_added_timestamp", MySqlDbType.DateTime);
                    param[1].Value = obj_file_permissions.user_added_timestamp;

                    param[2] = new MySqlParameter("p_user_removed_timestamp", MySqlDbType.DateTime);
                    param[2].Value = obj_file_permissions.user_removed_timestamp;

                    param[3] = new MySqlParameter("p_file_admin", MySqlDbType.Bool);
                    param[3].Value = obj_file_permissions.file_admin;

                    param[4] = new MySqlParameter("p_edit_file", MySqlDbType.Bool);
                    param[4].Value = obj_file_permissions.edit_file;

                    param[5] = new MySqlParameter("p_rename_file", MySqlDbType.Bool);
                    param[5].Value = obj_file_permissions.rename_file;

                    param[6] = new MySqlParameter("p_download_file", MySqlDbType.Bool);
                    param[6].Value = obj_file_permissions.download_file;

                    param[7] = new MySqlParameter("p_copy_file", MySqlDbType.Bool);
                    param[7].Value = obj_file_permissions.copy_file;

                    param[8] = new MySqlParameter("p_share_file", MySqlDbType.Bool);
                    param[8].Value = obj_file_permissions.share_file;

                    param[9] = new MySqlParameter("p_file_activity_notifications_requested", MySqlDbType.Bool); //file_delete_notification
                    param[9].Value = obj_file_permissions.file_activity_notifications_requested;

                    param[10] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                    param[10].Value = "Insert";


                    param[11] = new MySqlParameter("p_file_id", MySqlDbType.Int64);
                    param[11].Value = obj_file_permissions.file_id;

                    param[12] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[12].Value = obj_file_permissions.cust_id;


                    param[13] = new MySqlParameter("p_shared_user_id", MySqlDbType.Int64);
                    param[13].Value = obj_file_permissions.shared_user_id;


                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_InsertFilePermissions", param);

                }
                string Mapping_Id = Convert.ToString(ds.Tables[0].Rows[0]["Mapping_Id"].ToString());
                string Is_Folder = Convert.ToString(ds.Tables[0].Rows[0]["Is_Folder"].ToString());
                string Mapping_Parent = Convert.ToString(ds.Tables[0].Rows[0]["Mapping_Parent"].ToString());


                if (ds.Tables[0].Rows.Count > 0)
                {

                    MySqlParameter[] param1 = new MySqlParameter[7];
                    try
                    {
                        using MySqlConnection con1 = new MySqlConnection(connection);
                        {
                            param1[0] = new MySqlParameter("p_Mapping_Id", MySqlDbType.VarChar);
                            param1[0].Value = Mapping_Id;

                            param1[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                            param1[1].Value = obj_file_permissions.cust_id;

                            param1[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                            param1[2].Value = obj_file_permissions.user_id;

                            param1[3] = new MySqlParameter("p_file_id", MySqlDbType.Int64);
                            param1[3].Value = obj_file_permissions.file_id;


                            param1[4] = new MySqlParameter("p_shared_user_id", MySqlDbType.Int64);
                            param1[4].Value = obj_file_permissions.shared_user_id;


                            param1[5] = new MySqlParameter("p_Is_Folder", MySqlDbType.VarChar);
                            param1[5].Value = Is_Folder;

                            param1[6] = new MySqlParameter("p_Mapping_Parent", MySqlDbType.VarChar);
                            param1[6].Value = Mapping_Parent;

                            ds1 = SqlHelpher.ExecuteDataset(con1, CommandType.StoredProcedure, "SP_InsertUserFolderFilesForFiles", param1);

                        }

                    }
                    catch (Exception ex)
                    {

                    }

                    if (Convert.ToString(ds1.Tables[0].Rows[0]["Message"]) == "200")
                    {

                        response.Data = "";
                        response.Message = "New User Added successfully For FilePermissions !!";
                        response.Status = true;
                    }
                    else
                    {
                        response.Message = Convert.ToString(ds1.Tables[0].Rows[0]["Message"]);
                        response.Status = Convert.ToInt32(ds1.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                    }

                }

            }


            catch (Exception ex)
            {

            }
            return response;

        }



        public Response AddFolderPermissions(folder_users_list_permissions obj_folder_users_list_permissions)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();


            MySqlParameter[] param = new MySqlParameter[16];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {


                    param[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[0].Value = obj_folder_users_list_permissions.user_id;

                    param[1] = new MySqlParameter("p_user_added_timestamp", MySqlDbType.DateTime);
                    param[1].Value = obj_folder_users_list_permissions.user_added_timestamp;

                    param[2] = new MySqlParameter("p_user_removed_timestamp", MySqlDbType.DateTime);
                    param[2].Value = obj_folder_users_list_permissions.user_removed_timestamp;

                    param[3] = new MySqlParameter("p_folder_admin", MySqlDbType.Bool);
                    param[3].Value = obj_folder_users_list_permissions.folder_admin;

                    param[4] = new MySqlParameter("p_access_recent_no_of_files", MySqlDbType.Int64);
                    param[4].Value = obj_folder_users_list_permissions.access_recent_no_of_files;

                    param[5] = new MySqlParameter("p_upload_folder", MySqlDbType.Bool);
                    param[5].Value = obj_folder_users_list_permissions.upload_folder;

                    param[6] = new MySqlParameter("p_rename_folder", MySqlDbType.Bool);
                    param[6].Value = obj_folder_users_list_permissions.rename_folder;

                    param[7] = new MySqlParameter("p_download_folder", MySqlDbType.Bool);
                    param[7].Value = obj_folder_users_list_permissions.download_folder;

                    param[8] = new MySqlParameter("p_copy_folder", MySqlDbType.Bool);
                    param[8].Value = obj_folder_users_list_permissions.copy_folder;

                    param[9] = new MySqlParameter("p_share_folder", MySqlDbType.Bool);
                    param[9].Value = obj_folder_users_list_permissions.share_folder;

                    param[10] = new MySqlParameter("p_folder_activity_notification", MySqlDbType.Bool);
                    param[10].Value = obj_folder_users_list_permissions.folder_activity_notification;

                    param[11] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                    param[11].Value = "Insert";


                    param[12] = new MySqlParameter("p_folder_id", MySqlDbType.Int64);
                    param[12].Value = obj_folder_users_list_permissions.folder_id;

                    param[13] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[13].Value = obj_folder_users_list_permissions.cust_id;

                    param[14] = new MySqlParameter("p_shared_user_id", MySqlDbType.Int64);
                    param[14].Value = obj_folder_users_list_permissions.shared_user_id;

                    param[15] = new MySqlParameter("p_mapping_id", MySqlDbType.VarChar);
                    param[15].Value = obj_folder_users_list_permissions.mapping_id;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_InsertFolderPermissions", param);

                }


                string Mapping_Id = Convert.ToString(ds.Tables[0].Rows[0]["Mapping_Id"].ToString());

                string Is_Folder = Convert.ToString(ds.Tables[0].Rows[0]["Is_Folder"].ToString());

                string Mapping_Parent = Convert.ToString(ds.Tables[0].Rows[0]["Mapping_Parent"].ToString());




                if (Mapping_Id != null && Is_Folder != null && Mapping_Parent != null)
                {

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MySqlParameter[] param1 = new MySqlParameter[7];
                        try
                        {
                            using MySqlConnection con1 = new MySqlConnection(connection);
                            {
                                param1[0] = new MySqlParameter("p_Mapping_Id", MySqlDbType.VarChar);
                                param1[0].Value = Mapping_Id;

                                param1[1] = new MySqlParameter("P_Is_Folder", MySqlDbType.VarChar);  //doubt
                                param1[1].Value = Is_Folder;

                                param1[2] = new MySqlParameter("P_Mapping_Parent", MySqlDbType.VarChar);
                                param1[2].Value = Mapping_Parent;

                                param1[3] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                param1[3].Value = obj_folder_users_list_permissions.cust_id;

                                param1[4] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                                param1[4].Value = obj_folder_users_list_permissions.user_id;

                                param1[5] = new MySqlParameter("p_folder_id", MySqlDbType.Int64);
                                param1[5].Value = obj_folder_users_list_permissions.folder_id;

                                param1[6] = new MySqlParameter("p_shared_user_id", MySqlDbType.Int64);
                                param1[6].Value = obj_folder_users_list_permissions.shared_user_id;

                                ds1 = SqlHelpher.ExecuteDataset(con1, CommandType.StoredProcedure, "SP_InsertUserFolderFilesForFolders", param1);

                            }

                        }


                        catch (Exception ex)
                        {

                        }
                        if (Convert.ToString(ds1.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";
                            response.Message = "New User Added successfully For FolderPermissions !!";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds1.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds1.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }
            }



            catch (Exception ex)
            {

            }
            return response;
        }



        public Response DeleteUserForFolderPermissionsById(string CustId, int UserId, int FolderId)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();


            MySqlParameter[] param = new MySqlParameter[3];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_folder_id", MySqlDbType.Int64);
                    param[0].Value = FolderId;
                    param[1] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[1].Value = UserId;

                    param[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[2].Value = CustId;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_DeleteUserForFolderPermissionsById", param);

                }


                Int32 getcount = Convert.ToInt32(ds.Tables[0].Rows[0]["countdeletestatus"].ToString());
                if (getcount >= 1)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {


                        MySqlParameter[] param1 = new MySqlParameter[3];
                        try
                        {
                            using MySqlConnection con1 = new MySqlConnection(connection);
                            {
                                param1[0] = new MySqlParameter("p_folder_id", MySqlDbType.Int64);
                                param1[0].Value = FolderId;

                                param1[1] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                                param1[1].Value = UserId;

                                param1[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                                param1[2].Value = CustId;

                                ds1 = SqlHelpher.ExecuteDataset(con1, CommandType.StoredProcedure, "SP_DeleteUserForFolderPermissionsByIds", param1);

                            }

                            if (Convert.ToString(ds1.Tables[0].Rows[0]["Message"]) == "200")
                            {

                                response.Data = "";
                                response.Message = "Delete User For File Permissions Successfully !!";
                                response.Status = true;
                            }
                            else
                            {
                                response.Message = Convert.ToString(ds1.Tables[0].Rows[0]["Message"]);
                                response.Status = Convert.ToInt32(ds1.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                            }

                        }


                        catch (Exception ex)
                        {

                        }
                        return response;
                    }
                }

                else
                {
                    response.Data = "";
                    response.Message = "admin can not delete this user !!";
                    response.Status = false;
                }
            }


            catch (Exception ex)
            {

            }
            return response;

        }











        public Response DeleteUserForFilePermissionsById(string CustId, int FileId, int UserId)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();


            MySqlParameter[] param = new MySqlParameter[3];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_file_id", MySqlDbType.Int64);
                    param[0].Value = FileId;
                    param[1] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[1].Value = UserId;

                    param[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[2].Value = CustId;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_DeleteUserForFilePermissionsById", param);

                }

                Int32 getcount = Convert.ToInt32(ds.Tables[0].Rows[0]["countdeletestatus"].ToString());
                if (getcount >= 1)
                {


                    MySqlParameter[] param1 = new MySqlParameter[3];
                    try
                    {
                        using MySqlConnection con1 = new MySqlConnection(connection);
                        {
                            param1[0] = new MySqlParameter("p_file_id", MySqlDbType.Int64);
                            param1[0].Value = FileId;

                            param1[1] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                            param1[1].Value = UserId;

                            param1[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                            param1[2].Value = CustId;

                            ds1 = SqlHelpher.ExecuteDataset(con1, CommandType.StoredProcedure, "SP_DeleteUserForFilePermissionsByIds", param1);

                        }

                        if (Convert.ToString(ds1.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";
                            response.Message = "Delete User For File Permissions Successfully !!";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds1.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds1.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }

                    }


                    catch (Exception ex)
                    {

                    }
                    return response;
                }
                else
                {
                    response.Data = "";
                    response.Message = "admin can not delete this user !!";
                    response.Status = false;
                }
            }

            catch (Exception ex)
            {

            }
            return response;
        }


        public DataTable GetAllCloudFileStorageAppRegisteration(string CustId)
        {
            Response response = new Response();
            DataTable ds = new DataTable();

            MySqlParameter[] param = new MySqlParameter[1];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[0].Value = CustId;


                    ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetAllCloudFileStorageAppRegisteration", param);
                    return ds;

                }

            }

            catch (Exception ex)
            {

            }
            return ds;
        }

        public DataTable GetDeleteFileActivityLogById(string CustId, Int64 UserId)
        {
            Response response = new Response();
            DataTable ds = new DataTable();
            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_uploaded_created_by_user_id", MySqlDbType.Int64);
                    param[0].Value = UserId;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = CustId;

                    ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetDeleteFileActivityLogById", param);
                    return ds;

                }

            }

            catch (Exception ex)
            {

            }
            return ds;
        }


        public DataTable GetDeleteFolderActivityLogBtId(string CustId, Int64 UserId)
        {
            Response response = new Response();
            DataTable ds = new DataTable();
            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[0].Value = UserId;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = CustId;

                    ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetDeleteFolderActivityLogById", param);
                    return ds;
                }

            }

            catch (Exception ex)
            {

            }
            return ds;
        }




        // ///////////////////// 27112021


        public DataTable GetAllFoldersByParentFieldBased(string CustId)
        {
            Response response = new Response();
            DataTable dsetfm = new DataTable();
            MySqlParameter[] param = new MySqlParameter[1];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {


                    param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[0].Value = CustId;


                    dsetfm = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetAllFoldersByParentFieldBased", param);
                    return dsetfm;

                }

            }

            catch (Exception ex)
            {

            }
            return dsetfm;
        }
        //
        public DataTable GetAllFoldersByParentFieldBasedById(string CustId, Int64 UserId)
        {
            Response response = new Response();
            DataTable dsetfm = new DataTable();
            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {


                    param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[0].Value = CustId;

                    param[1] = new MySqlParameter("p_user_id", MySqlDbType.VarChar);
                    param[1].Value = UserId;



                    dsetfm = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetAllFoldersByParentFieldBasedById", param);
                    return dsetfm;

                }

            }

            catch (Exception ex)
            {

            }
            return dsetfm;
        }

        public DataSet GetAllDeleteFilesAndFolders(string CustId, Int64 UserId) //,
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[0].Value = UserId;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = CustId;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_GetAllDeleteFilesAndFolders", param);
                    return ds;

                }

            }

            catch (Exception ex)
            {

            }
            return ds;
        }



        public DataSet GetAllFolderFilesViewDetails(string CustId, Int64 UserId, string MappingId, Int64 FromUserId)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            MySqlParameter[] param = new MySqlParameter[4];

            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[0].Value = CustId;

                    param[1] = new MySqlParameter("p_mapping_id", MySqlDbType.VarChar);
                    param[1].Value = MappingId;

                    param[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[2].Value = UserId;

                    param[3] = new MySqlParameter("p_from_user_id", MySqlDbType.Int64);
                    param[3].Value = FromUserId;





                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_GetAllFoldersFieldViewDetails", param);

                    return ds;
                }


            }

            catch (Exception ex)
            {

            }
            return ds;
        }

        //UpdateFileDeleteStatus


        public Response UpdateFileDeleteStatus(files_master obj_files_master)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[3];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_file_id", MySqlDbType.Int64);
                    param[0].Value = obj_files_master.file_id;

                    param[1] = new MySqlParameter("p_deleted_status", MySqlDbType.Bool);
                    param[1].Value = obj_files_master.deleted_status;

                    param[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[2].Value = obj_files_master.cust_id;


                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateFileDeleteStatus", param);

                }
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";

                            response.Message = "Update DeleteStatus successfully";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }

            }

            catch (Exception ex)
            {

            }
            return response;
        }
        public Response UpdateFolderDeletedStatus(folders_master obj_folders_master)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[11];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_folder_id", MySqlDbType.Int64);
                    param[0].Value = obj_folders_master.folder_id;

                    param[1] = new MySqlParameter("p_deleted_status", MySqlDbType.Bool);
                    param[1].Value = obj_folders_master.deleted_status;

                    param[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[2].Value = obj_folders_master.cust_id;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateFolderDeletedStatus", param);

                }
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";

                            response.Message = "Update DeletedStatus successfully !!";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }

            }

            catch (Exception ex)
            {

            }
            return response;

        }
        public Response UpdateUserAppNewUserDefaultStorageLimit(userapp_new_user_default_storage_limit obj_userapp_new_user_default_storage_limit)
        {
                Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[3];
            try
            {

                //  ByteSize.FromKiloBytes(1024).ToString(); // 1 MB
                //  ByteSize.FromGigabytes(.5).ToString();   // 512 MB
                //  ByteSize.FromGigabytes(1024).ToString(); // 1 TB

                //var new_user_storage_limit_ConverToMB = ByteSize.FromKilobytes(obj_userapp_new_user_default_storage_limit.new_user_storage_limit).ToString();

                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_new_user_storage_limit", MySqlDbType.Int64);
                    param[0].Value = obj_userapp_new_user_default_storage_limit.new_user_storage_limit;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = obj_userapp_new_user_default_storage_limit.cust_id;

                    param[2] = new MySqlParameter("p_user_id", MySqlDbType.VarChar);
                    param[2].Value = obj_userapp_new_user_default_storage_limit.user_id;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateUserAppNewUserDefaultStorageLimit", param);
                }
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                        {
                            response.Data = "";
                            response.Message = "UserAppNewUserDefaultStorageLimit Added successfully  !!";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }

            }

            catch (Exception ex)
            {

            }
            return response;
        }
        public DataTable GetAllAndGetByIdUserappAuditTrailForAppAdministrator(string CustId, int UserId) //,
        {
            Response response = new Response();
            DataTable ds = new DataTable();
            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[0].Value = UserId;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = CustId;

                    ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetAllAndGetByIdUserappAuditTrailForAppAdministrator", param);
                    return ds;

                }

            }

            catch (Exception ex)
            {

            }
            return ds;
        }
        public DataTable GetUserNotificationsById(string CustId, Int64 UserId) //,
        {
            Response response = new Response();
            DataTable ds = new DataTable();
            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[0].Value = UserId;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = CustId;

                    ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetUserNotificationsById", param);
                    return ds;

                }

            }

            catch (Exception ex)
            {

            }
            return ds;
        }
        public DataTable GetUserNotificationsCountById(string CustId, Int64 UserId) //,
        {
            Response response = new Response();
            DataTable ds = new DataTable();
            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[0].Value = UserId;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = CustId;

                    ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetUserNotificationsCountById", param);
                    return ds;

                }

            }

            catch (Exception ex)
            {

            }
            return ds;
        }
        public Response UpdateNotificationStatus(user_notifications obj_user_notifications)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[3];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[0].Value = obj_user_notifications.sent_by_user_id;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = obj_user_notifications.cust_id;

                    param[2] = new MySqlParameter("p_notification_status", MySqlDbType.Bool);
                    param[2].Value = obj_user_notifications.notification_status;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateNotificationStatus", param);

                }
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";
                            response.Message = "Update Notification Status Successfully";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }

            }

            catch (Exception ex)
            {

            }
            return response;
        }

        public DataTable GetUserAppNewUserDefaultStorageLimit(string CustId) //,
        {
            Response response = new Response();
            DataTable ds = new DataTable();
            MySqlParameter[] param = new MySqlParameter[1];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[0].Value = CustId;

                    ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetUserAppNewUserDefaultStorageLimit", param);
                    return ds;

                }

            }

            catch (Exception ex)
            {

            }
            return ds;
        }








        public DataTable GetAllUserAppNewUserDefaultStorageLog(string CustId)
        {
            Response response = new Response();
            DataTable ds = new DataTable();
            MySqlParameter[] param = new MySqlParameter[1];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[0].Value = CustId;

                    ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetAllUserAppNewUserDefaultStorageLog", param);
                    return ds;

                }
            }

            catch (Exception ex)
            {

            }
            return ds;
        }

        public DataTable GetByIdUserAppNewUserDefaultStorageLog(string CustId, string UserId)
        {
            Response response = new Response();
            DataTable ds = new DataTable();
            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[0].Value = CustId;

                    param[1] = new MySqlParameter("p_user_id", MySqlDbType.VarChar);
                    param[1].Value = UserId;

                    ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetByIdUserAppNewUserDefaultStorageLog", param);
                    return ds;
                }

            }

            catch (Exception ex)
            {

            }
            return ds;
        }

        public DataTable DeleteByIdUserAppNewUserDefaultStorageLog(string CustId, string UserId)
        {
            Response response = new Response();
            DataTable ds = new DataTable();
            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[0].Value = CustId;

                    param[1] = new MySqlParameter("p_user_id", MySqlDbType.VarChar);
                    param[1].Value = UserId;

                    ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_DeleteUserAppNewUserDefaultStorageLog", param);
                    return ds;

                }

            }

            catch (Exception ex)
            {

            }
            return ds;
        }




















        public Response UpdateFolderPath(userapp_folder_path obj_userapp_folder_path)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[4];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {


                    param[0] = new MySqlParameter("p_id", MySqlDbType.Int64);
                    param[0].Value = obj_userapp_folder_path.Id;


                    param[1] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[1].Value = obj_userapp_folder_path.user_id;

                    param[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[2].Value = obj_userapp_folder_path.cust_id;

                    param[3] = new MySqlParameter("P_folder_path", MySqlDbType.VarChar);
                    param[3].Value = obj_userapp_folder_path.folder_path;



                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateFolderPath", param);

                }
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                        {
                            response.Message = "Update  Folder Path  successfully  !!";
                            response.Status = true;
                            response.Data = "";
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }

            }

            catch (Exception ex)
            {

            }
            return response;
        }







        public DataTable GetUserAppFolderPath(string UserId)
        {
            Response response = new Response();
            DataTable ds = new DataTable();
            MySqlParameter[] param = new MySqlParameter[1];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_user_id", MySqlDbType.VarChar);
                    param[0].Value = UserId;



                    ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetUserAppFolderPath", param);
                    return ds;

                }

            }

            catch (Exception ex)
            {

            }
            return ds;
        }





        public DataSet GetTotalFileSizeByUserId(string CustId, Int64 UserId)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            MySqlParameter[] param = new MySqlParameter[3];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[0].Value = CustId;

                    param[1] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[1].Value = UserId;

                    param[2] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                    param[2].Value = "GetUserUsedStorage";


                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_GetTotalFileSizeByUserId", param);

                    //return ds;
                }


                string UserUsedStorage = ds.Tables[0].Rows[0]["userusedstorage"].ToString();

               // int UserUsedStorage = Convert.ToInt32(UserUsedStorage1);

                if (UserUsedStorage!="") 
                {
                    try
                    {
                        MySqlParameter[] param2 = new MySqlParameter[3];

                        using MySqlConnection con2 = new MySqlConnection(connection);
                        {
                            param2[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                            param2[0].Value = CustId;

                            param2[1] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                            param2[1].Value = UserId;

                            param2[2] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                            param2[2].Value = "GetUserTotalStoragePlusRemainingStorage";

                            ds2 = SqlHelpher.ExecuteDataset(con2, CommandType.StoredProcedure, "SP_GetTotalFileSizeByUserId", param2);

                            return ds2;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {
                    MySqlParameter[] param1 = new MySqlParameter[3];
                    try
                    {                                
                        using MySqlConnection con1 = new MySqlConnection(connection);
                        {
                            param1[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                            param1[0].Value = CustId;

                            param1[1] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                            param1[1].Value = UserId;

                            param1[2] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                            param1[2].Value = "GetUserTotalStorage";

                            ds1 = SqlHelpher.ExecuteDataset(con1, CommandType.StoredProcedure, "SP_GetTotalFileSizeByUserId", param1);

                            return ds1;
                        }

                    }
                    catch (Exception ex)
                    {

                    }

                }
                }

            catch (Exception ex)
                {

            }
            return ds;
            }


        public Response DeleteFolderPermanently(string CustId, Int64 FolderId, Int64 UserId, string MappingId)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            DataSet dsetmaxid = new DataSet();

            MySqlParameter[] param = new MySqlParameter[4];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_folder_id", MySqlDbType.Int64);
                    param[0].Value = FolderId;

                    param[1] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[1].Value = UserId;

                    param[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[2].Value = CustId;

                    param[3] = new MySqlParameter("p_mapping_id", MySqlDbType.VarChar);
                    param[3].Value = MappingId;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_DeleteFolderPermanently", param);

                }
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                        {
                            response.Data = "";
                            response.Message = "Deleted Folder Permanently !!";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(dsetmaxid.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(dsetmaxid.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }

                    }
                }
            }

            catch (Exception ex)
            {

            }
            return response;
        }





        public Response DeleteFilePermanently(string CustId, Int64 FileId)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();

            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[0].Value = CustId;

                    param[1] = new MySqlParameter("p_file_id", MySqlDbType.Int64);
                    param[1].Value = FileId;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_DeleteFilePermanantly", param);

                }

                if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                {

                    response.Data = "";
                    response.Message = "Deleted File Permanantly !!";
                    response.Status = true;
                }
                else
                {
                    response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                    response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                }
            }

            catch (Exception ex)
            {

            }
            return response;
        }






        public Response AddUserUserappListOfFilesForUserAppsFolderId(userapp_files_details_for_business_apps obj_userapp_files_details_for_business_apps, userapp_files_details_for_business_apps mainobj)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[19];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_file_id", MySqlDbType.Int64);
                    param[0].Value = obj_userapp_files_details_for_business_apps.file_id;

                    param[1] = new MySqlParameter("p_mapping_id", MySqlDbType.VarChar);
                    param[1].Value = obj_userapp_files_details_for_business_apps.mapping_id;

                    param[2] = new MySqlParameter("p_is_folder", MySqlDbType.Bool);
                    param[2].Value = obj_userapp_files_details_for_business_apps.is_folder;

                    param[3] = new MySqlParameter("p_mapping_parent", MySqlDbType.VarChar);
                    param[3].Value = obj_userapp_files_details_for_business_apps.mapping_parent;

                    param[4] = new MySqlParameter("p_file_or_folder", MySqlDbType.Bool);
                    param[4].Value = obj_userapp_files_details_for_business_apps.file_or_folder;

                    param[5] = new MySqlParameter("p_file_or_folder_id", MySqlDbType.Int64);
                    param[5].Value = obj_userapp_files_details_for_business_apps.file_or_folder_id;

                    param[6] = new MySqlParameter("p_file_name", MySqlDbType.VarChar);
                    param[6].Value = obj_userapp_files_details_for_business_apps.file_name;

                    param[7] = new MySqlParameter("p_multiuser_file_access", MySqlDbType.Bool);
                    param[7].Value = obj_userapp_files_details_for_business_apps.multiuser_file_access;

                    param[8] = new MySqlParameter("p_file_type", MySqlDbType.VarChar);
                    param[8].Value = obj_userapp_files_details_for_business_apps.file_type;

                    param[9] = new MySqlParameter("p_uploaded_created_by_user_id", MySqlDbType.Int64);
                    param[9].Value = obj_userapp_files_details_for_business_apps.uploaded_created_by_user_id;

                    param[10] = new MySqlParameter("p_uploaded_created_timestamp", MySqlDbType.VarChar);
                    param[10].Value = obj_userapp_files_details_for_business_apps.uploaded_created_timestamp;

                    param[11] = new MySqlParameter("p_shared_user_id", MySqlDbType.Int64);
                    param[11].Value = obj_userapp_files_details_for_business_apps.shared_user_id;

                    param[12] = new MySqlParameter("p_file_size", MySqlDbType.Int64);
                    param[12].Value = obj_userapp_files_details_for_business_apps.file_size;

                    param[13] = new MySqlParameter("p_deleted_status", MySqlDbType.Bool);
                    param[13].Value = obj_userapp_files_details_for_business_apps.deleted_status;

                    param[14] = new MySqlParameter("p_cust_id", MySqlDbType.Int64);
                    param[14].Value = obj_userapp_files_details_for_business_apps.cust_id;

                    param[15] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                    param[15].Value = "Insert";

                    param[16] = new MySqlParameter("p_app_id", MySqlDbType.Int64);
                    param[16].Value = obj_userapp_files_details_for_business_apps.app_id;

                    param[17] = new MySqlParameter("p_file_storage_url", MySqlDbType.VarChar);
                    param[17].Value = mainobj.file_storage_url;

                    param[18] = new MySqlParameter("p_user_apps_data_folder_id", MySqlDbType.Int64);
                    param[18].Value = obj_userapp_files_details_for_business_apps.user_apps_data_folder_id;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_AddUserUserappListOfFilesForUserAppsFolderId", param);
                }

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";

                            response.Message = "Insert UserUserappListOfFilesForUserAppsFolderId successfully  !!";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }



        public Response UpdateUserUserappListOfFilesForUserAppsFolderId(userapp_files_details_for_business_apps obj_userapp_files_details_for_business_apps)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[11];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_file_id", MySqlDbType.Int64);
                    param[0].Value = obj_userapp_files_details_for_business_apps.file_id;

                    param[1] = new MySqlParameter("p_file_name", MySqlDbType.VarChar);
                    param[1].Value = obj_userapp_files_details_for_business_apps.file_name;

                    param[2] = new MySqlParameter("p_mapping_id", MySqlDbType.VarChar);
                    param[2].Value = obj_userapp_files_details_for_business_apps.mapping_id;

                    param[3] = new MySqlParameter("p_file_type", MySqlDbType.Int64);
                    param[3].Value = obj_userapp_files_details_for_business_apps.file_type;

                    param[4] = new MySqlParameter("p_file_created_timestamp", MySqlDbType.VarChar);
                    param[4].Value = obj_userapp_files_details_for_business_apps.uploaded_created_timestamp;

                    param[5] = new MySqlParameter("p_file_storage_url", MySqlDbType.VarChar);
                    param[5].Value = obj_userapp_files_details_for_business_apps.file_storage_url;

                    param[6] = new MySqlParameter("p_deleted_status", MySqlDbType.Bool);
                    param[6].Value = obj_userapp_files_details_for_business_apps.deleted_status;

                    param[7] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[7].Value = obj_userapp_files_details_for_business_apps.cust_id;

                    param[8] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[8].Value = obj_userapp_files_details_for_business_apps.uploaded_created_by_user_id;

                    param[9] = new MySqlParameter("p_user_apps_data_folder_id", MySqlDbType.Int64);
                    param[9].Value = obj_userapp_files_details_for_business_apps.uploaded_created_by_user_id;

                    param[10] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                    param[10].Value = "Update";

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_AddUserUserappListOfFilesForUserAppsFolderId", param);
                }

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";

                            response.Message = "Update UserUserappListOfFilesForUserAppsFolderId successfully  !!";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }
        public Response DeleteUserUserappListOfFilesForUserAppsFolderId(string Cust_Id, Int64 User_Id, Int64 App_Id, Int64 User_Apps_Data_Folder_Id, Int64 File_Id)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[5];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_Cust_Id", MySqlDbType.Int64);
                    param[0].Value = Cust_Id;

                    param[1] = new MySqlParameter("p_User_Id", MySqlDbType.VarChar);
                    param[1].Value = User_Id;

                    param[2] = new MySqlParameter("p_App_Id", MySqlDbType.VarChar);
                    param[2].Value = App_Id;

                    param[3] = new MySqlParameter("p_User_Apps_Data_Folder_Id", MySqlDbType.Int64);
                    param[3].Value = User_Apps_Data_Folder_Id;

                    param[4] = new MySqlParameter("p_File_Id", MySqlDbType.Int64);
                    param[4].Value = File_Id;



                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_DeleteUserUserappListOfFilesForUserAppsFolderId", param);
                }

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";

                            response.Message = "Deleted UserUserappListOfFilesForUserAppsFolderId successfully  !!";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }





        public Response InsertUserappFolderDetailsForBusinessApps(userapp_folder_details_for_business_apps obj_userapp_folder_details_for_business_apps)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();

            MySqlParameter[] param5 = new MySqlParameter[16];
            try
            {
                using MySqlConnection con5 = new MySqlConnection(connection);
                {

                    param5[0] = new MySqlParameter("p_user_apps_data_folder_id", MySqlDbType.Int64);
                    param5[0].Value = obj_userapp_folder_details_for_business_apps.user_apps_data_folder_id;

                    param5[1] = new MySqlParameter("p_folder_name", MySqlDbType.VarChar);
                    param5[1].Value = obj_userapp_folder_details_for_business_apps.folder_name;

                    param5[2] = new MySqlParameter("p_mapping_id", MySqlDbType.VarChar);
                    param5[2].Value = obj_userapp_folder_details_for_business_apps.mapping_id;

                    param5[3] = new MySqlParameter("p_is_folder", MySqlDbType.Bool);
                    param5[3].Value = obj_userapp_folder_details_for_business_apps.is_folder;

                    param5[4] = new MySqlParameter("p_mapping_parent", MySqlDbType.VarChar);
                    param5[4].Value = obj_userapp_folder_details_for_business_apps.mapping_parent;

                    param5[5] = new MySqlParameter("p_file_or_folder", MySqlDbType.Bool);
                    param5[5].Value = obj_userapp_folder_details_for_business_apps.file_or_folder;

                    param5[6] = new MySqlParameter("p_file_or_folder_id", MySqlDbType.Int64);
                    param5[6].Value = obj_userapp_folder_details_for_business_apps.file_or_folder_id;

                    param5[7] = new MySqlParameter("p_multiuser_folder_access", MySqlDbType.Bool);
                    param5[7].Value = obj_userapp_folder_details_for_business_apps.multiuser_folder_access;

                    param5[8] = new MySqlParameter("p_created_by_user_id", MySqlDbType.Int64);
                    param5[8].Value = obj_userapp_folder_details_for_business_apps.created_by_user_id;

                    param5[9] = new MySqlParameter("p_shared_user_id", MySqlDbType.Int64);
                    param5[9].Value = obj_userapp_folder_details_for_business_apps.shared_user_id;

                    param5[10] = new MySqlParameter("p_folder_size", MySqlDbType.Int64);
                    param5[10].Value = obj_userapp_folder_details_for_business_apps.folder_size;

                    param5[11] = new MySqlParameter("p_created_timestamp", MySqlDbType.VarChar);
                    param5[11].Value = obj_userapp_folder_details_for_business_apps.created_timestamp;

                    param5[12] = new MySqlParameter("p_deleted_status", MySqlDbType.Bool);
                    param5[12].Value = obj_userapp_folder_details_for_business_apps.deleted_status;

                    param5[13] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                    param5[13].Value = "Insert";

                    param5[14] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param5[14].Value = obj_userapp_folder_details_for_business_apps.cust_id;

                    param5[15] = new MySqlParameter("p_app_id", MySqlDbType.Int32);
                    param5[15].Value = obj_userapp_folder_details_for_business_apps.app_id;

                    ds = SqlHelpher.ExecuteDataset(con5, CommandType.StoredProcedure, "SP_InsertFolderDetailsForBusinessApps", param5);

                }
                string GetMaxId = Convert.ToString(ds.Tables[0].Rows[0]["MaxId"].ToString());

                MySqlParameter[] param6 = new MySqlParameter[4];
                try
                {
                    using MySqlConnection con6 = new MySqlConnection(connection);
                    {

                        param6[0] = new MySqlParameter("p_MaxId", MySqlDbType.Int32);
                        param6[0].Value = GetMaxId;

                        param6[1] = new MySqlParameter("p_created_by_user_id", MySqlDbType.Int64);
                        param6[1].Value = obj_userapp_folder_details_for_business_apps.created_by_user_id;

                        param6[2] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                        param6[2].Value = obj_userapp_folder_details_for_business_apps.cust_id;

                        param6[3] = new MySqlParameter("p_app_id", MySqlDbType.Int32);
                        param6[3].Value = obj_userapp_folder_details_for_business_apps.app_id;

                        ds1 = SqlHelpher.ExecuteDataset(con6, CommandType.StoredProcedure, "SP_DymamicallyCreated_userapp_files_details_for_business_apps", param6);
                    }
                }
                catch (Exception ex)
                {


                }
                if (Convert.ToString(ds1.Tables[0].Rows[0]["Message"]) == "200")
                {
                    response.Data = "";
                    response.Message = "Inserted successfully";
                    response.Status = true;
                }
                return response;
            }

            catch (Exception ex)
            {


            }
            return response;

        }















        public DataTable GetAllUserappFilesDetailsForBusinessApps(string Cust_Id, Int64 User_Id, int App_Id, int User_Apps_Data_Folder_Id, string Mapping_Id)
        {
            Response response = new Response();
            DataTable dsetfm = new DataTable();
            MySqlParameter[] param = new MySqlParameter[5];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[0].Value = User_Id;

                    param[1] = new MySqlParameter("p_cust_id", MySqlDbType.VarChar);
                    param[1].Value = Cust_Id;

                    param[2] = new MySqlParameter("p_App_Id", MySqlDbType.Int64);
                    param[2].Value = App_Id;

                    param[3] = new MySqlParameter("p_User_Apps_Data_Folder_Id", MySqlDbType.Int64);
                    param[3].Value = User_Apps_Data_Folder_Id;


                    param[4] = new MySqlParameter("p_Mapping_Id", MySqlDbType.VarChar);
                    param[4].Value = Mapping_Id;

                    dsetfm = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetAllUserappFilesDetailsForBusinessApps", param);
                    return dsetfm;

                }

            }

            catch (Exception ex)
            {

            }
            return dsetfm;
        }

    }

}


