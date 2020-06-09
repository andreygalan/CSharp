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
        public class Vertex
        {
            private string inf;
            private List<Vertex> adjVertexList;
            private int id;
            private int col;

            public Vertex(int newid)
            {
                this.inf = "";
                adjVertexList = new List<Vertex>();
                id = newid;
                col = 0;
            }
            public Vertex(int newid, string new_inf)
            {
                this.inf = new_inf;
                adjVertexList = new List<Vertex>();
                id = newid;
                col = 0;
            }

            public void addAdjacentVertex(Vertex newVertex)
            {
                adjVertexList.Add(newVertex);
            }
            public List<Vertex> getAdjVertexList()
            {
                return adjVertexList;
            }
            public void setVertexinf(string new_inf)
            {
                this.inf = new_inf;
            }
            public string getVertexinf()
            {
                return this.inf;
            }
            public int getVertexid()
            {
                return this.id;
            }
            public int getColor()
            {
                return this.col;
            }
            public void setColor(int newColor)
            {
                this.col = newColor;
            }
            public int Degree()
            {
                return adjVertexList.Count;
            }
        }
        public class Edge
        {
            Vertex sourceVertex;
            Vertex stockVertex;
           
            private int capacity;
            private int flow;
            


            public Edge(Vertex new_sourceVertex, Vertex new_stockVertex,  int new_inf)
            {
                this.sourceVertex = new_sourceVertex;
                this.stockVertex = new_stockVertex;
                
                this.capacity = new_inf;
            }

            public void setEdgeVertex(Vertex new_sourceVertex,Vertex new_stockVertex )
            {
                this.sourceVertex = new_sourceVertex;
                this.stockVertex = new_stockVertex;
               
            }
            public void setstockVertex(Vertex new_stockVertex)
            {
                this.stockVertex = new_stockVertex;
            }
            public void setsourceVertex(Vertex new_sourceVertex)
            {
                this.stockVertex = new_sourceVertex;
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
                this.capacity = new_inf;
            }
            public int getInf()
            {
                return this.capacity;
            }
            public int residualCapacityTo(Vertex x)
            {
                if (x == sourceVertex) return flow;
                if (x == stockVertex) return capacity - flow;
                throw new NotImplementedException();
            }

            public void addResidualFlowTo(Vertex x, int delta)
            {
                if (x == sourceVertex) flow -= delta;
                else if (x == stockVertex) flow += delta;
            }
            public Vertex other(Vertex x)
            {
                return x == sourceVertex ? stockVertex : sourceVertex;
            }
        }

        public class Graph
        {

            private List<Vertex> listVertex;
            private List<Edge>[] adjListEdge;
            private int edgecount;
            private List<int> color;
            bool[] visited;
            int[,] matr;
            Vertex S, T;

            public Graph()
            {
                listVertex = new List<Vertex>();
                color = new List<int>();
                edgecount = 0;
            }

            public void setupGraph(int[,] matrSm)
            {

                int size = System.Convert.ToInt32(System.Math.Sqrt(matrSm.Length));
                adjListEdge = new List<Edge>[size];
                for (int i = 0; i < size; i++)
                {
                    addVertex();
                    adjListEdge[i] = new List<Edge>();
                }
                matr = matrSm;

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
                            addEdge(newedge);
                        }
                        if (matrSm[i, j] > 0 && matrSm[j, i] <= 0)
                        {
                            if (!listVertex[i].getAdjVertexList().Contains(listVertex[j]))
                                listVertex[i].addAdjacentVertex(listVertex[j]);
                            Edge newedge = new Edge(listVertex[i], listVertex[j], matrSm[i, j]);
                            addEdge(newedge);
                        }
                        if (matrSm[i, j] <= 0 && matrSm[j, i] > 0)
                        {
                            if (!listVertex[j].getAdjVertexList().Contains(listVertex[i]))
                                listVertex[j].addAdjacentVertex(listVertex[i]);
                            Edge newedge = new Edge(listVertex[i], listVertex[j], matrSm[i, j]);
                            addEdge(newedge);
                        }

                    }
            }

            public Vertex addVertex()
            {
                Vertex newVertex = new Vertex(listVertex.Count);
                listVertex.Add(newVertex);
                return newVertex;
            }
            public List<Vertex> getListVertex()
            {
                return listVertex;
            }

            public List<Edge>[] getListEdge()
            {
                return adjListEdge;
            }

            public void addEdge(Edge e)
            {

                adjListEdge[e.getsourceVertex().getVertexid()].Add(e);
                adjListEdge[e.getstockVertex().getVertexid()].Add(e);
                edgecount++;
            }

            public List<Vertex> startHamiltonianPaths()
            {
                List<Vertex> pathg;
                List<Vertex> path = new List<Vertex>();
                visited = new bool[listVertex.Count];
                for (int i = 0; i < listVertex.Count; i++)
                {
                    pathg = HamiltonianPaths(listVertex[i], path);
                    if (!(pathg.Count == 0)) return pathg;
                }
                return null;
            }
            public List<Vertex> HamiltonianPaths(Vertex v, List<Vertex> path)
            {
                if (path.Count == listVertex.Count)
                {
                    return path;
                }
                foreach (Vertex w in listVertex[v.getVertexid()].getAdjVertexList())
                {
                    if (!visited[w.getVertexid()])
                    {
                        visited[w.getVertexid()] = true;
                        path.Add(w);
                        List<Vertex> newpath = HamiltonianPaths(w, path);
                        if (newpath.Count == listVertex.Count) return path;
                        visited[w.getVertexid()] = false;
                        path.Remove(w);
                    }
                }
                return path;
            }


            public int startnumcolor()
            {
                int col;
                int col1;
                col = numcolor(listVertex[0]);
                for (int i = 1; i < listVertex.Count; i++)
                {
                    col1 = numcolor(listVertex[i]);
                    if (col1 < col) col = col1;
                }
                return col;

            }
            public int numcolor(Vertex v)
            {
                if (v.getColor() == 0)
                {
                    int col = 1;
                    foreach (Vertex w in v.getAdjVertexList())
                    {
                        if (w.getColor() == col) col++;
                    }
                    listVertex[v.getVertexid()].setColor(col);

                    if (!color.Contains(col)) color.Add(col);
                }
                else return color.Count;
                foreach (Vertex w in listVertex[v.getVertexid()].getAdjVertexList())
                {
                    numcolor(w);
                }
                return color.Count;
            }
            public int Determinant(int[,] arr)
            {
                int result = 0;

                if (arr.Length == 1)
                {
                    return arr[0, 0];
                }

                for (int el = 0; el < arr.GetLength(1); el++)
                {
                    int[,] temp = new int[arr.GetLength(0) - 1, arr.GetLength(1) - 1];

                    for (int i = 0; i < temp.GetLength(0); i++)
                        for (int j = 0; j < temp.GetLength(1); j++)
                        {
                            temp[i, j] = (j < el) ? arr[i + 1, j] : arr[i + 1, j + 1];
                        }

                    int pow;
                    if (el % 2 == 0) pow = 1;
                    else
                        pow = -1;
                    result += (arr[0, el] * pow * Determinant(temp));
                }
                return result;
            }
            public int ost()
            {
                double EPS = 1E-9;
                int size = listVertex.Count;
                int det = 1;
                int[,] mkir = new int[size, size];
                int[,] b = new int[size, size];


                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size; j++)
                        mkir[i, j] = 0;

                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size; j++)
                    {
                        mkir[i, i] += matr[i, j];
                        mkir[i, j] -= matr[i, j];
                    }
                int[,] algdopmkir = new int[size - 1, size - 1];
                for (int i = 1; i < size; i++)
                    for (int j = 1; j < size; j++)
                        algdopmkir[i - 1, j - 1] = mkir[i, j];
                det = Determinant(algdopmkir);
                return det;
            }


            private int value;


            public void setupTS(int[,] matrSm)
            {
                List<int> SS = new List<int>();
                List<int> TT = new List<int>();
                int size = System.Convert.ToInt32(System.Math.Sqrt(matrSm.Length));
                adjListEdge = new List<Edge>[size + 2];

                for (int i = 0; i < size + 2; i++)
                {
                    addVertex();
                    adjListEdge[i] = new List<Edge>();
                }

                matr = matrSm;
                bool f;
                for (int i = 0; i < size; i++)
                {
                    f = true;
                    for (int j = 0; j < size; j++)
                    {
                        if (matrSm[j, i] != 0) f = false;
                    }
                    if (f) SS.Add(i + 1);
                }
                for (int i = 0; i < size; i++)
                {
                    f = true;
                    for (int j = 0; j < size; j++)
                    {
                        if (matrSm[i, j] != 0) f = false;
                    }
                    if (f) TT.Add(i + 1);
                }
                int sumflow;
                foreach (int i in SS)
                {
                    sumflow = 0;
                    for (int j = 0; j < size; j++)
                    {
                        sumflow += matrSm[i - 1, j];
                    }
                    listVertex[0].addAdjacentVertex(listVertex[i]);
                    Edge newedge = new Edge(listVertex[0], listVertex[i], sumflow);
                    addEdge(newedge);

                }
                foreach (int i in TT)
                {
                    sumflow = 0;
                    for (int j = 0; j < size; j++)
                    {
                        sumflow += matrSm[j, i - 1];
                    }
                    listVertex[i].addAdjacentVertex(listVertex[listVertex.Count - 1]);
                    Edge newedge = new Edge(listVertex[i], listVertex[listVertex.Count - 1], sumflow);
                    addEdge(newedge);

                }
                matr = matrSm;

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
                            addEdge(newedge);
                        }
                        if (matrSm[i, j] > 0 && matrSm[j, i] <= 0)
                        {
                            if (!listVertex[i + 1].getAdjVertexList().Contains(listVertex[j + 1]))
                                listVertex[i + 1].addAdjacentVertex(listVertex[j + 1]);
                            Edge newedge = new Edge(listVertex[i + 1], listVertex[j + 1], matrSm[i, j]);
                            addEdge(newedge);
                        }
                        if (matrSm[i, j] <= 0 && matrSm[j, i] > 0)
                        {
                            if (!listVertex[j + 1].getAdjVertexList().Contains(listVertex[i + 1]))
                                listVertex[j].addAdjacentVertex(listVertex[i + 1]);
                            Edge newedge = new Edge(listVertex[i + 1], listVertex[j + 1], matrSm[i, j]);
                            addEdge(newedge);
                        }

                    }
            }

            public int FordFulkerson()
            {
                Edge[] edgeTo;
                value = 0;

                while (BFS(out edgeTo))
                {
                    int bottle = int.MaxValue;
                    for (Vertex x = T; x != S; x = edgeTo[x.getVertexid()].other(x))
                    {
                        bottle = Math.Min(bottle, edgeTo[x.getVertexid()].residualCapacityTo(x));
                    }

                    for (Vertex x = T; x != S; x = edgeTo[x.getVertexid()].other(x))
                    {
                        edgeTo[x.getVertexid()].addResidualFlowTo(x, bottle);
                    }

                    value += bottle;
                }
                return value;
            }

            private bool BFS(out Edge[] edgeTo)
            {
                S = listVertex[0];
                T = listVertex[listVertex.Count - 1];
                edgeTo = new Edge[listVertex.Count];
                visited = new bool[listVertex.Count];
                Queue<Vertex> queue = new Queue<Vertex>();
                queue.Enqueue(S);

                while (!(queue.Count == 0))
                {
                    var x = queue.Dequeue();
                    visited[x.getVertexid()] = true;
                    foreach (var e in adjListEdge[x.getVertexid()])
                    {
                        var w = e.other(x);

                        if (!visited[w.getVertexid()] && e.residualCapacityTo(w) > 0)
                        {
                            queue.Enqueue(w);
                            edgeTo[w.getVertexid()] = e;

                            if (w == T)
                            {
                                return true;
                            }
                        }
                    }
                }

                return false;
            }

            public List<Edge> LargestEdgeCover()
            {
                listedgecover = new List<Edge>();
                bool[] usedVertex = new bool[listVertex.Count];
                FindLargestEdgeCover(usedVertex);

                return listedgecover;
            }
            List<Edge> listedgecover;
            public void FindLargestEdgeCover(bool[] usedVertex)
            {
                Vertex vmindeg;

                for (int k = 0; k < listVertex.Count; k++)
                {
                    vmindeg = listVertex[k];
                    for (int i = 0; i < listVertex.Count; i++)
                        if (vmindeg.Degree() > listVertex[i].Degree() && usedVertex[i] == false)
                            vmindeg = listVertex[i];
                    foreach (Edge e in adjListEdge[vmindeg.getVertexid()])
                    {
                        if (usedVertex[e.getsourceVertex().getVertexid()] == false && usedVertex[e.getstockVertex().getVertexid()] == false)
                        {
                            listedgecover.Add(e);
                            usedVertex[e.getsourceVertex().getVertexid()] = true;
                            usedVertex[e.getstockVertex().getVertexid()] = true;
                        }
                    }
                }
                for (int i = 0; i < listVertex.Count; i++)
                {
                    
                    foreach (Edge e in adjListEdge[i])
                    {  
                        if (usedVertex[i] == false)
                        {
                            listedgecover.Add(e);
                            usedVertex[e.getsourceVertex().getVertexid()] = true;
                            usedVertex[e.getstockVertex().getVertexid()] = true;
                        }
                    }
                }

            }




        }
        private void button2_Click(object sender, EventArgs e)
        {
            V.Clear();       
            L.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            string filename = openFileDialog1.FileName;
            string filetext = System.IO.File.ReadAllText(filename);
            V.Text = filetext;
            
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
        private Graph setTS()
        {
            
            if (V.Text.Length == 0)
            {
                V.AppendText("Введите матрицу!");
                return null;
            }
            
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
            G.setupTS(matr);

            return G;
        }

        private void hamilbutton_Click_1(object sender, EventArgs e)
        {
            L.Clear();

            Graph G = setGraph();
            if (G == null) return;
            List<Vertex> res = G.startHamiltonianPaths();
            if (!(res == null))
                foreach (Vertex i in res)
                    L.AppendText((i.getVertexid()).ToString());
            else L.AppendText("нет гам путей");
        }

        private void ostbutton_Click(object sender, EventArgs e)
        {
            L.Clear();

            Graph G = setGraph();
            if (G == null) return;
            int n = G.ost();
            L.AppendText(n.ToString());
        }

        private void chrombutton_Click(object sender, EventArgs e)
        {
            L.Clear();

            Graph G = setGraph();
            if (G == null) return;
            int n = G.startnumcolor();
            L.AppendText(n.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            L.Clear();

            Graph G = setTS();
            if (G == null) return;
            int n = G.FordFulkerson();
            L.AppendText(n.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            L.Clear();

            Graph G = setGraph();
            if (G == null) return;
            List<Edge> n = G.LargestEdgeCover();
            for(int i=0;i<n.Count;i++)
            {
                L.AppendText("("+n[i].getsourceVertex().getVertexid().ToString()+","+ n[i].getstockVertex().getVertexid().ToString()+") ");
            }
            
        }
    }
}
