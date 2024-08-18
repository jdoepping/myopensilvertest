using System;
using System.Windows.Controls;
using OpenSilver;
using static MyProject.MainPage;

namespace MyProject
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // Enter construction logic here...
             string PreviousDealResource = Properties.Resource.Text01;
             this.DataContext = this;
        }

        public string Text01 => Properties.Resource.Text01;
        public string Text02 => Properties.Resource.Text02;
        public string HeartsImage => ImageResourcesEnum.Hearts.ToFileName();
        public string SpadeImage => ImageResourcesEnum.Spades.ToFileName();
        public enum ImageResourcesEnum
        {
            Transparent,
            Hearts,
            Clubs,
            Spades,
            Diamonds,
            NoTrumph
        }

       

    }
    public static class ImageResourcesExtensions
    {
        public static string ToFileName(this ImageResourcesEnum enumResource)
        {
            var resource = string.Empty;
            switch (enumResource)
            {
                case ImageResourcesEnum.Transparent:
                    resource = "transparent";
                    break;
                case ImageResourcesEnum.Hearts:
                    resource = "hjerter";
                    break;
                case ImageResourcesEnum.Clubs:
                    resource = "kloer_green";
                    break;
                case ImageResourcesEnum.Spades:
                    resource = "spar";
                    break;
                case ImageResourcesEnum.Diamonds:
                    resource = "ruder_orange";
                    break;
                case ImageResourcesEnum.NoTrumph:
                    resource = "trumf";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(resource), resource, null);
            }
            string currentDirectory = Environment.CurrentDirectory;
            Interop.ExecuteJavaScript("alert($0)", currentDirectory);
            var s=  $"../../../../../images/{resource}.png";
            Interop.ExecuteJavaScript("alert($0)", s);
            return s;
        }
    }
public static class MyText{
    public static string Klyp=> "Kurt kobik";
}
}
