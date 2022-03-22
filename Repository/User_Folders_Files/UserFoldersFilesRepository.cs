using getbiz_cloud_file_storage_app.Getbiz_DbContext;
using getbiz_cloud_file_storage_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.User_Folders_Files
{
    public class UserFoldersFilesRepository : IUserFoldersFilesRepository
    {
        public readonly CloudFileStorageAppDB_DbContext _DbContext;
        public UserFoldersFilesRepository(CloudFileStorageAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response AddUserFoldersFiles(user_folders_files obj_user_folders_files)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                    var result = Obj_getsetdb.AddUserFoldersFiles(obj_user_folders_files);
                    response = result;

         


            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response UpdateUserFoldersFiles(user_folders_files obj_user_folders_files)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.UpdateUserFoldersFiles(obj_user_folders_files);
                response = result;

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }





        public Response GetUserFolderFiles(string CustId, Int64 UserId, Int64 FileOrFolderId, Int64 FileId, Int64 FolderId)
        {
            Response response = new Response();
            try
            {
                DataSet dset = new DataSet();

                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                dset = Obj_GetSetDatabase.GetUserFolderFiles(CustId, UserId, FileOrFolderId,  FileId,  FolderId);



              //  List<user_folders_files> Details = new List<user_folders_files>();
             //   Details = ConvertDataTable<user_folders_files>(dset);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(dset);
                response.Data = JSONresult;

                //response.Data = (Details).ToList();

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
