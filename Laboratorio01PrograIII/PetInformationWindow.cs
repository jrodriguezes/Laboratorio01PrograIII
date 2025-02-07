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
using Logic;

namespace Laboratorio01PrograIII
{
    public partial class PetInformationWindow : Form
    {
        private int petId;
        private DataGridView dgvPet;
        bdLogic logic = new bdLogic();

        public PetInformationWindow(int petId, DataGridView dgvPet)
        {
            InitializeComponent();
            this.petId = petId;
            this.dgvPet = dgvPet;
        }

        private void btnLike_Click(object sender, EventArgs e)
        {
            logic.InsertPetLikes(petId);
            this.Close();
        }

        private void btnAdoptar_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(txtCedula.Text);
            string name = txtNombre.Text;
            logic.InsertUser(userId, name);
            DateTime actualDate = DateTime.Now;

            logic.InsertAdoption(userId, name, petId, actualDate);
            string petName = logic.GetPetNameById(petId);

            MessageBox.Show("Felicidades " + name + " has adoptado a: " + petName);
            logic.LoadPets(dgvPet);
            this.Close();

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
            txtCedula.Visible = false;
            txtNombre.Visible = false;
            btnAdoptar.Visible = false;
            lbl.Visible = false;
            label1.Visible = false;
            btnLike.Visible = false;
            logic.LoadPetInformation(dgvInformacion, petId);
        }
    }
}
