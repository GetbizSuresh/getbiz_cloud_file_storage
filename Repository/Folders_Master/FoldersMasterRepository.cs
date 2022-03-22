using getbiz_cloud_file_storage_app.Getbiz_DbContext;
using getbiz_cloud_file_storage_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Data;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace getbiz_cloud_file_storage_app.Repository.Folders_Master
{
    public class FoldersMasterRepository : IFoldersMasterRepository
    {
        public readonly CloudFileStorageAppDB_DbContext _DbContext;
        public FoldersMasterRepository(CloudFileStorageAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response AddFoldersmaster(folders_master obj_folders_master)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.Addfoldermaster(obj_folders_master);
                response = result;

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response DeleteFoldersMaster(folders_master obj_folders_master)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.DeleteFoldersMaster(obj_folders_master);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }



        public Response UpdateFolderMaster(folders_master obj_folders_master)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.UpdateFolderMaster(obj_folders_master);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public Response FolderRename(folders_master obj_folders_master)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.FolderRename(obj_folders_master);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }



        public Response GetAllFolderMaster(string CustId, Int64 UserId)
        {
            Response response = new Response();
            try
            {
                DataTable dset = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetAllFolderMaster(CustId, UserId);

                //  files_master objfilemaster = new files_master();

                // List<folders_master> folders_master_details = new List<folders_master>();
                //folders_master_details = ConvertDataTable<folders_master>(dset);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dset);
                response.Data = JSONresult;

                // response.Data = (folders_master_details).ToList();
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




        public Response GetFolderActivity(string CustId, Int64 FolderId)
        {
            Response response = new Response();
            try
            {
                DataTable dset = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetFolderActivity(CustId, FolderId);

                //List<folder_activity_log_copy> folder_activity_Details = new List<folder_activity_log_copy>();
                //folder_activity_Details = ConvertDataTable<folder_activity_log_copy>(dset);


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



        // ////////////////////////// 27112021



        public Response GetAllFoldersByParentFieldBased(string CustId)
        {
            Response response = new Response();
            try
            {
                DataTable dset = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetAllFoldersByParentFieldBased(CustId);

                // List<folders_master> folders_master_details = new List<folders_master>();
                //folders_master_details = ConvertDataTable<folders_master>(dset);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dset);
                response.Data = JSONresult;

                // response.Data = (folders_master_details).ToList();
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

        //

        public Response GetAllFoldersByParentFieldBasedById(string CustId, Int64 UserId)
        {
            Response response = new Response();
            try
            {
                DataTable dset = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetAllFoldersByParentFieldBasedById(CustId, UserId);

                // List<folders_master> folders_master_details = new List<folders_master>();
                //folders_master_details = ConvertDataTable<folders_master>(dset);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dset);
                response.Data = JSONresult;

                // response.Data = (folders_master_details).ToList();
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

        public Response GetAllFolderFilesViewDetails(string CustId, Int64 UserId, string MappingId, Int64 FromUserId)
        {
            Response response = new Response();
            try
            {
                DataSet dset = new DataSet();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetAllFolderFilesViewDetails(CustId, UserId, MappingId, FromUserId);


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

        public Response UpdateFolderDeletedStatus(folders_master obj_folders_master)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.UpdateFolderDeletedStatus(obj_folders_master);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }




        public Response DeleteFolderPermanently(string CustId, Int64 FolderId, Int64 UserId , string MappingId)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.DeleteFolderPermanently(CustId, FolderId, UserId, MappingId);
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
