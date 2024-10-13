using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CT_Web.Common_Utility
{
    public class SqlQueries
    {
        public static IConfiguration _configurationBike = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddXmlFile("Common_Xml/BikeInfoQuery.xml", true, true).Build();
        public static IConfiguration _configurationDaily = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddXmlFile("Common_Xml/DailyQuery.xml", true, true).Build();
        public static IConfiguration _configurationDailyAnt = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddXmlFile("Common_Xml/DailyAntQuery.xml", true, true).Build();
        public static IConfiguration _configurationDailyCut = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddXmlFile("Common_Xml/DailyCutQuery.xml", true, true).Build();
        public static IConfiguration _configurationDailySaving = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddXmlFile("Common_Xml/DailySavingQuery.xml", true, true).Build();
        public static IConfiguration _configurationGiven = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddXmlFile("Common_Xml/GivenQuery.xml", true, true).Build();
        public static IConfiguration _configurationImages = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddXmlFile("Common_Xml/ImagesQuery.xml", true, true).Build();
        public static IConfiguration _configurationInstallment = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddXmlFile("Common_Xml/InstallmentQuery.xml", true, true).Build();
        public static IConfiguration _configurationMarketMemo = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddXmlFile("Common_Xml/MarketMemoQuery.xml", true, true).Build();
        public static IConfiguration _configurationMarket = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddXmlFile("Common_Xml/MarketQuery.xml", true, true).Build();
        public static IConfiguration _configurationMonthlyTake = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddXmlFile("Common_Xml/MonthlyTakeQuery.xml", true, true).Build();
        public static IConfiguration _configurationSaving = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddXmlFile("Common_Xml/SavingQuery.xml", true, true).Build();
        public static IConfiguration _configurationTariffAmt = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddXmlFile("Common_Xml/TariffAmtQuery.xml", true, true).Build();
        public static IConfiguration _configurationTeken = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddXmlFile("Common_Xml/TekenQuery.xml", true, true).Build();
        public static IConfiguration _configurationUnrated = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddXmlFile("Common_Xml/UnratedQuery.xml", true, true).Build();
        
        public static string AddBike { get { return _configurationBike["AddBikeInfo"]; } }
        public static string GetBike { get { return _configurationBike["GetBikeData"]; } }
        public static string GetBikeID { get { return _configurationBike["GetBikeIDData"]; } }
        public static string UpdateBike { get { return _configurationBike["UpdateBikeData"]; } }
        public static string DeleteBike { get { return _configurationBike["DeleteBikeData"]; } }
        
        public static string AddDailyInfo { get { return _configurationDaily["AddDailyInfo"]; } }
        public static string GetDaily { get { return _configurationDaily["GetDailyData"]; } }
        public static string GetDailyID { get { return _configurationDaily["GetDailyIDData"]; } }
        public static string UpdateDaily { get { return _configurationDaily["UpdateDailyData"]; } }
        public static string DeleteDaily { get { return _configurationDaily["DeleteDailyData"]; } }
        public static string DeleteResonDaily { get { return _configurationDaily["DeleteResonDailyData"]; } }
        
        public static string AddDailyAnt { get { return _configurationDailyAnt["AddDailyAntInfo"]; } }
        public static string GetDailyAnt { get { return _configurationDailyAnt["GetDailyAntData"]; } }
        public static string GetDailyAntID { get { return _configurationDailyAnt["GetDailyAntIDData"]; } }
        public static string UpdateDailyAnt { get { return _configurationDailyAnt["UpdateDailyAntData"]; } }
        public static string DeleteDailyAnt { get { return _configurationDailyAnt["DeleteDailyAntData"]; } }
        public static string DeleteResonDailyAnt { get { return _configurationDailyAnt["DeleteResonDailyData"]; } }
        
        public static string AddDailyCut { get { return _configurationDailyCut["AddDailyCutInfo"]; } }
        public static string GetDailyCut { get { return _configurationDailyCut["GetDailyCutData"]; } }
        public static string GetDailyCutID { get { return _configurationDailyCut["GetDailyCutIDData"]; } }
        public static string UpdateDailyCut { get { return _configurationDailyCut["UpdateDailyCutData"]; } }
        public static string DeleteDailyCut { get { return _configurationDailyCut["DeleteDailyCutData"]; } }
        
        public static string AddDailySaving { get { return _configurationDailySaving["AddDailySavingInfo"]; } }
        public static string GetDailySaving { get { return _configurationDailySaving["GetDailySavingData"]; } }
        public static string GetDailySavingID { get { return _configurationDailySaving["GetDailySavingIDData"]; } }
        public static string UpdateDailySaving { get { return _configurationDailySaving["UpdateDailySavingData"]; } }
        public static string DeleteDailySaving { get { return _configurationDailySaving["DeleteDailySavingData"]; } }
        public static string DeleteResonDailySaving { get { return _configurationDailySaving["DeleteResonDailySavingData"]; } }
        
        public static string AddGiven { get { return _configurationGiven["AddGivenInfo"]; } }
        public static string GetGiven { get { return _configurationGiven["GetGivenData"]; } }
        public static string GetGivenID { get { return _configurationGiven["GetGivenIDData"]; } }
        public static string UpdateGiven { get { return _configurationGiven["UpdateGivenData"]; } }
        public static string DeleteGiven { get { return _configurationGiven["DeleteGivenData"]; } }
        public static string DeleteResonGiven { get { return _configurationGiven["DeleteResonGivenData"]; } }
        
        public static string AddImages { get { return _configurationImages["AddImagesInfo"]; } }
        public static string GetImages { get { return _configurationImages["GetImagesData"]; } }
        public static string GetImagesID { get { return _configurationImages["GetImagesIDData"]; } }
        public static string UpdateImages { get { return _configurationImages["UpdateImagesData"]; } }
        public static string DeleteImages { get { return _configurationImages["DeleteImagesData"]; } }
        
        public static string AddInstallment { get { return _configurationInstallment["AddInstallmentInfo"]; } }
        public static string GetInstallment { get { return _configurationInstallment["GetInstallmentData"]; } }
        public static string GetInstallmentID { get { return _configurationInstallment["GetInstallmentIDData"]; } }
        public static string UpdateInstallment { get { return _configurationInstallment["UpdateInstallmentData"]; } }
        public static string DeleteInstallment { get { return _configurationInstallment["DeleteInstallmentData"]; } }

        public static string AddMarketMemo { get { return _configurationMarketMemo["AddMarketMemoInfo"]; } }
        public static string GetMarketMemo { get { return _configurationMarketMemo["GetMarketMemoData"]; } }
        public static string GetMarketMemoID { get { return _configurationMarketMemo["GetMarketMemoIDData"]; } }
        public static string UpdateMarketMemo { get { return _configurationMarketMemo["UpdateMarketMemoData"]; } }
        public static string DeleteMarketMemo { get { return _configurationMarketMemo["DeleteMarketMemoData"]; } }

        public static string AddMarket { get { return _configurationMarket["AddMarketInfo"]; } }
        public static string GetMarket { get { return _configurationMarket["GetMarketData"]; } }
        public static string GetMarketID { get { return _configurationMarket["GetMarketIDData"]; } }
        public static string UpdateMarket { get { return _configurationMarket["UpdateMarketData"]; } }
        public static string DeleteMarket { get { return _configurationMarket["DeleteMarketData"]; } }

        public static string AddMonthlyTake { get { return _configurationMonthlyTake["AddMonthlyTakenInfo"]; } }
        public static string GetMonthlyTake { get { return _configurationMonthlyTake["GetMonthlyTakenData"]; } }
        public static string GetMonthlyTakeID { get { return _configurationMonthlyTake["GetMonthlyTakenIDData"]; } }
        public static string UpdateMonthlyTake { get { return _configurationMonthlyTake["UpdateMonthlyTakenData"]; } }
        public static string DeleteMonthlyTake { get { return _configurationMonthlyTake["DeleteMonthlyTakenData"]; } }

        public static string AddSaving { get { return _configurationSaving["AddSavingInfo"]; } }
        public static string GetSaving { get { return _configurationSaving["GetSavingData"]; } }
        public static string GetSavingID { get { return _configurationSaving["GetSavingIDData"]; } }
        public static string UpdateSaving { get { return _configurationSaving["UpdateSavingData"]; } }
        public static string DeleteSaving { get { return _configurationSaving["DeleteSavingData"]; } }

        public static string AddTariffAmt { get { return _configurationTariffAmt["AddTariffAmtInfo"]; } }
        public static string GetTariffAmt { get { return _configurationTariffAmt["GetTariffAmtData"]; } }
        public static string GetTariffAmtID { get { return _configurationTariffAmt["GetTariffAmtIDData"]; } }
        public static string UpdateTariffAmt { get { return _configurationTariffAmt["UpdateTariffAmtData"]; } }
        public static string DeleteTariffAmt { get { return _configurationTariffAmt["DeleteTariffAmtData"]; } }

        public static string AddTeken { get { return _configurationTeken["AddTakenInfo"]; } }
        public static string GetTeken { get { return _configurationTeken["GetTakenData"]; } }
        public static string GetTekenID { get { return _configurationTeken["GetTakenIDData"]; } }
        public static string UpdateTeken { get { return _configurationTeken["UpdateTakenData"]; } }
        public static string DeleteTeken { get { return _configurationTeken["DeleteTakenData"]; } }

        public static string AddUnrated { get { return _configurationUnrated["AddUndatedInfo"]; } }
        public static string GetUnrated { get { return _configurationUnrated["GetUndatedData"]; } }
        public static string GetUnratedID { get { return _configurationUnrated["GetUndatedIDData"]; } }
        public static string UpdateUnrated { get { return _configurationUnrated["UpdateUndatedData"]; } }
        public static string DeleteUnrated { get { return _configurationUnrated["DeleteUndatedData"]; } }
    }
}
