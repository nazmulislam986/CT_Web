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
    public class TekenRL : ITekenRL
    {
        public readonly IConfiguration _configuration;
        public readonly MySqlConnection _sqlConn;
        public readonly ILogger<TekenRL> _logger;
        public TekenRL(IConfiguration configuration, ILogger<TekenRL> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _sqlConn = new MySqlConnection(_configuration["ConnectionStrings:connMySql"]);
        }

        public async Task<Teken> ICreateTekenRecordRL(Teken teken)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Teken respTeken = new Teken();
            respTeken.IsSuccess = true;
            respTeken.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.AddTeken, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@InTake", teken.InTake);
                    cmd.Parameters.AddWithValue("@Total_Take", teken.Total_Take);
                    cmd.Parameters.AddWithValue("@Take_To", teken.Take_To);
                    cmd.Parameters.AddWithValue("@ThroughBy_Take", teken.ThroughBy_Take);
                    cmd.Parameters.AddWithValue("@Take_Date", teken.Take_Date);
                    cmd.Parameters.AddWithValue("@Remarks_Take", teken.Remarks_Take);
                    cmd.Parameters.AddWithValue("@TDT_V", teken.TDT_V);
                    cmd.Parameters.AddWithValue("@T_Insrt_Person", teken.T_Insrt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respTeken.IsSuccess = false;
                        respTeken.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respTeken;
                    }
                }
            }
            catch (Exception ex)
            {
                respTeken.IsSuccess = false;
                respTeken.Message = ex.Message;
                _logger.LogError($"Insert Teken Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respTeken;
        }
        public async Task<Teken> IReadTekenRecordRL()
        {
            _logger.LogInformation($"Calling Repository Layer");
            Teken respTeken = new Teken();
            respTeken.IsSuccess = true;
            respTeken.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetTeken, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respTeken.TekenDataList = new List<Teken>();
                            while (await dataReader.ReadAsync())
                            {
                                Teken getData = new Teken()
                                {
                                    InTake = dataReader["InTake"] as string,
                                    Total_Take = dataReader["Total_Take"] as float? ?? 0,
                                    Take_To = dataReader["Take_To"] as string,
                                    ThroughBy_Take = dataReader["ThroughBy_Take"] as string,
                                    Take_Date = (DateTime)(dataReader["Take_Date"] as DateTime?),
                                    Remarks_Take = dataReader["Remarks_Take"] as string,
                                    TDT_V = dataReader["TDT_V"] as string,
                                    TDT_V_Date = (DateTime)(dataReader[""] as DateTime?),
                                    DDT_V_Date = (DateTime)(dataReader[""] as DateTime?),
                                    T_Insrt_Person = dataReader["T_Insrt_Person"] as string,
                                    T_Updt_Person = dataReader["T_Updt_Person"] as string,
                                    T_Del_Person = dataReader["T_Del_Person"] as string
                                };
                                respTeken.TekenDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respTeken.IsSuccess = true;
                            respTeken.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respTeken.IsSuccess = false;
                respTeken.Message = ex.Message;
                _logger.LogError($"Read Teken Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respTeken;
        }
        public async Task<Teken> IReadTekenIDRecordRL(Teken teken)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Teken respTeken = new Teken();
            respTeken.IsSuccess = true;
            respTeken.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetTekenID, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@InTake", teken.InTake);
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respTeken.TekenDataList = new List<Teken>();
                            if (await dataReader.ReadAsync())
                            {
                                Teken getData = new Teken()
                                {
                                    InTake = dataReader["InTake"] as string,
                                    Total_Take = dataReader["Total_Take"] as float? ?? 0,
                                    Take_To = dataReader["Take_To"] as string,
                                    ThroughBy_Take = dataReader["ThroughBy_Take"] as string,
                                    Take_Date = (DateTime)(dataReader["Take_Date"] as DateTime?),
                                    Remarks_Take = dataReader["Remarks_Take"] as string,
                                    TDT_V = dataReader["TDT_V"] as string,
                                    TDT_V_Date = (DateTime)(dataReader[""] as DateTime?),
                                    DDT_V_Date = (DateTime)(dataReader[""] as DateTime?),
                                    T_Insrt_Person = dataReader["T_Insrt_Person"] as string,
                                    T_Updt_Person = dataReader["T_Updt_Person"] as string,
                                    T_Del_Person = dataReader["T_Del_Person"] as string
                                };
                                respTeken.TekenDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respTeken.IsSuccess = true;
                            respTeken.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respTeken.IsSuccess = false;
                respTeken.Message = ex.Message;
                _logger.LogError($"Read Teken ID Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respTeken;
        }
        public async Task<Teken> IUpdateTekenRecordRL(Teken teken)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Teken respTeken = new Teken();
            respTeken.IsSuccess = true;
            respTeken.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.UpdateTeken, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@InTake", teken.InTake);
                    cmd.Parameters.AddWithValue("@Total_Take", teken.Total_Take);
                    cmd.Parameters.AddWithValue("@Take_To", teken.Take_To);
                    cmd.Parameters.AddWithValue("@ThroughBy_Take", teken.ThroughBy_Take);
                    cmd.Parameters.AddWithValue("@Take_Date", teken.Take_Date);
                    cmd.Parameters.AddWithValue("@Remarks_Take", teken.Remarks_Take);
                    cmd.Parameters.AddWithValue("@TDT_V_Date", teken.TDT_V_Date);
                    cmd.Parameters.AddWithValue("@T_Updt_Person", teken.T_Updt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respTeken.IsSuccess = false;
                        respTeken.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respTeken;
                    }
                }
            }
            catch (Exception ex)
            {
                respTeken.IsSuccess = false;
                respTeken.Message = ex.Message;
                _logger.LogError($"Update Teken Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respTeken;
        }
        public async Task<Teken> IDeleteTekenRecordRL(Teken teken)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Teken respTeken = new Teken();
            respTeken.IsSuccess = true;
            respTeken.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.DeleteTeken, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@InTake", teken.InTake);
                    cmd.Parameters.AddWithValue("@TDT_V", teken.TDT_V);
                    cmd.Parameters.AddWithValue("@DDT_V_Date", teken.DDT_V_Date);
                    cmd.Parameters.AddWithValue("@T_Del_Person", teken.T_Del_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respTeken.IsSuccess = false;
                        respTeken.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respTeken;
                    }
                }
            }
            catch (Exception ex)
            {
                respTeken.IsSuccess = false;
                respTeken.Message = ex.Message;
                _logger.LogError($"Delete Teken Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respTeken;
        }
    }
}
