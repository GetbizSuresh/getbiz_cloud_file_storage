using getbiz_cloud_file_storage_app.Getbiz_DbContext;
using getbiz_cloud_file_storage_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.User_Userapp_List_Of_Files_For_User_Apps_Folder_Id
{
    public class UserUserappListOfFilesForUserAppsFolderIdRepository : IUserUserappListOfFilesForUserAppsFolderIdRepository
    {

        public readonly CloudFileStorageAppDB_DbContext _DbContext;
        public UserUserappListOfFilesForUserAppsFolderIdRepository(CloudFileStorageAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response AddUserUserappListOfFilesForUserAppsFolderId(userapp_files_details_for_business_apps obj_userapp_files_details_for_business_apps, userapp_files_details_for_business_apps mainobj)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.AddUserUserappListOfFilesForUserAppsFolderId(obj_userapp_files_details_for_business_apps, mainobj);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public Response DeleteUserUserappListOfFilesForUserAppsFolderId(string Cust_Id, Int64 User_Id, Int64 App_Id, Int64 User_Apps_Data_Folder_Id, Int64 File_Id)

        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.DeleteUserUserappListOfFilesForUserAppsFolderId( Cust_Id,  User_Id,  App_Id,  User_Apps_Data_Folder_Id,  File_Id);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }



















        public Response GetAllUserappFilesDetailsForBusinessApps(string Cust_Id, Int64 User_Id, int App_Id, int User_Apps_Data_Folder_Id, string Mapping_Id)
        {
            Response response = new Response();
            try
            {
                DataTable dsetfm = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dsetfm = Obj_getsetdb.GetAllUserappFilesDetailsForBusinessApps(Cust_Id, User_Id, App_Id, User_Apps_Data_Folder_Id, Mapping_Id);



    

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dsetfm);
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
