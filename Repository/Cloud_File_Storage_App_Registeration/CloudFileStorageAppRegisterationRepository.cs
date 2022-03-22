using getbiz_cloud_file_storage_app.Getbiz_DbContext;
using getbiz_cloud_file_storage_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.Cloud_File_Storage_App_Registeration
{
    public class CloudFileStorageAppRegisterationRepository : ICloudFileStorageAppRegisterationRepository
    {


        private CloudFileStorageAppDB_DbContext _cloudFileStorageAppDB_DbContext;

        public CloudFileStorageAppRegisterationRepository(CloudFileStorageAppDB_DbContext cloudFileStorageAppDB_DbContext)
        {
            _cloudFileStorageAppDB_DbContext = cloudFileStorageAppDB_DbContext;
        }

        public Response CloudFileStorageAppRegisteration(cloud_file_storage_app_registeration obj_cloud_file_storage_app_registeration)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.CloudFileStorageAppRegisteration(obj_cloud_file_storage_app_registeration);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public Response GetAllCloudFileStorageAppRegisteration(string CustId)
        {
            Response response = new Response();
            try
            {
                 DataTable dset = new DataTable();

                 GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetAllCloudFileStorageAppRegisteration(CustId);


                // List<cloud_file_storage_app_registeration> cloud_file_storage_app_registeration_Details = new List<cloud_file_storage_app_registeration>();
                //cloud_file_storage_app_registeration_Details = ConvertDataTable<cloud_file_storage_app_registeration>(dset);

                //response.Data = (cloud_file_storage_app_registeration_Details).ToList();

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
