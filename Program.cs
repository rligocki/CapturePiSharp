using System;
using OpenCvSharp;

namespace CapturePiSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var capture = new VideoCapture(0);

            capture.FrameHeight = 1080;
            capture.FrameWidth = 1920;
            capture.Roll = 180;

            using (var window = new Window("capture"))
            {
                // Frame image buffer
                var image = new Mat();

                // When the movie playback reaches end, Mat.data becomes NULL.
                while (true)
                {
                    capture.Read(image); // same as cvQueryFrame
                    if (image.Empty())
                        break;

                    window.ShowImage(image);
                    Cv2.WaitKey(250);
                }
            }
        }
    }
}
