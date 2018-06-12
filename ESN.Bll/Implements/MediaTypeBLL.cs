using ESN.Dal;
using ESN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Bll
{
    public class MediaTypeBLL : IMediaTypeBLL
    {
        protected readonly IMediaTypeDAL mediaTypeDAL;
        public MediaTypeBLL()
        {
            this.mediaTypeDAL = new MediaTypeDAL();
        }

        public IEnumerable<MSMediaType> GetAll()
        {
            return mediaTypeDAL.GetAll();
        }
    }
}