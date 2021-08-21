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

        private readonly MyDBContext _context;
        DZguba tmp;
        List<DZguba> InneGet = new List<DZguba>();
        List<UserRanking> RankingGet = new List<UserRanking>();
        List<DNagroda> NagrodyGet = new List<DNagroda>();
        DataTable dt = new DataTable();
        public IConfiguration Configuration { get; }
        public UtilityController(IConfiguration configuration, MyDBContext context)
        {
            Configuration = configuration;
            _context = context;
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
            

            return InneGet;//new string[] { "value1", "value2" };
        }

        // GET: Ranking
        [HttpGet("Ranking")]
        public IEnumerable<UserRanking> GetRanking()
        {
            String asd = Configuration.GetConnectionString("DevConnection");
            using (var conn = new SqlConnection(asd))
            {



                SqlCommand cmd = new SqlCommand("Ranking", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    UserRanking obj = new UserRanking();

                    obj.rank = Int32.Parse(dr["Rank"].ToString());
                    obj.name = dr["Name"].ToString();
                    obj.surname = dr["Surname"].ToString();
                    obj.points = Int32.Parse(dr["Points"].ToString());
                    obj.image = dr["ImageB"].ToString();
                    RankingGet.Add(obj);
                }
            }


            return RankingGet;//new string[] { "value1", "value2" };

        }

        [HttpGet("NagrodyUser/{IdUser}")]
        public IEnumerable<DNagroda> GetNagrody(string IdUser)
        {
            String asd = Configuration.GetConnectionString("DevConnection");
            using (var conn = new SqlConnection(asd))
            {
                SqlCommand cmd = new SqlCommand("Nagrody_User", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdUser", SqlDbType.NVarChar);
              
                cmd.Parameters["@IdUser"].Value = IdUser;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    DNagroda obj = new DNagroda();

                    obj.id = dr["id"].ToString();
                    obj.name = dr["Name"].ToString();
                    obj.description = dr["Description"].ToString();
                    obj.cost = Int32.Parse(dr["Cost"].ToString());
                    obj.ilosc = Int32.Parse(dr["Ilosc"].ToString());
                    obj.imageB = dr["ImageB"].ToString();
                    NagrodyGet.Add(obj);
                }
            }


            return NagrodyGet;//new string[] { "value1", "value2" };

        }


        // GET: api/Utility/5
        [HttpGet("Search/{Category}/{byWhat}/{regex}")]
        public IEnumerable<DZguba> Get(string byWhat, string regex, string Category )
        {
            if (regex == "pusty")
                regex = " ";

            String asd = Configuration.GetConnectionString("DevConnection");
            using (var conn = new SqlConnection(asd))
            {

                SqlCommand cmd = new SqlCommand("SearchByName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Regex", SqlDbType.NVarChar);
                cmd.Parameters.Add("@ByWhat", SqlDbType.NVarChar);
                cmd.Parameters.Add("@Category", SqlDbType.NVarChar);
                cmd.Parameters["@Regex"].Value = regex;
                cmd.Parameters["@ByWhat"].Value = byWhat;
                cmd.Parameters["@Category"].Value = Category;
              

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if (Category == "Wszystkie")
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        DZguba obj = new DZguba();

                        obj.id = Int32.Parse(dr["id"].ToString());
                        obj.image = null; //Encoding.ASCII.GetBytes(dr["image"].ToString());
                        obj.imageB = dr["imageB"].ToString();
                        obj.location = dr["location"].ToString();
                        obj.name = dr["name"].ToString();
                        obj.status = dr["status"].ToString();
                        obj.user = dr["user"].ToString();
                        obj.freward = dr["freward"].ToString();

                        InneGet.Add(obj);
                    }
                }
                else if (Category == "Ubranie")
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        DZguba_Ubranie obj = new DZguba_Ubranie();

                        obj.id = Int32.Parse(dr["id"].ToString());
                        obj.image = null; //Encoding.ASCII.GetBytes(dr["image"].ToString());
                        obj.imageB = dr["imageB"].ToString();
                        obj.location = dr["location"].ToString();
                        obj.name = dr["name"].ToString();
                        obj.status = dr["status"].ToString();
                        obj.user = dr["user"].ToString();
                        obj.Rodzaj = dr["Rodzaj"].ToString();
                        obj.Marka = dr["Marka"].ToString();
                        obj.Kolor = dr["Kolor"].ToString();


                        InneGet.Add(obj);
                    }
                }
                else if (Category == "Zwierze")
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        DZguba_Zwierze obj = new DZguba_Zwierze();

                        obj.id = Int32.Parse(dr["id"].ToString());
                        obj.image = null; //Encoding.ASCII.GetBytes(dr["image"].ToString());
                        obj.imageB = dr["imageB"].ToString();
                        obj.location = dr["location"].ToString();
                        obj.name = dr["name"].ToString();
                        obj.status = dr["status"].ToString();
                        obj.user = dr["user"].ToString();
                        obj.gatunek = dr["gatunek"].ToString();
                        obj.umaszczenie = dr["umaszczenie"].ToString();
                        obj.freward = dr["freward"].ToString();


                        InneGet.Add(obj);
                    }
                }
                else if (Category == "Inne")
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        DZguba obj = new DZguba();

                        obj.id = Int32.Parse(dr["id"].ToString());
                        obj.image = null; //Encoding.ASCII.GetBytes(dr["image"].ToString());
                        obj.imageB = dr["imageB"].ToString();
                        obj.location = dr["location"].ToString();
                        obj.name = dr["name"].ToString();
                        obj.status = dr["status"].ToString();
                        obj.user = dr["user"].ToString();
                        obj.freward = dr["freward"].ToString();

                        InneGet.Add(obj);
                    }
                }
                else if (Category == "Elektronika")
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        DZguba_Elektronika obj = new DZguba_Elektronika();

                        obj.id = Int32.Parse(dr["id"].ToString());
                        obj.image = null; //Encoding.ASCII.GetBytes(dr["image"].ToString());
                        obj.imageB = dr["imageB"].ToString();
                        obj.location = dr["location"].ToString();
                        obj.name = dr["name"].ToString();
                        obj.status = dr["status"].ToString();
                        obj.user = dr["user"].ToString();
                        obj.freward = dr["freward"].ToString();
                        obj.Rodzaj = dr["Rodzaj"].ToString();
                        obj.Producent = dr["Producent"].ToString();

                        InneGet.Add(obj);
                    }

                }
             
            }

            String test = byWhat + " " + regex + " " + Category;
            return InneGet;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DZguba>> DeleteDZguba(int id)
        {
            var dZguba = await _context.DZguby.FindAsync(id);
            if (dZguba == null)
            {
                return NotFound();
            }

            _context.DZguby.Remove(dZguba);
            await _context.SaveChangesAsync();

            return dZguba;
        }
    }
}
