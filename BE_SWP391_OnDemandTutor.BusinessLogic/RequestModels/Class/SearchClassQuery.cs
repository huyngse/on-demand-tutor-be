using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Class
{
    public class SearchClassQuery
    {
        public string? ClassName { get; set; } = null;
        public string? City { get; set; } = null;
        public string? District { get; set; } = null;
        public string? Ward { get; set; } = null;
        public string? ClassMethod { get; set; } = null;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
