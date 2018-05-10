﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        bool loaded = false;
        int w;
        int h;
        double n0 = 0;
        double n100 = 200;
        double coeff_scale;
        double rotateX = 15;
        double rotateY = -30;
        double rotateZ = 0;
        int n = 1;
        int m = 1;
        int k = 1;
        List<Node> nodes = new List<Node>();
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
            list.Add(new Node(n0, n0, n0));
            list.Add(new Node(n100, n0, n0));
            list.Add(new Node(n100, n0, n100));
            list.Add(new Node(n0, n0, n100));
            list.Add(new Node(n0, n100, n0));
            list.Add(new Node(n100, n100, n0));
            list.Add(new Node(n100, n100, n100));
            list.Add(new Node(n0, n100, n100));
            WriteDataGridView();
            AddItemComboBox(nodes.Count);
            return list;
        }
        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;
            SetupViewport();
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

            // x,y,z,a : a - однорідні координати а =1, а = 0 - у безмежності
            // нормаль,модель освітлення, джерело світла, параметри світла 
            // туман fog колір плафона FogDensity FogHint - пунктирно лінії
            // f = (e-z):(e-s) - FogMode.Linear ) isnye exp, exp2
            // z - відстань від об'єкта до плафона
            // e - end point
            // s - start point
            // математик освещение гугл

            // некст -  матеріал, текстура
            // енд - тінь малювати 
            // GL.Enable(EnableCap.Lighting);       //штори                     
            GL.Enable(EnableCap.Light0); // джерела світла, 8 ламп 0..7
            GL.Light(LightName.Light0, LightParameter.Position, new float[] { 0.0f, 0.0f, 500.0f, 1.0f });
            // GL.Light(LightName.Light0, LightParameter.Diffuse, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
            GL.LightModel(LightModelParameter.LightModelLocalViewer, new float[] { 1.0f });

            GL.Enable(EnableCap.ColorMaterial);
            // will  be done GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Specular,m_mat_spec);
            PaintCube(rotateX, rotateY, rotateZ);

            glControl1.SwapBuffers();
        }

        private void glControl1_PaintCOPY(object sender, EventArgs e)
        {
            //Matrix4 mDim;

            //mDim = new Matrix4();
            //mDim.Row0 = new Vector4(1.0f, 0.0f, 0.0f, 0.0f);
            //mDim.Row1 = new Vector4(0.0f, 1.0f, 0.0f, 0.0f);
            //mDim.Row2 = new Vector4(0.0f, 0.0f, 1.0f, 0.0f);
            //mDim.Row3 = new Vector4(0.0f, 0.0f, 0.0f, 1.0f);

            //if (!loaded) //Пока контекст не создан
            //    return;

            //GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //GL.MatrixMode(MatrixMode.Modelview);
            //GL.LoadMatrix(ref mDim);
            //GL.Color3(Color.White);
            //GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);

            //GL.Enable(EnableCap.Light0); // джерела світла, 8 ламп 0..7
            //GL.Light(LightName.Light0, LightParameter.Position, new float[] { 0.0f, 0.0f, 500.0f, 1.0f });
            ////     GL.Light(LightName.Light0, LightParameter.Diffuse, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
            //GL.LightModel(LightModelParameter.LightModelLocalViewer, new float[] { 1.0f });

            //GL.Enable(EnableCap.ColorMaterial);
            //// will  be done GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Specular,m_mat_spec);
            //PaintCube(rotateX,rotateY,rotateZ);

            //glControl1.SwapBuffers();
            
            NewMethod();
        }

        private void PaintCube(double rotateX, double rotateY, double rotateZ)
        {
            GL.Rotate(rotateY, 0, 1, 0);
            GL.Rotate(rotateX, 1, 0, 0);
            GL.Rotate(rotateZ, 0, 0, 1);
            //GL.Translate(50, 50, 0);
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
                    pointsX[i] = n0 + (n100 - n0) * (i + 1) / n;
                }
                for (int i = 0; i < pointsY.Length; i++)
                {
                    pointsY[i] = n0 + (n100 - n0) * (i + 1) / m;
                }
                for (int i = 0; i < pointsZ.Length; i++)
                {
                    pointsZ[i] = n0 + (n100 - n0) * (i + 1) / k;
                }
                GL.Color3(Color.Blue);
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
                GL.Begin(BeginMode.Quads);

                for (int i = 0; i < pointsX.Length; i++)
                {
                    GL.Vertex3(pointsX[i], n0, n0);
                    GL.Vertex3(pointsX[i], n0, n100);
                    GL.Vertex3(pointsX[i], n100, n100);
                    GL.Vertex3(pointsX[i], n100, n0);
                }
                for (int i = 0; i < pointsY.Length; i++)
                {
                    GL.Vertex3(n0, pointsY[i], n0);
                    GL.Vertex3(n0, pointsY[i], n100);
                    GL.Vertex3(n100, pointsY[i], n100);
                    GL.Vertex3(n100, pointsY[i], n0);
                }
                for (int i = 0; i < pointsZ.Length; i++)
                {
                    GL.Vertex3(n0, n0, pointsZ[i]);
                    GL.Vertex3(n0, n100, pointsZ[i]);
                    GL.Vertex3(n100, n100, pointsZ[i]);
                    GL.Vertex3(n100, n0, pointsZ[i]);
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
            for (double z = n0; z <= n100; z += (n100 - n0) / k) 
            {
                for (double y = n0; y <= n100; y += (n100 - n0) / m) 
                {
                    for (double x = n0; x <= n100; x += (n100 - n0) / n) 
                    {
                        nodes.Add(new Node(x, y, z));
                    }
                }
            }


            glControl1.SwapBuffers();
            DrawLinesCubes();


            glControl1.SwapBuffers();
            //DrawMiniCube(Color.YellowGreen,n, m,0);

            //if (n > 1)
            //{
            //    double[] pointsX = new double[n - 1];
            //    for (int i = 0; i < pointsX.Length; i++)
            //    {
            //        pointsX[i] = n0 + (n100 - n0) * (i + 1) / n;
            //    }
            //    GL.Color3(Color.Red);
            //    GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            //    GL.Begin(BeginMode.Quads);

            //    for (int i = 0; i < pointsX.Length; i++)
            //    {
            //        int countFirst = nodes.Count;
            //        nodes.Add(new Node(pointsX[i], n0, n0));
            //        nodes.Add(new Node(pointsX[i], n0, n100));
            //        nodes.Add(new Node(pointsX[i], n100, n100));
            //        nodes.Add(new Node(pointsX[i], n100, n0));
            //        PaintQuads(countFirst, countFirst + 1, countFirst + 2, countFirst +3);
            //    }
            //    GL.End();

            //}
            //if (m > 1)
            //{
            //    double[] pointsY = new double[m - 1];
            //    for (int i = 0; i < pointsY.Length; i++)
            //    {
            //        pointsY[i] = n0 + (n100 - n0) * (i + 1) / m;
            //    }
            //    GL.Color3(Color.Green);
            //    GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            //    GL.Begin(BeginMode.Quads);

            //    for (int i = 0; i < pointsY.Length; i++)
            //    {
            //        int countFirst = nodes.Count;
            //        nodes.Add(new Node(n0,pointsY[i], n0));
            //        nodes.Add(new Node(n0,pointsY[i], n100));
            //        nodes.Add(new Node(n100,pointsY[i], n100));
            //        nodes.Add(new Node(n100,pointsY[i],  n0));
            //        PaintQuads(countFirst, countFirst + 1, countFirst + 2, countFirst + 3);
            //    }
            //    GL.End();

            //}
            //if (k > 1)
            //{
            //    double[] pointsZ = new double[k - 1];
            //    for (int i = 0; i < pointsZ.Length; i++)
            //    {
            //        pointsZ[i] = n0 + (n100 - n0) * (i + 1) / k;
            //    }
            //    GL.Color3(Color.Blue);
            //    GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            //    GL.Begin(BeginMode.Quads);

            //    for (int i = 0; i < pointsZ.Length; i++)
            //    {
            //        int countFirst = nodes.Count;
            //        nodes.Add(new Node(n0, n0, pointsZ[i]));
            //        nodes.Add(new Node(n0, n100, pointsZ[i]));
            //        nodes.Add(new Node(n100, n100, pointsZ[i]));
            //        nodes.Add(new Node(n100, n0, pointsZ[i]));
            //        PaintQuads(countFirst, countFirst + 1, countFirst + 2, countFirst + 3);
            //    }
            //    GL.End();

            //}

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
            //glControl1.Refresh();


        }

        private void DrawMiniCube(Color color, int n, int m, int delta)
        {
            int[] cubes = new int[8];
            cubes[0] = (0 + delta) % nodes.Count;
            cubes[1] = (1 + delta) % nodes.Count;
            cubes[2] = (n + 2 + delta) % nodes.Count;
            cubes[3] = (n + 1 + delta) % nodes.Count;
            cubes[4] = ((n + 1) * (m + 1) + delta) % nodes.Count;
            cubes[5] = ((n + 1) * (m + 1) + 1 + delta) % nodes.Count;
            cubes[6] = ((n + 1) * (m + 2) + 1 + delta) % nodes.Count;
            cubes[7] = ((n + 1) * (m + 2) + delta) % nodes.Count;

            GL.Color3(color);
               GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
               GL.Begin(BeginMode.Quads);
            PaintQuads(cubes[0], cubes[1], cubes[5], cubes[4]);
            PaintQuads(cubes[1], cubes[2], cubes[6], cubes[5]);
            PaintQuads(cubes[4], cubes[7], cubes[6], cubes[5]);
            PaintQuads(cubes[4], cubes[7], cubes[3], cubes[0]);
            PaintQuads(cubes[7], cubes[6], cubes[2], cubes[3]);
            //glControl1.Invalidate();
            GL.End();
            glControl1.SwapBuffers();
            
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
            n100 *= coeff_scale ;
            nodes = ReWriteNodeAfterScale(nodes, coeff_scale);
            
            glControl1_PaintCOPY(sender, e);
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            coeff_scale = 5.0 / 6;
            n100 *= coeff_scale ;
            nodes = ReWriteNodeAfterScale(nodes, coeff_scale);
            glControl1_PaintCOPY(sender, e);
        }

        private void buttonRotateXPlus_Click(object sender, EventArgs e)
        {
            rotateX += 10;
            glControl1_PaintCOPY(sender, e);
        }

        private void buttonRotateXMinus_Click(object sender, EventArgs e)
        {
            rotateX -= 10;
            glControl1_PaintCOPY(sender, e);
        }

        private void buttonRotateYPlus_Click(object sender, EventArgs e)
        {
            rotateY += 10;
            glControl1_PaintCOPY(sender, e);
        }

        private void buttonRotateYMinus_Click(object sender, EventArgs e)
        {
            rotateY -= 10;
            glControl1_PaintCOPY(sender, e);
        }

        private void buttonRotateZPlus_Click(object sender, EventArgs e)
        {
            rotateZ += 10;
            glControl1_PaintCOPY(sender, e);
        }

        private void buttonRotateZMinus_Click(object sender, EventArgs e)
        {
            rotateZ -= 10;
            glControl1_PaintCOPY(sender, e);
        }

        private void buttonSwapBuffers_Click(object sender, EventArgs e)
        {
            glControl1.SwapBuffers();
        }

        private void glControl1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

            textBoxXMouse.Text = x.ToString();
            textBoxYMouse.Text = y.ToString();
        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexNode = int.Parse(comboBoxChooseNode.SelectedItem.ToString());

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //MessageBox.Show(indexNode.ToString());
            DrawMiniCube(Color.GreenYellow,n, m, indexNode);
            //glControl1.Invalidate();
            GL.End();
            //glControl1.SwapBuffers();

            //glControl1.SwapBuffers();
        }
        private void AddItemComboBox(int nodes_count)
        {
            comboBoxChooseNode.Items.Clear() ;
            for (int i = 0; i < nodes_count; i++)
            {
                comboBoxChooseNode.Items.Add(i);
            }
        }
    }
}