using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication16
{
    public partial class Syntax_Tree : Form
    {
        Bitmap DrawArea;
        string parser;
        
        public Syntax_Tree(string Input)
        {
            InitializeComponent();
            DrawArea = new Bitmap(5000, 5000);
            parser = Input; 
            panel1.AutoScroll = true;
            //pictureBox1.Width = pictureBox1.Height = 5000;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            
        }

        private void Syntax_Tree_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = DrawArea;
            Graphics g;
            g = Graphics.FromImage(DrawArea);
            parsing(g, parser);
        }
        static void parsing(Graphics G, string s)
        {
            Queue <string> item = new Queue <string>();
            Queue <string> name = new Queue<string>();
            int max = s.Length;
            int index = 0;
            Pen P1 = new Pen(Color.Black);
            Font F1 = new Font("Consolas", 12);
            SolidBrush B1 = new SolidBrush(Color.Black);
            Point C1 = new Point(250, 10);
            while (index < max)
            {
                int comma = s.IndexOf(",");
                index += (comma + 1);
                item.Enqueue (s.Substring(0, comma));
                s = s.Substring(comma + 1, s.Length - comma - 1);
                int line = s.IndexOf('\n');
                name.Enqueue(s.Substring(0, line));
                s = s.Substring(line + 1, s.Length - line - 1);
                index += (line + 1);
            }
             
            Stack<string> id = new Stack<string>();
            Stack<string> op = new Stack<string>();
            Stack <Point> pnt = new Stack <Point> ();
           
            while ((item.Count!=0) || (name.Count!=0))
            {
           
               // var.Push(s.Substring(0,comma));
              
                
                if (name.Peek().Contains("identifier"))
                {
                    name.Dequeue();
                     id.Push( item.Dequeue());
                   // item.Dequeue();
   
                   
                }
                else if (name.Peek().Contains("resevered"))
                {
                    if (item.Peek().Contains("read") )
                    {
                        pnt.Push(C1);
                        G.DrawString(item.Dequeue(), F1, B1, C1);
                        C1 = new Point(C1.X + 15, C1.Y + 20);
                        G.DrawLine(P1, new Point(C1.X + 7, C1.Y), new Point(C1.X + 7, C1.Y + 20));
                        C1 = new Point(C1.X, C1.Y + 20);
                        G.DrawString(item.Dequeue(), F1, B1, C1);
                        C1 = new Point(C1.X + 280, pnt.Peek().Y + 10);
                        G.DrawLine(P1, new Point(pnt.Peek().X + 50, pnt.Peek().Y + 10), C1);
                        C1 = new Point(C1.X, C1.Y - 10);
                        pnt.Pop();
                        name.Dequeue();
                        name.Dequeue();
                    }
                    else if (item.Peek().Contains("write"))
                    {
                        int bas=id.Count-1; 
                        pnt.Push(C1);
                        G.DrawString(item.Dequeue(), F1, B1, C1);
                        C1 = new Point(C1.X + 15, C1.Y + 20);
                        G.DrawLine(P1, new Point(C1.X + 7, C1.Y), new Point(C1.X + 7, C1.Y + 20));
                        name.Dequeue();
                        C1 = new Point(C1.X, C1.Y + 20);
                        brack_rgx(G, B1, P1, ref C1, F1, id, op, item, name,0 );
                        if ((item.Count() != 0) && !(item.Peek().Contains("end") || item.Peek().Contains("else") || item.Peek().Contains("until")))
                        {
                            C1 = new Point(C1.X + 180, pnt.Peek().Y + 10);
                            G.DrawLine(P1, new Point(pnt.Peek().X + 50, pnt.Peek().Y + 10), C1);
                        }
                        C1 = new Point(C1.X, C1.Y - 10);
                        pnt.Pop();
                        //name.Dequeue();
                        
                    }

                    else if (item.Peek().Contains("repeat"))
                    {
                        G.DrawLine(P1, new Point(C1.X + 60, C1.Y+10), new Point(C1.X + 200, C1.Y+10));
                        pnt.Push( new Point(C1.X + 200, C1.Y));
                        G.DrawString(item.Dequeue(), F1, B1, C1);
                        name.Dequeue();
                        C1 = new Point(C1.X+20,C1.Y+20);
                        G.DrawLine(P1, C1, new Point (C1.X,C1.Y+60));
                        C1= new Point (C1.X, C1.Y+60);
                        G.DrawLine(P1, C1, new Point(C1.X+20, C1.Y + 20));
                        pnt.Push(new Point(C1.X + 20, C1.Y + 20));
                        G.DrawLine(P1, C1, new Point (C1.X-140,C1.Y+140));
                        G.DrawLine(P1, C1, new Point (C1.X-40,C1.Y+40));
                        C1=new Point (C1.X-160,C1.Y+140);
                        

                    }

                    else if (item.Peek().Contains("until"))
                    {
                        item.Dequeue();
                        name.Dequeue();
                        C1 = pnt.Pop();
                        id.Push(item.Dequeue());
                        name.Dequeue();
                        op.Push(item.Dequeue());
                        name.Dequeue();
                        id.Push(item.Dequeue());
                        name.Dequeue();
                        G.DrawString(op.Pop(), F1, B1, C1);
                        C1 = new Point(C1.X,C1.Y+10);
                        G.DrawLine(P1, new Point(C1.X + 15, C1.Y), new Point(C1.X + 45, C1.Y + 40));
                        G.DrawString(id.Pop(), F1, B1, new Point(C1.X + 40, C1.Y + 40));
                        G.DrawLine(P1, new Point(C1.X -2, C1.Y ), new Point(C1.X - 32, C1.Y + 40));
                        G.DrawString(id.Pop(), F1, B1, new Point(C1.X - 40, C1.Y + 40));
                        C1 = pnt.Pop();
                    }
                    else if (item.Peek().Contains("if"))
                    {
                        G.DrawLine(P1, new Point(C1.X + 30, C1.Y + 10), new Point(C1.X + 150, C1.Y + 10));
                        pnt.Push( new Point(C1.X + 150, C1.Y));
                        G.DrawString(item.Dequeue(), F1, B1, C1);
                        name.Dequeue();
                        G.DrawLine(P1, new Point(C1.X +10, C1.Y+20), new Point(C1.X +10, C1.Y + 300));
                        C1 = new Point(C1.X+10, C1.Y + 300);
                        pnt.Push( C1);
                        G.DrawLine(P1, C1, new Point(C1.X-80, C1.Y + 80));
                        C1 = new Point(C1.X - 80, C1.Y + 80);
                        id.Push(item.Dequeue());
                        name.Dequeue();
                        op.Push(item.Dequeue());
                        name.Dequeue();
                        id.Push(item.Dequeue());
                        name.Dequeue();
                        G.DrawString(op.Pop(), F1, B1, C1);
                        C1 = new Point(C1.X, C1.Y + 10);
                        G.DrawLine(P1, new Point(C1.X + 15, C1.Y), new Point(C1.X + 45, C1.Y + 40));
                        G.DrawString(id.Pop(), F1, B1, new Point(C1.X + 40, C1.Y + 40));
                        G.DrawLine(P1, new Point(C1.X - 2, C1.Y), new Point(C1.X - 32, C1.Y + 40));
                        G.DrawString(id.Pop(), F1, B1, new Point(C1.X - 40, C1.Y + 40));
                        C1 = pnt.Peek();
                        G.DrawLine(P1, C1, new Point(C1.X , C1.Y + 190));
                        C1 = new Point(C1.X-20, C1.Y + 190);
                       
                    }

                    else if (item.Peek().Contains("end"))
                    {
                        item.Dequeue();
                        name.Dequeue();
                        if (pnt.Count == 2)
                        {
                            pnt.Pop();
                            C1 = pnt.Pop();
                        }
                         else if(pnt.Count == 1)
                        {
                            C1 = pnt.Pop();
                        }

                    }
                    else if (item.Peek().Contains("else"))
                    {
                        item.Dequeue();
                        name.Dequeue();
                        C1 = pnt.Pop();
                        G.DrawLine(P1, C1, new Point(C1.X + 80, C1.Y + 80));
                        C1 = new Point(C1.X + 80, C1.Y + 80);
                       

                    }


                    else
                    {
                        name.Dequeue();
                        item.Dequeue();
                    }
                    //res.Push(var.Pop());
                }
                else if (name.Peek().Contains("assign"))
                {
                    int bas=id.Count-1;  //edit when end project
                    item.Dequeue();
                    
                    Point old = C1;

                    G.DrawString(name.Dequeue(), F1, B1, C1);
                    C1 = new Point(C1.X + 15, C1.Y + 20);
                    G.DrawString(id.Pop(), F1, B1, C1);
                    C1 = new Point(C1.X, C1.Y + 20);
                    G.DrawLine(P1, new Point(C1.X + 7, C1.Y), new Point(C1.X + 7, C1.Y + 20));
                    C1 = new Point(C1.X, C1.Y + 20);
                   

                    brack_rgx (G,  B1,  P1, ref C1,  F1,  id,  op,item,name,  bas);
                    if ((item.Count() != 0) && !(item.Peek().Contains("end") || item.Peek().Contains("else") || item.Peek().Contains("until")))
                    {
                        C1 = new Point(old.X + 150, old.Y + 10);
                        G.DrawLine(P1, new Point(old.X + 70, old.Y + 10), C1);
                    }
                    C1 = new Point(C1.X, C1.Y - 10);
                 
                }
                else if (name.Peek().Contains("symbol"))
                {
                    name.Dequeue();
                    item.Dequeue();
                   
                }
                else if (name.Peek().Contains("Number"))
                {
                    name.Dequeue();
                    item.Dequeue();
               
                   
                }
              
            }


            //G.DrawString("assign", F1, B1, new PointF(600, 10));

        }

        static void rgx (Graphics G, Brush B1, Pen P1, Point C1, Font F1, Stack <string> id, Stack <string> op, int bas)
    {
        while (op.Count != 0 || id.Count > bas)  //edit when project end
        {
            if (op.Count != 0)
            {
                C1 = new Point(C1.X - 5, C1.Y);
                G.DrawString("op", F1, B1, C1);
                C1 = new Point(C1.X + 5, C1.Y + 20);
                G.DrawString(op.Pop(), F1, B1, C1);
                C1 = new Point(C1.X, C1.Y + 20);
                G.DrawLine(P1, new Point(C1.X + 15, C1.Y - 10), new Point(C1.X + 70, C1.Y + 45));
                G.DrawLine(P1, new Point(C1.X, C1.Y - 10), new Point(C1.X - 55, C1.Y + 45));
                C1 = new Point(C1.X + 65, C1.Y + 45);
                G.DrawString(id.Pop(), F1, B1, C1);
                C1 = new Point(C1.X - 130, C1.Y);

            }
            else
            {

                G.DrawString(id.Pop(), F1, B1, C1);

            }

        }
    }


        static void brack_rgx(Graphics G, Brush B1, Pen P1,ref Point C1, Font F1, Stack <string> id, Stack <string> op,Queue <string> item, Queue <string> name, int bas)
        {
                       id.Push(item.Dequeue());
                    name.Dequeue();
                    
                    while ((name.Count!=0)&&name.Peek().Contains("symbol"))
                    {
                    
                        if (item.Peek().Contains("+") || item.Peek().Contains("-") || item.Peek().Contains("*") || item.Peek().Contains("+"))
                        {
                            op.Push(item.Dequeue());
                            name.Dequeue();
                            bool brack_falg = false;
                            if (item.Peek().Contains("("))
                            {
                                brack_falg = true;
                                Stack<string> br1 = new Stack<string>();
                                Stack<string> br2 = new Stack<string>();
                                item.Dequeue();
                                name.Dequeue();
                                br2.Push(item.Dequeue());
                                name.Dequeue();
                                while (!item.Peek().Contains(")"))
                                {
                                    br1.Push(item.Dequeue());
                                    name.Dequeue();
                                    br2.Push(item.Dequeue());
                                    name.Dequeue();
                                }
                                item.Dequeue();
                                name.Dequeue();

                                C1 = new Point(C1.X - 5, C1.Y);
                                G.DrawString("op", F1, B1, C1);
                                C1 = new Point(C1.X + 5, C1.Y + 20);
                                G.DrawString(op.Pop(), F1, B1, C1);
                                C1 = new Point(C1.X, C1.Y + 20);
                                G.DrawLine(P1, new Point(C1.X + 15, C1.Y - 10), new Point(C1.X + 70, C1.Y + 45));
                                G.DrawLine(P1, new Point(C1.X, C1.Y - 10), new Point(C1.X - 55, C1.Y + 45));
                                C1 = new Point(C1.X + 65, C1.Y + 45);
                                rgx(G, B1, P1, C1, F1, br2, br1, 0);
                                C1 = new Point(C1.X - 130, C1.Y);
                            }
                            if (!brack_falg)
                            {
                                id.Push(item.Dequeue());
                                name.Dequeue();
                            }
                        }
                        else
                            break;
                    }
                    rgx(G, B1, P1, C1, F1, id, op, bas);
        }
    }
}
