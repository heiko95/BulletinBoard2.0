﻿using hgSoftware.DomainServices.OutgoingPorts;
using hgSoftware.Infrastructure.Models;

namespace hgSoftware.Infrastructure.FileReaders
{
    public class WelcomeImageReader : IWelcomeImageReader
    {
        #region Private Fields

        private readonly Context _context;

        #endregion Private Fields

        #region Public Constructors

        public WelcomeImageReader(Context context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Methods

        public void ReadImage(string filePath)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException(filePath);

            var imageArray = File.ReadAllBytes(filePath);
            var image = Convert.ToBase64String(imageArray);
            var base64Image = string.Format("data:image/jpg;base64,{0}", image);
            _context.WelcomeImage = new Image(base64Image, DateOnly.FromDateTime(File.GetCreationTime(filePath)), filePath);
        }

        #endregion Public Methods
    }
}