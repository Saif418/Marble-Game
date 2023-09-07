using Timer;

namespace Saif_assignment_2

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
            this.TLP1 = new System.Windows.Forms.TableLayoutPanel();
            this.TLP2 = new System.Windows.Forms.TableLayoutPanel();
            this.button5 = new System.Windows.Forms.Button();
            this.TPL4 = new System.Windows.Forms.TableLayoutPanel();
            this.Left = new System.Windows.Forms.Button();
            this.Down = new System.Windows.Forms.Button();
            this.Up = new System.Windows.Forms.Button();
            this.Right = new System.Windows.Forms.Button();
            this.clock1 = new Timer.Clock();
            this.Pause_button = new System.Windows.Forms.Button();
            this.Resume_button = new System.Windows.Forms.Button();
            this.ScoreList = new System.Windows.Forms.ListView();
            this.PName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Moves = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TLP1.SuspendLayout();
            this.TLP2.SuspendLayout();
            this.TPL4.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLP1
            // 
            this.TLP1.ColumnCount = 2;
            this.TLP1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.TLP1.Controls.Add(this.TLP2, 1, 0);
            this.TLP1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP1.Location = new System.Drawing.Point(0, 0);
            this.TLP1.Margin = new System.Windows.Forms.Padding(0);
            this.TLP1.Name = "TLP1";
            this.TLP1.RowCount = 1;
            this.TLP1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP1.Size = new System.Drawing.Size(895, 695);
            this.TLP1.TabIndex = 5;
            this.TLP1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // TLP2
            // 
            this.TLP2.ColumnCount = 2;
            this.TLP2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.TLP2.Controls.Add(this.button5, 0, 0);
            this.TLP2.Controls.Add(this.TPL4, 0, 1);
            this.TLP2.Controls.Add(this.clock1, 0, 2);
            this.TLP2.Controls.Add(this.Pause_button, 0, 3);
            this.TLP2.Controls.Add(this.Resume_button, 1, 3);
            this.TLP2.Controls.Add(this.ScoreList, 0, 4);
            this.TLP2.Dock = System.Windows.Forms.DockStyle.Right;
            this.TLP2.Location = new System.Drawing.Point(695, 0);
            this.TLP2.Margin = new System.Windows.Forms.Padding(0);
            this.TLP2.Name = "TLP2";
            this.TLP2.RowCount = 5;
            this.TLP2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.857144F));
            this.TLP2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.9854F));
            this.TLP2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.22775F));
            this.TLP2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.223228F));
            this.TLP2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.77979F));
            this.TLP2.Size = new System.Drawing.Size(200, 695);
            this.TLP2.TabIndex = 6;
            this.TLP2.Paint += new System.Windows.Forms.PaintEventHandler(this.TLP2_Paint);
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Location = new System.Drawing.Point(0, 0);
            this.button5.Margin = new System.Windows.Forms.Padding(0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(158, 33);
            this.button5.TabIndex = 4;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // TPL4
            // 
            this.TPL4.ColumnCount = 2;
            this.TPL4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TPL4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TPL4.Controls.Add(this.Left, 0, 1);
            this.TPL4.Controls.Add(this.Down, 1, 1);
            this.TPL4.Controls.Add(this.Up, 0, 0);
            this.TPL4.Controls.Add(this.Right, 1, 0);
            this.TPL4.Location = new System.Drawing.Point(3, 36);
            this.TPL4.Name = "TPL4";
            this.TPL4.RowCount = 2;
            this.TPL4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TPL4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TPL4.Size = new System.Drawing.Size(134, 168);
            this.TPL4.TabIndex = 5;
            // 
            // Left
            // 
            this.Left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Left.Enabled = false;
            this.Left.Location = new System.Drawing.Point(0, 84);
            this.Left.Margin = new System.Windows.Forms.Padding(0);
            this.Left.Name = "Left";
            this.Left.Size = new System.Drawing.Size(67, 84);
            this.Left.TabIndex = 1;
            this.Left.Text = "LEFT";
            this.Left.UseVisualStyleBackColor = true;
            this.Left.Click += new System.EventHandler(this.button6_Click);
            // 
            // Down
            // 
            this.Down.Enabled = false;
            this.Down.Location = new System.Drawing.Point(67, 84);
            this.Down.Margin = new System.Windows.Forms.Padding(0);
            this.Down.Name = "Down";
            this.Down.Size = new System.Drawing.Size(67, 84);
            this.Down.TabIndex = 3;
            this.Down.Text = "DOWN";
            this.Down.UseVisualStyleBackColor = true;
            this.Down.Click += new System.EventHandler(this.button8_Click);
            // 
            // Up
            // 
            this.Up.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Up.Enabled = false;
            this.Up.Location = new System.Drawing.Point(0, 0);
            this.Up.Margin = new System.Windows.Forms.Padding(0);
            this.Up.Name = "Up";
            this.Up.Size = new System.Drawing.Size(67, 84);
            this.Up.TabIndex = 0;
            this.Up.Text = "UP";
            this.Up.UseVisualStyleBackColor = true;
            this.Up.Click += new System.EventHandler(this.button5_Click);
            // 
            // Right
            // 
            this.Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Right.Enabled = false;
            this.Right.Location = new System.Drawing.Point(67, 0);
            this.Right.Margin = new System.Windows.Forms.Padding(0);
            this.Right.Name = "Right";
            this.Right.Size = new System.Drawing.Size(67, 84);
            this.Right.TabIndex = 2;
            this.Right.Text = "RIGHT";
            this.Right.UseVisualStyleBackColor = true;
            this.Right.Click += new System.EventHandler(this.button7_Click);
            // 
            // clock1
            // 
            this.clock1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clock1.Location = new System.Drawing.Point(3, 216);
            this.clock1.Name = "clock1";
            this.clock1.Size = new System.Drawing.Size(152, 155);
            this.clock1.TabIndex = 6;
            this.clock1.Load += new System.EventHandler(this.clock1_Load);
            // 
            // Pause_button
            // 
            this.Pause_button.Location = new System.Drawing.Point(3, 377);
            this.Pause_button.Name = "Pause_button";
            this.Pause_button.Size = new System.Drawing.Size(152, 22);
            this.Pause_button.TabIndex = 7;
            this.Pause_button.Text = "Pause";
            this.Pause_button.UseVisualStyleBackColor = true;
            this.Pause_button.Click += new System.EventHandler(this.Pause_button_Click);
            // 
            // Resume_button
            // 
            this.Resume_button.Location = new System.Drawing.Point(161, 377);
            this.Resume_button.Name = "Resume_button";
            this.Resume_button.Size = new System.Drawing.Size(36, 22);
            this.Resume_button.TabIndex = 10;
            this.Resume_button.Text = "Resume";
            this.Resume_button.UseVisualStyleBackColor = true;
            this.Resume_button.Click += new System.EventHandler(this.Resume_button_Click);
            // 
            // ScoreList
            // 
            this.ScoreList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PName,
            this.Moves,
            this.Time});
            this.ScoreList.HideSelection = false;
            this.ScoreList.Location = new System.Drawing.Point(3, 406);
            this.ScoreList.Name = "ScoreList";
            this.ScoreList.Size = new System.Drawing.Size(152, 286);
            this.ScoreList.TabIndex = 8;
            this.ScoreList.UseCompatibleStateImageBehavior = false;
            this.ScoreList.View = System.Windows.Forms.View.Details;
            this.ScoreList.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // PName
            // 
            this.PName.Text = "Name";
            // 
            // Moves
            // 
            this.Moves.Text = "Moves";
            this.Moves.Width = 45;
            // 
            // Time
            // 
            this.Time.Text = "Time";
            this.Time.Width = 45;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(895, 695);
            this.Controls.Add(this.TLP1);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.TLP1.ResumeLayout(false);
            this.TLP2.ResumeLayout(false);
            this.TPL4.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;



        #endregion
        private System.Windows.Forms.TableLayoutPanel TLP1;
        private System.Windows.Forms.TableLayoutPanel TLP2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TableLayoutPanel TPL4;
        private System.Windows.Forms.Button Left;
        private System.Windows.Forms.Button Down;
        private System.Windows.Forms.Button Up;
        private System.Windows.Forms.Button Right;
        private Clock clock1;
        private System.Windows.Forms.Button Pause_button;
        private System.Windows.Forms.Button Resume_button;
        private System.Windows.Forms.ListView ScoreList;
        private System.Windows.Forms.ColumnHeader PName;
        private System.Windows.Forms.ColumnHeader Moves;
        private System.Windows.Forms.ColumnHeader Time;
    }

}
