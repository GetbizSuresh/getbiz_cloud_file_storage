using getbiz_cloud_file_storage_app.Getbiz_DbContext;
using getbiz_cloud_file_storage_app.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CloudFileStorageAppLoginController : ControllerBase
    {
        public CloudFileStorageAppDB_DbContext _DBContext;
        public IConfiguration _configuration;

        public CloudFileStorageAppLoginController(IConfiguration configuration, CloudFileStorageAppDB_DbContext DBContext)
        {
            _DBContext = DBContext;
            _configuration = configuration;
        }
 
      // string connection = "Server=localhost;User ID=root;Password=mysql;Database=cloudfilestorageappdb; Allow User Variables=true";

        string connection = "Server=185.252.235.20;User ID=root;Password=GetBizMysqlDatabasePwd2021@;Database=cloudfilestorageappdb; Allow User Variables=true";
        [HttpGet]
        [Route("api/GetCloudFileStorageAppLoginDetails")]
        public IActionResult GetUser(string Cust_Id, string MobileNo, string Password)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();

            MySqlParameter[] param = new MySqlParameter[3];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_MobileNo", MySqlDbType.VarChar);
                    param[0].Value = MobileNo;

                    param[1] = new MySqlParameter("p_Password", MySqlDbType.VarChar);
                    param[1].Value = Password;

                    param[2] = new MySqlParameter("p_Cust_Id", MySqlDbType.VarChar);
                    param[2].Value = Cust_Id;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_GetLoginData", param);
                    // return Ok(ds);
                }
            }
            catch (Exception ex)
            {

            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                var mobile_no = ds.Tables[0].Rows[0]["mobile_no"].ToString();
                var password = ds.Tables[0].Rows[0]["password"].ToString();

                if (mobile_no != null && password != null)
                {                 
                        var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                        new Claim("MobileNo", mobile_no),
                        new Claim("Password", password)
                        };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                            claims,
                            expires: DateTime.Now.AddMinutes(1),
                            signingCredentials: signIn);

                        var authkey = "Bearer " + new JwtSecurityTokenHandler().WriteToken(token);

                        MySqlParameter[] param1 = new MySqlParameter[4];
                        try
                        {
                            using MySqlConnection con1 = new MySqlConnection(connection);
                            {
                                param1[0] = new MySqlParameter("p_authkey", MySqlDbType.VarChar);
                                param1[0].Value = authkey;

                                param1[1] = new MySqlParameter("p_MobileNo", MySqlDbType.VarChar);
                                param1[1].Value = MobileNo;

                                param1[2] = new MySqlParameter("p_Password", MySqlDbType.VarChar);
                                param1[2].Value = Password;

                                param1[3] = new MySqlParameter("p_Cust_Id", MySqlDbType.VarChar);
                                param1[3].Value = Cust_Id;

                                ds1 = SqlHelpher.ExecuteDataset(con1, CommandType.StoredProcedure, "SP_AssignAuthkey", param1);
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                        return new JsonResult(new { result = "successfully Login..!!", mobile_no, password,  Token = new JwtSecurityTokenHandler().WriteToken(token) });               
                }
                else
                {
                    return BadRequest("Invalid credentials......!!!");
                }
            }
            else
            {
                return BadRequest("Invalid credentials........!!");
            }


        }
    }
}
