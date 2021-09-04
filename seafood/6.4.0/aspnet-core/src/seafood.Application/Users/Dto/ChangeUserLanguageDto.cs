using System.ComponentModel.DataAnnotations;

namespace seafood.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}