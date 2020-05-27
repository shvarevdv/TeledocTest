using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace TeledocTestProject.Models
{
    public abstract class Employe
    {
        public int Id { get; set; }
        [JsonPropertyName("ИНН")]
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
