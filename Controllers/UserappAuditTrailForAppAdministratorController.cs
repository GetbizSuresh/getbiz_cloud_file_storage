using getbiz_cloud_file_storage_app.Repository.Userapp_Audit_Trail_For_App_Administrator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize]
    public class UserappAuditTrailForAppAdministratorController : ControllerBase
    {

        private readonly IUserappAuditTrailForAppAdministratorRepository _userappAuditTrailForAppAdministratorRepository;

        public UserappAuditTrailForAppAdministratorController(IUserappAuditTrailForAppAdministratorRepository userappAuditTrailForAppAdministratorRepository)
        {
            _userappAuditTrailForAppAdministratorRepository = userappAuditTrailForAppAdministratorRepository;
        }



        [HttpGet]
        [Route("api/GetAllAndGetByIdUserappAuditTrailForAppAdministrator")]
        public IActionResult GetAllAndGetByIdUserappAuditTrailForAppAdministrator(string CustId,int UserId)
        {
            try
            {
                var messages = _userappAuditTrailForAppAdministratorRepository.GetAllAndGetByIdUserappAuditTrailForAppAdministrator(CustId, UserId);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
