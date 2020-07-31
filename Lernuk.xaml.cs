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
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;

namespace applernnewwords
{
    /// <summary>
    /// Логика взаимодействия для Lernuk.xaml
    /// </summary>
    public partial class Lernuk : Window
    {
        public Lernuk()
        {
            InitializeComponent();
            englbutton.Visibility = Visibility.Hidden;
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow o = new MainWindow();
            o.Show();
            this.Close();
        }

        private void ireg_Click(object sender, RoutedEventArgs e)
        {

            Iragwen q = new Iragwen();
            this.Close();
            q.Show();
        }

        private void myword_Click(object sender, RoutedEventArgs e)
        {
            Myword k = new Myword();
            k.Show();
            this.Close();
        }

        

       

        private void R1_Click(object sender, RoutedEventArgs e)
        {
            englbutton.Visibility = Visibility.Visible;
            text.Content = "натисніть на слово щоб побатити переклад";

            string cs = @"server=localhost;userid=admin;password=admin;database=word";

            int uk = 1;
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cs))
                {
                    uk++;

                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM words WHERE id = 8 ", cn))
                    {

                        cn.Open();

                        using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        {

                            if (dataReader.HasRows)
                            {

                                while (dataReader.Read())
                                {
                                    englbutton.Content = (dataReader.GetString(1));
                                }

                            }
                        }
                    }
                }

            }
            catch {
                englbutton.Visibility = Visibility.Hidden;
                MessageBox.Show("Ой, виникла якась проблема");
            }

        }

        private void newword_Click(object sender, RoutedEventArgs e)
        {
            Enwords h = new Enwords();
            h.Show();
            this.Close();
        }

        private void proprog_Click(object sender, RoutedEventArgs e)
        {
            Proprog j = new Proprog();
            this.Close();
            j.Show();
        }

        private void sett_Click(object sender, RoutedEventArgs e)
        {
            Settp p = new Settp();
            this.Close();
            p.Show();
        }

        private void englbutton_Click(object sender, RoutedEventArgs e)
        {

            string cs = @"server=localhost;userid=admin;password=admin;database=word";

            int id = 1;
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cs))
                {

                    id++;

                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM words WHERE id= 8", cn))
                    {

                        cn.Open();

                        using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        {

                            if (dataReader.HasRows)
                            {

                                while (dataReader.Read())
                                {
                                    ukrlabel.Content = (dataReader.GetString(2));
                                }

                            }
                        }
                    }
                }
            }

            catch {
               
                MessageBox.Show("Ой, виникла якась проблема");
            }    
            
            }
    }
}
