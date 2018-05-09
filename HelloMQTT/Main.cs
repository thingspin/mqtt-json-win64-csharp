using System;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace HelloMQTT
{
    public partial class Main : Form
    {
        MqttClient client = null;

        string[] topic = {
                "K/INSPT/#",
                "THINGSPIN/MODELS/#",
                "THINGSPIN/FAULTYCODE/#"
            };

        public Main()
        {
            InitializeComponent();

            client = new MqttClient("219.251.4.237");

            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
            client.MqttMsgSubscribed += client_MqttMsgSubscribed;
            client.MqttMsgUnsubscribed += client_MqttMsgUnsubscribed;

            client.Connect(Guid.NewGuid().ToString());



            byte[] qosLevels = {
                MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE,
                MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE,
                MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE
            };

            client.Subscribe(topic, qosLevels);
        }

        void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            var message = System.Text.Encoding.Default.GetString(e.Message);
            System.Console.WriteLine("Message received: " + message);
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
            var inspctDev = new JObject();
            inspctDev.Add("prodModel", "ACPBRC15B20");
            inspctDev.Add("startTime", "2018/05/09 11:05:24");
            inspctDev.Add("pass", false);

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

            client.Publish("K/INSPT/IPC01/0", Encoding.UTF8.GetBytes(inspctDev.ToString()));
        }
    }
}
