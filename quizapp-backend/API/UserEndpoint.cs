﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quizapp_backend.Database;
using quizapp_backend.Models.AuthModels;
using quizapp_backend.Models.DataTransferObjects;
using quizapp_backend.Models.ScoreModels;
using quizapp_backend.Models.UserModels;
using quizapp_backend.Services.DtoManagers;

namespace quizapp_backend.API
{
    [ApiController]
    [Route("/User")]
    public class UsersEndpoint : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DatabaseContext _context;
        private readonly TokenService _tokenService;

        public UsersEndpoint(UserManager<ApplicationUser> userManager, DatabaseContext context,
            TokenService tokenService, ILogger<UsersEndpoint> logger)
        {
            _userManager = userManager;
            _context = context;
            _tokenService = tokenService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetAll()
        {
            var users = await _userManager.Users.ToListAsync();

            ICollection<UserOutput> usersOutput = UserDtoManager.Convert(users);
            Payload<ICollection<UserOutput>> payload = new Payload<ICollection<UserOutput>>(usersOutput);
            return Ok(usersOutput);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ApplicationUser>> Get(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            UserOutput userOutput = UserDtoManager.Convert(user);
            Payload<UserOutput> payload = new Payload<UserOutput>(userOutput);
            return Ok(payload);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegistrationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userManager.CreateAsync(
                new ApplicationUser { UserName = request.Username, Email = request.Email, Role = request.Role },
                request.Password!
            );

            if (result.Succeeded)
            {
                request.Password = "";
                return CreatedAtAction(nameof(Register), new { email = request.Email, role = Role.User }, request);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var managedUser = await _userManager.FindByEmailAsync(request.Email!);

            if (managedUser == null)
            {
                return BadRequest("Bad credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password!);

            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }

            ApplicationUser? userInDb = _context.Users.FirstOrDefault(u => u.Email == request.Email);

            if (userInDb is null)
            {
                return Unauthorized();
            }

            var accessToken = _tokenService.CreateToken(userInDb);
            await _context.SaveChangesAsync();

            return Ok(new AuthResponse
            {
                Id = userInDb.Id,
                Username = userInDb.UserName,
                Email = userInDb.Email,
                Role = userInDb.Role,
                Token = accessToken,
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return NoContent();
        }

        //[HttpGet]
        //[Route("{userId}/Score/{quizId}")]
        //public async Task<ActionResult<UserScore>> QuizResult(string userId, int quizId)
        //{
        //    ApplicationUser? userInDb = _context.Users.FirstOrDefault(u => u.id == userId);
        //    if (userInDb is null)
        //        return Unauthorized();

        //    var quiz = await _context.Quizzes.FindAsync(quizId);

        //    return Ok(new UserScore
        //    {
        //        UserId = userInDb.Id,
        //        QuizId = quizId,
        //        Score = 0,
        //        HighestPossibleScore = 0,
        //        Correct = 0,
        //        Wrong = 0
        //    });
        //}
    }
}
