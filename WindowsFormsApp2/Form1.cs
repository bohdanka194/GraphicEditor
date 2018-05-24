using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        bool loaded = false;
        int w;
        int h;
        double x_start = 0;
        double x_end = 250;
        double coeff_scale;
        double rotateX = 15;
        double rotateY = -30;
        double rotateZ = 7;
        int n = 1;
        int m = 1;
        int k = 1;
        Bitmap bmpTex;
        double AngleX;
        double AngleY;
        List<Node> nodes = new List<Node>();
        List<int> indexMiniCubes = new List<int>() { 0,1,2,3,4,5,6,7};
        private BitmapData bmpData;

        public Form1()
        {
            InitializeComponent();
            nodes = InitializeNodes();
        }
        private List<Node> ReWriteNodeAfterScale(List<Node> nodes, double coeff)
        {
            List<Node> list = new List<Node>();
            for (int i = 0; i < nodes.Count; i++)
            {
                list.Add(new Node(nodes[i].X * coeff,
                    nodes[i].Y * coeff,
                    nodes[i].Z * coeff
                    ));
            }
            return list;
        }
        private List<Node> InitializeNodes()
        {
            List<Node> list = new List<Node>();
            list.Add(new Node(x_start, x_start, x_start));
            list.Add(new Node(x_end, x_start, x_start));
            list.Add(new Node(x_end, x_start, x_end));
            list.Add(new Node(x_start, x_start, x_end));
            list.Add(new Node(x_start, x_end, x_start));
            list.Add(new Node(x_end, x_end, x_start));
            list.Add(new Node(x_end, x_end, x_end));
            list.Add(new Node(x_start, x_end, x_end));
            WriteDataGridView();
            AddItemComboBox(nodes.Count);
            return list;
        }
        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;
            SetupViewport();
           // if (checkBoxColorful.Checked==true)
            
        }
        private void buttonColorfulQuads_Click(object sender, EventArgs e)
        {
        //    this.Invalidate();
        //    glControl1.SwapBuffers();
            GL.Color3(Color.White);
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill); // line
            GL.Begin(BeginMode.Quads); 
            PaintQuads(0, 1, 2, 3);

            GL.Color3(Color.Red);
            GL.Begin(BeginMode.Quads);
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            PaintQuads(1, 5, 6, 2);
            //GL.End();

            GL.Color3(Color.Brown);
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            GL.Begin(BeginMode.Quads);
            PaintQuads(3, 7, 6, 2);
            //GL.End();

            GL.Color3(Color.Green);
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            GL.Begin(BeginMode.Quads);
            PaintQuads(3, 7, 4, 0);
            //GL.End();

            GL.Color3(Color.HotPink);
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            GL.Begin(BeginMode.Quads);
            PaintQuads(7, 6, 5, 4);
           GL.End();
            glControl1.SwapBuffers(); 
        }
        private void SetupViewport()
        {
            w = glControl1.Width;
            h = glControl1.Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-w, w, -h, h, -500, 500); // Верхний левый угол имеет кооординаты(0, 0)
                                               //    GL.Frustum(-w, w, -h, h, -50, 500);
            GL.Viewport(0, 0, w, h); // Использовать всю поверхность GLControl под рисование
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            NewMethod();
        }
        private void NewMethod()
        {
            Matrix4 mDim = new Matrix4();
            mDim.Row0 = new Vector4(1.0f, 0.0f, 0.0f, 0.0f);
            mDim.Row1 = new Vector4(0.0f, 1.0f, 0.0f, 0.0f);
            mDim.Row2 = new Vector4(0.0f, 0.0f, 1.0f, 0.0f);
            mDim.Row3 = new Vector4(0.0f, 0.0f, 0.0f, 1.0f);

            if (!loaded) //Пока контекст не создан
                return;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);


            GL.MatrixMode(MatrixMode.Modelview);
            // GL.LoadIdentity();
            //     GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref mDim);
            GL.Color3(Color.White);
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
                  
            GL.Enable(EnableCap.Light3); // джерела світла, 8 ламп 0..7
            GL.Light(LightName.Light3, LightParameter.Position, new float[] { 0.0f, 0.0f, 500.0f, 0.0f });
            // GL.Light(LightName.Light0, LightParameter.Diffuse, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
            GL.LightModel(LightModelParameter.LightModelLocalViewer, new float[] { 1.0f });

            GL.Enable(EnableCap.ColorMaterial);
            // will  be done GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Specular,m_mat_spec);
            PaintCube(rotateX, rotateY, rotateZ);
            
            glControl1.SwapBuffers();
        }

        private void glControl1_PaintCOPY(object sender, EventArgs e)
        {
            
            NewMethod();
        }

        private void PaintCube(double rotateX, double rotateY, double rotateZ)
        {
            GL.Rotate(rotateX, 1, 0, 0);
            GL.Rotate(rotateY, 0, 1, 0);
            GL.Rotate(rotateZ, 0, 0, 1);

            //GL.Translate(dx, dy, dz);

            nodes = InitializeNodes();
            GL.Color3(Color.White);
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line); // line
            GL.Begin(BeginMode.Quads);

            PaintQuads(0, 1, 2, 3);
            PaintQuads(1, 5, 6, 2);
            PaintQuads(3, 7, 6, 2);
            PaintQuads(3, 7, 4, 0);
            PaintQuads(7, 6, 5, 4);
            GL.End();
        }

        private void PaintQuads(int a, int b, int c, int d)
        {
            GL.Vertex3(nodes[a].X, nodes[a].Y, nodes[a].Z);
            GL.Vertex3(nodes[b].X, nodes[b].Y, nodes[b].Z);
            GL.Vertex3(nodes[c].X, nodes[c].Y, nodes[c].Z);
            GL.Vertex3(nodes[d].X, nodes[d].Y, nodes[d].Z);
        }

        private void DrawLinesCubes()
        {
            if (n > 1 || m > 1 || k > 1)
            {
                double[] pointsX = new double[n - 1];
                double[] pointsY = new double[m - 1];
                double[] pointsZ = new double[k - 1];
                for (int i = 0; i < pointsX.Length; i++)
                {
                    pointsX[i] = x_start + (x_end - x_start) * (i + 1) / n;
                }
                for (int i = 0; i < pointsY.Length; i++)
                {
                    pointsY[i] = x_start + (x_end - x_start) * (i + 1) / m;
                }
                for (int i = 0; i < pointsZ.Length; i++)
                {
                    pointsZ[i] = x_start + (x_end - x_start) * (i + 1) / k;
                }
                GL.Color3(Color.Blue);
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
                GL.Begin(BeginMode.Quads);

                for (int i = 0; i < pointsX.Length; i++)
                {
                    GL.Vertex3(pointsX[i], x_start, x_start);
                    GL.Vertex3(pointsX[i], x_start, x_end);
                    GL.Vertex3(pointsX[i], x_end, x_end);
                    GL.Vertex3(pointsX[i], x_end, x_start);
                }
                for (int i = 0; i < pointsY.Length; i++)
                {
                    GL.Vertex3(x_start, pointsY[i], x_start);
                    GL.Vertex3(x_start, pointsY[i], x_end);
                    GL.Vertex3(x_end, pointsY[i], x_end);
                    GL.Vertex3(x_end, pointsY[i], x_start);
                }
                for (int i = 0; i < pointsZ.Length; i++)
                {
                    GL.Vertex3(x_start, x_start, pointsZ[i]);
                    GL.Vertex3(x_start, x_end, pointsZ[i]);
                    GL.Vertex3(x_end, x_end, pointsZ[i]);
                    GL.Vertex3(x_end, x_start, pointsZ[i]);
                }
                GL.End();
            }
        }
        private void buttonDivideNMK_Click(object sender, EventArgs e)
        {
            n = int.Parse(textBoxN.Text);
            m = int.Parse(textBoxM.Text);
            k = int.Parse(textBoxK.Text);

            // avoid to add the same node. Create new list and add new nodes
            //nodes = InitializeNodes();

            int count_new_nodes = (n + 1) * (m + 1) * (k + 1);
            nodes = null;
            nodes = new List<Node>();
            for (double z = x_start; z <= x_end; z += (x_end - x_start) / k) 
            {
                for (double y = x_start; y <= x_end; y += (x_end - x_start) / m) 
                {
                    for (double x = x_start; x <= this.x_end; x += (this.x_end - x_start) / n) 
                    {
                        nodes.Add(new Node(x, y, z));
                    }
                }
            }
            
            glControl1.SwapBuffers();
            DrawLinesCubes();
            
            //this.Invalidate();
            glControl1.SwapBuffers();
            

            //for testing
            textBoxNodeCOunt.Text = nodes.Count.ToString();
            if (nodes.Count == (n + 1) * (m + 1) * (k + 1))
            {
                textBoxIsNormCount.Text = "true";
            }
            else
            {
                textBoxIsNormCount.Text = "falssse";
            }

            WriteDataGridView();
            AddItemComboBox(nodes.Count);
            
        }

        private void DrawMiniCube(Color color, int delta)
        {
            int[] cubes = new int[8];
            indexMiniCubes = null;
            indexMiniCubes = new List<int>();
            
            cubes[0] = (0 + (n + 1) * (m + 1) * (k - 1) + delta) % nodes.Count;
            cubes[1] = (1 + (n + 1) * (m + 1) * (k - 1) + delta) % nodes.Count;
            cubes[2] = (n + (n + 1) * (m + 1) * (k - 1) + 2 + delta) % nodes.Count;
            cubes[3] = (n + 1 + (n + 1) * (m + 1) * (k - 1) + delta) % nodes.Count;
            cubes[4] = ((n + 1) * (m + 1) + (n + 1) * (m + 1) * (k - 1) + delta) % nodes.Count;
            cubes[5] = ((n + 1) * (m + 1) + (n + 1) * (m + 1) * (k - 1) + 1 + delta) % nodes.Count;
            cubes[6] = ((n + 1) * (m + 2) + (n + 1) * (m + 1) * (k - 1) + 1 + delta) % nodes.Count;
            cubes[7] = ((n + 1) * (m + 2) + (n + 1) * (m + 1) * (k - 1) + delta) % nodes.Count;
            for (int i=0;i<8;i++)
            {
                indexMiniCubes.Add(cubes[i]);
            }
            GL.Color3(color);
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            GL.Begin(BeginMode.Quads);

            PaintQuads(cubes[4], cubes[7], cubes[6], cubes[5]);

            PaintQuads(cubes[0], cubes[1], cubes[5], cubes[4]);
            PaintQuads(cubes[4], cubes[7], cubes[3], cubes[0]);
            PaintQuads(cubes[7], cubes[6], cubes[2], cubes[3]);
            //    GL.End();
            //GL.Color3(Color.Red);
            //GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            //GL.Begin(BeginMode.Quads);
            PaintQuads(cubes[1], cubes[2], cubes[6], cubes[5]);

            //GL.Color3(color);
            //GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);


            GL.End();
            
        }
     private void WriteDataGridView()
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = i;
                dataGridView1.Rows[i].Cells[1].Value = nodes[i].X;
                dataGridView1.Rows[i].Cells[2].Value = nodes[i].Y;
                dataGridView1.Rows[i].Cells[3].Value = nodes[i].Z;
            }
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            coeff_scale = 1.2;
            x_end *= coeff_scale ;
            nodes = ReWriteNodeAfterScale(nodes, coeff_scale);
            
            glControl1_PaintCOPY(sender, e);
            buttonDivideNMK_Click(sender, e);
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            coeff_scale = 5.0 / 6;
            x_end *= coeff_scale ;
            nodes = ReWriteNodeAfterScale(nodes, coeff_scale);
            glControl1_PaintCOPY(sender, e);
            buttonDivideNMK_Click(sender, e);
        }

        private void buttonRotateXPlus_Click(object sender, EventArgs e)
        {
            rotateX += 10;
            glControl1_PaintCOPY(sender, e);
            buttonDivideNMK_Click(sender, e);
        }

        private void buttonRotateXMinus_Click(object sender, EventArgs e)
        {
            rotateX -= 10;
            glControl1_PaintCOPY(sender, e);
            buttonDivideNMK_Click(sender, e);
        }

        private void buttonRotateYPlus_Click(object sender, EventArgs e)
        {
            rotateY += 10;
            glControl1_PaintCOPY(sender, e);

            buttonDivideNMK_Click(sender, e);
        }

        private void buttonRotateYMinus_Click(object sender, EventArgs e)
        {
            rotateY -= 10;
            glControl1_PaintCOPY(sender, e);
            buttonDivideNMK_Click(sender, e);
        }

        private void buttonRotateZPlus_Click(object sender, EventArgs e)
        {
            rotateZ += 10;
            glControl1_PaintCOPY(sender, e);
            buttonDivideNMK_Click(sender, e);
        }

        private void buttonRotateZMinus_Click(object sender, EventArgs e)
        {
            rotateZ -= 10;
            glControl1_PaintCOPY(sender, e);
            buttonDivideNMK_Click(sender, e);
        }

        private void buttonSwapBuffers_Click(object sender, EventArgs e)
        {
            glControl1.SwapBuffers();
        }

        //private void glControl1_MouseClick(object sender, MouseEventArgs e)
        //{
        //    int x = e.X;
        //    int y = e.Y;

        //    textBoxXMouse.Text = x.ToString();
        //    textBoxYMouse.Text = y.ToString();
        //}
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            int indexNode = int.Parse(comboBoxChooseNode.SelectedItem.ToString());
            if (indexNode % (n+1) == n ) { indexNode -=1; }
            DrawMiniCube(Color.GreenYellow, indexNode);

            glControl1.SwapBuffers();
        }
        private void AddItemComboBox(int nodes_count)
        {
            comboBoxChooseNode.Items.Clear() ;
            for (int i = 0; i < nodes_count; i++)
            {
                comboBoxChooseNode.Items.Add(i);
            }
        }

        private void buttonTexture_Click(object sender, EventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            bmpTex = new Bitmap("C:\\Users\\bohdanka\\source\\repos\\WindowsFormsApp3\\WindowsFormsApp2\\asfalt.bmp");
            //bmpTex = new Bitmap("C:\\Users\\bohdanka\\source\\repos\\WindowsFormsApp3\\WindowsFormsApp2\\2.bmp");

            GLTexture.LoadTexture(bmpTex);
            GL.Enable(EnableCap.Texture2D);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.QuadTextureSelectSgis, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

           
            GL.TexCoord2(0, 0); GL.Vertex3(nodes[indexMiniCubes[2]].X, nodes[indexMiniCubes[2]].Y, nodes[indexMiniCubes[2]].Z);
            GL.TexCoord2(1, 0); GL.Vertex3(nodes[indexMiniCubes[6]].X, nodes[indexMiniCubes[6]].Y, nodes[indexMiniCubes[6]].Z);
            GL.TexCoord2(1, 1); GL.Vertex3(nodes[indexMiniCubes[7]].X, nodes[indexMiniCubes[7]].Y, nodes[indexMiniCubes[7]].Z);
            GL.TexCoord2(0, 1); GL.Vertex3(nodes[indexMiniCubes[3]].X, nodes[indexMiniCubes[3]].Y, nodes[indexMiniCubes[3]].Z);
            // Back Face
            GL.Color3(Color.Blue);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(nodes[indexMiniCubes[0]].X, nodes[indexMiniCubes[0]].Y, nodes[indexMiniCubes[0]].Z);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(nodes[indexMiniCubes[1]].X, nodes[indexMiniCubes[1]].Y, nodes[indexMiniCubes[1]].Z);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(nodes[indexMiniCubes[5]].X, nodes[indexMiniCubes[5]].Y, nodes[indexMiniCubes[5]].Z);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(nodes[indexMiniCubes[4]].X, nodes[indexMiniCubes[4]].Y, nodes[indexMiniCubes[4]].Z);
            // Top Face
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(nodes[indexMiniCubes[7]].X, nodes[indexMiniCubes[7]].Y, nodes[indexMiniCubes[7]].Z);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(nodes[indexMiniCubes[6]].X, nodes[indexMiniCubes[6]].Y, nodes[indexMiniCubes[6]].Z);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(nodes[indexMiniCubes[5]].X, nodes[indexMiniCubes[5]].Y, nodes[indexMiniCubes[5]].Z);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(nodes[indexMiniCubes[4]].X, nodes[indexMiniCubes[4]].Y, nodes[indexMiniCubes[4]].Z);
            // Bottom Face
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(nodes[indexMiniCubes[0]].X, nodes[indexMiniCubes[0]].Y, nodes[indexMiniCubes[0]].Z);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(nodes[indexMiniCubes[1]].X, nodes[indexMiniCubes[1]].Y, nodes[indexMiniCubes[1]].Z);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(nodes[indexMiniCubes[2]].X, nodes[indexMiniCubes[2]].Y, nodes[indexMiniCubes[2]].Z);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(nodes[indexMiniCubes[3]].X, nodes[indexMiniCubes[3]].Y, nodes[indexMiniCubes[3]].Z);
            // Right face
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(nodes[indexMiniCubes[5]].X, nodes[indexMiniCubes[5]].Y, nodes[indexMiniCubes[5]].Z);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(nodes[indexMiniCubes[6]].X, nodes[indexMiniCubes[6]].Y, nodes[indexMiniCubes[6]].Z);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(nodes[indexMiniCubes[2]].X, nodes[indexMiniCubes[2]].Y, nodes[indexMiniCubes[2]].Z);
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(nodes[indexMiniCubes[1]].X, nodes[indexMiniCubes[1]].Y, nodes[indexMiniCubes[1]].Z);
            // Left Face
            GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(nodes[indexMiniCubes[0]].X, nodes[indexMiniCubes[0]].Y, nodes[indexMiniCubes[0]].Z);
            GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(nodes[indexMiniCubes[4]].X, nodes[indexMiniCubes[4]].Y, nodes[indexMiniCubes[4]].Z);
            GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(nodes[indexMiniCubes[7]].X, nodes[indexMiniCubes[7]].Y, nodes[indexMiniCubes[7]].Z);
            GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(nodes[indexMiniCubes[3]].X, nodes[indexMiniCubes[3]].Y, nodes[indexMiniCubes[3]].Z);
            //GL.End();
            //glControl1.Invalidate();
            //glControl1.SwapBuffers();

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);


            //bmpTex.UnlockBits(bmpData);
            glControl1_PaintCOPY(sender, e);
            buttonDivideNMK_Click(sender, e);
        }

        
    }
}