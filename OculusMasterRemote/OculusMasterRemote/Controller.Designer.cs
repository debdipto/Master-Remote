namespace EvergreenMasterRemote
{
    partial class Controller
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_MonitorOn = new System.Windows.Forms.Button();
            this.btn_MonitorOff = new System.Windows.Forms.Button();
            this.lbl_Monitor = new System.Windows.Forms.Label();
            this.lbl_AudioControls = new System.Windows.Forms.Label();
            this.btn_VolumeUp = new System.Windows.Forms.Button();
            this.btn_Mute = new System.Windows.Forms.Button();
            this.btn_VolumeDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_MonitorOn
            // 
            this.btn_MonitorOn.Location = new System.Drawing.Point(15, 55);
            this.btn_MonitorOn.Name = "btn_MonitorOn";
            this.btn_MonitorOn.Size = new System.Drawing.Size(100, 54);
            this.btn_MonitorOn.TabIndex = 0;
            this.btn_MonitorOn.Text = "Turn Monitor On";
            this.btn_MonitorOn.UseVisualStyleBackColor = true;
            this.btn_MonitorOn.Click += new System.EventHandler(this.btn_MonitorOn_Click);
            // 
            // btn_MonitorOff
            // 
            this.btn_MonitorOff.Location = new System.Drawing.Point(121, 55);
            this.btn_MonitorOff.Name = "btn_MonitorOff";
            this.btn_MonitorOff.Size = new System.Drawing.Size(100, 54);
            this.btn_MonitorOff.TabIndex = 1;
            this.btn_MonitorOff.Text = "Turn Monitor Off";
            this.btn_MonitorOff.UseVisualStyleBackColor = true;
            this.btn_MonitorOff.Click += new System.EventHandler(this.btn_MonitorOff_Click);
            // 
            // lbl_Monitor
            // 
            this.lbl_Monitor.AutoSize = true;
            this.lbl_Monitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Monitor.Location = new System.Drawing.Point(11, 18);
            this.lbl_Monitor.Name = "lbl_Monitor";
            this.lbl_Monitor.Size = new System.Drawing.Size(147, 24);
            this.lbl_Monitor.TabIndex = 2;
            this.lbl_Monitor.Text = "Monitor Controls";
            // 
            // lbl_AudioControls
            // 
            this.lbl_AudioControls.AutoSize = true;
            this.lbl_AudioControls.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AudioControls.Location = new System.Drawing.Point(11, 136);
            this.lbl_AudioControls.Name = "lbl_AudioControls";
            this.lbl_AudioControls.Size = new System.Drawing.Size(134, 24);
            this.lbl_AudioControls.TabIndex = 3;
            this.lbl_AudioControls.Text = "Audio Controls";
            // 
            // btn_VolumeUp
            // 
            this.btn_VolumeUp.Location = new System.Drawing.Point(121, 175);
            this.btn_VolumeUp.Name = "btn_VolumeUp";
            this.btn_VolumeUp.Size = new System.Drawing.Size(100, 54);
            this.btn_VolumeUp.TabIndex = 5;
            this.btn_VolumeUp.Text = "Volume up";
            this.btn_VolumeUp.UseVisualStyleBackColor = true;
            this.btn_VolumeUp.Click += new System.EventHandler(this.btn_VolumeUp_Click);
            // 
            // btn_Mute
            // 
            this.btn_Mute.Location = new System.Drawing.Point(15, 175);
            this.btn_Mute.Name = "btn_Mute";
            this.btn_Mute.Size = new System.Drawing.Size(100, 54);
            this.btn_Mute.TabIndex = 4;
            this.btn_Mute.Text = "Mute";
            this.btn_Mute.UseVisualStyleBackColor = true;
            this.btn_Mute.Click += new System.EventHandler(this.btn_Mute_Click);
            // 
            // btn_VolumeDown
            // 
            this.btn_VolumeDown.Location = new System.Drawing.Point(227, 175);
            this.btn_VolumeDown.Name = "btn_VolumeDown";
            this.btn_VolumeDown.Size = new System.Drawing.Size(100, 54);
            this.btn_VolumeDown.TabIndex = 6;
            this.btn_VolumeDown.Text = "Volume down";
            this.btn_VolumeDown.UseVisualStyleBackColor = true;
            this.btn_VolumeDown.Click += new System.EventHandler(this.btn_VolumeDown_Click);
            // 
            // Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btn_VolumeDown);
            this.Controls.Add(this.btn_VolumeUp);
            this.Controls.Add(this.btn_Mute);
            this.Controls.Add(this.lbl_AudioControls);
            this.Controls.Add(this.lbl_Monitor);
            this.Controls.Add(this.btn_MonitorOff);
            this.Controls.Add(this.btn_MonitorOn);
            this.Name = "Controller";
            this.Size = new System.Drawing.Size(680, 448);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_MonitorOn;
        private System.Windows.Forms.Button btn_MonitorOff;
        private System.Windows.Forms.Label lbl_Monitor;
        private System.Windows.Forms.Label lbl_AudioControls;
        private System.Windows.Forms.Button btn_VolumeUp;
        private System.Windows.Forms.Button btn_Mute;
        private System.Windows.Forms.Button btn_VolumeDown;
    }
}
