using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Collections.Generic;

namespace WindowsFormsApp1
{
    public partial class 결재 : Form
    {
        private DBClass dbClass;
        public int SelectedSeats1 { get; set; }
        public int SelectedSeats2 { get; set; }
        public string id = 메인.loggedInUserName;
        int totalPrice;

        public 결재(좌석 s, int selectedSeats1, int selectedSeats2)
        {
            InitializeComponent();
            SelectedSeats1 = selectedSeats1;
            SelectedSeats2 = selectedSeats2;
            totalPrice = SelectedSeats1 * 15000 + SelectedSeats2 * 12000;
            pricebox.Text = totalPrice.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dbClass = new DBClass(); // DBClass 인스턴스를 생성합니다.
                dbClass.DB_Access(); // 데이터베이스 연결을 엽니다.\
                string query1 = $"SELECT movie_id FROM Movie WHERE movie_name = '{moviename.Text}'";
                string query2 = $"SELECT member_id FROM Member WHERE identity = '{id}'";
                string query3 = "SELECT COUNT(*) FROM Ticket";
                string query4 = $"SELECT cinema_code FROM Cinema WHERE cinema_name = '{cinemaname.Text}'";
                string Date = $"2023-{showDay.Text}";
                string query5 = $"SELECT show_code FROM Scheduler WHERE release_day = TO_DATE('{Date}', 'YYYY-MM-DD') AND release_time = TO_TIMESTAMP('{showTime.Text}', 'HH24:MI:SS')";
                OracleCommand cmd1 = new OracleCommand(query1, dbClass.Con);
                OracleCommand cmd2 = new OracleCommand(query2, dbClass.Con);
                OracleCommand cmd3 = new OracleCommand(query3, dbClass.Con);
                OracleCommand cmd4 = new OracleCommand(query4, dbClass.Con);
                OracleCommand cmd5 = new OracleCommand(query5, dbClass.Con);
                object movie_code = cmd1.ExecuteScalar();
                object memberCode = cmd2.ExecuteScalar();
                object cinemaCode = cmd4.ExecuteScalar();
                object showcode = cmd5.ExecuteScalar();
                
                if (!string.IsNullOrEmpty(seat1.Text))
                {
                    int ticketCount = Convert.ToInt32(cmd3.ExecuteScalar()) + 1;

                    string queryUpdateSeat1 = $"INSERT INTO Seat (seat_num, seat_status, seat_type, cinema_code, show_code) " +
                             $"VALUES ('{seat1.Text}', 1, 1, '{cinemaCode}', '{showcode}')";
                    OracleCommand cmdUpdateSeat = new OracleCommand(queryUpdateSeat1, dbClass.Con);

                    cmdUpdateSeat.Parameters.Add(":seatNum", OracleDbType.Varchar2).Value = seat1.Text;
                    cmdUpdateSeat.Parameters.Add(":seatStatus", OracleDbType.Int32).Value = 1; 
                    cmdUpdateSeat.Parameters.Add(":seatType", OracleDbType.Int32).Value = 1; 
                    cmdUpdateSeat.Parameters.Add(":cinemaCode", OracleDbType.Varchar2).Value = cinemaCode;
                    cmdUpdateSeat.Parameters.Add(":showCode", OracleDbType.Int32).Value = showcode;

                    int rowsAffectedSeat = cmdUpdateSeat.ExecuteNonQuery();

                    string queryUpdateTicket1 = $"INSERT INTO Ticket (ticket_num, price, member_id, seat_num, movie_id, cinema_code, show_code) " +
                                      $"VALUES ('{ticketCount}',{pricebox.Text}, {memberCode}, '{seat1.Text}', '{movie_code}', '{cinemaCode}' , '{showcode}')";
                    OracleCommand cmdUpdateTicket1 = new OracleCommand(queryUpdateTicket1, dbClass.Con);

                    cmdUpdateTicket1.Parameters.Add(":ticketCount", OracleDbType.Int32).Value = ticketCount;
                    cmdUpdateTicket1.Parameters.Add(":price", OracleDbType.Int32).Value = Convert.ToInt32(pricebox.Text); 
                    cmdUpdateTicket1.Parameters.Add(":memberCode", OracleDbType.Int32).Value = memberCode;
                    cmdUpdateTicket1.Parameters.Add(":seatNum", OracleDbType.Varchar2).Value = seat1.Text;
                    cmdUpdateTicket1.Parameters.Add(":movieCode", OracleDbType.Varchar2).Value = movie_code;
                    cmdUpdateTicket1.Parameters.Add(":cinemaCode", OracleDbType.Varchar2).Value = cinemaCode;
                    cmdUpdateTicket1.Parameters.Add(":showCode", OracleDbType.Int32).Value = showcode;

                    int rowsAffected = cmdUpdateTicket1.ExecuteNonQuery();
                }

                if (!string.IsNullOrEmpty(seat2.Text))
                {
                    int ticketCount = Convert.ToInt32(cmd3.ExecuteScalar()) + 1;

                    string queryUpdateSeat2 = $"INSERT INTO Seat (seat_num, seat_status, seat_type, cinema_code, show_code) " +
                                             $"VALUES ('{seat2.Text}', 1, 1, '{cinemaCode}', '{showcode}')";
                    OracleCommand cmdUpdateSeat2 = new OracleCommand(queryUpdateSeat2, dbClass.Con);

                    cmdUpdateSeat2.Parameters.Add(":seatNum", OracleDbType.Varchar2).Value = seat2.Text;
                    cmdUpdateSeat2.Parameters.Add(":seatStatus", OracleDbType.Int32).Value = 1;
                    cmdUpdateSeat2.Parameters.Add(":seatType", OracleDbType.Int32).Value = 1;
                    cmdUpdateSeat2.Parameters.Add(":cinemaCode", OracleDbType.Varchar2).Value = cinemaCode;
                    cmdUpdateSeat2.Parameters.Add(":showCode", OracleDbType.Int32).Value = showcode;

                    int rowsAffectedSeat2 = cmdUpdateSeat2.ExecuteNonQuery();

                    string queryUpdateTicket2 = $"INSERT INTO Ticket (ticket_num, price, member_id, seat_num, movie_id, cinema_code, show_code) " +
                                              $"VALUES ('{ticketCount}',{pricebox.Text}, {memberCode}, '{seat2.Text}', '{movie_code}', '{cinemaCode}' , '{showcode}')";
                    OracleCommand cmdUpdateTicket2 = new OracleCommand(queryUpdateTicket2, dbClass.Con);

                    cmdUpdateTicket2.Parameters.Add(":ticketCount", OracleDbType.Int32).Value = ticketCount;
                    cmdUpdateTicket2.Parameters.Add(":price", OracleDbType.Int32).Value = Convert.ToInt32(pricebox.Text);
                    cmdUpdateTicket2.Parameters.Add(":memberCode", OracleDbType.Int32).Value = memberCode;
                    cmdUpdateTicket2.Parameters.Add(":seatNum", OracleDbType.Varchar2).Value = seat2.Text;
                    cmdUpdateTicket2.Parameters.Add(":movieCode", OracleDbType.Varchar2).Value = movie_code;
                    cmdUpdateTicket2.Parameters.Add(":cinemaCode", OracleDbType.Varchar2).Value = cinemaCode;
                    cmdUpdateTicket2.Parameters.Add(":showCode", OracleDbType.Int32).Value = showcode;

                    int rowsAffected2 = cmdUpdateTicket2.ExecuteNonQuery();
                }

                if (!string.IsNullOrEmpty(seat3.Text))
                {
                    int ticketCount = Convert.ToInt32(cmd3.ExecuteScalar()) + 1;

                    string queryUpdateSeat3 = $"INSERT INTO Seat (seat_num, seat_status, seat_type, cinema_code, show_code) " +
                                             $"VALUES ('{seat3.Text}', 1, 1, '{cinemaCode}', '{showcode}')";
                    OracleCommand cmdUpdateSeat3 = new OracleCommand(queryUpdateSeat3, dbClass.Con);

                    cmdUpdateSeat3.Parameters.Add(":seatNum", OracleDbType.Varchar2).Value = seat3.Text;
                    cmdUpdateSeat3.Parameters.Add(":seatStatus", OracleDbType.Int32).Value = 1;
                    cmdUpdateSeat3.Parameters.Add(":seatType", OracleDbType.Int32).Value = 1;
                    cmdUpdateSeat3.Parameters.Add(":cinemaCode", OracleDbType.Varchar2).Value = cinemaCode;
                    cmdUpdateSeat3.Parameters.Add(":showCode", OracleDbType.Int32).Value = showcode;

                    int rowsAffectedSeat3 = cmdUpdateSeat3.ExecuteNonQuery();

                    string queryUpdateTicket3 = $"INSERT INTO Ticket (ticket_num, price, member_id, seat_num, movie_id, cinema_code, show_code) " +
                                              $"VALUES ('{ticketCount}',{pricebox.Text}, {memberCode}, '{seat3.Text}', '{movie_code}', '{cinemaCode}' , '{showcode}')";
                    OracleCommand cmdUpdateTicket3 = new OracleCommand(queryUpdateTicket3, dbClass.Con);

                    cmdUpdateTicket3.Parameters.Add(":ticketCount", OracleDbType.Int32).Value = ticketCount;
                    cmdUpdateTicket3.Parameters.Add(":price", OracleDbType.Int32).Value = Convert.ToInt32(pricebox.Text);
                    cmdUpdateTicket3.Parameters.Add(":memberCode", OracleDbType.Int32).Value = memberCode;
                    cmdUpdateTicket3.Parameters.Add(":seatNum", OracleDbType.Varchar2).Value = seat3.Text;
                    cmdUpdateTicket3.Parameters.Add(":movieCode", OracleDbType.Varchar2).Value = movie_code;
                    cmdUpdateTicket3.Parameters.Add(":cinemaCode", OracleDbType.Varchar2).Value = cinemaCode;
                    cmdUpdateTicket3.Parameters.Add(":showCode", OracleDbType.Int32).Value = showcode;

                    int rowsAffected3 = cmdUpdateTicket3.ExecuteNonQuery();
                }

                if (!string.IsNullOrEmpty(seat4.Text))
                {
                    int ticketCount = Convert.ToInt32(cmd3.ExecuteScalar()) + 1;

                    string queryUpdateSeat4 = $"INSERT INTO Seat (seat_num, seat_status, seat_type, cinema_code, show_code) " +
                                             $"VALUES ('{seat4.Text}', 1, 1, '{cinemaCode}', '{showcode}')";
                    OracleCommand cmdUpdateSeat4 = new OracleCommand(queryUpdateSeat4, dbClass.Con);

                    cmdUpdateSeat4.Parameters.Add(":seatNum", OracleDbType.Varchar2).Value = seat4.Text;
                    cmdUpdateSeat4.Parameters.Add(":seatStatus", OracleDbType.Int32).Value = 1;
                    cmdUpdateSeat4.Parameters.Add(":seatType", OracleDbType.Int32).Value = 1;
                    cmdUpdateSeat4.Parameters.Add(":cinemaCode", OracleDbType.Varchar2).Value = cinemaCode;
                    cmdUpdateSeat4.Parameters.Add(":showCode", OracleDbType.Int32).Value = showcode;

                    int rowsAffectedSeat4 = cmdUpdateSeat4.ExecuteNonQuery();

                    string queryUpdateTicket4 = $"INSERT INTO Ticket (ticket_num, price, member_id, seat_num, movie_id, cinema_code, show_code) " +
                                              $"VALUES ('{ticketCount}',{pricebox.Text}, {memberCode}, '{seat4.Text}', '{movie_code}', '{cinemaCode}' , '{showcode}')";
                    OracleCommand cmdUpdateTicket4 = new OracleCommand(queryUpdateTicket4, dbClass.Con);

                    cmdUpdateTicket4.Parameters.Add(":ticketCount", OracleDbType.Int32).Value = ticketCount;
                    cmdUpdateTicket4.Parameters.Add(":price", OracleDbType.Int32).Value = Convert.ToInt32(pricebox.Text);
                    cmdUpdateTicket4.Parameters.Add(":memberCode", OracleDbType.Int32).Value = memberCode;
                    cmdUpdateTicket4.Parameters.Add(":seatNum", OracleDbType.Varchar2).Value = seat4.Text;
                    cmdUpdateTicket4.Parameters.Add(":movieCode", OracleDbType.Varchar2).Value = movie_code;
                    cmdUpdateTicket4.Parameters.Add(":cinemaCode", OracleDbType.Varchar2).Value = cinemaCode;
                    cmdUpdateTicket4.Parameters.Add(":showCode", OracleDbType.Int32).Value = showcode;

                    int rowsAffected4 = cmdUpdateTicket4.ExecuteNonQuery();
                }

                if (!string.IsNullOrEmpty(seat5.Text))
                {
                    int ticketCount = Convert.ToInt32(cmd3.ExecuteScalar()) + 1;

                    string queryUpdateSeat5 = $"INSERT INTO Seat (seat_num, seat_status, seat_type, cinema_code, show_code) " +
                                             $"VALUES ('{seat5.Text}', 1, 1, '{cinemaCode}', '{showcode}')";
                    OracleCommand cmdUpdateSeat5 = new OracleCommand(queryUpdateSeat5, dbClass.Con);

                    cmdUpdateSeat5.Parameters.Add(":seatNum", OracleDbType.Varchar2).Value = seat5.Text;
                    cmdUpdateSeat5.Parameters.Add(":seatStatus", OracleDbType.Int32).Value = 1;
                    cmdUpdateSeat5.Parameters.Add(":seatType", OracleDbType.Int32).Value = 1;
                    cmdUpdateSeat5.Parameters.Add(":cinemaCode", OracleDbType.Varchar2).Value = cinemaCode;
                    cmdUpdateSeat5.Parameters.Add(":showCode", OracleDbType.Int32).Value = showcode;

                    int rowsAffectedSeat5 = cmdUpdateSeat5.ExecuteNonQuery();

                    string queryUpdateTicket5 = $"INSERT INTO Ticket (ticket_num, price, member_id, seat_num, movie_id, cinema_code, show_code) " +
                                              $"VALUES ('{ticketCount}',{pricebox.Text}, {memberCode}, '{seat5.Text}', '{movie_code}', '{cinemaCode}' , '{showcode}')";
                    OracleCommand cmdUpdateTicket5 = new OracleCommand(queryUpdateTicket5, dbClass.Con);

                    cmdUpdateTicket5.Parameters.Add(":ticketCount", OracleDbType.Int32).Value = ticketCount;
                    cmdUpdateTicket5.Parameters.Add(":price", OracleDbType.Int32).Value = Convert.ToInt32(pricebox.Text);
                    cmdUpdateTicket5.Parameters.Add(":memberCode", OracleDbType.Int32).Value = memberCode;
                    cmdUpdateTicket5.Parameters.Add(":seatNum", OracleDbType.Varchar2).Value = seat5.Text;
                    cmdUpdateTicket5.Parameters.Add(":movieCode", OracleDbType.Varchar2).Value = movie_code;
                    cmdUpdateTicket5.Parameters.Add(":cinemaCode", OracleDbType.Varchar2).Value = cinemaCode;
                    cmdUpdateTicket5.Parameters.Add(":showCode", OracleDbType.Int32).Value = showcode;

                    int rowsAffected5 = cmdUpdateTicket5.ExecuteNonQuery();
                }

                if (!string.IsNullOrEmpty(seat6.Text))
                {
                    int ticketCount = Convert.ToInt32(cmd3.ExecuteScalar()) + 1;

                    string queryUpdateSeat6 = $"INSERT INTO Seat (seat_num, seat_status, seat_type, cinema_code, show_code) " +
                                             $"VALUES ('{seat6.Text}', 1, 1, '{cinemaCode}', '{showcode}')";
                    OracleCommand cmdUpdateSeat6 = new OracleCommand(queryUpdateSeat6, dbClass.Con);

                    cmdUpdateSeat6.Parameters.Add(":seatNum", OracleDbType.Varchar2).Value = seat6.Text;
                    cmdUpdateSeat6.Parameters.Add(":seatStatus", OracleDbType.Int32).Value = 1;
                    cmdUpdateSeat6.Parameters.Add(":seatType", OracleDbType.Int32).Value = 1;
                    cmdUpdateSeat6.Parameters.Add(":cinemaCode", OracleDbType.Varchar2).Value = cinemaCode;
                    cmdUpdateSeat6.Parameters.Add(":showCode", OracleDbType.Int32).Value = showcode;

                    int rowsAffectedSeat6 = cmdUpdateSeat6.ExecuteNonQuery();

                    string queryUpdateTicket6 = $"INSERT INTO Ticket (ticket_num, price, member_id, seat_num, movie_id, cinema_code, show_code) " +
                                              $"VALUES ('{ticketCount}',{pricebox.Text}, {memberCode}, '{seat6.Text}', '{movie_code}', '{cinemaCode}' , '{showcode}')";
                    OracleCommand cmdUpdateTicket6 = new OracleCommand(queryUpdateTicket6, dbClass.Con);

                    cmdUpdateTicket6.Parameters.Add(":ticketCount", OracleDbType.Int32).Value = ticketCount;
                    cmdUpdateTicket6.Parameters.Add(":price", OracleDbType.Int32).Value = Convert.ToInt32(pricebox.Text);
                    cmdUpdateTicket6.Parameters.Add(":memberCode", OracleDbType.Int32).Value = memberCode;
                    cmdUpdateTicket6.Parameters.Add(":seatNum", OracleDbType.Varchar2).Value = seat6.Text;
                    cmdUpdateTicket6.Parameters.Add(":movieCode", OracleDbType.Varchar2).Value = movie_code;
                    cmdUpdateTicket6.Parameters.Add(":cinemaCode", OracleDbType.Varchar2).Value = cinemaCode;
                    cmdUpdateTicket6.Parameters.Add(":showCode", OracleDbType.Int32).Value = showcode;

                    int rowsAffected6 = cmdUpdateTicket6.ExecuteNonQuery();
                }


                string selectedSeats = new List<string> { seat1.Text, seat2.Text, seat3.Text, seat4.Text, seat5.Text, seat6.Text }
                                  .Where(seat => !string.IsNullOrEmpty(seat))
                                  .Aggregate((current, next) => string.IsNullOrEmpty(current) ? next : $"{current} {next}");

                MessageBox.Show($"결제완료\n금액 : {pricebox.Text}\n영화 : {cinemaname.Text}\n시간 : {showDay.Text}\n좌석 : {selectedSeats}\n데이터베이스에 저장되었습니다.");
            }

            catch (Exception ex)
            {
                MessageBox.Show("오류 발생: " + ex.Message);
            }
            finally
            {
                if (dbClass != null && dbClass.Con.State == ConnectionState.Open)
                    dbClass.Con.Close(); // 데이터베이스 연결이 열려있으면 닫습니다.
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("결제 및 할인 관련 기능은 미구현입니다.");
        }
    }
}
