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
        public static string GetBike { get { return _configuration["GetBikeData"]; } }
        public static string GetBikeID { get { return _configuration["GetBikeIDData"]; } }
        public static string UpdateBike { get { return _configuration["UpdateBikeData"]; } }
        public static string DeleteBike { get { return _configuration["DeleteBikeData"]; } }
        
        public static string AddDailyInfo { get { return _configuration["AddDailyInfo"]; } }
        public static string GetDaily { get { return _configuration["GetDailyData"]; } }
        public static string GetDailyID { get { return _configuration["GetDailyIDData"]; } }
        public static string UpdateDaily { get { return _configuration["UpdateDailyData"]; } }
        public static string DeleteDaily { get { return _configuration["DeleteDailyData"]; } }
        public static string DeleteResonDaily { get { return _configuration["DeleteResonDailyData"]; } }
        
        public static string AddDailyAnt { get { return _configuration["AddDailyAntInfo"]; } }
        public static string GetDailyAnt { get { return _configuration["GetDailyAntData"]; } }
        public static string GetDailyAntID { get { return _configuration["GetDailyAntIDData"]; } }
        public static string UpdateDailyAnt { get { return _configuration["UpdateDailyAntData"]; } }
        public static string DeleteDailyAnt { get { return _configuration["DeleteDailyAntData"]; } }
        public static string DeleteResonDailyAnt { get { return _configuration["DeleteResonDailyData"]; } }
        
        public static string AddDailyCut { get { return _configuration["AddDailyCutInfo"]; } }
        public static string GetDailyCut { get { return _configuration["GetDailyCutData"]; } }
        public static string GetDailyCutID { get { return _configuration["GetDailyCutIDData"]; } }
        public static string UpdateDailyCut { get { return _configuration["UpdateDailyCutData"]; } }
        public static string DeleteDailyCut { get { return _configuration["DeleteDailyCutData"]; } }
        
        public static string AddDailySaving { get { return _configuration["AddDailySavingInfo"]; } }
        public static string GetDailySaving { get { return _configuration["GetDailySavingData"]; } }
        public static string GetDailySavingID { get { return _configuration["GetDailySavingIDData"]; } }
        public static string UpdateDailySaving { get { return _configuration["UpdateDailySavingData"]; } }
        public static string DeleteDailySaving { get { return _configuration["DeleteDailySavingData"]; } }
        public static string DeleteResonDailySaving { get { return _configuration["DeleteResonDailySavingData"]; } }
        
        public static string AddGiven { get { return _configuration["AddGivenInfo"]; } }
        public static string GetGiven { get { return _configuration["GetGivenData"]; } }
        public static string GetGivenID { get { return _configuration["GetGivenIDData"]; } }
        public static string UpdateGiven { get { return _configuration["UpdateGivenData"]; } }
        public static string DeleteGiven { get { return _configuration["DeleteGivenData"]; } }
        public static string DeleteResonGiven { get { return _configuration["DeleteResonGivenData"]; } }
        
        public static string AddImages { get { return _configuration["AddImagesInfo"]; } }
        public static string GetImages { get { return _configuration["GetImagesData"]; } }
        public static string GetImagesID { get { return _configuration["GetImagesIDData"]; } }
        public static string UpdateImages { get { return _configuration["UpdateImagesData"]; } }
        public static string DeleteImages { get { return _configuration["DeleteImagesData"]; } }
        
        public static string AddInstallment { get { return _configuration["AddInstallmentInfo"]; } }
        public static string GetInstallment { get { return _configuration["GetInstallmentData"]; } }
        public static string GetInstallmentID { get { return _configuration["GetInstallmentIDData"]; } }
        public static string UpdateInstallment { get { return _configuration["UpdateInstallmentData"]; } }
        public static string DeleteInstallment { get { return _configuration["DeleteInstallmentData"]; } }

        public static string AddMarketMemo { get { return _configuration["AddMarketMemoInfo"]; } }
        public static string GetMarketMemo { get { return _configuration["GetMarketMemoData"]; } }
        public static string GetMarketMemoID { get { return _configuration["GetMarketMemoIDData"]; } }
        public static string UpdateMarketMemo { get { return _configuration["UpdateMarketMemoData"]; } }
        public static string DeleteMarketMemo { get { return _configuration["DeleteMarketMemoData"]; } }

        public static string AddMarket { get { return _configuration["AddMarketInfo"]; } }
        public static string GetMarket { get { return _configuration["GetMarketData"]; } }
        public static string GetMarketID { get { return _configuration["GetMarketIDData"]; } }
        public static string UpdateMarket { get { return _configuration["UpdateMarketData"]; } }
        public static string DeleteMarket { get { return _configuration["DeleteMarketData"]; } }

        public static string AddMonthlyTake { get { return _configuration["AddMonthlyTakenInfo"]; } }
        public static string GetMonthlyTake { get { return _configuration["GetMonthlyTakenData"]; } }
        public static string GetMonthlyTakeID { get { return _configuration["GetMonthlyTakenIDData"]; } }
        public static string UpdateMonthlyTake { get { return _configuration["UpdateMonthlyTakenData"]; } }
        public static string DeleteMonthlyTake { get { return _configuration["DeleteMonthlyTakenData"]; } }

        public static string AddSaving { get { return _configuration["AddSavingInfo"]; } }
        public static string GetSaving { get { return _configuration["GetSavingData"]; } }
        public static string GetSavingID { get { return _configuration["GetSavingIDData"]; } }
        public static string UpdateSaving { get { return _configuration["UpdateSavingData"]; } }
        public static string DeleteSaving { get { return _configuration["DeleteSavingData"]; } }

        public static string AddTariffAmt { get { return _configuration["AddTariffAmtInfo"]; } }
        public static string GetTariffAmt { get { return _configuration["GetTariffAmtData"]; } }
        public static string GetTariffAmtID { get { return _configuration["GetTariffAmtIDData"]; } }
        public static string UpdateTariffAmt { get { return _configuration["UpdateTariffAmtData"]; } }
        public static string DeleteTariffAmt { get { return _configuration["DeleteTariffAmtData"]; } }

        public static string AddTeken { get { return _configuration["AddTakenInfo"]; } }
        public static string GetTeken { get { return _configuration["GetTakenData"]; } }
        public static string GetTekenID { get { return _configuration["GetTakenIDData"]; } }
        public static string UpdateTeken { get { return _configuration["UpdateTakenData"]; } }
        public static string DeleteTeken { get { return _configuration["DeleteTakenData"]; } }

        public static string AddUnrated { get { return _configuration["AddUndatedInfo"]; } }
        public static string GetUnrated { get { return _configuration["GetUndatedData"]; } }
        public static string GetUnratedID { get { return _configuration["GetUndatedIDData"]; } }
        public static string UpdateUnrated { get { return _configuration["UpdateUndatedData"]; } }
        public static string DeleteUnrated { get { return _configuration["DeleteUndatedData"]; } }
    }
}
