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
        public static string AddBike { get { return _configuration["AddBikeInfo"]; } }
        public static string ReadBike { get { return _configuration["GetBikeData"]; } }
        public static string ReadBikeID { get { return _configuration["GetBikeIDData"]; } }
        public static string UpdateBike { get { return _configuration["UpdateBikeData"]; } }
        public static string DeleteBike { get { return _configuration["DeleteBikeData"]; } }


        public static string AddDailyAnt { get { return _configuration[""]; } }
        public static string ReadDailyAnt { get { return _configuration[""]; } }
        public static string ReadDailyAntID { get { return _configuration[""]; } }
        public static string UpdateDailyAnt { get { return _configuration[""]; } }
        public static string DeleteDailyAnt { get { return _configuration[""]; } }


        public static string AddDailyCut { get { return _configuration[""]; } }
        public static string ReadDailyCut { get { return _configuration[""]; } }
        public static string ReadDailyCutID { get { return _configuration[""]; } }
        public static string UpdateDailyCut { get { return _configuration[""]; } }
        public static string DeleteDailyCut { get { return _configuration[""]; } }


        public static string AddDailySaving { get { return _configuration[""]; } }
        public static string ReadDailySaving { get { return _configuration[""]; } }
        public static string ReadDailySavingID { get { return _configuration[""]; } }
        public static string UpdateDailySaving { get { return _configuration[""]; } }
        public static string DeleteDailySaving { get { return _configuration[""]; } }


        public static string AddDaily { get { return _configuration[""]; } }
        public static string ReadDaily { get { return _configuration[""]; } }
        public static string ReadDailyID { get { return _configuration[""]; } }
        public static string UpdateDaily { get { return _configuration[""]; } }
        public static string DeleteDaily { get { return _configuration[""]; } }


        public static string AddGiven { get { return _configuration[""]; } }
        public static string ReadGiven { get { return _configuration[""]; } }
        public static string ReadGivenID { get { return _configuration[""]; } }
        public static string UpdateGiven { get { return _configuration[""]; } }
        public static string DeleteGiven { get { return _configuration[""]; } }


        public static string AddImages { get { return _configuration[""]; } }
        public static string ReadImages { get { return _configuration[""]; } }
        public static string ReadImagesID { get { return _configuration[""]; } }
        public static string UpdateImages { get { return _configuration[""]; } }
        public static string DeleteImages { get { return _configuration[""]; } }


        public static string AddInstallment { get { return _configuration[""]; } }
        public static string ReadInstallment { get { return _configuration[""]; } }
        public static string ReadInstallmentID { get { return _configuration[""]; } }
        public static string UpdateInstallment { get { return _configuration[""]; } }
        public static string DeleteInstallment { get { return _configuration[""]; } }


        public static string AddMarketMemo { get { return _configuration[""]; } }
        public static string ReadMarketMemo { get { return _configuration[""]; } }
        public static string ReadMarketMemoID { get { return _configuration[""]; } }
        public static string UpdateMarketMemo { get { return _configuration[""]; } }
        public static string DeleteMarketMemo { get { return _configuration[""]; } }


        public static string AddMarket { get { return _configuration["AddMarketInfo"]; } }
        public static string ReadMarket { get { return _configuration["GetMarketData"]; } }
        public static string ReadMarketID { get { return _configuration["GetMarketIDData"]; } }
        public static string UpdateMarket { get { return _configuration["UpdateMarketData"]; } }
        public static string DeleteMarket { get { return _configuration["DeleteMarketData"]; } }


        public static string AddMonthlyTake { get { return _configuration[""]; } }
        public static string ReadMonthlyTake { get { return _configuration[""]; } }
        public static string ReadMonthlyTakeID { get { return _configuration[""]; } }
        public static string UpdateMonthlyTake { get { return _configuration[""]; } }
        public static string DeleteMonthlyTake { get { return _configuration[""]; } }


        public static string AddSaving { get { return _configuration[""]; } }
        public static string ReadSaving { get { return _configuration[""]; } }
        public static string ReadSavingID { get { return _configuration[""]; } }
        public static string UpdateSaving { get { return _configuration[""]; } }
        public static string DeleteSaving { get { return _configuration[""]; } }


        public static string AddTariffAmt { get { return _configuration[""]; } }
        public static string ReadTariffAmt { get { return _configuration[""]; } }
        public static string ReadTariffAmtID { get { return _configuration[""]; } }
        public static string UpdateTariffAmt { get { return _configuration[""]; } }
        public static string DeleteTariffAmt { get { return _configuration[""]; } }

        
        public static string AddTeken { get { return _configuration[""]; } }
        public static string ReadTeken { get { return _configuration[""]; } }
        public static string ReadTekenID { get { return _configuration[""]; } }
        public static string UpdateTeken { get { return _configuration[""]; } }
        public static string DeleteTeken { get { return _configuration[""]; } }


        public static string AddUnrated { get { return _configuration[""]; } }
        public static string ReadUnrated { get { return _configuration[""]; } }
        public static string ReadUnratedID { get { return _configuration[""]; } }
        public static string UpdateUnrated { get { return _configuration[""]; } }
        public static string DeleteUnrated { get { return _configuration[""]; } }
    }
}
