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
        public struct Vertex
        {
            private string inf;
            public List<Vertex> adjVertexList;
            private int id;

            public Vertex(int newid)
            {
                this.inf = "";
                adjVertexList = new List<Vertex>();
                id = newid;
            }
            public Vertex(int newid, string new_date)
            {
                this.inf = new_date;
                adjVertexList = new List<Vertex>();
                id = newid;
            }

            public void addAdjacentVertex(Vertex newVertex)
            {
                adjVertexList.Add(newVertex);
            }
            public List<Vertex> getAdjVertexList()
            {
                return adjVertexList;
            }
            public void setVertexData(string new_date)
            {
                this.inf = new_date;
            }
            public string getVertexData()
            {
                return this.inf;
            }
            public int getVertexid()
            {
                return this.id;
            }
        }
        public struct Edge
        {
            Vertex stockVertex;
            Vertex sourceVertex;
            int inf;


            public Edge(Vertex new_stockVertex, Vertex new_sourceVertex, int new_inf)
            {
                this.stockVertex = new_stockVertex;
                this.sourceVertex = new_sourceVertex;
                this.inf = new_inf;
            }

            public void setEdgeVertex(Vertex new_stockVertex, Vertex new_sourceVertex)
            {
                this.stockVertex = new_stockVertex;
                this.sourceVertex = new_sourceVertex;
            }
            public void setstockVertex(Vertex new_stockVertex)
            {
                this.stockVertex = new_stockVertex;
            }
            public void setsourceVertex(Vertex new_sourceVertex)
            {
                this.stockVertex = new_sourceVertex;
            }
            public void getEdgeVertex(out Vertex new_stockVertex, out Vertex new_sourceVertex)
            {
                new_stockVertex = this.stockVertex;
                new_sourceVertex = this.sourceVertex;
            }

            public Vertex getstockVertex()
            {
                return this.stockVertex;
            }
            public Vertex getsourceVertex()
            {
                return this.sourceVertex;
            }
            public void setInf(int new_inf)
            {
                this.inf = new_inf;
            }
            public int getInf()
            {
                return this.inf;
            }

        }

        public class Graph
        {

            private List<Vertex> listVertex;
            private List<Edge> listEdge;
            bool[] visited;



            public Graph()
            {
                listVertex = new List<Vertex>();
                listEdge = new List<Edge>();
            }


            public void setupGraph(int[,] matrSm)
            {
                // resize the vector to N elements of type vector<int>
                int size = System.Convert.ToInt32(System.Math.Sqrt(matrSm.Length));
                for (int i = 0; i < size; i++)
                    addVertex();

                // add edges to the undirected graph
                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size; j++)
                    {

                        if (matrSm[i, j] * matrSm[j, i] > 0)
                        {
                            if (!listVertex[i].getAdjVertexList().Contains(listVertex[j]))
                                listVertex[i].addAdjacentVertex(listVertex[j]);
                            if (!listVertex[j].getAdjVertexList().Contains(listVertex[i]))
                                listVertex[j].addAdjacentVertex(listVertex[i]);
                            Edge newedge = new Edge(listVertex[i], listVertex[j], matrSm[i, j]);
                            AddEdge(newedge);
                        }
                        if (matrSm[i, j] > 0 && matrSm[j, i] <= 0)
                        {
                            if (!listVertex[i].getAdjVertexList().Contains(listVertex[j]))
                                listVertex[i].addAdjacentVertex(listVertex[j]);
                            Edge newedge = new Edge(listVertex[i], listVertex[j], matrSm[i, j]);
                            AddEdge(newedge);
                        }
                        if (matrSm[i, j] <= 0 && matrSm[j, i] > 0)
                        {
                            if (!listVertex[j].getAdjVertexList().Contains(listVertex[i]))
                                listVertex[j].addAdjacentVertex(listVertex[i]);
                            Edge newedge = new Edge(listVertex[i], listVertex[j], matrSm[i, j]);
                            AddEdge(newedge);
                        }

                    }
            }




            public void AddEdge(Edge edge_to_add)
            {
                listEdge.Add(edge_to_add);
            }

            public void del_to_edge_list(int inf_to_del)
            {

                foreach (Edge e in listEdge)
                {
                    if (e.getInf() == inf_to_del)
                    {
                        listEdge.Remove(e);
                    }
                }

            }
            public Vertex addVertex()
            {
                Vertex newVertex = new Vertex(listVertex.Count);
                listVertex.Add(newVertex);
                return newVertex;
            }
            public void del_to_vertex_list(string date_to_del)
            {

                foreach (Vertex v in listVertex)
                {
                    if (v.getVertexData() == date_to_del)
                    {
                        listVertex.Remove(v);
                    }
                }

            }
            public List<Vertex> startHamiltonianPaths()
            {
                List<Vertex> pathg;
                List<Vertex> path = new List<Vertex>();
                visited = new bool[listVertex.Count];
                for (int i = 0; i < listVertex.Count; i++)
                {
                    pathg = printAllHamiltonianPaths(listVertex[i], path);
                    if (!(pathg.Count == 0)) return pathg;
                }
                return null;
            }
            public List<Vertex> printAllHamiltonianPaths(Vertex v, List<Vertex> path)
            {
                // if all the vertices are visited, then
                // Hamiltonian path exists
                if (path.Count == listVertex.Count)
                {
                    return path;
                }


                foreach (Vertex w in listVertex[v.getVertexid()].getAdjVertexList())
                {
                    // process only unvisited vertices as Hamiltonian
                    // path visits each vertex exactly once
                    if (!visited[w.getVertexid()])
                    {
                        visited[w.getVertexid()] = true;
                        path.Add(w);


                        List<Vertex> newpath = printAllHamiltonianPaths(w, path);
                        if (newpath.Count == listVertex.Count) return path;

                        visited[w.getVertexid()] = false;
                        path.Remove(w);
                    }
                }
                return path;
            }


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
        private int[,] createVR(int[,] matr, int col, int n)
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
            string filename = openFileDialog1.FileName;
            string filetext = System.IO.File.ReadAllText(filename);
            V.Text = filetext;
            int gtytyg = 123454;
        }
        private Graph setGraph()
        {
            // Проверки
            if (V.Text.Length == 0)
            {
                V.AppendText("Введите матрицу!");
                return null;
            }
            // Инициализация
            string reference = V.Text.Trim();
            string[] str = reference.Split('\n');
            int size = str.Length;
            int[,] matr = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                string[] stl = str[i].Split(' ');

                if (stl.Length != size)
                {
                    V.AppendText("Неверный формат матрицы!");
                    return null;
                }

                for (int j = 0; j < size; j++)
                    matr[i, j] = System.Convert.ToInt32(stl[j]);
            }

            Graph G = new Graph();
            G.setupGraph(matr);

            return G;
        }
        private void hamilbutton_Click(object sender, EventArgs e)
        {
            L.Clear();



            Graph G = setGraph();
            if (G == null) return;



            // Поиск количества путей
            List<Vertex> res = G.startHamiltonianPaths();
            if (!(res == null))
                foreach (Vertex i in res)
                    L.AppendText((i.getVertexid()).ToString());
            else L.AppendText("нет гам путей");
        }
    }
}
