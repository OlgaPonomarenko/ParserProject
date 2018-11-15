using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ParseProject
{
    public partial class MainForm : Form
    {
        List<PictureBox> listOfPictureBox = new List<PictureBox>();

        List<PointsForLine> pointsForLineList = new List<PointsForLine>();

        bool isClicked = false;

        int xStart = 0;
        int yStart = 0;

        int xEnd = 0;
        int yEnd = 0;

        bool letCangeLocation = true;

        List<Point> listOfPointOfLine = new List<Point>();

        bool isDown = false;

        Point currentPoint = new Point();

        List<List<GateNameLocation>> listForComponentsWithlistOfGateNameLocation = new List<List<GateNameLocation>>();

        Rectangle componentRect;

        Graphics graphics;

        List<Bitmap> listOfBitmap = new List<Bitmap>();

        Bitmap mainBitmap;

        Graphics gr;

        Bitmap newBitmap;

        List<ComponentEntity> listOfComponentEntity = new List<ComponentEntity>();

        Point startDrawLine;
        bool startExist = false;
        Point endDrawLine;
        bool endExist = false;


        public MainForm()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listOfComponentEntity.Add(new ComponentEntity());
            
            ParseFile(listOfComponentEntity[0]);

            listOfPictureBox.Add(pictureBox1);

            DrawComponent(listOfPictureBox[0], listOfComponentEntity[0]);

        }

        public void ParseFile(ComponentEntity currentComponent)
        {
            string fileName = string.Empty;
            var dialog = new OpenFileDialog();
            dialog.Filter = "Текстовые файлы|*.txt|VHDL файлы|*.vhd|DAT файлы|*.dat";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileName = dialog.FileName;
            }

            if (fileName.Contains("dat"))
            {
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    SaveImage newImage = (SaveImage)formatter.Deserialize(fs);

                    pictureBox1.Hide();
                    pictureBox2.Hide();

                    pictureBox3.BackgroundImage = newImage.bitmap;
                }
            }
            else
            {

                try
                {
                    Parser parser = new Parser(fileName);
                    parser.ParseFile(currentComponent);

                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void DrawComponent(PictureBox pictureBox1, ComponentEntity currentComponent)
        {

            int pictureBoxWidth = pictureBox1.Width;
            int pictureBoxHeight = pictureBox1.Height;
            Bitmap bitmap = null;

            if (listOfBitmap.Count < 2)
            {
                bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                graphics = Graphics.FromImage(bitmap);
            }
            else
            {
                listOfBitmap[listOfPictureBox.IndexOf(pictureBox1)] = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                graphics = Graphics.FromImage(listOfBitmap[listOfPictureBox.IndexOf(pictureBox1)]);
            }

            SolidBrush backGround = new SolidBrush(Color.White);

            SolidBrush circle = new SolidBrush(Color.Black);

            graphics.FillRectangle(backGround, 0, 0, pictureBox1.Width, pictureBox1.Height);


            componentRect = new Rectangle(pictureBox1.Width / 6, pictureBox1.Height / 6,
                                                    pictureBox1.Width / 6 *4, pictureBox1.Height / 6 * 4);

            LineInOutX inOutX = new LineInOutX(0, pictureBox1.Width / 6,
                                              componentRect.Left + componentRect.Width,
                                              pictureBox1.Right);

            Font newFont = new Font("Arial", 9, FontStyle.Regular);

            SizeF newSize = graphics.MeasureString(currentComponent.componentName, newFont);

            graphics.DrawRectangle(Pens.Black, componentRect);


            graphics.DrawString(currentComponent.componentName, newFont, Brushes.Brown,
                                componentRect.Left + componentRect.Width / 2 - newSize.Width / 2, 
                                componentRect.Top + componentRect.Height/30);

            int amountOfGateIn = currentComponent.gateIn.Count();
 
            int amountOfGateOut = currentComponent.gateOut.Count();
  

            DrawComponentLine(amountOfGateIn, amountOfGateOut, componentRect, inOutX, graphics, currentComponent);


            if(startExist && endExist)
            {
                graphics.DrawLine(Pens.Black, startDrawLine, endDrawLine);
            }

            if (listOfBitmap.Count < 2)
            {
                listOfBitmap.Add(bitmap);
                pictureBox1.BackgroundImage = bitmap;
            }
            else
                pictureBox1.BackgroundImage = listOfBitmap[listOfPictureBox.IndexOf(pictureBox1)];
        }

        private void DrawComponentLine(int amountOfGateIn, int amountOfGateOut, Rectangle componentRect, LineInOutX inOutX,
                                       Graphics graphics, ComponentEntity currentComponent)
        {
            List<GateNameLocation> currentListOfGateNameLocation = new List<GateNameLocation>();
            

            Font newFont = new Font("Arial", 9, FontStyle.Regular);

            int stepIn = componentRect.Height / (amountOfGateIn + 1);

            int currentY = componentRect.Top + stepIn;

            foreach (Gate entry in currentComponent.gateIn)
            {
                graphics.DrawLine(Pens.Black, inOutX.startOfLineInX, currentY,
                                          inOutX.endOfLineInX, currentY);

                listOfPointOfLine.Add(new Point((int)inOutX.startOfLineInX, currentY));


                if (entry.dimension > 0)
                {
                    graphics.DrawLine(Pens.Black, inOutX.startOfLineInX + (inOutX.endOfLineInX - inOutX.startOfLineInX) / 2 - 5, currentY + 5,
                                                  inOutX.startOfLineInX + (inOutX.endOfLineInX - inOutX.startOfLineInX) / 2 + 5, currentY - 5);

                    graphics.DrawString(entry.dimension.ToString(), newFont, Brushes.Brown,
                        inOutX.startOfLineInX + (inOutX.endOfLineInX - inOutX.startOfLineInX) / 2 - 5, currentY - 15);
                }



                SizeF newSize = graphics.MeasureString(entry.gateName, newFont);

                int param1 = componentRect.Left + pictureBox1.Width/30;
                int param2 = currentY - (int)newSize.Height / 2;

                graphics.DrawString(entry.gateName, newFont, Brushes.Brown,
                                    param1, param2);

                GateNameLocation namesLocation = new GateNameLocation(entry, param1, param2,
                                                                      newSize.Width, newSize.Height);

                currentListOfGateNameLocation.Add(namesLocation);

                currentY += stepIn;
            }

            stepIn = componentRect.Height / (amountOfGateOut + 1);
            currentY = componentRect.Top + stepIn;

            foreach (Gate entry in currentComponent.gateOut)
            {
                graphics.DrawLine(Pens.Black, inOutX.startOfLineOutX, currentY,
                                          inOutX.endOfLineOutX, currentY);

                listOfPointOfLine.Add(new Point((int)inOutX.endOfLineOutX, currentY));

                if (entry.dimension > 0)
                {
                    graphics.DrawLine(Pens.Black, inOutX.startOfLineOutX + (inOutX.endOfLineOutX - inOutX.startOfLineOutX) / 2 - 5, currentY + 5,
                                                  inOutX.startOfLineOutX + (inOutX.endOfLineOutX - inOutX.startOfLineOutX) / 2 + 5, currentY - 5);

                    graphics.DrawString(entry.dimension.ToString(), newFont, Brushes.Brown,
                        inOutX.startOfLineOutX + (inOutX.endOfLineOutX - inOutX.startOfLineOutX) / 2 - 5, currentY - 15);
                }

                SizeF newSize = graphics.MeasureString(entry.gateName, newFont);

                int param1 = componentRect.Left + componentRect.Width - (int)newSize.Width - pictureBox1.Width/30;
                int param2 = currentY - (int)newSize.Height/2;


                graphics.DrawString(entry.gateName, newFont, Brushes.Brown,
                                    param1, param2);

                GateNameLocation namesLocation = new GateNameLocation(entry, param1, param2,
                                                                      newSize.Width, newSize.Height);
                currentListOfGateNameLocation.Add(namesLocation);

                currentY += stepIn;
            }

            listForComponentsWithlistOfGateNameLocation.Add(currentListOfGateNameLocation);

        }

        

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {

            currentPoint = PointToClient(MousePosition);

            Point pt = new Point();
            pt.X = currentPoint.X - pictureBox1.Location.X; // - (pictureBox1.Left - pictureBox3.Left);
            pt.Y = currentPoint.Y - pictureBox1.Location.Y; //- (pictureBox1.Top - pictureBox3.Top);


            ChangeGateName(listOfPictureBox.IndexOf(pictureBox1), pt);           
        }

        public void ChangeGateName(int _numberOfPictureBox, Point _point)
        {
            Font newFont = new Font("Arial", 9, FontStyle.Italic);



            int indexOfTargetedGate = -1;

            bool nameIsChanged = false;
            string newName = "";

            ChangeGateNameForm dialogForm = null;

            foreach (GateNameLocation entry in listForComponentsWithlistOfGateNameLocation[_numberOfPictureBox])
            {
                indexOfTargetedGate = -1;
              
                if (entry.ContainPointInRect(_point)) ////////
                {
                    
                    indexOfTargetedGate = listForComponentsWithlistOfGateNameLocation[_numberOfPictureBox].IndexOf(entry);
                    int a = indexOfTargetedGate + 1;

                    dialogForm = new ChangeGateNameForm();
                    dialogForm.ShowDialog(this);

                    if (dialogForm.newGateName != "")
                    {
                        newName = dialogForm.newGateName;
                        nameIsChanged = true;
                    }
                    break;
                }
            }

            if (nameIsChanged && dialogForm.operationChangeName)
            {
                listForComponentsWithlistOfGateNameLocation[_numberOfPictureBox][indexOfTargetedGate].thisGate.gateName = newName;
                DrawComponent(listOfPictureBox[_numberOfPictureBox], listOfComponentEntity[_numberOfPictureBox]);
            }
        }

        public int GetCurrentPictureBox()
        {
            Rectangle tempRect;
            int currentPictureBox = -1;

            foreach (PictureBox entry in listOfPictureBox)
            {
                tempRect = new Rectangle(entry.Left, entry.Top, entry.Width, entry.Height);
                if (tempRect.Contains(currentPoint))
                {
                    currentPictureBox = listOfPictureBox.IndexOf(entry);
                }
            }

            return currentPictureBox;
        }

        private void ButtonDeleteGate_Click(object sender, EventArgs e)
        {
            Rectangle tempRect;
            int currentPictureBox = -1;

            foreach (PictureBox entry in listOfPictureBox)
            {
                tempRect = new Rectangle(entry.Left, entry.Top, entry.Width, entry.Height);
                if (tempRect.Contains(currentPoint))
                {
                    currentPictureBox = listOfPictureBox.IndexOf(entry);
                }
            }

            if (currentPictureBox == -1)
                MessageBox.Show("Select component");
            else
            {
                SelectGateForm dialogForm = new SelectGateForm();

                List<Gate> gIn = new List<Gate>();
                List<Gate> gOut = new List<Gate>();

                listOfComponentEntity[currentPictureBox].GetCopyOfGates(ref gIn, ref gOut);
                dialogForm.FillListBoxByGateName(gIn, gOut);

                dialogForm.ShowDialog(this);

                if (dialogForm.selectedGateName != "")
                    listOfComponentEntity[currentPictureBox].DeleteComponentOnName(dialogForm.selectedGateName);

                DrawComponent(listOfPictureBox[currentPictureBox], listOfComponentEntity[currentPictureBox]);
            }

        }

        private void ButtonAddGate_Click(object sender, EventArgs e)
        {
            Rectangle tempRect;
            int currentPictureBox = -1;

            foreach (PictureBox entry in listOfPictureBox)
            {
                tempRect = new Rectangle(entry.Left, entry.Top, entry.Width, entry.Height);
                if (tempRect.Contains(currentPoint))
                {
                    currentPictureBox = listOfPictureBox.IndexOf(entry);
                }
            }
            if (currentPictureBox < 0)
                MessageBox.Show("Select component");
               
            else
            {
                Gate newGate = new Gate();

                AddGateForm dialogForm = new AddGateForm();
                dialogForm.ShowDialog(this);

                if (dialogForm.operationCreateGate)
                {
                    newGate = dialogForm.GetNewGate();

                    listOfComponentEntity[currentPictureBox].AddGate(newGate);
                    this.DrawComponent(listOfPictureBox[currentPictureBox], listOfComponentEntity[currentPictureBox]);                   
                }
            }
        }

        private void ButtonSaveAsPicture_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Изображения в формате jpeg|*.jpg|Изображения в формате bmp|*.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Imaging.ImageFormat format = null;
                switch (dialog.FilterIndex)
                {
                    case 1: //jpeg
                        format = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                    case 2: //bmp
                        format = System.Drawing.Imaging.ImageFormat.Bmp;
                        break;
                    default: // png
                        format = System.Drawing.Imaging.ImageFormat.Png;
                        break;
                }
                

                mainBitmap = new Bitmap(pictureBox3.Width, pictureBox3.Height);

                using (Graphics graphics = Graphics.FromImage(mainBitmap))
                {
                    graphics.DrawImage(newBitmap, 0, 0);
                    graphics.DrawImage(listOfBitmap[0], 
                        pictureBox1.Location.X - pictureBox3.Location.X, pictureBox1.Location.Y - pictureBox3.Location.Y);
                    graphics.DrawImage(listOfBitmap[1], 
                        pictureBox2.Location.X - pictureBox3.Location.X, pictureBox2.Location.Y - pictureBox3.Location.Y);
                }

                SaveImage newImage = new SaveImage(mainBitmap);

                mainBitmap.Save(dialog.FileName, format);

                // создаем объект BinaryFormatter
                BinaryFormatter formatter = new BinaryFormatter();
                // получаем поток, куда будем записывать сериализованный объект
                using (FileStream fs = new FileStream(@"D:\testForLab\directoryOne\people.dat", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, newImage);                   
                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            currentPoint = PointToClient(MousePosition);
        }

        private void ButtonAddAnother_Click(object sender, EventArgs e)
        {
            listOfComponentEntity.Add(new ComponentEntity());

            ParseFile(listOfComponentEntity[1]);

            listOfPictureBox.Add(pictureBox2);

            DrawComponent(listOfPictureBox[1], listOfComponentEntity[1]);
        }       


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(letCangeLocation)
                isDown = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            
                Control c = sender as Control;
                if (isDown)
                    c.Location = this.PointToClient(Control.MousePosition);
            
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {           
                isDown = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            currentPoint = PointToClient(MousePosition);
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
           if(letCangeLocation)
                isDown = true;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            
                Control c = sender as Control;
                if (isDown)
                    c.Location = this.PointToClient(Control.MousePosition);
           
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {           
                isDown = false;
        }

        

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            
            isClicked = true;
            xStart = e.X;
            yStart = e.Y;

        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (isClicked)
            {
                xEnd = e.X;
                yEnd = e.Y;

                newBitmap = new Bitmap(pictureBox3.Width, pictureBox3.Height);
                gr = Graphics.FromImage(newBitmap);

                SolidBrush backGround = new SolidBrush(Color.White);
                gr.FillRectangle(backGround, 0, 0, pictureBox3.Width, pictureBox3.Height);

                gr.DrawLine(Pens.Black, new Point(xStart, yStart), new Point(xEnd, yEnd));

                foreach (PointsForLine entry in pointsForLineList)
                    gr.DrawLine(Pens.Black, entry.startLine, entry.endLine);

                pictureBox3.BackgroundImage = newBitmap;
            }

        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            isClicked = false;
           
            pointsForLineList.Add(new PointsForLine(xStart, yStart, xEnd, yEnd));

            letCangeLocation = false;
        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            currentPoint = PointToClient(MousePosition);

            Point pt = new Point();
            pt.X = currentPoint.X - pictureBox2.Location.X; 
            pt.Y = currentPoint.Y - pictureBox2.Location.Y;  

            ChangeGateName(listOfPictureBox.IndexOf(pictureBox2), pt);
        }
    }
}
