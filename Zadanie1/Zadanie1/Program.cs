using MySqlConnector;

namespace Zadanie1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Eat> eats = new List<Eat>();
            string connecting = "server=localhost;user id=voloda;password=rhenj;database=sys"; ;
            

            using (var conn = new MySqlConnection(connecting))
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                   
                    command.CommandText = "SELECT * FROM eat WHERE weight > @weight";
                    int weight = 400;
                    command.Parameters.AddWithValue("@weight",weight);
                    using (var reader = command.ExecuteReader())
                    {
                       
                        while (reader.Read())
                        {
                            eats.Add(new Eat
                            {
                                Id = reader.GetInt32(0),
                                name = reader.GetString(1),
                                weight = reader.GetInt32(2)
                            });
                        }
                    }
                }
                    
             
            }
            Console.WriteLine($"ID Name Weight");
            foreach (var a in eats)
            {
                Console.WriteLine($"{a.Id} {a.name} {a.weight}");
            }



        }
    }
}