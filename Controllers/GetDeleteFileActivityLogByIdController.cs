using getbiz_cloud_file_storage_app.Repository.Delete_Activity_Log_By_Id;
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
   // [Authorize]
    public class GetDeleteFileActivityLogByIdController : ControllerBase
    {


        private IGetDeleteFileActivityLogByIdRepository _getDeleteFileActivityLogByIdRepository;

        public GetDeleteFileActivityLogByIdController(IGetDeleteFileActivityLogByIdRepository getDeleteFileActivityLogByIdRepository)
        {
            _getDeleteFileActivityLogByIdRepository = getDeleteFileActivityLogByIdRepository;
        }


        [HttpGet]
        [Route("api/GetDeleteFileActivityLogById")]
        public IActionResult GetDeleteFileActivityLogById(string CustId, Int64 UserId)
        {
            try
            {
                var messages = _getDeleteFileActivityLogByIdRepository.GetDeleteFileActivityLogById(CustId, UserId );
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
