using System;
using System.Collections.Generic;
using System.Linq;
using amazen_server.Models;
using amazen_server.Repositories;

namespace amazen_server.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;

    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }

    public Keep Create(Keep newKeep)
    {
      newKeep.Id = _repo.Create(newKeep);
      return newKeep;
    }
    public IEnumerable<Keep> Get()
    {
      return _repo.Get();
    }
    public Keep GetOne(int id)
    {
      return _repo.GetOne(id);
    }
    public string Delete(int id, string userId)
    {
      Keep keep =_repo.GetEdit(id);
      if (keep == null)
      {
        throw new Exception("Keep not found");
      }
      if (keep.creatorId != userId)
      {
      throw new Exception("Unauthorized Action");
      }
      if (_repo.Delete(id))
      {
        return "Keep Deleted";
      }
      return "Delete Unsuccessful";
    }
      internal Keep Edit(Keep keep, string userId)
    {
      Keep original = _repo.GetEdit(keep.Id);
      if (original == null)
      {
        throw new Exception("Invalid Keep");
      }
      if (original.creatorId != userId)
      {
        throw new Exception("Unauthorized");
      }
      _repo.Edit(keep);
      return _repo.GetEdit(keep.Id);
    }

    internal IEnumerable<Keep> GetKeepsByProfile(string pId, string uId)
    {
      return _repo.GetKeepsByProfile(pId).ToList().FindAll(k => k.creatorId == uId || !k.IsPrivate);
    }
  }
}