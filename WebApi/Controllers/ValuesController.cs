using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Concrete;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ContactController : ApiController
    {
        private EfContactRepository _repo;

     
        public ContactController()

        {
            _repo = new EfContactRepository();
        }


        //получаем всех людей
        [HttpGet]
        [Route("api/person")]
        public IEnumerable<Person> GetPerson()

        {
            return _repo.Persons;
 
        }

        //добавляем человека
        [HttpPost]
        [Route("api/person")]
        public void AddPerson([FromBody]Person person)
        {
            _repo.AddPerson(person);
        }

        //редактируем человека
        [HttpPut]
        [Route("api/person")]
        public void EditPerson([FromBody]Person person)
        {
            _repo.SavePerson(person);
        }

        //удаляем человека
        [HttpDelete]
        [Route("api/person/{id}")]
        public void DeletePerson(int id)
        {
            _repo.DeletePerson(id);
        }




        //получаем контакт по id person
        [HttpGet]
        [Route("api/contacts/{id}")]
        public IEnumerable<Contacts> GetContacts(int id)
        {
            return _repo.Contacts.Where(x => x.PersonId == id);
        }



        //добавляем контакт
        [HttpPost]
        [Route("api/contacts/{id}")]
        public void AddContact(int id, [FromBody]ContactInfo contact)
        {
            _repo.AddContacts(new Contacts()
            {
                NameContact = contact.Name,
                ValContact = contact.Value,
                PersonId = id
            });

        }

        //редактируем контакт
        [HttpPut]
        [Route("api/contact")]
        public void EditContact([FromBody]Contacts contact)
        {
            _repo.SaveContacts(contact);
        }

        //удаляем контакт
        [HttpDelete]
        [Route("api/contact/{id}")]
        public void DeleteContact(int id)
        {
            _repo.DeleteContacts(id);
        }
    }
}
