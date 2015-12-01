namespace WindowsFormsApplication6
{
    partial class add_mschine
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.longitude = new System.Windows.Forms.TextBox();
            this.latitude = new System.Windows.Forms.TextBox();
            this.add_machine_save = new System.Windows.Forms.Button();
            this.add_machine_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "经度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "纬度";
            // 
            // longitude
            // 
            this.longitude.Location = new System.Drawing.Point(98, 50);
            this.longitude.Name = "longitude";
            this.longitude.Size = new System.Drawing.Size(100, 21);
            this.longitude.TabIndex = 2;
            // 
            // latitude
            // 
            this.latitude.Location = new System.Drawing.Point(98, 91);
            this.latitude.Name = "latitude";
            this.latitude.Size = new System.Drawing.Size(100, 21);
            this.latitude.TabIndex = 3;
            // 
            // add_machine_save
            // 
            this.add_machine_save.Location = new System.Drawing.Point(98, 216);
            this.add_machine_save.Name = "add_machine_save";
            this.add_machine_save.Size = new System.Drawing.Size(75, 23);
            this.add_machine_save.TabIndex = 4;
            this.add_machine_save.Text = "添加";
            this.add_machine_save.UseVisualStyleBackColor = true;
            this.add_machine_save.Click += new System.EventHandler(this.add_machine_save_Click);
            // 
            // add_machine_cancel
            // 
            this.add_machine_cancel.Location = new System.Drawing.Point(188, 216);
            this.add_machine_cancel.Name = "add_machine_cancel";
            this.add_machine_cancel.Size = new System.Drawing.Size(75, 23);
            this.add_machine_cancel.TabIndex = 5;
            this.add_machine_cancel.Text = "取消";
            this.add_machine_cancel.UseVisualStyleBackColor = true;
            // 
            // add_mschine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.add_machine_cancel);
            this.Controls.Add(this.add_machine_save);
            this.Controls.Add(this.latitude);
            this.Controls.Add(this.longitude);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "add_mschine";
            this.Text = "添加新的设备";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox longitude;
        private System.Windows.Forms.TextBox latitude;
        private System.Windows.Forms.Button add_machine_save;
        private System.Windows.Forms.Button add_machine_cancel;
    }
}