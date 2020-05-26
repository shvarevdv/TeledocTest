using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TeledocTestProject.Models
{
    public class Founder: Employe
    {        
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }

        [ForeignKey("EntityClient")]
        public int? EntityClientId { get; set; }
        public EntityClient Client { get; set; }
        public override string ToString()
        {
            return new string(string.Format("{0} {1} {2}", LastName, FirstName, SecondName));
        }
    }
}
