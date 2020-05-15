using BizzPo.Core.Infrastructure.Repository.InMemory;
using HiPages.Domain.Contacts;

namespace HiPages.Infrastructure.Repositories
{
    //do your own implementation of IRepository<T>
    //or you can inherit / use from
    //BizzPo.Core.Infrastructure.Repository.InMemory.InMemoryRepository
    public class InMemoryContactRepository : InMemoryRepository<Contact>
    {
    }
}