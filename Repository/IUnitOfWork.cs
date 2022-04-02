using Models.Data;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public interface IUnitOfWork
    {
        public IRepository<Persona> Personas { get; }
        public IRepository<Nacionalidad> Nacionalidades { get; }

        public void Save();
    }
}
