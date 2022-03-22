using getbiz_cloud_file_storage_app.Models;
using getbiz_cloud_file_storage_app.Repository.User_Apps_Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Controllers
{
   
    [ApiController]
   //  [Authorize]
    public class UserappFolderDetailsForBusinessAppsController : ControllerBase
    {
        private IUserappFolderDetailsForBusinessAppsRepository _userAppsDataRepository;

        public UserappFolderDetailsForBusinessAppsController(IUserappFolderDetailsForBusinessAppsRepository userAppsDataRepository)
        {
            _userAppsDataRepository = userAppsDataRepository;
        }

       //  [AllowAnonymous]
        [HttpPost]
        [Route("api/CreateUserappData")]
        public IActionResult AddUserappFolderDetailsForBusinessApps(userapp_folder_details_for_business_apps obj_userapp_folder_details_for_business_apps)
        {
            try
            {
                var messages = _userAppsDataRepository.AddUserappFolderDetailsForBusinessApps(obj_userapp_folder_details_for_business_apps);
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


        [HttpPost]
        [Route("api/InsertUserappFolderDetailsForBusinessApps")]
        public IActionResult InsertUserappFolderDetailsForBusinessApps(userapp_folder_details_for_business_apps obj_userapp_folder_details_for_business_apps)
        {
            try
            {
                var messages = _userAppsDataRepository.InsertUserappFolderDetailsForBusinessApps(obj_userapp_folder_details_for_business_apps);
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



        [HttpGet]
        [Route("api/GetUserappFolderDetailsForBusinessAppsbyMappingParentBased")]
        public IActionResult GetUserappFolderDetailsForBusinessAppsbyMappingParentBased(string CustId, Int64 UserId, Int64 AppId, string Mapping_Id)
        {
            try
            {
                var messages = _userAppsDataRepository.GetUserappFolderDetailsForBusinessAppsbyMappingParentBase(CustId, UserId, AppId, Mapping_Id);
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



        [HttpDelete]
        [Route("api/DeleteUserappFolderDetailsForBusinessAppsbyId")]
        public IActionResult DeleteUserappFolderDetailsForBusinessAppsbyId(string CustId, Int64 UserId, Int64 AppId, Int64 UserAppsDataFolderId)
        {
            try
            {
                var messages = _userAppsDataRepository.DeleteUserappFolderDetailsForBusinessAppsbyId(CustId, UserId, AppId, UserAppsDataFolderId);
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















        //[HttpPut]
        //[Route("api/UpdateUserappFolderDetailsForBusinessApps")]
        //public IActionResult UpdateUserappFolderDetailsForBusinessApps(userapp_folder_details_for_business_apps obj_userapp_folder_details_for_business_apps)
        //{
        //    try
        //    {
        //        var messages = _userAppsDataRepository.UpdateUserappFolderDetailsForBusinessApps(obj_userapp_folder_details_for_business_apps);
        //        if (messages == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(messages);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest();
        //    }

        //}



        //[HttpGet]
        //[Route("api/GetUserappFolderDetailsForBusinessAppsbyMappingParentBased")]
        //public IActionResult GetUserappFolderDetailsForBusinessAppsbyMappingParentBased(string CustId, Int64 UserId)
        //{
        //    try
        //    {
        //        var messages = _userAppsDataRepository.GetUserappFolderDetailsForBusinessAppsbyMappingParentBased(CustId, UserId);
        //        if (messages == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(messages);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest();
        //    }
        //}







    }

}
