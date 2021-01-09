using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using amazen_server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using amazen_server.Services;

namespace amazen_server.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultkeepsController : ControllerBase
  {
    private readonly VaultkeepsService _vks;

    public VaultkeepsController(VaultkeepsService vks)
    {
      _vks = vks;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<VaultKeep>> Create([FromBody] VaultKeep newVk)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newVk.CreatorId = userInfo.Id;
        return Ok(_vks.Create(newVk));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_vks.Delete(id, userInfo.Id));
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);

      }
    }

  }
}