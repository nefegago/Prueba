using System;
using System.Collections.Generic;

#nullable disable

namespace prueba.Models
{
    public partial class PDocumento
    {
        public int IdPDocumento { get; set; }
        public string Name { get; set; }
        public int PCarpetaIdPCarpeta { get; set; }
    }
}
