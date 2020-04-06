using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientesTG.Models
{
    public partial class Logradouros
    {       
        public int LogradouroId { get; set; }
              
        public string Logradouro { get; set; }
               
        public int? ClienteId { get; set; }

        public virtual Clientes Cliente { get; set; }
    }
}
