using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;

namespace Laboratorio01PrograIII
{
    public partial class PetInformationWindow : Form
    {

        private int petId;
        public PetInformationWindow(int petId)
        {
            InitializeComponent();
            this.petId = petId;
        }

        private void btnLike_Click(object sender, EventArgs e)
        {
            bdCRUD bd = new bdCRUD();
            bd.insert_PetLikes(petId);
            this.Close();
        }

        private void btnAdoptar_Click(object sender, EventArgs e)
        {

        }

        private void rdLike_Checked_Changed(object sender, EventArgs e)
        {
            if (rdLike.Checked) {
                txtCedula.Visible = false;
                txtNombre.Visible = false;
                btnAdoptar.Visible = false;
                lbl.Visible = false;
                label1.Visible = false;
                btnLike.Visible = true; 
            }
        }

        private void rdAdoptar_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAdoptar.Checked)
            {
                txtCedula.Visible = true;
                txtNombre.Visible = true;
                btnAdoptar.Visible = true;
                lbl.Visible = true;
                label1.Visible = true;
                btnLike.Visible = false;
            }
        }

        private void InformationForm_Load(object sender, EventArgs e)
        {
            bdQueries qry = new bdQueries();
            txtCedula.Visible = false;
            txtNombre.Visible = false;
            btnAdoptar.Visible = false;
            lbl.Visible = false;
            label1.Visible = false;
            btnLike.Visible = false;
            qry.load_PetInformation(dgvInformacion, petId);
        }
    }
}
