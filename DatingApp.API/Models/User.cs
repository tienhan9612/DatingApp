namespace DatingApp.API.Models
{
    public class User
    {
        public int Id {get;set;}
        public string UserName {get;set;}
        public byte[] PassWordHash {get;set;}
        public byte[] PassWordSalt {get;set;}
    }
}