using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
    {
    public partial class 메인 : Form
    {
        private bool isUserLoggedIn = false;
        public static string loggedInUserName = "";
        public 메인()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //로그아웃 버튼 클릭 식 현재창을 닫고, 로그인폼을 불러옴
        {
            this.Close();
            로그인 f1 = new 로그인(this); 
            f1.ShowDialog();
        }
        private void 메인_Load(object sender, EventArgs e)
        {
            UpdateUserStatusLabel();
        }
        public void SetLoggedInUser(string userName) //사용자 이름을 받아옴
        {
            isUserLoggedIn = true;
            loggedInUserName = userName;
            UpdateUserStatusLabel();
        }
        private void UpdateUserStatusLabel() 
            //사용자 이름 정보를 받아 상단에 환영메시지 출력. 로그인된 유저 이름이 없는 경우는 비회원이므로 비회원님 환영합니다 출력
        {
            if (isUserLoggedIn)
            {
                user.Text = $"{loggedInUserName}님 환영합니다.";
            }
            else
            {
                user.Text = "비회원님 환영합니다.";
            }
        }
        private void button2_Click(object sender, EventArgs e) //예매 버튼 클릭 시 예매폼으로 넘어감
        {
            예매 reservation = new 예매();
            reservation.ShowDialog();
        }

        // 각 픽처박스 클릭시, 그에 맞는 영화설명 폼을 불러옴
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            설명 intro = new 설명(pictureBox.Name, this);
            intro.ShowDialog();
        }
        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            설명 intro = new 설명(pictureBox.Name, this);
            intro.ShowDialog();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            설명 intro = new 설명(pictureBox.Name, this);
            intro.ShowDialog();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            설명 intro = new 설명(pictureBox.Name, this);
            intro.ShowDialog();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            설명 intro = new 설명(pictureBox.Name, this);
            intro.ShowDialog();
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            설명 intro = new 설명(pictureBox.Name, this);
            intro.ShowDialog();
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            설명 intro = new 설명(pictureBox.Name, this);
            intro.ShowDialog();
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            설명 intro = new 설명(pictureBox.Name, this);
            intro.ShowDialog();
        }
        private void mypage_Click(object sender, EventArgs e) //마이페이지 클릭 시 마이페이지 폼을 불러옴
        {
            MyPage reservationForm = new MyPage(loggedInUserName); // 로그인한 사용자의 이름을 전달
            reservationForm.ShowDialog();
        }
    }
}
