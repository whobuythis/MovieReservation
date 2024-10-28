
namespace WindowsFormsApp1
{
    partial class 예매
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
            this.bookingbutton = new System.Windows.Forms.Button();
            this.movie_name = new System.Windows.Forms.Label();
            this.release_day = new System.Windows.Forms.Label();
            this.MovieView1 = new System.Windows.Forms.DataGridView();
            this.CinemaView1 = new System.Windows.Forms.DataGridView();
            this.Release_dayView1 = new System.Windows.Forms.DataGridView();
            this.Release_timeView1 = new System.Windows.Forms.DataGridView();
            this.release_time = new System.Windows.Forms.Label();
            this.cinema_name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MovieView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CinemaView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Release_dayView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Release_timeView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bookingbutton
            // 
            this.bookingbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bookingbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bookingbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bookingbutton.Location = new System.Drawing.Point(953, 299);
            this.bookingbutton.Name = "bookingbutton";
            this.bookingbutton.Size = new System.Drawing.Size(115, 46);
            this.bookingbutton.TabIndex = 19;
            this.bookingbutton.Text = "예매하기";
            this.bookingbutton.UseVisualStyleBackColor = false;
            this.bookingbutton.Click += new System.EventHandler(this.bookingbutton_Click);
            // 
            // movie_name
            // 
            this.movie_name.AutoSize = true;
            this.movie_name.Font = new System.Drawing.Font("배달의민족 도현", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.movie_name.Location = new System.Drawing.Point(299, 15);
            this.movie_name.Name = "movie_name";
            this.movie_name.Size = new System.Drawing.Size(72, 25);
            this.movie_name.TabIndex = 24;
            this.movie_name.Text = "영화명";
            // 
            // release_day
            // 
            this.release_day.AutoSize = true;
            this.release_day.Font = new System.Drawing.Font("배달의민족 도현", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.release_day.Location = new System.Drawing.Point(564, 15);
            this.release_day.Name = "release_day";
            this.release_day.Size = new System.Drawing.Size(92, 25);
            this.release_day.TabIndex = 26;
            this.release_day.Text = "상영일자";
            // 
            // MovieView1
            // 
            this.MovieView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MovieView1.Location = new System.Drawing.Point(304, 43);
            this.MovieView1.Name = "MovieView1";
            this.MovieView1.RowTemplate.Height = 23;
            this.MovieView1.Size = new System.Drawing.Size(240, 295);
            this.MovieView1.TabIndex = 32;
            // 
            // CinemaView1
            // 
            this.CinemaView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CinemaView1.Location = new System.Drawing.Point(31, 43);
            this.CinemaView1.Name = "CinemaView1";
            this.CinemaView1.RowTemplate.Height = 23;
            this.CinemaView1.Size = new System.Drawing.Size(240, 295);
            this.CinemaView1.TabIndex = 33;
            // 
            // Release_dayView1
            // 
            this.Release_dayView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Release_dayView1.Location = new System.Drawing.Point(569, 43);
            this.Release_dayView1.Name = "Release_dayView1";
            this.Release_dayView1.RowTemplate.Height = 23;
            this.Release_dayView1.Size = new System.Drawing.Size(240, 295);
            this.Release_dayView1.TabIndex = 34;
            // 
            // Release_timeView1
            // 
            this.Release_timeView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Release_timeView1.Location = new System.Drawing.Point(828, 43);
            this.Release_timeView1.Name = "Release_timeView1";
            this.Release_timeView1.RowTemplate.Height = 23;
            this.Release_timeView1.Size = new System.Drawing.Size(240, 243);
            this.Release_timeView1.TabIndex = 35;
            // 
            // release_time
            // 
            this.release_time.AutoSize = true;
            this.release_time.Font = new System.Drawing.Font("배달의민족 도현", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.release_time.Location = new System.Drawing.Point(823, 15);
            this.release_time.Name = "release_time";
            this.release_time.Size = new System.Drawing.Size(92, 25);
            this.release_time.TabIndex = 36;
            this.release_time.Text = "상영시간";
            // 
            // cinema_name
            // 
            this.cinema_name.AutoSize = true;
            this.cinema_name.Font = new System.Drawing.Font("배달의민족 도현", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cinema_name.Location = new System.Drawing.Point(26, 15);
            this.cinema_name.Name = "cinema_name";
            this.cinema_name.Size = new System.Drawing.Size(72, 25);
            this.cinema_name.TabIndex = 37;
            this.cinema_name.Text = "영화관";
            // 
            // 예매
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 357);
            this.Controls.Add(this.cinema_name);
            this.Controls.Add(this.release_time);
            this.Controls.Add(this.Release_timeView1);
            this.Controls.Add(this.Release_dayView1);
            this.Controls.Add(this.CinemaView1);
            this.Controls.Add(this.MovieView1);
            this.Controls.Add(this.release_day);
            this.Controls.Add(this.movie_name);
            this.Controls.Add(this.bookingbutton);
            this.Name = "예매";
            this.Text = "영화예매";
            this.Load += new System.EventHandler(this.예매_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MovieView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CinemaView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Release_dayView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Release_timeView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bookingbutton;
        private System.Windows.Forms.Label movie_name;
        private System.Windows.Forms.Label release_day;
        private System.Windows.Forms.DataGridView MovieView1;
        private System.Windows.Forms.DataGridView CinemaView1;
        private System.Windows.Forms.DataGridView Release_dayView1;
        private System.Windows.Forms.DataGridView Release_timeView1;
        private System.Windows.Forms.Label release_time;
        private System.Windows.Forms.Label cinema_name;
    }
}