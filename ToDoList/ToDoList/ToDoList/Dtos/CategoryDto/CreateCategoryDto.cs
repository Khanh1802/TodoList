namespace ToDoList.Dtos.CategoryDto
{
    public class CreateCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
    }
}
