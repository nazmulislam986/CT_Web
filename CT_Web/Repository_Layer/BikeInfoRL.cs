using CT_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public Task<BikeInfo> ICreateBikeInfoRecordRL(BikeInfo bikeinfo)
        {
            throw new NotImplementedException();
        }

        public Task<BikeInfo> IDeleteBikeInfoRecordRL(BikeInfo bikeinfo)
        {
            throw new NotImplementedException();
        }

        public Task<BikeInfo> IReadBikeInfoIDRecordRL(BikeInfo bikeinfo)
        {
            throw new NotImplementedException();
        }

        public Task<BikeInfo> IReadBikeInfoRecordRL()
        {
            throw new NotImplementedException();
        }

        public Task<BikeInfo> IUpdateBikeInfoRecordRL(BikeInfo bikeinfo)
        {
            throw new NotImplementedException();
        }
    }
}
