using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Concrete
{
    public class EfContactRepository 
    {
        ContactEntities _cntx = new ContactEntities();
        public IEnumerable<Person> Persons => _cntx.Person;

        public IEnumerable<Contacts> Contacts => _cntx.Contacts;

        public void AddPerson(Person person)
        {
            _cntx.Person.Add(person);
            _cntx.SaveChanges();
        }

        public void AddContacts(Contacts contact)
        {
            _cntx.Contacts.Add(contact);
            _cntx.SaveChanges();
        }

        public void SaveContacts(Contacts contact)
        {
            Contacts dbEntry = _cntx.Contacts.Find(contact.Id);
            if (dbEntry != null)
            {
                dbEntry.PersonId = contact.PersonId;
                dbEntry.NameContact = contact.NameContact;
                dbEntry.ValContact = contact.ValContact;
            }
            _cntx.SaveChanges();

        }
        public void SavePerson(Person person)
        {
            Person dbEntry = _cntx.Person.Find(person.Id);
            if (dbEntry != null)
            {
                dbEntry.Name = person.Name;
                dbEntry.BirthDate = person.BirthDate;
                dbEntry.Comment = person.Comment;
            }
            _cntx.SaveChanges();

        }

        public Person DeletePerson(int Id)
        {
            Person dbEntry = _cntx.Person.Find(Id);
            if (dbEntry != null)
            {
                _cntx.Person.Remove(dbEntry);
                var list = _cntx.Contacts.Where(x => x.PersonId == Id);
                foreach (var item in list)
                {
                    _cntx.Contacts.Remove(item);
                }


                _cntx.SaveChanges();

            }
            return dbEntry;
        }

        public Contacts DeleteContacts(int Id)
        {
            Contacts dbEntry = _cntx.Contacts.Find(Id);
            if (dbEntry != null)
            {
                _cntx.Contacts.Remove(dbEntry);
                _cntx.SaveChanges();
            }
            return dbEntry;
        }

    }
}