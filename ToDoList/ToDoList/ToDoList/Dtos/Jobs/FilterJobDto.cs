using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Dtos.Jobs
{
    public class FilterJobDto
    {
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public int StateId { get; set; }
    }
}
