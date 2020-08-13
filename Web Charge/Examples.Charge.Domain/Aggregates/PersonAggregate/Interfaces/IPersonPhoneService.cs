using Examples.Charge.Domain.Aggregates.Model;
using Examples.Charge.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneService
    {
        Task<List<PersonPhone>> FindAllAsync();
        Task<List<PersonPhoneViewModel>> GetListPersonPhoneAsync(int id);
        Task<string> InsertPhoneNumberAsync(InsertPersonPhoneViewModel model);
        Task<string> EditPhoneNumberAsync(string oldNumber ,EditPersonPhoneViewModel model);
        Task<string> DeletePhoneNumberAsync(int personId, string number, int phoneNumberTypeId);
    }
}
