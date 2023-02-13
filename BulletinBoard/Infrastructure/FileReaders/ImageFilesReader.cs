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
                                                let imageName = Path.GetFileNameWithoutExtension(file)
                                                where Regex.IsMatch(imageName, @"^\d{4}_(0[1-9]|1[0-2])_(0[1-9]|1[0-9]|2[0-9]|3[0-1])_.+$")
                                                let name = imageName.Split('-').First()
                                                let imageArray = File.ReadAllBytes(file)
                                                let image = Convert.ToBase64String(imageArray)
                                                let base64Image = string.Format("data:image/jpg;base64,{0}", image)
                                                select (name, base64Image))
            {
                var nameArray = name.Split('_');
                _context.Images.Add(new Image(base64Image, new DateOnly(int.Parse(nameArray[0]), int.Parse(nameArray[1]), int.Parse(nameArray[2])), nameArray.Last()));
            }
        }

        #endregion Public Methods
    }
}