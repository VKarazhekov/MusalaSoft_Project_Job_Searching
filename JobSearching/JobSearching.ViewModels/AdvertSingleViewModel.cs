using System;
using System.Collections.Generic;
using System.Text;
using JobSearching.ViewModels;
namespace JobSearching.ViewModels
{
    public class AdvertSingleViewModel
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public string CompanyName { get; set; }
    }
}
