using getbiz_cloud_file_storage_app.Getbiz_DbContext;
using getbiz_cloud_file_storage_app.Models;
using Humanizer.Bytes;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.Cloud_File_Storage_Users_Master
{
    public class CloudFileStorageUsersMasterRepository : ICloudFileStorageUsersMasterRepository
    {
        public readonly CloudFileStorageAppDB_DbContext _DbContext;


        public CloudFileStorageUsersMasterRepository(CloudFileStorageAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response AddCloudFileStorageUsersMaster(cloud_file_storage_users_master obj_cloud_file_storage_users_master)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase obj_GetSetDatabase = new GetSetDatabase();
                var result = obj_GetSetDatabase.AddCloudFileStorageUsersMaster(obj_cloud_file_storage_users_master);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error! While saving data";
            }
            return response;
        }

        public Response DeleteCloudFileStorageUsersMaster(string CustId, int UserId)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.DeleteCloudFileStorageUsersMaster(CustId, UserId);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public Response UpdateCloudFileStorageUsersMaster(cloud_file_storage_users_master obj_cloud_file_storage_users_master)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.UpdateCloudFileStorageUsersMaster(obj_cloud_file_storage_users_master);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }






        public Response GetAllCloudFileStorageUsersMaster(string CustId, int UserId)
        {
            Response response = new Response();
            test test_response = new test();
            List<test> obj_test = new List<test>();

            try
            {         
                DataTable dset = new DataTable();
        
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetAllCloudFileStorageUsersMaster(CustId, UserId);

               // obj_test = ConvertDataTable<test>(dset);
                foreach(DataRow row in dset.Rows)
                {

                    var storage_limit_in_mb = Convert.ToInt64(row["storage_limit_in_mb"].ToString());

                    var user_id = Convert.ToInt32(row["user_id"]);
                    var user_app_joining_timestamp = Convert.ToDateTime(row["user_app_joining_timestamp"].ToString());
                    var block_app_access = Convert.ToBoolean(row["block_app_access"]);
                    var photo_id = Convert.ToString(row["photo_id"]);
                    var user_name = Convert.ToString(row["user_name"]);

                    //   var test = Tuple.Create(test_response.storage_limit_in_mb, test_response.user_id, test_response.user_app_joining_timestamp, test_response.block_app_access, test_response.photo_id, test_response.user_name);

                    test objtest = new test();
                    objtest.user_id = user_id;
                    objtest.user_app_joining_timestamp = user_app_joining_timestamp;
                    objtest.block_app_access = block_app_access;
                    objtest.photo_id = photo_id;
                    objtest.user_name = user_name;
                  //  objtest.storage_limit_in_mb = FormatSize(storage_limit_in_mb);
                  //  var storage_limit_in_mb_1 = Convert.ToDouble(FormatSize(storage_limit_in_mb));
                    var storage_limit_in_mb_1 = FormatSize(storage_limit_in_mb);
                    decimal  storage_limit_in_mb_5 = Convert.ToDecimal(storage_limit_in_mb_1.Replace(" '' ", ""));
                    var result = Math.Round(storage_limit_in_mb_5);
                    objtest.storage_limit_in_mb = Convert.ToInt32(result);


                    obj_test.Add(objtest);

       
                    string JSONresult;
                    JSONresult = JsonConvert.SerializeObject(obj_test);

                    response.Data = JSONresult;
                    response.Message = "Data Fetch successfully !!";
                    response.Status = true;


                }
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


        //// convert bytes to MB 
        ///     // static readonly string[] suffixes ={ "Bytes", "KB", "MB", "GB", "TB", "PB" };      1 byte, 2 mb ,
        public static string FormatSize(Int64 storage_limit_in_mb)
        {
            int counter = 0;
            decimal number = (Int64)storage_limit_in_mb;
            while (Math.Round(number / 1024) >= 2)
            {
                number = number / 1024;
                counter++;
            }
           // return string.Format("{0:n1}{1}", number, suffixes[counter]);
            return string.Format("{0:n1}{1}", number,counter);
        }








    }


}
