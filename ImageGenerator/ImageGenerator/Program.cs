using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace ImageGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateImage("Vertice", "Вершина", "D:\\", Color.FromArgb(153, 38, 103));
        }

        private static void GenerateImage(string word, string translation, string filePath, Color? secondColor = null)
        {
            using var bitmap = new Bitmap(600, 320);
            using var graphics = Graphics.FromImage(bitmap);

            var rectangleWidth = 600; 
            var rectangleHeight = 160;
            
            secondColor ??= Color.FromArgb(81, 45, 168);
            
            var secondBrush = new SolidBrush(secondColor.Value);
            graphics.FillRectangle(secondBrush, new Rectangle(0, 0, rectangleWidth, rectangleHeight));
            graphics.FillRectangle(Brushes.White, new Rectangle(0, 160, rectangleWidth, rectangleHeight));

            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            
            using var wordFont = new Font("Tahoma", 68);
            var wordSize = graphics.MeasureString(word, wordFont);
            var wordLocation = new PointF(rectangleWidth*0.5f - wordSize.Width*0.5f, rectangleHeight*0.5f - wordSize.Height*0.5f);
            graphics.DrawString(word, wordFont, Brushes.White, wordLocation);

            using var translationFont = new Font("Tahoma", wordFont.Size*0.64f);
            var translationSize = graphics.MeasureString(translation, translationFont);
            var translationLocation = new PointF(rectangleWidth*0.5f - translationSize.Width*0.5f, rectangleHeight + rectangleHeight*0.5f - translationSize.Height*0.5f);
            graphics.DrawString(translation, translationFont, secondBrush, translationLocation);
            
            bitmap.Save($"{filePath}\\{word}.jpg", ImageFormat.Jpeg);
        }
    }
}