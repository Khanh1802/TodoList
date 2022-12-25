using System.ComponentModel.DataAnnotations;
using ToDoList.Data.Interface;

namespace ToDoList.Data.Models
{
    public class State : IAuditedEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Job> Jobs { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public DateTime? DeletetionTime { get; set; } 
        public DateTime? LastModificationTime { get; set; } 
        public bool IsDeleted { get; set; }
    }
}
