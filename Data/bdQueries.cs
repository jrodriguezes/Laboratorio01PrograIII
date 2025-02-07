using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;


namespace Data
{
    public class bdQueries
    {
        public void queryPets(DataGridView dgv)
        {
            connection connection = new connection();
            NpgsqlConnection actualConnection = connection.ConexionBD();

            DataTable dataTable = new DataTable();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("SELECT id, name, color, size, sex, years, status, dateofentry, image FROM pet WHERE status = TRUE", actualConnection);
            adapter.Fill(dataTable);

            dgv.Rows.Clear(); // Limpia filas antes de cargar nuevas

            foreach (DataRow row in dataTable.Rows)
            {
                int rowIndex = dgv.Rows.Add(); // Agrega una nueva fila y obtiene su índice

                // Asignar el ID a la columna correspondiente
                dgv.Rows[rowIndex].Cells["ID"].Value = row["id"].ToString();
                dgv.Rows[rowIndex].Cells["Nombre"].Value = row["name"].ToString();
                dgv.Rows[rowIndex].Cells["Edad"].Value = row["years"].ToString();
                dgv.Rows[rowIndex].Cells["Fecha_Ingreso"].Value = Convert.ToDateTime(row["dateofentry"]).ToString("yyyy-MM-dd");

                // Configuración de la celda ComboBox "Color"
                DataGridViewComboBoxCell colorCell = (DataGridViewComboBoxCell)dgv.Rows[rowIndex].Cells["Color"];
                if (colorCell.Items.Contains(row["color"].ToString()))
                {
                    colorCell.Value = row["color"].ToString();
                }
                else
                {
                    colorCell.Value = colorCell.Items.Count > 0 ? colorCell.Items[0] : null; // Valor por defecto si no está en la lista
                }

                // Configuración de la celda ComboBox "Tamaño"
                DataGridViewComboBoxCell sizeCell = (DataGridViewComboBoxCell)dgv.Rows[rowIndex].Cells["Tamaño"];
                if (sizeCell.Items.Contains(row["size"].ToString()))
                {
                    sizeCell.Value = row["size"].ToString();
                }
                else
                {
                    sizeCell.Value = sizeCell.Items.Count > 0 ? sizeCell.Items[0] : null; // Valor por defecto si no está en la lista
                }

                // Configuración del CheckBox para "Sexo"
                string sex = row["sex"].ToString();
                dgv.Rows[rowIndex].Cells["Sexo"].Value = sex.Equals("Hembra", StringComparison.OrdinalIgnoreCase);

                //Cargar la imagen en la columna "Foto"
                if (row["image"] != DBNull.Value)
                {
                    byte[] imageData = (byte[])row["image"];

                    if (imageData.Length > 0) // Verificar si el array no está vacío
                    {
                        try
                        {
                            using (MemoryStream ms = new MemoryStream(imageData))
                            {
                                ms.Position = 0; // Asegurar que el stream esté en la posición inicial
                                dgv.Rows[rowIndex].Cells["Foto"].Value = Image.FromStream(ms);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al cargar la imagen: " + ex.Message);
                        }
                    }
                    else
                    {
                        dgv.Rows[rowIndex].Cells["Foto"].Value = null; // Si la imagen está vacía, mostrar celda vacía
                    }
                }
            }
            actualConnection.Close();
            }
        

        public void load_Sizes(DataGridView dgv)
        {
            connection connection = new connection();
            NpgsqlConnection actualConnection = connection.ConexionBD();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT size FROM Size", actualConnection);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            // Verificar si la columna "Tamaño" es un ComboBoxColumn
            if (dgv.Columns["Tamaño"] is DataGridViewComboBoxColumn sizeColumn)
            {
                sizeColumn.Items.Clear(); // Limpia las opciones previas antes de cargar nuevas

                while (reader.Read())
                {
                    string size = reader["size"].ToString();

                    // Agregar valores al ComboBoxColumn
                    if (!sizeColumn.Items.Contains(size))
                    {
                        sizeColumn.Items.Add(size);
                    }
                }
            }
            actualConnection.Close();
        }

        public void load_Colors(DataGridView dgv)
        {
            connection connection = new connection();
            NpgsqlConnection actualConnection = connection.ConexionBD();

            NpgsqlCommand cmd = new NpgsqlCommand("SELECT color FROM COLOR", actualConnection);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            if (dgv.Columns["Color"] is DataGridViewComboBoxColumn sizeColumn)
            {
                sizeColumn.Items.Clear(); // Limpia las opciones previas antes de cargar nuevas

                while (reader.Read())
                {
                    string color = reader["color"].ToString();

                    // Agregar valores al ComboBoxColumn
                    if (!sizeColumn.Items.Contains(color))
                    {
                        sizeColumn.Items.Add(color);
                    }
                }
            }
            actualConnection.Close();
        }

        public void load_PetInformation(DataGridView dgv, int id)
        {
            connection connection = new connection();
            NpgsqlConnection actualConnection = connection.ConexionBD();

            DataTable datatable = new DataTable();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(
    "SELECT p.id, p.name, p.color, p.size, p.sex, p.years, p.status, p.dateofentry, pl.likes " +
    "FROM Pet p " +
    "LEFT JOIN Pet_Likes pl ON p.id = pl.pet_id " +
    "WHERE p.id = " + id, actualConnection);
            adapter.Fill(datatable);
            dgv.DataSource = datatable;

        }

        public string get_NameByPetId(int petId)
        {
            string Name = "";

            connection connection = new connection();
            NpgsqlConnection actualConnection = connection.ConexionBD();

            NpgsqlCommand cmd = new NpgsqlCommand("Select name from Pet where id =" + petId,actualConnection);

            NpgsqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    Name = dr["Name"].ToString();
                }
            }
            return Name;
        }
        public void get_adoptedPets(DataGridView dgv)
        {
            connection connection = new connection();
            NpgsqlConnection actualConnection = connection.ConexionBD();

            DataTable datatable = new DataTable();

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("Select a.Owner_Id as Cedula, a.Owner_Name as Nombre, " +
                "p.Name as Nombre_Mascota, p.Color as Color, p.Size as Tamano, p.Sex as Sexo, " +
                "p.Years as Anos, a.Adoption_Date as Fecha_Adopcion  from Adoption a" +
                " left join Pet p on p.Id = a.Pet_Id", actualConnection);

            adapter.Fill(datatable);
            dgv.DataSource= datatable;
        }


        public void get_Top3Likes(DataGridView dgv)
        {
            connection connection = new connection();
            NpgsqlConnection actualConnection = connection.ConexionBD();

            DataTable datatable = new DataTable();

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter("SELECT p.id, p.name AS Nombre, p.image AS Foto, pl.likes AS Likes " +
                "FROM Pet AS p INNER JOIN Pet_Likes AS pl ON p.id = pl.pet_id ORDER BY pl.likes DESC LIMIT 3;", actualConnection);

            adapter.Fill(datatable);
            dgv.DataSource = datatable;

            // Ahora, carga las imágenes
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Foto"].Value != DBNull.Value)
                {
                    if (row.Cells["Foto"].Value is byte[] imageData)
                    {
                        // Si la celda contiene un byte[], conviértelo a una imagen
                        if (imageData.Length > 0)
                        {
                            try
                            {
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    ms.Position = 0; // Asegurarse de que el stream esté en la posición inicial
                                    row.Cells["Foto"].Value = Image.FromStream(ms); // Asignar la imagen a la celda
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error al cargar la imagen: " + ex.Message);
                            }
                        }
                    }
                    else if (row.Cells["Foto"].Value is Image img)
                    {
                        // Si ya es una imagen, asignar directamente
                        row.Cells["Foto"].Value = img;
                    }
                }
            }

            actualConnection.Close();
        }

    }
}
