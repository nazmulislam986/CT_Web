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
    public class SavingRL : ISavingRL
    {
        public readonly IConfiguration _configuration;
        public readonly MySqlConnection _sqlConn;
        public readonly ILogger<SavingRL> _logger;
        public SavingRL(IConfiguration configuration, ILogger<SavingRL> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _sqlConn = new MySqlConnection(_configuration["ConnectionStrings:connMySql"]);
        }

        public async Task<Saving> ICreateSavingRecordRL(Saving saving)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Saving respSaving = new Saving();
            respSaving.IsSuccess = true;
            respSaving.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.AddSaving, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@InSaving", saving.InSaving);
                    cmd.Parameters.AddWithValue("@Saving_Amount", saving.Saving_Amount);
                    cmd.Parameters.AddWithValue("@Saving_To", saving.Saving_To);
                    cmd.Parameters.AddWithValue("@ThroughBy_Saving", saving.ThroughBy_Saving);
                    cmd.Parameters.AddWithValue("@Saving_Date", saving.Saving_Date);
                    cmd.Parameters.AddWithValue("@Remarks_Saving", saving.Remarks_Saving);
                    cmd.Parameters.AddWithValue("@SDT_V", saving.SDT_V);
                    cmd.Parameters.AddWithValue("@Saving_Bank", saving.Saving_Bank);
                    cmd.Parameters.AddWithValue("@S_Insrt_Person", saving.S_Insrt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respSaving.IsSuccess = false;
                        respSaving.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respSaving;
                    }
                }
            }
            catch (Exception ex)
            {
                respSaving.IsSuccess = false;
                respSaving.Message = ex.Message;
                _logger.LogError($"Insert Saving Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respSaving;
        }
        public async Task<Saving> IReadSavingRecordRL()
        {
            _logger.LogInformation($"Calling Repository Layer");
            Saving respSaving = new Saving();
            respSaving.IsSuccess = true;
            respSaving.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetSaving, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respSaving.SavingDataList = new List<Saving>();
                            while (await dataReader.ReadAsync())
                            {
                                Saving getData = new Saving()
                                {
                                    InSaving = dataReader["InSaving"] as string,
                                    Saving_Amount = dataReader["Saving_Amount"] as float? ?? 0,
                                    Saving_To = dataReader["Saving_To"] as string,
                                    ThroughBy_Saving = dataReader["ThroughBy_Saving"] as string,
                                    Saving_Date = (DateTime)(dataReader["Saving_Date"] as DateTime?),
                                    Remarks_Saving = dataReader["Remarks_Saving"] as string,
                                    SDT_V = dataReader["SDT_V"] as string,
                                    SDT_V_Date = (DateTime)(dataReader["SDT_V_Date"] as DateTime?),
                                    DDT_V_Date = (DateTime)(dataReader["DDT_V_Date"] as DateTime?),
                                    Saving_Bank = dataReader["Saving_Bank"] as string,
                                    S_Insrt_Person = dataReader["S_Insrt_Person"] as string,
                                    S_Updt_Person = dataReader["S_Updt_Person"] as string,
                                    S_Del_Person = dataReader["S_Del_Person"] as string
                                };
                                respSaving.SavingDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respSaving.IsSuccess = true;
                            respSaving.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respSaving.IsSuccess = false;
                respSaving.Message = ex.Message;
                _logger.LogError($"Read Saving Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respSaving;
        }
        public async Task<Saving> IReadSavingIDRecordRL(Saving saving)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Saving respSaving = new Saving();
            respSaving.IsSuccess = true;
            respSaving.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetSavingID, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@InSaving", saving.InSaving);
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respSaving.SavingDataList = new List<Saving>();
                            if (await dataReader.ReadAsync())
                            {
                                Saving getData = new Saving()
                                {
                                    InSaving = dataReader["InSaving"] as string,
                                    Saving_Amount = dataReader["Saving_Amount"] as float? ?? 0,
                                    Saving_To = dataReader["Saving_To"] as string,
                                    ThroughBy_Saving = dataReader["ThroughBy_Saving"] as string,
                                    Saving_Date = (DateTime)(dataReader["Saving_Date"] as DateTime?),
                                    Remarks_Saving = dataReader["Remarks_Saving"] as string,
                                    SDT_V = dataReader["SDT_V"] as string,
                                    SDT_V_Date = (DateTime)(dataReader["SDT_V_Date"] as DateTime?),
                                    DDT_V_Date = (DateTime)(dataReader["DDT_V_Date"] as DateTime?),
                                    Saving_Bank = dataReader["Saving_Bank"] as string,
                                    S_Insrt_Person = dataReader["S_Insrt_Person"] as string,
                                    S_Updt_Person = dataReader["S_Updt_Person"] as string,
                                    S_Del_Person = dataReader["S_Del_Person"] as string
                                };
                                respSaving.SavingDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respSaving.IsSuccess = true;
                            respSaving.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respSaving.IsSuccess = false;
                respSaving.Message = ex.Message;
                _logger.LogError($"Read Saving ID Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respSaving;
        }
        public async Task<Saving> IUpdateSavingRecordRL(Saving saving)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Saving respSaving = new Saving();
            respSaving.IsSuccess = true;
            respSaving.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.UpdateSaving, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@InSaving", saving.InSaving);
                    cmd.Parameters.AddWithValue("@Saving_Amount", saving.Saving_Amount);
                    cmd.Parameters.AddWithValue("@Saving_To", saving.Saving_To);
                    cmd.Parameters.AddWithValue("@ThroughBy_Saving", saving.ThroughBy_Saving);
                    cmd.Parameters.AddWithValue("@Saving_Date", saving.Saving_Date);
                    cmd.Parameters.AddWithValue("@Remarks_Saving", saving.Remarks_Saving);
                    cmd.Parameters.AddWithValue("@SDT_V_Date", saving.SDT_V_Date);
                    cmd.Parameters.AddWithValue("@Saving_Bank", saving.Saving_Bank);
                    cmd.Parameters.AddWithValue("@S_Updt_Person", saving.S_Updt_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respSaving.IsSuccess = false;
                        respSaving.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respSaving;
                    }
                }
            }
            catch (Exception ex)
            {
                respSaving.IsSuccess = false;
                respSaving.Message = ex.Message;
                _logger.LogError($"Update Saving Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respSaving;
        }
        public async Task<Saving> IDeleteSavingRecordRL(Saving saving)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Saving respSaving = new Saving();
            respSaving.IsSuccess = true;
            respSaving.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.DeleteSaving, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@InSaving", saving.InSaving);
                    cmd.Parameters.AddWithValue("@SDT_V", saving.SDT_V);
                    cmd.Parameters.AddWithValue("@DDT_V_Date", saving.DDT_V_Date);
                    cmd.Parameters.AddWithValue("@S_Del_Person", saving.S_Del_Person);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respSaving.IsSuccess = false;
                        respSaving.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respSaving;
                    }
                }
            }
            catch (Exception ex)
            {
                respSaving.IsSuccess = false;
                respSaving.Message = ex.Message;
                _logger.LogError($"Delete Saving Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respSaving;
        }
    }
}
