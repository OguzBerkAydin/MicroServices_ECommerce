using ECommerce.IdentityServer.Dtos;
using ECommerce.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Duende.IdentityServer.IdentityServerConstants;

namespace ECommerce.IdentityServer.Controllers
{
	[Authorize(LocalApi.PolicyName)]
	[Route("api/[controller]")]
	[ApiController]
	public class RegistersController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public RegistersController(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpPost]
		public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
		{
			var value = new ApplicationUser()
			{
				UserName = userRegisterDto.UserName,
				Email = userRegisterDto.Email,
				Name = userRegisterDto.Name,
				Surname = userRegisterDto.Surname,
			};

			var result = await _userManager.CreateAsync(value, userRegisterDto.Password);
			if (result.Succeeded)
			{
				return Ok("User Registered Successfuly");
			}
			return BadRequest("Failed");
		}
	}
}
