using System;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class 회원가입 : Form
    {
        private readonly DBClass dbClass;
        private int nextMemberId;
        public 회원가입()
        {
            InitializeComponent();
            dbClass = new DBClass();
            this.Load += 회원가입_Load;
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public ComboboxItem(string text, int value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString()
            {
                return Text;
            }
        }

        private void 회원가입_Load(object sender, EventArgs e)
        {
            InitGenreComboBox();  // 폼 로드 시 장르 콤보박스 초기화 메서드 호출
        }

        // 장르 콤보박스 초기화 메서드
        private void InitGenreComboBox()
        {
            try
            {

                dbClass.DB_Access();
                comboBox1.Items.Clear();
                using (var cmd = new OracleCommand("SELECT genre_id, genre_name FROM Genre ORDER BY genre_id", dbClass.Con))
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int genreID = Convert.ToInt32(reader["genre_id"]); // 정수로 변환
                        string genreName = reader["genre_name"].ToString(); // 문자열로 변환
                        comboBox1.Items.Add(new ComboboxItem($"{genreID}: {genreName}", genreID));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"장르 데이터를 불러오는 중 에러 발생: {ex.Message}");
            }
            finally
            {
                dbClass.Con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsInputValid())
            {
                MessageBox.Show("모든 정보를 입력해주세요.");
                return;
            }

            try
            {
                dbClass.DB_Access();
                int nextMemberId = GetNextMemberId();

                if (textBox5.Text.Trim().ToLower() == "admin") // 관리자 계정은 생성 불가
                {
                    MessageBox.Show("사용할 수 없는 아이디입니다.");
                    return;
                }

                using (var cmd = new OracleCommand("INSERT INTO Member (member_id, member_name, address, birthday, phone_number, identity, password, genre_id) " +
                                                  "VALUES (:MemberId, :MemberName, :Address, :Birthday, :PhoneNumber, :Identity, :Password, :GenreID)", dbClass.Con))
                {
                    // 회원의 설정 및 회원 테이블에 추가
                    cmd.Parameters.Add(new OracleParameter("MemberId", nextMemberId));
                    AddParameters(cmd);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("회원가입이 완료되었습니다.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("회원가입에 실패했습니다. 다시 시도해주세요.");
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show($"오라클 에러 발생: {ex.Number} - {ex.Message}");
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

        //마지막 회원 정보 밑에 추가하기 위한 메소드
        private int GetNextMemberId()
        {
            int nextMemberId = 1; // 초기값

            using (var cmd = new OracleCommand("SELECT MAX(member_id) FROM Member", dbClass.Con))
            {
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    nextMemberId = Convert.ToInt32(result) + 1;
                }
            }
            return nextMemberId;
        }

        private void AddParameters(OracleCommand cmd) //사용자가 입력한 데이터를 회원 테이블 형식에 맞게 변환
        {
            cmd.Parameters.Add(new OracleParameter("MemberName", textBox1.Text));
            cmd.Parameters.Add(new OracleParameter("Address", textBox2.Text));
            cmd.Parameters.Add(new OracleParameter("Birthday", dateTimePicker1.Value.ToString("yyyy-MM-dd")));
            cmd.Parameters.Add(new OracleParameter("PhoneNumber", textBox4.Text));
            cmd.Parameters.Add(new OracleParameter("Identity", textBox5.Text));
            cmd.Parameters.Add(new OracleParameter("Password", textBox6.Text));

            //주로 미입력되는 것으로 예상되는 콤보박스는 추가적인 안내 메세지 출력
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("선호 영화 장르를 선택해주세요.");
                return;
            }

            if (comboBox1.SelectedItem is ComboboxItem selectedGenre)
            {
                cmd.Parameters.Add(new OracleParameter("GenreID", selectedGenre.Value));
            }
            else
            {
                MessageBox.Show("잘못된 장르 ID입니다.");
            }
        }

        private bool IsInputValid() //모든 데이터가 입력되었는지 확인
        {
            return !string.IsNullOrWhiteSpace(textBox1.Text) &&
                   !string.IsNullOrWhiteSpace(textBox2.Text) &&
                   !string.IsNullOrWhiteSpace(textBox6.Text) &&
                   !string.IsNullOrWhiteSpace(textBox4.Text) &&
                   !string.IsNullOrWhiteSpace(textBox5.Text) &&
                   dateTimePicker1.Value != null &&
                   comboBox1.SelectedItem != null;
        }
    }
}