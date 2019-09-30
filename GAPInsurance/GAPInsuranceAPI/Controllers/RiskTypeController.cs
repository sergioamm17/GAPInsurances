using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using GAPInsuranceAPI.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GAPInsuranceAPI.Controllers
{
    [EnableCors("CorsPolicy")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class RiskTypeController : ControllerBase
    {
        private IRepository<RiskType> repository = null;

        public RiskTypeController(IRepository<RiskType> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RiskType>> Get()
        {
            return Ok(this.repository.GetAll());
        }


    }
}