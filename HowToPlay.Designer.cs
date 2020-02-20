namespace CST343Project
{
    partial class HowToPlay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HowToPlay));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RulesTextBox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.firstDie = new System.Windows.Forms.PictureBox();
            this.secondDie = new System.Windows.Forms.PictureBox();
            this.thirdDie = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.firstDie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondDie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdDie)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(431, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rules";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-3020, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(300, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // RulesTextBox
            // 
            this.RulesTextBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.RulesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RulesTextBox.Location = new System.Drawing.Point(182, 175);
            this.RulesTextBox.Name = "RulesTextBox";
            this.RulesTextBox.ReadOnly = true;
            this.RulesTextBox.Size = new System.Drawing.Size(585, 227);
            this.RulesTextBox.TabIndex = 2;
            this.RulesTextBox.Text = resources.GetString("RulesTextBox.Text");
            this.RulesTextBox.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.IndianRed;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(407, 420);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 45);
            this.button1.TabIndex = 3;
            this.button1.Text = "Main Menu";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // firstDie
            // 
            this.firstDie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.firstDie.Image = ((System.Drawing.Image)(resources.GetObject("firstDie.Image")));
            this.firstDie.Location = new System.Drawing.Point(391, 68);
            this.firstDie.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.firstDie.Name = "firstDie";
            this.firstDie.Size = new System.Drawing.Size(51, 56);
            this.firstDie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.firstDie.TabIndex = 31;
            this.firstDie.TabStop = false;
            // 
            // secondDie
            // 
            this.secondDie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.secondDie.Image = ((System.Drawing.Image)(resources.GetObject("secondDie.Image")));
            this.secondDie.Location = new System.Drawing.Point(448, 68);
            this.secondDie.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.secondDie.Name = "secondDie";
            this.secondDie.Size = new System.Drawing.Size(51, 56);
            this.secondDie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.secondDie.TabIndex = 33;
            this.secondDie.TabStop = false;
            // 
            // thirdDie
            // 
            this.thirdDie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.thirdDie.Image = ((System.Drawing.Image)(resources.GetObject("thirdDie.Image")));
            this.thirdDie.Location = new System.Drawing.Point(505, 68);
            this.thirdDie.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.thirdDie.Name = "thirdDie";
            this.thirdDie.Size = new System.Drawing.Size(51, 56);
            this.thirdDie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.thirdDie.TabIndex = 34;
            this.thirdDie.TabStop = false;
            // 
            // HowToPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::CST343Project.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(927, 569);
            this.Controls.Add(this.thirdDie);
            this.Controls.Add(this.secondDie);
            this.Controls.Add(this.firstDie);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RulesTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(945, 616);
            this.MinimumSize = new System.Drawing.Size(945, 616);
            this.Name = "HowToPlay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Left Center Right";
            ((System.ComponentModel.ISupportInitialize)(this.firstDie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondDie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thirdDie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox RulesTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox firstDie;
        private System.Windows.Forms.PictureBox secondDie;
        private System.Windows.Forms.PictureBox thirdDie;
    }
}