using Hotcakes.CommerceDTO;
using Hotcakes.CommerceDTO.v1;
using Hotcakes.CommerceDTO.v1.Client;
using Hotcakes.CommerceDTO.v1.Contacts;
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
            //Api endpoint
            string url = "http://20.234.113.211:8096/";
            string key = "1-4e562905-01dc-461b-b352-328f936981da";

            Api proxy = new Api(url, key);

            // specify the price group ID (bvin) you want to find
            var priceGroupID = "f3aafd58-e17b-49df-8e8e-9f5ae33d3bc4";

            // search for and return the price group
            ApiResponse<PriceGroupDTO> response = proxy.PriceGroupsFind(priceGroupID);

            //textBox1.Text = response.ToString();
            textBox1.Text = response.Errors[0].Description;
        }
    }
}