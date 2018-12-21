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
            DrawArea = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            parser = Input;
       
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


            Point repeat = new Point(0,0);
            Point repeat_old = new Point(0,0);

            Point IF = new Point(0,0);
            Point IF_old = new Point(0,0);
            
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
                    if (item.Peek().Contains("read") || item.Peek().Contains("write"))
                    {
                        Point old = C1;
                        G.DrawString(item.Dequeue(), F1, B1, C1);
                        C1 = new Point(C1.X + 15, C1.Y + 20);
                        G.DrawLine(P1, new Point(C1.X + 7, C1.Y), new Point(C1.X + 7, C1.Y + 20));
                        C1 = new Point(C1.X, C1.Y + 20);
                        G.DrawString(item.Dequeue(), F1, B1, C1);
                        C1 = new Point(C1.X + 80, old.Y + 10);
                        G.DrawLine(P1, new Point(old.X + 50, old.Y + 10), C1);
                        C1 = new Point(C1.X, C1.Y - 10);
                        name.Dequeue();
                        name.Dequeue();
                    }

                    else if (item.Peek().Contains("repeat"))
                    {
                        G.DrawLine(P1, new Point(C1.X + 60, C1.Y+10), new Point(C1.X + 200, C1.Y+10));
                        repeat_old = new Point(C1.X + 200, C1.Y);
                        G.DrawString(item.Dequeue(), F1, B1, C1);
                        name.Dequeue();
                        C1 = new Point(C1.X+20,C1.Y+20);
                        G.DrawLine(P1, C1, new Point (C1.X,C1.Y+60));
                        C1= new Point (C1.X, C1.Y+60);
                        G.DrawLine(P1, C1, new Point(C1.X+20, C1.Y + 20));
                        repeat = new Point(C1.X + 20, C1.Y + 20);
                        G.DrawLine(P1, C1, new Point (C1.X-140,C1.Y+140));
                        G.DrawLine(P1, C1, new Point (C1.X-40,C1.Y+40));
                        C1=new Point (C1.X-160,C1.Y+140);
                        

                    }

                    else if (item.Peek().Contains("until"))
                    {
                        item.Dequeue();
                        name.Dequeue();
                        C1 = repeat;
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
                        C1 = repeat_old;
                    }
                    else if (item.Peek().Contains("if"))
                    {
                        G.DrawLine(P1, new Point(C1.X + 30, C1.Y + 10), new Point(C1.X + 150, C1.Y + 10));
                        IF_old = new Point(C1.X + 150, C1.Y);
                        G.DrawString(item.Dequeue(), F1, B1, C1);
                        name.Dequeue();
                        G.DrawLine(P1, new Point(C1.X +10, C1.Y+20), new Point(C1.X +10, C1.Y + 110));
                        C1 = new Point(C1.X+10, C1.Y + 110);
                        IF = C1;
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
                        C1 = IF;
                        G.DrawLine(P1, C1, new Point(C1.X , C1.Y + 180));
                        C1 = new Point(C1.X-20, C1.Y + 180);
                       
                    }

                    else if (item.Peek().Contains("end"))
                    {
                        item.Dequeue();
                        name.Dequeue();
                        C1 = IF_old;

                    }
                    else if (item.Peek().Contains("else"))
                    {
                        item.Dequeue();
                        name.Dequeue();
                        C1 = IF;
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

                  
                   // G.DrawLine(P1, new Point (old.X, old.Y+10), new Point(old.X +60, old.Y+10));
                    //C1 = new Point(C1.X + 60, C1.Y );
                    G.DrawString(name.Dequeue(), F1, B1, C1);
                    C1 = new Point(C1.X + 15, C1.Y + 20);
                    G.DrawString(id.Pop(), F1, B1, C1);
                    C1 = new Point(C1.X, C1.Y + 20);
                    G.DrawLine(P1, new Point(C1.X + 7, C1.Y), new Point(C1.X + 7, C1.Y + 20));
                    C1 = new Point(C1.X, C1.Y + 20);
                   
                   
                    id.Push(item.Dequeue());
                    name.Dequeue();
                    
                    while (name.Peek().Contains("symbol"))
                    {
                        if (item.Peek().Contains("+") || item.Peek().Contains("-") || item.Peek().Contains("*") || item.Peek().Contains("+"))
                        {
                            op.Push(item.Dequeue());
                            name.Dequeue();
                            id.Push(item.Dequeue());
                            name.Dequeue();
                        }
                        else
                            break;
                    }
                  

                    while (op.Count != 0 || id.Count != bas /*edit when project end*/)
                    {
                        if (op.Count != 0)
                        {
                            C1 = new Point( C1.X -5, C1.Y);
                            G.DrawString("op", F1, B1, C1);
                            C1 = new Point(C1.X + 5, C1.Y + 20);
                            G.DrawString(op.Pop(), F1, B1, C1);
                            C1 = new Point(C1.X, C1.Y + 20);
                            G.DrawLine(P1, new Point(C1.X + 15, C1.Y - 10), new Point(C1.X + 70, C1.Y + 45));
                            G.DrawLine(P1, new Point(C1.X , C1.Y-10), new Point(C1.X - 55, C1.Y + 45));
                            C1 = new Point(C1.X + 65, C1.Y+45);
                            G.DrawString(id.Pop(), F1, B1, C1);
                            C1 = new Point(C1.X - 130, C1.Y);

                        }
                        else
                        {
                           
                            G.DrawString(id.Pop(), F1, B1, C1);
                            C1 = new Point(C1.X + 320, old.Y + 10);
                            G.DrawLine(P1, new Point(old.X + 70, old.Y + 10), C1);
                            C1 = new Point(C1.X, C1.Y - 10);
                        }

                    }
                 
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

  
    }
}
