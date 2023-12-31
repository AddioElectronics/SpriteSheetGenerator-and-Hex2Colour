﻿using Mapper;
using SpriteSheetGenerator.Packing;
using Image = System.Drawing.Image;

namespace SpriteSheetGenerator
{
    /// <summary>
    /// Static class with functions for rotating, mirroring, and packing bitmaps.
    /// </summary>
    public static class SpriteSheetGenerator
    {

        #region Fields

        /// <summary>
        /// Pixel formats that are valid to use with the CreateSheet functions.
        /// </summary>
        public static readonly PixelFormat[] validPixelFormats = new PixelFormat[]
        {
            PixelFormat.Format16bppRgb555,
            PixelFormat.Format16bppRgb565,
            PixelFormat.Format24bppRgb,
            PixelFormat.Format32bppArgb,
            PixelFormat.Format32bppPArgb,
            PixelFormat.Format48bppRgb,
            PixelFormat.Format64bppArgb,
            PixelFormat.Format64bppPArgb,
        };

        #endregion


        #region Methods

        #region Public

        /// <summary>
        /// Is the <see cref="PixelFormat"/> valid for use with the CreateSheet functions.
        /// </summary>
        /// <returns>If <paramref name="format"/> is valid for use with the CreateSheet functions.</returns>
        public static bool IsValidFormat(PixelFormat format)
        {
            return validPixelFormats.Contains(format);
        }

        /// <summary>
        /// Rotates the <paramref name="bitmaps"/> by <paramref name="flipType"/>, and returns a new array with the rotated bitmaps.
        /// </summary>
        /// <param name="bitmaps">Bitmaps to rotate</param>
        /// <param name="flipType">Type of rotation or mirroring.</param>
        /// <param name="format"><see cref="PixelFormat"/> of the generated bitmaps.</param>
        /// <returns>Array containing the processed bitmaps.</returns>
        public static Bitmap[] RotateFlipBitmaps(Bitmap[] bitmaps, RotateFlipType flipType, PixelFormat format)
        {
            return bitmaps.Select(x => RotateFlipBitmap(x, flipType, format)).ToArray();
        }

        /// <summary>
        /// Clones using the pixel <paramref name="format"/> and rotates the <paramref name="bitmap"/> by the <paramref name="flipType"/>.
        /// </summary>
        /// <param name="bitmap">Bitmap to rotate</param>
        /// <param name="flipType">Type of rotation or mirroring.</param>
        /// <param name="format"><see cref="PixelFormat"/> of the generated bitmap.</param>
        /// <returns>The processed bitmap.</returns>
        public static Bitmap RotateFlipBitmap(Bitmap bitmap, RotateFlipType flipType, PixelFormat format)
        {
            //Duplicate bitmap with the selected pixel format
            Rectangle rect = new Rectangle(Point.Empty, bitmap.Size);
            Bitmap rotate = bitmap.Clone(rect, format);

            //Rotate
            rotate.RotateFlip(flipType);
            return rotate;
        }

        /// <summary>
        /// Applies all the <paramref name="flipTypes"/> to <paramref name="bitmap"/> and returns the new bitmaps.
        /// </summary>
        /// <param name="bitmap">Bitmap</param>
        /// <param name="format">Pixel format</param>
        /// <param name="flipTypes">Rotations and flips to apply.</param>
        /// <returns>An array containing the new variants.</returns>
        public static Image[] GenerateBitmapVariations(Bitmap bitmap, PixelFormat format, params RotateFlipType[] flipTypes)
        {
            Bitmap[] variants = new Bitmap[flipTypes.Length];

            for(int i = 0; i < flipTypes.Length; i++)
            {
                variants[i] = RotateFlipBitmap(bitmap, flipTypes[i], format);
            }

            return variants;
        }

        /// <inheritdoc cref="GenerateBitmapVariations(Bitmap, PixelFormat, RotateFlipType[])"/>
        public static Image[] GenerateBitmapVariations(Image image, PixelFormat format, params RotateFlipType[] flipTypes)
        {
            return GenerateBitmapVariations(new Bitmap(image), format, flipTypes);
        }

        /// <summary>
        /// Combines all the pregrouped <paramref name="images"/> into a single sprite sheet.
        /// </summary>
        /// <remarks>
        /// Each bitmap, along with any generated variation, are mapped to its own column(or row), in the order of the array.
        /// This function is recommended if every sprite is the same size.
        /// If you are combining bitmaps of various sizes, use <see cref="CreateSheetPacked"/> instead.
        /// </remarks>
        /// <param name="images">Pregrouped images to combine into a sprite sheet.</param>
        /// <param name="alignVertically">Align image groups vertically.</param>
        /// <param name="equalSpacing">Always space image variations equally.</param>
        /// <param name="pixelFormat">
        /// <see cref="PixelFormat"/> of the sprite sheet. 
        /// Note: Must be a <see cref="PixelFormat"/> from <see cref="validPixelFormats"/>.
        /// </param>
        /// <returns>The sprite sheet image.</returns>
        public static Image CreateSheet(List<Image>[] images, bool alignVertically, bool equalSpacing, PixelFormat pixelFormat)
        {
            var sprites = images.SelectMany(x => x).ToArray();

            //Calculate columns, rows and size
            int rows = images.Length;
            int columns = sprites.Length / rows;

            //Get size of each sprite group and calculate size of sprite sheet
            List<GroupSize> setSizes = images.Select(x => GetBitmapSetSize(x)).ToList();
            Size size = CalculateSheetSize(setSizes.ToArray(), alignVertically);

            //Create the sheet bitmap
            Bitmap sheet = new Bitmap(size.Width, size.Height, pixelFormat);

            //Copy all the bitmaps onto the sheet
            using (Graphics g = Graphics.FromImage(sheet))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.AssumeLinear;

                Point point = Point.Empty;  //Bitmap placement point

                if (alignVertically)
                {
                    for (int groupId = 0; groupId < images.Length; groupId++)
                    {
                        List<Image> group = images[groupId];

                        foreach (Image bm in group)
                        {
                            g.DrawImage(bm, point);
                            point.Y += equalSpacing ?
                              setSizes[groupId].maxSize.Height :
                              bm.Height;
                        }

                        point.X += setSizes[groupId].maxSize.Width;
                        point.Y = 0;
                    }
                }
                else
                {
                    for (int groupId = 0; groupId < images.Length; groupId++)
                    {
                        List<Image> group = images[groupId];

                        foreach (Image bm in group)
                        {
                            g.DrawImage(bm, point);
                            point.X += equalSpacing ?
                                setSizes[groupId].maxSize.Width :
                                bm.Width;
                        }

                        point.X = 0;
                        point.Y += setSizes[groupId].maxSize.Height;
                    }
                }



                //Apply the graphics
                g.Save();
            }

            return sheet;
        }

        /// <summary>
        /// Processes and combines all <paramref name="images"/>, into a single sprite sheet.
        /// </summary>
        /// <remarks>
        /// Each bitmap, along with any generated variation, are mapped to its own column(or row), in the order of the array.
        /// This function is recommended if every sprite is the same size.
        /// If you are combining bitmaps of various sizes, use <see cref="CreateSheetPacked"/> instead.
        /// </remarks>
        /// <param name="images">Images</param>
        /// <param name="alignVertically">Align image groups vertically.</param>
        /// <param name="equalSpacing">Always space image variations equally.</param>
        /// <param name="pixelFormat">
        /// <see cref="PixelFormat"/> of the sprite sheet. 
        /// Note: Must be a <see cref="PixelFormat"/> from <see cref="validPixelFormats"/>.
        /// </param>
        /// <param name="rotateFlipTypes">Types of rotations and mirroring to apply to <paramref name="images"/>.</param>
        /// <returns>The sprite sheet image.</returns>
        public static Image CreateSheet(Image[] images, bool alignVertically, bool equalSpacing, PixelFormat pixelFormat, params RotateFlipType[]? rotateFlipTypes)
        {
            //Assert that the pixel format is valid.
            if (!validPixelFormats.Contains(pixelFormat))
            {
                throw new FormatException("Invalid pixel format. Can only use formats listed in validPixelFormats.");
            }

            //Generate variants and group them in separate lists.
            List<Image>[] spriteGroups = BeginSheet(images, pixelFormat, rotateFlipTypes, out Image[] sprites);

            Image sheet = CreateSheet(spriteGroups, alignVertically, equalSpacing, pixelFormat);
            DisposeGeneratedImages(images, sprites);
            return sheet;
        }

        /// <summary>
        /// Processes, and packs, all the <paramref name="images"/> into a single sprite sheet.
        /// </summary>
        /// <returns>The sprite sheet image.</returns>
        /// <param name="images">Images</param>
        /// <param name="pixelFormat">
        /// <see cref="PixelFormat"/> of the sprite sheet. 
        /// Note: Must be a <see cref="PixelFormat"/> from <see cref="validPixelFormats"/>.
        /// </param>
        /// <param name="rotateFlipTypes">Optional types of rotations and mirroring to apply to <paramref name="images"/>.</param>
        /// <exception cref="ArgumentException">
        /// Will throw when too many packer runs out of room. 
        /// This is from the external library "RectanglePacker" and currently have no plans to fork.
        /// </exception>
        public static Image CreateSheetPacked(Image[] images, PixelFormat pixelFormat, params RotateFlipType[]? rotateFlipTypes)
        {
            //Assert that the pixel format is valid.
            if (!validPixelFormats.Contains(pixelFormat))
            {
                throw new FormatException("Invalid pixel format. Can only use formats listed in validPixelFormats.");
            }

            //Generate variants
            BeginSheet(images, pixelFormat, rotateFlipTypes, out Image[] sprites);

            //Convert to IImageInfo for packer
            IEnumerable<IImageInfo> bmpInfos = sprites.Select(x => new SpriteInfo(x));

            //Initialize the packer
            Canvas canvas = new Canvas();
            MapperOptimalEfficiency<SpriteSheetMap> packer = new MapperOptimalEfficiency<SpriteSheetMap>(canvas);

            //Pack some fudge
            SpriteSheetMap spriteMap = packer.Mapping(bmpInfos);

            //Create the sheet bitmap
            Bitmap sheet = new Bitmap(spriteMap.Width, spriteMap.Height, pixelFormat);

            //Copy all the bitmaps onto the sheet
            using (Graphics g = Graphics.FromImage(sheet))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.AssumeLinear;


                foreach (MappedImageInfo mii in spriteMap.MappedImages)
                {
                    SpriteInfo binfo = (SpriteInfo)mii.ImageInfo;
                    g.DrawImage(binfo.bitmap, new Point(mii.X, mii.Y));
                }

                //Apply the graphics
                g.Save();
            }

            DisposeGeneratedImages(images, sprites);

            return sheet;
        }

        #endregion

        #region Private

        /// <summary>
        /// Adds the <paramref name="originalSprites"/> to their separate group list.
        /// </summary>
        /// <param name="originalSprites">The unprocessed images.</param>
        /// <returns>List containing each group list.</returns>
        static List<Image>[] InitializeSpriteGroupLists(Image[] originalSprites)
        {
            return originalSprites.Select(x => new List<Image>() { x }).ToArray();
        }

        /// <summary>
        /// Generates all <paramref name="rotateFlipTypes"/> variants of the <paramref name="originalSprites"/>, and groups them into separate lists.  
        /// </summary>
        /// <param name="originalSprites">Sprites to create variations of.</param>
        /// <param name="rotateFlipTypes">Types of variations to generate.</param>
        /// <param name="sprites">List containing all sprites.</param>
        /// <returns>A list of all <paramref name="originalSprites"/> and generated sprites, separated in group lists.</returns>
        static List<Image>[] BeginSheet(Image[] originalSprites, PixelFormat pixelFormat, RotateFlipType[]? rotateFlipTypes, out Image[] sprites)
        {
            //Setup the sprites dictionary
            List<Image>[]  groupedSprites = InitializeSpriteGroupLists(originalSprites);

            //Process the bitmaps
            if (rotateFlipTypes != null && rotateFlipTypes.Length > 0)
                GenerateBitmapVariations(groupedSprites, pixelFormat, rotateFlipTypes);

            //Combine all bitmaps from sprites into a single array.
            sprites = groupedSprites.SelectMany(x => x).ToArray();
            return groupedSprites;
        }

        /// <summary>
        /// Gets the max width, and the sum of all the <paramref name="bitmaps"/>'s heights.
        /// </summary>
        /// <param name="bitmaps">List of bitmaps that make up a column in the sprite sheet.</param>
        /// <returns>Size containing the largest bitmap width, and the sum of all the <paramref name="bitmaps"/> heights.</returns>
        static GroupSize GetBitmapSetSize(List<Image> bitmaps)
        {
            int width = 0;      //Total width
            int height = 0;     //Total height
            int maxWidth = 0;   //Bitmap max width
            int maxHeight = 0;  //Bitmap max height
            int minWidth = 0;   //Bitmap min width
            int minHeight = 0;  //Bitmap min height

            foreach (var bm in bitmaps)
            {
                if (bm.Width > width)
                    maxWidth = bm.Width;

                if (bm.Height > height)
                    maxHeight = bm.Height;

                if (bm.Width < minWidth)
                    minWidth = bm.Width;

                if (bm.Height < minHeight)
                    minHeight = bm.Height;

                width += bm.Width;
                height += bm.Height;
            }

            return new GroupSize(width, height, minWidth, minHeight, maxWidth, maxHeight);
        }

        /// <summary>
        /// Calculates the final size of the sprite sheet using precalculated <paramref name="groupSize"/>s.
        /// </summary>
        /// <param name="groupSize">Array of each sprite group's precalculated <see cref="GroupSize"/>.</param>
        /// <param name="alignVertically">If the groups are being aligned vertically.</param>
        /// <returns>The final size of sprite sheet.</returns>
        static Size CalculateSheetSize(GroupSize[] groupSize, bool alignVertically)
        {
            int minWidth = 0;         //Veritcally aligned Sheet width
            int minHeight = 0;        //Horizontally aligned Sheet height
            int maxWidth = 0;         //Horizontally aligned Sheet width
            int maxHeight = 0;        //Veritcally aligned Sheet height

            foreach (var setSize in groupSize)
            {
                minWidth += setSize.maxSize.Width;
                minHeight += setSize.maxSize.Height;

                if (maxWidth < setSize.sum.Width)
                    maxWidth = setSize.sum.Width;

                if (maxHeight < setSize.sum.Height)
                    maxHeight = setSize.sum.Height;
            }

            return alignVertically ?
                new Size(minWidth, maxHeight) :
                new Size(maxWidth, minHeight);
        }


        /// <summary>
        /// Applies the <paramref name="rotateFlipTypes"/> to the <paramref name="originalSprites"/> and places them in <see cref="groupedSprites"/>.
        /// </summary>
        /// <param name="spriteGroups">
        /// List containing the group lists for the generated bitmaps to be added to. 
        /// Each internal list should only contain the original bitmap as the first index.
        /// </param>
        /// <param name="pixelFormat"><see cref="PixelFormat"/> of the generated bitmaps.</param>
        /// <param name="rotateFlipTypes">Types of rotations and mirrors to apply.</param>
        static void GenerateBitmapVariations(List<Image>[] spriteGroups, PixelFormat pixelFormat, RotateFlipType[] rotateFlipTypes)
        {
            for (int i = 0; i < spriteGroups.Length; i++)
            {
                //First index of the internal list contains the original bitmap
                var bitmaps = GenerateBitmapVariations(spriteGroups[i][0], pixelFormat, rotateFlipTypes);
                spriteGroups[i].AddRange(bitmaps);
            }
        }

        /// <summary>
        /// Dispose all generated images.
        /// </summary>
        /// <param name="originals">Original images, used check if image should be disposed.</param>
        /// <param name="sprites">Original and generated images.</param>
        static void DisposeGeneratedImages(Image[] originals, Image[] sprites)
        {
            int originalsSeen = 0;
            foreach(var image in sprites)
            {
                //Only check if there are still originals left.
                if (originalsSeen < originals.Length && originals.Contains(image))
                {
                    originalsSeen++;
                    continue;
                }

                image.Dispose();
            }
        }

        #endregion

        #endregion
    }
}
