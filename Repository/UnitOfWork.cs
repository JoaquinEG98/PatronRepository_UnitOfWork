using Models.Data;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class UnitOfWork : IUnitOfWork
    {
        private PatronesContext _context;
        private IRepository<Persona>? _personas;
        private IRepository<Nacionalidad>? _nacionalidades;

        public UnitOfWork(PatronesContext context)
        {
            _context = context;
        }


        public IRepository<Persona> Personas
        {
            get
            {
                return _personas == null ?
                    _personas = new Repository<Persona>(_context) :
                    _personas;
            }
        }


        public IRepository<Nacionalidad> Nacionalidades
        {
            get
            {
                return _nacionalidades == null ?
                    _nacionalidades = new Repository<Nacionalidad>(_context) :
                    _nacionalidades;
            }
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
