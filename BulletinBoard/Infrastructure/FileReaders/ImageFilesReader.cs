using hgSoftware.DomainServices.OutgoingPorts;
using hgSoftware.Infrastructure.Models;
using System.Text.RegularExpressions;

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

            foreach (var (name, base64Image) in from file in Directory.GetFiles(folderpath, "*.jpg")
                                                let name = Path.GetFileNameWithoutExtension(file)
                                                where Regex.IsMatch(name, @"^\d{4}_(0[1-9]|1[0-2])_(0[1-9]|1[0-9]|2[0-9]|3[0-1])_.+$")
                                                let imageArray = File.ReadAllBytes(file)
                                                let image = Convert.ToBase64String(imageArray)
                                                let base64Image = string.Format("data:image/jpg;base64,{0}", image)
                                                select (file, base64Image))
            {
                _context.Images.Add(new Image(base64Image, name));
            }
        }

        #endregion Public Methods
    }
}