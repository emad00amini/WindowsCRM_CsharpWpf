using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE_CRM;
using System.IO;
using BLL_CRM;


namespace CRM
{
    public partial class userClick : Form
    {

        public userClick()
        {
            InitializeComponent();
        }




        OpenFileDialog openfiledialog = new OpenFileDialog();
        Image image;
        userBll userBll = new userBll();
        userGroupBll userGroupBll = new userGroupBll();

        public void EmptyTextboxes()
        {
            textBoxX1.Text = " ";
            textBoxX2.Text = " ";
            textBoxX3.Text = " ";
            textBoxX4.Text = " ";
            textBoxX5.Text = " ";

        }
        public void datagridviewReload()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = userBll.read();
            dataGridView1.Columns["id"].Visible = false;
        }
        int id;
        string savePath(string user)
        {
            string mainAddress = Path.GetDirectoryName(Application.ExecutablePath) + @"\UserPics\";
            if (!Directory.Exists(mainAddress))
            {
                Directory.CreateDirectory(mainAddress);
            }
            string picName = user + ".JPG";
            string picAddress = openfiledialog.FileName;
            File.Copy(picAddress, mainAddress + picName, true);
            return mainAddress + picName;
        }
        userAccessRole FillAccessRole(string section,bool canEnter,bool canCreate,bool canUpdate,bool canDelete)
        {
            userAccessRole userAccessRole = new userAccessRole();
            userAccessRole.section = section;
            userAccessRole.canCreate = canCreate;
            userAccessRole.canDelete = canDelete;
            userAccessRole.canEnter = canEnter;
            userAccessRole.canUpdate = canUpdate;

            return userAccessRole;
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openfiledialog.Filter = "JPG(*.JPG)|*.JPG";
            openfiledialog.Title = "انتخاب تصویر";
            if (openfiledialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(openfiledialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
           
            user user = new user();
            user.name = textBoxX1.Text;
            user.userName = textBoxX2.Text;
            user.regDate = DateTime.Now;

            if (textBoxX3.Text == textBoxX4.Text)
            {
                user.password = textBoxX3.Text;
            }
            else
            {
                MessageBox.Show("پسوورد ها همخوانی ندارند");
            }

            if (userBll.read(user)&& userGroupBll.read(textBoxX5.Text))
            {
                user.pic = savePath(textBoxX2.Text);
                MessageBox.Show(userBll.create(user,userGroupBll.readN(textBoxX5.Text)));
            }
            else
            {
                user.pic = savePath(textBoxX2.Text);
                MessageBox.Show(userBll.update(user, id));
            }
            EmptyTextboxes();
            datagridviewReload();

        }

        private void userClick_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.userGroups' table. You can move, or remove it, as needed.
            this.userGroupsTableAdapter.Fill(this.database1DataSet.userGroups);
            datagridviewReload();
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user u = userBll.read(id);

            textBoxX1.Text = u.name;
            textBoxX2.Text = u.userName;
            pictureBox1.Image = Image.FromFile(u.pic);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            label1.Text = "ویرایش اطلاعات";

        }



        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value);
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userBll.delete(id);
            datagridviewReload();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox8.Checked = true;
                checkBox12.Checked = true;
                checkBox16.Checked = true;
                checkBox20.Checked = true;
                checkBox24.Checked = true;
                checkBox28.Checked = true;
                checkBox32.Checked = true;
                checkBox36.Checked = true;
                checkBox40.Checked = true;

            }
            else
            {
                checkBox8.Checked = false;
                checkBox12.Checked = false;
                checkBox16.Checked = false;
                checkBox20.Checked = false;
                checkBox24.Checked = false;
                checkBox28.Checked = false;
                checkBox32.Checked = false;
                checkBox36.Checked = false;
                checkBox40.Checked = false;
            }
           
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox5.Checked = true;
                checkBox9.Checked = true;
                checkBox13.Checked = true;
                checkBox17.Checked = true;
                checkBox21.Checked = true;
                checkBox25.Checked = true;
                checkBox29.Checked = true;
                checkBox33.Checked = true;
                checkBox37.Checked = true;

            }
            else
            {
                checkBox5.Checked = false;
                checkBox9.Checked = false;
                checkBox13.Checked = false;
                checkBox17.Checked = false;
                checkBox21.Checked = false;
                checkBox25.Checked = false;
                checkBox29.Checked = false;
                checkBox33.Checked = false;
                checkBox37.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox6.Checked = true;
                checkBox10.Checked = true;
                checkBox14.Checked = true;
                checkBox18.Checked = true;
                checkBox22.Checked = true;
                checkBox26.Checked = true;
                checkBox30.Checked = true;
                checkBox34.Checked = true;
                checkBox38.Checked = true;

            }
            else
            {
                checkBox6.Checked = false;
                checkBox10.Checked = false;
                checkBox14.Checked = false;
                checkBox18.Checked = false;
                checkBox22.Checked = false;
                checkBox26.Checked = false;
                checkBox30.Checked = false;
                checkBox34.Checked = false;
                checkBox38.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox7.Checked = true;
                checkBox11.Checked = true;
                checkBox15.Checked = true;
                checkBox19.Checked = true;
                checkBox23.Checked = true;
                checkBox27.Checked = true;
                checkBox31.Checked = true;
                checkBox35.Checked = true;
                checkBox39.Checked = true;

            }
            else
            {
                checkBox7.Checked = false;
                checkBox11.Checked = false;
                checkBox15.Checked = false;
                checkBox19.Checked = false;
                checkBox23.Checked = false;
                checkBox27.Checked = false;
                checkBox31.Checked = false;
                checkBox35.Checked = false;
                checkBox39.Checked = false;
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            if (textBoxX10.Text.Trim()== "")
            {
                MessageBox.Show("نام گروه کاربری را وارد کنید");
            }
            else
            {
                userGroup ug = new userGroup();
                ug.title = textBoxX10.Text;
                ug.userAccessRoles.Add(FillAccessRole(label3.Text, checkBox8.Checked, checkBox5.Checked, checkBox6.Checked, checkBox7.Checked));
                ug.userAccessRoles.Add(FillAccessRole(label4.Text, checkBox12.Checked, checkBox9.Checked, checkBox10.Checked, checkBox11.Checked));
                ug.userAccessRoles.Add(FillAccessRole(label5.Text, checkBox16.Checked, checkBox13.Checked, checkBox14.Checked, checkBox15.Checked));
                ug.userAccessRoles.Add(FillAccessRole(label6.Text, checkBox20.Checked, checkBox17.Checked, checkBox18.Checked, checkBox19.Checked));
                ug.userAccessRoles.Add(FillAccessRole(label7.Text, checkBox24.Checked, checkBox21.Checked, checkBox22.Checked, checkBox23.Checked));
                ug.userAccessRoles.Add(FillAccessRole(label8.Text, checkBox28.Checked, checkBox25.Checked, checkBox26.Checked, checkBox27.Checked));
                ug.userAccessRoles.Add(FillAccessRole(label9.Text, checkBox32.Checked, checkBox29.Checked, checkBox30.Checked, checkBox31.Checked));
                ug.userAccessRoles.Add(FillAccessRole(label10.Text, checkBox36.Checked, checkBox33.Checked, checkBox34.Checked, checkBox35.Checked));
                ug.userAccessRoles.Add(FillAccessRole(label11.Text, checkBox40.Checked, checkBox37.Checked, checkBox38.Checked, checkBox39.Checked));
                MessageBox.Show(userGroupBll.Create(ug));
            }
            
           
        }
    }
}
