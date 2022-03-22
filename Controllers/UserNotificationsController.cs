using getbiz_cloud_file_storage_app.Models;
using getbiz_cloud_file_storage_app.Repository.User_Notifications;
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
  //   [Authorize]
    public class UserNotificationsController : ControllerBase
    {

        private IUserNotificationsRepository _userNotificationsRepository;

        public UserNotificationsController(IUserNotificationsRepository userNotificationsRepository)
        {
            _userNotificationsRepository = userNotificationsRepository;
        }

        



        [HttpGet]
        [Route("api/GetUserNotificationsById")]
        public IActionResult GetUserNotificationsById(string CustId, Int64 UserId)
        {
            try
            {
                var messages = _userNotificationsRepository.GetUserNotificationsById(CustId,UserId);
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
   
        [Route("api/GetUserNotificationsCountById")]
        public IActionResult GetUserNotificationsCountById(string CustId, Int64 UserId)
        {
            try
            {
                var messages = _userNotificationsRepository.GetUserNotificationsCountById(CustId, UserId);
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



        [HttpPut]
        [Route("api/UpdateNotificationStatus")]
        public IActionResult UpdateNotificationStatus(user_notifications obj_user_notifications)
        {
            try
            {
                var messages = _userNotificationsRepository.UpdateNotificationStatus(obj_user_notifications);
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
