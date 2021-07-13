namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; } // hashed pw returns a byte array

        public byte[] PasswordSalt { get; set; }

    }
}