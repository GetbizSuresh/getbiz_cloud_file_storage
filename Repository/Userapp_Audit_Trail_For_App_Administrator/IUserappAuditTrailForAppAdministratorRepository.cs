using getbiz_cloud_file_storage_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.Userapp_Audit_Trail_For_App_Administrator
{
    public interface IUserappAuditTrailForAppAdministratorRepository
    {

        Response GetAllAndGetByIdUserappAuditTrailForAppAdministrator(string CustId, int UserId);
    }
}
