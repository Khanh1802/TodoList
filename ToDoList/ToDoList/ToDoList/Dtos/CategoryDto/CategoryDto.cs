using ToDoList.Data.Models;

namespace ToDoList.Dtos.CategoryDto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// 1 - n biểu hiện cho 1 nhiều
        /// </summary>
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public DateTime? DeletetionTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
