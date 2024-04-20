using APBD_REST_BD.Models;
using APBD_REST_BD.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APBD_REST_BD.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalController: ControllerBase
{

    private IAnimalRepository _animalRepository;

    public AnimalController(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    [HttpGet]
    public IActionResult GetAnimals([FromQuery] string orderBy = "Name")
    {
        var animals = _animalRepository.GetAnimals(orderBy);
        return Ok(animals);
    }
    
    
    [HttpPost]
    public IActionResult AddAnimal([FromBody] Animal animal)
    {
         _animalRepository.AddAnimal(animal);
         return Created("/api/animals", null);
    }
    
    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, [FromBody] Animal animal)
    {
        _animalRepository.UpdateAnimal(id, animal);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        _animalRepository.DeleteAnimal(id);
        return NoContent();
    }
    


}