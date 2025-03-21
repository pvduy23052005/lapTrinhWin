using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn1
{

    public partial class frmthucan : Form
    {
        ketnoi db = new ketnoi();
        public Color x;
        public frmthucan()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmthucan_Load(object sender, EventArgs e)
        {
            DataTable dt = db.dsquanan("select * from Food,FoodCategory where Food.idCategory = FoodCategory.id;");
            dataviewthucdon.DataSource = dt;
            dataviewthucdon.Columns[0].Visible = false;
            dataviewthucdon.Columns[2].Visible = false;
            dataviewthucdon.Columns[4].Visible = false;
            DataTable ds = db.dsquanan("select * from FoodCategory ");//lay du lieuj cho cômbox
            cbtimfood.DataSource = ds;
            cbtimfood.DisplayMember = "name";
            cbtimfood.ValueMember = "id";
            DataTable dss = db.dsquanan("select * from FoodCategory ");
            cbdanhmuc.DataSource = dss;
            cbdanhmuc.DisplayMember = "name";
            cbdanhmuc.ValueMember = "id";



            k++;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = db.dsquanan("select id from FoodCategory where name = N'" + cbdanhmuc.Text + "'");
            string x = dt.Rows[0]["id"].ToString();
            int g = Convert.ToInt32(x);
            MessageBox.Show(g.ToString());
            db.dsupdate("insert into Food (name, idCategory, price) values(N'" + tbten.Text + "','" + g + "','" + tbgia.Text + "')");
            DataTable dtt = db.dsquanan("select * from Food,FoodCategory where Food.idCategory = FoodCategory.id;");
            dataviewthucdon.DataSource = dtt;
            dataviewthucdon.Columns[0].Visible = false;
            dataviewthucdon.Columns[2].Visible = false;
            dataviewthucdon.Columns[4].Visible = false;


        }

        private void cbdanhmuc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataviewthucdon_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            tbid.Text = dataviewthucdon.CurrentRow.Cells[0].Value.ToString();
            tbten.Text = dataviewthucdon.CurrentRow.Cells[1].Value.ToString();
            tbgia.Text = dataviewthucdon.CurrentRow.Cells[3].Value.ToString();
            cbdanhmuc.Text = dataviewthucdon.CurrentRow.Cells[5].Value.ToString();
        }

        private void lbtim_Click(object sender, EventArgs e)
        {

            DataTable dt = db.dsquanan("select * from Food,FoodCategory where Food.idCategory = FoodCategory.id;");
            dataviewthucdon.DataSource = dt;
            dataviewthucdon.Columns[0].Visible = false;
            dataviewthucdon.Columns[2].Visible = false;
            dataviewthucdon.Columns[4].Visible = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {

            //DialogResult dn =    MessageBox.Show("bạn có muốn thoát không?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if(dn == DialogResult.Yes)
            //  {
            Close();
            // }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable x = db.dsquanan("select id from FoodCategory where name = N'" + cbdanhmuc.Text + "'");
            string g = x.Rows[0]["id"].ToString();
            int h = Convert.ToInt32(g);
            MessageBox.Show(h.ToString());
            db.dsupdate("update Food set name = N'" + tbten.Text + "',price = '" + tbgia.Text + "',idCategory = '" + h + "' where id = '" + tbid.Text + "'");
            DataTable dtt = db.dsquanan("select * from Food,FoodCategory where Food.idCategory = FoodCategory.id;");
            dataviewthucdon.DataSource = dtt;
            dataviewthucdon.Columns[0].Visible = false;
            dataviewthucdon.Columns[2].Visible = false;
            dataviewthucdon.Columns[4].Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            db.dsupdate("delete from food where food.id = '" + tbid.Text + "'");
            DataTable dt = db.dsquanan("select * from Food,FoodCategory where Food.idCategory = FoodCategory.id;");
            dataviewthucdon.DataSource = dt;
            dataviewthucdon.Columns[0].Visible = false;
            dataviewthucdon.Columns[2].Visible = false;
            dataviewthucdon.Columns[4].Visible = false;
        }
        int k = 0;
        private void cbtimfood_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (k != 0)
            {
                DataTable dt = db.dsquanan("select * from Food,FoodCategory where Food.idCategory = FoodCategory.id and FoodCategory.name = N'" + cbtimfood.Text + "'");
                dataviewthucdon.DataSource = dt;
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void button1_Leave(object sender, EventArgs e)
        {

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
        }

        private void button1_MouseEnter_1(object sender, EventArgs e)
        {

        }

        private void doimau(object sender, EventArgs e)
        {
            Button bt = (Button)sender;

            bt.Tag = bt.BackColor;

            if (bt != btdong) bt.BackColor = Color.ForestGreen;
            else bt.BackColor = Color.Red;
        }

        private void roimau(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            bt.BackColor = (Color)bt.Tag;



        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void grthucdon_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {



        }
    }
}
