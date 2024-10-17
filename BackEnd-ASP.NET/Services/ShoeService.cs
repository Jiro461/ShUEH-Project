using BackEnd_ASP_NET.Models;
using Microsoft.AspNetCore.Mvc;
using BackEnd_ASP.NET.Data;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_ASP.NET.Services
{
    public class ShoeService : ControllerBase, IShoeService
    {
        private readonly IShoeRepository shoeRepository;
        private readonly ShUEHContext context;

        public ShoeService(IShoeRepository shoeRepository, ShUEHContext context)
        {
            this.shoeRepository = shoeRepository;
            this.context = context;
        }

        public async Task<ICollection<Shoe>> GetAllShoesAsync()
        {
            var shoes = await shoeRepository.GetAllShoesAsync();
            return shoes.ToList();
        }

        public async Task<IActionResult> GetShoeByIdAsync(Guid id)
        {
            var shoe = await shoeRepository.GetShoeByIdAsync(id);
            if (shoe == null)
                return NotFound($"Shoe with ID {id} not found.");
            return Ok(shoe);
        }

        public async Task<IActionResult> AddShoeAsync(Shoe shoe)
        {
            if (shoe == null)
                return BadRequest("Shoe data is required.");

            await shoeRepository.AddShoeAsync(shoe);
            return CreatedAtAction(nameof(GetShoeByIdAsync), new { id = shoe.Id }, shoe);
        }

        public async Task<IActionResult> UpdateShoeAsync(Guid shoeId, Shoe updateShoe)
        {
            var existingShoe = await shoeRepository.GetShoeByIdAsync(shoeId);
            if (existingShoe == null)
                return NotFound($"Shoe with ID {shoeId} not found.");
            existingShoe = updateShoe;
            await shoeRepository.UpdateShoeAsync(existingShoe);
            return Ok("Shoe updated successfully");
        }

        public async Task<IActionResult> DeleteShoeAsync(Guid id)
        {
            var result = await shoeRepository.DeleteShoeAsync(id);
            if (!result)
                return NotFound($"Shoe with ID {id} not found.");
            return Ok("Shoe deleted successfully");
        }
    }
}
