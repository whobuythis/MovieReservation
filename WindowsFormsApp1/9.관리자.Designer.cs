
using System;

namespace WindowsFormsApp1
{
    partial class 관리자
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
            this.RatingView = new System.Windows.Forms.DataGridView();
            this.GenreView = new System.Windows.Forms.DataGridView();
            this.MovieView = new System.Windows.Forms.DataGridView();
            this.CinemaView = new System.Windows.Forms.DataGridView();
            this.TicketView = new System.Windows.Forms.DataGridView();
            this.MemberView = new System.Windows.Forms.DataGridView();
            this.SchedulerView = new System.Windows.Forms.DataGridView();
            this.SeatView = new System.Windows.Forms.DataGridView();
            this.Rating = new System.Windows.Forms.Label();
            this.Genre = new System.Windows.Forms.Label();
            this.Movie = new System.Windows.Forms.Label();
            this.Cinema = new System.Windows.Forms.Label();
            this.Scheduler = new System.Windows.Forms.Label();
            this.Seat = new System.Windows.Forms.Label();
            this.Member = new System.Windows.Forms.Label();
            this.Ticket = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RatingView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GenreView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MovieView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CinemaView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TicketView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemberView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SchedulerView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeatView)).BeginInit();
            this.SuspendLayout();
            // 
            // RatingView
            // 
            this.RatingView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RatingView.Location = new System.Drawing.Point(21, 41);
            this.RatingView.Name = "RatingView";
            this.RatingView.RowTemplate.Height = 23;
            this.RatingView.Size = new System.Drawing.Size(516, 126);
            this.RatingView.TabIndex = 1;
            // 
            // GenreView
            // 
            this.GenreView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GenreView.Location = new System.Drawing.Point(21, 211);
            this.GenreView.Name = "GenreView";
            this.GenreView.RowTemplate.Height = 23;
            this.GenreView.Size = new System.Drawing.Size(516, 126);
            this.GenreView.TabIndex = 2;
            // 
            // MovieView
            // 
            this.MovieView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MovieView.Location = new System.Drawing.Point(21, 377);
            this.MovieView.Name = "MovieView";
            this.MovieView.RowTemplate.Height = 23;
            this.MovieView.Size = new System.Drawing.Size(516, 126);
            this.MovieView.TabIndex = 3;
            // 
            // CinemaView
            // 
            this.CinemaView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CinemaView.Location = new System.Drawing.Point(21, 552);
            this.CinemaView.Name = "CinemaView";
            this.CinemaView.RowTemplate.Height = 23;
            this.CinemaView.Size = new System.Drawing.Size(516, 126);
            this.CinemaView.TabIndex = 4;
            // 
            // TicketView
            // 
            this.TicketView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TicketView.Location = new System.Drawing.Point(592, 552);
            this.TicketView.Name = "TicketView";
            this.TicketView.RowTemplate.Height = 23;
            this.TicketView.Size = new System.Drawing.Size(516, 126);
            this.TicketView.TabIndex = 5;
            // 
            // MemberView
            // 
            this.MemberView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MemberView.Location = new System.Drawing.Point(592, 377);
            this.MemberView.Name = "MemberView";
            this.MemberView.RowTemplate.Height = 23;
            this.MemberView.Size = new System.Drawing.Size(516, 126);
            this.MemberView.TabIndex = 6;
            // 
            // SchedulerView
            // 
            this.SchedulerView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SchedulerView.Location = new System.Drawing.Point(592, 41);
            this.SchedulerView.Name = "SchedulerView";
            this.SchedulerView.RowTemplate.Height = 23;
            this.SchedulerView.Size = new System.Drawing.Size(516, 126);
            this.SchedulerView.TabIndex = 7;
            // 
            // SeatView
            // 
            this.SeatView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SeatView.Location = new System.Drawing.Point(592, 211);
            this.SeatView.Name = "SeatView";
            this.SeatView.RowTemplate.Height = 23;
            this.SeatView.Size = new System.Drawing.Size(516, 126);
            this.SeatView.TabIndex = 8;
            // 
            // Rating
            // 
            this.Rating.AutoSize = true;
            this.Rating.Font = new System.Drawing.Font("배달의민족 주아", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Rating.Location = new System.Drawing.Point(19, 24);
            this.Rating.Name = "Rating";
            this.Rating.Size = new System.Drawing.Size(27, 14);
            this.Rating.TabIndex = 9;
            this.Rating.Text = "등급";
            // 
            // Genre
            // 
            this.Genre.AutoSize = true;
            this.Genre.Font = new System.Drawing.Font("배달의민족 주아", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Genre.Location = new System.Drawing.Point(19, 194);
            this.Genre.Name = "Genre";
            this.Genre.Size = new System.Drawing.Size(28, 14);
            this.Genre.TabIndex = 10;
            this.Genre.Text = "장르";
            // 
            // Movie
            // 
            this.Movie.AutoSize = true;
            this.Movie.Font = new System.Drawing.Font("배달의민족 주아", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Movie.Location = new System.Drawing.Point(19, 358);
            this.Movie.Name = "Movie";
            this.Movie.Size = new System.Drawing.Size(29, 14);
            this.Movie.TabIndex = 11;
            this.Movie.Text = "영화";
            // 
            // Cinema
            // 
            this.Cinema.AutoSize = true;
            this.Cinema.Font = new System.Drawing.Font("배달의민족 주아", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Cinema.Location = new System.Drawing.Point(19, 530);
            this.Cinema.Name = "Cinema";
            this.Cinema.Size = new System.Drawing.Size(40, 14);
            this.Cinema.TabIndex = 12;
            this.Cinema.Text = "상영관";
            // 
            // Scheduler
            // 
            this.Scheduler.AutoSize = true;
            this.Scheduler.Font = new System.Drawing.Font("배달의민족 주아", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Scheduler.Location = new System.Drawing.Point(590, 24);
            this.Scheduler.Name = "Scheduler";
            this.Scheduler.Size = new System.Drawing.Size(60, 14);
            this.Scheduler.TabIndex = 13;
            this.Scheduler.Text = "상영시간표";
            // 
            // Seat
            // 
            this.Seat.AutoSize = true;
            this.Seat.Font = new System.Drawing.Font("배달의민족 주아", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Seat.Location = new System.Drawing.Point(590, 194);
            this.Seat.Name = "Seat";
            this.Seat.Size = new System.Drawing.Size(71, 14);
            this.Seat.TabIndex = 14;
            this.Seat.Text = "판매좌석관리";
            // 
            // Member
            // 
            this.Member.AutoSize = true;
            this.Member.Font = new System.Drawing.Font("배달의민족 주아", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Member.Location = new System.Drawing.Point(590, 358);
            this.Member.Name = "Member";
            this.Member.Size = new System.Drawing.Size(53, 14);
            this.Member.TabIndex = 15;
            this.Member.Text = "회원 정보";
            // 
            // Ticket
            // 
            this.Ticket.AutoSize = true;
            this.Ticket.Font = new System.Drawing.Font("배달의민족 주아", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Ticket.Location = new System.Drawing.Point(590, 530);
            this.Ticket.Name = "Ticket";
            this.Ticket.Size = new System.Drawing.Size(50, 14);
            this.Ticket.TabIndex = 16;
            this.Ticket.Text = "예매정보";
            // 
            // 관리자
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 713);
            this.Controls.Add(this.Ticket);
            this.Controls.Add(this.Member);
            this.Controls.Add(this.Seat);
            this.Controls.Add(this.Scheduler);
            this.Controls.Add(this.Cinema);
            this.Controls.Add(this.Movie);
            this.Controls.Add(this.Genre);
            this.Controls.Add(this.Rating);
            this.Controls.Add(this.SeatView);
            this.Controls.Add(this.SchedulerView);
            this.Controls.Add(this.MemberView);
            this.Controls.Add(this.TicketView);
            this.Controls.Add(this.CinemaView);
            this.Controls.Add(this.MovieView);
            this.Controls.Add(this.GenreView);
            this.Controls.Add(this.RatingView);
            this.Font = new System.Drawing.Font("배달의민족 주아", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "관리자";
            this.Text = "관리자 패널";
            this.Load += new System.EventHandler(this.관리자_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RatingView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GenreView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MovieView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CinemaView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TicketView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemberView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SchedulerView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SeatView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView RatingView;
        private System.Windows.Forms.DataGridView GenreView;
        private System.Windows.Forms.DataGridView MovieView;
        private System.Windows.Forms.DataGridView CinemaView;
        private System.Windows.Forms.DataGridView TicketView;
        private System.Windows.Forms.DataGridView MemberView;
        private System.Windows.Forms.DataGridView SchedulerView;
        private System.Windows.Forms.DataGridView SeatView;
        private System.Windows.Forms.Label Rating;
        private System.Windows.Forms.Label Genre;
        private System.Windows.Forms.Label Movie;
        private System.Windows.Forms.Label Cinema;
        private System.Windows.Forms.Label Scheduler;
        private System.Windows.Forms.Label Seat;
        private System.Windows.Forms.Label Member;
        private System.Windows.Forms.Label Ticket;
    }
}