using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace graphicTrees
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }
        int width, height;
        WriteableBitmap frame;
        private void ViewPort_Loaded(object sender, RoutedEventArgs e)
        {
            width = (int)this.ViewPortContainer.ActualWidth;
            height = (int)this.ViewPortContainer.ActualHeight;

            frame = BitmapFactory.New(width, height);
            ViewPort.Source = frame;
            List<Branch> Branches = new List<Branch>();
            Branch bottom = new Branch((width / 2), height, 0, 50, 200);
            Branches.Add(bottom);

            frame.DrawLine(bottom.posX, bottom.posY, bottom.posX, height - bottom.length, Branch.color);
            bottom.setEndPoint(bottom.posX, height - bottom.length);
            //System.Diagnostics.Debug.WriteLine(Math.Sin(60.0* Math.PI / 180));
            //System.Diagnostics.Debug.WriteLine(bottom.posX+ " " + bottom.posY + " " + bottom.posX + " " + (bottom.posY + bottom.length));
            int counter = 0;
            int branchesCount;
            List<Branch> newBranches;
            int numToRemove;
            int index;
            while(Branches.Count > 0 && counter < 4)
            {
                branchesCount = Branches.Count;
                newBranches = new List<Branch>();
                if (branchesCount > 4)
                {
                    index = 0;
                    numToRemove = (branchesCount / 2);
                    for (int i = 0; i <= numToRemove; i++)
                    {
                        index = new Random().Next(0, (branchesCount - 1));
                        for (int x = 0; x < 6; x++)
                        {
                            frame.DrawEllipseCentered(Branches.ElementAt(index).posX, Branches.ElementAt(index).posY, x, x, Colors.Green);
                        }
                        Branches.RemoveAt(index);
                        branchesCount--;
                    }
                }
                
                foreach (var b in Branches)
                {
                    for (int i = 0; i < (branchesCount * 2); i++)
                    {
                        newBranches.Add(new Branch(b.posX, b.posY));
                    }
                }

                Branches = newBranches;
                branchesCount = Branches.Count;


                foreach (var b in Branches)
                {
                    int oldX = b.posX;
                    int oldY = b.posY;

                    b.setEndPoint();

                    int newX = b.posX;
                    int newY = b.posY;

                    frame.DrawLine(oldX, oldY, newX, newY, Branch.color);
                }
                
                
                
                counter++;
            }
            index = 0;
            foreach (var b in Branches)
            {
                for(int i = 0; i < 6; i++)
                {
                    frame.DrawEllipseCentered(Branches.ElementAt(index).posX, Branches.ElementAt(index).posY, i, i, Colors.Green);
                }
                index++;
            }
        }
    }
}
