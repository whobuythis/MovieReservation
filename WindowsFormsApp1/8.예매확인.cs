using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class MyPage : Form
    {
        private readonly DBClass dbClass;
        private string loggedInUserName;
        public MyPage(string userName)
        {
            InitializeComponent();
            dbClass = new DBClass();
            loggedInUserName = userName;
        }
        private void button1_Click(object sender, EventArgs e) //인증하기 버튼 클릭시 
        {
            string enteredPhoneNumber = textBox1.Text;
            if (string.IsNullOrWhiteSpace(enteredPhoneNumber))
            {
                MessageBox.Show("휴대폰 번호를 입력하세요.");
                return;
            }

            DataTable reservationData = GetReservationData(enteredPhoneNumber);

            if (reservationData != null && reservationData.Rows.Count > 0)
            {
                DataTable displayTable = new DataTable();
                displayTable.Columns.Add("예매번호", typeof(int));
                displayTable.Columns.Add("예매가격", typeof(int));
                displayTable.Columns.Add("좌석번호", typeof(string));
                displayTable.Columns.Add("영화명", typeof(string));

                foreach (DataRow row in reservationData.Rows)
                {
                    string movieId = row["movie_id"].ToString();
                    string movieName = GetMovieNameByMovieId(movieId);

                    displayTable.Rows.Add(row["ticket_num"], row["price"], row["seat_num"], movieName);
                }
                dataGridView1.DataSource = displayTable;
                dataGridView1.Columns["예매번호"].HeaderText = "예매번호";
                dataGridView1.Columns["예매가격"].HeaderText = "예매가격";
                dataGridView1.Columns["좌석번호"].HeaderText = "좌석번호";
                dataGridView1.Columns["영화명"].HeaderText = "영화명";
            }
            else
            {
                MessageBox.Show("해당 휴대폰 번호로 예매된 정보가 없습니다.");
            }
        }

        private DataTable GetReservationData(string phoneNumber)
        {
            DataTable reservationData = new DataTable();

            try
            {
                dbClass.DB_Access();
                using (var cmd = new OracleCommand("SELECT ticket_num, price, seat_num, movie_id FROM Ticket WHERE member_id IN (SELECT member_id FROM Member WHERE phone_number = :PhoneNumber)", dbClass.Con))
                {
                    cmd.Parameters.Add(new OracleParameter("PhoneNumber", phoneNumber));
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        adapter.Fill(reservationData);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"에러 발생: {ex.Message}");
            }
            finally
            {
                dbClass.Con.Close();
            }

            return reservationData;
        }

        private void button2_Click(object sender, EventArgs e) //확인 버튼 클릭 시 창 닫기
        {
            this.Close();
        }
        private string GetMovieNameByMovieId(string movieId)
        {
            string movieName = "";

            try
            {
                dbClass.DB_Access();
                using (var cmd = new OracleCommand("SELECT movie_name FROM Movie WHERE movie_id = :MovieId", dbClass.Con))
                {
                    cmd.Parameters.Add(new OracleParameter("MovieId", movieId));
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        movieName = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"에러 발생: {ex.Message}");
            }
            finally
            {
                dbClass.Con.Close();
            }

            return movieName;
        }
        private void 예매취소ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                int ticketNum = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["예매번호"].Value);
                try
                {
                    dbClass.DB_Access();
                    using (var cmd = new OracleCommand("DELETE FROM Ticket WHERE ticket_num = :ticket_num", dbClass.Con))
                    {
                        cmd.Parameters.Add(new OracleParameter("ticket_num", ticketNum));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("해당 예매가 취소되었습니다.");
                        dataGridView1.Rows.RemoveAt(selectedRowIndex);
                    }
                }
                catch (OracleException ex)
                {
                    MessageBox.Show($"Oracle 에러 발생: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"에러 발생: {ex.Message}");
                }
                finally
                {
                    dbClass.Con.Close();
                }
            }
            else
            {
                MessageBox.Show("예매를 취소할 티켓을 선택하세요.");
            }
        }
    }
}