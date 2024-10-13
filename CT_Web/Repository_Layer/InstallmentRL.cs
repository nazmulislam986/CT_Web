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
    public class InstallmentRL : IInstallmentRL
    {
        public readonly IConfiguration _configuration;
        public readonly MySqlConnection _sqlConn;
        public readonly ILogger<InstallmentRL> _logger;
        public InstallmentRL(IConfiguration configuration, ILogger<InstallmentRL> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _sqlConn = new MySqlConnection(_configuration["ConnectionStrings:connMySql"]);
        }

        public async Task<Installment> ICreateInstallmentRecordRL(Installment installment)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Installment respInstallment = new Installment();
            respInstallment.IsSuccess = true;
            respInstallment.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.AddInstallment, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@I_ID", installment.I_ID);
                    cmd.Parameters.AddWithValue("@I_Date", installment.I_Date);
                    cmd.Parameters.AddWithValue("@Take_Total", installment.Take_Total);
                    cmd.Parameters.AddWithValue("@Take_Anot", installment.Take_Anot);
                    cmd.Parameters.AddWithValue("@Take_Mine", installment.Take_Mine);
                    cmd.Parameters.AddWithValue("@Take_Data", installment.Take_Data);
                    cmd.Parameters.AddWithValue("@InsPerMonth", installment.InsPerMonth);
                    cmd.Parameters.AddWithValue("@PerMonthPay", installment.PerMonthPay);
                    cmd.Parameters.AddWithValue("@InsPay", installment.InsPay);
                    cmd.Parameters.AddWithValue("@InsPay_Date", installment.InsPay_Date);
                    cmd.Parameters.AddWithValue("@I_Insrt_Person", installment.I_Insrt_Person);
                    cmd.Parameters.AddWithValue("@I_Updt_Person", installment.I_Updt_Person);
                    cmd.Parameters.AddWithValue("@I_Del_Person", installment.I_Del_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respInstallment.IsSuccess = false;
                        respInstallment.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respInstallment;
                    }
                }
            }
            catch (Exception ex)
            {
                respInstallment.IsSuccess = false;
                respInstallment.Message = ex.Message;
                _logger.LogError($"Insert Installment Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respInstallment;
        }
        public async Task<Installment> IReadInstallmentRecordRL()
        {
            _logger.LogInformation($"Calling Repository Layer");
            Installment respInstallment = new Installment();
            respInstallment.IsSuccess = true;
            respInstallment.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetInstallment, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respInstallment.InstallmentDataList = new List<Installment>();
                            while (await dataReader.ReadAsync())
                            {
                                Installment getData = new Installment()
                                {
                                    I_ID = dataReader["I_ID"] as string,
                                    I_Date = (DateTime)(dataReader["M_Date"] as DateTime?),
                                    Take_Total = dataReader["Take_Total"] as float? ?? 0,
                                    Take_Anot = dataReader["Take_Anot"] as float? ?? 0,
                                    Take_Mine = dataReader["Take_Mine"] as float? ?? 0,
                                    Take_Data = (DateTime)(dataReader["Take_Data"] as DateTime?),
                                    InsPerMonth = dataReader["InsPerMonth"] as float? ?? 0,
                                    PerMonthPay = dataReader["PerMonthPay"] as float? ?? 0,
                                    InsPay = dataReader["InsPay"] as float? ?? 0,
                                    InsPay_Date = (DateTime)(dataReader["InsPay_Date"] as DateTime?),
                                    I_Insrt_Person = dataReader["I_Insrt_Person"] as string,
                                    I_Updt_Person = dataReader["I_Updt_Person"] as string,
                                    I_Del_Person = dataReader["I_Del_Person"] as string
                                };
                                respInstallment.InstallmentDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respInstallment.IsSuccess = true;
                            respInstallment.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respInstallment.IsSuccess = false;
                respInstallment.Message = ex.Message;
                _logger.LogError($"Read Installment Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respInstallment;
        }
        public async Task<Installment> IReadInstallmentIDRecordRL(Installment installment)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Installment respInstallment = new Installment();
            respInstallment.IsSuccess = true;
            respInstallment.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetInstallmentID, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@I_ID", installment.I_ID);
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respInstallment.InstallmentDataList = new List<Installment>();
                            if (await dataReader.ReadAsync())
                            {
                                Installment getData = new Installment()
                                {
                                    I_ID = dataReader["I_ID"] as string,
                                    I_Date = (DateTime)(dataReader["M_Date"] as DateTime?),
                                    Take_Total = dataReader["Take_Total"] as float? ?? 0,
                                    Take_Anot = dataReader["Take_Anot"] as float? ?? 0,
                                    Take_Mine = dataReader["Take_Mine"] as float? ?? 0,
                                    Take_Data = (DateTime)(dataReader["Take_Data"] as DateTime?),
                                    InsPerMonth = dataReader["InsPerMonth"] as float? ?? 0,
                                    PerMonthPay = dataReader["PerMonthPay"] as float? ?? 0,
                                    InsPay = dataReader["InsPay"] as float? ?? 0,
                                    InsPay_Date = (DateTime)(dataReader["InsPay_Date"] as DateTime?),
                                    I_Insrt_Person = dataReader["I_Insrt_Person"] as string,
                                    I_Updt_Person = dataReader["I_Updt_Person"] as string,
                                    I_Del_Person = dataReader["I_Del_Person"] as string
                                };
                                respInstallment.InstallmentDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respInstallment.IsSuccess = true;
                            respInstallment.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respInstallment.IsSuccess = false;
                respInstallment.Message = ex.Message;
                _logger.LogError($"Update Installment ID Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respInstallment;
        }
        public async Task<Installment> IUpdateInstallmentRecordRL(Installment installment)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Installment respInstallment = new Installment();
            respInstallment.IsSuccess = true;
            respInstallment.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.UpdateInstallment, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@I_ID", installment.I_ID);
                    cmd.Parameters.AddWithValue("@Take_Total", installment.Take_Total);
                    cmd.Parameters.AddWithValue("@Take_Anot", installment.Take_Anot);
                    cmd.Parameters.AddWithValue("@Take_Mine", installment.Take_Mine);
                    cmd.Parameters.AddWithValue("@Take_Data", installment.Take_Data);
                    cmd.Parameters.AddWithValue("@InsPerMonth", installment.InsPerMonth);
                    cmd.Parameters.AddWithValue("@PerMonthPay", installment.PerMonthPay);
                    cmd.Parameters.AddWithValue("@InsPay", installment.InsPay);
                    cmd.Parameters.AddWithValue("@InsPay_Date", installment.InsPay_Date);
                    cmd.Parameters.AddWithValue("@I_Updt_Person", installment.I_Updt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respInstallment.IsSuccess = false;
                        respInstallment.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respInstallment;
                    }
                }
            }
            catch (Exception ex)
            {
                respInstallment.IsSuccess = false;
                respInstallment.Message = ex.Message;
                _logger.LogError($"Update Installment Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respInstallment;
        }
        public async Task<Installment> IDeleteInstallmentRecordRL(Installment installment)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Installment respInstallment = new Installment();
            respInstallment.IsSuccess = true;
            respInstallment.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.DeleteInstallment, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@I_ID", installment.I_ID);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respInstallment.IsSuccess = false;
                        respInstallment.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respInstallment;
                    }
                }
            }
            catch (Exception ex)
            {
                respInstallment.IsSuccess = false;
                respInstallment.Message = ex.Message;
                _logger.LogError($"Delete Installment Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respInstallment;
        }
    }
}
