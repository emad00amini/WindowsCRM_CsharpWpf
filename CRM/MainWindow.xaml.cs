using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Effects;
using BE_CRM;
using BLL_CRM;
namespace CRM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

      public  user u = new user();
        public userBll userBll = new userBll();
        public MainWindow()
        {
            loginForm f = new loginForm();
            InitializeComponent();
            OpenWinForm(f);
        }

        void OpenWinForm(Form f)
        {
            BlurEffect bme = new BlurEffect();
            this.Effect = bme;
            bme.Radius = 15;
            f.ShowDialog();
            Effect = null;

        }
        void openform(Form form)
        {
            Window window = this.FindName("main") as Window;
            BlurBitmapEffect blurbitmapeffect = new BlurBitmapEffect();
            blurbitmapeffect.Radius = 20;
            window.BitmapEffect = blurbitmapeffect;
            form.ShowDialog();
            blurbitmapeffect.Radius = 0;
            window.BitmapEffect = blurbitmapeffect;

        }
        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ( userBll.Access(u, "مدیریت مشتری", 1) )
            {
                customersClick form = new customersClick();
                openform(form);
            }
            else
            {
                System.Windows.MessageBox.Show("دسترسی نداری");
            }


        }
        private void user_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            userClick form = new userClick();
            openform(form);


        }



        private void product_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ProductsClick form = new ProductsClick();
            openform(form);


        }
        private void factor_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FactorClick form = new FactorClick();
            openform(form);


        }
        private void activity_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ActivityClick form = new ActivityClick();
            openform(form);



        }
        private void reminder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AlarmClick form = new AlarmClick();
            openform(form);



        }
        private void setting_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            settingClick form = new settingClick();
            openform(form);



        }



    }
}
