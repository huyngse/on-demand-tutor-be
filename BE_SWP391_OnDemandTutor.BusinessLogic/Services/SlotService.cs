using BE_SWP391_OnDemandTutor.BusinessLogic.RequestModels.Slot;
using BE_SWP391_OnDemandTutor.BusinessLogic.ViewModels;

namespace BE_SWP391_OnDemandTutor.BusinessLogic.Services
{

    public interface ISlotService
    {
        public SlotViewModel CreateSlot(CreateSlotRequestModel slotCreate);
        public SlotViewModel UpdateSlot(UpdateSlotRequestModel slotUpdate);
        public bool DeleteSlot(int idTmp);
        public List<SlotViewModel> GetAll();
        public SlotViewModel GetById(int idTmp);
    }

    public class SlotService : ISlotService
    {


        public SlotViewModel CreateSlot(CreateSlotRequestModel slotCreate)
        {
            throw new NotImplementedException();
        }

        public SlotViewModel UpdateSlot(UpdateSlotRequestModel slotUpdate)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSlot(int idTmp)
        {
            throw new NotImplementedException();
        }

        public List<SlotViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public SlotViewModel GetById(int idTmp)
        {
            throw new NotImplementedException();
        }

    }

}
