using getbiz_cloud_file_storage_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.Get_Delete_Folde_Activity_Log_By_Id
{
    public interface IGetDeleteFolderActivityLogByIdRepository
    {
        Response GetDeleteFolderActivityLogBtId(string CustId, Int64 UserId);
    }
}
