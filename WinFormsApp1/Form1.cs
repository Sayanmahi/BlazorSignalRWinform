using Microsoft.AspNetCore.SignalR.Client;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        HubConnection hubConnection;
        public Form1()
        {
            InitializeComponent();
            hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7031/signalhub")
                .Build();
            hubConnection.Closed += HubConnection_Closed;

        }
        private async Task HubConnection_Closed(Exception? arg)
        {
            await Task.Delay(new Random().Next(0, 5) * 1000);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
