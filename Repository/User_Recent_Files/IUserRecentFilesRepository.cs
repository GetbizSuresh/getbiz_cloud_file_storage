using getbiz_cloud_file_storage_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.User_Recent_Files
{
    public interface IUserRecentFilesRepository
    {
        Response AddUserRecentFiles(user_recent_files user_recent_files);
        Response GetAllUserRecentFiles(string CustId, int UserId); //, Int64 FileId
    }
}
