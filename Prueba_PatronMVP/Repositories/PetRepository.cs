using Prueba_PatronMVP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_PatronMVP.Repositories
{
    internal class PetRepository : Conexion, IPetRepository
    {
        public void Add(PetModel petModel)
        {
            
        }

        public void Delete(int id)
        {

        }

        public void Edit(PetModel petModel)
        {
            
        }

        public IEnumerable<PetModel> GetAll()
        {
            var petList = new List<PetModel>();
            using (var connection = GetSqlConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Pet ORDER BY Pet_Id DESC";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var petModel = new PetModel();
                            petModel.Id = (int)reader[0];
                            petModel.Name = reader[1].ToString();
                            petModel.Type = reader[2].ToString();
                            petModel.Colour = reader[3].ToString();
                            petList.Add(petModel);
                        }
                    }
                }
            }
            return petList;
        }

        public IEnumerable<PetModel> GetByValue(string value)
        {
            var petList = new List<PetModel>();
            int petId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string petName = value;

            using (var connection = GetSqlConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM Pet
                                        WHERE Pet_Id = @ID OR Pet_Name LIKE @Name + '%' 
                                        ORDER BY Pet_Id DESC";

                    command.Parameters.Add("@ID", SqlDbType.Int).Value = petId;
                    command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = petName;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var petModel = new PetModel();
                            petModel.Id = (int)reader[0];
                            petModel.Name = reader[1].ToString();
                            petModel.Type = reader[2].ToString();
                            petModel.Colour = reader[3].ToString();
                            petList.Add(petModel);
                        }
                    }
                }
            }
            return petList;
        }
    }
}
