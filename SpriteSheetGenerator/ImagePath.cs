﻿namespace SpriteSheetGenerator
{
    internal class ImagePath : IDisposable
    {
        public Image image;
        public string? path;
        public string filename;
        public PictureBox pb;
        public int Width => image.Width;
        public int Height => image.Height;
        public bool IsDisposed => pb.IsDisposed;

#pragma warning disable 8618
        public ImagePath() { }

        public ImagePath(Image image, string path, string filename, PictureBox pb)
        {
            this.image = image;
            this.path = path;
            this.filename = filename;
            this.pb = pb;
        }

        public ImagePath(Image image, string origFilename, RotateFlipType flipType)
        {
            this.image = image;
            filename = Path.GetFileNameWithoutExtension(origFilename) + SpriteSheetGeneratorForm.rotateFlipNames[flipType];
        }
#pragma warning restore 8618

        ~ImagePath()
        {
            Dispose();
        }

        public override string ToString()
        {
            return filename;
        }

        public void Dispose()
        {
            if (!IsDisposed)
            {
                pb.Dispose();
                image.Dispose();
                GC.SuppressFinalize(this);
            }
        }


        public static implicit operator Image(ImagePath imgPath) => imgPath.image;
        public static implicit operator PictureBox(ImagePath imgPath) => imgPath.pb;
    }
}
