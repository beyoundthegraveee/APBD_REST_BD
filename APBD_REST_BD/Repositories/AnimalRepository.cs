using System.Data.SqlClient;
using APBD_REST_BD.Models;

namespace APBD_REST_BD.Repositories;

public class AnimalRepository : IAnimalRepository
{

    private IConfiguration _configuration;

    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    
    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        using var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = $"SELECT * FROM ANIMAL ORDER BY {orderBy} ASC ;";

        var dr = cmd.ExecuteReader();
        var animals = new List<Animal>();
        while (dr.Read())
        {
            animals.Add(new Animal()
            {
                IdAnimal = (int)dr["IdAnimal"],
                Name = (string)dr["Name"],
                Description = (string)dr["Description"],
                Category = (string)dr["Category"],
                Area = (string)dr["Area"]
            });

        }

        return animals;


    }

    public void AddAnimal(Animal animal)
    {
        using var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = $"INSERT INTO ANIMAL VALUES(@Name, @Description, @Category,@Area);";
        cmd.Parameters.AddWithValue("Name", animal.Name);
        cmd.Parameters.AddWithValue("Description", animal.Description);
        cmd.Parameters.AddWithValue("Category", animal.Category);
        cmd.Parameters.AddWithValue("Area", animal.Area);
        
        cmd.ExecuteNonQuery();
        
    }

    public void UpdateAnimal(int id, Animal animal)
    {
        using var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "UPDATE Animal SET Name=@Name, Description=@Description, Category=@Category, Area=@Area WHERE IdAnimal = @idAnimal";
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);
        cmd.Parameters.AddWithValue("@idAnimal", id);
        cmd.ExecuteNonQuery();
        
    }

    public void DeleteAnimal(int id)
    {
        using var con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE FROM Animal WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", id);
        cmd.ExecuteNonQuery();

    }
}