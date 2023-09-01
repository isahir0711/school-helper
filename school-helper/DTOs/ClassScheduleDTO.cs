namespace school_helper.DTOs
{
    public class ClassScheduleDTO
    {
        public string WeekDay { get; set; }
        public TimeOnly StartHour { get; set; }
        public TimeOnly EndHour { get; set; }
    }
}
