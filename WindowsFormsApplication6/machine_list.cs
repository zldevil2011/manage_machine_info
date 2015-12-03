using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication6
{
    struct machine
    {
        public int id;
        public string machine_name;
        public string location;
        public string install_time;
        public double longitude;
        public double latitude;

    }
    public partial class machine_list : Form
    {
        private GMapMarkerImage currentMarker;
        private machine[] m_list = new machine[10000];
        public machine_list()
        {
            InitializeComponent();
            get_machine_list();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            load_TreeView();
        }
        private void load_TreeView()
        {
            treeView1.LabelEdit = true;
            //添加结点
            TreeNode root = new TreeNode();
            root.Name = "root";
            root.Text = "设备列表";
            //一级
            int len = m_list.Length;
            for (int cnt = 0; cnt < len; ++cnt)
            {
                TreeNode tmp = new TreeNode();
                tmp.Text = m_list[cnt].machine_name;
                root.Nodes.Add(tmp);
            }
            //TreeNode node1 = new TreeNode();
            //node1.Text = "一号设备";
            //TreeNode node2 = new TreeNode();
            //node2.Text = "二号设备";
            //二级
            //TreeNode node11 = new TreeNode();
            //node11.Text = "基本信息";
            //TreeNode node12 = new TreeNode();
            //node12.Text = "观测信息";
            //TreeNode node21 = new TreeNode();
            //node21.Text = "基本信息";
            //TreeNode node22 = new TreeNode();
            //node22.Text = "观测信息";
            //二级加入一级
            //node1.Nodes.Add(node11);
            //node1.Nodes.Add(node12);
            //node2.Nodes.Add(node21);
            ///node2.Nodes.Add(node22);
            //一级加入根
            //root.Nodes.Add(node1);
            //root.Nodes.Add(node2);
            treeView1.Nodes.Add(root);
            treeView1.MouseDown += new MouseEventHandler(treeView1_MouseDown);
            //gmap.OnMarkerClick += new MarkerClick(gmap_OnMarkerClick);
        }
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            System.Console.WriteLine("treeView1_MouseDown");
            if (e.Button == MouseButtons.Right)
            {
                Point ClickPoint = new Point(e.X, e.Y);
                TreeNode CurrentNode = treeView1.GetNodeAt(ClickPoint);
                if (CurrentNode != null)// && true == CurrentNode.Checked)//判断你点的是不是一个节点
                {
                    switch (CurrentNode.Name)//根据不同节点显示不同的右键菜单，当然你可以让它显示一样的菜单
                    {
                        case "root":
                            CurrentNode.ContextMenuStrip = contextMenuStrip1;
                            contextMenuStrip1.Click +=new EventHandler(contextMenuStrip1_Click);
                            System.Console.WriteLine("root was 右键");
                            break;
                        default:
                            System.Console.WriteLine("飞");
                            break;
                    }
                    treeView1.SelectedNode = CurrentNode;//选中这个节点
                }
            }
        }
        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            string message = "点击添加设备";
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            add_mschine add_new = new add_mschine();
            add_new.ShowDialog();//显示登陆窗体
            if (add_new.DialogResult == DialogResult.OK)
                return;
            else return;
            //ShowDialog(add_new);
            add_new.Show();
            //MessageBox.Show(message); 
        }
        private void index_Click(object sender, EventArgs e)
        {

        }

        private void gmap_Load(object sender, EventArgs e)
        {
            // Initialize map:    
            gmap.MapProvider = GMap.NET.MapProviders.GoogleChinaMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmap.MinZoom = 2;  //最小缩放
            gmap.MaxZoom = 17; //最大缩放
            gmap.Zoom = 5;     //当前缩放
            gmap.ShowCenter = false; //不显示中心十字点
            gmap.Position = new PointLatLng(32.064, 118.704); //地图中心位置：南京
            GMapOverlay objects = new GMapOverlay("objects"); //放置marker的图层
            int len = m_list.Length;
            for (int cnt = 0; cnt < len; ++cnt)
            {
                Bitmap bitmap = Bitmap.FromFile("C:\\Users\\dell\\Documents\\Visual Studio 2010\\Projects\\WindowsFormsApplication6\\WindowsFormsApplication6\\images\\water1.png") as Bitmap;
                //GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(m_list[cnt].longitude, m_list[cnt].latitude), bitmap);
                GMapMarkerImage marker = new GMapMarkerImage(new PointLatLng(m_list[cnt].longitude, m_list[cnt].latitude), bitmap);
                marker.id = m_list[cnt].id;
                marker.machine_name = m_list[cnt].machine_name;
                marker.location = m_list[cnt].location;
                marker.install_time = m_list[cnt].install_time;
                marker.longitude = m_list[cnt].longitude;
                marker.latitude = m_list[cnt].latitude;
                objects.Markers.Add(marker);
            }
            gmap.Overlays.Add(objects);


            GMapOverlay polyOverlay = new GMapOverlay("polygons");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(32.064, 118.704));
            points.Add(new PointLatLng(33.067, 118.707));
            points.Add(new PointLatLng(34.070, 120.710));
            points.Add(new PointLatLng(31.073, 119.713));
            GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
            polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
            polygon.Stroke = new Pen(Color.Red, 1);
            polyOverlay.Polygons.Add(polygon);
            gmap.Overlays.Add(polyOverlay);

            gmap.OnMarkerClick += new MarkerClick(gmap_OnMarkerClick);
            gmap.OnMarkerEnter += new MarkerEnter(gmap_OnMarkerEnter);

        }
        void gmap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (item is GMapMarkerImage)
            {
                currentMarker = null;
                GMapMarkerImage m = item as GMapMarkerImage;
                String info_i = "设备编号:" + m.id;
                info_i += "\n设备名称:" + m.machine_name;
                info_i += "\n设备位置:" + m.location;
                info_i += "\n安装时间:" + m.install_time;
                info_i += "\n位置经度:" + m.longitude;
                info_i += "\n位置纬度:" + m.latitude;
                MessageBox.Show(info_i); 
            }
            //String message = "marker was clicked(经度：" + item.Position.Lng + ", 纬度：" + item.Position.Lat + ")" ;
            //MessageBox.Show(message); 
        }
        void gmap_OnMarkerEnter(GMapMarker item)
        {
            if (item is GMapMarkerImage)
            {
                currentMarker = null;
                GMapMarkerImage m = item as GMapMarkerImage;
                String info_i = "设备编号:" + m.id;
                info_i += "\n设备名称:" + m.machine_name;
                info_i += "\n设备位置:" + m.location;
                info_i += "\n安装时间:" + m.install_time;
                info_i += "\n位置经度:" + m.longitude;
                info_i += "\n位置纬度:" + m.latitude;
                this.toolTip1.SetToolTip(this.gmap, info_i);
            }
            
            //String info = item.Position.Lat + " " + item.Position.Lng;
            //this.toolTip1.SetToolTip(this.gmap, info);
        }
        void get_machine_list()
        {
            int m_num = 0;
            string query = "select * from machine_info";
            MySqlConnection myConnection = new MySqlConnection("server=localhost;user id=root;password=root;database=machine;Charset=utf8");
            MySqlCommand myCommand = new MySqlCommand(query, myConnection);
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            MySqlDataReader myDataReader = myCommand.ExecuteReader();
            machine tmp = new machine();
            while (myDataReader.Read() == true)
            {
                tmp.id = int.Parse(myDataReader["id"].ToString());
                tmp.machine_name = myDataReader["machine_name"].ToString();
                tmp.location = myDataReader["location"].ToString();
                tmp.install_time = myDataReader["install_time"].ToString();
                tmp.longitude = double.Parse(myDataReader["longitude"].ToString());
                tmp.latitude = double.Parse(myDataReader["latitude"].ToString());
                m_list[m_num++] = tmp;
                System.Console.WriteLine(tmp);
            }
            myDataReader.Close();
            myConnection.Close();
        }
    }


    class GMapMarkerImage : GMapMarker
    {
        public int id;
        public string machine_name;
        public string location;
        public string install_time;
        public double longitude;
        public double latitude;
        private Image image;
        public Image Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                if (image != null)
                {
                    this.Size = new Size(image.Width, image.Height);
                }
            }
        }
        public GMapMarkerImage(GMap.NET.PointLatLng p, Image image)
            : base(p)
        {
            Size = new System.Drawing.Size(image.Width, image.Height);
            Offset = new System.Drawing.Point(-Size.Width / 2, -Size.Height / 2);
            this.image = image;
        }

        public override void OnRender(Graphics g)
        {
            if (image == null)
                return;
            Rectangle rect = new Rectangle(LocalPosition.X, LocalPosition.Y, Size.Width, Size.Height);
            g.DrawImage(image, rect);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }

}
