namespace Laboratorio01PrograIII
{
    partial class PetInformationWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLike = new System.Windows.Forms.Button();
            this.btnAdoptar = new System.Windows.Forms.Button();
            this.dgvInformacion = new System.Windows.Forms.DataGridView();
            this.rdLike = new System.Windows.Forms.RadioButton();
            this.rdAdoptar = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInformacion)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLike
            // 
            this.btnLike.Location = new System.Drawing.Point(388, 176);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(75, 23);
            this.btnLike.TabIndex = 0;
            this.btnLike.Text = "Like";
            this.btnLike.UseVisualStyleBackColor = true;
            this.btnLike.Click += new System.EventHandler(this.btnLike_Click);
            // 
            // btnAdoptar
            // 
            this.btnAdoptar.Location = new System.Drawing.Point(235, 267);
            this.btnAdoptar.Name = "btnAdoptar";
            this.btnAdoptar.Size = new System.Drawing.Size(75, 23);
            this.btnAdoptar.TabIndex = 1;
            this.btnAdoptar.Text = "Adoptar";
            this.btnAdoptar.UseVisualStyleBackColor = true;
            this.btnAdoptar.Click += new System.EventHandler(this.btnAdoptar_Click);
            // 
            // dgvInformacion
            // 
            this.dgvInformacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInformacion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInformacion.Location = new System.Drawing.Point(12, 12);
            this.dgvInformacion.Name = "dgvInformacion";
            this.dgvInformacion.Size = new System.Drawing.Size(471, 150);
            this.dgvInformacion.TabIndex = 2;
            // 
            // rdLike
            // 
            this.rdLike.AutoSize = true;
            this.rdLike.Location = new System.Drawing.Point(6, 8);
            this.rdLike.Name = "rdLike";
            this.rdLike.Size = new System.Drawing.Size(45, 17);
            this.rdLike.TabIndex = 3;
            this.rdLike.TabStop = true;
            this.rdLike.Text = "Like";
            this.rdLike.UseVisualStyleBackColor = true;
            this.rdLike.CheckedChanged += new System.EventHandler(this.rdLike_Checked_Changed);
            // 
            // rdAdoptar
            // 
            this.rdAdoptar.AutoSize = true;
            this.rdAdoptar.Location = new System.Drawing.Point(57, 8);
            this.rdAdoptar.Name = "rdAdoptar";
            this.rdAdoptar.Size = new System.Drawing.Size(62, 17);
            this.rdAdoptar.TabIndex = 4;
            this.rdAdoptar.TabStop = true;
            this.rdAdoptar.Text = "Adoptar";
            this.rdAdoptar.UseVisualStyleBackColor = true;
            this.rdAdoptar.CheckedChanged += new System.EventHandler(this.rdAdoptar_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdLike);
            this.groupBox1.Controls.Add(this.rdAdoptar);
            this.groupBox1.Location = new System.Drawing.Point(200, 168);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(131, 31);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(168, 212);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(43, 13);
            this.lbl.TabIndex = 6;
            this.lbl.Text = "Cedula:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nombre:";
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(221, 207);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(100, 20);
            this.txtCedula.TabIndex = 8;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(221, 233);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 9;
            // 
            // PetInformationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 302);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvInformacion);
            this.Controls.Add(this.btnAdoptar);
            this.Controls.Add(this.btnLike);
            this.Name = "PetInformationWindow";
            this.Text = "Informacion de la mascota";
            this.Load += new System.EventHandler(this.InformationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInformacion)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLike;
        private System.Windows.Forms.Button btnAdoptar;
        private System.Windows.Forms.DataGridView dgvInformacion;
        private System.Windows.Forms.RadioButton rdLike;
        private System.Windows.Forms.RadioButton rdAdoptar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.TextBox txtNombre;
    }
}