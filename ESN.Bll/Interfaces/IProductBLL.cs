namespace ESN.Bll
{
    public interface IProductBLL
    {
        string GetTest();
        bool SaveByteArrayAsImage(string fullOutputPath, string base64String);
        bool SaveByteArrayAsVideo(string fullOutputPath, byte[] base64String);
    }
}
