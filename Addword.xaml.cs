using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

namespace applernnewwords
{
    /// <summary>
    /// Логика взаимодействия для Addword.xaml
    /// </summary>
    public partial class Addword : Window
    {
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
        public Addword()
        {
            InitializeComponent();
        }

        private void myword_Click(object sender, RoutedEventArgs e)
        {
            Myword k = new Myword();
            this.Close();
            k.Show();
        }

        private void newword_Click(object sender, RoutedEventArgs e)
        {
            Enwords y = new Enwords();
            this.Close();
            y.Show();
        }

        private void proprog_Click(object sender, RoutedEventArgs e)
        {
            Proprog j = new Proprog();
            this.Close();
            j.Show();
        }

        private void sett_Click(object sender, RoutedEventArgs e)
        {
            Settp k = new Settp();
            this.Close();
            k.Show();
        }

        private void ireg_Click(object sender, RoutedEventArgs e)
        {
            Iragwen h = new Iragwen();
            this.Close();
            h.Show();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (ukrword.Text == "" && englword.Text == "") { erreor.Content = "                 введіть слова"; }
            else if (ukrword.Text == "") { erreor.Content = "            введіть українське слово"; }
            else if (englword.Text == "") { erreor.Content = "            введіть англійське слово"; }
            else
            {
                 
                MessageBox.Show("слово додано!");
                erreor.Content = "    ";
                Myword g = new Myword();
                this.Close();
                g.Show();



                string cs = @"server=localhost;userid=admin;password=admin;database=word";

              
                string CommandText = "INSERT INTO words (ukr,en) VALUES ('" + ukrword.Text + "','" + englword.Text + "');";
                    using (MySqlConnection myConnection = new MySqlConnection(cs))
                    {

                        using (MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection))
                        {

                            myConnection.Open();

                            myCommand.ExecuteNonQuery();

                        }
                    }
                
            }
        }
      
    }
}
