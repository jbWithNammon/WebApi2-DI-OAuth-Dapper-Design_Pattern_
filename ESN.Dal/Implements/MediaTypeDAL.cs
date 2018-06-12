using ESN.Dal.Infrastructure;
using ESN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESN.Dal
{
    public class MediaTypeDAL : Repository<MSMediaType>, IMediaTypeDAL
    {
        protected readonly IDBFactory DbFactory;

        protected readonly IDBFactory SubDbFactory;
        public MediaTypeDAL() : this(new DBFactory())
        {
            MSMediaType media = new MSMediaType();
        }

        public MediaTypeDAL(IDBFactory dbFactory)
            : base(dbFactory.Connection)
        {
            this.DbFactory = dbFactory;
        }

        public IEnumerable<MSMediaType> GetMediaTypeAll()
        {
            return base.GetAll();
        }
    }
}
