using System;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Webapi.TokenOperations.Models;
using WebApi.Application.CustomerOperations.Commands.CreateCustomer;
using WebApi.Application.CustomerOperations.Commands.CreateToken;
using WebApi.Application.CustomerOperations.Commands.DeleteCustomer;
using WebApi.Application.CustomerOperations.Commands.RefreshToken;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class CustomerController:ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        private readonly IConfiguration _configuration;
        public CustomerController(MovieStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
           _context = context;
           _mapper = mapper;
           _configuration = configuration;
        }   

        [HttpPost]
        public IActionResult CreateCustomer(CreateCustomerModel newCustomer)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_context,_mapper);
            command.Model = newCustomer;
            CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
             DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
             command.CustomerId = id;
             DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
             validator.ValidateAndThrow(command);
             command.Handle();
             return Ok();
        }

        //---For the authentication operations;
        [HttpPost("connect/token")] //iki tane post islemi oldugundan, birisini ornegin parametre yollayip  ozellestirmezsen iki tane ayni HTTP metodu endpointlere kullanildigindan hata verir. 
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_context, _configuration, _mapper);
            command.Model = login;
            var token = command.Handle();
            return token;
        }

        //**Access token alindiginda onunla birlikte olusturulan refresh token araciligiyla mevcut access token'i refresh
        //etmek icin kullanilacak endpoint;
        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken([FromQuery] string token)
        {
            RefreshTokenCommand command = new RefreshTokenCommand(_context, _configuration);
            command.RefreshToken = token;
            var resultToken = command.Handle();
            return resultToken;
        }
    }
}