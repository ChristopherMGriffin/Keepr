namespace amazen_server.Models
{
  public class Keep
  {
    public int Id { get; set; }
    public string creatorId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public int Views { get; set; }
    public int Shares { get; set; }
    public int KeepCount { get; set; }
    public bool IsPrivate { get; set; }
    public Profile Creator { get; set; }
  }

  public class VaultKeepViewModel : Keep
  {
    public int VaultKeepId { get; set; }
  }
}