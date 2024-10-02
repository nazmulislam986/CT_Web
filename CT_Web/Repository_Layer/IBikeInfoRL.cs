using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Repository_Layer
{
    public interface IBikeInfoRL
    {
        public Task<BikeInfo> ICreateBikeInfoRecordRL(BikeInfo bikeinfo);
        public Task<BikeInfo> IReadBikeInfoRecordRL();
        public Task<BikeInfo> IReadBikeInfoIDRecordRL(BikeInfo bikeinfo);
        public Task<BikeInfo> IUpdateBikeInfoRecordRL(BikeInfo bikeinfo);
        public Task<BikeInfo> IDeleteBikeInfoRecordRL(BikeInfo bikeinfo);
    }
}
