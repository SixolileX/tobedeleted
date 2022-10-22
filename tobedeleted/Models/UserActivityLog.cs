using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tobedeleted.Data;

namespace tobedeleted.Models
{
    public class UserActivityLogFilter : IActionFilter
    {
        private readonly ApplicationDbContext _context;
        public UserActivityLogFilter(ApplicationDbContext context)
        {
            this._context = context;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
        
        public void OnActionExecuting(ActionExecutingContext context)
        { var data = "";
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];
            var url = $"{controllerName}/{actionName}";
            if (!String.IsNullOrEmpty(context.HttpContext.Request.QueryString.Value))
            {
                data = context.HttpContext.Request.QueryString.Value;
            }
            else 
            { 
                var userData = context.ActionArguments.FirstOrDefault();
                var stringUserData = JsonConvert.SerializeObject(userData);

                data = stringUserData;
            }
            var userName = context.HttpContext.User.Identity.Name;
            var ipAdress = context.HttpContext.Connection.RemoteIpAddress.ToString();
            StoreUserActivity(data, url, userName, ipAdress);
        }
        public void StoreUserActivity(string data, string url, string userName, string ipAddress)
        {
            var userActivity = new UserActivity
            {
                Data = data,
                Url = url,
                UserName = userName,
                IpAddress = ipAddress
            };
            _context.UserActivities.Add(userActivity);
            _context.SaveChanges();
        }
    }
}
