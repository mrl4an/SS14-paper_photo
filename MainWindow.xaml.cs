using Microsoft.Win32;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Color = System.Drawing.Color;


namespace SS14_paper_photo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void choiceImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            
            if (openFileDialog1.ShowDialog() == true)
            {
                if(!openFileDialog1.FileName.EndsWith(".jpg") && !openFileDialog1.FileName.EndsWith(".png") && !openFileDialog1.FileName.EndsWith(".jpeg"))
                    resultText.Content = "Неверный формат изображения!";
                else
                {
                    ColorText.Text = "";
                    FileInfo fileInfo = new FileInfo(openFileDialog1.FileName);
                    long fileSizeInBytes = fileInfo.Length;
                    if (fileSizeInBytes < 10000)
                    {
                        resultText.Content = "Изображение загружено";
                        string content = "";
                        Bitmap bmp = new Bitmap(openFileDialog1.FileName);
                        for (int y = 0; y < bmp.Height; y++)
                        {
                            for (int x = 0; x < bmp.Width; x++)
                            {
                                Color pixelColor = bmp.GetPixel(x, y);
                                content += Convert.ToString("[color=#" + pixelColor.R.ToString("X2") + pixelColor.G.ToString("X2") + pixelColor.B.ToString("X2") + "]██");
                            }
                            content += "\n";
                        }
                        ColorText.Text = content;
                    }
                    else
                    { resultText.Content = "Файл слишком большой"; }
                }
            }
        }
    }
}