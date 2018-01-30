namespace Triangulation.UI
{
    partial class MainForm
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
            this.PolygonPanel = new System.Windows.Forms.Panel();
            this.Coordinates = new System.Windows.Forms.Label();
            this.TriangulateButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.PolygonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PolygonPanel
            // 
            this.PolygonPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PolygonPanel.Controls.Add(this.Coordinates);
            this.PolygonPanel.Location = new System.Drawing.Point(13, 12);
            this.PolygonPanel.Name = "PolygonPanel";
            this.PolygonPanel.Size = new System.Drawing.Size(745, 417);
            this.PolygonPanel.TabIndex = 0;
            this.PolygonPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PolygonPanel_MouseDown);
            // 
            // Coordinates
            // 
            this.Coordinates.AutoSize = true;
            this.Coordinates.Location = new System.Drawing.Point(653, 16);
            this.Coordinates.Name = "Coordinates";
            this.Coordinates.Size = new System.Drawing.Size(0, 13);
            this.Coordinates.TabIndex = 0;
            // 
            // TriangulateButton
            // 
            this.TriangulateButton.Location = new System.Drawing.Point(13, 447);
            this.TriangulateButton.Name = "TriangulateButton";
            this.TriangulateButton.Size = new System.Drawing.Size(127, 54);
            this.TriangulateButton.TabIndex = 1;
            this.TriangulateButton.Text = "Triangulate";
            this.TriangulateButton.UseVisualStyleBackColor = true;
            this.TriangulateButton.Click += new System.EventHandler(this.TriangulateButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(630, 447);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(128, 53);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(146, 448);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(127, 53);
            this.ClearButton.TabIndex = 3;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 513);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.TriangulateButton);
            this.Controls.Add(this.PolygonPanel);
            this.Name = "MainForm";
            this.Text = "Triangulation";
            this.PolygonPanel.ResumeLayout(false);
            this.PolygonPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PolygonPanel;
        private System.Windows.Forms.Button TriangulateButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Label Coordinates;
    }
}

