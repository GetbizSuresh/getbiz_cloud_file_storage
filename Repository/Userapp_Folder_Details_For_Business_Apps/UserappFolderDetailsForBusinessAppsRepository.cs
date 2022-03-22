using getbiz_cloud_file_storage_app.Getbiz_DbContext;
using getbiz_cloud_file_storage_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.User_Apps_Data
{
    public class UserappFolderDetailsForBusinessAppsRepository : IUserappFolderDetailsForBusinessAppsRepository
    {
        
            public readonly CloudFileStorageAppDB_DbContext _DbContext;
            public UserappFolderDetailsForBusinessAppsRepository(CloudFileStorageAppDB_DbContext DbContext)
            {
                _DbContext = DbContext;
            }

        public Response AddUserappFolderDetailsForBusinessApps(userapp_folder_details_for_business_apps obj_userapp_folder_details_for_business_apps)
        {
            Response response = new Response();
            try
            {                                                                                     
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                var result = getSetDatabase.AddUserappFolderDetailsForBusinessApps(obj_userapp_folder_details_for_business_apps);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error! While saving data";
            }
            return response;
        }


        public Response InsertUserappFolderDetailsForBusinessApps(userapp_folder_details_for_business_apps obj_userapp_folder_details_for_business_apps)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase getSetDatabase = new GetSetDatabase();
                var result = getSetDatabase.InsertUserappFolderDetailsForBusinessApps(obj_userapp_folder_details_for_business_apps);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error! While saving data";
            }
            return response;
        }


 
        public Response DeleteUserappFolderDetailsForBusinessAppsbyId(string CustId, long UserId, long AppId, long UserAppsDataFolderId)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.DeleteUserappFolderDetailsForBusinessAppsbyId(CustId, UserId, AppId, UserAppsDataFolderId);
                response = result;

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }














        Response IUserappFolderDetailsForBusinessAppsRepository.GetUserappFolderDetailsForBusinessAppsbyMappingParentBase(string CustId, long UserId, long AppId, string Mapping_Id)
        {
            Response response = new Response();
            try
            {
                DataTable dsetfm = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dsetfm = Obj_getsetdb.GetUserappFolderDetailsForBusinessAppsbyMappingParentBased(CustId, UserId, AppId,  Mapping_Id);

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
