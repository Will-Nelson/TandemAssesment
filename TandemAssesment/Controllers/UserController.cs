using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

using TandemAssesment.Interface;
using TandemAssesment.Model;
using TandemAssesment.Utility;
using TandemAssesment.Validation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TandemAssesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryService _repositoryService;
        private readonly IValidator _uservalidation;
        
        public UserController(IRepositoryService repositoryService, IValidator<UserSaveModel> userValidator)
        {
            _repositoryService = repositoryService;
            _uservalidation = userValidator;
            
        }


        // GET api/<User>/5
        [HttpGet("{email}")]
        public async Task<ActionResult> Get(string email)
        {
            if (!EmailValidation.IsValidEmail(email))
            { 
                return BadRequest("Invalid search submission");
            }
            var user = await _repositoryService.GetUserAsync(email);
            return user != null ? Ok (user) : (ActionResult)NotFound();
        }

        // POST api/<User>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserSaveModel user)
        {
            var context = new ValidationContext<UserSaveModel>(user);
            var validationResult = _uservalidation.Validate(context); 
            if (!validationResult.IsValid)
            {
                return BadRequest("Invalid user submission");
            }
            return Ok(await _repositoryService.AddUserAsync(user));
        }

       
    }
}
