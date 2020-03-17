using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace HowlingWolf
{
    public partial class MainMenu : Form
    {

        public MainMenu()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            ShowAdding();

        }

        private void NewsButton_Click(object sender, EventArgs e)
        {
           
        }
        
        private void ShowCommand()
        {
            AddingPanel.Hide();
            CommandPanel.Show();
           
        }
        
        private void ShowAdding()
        {
            CommandPanel.Hide();
            AddingPanel.Show();
        }

        int count = 0;
      private   Static @static = new Static();

        private void AddingItem(int count)
        {
            

            using (SqlConnection connection = new SqlConnection(@static.connectionString))
            {

                Label labelUp = new Label();
                labelUp.Text ="Команды";
                labelUp.Name ="CommandLabel";
                labelUp.BackColor = Color.Transparent;
                labelUp.AutoSize = false;
                labelUp.Height = 40;
                labelUp.Width = 200;
                labelUp.Font = new Font("Comic Sans MS", 20, FontStyle.Bold);
                labelUp.Location = new Point(/*(NewsPanel.Width  /2)-(labelUp.Width /2)*/5,15);
                CommandPanel.Controls.Add(labelUp);

                connection.Open();
                string sqlExpression = @"Select * from dbo.Organization;";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    int x=35, y=5+labelUp.Height +labelUp.Top;
                    {
                        while (reader.Read())
                        {
                            count++;
                            Panel panel = new Panel();

                            
                            panel.BackColor = Color.Transparent;
                            panel.Width = 215;
                            panel.Height = 250;
                            panel.Location = new Point(x,y );
                            panel.Name = "Panel" + (reader["Name"].ToString()).Trim();
                            panel.BackgroundImage = ResourcePicture.item2 ;
                            panel.Cursor = Cursors.Hand;


                            PictureBox image = new PictureBox();
                            string Logo = reader["Logo"].ToString().Trim() ;
                            image.Image = Image.FromFile(@static.Path +Logo);
                            image.Name = (reader["Name"].ToString()).Trim() + "PictureBox";
                            image.Location = new Point(10, 35);
                            image.Height = 150;
                            image.Width = 200;
                            image.SizeMode = PictureBoxSizeMode.Zoom;
                            panel.Controls.Add(image);

                            Label label = new Label();

                            label.Text = reader["Name"].ToString().Trim ();
                            label.Name = reader["Name"].ToString()+"label";
                            label.BackColor = Color.Transparent;
                            label.AutoSize = false;
                            label.Height = 30;
                            label.Width = 200;
                            label.Font = new Font("Sitka", 16, FontStyle.Bold);
                            
                            
                            panel.Cursor = Cursors.Hand;
                            label.Location = new Point(image.Left, image.Top+image.Height+15);
                            panel.Controls.Add(label);

                            CommandPanel.Controls.Add(panel);

                            if (count == 13)
                            {
                                Panel  picture = new Panel();
                                picture.BackColor = Color.Transparent;
                                picture.Location = new Point(panel.Left, y+260);
                                picture.Height = 40;
                                CommandPanel.Controls.Add(picture);
                            }

                            if (count % 3 == 0)
                            {
                                x=35;
                                y +=260;
                            }else
                            {
                                x += 230;

                            }
                        }
                        
                    }
                   
                }
                reader.Close();
                connection.Close();
                
            }
            CommandPanel.Height += 30;
        }

        private void MainMenu_Load_1(object sender, EventArgs e)/*Компановка стилей панелей*/
        {


            AddingItem(0);

            ShowCommand();



            CommandPanel.BackgroundImage = ResourcePicture.Back2;
            
            CommandPanel.Height = this.Height -UpPanel.Height;
            CommandPanel.Width = this.Width - PanelMenu.Width;
            CommandPanel.Top = UpPanel.Height;
            CommandPanel.Left = PanelMenu.Width;
            

            AddingPanel.BackgroundImage = ResourcePicture._123;

            AddingPanel.Top = CommandPanel.Top;
            AddingPanel.Left = CommandPanel.Left;
            AddingPanel.Width = CommandPanel.Width;
            AddingPanel.Height = CommandPanel.Height;

          

            CommandPanel.VerticalScroll.Visible = true;

        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            ShowCommand();
        }

        private void NewsButton_Click_1(object sender, EventArgs e)
        {
          
        }
    }


}
