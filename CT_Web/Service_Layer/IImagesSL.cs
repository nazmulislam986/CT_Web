using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT_App.Models;

namespace CT_Web.Service_Layer
{
    public interface IImagesSL
    {
        public Task<Images> ICreateImagesRecordSL(Images images);
        public Task<Images> IReadImagesRecordSL();
        public Task<Images> IReadImagesIDRecordSL(Images images);
        public Task<Images> IUpdateImagesRecordSL(Images images);
        public Task<Images> IDeleteImagesRecordSL(Images images);
    }
}
