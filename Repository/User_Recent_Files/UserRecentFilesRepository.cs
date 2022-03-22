using getbiz_cloud_file_storage_app.Getbiz_DbContext;
using getbiz_cloud_file_storage_app.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.User_Recent_Files
{
    public class UserRecentFilesRepository : IUserRecentFilesRepository
    {
        public readonly CloudFileStorageAppDB_DbContext _DbContext;
        public UserRecentFilesRepository(CloudFileStorageAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response AddUserRecentFiles(user_recent_files user_recent_files)
        {
            Response response = new Response();
            try
            {
                UserRecentFilesGetSetDatabase userRecentFilesGetSetDatabase = new UserRecentFilesGetSetDatabase();
                var result = userRecentFilesGetSetDatabase.AddUserRecentFiles(user_recent_files);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error! While saving data";
            }
            return response;
        }


        public Response GetAllUserRecentFiles(string CustId, int UserId)  //, 
        {
            Response response = new Response();
            try
            {
                DataTable dset = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetAllUserRecentFiles(CustId, UserId);   //, FileId


                List<files_master> User_Recent_Files_Details = new List<files_master>();
                User_Recent_Files_Details = ConvertDataTable<files_master>(dset);

                response.Data = (User_Recent_Files_Details).ToList();
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
