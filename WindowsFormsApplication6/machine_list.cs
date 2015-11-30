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

namespace WindowsFormsApplication6
{
    public partial class machine_list : Form
    {
        public machine_list()
        {
            InitializeComponent();
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
            TreeNode node1 = new TreeNode();
            node1.Text = "一号设备";
            TreeNode node2 = new TreeNode();
            node2.Text = "二号设备";
            //二级
            TreeNode node11 = new TreeNode();
            node11.Text = "基本信息";
            TreeNode node12 = new TreeNode();
            node12.Text = "观测信息";
            TreeNode node21 = new TreeNode();
            node21.Text = "基本信息";
            TreeNode node22 = new TreeNode();
            node22.Text = "观测信息";
            //二级加入一级
            node1.Nodes.Add(node11);
            node1.Nodes.Add(node12);
            node2.Nodes.Add(node21);
            node2.Nodes.Add(node22);
            //一级加入根
            root.Nodes.Add(node1);
            root.Nodes.Add(node2);
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
            add_mschine add_new = new add_mschine();
            add_new.Show();
            //MessageBox.Show(message); 
        }
        private void index_Click(object sender, EventArgs e)
        {

        }

        private void gmap_Load(object sender, EventArgs e)
        {
            System.Random a = new Random(System.DateTime.Now.Millisecond);
            int RandKey = a.Next(10);
            System.Console.WriteLine("RandKey-----------------------------: {0}", RandKey);
            // Initialize map:    
            gmap.MapProvider = GMap.NET.MapProviders.GoogleChinaMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmap.MinZoom = 2;  //最小缩放
            gmap.MaxZoom = 17; //最大缩放
            gmap.Zoom = 5;     //当前缩放
            gmap.ShowCenter = false; //不显示中心十字点
            gmap.Position = new PointLatLng(32.064, 118.704); //地图中心位置：南京

            GMapOverlay objects = new GMapOverlay("objects"); //放置marker的图层
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(32.064, 118.704), GMarkerGoogleType.green);
            GMarkerGoogle marker1 = new GMarkerGoogle(new PointLatLng(32.064, 110.704), GMarkerGoogleType.green);
            objects.Markers.Add(marker);
            objects.Markers.Add(marker1);
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
            String message = "marker was clicked(经度：" + item.Position.Lng + ", 纬度：" + item.Position.Lat + ")" ;
            MessageBox.Show(message); 
        }
        void gmap_OnMarkerEnter(GMapMarker item)
        {
            String info = item.Position.Lat + " " + item.Position.Lng;
            this.toolTip1.SetToolTip(this.gmap, info);
        }
    }
}
