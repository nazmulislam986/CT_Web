using CT_App.Models;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using CT_Web.Common_Utility;
using MySqlConnector;


namespace CT_Web.Repository_Layer
{
    public class DailyRL : IDailyRL
    {
        public readonly IConfiguration _configuration;
        public readonly MySqlConnection _sqlConn;
        public readonly ILogger<DailyRL> _logger;
        public DailyRL(IConfiguration configuration, ILogger<DailyRL> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _sqlConn = new MySqlConnection(_configuration["ConnectionStrings:connMySql"]);
        }

        public async Task<Daily> ICreateDailyRecordRL(Daily daily)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Daily respDaily = new Daily();
            respDaily.IsSuccess = true;
            respDaily.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.AddDailyInfo, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@D_ID ", daily.D_ID);
                    cmd.Parameters.AddWithValue("@D_Date", daily.D_Data);
                    cmd.Parameters.AddWithValue("@D_FPAmount", daily.D_FPAmount);
                    cmd.Parameters.AddWithValue("@D_SPAmount", daily.D_SPAmount);
                    cmd.Parameters.AddWithValue("@NotTaken", daily.NotTaken);
                    cmd.Parameters.AddWithValue("@D_Data", daily.D_Data);
                    cmd.Parameters.AddWithValue("@TakenDate", daily.TakenDate);
                    cmd.Parameters.AddWithValue("@D_Insrt_Person", daily.D_Insrt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respDaily.IsSuccess = false;
                        respDaily.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respDaily;
                    }
                }
            }
            catch (Exception ex)
            {
                respDaily.IsSuccess = false;
                respDaily.Message = ex.Message;
                _logger.LogError($"Insert Daily Info Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respDaily;
        }
        public async Task<Daily> IReadDailyRecordRL()
        {
            _logger.LogInformation($"Calling Repository Layer");
            Daily respDaily = new Daily();
            respDaily.IsSuccess = true;
            respDaily.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetDaily, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respDaily.DailyDataList = new List<Daily>();
                            while (await dataReader.ReadAsync())
                            {
                                Daily getData = new Daily()
                                {
                                    D_ID = dataReader["D_ID"] as string,
                                    D_Date = (DateTime)(dataReader["D_Date"] as DateTime?),
                                    D_FPAmount = dataReader["D_FPAmount"] as float? ?? 0,
                                    D_SPAmount = dataReader["D_SPAmount"] as float? ?? 0,
                                    NotTaken = dataReader["NotTaken"] as float? ?? 0,
                                    D_Data = dataReader["D_Data"] as string,
                                    TakenDate = (DateTime)(dataReader["TakenDate"] as DateTime?),
                                    D_Insrt_Person = dataReader["D_Insrt_Person"] as string,
                                    D_Updt_Person = dataReader["D_Updt_Person"] as string,
                                    D_Del_Person = dataReader["D_Del_Person"] as string
                                };
                                respDaily.DailyDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respDaily.IsSuccess = true;
                            respDaily.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respDaily.IsSuccess = false;
                respDaily.Message = ex.Message;
                _logger.LogError($"Read Daily Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respDaily;
        }
        public async Task<Daily> IReadDailyIDRecordRL(Daily daily)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Daily respDaily = new Daily();
            respDaily.IsSuccess = true;
            respDaily.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetDailyID, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@D_ID", daily.D_ID);
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respDaily.DailyDataList = new List<Daily>();
                            if (await dataReader.ReadAsync())
                            {
                                Daily getData = new Daily()
                                {
                                    D_ID = dataReader["D_ID"] as string,
                                    D_Date = (DateTime)(dataReader["D_Date"] as DateTime?),
                                    D_FPAmount = dataReader["D_FPAmount"] as float? ?? 0,
                                    D_SPAmount = dataReader["D_SPAmount"] as float? ?? 0,
                                    NotTaken = dataReader["NotTaken"] as float? ?? 0,
                                    D_Data = dataReader["D_Data"] as string,
                                    TakenDate = (DateTime)(dataReader["TakenDate"] as DateTime?),
                                    D_Insrt_Person = dataReader["D_Insrt_Person"] as string,
                                    D_Updt_Person = dataReader["D_Updt_Person"] as string,
                                    D_Del_Person = dataReader["D_Del_Person"] as string
                                };
                                respDaily.DailyDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respDaily.IsSuccess = true;
                            respDaily.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respDaily.IsSuccess = false;
                respDaily.Message = ex.Message;
                _logger.LogError($"Read Daily ID Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respDaily;
        }
        public async Task<Daily> IUpdateDailyRecordRL(Daily daily)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Daily respDaily = new Daily();
            respDaily.IsSuccess = true;
            respDaily.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.UpdateDaily, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@D_ID", daily.D_ID);
                    cmd.Parameters.AddWithValue("@D_FPAmount", daily.D_FPAmount);
                    cmd.Parameters.AddWithValue("@D_SPAmount", daily.D_SPAmount);
                    cmd.Parameters.AddWithValue("@NotTaken", daily.NotTaken);
                    cmd.Parameters.AddWithValue("@D_Updt_Person", daily.D_Updt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respDaily.IsSuccess = false;
                        respDaily.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respDaily;
                    }
                }
            }
            catch (Exception ex)
            {
                respDaily.IsSuccess = false;
                respDaily.Message = ex.Message;
                _logger.LogError($"Update Daily Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respDaily;
        }
        public async Task<Daily> IDeleteDailyRecordRL(Daily daily)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Daily respDaily = new Daily();
            respDaily.IsSuccess = true;
            respDaily.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.DeleteDaily, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@D_ID", daily.D_ID);
                    cmd.Parameters.AddWithValue("@D_Data", daily.D_Data);
                    cmd.Parameters.AddWithValue("@TakenDate", daily.TakenDate);
                    cmd.Parameters.AddWithValue("@D_Del_Person", daily.D_Del_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respDaily.IsSuccess = false;
                        respDaily.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respDaily;
                    }
                }
            }
            catch (Exception ex)
            {
                respDaily.IsSuccess = false;
                respDaily.Message = ex.Message;
                _logger.LogError($"Delete Daily Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respDaily;
        }
        public async Task<Daily> IDeleteResonDailyRecordRL(Daily daily)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Daily respDaily = new Daily();
            respDaily.IsSuccess = true;
            respDaily.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.DeleteResonDaily, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@D_ID", daily.D_ID);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respDaily.IsSuccess = false;
                        respDaily.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respDaily;
                    }
                }
            }
            catch (Exception ex)
            {
                respDaily.IsSuccess = false;
                respDaily.Message = ex.Message;
                _logger.LogError($"Delete Daily Reson Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respDaily;
        }
    }
}
