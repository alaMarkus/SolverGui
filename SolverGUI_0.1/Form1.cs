using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolverGUI_0._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<DataGridView> dataGridViews;
        private Search search;

        private void createGridViews(List<int[]> path)
        {
            int size = 30;
            MyGrid asd = new MyGrid();
            dataGridViews.Add(new DataGridView());
            DataGridView grid = dataGridViews.Last<DataGridView>();
            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.DefaultCellStyle.Font = new Font("Tahoma", 15);
            grid.ScrollBars = ScrollBars.None;
            grid.Height = 123;
            grid.Width = 122;
            grid.ColumnCount = 4;
            grid.AllowUserToAddRows = false;
            grid.ColumnHeadersVisible = false;
            grid.RowHeadersVisible = false;
            grid.ReadOnly = true;
            grid.AllowUserToResizeColumns = false;
            grid.AllowUserToResizeRows = false;
            for (int i = 0; i < 4; i++)
            {
                grid.Rows.Add(i.ToString());
                grid.Rows[i].Cells[0].Value = "";
                grid.Columns[i].Width = size;
                grid.Rows[i].Height = size;
            }

            for (int h = 0; h < path.Count; h++)
            {
                Console.WriteLine("x:" + path[h][0] + " y:" + path[h][1]);
            }

            Console.WriteLine("------------------");

            for (int i = 0; i < 4; i++)
            {
                for(int j = 0; j<4; j++)
                {
                    for (int h = 0; h < path.Count; h++)
                    {
                        if (path[h][0] == i & path[h][1] == j)
                        {
                            grid.Rows[j].Cells[i].Value = dataGridView1.Rows[j].Cells[i].Value;
                        }
                    }
                }
            }

            //grid.ClearSelection();
            grid.Enabled = false;
            flowLayoutPanel1.Controls.Add(grid);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyGrid asd = new MyGrid();
            int size = 30;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 15);
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.Height = 124;
            dataGridView1.Width = 124;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            for (int i = 0; i < 4; i++)
            {
                dataGridView1.Rows.Add(i.ToString());
                dataGridView1.Rows[i].Cells[0].Value = "";
                dataGridView1.Columns[i].Width = size;
                dataGridView1.Rows[i].Height = size;
                for (int j = 0; j < 4; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = asd.getLetter(i, j);
                }
            }


            dataGridViews = new List<DataGridView>();
            search = new Search();
        }

        private string getLetter(int[] start)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == start[0] & j == start[1])
                    {
                        return dataGridView1.Rows[j].Cells[i].Value.ToString();
                    }
                }
            }
            return "!";
        }

        private Boolean exists(int[] cpoint, int[] spoint)
        {
            if (cpoint[0] < 4 && cpoint[1] < 4 && cpoint[0] > -1 && cpoint[1] > -1)
            {
                if (cpoint[0] == spoint[0] && cpoint[1] == spoint[1])
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private Boolean pathContains(List<int[]> path, int[] point)
        {
            foreach (int[] i in path)
            {
                if (i[0] == point[0] && i[1] == point[1])
                {
                    //   System.out.println("point: "+point[0]+","+point[1]+" is already in path: "+i[0]+","+i[1]);
                    return true;
                }
            }
            return false;
        }

        private string removeLastLetter(string str)
        {
            if (str != null && str.Length > 0)
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private int[] nextCurrent(int[] cpoint, int[] spoint)
        {
            if (cpoint[1] < spoint[1] + 1)
            {
                cpoint[1] = cpoint[1] + 1;
                return cpoint;
            }
            else
            {
                cpoint[0] = cpoint[0] + 1;
                cpoint[1] = spoint[1] - 1;
                return cpoint;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int[]> path = new List<int[]>();

            string word = "";

            int[] current = new int[] { 0, 0 };
            int[] start = new int[] { 1, 1 };

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (path.Count() < 2)
                    {
                        path.Clear();
                        //        System.out.println("path cleared");
                        //        System.out.println("start: "+i+","+j);
                        int[] adds = new int[] { i, j };
                        path.Add(adds);
                        //      System.out.println("added to path: "+adds[0]+","+adds[1]);
                        start[0] = i;
                        start[1] = j;

                        word = getLetter(start);
                        //        System.out.println("starting letter: "+word);

                        current[0] = start[0] - 1;
                        current[1] = start[1] - 1;

                        //        System.out.println("current: "+current[0]+","+current[1]);
                    }

                    while (current[0] <= start[0] + 1)
                    {
                        if (exists(current, start))
                        {
                            if (pathContains(path, current) == false)
                            {

                                //                scanner.nextLine();
                                word = word + getLetter(current);
                                //                System.out.println(word);

                                if (search.find(word)!=0)
                                {
                                    int[] toAdd = new int[] { current[0], current[1] };
                                    path.Add(toAdd);

                                    if (search.getRetval() == 2)
                                    {
                                        createGridViews(path);
                                    }

                                    //                    System.out.println("path updated with: "+toAdd[0]+","+toAdd[1]);
                                    start[0] = current[0];
                                    start[1] = current[1];
                                    //                    System.out.println("updated start to: "+ start[0]+","+start[1]);
                                    current[0] = start[0] - 1;
                                    current[1] = start[1] - 1;
                                    //                    System.out.println("updated current to "+current[0]+","+current[1]);
                                }
                                else
                                {
                                    word = removeLastLetter(word);
                                }
                            }
                        }
                        //        printPath(path);
                        //        System.out.println(word);
                        current = nextCurrent(current, start);
                        //        System.out.println("next current: "+current[0]+","+current[1]);
                        if (current[0] >= start[0] + 2)
                        {
                            //            System.out.println("current x: "+current[0]+" start x+2: "+start[0]+"+"+2);
                            if (path.Count() > 1)
                            {
                                do
                                {
                                    if (path.Count() > 1)
                                    {
                                        int index = path.Count - 2;
                                        start[0] = path[index][0];
                                        start[1] = path[index][1];
                                        //                        System.out.println("updated start to: "+ start[0]+","+start[1]+" from path");
                                        int index2 = path.Count - 1;
                                        current[0] = path[index2][0];
                                        current[1] = path[index2][1];
                                        current = nextCurrent(current, start);
                                        //                        System.out.println("updated current to: "+current[0]+","+current[1]+" from path");
                                        path.RemoveAt(index2);
                                        word = removeLastLetter(word);
                                        //                        System.out.println("removed last item from path");
                                    }
                                    else
                                    {
                                        break;
                                    }
                                } while (current[0] == start[0] + 2 && current[1] == start[1] - 1);
                            }
                        }
                    }
                }
            }
            Console.WriteLine("done");
        }
    }
}
