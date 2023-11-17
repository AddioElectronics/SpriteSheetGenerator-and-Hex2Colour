using Mapper;

namespace SpriteSheetGenerator.Packing
{
    internal class SpriteSheetMap : ISprite
    {
        int width = 0;
        int height = 0;

        readonly List<IMappedImageInfo> mappedImages = new List<IMappedImageInfo>();

        public int Width => width;

        public int Height => height;

        public int Area => Width * Height;

        public IEnumerable<IMappedImageInfo> MappedImages => mappedImages;

        public void AddMappedImage(IMappedImageInfo mappedImage)
        {
            mappedImages.Add(mappedImage);

            int imgRight = mappedImage.X + mappedImage.ImageInfo.Width;
            int imgBottom = mappedImage.Y + mappedImage.ImageInfo.Height;

            width = int.Max(width, imgRight);
            height = int.Max(height, imgBottom);
        }

    }
}
