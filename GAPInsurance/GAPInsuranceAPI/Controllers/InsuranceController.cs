﻿using System;
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
    public class InsuranceController : ControllerBase
    {

        private IRepository<Insurance> repository = null;

        public InsuranceController(IRepository<Insurance> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Insurance>> Get()
        {
            return Ok(this.repository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Insurance> Get(int id)
        {
            return Ok(this.repository.GetById(id));
        }

        [HttpPost]
        public ActionResult<Insurance> Post([FromBody] Insurance value)
        {
            if (value.RiskTypeID == (int)EnumRiskType.Alto && value.CoveragePercentage > Constants.MaxPercentageHighRisk)
            {
                
                return BadRequest($"Para una poliza de alto riesgo el porcentaje de cobertra no debe superar el {Constants.MaxPercentageHighRisk}%" );
            }

            return Ok(this.repository.Insert(value));
        }

        [HttpPut("{id}")]
        public ActionResult<Insurance> Put(int id, [FromBody] Insurance value)
        {
            value.InsuranceID = id;
            return Ok(this.repository.Update(value));
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return Ok(this.repository.Delete(id));
        }

    }
}