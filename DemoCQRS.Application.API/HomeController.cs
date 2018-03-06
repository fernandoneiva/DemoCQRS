using DemoCQRS.Application.Core.CommandStack;
using MediatR;
using System.Collections.Generic;
using System.Web.Http;

namespace DemoCQRS.Application.API
{
    public class HomeController : ApiController
    {
        IMediator mediator;
        public HomeController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        // GET api/values 
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5 
        public string Get(int id)
        {
            mediator.Send(new SalvarFaturaCommand());

            return "value";
        }

        // POST api/values 
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
        }
    }
}