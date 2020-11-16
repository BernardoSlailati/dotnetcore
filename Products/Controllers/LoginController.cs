using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.Dtos;
using Products.Models;

namespace Products.Controllers
{
    [Route("api")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly ProductsDBContext _context;

        private readonly IMapper _mapper;
        
        public LoginController(ProductsDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(User loginUser)
        {   
            if (await _context.Users.AnyAsync(user => user.Email == loginUser.Email && user.Password == loginUser.Password)) {
                return Ok();
            };

            return NotFound();
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(User registerUser)
        {
            await _context.Users.AddAsync(registerUser);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}