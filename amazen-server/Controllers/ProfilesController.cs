    using System.Threading.Tasks;
    using amazen_server.Models;
    using amazen_server.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using CodeWorks.Auth0Provider;
using System.Collections.Generic;

namespace amazen_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
    private readonly ProfilesService _ps;
    private readonly KeepsService _ks;

    public ProfileController(ProfilesService ps, KeepsService ks)
            {
            _ps = ps;
            _ks = ks;
            }

            [HttpGet]
            [Authorize]
            public async Task<ActionResult<Profile>> Get()
            {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                
                return Ok(_ps.GetOrCreateProfile(userInfo));
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
            } 
            [HttpGet("{id}")]
            [Authorize]
            public ActionResult<Profile> GetOneProfile()
            {
            try
            {
                return Ok(_ps.GetAllProfiles());
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
            } 
            [HttpGet("{id}/keeps")]   
            public async Task<ActionResult<Keep>> GetKeepsByProfile(string id)
            {
              try
              {
                  Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                  return Ok(_ks.GetKeepsByProfile(id, userInfo?.Id));
              }
              catch (System.Exception e)
              {
                  
                  return BadRequest(e.Message);
              }
            }

    }
}