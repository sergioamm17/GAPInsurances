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
    public class InsuranceCoverageTypeController : ControllerBase
    {
        private IRepository<InsuranceCoverageType> repository = null;

        public InsuranceCoverageTypeController(IRepository<InsuranceCoverageType> repository)
        {
            this.repository = repository;
        }

        [HttpGet("{id}")]
        public ActionResult<InsuranceCoverageType> Get(int id)
        {
            return Ok(this.repository.GetById(id));
        }

        [HttpPost]
        public ActionResult<InsuranceCoverageType> Post([FromBody] InsuranceCoverageType value)
        {
            return Ok(this.repository.Insert(value));
        }
    }
}