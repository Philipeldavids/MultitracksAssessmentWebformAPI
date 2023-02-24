using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class artistDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var connectionString = WebConfigurationManager.ConnectionStrings["admin"].ConnectionString;

        using (SqlConnection sqlConnectionm = new SqlConnection(connectionString))
        {
            sqlConnectionm.Open();
            //testConnectiontext.Text = "Connection Open Successfully";
            SqlDataAdapter da = new SqlDataAdapter("spGetArtistDetails", sqlConnectionm);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            sqlConnectionm.Close();
                       

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                DataRow dr = dt.Rows[i];

                biography.Text = dr[3].ToString();
                Image1.ImageUrl = dr[5].ToString();
                Image2.ImageUrl = dr[4].ToString();
                Image3.ImageUrl = dr[4].ToString();
                SongTitle1.Text = dr[2].ToString();
                SongTitle2.Text = dr[2].ToString();
                SongTitle3.Text = dr[2].ToString();
                Image4.ImageUrl = dr[4].ToString();
                Image5.ImageUrl = dr[4].ToString();
                Image6.ImageUrl = dr[4].ToString();
                SongTitle4.Text = dr[2].ToString();
                SongTitle5.Text = dr[2].ToString();
                SongTitle6.Text = dr[2].ToString();
            }
        }
    }
}