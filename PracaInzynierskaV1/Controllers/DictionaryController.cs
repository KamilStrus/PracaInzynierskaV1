using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PracaInzynierskaV1.Models;

namespace PracaInzynierskaV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictionaryController : ControllerBase
    {

        private readonly MyDBContext _context;
        List<Gatunek> GatunekGet = new List<Gatunek>();
        List<MarkaUbranie> MarkaUbranieGet = new List<MarkaUbranie>();
        List<RodzajElektronika> RodzajElektronikaGet = new List<RodzajElektronika>();
        List<RodzajUbranie> RodzajUbranieGet = new List<RodzajUbranie>();
        List<Producents> ProducentsGet = new List<Producents>();
        DataTable dt = new DataTable();

        public IConfiguration Configuration { get; }

        public DictionaryController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet("Gatunek")]
        public IEnumerable<Gatunek> Get()
        {
            String asd = Configuration.GetConnectionString("DevConnection");
            using (var conn = new SqlConnection(asd))
            {



                SqlCommand cmd = new SqlCommand("GETGATUNEK", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    Gatunek obj = new Gatunek();

                    obj.id = Int32.Parse(dr["id"].ToString());
                    obj.gatuneknazwa = dr["gatuneknazwa"].ToString();
                   
                    GatunekGet.Add(obj);
                }
            }


            return GatunekGet;//new string[] { "value1", "value2" };

        }



        [HttpGet("MarkaUbrania")]
        public IEnumerable<MarkaUbranie> MarkaGet()
        {
            String asd = Configuration.GetConnectionString("DevConnection");
            using (var conn = new SqlConnection(asd))
            {



                SqlCommand cmd = new SqlCommand("GETMARKAUBRANIE", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    MarkaUbranie obj = new MarkaUbranie();

                    obj.id = Int32.Parse(dr["id"].ToString());
                    obj.markaubrania = dr["markaubrania"].ToString();

                    MarkaUbranieGet.Add(obj);
                }
            }


            return MarkaUbranieGet;//new string[] { "value1", "value2" };

        }

        [HttpGet("Producent")]
        public IEnumerable<Producents> GetProducent()
        {
            String asd = Configuration.GetConnectionString("DevConnection");
            using (var conn = new SqlConnection(asd))
            {



                SqlCommand cmd = new SqlCommand("GETPRODUCENTS", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    Producents obj = new Producents();

                    obj.id = Int32.Parse(dr["id"].ToString());
                    obj.producentnazwa = dr["producentnazwa"].ToString();

                    ProducentsGet.Add(obj);
                }
            }


            return ProducentsGet;//new string[] { "value1", "value2" };

        }

        [HttpGet("RodzajElektronika")]
        public IEnumerable<RodzajElektronika> GetRodzajElektronika()
        {
            String asd = Configuration.GetConnectionString("DevConnection");
            using (var conn = new SqlConnection(asd))
            {



                SqlCommand cmd = new SqlCommand("GETRODZAJELEKTRONIKA", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    RodzajElektronika obj = new RodzajElektronika();

                    obj.id = Int32.Parse(dr["id"].ToString());
                    obj.rodzajelektroniki = dr["rodzajelektroniki"].ToString();

                    RodzajElektronikaGet.Add(obj);
                }
            }


            return RodzajElektronikaGet;//new string[] { "value1", "value2" };

        }

        [HttpGet("RodzajUbrania")]
        public IEnumerable<RodzajUbranie> GetRodzajUbrania()
        {
            String asd = Configuration.GetConnectionString("DevConnection");
            using (var conn = new SqlConnection(asd))
            {



                SqlCommand cmd = new SqlCommand("GETRODZAJUBRANIE", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    RodzajUbranie obj = new RodzajUbranie();

                    obj.id = Int32.Parse(dr["id"].ToString());
                    obj.rodzajubrania = dr["rodzajubrania"].ToString();

                    RodzajUbranieGet.Add(obj);
                }
            }


            return RodzajUbranieGet;//new string[] { "value1", "value2" };

        }


    }
}
