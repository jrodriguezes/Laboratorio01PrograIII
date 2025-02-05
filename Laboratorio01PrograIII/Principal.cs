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
            date.Visible = false;  
            spinnerYears.Visible = false;
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int columnDate = 5;  // Índice de la columna para `DateTimePicker`
            int columnNumeric = 4; // Índice de la columna para `NumericUpDown`
            
            // Ocultar ambos controles antes de verificar
            date.Visible = false;
            spinnerYears.Visible = false;

            // Si la celda activa es de la columna de fecha
            if (e.ColumnIndex == columnDate)
            {
                Rectangle rect = dgvPet.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                date.Location = new Point(dgvPet.Left + rect.X, dgvPet.Top + rect.Y);
                date.Size = new Size(rect.Width, rect.Height);
                date.Visible = true;

                // Si la celda ya tiene una fecha, asignarla al `DateTimePicker`
                if (dgvPet.CurrentCell.Value != null)
                {
                    DateTime fecha;
                    if (DateTime.TryParse(dgvPet.CurrentCell.Value.ToString(), out fecha))
                    {
                        date.Value = fecha;
                    }
                }
            }
            // Si la celda activa es de la columna numérica
            else if (e.ColumnIndex == columnNumeric)
            {
                Rectangle rect = dgvPet.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                spinnerYears.Location = new Point(dgvPet.Left + rect.X, dgvPet.Top + rect.Y);
                spinnerYears.Size = new Size(rect.Width, rect.Height);
                spinnerYears.Visible = true;

                // Si la celda ya tiene un valor, asignarlo al `NumericUpDown`
                if (dgvPet.CurrentCell.Value != null)
                {
                    decimal valor;
                    if (decimal.TryParse(dgvPet.CurrentCell.Value.ToString(), out valor))
                    {
                        spinnerYears.Value = valor;
                    }
                }
            }
        }

        private void spiner_ValueChanged(object sender, EventArgs e)
        {

        }

        private void date_ValueChanfed(object sender, EventArgs e)
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
    }
}
