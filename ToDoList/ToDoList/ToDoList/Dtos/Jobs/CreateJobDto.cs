namespace ToDoList.Dtos.Jobs
{
    public class CreateJobDto
    {
        public string Name { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int CategoryId { get; set; }
        public int StateId { get; set; }
    }
}
