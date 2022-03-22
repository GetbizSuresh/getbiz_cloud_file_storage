using getbiz_cloud_file_storage_app.Getbiz_DbContext;
using getbiz_cloud_file_storage_app.Models;
using getbiz_cloud_file_storage_app.Repository.Files_Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Controllers
{
   
    [ApiController]
  //  [Authorize]
    public class FilesMasterController : ControllerBase
    {
        private IFilesMasterRepository _filesMasterRepository;

        private IConfiguration configuration;


        public readonly CloudFileStorageAppDB_DbContext _DbContext;

        public FilesMasterController(IFilesMasterRepository filesMasterRepository,  CloudFileStorageAppDB_DbContext DbContext, IConfiguration _configuration)
        {
            _filesMasterRepository = filesMasterRepository;

            _DbContext = DbContext;
            configuration = _configuration;
        }

        // [AllowAnonymous]
        [HttpPost]
        [Route("api/AddFilesMaster")]
        public async Task<IActionResult> AddFilesMaster([FromForm]files_master obj_file_master)
        {
            try
            {
            files_master mainobj = new files_master();  //   choose_photo

                //  string Serverpath = configuration.GetSection("ServerPath").Value;


                string Serverpath = configuration.GetSection("Serverpath").Value;
                string LiveServerpath = configuration.GetSection("LiveServerpath").Value;

                if (obj_file_master.file_storage_urls != null && obj_file_master.choose_photo == null)
                {
                     var Custidpath = LiveServerpath + obj_file_master.cust_id;
                   // var Custidpath = Serverpath + obj_file_master.cust_id;

                    if (!(Directory.Exists(Custidpath)))
                    {
                        Directory.CreateDirectory(Custidpath);

                         var UserIdpath = LiveServerpath +  obj_file_master.cust_id + "\\" + obj_file_master.uploaded_created_by_user_id;
                      //  var UserIdpath = Serverpath + obj_file_master.cust_id + "\\" + obj_file_master.uploaded_created_by_user_id;
                        if (!(Directory.Exists(UserIdpath)))
                        {
                            Directory.CreateDirectory(UserIdpath);
                            if (obj_file_master.file_storage_urls.Length <= 0) return BadRequest();
                            var filePath = Path.Combine(UserIdpath, obj_file_master.file_storage_urls.FileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))                                  // create directory here 
                             {
                                await obj_file_master.file_storage_urls.CopyToAsync(stream);
                            }
                            mainobj.file_storage_url = obj_file_master.file_storage_urls.FileName; // assign filename
                        }
                        else
                        {
                            if (obj_file_master.file_storage_urls.Length <= 0) return BadRequest();
                            var filePath = Path.Combine(UserIdpath, obj_file_master.file_storage_urls.FileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await obj_file_master.file_storage_urls.CopyToAsync(stream);
                            }
                            mainobj.file_storage_url = obj_file_master.file_storage_urls.FileName; // assign filename
                        }
                    }

                    else
                    {
                          var UserIdpath = LiveServerpath + obj_file_master.cust_id +"\\" + obj_file_master.uploaded_created_by_user_id;
                     //   var UserIdpath = Serverpath + obj_file_master.uploaded_created_by_user_id;

                        if (!(Directory.Exists(UserIdpath)))
                        {
                            Directory.CreateDirectory(UserIdpath);
                            if (obj_file_master.file_storage_urls.Length <= 0) return BadRequest();
                            var filePath = Path.Combine(UserIdpath, obj_file_master.file_storage_urls.FileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await obj_file_master.file_storage_urls.CopyToAsync(stream);
                            }
                            mainobj.file_storage_url = obj_file_master.file_storage_urls.FileName; // assign filename
                        }
                        else
                        {
                            if (obj_file_master.file_storage_urls.Length <= 0) return BadRequest();

                            var filePath = Path.Combine(UserIdpath, obj_file_master.file_storage_urls.FileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await obj_file_master.file_storage_urls.CopyToAsync(stream);
                            }

                            mainobj.file_storage_url = obj_file_master.file_storage_urls.FileName; //assign filename
                        }
                    }

                }







                else
                {
                     var Custidpath = LiveServerpath + obj_file_master.cust_id;
                   // var Custidpath = Serverpath + obj_file_master.cust_id;

                    if (!(Directory.Exists(Custidpath)))
                    {
                        Directory.CreateDirectory(Custidpath);

                      var UserIdpath = LiveServerpath + obj_file_master.cust_id + "\\" + obj_file_master.uploaded_created_by_user_id;
                      //    var UserIdpath = Serverpath + obj_file_master.cust_id + "\\" + obj_file_master.uploaded_created_by_user_id;
                        if (!(Directory.Exists(UserIdpath)))
                        {
                            byte[] imageBytes = Convert.FromBase64String(obj_file_master.choose_photo);
                            string file_name = obj_file_master.file_name + ".jpg";
                            
                            Directory.CreateDirectory(UserIdpath);
                           //  if (obj_file_master.choose_photo.Length <= 0) return BadRequest();

                            var filePath = Path.Combine(UserIdpath, file_name);
                            System.IO.File.WriteAllBytes(filePath, imageBytes);


                            mainobj.file_storage_url = file_name; // assign filename
                        }
                        else
                        {
                            byte[] imageBytes = Convert.FromBase64String(obj_file_master.choose_photo);
                            string file_name = obj_file_master.file_name + ".jpg";

                            Directory.CreateDirectory(UserIdpath);
                            //  if (obj_file_master.choose_photo.Length <= 0) return BadRequest();

                            var filePath = Path.Combine(UserIdpath, file_name);
                            System.IO.File.WriteAllBytes(filePath, imageBytes);



                            mainobj.file_storage_url = file_name; // assign filename
                        }
                    }
                    else
                    {
                       var UserIdpath = LiveServerpath + obj_file_master.cust_id + "\\" + obj_file_master.uploaded_created_by_user_id;

                        //  var UserIdpath = Serverpath + obj_file_master.cust_id + "\\" + obj_file_master.uploaded_created_by_user_id;
                        if (!(Directory.Exists(UserIdpath)))
                        {
                            byte[] imageBytes = Convert.FromBase64String(obj_file_master.choose_photo);
                            string file_name = obj_file_master.file_name + ".jpg";

                            Directory.CreateDirectory(UserIdpath);

                            var filePath = Path.Combine(UserIdpath, file_name);
                            System.IO.File.WriteAllBytes(filePath, imageBytes);


                            mainobj.file_storage_url = file_name; // assign filename
                        }
                        else
                        {
                            byte[] imageBytes = Convert.FromBase64String(obj_file_master.choose_photo);
                            string file_name = obj_file_master.file_name + ".jpg";

                            Directory.CreateDirectory(UserIdpath);
                            var filePath = Path.Combine(UserIdpath, file_name);
                            System.IO.File.WriteAllBytes(filePath, imageBytes);
                            mainobj.file_storage_url = file_name; // assign filename
                        }
                    }
                }
               var messages = _filesMasterRepository.AddFilesMaster(obj_file_master, mainobj);
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











        // [AllowAnonymous]
        [HttpGet]
        [Route("api/GetAllFileMaster")]
        public IActionResult GetAllFileMaster(string CustId,Int64 UserId)
        {
            try
            {
                var messages = _filesMasterRepository.GetAllFileMaster(CustId, UserId);
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






        // [AllowAnonymous]
        [HttpDelete]
        [Route("api/DeleteFileMaster")]
        public IActionResult DeleteFilesMaster(files_master obj_files_master)
        {
            try
            {
                var messages = _filesMasterRepository.DeleteFilesMaster(obj_files_master);
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
        [Route("api/UpdateFilesMaster")]
        public IActionResult UpdateFilesMaster(files_master obj_files_master)
        {
            try
            {
                var messages = _filesMasterRepository.UpdateFilesMaster(obj_files_master);
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
        [Route("api/FileRename")]
        public IActionResult FileRename(files_master obj_files_master)
        {
            try
            {
                var messages = _filesMasterRepository.FileRename(obj_files_master);
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
        [Route("api/GetFileActivityLog")]
        public IActionResult GetFilesActivity(string CustId, Int64 FileId)
        {
            try
            {
                var messages = _filesMasterRepository.GetFilesActivity(CustId, FileId);
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

        // [AllowAnonymous]
        [HttpGet]
        [Route("api/GetAllDeleteFilesAndFolders")]
        public IActionResult GetAllDeleteFilesAndFolders(string CustId, Int64 UserId)  //, 
        {
            try
            {
                var messages = _filesMasterRepository.GetAllDeleteFilesAndFolders(CustId, UserId);  //, UserId
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

        //[HttpDelete]
        //[Route("api/DeleteFilePermanently")]
        //public IActionResult DeleteFilePermanently(string CustId, Int64 FileId, Int64 UserId)
        //{
        //    try
        //    {
        //        var messages = _filesMasterRepository.DeleteFilePermanently(CustId, FileId, UserId);
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

        [HttpPut]
        [Route("api/UpdateFileDeleteStatus")]
        public IActionResult UpdateFileDeleteStatus(files_master obj_files_master)
        {
            try
            {
                var messages = _filesMasterRepository.UpdateFileDeleteStatus(obj_files_master);
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
        [Route("api/GetTotalFileSizeByUserId")]
        public IActionResult GetTotalFileSizeByUserId(string CustId, Int64 UserId)   
        {
            try
            {
                var messages = _filesMasterRepository.GetTotalFileSizeByUserId(CustId, UserId);  
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

        // [AllowAnonymous]
        [HttpDelete]
        [Route("api/DeleteFilePermanently")]
        public IActionResult DeleteFilePermanently(string CustId, Int64 FileId )
        {
            try
            {
                var messages = _filesMasterRepository.DeleteFilePermanently(CustId, FileId );
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



        //protected byte[] ConvertFile(IFormFile FileName  )
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        FileName.CopyTo(ms);
        //        var fileBytes = ms.ToArray();
        //        ms.Dispose();
        //        return (byte[])fileBytes;
        //    }
        //}

        //protected string SaveFile(byte[] FileName)
        //{
        //    string uniqueFileName = Guid.NewGuid().ToString() + "_" + FileName + ".png";
        //    using (MemoryStream mem = new MemoryStream(FileName))
        //    {
        //        using (var yourImage = Image.FromStream(mem))
        //        {
        //            var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "uploads")).Root + $@"\{uniqueFileName}";
        //            yourImage.Save(filepath, ImageFormat.Png);
        //        }
        //    }
        //    return uniqueFileName;
        //}



  


        //private byte[] ConvertFile(string v)
        //{
        //    throw new NotImplementedException();
        //}





        //private IFormFile SaveFile(string v)
        //{
        //    throw new NotImplementedException();
        //}





    }
}
