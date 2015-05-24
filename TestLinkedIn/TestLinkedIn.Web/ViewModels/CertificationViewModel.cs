namespace TestLinkedIn.Web.ViewModels
{
    using System;
    using System.Linq.Expressions;

    using TestLinkedIn.Models;

    public class CertificationViewModel
    {
        public static Expression<Func<Certification, CertificationViewModel>> ViewModel
        {
            get
            {
                return x => new CertificationViewModel()
                {
                    Name = x.Name,
                    Url = x.Url,
                    TakenDate = x.TakenDate,
                    ExpirationDate = x.ExpirationDate
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string LicenseNumber { get; set; }

        public string Url { get; set; }

        public DateTime TakenDate { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}