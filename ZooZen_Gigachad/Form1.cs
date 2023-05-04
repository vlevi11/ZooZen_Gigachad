using Hotcakes.CommerceDTO;
using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Catalog;
using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.CommerceDTO.v1.Contacts;
using Hotcakes.Web;
using System.Data;
using Newtonsoft.Json;

namespace ZooZen_Gigachad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "http://20.234.113.211:8096/";
            string key = "1-4e562905-01dc-461b-b352-328f936981da";


            Api proxy = new Api(url, key);

            // call the API to find all orders in the store
            ApiResponse<List<ProductDTO>> response = proxy.ProductsFindAll();
            string json = JsonConvert.SerializeObject(response);
            textBox1.Text = response.Errors[0].Description;
            //GetProducts();
        }

        public void GetProducts()
        {
            string url = "http://20.234.113.211:8096/";
            string key = "1-4e562905-01dc-461b-b352-328f936981da";


            Api proxy = new Api(url, key);

            // call the API to find all orders in the store
            ApiResponse<List<ProductDTO>> response = proxy.ProductsFindAll();
            string json = JsonConvert.SerializeObject(response);

            textBox1.Text = response.Errors[0].Description;

            ApiResponse<List<ProductDTO>> deserializedResponse = JsonConvert.DeserializeObject<ApiResponse<List<ProductDTO>>>(json);

            DataTable dt = new DataTable();
            dt.Columns.Add("ProductName", typeof(string));
            dt.Columns.Add("SitePrice", typeof(decimal));

            foreach (ProductDTO item in deserializedResponse.Content)
            {
                dt.Rows.Add(item.ProductName, item.SitePrice);
            }

            dataGridView1.DataSource = dt;
        }
    }
}