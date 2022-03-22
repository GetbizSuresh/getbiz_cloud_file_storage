using getbiz_cloud_file_storage_app.Getbiz_DbContext;
using getbiz_cloud_file_storage_app.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.Userapp_New_User_Default_Storage_Limit
{
    public class UserappNewUserDefaultStorageLimitRepository : IUserappNewUserDefaultStorageLimitRepository
    {

            public readonly CloudFileStorageAppDB_DbContext _DbContext;
            public UserappNewUserDefaultStorageLimitRepository(CloudFileStorageAppDB_DbContext DbContext)
            {
                _DbContext = DbContext;
            }

       

        public Response GetUserAppNewUserDefaultStorageLimit(string CustId)
        {
            Response response = new Response();
            try
            {
                DataTable dset = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetUserAppNewUserDefaultStorageLimit(CustId);



                List<userapp_new_user_default_storage_limit> userapp_new_user_default_storage_limit_Details = new List<userapp_new_user_default_storage_limit>();
                userapp_new_user_default_storage_limit_Details = ConvertDataTable<userapp_new_user_default_storage_limit>(dset);
               

                
                response.Data = (userapp_new_user_default_storage_limit_Details).ToList();
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




        public Response UpdateUserAppNewUserDefaultStorageLimit(userapp_new_user_default_storage_limit obj_userapp_new_user_default_storage_limit)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.UpdateUserAppNewUserDefaultStorageLimit(obj_userapp_new_user_default_storage_limit);
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

