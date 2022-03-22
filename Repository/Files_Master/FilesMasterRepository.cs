using getbiz_cloud_file_storage_app.Getbiz_DbContext;
using getbiz_cloud_file_storage_app.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;
using Microsoft.Extensions.Configuration;


namespace getbiz_cloud_file_storage_app.Repository.Files_Master
{
    public class FilesMasterRepository : IFilesMasterRepository
    {

        public readonly CloudFileStorageAppDB_DbContext _DbContext;
            public FilesMasterRepository(CloudFileStorageAppDB_DbContext DbContext)
            {
                _DbContext = DbContext;
            }

        public Response AddFilesMaster(files_master obj_file_master, files_master mainobj)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.AddFilesMaster(obj_file_master, mainobj);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public Response DeleteFilesMaster(files_master obj_files_master)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.DeleteFileMaster(obj_files_master);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response UpdateFilesMaster(files_master obj_files_master)
          {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.UpdateFilesMaster(obj_files_master);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response FileRename(files_master obj_files_master)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.FileRename(obj_files_master);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public Response GetAllFileMaster(string CustId, Int64 UserId)
        {
            Response response = new Response();
            try
            {
                DataTable dset = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset= Obj_getsetdb.GetAllFileMaster(CustId, UserId);


                //List<files_master> files_master_Details = new List<files_master>();
                //files_master_Details = ConvertDataTable<files_master>(dset);
                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dset);

                response.Data = JSONresult;
                //response.Data = (files_master_Details).ToList();
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






        public Response GetFilesActivity(string CustId, Int64 FileId)
        {
            Response response = new Response();
            try
            {
                DataTable dset = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetFilesActivity(CustId, FileId);
                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dset);

                //List<file_activity_log> file_activity_Details = new List<file_activity_log>();
                //file_activity_Details = ConvertDataTable<file_activity_log>(dset);

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
        // ////////////////////////////////////////////




        public Response GetAllDeleteFilesAndFolders(string CustId, Int64 UserId) //, 
        {
            Response response = new Response();
            try
            {
                DataSet dset = new DataSet();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetAllDeleteFilesAndFolders(CustId, UserId);   //, UserId

                //List<files_master> files_master_Details = new List<files_master>();
                //files_master_Details = ConvertDataTable<files_master>(dset);
                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dset);

                response.Data = JSONresult;
                //response.Data = (files_master_Details).ToList();
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




      
        public Response UpdateFileDeleteStatus(files_master obj_files_master)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.UpdateFileDeleteStatus(obj_files_master);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }








        public Response GetTotalFileSizeByUserId(string CustId, Int64 UserId)
        {
            Response response = new Response();
            try
            {
                DataSet dset = new DataSet();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetTotalFileSizeByUserId(CustId, UserId);  

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




        public Response DeleteFilePermanently(string custId, long fileId  )
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.DeleteFilePermanently(custId, fileId );
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
