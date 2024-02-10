
namespace kurs
{
    partial class FormDB
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDB));
            this.btnResults = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.listAppView = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameApp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Time_end = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Duration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnShowDB = new System.Windows.Forms.Button();
            this.txtDel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnResults
            // 
            this.btnResults.Location = new System.Drawing.Point(215, 177);
            this.btnResults.Name = "btnResults";
            this.btnResults.Size = new System.Drawing.Size(145, 35);
            this.btnResults.TabIndex = 6;
            this.btnResults.Text = "Вывести отчет";
            this.btnResults.UseVisualStyleBackColor = true;
            this.btnResults.Click += new System.EventHandler(this.btnResults_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(40, 177);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(141, 35);
            this.btnDel.TabIndex = 5;
            this.btnDel.Text = "Удалить данные";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(397, 177);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 35);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Выход";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // listAppView
            // 
            this.listAppView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.NameApp,
            this.Time_end,
            this.Duration});
            this.listAppView.HideSelection = false;
            this.listAppView.Location = new System.Drawing.Point(27, 23);
            this.listAppView.Name = "listAppView";
            this.listAppView.Size = new System.Drawing.Size(481, 135);
            this.listAppView.TabIndex = 8;
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
            // btnShowDB
            // 
            this.btnShowDB.Location = new System.Drawing.Point(215, 219);
            this.btnShowDB.Name = "btnShowDB";
            this.btnShowDB.Size = new System.Drawing.Size(145, 36);
            this.btnShowDB.TabIndex = 9;
            this.btnShowDB.Text = "Обновить данные";
            this.btnShowDB.UseVisualStyleBackColor = true;
            this.btnShowDB.Click += new System.EventHandler(this.btnShowDB_Click);
            // 
            // txtDel
            // 
            this.txtDel.Location = new System.Drawing.Point(42, 228);
            this.txtDel.Name = "txtDel";
            this.txtDel.Size = new System.Drawing.Size(138, 20);
            this.txtDel.TabIndex = 10;
            this.txtDel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDel_KeyPress);
            // 
            // FormDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 281);
            this.Controls.Add(this.txtDel);
            this.Controls.Add(this.btnShowDB);
            this.Controls.Add(this.listAppView);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnResults);
            this.Controls.Add(this.btnDel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(550, 320);
            this.MinimumSize = new System.Drawing.Size(550, 320);
            this.Name = "FormDB";
            this.Text = "Работа с бд";
            this.Load += new System.EventHandler(this.FormDB_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDel_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnResults;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView listAppView;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader NameApp;
        private System.Windows.Forms.ColumnHeader Time_end;
        private System.Windows.Forms.ColumnHeader Duration;
        private System.Windows.Forms.Button btnShowDB;
        private System.Windows.Forms.TextBox txtDel;
    }
}

