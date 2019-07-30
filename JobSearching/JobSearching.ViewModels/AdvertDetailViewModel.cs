using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearching.ViewModels
{
    public class AdvertDetailViewModel
    {

        public int Id { get; set; }

        public string CompanyBossFirstName { get; set; }
        public string CompanyBossLastName { get; set; }

        public string CompanyName { get; set; }
        public string CompanyLocation { get; set; }

        public string Position { get; set; }
        public string Description { get; set; }

        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
    }
}
