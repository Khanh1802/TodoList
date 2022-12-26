namespace ToDoList.Dtos.Jobs
{
    public class JobDto
    {
        public int Id { get; set; }
        public string NameJob { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public int CategoryId { get; set; }
        public string NameCategory { get; set; }

        public int StateId { get; set; }
        public string NameState { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public DateTime? DeletetionTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
