namespace Code_NT106.Q14._2_Lab03_Group3_24521557_24520331_24521560_24521538_24521213
{
    partial class Bai02Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnListen = new Button();
            listViewCommand = new ListView();
            SuspendLayout();
            // 
            // btnListen
            // 
            btnListen.Location = new Point(416, 16);
            btnListen.Margin = new Padding(2, 2, 2, 2);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(88, 32);
            btnListen.TabIndex = 0;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = true;
            btnListen.Click += StartListen;
            // 
            // listViewCommand
            // 
            listViewCommand.Font = new Font("Consolas", 12F);
            listViewCommand.Location = new Point(16, 56);
            listViewCommand.Margin = new Padding(2, 2, 2, 2);
            listViewCommand.Name = "listViewCommand";
            listViewCommand.Size = new Size(489, 305);
            listViewCommand.TabIndex = 1;
            listViewCommand.UseCompatibleStateImageBehavior = false;
            listViewCommand.View = View.List;
            // 
            // Bai02Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 376);
            Controls.Add(listViewCommand);
            Controls.Add(btnListen);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            Name = "Bai02Form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 02 - TCP Telnet Server";
            ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.ListView listViewCommand;
    }
}
