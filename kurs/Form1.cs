using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace kurs
{
    public partial class FormDB : Form
    {
		int count = 0;
		private Excel.Application ObjExcel = new Excel.Application();
		string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\un1que\dpi\3 kurs\2 sem\spo\project\kurs\kurs\Education.mdf;Integrated Security=True;Connect Timeout=30";
		public FormDB()
        {
            InitializeComponent();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int current = 0;
            if (txtDel.Text == "")
                MessageBox.Show("Введено неверное значение!");
            else
            {
                if (txtDel.Text == "Все")
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(
                            "DELETE FROM dbo.TableApp"
                            ))
                        {
                            command.Connection = connection;
                            command.ExecuteNonQuery();
                        }
                        connection.Close();
                    }
                else
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(
                            "DELETE FROM dbo.TableApp WHERE Id = @Id"
                            ))
                        {
                            command.Connection = connection;
                            command.Parameters.AddWithValue("@Id", txtDel.Text);
                            command.ExecuteNonQuery();
                            Int32.TryParse(txtDel.Text, out current);
                            if (count != current)
                            {
                                using (SqlCommand commandRefresh = new SqlCommand( // у всех current меньше текущего, делаем -1
                                        "UPDATE dbo.TableApp SET Id = Id - 1 WHERE Id > @OldId"
                                        ))
                                {
                                    commandRefresh.Connection = connection;
                                    commandRefresh.Parameters.AddWithValue("@OldId", current);
                                    commandRefresh.ExecuteNonQuery();
                                }
                            }
                        }
                        connection.Close();
                    }
                }
            }
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            // вывод из бд
            var excelApp = this.ObjExcel;
            excelApp.Workbooks.Add();
            excelApp.Range["A1"].Value = "№п/п";
            excelApp.Range["B1"].Value = "Наименование приложения";
            excelApp.Range["C1"].Value = "Дата и время завершения";
            excelApp.Range["D1"].Value = "Длительность выполнения процесса";
            excelApp.Range["A1", "D1"].Font.Size = 14;
            excelApp.Range["A1", "D1"].EntireColumn.AutoFit();
            excelApp.Range["A1", "D1"].Interior.ColorIndex = 15;
            excelApp.Range["A1", "D1"].Borders.Weight = Excel.XlBorderWeight.xlThick;
            excelApp.Range["A1", "D1"].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
            excelApp.Range["A1", "D1"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            excelApp.Range["A1", "D1"].Font.Name = "Times New Roman";
            int i = 1;
            string pos2 = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM dbo.TableApp"
                    ))
                {
                    command.Connection = connection;
                    SqlDataReader dataReader = command.ExecuteReader();
                    string[] thisRowView = new string[4];
                    while (dataReader.Read())
                    {
                        thisRowView[0] = dataReader["Id"].ToString();
                        thisRowView[1] = dataReader["Name"].ToString();
                        thisRowView[2] = dataReader["Time_end"].ToString();
                        thisRowView[3] = dataReader["Duration"].ToString();
                        string pos1 = "A" + (i + 1).ToString();
                        pos2 = "D" + (i + 1).ToString();
                        i++;
                        excelApp.Range[pos1, pos2].Value = thisRowView;
                        excelApp.Range[pos1, pos2].Borders.Weight = Excel.XlBorderWeight.xlThin;
                        excelApp.Range[pos1, pos2].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        excelApp.Range[pos1, pos2].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    }
                    dataReader.Close();
                }
                connection.Close();
            }
            excelApp.Range["A2", pos2].BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);
            excelApp.Visible = true;
        }

        private void btnShowDB_Click(object sender, EventArgs e)
        {
            count = 0;
            listAppView.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM dbo.TableApp"
                    ))
                {
                    command.Connection = connection;
                    SqlDataReader dataReader = command.ExecuteReader();
                    string[] toView = new string[4];
                    while (dataReader.Read())
                    {
                        toView[0] = dataReader["Id"].ToString();
                        toView[1] = dataReader["Name"].ToString();
                        toView[2] = dataReader["Time_end"].ToString();
                        toView[3] = dataReader["Duration"].ToString();
                        ListViewItem Item = new ListViewItem(toView);
                        listAppView.Items.Add(Item);
                        count++;
                    }
                    dataReader.Close();
                }
                connection.Close();
            }
        }

        private void txtDel_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;
            if (!Char.IsDigit(key) && key != 8) // Если введенный символ не цифра
            { //  && key != 45
                e.Handled = true; // то событие не обрабатывается
            }
        }

        private void FormDB_Load(object sender, EventArgs e)
        {
            count = 0;
            listAppView.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(
                    "SELECT * FROM dbo.TableApp"
                    ))
                {
                    command.Connection = connection;
                    SqlDataReader dataReader = command.ExecuteReader();
                    string[] toView = new string[4];
                    while (dataReader.Read())
                    {
                        toView[0] = dataReader["Id"].ToString();
                        toView[1] = dataReader["Name"].ToString();
                        toView[2] = dataReader["Time_end"].ToString();
                        toView[3] = dataReader["Duration"].ToString();
                        ListViewItem Item = new ListViewItem(toView);
                        listAppView.Items.Add(Item);
                        count++;
                    }
                    dataReader.Close();
                }
                connection.Close();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}