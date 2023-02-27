using Multitracks.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Xml.Linq;

namespace Multitracks.Repository
{
    public interface IArtistRepository
    {
        Task<Artist> GetArtistByName(int id);
        Task<bool> AddArtist(Artist artist);
    }
    public static class ArtistRepository
    {

        public static async Task<Artist> GetArtistByName(string name)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["admin"].ConnectionString;
            Artist artist = new Artist();
            using (SqlConnection sqlConnectionm = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Artist WHERE title = '" + name + "'";
                sqlConnectionm.Open();
                //testConnectiontext.Text = "Connection Open Successfully";
                SqlDataAdapter da = new SqlDataAdapter(sql, sqlConnectionm);                
                DataTable dt = new DataTable();
                da.Fill(dt);
                sqlConnectionm.Close();


                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    DataRow dr = dt.Rows[i];

                    artist.ArtistID = int.Parse(dr["artistID"].ToString());
                    artist.Title = dr["title"].ToString();
                    artist.DateCreation = Convert.ToDateTime(dr["dateCreation"].ToString());
                    artist.Biography = dr["biography"].ToString();
                    artist.ImageUrl = dr["imageURL"].ToString();
                    artist.HeroUrl = dr["heroURL"].ToString();

                }
               
            }
            return artist;
        }

        public static int GetLastAssetNo()
        {
            int lastNo = 0;
            var connectionString = WebConfigurationManager.ConnectionStrings["admin"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            string sqlscript = "SELECT MAX(artistID) as LastNo FROM Artist";
            con.Open();
            SqlCommand cmd = new SqlCommand(sqlscript, con);
            SqlDataReader sqlReader = cmd.ExecuteReader();
            while (sqlReader.Read())
            {
                string code = sqlReader.GetValue(0).ToString();
                lastNo = int.Parse(code);
            }
            return lastNo;
        }
        public static async Task<bool> AddArtist(Artist artist)
        {
            var connectionString = WebConfigurationManager.ConnectionStrings["admin"].ConnectionString;

            //int lastno = GetLastAssetNo();
            //lastno++;

            using(SqlConnection sqlConnectionm = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Artist (dateCreation, title, biography,imageURL,heroURL) VALUES ('" + artist.DateCreation + "','" + artist.Title + "','" + artist.Biography + "','" + artist.ImageUrl + "','" + artist.HeroUrl + "')";
                sqlConnectionm.Open();

                SqlCommand cmd = new SqlCommand(sql, sqlConnectionm);

                //cmd.Parameters.Add("artistID", SqlDbType.Int).Value = lastno;
                cmd.Parameters.Add("dateCreation", SqlDbType.SmallDateTime).Value = artist.DateCreation;
                cmd.Parameters.Add("title", SqlDbType.NVarChar).Value = artist.Title;
                cmd.Parameters.Add("biography", SqlDbType.NVarChar).Value = artist.Biography;
                cmd.Parameters.Add("imageURL", SqlDbType.NVarChar).Value = artist.ImageUrl;
                cmd.Parameters.Add("heroURL", SqlDbType.NVarChar).Value = artist.HeroUrl;

                await cmd.ExecuteNonQueryAsync();
                sqlConnectionm.Close();
                return true;
            }
        }
    }
}