using CarDealership.Models.Interfaces;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.InMemoryIntegration
{
    public class ContactRepositoryQA : IContactRepository
    {
        private List<Contact> _contacts = new List<Contact>()
        {
            new Contact()
            {
                ContactId = 0,
                Name = "Jane Doe",
                Email = "janedoe@example.com",
                Phone = "5551234567",
                Message = "I would like to negotiate the price for this Acura Integra"
            }
        };

        public Contact GetById(int id)
        {
            return _contacts.Where(m => m.ContactId == id).FirstOrDefault();
        }

        public void Insert(Contact contact)
        {
            _contacts.Add(contact);
        }
    }
}
