using System;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class 로그인 : Form
    {
        private 메인 mainForm;
        private DBClass dbClass;

        public 로그인()
        {
            InitializeComponent();
            dbClass = new DBClass();
            dbClass.DB_Access();
        }

        public 로그인(메인 mainForm) : this()
        {
            this.mainForm = mainForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckUserCredentials(textBox1.Text, textBox2.Text)) // 회원 데이터가 있을 경우 로그인 후 메인 폼으로
            {
                MessageBox.Show("로그인 성공!");
                OpenMainForm();
            }
            else if (textBox1.Text == "비회원" && textBox2.Text == "1") // 테스트 및 비회원 기능을 위한 임시 아이디와 비밀번호
            {
                MessageBox.Show("비회원 모드 입니다.");
                OpenMainForm();
            }
            else
            {
                MessageBox.Show("로그인 실패. 등록된 정보가 없거나 비밀번호가 틀렸습니다."); // 로그인 시 잘못된 정보 입력시 안내 문구 출력
            }
        }
        private void OpenMainForm()
        {
            if (mainForm != null && !mainForm.IsDisposed)
            {
                mainForm.Show();
                Hide(); // 로그인 폼이 남아 있는 경우를 방지
            }
            else
            {
                var f3 = new 메인();
                f3.SetLoggedInUser(textBox1.Text);
                f3.Show();
                Hide(); // 로그인 폼이 남아 있는 경우를 방지
            }
        }

        private bool CheckUserCredentials(string enteredID, string enteredPassword) //아이디와 비밀번호를 확인
        {
            try
            {
                using (var cmd = new OracleCommand("SELECT COUNT(*) FROM Member WHERE identity = :EnteredID AND password = :EnteredPassword", dbClass.Con)) 
                    //맴버 테이블의 아이디와 비밀번호를 불러와 입력한 아이디와 비밀번호와 대조
                {
                    cmd.Parameters.Add(new OracleParameter("EnteredID", enteredID));
                    cmd.Parameters.Add(new OracleParameter("EnteredPassword", enteredPassword));
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (enteredID.ToLower() == "admin" && enteredPassword.ToLower() == "admin") // 어드민 계정으로 로그인 시 메인폼이 아닌 관리자 폼으로 열기
                    {
                        var f9 = new 관리자();
                        f9.Show();
                        return true;
                    }

                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"에러 발생: {ex.Message}");
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f2 = new 회원가입();
            f2.ShowDialog();
        }
    }
}