using System.Data;
using System.Data.SqlClient;

namespace Inn_TuneProject.Models
{
    public class Reports
    {
        //public int RID { get; set; }
        string constr = "Server=sict-sql.mandela.ac.za;Database=GRP15-INN-TUNEDB;User ID=GRP15;Password=grp15-soit2022;Trusted_Connection=False";
        public DataTable GetDepartments()
        {
            var dt = new DataTable();
            using(SqlConnection con= new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("SPGetDepartments", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.Fill(dt);
                con.Close();
            }
            return dt;
        }

    }
}