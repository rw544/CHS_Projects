using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CHSYesWebApp.Models
{
    public class ServiceForm
    {
        [DisplayName("Service ID")]
        public int ServiceFormId { get; set; }

        [DisplayName("Service ID")]
        public DateTime ServiceDate { get; set; }

        [DisplayName("Service Hours")]
        public double HourOfService { get; set; }

        [DisplayName("Service Description")]
        public string ServiceDescription { get; set; }

        [DisplayName("Rewarded For Service?")]
        public bool RewardedForService { get; set; }

        [DisplayName("Student Signature")]
        public string StudentSignature { get; set; }

        [DisplayName("Organization Name")]
        public string OrganizationName { get; set; }

        [DisplayName("Organization Phone")]
        public string OrganizationPhone { get; set; }

        [DisplayName("Organization Website")]
        public string OrganizationWebSite { get; set; }

        [DisplayName("Organization Address")]
        public string OrganizationStreetAddress { get; set; }

        [DisplayName("Sponsor Name")]
        public string SponsorName { get; set; }

        [DisplayName("Sponsor Email")]
        public string SponsorEmail { get; set; }

        [DisplayName("ParentS ignature")]
        public string ParentSignature { get; set; }

        [DisplayName("Status")]
        public ContactStatus Status { get; set; }

        // user ID from AspNetUser table.
        [DisplayName("Owner ID")]
        public string OwnerID { get; set; }

        //public ApplicationUser ApplicationUser { get; set; }
    }

    public enum ContactStatus
    {
        Submitted,
        Approved,
        Rejected
    }
}
