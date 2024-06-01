namespace BE_SWP391_OnDemandTutor.DataAccess.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }
        public Rate Rate { get; set; }
        public Slot Slot { get; set; }
    }
}
