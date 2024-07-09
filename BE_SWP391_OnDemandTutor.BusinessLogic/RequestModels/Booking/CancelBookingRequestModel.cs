using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Booking
{
    public class CancelBookingRequestModel
    {
        public string CancellationReason { get; set; } = "";
        public string Status { get; set; } = "Cancelled";
    }
}
