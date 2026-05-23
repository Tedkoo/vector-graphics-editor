namespace official
{
    partial class CalculationsForm
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
            this.titleArea = new System.Windows.Forms.Label();
            this.titlePer = new System.Windows.Forms.Label();
            this.labelPer = new System.Windows.Forms.Label();
            this.labelArea = new System.Windows.Forms.Label();
            this.btnAccuracy = new System.Windows.Forms.Button();
            this.labelAccArea = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleArea
            // 
            this.titleArea.AutoSize = true;
            this.titleArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleArea.Location = new System.Drawing.Point(20, 25);
            this.titleArea.Name = "titleArea";
            this.titleArea.Size = new System.Drawing.Size(44, 20);
            this.titleArea.TabIndex = 0;
            this.titleArea.Text = "Area";
            // 
            // titlePer
            // 
            this.titlePer.AutoSize = true;
            this.titlePer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titlePer.Location = new System.Drawing.Point(347, 25);
            this.titlePer.Name = "titlePer";
            this.titlePer.Size = new System.Drawing.Size(82, 20);
            this.titlePer.TabIndex = 1;
            this.titlePer.Text = "Perimeter";
            // 
            // labelPer
            // 
            this.labelPer.AutoSize = true;
            this.labelPer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPer.Location = new System.Drawing.Point(347, 87);
            this.labelPer.Name = "labelPer";
            this.labelPer.Size = new System.Drawing.Size(0, 20);
            this.labelPer.TabIndex = 3;
            // 
            // labelArea
            // 
            this.labelArea.AutoSize = true;
            this.labelArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelArea.Location = new System.Drawing.Point(20, 87);
            this.labelArea.Name = "labelArea";
            this.labelArea.Size = new System.Drawing.Size(0, 20);
            this.labelArea.TabIndex = 2;
            // 
            // btnAccuracy
            // 
            this.btnAccuracy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccuracy.Location = new System.Drawing.Point(361, 124);
            this.btnAccuracy.Name = "btnAccuracy";
            this.btnAccuracy.Size = new System.Drawing.Size(155, 38);
            this.btnAccuracy.TabIndex = 4;
            this.btnAccuracy.Text = "прибл. точност";
            this.btnAccuracy.UseVisualStyleBackColor = true;
            this.btnAccuracy.Click += new System.EventHandler(this.btnAccuracy_Click);
            // 
            // labelAccArea
            // 
            this.labelAccArea.AutoSize = true;
            this.labelAccArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAccArea.Location = new System.Drawing.Point(21, 124);
            this.labelAccArea.Name = "labelAccArea";
            this.labelAccArea.Size = new System.Drawing.Size(0, 20);
            this.labelAccArea.TabIndex = 5;
            // 
            // CalculationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 165);
            this.Controls.Add(this.labelAccArea);
            this.Controls.Add(this.btnAccuracy);
            this.Controls.Add(this.labelPer);
            this.Controls.Add(this.labelArea);
            this.Controls.Add(this.titlePer);
            this.Controls.Add(this.titleArea);
            this.Name = "CalculationsForm";
            this.Text = "CalculationsForm";
            this.Load += new System.EventHandler(this.CalculationsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleArea;
        private System.Windows.Forms.Label titlePer;
        private System.Windows.Forms.Label labelPer;
        private System.Windows.Forms.Label labelArea;
        private System.Windows.Forms.Button btnAccuracy;
        private System.Windows.Forms.Label labelAccArea;
    }
}