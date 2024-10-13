using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Service_Layer
{
    public interface IBikeInfoSL
    {
        public Task<BikeInfo> ICreateBikeInfoRecordSL(BikeInfo bikeInfo);
        public Task<BikeInfo> IReadBikeInfoRecordSL();
        public Task<BikeInfo> IReadBikeInfoIDRecordSL(BikeInfo bikeInfo);
        public Task<BikeInfo> IUpdateBikeInfoRecordSL(BikeInfo bikeInfo);
        public Task<BikeInfo> IDeleteBikeInfoRecordSL(BikeInfo bikeInfo);
    }
}
