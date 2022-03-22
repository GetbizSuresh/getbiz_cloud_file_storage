using getbiz_cloud_file_storage_app.Getbiz_DbContext;
using getbiz_cloud_file_storage_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace getbiz_cloud_file_storage_app.Repository.Folder_Users_List_Permissions
{
    public class FolderUsersListPermissionsRepository : IFolderUsersListPermissionsRepository
    {
        public Response UpdateFolderPermissions(folder_users_list_permissions obj_folder_permissions)
        {
            Response response = new Response();
            try   
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.Updatefolderpermissions(obj_folder_permissions);
                response = result;
            }
            catch (Exception ex)                                       
            {
                response.Status = false;          
                response.Message = ex.Message;             
            }
            return response;
        }



        //public Response GetFolderPermissions(string CustId, int Maxid)
        //{
        //    Response response = new Response();
        //    try
        //    {
        //        DataTable dset = new DataTable();

        //        GetSetDatabase Obj_getsetdb = new GetSetDatabase();
        //        dset = Obj_getsetdb.GetFolderPermissions(CustId, Maxid);


        //        List<folder_users_list_permissions> folder_users_list_permissions_Details = new List<folder_users_list_permissions>();
        //        folder_users_list_permissions_Details = ConvertDataTable<folder_users_list_permissions>(dset);

        //        response.Data = (folder_users_list_permissions_Details).ToList();
        //        response.Message = "Data Fetch successfully !!";
        //        response.Status = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Status = false;
        //        response.Message = ex.Message;
        //    }
        //    return response;
        //}


        public Response GetFolderPermissions(string CustId, int FolerId, int UserId)
        {
            Response response = new Response();
            try
            {
                DataTable dset = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetFolderPermissions(CustId, FolerId, UserId);


                //List<folder_users_list_permissions> folder_users_list_permissions_Details = new List<folder_users_list_permissions>();
                //folder_users_list_permissions_Details = ConvertDataTable<folder_users_list_permissions>(dset);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dset);
                response.Data = JSONresult;

                response.Message = "Data Fetch successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

       

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                       
                            pro.SetValue(obj, dr[column.ColumnName], null);
                      
                        else
                            continue;
                }
            }
            return obj;
        }

        public Response AddFolderPermissions(folder_users_list_permissions obj_folder_users_list_permissions)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.AddFolderPermissions(obj_folder_users_list_permissions);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response DeleteUserForFolderPermissionsById(string CustId, int UserId,int FolderId)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.DeleteUserForFolderPermissionsById(CustId, UserId, FolderId);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
