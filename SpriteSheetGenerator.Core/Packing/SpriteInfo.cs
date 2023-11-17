﻿using Mapper;
using System.Drawing.Imaging;

namespace SpriteSheetGenerator.Packing
{
    internal class SpriteInfo : IImageInfo
    {
        internal int id;
        internal RotateFlipType flipType;
        internal Bitmap bitmap;

        public int Width => bitmap.Width;

        public int Height => bitmap.Height;

        /// <summary>
        /// Keeps the original reference to <paramref name="bitmap"/>.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="id">Group identifier</param>
        /// <param name="flipType">The <see cref="RotateFlipType"/> the bitmap was altered with.</param>
        public SpriteInfo(Bitmap bitmap, int id, RotateFlipType flipType = RotateFlipType.RotateNoneFlipNone)
        {            
            this.bitmap = bitmap;
            this.id = id;
        }

        /// <summary>
        /// Clones the <paramref name="image"/> as a <see cref="Bitmap"/>.
        /// </summary>
        /// <param name="image">Image to clone.</param>
        /// <param name="id">Group identifier</param>
        /// <param name="flipType">The <see cref="RotateFlipType"/> the bitmap was altered with.</param>
        public SpriteInfo(Image image, int id, RotateFlipType flipType = RotateFlipType.RotateNoneFlipNone) : this(new Bitmap(image), id, flipType)
        {
        }
    }
}
