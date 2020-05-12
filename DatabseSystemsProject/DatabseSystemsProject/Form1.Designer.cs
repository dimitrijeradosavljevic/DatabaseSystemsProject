namespace DatabseSystemsProject
{
    partial class Form1
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
            this.btnDeleteNarodniPoslanik = new System.Windows.Forms.Button();
            this.btnUpdateNarodniPoslanik = new System.Windows.Forms.Button();
            this.btnCreateNarodniPoslanik = new System.Windows.Forms.Button();
            this.btnReadNarodniPoslanik = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDeleteNarodniPoslanik
            // 
            this.btnDeleteNarodniPoslanik.Location = new System.Drawing.Point(12, 132);
            this.btnDeleteNarodniPoslanik.Name = "btnDeleteNarodniPoslanik";
            this.btnDeleteNarodniPoslanik.Size = new System.Drawing.Size(240, 34);
            this.btnDeleteNarodniPoslanik.TabIndex = 10;
            this.btnDeleteNarodniPoslanik.Text = "Delete NarodniPoslanik";
            this.btnDeleteNarodniPoslanik.UseVisualStyleBackColor = true;
            this.btnDeleteNarodniPoslanik.Click += new System.EventHandler(this.btnDeleteNarodniPoslanik_Click);
            // 
            // btnUpdateNarodniPoslanik
            // 
            this.btnUpdateNarodniPoslanik.Location = new System.Drawing.Point(12, 92);
            this.btnUpdateNarodniPoslanik.Name = "btnUpdateNarodniPoslanik";
            this.btnUpdateNarodniPoslanik.Size = new System.Drawing.Size(240, 34);
            this.btnUpdateNarodniPoslanik.TabIndex = 9;
            this.btnUpdateNarodniPoslanik.Text = "Update NarodniPoslanik";
            this.btnUpdateNarodniPoslanik.UseVisualStyleBackColor = true;
            this.btnUpdateNarodniPoslanik.Click += new System.EventHandler(this.btnUpdateNarodniPoslanik_Click);
            // 
            // btnCreateNarodniPoslanik
            // 
            this.btnCreateNarodniPoslanik.Location = new System.Drawing.Point(12, 12);
            this.btnCreateNarodniPoslanik.Name = "btnCreateNarodniPoslanik";
            this.btnCreateNarodniPoslanik.Size = new System.Drawing.Size(240, 34);
            this.btnCreateNarodniPoslanik.TabIndex = 8;
            this.btnCreateNarodniPoslanik.Text = "Create NarodniPoslanik";
            this.btnCreateNarodniPoslanik.UseVisualStyleBackColor = true;
            this.btnCreateNarodniPoslanik.Click += new System.EventHandler(this.btnCreateNarodniPoslanik_Click);
            // 
            // btnReadNarodniPoslanik
            // 
            this.btnReadNarodniPoslanik.Location = new System.Drawing.Point(12, 52);
            this.btnReadNarodniPoslanik.Name = "btnReadNarodniPoslanik";
            this.btnReadNarodniPoslanik.Size = new System.Drawing.Size(240, 34);
            this.btnReadNarodniPoslanik.TabIndex = 7;
            this.btnReadNarodniPoslanik.Text = "Read NarodniPoslanik";
            this.btnReadNarodniPoslanik.UseVisualStyleBackColor = true;
            this.btnReadNarodniPoslanik.Click += new System.EventHandler(this.btnReadNarodniPoslanik_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDeleteNarodniPoslanik);
            this.Controls.Add(this.btnUpdateNarodniPoslanik);
            this.Controls.Add(this.btnCreateNarodniPoslanik);
            this.Controls.Add(this.btnReadNarodniPoslanik);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteNarodniPoslanik;
        private System.Windows.Forms.Button btnUpdateNarodniPoslanik;
        private System.Windows.Forms.Button btnCreateNarodniPoslanik;
        private System.Windows.Forms.Button btnReadNarodniPoslanik;
    }
}

