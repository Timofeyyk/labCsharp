using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10.Views
{
    public interface IVideoView
    {
        String VideoName { get; set; }
        int VideoId { get; set; }
        string VideoUrl {  get; set; }
        string VideoDes {  get; set; }
        void DisplayVideos(DataTable videos);
        event EventHandler AddVideo;
        event EventHandler UpdateVideo;
        event EventHandler ViewVideos;
        event EventHandler DeleteVideo;
    }
}
