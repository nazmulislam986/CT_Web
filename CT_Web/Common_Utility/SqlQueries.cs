using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CT_Web.Common_Utility
{
    public class SqlQueries
    {
        public static IConfiguration _configuration = new ConfigurationBuilder().AddXmlFile("SqlQueries.xml", true, true).Build();
        public static string AddMarket { get { return _configuration["AddMarketInfo"]; } }
        public static string ReadMarket { get { return _configuration["GetMarketData"]; } }
        public static string ReadMarketID { get { return _configuration["GetMarketIDData"]; } }
        public static string UpdateMarket { get { return _configuration["UpdateMarketData"]; } }
        public static string DeleteMarket { get { return _configuration["DeleteMarketData"]; } }





    }
}
