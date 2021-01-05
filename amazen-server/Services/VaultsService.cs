using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using amazen_server.Repositories;
using amazen_server.Models;
using System.Linq;

namespace amazen_server.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;

    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Vault> Get()
    {
      return _repo.Get();
    }

    public Vault GetOne(int id, string userId)
    {
     Vault vault = _repo.GetOne(id);
      if (vault == null)
      {
        throw new Exception("Vault not Found");
      }
      if (!vault.IsPublished && vault.creatorId != userId )
      {
        throw new Exception("This Vault is Private");
      }
      return vault;
    }

    public Vault Create(Vault newVault)
    {
      newVault.Id = _repo.Create(newVault);
      return newVault;
    }

    public string Delete(int id, string userId)
    {
      Vault vault = _repo.GetOne(id);
      if (vault == null)
      {
        throw new Exception("Vault not found");
      }
      if (vault.creatorId != userId)
      {
        throw new Exception("Unauthorized Action");
      }
      if (_repo.Delete(id))
      {
        return "Deleted Vault";
      }
      return "Delete Unsuccessful";
    }

    internal Vault Edit(Vault vault, string userId)
    {
      Vault original = _repo.GetOne(vault.Id);
      if (original == null)
      {
        throw new Exception("Invalid Id");
      }
      if (original.creatorId != userId)
      {
        throw new Exception("Unauthorized");
      }
      _repo.Edit(vault);
      return _repo.GetOne(vault.Id);
    }

   

    internal IEnumerable<Vault> GetVaultsByProfile(string pId, string uId)
    {
      return _repo.GetVaultsByProfile(pId).ToList().FindAll(v => v.creatorId == uId || v.IsPublished);
    }
  }
}