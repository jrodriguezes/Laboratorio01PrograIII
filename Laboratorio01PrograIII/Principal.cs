using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            AjustarPosicionControles(0);
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            AjustarPosicionControles(e.RowIndex);
        }

        private void spiner_ValueChanged(object sender, EventArgs e)
        {
            if (dgvPet.CurrentCell != null && dgvPet.CurrentCell.ColumnIndex == 4) // Columna numérica
            {
                dgvPet.CurrentCell.Value = spinnerYears.Value;
            }
        }
  

        private void date_ValueChanged(object sender, EventArgs e)
        {
            if (dgvPet.CurrentCell != null && dgvPet.CurrentCell.ColumnIndex == 5) // Columna de fecha
            {
                dgvPet.CurrentCell.Value = date.Value.ToShortDateString();
            }
        
    }

        private void AjustarPosicionControles(int fila)
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
    }
}
