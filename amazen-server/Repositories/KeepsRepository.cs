using System;
using System.Collections.Generic;
using System.Data;
using amazen_server.Models;
using Dapper;

namespace amazen_server.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db =db;
    }

    public int Create(Keep newKeep)
    {
      string sql = @"
      INSERT INTO keepstable
      (name, description, img, creatorId)
      VALUES
      (@Name, @Description, @Img, @CreatorId)";
      return _db.ExecuteScalar<int>(sql, newKeep);
    }
    public IEnumerable<Keep> Get()
    {
      string sql =  "SELECT keep.*, profile.* FROM keepstable keep INNER JOIN profiles profile ON keep.creatorId = profile.id";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, splitOn: "id");
    }
    
    internal Keep GetOne(int id)
    {
      string sql1 = "UPDATE keepstable SET views = views + 1 WHERE id = @Id";
      _db.Execute(sql1, new { id });
      string sql = "SELECT * FROM keepstable WHERE id = @Id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }
    
    internal Keep GetEdit(int id)
    {
      string sql = "SELECT * FROM keepstable WHERE id = @Id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }
    internal bool Delete(int id)
    {
      string sql = "DELETE FROM keepstable WHERE id = @id";
      int valid = _db.Execute(sql, new { id });
      return valid > 0;
    }

    internal IEnumerable<Keep> GetKeepsByProfile(string pId)
    {
      string sql = @"
      SELECT keep.*, p.* FROM  keepstable keep Join profiles p ON keep.creatorId = p.id
      WHERE keep.creatorId = @pId;";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, new { pId }, splitOn: "id");
    }

    internal void Edit(Keep keep)
    {
      string sql = @"
     UPDATE keepstable
     SET
     name = @Name,
     description = @Description,
     img = @Img
     Where id = @Id;";
      _db.Execute(sql, keep);
    }
  }
}