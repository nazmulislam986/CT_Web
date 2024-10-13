using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Repository_Layer
{
    public interface ITekenRL
    {
        public Task<Teken> ICreateTekenRecordRL(Teken teken);
        public Task<Teken> IReadTekenRecordRL();
        public Task<Teken> IReadTekenIDRecordRL(Teken teken);
        public Task<Teken> IUpdateTekenRecordRL(Teken teken);
        public Task<Teken> IDeleteTekenRecordRL(Teken teken);
    }
}
