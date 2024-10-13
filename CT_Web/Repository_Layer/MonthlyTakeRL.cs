using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;
using CT_Web.Common_Utility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySqlConnector;

namespace CT_Web.Repository_Layer
{
    public class MonthlyTakeRL : IMonthlyTakeRL
    {
        public readonly IConfiguration _configuration;
        public readonly MySqlConnection _sqlConn;
        public readonly ILogger<MonthlyTakeRL> _logger;
        public MonthlyTakeRL(IConfiguration configuration, ILogger<MonthlyTakeRL> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _sqlConn = new MySqlConnection(_configuration["ConnectionStrings:connMySql"]);
        }

        public async Task<MonthlyTake> ICreateMonthlyTakeRecordRL(MonthlyTake monthlyTake)
        {
            _logger.LogInformation($"Calling Repository Layer");
            MonthlyTake respMonthlyTake = new MonthlyTake();
            respMonthlyTake.IsSuccess = true;
            respMonthlyTake.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.AddMonthlyTake, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@MT_ID", monthlyTake.MT_ID);
                    cmd.Parameters.AddWithValue("@MT_Date", monthlyTake.MT_Date);
                    cmd.Parameters.AddWithValue("@MT_TotalTK", monthlyTake.MT_TotalTK);
                    cmd.Parameters.AddWithValue("@MT_Giv_TK", monthlyTake.MT_Giv_TK);
                    cmd.Parameters.AddWithValue("@MT_LS_TK", monthlyTake.MT_LS_TK);
                    cmd.Parameters.AddWithValue("@T01", monthlyTake.T01);
                    cmd.Parameters.AddWithValue("@T02", monthlyTake.T02);
                    cmd.Parameters.AddWithValue("@T03", monthlyTake.T03);
                    cmd.Parameters.AddWithValue("@T04", monthlyTake.T04);
                    cmd.Parameters.AddWithValue("@T05", monthlyTake.T05);
                    cmd.Parameters.AddWithValue("@T06", monthlyTake.T06);
                    cmd.Parameters.AddWithValue("@T07", monthlyTake.T07);
                    cmd.Parameters.AddWithValue("@T08", monthlyTake.T08);
                    cmd.Parameters.AddWithValue("@T09", monthlyTake.T09);
                    cmd.Parameters.AddWithValue("@T10", monthlyTake.T10);
                    cmd.Parameters.AddWithValue("@T11", monthlyTake.T11);
                    cmd.Parameters.AddWithValue("@T12", monthlyTake.T12);
                    cmd.Parameters.AddWithValue("@T13", monthlyTake.T13);
                    cmd.Parameters.AddWithValue("@T14", monthlyTake.T14);
                    cmd.Parameters.AddWithValue("@T15", monthlyTake.T15);
                    cmd.Parameters.AddWithValue("@T16", monthlyTake.T16);
                    cmd.Parameters.AddWithValue("@T17", monthlyTake.T17);
                    cmd.Parameters.AddWithValue("@T18", monthlyTake.T18);
                    cmd.Parameters.AddWithValue("@T19", monthlyTake.T19);
                    cmd.Parameters.AddWithValue("@T20", monthlyTake.T20);
                    cmd.Parameters.AddWithValue("@T21", monthlyTake.T21);
                    cmd.Parameters.AddWithValue("@T22", monthlyTake.T22);
                    cmd.Parameters.AddWithValue("@T23", monthlyTake.T23);
                    cmd.Parameters.AddWithValue("@T24", monthlyTake.T24);
                    cmd.Parameters.AddWithValue("@T25", monthlyTake.T25);
                    cmd.Parameters.AddWithValue("@T26", monthlyTake.T26);
                    cmd.Parameters.AddWithValue("@T27", monthlyTake.T27);
                    cmd.Parameters.AddWithValue("@T28", monthlyTake.T28);
                    cmd.Parameters.AddWithValue("@T29", monthlyTake.T29);
                    cmd.Parameters.AddWithValue("@T30", monthlyTake.T30);
                    cmd.Parameters.AddWithValue("@T31", monthlyTake.T31);
                    cmd.Parameters.AddWithValue("@T32", monthlyTake.T32);
                    cmd.Parameters.AddWithValue("@T33", monthlyTake.T33);
                    cmd.Parameters.AddWithValue("@T34", monthlyTake.T34);
                    cmd.Parameters.AddWithValue("@T35", monthlyTake.T35);
                    cmd.Parameters.AddWithValue("@T36", monthlyTake.T36);
                    cmd.Parameters.AddWithValue("@T37", monthlyTake.T37);
                    cmd.Parameters.AddWithValue("@T38", monthlyTake.T38);
                    cmd.Parameters.AddWithValue("@T39", monthlyTake.T39);
                    cmd.Parameters.AddWithValue("@T40", monthlyTake.T40);
                    cmd.Parameters.AddWithValue("@T41", monthlyTake.T41);
                    cmd.Parameters.AddWithValue("@T42", monthlyTake.T42);
                    cmd.Parameters.AddWithValue("@T43", monthlyTake.T43);
                    cmd.Parameters.AddWithValue("@T44", monthlyTake.T44);
                    cmd.Parameters.AddWithValue("@T45", monthlyTake.T45);
                    cmd.Parameters.AddWithValue("@T46", monthlyTake.T46);
                    cmd.Parameters.AddWithValue("@T47", monthlyTake.T47);
                    cmd.Parameters.AddWithValue("@T48", monthlyTake.T48);
                    cmd.Parameters.AddWithValue("@T49", monthlyTake.T49);
                    cmd.Parameters.AddWithValue("@T50", monthlyTake.T50);
                    cmd.Parameters.AddWithValue("@T51", monthlyTake.T51);
                    cmd.Parameters.AddWithValue("@T52", monthlyTake.T52);
                    cmd.Parameters.AddWithValue("@T53", monthlyTake.T53);
                    cmd.Parameters.AddWithValue("@T54", monthlyTake.T54);
                    cmd.Parameters.AddWithValue("@T55", monthlyTake.T55);
                    cmd.Parameters.AddWithValue("@T56", monthlyTake.T56);
                    cmd.Parameters.AddWithValue("@T57", monthlyTake.T57);
                    cmd.Parameters.AddWithValue("@T58", monthlyTake.T58);
                    cmd.Parameters.AddWithValue("@T59", monthlyTake.T59);
                    cmd.Parameters.AddWithValue("@T60", monthlyTake.T60);
                    cmd.Parameters.AddWithValue("@T61", monthlyTake.T61);
                    cmd.Parameters.AddWithValue("@T62", monthlyTake.T62);
                    cmd.Parameters.AddWithValue("@T63", monthlyTake.T63);
                    cmd.Parameters.AddWithValue("@T64", monthlyTake.T64);
                    cmd.Parameters.AddWithValue("@T65", monthlyTake.T65);
                    cmd.Parameters.AddWithValue("@T66", monthlyTake.T66);
                    cmd.Parameters.AddWithValue("@T67", monthlyTake.T67);
                    cmd.Parameters.AddWithValue("@T68", monthlyTake.T68);
                    cmd.Parameters.AddWithValue("@T69", monthlyTake.T69);
                    cmd.Parameters.AddWithValue("@T70", monthlyTake.T70);
                    cmd.Parameters.AddWithValue("@T71", monthlyTake.T71);
                    cmd.Parameters.AddWithValue("@T72", monthlyTake.T72);
                    cmd.Parameters.AddWithValue("@T73", monthlyTake.T73);
                    cmd.Parameters.AddWithValue("@T74", monthlyTake.T74);
                    cmd.Parameters.AddWithValue("@T75", monthlyTake.T75);
                    cmd.Parameters.AddWithValue("@T76", monthlyTake.T76);
                    cmd.Parameters.AddWithValue("@T77", monthlyTake.T77);
                    cmd.Parameters.AddWithValue("@T78", monthlyTake.T78);
                    cmd.Parameters.AddWithValue("@T79", monthlyTake.T79);
                    cmd.Parameters.AddWithValue("@T80", monthlyTake.T80);
                    cmd.Parameters.AddWithValue("@T81", monthlyTake.T81);
                    cmd.Parameters.AddWithValue("@T82", monthlyTake.T82);
                    cmd.Parameters.AddWithValue("@T83", monthlyTake.T83);
                    cmd.Parameters.AddWithValue("@T84", monthlyTake.T84);
                    cmd.Parameters.AddWithValue("@T85", monthlyTake.T85);
                    cmd.Parameters.AddWithValue("@T86", monthlyTake.T86);
                    cmd.Parameters.AddWithValue("@T87", monthlyTake.T87);
                    cmd.Parameters.AddWithValue("@T88", monthlyTake.T88);
                    cmd.Parameters.AddWithValue("@T89", monthlyTake.T89);
                    cmd.Parameters.AddWithValue("@T90", monthlyTake.T90);
                    cmd.Parameters.AddWithValue("@T91", monthlyTake.T91);
                    cmd.Parameters.AddWithValue("@T92", monthlyTake.T92);
                    cmd.Parameters.AddWithValue("@T93", monthlyTake.T93);
                    cmd.Parameters.AddWithValue("@T94", monthlyTake.T94);
                    cmd.Parameters.AddWithValue("@T95", monthlyTake.T95);
                    cmd.Parameters.AddWithValue("@T96", monthlyTake.T96);
                    cmd.Parameters.AddWithValue("@T97", monthlyTake.T97);
                    cmd.Parameters.AddWithValue("@T98", monthlyTake.T98);
                    cmd.Parameters.AddWithValue("@T99", monthlyTake.T99);
                    cmd.Parameters.AddWithValue("@T100", monthlyTake.T100);
                    cmd.Parameters.AddWithValue("@T101", monthlyTake.T101);
                    cmd.Parameters.AddWithValue("@T102", monthlyTake.T102);
                    cmd.Parameters.AddWithValue("@T103", monthlyTake.T103);
                    cmd.Parameters.AddWithValue("@T104", monthlyTake.T104);
                    cmd.Parameters.AddWithValue("@T105", monthlyTake.T105);
                    cmd.Parameters.AddWithValue("@T106", monthlyTake.T106);
                    cmd.Parameters.AddWithValue("@T107", monthlyTake.T107);
                    cmd.Parameters.AddWithValue("@T108", monthlyTake.T108);
                    cmd.Parameters.AddWithValue("@T109", monthlyTake.T109);
                    cmd.Parameters.AddWithValue("@T110", monthlyTake.T110);
                    cmd.Parameters.AddWithValue("@T111", monthlyTake.T111);
                    cmd.Parameters.AddWithValue("@T112", monthlyTake.T112);
                    cmd.Parameters.AddWithValue("@T113", monthlyTake.T113);
                    cmd.Parameters.AddWithValue("@T114", monthlyTake.T114);
                    cmd.Parameters.AddWithValue("@T115", monthlyTake.T115);
                    cmd.Parameters.AddWithValue("@T116", monthlyTake.T116);
                    cmd.Parameters.AddWithValue("@T117", monthlyTake.T117);
                    cmd.Parameters.AddWithValue("@T118", monthlyTake.T118);
                    cmd.Parameters.AddWithValue("@T119", monthlyTake.T119);
                    cmd.Parameters.AddWithValue("@T120", monthlyTake.T120);
                    cmd.Parameters.AddWithValue("@MTDT_V", monthlyTake.MTDT_V);
                    cmd.Parameters.AddWithValue("@MT_Insrt_Person", monthlyTake.MT_Insrt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respMonthlyTake.IsSuccess = false;
                        respMonthlyTake.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respMonthlyTake;
                    }
                }
            }
            catch (Exception ex)
            {
                respMonthlyTake.IsSuccess = false;
                respMonthlyTake.Message = ex.Message;
                _logger.LogError($"Insert Market Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respMonthlyTake;
        }
        public async Task<MonthlyTake> IReadMonthlyTakeRecordRL()
        {
            _logger.LogInformation($"Calling Repository Layer");
            MonthlyTake respMonthlyTake = new MonthlyTake();
            respMonthlyTake.IsSuccess = true;
            respMonthlyTake.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetMonthlyTake, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respMonthlyTake.MonthlyTakeDataList = new List<MonthlyTake>();
                            while (await dataReader.ReadAsync())
                            {
                                MonthlyTake getData = new MonthlyTake()
                                {
                                    MT_ID = dataReader["MT_ID"] as string,
                                    MT_Date = (DateTime)(dataReader["MT_Date"] as DateTime?),
                                    MT_TotalTK = dataReader["MT_TotalTK"] as float? ?? 0,
                                    MT_Giv_TK = dataReader["MT_Giv_TK"] as float? ?? 0,
                                    MT_LS_TK = dataReader["MT_LS_TK"] as float? ?? 0,
                                    T01 = dataReader["T01"] as float? ?? 0,
                                    T02 = dataReader["T02"] as float? ?? 0,
                                    T03 = dataReader["T03"] as float? ?? 0,
                                    T04 = dataReader["T04"] as float? ?? 0,
                                    T05 = dataReader["T05"] as float? ?? 0,
                                    T06 = dataReader["T06"] as float? ?? 0,
                                    T07 = dataReader["T07"] as float? ?? 0,
                                    T08 = dataReader["T08"] as float? ?? 0,
                                    T09 = dataReader["T09"] as float? ?? 0,
                                    T10 = dataReader["T10"] as float? ?? 0,
                                    T11 = dataReader["T11"] as float? ?? 0,
                                    T12 = dataReader["T12"] as float? ?? 0,
                                    T13 = dataReader["T13"] as float? ?? 0,
                                    T14 = dataReader["T14"] as float? ?? 0,
                                    T15 = dataReader["T15"] as float? ?? 0,
                                    T16 = dataReader["T16"] as float? ?? 0,
                                    T17 = dataReader["T17"] as float? ?? 0,
                                    T18 = dataReader["T18"] as float? ?? 0,
                                    T19 = dataReader["T19"] as float? ?? 0,
                                    T20 = dataReader["T20"] as float? ?? 0,
                                    T21 = dataReader["T21"] as float? ?? 0,
                                    T22 = dataReader["T22"] as float? ?? 0,
                                    T23 = dataReader["T23"] as float? ?? 0,
                                    T24 = dataReader["T24"] as float? ?? 0,
                                    T25 = dataReader["T25"] as float? ?? 0,
                                    T26 = dataReader["T26"] as float? ?? 0,
                                    T27 = dataReader["T27"] as float? ?? 0,
                                    T28 = dataReader["T28"] as float? ?? 0,
                                    T29 = dataReader["T29"] as float? ?? 0,
                                    T30 = dataReader["T30"] as float? ?? 0,
                                    T31 = dataReader["T31"] as float? ?? 0,
                                    T32 = dataReader["T32"] as float? ?? 0,
                                    T33 = dataReader["T33"] as float? ?? 0,
                                    T34 = dataReader["T34"] as float? ?? 0,
                                    T35 = dataReader["T35"] as float? ?? 0,
                                    T36 = dataReader["T36"] as float? ?? 0,
                                    T37 = dataReader["T37"] as float? ?? 0,
                                    T38 = dataReader["T38"] as float? ?? 0,
                                    T39 = dataReader["T39"] as float? ?? 0,
                                    T40 = dataReader["T40"] as float? ?? 0,
                                    T41 = dataReader["T41"] as float? ?? 0,
                                    T42 = dataReader["T42"] as float? ?? 0,
                                    T43 = dataReader["T43"] as float? ?? 0,
                                    T44 = dataReader["T44"] as float? ?? 0,
                                    T45 = dataReader["T45"] as float? ?? 0,
                                    T46 = dataReader["T46"] as float? ?? 0,
                                    T47 = dataReader["T47"] as float? ?? 0,
                                    T48 = dataReader["T48"] as float? ?? 0,
                                    T49 = dataReader["T49"] as float? ?? 0,
                                    T50 = dataReader["T50"] as float? ?? 0,
                                    T51 = dataReader["T51"] as float? ?? 0,
                                    T52 = dataReader["T52"] as float? ?? 0,
                                    T53 = dataReader["T53"] as float? ?? 0,
                                    T54 = dataReader["T54"] as float? ?? 0,
                                    T55 = dataReader["T55"] as float? ?? 0,
                                    T56 = dataReader["T56"] as float? ?? 0,
                                    T57 = dataReader["T57"] as float? ?? 0,
                                    T58 = dataReader["T58"] as float? ?? 0,
                                    T59 = dataReader["T59"] as float? ?? 0,
                                    T60 = dataReader["T60"] as float? ?? 0,
                                    T61 = dataReader["T61"] as float? ?? 0,
                                    T62 = dataReader["T62"] as float? ?? 0,
                                    T63 = dataReader["T63"] as float? ?? 0,
                                    T64 = dataReader["T64"] as float? ?? 0,
                                    T65 = dataReader["T65"] as float? ?? 0,
                                    T66 = dataReader["T66"] as float? ?? 0,
                                    T67 = dataReader["T67"] as float? ?? 0,
                                    T68 = dataReader["T68"] as float? ?? 0,
                                    T69 = dataReader["T69"] as float? ?? 0,
                                    T70 = dataReader["T70"] as float? ?? 0,
                                    T71 = dataReader["T71"] as float? ?? 0,
                                    T72 = dataReader["T72"] as float? ?? 0,
                                    T73 = dataReader["T73"] as float? ?? 0,
                                    T74 = dataReader["T74"] as float? ?? 0,
                                    T75 = dataReader["T75"] as float? ?? 0,
                                    T76 = dataReader["T76"] as float? ?? 0,
                                    T77 = dataReader["T77"] as float? ?? 0,
                                    T78 = dataReader["T78"] as float? ?? 0,
                                    T79 = dataReader["T79"] as float? ?? 0,
                                    T80 = dataReader["T80"] as float? ?? 0,
                                    T81 = dataReader["T81"] as float? ?? 0,
                                    T82 = dataReader["T82"] as float? ?? 0,
                                    T83 = dataReader["T83"] as float? ?? 0,
                                    T84 = dataReader["T84"] as float? ?? 0,
                                    T85 = dataReader["T85"] as float? ?? 0,
                                    T86 = dataReader["T86"] as float? ?? 0,
                                    T87 = dataReader["T87"] as float? ?? 0,
                                    T88 = dataReader["T88"] as float? ?? 0,
                                    T89 = dataReader["T89"] as float? ?? 0,
                                    T90 = dataReader["T90"] as float? ?? 0,
                                    T91 = dataReader["T91"] as float? ?? 0,
                                    T92 = dataReader["T92"] as float? ?? 0,
                                    T93 = dataReader["T93"] as float? ?? 0,
                                    T94 = dataReader["T94"] as float? ?? 0,
                                    T95 = dataReader["T95"] as float? ?? 0,
                                    T96 = dataReader["T96"] as float? ?? 0,
                                    T97 = dataReader["T97"] as float? ?? 0,
                                    T98 = dataReader["T98"] as float? ?? 0,
                                    T99 = dataReader["T99"] as float? ?? 0,
                                    T100 = dataReader["T100"] as float? ?? 0,
                                    T101 = dataReader["T101"] as float? ?? 0,
                                    T102 = dataReader["T102"] as float? ?? 0,
                                    T103 = dataReader["T103"] as float? ?? 0,
                                    T104 = dataReader["T104"] as float? ?? 0,
                                    T105 = dataReader["T105"] as float? ?? 0,
                                    T106 = dataReader["T106"] as float? ?? 0,
                                    T107 = dataReader["T107"] as float? ?? 0,
                                    T108 = dataReader["T108"] as float? ?? 0,
                                    T109 = dataReader["T109"] as float? ?? 0,
                                    T110 = dataReader["T110"] as float? ?? 0,
                                    T111 = dataReader["T111"] as float? ?? 0,
                                    T112 = dataReader["T112"] as float? ?? 0,
                                    T113 = dataReader["T113"] as float? ?? 0,
                                    T114 = dataReader["T114"] as float? ?? 0,
                                    T115 = dataReader["T115"] as float? ?? 0,
                                    T116 = dataReader["T116"] as float? ?? 0,
                                    T117 = dataReader["T117"] as float? ?? 0,
                                    T118 = dataReader["T118"] as float? ?? 0,
                                    T119 = dataReader["T119"] as float? ?? 0,
                                    T120 = dataReader["T120"] as float? ?? 0,
                                    MTDT_V = dataReader["MTDT_V"] as string,
                                    MT_Insrt_Person = dataReader["MT_Insrt_Person"] as string,
                                    MT_Updt_Person = dataReader["MT_Updt_Person"] as string,
                                    MT_Del_Person = dataReader["MT_Del_Person"] as string
                                };
                                respMonthlyTake.MonthlyTakeDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respMonthlyTake.IsSuccess = true;
                            respMonthlyTake.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respMonthlyTake.IsSuccess = false;
                respMonthlyTake.Message = ex.Message;
                _logger.LogError($"Read Market Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respMonthlyTake;
        }
        public async Task<MonthlyTake> IReadMonthlyTakeIDRecordRL(MonthlyTake monthlyTake)
        {
            _logger.LogInformation($"Calling Repository Layer");
            MonthlyTake respMonthlyTake = new MonthlyTake();
            respMonthlyTake.IsSuccess = true;
            respMonthlyTake.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetMonthlyTakeID, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@MT_ID", monthlyTake.MT_ID);
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respMonthlyTake.MonthlyTakeDataList = new List<MonthlyTake>();
                            if (await dataReader.ReadAsync())
                            {
                                MonthlyTake getData = new MonthlyTake()
                                {
                                    MT_ID = dataReader["MT_ID"] as string,
                                    MT_Date = (DateTime)(dataReader["MT_Date"] as DateTime?),
                                    MT_TotalTK = dataReader["MT_TotalTK"] as float? ?? 0,
                                    MT_Giv_TK = dataReader["MT_Giv_TK"] as float? ?? 0,
                                    MT_LS_TK = dataReader["MT_LS_TK"] as float? ?? 0,
                                    T01 = dataReader["T01"] as float? ?? 0,
                                    T02 = dataReader["T02"] as float? ?? 0,
                                    T03 = dataReader["T03"] as float? ?? 0,
                                    T04 = dataReader["T04"] as float? ?? 0,
                                    T05 = dataReader["T05"] as float? ?? 0,
                                    T06 = dataReader["T06"] as float? ?? 0,
                                    T07 = dataReader["T07"] as float? ?? 0,
                                    T08 = dataReader["T08"] as float? ?? 0,
                                    T09 = dataReader["T09"] as float? ?? 0,
                                    T10 = dataReader["T10"] as float? ?? 0,
                                    T11 = dataReader["T11"] as float? ?? 0,
                                    T12 = dataReader["T12"] as float? ?? 0,
                                    T13 = dataReader["T13"] as float? ?? 0,
                                    T14 = dataReader["T14"] as float? ?? 0,
                                    T15 = dataReader["T15"] as float? ?? 0,
                                    T16 = dataReader["T16"] as float? ?? 0,
                                    T17 = dataReader["T17"] as float? ?? 0,
                                    T18 = dataReader["T18"] as float? ?? 0,
                                    T19 = dataReader["T19"] as float? ?? 0,
                                    T20 = dataReader["T20"] as float? ?? 0,
                                    T21 = dataReader["T21"] as float? ?? 0,
                                    T22 = dataReader["T22"] as float? ?? 0,
                                    T23 = dataReader["T23"] as float? ?? 0,
                                    T24 = dataReader["T24"] as float? ?? 0,
                                    T25 = dataReader["T25"] as float? ?? 0,
                                    T26 = dataReader["T26"] as float? ?? 0,
                                    T27 = dataReader["T27"] as float? ?? 0,
                                    T28 = dataReader["T28"] as float? ?? 0,
                                    T29 = dataReader["T29"] as float? ?? 0,
                                    T30 = dataReader["T30"] as float? ?? 0,
                                    T31 = dataReader["T31"] as float? ?? 0,
                                    T32 = dataReader["T32"] as float? ?? 0,
                                    T33 = dataReader["T33"] as float? ?? 0,
                                    T34 = dataReader["T34"] as float? ?? 0,
                                    T35 = dataReader["T35"] as float? ?? 0,
                                    T36 = dataReader["T36"] as float? ?? 0,
                                    T37 = dataReader["T37"] as float? ?? 0,
                                    T38 = dataReader["T38"] as float? ?? 0,
                                    T39 = dataReader["T39"] as float? ?? 0,
                                    T40 = dataReader["T40"] as float? ?? 0,
                                    T41 = dataReader["T41"] as float? ?? 0,
                                    T42 = dataReader["T42"] as float? ?? 0,
                                    T43 = dataReader["T43"] as float? ?? 0,
                                    T44 = dataReader["T44"] as float? ?? 0,
                                    T45 = dataReader["T45"] as float? ?? 0,
                                    T46 = dataReader["T46"] as float? ?? 0,
                                    T47 = dataReader["T47"] as float? ?? 0,
                                    T48 = dataReader["T48"] as float? ?? 0,
                                    T49 = dataReader["T49"] as float? ?? 0,
                                    T50 = dataReader["T50"] as float? ?? 0,
                                    T51 = dataReader["T51"] as float? ?? 0,
                                    T52 = dataReader["T52"] as float? ?? 0,
                                    T53 = dataReader["T53"] as float? ?? 0,
                                    T54 = dataReader["T54"] as float? ?? 0,
                                    T55 = dataReader["T55"] as float? ?? 0,
                                    T56 = dataReader["T56"] as float? ?? 0,
                                    T57 = dataReader["T57"] as float? ?? 0,
                                    T58 = dataReader["T58"] as float? ?? 0,
                                    T59 = dataReader["T59"] as float? ?? 0,
                                    T60 = dataReader["T60"] as float? ?? 0,
                                    T61 = dataReader["T61"] as float? ?? 0,
                                    T62 = dataReader["T62"] as float? ?? 0,
                                    T63 = dataReader["T63"] as float? ?? 0,
                                    T64 = dataReader["T64"] as float? ?? 0,
                                    T65 = dataReader["T65"] as float? ?? 0,
                                    T66 = dataReader["T66"] as float? ?? 0,
                                    T67 = dataReader["T67"] as float? ?? 0,
                                    T68 = dataReader["T68"] as float? ?? 0,
                                    T69 = dataReader["T69"] as float? ?? 0,
                                    T70 = dataReader["T70"] as float? ?? 0,
                                    T71 = dataReader["T71"] as float? ?? 0,
                                    T72 = dataReader["T72"] as float? ?? 0,
                                    T73 = dataReader["T73"] as float? ?? 0,
                                    T74 = dataReader["T74"] as float? ?? 0,
                                    T75 = dataReader["T75"] as float? ?? 0,
                                    T76 = dataReader["T76"] as float? ?? 0,
                                    T77 = dataReader["T77"] as float? ?? 0,
                                    T78 = dataReader["T78"] as float? ?? 0,
                                    T79 = dataReader["T79"] as float? ?? 0,
                                    T80 = dataReader["T80"] as float? ?? 0,
                                    T81 = dataReader["T81"] as float? ?? 0,
                                    T82 = dataReader["T82"] as float? ?? 0,
                                    T83 = dataReader["T83"] as float? ?? 0,
                                    T84 = dataReader["T84"] as float? ?? 0,
                                    T85 = dataReader["T85"] as float? ?? 0,
                                    T86 = dataReader["T86"] as float? ?? 0,
                                    T87 = dataReader["T87"] as float? ?? 0,
                                    T88 = dataReader["T88"] as float? ?? 0,
                                    T89 = dataReader["T89"] as float? ?? 0,
                                    T90 = dataReader["T90"] as float? ?? 0,
                                    T91 = dataReader["T91"] as float? ?? 0,
                                    T92 = dataReader["T92"] as float? ?? 0,
                                    T93 = dataReader["T93"] as float? ?? 0,
                                    T94 = dataReader["T94"] as float? ?? 0,
                                    T95 = dataReader["T95"] as float? ?? 0,
                                    T96 = dataReader["T96"] as float? ?? 0,
                                    T97 = dataReader["T97"] as float? ?? 0,
                                    T98 = dataReader["T98"] as float? ?? 0,
                                    T99 = dataReader["T99"] as float? ?? 0,
                                    T100 = dataReader["T100"] as float? ?? 0,
                                    T101 = dataReader["T101"] as float? ?? 0,
                                    T102 = dataReader["T102"] as float? ?? 0,
                                    T103 = dataReader["T103"] as float? ?? 0,
                                    T104 = dataReader["T104"] as float? ?? 0,
                                    T105 = dataReader["T105"] as float? ?? 0,
                                    T106 = dataReader["T106"] as float? ?? 0,
                                    T107 = dataReader["T107"] as float? ?? 0,
                                    T108 = dataReader["T108"] as float? ?? 0,
                                    T109 = dataReader["T109"] as float? ?? 0,
                                    T110 = dataReader["T110"] as float? ?? 0,
                                    T111 = dataReader["T111"] as float? ?? 0,
                                    T112 = dataReader["T112"] as float? ?? 0,
                                    T113 = dataReader["T113"] as float? ?? 0,
                                    T114 = dataReader["T114"] as float? ?? 0,
                                    T115 = dataReader["T115"] as float? ?? 0,
                                    T116 = dataReader["T116"] as float? ?? 0,
                                    T117 = dataReader["T117"] as float? ?? 0,
                                    T118 = dataReader["T118"] as float? ?? 0,
                                    T119 = dataReader["T119"] as float? ?? 0,
                                    T120 = dataReader["T120"] as float? ?? 0,
                                    MTDT_V = dataReader["MTDT_V"] as string,
                                    MT_Insrt_Person = dataReader["MT_Insrt_Person"] as string,
                                    MT_Updt_Person = dataReader["MT_Updt_Person"] as string,
                                    MT_Del_Person = dataReader["MT_Del_Person"] as string
                                };
                                respMonthlyTake.MonthlyTakeDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respMonthlyTake.IsSuccess = true;
                            respMonthlyTake.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respMonthlyTake.IsSuccess = false;
                respMonthlyTake.Message = ex.Message;
                _logger.LogError($"Update Market ID Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respMonthlyTake;
        }
        public async Task<MonthlyTake> IUpdateMonthlyTakeRecordRL(MonthlyTake monthlyTake)
        {
            _logger.LogInformation($"Calling Repository Layer");
            MonthlyTake respMonthlyTake = new MonthlyTake();
            respMonthlyTake.IsSuccess = true;
            respMonthlyTake.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.UpdateMonthlyTake, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@MT_ID", monthlyTake.MT_ID);
                    cmd.Parameters.AddWithValue("@MT_TotalTK", monthlyTake.MT_TotalTK);
                    cmd.Parameters.AddWithValue("@MT_Giv_TK", monthlyTake.MT_Giv_TK);
                    cmd.Parameters.AddWithValue("@MT_LS_TK", monthlyTake.MT_LS_TK);
                    cmd.Parameters.AddWithValue("@T01", monthlyTake.T01);
                    cmd.Parameters.AddWithValue("@T02", monthlyTake.T02);
                    cmd.Parameters.AddWithValue("@T03", monthlyTake.T03);
                    cmd.Parameters.AddWithValue("@T04", monthlyTake.T04);
                    cmd.Parameters.AddWithValue("@T05", monthlyTake.T05);
                    cmd.Parameters.AddWithValue("@T06", monthlyTake.T06);
                    cmd.Parameters.AddWithValue("@T07", monthlyTake.T07);
                    cmd.Parameters.AddWithValue("@T08", monthlyTake.T08);
                    cmd.Parameters.AddWithValue("@T09", monthlyTake.T09);
                    cmd.Parameters.AddWithValue("@T10", monthlyTake.T10);
                    cmd.Parameters.AddWithValue("@T11", monthlyTake.T11);
                    cmd.Parameters.AddWithValue("@T12", monthlyTake.T12);
                    cmd.Parameters.AddWithValue("@T13", monthlyTake.T13);
                    cmd.Parameters.AddWithValue("@T14", monthlyTake.T14);
                    cmd.Parameters.AddWithValue("@T15", monthlyTake.T15);
                    cmd.Parameters.AddWithValue("@T16", monthlyTake.T16);
                    cmd.Parameters.AddWithValue("@T17", monthlyTake.T17);
                    cmd.Parameters.AddWithValue("@T18", monthlyTake.T18);
                    cmd.Parameters.AddWithValue("@T19", monthlyTake.T19);
                    cmd.Parameters.AddWithValue("@T20", monthlyTake.T20);
                    cmd.Parameters.AddWithValue("@T21", monthlyTake.T21);
                    cmd.Parameters.AddWithValue("@T22", monthlyTake.T22);
                    cmd.Parameters.AddWithValue("@T23", monthlyTake.T23);
                    cmd.Parameters.AddWithValue("@T24", monthlyTake.T24);
                    cmd.Parameters.AddWithValue("@T25", monthlyTake.T25);
                    cmd.Parameters.AddWithValue("@T26", monthlyTake.T26);
                    cmd.Parameters.AddWithValue("@T27", monthlyTake.T27);
                    cmd.Parameters.AddWithValue("@T28", monthlyTake.T28);
                    cmd.Parameters.AddWithValue("@T29", monthlyTake.T29);
                    cmd.Parameters.AddWithValue("@T30", monthlyTake.T30);
                    cmd.Parameters.AddWithValue("@T31", monthlyTake.T31);
                    cmd.Parameters.AddWithValue("@T32", monthlyTake.T32);
                    cmd.Parameters.AddWithValue("@T33", monthlyTake.T33);
                    cmd.Parameters.AddWithValue("@T34", monthlyTake.T34);
                    cmd.Parameters.AddWithValue("@T35", monthlyTake.T35);
                    cmd.Parameters.AddWithValue("@T36", monthlyTake.T36);
                    cmd.Parameters.AddWithValue("@T37", monthlyTake.T37);
                    cmd.Parameters.AddWithValue("@T38", monthlyTake.T38);
                    cmd.Parameters.AddWithValue("@T39", monthlyTake.T39);
                    cmd.Parameters.AddWithValue("@T40", monthlyTake.T40);
                    cmd.Parameters.AddWithValue("@T41", monthlyTake.T41);
                    cmd.Parameters.AddWithValue("@T42", monthlyTake.T42);
                    cmd.Parameters.AddWithValue("@T43", monthlyTake.T43);
                    cmd.Parameters.AddWithValue("@T44", monthlyTake.T44);
                    cmd.Parameters.AddWithValue("@T45", monthlyTake.T45);
                    cmd.Parameters.AddWithValue("@T46", monthlyTake.T46);
                    cmd.Parameters.AddWithValue("@T47", monthlyTake.T47);
                    cmd.Parameters.AddWithValue("@T48", monthlyTake.T48);
                    cmd.Parameters.AddWithValue("@T49", monthlyTake.T49);
                    cmd.Parameters.AddWithValue("@T50", monthlyTake.T50);
                    cmd.Parameters.AddWithValue("@T51", monthlyTake.T51);
                    cmd.Parameters.AddWithValue("@T52", monthlyTake.T52);
                    cmd.Parameters.AddWithValue("@T53", monthlyTake.T53);
                    cmd.Parameters.AddWithValue("@T54", monthlyTake.T54);
                    cmd.Parameters.AddWithValue("@T55", monthlyTake.T55);
                    cmd.Parameters.AddWithValue("@T56", monthlyTake.T56);
                    cmd.Parameters.AddWithValue("@T57", monthlyTake.T57);
                    cmd.Parameters.AddWithValue("@T58", monthlyTake.T58);
                    cmd.Parameters.AddWithValue("@T59", monthlyTake.T59);
                    cmd.Parameters.AddWithValue("@T60", monthlyTake.T60);
                    cmd.Parameters.AddWithValue("@T61", monthlyTake.T61);
                    cmd.Parameters.AddWithValue("@T62", monthlyTake.T62);
                    cmd.Parameters.AddWithValue("@T63", monthlyTake.T63);
                    cmd.Parameters.AddWithValue("@T64", monthlyTake.T64);
                    cmd.Parameters.AddWithValue("@T65", monthlyTake.T65);
                    cmd.Parameters.AddWithValue("@T66", monthlyTake.T66);
                    cmd.Parameters.AddWithValue("@T67", monthlyTake.T67);
                    cmd.Parameters.AddWithValue("@T68", monthlyTake.T68);
                    cmd.Parameters.AddWithValue("@T69", monthlyTake.T69);
                    cmd.Parameters.AddWithValue("@T70", monthlyTake.T70);
                    cmd.Parameters.AddWithValue("@T71", monthlyTake.T71);
                    cmd.Parameters.AddWithValue("@T72", monthlyTake.T72);
                    cmd.Parameters.AddWithValue("@T73", monthlyTake.T73);
                    cmd.Parameters.AddWithValue("@T74", monthlyTake.T74);
                    cmd.Parameters.AddWithValue("@T75", monthlyTake.T75);
                    cmd.Parameters.AddWithValue("@T76", monthlyTake.T76);
                    cmd.Parameters.AddWithValue("@T77", monthlyTake.T77);
                    cmd.Parameters.AddWithValue("@T78", monthlyTake.T78);
                    cmd.Parameters.AddWithValue("@T79", monthlyTake.T79);
                    cmd.Parameters.AddWithValue("@T80", monthlyTake.T80);
                    cmd.Parameters.AddWithValue("@T81", monthlyTake.T81);
                    cmd.Parameters.AddWithValue("@T82", monthlyTake.T82);
                    cmd.Parameters.AddWithValue("@T83", monthlyTake.T83);
                    cmd.Parameters.AddWithValue("@T84", monthlyTake.T84);
                    cmd.Parameters.AddWithValue("@T85", monthlyTake.T85);
                    cmd.Parameters.AddWithValue("@T86", monthlyTake.T86);
                    cmd.Parameters.AddWithValue("@T87", monthlyTake.T87);
                    cmd.Parameters.AddWithValue("@T88", monthlyTake.T88);
                    cmd.Parameters.AddWithValue("@T89", monthlyTake.T89);
                    cmd.Parameters.AddWithValue("@T90", monthlyTake.T90);
                    cmd.Parameters.AddWithValue("@T91", monthlyTake.T91);
                    cmd.Parameters.AddWithValue("@T92", monthlyTake.T92);
                    cmd.Parameters.AddWithValue("@T93", monthlyTake.T93);
                    cmd.Parameters.AddWithValue("@T94", monthlyTake.T94);
                    cmd.Parameters.AddWithValue("@T95", monthlyTake.T95);
                    cmd.Parameters.AddWithValue("@T96", monthlyTake.T96);
                    cmd.Parameters.AddWithValue("@T97", monthlyTake.T97);
                    cmd.Parameters.AddWithValue("@T98", monthlyTake.T98);
                    cmd.Parameters.AddWithValue("@T99", monthlyTake.T99);
                    cmd.Parameters.AddWithValue("@T100", monthlyTake.T100);
                    cmd.Parameters.AddWithValue("@T101", monthlyTake.T101);
                    cmd.Parameters.AddWithValue("@T102", monthlyTake.T102);
                    cmd.Parameters.AddWithValue("@T103", monthlyTake.T103);
                    cmd.Parameters.AddWithValue("@T104", monthlyTake.T104);
                    cmd.Parameters.AddWithValue("@T105", monthlyTake.T105);
                    cmd.Parameters.AddWithValue("@T106", monthlyTake.T106);
                    cmd.Parameters.AddWithValue("@T107", monthlyTake.T107);
                    cmd.Parameters.AddWithValue("@T108", monthlyTake.T108);
                    cmd.Parameters.AddWithValue("@T109", monthlyTake.T109);
                    cmd.Parameters.AddWithValue("@T110", monthlyTake.T110);
                    cmd.Parameters.AddWithValue("@T111", monthlyTake.T111);
                    cmd.Parameters.AddWithValue("@T112", monthlyTake.T112);
                    cmd.Parameters.AddWithValue("@T113", monthlyTake.T113);
                    cmd.Parameters.AddWithValue("@T114", monthlyTake.T114);
                    cmd.Parameters.AddWithValue("@T115", monthlyTake.T115);
                    cmd.Parameters.AddWithValue("@T116", monthlyTake.T116);
                    cmd.Parameters.AddWithValue("@T117", monthlyTake.T117);
                    cmd.Parameters.AddWithValue("@T118", monthlyTake.T118);
                    cmd.Parameters.AddWithValue("@T119", monthlyTake.T119);
                    cmd.Parameters.AddWithValue("@T120", monthlyTake.T120);
                    cmd.Parameters.AddWithValue("@MTDT_V", monthlyTake.MTDT_V);
                    cmd.Parameters.AddWithValue("@MT_Updt_Person", monthlyTake.MT_Updt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respMonthlyTake.IsSuccess = false;
                        respMonthlyTake.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respMonthlyTake;
                    }
                }
            }
            catch (Exception ex)
            {
                respMonthlyTake.IsSuccess = false;
                respMonthlyTake.Message = ex.Message;
                _logger.LogError($"Update Market Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respMonthlyTake;
        }
        public async Task<MonthlyTake> IDeleteMonthlyTakeRecordRL(MonthlyTake monthlyTake)
        {
            _logger.LogInformation($"Calling Repository Layer");
            MonthlyTake respMonthlyTake = new MonthlyTake();
            respMonthlyTake.IsSuccess = true;
            respMonthlyTake.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.DeleteMonthlyTake, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@MT_ID", monthlyTake.MT_ID);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respMonthlyTake.IsSuccess = false;
                        respMonthlyTake.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respMonthlyTake;
                    }
                }
            }
            catch (Exception ex)
            {
                respMonthlyTake.IsSuccess = false;
                respMonthlyTake.Message = ex.Message;
                _logger.LogError($"Delete Market Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respMonthlyTake;
        }
    }
}
