using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using GAPInsuranceAPI.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GAPInsuranceAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInsuranceController : ControllerBase
    {
        private IRepository<CustomerInsurance> repository = null;

        public CustomerInsuranceController(IRepository<CustomerInsurance> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerInsurance>> Get()
        {
            return Ok(this.repository.GetAll());
        }

        [HttpPost]
        public ActionResult<Insurance> Post([FromBody] CustomerInsurance value)
        {
            return Ok(this.repository.Insert(value));
        }
    }
}