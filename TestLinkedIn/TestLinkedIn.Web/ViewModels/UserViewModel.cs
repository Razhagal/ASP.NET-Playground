namespace TestLinkedIn.Web.ViewModels
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using TestLinkedIn.Models;

    public class UserViewModel
    {
        public static Expression<Func<User, UserViewModel>> ViewModel
        {
            get
            {
                return x => new UserViewModel()
                {
                    UserName = x.UserName,
                    Email = x.Email,
                    FullName = x.FullName,
                    AvatarUrl = x.AvatarUrl,
                    ContactInfo = x.ContactInfo,
                    Summary = x.Summary,
                    Certifications = x.Certifications
                        .AsQueryable()
                        .Select(CertificationViewModel.ViewModel),
                    Skills = x.Skills.AsQueryable().Select(SkillViewModel.ViewModel)
                };
            }
        }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string AvatarUrl { get; set; }

        public string Summary { get; set; }

        public ContactInfo ContactInfo { get; set; }

        public IEnumerable<CertificationViewModel> Certifications { get; set; }

        public IEnumerable<SkillViewModel> Skills { get; set; }

        //public static object FromModel(User user)
        //{
        //    return new UserViewModel()
        //    {
        //        UserName = user.UserName,
        //        Email = user.Email,
        //        FullName = user.FullName,
        //        AvatarUrl = user.AvatarUrl,
        //        ContactInfo = user.ContactInfo,
        //        Summary = user.Summary
        //    };
        //}
    }
}