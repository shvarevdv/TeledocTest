using System;

namespace TeledocTestProject.Models
{
    public abstract class Employe
    {
        public int Id { get; set; }
        public int Inn { get; set; }        
        public DateTime CreateDate { get; private set; }
        public DateTime UpdateDate { get; private set; }

        public void SetCreateDate()
        {
            CreateDate = DateTime.Now;
        }
        public void SetUpdateDate()
        {
            UpdateDate = DateTime.Now;
        }
    }
}
