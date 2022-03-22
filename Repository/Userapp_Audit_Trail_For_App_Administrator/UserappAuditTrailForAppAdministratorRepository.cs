using getbiz_cloud_file_storage_app.Getbiz_DbContext;
using getbiz_cloud_file_storage_app.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.Userapp_Audit_Trail_For_App_Administrator
{
    public class UserappAuditTrailForAppAdministratorRepository : IUserappAuditTrailForAppAdministratorRepository
    {
        public Response GetAllAndGetByIdUserappAuditTrailForAppAdministrator(string CustId, int UserId)
        {
            Response response = new Response();
            try
            {
                DataTable dset = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                dset = Obj_getsetdb.GetAllAndGetByIdUserappAuditTrailForAppAdministrator(CustId, UserId);

                List<userapp_audit_trail_for_app_administrator> userapp_audit_trail_for_app_administrator_Details = new List<userapp_audit_trail_for_app_administrator>();
                userapp_audit_trail_for_app_administrator_Details = ConvertDataTable<userapp_audit_trail_for_app_administrator>(dset);

                // string JSONresult;
                //JSONresult = JsonConvert.SerializeObject(dset);
                // response.Data = JSONresult;


                response.Data = (userapp_audit_trail_for_app_administrator_Details).ToList();
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
