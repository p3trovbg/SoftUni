
namespace SnakeGame
{
    partial class GameForm
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
            this.components = new System.ComponentModel.Container();
            this.StartButton = new System.Windows.Forms.Button();
            this.Map = new System.Windows.Forms.PictureBox();
            this.txtScore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.fieldNickname = new System.Windows.Forms.TextBox();
            this.txtNickname = new System.Windows.Forms.Label();
            this.applyNameButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Map)).BeginInit();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.Chartreuse;
            this.StartButton.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.StartButton.Location = new System.Drawing.Point(580, 14);
            this.StartButton.Margin = new System.Windows.Forms.Padding(5);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(101, 43);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartGame);
            // 
            // Map
            // 
            this.Map.BackColor = System.Drawing.Color.AntiqueWhite;
            this.Map.Location = new System.Drawing.Point(14, 14);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(560, 626);
            this.Map.TabIndex = 2;
            this.Map.TabStop = false;
            this.Map.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdatePictureBox);
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.BackColor = System.Drawing.SystemColors.Info;
            this.txtScore.Font = new System.Drawing.Font("Microsoft Uighur", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore.Location = new System.Drawing.Point(580, 73);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(90, 43);
            this.txtScore.TabIndex = 3;
            this.txtScore.Text = "Score: 0";
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 55;
            this.gameTimer.Tick += new System.EventHandler(this.GameTimerEvent);
            // 
            // fieldNickname
            // 
            this.fieldNickname.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fieldNickname.Location = new System.Drawing.Point(585, 172);
            this.fieldNickname.Multiline = true;
            this.fieldNickname.Name = "fieldNickname";
            this.fieldNickname.Size = new System.Drawing.Size(192, 33);
            this.fieldNickname.TabIndex = 4;
            // 
            // txtNickname
            // 
            this.txtNickname.AutoSize = true;
            this.txtNickname.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNickname.Location = new System.Drawing.Point(580, 140);
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.Size = new System.Drawing.Size(186, 29);
            this.txtNickname.TabIndex = 5;
            this.txtNickname.Text = "Your nickname";
            // 
            // applyNameButton
            // 
            this.applyNameButton.BackColor = System.Drawing.Color.Lime;
            this.applyNameButton.Font = new System.Drawing.Font("Papyrus", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyNameButton.Location = new System.Drawing.Point(647, 221);
            this.applyNameButton.Name = "applyNameButton";
            this.applyNameButton.Size = new System.Drawing.Size(130, 34);
            this.applyNameButton.TabIndex = 6;
            this.applyNameButton.Text = "Apply name";
            this.applyNameButton.UseVisualStyleBackColor = false;
            this.applyNameButton.Click += new System.EventHandler(this.NameButton);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(784, 658);
            this.Controls.Add(this.applyNameButton);
            this.Controls.Add(this.txtNickname);
            this.Controls.Add(this.fieldNickname);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.Map);
            this.Controls.Add(this.StartButton);
            this.Name = "GameForm";
            this.Text = "SnakeGame V1.2";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeysDown);
            ((System.ComponentModel.ISupportInitialize)(this.Map)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.PictureBox Map;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.TextBox fieldNickname;
        private System.Windows.Forms.Label txtNickname;
        private System.Windows.Forms.Button applyNameButton;
    }
}

