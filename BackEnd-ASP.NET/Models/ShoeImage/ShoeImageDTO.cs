using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace BackEnd_ASP_NET.Models
{
    public class ShoeImageDTO
    {
        public IFormFile? Url { get; set; }

    }
}