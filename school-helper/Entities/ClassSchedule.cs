namespace school_helper.Entities
{
    public class ClassSchedule
    {

        public int Id { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public string WeekDay { get; set; }
        public DateTime StartHour { get; set; }
        public DateTime EndHour { get; set; }
    }
}
