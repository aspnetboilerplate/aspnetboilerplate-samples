using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterceptionDemo.Tasks.Dto
{
    public class CreateTaskInput
    {
        public int AssignedUserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
