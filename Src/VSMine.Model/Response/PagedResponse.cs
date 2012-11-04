using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSMine.Model.Response
{
    public abstract class PagedResponseBase
    {
        public int Offset { get; set; }

        public int Limit { get; set; }

        public int TotalCount { get; set; }
    }
}
