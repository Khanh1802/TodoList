using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Dtos.Jobs
{
    public class UpdateJobDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int CategoryId { get; set; }
        public int StateId { get; set; }
    }
}
