namespace Repaso2
{
    partial class FormAlquiler
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
            this.dataGridViewVehiculos = new System.Windows.Forms.DataGridView();
            this.dataGridViewResumen = new System.Windows.Forms.DataGridView();
            this.buttonAlquileres = new System.Windows.Forms.Button();
            this.dataGridViewAlquileres = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVehiculos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResumen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlquileres)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewVehiculos
            // 
            this.dataGridViewVehiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVehiculos.Location = new System.Drawing.Point(12, 33);
            this.dataGridViewVehiculos.Name = "dataGridViewVehiculos";
            this.dataGridViewVehiculos.RowTemplate.Height = 25;
            this.dataGridViewVehiculos.Size = new System.Drawing.Size(524, 153);
            this.dataGridViewVehiculos.TabIndex = 0;
            // 
            // dataGridViewResumen
            // 
            this.dataGridViewResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResumen.Location = new System.Drawing.Point(656, 12);
            this.dataGridViewResumen.Name = "dataGridViewResumen";
            this.dataGridViewResumen.RowTemplate.Height = 25;
            this.dataGridViewResumen.Size = new System.Drawing.Size(647, 241);
            this.dataGridViewResumen.TabIndex = 1;
            // 
            // buttonAlquileres
            // 
            this.buttonAlquileres.Location = new System.Drawing.Point(675, 327);
            this.buttonAlquileres.Name = "buttonAlquileres";
            this.buttonAlquileres.Size = new System.Drawing.Size(184, 72);
            this.buttonAlquileres.TabIndex = 2;
            this.buttonAlquileres.Text = "Ver Resumen de Alquileres";
            this.buttonAlquileres.UseVisualStyleBackColor = true;
            this.buttonAlquileres.Click += new System.EventHandler(this.buttonAlquileres_Click);
            // 
            // dataGridViewAlquileres
            // 
            this.dataGridViewAlquileres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAlquileres.Location = new System.Drawing.Point(12, 249);
            this.dataGridViewAlquileres.Name = "dataGridViewAlquileres";
            this.dataGridViewAlquileres.RowTemplate.Height = 25;
            this.dataGridViewAlquileres.Size = new System.Drawing.Size(524, 150);
            this.dataGridViewAlquileres.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Alquileres";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Automoviles";
            // 
            // FormAlquiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewAlquileres);
            this.Controls.Add(this.buttonAlquileres);
            this.Controls.Add(this.dataGridViewResumen);
            this.Controls.Add(this.dataGridViewVehiculos);
            this.Name = "FormAlquiler";
            this.Text = "FormAlquiler";
            this.Load += new System.EventHandler(this.FormAlquiler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVehiculos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResumen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlquileres)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewVehiculos;
        private System.Windows.Forms.DataGridView dataGridViewResumen;
        private System.Windows.Forms.Button buttonAlquileres;
        private System.Windows.Forms.DataGridView dataGridViewAlquileres;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}