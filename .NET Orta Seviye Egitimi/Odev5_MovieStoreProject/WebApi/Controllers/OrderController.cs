using System;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.OrderOperations.Commands.CreateOrder;
using WebApi.Application.OrderOperations.Commands.DeleteOrder;
using WebApi.Application.OrderOperations.Queries.GetOrders;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
    [Authorize] //token alabilen user(authenticated user) request'i karsisinda response abilir, aksi halde hata verir.
    [ApiController]
    [Route("[controller]s")]
    public class OrderController:ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public OrderController(MovieStoreDbContext context, IMapper mapper)
        {
           _context = context;
           _mapper = mapper;
        }   

        [HttpGet]
        public IActionResult GetOrders()
        {
           GetOrdersQuery query = new GetOrdersQuery(_context,_mapper);
           var result = query.Handle();
           return Ok(result);
        }

        [HttpPost]
        public IActionResult AddOrder(CreateOrderModel newOrder)
        {
            CreateOrderCommand command = new CreateOrderCommand(_context,_mapper);
            command.Model = newOrder;
            CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("customerId={customerId}&filmId={filmId}")]
        public IActionResult DeleteOrder(int customerId, int filmId)
        {
            DeleteOrderCommand command = new DeleteOrderCommand(_context);
            command.CustomerId = customerId;
            command.FilmId = filmId;
            DeleteOrderCommandValidator validator = new DeleteOrderCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}