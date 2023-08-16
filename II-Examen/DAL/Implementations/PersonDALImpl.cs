using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class PersonDALImpl : IPersonDAL
    {
        private SchoolContext _schoolContext;
        private UnidadDeTrabajo<Person> unidad;

        public bool Add(Person entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Person>(new SchoolContext()))
                {
                    unidad.genericDAL.Add(entity);
                    unidad.Complete();
                }


                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void AddRange(IEnumerable<Person> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> Find(Expression<Func<Person, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Person Get(int id)
        {
            Person person = null;
            using (unidad = new UnidadDeTrabajo<Person>(new SchoolContext()))
            {
                person = unidad.genericDAL.Get(id);
            }
            return person;
        }

        public IEnumerable<Person> GetAll()
        {
            IEnumerable<Person> persons = null;

            using (unidad = new UnidadDeTrabajo<Person>(new SchoolContext()))
            {
                persons = unidad.genericDAL.GetAll();
            }
            return persons;
        }

        public bool Remove(Person entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Person>(new SchoolContext()))
                {
                    unidad.genericDAL.Remove(entity);
                    unidad.Complete();
                }


                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void RemoveRange(IEnumerable<Person> entities)
        {
            throw new NotImplementedException();
        }

        public Person SingleOrDefault(Expression<Func<Person, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Person entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Person>(new SchoolContext()))
                {
                    unidad.genericDAL.Update(entity);
                    unidad.Complete();
                }


                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
