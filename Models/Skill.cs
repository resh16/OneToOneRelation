using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneToOneRelation.Models
{
    public class Skill
    {
        public int skillId { get; set; }
        public string skillName { get; set; }

        public int EmployeeId { get; set; }
        public Employee emp { get; set; }
    }
}
