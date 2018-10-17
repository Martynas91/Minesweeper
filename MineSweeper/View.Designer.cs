namespace MineSweeper
{
    partial class View
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
            this.btStart = new System.Windows.Forms.Button();
            this.cbLevel = new System.Windows.Forms.ComboBox();
            this.lblBombs = new System.Windows.Forms.Label();
            this.lblFlags = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btStart
            // 
            this.btStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btStart.Location = new System.Drawing.Point(1059, 75);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(143, 58);
            this.btStart.TabIndex = 0;
            this.btStart.Text = "START";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // cbLevel
            // 
            this.cbLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLevel.FormattingEnabled = true;
            this.cbLevel.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard"});
            this.cbLevel.Location = new System.Drawing.Point(1059, 30);
            this.cbLevel.Name = "cbLevel";
            this.cbLevel.Size = new System.Drawing.Size(143, 28);
            this.cbLevel.TabIndex = 1;
            this.cbLevel.Text = "Easy";
            // 
            // lblBombs
            // 
            this.lblBombs.AutoSize = true;
            this.lblBombs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBombs.Location = new System.Drawing.Point(1057, 157);
            this.lblBombs.Name = "lblBombs";
            this.lblBombs.Size = new System.Drawing.Size(88, 20);
            this.lblBombs.TabIndex = 2;
            this.lblBombs.Text = "Flags left: ";
            // 
            // lblFlags
            // 
            this.lblFlags.AutoSize = true;
            this.lblFlags.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlags.Location = new System.Drawing.Point(1151, 157);
            this.lblFlags.Name = "lblFlags";
            this.lblFlags.Size = new System.Drawing.Size(0, 20);
            this.lblFlags.TabIndex = 3;
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 785);
            this.Controls.Add(this.lblFlags);
            this.Controls.Add(this.lblBombs);
            this.Controls.Add(this.cbLevel);
            this.Controls.Add(this.btStart);
            this.Name = "View";
            this.Text = "View";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.ComboBox cbLevel;
        private System.Windows.Forms.Label lblBombs;
        private System.Windows.Forms.Label lblFlags;
    }
}

