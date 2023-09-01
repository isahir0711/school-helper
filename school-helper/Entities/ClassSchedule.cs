namespace school_helper.Entities
{
    public class ClassSchedule
    {

        public int Id { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public string WeekDay { get; set; }
        public TimeOnly StartHour { get; set; }
        public TimeOnly EndHour { get; set; }
    }
}
