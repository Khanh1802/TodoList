using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoList.Data.Interface;

namespace ToDoList.Data.Models
{
    public class Job : IAuditedEntity
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public int CategoryId { get; set; }

        public int StateId { get; set; }

        public Category Category { get; set; }
        public State State { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public DateTime? DeletetionTime { get; set; }
        public DateTime? LastModificationTime { get; set; } 
        public bool IsDeleted { get; set; }
    }
}
