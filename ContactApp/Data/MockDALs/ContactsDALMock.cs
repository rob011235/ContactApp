using Entities.Interfaces;
using Entities.Models;

namespace ContactApp.Data.MockDALs
{
    public class ContactsDALMock : IContactsDAL
    {
        List<Contact> contacts = new List<Contact>()
        {
            new Contact{ Id = Guid.NewGuid(), Name = "John Doe", Email = "jd@aserver.net", Phone = "123-456-7890", Message="Hello"},
            new Contact{ Id = Guid.NewGuid(), Name = "Grace Hopper", Email = "gh@aserver.net", Phone = "123-456-1234", Message="Do you know what a light second is?"},
            new Contact{ Id = Guid.NewGuid(), Name = "Bjarney Stroustrup", Email = "stroustrup@aserver.net", Phone = "123-456-4321", Message="See my latest update on C++!"},
        };
        public Task AddContactAsync(Contact contact)
        {
            contacts.Add(contact);
            return Task.CompletedTask;
        }

        public Task DeleteContactAsync(Guid id)
        {
            Contact? contact = contacts.FirstOrDefault(c => c.Id == id);
            if (contact != null)
            {
                contacts.Remove(contact);
            }
            return Task.CompletedTask;
        }

        public Task<Contact?> GetContactByIdAsync(Guid id)
        {
            return Task.FromResult(contacts.FirstOrDefault(c => c.Id == id));
        }

        public Task<List<Contact>> GetContactsAsync()
        {
            return Task.FromResult(contacts);    
        }

        public Task UpdateContactAsync(Contact contact)
        {
            var existingContact = contacts.FirstOrDefault(c => c.Id == contact.Id);
            if (existingContact != null)
            {
                existingContact.Name = contact.Name;
                existingContact.Email = contact.Email;
                existingContact.Phone = contact.Phone;
                existingContact.Message = contact.Message;
            }
            return Task.CompletedTask;
        }
    }
}
