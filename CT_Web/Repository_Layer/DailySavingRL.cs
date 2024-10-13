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
    public class DailySavingRL : IDailySavingRL
    {
        public readonly IConfiguration _configurationDailySaving;
        public readonly MySqlConnection _sqlConn;
        public readonly ILogger<DailySavingRL> _logger;
        public DailySavingRL(IConfiguration configurationDailySaving, ILogger<DailySavingRL> logger)
        {
            _configurationDailySaving = configurationDailySaving;
            _logger = logger;
            _sqlConn = new MySqlConnection(_configurationDailySaving["ConnectionStrings:connMySql"]);
        }

        public async Task<DailySaving> ICreateDailySavingRecordRL(DailySaving dailySaving)
        {
            _logger.LogInformation($"Calling Repository Layer");
            DailySaving respDailySaving = new DailySaving();
            respDailySaving.IsSuccess = true;
            respDailySaving.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.AddDailySaving, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@DS_ID", dailySaving.DS_ID);
                    cmd.Parameters.AddWithValue("@DS_Date", dailySaving.DS_Date);
                    cmd.Parameters.AddWithValue("@DS_FPAmount", dailySaving.DS_FPAmount);
                    cmd.Parameters.AddWithValue("@DS_SPAmount", dailySaving.DS_SPAmount);
                    cmd.Parameters.AddWithValue("@DS_TPAmount", dailySaving.DS_TPAmount);
                    cmd.Parameters.AddWithValue("@NotTaken", dailySaving.NotTaken);
                    cmd.Parameters.AddWithValue("@DS_Data", dailySaving.DS_Data);
                    cmd.Parameters.AddWithValue("@DS_Insrt_Person", dailySaving.DS_Insrt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respDailySaving.IsSuccess = false;
                        respDailySaving.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respDailySaving;
                    }
                }
            }
            catch (Exception ex)
            {
                respDailySaving.IsSuccess = false;
                respDailySaving.Message = ex.Message;
                _logger.LogError($"Insert DailySaving Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respDailySaving;
        }
        public async Task<DailySaving> IReadDailySavingRecordRL()
        {
            _logger.LogInformation($"Calling Repository Layer");
            DailySaving respDailySaving = new DailySaving();
            respDailySaving.IsSuccess = true;
            respDailySaving.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetDailySaving, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respDailySaving.DailySavingDataList = new List<DailySaving>();
                            while (await dataReader.ReadAsync())
                            {
                                DailySaving getData = new DailySaving()
                                {
                                    DS_ID = dataReader["DS_ID"] as string,
                                    DS_Date = (DateTime)(dataReader["DS_Date"] as DateTime?),
                                    DS_FPAmount = dataReader["DS_FPAmount"] as float? ?? 0,
                                    DS_SPAmount = dataReader["DS_SPAmount"] as float? ?? 0,
                                    DS_TPAmount = dataReader["DS_TPAmount"] as float? ?? 0,
                                    NotTaken = dataReader["NotTaken"] as float? ?? 0,
                                    DS_Data = dataReader["DS_Data"] as string,
                                    DS_InBankDate = (DateTime)(dataReader["DS_InBankDate"] as DateTime?),
                                    DS_Insrt_Person = dataReader["DS_Insrt_Person"] as string,
                                    DS_Updt_Person = dataReader["DS_Updt_Person"] as string,
                                    DS_Del_Person = dataReader["DS_Del_Person"] as string
                                };
                                respDailySaving.DailySavingDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respDailySaving.IsSuccess = true;
                            respDailySaving.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respDailySaving.IsSuccess = false;
                respDailySaving.Message = ex.Message;
                _logger.LogError($"Read DailySaving Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respDailySaving;
        }
        public async Task<DailySaving> IReadDailySavingIDRecordRL(DailySaving dailySaving)
        {
            _logger.LogInformation($"Calling Repository Layer");
            DailySaving respDailySaving = new DailySaving();
            respDailySaving.IsSuccess = true;
            respDailySaving.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetDailySavingID, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@DS_ID", dailySaving.DS_ID);
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respDailySaving.DailySavingDataList = new List<DailySaving>();
                            if (await dataReader.ReadAsync())
                            {
                                DailySaving getData = new DailySaving()
                                {
                                    DS_ID = dataReader["DS_ID"] as string,
                                    DS_Date = (DateTime)(dataReader["DS_Date"] as DateTime?),
                                    DS_FPAmount = dataReader["DS_FPAmount"] as float? ?? 0,
                                    DS_SPAmount = dataReader["DS_SPAmount"] as float? ?? 0,
                                    DS_TPAmount = dataReader["DS_TPAmount"] as float? ?? 0,
                                    NotTaken = dataReader["NotTaken"] as float? ?? 0,
                                    DS_Data = dataReader["DS_Data"] as string,
                                    DS_InBankDate = (DateTime)(dataReader["DS_InBankDate"] as DateTime?),
                                    DS_Insrt_Person = dataReader["DS_Insrt_Person"] as string,
                                    DS_Updt_Person = dataReader["DS_Updt_Person"] as string,
                                    DS_Del_Person = dataReader["DS_Del_Person"] as string
                                };
                                respDailySaving.DailySavingDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respDailySaving.IsSuccess = true;
                            respDailySaving.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respDailySaving.IsSuccess = false;
                respDailySaving.Message = ex.Message;
                _logger.LogError($"Update DailySaving ID Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respDailySaving;
        }
        public async Task<DailySaving> IUpdateDailySavingRecordRL(DailySaving dailySaving)
        {
            _logger.LogInformation($"Calling Repository Layer");
            DailySaving respDailySaving = new DailySaving();
            respDailySaving.IsSuccess = true;
            respDailySaving.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.UpdateDailySaving, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@DS_ID", dailySaving.DS_ID);
                    cmd.Parameters.AddWithValue("@DS_FPAmount", dailySaving.DS_FPAmount);
                    cmd.Parameters.AddWithValue("@DS_SPAmount", dailySaving.DS_SPAmount);
                    cmd.Parameters.AddWithValue("@DS_TPAmount", dailySaving.DS_TPAmount);
                    cmd.Parameters.AddWithValue("@NotTaken", dailySaving.NotTaken);
                    cmd.Parameters.AddWithValue("@DS_Updt_Person", dailySaving.DS_Updt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respDailySaving.IsSuccess = false;
                        respDailySaving.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respDailySaving;
                    }
                }
            }
            catch (Exception ex)
            {
                respDailySaving.IsSuccess = false;
                respDailySaving.Message = ex.Message;
                _logger.LogError($"Update DailySaving Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respDailySaving;
        }
        public async Task<DailySaving> IDeleteDailySavingRecordRL(DailySaving dailySaving)
        {
            _logger.LogInformation($"Calling Repository Layer");
            DailySaving respDailySaving = new DailySaving();
            respDailySaving.IsSuccess = true;
            respDailySaving.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.DeleteDailySaving, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@DS_ID", dailySaving.DS_ID);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respDailySaving.IsSuccess = false;
                        respDailySaving.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respDailySaving;
                    }
                }
            }
            catch (Exception ex)
            {
                respDailySaving.IsSuccess = false;
                respDailySaving.Message = ex.Message;
                _logger.LogError($"Delete DailySaving Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respDailySaving;
        }
        public async Task<DailySaving> IDeleteResonDailySavingRecordRL(DailySaving dailySaving)
        {
            _logger.LogInformation($"Calling Repository Layer");
            DailySaving respDailySaving = new DailySaving();
            respDailySaving.IsSuccess = true;
            respDailySaving.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.DeleteResonDailySaving, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@DS_ID", dailySaving.DS_ID);
                    cmd.Parameters.AddWithValue("@DS_Data", dailySaving.DS_Data);
                    cmd.Parameters.AddWithValue("@DS_InBankDate", dailySaving.DS_InBankDate);
                    cmd.Parameters.AddWithValue("@DS_Del_Person", dailySaving.DS_Del_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respDailySaving.IsSuccess = false;
                        respDailySaving.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respDailySaving;
                    }
                }
            }
            catch (Exception ex)
            {
                respDailySaving.IsSuccess = false;
                respDailySaving.Message = ex.Message;
                _logger.LogError($"Delete Reson DailySaving Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respDailySaving;
        }
    }
}
