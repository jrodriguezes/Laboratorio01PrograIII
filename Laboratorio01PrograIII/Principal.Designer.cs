namespace Laboratorio01PrograIII
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.spinnerYears = new System.Windows.Forms.NumericUpDown();
            this.dgvPet = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorR = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Tamaño = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Sexo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Edad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_Ingreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Foto = new System.Windows.Forms.DataGridViewImageColumn();
            this.Insertar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Modificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Desahabilitar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerYears)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPet)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(868, 459);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.date);
            this.tabPage1.Controls.Add(this.spinnerYears);
            this.tabPage1.Controls.Add(this.dgvPet);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(860, 433);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // date
            // 
            this.date.Location = new System.Drawing.Point(395, 179);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(185, 20);
            this.date.TabIndex = 2;
            this.date.ValueChanged += new System.EventHandler(this.date_ValueChanged);
            // 
            // spinnerYears
            // 
            this.spinnerYears.Location = new System.Drawing.Point(282, 179);
            this.spinnerYears.Name = "spinnerYears";
            this.spinnerYears.Size = new System.Drawing.Size(68, 20);
            this.spinnerYears.TabIndex = 1;
            this.spinnerYears.ValueChanged += new System.EventHandler(this.spinnerYears_ValueChanged);
            // 
            // dgvPet
            // 
            this.dgvPet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.ColorR,
            this.Tamaño,
            this.Sexo,
            this.Edad,
            this.Fecha_Ingreso,
            this.Foto,
            this.Insertar,
            this.Modificar,
            this.Desahabilitar});
            this.dgvPet.Location = new System.Drawing.Point(3, 53);
            this.dgvPet.Name = "dgvPet";
            this.dgvPet.Size = new System.Drawing.Size(861, 363);
            this.dgvPet.TabIndex = 0;
            this.dgvPet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPet_CellClick);
            this.dgvPet.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(860, 433);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Nombre
            // 
            this.Nombre.Frozen = true;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // ColorR
            // 
            this.ColorR.Frozen = true;
            this.ColorR.HeaderText = "Color";
            this.ColorR.Name = "ColorR";
            // 
            // Tamaño
            // 
            this.Tamaño.Frozen = true;
            this.Tamaño.HeaderText = "Tamaño";
            this.Tamaño.Name = "Tamaño";
            // 
            // Sexo
            // 
            this.Sexo.HeaderText = "Sexo";
            this.Sexo.Name = "Sexo";
            this.Sexo.Width = 50;
            // 
            // Edad
            // 
            this.Edad.HeaderText = "Edad";
            this.Edad.Name = "Edad";
            this.Edad.Width = 50;
            // 
            // Fecha_Ingreso
            // 
            this.Fecha_Ingreso.HeaderText = "Fecha de ingreso";
            this.Fecha_Ingreso.Name = "Fecha_Ingreso";
            this.Fecha_Ingreso.Width = 135;
            // 
            // Foto
            // 
            this.Foto.HeaderText = "Foto";
            this.Foto.Name = "Foto";
            this.Foto.Width = 50;
            // 
            // Insertar
            // 
            this.Insertar.HeaderText = "Insertar";
            this.Insertar.Name = "Insertar";
            this.Insertar.Width = 75;
            // 
            // Modificar
            // 
            this.Modificar.HeaderText = "Modificar";
            this.Modificar.Name = "Modificar";
            this.Modificar.ReadOnly = true;
            this.Modificar.Width = 75;
            // 
            // Desahabilitar
            // 
            this.Desahabilitar.HeaderText = "Desahabilitar";
            this.Desahabilitar.Name = "Desahabilitar";
            this.Desahabilitar.ReadOnly = true;
            this.Desahabilitar.Width = 80;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Principal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinnerYears)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvPet;
        private System.Windows.Forms.NumericUpDown spinnerYears;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColorR;
        private System.Windows.Forms.DataGridViewComboBoxColumn Tamaño;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Sexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Edad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Ingreso;
        private System.Windows.Forms.DataGridViewImageColumn Foto;
        private System.Windows.Forms.DataGridViewButtonColumn Insertar;
        private System.Windows.Forms.DataGridViewButtonColumn Modificar;
        private System.Windows.Forms.DataGridViewButtonColumn Desahabilitar;
    }
}

