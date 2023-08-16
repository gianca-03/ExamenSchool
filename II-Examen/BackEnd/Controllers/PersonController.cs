using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private IPersonDAL personDal;

        private PersonModel Convertir(Person person)
        {
            return (new PersonModel
            {
                PersonId = person.PersonId,
                LastName = person.LastName,
                FirstName = person.FirstName,
                HireDate = person.HireDate,
                Discriminator = person.Discriminator
               
            });
        }

        private Person Convertir(PersonModel person)
        {
            return (new Person
            {
                PersonId = person.PersonId,
                LastName = person.LastName,
                FirstName = person.FirstName,
                HireDate = person.HireDate,
                Discriminator = person.Discriminator
            });
        }

        public PersonController()
        {
            personDal = new PersonDALImpl();
        }

        // GET: api/<PersonController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Person> persons = personDal.GetAll();
            List<PersonModel> models = new List<PersonModel>();

            foreach (var person in persons)
            {
                models.Add(Convertir(person));
            }

            return new JsonResult(models);
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Person person = personDal.Get(id);

            return new JsonResult(Convertir(person));
        }

        // POST api/<PersonController>
        [HttpPost]
        public JsonResult Post([FromBody] PersonModel person)
        {
            personDal.Add(Convertir(person));
            return new JsonResult(person);
        }

        // PUT api/<PersonController>/5
        [HttpPut]
        public JsonResult Put([FromBody] PersonModel person)
        {
            personDal.Update(Convertir(person));
            return new JsonResult(person);
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Person person = new Person
            {
                PersonId = id
            };

            personDal.Remove(person);

        }
    }
}
