using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Repository_Layer
{
    public interface ISavingRL
    {
        public Task<Saving> ICreateSavingRecordRL(Saving saving);
        public Task<Saving> IReadSavingRecordRL();
        public Task<Saving> IReadSavingIDRecordRL(Saving saving);
        public Task<Saving> IUpdateSavingRecordRL(Saving saving);
        public Task<Saving> IDeleteSavingRecordRL(Saving saving);
    }
}
