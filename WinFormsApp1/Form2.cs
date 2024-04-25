using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Model;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        HubConnection hubConnection;
        public static List<Employee> employees = new List<Employee>();
        public Form2()
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
        private async void Form2_Load(object sender, EventArgs e)
        {
            await hubConnection.StartAsync();
            listBox1.Items.Add("Connection Started");
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }


        private async void button1_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.Id = Convert.ToInt32(textBox1.Text);
            emp.Name = textBox2.Text;
            emp.PhoneNo = textBox3.Text;
            emp.clientid = textBox4.Text;
            employees.Add(emp);
            await hubConnection.InvokeAsync("BroadcastEmployee", emp);
            listBox1.Items.Add(emp.Name);
            


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


    }
}
