using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Repository_Layer
{
    public interface IUnratedRL
    {
        public Task<Unrated> ICreateUnratedRecordRL(Unrated unrated);
        public Task<Unrated> IReadUnratedRecordRL();
        public Task<Unrated> IReadUnratedIDRecordRL(Unrated unrated);
        public Task<Unrated> IUpdateUnratedRecordRL(Unrated unrated);
        public Task<Unrated> IDeleteUnratedRecordRL(Unrated unrated);
    }
}
