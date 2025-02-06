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
            int columnDate = 5;    // Índice de la columna para `DateTimePicker`
            int columnNumeric = 4; // Índice de la columna para `NumericUpDown`

            // Obtener el rectángulo de la celda de fecha
            Rectangle rectFecha = dgvPet.GetCellDisplayRectangle(columnDate, fila, true);
            date.Location = new Point(dgvPet.Left + rectFecha.X, dgvPet.Top + rectFecha.Y);
            date.Size = new Size(rectFecha.Width, rectFecha.Height);

            // Obtener el rectángulo de la celda numérica
            Rectangle rectNumero = dgvPet.GetCellDisplayRectangle(columnNumeric, fila, true);
            spinnerYears.Location = new Point(dgvPet.Left + rectNumero.X, dgvPet.Top + rectNumero.Y);
            spinnerYears.Size = new Size(rectNumero.Width, rectNumero.Height);

            // Asignar valores de la celda a los controles si ya existen
            if (dgvPet.Rows[fila].Cells[columnDate].Value != null)
            {
                DateTime fecha;
                if (DateTime.TryParse(dgvPet.Rows[fila].Cells[columnDate].Value.ToString(), out fecha))
                {
                    date.Value = fecha;
                }
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
            int fila = dgvPet.CurrentCell.RowIndex;
            int columnDate = 5; // Índice de la columna de fecha
            dgvPet.Rows[fila].Cells[columnDate].Value = date.Value.ToString("yyyy-MM-dd");
        }

        private void spinnerYears_ValueChanged(object sender, EventArgs e)
        {
            int fila = dgvPet.CurrentCell.RowIndex;
            int columnNumeric = 4; // Índice de la columna numérica
            dgvPet.Rows[fila].Cells[columnNumeric].Value = spinnerYears.Value;
        }

        private void dgvPet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que la celda seleccionada sea válida y que se haga clic en la columna 8
            if (e.RowIndex >= 0 && e.ColumnIndex == 7)  // Columna 8 (índice 7 porque inicia en 0)
            {
                // Recoger la información de la fila seleccionada
                objPet pet = new objPet
                {
                    Name = dgvPet.Rows[e.RowIndex].Cells["Nombre"].Value.ToString(),
                    Size = dgvPet.Rows[e.RowIndex].Cells["Tamaño"].Value.ToString(),
                    Sex = dgvPet.Rows[e.RowIndex].Cells["Sexo"].Value.ToString(),
                    Years = Convert.ToInt32(dgvPet.Rows[e.RowIndex].Cells["Edad"].Value),
                    Status = true,  // Suponiendo que siempre está activo al insertarlo
                    DateOfEntry = Convert.ToDateTime(dgvPet.Rows[e.RowIndex].Cells["Fecha_Ingreso"].Value),
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
                    pet.Image = new byte[0]; // Si no hay imagen, se envía un byte vacío
                }

                // Insertar la mascota en la base de datos
                bdCRUD crud = new bdCRUD();
                crud.insertPet(pet);

                MessageBox.Show("Mascota insertada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else if (e.RowIndex >= 0 && e.ColumnIndex == 8)
            {
                // Recoger la información de la fila seleccionada
                objPet pet = new objPet
                {
           
                    Name = dgvPet.Rows[e.RowIndex].Cells["Nombre"].Value.ToString(),
                    Size = dgvPet.Rows[e.RowIndex].Cells["Tamaño"].Value.ToString(),
                    Sex = dgvPet.Rows[e.RowIndex].Cells["Sexo"].Value.ToString(),
                    Years = Convert.ToInt32(dgvPet.Rows[e.RowIndex].Cells["Edad"].Value),
                    Status = true,  // Suponiendo que siempre está activo al insertarlo
                    DateOfEntry = Convert.ToDateTime(dgvPet.Rows[e.RowIndex].Cells["Fecha_Ingreso"].Value),
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
                    pet.Image = new byte[0]; // Si no hay imagen, se envía un byte vacío
                }
                bdCRUD crud = new bdCRUD();
                crud.updatePet(pet);
            }
        }
    }
}
