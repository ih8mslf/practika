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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp2;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для mine.xaml
    /// </summary>
    public partial class mine : Window
    {
        public mine()
        {
            InitializeComponent();

            var context = new AppDbContext();

            DataGridBox.ItemsSource = context.Users.ToList();
        }

        private void Button_Click(object sender, SelectionChangedEventArgs e)
        {
            var user = new user { Login = "123", Password = "123" };
            var context = new AppDbContext();
            context.Users.Add(user);
            context.SaveChanges();

            DataGridBox.ItemsSource = context.Users.ToList();
        }      
    }
}



