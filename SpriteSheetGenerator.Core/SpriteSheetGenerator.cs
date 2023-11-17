using Mapper;
using SpriteSheetGenerator.Packing;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using Image = System.Drawing.Image;

namespace SpriteSheetGenerator
{
    /// <summary>
    /// Takes 1 or more bitmaps and applies optional rotations before combining them into a single sprite sheet.
    /// </summary>
    public class SpriteSheetGenerator
    {

        #region Properties

        /// <summary>
        /// Output pixel format.
        /// </summary>
        /// <remarks>Can only use formats listed in <see cref="validPixelFormats"/>. (Non indexed 16-64bpp P/A/RGB)</remarks>
        public PixelFormat PixelFormat
        {
            get => _pixelFormat;
            set
            {
                if (!validPixelFormats.Contains(value))
                {
                    throw new FormatException("Invalid pixel format. Can only use formats listed in validPixelFormats.");
                }
            }
        }

        /// <summary>
        /// Top row contains all original images, with all variations vertically aligned beneath.
        /// </summary>
        public bool AlignVertically { get; set; }

        /// <summary>
        /// If bitmaps are not equal width and height, 
        /// always space the variations equally on the set.
        /// </summary>
        public bool EqualSpacing { get; set; }

        /// <summary>
        /// Type types of rotations to generate
        /// </summary>
        public RotateFlipType[]? RotationsToGenerate { get; set; }

        #endregion

        #region Fields

        PixelFormat _pixelFormat = PixelFormat.Format32bppArgb;

        /// <summary>
        /// Pixel formats that are valid to use.
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

        /// <summary>
        /// List of the original bitmaps.
        /// </summary>
        SpriteInfo[] origBitmaps;

        /// <summary>
        /// Dictionary containing all the bitmaps for the sheet.
        /// Each key is a column, each value is a row.
        /// </summary>
        readonly Dictionary<RotateFlipType, List<SpriteInfo>> flipTypeSprites = new Dictionary<RotateFlipType, List<SpriteInfo>>();

        /// <summary>
        /// Dictionary containing all the bitmaps for the sheet.
        /// The key is a group ID (currently the index from the original bitmaps).
        /// </summary>
        readonly Dictionary<int, List<SpriteInfo>> sprites = new Dictionary<int, List<SpriteInfo>>();
        //readonly Dictionary<int, Dictionary<RotateFlipType, List<SpriteInfo>>> sprites = new Dictionary<int, Dictionary<RotateFlipType, List<SpriteInfo>>>();

        #endregion

        #region Constructors
#pragma warning disable 8618

        /// <summary>
        /// 
        /// </summary>
        /// <param name="images">Array of images</param>
        /// <param name="toGenerate">Types of rotations to generate.</param>
        public SpriteSheetGenerator(Image[] images, params RotateFlipType[]? toGenerate)
        {
            SetImages(images, toGenerate);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="images">Image list</param>
        /// <param name="toGenerate">Types of rotations to generate.</param>
        public SpriteSheetGenerator(List<Image> images, params RotateFlipType[] toGenerate) : this(images.ToArray(), toGenerate) { }

#pragma warning restore 9618
        #endregion

        #region Methods

        #region Public

        /// <summary>
        /// Set the next batch of images to create a sprite sheet from.
        /// </summary>
        /// <param name="images">Images to sheeterize</param>
        /// <param name="toGenerate">The types of rotations to generate.</param>
        public void SetImages(Image[] images, params RotateFlipType[]? toGenerate)
        {
            GenerateOriginalSpriteInfos(images);
            RotationsToGenerate = toGenerate;
        }

        /// <summary>
        /// Rotates the <paramref name="bitmaps"/> by <paramref name="flipType"/>, and returns a new array with the rotated bitmaps.
        /// </summary>
        /// <param name="bitmaps">Bitmaps to rotate</param>
        /// <param name="flipType">Type of rotation or mirroring.</param>
        /// <returns>Array containing the rotated bitmaps.</returns>
        public static Bitmap[] RotateFlipBitmaps(Bitmap[] bitmaps, RotateFlipType flipType, PixelFormat format)
        {
            int length = bitmaps.Length;
            Bitmap[] rotated = new Bitmap[length];

            for (int i = 0; i < length; i++)
            {
                Bitmap bm = bitmaps[i];

                //Duplicate bitmap with the set pixel format
                Bitmap rotate = new Bitmap(bm);

                //Rotate
                rotate.RotateFlip(flipType);
            }
            return rotated;
        }

        /// <summary>
        /// Clones using the pixel <paramref name="format"/> and rotates the <paramref name="bitmap"/> by the <paramref name="flipType"/>.
        /// </summary>
        /// <param name="bitmap">Bitmap to rotate</param>
        /// <param name="flipType">Type of rotation or mirroring.</param>
        /// <returns>The processed bitmap.</returns>
        public static Bitmap RotateFlipBitmap(Bitmap bitmap, RotateFlipType flipType, PixelFormat format)
        {
            //Duplicate bitmap with the set pixel format
            Rectangle rect = new Rectangle(Point.Empty, bitmap.Size);
            Bitmap rotate = bitmap.Clone(rect, format);

            //Rotate
            rotate.RotateFlip(flipType);
            return rotate;
        }



        /// <summary>
        /// Clones and applies the <paramref name="flipTypes"/> to <paramref name="bitmap"/>.
        /// </summary>
        /// <param name="bitmap">Bitmap</param>
        /// <param name="format">Pixel format</param>
        /// <param name="flipTypes">Rotations and flips to apply.</param>
        /// <returns>An array containing the new variants.</returns>
        public static Bitmap[]? GenerateBitmapVariations(Bitmap bitmap, PixelFormat format, params RotateFlipType[] flipTypes)
        {
            if (bitmap == null || flipTypes == null || flipTypes.Length == 0)
                return null;

            Bitmap[] variants = new Bitmap[flipTypes.Length];

            for(int i = 0; i < flipTypes.Length; i++)
            {
                variants[i] = RotateFlipBitmap(bitmap, flipTypes[i], format);
            }

            return variants;
        }

        /// <inheritdoc cref="GenerateBitmapVariations(Bitmap, PixelFormat, RotateFlipType[])"/>
        public static Bitmap[]? GenerateBitmapVariations(Image image, PixelFormat format, params RotateFlipType[] flipTypes)
        {
            return GenerateBitmapVariations(new Bitmap(image), format, flipTypes);
        }

        /// <summary>
        /// Processes and combines all the bitmaps that were previously set via <see cref="SetImages(Image[], RotateFlipType[])"/>, or the constructor, into a single sprite sheet.
        /// </summary>
        /// <remarks>
        /// Each bitmap, along with any generated variation, are mapped to its own column(or row), in the order of the array.
        /// This function is recommended if every sprite is the same size.
        /// If you are combining bitmaps of various sizes, use <see cref="CreateSheetPacked"/> instead.
        /// </remarks>
        /// <returns>The sprite sheet image.</returns>
        public Image CreateSheet()
        {
            var bitmaps = BeginSheet();

            //Calculate columns, rows and size
            int rows = origBitmaps.Length;
            int columns = bitmaps.Count / rows;

            Dictionary<int, GroupSize> setSizes = new Dictionary<int, GroupSize>();

            foreach(int groupId in sprites.Keys)
                setSizes[groupId] = GetBitmapSetSize(sprites[groupId]);

            Size size = GetSheetSize(setSizes.Values.ToArray());

            //Create the sheet bitmap
            Bitmap sheet = new Bitmap(size.Width, size.Height, PixelFormat);
            //Bitmap sheet = AlignVertically ?
            //    new Bitmap(size.maxSize.Width, size.minSize.Height, PixelFormat) :
            //    new Bitmap(size.minSize.Width, size.maxSize.Height, PixelFormat);

            //Copy all the bitmaps onto the sheet
            using (Graphics g = Graphics.FromImage(sheet))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.AssumeLinear;

                int rowBase = 0;    //The current row's 0 index                

                Point point = Point.Empty;

                if (AlignVertically)
                {
                    foreach (int groupId in sprites.Keys)
                    {
                        List<SpriteInfo> group = sprites[groupId];

                        foreach (SpriteInfo sprite in group)
                        {
                            Bitmap bm = sprite.bitmap;

                            g.DrawImage(bm, point);
                            point.Y += EqualSpacing ?
                              setSizes[groupId].maxSize.Height :
                              bm.Height;
                        }

                        point.X += setSizes[groupId].maxSize.Width;
                        point.Y = 0;
                    }                    
                }
                else
                {
                    foreach (int groupId in sprites.Keys)
                    {
                        List<SpriteInfo> group = sprites[groupId];

                        foreach (SpriteInfo sprite in group)
                        {
                            Bitmap bm = sprite.bitmap;

                            g.DrawImage(bm, point);
                            point.X += EqualSpacing ?
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
        /// Processes, and packs, all the bitmaps that were previously set via <see cref="SetImages(Image[], RotateFlipType[])"/>, or the constructor, into a single sprite sheet.
        /// </summary>
        /// <returns>The sprite sheet image.</returns>
        /// <exception cref="ArgumentException">
        /// Will throw when too many packer runs out of room. 
        /// This is from the external library "RectanglePacker" and currently have no plans to fork.
        /// </exception>
        public Image CreateSheetPacked()
        {
            var bitmaps = BeginSheet();

            //Convert to IImageInfo for packer
            IEnumerable<IImageInfo> bmpInfos = bitmaps;

            //Initialize the packer
            Canvas canvas = new Canvas();
            MapperOptimalEfficiency<SpriteSheetMap> packer = new MapperOptimalEfficiency<SpriteSheetMap>(canvas);

            //Pack some fudge
            SpriteSheetMap spriteMap = packer.Mapping(bmpInfos);

            //Create the sheet bitmap
            Bitmap sheet = new Bitmap(spriteMap.Width, spriteMap.Height, PixelFormat);

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

            return sheet;
        }

        #endregion

        #region Private

        void GenerateOriginalSpriteInfos(Image[] images)
        {
            List<SpriteInfo> spriteInfos = new List<SpriteInfo>();

            for (int i = 0; i < images.Length; i++)
            {
                SpriteInfo si = new SpriteInfo(images[i], i + sprites.Count);
                spriteInfos.Add(si);
            }

            origBitmaps = spriteInfos.ToArray();
        }

        void InitializeSpriteLists()
        {
            sprites.Clear();
            flipTypeSprites[RotateFlipType.RotateNoneFlipNone] = origBitmaps.ToList();
            foreach(SpriteInfo si in origBitmaps)
            {
                sprites.Add(si.id, new List<SpriteInfo>() { si });
            }
        }

        /// <summary>
        /// Clears <see cref="sprites"/>, calls <see cref="GenerateBitmapVariations"/> and returns all bitmaps in a list.
        /// </summary>
        /// <returns>A list of bitmap of the originals and variations .</returns>
        List<SpriteInfo> BeginSheet()
        {
            //Setup the sprites dictionary
            InitializeSpriteLists();

            //Process the bitmaps
            GenerateBitmapVariations();

            //Combine all bitmaps from sprites into a single array.
            var bitmaps = GetSprites();
            return bitmaps;
        }

        /// <summary>
        /// Gets the max width, and the sum of all the <paramref name="bitmaps"/>'s heights.
        /// </summary>
        /// <param name="bitmaps">List of bitmaps that make up a column in the sprite sheet.</param>
        /// <returns>Size containing the largest bitmap width, and the sum of all the <paramref name="bitmaps"/> heights.</returns>
        static GroupSize GetBitmapSetSize(List<SpriteInfo> bitmaps)
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
        /// Gets the size of each column from <see cref="sprites"/>, and then sums the width, and gets the max height.
        /// </summary>
        /// <param name="setMaxSizes">Returns the max size for each bitmap set.</param>
        /// <returns>The total size of sprite sheet to generate.</returns>
        Size GetSheetSize(GroupSize[] setSizes)
        {
            int minWidth = 0;         //Veritcally aligned Sheet width
            int minHeight = 0;        //Horizontally aligned Sheet height
            int maxWidth = 0;         //Horizontally aligned Sheet width
            int maxHeight = 0;        //Veritcally aligned Sheet height

            foreach (var setSize in setSizes)
            {
                minWidth += setSize.maxSize.Width;
                minHeight += setSize.maxSize.Height;

                if (maxWidth < setSize.sum.Width)
                    maxWidth = setSize.sum.Width;

                if (maxHeight < setSize.sum.Height)
                    maxHeight = setSize.sum.Height;
            }

            return AlignVertically ?
                new Size(minWidth, maxHeight) :
                new Size(maxWidth, minHeight);
        }

        /// <summary>
        /// Combines all bitmaps from <see cref="sprites"/> into a single list.
        /// </summary>
        /// <returns>A list containing all bitmaps from <see cref="sprites"/>.</returns>
        List<SpriteInfo> GetSprites()
        {
            return sprites.Values.SelectMany(x => x).ToList();
        }


        /// <summary>
        /// Rotates the <paramref name="bitmaps"/> by <paramref name="flipType"/>, and returns a new array with the rotated bitmaps.
        /// </summary>
        /// <param name="bitmaps">Bitmaps to rotate</param>
        /// <param name="flipType">Type of rotation or mirroring.</param>
        /// <returns>Array containing the rotated bitmaps.</returns>
        SpriteInfo[] RotateBitmaps(SpriteInfo[] bitmaps, RotateFlipType flipType)
        {
            int length = bitmaps.Length;
            SpriteInfo[] rotated = new SpriteInfo[length];

            for (int i = 0; i < length; i++)
            {
                Bitmap bm = bitmaps[i].bitmap;

                //Duplicate bitmap with the set pixel format
                Rectangle rect = new Rectangle(Point.Empty, bm.Size);
                Bitmap rotate = new Bitmap(bm);

                //Rotate
                rotate.RotateFlip(flipType);

                //Add to array
                rotated[i] = new SpriteInfo(rotate, bitmaps[i].id, flipType);
            }
            return rotated;
        }

        /// <summary>
        /// Applies rotations to the <see cref="origBitmaps"/> and places them in <see cref="sprites"/>.
        /// </summary>
        void GenerateBitmapVariations()
        {
            if (RotationsToGenerate != null)
                foreach (RotateFlipType flipType in RotationsToGenerate)
                {
                    //Rotate, place in dictionary, and set to source
                    SpriteInfo[] rotated = RotateBitmaps(origBitmaps, flipType);

                    //Add modified bitmaps to their group list
                    foreach (SpriteInfo si in rotated)
                        sprites[si.id].Add(si);

                    //Add all bitmaps with same RotateFlipType to a group list
                    flipTypeSprites[flipType] = rotated.ToList();
                }
        }

        #endregion

        #endregion
    }
}
