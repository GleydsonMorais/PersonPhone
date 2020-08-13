using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examples.Charge.Domain.Aggregates.Model;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonPhoneController : ControllerBase
    {
        private readonly IPersonPhoneService _personPhoneService;

        public PersonPhoneController(IPersonPhoneService personPhoneService)
        {
            _personPhoneService = personPhoneService;
        }

        //// GET: api/PersonPhone
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/PersonPhone/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IList<PersonPhoneViewModel>> Get(int id) => await _personPhoneService.GetListPersonPhoneAsync(id);

        // POST: api/PersonPhone
        [HttpPost]
        public async Task<string> Post([FromBody] InsertPersonPhoneViewModel model) => await _personPhoneService.InsertPhoneNumberAsync(model);

        // PUT: api/PersonPhone/5
        [HttpPut("{oldNumber}")]
        public async Task<string> Put(string oldNumber, [FromBody] EditPersonPhoneViewModel model) => await _personPhoneService.EditPhoneNumberAsync(oldNumber, model);

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
