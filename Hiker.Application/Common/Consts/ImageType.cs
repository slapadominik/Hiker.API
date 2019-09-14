namespace Hiker.Application.Common.Consts
{
    public sealed class ImageType
    {
        public string Value { get; }

        private ImageType(string value)
        {
            Value = value;
        }

        public static ImageType Jpeg => new ImageType("jpg");

        public static ImageType Png => new ImageType("png");
    }
}