using CHSFaceAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Windows.Media.Imaging;

namespace CHSFaceAPI.Web.Helper
{
    /// <summary>
    /// UI helper functions
    /// </summary>
    internal static class ImageHelper
    {
        #region Methods

        /// <summary>
        /// Calculate the rendering face rectangle
        /// </summary>
        /// <param name="faces">Detected face from service</param>
        /// <param name="maxSize">Image rendering size</param>
        /// <param name="imageDetails">Image width and height</param>
        /// <returns>Face structure for rendering</returns>
        public static IEnumerable<FaceModel> GetFaceImageRectangle(IEnumerable<Microsoft.ProjectOxford.Face.Contract.Face> faces, int maxSize, Tuple<int, int> imageDetails)
        {
            var imageWidth = imageDetails.Item1;
            var imageHeight = imageDetails.Item2;
            float ratio = (float)imageWidth / imageHeight;

            int uiWidth = 0;
            int uiHeight = 0;

            uiWidth = maxSize;
            uiHeight = (int)(maxSize / ratio);

            float scale = (float)uiWidth / imageWidth;

            foreach (var face in faces)
            {
                yield return new FaceModel()
                {
                    FaceId = face.FaceId.ToString(),
                    Left = (int)(face.FaceRectangle.Left * scale),
                    Top = (int)(face.FaceRectangle.Top * scale),
                    Height = (int)(face.FaceRectangle.Height * scale),
                    Width = (int)(face.FaceRectangle.Width * scale),
                };
            }
        }

        /// <summary>
        /// Get image basic information for further rendering usage
        /// </summary>
        /// <param name="imageFilePath">Path to the image file</param>
        /// <returns>Image width and height</returns>
        public static Tuple<int, int> GetImageDetails(string imageFilePath)
        {
            try
            {
                using (var s = File.OpenRead(imageFilePath))
                {
                    JpegBitmapDecoder decoder = new JpegBitmapDecoder(s, BitmapCreateOptions.None, BitmapCacheOption.None);
                    var frame = decoder.Frames.First();

                    // Store image width and height for following rendering
                    return new Tuple<int, int>(frame.PixelWidth, frame.PixelHeight);
                }
            }
            catch
            {
                return new Tuple<int, int>(0, 0);
            }
        }
        #endregion Methods
    }
}