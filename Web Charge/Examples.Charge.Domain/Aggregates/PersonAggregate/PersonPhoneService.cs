using Examples.Charge.Domain.Aggregates.Model;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IPersonService _personService;
        private readonly IPersonPhoneRepository _personPhoneRepository;
        private readonly IPhoneNumberTypeService _phoneNumberTypeService;

        public PersonPhoneService(IPersonService personService,
            IPersonPhoneRepository personPhoneRepository,
            IPhoneNumberTypeService phoneNumberTypeService)
        {
            _personService = personService;
            _personPhoneRepository = personPhoneRepository;
            _phoneNumberTypeService = phoneNumberTypeService;
        }

        public async Task<List<PersonPhone>> FindAllAsync() => (await _personPhoneRepository.FindAllAsync()).ToList();

        public async Task<List<PersonPhoneViewModel>> GetListPersonPhoneAsync(int id)
        {
            var allPersonPhone = await FindAllAsync();
            return allPersonPhone.Where(x => x.BusinessEntityID == id).Select(x => 
            new PersonPhoneViewModel
            {
                Type = _phoneNumberTypeService.Find(x.PhoneNumberTypeID).Name,
                Numeber = x.PhoneNumber
            }).ToList();
        }

        public async Task<string> InsertPhoneNumberAsync(InsertPersonPhoneViewModel model)
        {
            var person = await _personService.FindAsync(model.PersonId);
            if (person != null)
            {
                var phoneNumeberType = _phoneNumberTypeService.Find(model.PhoneNumberTypeId);
                if (phoneNumeberType != null)
                {
                    if (!string.IsNullOrEmpty(model.Number))
                    {
                        var personPhone = new PersonPhone
                        {
                            BusinessEntityID = model.PersonId,
                            PhoneNumber = model.Number,
                            PhoneNumberTypeID = model.PhoneNumberTypeId
                        };

                        var result = await _personPhoneRepository.InsertAsync(personPhone);
                        if (result)
                            return "Successfully inserted";
                        else
                            return "Error, try again!";
                    }
                    else
                    {
                        return "Number field cannot be empty!";
                    }
                }
                else
                {
                    return "Number type does not exist!";
                }
            }
            else
            {
                return "Person does not exist!";
            }
        }

        public async Task<string> EditPhoneNumberAsync(string oldNumber, EditPersonPhoneViewModel model)
        {
            if (!string.IsNullOrEmpty(oldNumber))
            {
                var listPersonPhone = await _personPhoneRepository.FindAllAsync();
                var oldPersonPhone = listPersonPhone.SingleOrDefault(x => x.BusinessEntityID == model.PersonId && x.PhoneNumber == oldNumber && x.PhoneNumberTypeID == model.PhoneNumberTypeId);
                if (oldPersonPhone != null)
                {
                    var phoneNumeberType = _phoneNumberTypeService.Find(model.PhoneNumberTypeId);
                    if (phoneNumeberType != null)
                    {
                        if (!string.IsNullOrEmpty(model.Number))
                        {
                            var newPersonPhone = new PersonPhone
                            {
                                BusinessEntityID = model.PersonId,
                                PhoneNumber = model.Number,
                                PhoneNumberTypeID = model.PhoneNumberTypeId
                            };

                            var result = await _personPhoneRepository.EditAsync(oldPersonPhone, newPersonPhone);
                            if (result)
                                return "Successfully edit";
                            else
                                return "Error, try again!";
                        }
                        else
                        {
                            return "Number field cannot be empty!";
                        }
                    }
                    else
                    {
                        return "Number type does not exist!";
                    }
                }
                else
                {
                    return "Register not found!";
                }
            }
            else
            {
                return "Number field cannot be empty!";
            }
        }
    }
}
