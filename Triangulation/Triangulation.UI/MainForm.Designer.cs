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
            this.label1 = new System.Windows.Forms.Label();
            this.FrameCentoid = new System.Windows.Forms.Label();
            this.Body = new System.Windows.Forms.Label();
            this.Tops = new System.Windows.Forms.Label();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label1.Location = new System.Drawing.Point(765, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Centoids:";
            // 
            // FrameCentoid
            // 
            this.FrameCentoid.AutoSize = true;
            this.FrameCentoid.BackColor = System.Drawing.Color.Violet;
            this.FrameCentoid.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.FrameCentoid.Location = new System.Drawing.Point(768, 30);
            this.FrameCentoid.Name = "FrameCentoid";
            this.FrameCentoid.Size = new System.Drawing.Size(51, 18);
            this.FrameCentoid.TabIndex = 5;
            this.FrameCentoid.Text = "Frame";
            // 
            // Body
            // 
            this.Body.AutoSize = true;
            this.Body.BackColor = System.Drawing.Color.Black;
            this.Body.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.Body.ForeColor = System.Drawing.Color.White;
            this.Body.Location = new System.Drawing.Point(768, 48);
            this.Body.Name = "Body";
            this.Body.Size = new System.Drawing.Size(42, 18);
            this.Body.TabIndex = 6;
            this.Body.Text = "Body";
            // 
            // Tops
            // 
            this.Tops.AutoSize = true;
            this.Tops.BackColor = System.Drawing.Color.YellowGreen;
            this.Tops.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.Tops.Location = new System.Drawing.Point(768, 66);
            this.Tops.Name = "Tops";
            this.Tops.Size = new System.Drawing.Size(42, 18);
            this.Tops.TabIndex = 7;
            this.Tops.Text = "Tops";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 513);
            this.Controls.Add(this.Tops);
            this.Controls.Add(this.Body);
            this.Controls.Add(this.FrameCentoid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.TriangulateButton);
            this.Controls.Add(this.PolygonPanel);
            this.Name = "MainForm";
            this.Text = "Triangulation";
            this.PolygonPanel.ResumeLayout(false);
            this.PolygonPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PolygonPanel;
        private System.Windows.Forms.Button TriangulateButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Label Coordinates;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label FrameCentoid;
        private System.Windows.Forms.Label Body;
        private System.Windows.Forms.Label Tops;
    }
}

