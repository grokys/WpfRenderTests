// Copyright (c) The Avalonia Project. All rights reserved.
// Licensed under the MIT license. See licence.md file in the project root for full license information.

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Xunit;

namespace WpfTilingTests
{
    public class ImageBrushTests : TestBase
    {
        public ImageBrushTests()
            : base(@"Media\ImageBrush")
        {
        }

        private string BitmapPath
        {
            get { return System.IO.Path.Combine(OutputPath, "github_icon.png"); }
        }

        [WpfFact]
        public void ImageBrush_Tile_Fill()
        {
            Decorator target = new Decorator
            {
                Width = 200,
                Height = 200,
                Child = new Rectangle
                {
                    Margin = new Thickness(8),
                    Fill = new ImageBrush
                    {
                        Stretch = Stretch.Fill,
                        TileMode = TileMode.Tile,
                        Viewport = new Rect(0, 0, 25, 30),
                        ViewportUnits = BrushMappingMode.Absolute,
                        ImageSource = LoadBitmap(BitmapPath),
                    }
                }
            };

            RenderToFile(target);
            CompareImages();
        }

        [WpfFact]
        public void ImageBrush_Tile_UniformToFill()
        {
            Decorator target = new Decorator
            {
                Width = 200,
                Height = 200,
                Child = new Rectangle
                {
                    Margin = new Thickness(8),
                    Fill = new ImageBrush
                    {
                        Stretch = Stretch.Uniform,
                        TileMode = TileMode.Tile,
                        Viewport = new Rect(0, 0, 25, 30),
                        ViewportUnits = BrushMappingMode.Absolute,
                        ImageSource = LoadBitmap(BitmapPath),
                    }
                }
            };

            RenderToFile(target);
            CompareImages();
        }

        [WpfFact]
        public void ImageBrush_NoStretch_NoTile_Alignment_TopLeft()
        {
            Decorator target = new Decorator
            {
                Width = 200,
                Height = 200,
                Child = new Rectangle
                {
                    Margin = new Thickness(8),
                    Fill = new ImageBrush
                    {
                        Stretch = Stretch.None,
                        TileMode = TileMode.None,
                        AlignmentX = AlignmentX.Left,
                        AlignmentY = AlignmentY.Top,
                        ImageSource = LoadBitmap(BitmapPath),
                    }
                }
            };

            RenderToFile(target);
            CompareImages();
        }

        [WpfFact]
        public void ImageBrush_NoStretch_NoTile_Alignment_Center()
        {
            Decorator target = new Decorator
            {
                Width = 200,
                Height = 200,
                Child = new Rectangle
                {
                    Margin = new Thickness(8),
                    Fill = new ImageBrush
                    {
                        Stretch = Stretch.None,
                        TileMode = TileMode.None,
                        AlignmentX = AlignmentX.Center,
                        AlignmentY = AlignmentY.Center,
                        ImageSource = LoadBitmap(BitmapPath),
                    }
                }
            };

            RenderToFile(target);
            CompareImages();
        }

        [WpfFact]
        public void ImageBrush_NoStretch_NoTile_Alignment_BottomRight()
        {
            Decorator target = new Decorator
            {
                Width = 200,
                Height = 200,
                Child = new Rectangle
                {
                    Margin = new Thickness(8),
                    Fill = new ImageBrush
                    {
                        Stretch = Stretch.None,
                        TileMode = TileMode.None,
                        AlignmentX = AlignmentX.Right,
                        AlignmentY = AlignmentY.Bottom,
                        ImageSource = LoadBitmap(BitmapPath),
                    }
                }
            };

            RenderToFile(target);
            CompareImages();
        }

        [WpfFact]
        public void ImageBrush_Fill_NoTile()
        {
            Decorator target = new Decorator
            {
                Width = 920,
                Height = 920,
                Child = new Rectangle
                {
                    Margin = new Thickness(8),
                    Fill = new ImageBrush
                    {
                        Stretch = Stretch.Fill,
                        TileMode = TileMode.None,
                        ImageSource = LoadBitmap(BitmapPath),
                    }
                }
            };

            RenderToFile(target);
            CompareImages();
        }

        [WpfFact]
        public void ImageBrush_Uniform_NoTile()
        {
            Decorator target = new Decorator
            {
                Width = 300,
                Height = 200,
                Child = new Rectangle
                {
                    Margin = new Thickness(8),
                    Fill = new ImageBrush
                    {
                        Stretch = Stretch.Uniform,
                        TileMode = TileMode.None,
                        ImageSource = LoadBitmap(BitmapPath),
                    }
                }
            };

            RenderToFile(target);
            CompareImages();
        }

        [WpfFact]
        public void ImageBrush_UniformToFill_NoTile()
        {
            Decorator target = new Decorator
            {
                Width = 300,
                Height = 200,
                Child = new Rectangle
                {
                    Margin = new Thickness(8),
                    Fill = new ImageBrush
                    {
                        Stretch = Stretch.UniformToFill,
                        TileMode = TileMode.None,
                        ImageSource = LoadBitmap(BitmapPath),
                    }
                }
            };

            RenderToFile(target);
            CompareImages();
        }

        [WpfFact]
        public void ImageBrush_NoStretch_NoTile_BottomRightQuarterSource()
        {
            Decorator target = new Decorator
            {
                Width = 200,
                Height = 200,
                Child = new Rectangle
                {
                    Margin = new Thickness(8),
                    Fill = new ImageBrush
                    {
                        Stretch = Stretch.None,
                        TileMode = TileMode.None,
                        Viewbox = new Rect(250, 250, 250, 250),
                        ViewboxUnits = BrushMappingMode.Absolute,
                        ImageSource = LoadBitmap(BitmapPath),
                    }
                }
            };

            RenderToFile(target);
            CompareImages();
        }

        [WpfFact]
        public void ImageBrush_NoStretch_NoTile_BottomRightQuarterDest()
        {
            Decorator target = new Decorator
            {
                Width = 200,
                Height = 200,
                Child = new Rectangle
                {
                    Margin = new Thickness(8),
                    Fill = new ImageBrush
                    {
                        Stretch = Stretch.None,
                        TileMode = TileMode.None,
                        Viewport = new Rect(92, 92, 92, 92),
                        ViewportUnits = BrushMappingMode.Absolute,
                        ImageSource = LoadBitmap(BitmapPath),
                    }
                }
            };

            RenderToFile(target);
            CompareImages();
        }

        [WpfFact]
        public void ImageBrush_NoStretch_NoTile_BottomRightQuarterSource_BottomRightQuarterDest()
        {
            Decorator target = new Decorator
            {
                Width = 200,
                Height = 200,
                Child = new Rectangle
                {
                    Margin = new Thickness(8),
                    Fill = new ImageBrush
                    {
                        Stretch = Stretch.None,
                        TileMode = TileMode.None,
                        Viewbox = new Rect(0.5, 0.5, 0.5, 0.5),
                        ViewboxUnits = BrushMappingMode.RelativeToBoundingBox,
                        Viewport = new Rect(0.5, 0.5, 0.5, 0.5),
                        ViewportUnits = BrushMappingMode.RelativeToBoundingBox,
                        ImageSource = LoadBitmap(BitmapPath),
                    }
                }
            };

            RenderToFile(target);
            CompareImages();
        }

        [WpfFact]
        public void ImageBrush_NoStretch_Tile_BottomRightQuarterSource_CenterQuarterDest()
        {
            Decorator target = new Decorator
            {
                Width = 200,
                Height = 200,
                Child = new Rectangle
                {
                    Margin = new Thickness(8),
                    Fill = new ImageBrush
                    {
                        Stretch = Stretch.None,
                        TileMode = TileMode.Tile,
                        Viewbox = new Rect(0.5, 0.5, 0.5, 0.5),
                        ViewboxUnits = BrushMappingMode.RelativeToBoundingBox,
                        Viewport = new Rect(0.5, 0.5, 0.5, 0.5),
                        ViewportUnits = BrushMappingMode.RelativeToBoundingBox,
                        ImageSource = LoadBitmap(BitmapPath),
                    }
                }
            };

            RenderToFile(target);
            CompareImages();
        }

        [WpfFact]
        public void ImageBrush_NoStretch_FlipX_TopLeftDest()
        {
            Decorator target = new Decorator
            {
                Width = 200,
                Height = 200,
                Child = new Rectangle
                {
                    Margin = new Thickness(8),
                    Fill = new ImageBrush
                    {
                        Stretch = Stretch.None,
                        TileMode = TileMode.FlipX,
                        Viewport = new Rect(0.5, 0.5, 0.5, 0.5),
                        ViewportUnits = BrushMappingMode.RelativeToBoundingBox,
                        ImageSource = LoadBitmap(BitmapPath),
                    }
                }
            };

            RenderToFile(target);
            CompareImages();
        }

        [WpfFact]
        public void ImageBrush_NoStretch_FlipY_TopLeftDest()
        {
            Decorator target = new Decorator
            {
                Width = 200,
                Height = 200,
                Child = new Rectangle
                {
                    Margin = new Thickness(8),
                    Fill = new ImageBrush
                    {
                        Stretch = Stretch.None,
                        TileMode = TileMode.FlipY,
                        Viewport = new Rect(0, 0, 0.5, 0.5),
                        ViewportUnits = BrushMappingMode.RelativeToBoundingBox,
                        ImageSource = LoadBitmap(BitmapPath),
                    }
                }
            };

            RenderToFile(target);
            CompareImages();
        }

        [WpfFact]
        public void ImageBrush_NoStretch_FlipXY_TopLeftDest()
        {
            Decorator target = new Decorator
            {
                Width = 200,
                Height = 200,
                Child = new Rectangle
                {
                    Margin = new Thickness(8),
                    Fill = new ImageBrush
                    {
                        Stretch = Stretch.None,
                        TileMode = TileMode.FlipXY,
                        Viewport = new Rect(0, 0, 0.5, 0.5),
                        ViewportUnits = BrushMappingMode.RelativeToBoundingBox,
                        ImageSource = LoadBitmap(BitmapPath),
                    }
                }
            };

            RenderToFile(target);
            CompareImages();
        }

        ImageSource LoadBitmap(string path)
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(path);
            bitmap.EndInit();
            return bitmap;
        }
    }
}
