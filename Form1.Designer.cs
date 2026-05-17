namespace Sistema_de_Reserva_de_comida
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbltitulo = new Label();
            txtnombre = new TextBox();
            txtasiento = new TextBox();
            cmbcomidas = new ComboBox();
            btnreservar = new Button();
            btncancelar = new Button();
            Reservas = new ListBox();
            btnmostrar = new Button();
            SuspendLayout();
            // 
            // lbltitulo
            // 
            lbltitulo.AutoSize = true;
            lbltitulo.BackColor = SystemColors.HotTrack;
            lbltitulo.Font = new Font("Showcard Gothic", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbltitulo.Location = new Point(252, 38);
            lbltitulo.Name = "lbltitulo";
            lbltitulo.Size = new Size(484, 59);
            lbltitulo.TabIndex = 0;
            lbltitulo.Text = "Reserva Tu Comida";
            // 
            // txtnombre
            // 
            txtnombre.BackColor = SystemColors.HotTrack;
            txtnombre.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtnombre.Location = new Point(115, 194);
            txtnombre.Name = "txtnombre";
            txtnombre.Size = new Size(272, 34);
            txtnombre.TabIndex = 1;
            // 
            // txtasiento
            // 
            txtasiento.BackColor = SystemColors.HotTrack;
            txtasiento.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtasiento.Location = new Point(450, 194);
            txtasiento.Name = "txtasiento";
            txtasiento.Size = new Size(136, 34);
            txtasiento.TabIndex = 2;
            // 
            // cmbcomidas
            // 
            cmbcomidas.BackColor = SystemColors.HotTrack;
            cmbcomidas.FormattingEnabled = true;
            cmbcomidas.Location = new Point(115, 247);
            cmbcomidas.Name = "cmbcomidas";
            cmbcomidas.Size = new Size(272, 28);
            cmbcomidas.TabIndex = 3;
            // 
            // btnreservar
            // 
            btnreservar.BackColor = SystemColors.Control;
            btnreservar.Location = new Point(115, 341);
            btnreservar.Name = "btnreservar";
            btnreservar.Size = new Size(94, 29);
            btnreservar.TabIndex = 4;
            btnreservar.Text = "Reservar";
            btnreservar.UseVisualStyleBackColor = false;
            btnreservar.Click += btnreservar_Click;
            // 
            // btncancelar
            // 
            btncancelar.BackColor = SystemColors.Control;
            btncancelar.Location = new Point(252, 341);
            btncancelar.Name = "btncancelar";
            btncancelar.Size = new Size(94, 29);
            btncancelar.TabIndex = 6;
            btncancelar.Text = "Cancelar";
            btncancelar.UseVisualStyleBackColor = false;
            btncancelar.Click += btncancelar_Click;
            // 
            // Reservas
            // 
            Reservas.FormattingEnabled = true;
            Reservas.Location = new Point(623, 148);
            Reservas.Name = "Reservas";
            Reservas.Size = new Size(401, 264);
            Reservas.TabIndex = 7;
            // 
            // btnmostrar
            // 
            btnmostrar.BackColor = SystemColors.ButtonFace;
            btnmostrar.Location = new Point(390, 339);
            btnmostrar.Name = "btnmostrar";
            btnmostrar.Size = new Size(94, 29);
            btnmostrar.TabIndex = 8;
            btnmostrar.Text = "Mostrar";
            btnmostrar.UseVisualStyleBackColor = false;
            btnmostrar.Click += btnmostrar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gold;
            ClientSize = new Size(1050, 496);
            Controls.Add(btnmostrar);
            Controls.Add(Reservas);
            Controls.Add(btncancelar);
            Controls.Add(btnreservar);
            Controls.Add(cmbcomidas);
            Controls.Add(txtasiento);
            Controls.Add(txtnombre);
            Controls.Add(lbltitulo);
            Name = "Form1";
            Text = "Sistema de reserva de comida";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbltitulo;
        private TextBox txtnombre;
        private TextBox txtasiento;
        private ComboBox cmbcomidas;
        private Button btnreservar;
        private Button btncancelar;
        private ListBox Reservas;
        private Button btnmostrar;
    }
}
