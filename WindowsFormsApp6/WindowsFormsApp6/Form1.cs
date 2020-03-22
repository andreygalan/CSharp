using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void prV()
        {
            String[] str = V.Lines;

            int n;
            n = str.Length;

            int[,] matr = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                String[] tmp = str[i].Split(' ');
                for (int j = 0; j < n; j++)
                    matr[i, j] = Convert.ToInt32(tmp[j]);
            }

            for (int i = 0; i < n; i++)
            {
                //L.AppendText((i+1).ToString()+":");
                for (int j = 0; j < n; j++)
                    if (matr[i, j] == 1) L.AppendText(" " + (j + 1).ToString());
                L.AppendText("\n");
            }
            //инцендентность
            int col = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (Convert.ToBoolean(matr[i, j])) col++;
            col /= 2;
            int[,] matrinc; 
            matrinc = createVR(matr, col, n);
            createR(matrinc, col, n);
        }




        private void prL()
        {
            String[] str = L.Lines;
            List<List<int>> list = new List<List<int>>();

            for (int i = 0; i < str.Length; i++)
            {
                List<int> a = new List<int>();
                String[] tmp = str[i].Split(' ');
                for (int j = 0; j < tmp.Length; j++)
                    a.Add(Convert.ToInt32(tmp[j]));
                list.Add(a);
            }
            int[,] matr = new int[list.Count, list.Count];


            for (int i = 0; i < list.Count; i++)
                for (int j = 0; j < list.Count; j++)
                    matr[i, j] = 0;

            for (int i = 0; i < list.Count; i++)
                for (int j = 0; j < list[i].Count; j++)
                {
                    matr[i, list[i][j] - 1] = 1;
                    matr[list[i][j] - 1, i] = 1;
                }


            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                    V.AppendText(matr[i, j].ToString() + " ");
                V.AppendText("\n");
            }
            int col = 0;
            int n = list.Count;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (Convert.ToBoolean(matr[i, j])) col++;
            col /= 2;
            int[,] matrinc;
            
            matrinc = createVR(matr, col, n);

            createR(matrinc, col, n);


        }

        private void prVR()
        {
            String[] str = VR.Lines;
            int n = str.Length;
            int m = str[0].Split(' ').Length;
            int[,] matrinc = new int[n, m];
            int[,] matr = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                String[] tmp = str[i].Split(' ');
                for (int j = 0; j < m; j++)
                    matrinc[i, j] = Convert.ToInt32(tmp[j]);
            }
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matr[i, j] = 0;
            int k = 0;
            for (int i = 0; i < m; i++)
            {
                k = 0;
                while (!Convert.ToBoolean(matrinc[k, i]))
                    k++;
                for (int j = k + 1; j < n; j++)
                {

                    if (Convert.ToBoolean(matrinc[k, i]) && Convert.ToBoolean(matrinc[j, i]))
                    {
                        matr[k, j] = 1;
                        matr[j, k] = 1;

                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    V.AppendText(matr[i, j].ToString() + " ");
                V.AppendText("\n");
            }
            for (int i = 0; i < n; i++)
            {
                //L.AppendText((i+1).ToString()+":");
                for (int j = 0; j < n; j++)
                    if (matr[i, j] == 1) L.AppendText(" " + (j + 1).ToString());
                L.AppendText("\n");
            }
            createR(matrinc, m, n);
        }
        private void createR(int[,] matrinc, int col, int n)
        {
            int[,] matrR = new int[col, col];
            for (int i = 0; i < col; i++)
                for (int j = 0; j < col; j++)
                    matrR[i, j] = 0;

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < n; j++)
                    if (Convert.ToBoolean(matrinc[j, i]))
                    {
                        for (int l = 0; l < col; l++)
                            if (i != l && Convert.ToBoolean(matrinc[j, l])) matrR[i, l] = 1;
                    }
            }

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < col; j++)
                    R.AppendText(matrR[i, j].ToString() + " ");
                R.AppendText("\n");
            }
        }
        private int[,] createVR(int[,] matr,int col, int n)
        {
            int[,] matrinc = new int[n, col];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < col; j++)
                    matrinc[i, j] = 0;
            int k = 0;
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                    if (Convert.ToBoolean(matr[i, j]))
                    {
                        matrinc[i, k] = 1;
                        matrinc[j, k] = 1;
                        k++;
                    }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < col; j++)
                    VR.AppendText(matrinc[i, j].ToString() + " ");
                VR.AppendText("\n");
            }
            return matrinc;
        }
        private void DFS(bool[] vis,int v,int[,] g)
        {
            vis[v] = true;




            for (int i = 0; i < vis.Length; i++)
            {
                if (!vis[i] && Convert.ToBoolean(g[v, i]))DFS(vis, v, g);
            }
        }
            private void button1_Click(object sender, EventArgs e)
        {
            bool f1, f2, f3, f4;
            f1 = Convert.ToBoolean(V.Text.Length);
            f2 = Convert.ToBoolean(R.Text.Length);
            f3 = Convert.ToBoolean(VR.Text.Length);
            f4 = Convert.ToBoolean(L.Text.Length);
            if (f1) prV();
            if (f2) ;
            if (f3) prVR();
            if (f4) prL();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            V.Clear();
            R.Clear();
            VR.Clear();
            L.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            string filename= openFileDialog1.FileName;
            string filetext = System.IO.File.ReadAllText(filename);
            V.Text = filetext;
        }
    }
}
