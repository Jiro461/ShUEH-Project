using System.ComponentModel.DataAnnotations;

namespace BackEnd_ASP.NET.Models.ShoeDetail
{
    public class ShoeDetailDTO
    {

	    [Required(ErrorMessage = "Size is required.")]
        public int Size { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }

    }

}