using Api.DataBase.Sql;
using Api.Models.DTOs;
using Api.Models.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Repositories.Users;
using AutoMapper;
using Api.CustomActionFilters;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UsersController(IUserRepository userRepository,IMapper mapper)
        {
            this.userRepository=userRepository;
            this.mapper=mapper;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var users=await userRepository.GetAllAsync();
            List<UserDto> userDtos = mapper.Map<List<UserDto>>(users);
            return Ok(userDtos);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var user = await userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            UserDto userDto=mapper.Map<UserDto>(user);

            return Ok(userDto);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] RegisterRequestDto createUserDto) 
        {
            var user=mapper.Map<User>(createUserDto);
            user.createdDate = DateTime.Now;
            user.lastPlayDate = DateTime.Now;


            await userRepository.CreateUserAsync(user);

            var userDto =mapper.Map<UserDto>(user);
            return CreatedAtAction(nameof(GetById), new {id=userDto.id}, userDto);
        
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody]UpdateUserDto updateUserDto) 
        {
            var user = await userRepository.UpdateUserAsync(id, updateUserDto);
            if (user == null)
            {
                return NotFound();
            }
            var userDto = mapper.Map<UserDto>(user);
            return Ok(userDto);

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var user = await userRepository.DeleteUserAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
