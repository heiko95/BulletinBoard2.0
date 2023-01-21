using hgSoftware.DomainServices.OutgoingPorts;
using hgSoftware.Infrastructure.Models;

namespace hgSoftware.Infrastructure.FileReaders
{
    public class ImageFilesReader : IImageFilesReader
    {
        #region Private Fields

        private readonly Context _context;

        #endregion Private Fields

        #region Public Constructors

        public ImageFilesReader(Context context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Methods

        public void ReadImages(string folderpath)
        {
            if (!Directory.Exists(folderpath)) throw new DirectoryNotFoundException(folderpath);

            _context.Images.Clear();

            foreach (var (file, base64Image) in from file in Directory.GetFiles(folderpath, "*.jpg")
                                                let imageArray = File.ReadAllBytes(file)
                                                let image = Convert.ToBase64String(imageArray)
                                                let base64Image = string.Format("data:image/jpg;base64,{0}", image)
                                                select (file, base64Image))
            {
                _context.Images.Add(new Image(base64Image, file));
            }
        }

        #endregion Public Methods
    }
}