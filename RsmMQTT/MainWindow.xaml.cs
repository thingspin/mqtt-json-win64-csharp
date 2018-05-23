using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace RsmMQTT
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MqttClient client = null;

            string[] topic = {
                "INSPPROP/#", "+/INSPPROP/#",
                "+/MODELS/#",
                "+/INSPT/#",
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

        }
    }
}
