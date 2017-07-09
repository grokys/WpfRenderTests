// Copyright (c) The Avalonia Project. All rights reserved.
// Licensed under the MIT license. See licence.md file in the project root for full license information.

using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ImageMagick;
using Xunit;

namespace WpfTilingTests
{
    public class TestBase
    {
        public TestBase(string outputPath)
        {
            string testFiles = Path.GetFullPath(@"..\..\TestFiles");
            OutputPath = Path.Combine(testFiles, outputPath);
        }

        public string OutputPath
        {
            get;
        }

        protected void RenderToFile(FrameworkElement target, [CallerMemberName] string testName = "")
        {
            if (!Directory.Exists(OutputPath))
            {
                Directory.CreateDirectory(OutputPath);
            }

            string path = Path.Combine(OutputPath, testName + ".out.png");

            var bitmap = new RenderTargetBitmap(
                (int)target.Width,
                (int)target.Height,
                96,
                96,
                PixelFormats.Pbgra32);
            Size size = new Size(target.Width, target.Height);
            target.Measure(size);
            target.Arrange(new Rect(size));
            bitmap.Render(target);

            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmap));

            using (var s = File.OpenWrite(path))
            {
                encoder.Save(s);
            }
        }

        protected void CompareImages([CallerMemberName] string testName = "")
        {
            string expectedPath = Path.Combine(OutputPath, testName + ".expected.png");
            string actualPath = Path.Combine(OutputPath, testName + ".out.png");
            using (MagickImage expected = new MagickImage(expectedPath))
            using (MagickImage actual = new MagickImage(actualPath))
            {
                double error = expected.Compare(actual, ErrorMetric.RootMeanSquared);

                if (error > 0.022)
                {
                    Assert.True(false, actualPath + ": Error = " + error);
                }
            }
        }
    }
}
