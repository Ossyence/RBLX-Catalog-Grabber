
namespace Roblox_Catalog_Items_Grabber
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.title = new System.Windows.Forms.Label();
            this.button_run = new System.Windows.Forms.Button();
            this.button_copy = new System.Windows.Forms.Button();
            this.progress_running = new System.Windows.Forms.Label();
            this.progress_done = new System.Windows.Forms.Label();
            this.debugMode_box = new System.Windows.Forms.CheckBox();
            this.topIcon = new System.Windows.Forms.PictureBox();
            this.result_text = new System.Windows.Forms.Label();
            this.button_cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.topIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.Color.White;
            this.title.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.SystemColors.InfoText;
            this.title.Location = new System.Drawing.Point(69, 3);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(321, 28);
            this.title.TabIndex = 0;
            this.title.Text = "Roblox Catalog Item Grabber";
            // 
            // button_run
            // 
            this.button_run.BackColor = System.Drawing.Color.White;
            this.button_run.ForeColor = System.Drawing.SystemColors.InfoText;
            this.button_run.Location = new System.Drawing.Point(277, 411);
            this.button_run.Name = "button_run";
            this.button_run.Size = new System.Drawing.Size(400, 34);
            this.button_run.TabIndex = 10;
            this.button_run.Text = "Run (may take a while)";
            this.button_run.UseVisualStyleBackColor = false;
            this.button_run.Click += new System.EventHandler(this.button_run_Click);
            // 
            // button_copy
            // 
            this.button_copy.BackColor = System.Drawing.Color.White;
            this.button_copy.ForeColor = System.Drawing.SystemColors.InfoText;
            this.button_copy.Location = new System.Drawing.Point(683, 411);
            this.button_copy.Name = "button_copy";
            this.button_copy.Size = new System.Drawing.Size(112, 34);
            this.button_copy.TabIndex = 11;
            this.button_copy.Text = "Copy Result";
            this.button_copy.UseVisualStyleBackColor = false;
            this.button_copy.Click += new System.EventHandler(this.button_copy_Click);
            // 
            // progress_running
            // 
            this.progress_running.BackColor = System.Drawing.Color.White;
            this.progress_running.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progress_running.ForeColor = System.Drawing.SystemColors.InfoText;
            this.progress_running.Location = new System.Drawing.Point(419, 31);
            this.progress_running.Name = "progress_running";
            this.progress_running.Size = new System.Drawing.Size(376, 19);
            this.progress_running.TabIndex = 13;
            this.progress_running.Text = "Running: null/null, null";
            this.progress_running.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progress_done
            // 
            this.progress_done.BackColor = System.Drawing.Color.White;
            this.progress_done.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progress_done.ForeColor = System.Drawing.SystemColors.InfoText;
            this.progress_done.Location = new System.Drawing.Point(423, 12);
            this.progress_done.Name = "progress_done";
            this.progress_done.Size = new System.Drawing.Size(372, 19);
            this.progress_done.TabIndex = 14;
            this.progress_done.Text = "Done: null/null";
            this.progress_done.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // debugMode_box
            // 
            this.debugMode_box.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.debugMode_box.Location = new System.Drawing.Point(74, 31);
            this.debugMode_box.Name = "debugMode_box";
            this.debugMode_box.Size = new System.Drawing.Size(173, 19);
            this.debugMode_box.TabIndex = 15;
            this.debugMode_box.Text = "Debug Mode";
            this.debugMode_box.UseVisualStyleBackColor = true;
            this.debugMode_box.CheckedChanged += new System.EventHandler(this.debugMode_box_CheckedChanged);
            // 
            // topIcon
            // 
            this.topIcon.BackColor = System.Drawing.Color.Transparent;
            this.topIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.topIcon.ErrorImage = null;
            this.topIcon.Image = ((System.Drawing.Image)(resources.GetObject("topIcon.Image")));
            this.topIcon.InitialImage = null;
            this.topIcon.Location = new System.Drawing.Point(3, 3);
            this.topIcon.Name = "topIcon";
            this.topIcon.Size = new System.Drawing.Size(60, 59);
            this.topIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.topIcon.TabIndex = 16;
            this.topIcon.TabStop = false;
            // 
            // result_text
            // 
            this.result_text.BackColor = System.Drawing.Color.White;
            this.result_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.result_text.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result_text.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.result_text.Location = new System.Drawing.Point(3, 65);
            this.result_text.Name = "result_text";
            this.result_text.Size = new System.Drawing.Size(792, 343);
            this.result_text.TabIndex = 0;
            this.result_text.Text = "Press run to start!";
            // 
            // button_cancel
            // 
            this.button_cancel.BackColor = System.Drawing.Color.White;
            this.button_cancel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.button_cancel.Location = new System.Drawing.Point(3, 411);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(268, 34);
            this.button_cancel.TabIndex = 17;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = false;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.result_text);
            this.Controls.Add(this.topIcon);
            this.Controls.Add(this.debugMode_box);
            this.Controls.Add(this.progress_done);
            this.Controls.Add(this.progress_running);
            this.Controls.Add(this.button_copy);
            this.Controls.Add(this.button_run);
            this.Controls.Add(this.title);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Roblox Catalog Grabber";
            ((System.ComponentModel.ISupportInitialize)(this.topIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button button_run;
        private System.Windows.Forms.Button button_copy;
        public System.Windows.Forms.Label progress_running;
        public System.Windows.Forms.Label progress_done;
        private System.Windows.Forms.CheckBox debugMode_box;
        private System.Windows.Forms.PictureBox topIcon;
        private System.Windows.Forms.Label result_text;
        private System.Windows.Forms.Button button_cancel;
    }
}

