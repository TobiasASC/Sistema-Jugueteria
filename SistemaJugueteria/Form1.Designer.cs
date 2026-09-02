namespace SistemaJugueteria
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
            menuPrincipal = new ReaLTaiizor.Controls.MaterialCard();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            hopeTextBox2 = new ReaLTaiizor.Controls.HopeTextBox();
            hopeTextBox1 = new ReaLTaiizor.Controls.HopeTextBox();
            bigLabel2 = new ReaLTaiizor.Controls.BigLabel();
            bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            pictureBox1 = new PictureBox();
            hopeButton1 = new ReaLTaiizor.Controls.HopeButton();
            menuPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuPrincipal
            // 
            menuPrincipal.Anchor = AnchorStyles.None;
            menuPrincipal.BackColor = Color.FromArgb(255, 255, 255);
            menuPrincipal.Controls.Add(pictureBox3);
            menuPrincipal.Controls.Add(pictureBox2);
            menuPrincipal.Controls.Add(hopeTextBox2);
            menuPrincipal.Controls.Add(hopeTextBox1);
            menuPrincipal.Controls.Add(bigLabel2);
            menuPrincipal.Controls.Add(bigLabel1);
            menuPrincipal.Controls.Add(pictureBox1);
            menuPrincipal.Controls.Add(hopeButton1);
            menuPrincipal.Depth = 0;
            menuPrincipal.ForeColor = Color.FromArgb(222, 0, 0, 0);
            menuPrincipal.Location = new Point(316, 64);
            menuPrincipal.Margin = new Padding(14);
            menuPrincipal.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Padding = new Padding(14);
            menuPrincipal.Size = new Size(385, 420);
            menuPrincipal.TabIndex = 0;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.icono_candado_login;
            pictureBox3.Location = new Point(49, 274);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(36, 38);
            pictureBox3.TabIndex = 7;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.icono_usuario_login;
            pictureBox2.Location = new Point(49, 230);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(36, 38);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // hopeTextBox2
            // 
            hopeTextBox2.BackColor = Color.White;
            hopeTextBox2.BaseColor = Color.White;
            hopeTextBox2.BorderColorA = Color.FromArgb(64, 158, 255);
            hopeTextBox2.BorderColorB = Color.FromArgb(220, 223, 230);
            hopeTextBox2.Font = new Font("Segoe UI", 12F);
            hopeTextBox2.ForeColor = Color.Gray;
            hopeTextBox2.Hint = "contraseña";
            hopeTextBox2.Location = new Point(86, 274);
            hopeTextBox2.MaxLength = 32767;
            hopeTextBox2.Multiline = false;
            hopeTextBox2.Name = "hopeTextBox2";
            hopeTextBox2.PasswordChar = '*';
            hopeTextBox2.ScrollBars = ScrollBars.None;
            hopeTextBox2.SelectedText = "";
            hopeTextBox2.SelectionLength = 0;
            hopeTextBox2.SelectionStart = 0;
            hopeTextBox2.Size = new Size(245, 38);
            hopeTextBox2.TabIndex = 5;
            hopeTextBox2.TabStop = false;
            hopeTextBox2.UseSystemPasswordChar = false;
            hopeTextBox2.Click += hopeTextBox2_Click;
            // 
            // hopeTextBox1
            // 
            hopeTextBox1.BackColor = Color.White;
            hopeTextBox1.BaseColor = Color.White;
            hopeTextBox1.BorderColorA = Color.FromArgb(64, 158, 255);
            hopeTextBox1.BorderColorB = Color.FromArgb(220, 223, 230);
            hopeTextBox1.Font = new Font("Segoe UI", 12F);
            hopeTextBox1.ForeColor = Color.Gray;
            hopeTextBox1.Hint = "usuario";
            hopeTextBox1.Location = new Point(86, 230);
            hopeTextBox1.MaxLength = 32767;
            hopeTextBox1.Multiline = false;
            hopeTextBox1.Name = "hopeTextBox1";
            hopeTextBox1.PasswordChar = '\0';
            hopeTextBox1.ScrollBars = ScrollBars.None;
            hopeTextBox1.SelectedText = "";
            hopeTextBox1.SelectionLength = 0;
            hopeTextBox1.SelectionStart = 0;
            hopeTextBox1.Size = new Size(245, 38);
            hopeTextBox1.TabIndex = 4;
            hopeTextBox1.TabStop = false;
            hopeTextBox1.UseSystemPasswordChar = false;
            // 
            // bigLabel2
            // 
            bigLabel2.AutoSize = true;
            bigLabel2.BackColor = Color.Transparent;
            bigLabel2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bigLabel2.ForeColor = Color.FromArgb(35, 53, 78);
            bigLabel2.Location = new Point(90, 195);
            bigLabel2.Name = "bigLabel2";
            bigLabel2.Size = new Size(223, 20);
            bigLabel2.TabIndex = 3;
            bigLabel2.Text = "- inicie sesión para continuar - ";
            bigLabel2.Click += bigLabel2_Click;
            // 
            // bigLabel1
            // 
            bigLabel1.AutoSize = true;
            bigLabel1.BackColor = Color.Transparent;
            bigLabel1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bigLabel1.ForeColor = Color.FromArgb(35, 53, 78);
            bigLabel1.Location = new Point(130, 154);
            bigLabel1.Name = "bigLabel1";
            bigLabel1.Size = new Size(130, 30);
            bigLabel1.TabIndex = 2;
            bigLabel1.Text = "Bienvenido!";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = Properties.Resources.logo_tntoys;
            pictureBox1.Location = new Point(64, 39);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(267, 101);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // hopeButton1
            // 
            hopeButton1.BackColor = Color.FromArgb(255, 162, 145);
            hopeButton1.BorderColor = Color.FromArgb(220, 223, 230);
            hopeButton1.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            hopeButton1.DangerColor = Color.FromArgb(245, 108, 108);
            hopeButton1.DefaultColor = Color.FromArgb(255, 255, 255);
            hopeButton1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            hopeButton1.HoverTextColor = Color.FromArgb(48, 49, 51);
            hopeButton1.InfoColor = Color.FromArgb(144, 147, 153);
            hopeButton1.Location = new Point(86, 330);
            hopeButton1.Name = "hopeButton1";
            hopeButton1.PrimaryColor = Color.FromArgb(255, 151, 133);
            hopeButton1.Size = new Size(191, 37);
            hopeButton1.SuccessColor = Color.FromArgb(103, 194, 58);
            hopeButton1.TabIndex = 0;
            hopeButton1.Text = "Iniciar Sesión";
            hopeButton1.TextColor = Color.White;
            hopeButton1.WarningColor = Color.FromArgb(230, 162, 60);
            hopeButton1.Click += hopeButton1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 173, 159);
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(978, 531);
            Controls.Add(menuPrincipal);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            menuPrincipal.ResumeLayout(false);
            menuPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.MaterialCard menuPrincipal;
        private ReaLTaiizor.Controls.HopeButton hopeButton1;
        private ReaLTaiizor.Controls.BigLabel bigLabel2;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private PictureBox pictureBox1;
        private ReaLTaiizor.Controls.HopeTextBox hopeTextBox2;
        private ReaLTaiizor.Controls.HopeTextBox hopeTextBox1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
    }
}
