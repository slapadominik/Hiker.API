using System.ComponentModel.DataAnnotations;

namespace Hiker.Application.Features.Account.DTO
{
    public class FacebookLogin
    {
        [Required]
        [StringLength(255)]
        public string FacebookToken { get; set; }
    }
}