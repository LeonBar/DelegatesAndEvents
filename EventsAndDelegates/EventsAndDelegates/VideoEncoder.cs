using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }

    class VideoEncoder
    {
        // 1 - Define a delegate
        // 2 - Define an evant based on that delkegate
        // 3 - Raise the event

        //1
        //public delegate void VideoEncodedEventHandler(object source, EventArgs args);
        //2
        //public event VideoEncodedEventHandler VideoEncoded;

        //EventHandler
        //EventHandler<TEventArgs> // with additional data

        //New way to create event
        public event EventHandler<VideoEventArgs> VideoEncoded;



        internal void Encode(Video video)
        {
            Console.WriteLine("Encoding Video...");
            Thread.Sleep(3000);

            OnVideoEncoded(video);
        }

        //3
        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs { Video = video });
        }
    }
}
