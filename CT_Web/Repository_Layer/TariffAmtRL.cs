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
    public class TariffAmtRL : ITariffAmtRL
    {
        public readonly IConfiguration _configurationTariffAmt;
        public readonly MySqlConnection _sqlConn;
        public readonly ILogger<TariffAmtRL> _logger;
        public TariffAmtRL(IConfiguration configurationTariffAmt, ILogger<TariffAmtRL> logger)
        {
            _configurationTariffAmt = configurationTariffAmt;
            _logger = logger;
            _sqlConn = new MySqlConnection(_configurationTariffAmt["ConnectionStrings:connMySql"]);
        }

        public async Task<TariffAmt> ICreateTariffAmtRecordRL(TariffAmt tariffAmt)
        {
            _logger.LogInformation($"Calling Repository Layer");
            TariffAmt respTariffAmt = new TariffAmt();
            respTariffAmt.IsSuccess = true;
            respTariffAmt.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.AddTariffAmt, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@InExpense", tariffAmt.InExpense);
                    cmd.Parameters.AddWithValue("@Expense_Amount", tariffAmt.Expense_Amount);
                    cmd.Parameters.AddWithValue("@Expense_To", tariffAmt.Expense_To);
                    cmd.Parameters.AddWithValue("@ThroughBy_Expense", tariffAmt.ThroughBy_Expense);
                    cmd.Parameters.AddWithValue("@Expense_Date", tariffAmt.Expense_Date);
                    cmd.Parameters.AddWithValue("@Remarks_Expense", tariffAmt.Remarks_Expense);
                    cmd.Parameters.AddWithValue("@EDT_V", tariffAmt.EDT_V);
                    cmd.Parameters.AddWithValue("@E_Insrt_Person", tariffAmt.E_Insrt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respTariffAmt.IsSuccess = false;
                        respTariffAmt.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respTariffAmt;
                    }
                }
            }
            catch (Exception ex)
            {
                respTariffAmt.IsSuccess = false;
                respTariffAmt.Message = ex.Message;
                _logger.LogError($"Insert TariffAmt Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respTariffAmt;
        }
        public async Task<TariffAmt> IReadTariffAmtRecordRL()
        {
            _logger.LogInformation($"Calling Repository Layer");
            TariffAmt respTariffAmt = new TariffAmt();
            respTariffAmt.IsSuccess = true;
            respTariffAmt.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetTariffAmt, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respTariffAmt.TariffAmtDataList = new List<TariffAmt>();
                            while (await dataReader.ReadAsync())
                            {
                                TariffAmt getData = new TariffAmt()
                                {
                                    InExpense = dataReader["InExpense"] as string,
                                    Expense_Amount = dataReader["Expense_Amount"] as float? ?? 0,
                                    Expense_To = dataReader["Expense_To"] as string,
                                    ThroughBy_Expense = dataReader["ThroughBy_Expense"] as string,
                                    Expense_Date = (DateTime)(dataReader["Expense_Date"] as DateTime?),
                                    Remarks_Expense = dataReader["Remarks_Expense"] as string,
                                    EDT_V = dataReader["EDT_V"] as string,
                                    EDT_V_Date = (DateTime)(dataReader["EDT_V_Date"] as DateTime?),
                                    DDT_V_Date = (DateTime)(dataReader["DDT_V_Date"] as DateTime?),
                                    E_Insrt_Person = dataReader["E_Insrt_Person"] as string,
                                    E_Updt_Person = dataReader["E_Updt_Person"] as string,
                                    E_Del_Person = dataReader["E_Del_Person"] as string
                                };
                                respTariffAmt.TariffAmtDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respTariffAmt.IsSuccess = true;
                            respTariffAmt.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respTariffAmt.IsSuccess = false;
                respTariffAmt.Message = ex.Message;
                _logger.LogError($"Read TariffAmt Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respTariffAmt;
        }
        public async Task<TariffAmt> IReadTariffAmtIDRecordRL(TariffAmt tariffAmt)
        {
            _logger.LogInformation($"Calling Repository Layer");
            TariffAmt respTariffAmt = new TariffAmt();
            respTariffAmt.IsSuccess = true;
            respTariffAmt.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetTariffAmtID, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@InExpense", tariffAmt.InExpense);
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respTariffAmt.TariffAmtDataList = new List<TariffAmt>();
                            if (await dataReader.ReadAsync())
                            {
                                TariffAmt getData = new TariffAmt()
                                {
                                    InExpense = dataReader["InExpense"] as string,
                                    Expense_Amount = dataReader["Expense_Amount"] as float? ?? 0,
                                    Expense_To = dataReader["Expense_To"] as string,
                                    ThroughBy_Expense = dataReader["ThroughBy_Expense"] as string,
                                    Expense_Date = (DateTime)(dataReader["Expense_Date"] as DateTime?),
                                    Remarks_Expense = dataReader["Remarks_Expense"] as string,
                                    EDT_V = dataReader["EDT_V"] as string,
                                    EDT_V_Date = (DateTime)(dataReader["EDT_V_Date"] as DateTime?),
                                    DDT_V_Date = (DateTime)(dataReader["DDT_V_Date"] as DateTime?),
                                    E_Insrt_Person = dataReader["E_Insrt_Person"] as string,
                                    E_Updt_Person = dataReader["E_Updt_Person"] as string,
                                    E_Del_Person = dataReader["E_Del_Person"] as string
                                };
                                respTariffAmt.TariffAmtDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respTariffAmt.IsSuccess = true;
                            respTariffAmt.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respTariffAmt.IsSuccess = false;
                respTariffAmt.Message = ex.Message;
                _logger.LogError($"Update TariffAmt ID Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respTariffAmt;
        }
        public async Task<TariffAmt> IUpdateTariffAmtRecordRL(TariffAmt tariffAmt)
        {
            _logger.LogInformation($"Calling Repository Layer");
            TariffAmt respTariffAmt = new TariffAmt();
            respTariffAmt.IsSuccess = true;
            respTariffAmt.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.UpdateTariffAmt, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@InExpense", tariffAmt.InExpense);
                    cmd.Parameters.AddWithValue("@Expense_Amount", tariffAmt.Expense_Amount);
                    cmd.Parameters.AddWithValue("@Expense_To", tariffAmt.Expense_To);
                    cmd.Parameters.AddWithValue("@ThroughBy_Expense", tariffAmt.ThroughBy_Expense);
                    cmd.Parameters.AddWithValue("@Remarks_Expense", tariffAmt.Remarks_Expense);
                    cmd.Parameters.AddWithValue("@EDT_V_Date", tariffAmt.EDT_V_Date);
                    cmd.Parameters.AddWithValue("@E_Updt_Person", tariffAmt.E_Updt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respTariffAmt.IsSuccess = false;
                        respTariffAmt.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respTariffAmt;
                    }
                }
            }
            catch (Exception ex)
            {
                respTariffAmt.IsSuccess = false;
                respTariffAmt.Message = ex.Message;
                _logger.LogError($"Update TariffAmt Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respTariffAmt;
        }
        public async Task<TariffAmt> IDeleteTariffAmtRecordRL(TariffAmt tariffAmt)
        {
            _logger.LogInformation($"Calling Repository Layer");
            TariffAmt respTariffAmt = new TariffAmt();
            respTariffAmt.IsSuccess = true;
            respTariffAmt.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.DeleteTariffAmt, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@InExpense", tariffAmt.InExpense);
                    cmd.Parameters.AddWithValue("@EDT_V", tariffAmt.EDT_V);
                    cmd.Parameters.AddWithValue("@DDT_V_Date", tariffAmt.DDT_V_Date);
                    cmd.Parameters.AddWithValue("@E_Del_Person", tariffAmt.E_Del_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respTariffAmt.IsSuccess = false;
                        respTariffAmt.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respTariffAmt;
                    }
                }
            }
            catch (Exception ex)
            {
                respTariffAmt.IsSuccess = false;
                respTariffAmt.Message = ex.Message;
                _logger.LogError($"Delete TariffAmt Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respTariffAmt;
        }
    }
}
