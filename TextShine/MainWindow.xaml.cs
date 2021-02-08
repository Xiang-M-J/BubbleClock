using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TextShine
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        string second = DateTime.Now.ToString("ss");
        string minute = DateTime.Now.ToString("mm");
        string hour = DateTime.Now.ToString("HH");
        int min = DateTime.Now.Minute;
        int hou = DateTime.Now.Hour;
        System.Timers.Timer timer = new System.Timers.Timer(1000);

        public MainWindow()
        {
            InitializeComponent();
            MainWindow_Loaded1(second);
            MainWindow_Loaded2(minute);
            MainWindow_Loaded3(hour);
            MainWindow_Loaded4();
            MainWindow_Loaded5();
            //MainWindow_Loaded6();
            //MainWindow_Loaded7();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;  
        }

        public void Recevie(string []Color)
        {
            Color color;
            try
            {
                color = (Color)ColorConverter.ConvertFromString(Color[0]);
                Border1.Background = new SolidColorBrush(color);
            }
            catch
            {
                //MessageBox.Show("Something Woring goes in the Back Color");
                color = (Color)ColorConverter.ConvertFromString("#00000000");
                Border1.Background = new SolidColorBrush(color);
            }

            try
            {
                color = (Color)ColorConverter.ConvertFromString(Color[1]);
                Border2.BorderBrush = new SolidColorBrush(color);
            }
            catch
            {
                //MessageBox.Show("Something Woring goes in the border Color");
                color = (Color)ColorConverter.ConvertFromString("#FF0092BC");
                Border2.BorderBrush = new SolidColorBrush(color);
            }

            try
            {
                
                color = (Color)ColorConverter.ConvertFromString(Color[2]);
                TextBlock1.Foreground = new SolidColorBrush(color);
            }
            catch
            {
                //MessageBox.Show("Something Woring goes in the Font Color");
                color = (Color)ColorConverter.ConvertFromString("#FF277AD4");
                TextBlock1.Foreground = new SolidColorBrush(color);
            }
            
            
        }


        private ParticleSystem ps;

        private void Image1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Image3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            this.Close();
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }

        }
        private void MainWindow_Loaded1(string time)
        {
            Geometry g = CreateTextPath(time, new Point(this.canva3.Margin.Left+15, this.canva3.Margin.Top-12), new Typeface(new FontFamily("微软雅黑"), FontStyles.Normal, FontWeights.UltraLight, FontStretches.Normal), 100);
            ps = new ParticleSystem(g, 4, 200, this.canva3);
        }
        private void MainWindow_Loaded2(string time)
        {
            Geometry g = CreateTextPath(time, new Point(this.canva2.Margin.Left + 18, this.canva2.Margin.Top - 12), new Typeface(new FontFamily("微软雅黑"), FontStyles.Normal, FontWeights.UltraLight, FontStretches.Normal), 100);
            ps = new ParticleSystem(g, 4, 200, this.canva2);
        }
        private void MainWindow_Loaded3(string time)
        {
            Geometry g = CreateTextPath(time, new Point(this.canva1.Margin.Left + 15, this.canva1.Margin.Top - 12), new Typeface(new FontFamily("微软雅黑"), FontStyles.Normal, FontWeights.UltraLight, FontStretches.Normal), 100);
            ps = new ParticleSystem(g, 4, 200, this.canva1);
        }
        private void MainWindow_Loaded4()
        {
            Geometry g = CreateTextPath(":", new Point(this.canvaDot1.Margin.Left , this.canvaDot1.Margin.Top -20), new Typeface(new FontFamily("微软雅黑"), FontStyles.Normal, FontWeights.UltraLight, FontStretches.Normal), 100);
            ps = new ParticleSystem(g, 4, 40, this.canvaDot1);
            
        }
        private void MainWindow_Loaded5()
        {
            Geometry g = CreateTextPath(":", new Point(this.canvaDot2.Margin.Left, this.canvaDot2.Margin.Top -20), new Typeface(new FontFamily("微软雅黑"), FontStyles.Normal, FontWeights.UltraLight, FontStretches.Normal), 100);
            ps = new ParticleSystem(g, 4, 40, this.canvaDot2);
        }
        //private void MainWindow_Loaded6()
        //{
        //    Geometry g = CreateTextPath(":", new Point(this.canvaDot11.Margin.Left, this.canvaDot11.Margin.Top + 20), new Typeface(new FontFamily("微软雅黑"), FontStyles.Normal, FontWeights.UltraLight, FontStretches.Normal), 200);
        //    ps = new ParticleSystem(g, 4, 80, this.canvaDot11);
        //}
        //private void MainWindow_Loaded7()
        //{
        //    Geometry g = CreateTextPath(":", new Point(this.canvaDot22.Margin.Left, this.canvaDot22.Margin.Top + 20), new Typeface(new FontFamily("微软雅黑"), FontStyles.Normal, FontWeights.UltraLight, FontStretches.Normal), 200);
        //    ps = new ParticleSystem(g, 4, 80, this.canvaDot22);
        //}

        private Geometry CreateTextPath(string word, Point point, Typeface typeface, int fontSize)
        {
            FormattedText text = new FormattedText(word, new System.Globalization.CultureInfo("en-US"), FlowDirection.LeftToRight, typeface, fontSize, Brushes.Black);
            Geometry g = text.BuildGeometry(point);
            PathGeometry path = g.GetFlattenedPathGeometry();
            return path;
        }
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //UI异步更新
            int NowMin = DateTime.Now.Minute;
            int NowHou = DateTime.Now.Hour;
            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
            {
               
                second = DateTime.Now.ToString("ss");
                MainWindow_Loaded1(second);
                if (min!= NowMin)
                {
                    MainWindow_Loaded2(DateTime.Now.ToString("mm"));
                    min = NowMin;
                }
                if(hou != NowHou)
                {
                    MainWindow_Loaded3(DateTime.Now.Hour.ToString("HH"));
                    hou = NowHou;
                }
            }));

        }
        //private bool IS_Change(int Now,int Former)
        //{
        //    if (Now != Former)
        //    {
        //        return true;
        //    }
        //    return false; 
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Setting Setting = new Setting() {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            Setting.sendMessage = Recevie;
            Setting.Show();
        }
    }
}
