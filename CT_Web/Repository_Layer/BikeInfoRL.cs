using CT_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_Web.Common_Utility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySqlConnector;

namespace CT_Web.Repository_Layer
{
    public class BikeInfoRL : IBikeInfoRL
    {
        public readonly IConfiguration _configuration;
        public readonly MySqlConnection _sqlConn;
        public readonly ILogger<BikeInfoRL> _logger;
        public BikeInfoRL(IConfiguration configuration, ILogger<BikeInfoRL> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _sqlConn = new MySqlConnection(_configuration["ConnectionStrings:connMySql"]);
        }

        public async Task<BikeInfo> ICreateBikeInfoRecordRL(BikeInfo bikeinfo)
        {
            _logger.LogInformation($"Calling Repository Layer");
            BikeInfo respBike = new BikeInfo();
            respBike.IsSuccess = true;
            respBike.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.AddBike, _sqlConn)) //SqlQueries.AddMarket, _sqlConn || "sp_marketSync", _sqlConn
                {
                    cmd.CommandType = System.Data.CommandType.Text; //System.Data.CommandType.Text || System.Data.CommandType.StoredProcedure
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@B_ID", bikeinfo.B_ID);
                    cmd.Parameters.AddWithValue("@B_Chng_Date", bikeinfo.B_Chng_Date);
                    cmd.Parameters.AddWithValue("@B_KM_ODO", bikeinfo.B_KM_ODO);
                    cmd.Parameters.AddWithValue("@B_Mobile_Go", bikeinfo.B_Mobile_Go);
                    cmd.Parameters.AddWithValue("@B_Next_ODO", bikeinfo.B_Next_ODO);
                    cmd.Parameters.AddWithValue("@B_Insrt_Person", bikeinfo.B_Insrt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respBike.IsSuccess = false;
                        respBike.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respBike;
                    }
                }
            }
            catch (Exception ex)
            {
                respBike.IsSuccess = false;
                respBike.Message = ex.Message;
                _logger.LogError($"Insert Bike Info Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respBike;
        }
        public async Task<BikeInfo> IReadBikeInfoRecordRL()
        {
            _logger.LogInformation($"Calling Repository Layer");
            BikeInfo respBike = new BikeInfo();
            respBike.IsSuccess = true;
            respBike.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.ReadBike, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respBike.BikeInfoList = new List<BikeInfo>();
                            while (await dataReader.ReadAsync())
                            {
                                BikeInfo getData = new BikeInfo()
                                {
                                    B_ID = dataReader["B_ID"] as string,
                                    B_Chng_Date = (DateTime)(dataReader["B_Chng_Date"] as DateTime?),
                                    B_KM_ODO = dataReader["B_KM_ODO"] as float? ?? 0,
                                    B_Mobile_Go = dataReader["B_Mobile_Go"] as float? ?? 0,
                                    B_Next_ODO = dataReader["B_Next_ODO"] as float? ?? 0,
                                    B_Insrt_Person = dataReader["B_Insrt_Person"] as string,
                                    B_Updt_Person = dataReader["B_Updt_Person"] as string
                                };
                                respBike.BikeInfoList.Add(getData);
                            }
                        }
                        else
                        {
                            respBike.IsSuccess = true;
                            respBike.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respBike.IsSuccess = false;
                respBike.Message = ex.Message;
                _logger.LogError($"Read Bike Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respBike;
        }
        public async Task<BikeInfo> IReadBikeInfoIDRecordRL(BikeInfo bikeinfo)
        {
            _logger.LogInformation($"Calling Repository Layer");
            BikeInfo respBike = new BikeInfo();
            respBike.IsSuccess = true;
            respBike.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.ReadBikeID, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@B_ID", bikeinfo.B_ID);
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respBike.BikeInfoList = new List<BikeInfo>();
                            if (await dataReader.ReadAsync())
                            {
                                BikeInfo getData = new BikeInfo()
                                {
                                    B_ID = dataReader["B_ID"] as string,
                                    B_Chng_Date = (DateTime)(dataReader["B_Chng_Date"] as DateTime?),
                                    B_KM_ODO = dataReader["B_KM_ODO"] as float? ?? 0,
                                    B_Mobile_Go = dataReader["B_Mobile_Go"] as float? ?? 0,
                                    B_Next_ODO = dataReader["B_Next_ODO"] as float? ?? 0,
                                    B_Insrt_Person = dataReader["B_Insrt_Person"] as string,
                                    B_Updt_Person = dataReader["B_Updt_Person"] as string
                                };
                                respBike.BikeInfoList.Add(getData);
                            }
                        }
                        else
                        {
                            respBike.IsSuccess = true;
                            respBike.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respBike.IsSuccess = false;
                respBike.Message = ex.Message;
                _logger.LogError($"Read Bike ID Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respBike;
        }
        public async Task<BikeInfo> IUpdateBikeInfoRecordRL(BikeInfo bikeinfo)
        {
            _logger.LogInformation($"Calling Repository Layer");
            BikeInfo respBike = new BikeInfo();
            respBike.IsSuccess = true;
            respBike.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.UpdateBike, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@B_ID", bikeinfo.B_ID);
                    cmd.Parameters.AddWithValue("@B_KM_ODO", bikeinfo.B_KM_ODO);
                    cmd.Parameters.AddWithValue("@B_Mobile_Go", bikeinfo.B_Mobile_Go);
                    cmd.Parameters.AddWithValue("@B_Next_ODO", bikeinfo.B_Next_ODO);
                    cmd.Parameters.AddWithValue("@B_Updt_Person", bikeinfo.B_Updt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respBike.IsSuccess = false;
                        respBike.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respBike;
                    }
                }
            }
            catch (Exception ex)
            {
                respBike.IsSuccess = false;
                respBike.Message = ex.Message;
                _logger.LogError($"Update BIke Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respBike;
        }
        public async Task<BikeInfo> IDeleteBikeInfoRecordRL(BikeInfo bikeinfo)
        {
            _logger.LogInformation($"Calling Repository Layer");
            BikeInfo respBike = new BikeInfo();
            respBike.IsSuccess = true;
            respBike.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.DeleteBike, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@B_ID", bikeinfo.B_ID);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respBike.IsSuccess = false;
                        respBike.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respBike;
                    }
                }
            }
            catch (Exception ex)
            {
                respBike.IsSuccess = false;
                respBike.Message = ex.Message;
                _logger.LogError($"Delete Bike Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respBike;
        }
    }
}
