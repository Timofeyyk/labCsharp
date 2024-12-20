using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab10.Models
{
    class VideoModel
    {
        private string connectionString = "";
        public void AddVideo(string VideoName, string VideoDes, string VideoUrl)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO videos (VideoName,VideoDes,VideoUrl) VALUES (@VideoName,@VideoDes,@VideoUrl)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@VideoName", VideoName);
                cmd.Parameters.AddWithValue("@VideoDes", VideoDes);
                cmd.Parameters.AddWithValue("@VideoUrl", VideoUrl);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ReadVideos()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM videos";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
        public void DeleteVideo(int VideoId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM videos WHERE VideoId = @VideoId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@VideoId", VideoId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateVideo(int VideoId, string VideoName, string VideoDes, string VideoUrl)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE videos SET VideoName = @VideoName, VideoUrl=@VideoUrl,VideoDes=@VideoDes WHERE VideoId = @VideoId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@VideoId", VideoId);
                cmd.Parameters.AddWithValue("@VideoName", VideoName);
                cmd.Parameters.AddWithValue("@VideoDes", VideoDes);
                cmd.Parameters.AddWithValue("@VideoUrl", VideoUrl);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
