using System;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class 예매 : Form
    {
        private DBClass dbClass;

        public 예매()
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
                LoadDataToGridView("SELECT DISTINCT * FROM Cinema", CinemaView1, "cinema_name");
                LoadDataToGridView("SELECT DISTINCT * FROM Movie", MovieView1, "movie_name");
                LoadDataToGridView("SELECT DISTINCT TO_CHAR(release_day, 'MM-DD') AS release_day FROM Scheduler ORDER BY release_day", Release_dayView1, "release_day");
                LoadDataToGridView("SELECT DISTINCT TO_CHAR(release_time, 'HH24:MI:SS') AS release_time FROM Scheduler", Release_timeView1, "release_time");
            }
            catch 
            {
                MessageBox.Show($"데이터를 불러오는 중 에러 발생");
            }
            finally
            {
                dbClass.Con.Close();
            }
        }

        private void LoadDataToGridView(string query, DataGridView dataGridView, string columnToKeep)
        {
            using (var cmd = new OracleCommand(query, dbClass.Con))
            using (var adapter = new OracleDataAdapter(cmd))
            {
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView.DataSource = dataTable;
                HideColumnsExcept(dataGridView, columnToKeep);
            }
        }

        private void HideColumnsExcept(DataGridView dataGridView, string columnToKeep)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.Visible = false;
            }

            if (dataGridView.Columns.Contains(columnToKeep))
            {
                dataGridView.Columns[columnToKeep].Visible = true;
                dataGridView.Columns[columnToKeep].HeaderText = GetHeaderText(columnToKeep);
            }
        }

        private string GetHeaderText(string columnName)
        {         
            switch (columnName)
            {
                case "cinema_name":
                    return "상영관명";
                case "movie_name":
                    return "영화명";
                case "release_day":
                    return "상영일";
                case "release_time":
                    return "상영시간";
                default:
                    return columnName;
            }
        }
        private void 예매_Load(object sender, EventArgs e)
        {
            LoadTableData();
        }
        private void bookingbutton_Click(object sender, EventArgs e)
        {
            // 선택된 상영일 및 상영시간 가져오기
            string selectedReleaseDay = GetSelectedValue(Release_dayView1, "release_day");
            string selectedReleaseTime = GetSelectedValue(Release_timeView1, "release_time");
            // 선택된 영화명과 상영관명 가져오기
            string selectedMovieName = GetSelectedValue(MovieView1, "movie_name");
            string selectedCinemaName = GetSelectedValue(CinemaView1, "cinema_name");
            // 좌석 폼에 값 전달
            좌석 seatForm = new 좌석(selectedMovieName, selectedCinemaName, selectedReleaseDay, selectedReleaseTime);
            seatForm.ShowDialog();
            this.Close();
        }

        private string GetSelectedValue(DataGridView dataGridView, string columnName)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dataGridView.SelectedCells[0].RowIndex;
                return dataGridView.Rows[selectedRowIndex].Cells[columnName].Value.ToString();
            }
            return null;
        }
    }
}
