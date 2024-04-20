using System.Data;
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

namespace WpfApp2
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void ToRegBtn_Click(object sender, RoutedEventArgs e)
        {
            Reg reg = new Reg();
            reg.Show();
            this.Hide();
        }

        private void ToMineBtn_Click(object sender, RoutedEventArgs e)
        {           

            var login = log.Text;
            var password = pas.Password;

            var context = new AppDbContext();

            var user = context.Users.SingleOrDefault(x => x.Login == login && x.Password == password);
            if (user is null)
            {
                MessageBox.Show("Неправильный логин или пароль!");
                return;
            }

            MessageBox.Show("Вы успешно вошли в аккаунт!");

            mine mine = new mine();
            mine.Show();
            this.Hide();
        }              
    }
}