using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CHSYesWebApp.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the CHSYesWebAppUser class
    public class CHSYesWebAppUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string LastName { get; set; }

        [PersonalData]
        public string ClassOf { get; set; }

        [PersonalData]
        public string ThirdPeriodTeacher { get; set; }
    }
}
