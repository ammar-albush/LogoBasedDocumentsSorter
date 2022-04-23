using Emgu.CV;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Dnn;

namespace LogoBasedDocumentSorter
{
    public class ImageProcessor
    {

        public string ImageLocation = string.Empty;

        public Image image = null;

        public Image<Bgr, byte> imgeBgrByte = null;


        public ImageProcessor()
        {


        }

        public ImageProcessor(string Img)
        {

            this.ImageLocation = Img;
            this.imgeBgrByte = new Image<Bgr, byte>(Img);

        }


        public ImageProcessor(Image<Bgr, byte> Img)
        {

            this.imgeBgrByte = Img;

        }

        public Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }



        public Bitmap CutImage(Rectangle rect)
        {


            if (this.imgeBgrByte != null)
            {
                this.imgeBgrByte.ROI = rect;

                Image<Bgr, byte> temp = this.imgeBgrByte.CopyBlank();

                imgeBgrByte.CopyTo(temp);

                imgeBgrByte.ROI = Rectangle.Empty;

                return temp.ToBitmap();

            }
            else return null;

        }

        public Bitmap CutImage(Rectangle rect, Image<Bgr, byte> Img)
        {

                Img.ROI = rect;

                Image<Bgr, byte> temp = Img.CopyBlank();

                Img.CopyTo(temp);

                Img.ROI = Rectangle.Empty;

                return temp.ToBitmap();

         

        }

        public Bitmap BGRFiler(Bitmap bmp)=> bmp.ToImage<Bgr, byte>().ToBitmap();

        public Bitmap GrayFilter(Bitmap bmp)=> bmp.ToImage<Gray, byte>().ToBitmap();

        public int[,] getImagePixles2d(Bitmap bmp)
        {

            int[,] argb = new int[bmp.Width,bmp.Height];

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color pixel = bmp.GetPixel(i, j);

                    argb[i,j] =  pixel.ToArgb();
                  
                }
            }

            return argb;

        }

        /*   public byte[,] getImagePixels2d(Bitmap bmp)
           {


               byte[] ImagePixles = getImagePixles(bmp);

               byte[,] bytes = new byte[bmp.Width, bmp.Height];

               for (int i = 0; i < bmp.Width; i++)
               {
                   for (int j = 0; j < bmp.Height; j++)
                   {

                       bytes[i, j] = ImagePixles[i * bmp.Height + j];

                   }

               }

               return bytes;

           }
        */

       public List<Bitmap> getBiggestBlobsBitmapInImage(Bitmap Image, int Threshold, int minwidth, int minheight, int maxwidth, int maxheight)
        {

            var image = new Bitmap(Image).ToImage<Bgr, Byte>();

            var temp = image.SmoothGaussian(5).Convert<Gray, Byte>().ThresholdBinaryInv(new Gray(Threshold), new Gray(250));

            VectorOfVectorOfPoint contors = new VectorOfVectorOfPoint();

            Mat m = new Mat();

            CvInvoke.FindContours(temp, contors, m, Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

            List<Bitmap> filterdfundContors = FilterBitmaps(Image, contors,10);

            return filterdfundContors.Where(x => ((x.Width > minwidth) && (x.Height > minheight) && (x.Width < maxwidth) && (x.Height < maxheight))).ToList();


        }


        public List<Rectangle> getBiggestBlobsRectangleInImage(Bitmap Image, int Threshold, int minwidth, int minheight, int maxwidth, int maxheight)
        {

            var image = new Bitmap(Image).ToImage<Bgr, Byte>();

            var temp = image.SmoothGaussian(5).Convert<Gray, Byte>().ThresholdBinaryInv(new Gray(Threshold), new Gray(250));

            VectorOfVectorOfPoint contors = new VectorOfVectorOfPoint();

            Mat m = new Mat();

            CvInvoke.FindContours(temp, contors, m, Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

            List<Rectangle> filterdfundContors = FilterRectangles(Image, contors, 10);

            return filterdfundContors.Where(x => ((x.Width > minwidth) && (x.Height > minheight) && (x.Width < maxwidth) && (x.Height < maxheight))).ToList();

        }

        public List<Blob> getBiggestBlobsInImage(Bitmap Image, int Threshold, int minwidth, int minheight, int maxwidth, int maxheight)
        {

            var image = new Bitmap(Image).ToImage<Bgr, Byte>();

            var temp = image.SmoothGaussian(5).Convert<Gray, Byte>().ThresholdBinaryInv(new Gray(Threshold), new Gray(250));

            VectorOfVectorOfPoint contors = new VectorOfVectorOfPoint();

            Mat m = new Mat();

            CvInvoke.FindContours(temp, contors, m, Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

            List<Blob> filterdfundBlobss = FilterBlobs(Image, contors, 10);

           return filterdfundBlobss.Where(x => ((x.BMP.Width > minwidth) && (x.BMP.Height > minheight) && (x.BMP.Width < maxwidth) && (x.BMP.Height < maxheight))).ToList();

        }


        Bitmap getContorformVectorOfPoint(Bitmap imgae, VectorOfPoint points)
        {

            var img = imgae.ToImage<Bgr, Byte>();

            int minx = points[0].X;
            int miny = points[0].Y;
            int maxX = points[0].X;
            int maxy = points[0].Y;

            for (int i = 0; i < points.Size; i++)
            {

                if (points[i].X > maxX)
                {
                    maxX = points[i].X;

                }
                if (points[i].X < minx)
                {
                    minx = points[i].X;

                }
                if (points[i].Y > maxy)
                {
                    maxy = points[i].Y;

                }
                if (points[i].Y < miny)
                {
                    miny = points[i].Y;

                }

            }

            int x = minx;

            int y = miny;

            int width = maxX - minx;

            int height = maxy - miny;

            Rectangle rectangle = new Rectangle(x, y, width, height);

            return CutImage(rectangle, img);


        }

        List<Bitmap> FilterBitmaps(Bitmap Image, VectorOfVectorOfPoint contors, int minWidth, int minheight)
        {


            List<Bitmap> bitmaps = new List<Bitmap>();

            for (int i = 0; i < contors.Size; i++)
            {

                Bitmap bitmap = getContorformVectorOfPoint(Image, contors[i]);

                if (bitmap.Width > minWidth && bitmap.Height > minheight)
                    bitmaps.Add(bitmap);


            }

            return bitmaps;

        }

        List<Blob> FilterBlobs(Bitmap Image, VectorOfVectorOfPoint Imagecontors, int maxdistance)
        {

            List<Blob> blobs = new List<Blob>();

            List<int> tofilterelments = new List<int>();

            for (int i = 0; i < Imagecontors.Size; i++)
            {


                if (tofilterelments != null || tofilterelments.Count != 0)
                {

                    if (!tofilterelments.Contains(i))
                    {

                        SelectedContor SelectLogoAttachmentsRectangle = selectLogoAttachmentsRectangle(Imagecontors, Imagecontors[i], maxdistance);

                        tofilterelments.AddRange(SelectLogoAttachmentsRectangle.SelectedContorsIndexs);

                        if (SelectLogoAttachmentsRectangle.Rectangle.Width > 0 && SelectLogoAttachmentsRectangle.Rectangle.Height > 0)
                            blobs.Add(new Blob(SelectLogoAttachmentsRectangle.Rectangle, CutImage(SelectLogoAttachmentsRectangle.Rectangle, Image.ToImage<Bgr, Byte>())));

                    }

                }
                else
                {

                    SelectedContor SelectLogoAttachmentsRectangle = selectLogoAttachmentsRectangle(Imagecontors, Imagecontors[i], maxdistance);
                    tofilterelments.AddRange(SelectLogoAttachmentsRectangle.SelectedContorsIndexs);
                    if (SelectLogoAttachmentsRectangle.Rectangle.Width > 0 && SelectLogoAttachmentsRectangle.Rectangle.Height > 0)
                        blobs.Add(new Blob(SelectLogoAttachmentsRectangle.Rectangle, CutImage(SelectLogoAttachmentsRectangle.Rectangle, Image.ToImage<Bgr, Byte>())));

                }


            }

            return blobs;


        }

        List<Rectangle> FilterRectangles(Bitmap Image, VectorOfVectorOfPoint Imagecontors, int maxdistance)
        {


            List<Rectangle> Rectangles = new List<Rectangle>();

            List<int> tofilterelments = new List<int>();

            for (int i = 0; i < Imagecontors.Size; i++)
            {


                if (tofilterelments != null || tofilterelments.Count != 0)
                {

                    if (!tofilterelments.Contains(i))
                    {

                        SelectedContor SelectLogoAttachmentsRectangle = selectLogoAttachmentsRectangle(Imagecontors, Imagecontors[i], maxdistance);

                        tofilterelments.AddRange(SelectLogoAttachmentsRectangle.SelectedContorsIndexs);

                        if (SelectLogoAttachmentsRectangle.Rectangle.Width > 0 && SelectLogoAttachmentsRectangle.Rectangle.Height > 0)
                            Rectangles.Add(SelectLogoAttachmentsRectangle.Rectangle);

                    }

                }
                else
                {

                    SelectedContor SelectLogoAttachmentsRectangle = selectLogoAttachmentsRectangle(Imagecontors, Imagecontors[i], maxdistance);
                    tofilterelments.AddRange(SelectLogoAttachmentsRectangle.SelectedContorsIndexs);
                    if (SelectLogoAttachmentsRectangle.Rectangle.Width > 0 && SelectLogoAttachmentsRectangle.Rectangle.Height > 0)
                        Rectangles.Add(SelectLogoAttachmentsRectangle.Rectangle);

                }


            }

            return Rectangles;

        }

        List<Bitmap> FilterBitmaps(Bitmap Image, VectorOfVectorOfPoint Imagecontors, int maxdistance)
        {


            List<Bitmap> bitmaps = new List<Bitmap>();

            List<int> tofilterelments = new List<int>();

            for (int i = 0; i < Imagecontors.Size; i++)
            {


                if (tofilterelments != null || tofilterelments.Count != 0)
                {

                    if (!tofilterelments.Contains(i))
                    {

                        SelectedContor SelectLogoAttachmentsRectangle = selectLogoAttachmentsRectangle(Imagecontors, Imagecontors[i], maxdistance);

                        tofilterelments.AddRange(SelectLogoAttachmentsRectangle.SelectedContorsIndexs);

                        if (SelectLogoAttachmentsRectangle.Rectangle.Width > 0 && SelectLogoAttachmentsRectangle.Rectangle.Height > 0)
                            bitmaps.Add(CutImage(SelectLogoAttachmentsRectangle.Rectangle, Image.ToImage<Bgr, Byte>()));

                    }

                }
                else
                {

                    SelectedContor SelectLogoAttachmentsRectangle = selectLogoAttachmentsRectangle(Imagecontors, Imagecontors[i], maxdistance);
                    tofilterelments.AddRange(SelectLogoAttachmentsRectangle.SelectedContorsIndexs);
                    if (SelectLogoAttachmentsRectangle.Rectangle.Width > 0 && SelectLogoAttachmentsRectangle.Rectangle.Height > 0)
                        bitmaps.Add(CutImage(SelectLogoAttachmentsRectangle.Rectangle, Image.ToImage<Bgr, Byte>()));

                }


            }

            return bitmaps;

        }




        Rectangle getRectangleFromPoints(VectorOfPoint points)
        {

            int minx = points[0].X;
            int miny = points[0].Y;
            int maxX = points[0].X;
            int maxy = points[0].Y;

            for (int i = 0; i < points.Size; i++)
            {

                if (points[i].X > maxX)
                {
                    maxX = points[i].X;

                }
                if (points[i].X < minx)
                {
                    minx = points[i].X;

                }
                if (points[i].Y > maxy)
                {
                    maxy = points[i].Y;

                }
                if (points[i].Y < miny)
                {
                    miny = points[i].Y;

                }

            }

            return new Rectangle(minx, miny, maxX - minx, maxy - miny);


        }

        SelectedContor selectLogoAttachmentsRectangle(VectorOfVectorOfPoint Imagecontors, VectorOfPoint Logopoints, int maxdistance)
        {

            Rectangle rectangle1 = getRectangleFromPoints(Logopoints);

            int startX = rectangle1.X;

            int startY = rectangle1.Y;

            int startWidth = rectangle1.Width;

            int startHeight = rectangle1.Height;

            int endX1 = startX + startWidth;

            int endY1 = startY + startHeight;

            List<int> selectedIndexes = new List<int>();

            for (int c = 0; c < Imagecontors.Size; c++)
            {

                try
                {

                    Rectangle rectangle2 = getRectangleFromPoints(Imagecontors[c]);


                    int startX2 = rectangle2.X;

                    int startY2 = rectangle2.Y;

                    int startWidth2 = rectangle2.Width;

                    int startHeight2 = rectangle2.Height;

                    int endX2 = startX2 + startWidth2;

                    int endY2 = startY2 + startHeight2;

                    if (((startX2 >= startX + maxdistance) && (startX2 <= endX1 + maxdistance) && (startY2 >= startY + maxdistance) && (startY2 <= endY1 + maxdistance))
                    || ((endX2 >= startX + maxdistance) && (endX2 <= endX1 + maxdistance) && (startY2 >= startY + maxdistance) && (startY2 <= endY1 + maxdistance))
                    || ((startX2 >= startX + maxdistance) && (startX2 <= endX1 + maxdistance) && (endY2 >= startY + maxdistance) && (endY2 <= endY1 + maxdistance))
                    || ((endX2 >= startX + maxdistance) && (endX2 <= endX1 + maxdistance) && (endY2 >= startY + maxdistance) && (endY2 <= endY1 + maxdistance)))
                    {

                        selectedIndexes.Add(c);

                        if (startX2 < startX)
                        {

                            startX = startX2;
                            startWidth = startWidth + startWidth2 + maxdistance;

                        }
                        if (startY2 < startY)
                        {

                            startY = startY2;
                            startHeight = startHeight + startHeight2 + maxdistance;

                        }
                        if (startX2 > startX)
                        {

                            startWidth = startWidth + startWidth2 + maxdistance;

                        }
                        if (startY2 > startY)
                        {

                            startHeight = startHeight + startHeight2 + maxdistance;

                        }



                    }

                    if (((startX2 >= startX - maxdistance) && (startX2 <= endX1 - maxdistance) && (startY2 >= startY - maxdistance) && (startY2 <= endY1 - maxdistance))
                   || ((endX2 >= startX - maxdistance) && (endX2 <= endX1 - maxdistance) && (startY2 >= startY - maxdistance) && (startY2 <= endY1 - maxdistance))
                   || ((startX2 >= startX - maxdistance) && (startX2 <= endX1 - maxdistance) && (endY2 >= startY - maxdistance) && (endY2 <= endY1 - maxdistance))
                   || ((endX2 >= startX - maxdistance) && (endX2 <= endX1 - maxdistance) && (endY2 >= startY - maxdistance) && (endY2 <= endY1 - maxdistance)))
                    {

                        selectedIndexes.Add(c);

                        if (startX2 < startX)
                        {

                            startX = startX2;
                            startWidth = startWidth + startWidth2 + maxdistance;

                        }
                        if (startY2 < startY)
                        {

                            startY = startY2;
                            startHeight = startHeight + startHeight2 + maxdistance;

                        }
                        if (startX2 > startX)
                        {

                            startWidth = startWidth + startWidth2 + maxdistance;

                        }
                        if (startY2 > startY)
                        {

                            startHeight = startHeight + startHeight2 + maxdistance;

                        }



                    }

                }
                catch (Exception ex)
                {
                    
                }
            }

            return new SelectedContor(selectedIndexes, new Rectangle(startX, startY, startWidth, startHeight));

        }


    }

    public class SelectedContor
    {

        public List<int> SelectedContorsIndexs = new List<int>();

        public Rectangle Rectangle = new Rectangle();

        public SelectedContor(List<int> selectedContorsIndexs, Rectangle rectangle)
        {

            this.SelectedContorsIndexs = selectedContorsIndexs;

            this.Rectangle = rectangle;

        }


    }

    public class Blob
    {

        public Rectangle Rectangle { get; set; }

        public Bitmap BMP { get; set; }
        
        public Blob(Rectangle Rect , Bitmap bitmap)
        {

            this.Rectangle = Rect;
            this.BMP = bitmap;

        
        }
    
    
    }



}



