using System;
using System.IO;
using System.Drawing;

namespace ESN.Bll
{
    public class ProductBLL: IProductBLL
    {
        public string GetTest()
        {
            return "hello";
        }
        public bool SaveByteArrayAsImage(string fullOutputPath, string base64String)
        {
            byte[] bytes = Convert.FromBase64String(base64String);

            Image image;
            //using (MemoryStream ms = new MemoryStream(bytes))
            //{
            //    image = Image.FromStream(ms);
            //}

            //image.Save(fullOutputPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            //image.Dispose();
            //return true;
            using (var streamBitmap = new MemoryStream(bytes))
            {
                using (image = Image.FromStream(streamBitmap))
                {
                    image.Save(fullOutputPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            return true;
        }

        public bool SaveByteArrayAsVideo(string fullOutputPath, byte[] base64String)
        {
            //byte[] ret = Convert.FromBase64String(base64String);
            //FileInfo fil = new FileInfo(fullOutputPath);

            //using (Stream sw = fil.OpenWrite())
            //{
            //    sw.Write(ret, 0, ret.Length);
            //    sw.Close();
            //}
            File.WriteAllBytes(fullOutputPath, base64String);
            return true;
        }
    }
}
