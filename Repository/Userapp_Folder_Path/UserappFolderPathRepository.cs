using getbiz_cloud_file_storage_app.Getbiz_DbContext;
using getbiz_cloud_file_storage_app.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.Userapp_Folder_Path
{
    public class UserappFolderPathRepository : IUserappFolderPathRepository
    {
        private readonly  CloudFileStorageAppDB_DbContext _cloudFileStorageAppDB_DbContext;

        public UserappFolderPathRepository(CloudFileStorageAppDB_DbContext cloudFileStorageAppDB_DbContext)
        {
            _cloudFileStorageAppDB_DbContext = cloudFileStorageAppDB_DbContext;
        }















        public Response UpdateFolderPath(userapp_folder_path obj_userapp_folder_path)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.UpdateFolderPath(obj_userapp_folder_path);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }



        public Response GetUserAppFolderPath(string UserId)
        {
            Response response = new Response();
            try
            {
                DataTable dset = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetUserAppFolderPath(UserId);


                List<userapp_folder_path> userapp_folder_path_details = new List<userapp_folder_path>();
                userapp_folder_path_details = ConvertDataTable<userapp_folder_path>(dset);


                response.Data = (userapp_folder_path_details).ToList();
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


        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
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





















    }
}
