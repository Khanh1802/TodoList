namespace ToDoList.Dtos.Jobs
{
    public class FilterJobDto
    {
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public int StateId { get; set; }
    }
}
