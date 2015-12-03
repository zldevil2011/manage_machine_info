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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.longitude = new System.Windows.Forms.TextBox();
            this.latitude = new System.Windows.Forms.TextBox();
            this.add_machine_save = new System.Windows.Forms.Button();
            this.add_machine_cancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.install_time = new System.Windows.Forms.TextBox();
            this.location = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.machine_name = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "经度";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "纬度";
            // 
            // longitude
            // 
            this.longitude.Location = new System.Drawing.Point(99, 125);
            this.longitude.Name = "longitude";
            this.longitude.Size = new System.Drawing.Size(100, 21);
            this.longitude.TabIndex = 4;
            // 
            // latitude
            // 
            this.latitude.Location = new System.Drawing.Point(98, 165);
            this.latitude.Name = "latitude";
            this.latitude.Size = new System.Drawing.Size(100, 21);
            this.latitude.TabIndex = 5;
            // 
            // add_machine_save
            // 
            this.add_machine_save.Location = new System.Drawing.Point(98, 216);
            this.add_machine_save.Name = "add_machine_save";
            this.add_machine_save.Size = new System.Drawing.Size(75, 23);
            this.add_machine_save.TabIndex = 6;
            this.add_machine_save.Text = "添加";
            this.add_machine_save.UseVisualStyleBackColor = true;
            this.add_machine_save.Click += new System.EventHandler(this.add_machine_save_Click);
            // 
            // add_machine_cancel
            // 
            this.add_machine_cancel.Location = new System.Drawing.Point(188, 216);
            this.add_machine_cancel.Name = "add_machine_cancel";
            this.add_machine_cancel.Size = new System.Drawing.Size(75, 23);
            this.add_machine_cancel.TabIndex = 7;
            this.add_machine_cancel.Text = "取消";
            this.add_machine_cancel.UseVisualStyleBackColor = true;
            this.add_machine_cancel.Click += new System.EventHandler(this.add_machine_cancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "安装时间";
            // 
            // install_time
            // 
            this.install_time.Location = new System.Drawing.Point(101, 88);
            this.install_time.Name = "install_time";
            this.install_time.Size = new System.Drawing.Size(100, 21);
            this.install_time.TabIndex = 3;
            // 
            // location
            // 
            this.location.Location = new System.Drawing.Point(101, 53);
            this.location.Name = "location";
            this.location.Size = new System.Drawing.Size(100, 21);
            this.location.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "安装位置";
            // 
            // machine_name
            // 
            this.machine_name.Location = new System.Drawing.Point(104, 17);
            this.machine_name.Name = "machine_name";
            this.machine_name.Size = new System.Drawing.Size(100, 21);
            this.machine_name.TabIndex = 1;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(38, 20);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(53, 12);
            this.label.TabIndex = 10;
            this.label.Text = "设备名称";
            // 
            // add_mschine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.machine_name);
            this.Controls.Add(this.label);
            this.Controls.Add(this.location);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.install_time);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.add_machine_cancel);
            this.Controls.Add(this.add_machine_save);
            this.Controls.Add(this.latitude);
            this.Controls.Add(this.longitude);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "add_mschine";
            this.Text = "添加新的设备";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox longitude;
        private System.Windows.Forms.TextBox latitude;
        private System.Windows.Forms.Button add_machine_save;
        private System.Windows.Forms.Button add_machine_cancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox install_time;
        private System.Windows.Forms.TextBox location;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox machine_name;
        private System.Windows.Forms.Label label;
    }
}