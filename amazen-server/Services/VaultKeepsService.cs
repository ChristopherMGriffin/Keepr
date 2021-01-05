using System;
using System.Collections.Generic;
using amazen_server.Models;
using amazen_server.Repositories;

namespace amazen_server.Services
{
  public class VaultkeepsService
  {

    private readonly VaultkeepsRepository _vkrepo;
    private readonly VaultsRepository _vrepo;

    public VaultkeepsService(VaultkeepsRepository vkrepo, VaultsRepository vrepo)
    {
      _vkrepo = vkrepo;
      _vrepo = vrepo;
    }

    public string Create(VaultKeep newVk)
    {
      Vault v = _vrepo.GetOne(newVk.VaultId);
      if (v.creatorId == newVk.CreatorId)
      {
        newVk.Id = _vkrepo.Create(newVk);
        return "relationship created successfully";
      }
      return "this is not your vault to add to";
    }

    internal IEnumerable<Keep> GetKeepsByVaultId(int vaultId)
    {
      return _vkrepo.GetKeepsByVaultId(vaultId);
    }

    internal string Delete(int id, string userId)
    {
      VaultKeep original = _vkrepo.Get(id);
      int kId = original.KeepId;
      if (original == null) { throw new Exception("Relationship not found"); }
      if (original.CreatorId != userId)
      {
        throw new Exception("Unauthorized to delete this relationship");
      }
      if (_vkrepo.Delete(id, kId))
      {
        return "relationship deleted succesfully";
      }
      return "relationship delete unsuccessful";
    }
  }
}