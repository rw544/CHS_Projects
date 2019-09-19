using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CHSYesWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using CHSYesWebApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using CHSYesWebApp.Data;
using Microsoft.AspNetCore.Authorization;
using CHSYesWebApp.Authorization;
using Microsoft.AspNetCore.Http;
using CHSYesWebApp.Pages.ServiceForms;
using System.Data;

namespace CHSYesWebApp.Pages
{
    public class StudentHourChartModel : DI_BasePageModel
    {
        public StudentHourChartModel(
                CHSYesWebAppContext context,
                IAuthorizationService authorizationService,
                UserManager<CHSYesWebAppUser> userManager)
                : base(context, authorizationService, userManager)
        {

        }

        public IList<HoursByOrganization> ChartHoursByOrganization { get; set; }
       
        public async Task OnGetAsync(string serviceOrganization, string searchString)
        {

            var userName = UserManager.GetUserId(User);

            // Use LINQ to get list of genres.

            IQueryable<string> serviceQuery = from m in Context.ServiceForm
                                              orderby m.ServiceDescription
                                              select m.ServiceDescription;

            var serviceForms = from s in Context.ServiceForm
                               select s;

          
            var currentUserId = UserManager.GetUserId(User);
            CHSYesWebAppUser webAppUser = await UserManager.GetUserAsync(User);
            var isAuthorized = await UserManager.IsInRoleAsync(webAppUser, Constants.ServiceFormManagersRole) ||
                               await UserManager.IsInRoleAsync(webAppUser, Constants.ServiceFormAdministratorsRole);

            
            if (!isAuthorized)
            {
    
                 
                 var chartQuery =
                          from p in Context.ServiceForm
                          where p.OwnerID == currentUserId
                          group p by p.OrganizationName into g
                          
                          select new HoursByOrganization() { OrganizationName = g.Key.ToString(), TotalHours = g.Sum(p => p.HourOfService).ToString() };


                ChartHoursByOrganization = await chartQuery.ToListAsync();
            }
            else
            {

                serviceForms = serviceForms.Where(x => x.OwnerID == currentUserId);
                var chartQuery =
                          from p in Context.ServiceForm
                          group p by p.OrganizationName into g

                          select new HoursByOrganization() { OrganizationName = g.Key.ToString(), TotalHours = g.Sum(p => p.HourOfService).ToString() };
                ChartHoursByOrganization = await chartQuery.ToListAsync();

            }
        }

        public JsonResult OnGetList()
        {
            List<object> iData = new List<object>();
            //Creating sample data  
            DataTable dt = new DataTable();
            dt.Columns.Add("Employee", System.Type.GetType("System.String"));
            dt.Columns.Add("Credit", System.Type.GetType("System.Int32"));

            DataRow dr = dt.NewRow();
            dr["Employee"] = "Sam";
            dr["Credit"] = 123;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Employee"] = "Alex";
            dr["Credit"] = 456;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Employee"] = "Michael";
            dr["Credit"] = 587;
            dt.Rows.Add(dr);
            //Looping and extracting each DataColumn to List<Object>  
            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }
            //Source data returned as JSON  
            return new JsonResult(iData);

            /*
            List<string> lstString = new List<string>
            {
                "Val 1",
                "Val 2",
                "Val 3"
            };
            return new JsonResult(lstString);
            */
        }
    }

    public class HoursByOrganization
    {
        public string OrganizationName { get; set; }
        public string TotalHours { get; set; }
    }
}