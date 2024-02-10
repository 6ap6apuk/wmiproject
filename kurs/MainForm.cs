using System;
using System.Windows.Forms;
using System.Management;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace kurs
{
	/// <summary>
	/// Description of MainForm.к
	/// </summary>
	public partial class MainForm : Form
	{
		int flagStart = 0, counter = 0;
		string date = ""; string name = "";
		DateTime timeCreation; TimeSpan diff;
		ManagementEventWatcher w;
		private Excel.Application ObjExcel = new Excel.Application(); // добавление приложения office excel
		//подключение к бд MSSQLLocalDB
		string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\un1que\dpi\3 kurs\2 sem\spo\project\kurs\kurs\Education.mdf;Integrated Security=True;Connect Timeout=30";
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void BtnStartClick(object sender, EventArgs e)
		{
			if (flagStart == 0)
			{
				w = new ManagementEventWatcher("SELECT * FROM __InstanceDeletionEvent WITHIN 4 WHERE TargetInstance ISA 'Win32_Process'");
				w.EventArrived += new EventArrivedEventHandler(EventArrived1);
				//На событие EventArrived объекта w подписан обработчик EventArrived1.
				w.Start();
				listAppView.Items.Clear();
				counter = 0;
				btnDBShow.Enabled = false;
				btnResults.Enabled = false;
				btnAdd.Enabled = false;
				flagStart = 1;
			}
			else
				MessageBox.Show("Процесс запущен.");
		}
		
		void BtnStopClick(object sender, EventArgs e)
		{
			if (flagStart == 1)
			{
				w.Stop(); flagStart = 0;
				btnDBShow.Enabled = true;
				btnResults.Enabled = true;
				btnAdd.Enabled = true;
			}
			else
				MessageBox.Show("Процесс не запущен.");
		}
		
		void BtnCloseClick(object sender, EventArgs e)
		{
			if (flagStart == 1)
			{
				w.Stop();
			}
			Close();
		}
		
		public void EventArrived1(Object sender, EventArrivedEventArgs e)
		{
			counter++;
			// Получаем объект Event и отображаем его
			ManagementBaseObject mo = e.NewEvent;
			// Выводим информацию о подписанном объекте
		   	name = ((ManagementBaseObject)mo["TargetInstance"])["Name"].ToString();
			//date = ((ManagementBaseObject)mo["TargetInstance"])["CreationDate"].ToString();
			// Получаем время работы приложения
			timeCreation = ManagementDateTimeConverter.ToDateTime(((ManagementBaseObject)mo["TargetInstance"])["CreationDate"].ToString());
			//timeCreation = ManagementDateTimeConverter.ToDateTime(((ManagementBaseObject)mo["TargetInstance"])["TerminationDate"].ToString());			
			// Приводим событие к классу басеобджект и из таргет инстанса достаем нейм
			// Получаем время работы приложения
			diff = DateTime.Now.Subtract(timeCreation);
			//string[] toView = { counter.ToString(), name, timeCreation.ToString(), diff.ToString() };
			string[] toView = { counter.ToString(), name, DateTime.Now.ToString(), diff.ToString() };
			// Выполнение добавление в listview отдельным потоком
			this.Invoke(new Action(() =>
              {
                  ListViewItem Item = new ListViewItem(toView);
                  listAppView.Items.Add(Item);
            }));
        }

        private void btnDBShow_Click(object sender, EventArgs e)
		{
			FormDB formDB = new FormDB();
			formDB.Show();
		}

        private void btnAdd_Click(object sender, EventArgs e)
        {
			if (listAppView.Items.Count == 0)
			{
				MessageBox.Show("Список на добавление пустой!");
				return; 
			}
			object executed;
			int count;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				using (SqlCommand command = new SqlCommand(
					"SELECT COUNT(Id) FROM dbo.TableApp"
					))
				{
					command.Connection = connection;
					executed = command.ExecuteScalar();
					count = Convert.ToInt32(executed);
				}
				for (int i = 0; i < listAppView.Items.Count; i++)
				{
					string[] thisRowView = new string[4];
					for (int j = 0; j < listAppView.Items[i].SubItems.Count; j++)
					{
						thisRowView[j] = listAppView.Items[i].SubItems[j].Text;
					}
					using (SqlCommand command = new SqlCommand(
					"INSERT INTO dbo.TableApp (Id, Name, Time_end, Duration) VALUES (@Id, @Name, @Time_end, @Duration)"
					))
					{
						command.Connection = connection;
						if(count == 0)
							command.Parameters.AddWithValue("@Id", thisRowView[0]);
						else
							command.Parameters.AddWithValue("@Id", Convert.ToInt32(thisRowView[0]) + count);
						command.Parameters.AddWithValue("@Name", thisRowView[1]);
						command.Parameters.AddWithValue("@Time_end", thisRowView[2]);
						command.Parameters.AddWithValue("@Duration", thisRowView[3]);
						command.ExecuteNonQuery();
					}
				}
				connection.Close();
			}
		}

        private void btnResults_Click(object sender, EventArgs e)
        {
			//Вывод в эксель
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
			string pos2 = "";
			for (int i = 0; i < listAppView.Items.Count; i++)
            {
				string[] thisRowView = new string[4];
                for (int j = 0; j < listAppView.Items[i].SubItems.Count; j++)
                {
					thisRowView[j] = listAppView.Items[i].SubItems[j].Text;
				}
				string pos1 = "A" + (i + 2).ToString();
				pos2 = "D" + (i + 2).ToString();
				excelApp.Range[pos1, pos2].Value = thisRowView;
				excelApp.Range[pos1, pos2].Borders.Weight = Excel.XlBorderWeight.xlThin;
				excelApp.Range[pos1, pos2].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
				excelApp.Range[pos1, pos2].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
			}
			excelApp.Range["A2", pos2].BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);
			excelApp.Visible = true;
		}
	}
}