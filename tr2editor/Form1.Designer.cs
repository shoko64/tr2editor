
namespace tr2editor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ids = new System.Windows.Forms.ListBox();
            this.open = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.text = new System.Windows.Forms.Label();
            this.entry = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.info = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ids
            // 
            this.ids.FormattingEnabled = true;
            this.ids.ItemHeight = 15;
            this.ids.Location = new System.Drawing.Point(59, 123);
            this.ids.Name = "ids";
            this.ids.Size = new System.Drawing.Size(250, 244);
            this.ids.TabIndex = 1;
            this.ids.SelectedIndexChanged += new System.EventHandler(this.ids_SelectedIndexChanged);
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(328, 127);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(188, 23);
            this.open.TabIndex = 2;
            this.open.Text = "Open";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(328, 339);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(188, 23);
            this.close.TabIndex = 3;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.button1_Click);
            // 
            // text
            // 
            this.text.AutoSize = true;
            this.text.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.text.Location = new System.Drawing.Point(261, 21);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(490, 50);
            this.text.TabIndex = 4;
            this.text.Text = "tr2editor Created by shoko";
            this.text.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // entry
            // 
            this.entry.Location = new System.Drawing.Point(537, 128);
            this.entry.Multiline = true;
            this.entry.Name = "entry";
            this.entry.ReadOnly = true;
            this.entry.Size = new System.Drawing.Size(436, 234);
            this.entry.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Entries";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Location = new System.Drawing.Point(670, 405);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(0, 15);
            this.info.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 469);
            this.Controls.Add(this.info);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.entry);
            this.Controls.Add(this.text);
            this.Controls.Add(this.close);
            this.Controls.Add(this.open);
            this.Controls.Add(this.ids);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "tr2editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox ids;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Label text;
        private System.Windows.Forms.TextBox entry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label info;
    }
}

