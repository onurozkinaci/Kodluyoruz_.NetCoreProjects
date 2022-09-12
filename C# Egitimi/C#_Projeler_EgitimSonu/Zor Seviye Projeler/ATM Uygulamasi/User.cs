public class User
{
   private string id;
   private string username;

   private string password;

   public User(string id, string username, string password)
   {
      this.Id = id;
      this.Username = username;
      this.Password = password;
   }
    public string Id { get => id; set => id = value; }
    public string Username { get => username; set => username = value; }
    public string Password { get => password; set => password = value; }
}