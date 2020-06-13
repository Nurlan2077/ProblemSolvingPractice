using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using static Practice.Task4;

namespace Task4_App
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        // Вычисляет значение по нажатие на кнопку.
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            // Проверяет поля на пустоту.
            if (AccuracyTextBox.Text.Trim() == ""
                || LeftBorder.Text.Trim()   == ""
                || RightBorder.Text.Trim()  == "")
            {
                MessageBox.Show("Заполните все поля вещественными числами, для разделения используйте ','.");
            }
            else
            {
                // Вычисляет значение с заданной точностью и границами.
                Result.Content = FindRoot(double.Parse(AccuracyTextBox.Text),
                                 double.Parse(LeftBorder.Text),
                                 double.Parse(RightBorder.Text));
            }

        }


        // Ограничивает ввод пользователя только вещественными числами.
        private void AccuracyTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[0-9]*(?:\,[0-9]*)?$");
            e.Handled = !regex.IsMatch(e.Text);
        }
    }
}
