using System.Configuration;

namespace Hotelz.Data
{
    public class Helper
    {
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["Hotelz.Winforms.Properties.Settings.conStr"].ConnectionString;
    }
}
