using getbiz_cloud_file_storage_app.Getbiz_DbContext;
using getbiz_cloud_file_storage_app.Repository.Cloud_File_Storage_Users_Master;
using getbiz_cloud_file_storage_app.Repository.User_Apps_Data;
using getbiz_cloud_file_storage_app.Repository.User_Apps_Data_Folder_Id;
using getbiz_cloud_file_storage_app.Repository.User_Folders_Files;
using getbiz_cloud_file_storage_app.Repository.User_Notifications;
using getbiz_cloud_file_storage_app.Repository.User_Recent_Files;
using getbiz_cloud_file_storage_app.Repository.Folders_Master;
using getbiz_cloud_file_storage_app.Repository.Folder_Users_List_Permissions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using getbiz_cloud_file_storage_app.Repository.Files_Master;
using getbiz_cloud_file_storage_app.Repository.File_Users_List_Permissions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using getbiz_cloud_file_storage_app.Repository.Gps_Table;
using getbiz_cloud_file_storage_app.Repository.Cloud_File_Storage_App_Registeration;
using getbiz_cloud_file_storage_app.Repository.Delete_Activity_Log_By_Id;
using getbiz_cloud_file_storage_app.Repository.Get_Delete_Folde_Activity_Log_By_Id;
using getbiz_cloud_file_storage_app.Repository.Userapp_New_User_Default_Storage_Limit;
using getbiz_cloud_file_storage_app.Repository.Userapp_Audit_Trail_For_App_Administrator;
using getbiz_cloud_file_storage_app.Repository.User_App_New_User_Default_Storage_Log;
using getbiz_cloud_file_storage_app.Repository.Userapp_Folder_Path;
using getbiz_cloud_file_storage_app.Repository.User_Userapp_List_Of_Files_For_User_Apps_Folder_Id;

namespace getbiz_cloud_file_storage_app
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            String mySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<CloudFileStorageAppDB_DbContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "getbiz_cloud_file_storage_app", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                          Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          }
                        },
                        new string[]{}
                    }
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = Configuration["Jwt:Issuer"],
                   ValidAudience = Configuration["Jwt:Audience"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
               };
           });
            services.AddMvc();


            services.AddScoped<ICloudFileStorageUsersMasterRepository, CloudFileStorageUsersMasterRepository>();
            services.AddScoped<IUserappFolderDetailsForBusinessAppsRepository, UserappFolderDetailsForBusinessAppsRepository>();
            services.AddScoped<IUserAppsDataFolderIdRepository, UserAppsDataFolderIdRepository>();
            services.AddScoped<IUserNotificationsRepository, UserNotificationsRepository>();
            services.AddScoped<IUserRecentFilesRepository, UserRecentFilesRepository>();
            services.AddScoped<IUserFoldersFilesRepository, UserFoldersFilesRepository>();
            services.AddScoped<IFoldersMasterRepository, FoldersMasterRepository>();
            services.AddScoped<IFilesMasterRepository, FilesMasterRepository>();
            services.AddScoped<IFolderUsersListPermissionsRepository, FolderUsersListPermissionsRepository>();
            services.AddScoped<IFileUsersListPermissionsRepository, FileUsersListPermissionsRepository>();
            services.AddScoped<ICloudFileStorageAppRegisterationRepository, CloudFileStorageAppRegisterationRepository>();
            services.AddScoped<IGetDeleteFileActivityLogByIdRepository, GetDeleteFileActivityLogByIdRepository>();
            services.AddScoped<IGetDeleteFolderActivityLogByIdRepository, GetDeleteFolderActivityLogByIdRepository>();
            services.AddScoped<IGpsTableRepositoy, GpsTableRepositoy>();
            services.AddScoped<IUserappNewUserDefaultStorageLimitRepository, UserappNewUserDefaultStorageLimitRepository>();        
            services.AddScoped<IUserappAuditTrailForAppAdministratorRepository, UserappAuditTrailForAppAdministratorRepository>();
            services.AddScoped<IUserAppNewUserDefaultStorageLogRepository, UserAppNewUserDefaultStorageLogRepository>();
            services.AddScoped<IUserappFolderPathRepository, UserappFolderPathRepository>();
            services.AddScoped<IUserUserappListOfFilesForUserAppsFolderIdRepository, UserUserappListOfFilesForUserAppsFolderIdRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "getbiz_cloud_file_storage_app v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true)
               .AllowCredentials());

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
