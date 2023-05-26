namespace GUI
{
    partial class GUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.ExitBtn = new System.Windows.Forms.Button();
            this.AddessLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Key = new System.Windows.Forms.TextBox();
            this.Msg = new System.Windows.Forms.TextBox();
            this.EncMsg = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.min = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.SystemColors.Window;
            this.ExitBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ExitBtn.FlatAppearance.BorderSize = 3;
            this.ExitBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ExitBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            resources.ApplyResources(this.ExitBtn, "ExitBtn");
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // AddessLbl
            // 
            resources.ApplyResources(this.AddessLbl, "AddessLbl");
            this.AddessLbl.Name = "AddessLbl";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Key
            // 
            resources.ApplyResources(this.Key, "Key");
            this.Key.Name = "Key";
            // 
            // Msg
            // 
            resources.ApplyResources(this.Msg, "Msg");
            this.Msg.Name = "Msg";
            this.Msg.TextChanged += new System.EventHandler(this.Msg_TextChanged);
            // 
            // EncMsg
            // 
            resources.ApplyResources(this.EncMsg, "EncMsg");
            this.EncMsg.Name = "EncMsg";
            this.EncMsg.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.min);
            this.panel1.Controls.Add(this.AddessLbl);
            this.panel1.Controls.Add(this.ExitBtn);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // min
            // 
            resources.ApplyResources(this.min, "min");
            this.min.Name = "min";
            this.min.UseVisualStyleBackColor = true;
            this.min.Click += new System.EventHandler(this.min_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // GUI
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.EncMsg);
            this.Controls.Add(this.Msg);
            this.Controls.Add(this.Key);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GUI";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Label AddessLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Key;
        private System.Windows.Forms.TextBox Msg;
        private System.Windows.Forms.TextBox EncMsg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button min;
        private System.Windows.Forms.Label label4;
    }
}

