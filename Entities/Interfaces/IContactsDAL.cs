using Entities.Models;

namespace Entities.Interfaces
{
    public interface IContactsDAL
    {
        Task<List<Contact>> GetContactsAsync();
        Task<Contact?> GetContactByIdAsync(Guid id);
        Task AddContactAsync(Contact contact);
        Task UpdateContactAsync(Contact contact);
        Task DeleteContactAsync(Guid id);
    }
}
