using APBD_REST_BD.Models;

namespace APBD_REST_BD.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimals(string orderBy);

    void AddAnimal(Animal animal);

    void UpdateAnimal(int id, Animal animal);

    void DeleteAnimal(int id);

}