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
    public class MarketRL : IMarketRL
    {
        public readonly IConfiguration _configuration;
        public readonly MySqlConnection _sqlConn;
        public readonly ILogger<MarketRL> _logger;
        public MarketRL(IConfiguration configuration, ILogger<MarketRL> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _sqlConn = new MySqlConnection(_configuration["ConnectionStrings:connMySql"]);
        }
        public async Task<Market> ICreateMarketRecordRL(Market market)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Market respMarket = new Market();
            respMarket.IsSuccess = true;
            respMarket.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.AddMarket, _sqlConn)) //SqlQueries.AddMarket, _sqlConn || "sp_marketSync", _sqlConn
                {
                    cmd.CommandType = System.Data.CommandType.Text; //System.Data.CommandType.Text || System.Data.CommandType.StoredProcedure
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@M_ID", market.M_ID);
                    cmd.Parameters.AddWithValue("@M_Date", market.M_Date);
                    cmd.Parameters.AddWithValue("@M_Amount", market.M_Amount);
                    cmd.Parameters.AddWithValue("@M_Insrt_Person", market.M_Insrt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respMarket.IsSuccess = false;
                        respMarket.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respMarket;
                    }
                }
            }
            catch (Exception ex)
            {
                respMarket.IsSuccess = false;
                respMarket.Message = ex.Message;
                _logger.LogError($"Insert Market Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respMarket;
        }
        public async Task<Market> IReadMarketRecordRL()
        {
            _logger.LogInformation($"Calling Repository Layer");
            Market respMarket = new Market();
            respMarket.IsSuccess = true;
            respMarket.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.ReadMarket, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respMarket.MarketDataList = new List<Market>();
                            while (await dataReader.ReadAsync())
                            {
                                Market getData = new Market();
                                getData.M_ID = (string)(dataReader["M_ID"] != DBNull.Value ? dataReader["M_ID"] : null);
                                getData.M_Date = (DateTime)(dataReader["M_Date"] != DBNull.Value ? Convert.ToDateTime(dataReader["M_Date"]) : (DateTime?)null);
                                getData.M_Amount = (float)(dataReader["M_Amount"] != DBNull.Value ? dataReader["M_Amount"] : 0);
                                getData.M_Insrt_Person = (string)(dataReader["M_Insrt_Person"] != DBNull.Value ? dataReader["M_Insrt_Person"] : null);
                                getData.M_Updt_Person = (string)(dataReader["M_Updt_Person"] != DBNull.Value ? dataReader["M_Updt_Person"] : null);
                                getData.M_Del_Person = (string)(dataReader["M_Del_Person"] != DBNull.Value ? dataReader["M_Del_Person"] : null);
                                respMarket.MarketDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respMarket.IsSuccess = true;
                            respMarket.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respMarket.IsSuccess = false;
                respMarket.Message = ex.Message;
                _logger.LogError($"Read Market Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respMarket;
        }
        public async Task<Market> IReadMarketIDRecordRL(Market market)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Market respMarket = new Market();
            respMarket.IsSuccess = true;
            respMarket.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.ReadMarketID, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respMarket.MarketDataList = new List<Market>();
                            while (await dataReader.ReadAsync())
                            {
                                Market getData = new Market();
                                getData.M_ID = (string)(dataReader["M_ID"] != DBNull.Value ? dataReader["M_ID"] : null);
                                getData.M_Date = (DateTime)(dataReader["M_Date"] != DBNull.Value ? Convert.ToDateTime(dataReader["M_Date"]) : (DateTime?)null);
                                getData.M_Amount = (float)(dataReader["M_Amount"] != DBNull.Value ? dataReader["M_Amount"] : 0);
                                getData.M_Insrt_Person = (string)(dataReader["M_Insrt_Person"] != DBNull.Value ? dataReader["M_Insrt_Person"] : null);
                                getData.M_Updt_Person = (string)(dataReader["M_Updt_Person"] != DBNull.Value ? dataReader["M_Updt_Person"] : null);
                                getData.M_Del_Person = (string)(dataReader["M_Del_Person"] != DBNull.Value ? dataReader["M_Del_Person"] : null);
                                respMarket.MarketDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respMarket.IsSuccess = true;
                            respMarket.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respMarket.IsSuccess = false;
                respMarket.Message = ex.Message;
                _logger.LogError($"Update Market Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respMarket;
        }
        public async Task<Market> IUpdateMarketRecordRL(Market market)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Market respMarket = new Market();
            respMarket.IsSuccess = true;
            respMarket.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.UpdateMarket, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@M_ID", market.M_ID);
                    cmd.Parameters.AddWithValue("@M_Amount", market.M_Amount);
                    cmd.Parameters.AddWithValue("@M_Updt_Person", market.M_Updt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respMarket.IsSuccess = false;
                        respMarket.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respMarket;
                    }
                }
            }
            catch (Exception ex)
            {
                respMarket.IsSuccess = false;
                respMarket.Message = ex.Message;
                _logger.LogError($"Update Market Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respMarket;
        }
        public async Task<Market> IDeleteMarketRecordRL(Market market)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Market respMarket = new Market();
            respMarket.IsSuccess = true;
            respMarket.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.DeleteMarket, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@M_ID", market.M_ID);
                    cmd.Parameters.AddWithValue("@M_Amount", market.M_Amount);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respMarket.IsSuccess = false;
                        respMarket.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respMarket;
                    }
                }
            }
            catch (Exception ex)
            {
                respMarket.IsSuccess = false;
                respMarket.Message = ex.Message;
                _logger.LogError($"Update Market Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respMarket;
        }
    }
}
