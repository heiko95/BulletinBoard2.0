using hgSoftware.DomainServices.IncomingPorts;
using hgSoftware.DomainServices.Models;
using System.Net;

namespace hgSoftware.DomainServices.Services
{
    public class WelcomeService : IWelcomeService
    {
        #region Public Methods

        public ImageElement GetWelcomePicture()
        {
            return DefaultData();
        }

        #endregion Public Methods

        #region Private Methods

        private ImageElement DefaultData()
        {
            using (WebClient webClient = new WebClient())
            {
                var image = Convert.ToBase64String(webClient.DownloadData(@"http://andacht.nak-bk.de/ThumbnailGemeinde.jpg"));
                return new ImageElement()
                {
                    Base64Image = string.Format("data:image/jpg;base64,{0}", image)
                };
            }
        }

        #endregion Private Methods
    }
}