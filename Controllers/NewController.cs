using WebApplication1.data;
using WebApplication1.Entities;
using WebApplication1.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;
    [ApiController]
    [Route("api/new")]
    public class NewController :Controller
    {
        private readonly ApplicationDbContext _context;

        public NewController (ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("Add")]

        public IActionResult AddUser([FromBody] InsertUserDtos userDto)
        {
            try
            {
                var user = new User {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Gender = userDto.Gender,
                    ImageURL = userDto.ImageURL,
                    RegisterDate = userDto.RegisterDate,
                    IsActive = true
                };

                _context.Users.Add(user);

                _context.SaveChanges();

                return Ok("Users Added Successfully");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
