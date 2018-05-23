using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

//==================================================================================================================================
namespace HelloMQTT
{
    public partial class Main : Form
    {
        MqttClient client = null;

        string[] topic = {
            "INSPPROP/#", "+/INSPPROP/#",
            "+/MODELS/#",
            //"+/INSPT/#",
            "+/INSPTDEV/#",
            "ACTINADV/#", "+/ACTINADV/#"
        };

        byte[] qosLevels = {
            MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE,
            MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE,
            MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE,
            MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE
        };

        ObservableCollection<Model> Models = new ObservableCollection<Model>();
        ObservableCollection<QualityItem> QualityItems = new ObservableCollection<QualityItem>();

        int count_Send = 0;
        int count_Echo = 0;

        Random rand = new Random();

        public Main()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;
            listView_Log.View = View.Details;
            listView_Log.GridLines = true;
            listView_Log.FullRowSelect = true;


            Models.CollectionChanged += models_CollectionChanged;
            QualityItems.CollectionChanged += qualityItems_CollectionChanged;

            client = new MqttClient("219.251.4.237");

            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            client.MqttMsgSubscribed += client_MqttMsgSubscribed;
            client.MqttMsgUnsubscribed += client_MqttMsgUnsubscribed;

            client.Connect(Guid.NewGuid().ToString());

            client.Subscribe(topic, qosLevels);
        }
 
        public void models_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
        }

        public void qualityItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
        }

        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            var topic = e.Topic;
            var payload = System.Text.Encoding.UTF8.GetString(e.Message);

            Match match = Regex.Match(topic, @"([^/\n]*)INSPPROP/((.*?))");
            if (match.Success)
            {
                topic = topic.Replace("THINGSPIN/", "");
                string[] token = topic.Split('/');
                int id = Int16.Parse(token[1]);

                if (payload != null && payload != "")
                {
                    JObject item = JObject.Parse(payload);

                    QualityItem q = new QualityItem(id, (string)item["NAME"], (string)item["DESCRIPTION"]);
                    QualityItems.Add(q);

                    ListViewItem log = new ListViewItem("검사항목 수신 : " + topic);
                    log.SubItems.Add(payload);
                    listView_Log.Items.Insert(0, log);

                }
                else {
                    ListViewItem log = new ListViewItem("검사항목 삭제 : " + topic);
                    listView_Log.Items.Insert(0, log);
                }

                return;
            }

            match = Regex.Match(topic, @"THINGSPIN/MODELS$");
            if (match.Success)
            {

                JArray arr = JArray.Parse(payload);

                foreach (var item in arr)
                {
                    Model m = new Model((string)item["MODEL_ID"], (string)item["DESCRIPTION"]);
                    Models.Add(m);
                }

                ListViewItem log = new ListViewItem("모델정보 수신 : " + topic);
                log.SubItems.Add(payload);
                listView_Log.Items.Insert(0, log);

                return;
            }

            //match = Regex.Match(topic, @"([^/\n]*)INSPT/((.*?))");
            match = Regex.Match(topic, @"([^/\n]*)INSPTDEV/((.*?))");
            if (match.Success)
            {
                ++count_Echo;
                this.label_Count_Return.Text = count_Echo.ToString();

                //ListViewItem log = new ListViewItem("시험결과 에코 : " + topic);
                //log.SubItems.Add(payload);
                //listView_Log.Items.Insert(0, log);
                return;
            }

            match = Regex.Match(topic, @"([^/\n]*)ACTINADV/((.*?))");
            if (match.Success)
            {
                ListViewItem log = new ListViewItem("사전조치룰 : " + topic);
                log.SubItems.Add(payload);
                listView_Log.Items.Insert(0, log);
                return;
            }
        }

        void client_MqttMsgUnsubscribed(object sender, MqttMsgUnsubscribedEventArgs e)
        {
            // write your code
        }

        void client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {
            // write your code
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Unsubscribe(topic);
        }

        private void timerPUB_Tick(object sender, EventArgs e)
        {
            simulation_Send();
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGetModelList_Click(object sender, EventArgs e)
        {
            listBox_Models.DataSource = Models;
        }

        private void button_getQuailtyItems_Click(object sender, EventArgs e)
        {
            listView_QualityItems.Items.Clear();

            foreach (QualityItem q in QualityItems)
            {
                ListViewItem lvi = new ListViewItem(q.ToString());
                lvi.SubItems.Add(q.name);
                lvi.SubItems.Add(q.description);

                listView_QualityItems.Items.Add(lvi);
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            simulation_Send();
        }

        public void simulation_Send() {

            if (Models.Count == 0 || QualityItems.Count == 0) {
                return;
            }

            int randomMODEL = rand.Next(1, Models.Count - 1);
            int randomPCID = rand.Next(1, 4);
            int randomChannel = rand.Next(1, 5);

            string lineCD = "ASSEY"; // 라인구분 코드
            string pcID = "SOOSKIM" + randomPCID.ToString("D2"); // 검사기 PC의 아이디 (프로그램에서 세팅값)
            string modelID = Models[randomMODEL].id; // 검사하는 디바이스의 모델명 (모델리스트에서 선택한 값)

            int channel = randomChannel; // 디바이스가 테스트되는 채널 번호 (가정 : 0 ~ 3)

            //string topic = lineCD + "/" + "INSPT/" + pcID + "/" + channel; 
            string topic = lineCD + "/" + "INSPTDEV/" + pcID + "/" + channel;

            var inspctDev = new JObject();
            bool passAll = true;

            inspctDev.Add("prodModel", modelID);
            inspctDev.Add("pcID", pcID);
            inspctDev.Add("channel", channel);

            string sTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            inspctDev.Add("startTime", sTime);
            
            //inspctDev.Add("barCode", "4343-5454-544-54545"); // optional - future use.
            //inspctDev.Add("macADDR", "4343:5454:544"); // optional - future use.
            //inspctDev.Add("bltADDR", "4343:5454:544"); // optional - future use.

            var details = new JArray();
            //foreach (QualityItem q in QualityItems)
            for (int i = 0; i < QualityItems.Count; i++)
            {
                QualityItem q = QualityItems[i];

                var inspctItem = new JObject();

                //double u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
                //double u2 = 1.0 - rand.NextDouble();
                //double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
                //double randNormal = mean + stdDev * randStdNormal; //random normal(mean,stdDev^2)

                float val = (float)rand.NextGaussian(-1.0, +1.0);
                float min = (float)-0.95;
                float max = (float)+0.95;

                bool pass = false;

                if (min < val && max > val)
                {
                    pass = true;
                }
                else
                {
                    pass = false;
                    passAll = false; // 검사항목 중 1개라도 불량이면 디바이스는 불량으로 처리
                }

                inspctItem.Add("iid", q.id); // !!!! 검사항목 번호 !!!!

                inspctItem.Add("val", val); // temporary random
                inspctItem.Add("min", min); // temporary random
                inspctItem.Add("max", max); // temporary random
                inspctItem.Add("pass", pass);

                details.Add(inspctItem);
            }

            /*
            var randPASS = new Random();
            if (randPASS.Next(0, 7) == 0)
                passAll = false;
            else
                passAll = true;
            */

            inspctDev.Add("pass", passAll);

            string eTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            inspctDev.Add("endTime", eTime);

            inspctDev.Add("details", details);

            byte[] payload = Encoding.UTF8.GetBytes(inspctDev.ToString(Formatting.None));

            client.Publish(topic, payload);

            ++count_Send;
            this.label_Count_Send.Text = count_Send.ToString();
            
            //ListViewItem log = new ListViewItem("시험결과 전송 : " + topic);
            //log.SubItems.Add(inspctDev.ToString(Formatting.None));
            //listView_Log.Items.Insert(0, log);
        }

        private void listView_Log_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_ClearLog_Click(object sender, EventArgs e)
        {
            count_Echo = 0;
            this.label_Count_Return.Text = count_Echo.ToString();

            count_Send = 0;
            this.label_Count_Send.Text = count_Send.ToString();

            listView_Log.Items.Clear();
        }

        private void button_StartPublisher_Click(object sender, EventArgs e)
        {
            this.timerPUB.Enabled = true;
        }

        private void button_StopPubliser_Click(object sender, EventArgs e)
        {
            this.timerPUB.Enabled = false;
        }

        private void numericUpDown_intervalMS_ValueChanged(object sender, EventArgs e)
        {
            bool tE = timerPUB.Enabled;
            timerPUB.Enabled = false;

            timerPUB.Interval = (int)((NumericUpDown)sender).Value;

            timerPUB.Enabled = tE;
        }

        private void button_Quit_Click(object sender, EventArgs e)
        {
            timerPUB.Enabled = false;

            client.Unsubscribe(topic);
            client.Disconnect();

            this.Close();
        }
    }
}
//==================================================================================================================================