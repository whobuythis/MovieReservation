using Oracle.DataAccess.Client;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class 설명 : Form
    {
        private string pst;
        private 메인 main;
        private DBClass dbClass;

        public 설명(string name, 메인 in_form)
        {
            InitializeComponent();
            pst = name;
            main = in_form;
            dbClass = new DBClass();
        }

        private void 설명_Load_1(object sender, EventArgs e)
        {
            string Movie_id = "";

            if (pst.Equals("pictureBox1"))
            {
                Movie_id = "M001";
                pictureBox1.Image = Properties.Resources.poster__1_;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            }
            else if (pst.Equals("pictureBox2"))
            {
                Movie_id = "M002";
                pictureBox1.Image = Properties.Resources.poster__2_;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            }
            else if (pst.Equals("pictureBox3"))
            {
                Movie_id = "M003";
                pictureBox1.Image = Properties.Resources.poster__3_;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            }
            else if (pst.Equals("pictureBox4"))
            {
                Movie_id = "M004";
                pictureBox1.Image = Properties.Resources.poster__4_;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            }
            else if (pst.Equals("pictureBox5"))
            {
                Movie_id = "M005";
                pictureBox1.Image = Properties.Resources.poster__5_;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            }
            else if (pst.Equals("pictureBox6"))
            {
                Movie_id = "M006";
                pictureBox1.Image = Properties.Resources.poster__6_;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            }
            else if (pst.Equals("pictureBox7"))
            {
                Movie_id = "M007";
                pictureBox1.Image = Properties.Resources.poster__7_;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            }
            else if (pst.Equals("pictureBox8"))
            {
                Movie_id = "M008";
                pictureBox1.Image = Properties.Resources.poster__8_;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            LoadMovieInfo(Movie_id);
        }
        private void LoadMovieInfo(string movieId)
        {
            string query = "SELECT movie_name, running_time, rating_code, genre_id, release, director, actors, Synop FROM Movie WHERE movie_id = :Movie_id";

            dbClass.DB_Access();  // DB 연결 열기

            using (OracleCommand command = new OracleCommand(query, dbClass.Con))
            {
                command.Parameters.Add("Movie_id", OracleDbType.Varchar2).Value = movieId;

                using (OracleDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        movie_name.Text = reader["movie_name"].ToString();
                        running_time.Text = reader["running_time"].ToString();
                        rating_code.Text = reader["rating_code"].ToString();

                        // 관람 등급 코드와 장르 코드를 가져와서 해당하는 등급명을 찾아서 출력
                        int ratingCode = Convert.ToInt32(reader["rating_code"]);
                        string rating = GetRatingName(ratingCode);
                        rating_code.Text = rating;
                        int genreCode = Convert.ToInt32(reader["genre_id"]);
                        string genre = GetGenreName(genreCode);
                        genre_id.Text = genre;
                        release.Text = reader["release"].ToString();
                        director.Text = reader["director"].ToString();
                        actors.Text = reader["actors"].ToString();
                        Synop.Text = reader["Synop"].ToString();
                    }
                }
            }
            dbClass.Con.Close();  // DB 연결 닫기
        }

        private string GetRatingName(int ratingCode)
        {
            string query = "SELECT film_rating FROM Rating WHERE rating_code = :RC001";
            using (OracleCommand command = new OracleCommand(query, dbClass.Con))
            {
                command.Parameters.Add("RC001", OracleDbType.Int32).Value = ratingCode;
                object result = command.ExecuteScalar();
                return result != null ? result.ToString() : string.Empty;
            }
        }

        private string GetGenreName(int genreCode)
        {
            string query = "SELECT genre_name FROM Genre WHERE genre_id = :GC001";
            using (OracleCommand command = new OracleCommand(query, dbClass.Con))
            {
                command.Parameters.Add("GC001", OracleDbType.Int32).Value = genreCode;
                object result = command.ExecuteScalar();
                return result != null ? result.ToString() : string.Empty;
            }

        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string naverLink = GetNaverLink();
            if (!string.IsNullOrEmpty(naverLink))
            {
                this.linkLabel1.LinkVisited = true;
                System.Diagnostics.Process.Start(naverLink);
            }
        }
        private string GetNaverLink()
        {
            switch (pst)
            {
                case "pictureBox1":
                    return "https://tv.naver.com/v/43843300";
                case "pictureBox2":
                    return "https://tv.naver.com/v/42611114";
                case "pictureBox3":
                    return "https://tv.naver.com/v/42291968";
                case "pictureBox4":
                    return "https://tv.naver.com/v/42447789";
                case "pictureBox5":
                    return "https://tv.naver.com/v/42131990";
                case "pictureBox6":
                    return "https://tv.naver.com/v/42379626";
                case "pictureBox7":
                    return "https://tv.naver.com/v/22055749";
                case "pictureBox8":
                    return "https://tv.naver.com/v/42924154";
                default:
                    return string.Empty;
            }
        }
    }
}
