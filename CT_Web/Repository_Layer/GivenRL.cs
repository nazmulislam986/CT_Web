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
    public class GivenRL : IGivenRL
    {
        public readonly IConfiguration _configuration;
        public readonly MySqlConnection _sqlConn;
        public readonly ILogger<GivenRL> _logger;
        public GivenRL(IConfiguration configuration, ILogger<GivenRL> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _sqlConn = new MySqlConnection(_configuration["ConnectionStrings:connMySql"]);
        }

        public async Task<Given> ICreateGivenRecordRL(Given given)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Given respGiven = new Given();
            respGiven.IsSuccess = true;
            respGiven.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.AddGiven, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@InGiven", given.InGiven);
                    cmd.Parameters.AddWithValue("@Total_Given", given.Total_Given);
                    cmd.Parameters.AddWithValue("@Given_To", given.Given_To);
                    cmd.Parameters.AddWithValue("@ThroughBy_Given", given.ThroughBy_Given);
                    cmd.Parameters.AddWithValue("@Given_Date", given.Given_Date);
                    cmd.Parameters.AddWithValue("@Remarks_Given", given.Remarks_Given);
                    cmd.Parameters.AddWithValue("@GDT_V", given.GDT_V);
                    cmd.Parameters.AddWithValue("@G_Insrt_Person", given.G_Insrt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respGiven.IsSuccess = false;
                        respGiven.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respGiven;
                    }
                }
            }
            catch (Exception ex)
            {
                respGiven.IsSuccess = false;
                respGiven.Message = ex.Message;
                _logger.LogError($"Insert Given Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respGiven;
        }
        public async Task<Given> IReadGivenRecordRL()
        {
            _logger.LogInformation($"Calling Repository Layer");
            Given respGiven = new Given();
            respGiven.IsSuccess = true;
            respGiven.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetGiven, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respGiven.GivenDataList = new List<Given>();
                            while (await dataReader.ReadAsync())
                            {
                                Given getData = new Given()
                                {
                                    InGiven = dataReader["InGiven"] as string,
                                    Total_Given = dataReader["Total_Given"] as float? ?? 0,
                                    Given_To = dataReader["Given_To"] as string,
                                    ThroughBy_Given = dataReader["ThroughBy_Given"] as string,
                                    Given_Date = (DateTime)(dataReader["Given_Date"] as DateTime?),
                                    Remarks_Given = dataReader["Remarks_Given"] as string,
                                    GDT_V = dataReader["GDT_V"] as string,
                                    GDT_V_Date = (DateTime)(dataReader["GDT_V_Date"] as DateTime?),
                                    DDT_V_Date = (DateTime)(dataReader["DDT_V_Date"] as DateTime?),
                                    G_Insrt_Person = dataReader["G_Insrt_Person"] as string,
                                    G_Updt_Person = dataReader["G_Updt_Person"] as string,
                                    G_Del_Person = dataReader["G_Del_Person"] as string
                                };
                                respGiven.GivenDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respGiven.IsSuccess = true;
                            respGiven.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respGiven.IsSuccess = false;
                respGiven.Message = ex.Message;
                _logger.LogError($"Read Given Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respGiven;
        }
        public async Task<Given> IReadGivenIDRecordRL(Given given)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Given respGiven = new Given();
            respGiven.IsSuccess = true;
            respGiven.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetGivenID, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@InGiven", given.InGiven);
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respGiven.GivenDataList = new List<Given>();
                            if (await dataReader.ReadAsync())
                            {
                                Given getData = new Given()
                                {
                                    InGiven = dataReader["InGiven"] as string,
                                    Total_Given = dataReader["Total_Given"] as float? ?? 0,
                                    Given_To = dataReader["Given_To"] as string,
                                    ThroughBy_Given = dataReader["ThroughBy_Given"] as string,
                                    Given_Date = (DateTime)(dataReader["Given_Date"] as DateTime?),
                                    Remarks_Given = dataReader["Remarks_Given"] as string,
                                    GDT_V = dataReader["GDT_V"] as string,
                                    GDT_V_Date = (DateTime)(dataReader["GDT_V_Date"] as DateTime?),
                                    DDT_V_Date = (DateTime)(dataReader["DDT_V_Date"] as DateTime?),
                                    G_Insrt_Person = dataReader["G_Insrt_Person"] as string,
                                    G_Updt_Person = dataReader["G_Updt_Person"] as string,
                                    G_Del_Person = dataReader["G_Del_Person"] as string
                                };
                                respGiven.GivenDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respGiven.IsSuccess = true;
                            respGiven.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respGiven.IsSuccess = false;
                respGiven.Message = ex.Message;
                _logger.LogError($"Update Given ID Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respGiven;
        }
        public async Task<Given> IUpdateGivenRecordRL(Given given)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Given respGiven = new Given();
            respGiven.IsSuccess = true;
            respGiven.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.UpdateGiven, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@InGiven", given.InGiven);
                    cmd.Parameters.AddWithValue("@Total_Given", given.Total_Given);
                    cmd.Parameters.AddWithValue("@Given_To", given.Given_To);
                    cmd.Parameters.AddWithValue("@ThroughBy_Given", given.ThroughBy_Given);
                    cmd.Parameters.AddWithValue("@Remarks_Given", given.Remarks_Given);
                    cmd.Parameters.AddWithValue("@GDT_V_Date", given.GDT_V_Date);
                    cmd.Parameters.AddWithValue("@G_Updt_Person", given.G_Updt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respGiven.IsSuccess = false;
                        respGiven.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respGiven;
                    }
                }
            }
            catch (Exception ex)
            {
                respGiven.IsSuccess = false;
                respGiven.Message = ex.Message;
                _logger.LogError($"Update Given Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respGiven;
        }
        public async Task<Given> IDeleteGivenRecordRL(Given given)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Given respGiven = new Given();
            respGiven.IsSuccess = true;
            respGiven.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.DeleteGiven, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@InGiven", given.InGiven);
                    cmd.Parameters.AddWithValue("@GDT_V", given.GDT_V);
                    cmd.Parameters.AddWithValue("@DDT_V_Date", given.DDT_V_Date);
                    cmd.Parameters.AddWithValue("@G_Del_Person", given.G_Del_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respGiven.IsSuccess = false;
                        respGiven.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respGiven;
                    }
                }
            }
            catch (Exception ex)
            {
                respGiven.IsSuccess = false;
                respGiven.Message = ex.Message;
                _logger.LogError($"Delete Given Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respGiven;
        }
        public async Task<Given> IDeleteResonGivenRecordRL(Given given)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Given respGiven = new Given();
            respGiven.IsSuccess = true;
            respGiven.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.DeleteResonGiven, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@InGiven", given.InGiven);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respGiven.IsSuccess = false;
                        respGiven.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respGiven;
                    }
                }
            }
            catch (Exception ex)
            {
                respGiven.IsSuccess = false;
                respGiven.Message = ex.Message;
                _logger.LogError($"Delete Reson Given Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respGiven;
        }
    }
}
