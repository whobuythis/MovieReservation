using System;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class 관리자 : Form
    {
        private DBClass dbClass;

        public 관리자()
        {
            InitializeComponent();
            dbClass = new DBClass();
            LoadTableData();
        }

        private void LoadTableData()
        {
            try
            {
                dbClass.DB_Access();
                LoadDataToGridView("SELECT * FROM Rating", RatingView);
                LoadDataToGridView("SELECT * FROM Genre", GenreView);
                LoadDataToGridView("SELECT * FROM Movie", MovieView);
                LoadDataToGridView("SELECT * FROM Cinema", CinemaView);
                LoadDataToGridView("SELECT * FROM Scheduler", SchedulerView);
                SchedulerView.Columns["release_time"].DefaultCellStyle.Format = "HH:mm:ss";
                LoadDataToGridView("SELECT * FROM Seat", SeatView);
                LoadDataToGridView("SELECT * FROM Member", MemberView);
                LoadDataToGridView("SELECT * FROM Ticket", TicketView);
                // 각 테이블에 대한 데이터를 불러옴
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터를 불러오는 중 에러 발생: {ex.Message}");
            }
            finally
            {
                dbClass.Con.Close();
            }
        }
        private void LoadDataToGridView(string query, DataGridView dataGridView)//데이터 그리드 뷰를 채워줌
        {
            using (var cmd = new OracleCommand(query, dbClass.Con))
            using (var adapter = new OracleDataAdapter(cmd))
            {
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView.DataSource = dataTable;
            }
        }
        private void 관리자_Load(object sender, EventArgs e)     // 폼이 로드될 때 데이터를 불러오도록 설정
        {
            LoadTableData();
        }
    }
}
