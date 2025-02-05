using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Data
{
    public class bdCRUD
    {
        public void insertPet(objPet pet)
        {
            connection connection = new connection();
            NpgsqlConnection actualConnection = connection.ConexionBD();
    
            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO Pet (Name, Size, Sex, Years, Status, DateofEntry, Image) " +
            "VALUES ('" + pet.Name + "', '" + pet.Size + "', '" + pet.Sex + "', " +
            pet.Years + ", " + pet.Status + ", '" + pet.DateOfEntry.ToString("yyyy-MM-dd") + "', " +
            "'" + Convert.ToBase64String(pet.Image) + "')", actualConnection);

            cmd.ExecuteNonQuery();
        }

    }
}

