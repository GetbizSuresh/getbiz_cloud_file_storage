using getbiz_cloud_file_storage_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.Delete_Activity_Log_By_Id
{
    public interface IGetDeleteFileActivityLogByIdRepository
    {

        Response GetDeleteFileActivityLogById(string CustId, Int64 UserId);
           
    }
}
