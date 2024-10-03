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
            BikeInfo respMarket = new BikeInfo();
            respMarket.IsSuccess = true;
            respMarket.Message = "Successfull";
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
                    cmd.Parameters.AddWithValue("?", bikeinfo.B_ID);
                    cmd.Parameters.AddWithValue("?", bikeinfo.B_Chng_Date);
                    cmd.Parameters.AddWithValue("?", bikeinfo.B_KM_ODO);
                    cmd.Parameters.AddWithValue("?", bikeinfo.B_Mobile_Go);
                    cmd.Parameters.AddWithValue("?", bikeinfo.B_Next_ODO);
                    cmd.Parameters.AddWithValue("?", bikeinfo.B_Insrt_Person);
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
                _logger.LogError($"Insert Bike Info Record Error Message : {ex.Message}");
            }
            finally
            {
                await _sqlConn.CloseAsync();
                await _sqlConn.DisposeAsync();
            }
            return respMarket;
        }

        public async Task<BikeInfo> IDeleteBikeInfoRecordRL(BikeInfo bikeinfo)
        {
            throw new NotImplementedException();
        }

        public async Task<BikeInfo> IReadBikeInfoIDRecordRL(BikeInfo bikeinfo)
        {
            throw new NotImplementedException();
        }

        public async Task<BikeInfo> IReadBikeInfoRecordRL()
        {
            throw new NotImplementedException();
        }

        public async Task<BikeInfo> IUpdateBikeInfoRecordRL(BikeInfo bikeinfo)
        {
            throw new NotImplementedException();
        }
    }
}
