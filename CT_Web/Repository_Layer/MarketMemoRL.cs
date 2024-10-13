using CT_App.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CT_Web.Common_Utility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySqlConnector;


namespace CT_Web.Repository_Layer
{
    public class MarketMemoRL : IMarketMemoRL
    {
        public readonly IConfiguration _configuration;
        public readonly MySqlConnection _sqlConn;
        public readonly ILogger<MarketMemoRL> _logger;
        public MarketMemoRL(IConfiguration configuration, ILogger<MarketMemoRL> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _sqlConn = new MySqlConnection(_configuration["ConnectionStrings:connMySql"]);
        }
        public async Task<MarketMemos> ICreateMarketMemoRecordRL(MarketMemos marketMemos)
        {
            _logger.LogInformation($"Calling Repository Layer");
            MarketMemos respMarketMemos = new MarketMemos();
            respMarketMemos.IsSuccess = true;
            respMarketMemos.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.AddMarketMemo, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@Mem_ID,", marketMemos.Mem_ID);
                    cmd.Parameters.AddWithValue("@Mem_Date,", marketMemos.Mem_Date);
                    cmd.Parameters.AddWithValue("@R_InvTK,", marketMemos.R_InvTK);
                    cmd.Parameters.AddWithValue("@C_InvTK,", marketMemos.C_InvTK);
                    cmd.Parameters.AddWithValue("@Giv_TK,", marketMemos.Giv_TK);
                    cmd.Parameters.AddWithValue("@Ret_TK,", marketMemos.Ret_TK);
                    cmd.Parameters.AddWithValue("@I_N01,", marketMemos.I_N01);
                    cmd.Parameters.AddWithValue("@I_N02,", marketMemos.I_N02);
                    cmd.Parameters.AddWithValue("@I_N03,", marketMemos.I_N03);
                    cmd.Parameters.AddWithValue("@I_N04,", marketMemos.I_N04);
                    cmd.Parameters.AddWithValue("@I_N05,", marketMemos.I_N05);
                    cmd.Parameters.AddWithValue("@I_N06,", marketMemos.I_N06);
                    cmd.Parameters.AddWithValue("@I_N07,", marketMemos.I_N07);
                    cmd.Parameters.AddWithValue("@I_N08,", marketMemos.I_N08);
                    cmd.Parameters.AddWithValue("@I_N09,", marketMemos.I_N09);
                    cmd.Parameters.AddWithValue("@I_N10,", marketMemos.I_N10);
                    cmd.Parameters.AddWithValue("@I_N11,", marketMemos.I_N11);
                    cmd.Parameters.AddWithValue("@I_N12,", marketMemos.I_N12);
                    cmd.Parameters.AddWithValue("@I_N13,", marketMemos.I_N13);
                    cmd.Parameters.AddWithValue("@I_N14,", marketMemos.I_N14);
                    cmd.Parameters.AddWithValue("@I_N15,", marketMemos.I_N15);
                    cmd.Parameters.AddWithValue("@I_N16,", marketMemos.I_N16);
                    cmd.Parameters.AddWithValue("@I_P01,", marketMemos.I_P01);
                    cmd.Parameters.AddWithValue("@I_P02,", marketMemos.I_P02);
                    cmd.Parameters.AddWithValue("@I_P03,", marketMemos.I_P03);
                    cmd.Parameters.AddWithValue("@I_P04,", marketMemos.I_P04);
                    cmd.Parameters.AddWithValue("@I_P05,", marketMemos.I_P05);
                    cmd.Parameters.AddWithValue("@I_P06,", marketMemos.I_P06);
                    cmd.Parameters.AddWithValue("@I_P07,", marketMemos.I_P07);
                    cmd.Parameters.AddWithValue("@I_P08,", marketMemos.I_P08);
                    cmd.Parameters.AddWithValue("@I_P09,", marketMemos.I_P09);
                    cmd.Parameters.AddWithValue("@I_P10,", marketMemos.I_P10);
                    cmd.Parameters.AddWithValue("@I_P11,", marketMemos.I_P11);
                    cmd.Parameters.AddWithValue("@I_P12,", marketMemos.I_P12);
                    cmd.Parameters.AddWithValue("@I_P13,", marketMemos.I_P13);
                    cmd.Parameters.AddWithValue("@I_P14,", marketMemos.I_P14);
                    cmd.Parameters.AddWithValue("@I_P15,", marketMemos.I_P15);
                    cmd.Parameters.AddWithValue("@I_P16,", marketMemos.I_P16);
                    cmd.Parameters.AddWithValue("@I_Q01,", marketMemos.I_Q01);
                    cmd.Parameters.AddWithValue("@I_Q02,", marketMemos.I_Q02);
                    cmd.Parameters.AddWithValue("@I_Q03,", marketMemos.I_Q03);
                    cmd.Parameters.AddWithValue("@I_Q04,", marketMemos.I_Q04);
                    cmd.Parameters.AddWithValue("@I_Q05,", marketMemos.I_Q05);
                    cmd.Parameters.AddWithValue("@I_Q06,", marketMemos.I_Q06);
                    cmd.Parameters.AddWithValue("@I_Q07,", marketMemos.I_Q07);
                    cmd.Parameters.AddWithValue("@I_Q08,", marketMemos.I_Q08);
                    cmd.Parameters.AddWithValue("@I_Q09,", marketMemos.I_Q09);
                    cmd.Parameters.AddWithValue("@I_Q10,", marketMemos.I_Q10);
                    cmd.Parameters.AddWithValue("@I_Q11,", marketMemos.I_Q11);
                    cmd.Parameters.AddWithValue("@I_Q12,", marketMemos.I_Q12);
                    cmd.Parameters.AddWithValue("@I_Q13,", marketMemos.I_Q13);
                    cmd.Parameters.AddWithValue("@I_Q14,", marketMemos.I_Q14);
                    cmd.Parameters.AddWithValue("@I_Q15,", marketMemos.I_Q15);
                    cmd.Parameters.AddWithValue("@I_Q16,", marketMemos.I_Q16);
                    cmd.Parameters.AddWithValue("@I_ST01,", marketMemos.I_ST01);
                    cmd.Parameters.AddWithValue("@I_ST02,", marketMemos.I_ST02);
                    cmd.Parameters.AddWithValue("@I_ST03,", marketMemos.I_ST03);
                    cmd.Parameters.AddWithValue("@I_ST04,", marketMemos.I_ST04);
                    cmd.Parameters.AddWithValue("@I_ST05,", marketMemos.I_ST05);
                    cmd.Parameters.AddWithValue("@I_ST06,", marketMemos.I_ST06);
                    cmd.Parameters.AddWithValue("@I_ST07,", marketMemos.I_ST07);
                    cmd.Parameters.AddWithValue("@I_ST08,", marketMemos.I_ST08);
                    cmd.Parameters.AddWithValue("@I_ST09,", marketMemos.I_ST09);
                    cmd.Parameters.AddWithValue("@I_ST10,", marketMemos.I_ST10);
                    cmd.Parameters.AddWithValue("@I_ST11,", marketMemos.I_ST11);
                    cmd.Parameters.AddWithValue("@I_ST12,", marketMemos.I_ST12);
                    cmd.Parameters.AddWithValue("@I_ST13,", marketMemos.I_ST13);
                    cmd.Parameters.AddWithValue("@I_ST14,", marketMemos.I_ST14);
                    cmd.Parameters.AddWithValue("@I_ST15,", marketMemos.I_ST15);
                    cmd.Parameters.AddWithValue("@I_ST16,", marketMemos.I_ST16);
                    cmd.Parameters.AddWithValue("@R_Inv01,", marketMemos.R_Inv01);
                    cmd.Parameters.AddWithValue("@R_Inv02,", marketMemos.R_Inv02);
                    cmd.Parameters.AddWithValue("@R_Inv03,", marketMemos.R_Inv03);
                    cmd.Parameters.AddWithValue("@R_Inv04,", marketMemos.R_Inv04);
                    cmd.Parameters.AddWithValue("@R_Inv05,", marketMemos.R_Inv05);
                    cmd.Parameters.AddWithValue("@R_Inv06,", marketMemos.R_Inv06);
                    cmd.Parameters.AddWithValue("@R_Inv07,", marketMemos.R_Inv07);
                    cmd.Parameters.AddWithValue("@R_Inv08,", marketMemos.R_Inv08);
                    cmd.Parameters.AddWithValue("@R_Inv09,", marketMemos.R_Inv09);
                    cmd.Parameters.AddWithValue("@R_Inv10,", marketMemos.R_Inv10);
                    cmd.Parameters.AddWithValue("@R_Inv11,", marketMemos.R_Inv11);
                    cmd.Parameters.AddWithValue("@R_Inv12,", marketMemos.R_Inv12);
                    cmd.Parameters.AddWithValue("@R_Inv13,", marketMemos.R_Inv13);
                    cmd.Parameters.AddWithValue("@R_Inv14,", marketMemos.R_Inv14);
                    cmd.Parameters.AddWithValue("@R_Inv15,", marketMemos.R_Inv15);
                    cmd.Parameters.AddWithValue("@R_Inv16,", marketMemos.R_Inv16);
                    cmd.Parameters.AddWithValue("@R_Inv17,", marketMemos.R_Inv17);
                    cmd.Parameters.AddWithValue("@R_Inv18,", marketMemos.R_Inv18);
                    cmd.Parameters.AddWithValue("@R_Inv19,", marketMemos.R_Inv19);
                    cmd.Parameters.AddWithValue("@R_Inv20,", marketMemos.R_Inv20);
                    cmd.Parameters.AddWithValue("@R_Inv21,", marketMemos.R_Inv21);
                    cmd.Parameters.AddWithValue("@R_Inv22,", marketMemos.R_Inv22);
                    cmd.Parameters.AddWithValue("@R_Inv23,", marketMemos.R_Inv23);
                    cmd.Parameters.AddWithValue("@R_Inv24,", marketMemos.R_Inv24);
                    cmd.Parameters.AddWithValue("@Mem_Insrt_Person,", marketMemos.Mem_Insrt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respMarketMemos.IsSuccess = false;
                        respMarketMemos.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respMarketMemos;
                    }
                }
            }
            catch (Exception ex)
            {
                respMarketMemos.IsSuccess = false;
                respMarketMemos.Message = ex.Message;
                _logger.LogError($"Insert MarketMemo Record Error Message : {ex.Message}");
            }
            finally
            {
               await _sqlConn.CloseAsync();
               await _sqlConn.DisposeAsync();
            }
            return respMarketMemos;
        }
        public async Task<MarketMemos> IReadMarketMemoRecordRL()
        {
            _logger.LogInformation($"Calling Repository Layer");
            MarketMemos respMarketMemos = new MarketMemos();
            respMarketMemos.IsSuccess = true;
            respMarketMemos.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetMarketMemo, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respMarketMemos.MarketMemosDataList = new List<MarketMemos>();
                            while (await dataReader.ReadAsync())
                            {
                                MarketMemos getData = new MarketMemos()
                                {
                                    Mem_ID = dataReader["Mem_ID"] as string,
                                    Mem_Date = (DateTime)(dataReader["M_Date"] as DateTime?),
                                    R_InvTK = dataReader["R_InvTK"] as float? ?? 0,
                                    C_InvTK = dataReader["C_InvTK"] as float? ?? 0,
                                    Giv_TK = dataReader["Giv_TK"] as float? ?? 0,
                                    Ret_TK = dataReader["Ret_TK"] as float? ?? 0,
                                    I_N01 = dataReader["I_N01"] as string,
                                    I_N02 = dataReader["I_N02"] as string,
                                    I_N03 = dataReader["I_N03"] as string,
                                    I_N04 = dataReader["I_N04"] as string,
                                    I_N05 = dataReader["I_N05"] as string,
                                    I_N06 = dataReader["I_N06"] as string,
                                    I_N07 = dataReader["I_N07"] as string,
                                    I_N08 = dataReader["I_N08"] as string,
                                    I_N09 = dataReader["I_N09"] as string,
                                    I_N10 = dataReader["I_N10"] as string,
                                    I_N11 = dataReader["I_N11"] as string,
                                    I_N12 = dataReader["I_N12"] as string,
                                    I_N13 = dataReader["I_N13"] as string,
                                    I_N14 = dataReader["I_N14"] as string,
                                    I_N15 = dataReader["I_N15"] as string,
                                    I_N16 = dataReader["I_N16"] as string,
                                    I_P01 = dataReader["I_P01"] as float? ?? 0,
                                    I_P02 = dataReader["I_P02"] as float? ?? 0,
                                    I_P03 = dataReader["I_P03"] as float? ?? 0,
                                    I_P04 = dataReader["I_P04"] as float? ?? 0,
                                    I_P05 = dataReader["I_P05"] as float? ?? 0,
                                    I_P06 = dataReader["I_P06"] as float? ?? 0,
                                    I_P07 = dataReader["I_P07"] as float? ?? 0,
                                    I_P08 = dataReader["I_P08"] as float? ?? 0,
                                    I_P09 = dataReader["I_P09"] as float? ?? 0,
                                    I_P10 = dataReader["I_P10"] as float? ?? 0,
                                    I_P11 = dataReader["I_P11"] as float? ?? 0,
                                    I_P12 = dataReader["I_P12"] as float? ?? 0,
                                    I_P13 = dataReader["I_P13"] as float? ?? 0,
                                    I_P14 = dataReader["I_P14"] as float? ?? 0,
                                    I_P15 = dataReader["I_P15"] as float? ?? 0,
                                    I_P16 = dataReader["I_P16"] as float? ?? 0,
                                    I_Q01 = dataReader["I_Q01"] as float? ?? 0,
                                    I_Q02 = dataReader["I_Q02"] as float? ?? 0,
                                    I_Q03 = dataReader["I_Q03"] as float? ?? 0,
                                    I_Q04 = dataReader["I_Q04"] as float? ?? 0,
                                    I_Q05 = dataReader["I_Q05"] as float? ?? 0,
                                    I_Q06 = dataReader["I_Q06"] as float? ?? 0,
                                    I_Q07 = dataReader["I_Q07"] as float? ?? 0,
                                    I_Q08 = dataReader["I_Q08"] as float? ?? 0,
                                    I_Q09 = dataReader["I_Q09"] as float? ?? 0,
                                    I_Q10 = dataReader["I_Q10"] as float? ?? 0,
                                    I_Q11 = dataReader["I_Q11"] as float? ?? 0,
                                    I_Q12 = dataReader["I_Q12"] as float? ?? 0,
                                    I_Q13 = dataReader["I_Q13"] as float? ?? 0,
                                    I_Q14 = dataReader["I_Q14"] as float? ?? 0,
                                    I_Q15 = dataReader["I_Q15"] as float? ?? 0,
                                    I_Q16 = dataReader["I_Q16"] as float? ?? 0,
                                    I_ST01 = dataReader["I_ST01"] as float? ?? 0,
                                    I_ST02 = dataReader["I_ST02"] as float? ?? 0,
                                    I_ST03 = dataReader["I_ST03"] as float? ?? 0,
                                    I_ST04 = dataReader["I_ST04"] as float? ?? 0,
                                    I_ST05 = dataReader["I_ST05"] as float? ?? 0,
                                    I_ST06 = dataReader["I_ST06"] as float? ?? 0,
                                    I_ST07 = dataReader["I_ST07"] as float? ?? 0,
                                    I_ST08 = dataReader["I_ST08"] as float? ?? 0,
                                    I_ST09 = dataReader["I_ST09"] as float? ?? 0,
                                    I_ST10 = dataReader["I_ST10"] as float? ?? 0,
                                    I_ST11 = dataReader["I_ST11"] as float? ?? 0,
                                    I_ST12 = dataReader["I_ST12"] as float? ?? 0,
                                    I_ST13 = dataReader["I_ST13"] as float? ?? 0,
                                    I_ST14 = dataReader["I_ST14"] as float? ?? 0,
                                    I_ST15 = dataReader["I_ST15"] as float? ?? 0,
                                    I_ST16 = dataReader["I_ST16"] as float? ?? 0,
                                    R_Inv01 = dataReader["R_Inv01"] as string,
                                    R_Inv02 = dataReader["R_Inv02"] as string,
                                    R_Inv03 = dataReader["R_Inv03"] as string,
                                    R_Inv04 = dataReader["R_Inv04"] as string,
                                    R_Inv05 = dataReader["R_Inv05"] as string,
                                    R_Inv06 = dataReader["R_Inv06"] as string,
                                    R_Inv07 = dataReader["R_Inv07"] as string,
                                    R_Inv08 = dataReader["R_Inv08"] as string,
                                    R_Inv09 = dataReader["R_Inv09"] as string,
                                    R_Inv10 = dataReader["R_Inv10"] as string,
                                    R_Inv11 = dataReader["R_Inv11"] as string,
                                    R_Inv12 = dataReader["R_Inv12"] as string,
                                    R_Inv13 = dataReader["R_Inv13"] as string,
                                    R_Inv14 = dataReader["R_Inv14"] as string,
                                    R_Inv15 = dataReader["R_Inv15"] as string,
                                    R_Inv16 = dataReader["R_Inv16"] as string,
                                    R_Inv17 = dataReader["R_Inv17"] as string,
                                    R_Inv18 = dataReader["R_Inv18"] as string,
                                    R_Inv19 = dataReader["R_Inv19"] as string,
                                    R_Inv20 = dataReader["R_Inv20"] as string,
                                    R_Inv21 = dataReader["R_Inv21"] as string,
                                    R_Inv22 = dataReader["R_Inv22"] as string,
                                    R_Inv23 = dataReader["R_Inv23"] as string,
                                    R_Inv24 = dataReader["R_Inv24"] as string,
                                    Mem_Insrt_Person = dataReader["Mem_Insrt_Person"] as string,
                                    Mem_Updt_Person = dataReader["Mem_Updt_Person"] as string,
                                    Mem_Del_Person = dataReader["Mem_Del_Person"] as string
                                };
                                //getData.M_ID = (string)(dataReader["M_ID"] != DBNull.Value ? dataReader["M_ID"] : null);
                                //getData.M_Date = (DateTime)(dataReader["M_Date"] != DBNull.Value ? Convert.ToDateTime(dataReader["M_Date"]) : (DateTime?)null);
                                //getData.M_Amount = (float)(dataReader["M_Amount"] != DBNull.Value ? dataReader["M_Amount"] : 0);
                                //getData.M_Insrt_Person = (string)(dataReader["M_Insrt_Person"] != DBNull.Value ? dataReader["M_Insrt_Person"] : null);
                                //getData.M_Updt_Person = (string)(dataReader["M_Updt_Person"] != DBNull.Value ? dataReader["M_Updt_Person"] : null);
                                //getData.M_Del_Person = (string)(dataReader["M_Del_Person"] != DBNull.Value ? dataReader["M_Del_Person"] : null);
                                respMarketMemos.MarketMemosDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respMarketMemos.IsSuccess = true;
                            respMarketMemos.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respMarketMemos.IsSuccess = false;
                respMarketMemos.Message = ex.Message;
                _logger.LogError($"Read MarketMemo Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respMarketMemos;
        }
        public async Task<MarketMemos> IReadMarketMemoIDRecordRL(MarketMemos marketMemos)
        {
            _logger.LogInformation($"Calling Repository Layer");
            MarketMemos respMarketMemos = new MarketMemos();
            respMarketMemos.IsSuccess = true;
            respMarketMemos.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetMarketMemoID, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@Mem_ID", marketMemos.Mem_ID);
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respMarketMemos.MarketMemosDataList = new List<MarketMemos>();
                            if (await dataReader.ReadAsync())
                            {
                                MarketMemos getData = new MarketMemos()
                                {
                                    Mem_ID = dataReader["Mem_ID"] as string,
                                    Mem_Date = (DateTime)(dataReader["M_Date"] as DateTime?),
                                    R_InvTK = dataReader["R_InvTK"] as float? ?? 0,
                                    C_InvTK = dataReader["C_InvTK"] as float? ?? 0,
                                    Giv_TK = dataReader["Giv_TK"] as float? ?? 0,
                                    Ret_TK = dataReader["Ret_TK"] as float? ?? 0,
                                    I_N01 = dataReader["I_N01"] as string,
                                    I_N02 = dataReader["I_N02"] as string,
                                    I_N03 = dataReader["I_N03"] as string,
                                    I_N04 = dataReader["I_N04"] as string,
                                    I_N05 = dataReader["I_N05"] as string,
                                    I_N06 = dataReader["I_N06"] as string,
                                    I_N07 = dataReader["I_N07"] as string,
                                    I_N08 = dataReader["I_N08"] as string,
                                    I_N09 = dataReader["I_N09"] as string,
                                    I_N10 = dataReader["I_N10"] as string,
                                    I_N11 = dataReader["I_N11"] as string,
                                    I_N12 = dataReader["I_N12"] as string,
                                    I_N13 = dataReader["I_N13"] as string,
                                    I_N14 = dataReader["I_N14"] as string,
                                    I_N15 = dataReader["I_N15"] as string,
                                    I_N16 = dataReader["I_N16"] as string,
                                    I_P01 = dataReader["I_P01"] as float? ?? 0,
                                    I_P02 = dataReader["I_P02"] as float? ?? 0,
                                    I_P03 = dataReader["I_P03"] as float? ?? 0,
                                    I_P04 = dataReader["I_P04"] as float? ?? 0,
                                    I_P05 = dataReader["I_P05"] as float? ?? 0,
                                    I_P06 = dataReader["I_P06"] as float? ?? 0,
                                    I_P07 = dataReader["I_P07"] as float? ?? 0,
                                    I_P08 = dataReader["I_P08"] as float? ?? 0,
                                    I_P09 = dataReader["I_P09"] as float? ?? 0,
                                    I_P10 = dataReader["I_P10"] as float? ?? 0,
                                    I_P11 = dataReader["I_P11"] as float? ?? 0,
                                    I_P12 = dataReader["I_P12"] as float? ?? 0,
                                    I_P13 = dataReader["I_P13"] as float? ?? 0,
                                    I_P14 = dataReader["I_P14"] as float? ?? 0,
                                    I_P15 = dataReader["I_P15"] as float? ?? 0,
                                    I_P16 = dataReader["I_P16"] as float? ?? 0,
                                    I_Q01 = dataReader["I_Q01"] as float? ?? 0,
                                    I_Q02 = dataReader["I_Q02"] as float? ?? 0,
                                    I_Q03 = dataReader["I_Q03"] as float? ?? 0,
                                    I_Q04 = dataReader["I_Q04"] as float? ?? 0,
                                    I_Q05 = dataReader["I_Q05"] as float? ?? 0,
                                    I_Q06 = dataReader["I_Q06"] as float? ?? 0,
                                    I_Q07 = dataReader["I_Q07"] as float? ?? 0,
                                    I_Q08 = dataReader["I_Q08"] as float? ?? 0,
                                    I_Q09 = dataReader["I_Q09"] as float? ?? 0,
                                    I_Q10 = dataReader["I_Q10"] as float? ?? 0,
                                    I_Q11 = dataReader["I_Q11"] as float? ?? 0,
                                    I_Q12 = dataReader["I_Q12"] as float? ?? 0,
                                    I_Q13 = dataReader["I_Q13"] as float? ?? 0,
                                    I_Q14 = dataReader["I_Q14"] as float? ?? 0,
                                    I_Q15 = dataReader["I_Q15"] as float? ?? 0,
                                    I_Q16 = dataReader["I_Q16"] as float? ?? 0,
                                    I_ST01 = dataReader["I_ST01"] as float? ?? 0,
                                    I_ST02 = dataReader["I_ST02"] as float? ?? 0,
                                    I_ST03 = dataReader["I_ST03"] as float? ?? 0,
                                    I_ST04 = dataReader["I_ST04"] as float? ?? 0,
                                    I_ST05 = dataReader["I_ST05"] as float? ?? 0,
                                    I_ST06 = dataReader["I_ST06"] as float? ?? 0,
                                    I_ST07 = dataReader["I_ST07"] as float? ?? 0,
                                    I_ST08 = dataReader["I_ST08"] as float? ?? 0,
                                    I_ST09 = dataReader["I_ST09"] as float? ?? 0,
                                    I_ST10 = dataReader["I_ST10"] as float? ?? 0,
                                    I_ST11 = dataReader["I_ST11"] as float? ?? 0,
                                    I_ST12 = dataReader["I_ST12"] as float? ?? 0,
                                    I_ST13 = dataReader["I_ST13"] as float? ?? 0,
                                    I_ST14 = dataReader["I_ST14"] as float? ?? 0,
                                    I_ST15 = dataReader["I_ST15"] as float? ?? 0,
                                    I_ST16 = dataReader["I_ST16"] as float? ?? 0,
                                    R_Inv01 = dataReader["R_Inv01"] as string,
                                    R_Inv02 = dataReader["R_Inv02"] as string,
                                    R_Inv03 = dataReader["R_Inv03"] as string,
                                    R_Inv04 = dataReader["R_Inv04"] as string,
                                    R_Inv05 = dataReader["R_Inv05"] as string,
                                    R_Inv06 = dataReader["R_Inv06"] as string,
                                    R_Inv07 = dataReader["R_Inv07"] as string,
                                    R_Inv08 = dataReader["R_Inv08"] as string,
                                    R_Inv09 = dataReader["R_Inv09"] as string,
                                    R_Inv10 = dataReader["R_Inv10"] as string,
                                    R_Inv11 = dataReader["R_Inv11"] as string,
                                    R_Inv12 = dataReader["R_Inv12"] as string,
                                    R_Inv13 = dataReader["R_Inv13"] as string,
                                    R_Inv14 = dataReader["R_Inv14"] as string,
                                    R_Inv15 = dataReader["R_Inv15"] as string,
                                    R_Inv16 = dataReader["R_Inv16"] as string,
                                    R_Inv17 = dataReader["R_Inv17"] as string,
                                    R_Inv18 = dataReader["R_Inv18"] as string,
                                    R_Inv19 = dataReader["R_Inv19"] as string,
                                    R_Inv20 = dataReader["R_Inv20"] as string,
                                    R_Inv21 = dataReader["R_Inv21"] as string,
                                    R_Inv22 = dataReader["R_Inv22"] as string,
                                    R_Inv23 = dataReader["R_Inv23"] as string,
                                    R_Inv24 = dataReader["R_Inv24"] as string,
                                    Mem_Insrt_Person = dataReader["Mem_Insrt_Person"] as string,
                                    Mem_Updt_Person = dataReader["Mem_Updt_Person"] as string,
                                    Mem_Del_Person = dataReader["Mem_Del_Person"] as string
                                };
                                respMarketMemos.MarketMemosDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respMarketMemos.IsSuccess = true;
                            respMarketMemos.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respMarketMemos.IsSuccess = false;
                respMarketMemos.Message = ex.Message;
                _logger.LogError($"Update MarketMemo Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respMarketMemos;
        }
        public async Task<MarketMemos> IUpdateMarketMemoRecordRL(MarketMemos marketMemos)
        {
            _logger.LogInformation($"Calling Repository Layer");
            MarketMemos respMarketMemos = new MarketMemos();
            respMarketMemos.IsSuccess = true;
            respMarketMemos.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.UpdateMarketMemo, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@Mem_ID,", marketMemos.Mem_ID);
                    cmd.Parameters.AddWithValue("@Mem_Date,", marketMemos.Mem_Date);
                    cmd.Parameters.AddWithValue("@R_InvTK,", marketMemos.R_InvTK);
                    cmd.Parameters.AddWithValue("@C_InvTK,", marketMemos.C_InvTK);
                    cmd.Parameters.AddWithValue("@Giv_TK,", marketMemos.Giv_TK);
                    cmd.Parameters.AddWithValue("@Ret_TK,", marketMemos.Ret_TK);
                    cmd.Parameters.AddWithValue("@I_N01,", marketMemos.I_N01);
                    cmd.Parameters.AddWithValue("@I_N02,", marketMemos.I_N02);
                    cmd.Parameters.AddWithValue("@I_N03,", marketMemos.I_N03);
                    cmd.Parameters.AddWithValue("@I_N04,", marketMemos.I_N04);
                    cmd.Parameters.AddWithValue("@I_N05,", marketMemos.I_N05);
                    cmd.Parameters.AddWithValue("@I_N06,", marketMemos.I_N06);
                    cmd.Parameters.AddWithValue("@I_N07,", marketMemos.I_N07);
                    cmd.Parameters.AddWithValue("@I_N08,", marketMemos.I_N08);
                    cmd.Parameters.AddWithValue("@I_N09,", marketMemos.I_N09);
                    cmd.Parameters.AddWithValue("@I_N10,", marketMemos.I_N10);
                    cmd.Parameters.AddWithValue("@I_N11,", marketMemos.I_N11);
                    cmd.Parameters.AddWithValue("@I_N12,", marketMemos.I_N12);
                    cmd.Parameters.AddWithValue("@I_N13,", marketMemos.I_N13);
                    cmd.Parameters.AddWithValue("@I_N14,", marketMemos.I_N14);
                    cmd.Parameters.AddWithValue("@I_N15,", marketMemos.I_N15);
                    cmd.Parameters.AddWithValue("@I_N16,", marketMemos.I_N16);
                    cmd.Parameters.AddWithValue("@I_P01,", marketMemos.I_P01);
                    cmd.Parameters.AddWithValue("@I_P02,", marketMemos.I_P02);
                    cmd.Parameters.AddWithValue("@I_P03,", marketMemos.I_P03);
                    cmd.Parameters.AddWithValue("@I_P04,", marketMemos.I_P04);
                    cmd.Parameters.AddWithValue("@I_P05,", marketMemos.I_P05);
                    cmd.Parameters.AddWithValue("@I_P06,", marketMemos.I_P06);
                    cmd.Parameters.AddWithValue("@I_P07,", marketMemos.I_P07);
                    cmd.Parameters.AddWithValue("@I_P08,", marketMemos.I_P08);
                    cmd.Parameters.AddWithValue("@I_P09,", marketMemos.I_P09);
                    cmd.Parameters.AddWithValue("@I_P10,", marketMemos.I_P10);
                    cmd.Parameters.AddWithValue("@I_P11,", marketMemos.I_P11);
                    cmd.Parameters.AddWithValue("@I_P12,", marketMemos.I_P12);
                    cmd.Parameters.AddWithValue("@I_P13,", marketMemos.I_P13);
                    cmd.Parameters.AddWithValue("@I_P14,", marketMemos.I_P14);
                    cmd.Parameters.AddWithValue("@I_P15,", marketMemos.I_P15);
                    cmd.Parameters.AddWithValue("@I_P16,", marketMemos.I_P16);
                    cmd.Parameters.AddWithValue("@I_Q01,", marketMemos.I_Q01);
                    cmd.Parameters.AddWithValue("@I_Q02,", marketMemos.I_Q02);
                    cmd.Parameters.AddWithValue("@I_Q03,", marketMemos.I_Q03);
                    cmd.Parameters.AddWithValue("@I_Q04,", marketMemos.I_Q04);
                    cmd.Parameters.AddWithValue("@I_Q05,", marketMemos.I_Q05);
                    cmd.Parameters.AddWithValue("@I_Q06,", marketMemos.I_Q06);
                    cmd.Parameters.AddWithValue("@I_Q07,", marketMemos.I_Q07);
                    cmd.Parameters.AddWithValue("@I_Q08,", marketMemos.I_Q08);
                    cmd.Parameters.AddWithValue("@I_Q09,", marketMemos.I_Q09);
                    cmd.Parameters.AddWithValue("@I_Q10,", marketMemos.I_Q10);
                    cmd.Parameters.AddWithValue("@I_Q11,", marketMemos.I_Q11);
                    cmd.Parameters.AddWithValue("@I_Q12,", marketMemos.I_Q12);
                    cmd.Parameters.AddWithValue("@I_Q13,", marketMemos.I_Q13);
                    cmd.Parameters.AddWithValue("@I_Q14,", marketMemos.I_Q14);
                    cmd.Parameters.AddWithValue("@I_Q15,", marketMemos.I_Q15);
                    cmd.Parameters.AddWithValue("@I_Q16,", marketMemos.I_Q16);
                    cmd.Parameters.AddWithValue("@I_ST01,", marketMemos.I_ST01);
                    cmd.Parameters.AddWithValue("@I_ST02,", marketMemos.I_ST02);
                    cmd.Parameters.AddWithValue("@I_ST03,", marketMemos.I_ST03);
                    cmd.Parameters.AddWithValue("@I_ST04,", marketMemos.I_ST04);
                    cmd.Parameters.AddWithValue("@I_ST05,", marketMemos.I_ST05);
                    cmd.Parameters.AddWithValue("@I_ST06,", marketMemos.I_ST06);
                    cmd.Parameters.AddWithValue("@I_ST07,", marketMemos.I_ST07);
                    cmd.Parameters.AddWithValue("@I_ST08,", marketMemos.I_ST08);
                    cmd.Parameters.AddWithValue("@I_ST09,", marketMemos.I_ST09);
                    cmd.Parameters.AddWithValue("@I_ST10,", marketMemos.I_ST10);
                    cmd.Parameters.AddWithValue("@I_ST11,", marketMemos.I_ST11);
                    cmd.Parameters.AddWithValue("@I_ST12,", marketMemos.I_ST12);
                    cmd.Parameters.AddWithValue("@I_ST13,", marketMemos.I_ST13);
                    cmd.Parameters.AddWithValue("@I_ST14,", marketMemos.I_ST14);
                    cmd.Parameters.AddWithValue("@I_ST15,", marketMemos.I_ST15);
                    cmd.Parameters.AddWithValue("@I_ST16,", marketMemos.I_ST16);
                    cmd.Parameters.AddWithValue("@R_Inv01,", marketMemos.R_Inv01);
                    cmd.Parameters.AddWithValue("@R_Inv02,", marketMemos.R_Inv02);
                    cmd.Parameters.AddWithValue("@R_Inv03,", marketMemos.R_Inv03);
                    cmd.Parameters.AddWithValue("@R_Inv04,", marketMemos.R_Inv04);
                    cmd.Parameters.AddWithValue("@R_Inv05,", marketMemos.R_Inv05);
                    cmd.Parameters.AddWithValue("@R_Inv06,", marketMemos.R_Inv06);
                    cmd.Parameters.AddWithValue("@R_Inv07,", marketMemos.R_Inv07);
                    cmd.Parameters.AddWithValue("@R_Inv08,", marketMemos.R_Inv08);
                    cmd.Parameters.AddWithValue("@R_Inv09,", marketMemos.R_Inv09);
                    cmd.Parameters.AddWithValue("@R_Inv10,", marketMemos.R_Inv10);
                    cmd.Parameters.AddWithValue("@R_Inv11,", marketMemos.R_Inv11);
                    cmd.Parameters.AddWithValue("@R_Inv12,", marketMemos.R_Inv12);
                    cmd.Parameters.AddWithValue("@R_Inv13,", marketMemos.R_Inv13);
                    cmd.Parameters.AddWithValue("@R_Inv14,", marketMemos.R_Inv14);
                    cmd.Parameters.AddWithValue("@R_Inv15,", marketMemos.R_Inv15);
                    cmd.Parameters.AddWithValue("@R_Inv16,", marketMemos.R_Inv16);
                    cmd.Parameters.AddWithValue("@R_Inv17,", marketMemos.R_Inv17);
                    cmd.Parameters.AddWithValue("@R_Inv18,", marketMemos.R_Inv18);
                    cmd.Parameters.AddWithValue("@R_Inv19,", marketMemos.R_Inv19);
                    cmd.Parameters.AddWithValue("@R_Inv20,", marketMemos.R_Inv20);
                    cmd.Parameters.AddWithValue("@R_Inv21,", marketMemos.R_Inv21);
                    cmd.Parameters.AddWithValue("@R_Inv22,", marketMemos.R_Inv22);
                    cmd.Parameters.AddWithValue("@R_Inv23,", marketMemos.R_Inv23);
                    cmd.Parameters.AddWithValue("@R_Inv24,", marketMemos.R_Inv24);
                    cmd.Parameters.AddWithValue("@Mem_Updt_Person,", marketMemos.Mem_Updt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respMarketMemos.IsSuccess = false;
                        respMarketMemos.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respMarketMemos;
                    }
                }
            }
            catch (Exception ex)
            {
                respMarketMemos.IsSuccess = false;
                respMarketMemos.Message = ex.Message;
                _logger.LogError($"Update MarketMemo Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respMarketMemos;
        }
        public async Task<MarketMemos> IDeleteMarketMemoRecordRL(MarketMemos marketMemos)
        {
            _logger.LogInformation($"Calling Repository Layer");
            MarketMemos respMarketMemos = new MarketMemos();
            respMarketMemos.IsSuccess = true;
            respMarketMemos.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.DeleteMarketMemo, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@Mem_ID,", marketMemos.Mem_ID);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respMarketMemos.IsSuccess = false;
                        respMarketMemos.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respMarketMemos;
                    }
                }
            }
            catch (Exception ex)
            {
                respMarketMemos.IsSuccess = false;
                respMarketMemos.Message = ex.Message;
                _logger.LogError($"Update MarketMamo Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respMarketMemos;
        }
    }
}
