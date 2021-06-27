using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracaInzynierskaV1.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace PracaInzynierskaV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilityController : ControllerBase
    {
        DZguba tmp;
        List<DZguba> InneGet = new List<DZguba>();
        DataTable dt = new DataTable();
        public IConfiguration Configuration { get; }
        public UtilityController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // GET: api/Utility
        [HttpGet]
        public IEnumerable<DZguba> Get()
        {
            String asd = Configuration.GetConnectionString("DevConnection");
            using (var conn = new SqlConnection(asd))
            {


                SqlCommand cmd = new SqlCommand("GETINNEDZGUBY", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    DZguba obj = new DZguba();

                    obj.id = Int32.Parse( dr["id"].ToString());
                    obj.image = null; //Encoding.ASCII.GetBytes(dr["image"].ToString());
                    obj.imageB = dr["imageB"].ToString();
                    obj.location = dr["location"].ToString();
                    obj.name = dr["name"].ToString();
                    obj.status  = dr["status"].ToString();
                    obj.user = dr["user"].ToString();
                    obj.freward = dr["freward"].ToString();
                    InneGet.Add(obj);
                }
            }
            //tutaj procke do pobierania innych 

            return InneGet;//new string[] { "value1", "value2" };
        }

        // GET: api/Utility/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Utility
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Utility/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
