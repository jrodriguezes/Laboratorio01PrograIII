using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;

namespace Laboratorio01PrograIII
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            date.Visible = true;
            spinnerYears.Visible = true;
            dgvPet.Columns["Id"].Visible = false;  // Ocultar la columna Id

            // Posicionar en la primera celda de su columna correspondiente
            adjustPosition(0);
            bdQueries bd = new bdQueries();
            bd.load_Sizes(dgvPet);
            bd.load_Colors(dgvPet);
            bd.queryPets(dgvPet);
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            adjustPosition(e.RowIndex);
        }

        private void adjustPosition(int fila)
        {
            int columnDate = 6;
            int columnNumeric = 5;

            // Obtener el rectangulo de la celda de fecha
            Rectangle rectFecha = dgvPet.GetCellDisplayRectangle(columnDate, fila, true);
            date.Location = new Point(dgvPet.Left + rectFecha.X, dgvPet.Top + rectFecha.Y);
            date.Size = new Size(rectFecha.Width, rectFecha.Height);

            // Obtener el rectangulo de la celda numerica
            Rectangle rectNumero = dgvPet.GetCellDisplayRectangle(columnNumeric, fila, true);
            spinnerYears.Location = new Point(dgvPet.Left + rectNumero.X, dgvPet.Top + rectNumero.Y);
            spinnerYears.Size = new Size(rectNumero.Width, rectNumero.Height);

            // Asignar valores de la celda a los controles si ya existen
            if (dgvPet.Rows[fila].Cells[columnDate].Value != null)
            {
                DateTime fecha;
                // Verificar si la fecha es valida
                if (DateTime.TryParse(dgvPet.Rows[fila].Cells[columnDate].Value.ToString(), out fecha) && fecha != DateTime.MinValue)
                {
                    date.Value = fecha;
                }
                else
                {
                    // Asignar una fecha valida por defecto si la fecha es invalida
                    date.Value = DateTime.Today;  // o cualquier otra fecha predeterminada
                }
            }
            else
            {
                // Si la celda está vacia, puedes asignar una fecha predeterminada
                date.Value = DateTime.Today;
            }

            if (dgvPet.Rows[fila].Cells[columnNumeric].Value != null)
            {
                decimal valor;
                if (decimal.TryParse(dgvPet.Rows[fila].Cells[columnNumeric].Value.ToString(), out valor))
                {
                    spinnerYears.Value = valor;
                }
            }
        }
    
        private void date_ValueChanged(object sender, EventArgs e)
        {
            if (dgvPet.CurrentCell != null)
            {
                int fila = dgvPet.CurrentCell.RowIndex;
                int columnDate = 6;
                dgvPet.Rows[fila].Cells[columnDate].Value = date.Value.ToString("yyyy-MM-dd");
            }
            else
            {
             
            }
        }

        private void spinnerYears_ValueChanged(object sender, EventArgs e)
        {
            int fila = dgvPet.CurrentCell.RowIndex;
            int columnNumeric = 5;
            dgvPet.Rows[fila].Cells[columnNumeric].Value = spinnerYears.Value;
        }

        private void dgvPet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bdCRUD crud = new bdCRUD();
            bdQueries bd = new bdQueries();

            // Columna de imagen
            if (e.RowIndex >= 0 && e.ColumnIndex == 7)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Seleccionar imagen";
                    openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            string filePath = openFileDialog.FileName;
                            Image image = Image.FromFile(filePath);

                            // Ajustar el tamaño de la imagen para que se ajuste a la celda
                            int cellWidth = dgvPet.Columns[e.ColumnIndex].Width;
                            int cellHeight = dgvPet.Rows[e.RowIndex].Height;
                            Image resizedImage = ResizeImage(image, cellWidth, cellHeight);

                            // Asignar la imagen redimensionada a la celda
                            dgvPet.Rows[e.RowIndex].Cells["Foto"].Value = resizedImage;

                            // Convertir imagen a byte[]
                            byte[] imageBytes;
                            using (MemoryStream ms = new MemoryStream())
                            {
                                resizedImage.Save(ms, image.RawFormat);
                                imageBytes = ms.ToArray();
                            }

                            // Obtener ID de la mascota para actualizar la base de datos
                            int petId = Convert.ToInt32(dgvPet.Rows[e.RowIndex].Cells["ID"].Value);

                            // Llamar metodo para actualizar imagen en la BD
                            crud.updatePetImage(petId, imageBytes);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al cargar la imagen: " + ex.Message);
                        }
                    }
                }
                // Columna de insertar
            } else if (e.RowIndex >= 0 && e.ColumnIndex == 8)
            {
                objPet pet = new objPet
                {
                    // Comprobación para evitar null en las celdas
                    Name = dgvPet.Rows[e.RowIndex].Cells["Nombre"].Value != null ? dgvPet.Rows[e.RowIndex].Cells["Nombre"].Value.ToString() : string.Empty,
                    Color = dgvPet.Rows[e.RowIndex].Cells["Color"].Value != null ? dgvPet.Rows[e.RowIndex].Cells["Color"].Value.ToString() : string.Empty,
                    Size = dgvPet.Rows[e.RowIndex].Cells["Tamaño"].Value != null ? dgvPet.Rows[e.RowIndex].Cells["Tamaño"].Value.ToString() : string.Empty,
                    Sex = dgvPet.Rows[e.RowIndex].Cells["Sexo"].Value != null ? dgvPet.Rows[e.RowIndex].Cells["Sexo"].Value.ToString() : string.Empty,

                    // Comprobacion de Edad, en caso de que sea null
                    Years = dgvPet.Rows[e.RowIndex].Cells["Edad"].Value != null ? Convert.ToInt32(dgvPet.Rows[e.RowIndex].Cells["Edad"].Value) : 0,

                    // Comprobacion de Fecha_Ingreso, en caso de que sea null
                    DateOfEntry = dgvPet.Rows[e.RowIndex].Cells["Fecha_Ingreso"].Value != null ? Convert.ToDateTime(dgvPet.Rows[e.RowIndex].Cells["Fecha_Ingreso"].Value) : DateTime.MinValue,

                    Status = true 
                };

                // Cargar la imagen si existe
                if (dgvPet.Rows[e.RowIndex].Cells["Foto"].Value != null)
                {
                    Image img = (Image)dgvPet.Rows[e.RowIndex].Cells["Foto"].Value;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        pet.Image = ms.ToArray();
                    }
                }
                else
                {
                    pet.Image = new byte[0]; // Si no hay imagen, se envía un byte vacio
                }

                crud.insertPet(pet);

                bd.load_Sizes(dgvPet);
                bd.load_Colors(dgvPet);
                bd.queryPets(dgvPet);

                MessageBox.Show("Mascota insertada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Columna de modificar
            else if (e.RowIndex >= 0 && e.ColumnIndex == 9)
            {
                objPet pet = new objPet
                {
                    Id = Convert.ToInt32(dgvPet.Rows[e.RowIndex].Cells["Id"].Value),
                    Name = dgvPet.Rows[e.RowIndex].Cells["Nombre"].Value.ToString(),
                    Color = dgvPet.Rows[e.RowIndex].Cells["Color"].Value.ToString(),
                    Size = dgvPet.Rows[e.RowIndex].Cells["Tamaño"].Value.ToString(),
                    Sex = dgvPet.Rows[e.RowIndex].Cells["Sexo"].Value.ToString(),
                    Years = Convert.ToInt32(dgvPet.Rows[e.RowIndex].Cells["Edad"].Value),
                    Status = true,
                    DateOfEntry = Convert.ToDateTime(dgvPet.Rows[e.RowIndex].Cells["Fecha_Ingreso"].Value),
                   
                };
                MessageBox.Show("ID encontrado: " + pet.Id);

                if (dgvPet.Rows[e.RowIndex].Cells["Foto"].Value != null)
                {
                    Image img = (Image)dgvPet.Rows[e.RowIndex].Cells["Foto"].Value;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        pet.Image = ms.ToArray();
                    }
                }
                else
                {
                    pet.Image = new byte[0]; 
                }
           
                crud.updatePet(pet);

                bd.load_Sizes(dgvPet);
                bd.load_Colors(dgvPet);
                bd.queryPets(dgvPet);

                MessageBox.Show("Mascota modificada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Columna de informacion
            else if (e.RowIndex >= 0 && e.ColumnIndex == 10)
            {
                int petId = Convert.ToInt32(dgvPet.Rows[e.RowIndex].Cells["Id"].Value);
                PetInformationWindow nuevoFormulario = new PetInformationWindow(petId, dgvPet);
                nuevoFormulario.ShowDialog();
            }
        }

        private Image ResizeImage(Image img, int width, int height)
        {
            Bitmap resizedBitmap = new Bitmap(img, new Size(width, height));
            return resizedBitmap;
        }

        private void rdPets_CheckedChanged(object sender, EventArgs e)
        {
            dgvReport.Rows.Clear();
            bdQueries qry = new bdQueries();
            qry.get_adoptedPets(dgvReport);
        }

        private void rdLikes_CheckedChanged(object sender, EventArgs e)
        {
            //dgvReport.Rows.Clear();
            //bdQueries qry = new bdQueries();
            //qry.get_Top3Likes(dgvReport);
        }
    }
}
