using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrder.Application.ViewModels.AppSetting
{
    public class AppSettings
    {
        public static string ConnectionString { get; set; }
        public static string RunningMode { get; set; }
        public static string Domain { get; set; }
        public static string AllowedOrigins { get; set; }
    }
}
