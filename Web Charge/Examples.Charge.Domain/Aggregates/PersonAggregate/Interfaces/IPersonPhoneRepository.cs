using Examples.Charge.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneRepository
    {
        Task<IEnumerable<PersonAggregate.PersonPhone>> FindAllAsync();
        Task<bool> InsertAsync(PersonPhone model);
        Task<bool> EditAsync(PersonPhone oldPersonPhone, PersonPhone newPersonPhone);
        Task<bool> DeleteAsync(PersonPhone model);
    }
}
