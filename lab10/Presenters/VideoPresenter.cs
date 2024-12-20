using lab10.Models;
using lab10.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10.Presenters
{
    class VideoPresenter
    {
        private readonly IVideoView view;
        private readonly VideoModel model;

        public VideoPresenter(IVideoView view, VideoModel model)
        {
            this.view = view;
            this.model = model;

            view.AddVideo += OnAddVideo;
            view.UpdateVideo += OnUpdateVideo;
            view.DeleteVideo += OnDeleteVideo;
            view.ViewVideos += OnViewVideo;
        }
        private void OnAddVideo(object sender, EventArgs e)
        {
            model.AddVideo(view.VideoName,view.VideoDes,view.VideoUrl);
            OnViewVideo(sender, e);
        }
        private void OnUpdateVideo(object sender, EventArgs e)
        {
            model.UpdateVideo(view.VideoId, view.VideoName, view.VideoDes, view.VideoUrl);
            OnViewVideo(sender, e);
        }
        private void OnViewVideo(object sender, EventArgs e)
        {
            Debug.WriteLine($"Просмотр ролей...");
            view.DisplayVideos(model.ReadVideos());
        }
        private void OnDeleteVideo(object sender, EventArgs e)
        {
            model.DeleteVideo(view.VideoId);
            OnViewVideo(sender, e);
        }
    }
}
