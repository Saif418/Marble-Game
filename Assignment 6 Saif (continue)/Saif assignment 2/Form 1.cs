using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.IO;
using File_browser;

namespace Saif_assignment_2
{
    public partial class Form1 : Form
    
    {
         
        private int OldWidth;
        private int OldHeight;
       
        private Image loadimage;
        List<PersonItem> highscore_list;
        private string binpath;

        PuzzlePictureBox[,] ppb;
        int size;
        int ballCount;
        int wallCount;

        //int reservedArea = 500;
        int PuzzleTileRow = 0;
        int PuzzleTileCol = 0;
        float ratio = 1.0f;
        int puzzleSize = 4;
        private string NameEntered = "";
        private int Total_Moves = 0;
        private string ArchiveLocation;
        private int totaltime = 0;

        private BufferedGraphicsContext CurrentContext;

        public Form1()
        {
            InitializeComponent();
            highscore_list = new List<PersonItem>();
        }

       


        private void Form1_Load(object sender, EventArgs e)
        {

            //// from txt file
            // //loadimage = Image.FromFile("puzzleWide.jpg");

            // string[] lines = System.IO.File.ReadAllLines("puzzle.txt");
            // string[] pieces = lines[0].Split(' ');
            // loadimage = Image.FromFile("puzzle.jpg");
            // size = Convert.ToInt32(pieces[0]);
            // ballCount = Convert.ToInt32(pieces[1]);
            // wallCount = Convert.ToInt32(pieces[2]);


            // //ratio should always be between 0 and 1
            // if (loadimage.Width > loadimage.Height)
            // {
            //     ratio = loadimage.Height / loadimage.Width;
            //     pbxWidth = reservedArea / puzzleSize;
            //     pbxHeight = (int)(pbxWidth * ratio);
            // }
            // else
            // {
            //     ratio = loadimage.Width / loadimage.Height;
            //     pbxHeight = reservedArea / puzzleSize;
            //     pbxWidth = (int)(ratio * pbxHeight);
            // }



            // ppb = new PuzzlePictureBox[size, size];
            // for (int r = 0; r < size; r++)
            // {
            //     for (int c = 0; c < size; c++)
            //     {
            //         ppb[r, c] = new PuzzlePictureBox();
            //         ppb[r, c].Width = (int)pbxWidth;
            //         ppb[r, c].Height = (int)pbxHeight;
            //         ppb[r, c].Location = new System.Drawing.Point((int)pbxWidth + c * (int)pbxWidth, 150 + r * (int)pbxHeight);
            //         ppb[r, c].Name = "b" + r.ToString() + " " + c.ToString();
            //         ppb[r, c].Size = new System.Drawing.Size((int)pbxWidth, (int)pbxHeight);
            //         ppb[r, c].Row = r;
            //         ppb[r, c].Column = c;
            //         Controls.Add(ppb[r, c]);
            //     }
            // }

            // for (int i = 0; i < ballCount; i++)  // puts the balls in the corrcect spot on the borad
            // {
            //     string[] ballPieces = lines[i + 1].Split(' '); //plus 1 because we read the first line already
            //     int r = Convert.ToInt32(ballPieces[0]);
            //     int c = Convert.ToInt32(ballPieces[1]);
            //     ppb[r, c].BallOrHole = i + 1;
            // }

            // for (int i = 0; i < ballCount; i++)    // puts the wholes in the corrcect spot on the borad
            // {
            //     string[] holePieces = lines[i + 1 + ballCount].Split(' '); //plus 1 because we read the first line already
            //     int r = Convert.ToInt32(holePieces[0]);
            //     int c = Convert.ToInt32(holePieces[1]);
            //     ppb[r, c].BallOrHole = 0 - (i + 1);
            // }

            // for (int i = 0; i < wallCount; i++)   // puts the walls in the corrcect spot on the borad
            // {
            //     string[] wallPieces = lines[i + 1 + 2 * ballCount].Split(' '); //plus 1 because we read the first line already
            //     int r1 = Convert.ToInt32(wallPieces[0]);
            //     int c1 = Convert.ToInt32(wallPieces[1]);
            //     int r2 = Convert.ToInt32(wallPieces[2]);
            //     int c2 = Convert.ToInt32(wallPieces[3]);

            //     if (r1 == r2)
            //     {
            //         if (c1 > c2)
            //         {
            //             ppb[r1, c1].LeftWall = true;
            //             ppb[r2, c2].RightWall = true;
            //         }
            //         else
            //         {
            //             ppb[r1, c1].RightWall = true;
            //             ppb[r2, c2].LeftWall = true;
            //         }
            //     }
            //     else
            //     {
            //         if (r1 > r2)
            //         {
            //             ppb[r1, c1].TopWall = true;
            //             ppb[r2, c2].BottomWall = true;
            //         }
            //         else
            //         {
            //             ppb[r1, c1].BottomWall = true;
            //             ppb[r2, c2].TopWall = true;
            //         }
            //     }
            // }
            // updatePicture();



            //string archiveLocation = Path.Combine(Directory.GetCurrentDirectory(), "base.mrb");

            //if (TempDirectory != "")
            //{
            //    RemoveTempDir();
            //}

            //TempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            //Directory.CreateDirectory(TempDirectory);

            //using (ZipArchive archive = ZipFile.OpenRead(archiveLocation))
            //{
            //    foreach (ZipArchiveEntry entry in archive.Entries)
            //    {
            //        entry.ExtractToFile(Path.Combine(TempDirectory, entry.FullName), true);
            //    }
            //}


            //IFormatter formatter = new BinaryFormatter();
            //string PersonFile = Path.Combine(TempDirectory, "puzzle.bin");
            //try
            //{
            //    using (FileStream stream = new FileStream(PersonFile, FileMode.Open, FileAccess.Read))
            //    {
            //        ExistingPersonList = (List<PersonItem>)formatter.Deserialize(stream);

            //        foreach (PersonItem p in ExistingPersonList)
            //        {
            //            AddPerson(p);
            //        }
            //    }
            //}
            //catch (FileNotFoundException f)
            //{

            //}

        }
        int temp;

        

        private void button5_Click(object sender, EventArgs e)   // up
        {

            
            for (int r = 1; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    if (ppb[r, c].BallOrHole > 0)
                    {
                        temp = r;
                        while (temp > 0)
                        {
                            if (ppb[temp , c].TopWall == true || ppb[temp-1 , c ].BallOrHole > 0)
                            {
                                break;
                            }
                            if (ppb[temp -1, c].BallOrHole < 0)
                            {
                                if (ppb[temp -1, c].BallOrHole + ppb[temp,r].BallOrHole == 0)
                                {
                                    ppb[temp-1,c].BallOrHole = 0;
                                    ppb[temp ,c].BallOrHole = 0;
                                    break;
                                }
                                else
                                {
                                    clock1.End2();
                                    Up.Enabled = false;
                                    Right.Enabled = false;
                                    Down.Enabled = false;
                                    Left.Enabled = false;
                                    MessageBox.Show("You Lost!");
                                   
                                    return;
                                    
                                }

                            }
                            else
                            {
                                ppb[temp -1,c].BallOrHole = ppb[temp,c].BallOrHole;
                                ppb[temp ,c].BallOrHole = 0;

                                temp--;
                            }
                        }

                    }
                }
            }
            updatePicture();

            Total_Moves++;


            win();

           

        }

        private void button6_Click(object sender, EventArgs e)  //left
        {
            for (int r = 0; r < size ; r++) // are the > < signs correct for r?
            {
                for (int c = 1; c < size ; c++) // // are the > < signs correct for c?
                {
                    if (ppb[r, c].BallOrHole > 0)
                    {
                        int tempC = c;
                        while (tempC > 0)
                        {
                            if (ppb[r, tempC].LeftWall == true || ppb[r, tempC - 1].BallOrHole > 0) 
                            {
                                break;
                            }
                            if (ppb[r, tempC - 1].BallOrHole < 0)
                            {
                                if (ppb[r, tempC -1].BallOrHole + ppb[r, tempC ].BallOrHole == 0)
                                {
                                    ppb[r, tempC].BallOrHole = 0; 
                                    ppb[r, tempC -1 ].BallOrHole = 0;
                                    break;
                                }
                                else
                                {
                                    clock1.End2();
                                    Up.Enabled = false;
                                    Right.Enabled = false;
                                    Down.Enabled = false;
                                    Left.Enabled = false;
                                    MessageBox.Show("You Lost");
                                   
                                    return;
                                    
                                }

                            }
                            else
                            {

                                ppb[r, tempC -1 ].BallOrHole = ppb[r, tempC].BallOrHole;
                                ppb[r, tempC].BallOrHole = 0;
                                // move current ball to left 
                                // what do ou mean by that? and how do I do it right?
                                tempC--;
                            }
                        }

                    }
                }
            }
            updatePicture();
            Total_Moves++;
            win();



        }

        private void button7_Click(object sender, EventArgs e)// right
        {
            for (int r = 0; r < size -1 ; r++)
            {
                for (int c = size -2; c >= 0; c--)
                {
                    if (ppb[r, c].BallOrHole > 0)
                    {
                        temp = c;
                        while (temp < size -1)
                        {
                            if (ppb[r, temp].RightWall == true || ppb[r, temp + 1].BallOrHole > 0)
                            {
                                break;
                            }
                            if (ppb[r, temp + 1].BallOrHole < 0)
                            {
                                if (ppb[r, temp + 1].BallOrHole + ppb[r, temp].BallOrHole == 0)
                                {
                                    ppb[r, temp + 1].BallOrHole = 0;
                                    ppb[r, temp].BallOrHole = 0;
                                    break;
                                }
                                else
                                {
                                    clock1.End2();
                                    Up.Enabled = false;
                                    Right.Enabled = false;
                                    Down.Enabled = false;
                                    Left.Enabled = false;
                                    MessageBox.Show("You Lost");
                                    
                                    return;
                                   
                                }

                            }
                            else
                            {
                                ppb[r, temp +1 ].BallOrHole = ppb[r, temp].BallOrHole;
                                ppb[r, temp].BallOrHole = 0;

                                temp++;
                            }
                        }

                    }
                }
            }
            updatePicture();
            Total_Moves++;
            win();
        }

        private void button8_Click(object sender, EventArgs e)   //down
        {
            
            
            for (int r = size -2; r >= 0; r--)
            {
                for (int c = 0; c < size; c++)
                {
                    if (ppb[r, c].BallOrHole > 0)
                    {

                        temp = r;
                        while (temp < size -1)
                        {
                            if (ppb[temp ,c].BottomWall == true || ppb[temp + 1,c].BallOrHole > 0)
                            {
                                break;
                            }
                            if (ppb[temp + 1,c].BallOrHole < 0)
                            {
                                if (ppb[temp + 1,c].BallOrHole + ppb[temp,c].BallOrHole == 0)
                                {
                                    ppb[temp + 1,c].BallOrHole = 0;
                                    ppb[temp,c].BallOrHole = 0;
                                    break;
                                }
                                else
                                {
                                    clock1.End2();
                                    Up.Enabled = false;
                                    Right.Enabled = false;
                                    Down.Enabled = false;
                                    Left.Enabled = false;
                                    MessageBox.Show("You Lost!");
                                   
                                    return;
                                   
                                }

                            }
                            else
                            {
                                ppb[temp + 1,c].BallOrHole = ppb[temp,c].BallOrHole;
                                ppb[temp,c].BallOrHole = 0;

                                temp++;
                            }
                        }

                    }
                }
            }
            updatePicture();
            Total_Moves++;
            win();
        }

        private void win()
        {
            for (int r = 0; r < size ; r++)
            {
                for(int c = 0; c < size; c++)
                {
                    if(ppb[r,c].BallOrHole != 0)
                    {
                        
                        return;
                    }
                }
            }
            clock1.End();
            Form4 Win_Form = new Form4();

            Win_Form.ShowDialog();
            NameEntered = Win_Form.Name_Entered;
            totaltime = Convert.ToInt32(clock1.Get_totaltime.TotalSeconds);
            

            Up.Enabled = false;
            Right.Enabled = false;
            Down.Enabled = false;
            Left.Enabled = false;

            PersonItem personItem = new PersonItem();
            personItem.Name = NameEntered;
            personItem.Time = totaltime;
            personItem.Moves = Total_Moves;


            highscore_list.Add(personItem);
            Save_score();    // only if you win you save the score
            ScoreList.Items.Clear();
            highscore_list = highscore_list.OrderBy(x => x.Moves).ThenBy(x => x.Time).ToList();   // sorts it before saving
            foreach (PersonItem p in highscore_list)
            {

                AddPerson(p);    // not sure 
            }
        }
        //Load_Score();
        //ListViewItem item = new ListViewItem();

        //item.Text = NameEntered;
        //item.SubItems.Add(Total_Moves.ToString());
        //item.SubItems.Add(totaltime.ToString());

        //ScoreList.Items.Add(item);



        private void updatePicture()
        {
      
           

            for (int puzzCol = 0; puzzCol < size; puzzCol++)
            {
                for (int puzzRow = 0; puzzRow < size; puzzRow++)
                {

                    Bitmap bm = new Bitmap((int)loadimage.Width/7, (int)loadimage.Height/7);
                    Graphics g = Graphics.FromImage(bm);
                    Rectangle rec = new Rectangle(0, 0, (int)loadimage.Width / 7, (int)loadimage.Height / 7);

                    PuzzleTileRow = 0;
                    PuzzleTileCol = 0;
                    //there is a ball

                    int result = 0;
                    // if there is a left wall or rightwall, topwall, bottomwall than it is true otherwise it is false 
                    if (ppb[puzzCol, puzzRow].LeftWall == false && ppb[puzzCol, puzzRow].RightWall == false && ppb[puzzCol, puzzRow].TopWall == false && ppb[puzzCol, puzzRow].BottomWall == false)
                    {
                        result = 0;
                    }
                    else if (ppb[puzzCol, puzzRow].LeftWall == true && ppb[puzzCol, puzzRow].RightWall == false && ppb[puzzCol, puzzRow].TopWall == false && ppb[puzzCol, puzzRow].BottomWall == false)
                    {
                        result = 1;
                    }
                    else if (ppb[puzzCol, puzzRow].LeftWall == false && ppb[puzzCol, puzzRow].RightWall == true && ppb[puzzCol, puzzRow].TopWall == false && ppb[puzzCol, puzzRow].BottomWall == false)
                    {
                        result = 2;
                    }
                    else if (ppb[puzzCol, puzzRow].LeftWall == true && ppb[puzzCol, puzzRow].RightWall == false && ppb[puzzCol, puzzRow].TopWall == true && ppb[puzzCol, puzzRow].BottomWall == false)
                    {
                        result = 3;
                    }
                    else if (ppb[puzzCol, puzzRow].LeftWall == true && ppb[puzzCol, puzzRow].RightWall == false && ppb[puzzCol, puzzRow].TopWall == false && ppb[puzzCol, puzzRow].BottomWall == true)
                    {
                        result = 4;
                    }
                    else if (ppb[puzzCol, puzzRow].LeftWall == true && ppb[puzzCol, puzzRow].RightWall == false && ppb[puzzCol, puzzRow].TopWall == true && ppb[puzzCol, puzzRow].BottomWall == false)
                    {
                        result = 5;
                    }
                    else if (ppb[puzzCol, puzzRow].LeftWall == true && ppb[puzzCol, puzzRow].RightWall == true && ppb[puzzCol, puzzRow].TopWall == false && ppb[puzzCol, puzzRow].BottomWall == false)
                    {
                        result = 6;
                    }
                    else if (ppb[puzzCol, puzzRow].LeftWall == true && ppb[puzzCol, puzzRow].RightWall == false && ppb[puzzCol, puzzRow].TopWall == false && ppb[puzzCol, puzzRow].BottomWall == true)
                    {
                        result = 7;
                    }
                    else if (ppb[puzzCol, puzzRow].LeftWall == false && ppb[puzzCol, puzzRow].RightWall == true && ppb[puzzCol, puzzRow].TopWall == true && ppb[puzzCol, puzzRow].BottomWall == false)
                    {
                        result = 8;
                    }
                    else if (ppb[puzzCol, puzzRow].LeftWall == true && ppb[puzzCol, puzzRow].RightWall == true && ppb[puzzCol, puzzRow].TopWall == false && ppb[puzzCol, puzzRow].BottomWall == true)
                    {
                        result = 9;
                    }
                    else if (ppb[puzzCol, puzzRow].LeftWall == false && ppb[puzzCol, puzzRow].RightWall == false && ppb[puzzCol, puzzRow].TopWall == true && ppb[puzzCol, puzzRow].BottomWall == true)
                    {
                        result = 10;
                    }
                    else if (ppb[puzzCol, puzzRow].LeftWall == true && ppb[puzzCol, puzzRow].RightWall == false && ppb[puzzCol, puzzRow].TopWall == true && ppb[puzzCol, puzzRow].BottomWall == true)
                    {
                        result = 11;
                    }
                    else if (ppb[puzzCol, puzzRow].LeftWall == false && ppb[puzzCol, puzzRow].RightWall == true && ppb[puzzCol, puzzRow].TopWall == true && ppb[puzzCol, puzzRow].BottomWall == true)
                    {
                        result = 12;
                    }
                    else if (ppb[puzzCol, puzzRow].LeftWall == true && ppb[puzzCol, puzzRow].RightWall == true && ppb[puzzCol, puzzRow].TopWall == true && ppb[puzzCol, puzzRow].BottomWall == false)
                    {
                        result = 13;
                    }
                    else if (ppb[puzzCol, puzzRow].LeftWall == true && ppb[puzzCol, puzzRow].RightWall == true && ppb[puzzCol, puzzRow].TopWall == false && ppb[puzzCol, puzzRow].BottomWall == true)
                    {
                        result = 14;
                    }
                    else if (ppb[puzzCol, puzzRow].LeftWall == true && ppb[puzzCol, puzzRow].RightWall == true && ppb[puzzCol, puzzRow].TopWall == true && ppb[puzzCol, puzzRow].BottomWall == true)
                    {
                        result = 15;
                    }


                    if (ppb[puzzCol, puzzRow].BallOrHole < 0)
                    {
                        result += 16;   // + 16 would make it point towards the holes
                    }

                    if (ppb[puzzCol, puzzRow].BallOrHole > 0)
                    {
                        result += 32;       // this would make it point towards the balls
                    }

                    PuzzleTileRow = result / 7;
                    PuzzleTileCol = result % 7;


                    g.DrawImage(loadimage, rec, PuzzleTileCol * loadimage.Width / 7, PuzzleTileRow * loadimage.Height / 7, loadimage.Width / 7, loadimage.Height / 7, GraphicsUnit.Pixel);
                    if (ppb[puzzCol, puzzRow].BallOrHole > 0)
                    {
                        int BallNumber = ppb[puzzCol, puzzRow].BallOrHole;
                        Font f = new Font("Arial", 48.5f);
                        Brush b = new SolidBrush(Color.Lime);
                        StringFormat sf = new StringFormat();
                        sf.LineAlignment = StringAlignment.Center;
                        sf.Alignment = StringAlignment.Center;

                        g.DrawString(BallNumber.ToString(), f, b, rec, sf);
                        ppb[puzzCol, puzzRow].Image = bm;
                        //Controls.Add(ppb[puzzCol, puzzRow]);
                    } 
                    
                    else if(ppb[puzzCol, puzzRow].BallOrHole < 0)
                    {
                        int BallNumber = ppb[puzzCol, puzzRow].BallOrHole;
                        Font f = new Font("Arial", 48.5f);
                        Brush b = new SolidBrush(Color.Lime);
                        StringFormat sf = new StringFormat();
                        sf.LineAlignment = StringAlignment.Center;
                        sf.Alignment = StringAlignment.Center;

                        g.DrawString(BallNumber.ToString(), f, b, rec, sf);
                        ppb[puzzCol, puzzRow].Image = bm;
                        //Controls.Add(ppb[puzzCol, puzzRow]);
                    }
                    ppb[puzzCol, puzzRow].Image = bm;

                }
                


              

            }

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();


            if (f3.ShowDialog() == DialogResult.OK)   // delete the puzzle if another mrb is opened
            {
                binpath = f3.Bin_transfer;
                if (size > 0)
                {
                    
                    for (int r = 0; r < size; r++)
                    {
                        for (int c = 0; c < size; c++)
                        {

                            Controls.Remove(ppb[r, c]);


                            
                        }
                    }
                }

                ScoreList.Items.Clear();

               clock1.Start();
               
                ArchiveLocation = f3.archiveLocation;
                Load_Score();

                Up.Enabled = true;
                Right.Enabled = true;
                Down.Enabled = true;
                Left.Enabled = true;


                string[] lines = System.IO.File.ReadAllLines(f3.txttransfer);
                string[] pieces = lines[0].Split(' ');


                loadimage = Image.FromFile(f3.imagetransfer);
                //if (loadimage.Width > loadimage.Height)
                //{
                //    ratio = loadimage.Height / loadimage.Width;
                //    pbxWidth = reservedArea / puzzleSize;
                //    pbxHeight = (int)(ratio * pbxWidth);
                //}
                //else
                //{
                //    ratio = loadimage.Width / loadimage.Height;
                //    pbxHeight = reservedArea / puzzleSize;
                //    pbxWidth = (int)(ratio * pbxHeight);
                //}

                //TLP1.Controls.Add(TLP2, 0, 0);

                size = Convert.ToInt32(pieces[0]);
                ballCount = Convert.ToInt32(pieces[1]);
                wallCount = Convert.ToInt32(pieces[2]);

                TLP1.Controls.Add(TLP2, 0, 0);

                TableLayoutPanel RatioPanel = new TableLayoutPanel();
                RatioPanel.Margin = new Padding(0);
                RatioPanel.Name = "RatioPanel";
                RatioPanel.Dock = DockStyle.Fill;
                TLP1.Controls.Add(RatioPanel, 0, 0);
                //TLP1.Controls.Add(TLP1, 0, 0);


                string ImagePath = f3.imagetransfer;

                string txttransfer = f3.txttransfer;
                               
               using (Image temp = Image.FromFile(ImagePath))
                {
                    int ImageWidth = temp.Width;
                    int ImageHeight = temp.Height;

                    if(ImageWidth == ImageHeight)
                    {
                        RatioPanel.ColumnCount = 1;
                        RatioPanel.RowCount = 1;
                        RatioPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                        RatioPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                    }
                    else if (ImageWidth > ImageHeight)
                    {
                        //Width is bigger
                        float ratio = ImageHeight / (float)ImageWidth;
                        RatioPanel.ColumnCount = 1;
                        RatioPanel.RowCount = 2;

                        RatioPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

                        RatioPanel.RowStyles.Add(new RowStyle(SizeType.Percent, ratio * 100F));
                        RatioPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F - ratio * 100F));

                    }
                    else if (ImageWidth < ImageHeight)
                    {
                        //Height is bigger
                        float ratio = ImageWidth / (float)ImageHeight;
                        RatioPanel.ColumnCount = 2;
                        RatioPanel.RowCount = 1;

                        RatioPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, ratio * 100F));
                        RatioPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F - ratio * 100F));

                        RatioPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

                    }

                }

                TableLayoutPanel PuzzlePanel = new TableLayoutPanel();
                PuzzlePanel.Margin = new Padding(0);
                PuzzlePanel.Name = "PuzzlePanel";
                PuzzlePanel.Dock = DockStyle.Fill;
                RatioPanel.Controls.Add(PuzzlePanel, 0, 0);

                PuzzlePanel.ColumnCount = size;
                PuzzlePanel.RowCount = size;

                RatioPanel.Controls.Add(PuzzlePanel, 0, 0);

                for (int i = 0; i < size; i++)
                {
                    PuzzlePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / (float)size));
                    PuzzlePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / (float)size));
                }

                //This is where you'd load the puzzle
                // from txt file
                //loadimage = Image.FromFile("puzzleWide.jpg");

                  


                ////ratio should always be between 0 and 1
                //if (loadimage.Width > loadimage.Height)
                //{
                //    ratio = loadimage.Height / loadimage.Width;
                //    pbxWidth = reservedArea / puzzleSize;
                //    pbxHeight = (int)(pbxWidth * ratio);
                //}
                //else
                //{
                //    ratio = loadimage.Width / loadimage.Height;
                //    pbxHeight = reservedArea / puzzleSize;
                //    pbxWidth = (int)(ratio * pbxHeight);
                //}



                ppb = new PuzzlePictureBox[size, size];
                for (int r = 0; r < size; r++)
                {
                    for (int c = 0; c < size; c++)
                    {
                        ppb[r, c] = new PuzzlePictureBox();
                        ppb[r, c].Name = "b" + r.ToString() + " " + c.ToString();   
                        ppb[r, c].Row = r;
                        ppb[r, c].Column = c;
                        ppb[r, c].Dock = DockStyle.Fill;
                        ppb[r, c].Margin = new Padding(0);
                        ppb[r, c].SizeMode = PictureBoxSizeMode.StretchImage;
                        PuzzlePanel.Controls.Add(ppb[r, c], c, r);


                        //ppb[r, c].Width = (int)pbxWidth;
                        //ppb[r, c].Height = (int)pbxHeight;
                        //ppb[r, c].Location = new System.Drawing.Point((int)pbxWidth + c * (int)pbxWidth, 150 + r * (int)pbxHeight);
                        //ppb[r, c].Size = new System.Drawing.Size((int)pbxWidth, (int)pbxHeight);
                    }
                }

                for (int i = 0; i < ballCount; i++)  // puts the balls in the corrcect spot on the borad
                {
                    string[] ballPieces = lines[i + 1].Split(' '); //plus 1 because we read the first line already
                    int r = Convert.ToInt32(ballPieces[0]);
                    int c = Convert.ToInt32(ballPieces[1]);
                    ppb[r, c].BallOrHole = i + 1;
                }

                for (int i = 0; i < ballCount; i++)    // puts the wholes in the corrcect spot on the borad
                {
                    string[] holePieces = lines[i + 1 + ballCount].Split(' '); //plus 1 because we read the first line already
                    int r = Convert.ToInt32(holePieces[0]);
                    int c = Convert.ToInt32(holePieces[1]);
                    ppb[r, c].BallOrHole = 0 - (i + 1);
                }

                for (int i = 0; i < wallCount; i++)   // puts the walls in the corrcect spot on the borad
                {
                    string[] wallPieces = lines[i + 1 + 2 * ballCount].Split(' '); //plus 1 because we read the first line already
                    int r1 = Convert.ToInt32(wallPieces[0]);
                    int c1 = Convert.ToInt32(wallPieces[1]);
                    int r2 = Convert.ToInt32(wallPieces[2]);
                    int c2 = Convert.ToInt32(wallPieces[3]);

                    if (r1 == r2)
                    {
                        if (c1 > c2)
                        {
                            ppb[r1, c1].LeftWall = true;
                            ppb[r2, c2].RightWall = true;
                        }
                        else
                        {
                            ppb[r1, c1].RightWall = true;
                            ppb[r2, c2].LeftWall = true;
                        }
                    }
                    else
                    {
                        if (r1 > r2)
                        {
                            ppb[r1, c1].TopWall = true;
                            ppb[r2, c2].BottomWall = true;
                        }
                        else
                        {
                            ppb[r1, c1].BottomWall = true;
                            ppb[r2, c2].TopWall = true;
                        }
                    }
                }
                updatePicture();



                
            }

            
            //Rather then have a msg box
            //get the puzzle.txt and puzzle.jpg locatios from f3 and load the puzzle.
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void button6_Click_1(object sender, EventArgs e)
        //{
        //    MessageBox.Show(button6.Width.ToString());
        //    MessageBox.Show(button6.Height.ToString());
           

            
           //}

        private void Form1_Resize(object sender, EventArgs e)
        {
           

           
            
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            int DiffW = Math.Abs(Width - OldWidth); //Tells us how much W was changed
            int DiffH = Math.Abs(Height - OldHeight); //Tells us how much H was changed

            if (DiffH  > DiffW)
            {
                Width = Height + 177;
            }
            else if (DiffW > DiffH)
            {
                Height = Width - 177;
            }
            OldHeight = Height;
            OldWidth = Width;
            updatePicture();

            clock1.Clock_Resize();

        }

        private void TLP2_Paint(object sender, PaintEventArgs e)
        {
            CurrentContext = BufferedGraphicsManager.Current;
            System.Drawing.BufferedGraphics bg = CurrentContext.Allocate(CreateGraphics(), ClientRectangle);

            //DrawBigW(bg.Graphics);

            bg.Render();
        }

        private void Pause_button_Click(object sender, EventArgs e)
        {
            clock1.Pause();
            Up.Enabled = false;
            Right.Enabled = false;
            Down.Enabled = false;
            Left.Enabled = false;

            for (int r = 0; r < size; r++)      // hides the game
            {
                for (int c = 0; c < size; c++)
                {

                    ppb[r, c].Visible = false;



                }
            }




        }
        //private void Pause_button_MouseClick(object sender, MouseEventArgs e)
        //{
           

        //}
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        //private void Reset_button_Click(object sender, EventArgs e)
        //{
        //    clock1.Reset();
        //}

        private void Resume_button_Click(object sender, EventArgs e)
        {
            clock1.Resume();

            Up.Enabled = true;
            Right.Enabled = true;
            Down.Enabled = true;
            Left.Enabled = true;


            for (int r = 0; r < size; r++)     // makes the game visible
            {
                for (int c = 0; c < size; c++)
                {

                    ppb[r, c].Visible = true;



                }
            }

        }

        private void clock1_Load(object sender, EventArgs e)
        {

            clock1.Start();
            clock1.End();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Save_score();
            
        }
        private void Save_score() 
        {
           List<PersonItem> sorted_list = highscore_list.OrderBy(x => x.Moves).ThenBy(x => x.Time).ToList();   // sorts it before saving

            highscore_list = sorted_list;
            IFormatter formatter = new BinaryFormatter();         // creates puzzle.bin // saves to the archloc

            //string ArchiveFile = Path.Combine(Directory.GetCurrentDirectory(), "base.mrb");
            using (ZipArchive archive = ZipFile.Open(ArchiveLocation, ZipArchiveMode.Update))
            {
                ZipArchiveEntry oldEntry = archive.GetEntry("puzzle.bin");
                if (oldEntry != null)
                {
                    oldEntry.Delete();
                }
                ZipArchiveEntry scoreEntry = archive.CreateEntry("puzzle.bin");


                using (System.IO.Stream stream = scoreEntry.Open())
                {
                    formatter.Serialize(stream, highscore_list);
                }
            }

        }

        private void AddPerson(PersonItem person)
        {
            ListViewItem lvi = new ListViewItem();

            //Whatever you want to be visible in the first column goes in the text property
            lvi.Text = person.Name;
            lvi.SubItems.Add(person.Moves.ToString());
            lvi.SubItems.Add(person.Time.ToString());
            

            ScoreList.Items.Add(lvi);


        }

        private void Load_Score()  // when the game loads 
        {
            

            IFormatter formatter = new BinaryFormatter();
           // string PersonFile = Path.Combine(binpath, "puzzle.bin");
            try
            {
                using (FileStream stream = new FileStream( binpath, FileMode.Open, FileAccess.Read))  // fix this
                {
                    highscore_list = (List<PersonItem>)formatter.Deserialize(stream);   

                    foreach (PersonItem p in highscore_list)
                    {

                        AddPerson(p);    // not sure 
                    }
                }
            }
            catch (FileNotFoundException f)
            {

            }

        }


        //private void clock1_Load(object sender, EventArgs e)
        //{
        //    clock1.Start();
        //}

        //private void Add_button_Click(object sender, EventArgs e)
        //{
        //    ListViewItem lv = new ListViewItem();



        //}



        //private void Pause_button_MouseHover(object sender, EventArgs e)
        //{
        //    Console.WriteLine("Resume");
        //}

        //private void Resume(object sender, EventArgs e)
        //{
        //    Console.WriteLine("Resume");

        //}




    }

}




   

