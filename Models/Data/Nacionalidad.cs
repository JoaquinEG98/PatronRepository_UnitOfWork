using System;
using System.Collections.Generic;

namespace Models.Data
{
    public partial class Nacionalidad
    {
        public Nacionalidad()
        {
            Personas = new HashSet<Persona>();
        }

        public int NacionalidadId { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
