using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Service_Layer
{
    public interface ITekenSL
    {
        public Task<Teken> ICreateTekenRecordSL(Teken teken);
        public Task<Teken> IReadTekenRecordSL();
        public Task<Teken> IReadTekenIDRecordSL(Teken teken);
        public Task<Teken> IUpdateTekenRecordSL(Teken teken);
        public Task<Teken> IDeleteTekenRecordSL(Teken teken);
    }
}
