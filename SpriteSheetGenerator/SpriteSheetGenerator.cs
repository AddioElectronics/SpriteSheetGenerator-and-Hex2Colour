using System.Drawing.Imaging;
using Image = System.Drawing.Image;

namespace Hex2Colour
{
    /// <summary>
    /// Takes 1 or more bitmaps and applies optional rotations before combining them into a single sprite sheet.
    /// </summary>
    public class Hex2Colour
    {
        #region Definitions

        /// <summary>
        /// For holding the sizes of a specific bitmap set.
        /// </summary>
        struct SetSize
        {
            /// <summary>
            /// Sum of every bitmap in the set's size.
            /// </summary>
            public Size maxSize;

            /// <summary>
            /// Size of the largest bitmap in the set.
            /// </summary>
            public Size minSize;

            public SetSize(int maxWidth, int maxHeight, int minWidth, int minHeight)
            {
                maxSize = new Size(maxWidth, maxHeight);
                minSize = new Size(minWidth, minHeight);
            }
        }

        #endregion

        #region Properties
        /// <summary>
        /// Output pixel format.
        /// </summary>
        public PixelFormat PixelFormat { get; set; } = PixelFormat.Format32bppArgb;

        /// <summary>
        /// Original images aligned along column.
        /// </summary>
        public bool AlignVertically { get; set; }

        /// <summary>
        /// Type types of rotations to generate
        /// </summary>
        public RotateFlipType[] RotationsToGenerate { get; set; }

        #endregion

        #region Fields

        /// <summary>
        /// List of the original bitmaps.
        /// </summary>
        Bitmap[] origBitmaps;

        /// <summary>
        /// Dictionary containing all the bitmaps for the sheet.
        /// Each key is a column, each value is a row.
        /// </summary>
        Dictionary<RotateFlipType, List<Bitmap>> sprites = new Dictionary<RotateFlipType, List<Bitmap>>();

        #endregion

        #region Constructors

        public Hex2Colour() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="images">Array of images</param>
        /// <param name="toGenerate">Types of rotations to generate.</param>
        public Hex2Colour(Image[] images, params RotateFlipType[] toGenerate)
        {
            SetImages(images, toGenerate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="images">Image list</param>
        /// <param name="toGenerate">Types of rotations to generate.</param>
        public Hex2Colour(List<Image> images, params RotateFlipType[] toGenerate) : this(images.ToArray(), toGenerate) { }

        #endregion

        #region Methods

        /// <summary>
        /// Set the next batch of images to create a sprite sheet from.
        /// </summary>
        /// <param name="images">Images to sheeterize</param>
        /// <param name="toGenerate">The types of rotations to generate.</param>
        public void SetImages(Image[] images, params RotateFlipType[] toGenerate)
        {
            //Make sure raw format is BMP or rotated/mirrored bitmaps will draw blurry for some formats.
            origBitmaps = ConvertToBitmaps(images);
            RotationsToGenerate = toGenerate;
            sprites.Clear();
        }

        /// <summary>
        /// Converts an array of <see cref="Image"/>s into BMP format <see cref="Bitmap"/>s.
        /// </summary>
        /// <param name="images"></param>
        /// <returns>Array containing BMP format copies of <paramref name="images"/>.</returns>
        Bitmap[] ConvertToBitmaps(Image[] images)
        {
            int length = images.Length;
            Bitmap[] bitmaps = new Bitmap[length];

            for (int i = 0; i < length; i++)
            {
                Bitmap bmp = new Bitmap(images[i]);
                bitmaps[i] = bmp;
            }

            return bitmaps;
        }


        /// <summary>
        /// Gets the max width, and the sum of all the <paramref name="bitmaps"/>'s heights.
        /// </summary>
        /// <param name="bitmaps">List of bitmaps that make up a column in the sprite sheet.</param>
        /// <returns>Size containing the largest bitmap width, and the sum of all the <paramref name="bitmaps"/> heights.</returns>
        SetSize GetBitmapSetSize(List<Bitmap> bitmaps)
        {
            int width = 0;      //Total Column width
            int height = 0;     //Total Column height
            int maxWidth = 0;   //Bitmap max width
            int maxHeight = 0;  //Bitmap max height

            foreach (var bm in bitmaps)
            {
                if (bm.Width > width)
                    maxWidth = bm.Width;

                if (bm.Height > height)
                    maxHeight = bm.Height;

                width += bm.Width;
                height += bm.Height;
            }

            return new SetSize(width, height, maxWidth, maxHeight);
        }

        /// <summary>
        /// Gets the size of each column from <see cref="sprites"/>, and then sums the width, and gets the max height.
        /// </summary>
        /// <param name="setMaxSizes">Returns the max size for each bitmap set.</param>
        /// <returns>The total size of sprite sheet to generate.</returns>
        SetSize GetSheetSize(out SetSize[] setSizes)
        {
            int minWidth = 0;         //Sheet width
            int minHeight = 0;        //Sheet height
            int maxWidth = 0;         //Sheet width
            int maxHeight = 0;        //Sheet height

            List<SetSize> _setSizes = new List<SetSize>();

            foreach (var bmcol in sprites.Values)
            {
                SetSize setSize = GetBitmapSetSize(bmcol);
                _setSizes.Add(setSize);
                maxWidth += setSize.minSize.Width;
                maxHeight += setSize.minSize.Height;

                //minWidth += setSize.minSize.Width;
                //minHeight += setSize.minSize.Height;

                if (minWidth < setSize.maxSize.Width)
                    minWidth = setSize.maxSize.Width;

                if (minHeight < setSize.maxSize.Height)
                    minHeight = setSize.maxSize.Height;
            }

            setSizes = _setSizes.ToArray();
            return new SetSize(maxWidth, maxHeight, minWidth, minHeight);
        }

        /// <summary>
        /// Combines all bitmaps from <see cref="sprites"/> into a single list.
        /// </summary>
        /// <returns>A list containing all bitmaps from <see cref="sprites"/>.</returns>
        List<Bitmap> GetSprites()
        {
            return sprites.Values.SelectMany(x => x).ToList();
        }

        /// <summary>
        /// Processes and combines all the bitmaps that were previously set into a single sprite sheet.
        /// </summary>
        /// <param name="generate">Flags which decide which orientations will be generated.</param>
        /// <param name="mirror">Should bitmaps be mirrored when rotating?</param>
        /// <param name="orientationsMirrored">What orientations should be mirrored? (Only used when <paramref name="mirror"/> equals <see cref="MirrorType.SeparateSets"/>)</param>
        /// <returns>A list of all the generated and original bitmaps.</returns>
        public Image CreateSheet()
        {
            //Setup the sprites dictionary
            sprites.Clear();
            sprites[0] = origBitmaps.ToList();

            //Process the bitmaps
            GenerateBitmaps();

            //Combine all bitmaps from sprites into a single array.
            var bitmaps = GetSprites();

            //Calculate columns, rows and size
            int rows = sprites[0].Count;
            int columns = bitmaps.Count / rows;
            SetSize size = GetSheetSize(out SetSize[] setSizes);

            //Create the sheet bitmap
            Bitmap sheet = AlignVertically ? 
                new Bitmap(size.maxSize.Width, size.minSize.Height, PixelFormat) :
                new Bitmap(size.minSize.Width, size.maxSize.Height, PixelFormat);

            //Copy all the bitmaps onto the sheet
            using (Graphics g = Graphics.FromImage(sheet))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.AssumeLinear;

                int rowBase = 0;    //The current row's 0 index                

                if (AlignVertically)
                {
                    int y = 0;      //The current row's Y position

                    for (int c = 0; c < columns; c++)
                    {
                        Point point = new Point(0, y);

                        //Draw each bitmap in the column
                        for (int r = 0; r < rows; r++)
                        {
                            Bitmap bm = (Bitmap)bitmaps[rowBase + r];

                            g.DrawImage(bm, point);
                            point.X += bm.Width;
                        }

                        //Increase row/column base values
                        y += setSizes[c].minSize.Height;
                        rowBase += rows;
                    }
                }
                else
                {
                    int x = 0;     //The current column's X position

                    for (int c = 0; c < columns; c++)
                    {
                        Point point = new Point(x, 0);

                        //Draw each bitmap in the row
                        for (int r = 0; r < rows; r++)
                        {
                            Bitmap bm = (Bitmap)bitmaps[rowBase + r];

                            g.DrawImage(bm, point);
                            point.Y += bm.Height;
                        }

                        //Increase row/column base values
                        x += setSizes[c].minSize.Width;
                        rowBase += rows;
                    }
                }

               

                //Apply the graphics
                g.Save();
            }

            return sheet;
        }

        /// <summary>
        /// Rotates the <paramref name="bitmaps"/> by <paramref name="flipType"/>, and returns a new array with the rotated bitmaps.
        /// </summary>
        /// <param name="bitmaps">Bitmaps to rotate</param>
        /// <param name="flipType">Type of rotation or mirroring.</param>
        /// <returns>Array containing the rotated bitmaps.</returns>
        Bitmap[] RotateBitmapList(Bitmap[] bitmaps, RotateFlipType flipType)
        {
            int length = bitmaps.Length;
            Bitmap[] rotated = new Bitmap[length];

            for (int i = 0; i < length; i++)
            {
                Bitmap bm = (Bitmap)bitmaps[i];

                //Duplicate bitmap with the set pixel format
                Rectangle rect = new Rectangle(Point.Empty, bm.Size);
                Bitmap rotate = bm.Clone(rect, PixelFormat);

                //Rotate
                rotate.RotateFlip(flipType);

                //Add to array
                rotated[i] = rotate;
            }
            return rotated;
        }



        /// <summary>
        /// Applies rotations to the <see cref="origBitmaps"/> and places them in <see cref="sprites"/>.
        /// </summary>
        private void GenerateBitmaps()
        {
            foreach(RotateFlipType flipType in RotationsToGenerate) 
            {
                //Rotate, place in dictionary, and set to source
                Bitmap[] rotated = RotateBitmapList(origBitmaps, flipType);
                sprites[flipType] = rotated.ToList();
            }
        }
        #endregion
    }
}
