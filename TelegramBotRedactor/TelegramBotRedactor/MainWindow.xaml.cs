using System;
using System.Collections.Generic;
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
using System.IO;
using TelegramBotLibary;
using Newtonsoft.Json;


namespace TelegramBotRedactor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<ActionClass> _listReadyComand;

        DefaultActionList _list;

        public MainWindow()
        {
            InitializeComponent();

            _listReadyComand = new List<ActionClass>();
        }

        private void AddComandOut_Click(object sender, RoutedEventArgs e)
        {
            ActionClass temp = new ActionClass();

            if (OutComandType.Text.ToString() == "Отправить сообщение") temp._viewSend = ViewSendMessage.text;
            if (OutComandType.Text.ToString() == "Отправить стикер") temp._viewSend = ViewSendMessage.sticker;

            temp._data = OutComandData.Text.ToUpper();

            _listReadyComand.Add(temp);

            RefreshCmdListBox();
        }

        private void RefreshCmdListBox()
        {
            ComandList.Items.Clear();

            foreach (var t in _listReadyComand)
            {
                ComandList.Items.Add(JsonConvert.SerializeObject(t).ToString());
            }
        }

        private void AddToList_Click(object sender, RoutedEventArgs e)
        {
            _list = new DefaultActionList(FilePath.Text);
            _list.ReadList();

            TypeGetMessage tpgt = TypeGetMessage.comand;
            switch (InputMessageType.Text)
            {
                case "Команда":
                    {
                        tpgt = TypeGetMessage.comand;
                        break;
                    }
                case "Фраза":
                    {
                        tpgt = TypeGetMessage.containtext;
                        break;
                    }
                case "Содержит в себе":
                    {
                        tpgt = TypeGetMessage.containtext;
                        break;
                    }
                default:
                    {
                        tpgt = TypeGetMessage.containtext;
                        break;
                    }
            }


            _list.AddComand(tpgt, InputMessageData.Text, _listReadyComand);

            _listReadyComand.Clear();
            RefreshCmdListBox();
        }
    }
}
