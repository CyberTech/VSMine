using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSMine.Model.Response
{
    public class GetIssuesResponse : PagedResponseBase
    {
        public List<Issue> Issues { get; set; }
    }
}
