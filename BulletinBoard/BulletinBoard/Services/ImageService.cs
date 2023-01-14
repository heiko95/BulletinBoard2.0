using BulletinBoard.Data;
using BulletinBoard.Services.Contracts;
using System.Net;

namespace BulletinBoard.Services
{
    public class ImageService : IImageService
    {
        #region Public Methods

        public IList<ImageElement> GetPictures()
        {
            return DefaultData();
        }

        #endregion Public Methods

        #region Private Methods

        private IList<ImageElement> DefaultData()
        {
            var images = new List<ImageElement>();
            using (WebClient webClient = new WebClient())
            {
                var image = Convert.ToBase64String(webClient.DownloadData(@"https://www.w3schools.com/howto/img_mountains_wide.jpg"));
                images.Add(new ImageElement()
                {
                    Base64Image = string.Format("data:image/jpg;base64,{0}", image)
                });
            }
            return images;
        }

        #endregion Private Methods
    }
}