using ItemsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace ItemsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public ItemController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet]
        public List<Items> GetItems()
        {
            return LoadList();
        }
        [HttpPost]

        public string PostItems(Items it)

        {
            SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
           SqlCommand cmd = new SqlCommand("Insert into Items Values ('" + it.ItemName + "','" + it.ItemCode + "','" + it.Price , con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return "Added";

            

        }


        private List <Items> LoadList()
        {
            //var items = new List<Items>();
            List<Items> list = new List<Items>();

            SqlConnection con = new
                SqlConnection(configuration.GetConnectionString("DefaultConnection"));
                 con.Open();
                SqlCommand cmd = new SqlCommand("select * from Items ",con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Items ob = new Items();
                ob.ItemCode = dataTable.Rows[i]["ItemCode"].ToString();
                ob.ItemName = dataTable.Rows[i]["ItemName"].ToString();
                ob.Price = int.Parse(dataTable.Rows[i]["Price"].ToString());
                list.Add(ob);


            }

            return list;


        }

      
    }
}
