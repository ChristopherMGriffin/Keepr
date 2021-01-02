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
      INSERT INTO keeps
      (name, description, image, views, shares, creatorId, keepCount)
      VALUES
      (@Name, @Description, @Image, @Views, @Shares, @CreatorId, @KeepCount)";
      return _db.ExecuteScalar<int>(sql, newKeep);
    }
    public IEnumerable<Keep> Get()
    {
      string sql =  "SELECT keep.*, profile.* FROM keeps keep INNER JOIN profiles profile ON keep.creatorId = profile.id";
      return _db.Query<Keep, Profile, Keep>(sql, (product, profile) => { product.Creator = profile; return product; }, splitOn: "id");
    }
    
    internal Keep GetOne(int id)
    {
      string sql1 = "UPDATE keeps SET views = views + 1";
      _db.Execute(sql1, new { id });
      string sql = "SELECT * FROM keeps WHERE id = @Id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }
    internal bool Delete(int id)
    {
      string sql = "DELETE FROM keeps WHERE id = @id";
      int valid = _db.Execute(sql, new { id });
      return valid > 0;
    }
  }
}