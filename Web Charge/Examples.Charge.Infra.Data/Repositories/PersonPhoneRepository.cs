using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Domain.Model;
using Examples.Charge.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly ExampleContext _context;

        public PersonPhoneRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PersonPhone>> FindAllAsync() => await Task.Run(() => _context.PersonPhone);

        public async Task<bool> InsertAsync(PersonPhone model)
        {
            try
            {
                await _context.AddAsync(model);
                await _context.SaveChangesAsync();

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> EditAsync(PersonPhone oldPersonPhone, PersonPhone newPersonPhone)
        {
            try
            {
                _context.Remove(oldPersonPhone);
                _context.Update(newPersonPhone);
                await _context.SaveChangesAsync();

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(PersonPhone model)
        {
            try
            {
                _context.Remove(model);
                await _context.SaveChangesAsync();

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
