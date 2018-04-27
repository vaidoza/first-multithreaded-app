namespace WinFormsWithThreadsDB
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
            this.listViewThreadCtrl = new System.Windows.Forms.ListView();
            this.colRowNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colThreadId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGenText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbxThreadCnt = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewThreadCtrl
            // 
            this.listViewThreadCtrl.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRowNo,
            this.colThreadId,
            this.colGenText});
            this.listViewThreadCtrl.Location = new System.Drawing.Point(23, 81);
            this.listViewThreadCtrl.Name = "listViewThreadCtrl";
            this.listViewThreadCtrl.Size = new System.Drawing.Size(301, 287);
            this.listViewThreadCtrl.TabIndex = 1;
            this.listViewThreadCtrl.UseCompatibleStateImageBehavior = false;
            this.listViewThreadCtrl.View = System.Windows.Forms.View.Details;
            // 
            // colRowNo
            // 
            this.colRowNo.Text = "No.";
            // 
            // colThreadId
            // 
            this.colThreadId.Text = "Thread ID";
            this.colThreadId.Width = 103;
            // 
            // colGenText
            // 
            this.colGenText.Text = "Generated text";
            this.colGenText.Width = 173;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(182, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(83, 29);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Threads count";
            // 
            // txtbxThreadCnt
            // 
            this.txtbxThreadCnt.Location = new System.Drawing.Point(102, 21);
            this.txtbxThreadCnt.Name = "txtbxThreadCnt";
            this.txtbxThreadCnt.Size = new System.Drawing.Size(40, 20);
            this.txtbxThreadCnt.TabIndex = 4;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(182, 47);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(83, 28);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 394);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.txtbxThreadCnt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.listViewThreadCtrl);
            this.Name = "Form1";
            this.Text = "Multithreading app";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listViewThreadCtrl;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbxThreadCnt;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ColumnHeader colThreadId;
        private System.Windows.Forms.ColumnHeader colGenText;
        private System.Windows.Forms.ColumnHeader colRowNo;
    }
}

