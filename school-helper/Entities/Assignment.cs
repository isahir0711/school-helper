namespace school_helper.Entities
{
    public class Assignment
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsDone { get; set; }

    }
}
