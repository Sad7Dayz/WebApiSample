using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace WebApiSample.Controllers
{
    public class ValuesController : ApiController
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-31RBJTHA\SQLEXPRESS; database=TestEmployees; Integrated Security=true;");
        // GET api/values
        public string Get()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Employee", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count>0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
            {
                return "No data found";
            }
           
        }

        // GET api/values/5
        public string Get(int id)
        {
            //return "value";
            SqlDataAdapter da = new SqlDataAdapter("Select * from Employee Where id = '"+ id +"' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
            {
                return "No data found";
            }
        }


        // POST api/values
        public string Post([FromBody] string value)
        {
            //return value + " added sucessfully";
            SqlCommand cmd = new SqlCommand("Insert into Employee(Name) VALUES ('" + value + "')", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return "Record inserted with the value as " + value;
            }
            else
            {
                return "Try again. No data inserted";
            }
        }
      
        // PUT api/values/5
        public string Put(int id, [FromBody] string value)
        {
            //return value + "updated successfully with id " + id;

            SqlCommand cmd = new SqlCommand("UPDATE Employee set Name= '" + value + "' where ID = '" + id +"' ", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return "Record inserted with the value as " + value + " and id as" + id;
            }
            else
            {
                return "Try again. No data inserted";
            }
        }
       
        // DELETE api/values/5
        public string Delete(int id)
        {
            //return " record deleted successfully with the id " + id;
            SqlCommand cmd = new SqlCommand("DELETE FROM Employee WHERE ID = '" + id + "' ", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return "Record Deleted with the id as" + id;
            }
            else
            {
                return "Try again. No data inserted";
            }
        }
    }
}
