using System.ComponentModel.DataAnnotations;
using ToDoList.Data.Interface;

namespace ToDoList.Data.Models
{
    public class Category : IAuditedEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// 1 - n biểu hiện cho 1 nhiều
        /// </summary>
        public ICollection<Job> Jobs { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public DateTime? DeletetionTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
