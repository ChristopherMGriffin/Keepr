using System.Collections.Generic;
using System.Data;
using Dapper;
using amazen_server.Models;

namespace amazen_server.Repositories
{
  public class VaultkeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultkeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public int Create(VaultKeep newVk)
    {
      var kId = newVk.KeepId;
      string sql1 = "UPDATE keepstable SET keeps = keeps + 1 WHERE @kId = id";
      _db.Execute(sql1, new { kId });
      string sql = @"
        INSERT INTO vaultkeeps
        (vaultId, keepId, creatorId)
        VALUES
        (@VaultId, @KeepId, @CreatorId);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newVk);
    }

    internal IEnumerable<Keep> GetKeepsByVaultId(int vaultId)
    {
      string sql = @"
        SELECT keep.*,
        vk.id as VaultKeepId,
        profile.*
        FROM vaultkeeps vk
        JOIN keepstable keep ON keep.id = vk.keepId
        JOIN profiles profile ON profile.id = keep.creatorId
        WHERE vaultId = @VaultId;";
      return _db.Query<VaultKeepViewModel, Profile, VaultKeepViewModel>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, new { vaultId }, splitOn: "id");
    }

    internal bool Delete(int kvId, int kId)
    {
      string sql1 = "UPDATE keepstable SET keeps = keeps - 1 WHERE @kId = id";
      _db.Execute(sql1, new { kId });
      string sql = "DELETE from vaultkeeps WHERE id = @kvId";
      int valid = _db.Execute(sql, new { kvId });
      return valid > 0;
    }

    internal VaultKeep Get(int id)
    {
      string sql = @"SELECT * from vaultkeeps WHERE id = @id";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
    }
  }
}