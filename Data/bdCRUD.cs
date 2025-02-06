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

            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO Pet (Name, Color, Size, Sex, Years, Status, DateofEntry, Image) " +
            "VALUES ('" + pet.Name + "', '" + pet.Color + "', '" + pet.Size + "', '" + pet.Sex + "', " +
            pet.Years + ", " + pet.Status + ", '" + pet.DateOfEntry.ToString("yyyy-MM-dd") + "', " +
            "decode('" + BitConverter.ToString(pet.Image).Replace("-", "") + "', 'hex'))", actualConnection);

            cmd.ExecuteNonQuery();
        }

        public void updatePet(objPet pet)
{
    connection connection = new connection();
    NpgsqlConnection actualConnection = connection.ConexionBD();

    NpgsqlCommand cmd = new NpgsqlCommand("UPDATE Pet SET " +
    "Name = '" + pet.Name + "', " +
    "Color = '" + pet.Color + "', " +
    "Size = '" + pet.Size + "', " +
    "Sex = '" + pet.Sex + "', " +
    "Years = " + pet.Years + ", " +
    "Status = " + pet.Status + ", " +
    "DateofEntry = '" + pet.DateOfEntry.ToString("yyyy-MM-dd") + "', " +
    "Image = decode('" + BitConverter.ToString(pet.Image).Replace("-", "") + "', 'hex') " +
    "WHERE Id = " + pet.Id, actualConnection);

    cmd.ExecuteNonQuery();
}


    }
}

