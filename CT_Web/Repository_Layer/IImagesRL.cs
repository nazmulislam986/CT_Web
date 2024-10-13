using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Repository_Layer
{
    public interface IImagesRL
    {
        public Task<Images> ICreateImagesRecordRL(Images images);
        public Task<Images> IReadImagesRecordRL();
        public Task<Images> IReadImagesIDRecordRL(Images images);
        public Task<Images> IUpdateImagesRecordRL(Images images);
        public Task<Images> IDeleteImagesRecordRL(Images images);
    }
}
