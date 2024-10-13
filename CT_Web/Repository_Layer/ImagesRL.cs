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
    public class ImagesRL : IImagesRL
    {
        public readonly IConfiguration _configurationImages;
        public readonly MySqlConnection _sqlConn;
        public readonly ILogger<ImagesRL> _logger;
        public ImagesRL(IConfiguration configurationImages, ILogger<ImagesRL> logger)
        {
            _configurationImages = configurationImages;
            _logger = logger;
            _sqlConn = new MySqlConnection(_configurationImages["ConnectionStrings:connMySql"]);
        }

        public async Task<Images> ICreateImagesRecordRL(Images images)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Images respImages = new Images();
            respImages.IsSuccess = true;
            respImages.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.AddImages, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@Img_ID", images.Img_ID);
                    cmd.Parameters.AddWithValue("@ImageData", images.ImageData);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respImages.IsSuccess = false;
                        respImages.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respImages;
                    }
                }
            }
            catch (Exception ex)
            {
                respImages.IsSuccess = false;
                respImages.Message = ex.Message;
                _logger.LogError($"Insert Images Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respImages;
        }
        public async Task<Images> IReadImagesRecordRL()
        {
            _logger.LogInformation($"Calling Repository Layer");
            Images respImages = new Images();
            respImages.IsSuccess = true;
            respImages.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetImages, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respImages.ImagesDataList = new List<Images>();
                            while (await dataReader.ReadAsync())
                            {
                                Images getData = new Images()
                                {
                                    Img_ID = dataReader["Img_ID"] as string,
                                    ImageData = dataReader["ImageData"] as string
                                };
                                respImages.ImagesDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respImages.IsSuccess = true;
                            respImages.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respImages.IsSuccess = false;
                respImages.Message = ex.Message;
                _logger.LogError($"Read Images Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respImages;
        }
        public async Task<Images> IReadImagesIDRecordRL(Images images)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Images respImages = new Images();
            respImages.IsSuccess = true;
            respImages.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.GetImagesID, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@Img_ID", images.Img_ID);
                    using (MySqlDataReader dataReader = await cmd.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            respImages.ImagesDataList = new List<Images>();
                            if (await dataReader.ReadAsync())
                            {
                                Images getData = new Images()
                                {
                                    Img_ID = dataReader["Img_ID"] as string,
                                    ImageData = dataReader["ImageData"] as string
                                };
                                respImages.ImagesDataList.Add(getData);
                            }
                        }
                        else
                        {
                            respImages.IsSuccess = true;
                            respImages.Message = "No Record Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                respImages.IsSuccess = false;
                respImages.Message = ex.Message;
                _logger.LogError($"Update Images ID Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respImages;
        }
        public async Task<Images> IUpdateImagesRecordRL(Images images)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Images respImages = new Images();
            respImages.IsSuccess = true;
            respImages.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.UpdateImages, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@Img_ID", images.Img_ID);
                    cmd.Parameters.AddWithValue("@ImageData", images.ImageData);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respImages.IsSuccess = false;
                        respImages.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respImages;
                    }
                }
            }
            catch (Exception ex)
            {
                respImages.IsSuccess = false;
                respImages.Message = ex.Message;
                _logger.LogError($"Update Images Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respImages;
        }
        public async Task<Images> IDeleteImagesRecordRL(Images images)
        {
            _logger.LogInformation($"Calling Repository Layer");
            Images respImages = new Images();
            respImages.IsSuccess = true;
            respImages.Message = "Successfull";
            try
            {
                if (_sqlConn.State != System.Data.ConnectionState.Open)
                {
                    await _sqlConn.OpenAsync();
                }
                using (MySqlCommand cmd = new MySqlCommand(SqlQueries.DeleteImages, _sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.AddWithValue("@Img_ID", images.Img_ID);
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    if (rowsAffected <= 0)
                    {
                        respImages.IsSuccess = false;
                        respImages.Message = "Something Wrong";
                        _logger.LogError($"Query Execute Error");
                        return respImages;
                    }
                }
            }
            catch (Exception ex)
            {
                respImages.IsSuccess = false;
                respImages.Message = ex.Message;
                _logger.LogError($"Delete Images Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respImages;
        }
    }
}
