using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace HelloMQTT
{
    public partial class Main : Form
    {
        MqttClient client = null;

        string[] topic = {
            "INSPPROP/#", "+/INSPPROP/#",
            "+/MODELS/#",
            "+/INSPT/#"
        };

        byte[] qosLevels = {
            MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE,
            MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE,
            MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE
        };

        ObservableCollection<Model> Models = new ObservableCollection<Model>();
        ObservableCollection<QualityItem> QualityItems = new ObservableCollection<QualityItem>();

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

                JObject item = JObject.Parse(payload);

                QualityItem q = new QualityItem(id, (string)item["NAME"], (string)item["DESCRIPTION"]);
                QualityItems.Add(q);

                ListViewItem log = new ListViewItem("검사항목 수신 : " + topic);
                log.SubItems.Add(payload);
                listView_Log.Items.Insert(0, log);

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

            match = Regex.Match(topic, @"([^/\n]*)INSPT/((.*?))");
            if (match.Success)
            {
                ListViewItem log = new ListViewItem("시험결과 에코 : " + topic);
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
            client.Disconnect();
        }

        private void timerPUB_Tick(object sender, EventArgs e)
        {
            var inspctDev = new JObject();

            inspctDev.Add("prodModel", "ACPBRC15B20");
            inspctDev.Add("startTime", "2018/05/09 11:05:24");
            inspctDev.Add("pass", false);

            inspctDev.Add("barCode", "4343-5454-544-54545"); // optional - future use.
            inspctDev.Add("macADDR", "4343:5454:544"); // optional - future use.
            inspctDev.Add("bltADDR", "4343:5454:544"); // optional - future use.

            var details = new JArray();

            var rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                var inspctItem = new JObject();

                float val = (float)rand.NextDouble();
                float min = (float)rand.NextDouble();
                float max = (float)rand.NextDouble();

                if (min > max)
                {
                    var t = min;
                    min = max;
                    max = min;
                }

                bool pass = false;

                if (min < val && max > val)
                {
                    pass = true;
                }
                else
                {
                    pass = false;
                }

                inspctItem.Add("iid", i);
                inspctItem.Add("val", val); // temporary random - no meaningfull.
                inspctItem.Add("min", min); // temporary random - no meaningfull.
                inspctItem.Add("max", max); // temporary random - no meaningfull.
                inspctItem.Add("pass", pass);

                details.Add(inspctItem);
            }

            inspctDev.Add("details", details);

            client.Publish("K/INSPT/IPC01/0", Encoding.UTF8.GetBytes(inspctDev.ToString(Formatting.None)));
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
            var inspctDev = new JObject();

            inspctDev.Add("prodModel", "ACPBRC15B20");
            inspctDev.Add("startTime", "2018/05/09 11:05:24");
            inspctDev.Add("pass", false);

            inspctDev.Add("barCode", "4343-5454-544-54545"); // optional - future use.
            inspctDev.Add("macADDR", "4343:5454:544"); // optional - future use.
            inspctDev.Add("bltADDR", "4343:5454:544"); // optional - future use.

            var details = new JArray();

            var rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                var inspctItem = new JObject();

                float val = (float)rand.NextDouble();
                float min = (float)rand.NextDouble();
                float max = (float)rand.NextDouble();

                if (min > max)
                {
                    var t = min;
                    min = max;
                    max = min;
                }

                bool pass = false;

                if (min < val && max > val)
                {
                    pass = true;
                }
                else
                {
                    pass = false;
                }

                inspctItem.Add("iid", i);
                inspctItem.Add("val", val); // temporary random - no meaningfull.
                inspctItem.Add("min", min); // temporary random - no meaningfull.
                inspctItem.Add("max", max); // temporary random - no meaningfull.
                inspctItem.Add("pass", pass);

                details.Add(inspctItem);
            }

            inspctDev.Add("details", details);

            client.Publish("K/INSPT/IPC01/0", Encoding.UTF8.GetBytes(inspctDev.ToString(Formatting.None)));
        }

        private void listView_Log_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
