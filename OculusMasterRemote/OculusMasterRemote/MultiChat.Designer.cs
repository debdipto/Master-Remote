namespace EvergreenMasterRemote
{
    partial class MultiChat
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
            this.txtb_Input = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.btn_SendFile = new System.Windows.Forms.Button();
            this.txtb_Display = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtb_Input
            // 
            this.txtb_Input.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtb_Input.BackColor = System.Drawing.Color.White;
            this.txtb_Input.Location = new System.Drawing.Point(4, 322);
            this.txtb_Input.Multiline = true;
            this.txtb_Input.Name = "txtb_Input";
            this.txtb_Input.Size = new System.Drawing.Size(673, 68);
            this.txtb_Input.TabIndex = 0;
            this.txtb_Input.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtb_Input_KeyUp);
            // 
            // btn_Send
            // 
            this.btn_Send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Send.Location = new System.Drawing.Point(4, 397);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(153, 48);
            this.btn_Send.TabIndex = 1;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // btn_SendFile
            // 
            this.btn_SendFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SendFile.Location = new System.Drawing.Point(524, 397);
            this.btn_SendFile.Name = "btn_SendFile";
            this.btn_SendFile.Size = new System.Drawing.Size(153, 48);
            this.btn_SendFile.TabIndex = 2;
            this.btn_SendFile.Text = "Send File";
            this.btn_SendFile.UseVisualStyleBackColor = true;
            // 
            // txtb_Display
            // 
            this.txtb_Display.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtb_Display.BackColor = System.Drawing.SystemColors.Info;
            this.txtb_Display.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtb_Display.Location = new System.Drawing.Point(4, 4);
            this.txtb_Display.Multiline = true;
            this.txtb_Display.Name = "txtb_Display";
            this.txtb_Display.ReadOnly = true;
            this.txtb_Display.Size = new System.Drawing.Size(673, 312);
            this.txtb_Display.TabIndex = 3;
            // 
            // MultiChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.txtb_Display);
            this.Controls.Add(this.btn_SendFile);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.txtb_Input);
            this.Name = "MultiChat";
            this.Size = new System.Drawing.Size(680, 448);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtb_Input;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Button btn_SendFile;
        private System.Windows.Forms.TextBox txtb_Display;
    }
}
