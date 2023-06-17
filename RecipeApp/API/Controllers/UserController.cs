using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.API.Models.Update;
using RecipeApp.Application.Common;
using RecipeApp.Application.ViewModel.UserViewModel;
using RecipeApp.Domain.Entities;

namespace RecipeApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    
    public UserController(UserManager<User> userManager)
    {
        this._userManager = userManager;
    }
    
    [HttpGet]
    [Authorize]
    [Route("get-user")]
    public async Task<IActionResult> GetUser()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userId == null) 
        {
            return StatusCode(StatusCodes.Status500InternalServerError, 
                new Response("Error", "An error occurred while processing your request"));
        }
        
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) 
        {
            return StatusCode(StatusCodes.Status404NotFound, 
                new Response("Error", "User not found"));
        }

        // map to view model
        var userViewModel = new UserViewModel
        {
            UserName = user.UserName!,
            Email = user.Email!
        };

        return Ok(new Response("Success", "User found", userViewModel));
    }
    
    [HttpPut]
    [Authorize]
    [Route("update-user")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserModel model)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userId == null) 
        {
            return StatusCode(StatusCodes.Status500InternalServerError, 
                new Response("Error", "An error occurred while processing your request"));
        }
    
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) 
        {
            return StatusCode(StatusCodes.Status404NotFound, 
                new Response("Error", "User not found"));
        }

        // update user
        user.UserName = model.UserName;
        user.Email = model.Email;

        var result = await _userManager.UpdateAsync(user);
        if(result.Succeeded)
        {
            return Ok(new Response("Success", "User updated successfully"));
        }

        return StatusCode(StatusCodes.Status500InternalServerError, 
            new Response("Error", "An error occurred while updating the user"));
    }

    [HttpDelete]
    [Authorize]
    [Route("delete-profile")]
    public async Task<IActionResult> DeleteProfile()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userId == null) 
        {
            return StatusCode(StatusCodes.Status500InternalServerError, 
                new Response("Error", "An error occurred while processing your request"));
        }
    
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) 
        {
            return StatusCode(StatusCodes.Status404NotFound, 
                new Response("Error", "User not found"));
        }

        // delete user
        var result = await _userManager.DeleteAsync(user);
        if(result.Succeeded)
        {
            return Ok(new Response("Success", "User deleted successfully"));
        }

        return StatusCode(StatusCodes.Status500InternalServerError, 
            new Response("Error", "An error occurred while deleting the user"));
    }
}

