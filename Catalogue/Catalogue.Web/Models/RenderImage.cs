using Catalogue.Models.Entities;
using Omu.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace Catalogue.Web.Models
{
    public class RenderImage
    {
        private const int ImgMaxWidth = 125;
        private const int ImgMaxHeight = 125;

        public void RenderFile(Image fileImage, HttpPostedFileBase file)
        {
            fileImage.ImageName = file.FileName;
            fileImage.Value = ConverToBytes(file);
        }

        public Image ResizeFile(Image file)
        {
            MemoryStream ms = new MemoryStream(file.Value);

            var source = Imager.Resize(System.Drawing.Image.FromStream(ms), ImgMaxWidth, ImgMaxHeight, false);

            MemoryStream fileResize = new MemoryStream();
            source.Save(fileResize, ImageFormat.Png);

            Image resizedFile = new Image()
            {
                ImageName = file.ImageName,
                Value = fileResize.ToArray()
            };

            return resizedFile;
        }

        private byte[] ConverToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            using (System.IO.BinaryReader reader = new System.IO.BinaryReader(image.InputStream))
            {
                imageBytes = reader.ReadBytes((int)image.ContentLength);
                return imageBytes;
            }
        }
    }
}