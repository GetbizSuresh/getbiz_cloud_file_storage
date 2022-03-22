using getbiz_cloud_file_storage_app.Repository.Get_Delete_Folde_Activity_Log_By_Id;
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
    public class GetDeleteFolderActivityLogByIdController : ControllerBase
    {
        private IGetDeleteFolderActivityLogByIdRepository _getDeleteFolderActivityLogByIdRepository;

        public GetDeleteFolderActivityLogByIdController(IGetDeleteFolderActivityLogByIdRepository getDeleteFolderActivityLogByIdRepository)
        {
            _getDeleteFolderActivityLogByIdRepository = getDeleteFolderActivityLogByIdRepository;
        }


        [HttpGet]
        [Route("api/GetDeleteFolderActivityLogBtId")]
        public IActionResult GetDeleteFolderActivityLogBtId(string CustId, Int64 UserId)
        {
            try
            {
                var messages = _getDeleteFolderActivityLogByIdRepository.GetDeleteFolderActivityLogBtId(CustId, UserId);
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
