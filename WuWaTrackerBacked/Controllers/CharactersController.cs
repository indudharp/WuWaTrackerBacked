using Microsoft.AspNetCore.Mvc;
using WuWaTrackerBackend.Models;

namespace WuWaTrackerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private static List<Character> characters = new List<Character>
        {
            // We set some to 'true' and some to 'false' to test the visual difference
            new Character { Id = 1, Name = "Jinhsi", Element = "Spectro", Weapon = "Broadblade", ImageUrl = "/jinhsi.png", Description = "The Magistrate of Jinzhou.", IsObtained = true },
            new Character { Id = 2, Name = "Changli", Element = "Fusion", Weapon = "Sword", ImageUrl = "/changli.png", Description = "Counselor to the Magistrate.", IsObtained = false },
            new Character { Id = 3, Name = "Jiyan", Element = "Aero", Weapon = "Broadblade", ImageUrl = "/jiyan.png", Description = "General of the Midnight Rangers.", IsObtained = true },
            new Character { Id = 4, Name = "Yinlin", Element = "Electro", Weapon = "Rectifier", ImageUrl = "/yinlin.png", Description = "A natural born investigator.", IsObtained = false },
            new Character { Id = 5, Name = "Calcharo", Element = "Electro", Weapon = "Broadblade", ImageUrl = "/calcharo.png", Description = "Leader of the Ghost Hounds.", IsObtained = false },
            new Character { Id = 6, Name = "Verina", Element = "Spectro", Weapon = "Rectifier", ImageUrl = "/verina.png", Description = "A humble botanist.", IsObtained = true },
            new Character { Id = 7, Name = "Encore", Element = "Fusion", Weapon = "Rectifier", ImageUrl = "/encore.png", Description = "A girl accompanied by two wooly plushies.", IsObtained = false },
            new Character { Id = 8, Name = "Rover", Element = "Spectro", Weapon = "Sword", ImageUrl = "/rover.png", Description = "The awakener.", IsObtained = true }
        };

        // GET: Read Data
        [HttpGet]
        public ActionResult<List<Character>> GetAllCharacters()
        {
            return Ok(characters);
        }

        // POST: Create Data (Summon)
        [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character newChar)
        {
            int newId = characters.Count > 0 ? characters.Max(c => c.Id) + 1 : 1;
            newChar.Id = newId;
            // Default new summons to 'true' (Obtained)
            newChar.IsObtained = true;
            characters.Add(newChar);
            return Ok(characters);
        }

        // PUT: Update Data (Checkbox Toggle) -- NEW!
        [HttpPut("{id}")]
        public ActionResult<List<Character>> UpdateCharacter(int id, Character updatedChar)
        {
            // 1. Find the character in our list
            var charToUpdate = characters.FirstOrDefault(c => c.Id == id);

            if (charToUpdate == null) return NotFound();

            // 2. Update the "IsObtained" status
            charToUpdate.IsObtained = updatedChar.IsObtained;

            // 3. Return the fresh list so the UI updates instantly
            return Ok(characters);
        }
    }
}