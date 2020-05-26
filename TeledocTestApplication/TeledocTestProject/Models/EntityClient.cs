using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeledocTestProject.Models
{
    public class EntityClient : Employe
    {
        public string Name { get; set; }
        public IEnumerable<Founder> Founders { get; set; }
        
    }
}
