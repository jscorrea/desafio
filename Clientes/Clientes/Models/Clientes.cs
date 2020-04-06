using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ClientesTG.Models
{
    public partial class Clientes
    {
        public  int  ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Logotipo { get; set; }
      
        public virtual ICollection <Logradouros> Logradouros { get; set; }
    }
}