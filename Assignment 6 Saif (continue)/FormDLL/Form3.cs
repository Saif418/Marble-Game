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
using System.IO.Compression;

namespace FormDLL
{
    public partial class Form3 : Form
    {

        private string FullPath;
        private string Tempdir;
        public string imagetransfer;
        public string txttransfer;
        public string ImagePath;
        public string textpath;
        Image loadimage;
        public string archiveLocation;
        public string Bin_transfer;

        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
           FullPath = Directory.GetCurrentDirectory();

              

            ListDirectory();
        }

        private void button1_Click(object sender, EventArgs e)  //Last part
        {

            if (listview1.SelectedItems.Count == 1)  // only 1 file is selected
            {
                if (listview1.SelectedItems[0].ImageIndex == 1)   // makes sure if it is a folder
                {

                    imagetransfer = Tempdir + @"\puzzle.jpg";
                    txttransfer = Tempdir + @"\puzzle.txt";
                    Bin_transfer = Tempdir + @"\puzzle.bin";

                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Select .mrb file");
                }
            }
            else
            {
                MessageBox.Show("Select .mrb file");
            }

            //There's other code here
            //Set up some properties that tell either where the mrb file is, or where the puzzle.jpg and .txt were extracted to

            
        }

        

        private void ListDirectory()
        {
           
           // FullPath = textBox1.Text;
            listview1.Items.Clear();
            DirectoryInfo dirInfo = new DirectoryInfo(FullPath);
         

            try
            {
                DirectoryInfo[] dirList = dirInfo.GetDirectories();
                textBox1.Text = FullPath;
                listview1.Items.Clear();

                for (int x = 0; x < dirList.Length; x++)
                {
                    ListViewItem listviewitem = new ListViewItem();
                    listviewitem.Text = dirList[x].Name;
                    listviewitem.SubItems.Add(" ");
                    listviewitem.SubItems.Add(dirList[x].LastAccessTime.ToString());
                    listviewitem.ImageIndex = 0;

                    listview1.Items.Add(listviewitem);

                }

                FileInfo[] fileList = dirInfo.GetFiles();
                for (int x = 0; x < fileList.Length; x++)
                {
                    ListViewItem listview = new ListViewItem();
                    listview.Text = fileList[x].Name;
                    listview.SubItems.Add(fileList[x].Length.ToString());
                    listview.SubItems.Add(fileList[x].LastAccessTime.ToString());




                    if (fileList[x].Extension == ".mrb")
                    {
                        listview.ImageIndex = 1;
                    }
                    else
                    {
                        listview.ImageIndex = 2;
                    }


                    listview1.Items.Add(listview);
                }

            }
            catch(System.UnauthorizedAccessException)
            {
                MessageBox.Show("Access not Allowed");
            }
            catch(Exception Unhandled)
            {
                MessageBox.Show("Cannot Recognize Directory.Keep going back in the stack.");
            }

        }

        private void UP_Click(object sender, EventArgs e)
        {                                                         // up 
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(FullPath);

                DirectoryInfo parentinfo = dirInfo.Parent;
                FullPath = parentinfo.FullName;

            }
            catch(System.NullReferenceException x)
            {
                MessageBox.Show("No More");
            }
            

            ListDirectory();

        }

        private void listview1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void listview1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           if(listview1.SelectedItems.Count == 1)  // only 1 file is selected
            {
                if(listview1.SelectedItems[0].ImageIndex == 0)   // makes sure if it is a folder
                {
                   // MessageBox.Show(listview1.SelectedItems[0].Text);

                    FullPath = FullPath + @"\" + listview1.SelectedItems[0].Text;   // goes ahead in directory

                    

                    ListDirectory();



                }
                else if(listview1.SelectedItems[0].ImageIndex == 1)   // knows that it is an mrb file and needs to open this
                {
                    imagetransfer = Tempdir + @"\puzzle.jpg";
                    txttransfer = Tempdir + @"\puzzle.txt";
                    Bin_transfer = Tempdir + @"\puzzle.bin";
                    ImagePath = Tempdir;  //make sure you add something becuase it shows that image path is equal to null.

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)    // to write on the textbox and hit enter to go to a directory
        {
            try
            {


                if (e.KeyCode == Keys.Enter)  //if key pressed
                {
                   

                    FullPath = textBox1.Text.ToString();

                    ListDirectory();
                    

                }
            }catch(System.UnauthorizedAccessException)
            {
                MessageBox.Show("Cannot Recognize Directory");
                
            }catch(System.ArgumentException)
            {
                MessageBox.Show("Cannot Recognize Directory.");
                ListDirectory();
            }

        }


        private void listview1_Click(object sender, EventArgs e)
        {
            if (listview1.SelectedItems.Count == 1)
            {
                if(listview1.SelectedItems[0].ImageIndex == 1)
                {
                     archiveLocation = FullPath + @"\" + listview1.SelectedItems[0].Text.ToString();

                    Tempdir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

                    Directory.CreateDirectory(Tempdir);

                    //Try First
                    using (ZipArchive archive = ZipFile.OpenRead(archiveLocation))
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            entry.ExtractToFile(Path.Combine(Tempdir, entry.FullName), true);
                        }

                    }



                    string PicLoc = Tempdir + @"\puzzle.jpg";
                    string puzzletxt = Tempdir + @"\puzzle.txt";
                    




                    string[] lines = System.IO.File.ReadAllLines(puzzletxt);
                    string[] pieces = lines[0].Split(' ');
                    loadimage = Image.FromFile(PicLoc);


                    string size = Convert.ToInt32(pieces[0]).ToString();
                    textSize.Text = size.ToString();
                    string ballcount = Convert.ToInt32(pieces[1]).ToString();
                    textBall.Text = ballcount.ToString();
                    string wallcount = Convert.ToInt32(pieces[2]).ToString();
                    textWall.Text = wallcount.ToString();



                    //puzzlePictureBox1.Image = Image.FromFile(PicLoc);

                    using (Image temp = Image.FromFile(PicLoc))
                    {
                        Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        Rectangle r = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);
                        Graphics g = Graphics.FromImage(bm);
                        g.DrawImage(temp, r, 0, 0, temp.Width, temp.Height, GraphicsUnit.Pixel);
                        pictureBox1.Image = bm;
                    }

                }
            }
        }

        private void listview1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }






}

