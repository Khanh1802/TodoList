namespace ToDoList.Dtos.States
{
    public class CreateStateDto
    {
        public string Name { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public DateTime? DeletetionTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}
