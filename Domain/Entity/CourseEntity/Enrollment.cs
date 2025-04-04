using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.CourseEntity
{
    public class Enrollment
    {
        public int Id { get; set; }
        public string UserId { get; set; }      
        public int CourseId { get; set; }
    
    }
}
