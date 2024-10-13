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
    public class DailyAntRL : IDailyAntRL
    {
        public readonly IConfiguration _configuration;
        public readonly MySqlConnection _sqlConn;
        public readonly ILogger<DailyAntRL> _logger;
        public DailyAntRL(IConfiguration configuration, ILogger<DailyAntRL> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _sqlConn = new MySqlConnection(_configuration["ConnectionStrings:connMySql"]);
        }

        public async Task<DailyAnt> ICreateDailyAntRecordRL(DailyAnt dailyAnt)
        {
            _logger.LogInformation($"Calling Repository Layer");
            DailyAnt respDailyAnt = new DailyAnt();
            respDailyAnt.IsSuccess = true;
            respDailyAnt.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.AddDailyAnt, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@DA_ID,", dailyAnt.DA_ID);
                    cmd.Parameters.AddWithValue("@DA_Date,", dailyAnt.DA_Date);
                    cmd.Parameters.AddWithValue("@DA_FPAmount,", dailyAnt.DA_FPAmount);
                    cmd.Parameters.AddWithValue("@DA_SPAmount,", dailyAnt.DA_SPAmount);
                    cmd.Parameters.AddWithValue("@NotTaken,", dailyAnt.NotTaken);
                    cmd.Parameters.AddWithValue("@DA_Data,", dailyAnt.DA_Data);
                    cmd.Parameters.AddWithValue("@DA_Insrt_Person,", dailyAnt.DA_Insrt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respDailyAnt.IsSuccess = false;
                        respDailyAnt.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respDailyAnt;
                    }
                }
            }
            catch (Exception ex)
            {
                respDailyAnt.IsSuccess = false;
                respDailyAnt.Message = ex.Message;
                _logger.LogError($"Insert DailyAnt Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respDailyAnt;
        }
        public async Task<DailyAnt> IReadDailyAntRecordRL()
        {
            _logger.LogInformation($"Calling Repository Layer");
            DailyAnt respDailyAnt = new DailyAnt();
            respDailyAnt.IsSuccess = true;
            respDailyAnt.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetDailyAnt, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respDailyAnt.DailyAntDataList = new List<DailyAnt>();
                            while (await dataReader.ReadAsync())
                            {
                                DailyAnt getData = new DailyAnt()
                                {
                                    DA_ID = dataReader["DA_ID"] as string,
                                    DA_Date = (DateTime)(dataReader["DA_Date"] as DateTime?),
                                    DA_FPAmount = dataReader["DA_FPAmount"] as float? ?? 0,
                                    DA_SPAmount = dataReader["DA_SPAmount"] as float? ?? 0,
                                    NotTaken = dataReader["NotTaken"] as float? ?? 0,
                                    DA_Data = dataReader["DA_Data"] as string,
                                    TakenDate = (DateTime)(dataReader["TakenDate"] as DateTime?),
                                    DA_Insrt_Person = dataReader["DA_Insrt_Person"] as string,
                                    DA_Updt_Person = dataReader["DA_Updt_Person"] as string,
                                    DA_Del_Person = dataReader["DA_Del_Person"] as string
                                };
                                respDailyAnt.DailyAntDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respDailyAnt.IsSuccess = true;
                            respDailyAnt.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respDailyAnt.IsSuccess = false;
                respDailyAnt.Message = ex.Message;
                _logger.LogError($"Read DailyAnt Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respDailyAnt;
        }
        public async Task<DailyAnt> IReadDailyAntIDRecordRL(DailyAnt dailyAnt)
        {
            _logger.LogInformation($"Calling Repository Layer");
            DailyAnt respDailyAnt = new DailyAnt();
            respDailyAnt.IsSuccess = true;
            respDailyAnt.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetDailyAntID, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@DA_ID", dailyAnt.DA_ID);
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respDailyAnt.DailyAntDataList = new List<DailyAnt>();
                            if (await dataReader.ReadAsync())
                            {
                                DailyAnt getData = new DailyAnt()
                                {
                                    DA_ID = dataReader["DA_ID"] as string,
                                    DA_Date = (DateTime)(dataReader["DA_Date"] as DateTime?),
                                    DA_FPAmount = dataReader["DA_FPAmount"] as float? ?? 0,
                                    DA_SPAmount = dataReader["DA_SPAmount"] as float? ?? 0,
                                    NotTaken = dataReader["NotTaken"] as float? ?? 0,
                                    DA_Data = dataReader["DA_Data"] as string,
                                    TakenDate = (DateTime)(dataReader["TakenDate"] as DateTime?),
                                    DA_Insrt_Person = dataReader["DA_Insrt_Person"] as string,
                                    DA_Updt_Person = dataReader["DA_Updt_Person"] as string,
                                    DA_Del_Person = dataReader["DA_Del_Person"] as string
                                };
                                respDailyAnt.DailyAntDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respDailyAnt.IsSuccess = true;
                            respDailyAnt.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respDailyAnt.IsSuccess = false;
                respDailyAnt.Message = ex.Message;
                _logger.LogError($"Update DailyAnt ID Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respDailyAnt;
        }
        public async Task<DailyAnt> IUpdateDailyAntRecordRL(DailyAnt dailyAnt)
        {
            _logger.LogInformation($"Calling Repository Layer");
            DailyAnt respDailyAnt = new DailyAnt();
            respDailyAnt.IsSuccess = true;
            respDailyAnt.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.UpdateDailyAnt, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@DA_ID", dailyAnt.DA_ID);
                    cmd.Parameters.AddWithValue("@DA_FPAmount", dailyAnt.DA_FPAmount);
                    cmd.Parameters.AddWithValue("@DA_SPAmount", dailyAnt.DA_SPAmount);
                    cmd.Parameters.AddWithValue("@NotTaken", dailyAnt.NotTaken);
                    cmd.Parameters.AddWithValue("@DA_Updt_Person", dailyAnt.DA_Updt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respDailyAnt.IsSuccess = false;
                        respDailyAnt.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respDailyAnt;
                    }
                }
            }
            catch (Exception ex)
            {
                respDailyAnt.IsSuccess = false;
                respDailyAnt.Message = ex.Message;
                _logger.LogError($"Update DailyAnt Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respDailyAnt;
        }
        public async Task<DailyAnt> IDeleteDailyAntRecordRL(DailyAnt dailyAnt)
        {
            _logger.LogInformation($"Calling Repository Layer");
            DailyAnt respDailyAnt = new DailyAnt();
            respDailyAnt.IsSuccess = true;
            respDailyAnt.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.DeleteDailyAnt, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@DA_ID", dailyAnt.DA_ID);
                    cmd.Parameters.AddWithValue("@DA_Data", dailyAnt.DA_Data);
                    cmd.Parameters.AddWithValue("@TakenDate", dailyAnt.TakenDate);
                    cmd.Parameters.AddWithValue("@DA_Del_Person", dailyAnt.DA_Del_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respDailyAnt.IsSuccess = false;
                        respDailyAnt.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respDailyAnt;
                    }
                }
            }
            catch (Exception ex)
            {
                respDailyAnt.IsSuccess = false;
                respDailyAnt.Message = ex.Message;
                _logger.LogError($"Delete DailyAnt Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respDailyAnt;
        }
        public async Task<DailyAnt> IDeleteResonDailyAntRecordRL(DailyAnt dailyAnt)
        {
            _logger.LogInformation($"Calling Repository Layer");
            DailyAnt respDailyAnt = new DailyAnt();
            respDailyAnt.IsSuccess = true;
            respDailyAnt.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.DeleteResonDailyAnt, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@DA_ID", dailyAnt.DA_ID);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respDailyAnt.IsSuccess = false;
                        respDailyAnt.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respDailyAnt;
                    }
                }
            }
            catch (Exception ex)
            {
                respDailyAnt.IsSuccess = false;
                respDailyAnt.Message = ex.Message;
                _logger.LogError($"Delete Reson DailyAnt Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respDailyAnt;
        }
    }
}
