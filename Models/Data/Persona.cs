using System;
using System.Collections.Generic;

namespace Models.Data
{
    public partial class Persona
    {
        public int PersonaId { get; set; }
        public string Nombre { get; set; } = null!;
        public int Edad { get; set; }
        public int NacionalidadId { get; set; }

        public virtual Nacionalidad Nacionalidad { get; set; } = null!;
    }
}
