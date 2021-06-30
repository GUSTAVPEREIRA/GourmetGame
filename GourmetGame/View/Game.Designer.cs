using GourmetGame.Controllers;

namespace GourmetGame
{
    partial class Game
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

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbHometxt = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbHometxt
            // 
            this.lbHometxt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbHometxt.AutoSize = true;
            this.lbHometxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbHometxt.Location = new System.Drawing.Point(30, 10);
            this.lbHometxt.Name = "lbHometxt";
            this.lbHometxt.Size = new System.Drawing.Size(216, 21);
            this.lbHometxt.TabIndex = 0;
            this.lbHometxt.Text = "Pense em um prato que gosta";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOk.Location = new System.Drawing.Point(102, 41);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(59, 25);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.StartGame);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 91);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lbHometxt);
            this.Name = "Game";
            this.Text = "Jogo Gourmet";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.CenterToParent();

        }

        private System.Windows.Forms.Label lbHometxt;
        private System.Windows.Forms.Button btnOk;
    }
}