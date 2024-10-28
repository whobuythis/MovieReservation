using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class 좌석 : Form
    {
        private DBClass dbClass;
        int maxSeats = 6; // 최대 선택 가능한 좌석 수
        int selectedSeats1;
        int selectedSeats2 ;
        
        public 좌석(string selectedMovie, string selectedCinema, string selectedDay, string selectedTime)
        {
            InitializeComponent();
            MOVIE.Text = selectedMovie;
            CINEMA.Text = selectedCinema;
            DATE.Text = selectedDay;
            TIME.Text = selectedTime;
        }
        private void 좌석_Load(object sender, EventArgs e)
        {
            DisableReservedSeats();
            MessageBox.Show("좌석 선택은 최대 6개 입니다.");

        }

    private void DisableReservedSeats()
        {
            dbClass = new DBClass(); 
            dbClass.DB_Access();
            string query1 = $"SELECT cinema_code FROM Cinema WHERE cinema_name = '{CINEMA.Text}'";
            string Date = $"2023-{DATE.Text}";
            string query2 = $"SELECT show_code FROM Scheduler WHERE release_day = TO_DATE('{Date}', 'YYYY-MM-DD') AND release_time = TO_TIMESTAMP('{TIME.Text}', 'HH24:MI:SS')";
            OracleCommand cmd1 = new OracleCommand(query1, dbClass.Con);
            OracleCommand cmd2 = new OracleCommand(query2, dbClass.Con);
            object cinemaCode = cmd1.ExecuteScalar();
            object showcode = cmd2.ExecuteScalar();
            string queryGetReservedSeats = $"SELECT seat_num FROM Seat WHERE seat_status = 1 AND cinema_code = '{cinemaCode}' AND show_code = '{showcode}'";
            OracleCommand cmdGetReservedSeats = new OracleCommand(queryGetReservedSeats, dbClass.Con);
            OracleDataReader reader = cmdGetReservedSeats.ExecuteReader();

            while (reader.Read())
            {
                string reservedSeat = reader["seat_num"].ToString().Trim();
                DisableSeatButton(reservedSeat);
            }
            reader.Close();
        }
        private void DisableSeatButton(string seatText)
        {
            string buttonName = seatText.Replace("\n", ""); 
            Control[] controls = this.Controls.Find(buttonName, true);

            if (controls.Length > 0 && controls[0] is Button)
            {
                Button seatButton = (Button)controls[0];
                seatButton.Enabled = false;
                seatButton.BackgroundImage = WindowsFormsApp1.Properties.Resources.x1;
                seatButton.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }

        private bool IsRadioSelected()
        {
            // 라디오 버튼 중 하나라도 선택되었는지 확인
            return radioButton1.Checked || radioButton2.Checked || radioButton3.Checked ||
                   radioButton4.Checked || radioButton5.Checked || radioButton6.Checked ||
                   radioButton7.Checked || radioButton8.Checked || radioButton9.Checked ||
                   radioButton10.Checked || radioButton11.Checked || radioButton12.Checked;
        }
        private void CAL2_Click(object sender, EventArgs e)
        {
            if (!IsRadioSelected())
            {
                MessageBox.Show("관람 인원 수를 먼저 선택하세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // 선택된 좌석의 총 합 계산
            int totalSelectedSeats = selectedSeats1 + selectedSeats2;
            int selectedSeatsCount = GetSelectedSeatsCount();
            // 선택된 좌석 수가 최대 허용 좌석 수를 초과하는지 확인
            if (totalSelectedSeats > maxSeats)
            {
                MessageBox.Show("선택 가능한 좌석 수를 초과했습니다. 확인 부탁드립니다");
                return;
            }
            else if (selectedSeatsCount == 0)
            {
                MessageBox.Show("좌석을 선택해주시길 바랍니다. 확인 부탁드립니다");
                return;
            }
            else if (totalSelectedSeats > selectedSeatsCount)
            {
                MessageBox.Show("모든 좌석을 선택해주시길 바랍니다. 확인 부탁드립니다");
                return;
            }

                // 결재 폼 열기
            결재 결재 = new 결재(this, selectedSeats1, selectedSeats2);
            결재.SelectedSeats1 = selectedSeats1;
            결재.SelectedSeats2 = selectedSeats2;
            결재.moviename.Text = MOVIE.Text;
            결재.seat1.Text = seat1.Text;
            결재.seat2.Text = seat2.Text;
            결재.seat3.Text = seat3.Text;
            결재.seat4.Text = seat4.Text;
            결재.seat5.Text = seat5.Text;
            결재.seat6.Text = seat6.Text;
            결재.showDay.Text = DATE.Text;
            결재.showTime.Text = TIME.Text;
            결재.cinemaname.Text = CINEMA.Text;
            결재.ShowDialog();
            this.Close();

        }
        private void CANCLE_Click(object sender, EventArgs e)
        {
            seat1.Text = "";
            seat2.Text = "";
            seat3.Text = "";
            seat4.Text = "";
            seat5.Text = "";
            seat6.Text = "";
            ResetButtons(Controls.OfType<Button>());
        }

        private void ResetButtons(IEnumerable<Button> buttonList)
        {
            foreach (Button button in buttonList)
            {
                button.BackColor = SystemColors.ActiveCaption;
            }
        }
        private void ToggleButtonState(Button button, string buttonText, Color activeColor)
        {
            int totalSelectedSeats = selectedSeats1 + selectedSeats2;
            int selectedSeatsCount = GetSelectedSeatsCount();
            if (button.BackColor == activeColor)
            {
                RemoveSeatText(buttonText);
                button.BackColor = SystemColors.ActiveCaption;
            }
            else if (selectedSeatsCount > totalSelectedSeats)
            {
                MessageBox.Show("더 이상 좌석을 선택할 수 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                AddSeatText(buttonText);
                button.BackColor = activeColor;
            }
        }

        private void AddSeatText(string buttonText)
        {
            if (string.IsNullOrWhiteSpace(seat1.Text))
            {
                seat1.Text = buttonText;
            }
            else if (string.IsNullOrWhiteSpace(seat2.Text))
            {
                seat2.Text = buttonText;
            }
            else if (string.IsNullOrWhiteSpace(seat3.Text))
            {
                seat3.Text = buttonText;
            }
            else if (string.IsNullOrWhiteSpace(seat4.Text))
            {
                seat4.Text = buttonText;
            }
            else if (string.IsNullOrWhiteSpace(seat5.Text))
            {
                seat5.Text = buttonText;
            }
            else if (string.IsNullOrWhiteSpace(seat6.Text))
            {
                seat6.Text = buttonText;
            }
        }

        private void RemoveSeatText(string buttonText)
        {
            seat1.Text = seat1.Text.Replace(buttonText, "");
            seat2.Text = seat2.Text.Replace(buttonText, "");
            seat3.Text = seat3.Text.Replace(buttonText, "");
            seat4.Text = seat4.Text.Replace(buttonText, "");
            seat5.Text = seat5.Text.Replace(buttonText, "");
            seat6.Text = seat6.Text.Replace(buttonText, "");
        }
        private int GetSelectedSeatsCount()
        {
            int selectedCount = 0;
            foreach (Control control in Controls)
            {
                if (control is Button button && button.BackColor == Color.LightCoral)
                {
                    selectedCount++;
                }
            }
            return selectedCount;
        }

        private void A01_Click(object sender, EventArgs e)
        {
            ToggleButtonState(A01, "A01\n", Color.LightCoral);
        }
        private void A02_Click(object sender, EventArgs e)
        {
            ToggleButtonState(A02, "A02\n", Color.LightCoral);
        }
        private void A03_Click(object sender, EventArgs e)
        {
            ToggleButtonState(A03, "A03\n", Color.LightCoral);
        }
        private void A04_Click(object sender, EventArgs e)
        {
            ToggleButtonState(A04, "A04\n", Color.LightCoral);
        }
        private void A05_Click(object sender, EventArgs e)
        {
            ToggleButtonState(A05, "A05\n", Color.LightCoral);
        }
        private void A06_Click(object sender, EventArgs e)
        {
            ToggleButtonState(A06, "A06\n", Color.LightCoral);
        }
        private void A07_Click(object sender, EventArgs e)
        {
            ToggleButtonState(A07, "A07\n", Color.LightCoral);
        }
        private void A08_Click(object sender, EventArgs e)
        {
            ToggleButtonState(A08, "A08\n", Color.LightCoral);
        }
        private void B01_Click(object sender, EventArgs e)
        {
            ToggleButtonState(B01, "B01\n", Color.LightCoral);
        }

        private void B02_Click(object sender, EventArgs e)
        {
            ToggleButtonState(B02, "B02\n", Color.LightCoral);
        }

        private void B03_Click(object sender, EventArgs e)
        {
            ToggleButtonState(B03, "B03\n", Color.LightCoral);
        }

        private void B04_Click(object sender, EventArgs e)
        {
            ToggleButtonState(B04, "B04\n", Color.LightCoral);
        }

        private void B05_Click(object sender, EventArgs e)
        {
            ToggleButtonState(B05, "B05\n", Color.LightCoral);
        }

        private void B06_Click(object sender, EventArgs e)
        {
            ToggleButtonState(B06, "B06\n", Color.LightCoral);
        }

        private void B07_Click(object sender, EventArgs e)
        {
            ToggleButtonState(B07, "B07\n", Color.LightCoral);
        }

        private void B08_Click(object sender, EventArgs e)
        {
            ToggleButtonState(B08, "B08\n", Color.LightCoral);
        }

        private void C01_Click(object sender, EventArgs e)
        {
            ToggleButtonState(C01, "C01\n", Color.LightCoral);
        }

        private void C02_Click(object sender, EventArgs e)
        {
            ToggleButtonState(C02, "C02\n", Color.LightCoral);
        }

        private void C03_Click(object sender, EventArgs e)
        {
            ToggleButtonState(C03, "C03\n", Color.LightCoral);
        }

        private void C04_Click(object sender, EventArgs e)
        {
            ToggleButtonState(C04, "C04\n", Color.LightCoral);
        }

        private void C05_Click(object sender, EventArgs e)
        {
            ToggleButtonState(C05, "C05\n", Color.LightCoral);
        }

        private void C06_Click(object sender, EventArgs e)
        {
            ToggleButtonState(C06, "C06\n", Color.LightCoral);
        }

        private void C07_Click(object sender, EventArgs e)
        {
            ToggleButtonState(C07, "C07\n", Color.LightCoral);
        }

        private void C08_Click(object sender, EventArgs e)
        {
            ToggleButtonState(C08, "C08\n", Color.LightCoral);
        }

        private void D01_Click(object sender, EventArgs e)
        {
            ToggleButtonState(D01, "D01\n", Color.LightCoral);
        }

        private void D02_Click(object sender, EventArgs e)
        {
            ToggleButtonState(D02, "D02\n", Color.LightCoral);
        }

        private void D03_Click(object sender, EventArgs e)
        {
            ToggleButtonState(D03, "D03\n", Color.LightCoral);
        }

        private void D04_Click(object sender, EventArgs e)
        {
            ToggleButtonState(D04, "D04\n", Color.LightCoral);
        }

        private void D05_Click(object sender, EventArgs e)
        {
            ToggleButtonState(D05, "D05\n", Color.LightCoral);
        }

        private void D06_Click(object sender, EventArgs e)
        {
            ToggleButtonState(D06, "D06\n", Color.LightCoral);
        }

        private void D07_Click(object sender, EventArgs e)
        {
            ToggleButtonState(D07, "D07\n", Color.LightCoral);
        }

        private void D08_Click(object sender, EventArgs e)
        {
            ToggleButtonState(D08, "D08\n", Color.LightCoral);
        }

        private void E01_Click(object sender, EventArgs e)
        {
            ToggleButtonState(E01, "E01\n", Color.LightCoral);
        }

        private void E02_Click(object sender, EventArgs e)
        {
            ToggleButtonState(E02, "E02\n", Color.LightCoral);
        }

        private void E03_Click(object sender, EventArgs e)
        {
            ToggleButtonState(E03, "E03\n", Color.LightCoral);
        }

        private void E04_Click(object sender, EventArgs e)
        {
            ToggleButtonState(E04, "E04\n", Color.LightCoral);
        }

        private void E05_Click(object sender, EventArgs e)
        {
            ToggleButtonState(E05, "E05\n", Color.LightCoral);
        }

        private void E06_Click(object sender, EventArgs e)
        {
            ToggleButtonState(E06, "E06\n", Color.LightCoral);
        }

        private void E07_Click(object sender, EventArgs e)
        {
            ToggleButtonState(E07, "E07\n", Color.LightCoral);
        }

        private void E08_Click(object sender, EventArgs e)
        {
            ToggleButtonState(E08, "E08\n", Color.LightCoral);
        }

        private void F01_Click(object sender, EventArgs e)
        {
            ToggleButtonState(F01, "F01\n", Color.LightCoral);
        }

        private void F02_Click(object sender, EventArgs e)
        {
            ToggleButtonState(F02, "F02\n", Color.LightCoral);
        }

        private void F03_Click(object sender, EventArgs e)
        {
            ToggleButtonState(F03, "F03\n", Color.LightCoral);
        }

        private void F04_Click(object sender, EventArgs e)
        {
            ToggleButtonState(F04, "F04\n", Color.LightCoral);
        }

        private void F05_Click(object sender, EventArgs e)
        {
            ToggleButtonState(F05, "F05\n", Color.LightCoral);
        }

        private void F06_Click(object sender, EventArgs e)
        {
            ToggleButtonState(F06, "F06\n", Color.LightCoral);
        }

        private void F07_Click(object sender, EventArgs e)
        {
            ToggleButtonState(F07, "F07\n", Color.LightCoral);
        }

        private void F08_Click(object sender, EventArgs e)
        {
            ToggleButtonState(F08, "F08\n", Color.LightCoral);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            selectedSeats1 = 6;
            return;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            selectedSeats1 = 1;
            return;
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            selectedSeats1 = 4;
            return;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            selectedSeats1 = 2;
            return;
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            selectedSeats1 = 5;
            return;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            selectedSeats1 = 3;
            return;
        }
        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            selectedSeats2 = 1;
            return;
        }
        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            selectedSeats2 = 4;
            return;
        }
        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            selectedSeats2 = 2;
            return;
        }
        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            selectedSeats2 = 5;
            return;
        }
        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            selectedSeats2 = 3;
            return;
        }
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            selectedSeats2 = 6;
            return;
        }
    }
}