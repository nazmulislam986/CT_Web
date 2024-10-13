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
    public class DailyCutRL : IDailyCutRL
    {
        public readonly IConfiguration _configuration;
        public readonly MySqlConnection _sqlConn;
        public readonly ILogger<DailyCutRL> _logger;
        public DailyCutRL(IConfiguration configuration, ILogger<DailyCutRL> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _sqlConn = new MySqlConnection(_configuration["ConnectionStrings:connMySql"]);
        }

        public async Task<DailyCut> ICreateDailyCutRecordRL(DailyCut dailyCut)
        {
            _logger.LogInformation($"Calling Repository Layer");
            DailyCut respDailyCut = new DailyCut();
            respDailyCut.IsSuccess = true;
            respDailyCut.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.AddDailyCut, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@C_ID", dailyCut.C_ID);
                    cmd.Parameters.AddWithValue("@C_Date", dailyCut.C_Date);
                    cmd.Parameters.AddWithValue("@C_Amount", dailyCut.C_Amount);
                    cmd.Parameters.AddWithValue("@C_Insrt_Person", dailyCut.C_Insrt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respDailyCut.IsSuccess = false;
                        respDailyCut.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respDailyCut;
                    }
                }
            }
            catch (Exception ex)
            {
                respDailyCut.IsSuccess = false;
                respDailyCut.Message = ex.Message;
                _logger.LogError($"Insert DailyCut Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respDailyCut;
        }
        public async Task<DailyCut> IReadDailyCutRecordRL()
        {
            _logger.LogInformation($"Calling Repository Layer");
            DailyCut respDailyCut = new DailyCut();
            respDailyCut.IsSuccess = true;
            respDailyCut.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetDailyCut, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respDailyCut.DailyCutDataList = new List<DailyCut>();
                            while (await dataReader.ReadAsync())
                            {
                                DailyCut getData = new DailyCut()
                                {
                                    C_ID = dataReader["C_ID"] as string,
                                    C_Date = (DateTime)(dataReader["C_Date"] as DateTime?),
                                    C_Amount = dataReader["C_Amount"] as float? ?? 0,
                                    C_Insrt_Person = dataReader["C_Insrt_Person"] as string,
                                    C_Updt_Person = dataReader["C_Updt_Person"] as string,
                                    C_Del_Person = dataReader["C_Del_Person"] as string
                                };
                                respDailyCut.DailyCutDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respDailyCut.IsSuccess = true;
                            respDailyCut.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respDailyCut.IsSuccess = false;
                respDailyCut.Message = ex.Message;
                _logger.LogError($"Read DailyCut Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respDailyCut;
        }
        public async Task<DailyCut> IReadDailyCutIDRecordRL(DailyCut dailyCut)
        {
            _logger.LogInformation($"Calling Repository Layer");
            DailyCut respDailyCut = new DailyCut();
            respDailyCut.IsSuccess = true;
            respDailyCut.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetDailyCutID, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@C_ID", dailyCut.C_ID);
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respDailyCut.DailyCutDataList = new List<DailyCut>();
                            if (await dataReader.ReadAsync())
                            {
                                DailyCut getData = new DailyCut()
                                {
                                    C_ID = dataReader["C_ID"] as string,
                                    C_Date = (DateTime)(dataReader["C_Date"] as DateTime?),
                                    C_Amount = dataReader["C_Amount"] as float? ?? 0,
                                    C_Insrt_Person = dataReader["C_Insrt_Person"] as string,
                                    C_Updt_Person = dataReader["C_Updt_Person"] as string,
                                    C_Del_Person = dataReader["C_Del_Person"] as string
                                };
                                respDailyCut.DailyCutDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respDailyCut.IsSuccess = true;
                            respDailyCut.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respDailyCut.IsSuccess = false;
                respDailyCut.Message = ex.Message;
                _logger.LogError($"Update DailyCut ID Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respDailyCut;
        }
        public async Task<DailyCut> IUpdateDailyCutRecordRL(DailyCut dailyCut)
        {
            _logger.LogInformation($"Calling Repository Layer");
            DailyCut respDailyCut = new DailyCut();
            respDailyCut.IsSuccess = true;
            respDailyCut.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.UpdateDailyCut, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@C_ID", dailyCut.C_ID);
                    cmd.Parameters.AddWithValue("@C_Amount", dailyCut.C_Amount);
                    cmd.Parameters.AddWithValue("@C_Updt_Person", dailyCut.C_Updt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respDailyCut.IsSuccess = false;
                        respDailyCut.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respDailyCut;
                    }
                }
            }
            catch (Exception ex)
            {
                respDailyCut.IsSuccess = false;
                respDailyCut.Message = ex.Message;
                _logger.LogError($"Update DailyCut Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respDailyCut;
        }
        public async Task<DailyCut> IDeleteDailyCutRecordRL(DailyCut dailyCut)
        {
            _logger.LogInformation($"Calling Repository Layer");
            DailyCut respDailyCut = new DailyCut();
            respDailyCut.IsSuccess = true;
            respDailyCut.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.DeleteDailyCut, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@C_ID", dailyCut.C_ID);
                    cmd.Parameters.AddWithValue("@C_Amount", dailyCut.C_Amount);
                    cmd.Parameters.AddWithValue("@C_Del_Person", dailyCut.C_Del_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respDailyCut.IsSuccess = false;
                        respDailyCut.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respDailyCut;
                    }
                }
            }
            catch (Exception ex)
            {
                respDailyCut.IsSuccess = false;
                respDailyCut.Message = ex.Message;
                _logger.LogError($"Delete DailyCut Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respDailyCut;
        }
    }
}
