using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Service_Layer
{
    public interface IUnratedSL
    {
        public Task<Unrated> ICreateUnratedRecordSL(Unrated unrated);
        public Task<Unrated> IReadUnratedRecordSL();
        public Task<Unrated> IReadUnratedIDRecordSL(Unrated unrated);
        public Task<Unrated> IUpdateUnratedRecordSL(Unrated unrated);
        public Task<Unrated> IDeleteUnratedRecordSL(Unrated unrated);
    }
}
