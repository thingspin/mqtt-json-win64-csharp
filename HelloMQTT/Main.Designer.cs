namespace HelloMQTT
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerPUB = new System.Windows.Forms.Timer(this.components);
            this.listBox_Models = new System.Windows.Forms.ListBox();
            this.buttonGetModelList = new System.Windows.Forms.Button();
            this.listView_QualityItems = new System.Windows.Forms.ListView();
            this.button_getQuailtyItems = new System.Windows.Forms.Button();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NAME = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DESC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // timerPUB
            // 
            this.timerPUB.Enabled = true;
            this.timerPUB.Interval = 3000;
            this.timerPUB.Tick += new System.EventHandler(this.timerPUB_Tick);
            // 
            // listBox_Models
            // 
            this.listBox_Models.BackColor = System.Drawing.SystemColors.HotTrack;
            this.listBox_Models.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_Models.ForeColor = System.Drawing.SystemColors.Info;
            this.listBox_Models.FormattingEnabled = true;
            this.listBox_Models.ItemHeight = 18;
            this.listBox_Models.Location = new System.Drawing.Point(12, 91);
            this.listBox_Models.Name = "listBox_Models";
            this.listBox_Models.Size = new System.Drawing.Size(465, 702);
            this.listBox_Models.TabIndex = 0;
            // 
            // buttonGetModelList
            // 
            this.buttonGetModelList.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonGetModelList.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonGetModelList.FlatAppearance.BorderSize = 3;
            this.buttonGetModelList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonGetModelList.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonGetModelList.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonGetModelList.Location = new System.Drawing.Point(12, 12);
            this.buttonGetModelList.Name = "buttonGetModelList";
            this.buttonGetModelList.Size = new System.Drawing.Size(465, 73);
            this.buttonGetModelList.TabIndex = 1;
            this.buttonGetModelList.Text = "Get Model List";
            this.buttonGetModelList.UseVisualStyleBackColor = false;
            this.buttonGetModelList.Click += new System.EventHandler(this.buttonGetModelList_Click);
            // 
            // listView_QualityItems
            // 
            this.listView_QualityItems.BackColor = System.Drawing.SystemColors.HotTrack;
            this.listView_QualityItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView_QualityItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.NAME,
            this.DESC});
            this.listView_QualityItems.ForeColor = System.Drawing.SystemColors.Info;
            this.listView_QualityItems.FullRowSelect = true;
            this.listView_QualityItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_QualityItems.HideSelection = false;
            this.listView_QualityItems.LabelEdit = true;
            this.listView_QualityItems.Location = new System.Drawing.Point(502, 91);
            this.listView_QualityItems.Name = "listView_QualityItems";
            this.listView_QualityItems.Size = new System.Drawing.Size(704, 702);
            this.listView_QualityItems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView_QualityItems.TabIndex = 2;
            this.listView_QualityItems.UseCompatibleStateImageBehavior = false;
            this.listView_QualityItems.View = System.Windows.Forms.View.Details;
            // 
            // button_getQuailtyItems
            // 
            this.button_getQuailtyItems.BackColor = System.Drawing.Color.ForestGreen;
            this.button_getQuailtyItems.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button_getQuailtyItems.FlatAppearance.BorderSize = 3;
            this.button_getQuailtyItems.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_getQuailtyItems.ForeColor = System.Drawing.SystemColors.Window;
            this.button_getQuailtyItems.Location = new System.Drawing.Point(502, 12);
            this.button_getQuailtyItems.Name = "button_getQuailtyItems";
            this.button_getQuailtyItems.Size = new System.Drawing.Size(704, 73);
            this.button_getQuailtyItems.TabIndex = 3;
            this.button_getQuailtyItems.Text = "Get QualityItems";
            this.button_getQuailtyItems.UseVisualStyleBackColor = false;
            this.button_getQuailtyItems.Click += new System.EventHandler(this.button_getQuailtyItems_Click);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 50;
            // 
            // NAME
            // 
            this.NAME.Text = "NAME";
            this.NAME.Width = 240;
            // 
            // DESC
            // 
            this.DESC.Text = "설명";
            this.DESC.Width = 100;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(1228, 810);
            this.Controls.Add(this.button_getQuailtyItems);
            this.Controls.Add(this.listView_QualityItems);
            this.Controls.Add(this.buttonGetModelList);
            this.Controls.Add(this.listBox_Models);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hello MQTT with C#";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerPUB;
        public System.Windows.Forms.ListBox listBox_Models;
        private System.Windows.Forms.Button buttonGetModelList;
        private System.Windows.Forms.ListView listView_QualityItems;
        private System.Windows.Forms.Button button_getQuailtyItems;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader NAME;
        private System.Windows.Forms.ColumnHeader DESC;
    }
}

