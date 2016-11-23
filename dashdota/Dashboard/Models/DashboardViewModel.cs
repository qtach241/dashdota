using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dashboard.Models
{
    public class DashboardViewModel
    {
        public string SteamId { get; set; }
        public bool DeveloperView { get; set; } = false;
    }
}