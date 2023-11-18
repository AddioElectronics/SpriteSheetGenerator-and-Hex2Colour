namespace SpriteSheetGenerator
{
    /// <summary>
    /// Sizes of a bitmap group as a whole.
    /// </summary>
    internal struct GroupSize
    {
        /// <summary>
        /// Sum of every bitmap in the set's size.
        /// </summary>
        public Size sum;

        /// <summary>
        /// Smallest size in each set
        /// </summary>
        public Size minSize;

        /// <summary>
        /// Size of the largest bitmap in the set.
        /// </summary>
        public Size maxSize;

        public GroupSize(int sumWidth, int sumHeight, int minWidth, int minHeight, int maxWidth, int maxHeight)
        {
            sum = new Size(sumWidth, sumHeight);
            maxSize = new Size(maxWidth, maxHeight);
            minSize = new Size(minWidth, minHeight);
        }
    }
}
