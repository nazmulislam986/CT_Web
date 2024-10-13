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
        public readonly IConfiguration _configurationMarket;
        public readonly MySqlConnection _sqlConn;
        public readonly ILogger<MarketRL> _logger;
        public MarketRL(IConfiguration configurationMarket, ILogger<MarketRL> logger)
        {
            _configurationMarket = configurationMarket;
            _logger = logger;
            _sqlConn = new MySqlConnection(_configurationMarket["ConnectionStrings:connMySql"]);
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
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.AddMarket, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
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
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetMarket, _sqlConn))
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
                                Market getData = new Market()
                                {
                                    M_ID = dataReader["M_ID"] as string,
                                    M_Date = (DateTime)(dataReader["M_Date"] as DateTime?),
                                    M_Amount = dataReader["M_Amount"] as float? ?? 0,
                                    M_Insrt_Person = dataReader["M_Insrt_Person"] as string,
                                    M_Updt_Person = dataReader["M_Updt_Person"] as string,
                                    M_Del_Person = dataReader["M_Del_Person"] as string
                                };
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
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetMarketID, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@M_ID", market.M_ID);
                    cmd.Parameters.AddWithValue("@M_Amount", market.M_Amount);
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respMarket.MarketDataList = new List<Market>();
                            if (await dataReader.ReadAsync())
                            {
                                Market getData = new Market()
                                {
                                    M_ID = dataReader["M_ID"] as string,
                                    M_Date = (DateTime)(dataReader["M_Date"] as DateTime?),
                                    M_Amount = dataReader["M_Amount"] as float? ?? 0,
                                    M_Insrt_Person = dataReader["M_Insrt_Person"] as string,
                                    M_Updt_Person = dataReader["M_Updt_Person"] as string,
                                    M_Del_Person = dataReader["M_Del_Person"] as string
                                };
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
                _logger.LogError($"Update Market ID Record Error Message : {ex.Message}");
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
                _logger.LogError($"Delete Market Record Error Message : {ex.Message}");
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
