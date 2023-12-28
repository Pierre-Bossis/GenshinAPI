namespace GenshinAPI.Models.User
{
    public class ConnectedUserDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public int Avatar_Id { get; set; }
    }
}
