﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            int rowsAffected = cmd.ExecuteNonQuery();
            MessageBox.Show("Filas afectadas: " + rowsAffected); // Depuración

            if (rowsAffected == 0)
            {
                MessageBox.Show("No se modificó ninguna fila. Verifica si el ID existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void insert_PetLikes(int pet_Id)
        {
            int likes = 0;

            connection connection = new connection();
            NpgsqlConnection actualConnection = connection.ConexionBD();
            NpgsqlCommand cmd = new NpgsqlCommand("Select Likes from Pet_Likes where Pet_Id =" + pet_Id, actualConnection);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                // Si existe, obtener el valor actual y actualizarlo
                if (dr.Read())
                {
                    likes = dr.GetInt32(0); // Obtiene el valor actual de likes
                }
                dr.Close();

                likes++;

                cmd = new NpgsqlCommand("UPDATE Pet_Likes SET Likes = " + likes + " WHERE Pet_Id = " + pet_Id, actualConnection);
                cmd.ExecuteNonQuery();
            }
            else
            {
                // Si no existe, hacer un INSERT con likes = 1
                dr.Close();
                cmd = new NpgsqlCommand("INSERT INTO Pet_Likes (Pet_Id, Likes) VALUES (" + pet_Id + ", 1)", actualConnection);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Has dado un like!");
            actualConnection.Close();
        }

    }
}

