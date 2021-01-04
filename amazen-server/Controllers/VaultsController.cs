using System.Collections.Generic;
using amazen_server.Models;
using amazen_server.Services;
using Microsoft.AspNetCore.Mvc;
using CodeWorks.Auth0Provider;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace amazen_server.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _vs;
    // private readonly VaultKeepsService _vks; VaultKeepsService vks

    public VaultsController(VaultsService vs)
    {
      _vs = vs;
      // _vks = vks;
    }

    [HttpGet]
    [Authorize]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      try
      {
        return Ok(_vs.Get());
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Vault> GetOne(int id)
    {
      try
      {
        return Ok(_vs.GetOne(id));
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpGet("{vaultId}/vaultkeeps")]
    [Authorize]
    public ActionResult<IEnumerable<Keep>> Get(int vaultId)
    {
      try
      {
        // return Ok(_vks.GetKeepsByVaultId(vaultId))
        return null;
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Vault>> Create([FromBody] Vault newVault)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newVault.creatorId = userInfo.Id;
        Vault created = _vs.Create(newVault);
        created.Creator = userInfo;
        return Ok(created);
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
        return Ok(_vs.Delete(id, userInfo.Id));
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Vault>> Edit(int id, [FromBody] Vault vault)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        vault.Id = id;
        return Ok(_vs.Edit(vault, userInfo.Id));
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }



  }

}