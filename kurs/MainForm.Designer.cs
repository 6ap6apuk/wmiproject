/*
 * Created by SharpDevelop.
 * User: Egor
 * Date: 29.03.2022
 * Time: 16:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace kurs
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDBShow = new System.Windows.Forms.Button();
            this.btnResults = new System.Windows.Forms.Button();
            this.listAppView = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameApp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Time_end = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Duration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(60, 177);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(98, 35);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Старт";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStartClick);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(213, 177);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(98, 35);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Стоп";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStopClick);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(364, 177);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 35);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Выход";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnCloseClick);
            // 
            // btnDBShow
            // 
            this.btnDBShow.Location = new System.Drawing.Point(36, 226);
            this.btnDBShow.Name = "btnDBShow";
            this.btnDBShow.Size = new System.Drawing.Size(141, 37);
            this.btnDBShow.TabIndex = 3;
            this.btnDBShow.Text = "Работа с базой данных";
            this.btnDBShow.UseVisualStyleBackColor = true;
            this.btnDBShow.Click += new System.EventHandler(this.btnDBShow_Click);
            // 
            // btnResults
            // 
            this.btnResults.Location = new System.Drawing.Point(339, 226);
            this.btnResults.Name = "btnResults";
            this.btnResults.Size = new System.Drawing.Size(145, 35);
            this.btnResults.TabIndex = 4;
            this.btnResults.Text = "Вывести отчет";
            this.btnResults.UseVisualStyleBackColor = true;
            this.btnResults.Click += new System.EventHandler(this.btnResults_Click);
            // 
            // listAppView
            // 
            this.listAppView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.NameApp,
            this.Time_end,
            this.Duration});
            this.listAppView.HideSelection = false;
            this.listAppView.Location = new System.Drawing.Point(22, 21);
            this.listAppView.Name = "listAppView";
            this.listAppView.Size = new System.Drawing.Size(487, 135);
            this.listAppView.TabIndex = 5;
            this.listAppView.UseCompatibleStateImageBehavior = false;
            this.listAppView.View = System.Windows.Forms.View.Details;
            // 
            // Id
            // 
            this.Id.Text = "Id";
            this.Id.Width = 30;
            // 
            // NameApp
            // 
            this.NameApp.Text = "Name";
            this.NameApp.Width = 150;
            // 
            // Time_end
            // 
            this.Time_end.Text = "Time_end";
            this.Time_end.Width = 120;
            // 
            // Duration
            // 
            this.Duration.Text = "Duration";
            this.Duration.Width = 120;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(213, 226);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(98, 35);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 281);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.listAppView);
            this.Controls.Add(this.btnResults);
            this.Controls.Add(this.btnDBShow);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(550, 320);
            this.MinimumSize = new System.Drawing.Size(550, 320);
            this.Name = "MainForm";
            this.Text = "Главное меню";
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnDBShow;
        private System.Windows.Forms.Button btnResults;
        private System.Windows.Forms.ListView listAppView;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader NameApp;
        private System.Windows.Forms.ColumnHeader Time_end;
        private System.Windows.Forms.ColumnHeader Duration;
        private System.Windows.Forms.Button btnAdd;
    }
}
