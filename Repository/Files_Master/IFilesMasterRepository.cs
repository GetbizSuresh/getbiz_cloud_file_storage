using getbiz_cloud_file_storage_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.Files_Master
{
    public interface IFilesMasterRepository
    {
        Response AddFilesMaster(files_master obj_file_master, files_master mainobj);
        Response DeleteFilesMaster(files_master obj_files_master);

        Response UpdateFilesMaster(files_master obj_files_master);
    
        Response FileRename(files_master obj_files_master);
        Response GetAllFileMaster(string CustId, Int64 UserId);
        Response GetFilesActivity(string CustId, Int64 FileId);





        Response GetAllDeleteFilesAndFolders(string CustId, Int64 UserId);
 


        Response UpdateFileDeleteStatus(files_master obj_files_master);



        Response GetTotalFileSizeByUserId(string CustId, Int64 UserId);
       
        Response DeleteFilePermanently(string custId, long fileId  );
    }
}
