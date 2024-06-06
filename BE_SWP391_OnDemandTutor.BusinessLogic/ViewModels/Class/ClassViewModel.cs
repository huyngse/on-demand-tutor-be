

using System;
using System.Collections.Generic;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels 
{

    public class ClassViewModel {
        public Guid ClassId { get; set; } = new Guid();
        public string ClassName { get; set; } = null;
        public string ClassCode { get; set; } = null;
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; } = new Guid();
        public string CreatedByName { get; set; } = null;
        public string Duration { get; set; } = null;
        public int Status { get; set; }
        public string Location { get; set; } = null;
        public string UserName { get; set; } = null;
        public DateTime CreatedDate { get; set; }
        public Guid ModifiedBy { get; set; }
        public string ModifiedByName { get; set; } = null;
        public DateTime ModifiedDate { get; set; }

        public class GetDetailViewModel
        {
            public Guid ClassID { get; set; } = new Guid();
            public string ClassName { get; set; } = null;
            // Add more Field

        }
    }

}
