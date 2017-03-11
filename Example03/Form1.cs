using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoreLibrary;

namespace Example03

{
    public partial class Form1 : Form
    {
        private Order order;
        private Customer customer;

        public Form1()
        {
            InitializeComponent();
            this.customer = new Customer();
            this.customer.name = "陳一明";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RenderScreen();
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            this.order = new Order();
            this.order.Customer = this.customer;
            RenderScreen();
        }

        private void product1Button_Click(object sender, EventArgs e)
        {
            this.order.ProductList.Add(new Product() { Name = "豆漿", Price = 15 });
            RenderScreen();
        }

        private void product2Button_Click(object sender, EventArgs e)
        {
            this.order.ProductList.Add(new Product() { Name = "油條", Price = 10 });
            RenderScreen();
        }

        private void RenderScreen()
        {
            this.customerLabel.Text = this.customer.name;
            this.orderButton.Text = "點餐";
            this.product1Button.Text = "豆漿";
            this.product2Button.Text = "油條";
            this.accountButton.Text = "結帳";
            if (this.order != null)
            {
                this.product1Button.Enabled = true;
                this.product2Button.Enabled = true;
                orderButton.Enabled = false;
                this.orderRichTextBox.Text = order.GetDetail();
            }
            else
            {
                this.product1Button.Enabled = false;
                this.product2Button.Enabled = false;
                orderButton.Enabled = true;
                this.orderRichTextBox.Text = string.Empty;
            }
            this.product1Button.Enabled = this.order != null ? true : false;
            this.product2Button.Enabled = this.order != null ? true : false;
            this.orderButton.Enabled = this.order != null ? false : true;
            this.orderRichTextBox.Text = this.order != null ?
                order.GetDetail() : string.Empty;
        }

        private void accountButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("{0}:結帳金額:{1}，謝謝光臨!", this.order.Customer.name, this.order.GetDetail()));
            this.order = null;
            RenderScreen();
        }

        private void TableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SelctedIndex = TableComboBox.SelectedIndex;
            this.customer.name = TableComboBox.Items[TableComboBox.SelectedIndex].ToString() + "桌";
            RenderScreen();
        }
    }
}