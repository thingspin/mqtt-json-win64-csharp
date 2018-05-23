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
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NAME = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DESC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_getQuailtyItems = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.listView_Log = new System.Windows.Forms.ListView();
            this.Toptic = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Payload = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_ClearLog = new System.Windows.Forms.Button();
            this.button_StartPublisher = new System.Windows.Forms.Button();
            this.button_StopPubliser = new System.Windows.Forms.Button();
            this.numericUpDown_intervalMS = new System.Windows.Forms.NumericUpDown();
            this.button_Quit = new System.Windows.Forms.Button();
            this.label_Count_Send = new System.Windows.Forms.Label();
            this.label_Count_Return = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_intervalMS)).BeginInit();
            this.SuspendLayout();
            // 
            // timerPUB
            // 
            this.timerPUB.Interval = 1000;
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
            this.listBox_Models.Size = new System.Drawing.Size(465, 396);
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
            this.listView_QualityItems.Size = new System.Drawing.Size(704, 396);
            this.listView_QualityItems.TabIndex = 2;
            this.listView_QualityItems.UseCompatibleStateImageBehavior = false;
            this.listView_QualityItems.View = System.Windows.Forms.View.Details;
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
            // buttonSend
            // 
            this.buttonSend.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonSend.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonSend.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonSend.Location = new System.Drawing.Point(1228, 13);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(347, 72);
            this.buttonSend.TabIndex = 4;
            this.buttonSend.Text = "Send Test Data (1-record)";
            this.buttonSend.UseVisualStyleBackColor = false;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // listView_Log
            // 
            this.listView_Log.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.listView_Log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView_Log.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Toptic,
            this.Payload});
            this.listView_Log.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.listView_Log.LabelEdit = true;
            this.listView_Log.Location = new System.Drawing.Point(12, 493);
            this.listView_Log.Name = "listView_Log";
            this.listView_Log.Size = new System.Drawing.Size(1568, 591);
            this.listView_Log.TabIndex = 5;
            this.listView_Log.UseCompatibleStateImageBehavior = false;
            this.listView_Log.View = System.Windows.Forms.View.Details;
            this.listView_Log.SelectedIndexChanged += new System.EventHandler(this.listView_Log_SelectedIndexChanged);
            // 
            // Toptic
            // 
            this.Toptic.Text = "Topic";
            this.Toptic.Width = 250;
            // 
            // Payload
            // 
            this.Payload.Text = "Payload";
            this.Payload.Width = 900;
            // 
            // button_ClearLog
            // 
            this.button_ClearLog.BackColor = System.Drawing.Color.Black;
            this.button_ClearLog.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_ClearLog.Location = new System.Drawing.Point(1228, 349);
            this.button_ClearLog.Name = "button_ClearLog";
            this.button_ClearLog.Size = new System.Drawing.Size(347, 60);
            this.button_ClearLog.TabIndex = 6;
            this.button_ClearLog.Text = "Clear Log";
            this.button_ClearLog.UseVisualStyleBackColor = false;
            this.button_ClearLog.Click += new System.EventHandler(this.button_ClearLog_Click);
            // 
            // button_StartPublisher
            // 
            this.button_StartPublisher.Location = new System.Drawing.Point(1228, 130);
            this.button_StartPublisher.Name = "button_StartPublisher";
            this.button_StartPublisher.Size = new System.Drawing.Size(155, 86);
            this.button_StartPublisher.TabIndex = 7;
            this.button_StartPublisher.Text = "Start Publisher";
            this.button_StartPublisher.UseVisualStyleBackColor = true;
            this.button_StartPublisher.Click += new System.EventHandler(this.button_StartPublisher_Click);
            // 
            // button_StopPubliser
            // 
            this.button_StopPubliser.Location = new System.Drawing.Point(1412, 130);
            this.button_StopPubliser.Name = "button_StopPubliser";
            this.button_StopPubliser.Size = new System.Drawing.Size(154, 86);
            this.button_StopPubliser.TabIndex = 8;
            this.button_StopPubliser.Text = "Stop Publisher";
            this.button_StopPubliser.UseVisualStyleBackColor = true;
            this.button_StopPubliser.Click += new System.EventHandler(this.button_StopPubliser_Click);
            // 
            // numericUpDown_intervalMS
            // 
            this.numericUpDown_intervalMS.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.numericUpDown_intervalMS.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown_intervalMS.Location = new System.Drawing.Point(1228, 91);
            this.numericUpDown_intervalMS.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.numericUpDown_intervalMS.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_intervalMS.Name = "numericUpDown_intervalMS";
            this.numericUpDown_intervalMS.Size = new System.Drawing.Size(338, 33);
            this.numericUpDown_intervalMS.TabIndex = 9;
            this.numericUpDown_intervalMS.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.numericUpDown_intervalMS.ValueChanged += new System.EventHandler(this.numericUpDown_intervalMS_ValueChanged);
            // 
            // button_Quit
            // 
            this.button_Quit.BackColor = System.Drawing.Color.Black;
            this.button_Quit.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button_Quit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_Quit.Location = new System.Drawing.Point(1228, 415);
            this.button_Quit.Name = "button_Quit";
            this.button_Quit.Size = new System.Drawing.Size(347, 72);
            this.button_Quit.TabIndex = 10;
            this.button_Quit.Text = "Quit";
            this.button_Quit.UseVisualStyleBackColor = false;
            this.button_Quit.Click += new System.EventHandler(this.button_Quit_Click);
            // 
            // label_Count_Send
            // 
            this.label_Count_Send.BackColor = System.Drawing.Color.Lime;
            this.label_Count_Send.Font = new System.Drawing.Font("굴림", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Count_Send.ForeColor = System.Drawing.Color.Red;
            this.label_Count_Send.Location = new System.Drawing.Point(1236, 229);
            this.label_Count_Send.Name = "label_Count_Send";
            this.label_Count_Send.Size = new System.Drawing.Size(330, 54);
            this.label_Count_Send.TabIndex = 11;
            this.label_Count_Send.Text = "0";
            this.label_Count_Send.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Count_Return
            // 
            this.label_Count_Return.BackColor = System.Drawing.Color.GreenYellow;
            this.label_Count_Return.Font = new System.Drawing.Font("굴림", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Count_Return.ForeColor = System.Drawing.Color.Black;
            this.label_Count_Return.Location = new System.Drawing.Point(1236, 292);
            this.label_Count_Return.Name = "label_Count_Return";
            this.label_Count_Return.Size = new System.Drawing.Size(330, 54);
            this.label_Count_Return.TabIndex = 12;
            this.label_Count_Return.Text = "0";
            this.label_Count_Return.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(1592, 1163);
            this.Controls.Add(this.label_Count_Return);
            this.Controls.Add(this.label_Count_Send);
            this.Controls.Add(this.button_Quit);
            this.Controls.Add(this.numericUpDown_intervalMS);
            this.Controls.Add(this.button_StopPubliser);
            this.Controls.Add(this.button_StartPublisher);
            this.Controls.Add(this.button_ClearLog);
            this.Controls.Add(this.listView_Log);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.button_getQuailtyItems);
            this.Controls.Add(this.listView_QualityItems);
            this.Controls.Add(this.buttonGetModelList);
            this.Controls.Add(this.listBox_Models);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hello MQTT with C#";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_intervalMS)).EndInit();
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
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.ListView listView_Log;
        private System.Windows.Forms.ColumnHeader Toptic;
        private System.Windows.Forms.ColumnHeader Payload;
        private System.Windows.Forms.Button button_ClearLog;
        private System.Windows.Forms.Button button_StartPublisher;
        private System.Windows.Forms.Button button_StopPubliser;
        private System.Windows.Forms.NumericUpDown numericUpDown_intervalMS;
        private System.Windows.Forms.Button button_Quit;
        private System.Windows.Forms.Label label_Count_Send;
        private System.Windows.Forms.Label label_Count_Return;
    }
}

