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
    public class UnratedRL : IUnratedRL
    {
        public readonly IConfiguration _configuration;
        public readonly MySqlConnection _sqlConn;
        public readonly ILogger<UnratedRL> _logger;
        public UnratedRL(IConfiguration configuration, ILogger<UnratedRL> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _sqlConn = new MySqlConnection(_configuration["ConnectionStrings:connMySql"]);
        }

        public async Task<Unrated> ICreateUnratedRecordRL(Unrated unrated)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Unrated respUnrated = new Unrated();
            respUnrated.IsSuccess = true;
            respUnrated.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.AddUnrated, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@InUnrated", unrated.InUnrated);
                    cmd.Parameters.AddWithValue("@Unrated_Amount", unrated.Unrated_Amount);
                    cmd.Parameters.AddWithValue("@Unrated_To", unrated.Unrated_To);
                    cmd.Parameters.AddWithValue("@ThroughBy_Unrated", unrated.ThroughBy_Unrated);
                    cmd.Parameters.AddWithValue("@Unrated_Date", unrated.Unrated_Date);
                    cmd.Parameters.AddWithValue("@Remarks_Unrated", unrated.Remarks_Unrated);
                    cmd.Parameters.AddWithValue("@UDT_V", unrated.UDT_V);
                    cmd.Parameters.AddWithValue("@U_Insrt_Person", unrated.U_Insrt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respUnrated.IsSuccess = false;
                        respUnrated.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respUnrated;
                    }
                }
            }
            catch (Exception ex)
            {
                respUnrated.IsSuccess = false;
                respUnrated.Message = ex.Message;
                _logger.LogError($"Insert Unrated Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respUnrated;
        }
        public async Task<Unrated> IReadUnratedRecordRL()
        {
            _logger.LogInformation($"Calling Repository Layer");
            Unrated respUnrated = new Unrated();
            respUnrated.IsSuccess = true;
            respUnrated.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetUnrated, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respUnrated.UnratedDataList = new List<Unrated>();
                            while (await dataReader.ReadAsync())
                            {
                                Unrated getData = new Unrated()
                                {
                                    InUnrated = dataReader["InUnrated"] as string,
                                    Unrated_Amount = dataReader["Unrated_Amount"] as float? ?? 0,
                                    Unrated_To = dataReader["Unrated_To"] as string,
                                    ThroughBy_Unrated = dataReader["ThroughBy_Unrated"] as string,
                                    Unrated_Date = (DateTime)(dataReader["Unrated_Date"] as DateTime?),
                                    Remarks_Unrated = dataReader["Remarks_Unrated"] as string,
                                    UDT_V = dataReader["UDT_V"] as string,
                                    UDT_V_Date = (DateTime)(dataReader["UDT_V_Date"] as DateTime?),
                                    DDT_V_Date = (DateTime)(dataReader["DDT_V_Date"] as DateTime?),
                                    U_Insrt_Person = dataReader["U_Insrt_Person"] as string,
                                    U_Updt_Person = dataReader["U_Updt_Person"] as string,
                                    U_Del_Person = dataReader["U_Del_Person"] as string
                                };
                                respUnrated.UnratedDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respUnrated.IsSuccess = true;
                            respUnrated.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respUnrated.IsSuccess = false;
                respUnrated.Message = ex.Message;
                _logger.LogError($"Read Unrated Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respUnrated;
        }
        public async Task<Unrated> IReadUnratedIDRecordRL(Unrated unrated)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Unrated respUnrated = new Unrated();
            respUnrated.IsSuccess = true;
            respUnrated.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetUnratedID, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@InUnrated", unrated.InUnrated);
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respUnrated.UnratedDataList = new List<Unrated>();
                            if (await dataReader.ReadAsync())
                            {
                                Unrated getData = new Unrated()
                                {
                                    InUnrated = dataReader["InUnrated"] as string,
                                    Unrated_Amount = dataReader["Unrated_Amount"] as float? ?? 0,
                                    Unrated_To = dataReader["Unrated_To"] as string,
                                    ThroughBy_Unrated = dataReader["ThroughBy_Unrated"] as string,
                                    Unrated_Date = (DateTime)(dataReader["Unrated_Date"] as DateTime?),
                                    Remarks_Unrated = dataReader["Remarks_Unrated"] as string,
                                    UDT_V = dataReader["UDT_V"] as string,
                                    UDT_V_Date = (DateTime)(dataReader["UDT_V_Date"] as DateTime?),
                                    DDT_V_Date = (DateTime)(dataReader["DDT_V_Date"] as DateTime?),
                                    U_Insrt_Person = dataReader["U_Insrt_Person"] as string,
                                    U_Updt_Person = dataReader["U_Updt_Person"] as string,
                                    U_Del_Person = dataReader["U_Del_Person"] as string
                                };
                                respUnrated.UnratedDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respUnrated.IsSuccess = true;
                            respUnrated.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respUnrated.IsSuccess = false;
                respUnrated.Message = ex.Message;
                _logger.LogError($"Read Unrated ID Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respUnrated;
        }
        public async Task<Unrated> IUpdateUnratedRecordRL(Unrated unrated)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Unrated respUnrated = new Unrated();
            respUnrated.IsSuccess = true;
            respUnrated.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.UpdateUnrated, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@InUnrated", unrated.InUnrated);
                    cmd.Parameters.AddWithValue("@Unrated_Amount", unrated.Unrated_Amount);
                    cmd.Parameters.AddWithValue("@Unrated_To", unrated.Unrated_To);
                    cmd.Parameters.AddWithValue("@ThroughBy_Unrated", unrated.ThroughBy_Unrated);
                    cmd.Parameters.AddWithValue("@Unrated_Date", unrated.Unrated_Date);
                    cmd.Parameters.AddWithValue("@Remarks_Unrated", unrated.Remarks_Unrated);
                    cmd.Parameters.AddWithValue("@UDT_V_Date", unrated.UDT_V_Date);
                    cmd.Parameters.AddWithValue("@U_Updt_Person", unrated.U_Updt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respUnrated.IsSuccess = false;
                        respUnrated.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respUnrated;
                    }
                }
            }
            catch (Exception ex)
            {
                respUnrated.IsSuccess = false;
                respUnrated.Message = ex.Message;
                _logger.LogError($"Update Unrated Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respUnrated;
        }
        public async Task<Unrated> IDeleteUnratedRecordRL(Unrated unrated)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Unrated respUnrated = new Unrated();
            respUnrated.IsSuccess = true;
            respUnrated.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.DeleteUnrated, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@InUnrated", unrated.InUnrated);
                    cmd.Parameters.AddWithValue("@UDT_V", unrated.UDT_V);
                    cmd.Parameters.AddWithValue("@DDT_V_Date", unrated.DDT_V_Date);
                    cmd.Parameters.AddWithValue("@U_Del_Person", unrated.U_Del_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respUnrated.IsSuccess = false;
                        respUnrated.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respUnrated;
                    }
                }
            }
            catch (Exception ex)
            {
                respUnrated.IsSuccess = false;
                respUnrated.Message = ex.Message;
                _logger.LogError($"Delete Unrated Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respUnrated;
        }
    }
}
