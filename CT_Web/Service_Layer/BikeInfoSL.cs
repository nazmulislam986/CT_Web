using CT_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_Web.Repository_Layer;
using Microsoft.Extensions.Logging;

namespace CT_Web.Service_Layer
{
    public class BikeInfoSL : IBikeInfoSL
    {
        public readonly IBikeInfoRL _bikeInfoRL;
        public readonly ILogger<BikeInfoSL> _logger;
        public BikeInfoSL(IBikeInfoRL bikeInfoRL, ILogger<BikeInfoSL> logger)
        {
            _bikeInfoRL = bikeInfoRL;
            _logger = logger;
        }
        public Task<BikeInfo> ICreateBikeInfoRecordSL(BikeInfo bikeInfo)
        {
            throw new NotImplementedException();
        }
        public Task<BikeInfo> IDeleteBikeInfoRecordSL(BikeInfo bikeInfo)
        {
            throw new NotImplementedException();
        }
        public Task<BikeInfo> IReadBikeInfoIDRecordSL(BikeInfo bikeInfo)
        {
            throw new NotImplementedException();
        }
        public Task<BikeInfo> IReadBikeInfoRecordSL()
        {
            throw new NotImplementedException();
        }
        public Task<BikeInfo> IUpdateBikeInfoRecordSL(BikeInfo bikeInfo)
        {
            throw new NotImplementedException();
        }
    }
}
