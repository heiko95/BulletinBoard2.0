using hgSoftware.DomainServices.IncomingPorts;
using hgSoftware.DomainServices.Models;
using System.Net;

namespace hgSoftware.DomainServices.Services
{
    public class ImageService : IImageService
    {
        #region Private Fields

        private readonly string? _imageFolder;

        #endregion Private Fields

        #region Public Constructors

        public ImageService()
        {
            //_imageFolder = namedOptionsAccessor.Get(ElementSettings.ImageScreenSettings).FolderName;
            //var t = AppContext.BaseDirectory;
        }

        #endregion Public Constructors

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