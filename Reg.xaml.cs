using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void ToMine_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }

        private void Tomine_Click(object sender, RoutedEventArgs e)
        {                       
            var login = log.Text;

            var pass = pas.Password;

            var context = new AppDbContext();

            var user_exists = context.Users.FirstOrDefault(x => x.Login == login && x.Password == pass);
            if (user_exists is not null)
            {
                MessageBox.Show("Такой пользователь уже существует!");
                return;
            }
            
            var user = new user { Login = login, Password = pass };
            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("Вы успешно зарегестрировались!");           
        }                
    }  
}

