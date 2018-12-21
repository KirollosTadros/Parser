using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication16
{
   
    public partial class Form1 : Form
    {
         
        string File_str;
        string output;
        string parser;
        public Form1()
        {
            
            InitializeComponent();
            
        }

        //Open Button
        private void Open_Click(object sender, EventArgs e)
        {
           
            File_Name.Visible = true;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File_Name.Text = openFileDialog1.FileName;
                File_Name.Visible = true;
                File_str = File.ReadAllText(File_Name.Text); 
            }
            /*
            output = getTokens(File_str);
           saveFileDialog1.FileName = "Output";

           saveFileDialog1.Filter = "Text (*.txt)|*.txt|Word Doc (*.doc)|*.doc|csv(*.csv)|*.csv";

           if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
           {
               File.WriteAllText(saveFileDialog1.FileName, output);
           }*/
           new Syntax_Tree(getTokens(File_str)).Show();

            /*
            output = getTokens(File_str);   //Scanning function
            Save.Visible = true;
            MessageBox.Show("Output File is Ready You can save it");
         */
        }

        /*
        //Save button
        private void Save_Click(object sender, EventArgs e)
        {
            //SaveFileDialog savefile = new SaveFileDialog();

            saveFileDialog1.FileName = "Output";

            saveFileDialog1.Filter = "Text (*.txt)|*.txt|Word Doc (*.doc)|*.doc|csv(*.csv)|*.csv";
 
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               File.WriteAllText(saveFileDialog1.FileName, output);
            }
        }
        */

        //Scanning function
        static string getTokens(string s)
        {   int INDEX=0;
            string output="";
            s += "    ";
            while(INDEX<s.Length)
            {
          
                //if letter
            if(Char.IsLetter(s,INDEX))
            {

                //if i
                if (s[INDEX] == 'i' )
                {
                    if (s.Substring(INDEX, 2) == "if")
                    {
                       output=output+"if,resevered word"+System.Environment.NewLine;
                       INDEX = INDEX + 2;
                    }
                    else
                    {
                        int index = INDEX;
                        while (char.IsLetterOrDigit(s, index))
                            index++;
                        output = output + s.Substring(INDEX, index - INDEX) + ", identifier" + System.Environment.NewLine;
                        INDEX = index;
                    }
                }
                    //end of i




                    //if t
                else if (s[INDEX] == 't')
                {
                    if (s.Substring(INDEX, 4) == "then")
                    {
                        output = output + "then,resevered word" + System.Environment.NewLine;
                        INDEX = INDEX + 4;
                    }
                    else
                    {
                        int index = INDEX;
                        while (char.IsLetterOrDigit(s, index))
                            index++;
                        output = output + s.Substring(INDEX, index - INDEX) + ", identifier" + System.Environment.NewLine;
                        INDEX = index;
                    }
                }
                    //end of t



                    //if e
                else if (s[INDEX] == 'e')
                {
                    if (s.Substring(INDEX, 4) == "else")
                    {
                        output = output + "else,resevered word" + System.Environment.NewLine;
                        INDEX = INDEX + 4;
                    }
                    else if (s.Substring(INDEX, 3) == "end")
                    {
                        output = output + "end,resevered word" + System.Environment.NewLine;
                        INDEX = INDEX + 3;
                    }
                    else
                    {
                        int index = INDEX;
                        while (char.IsLetterOrDigit(s, index))
                            index++;
                        output = output + s.Substring(INDEX, index - INDEX) + ", identifier" + System.Environment.NewLine;
                        INDEX = index;
                    }
                }
                    //end of e


                    //if r
                else if (s[INDEX] == 'r')
                {
                    if (s.Substring(INDEX, 4) == "read")
                    {
                        output = output + "read,resevered word" + System.Environment.NewLine;
                        INDEX = INDEX + 4;
                    }
                    else if (s.Substring(INDEX, 6) == "repeat")
                    {
                        output = output + "repeat,resevered word" + System.Environment.NewLine;
                        INDEX = INDEX + 6;
                    }
                    else
                    {
                        int index = INDEX;
                        while (char.IsLetterOrDigit(s, index))
                            index++;
                        output = output + s.Substring(INDEX, index - INDEX) + ", identifier" + System.Environment.NewLine;
                        INDEX = index;
                    }
                }

                //end of r


                    //if u
                else if (s[INDEX] == 'u')
                {
                    if (s.Substring(INDEX, 5) == "until")
                    {
                        output = output + "until,resevered word" + System.Environment.NewLine;
                        INDEX = INDEX + 5;
                    }
                    else
                    {
                        int index = INDEX;
                        while (char.IsLetterOrDigit(s, index))
                            index++;
                        output = output + s.Substring(INDEX, index - INDEX) + ", identifier" + System.Environment.NewLine;
                        INDEX = index;
                    }
                }

                //end of u


                    //if w
                else if (s[INDEX] == 'w')
                {
                    if (s.Substring(INDEX, 5) == "write")
                    {
                        output = output + "write,resevered word" + System.Environment.NewLine;
                        INDEX = INDEX + 5;
                    }
                    else
                    {
                        int index = INDEX;
                        while (char.IsLetterOrDigit(s, index))
                            index++;
                        output = output + s.Substring(INDEX, index - INDEX) + ", identifier" + System.Environment.NewLine;
                        INDEX = index;
                    }
                }
                //end of w

                     //if t
                else if (s[INDEX] == 't')
                {
                    if (s.Substring(INDEX, 4) == "then")
                    {
                        output = output + "then,resevered word" + System.Environment.NewLine;
                        INDEX = INDEX + 4;
                    }
                    else
                    {
                        int index = INDEX;
                        while (char.IsLetterOrDigit(s, index))
                            index++;
                        output = output + s.Substring(INDEX, index - INDEX) + ", identifier" + System.Environment.NewLine;
                        INDEX = index;
                    }
                }
                //end of w



                else
                {
                    int index = INDEX;
                    while (char.IsLetterOrDigit(s, index))
                        index++;
                    output = output + s.Substring(INDEX, index - INDEX) + ", identifier" + System.Environment.NewLine;
                    INDEX = index;
                }

            }
                //end of letters

            else if (Regex.Match(s.Substring(INDEX, 1), @"\s+$").Success)
            {
                INDEX++;
            }


                 //if symbol
                //
            else if (Regex.Match(s.Substring(INDEX,1), @"^\W+$").Success)
                {
                    if (s[INDEX] == '{')
                    {
                        int index=s.IndexOf('}',INDEX,s.Length-INDEX);
                       // output = output + s.Substring(INDEX + 1, index - INDEX-1) + ",comment" + System.Environment.NewLine;
                        INDEX = index+1;
                    }/*
                    else if (s[INDEX] == '=')
                    {

                        output = output + "=,assign" + System.Environment.NewLine;
                        INDEX = INDEX + 1;
                    }*/
                    else if (s.Substring(INDEX, 2) == ":=")
                    {
                        output = output + ":=,assign" + System.Environment.NewLine;
                        INDEX = INDEX + 2;
                    }
                    else
                    {
                        output = output + s[INDEX] + ",symbol" + System.Environment.NewLine;
                        INDEX++;
                    }
                    //end of symbol


                  

                }


                //if number
            else if (Char.IsNumber(s,INDEX))
            {
                int index = INDEX;
                while (Char.IsNumber(s, index))
                    index++;
                output = output + s.Substring(INDEX, index - INDEX) + ",Number" + System.Environment.NewLine;
                INDEX = index;

            }

 

            }
   
            return output;
        }

      
    }
     
}
