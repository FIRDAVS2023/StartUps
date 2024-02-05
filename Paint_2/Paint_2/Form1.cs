using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Paint_2
{
    public partial class Form1 : Form
    {
        FileOperation filed;

        static Point oldClick;

        static Color select_color = Color.Black;
        static Color fill_col = Color.White;


        static Pen pen = new Pen(select_color, 1), eraser_sel;


        int x1, y1;
        int p_size = 1;
        int select_tool;


        static Bitmap bitmap;  
        static Bitmap bmp;
        static Bitmap colbitmap;
        static Bitmap openbitmap;

        bool risch = false, ereas_select = false;

        
        Point mousePos1, mousePos2;

        CutFrame cutframe;


        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true;
            Bitmap btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (var g = Graphics.FromImage(btm))
                g.Clear(Color.White);


            pictureBox1.Image = btm;
            select_tool = 1;

            filed = new FileOperation();
            filed.InitializeNewFile();
            this.Text = filed.Filename;


            comboBox1.SelectedItem = comboBox1.Items[0];

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void update()
        {
            this.Text = !filed.IsFileSaved ? filed.Filename + "*" : filed.Filename;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ereas_select) select_color = label4.BackColor;
            select_tool = 1;
            select_color = label4.BackColor;

            cutframe = null;
            mousePos1 = mousePos2;
            pictureBox1.Invalidate();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            p_size = comboBox1.SelectedIndex + 1;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();

            MyDialog.Color = label4.BackColor;

            // Update the text box color if = OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                select_color = MyDialog.Color;
                label4.BackColor = select_color;
            }

        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            open();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save();
        }

        public void open()
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open file";
            openFileDialog.InitialDirectory = "D:";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Filter = "jpg (*.jpg)|*.jpg|jpeg (*.jpeg)|*.jpeg|png (*.png)|*.png|bmp (*.bmp)|*.bmp";
            openFileDialog.ShowHelp = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    openbitmap = new Bitmap(openFileDialog.FileName);
                    openbitmap = new Bitmap(openbitmap, pictureBox1.Width, pictureBox1.Height);
                    pictureBox1.Image = openbitmap;
                    filed.OpenFile(openFileDialog.FileName);//открываем, сохраняем имя


                    update();

                }
                catch (Exception)
                {

                    MessageBox.Show("Can not open Image", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void save()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save as ...";

            saveFileDialog.OverwritePrompt = true; //есть ли такой файл

            saveFileDialog.CheckPathExists = true; //есть ли такой адрес

            saveFileDialog.Filter = "jpeg (*.jpeg)|*.jpeg|png (*.png)|*.png|bmp (*.bmp)|*.bmp";

            saveFileDialog.ShowHelp = true; //справ
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filed.SaveFile(saveFileDialog.FileName, (Bitmap)pictureBox1.Image.Clone(),
                    saveFileDialog.FilterIndex);
                update();
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;
            

            if (risch)
            {
                switch (select_tool)
                {
                    case 1:
                        pen_d(x1, y1, e.X, e.Y);
                        break;
                    case 2:
                        rec_d(oldClick.X, oldClick.Y, e.X, e.Y);
                        break;
                    case 7:
                        ell_d(oldClick.X, oldClick.Y, e.X, e.Y);
                        break;
                    case 8:
                        line_d(oldClick.X, oldClick.Y, e.X, e.Y);
                        break;
                    case 3:
                        if (e.Button == MouseButtons.Left)
                        {

                            // тянет фрагмент?
                            if (cutframe != null)
                            {
                                //сдвигаем фрагмент
                                cutframe.Location.Offset(e.Location.X - mousePos2.X, e.Location.Y - mousePos2.Y);
                                mousePos1 = e.Location;
                            }
                            //сдвигаем выделенную область

                            mousePos2 = e.Location;
                            pictureBox1.Invalidate();
                        }
                        else
                        {
                            mousePos1 = mousePos2 = e.Location;
                        }
                        break;


                }

                x1 = e.X;
                y1 = e.Y;

            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            filed.IsFileSaved = false;
            update();


            oldClick = new Point(e.X, e.Y);
            risch = true;
            x1 = e.X;
            y1 = e.Y;
            bitmap = new Bitmap(pictureBox1.Image);
            bmp = (Bitmap)bitmap.Clone();

            if (select_tool == 3)
            {

                mousePos1 = e.Location;
                //юзер кликнул мышью мимо фрагмента?
                if (cutframe != null && !cutframe.Rect.Contains(e.Location))
                {
                    //уничтожаем обьект

                    cutframe = null;
                    mousePos1 = mousePos2 = e.Location;
                    pictureBox1.Invalidate();
                }

            }
            else if (select_tool == 20)
            {
                Color tmp = bmp.GetPixel(e.X, e.Y);
                if (!(tmp.ToArgb() == select_color.ToArgb()))
                {

                    colbitmap = new Bitmap(pictureBox1.Image);
                    float stretch_X = colbitmap.Width / (float)pictureBox1.Width;
                    float stretch_Y = colbitmap.Height / (float)pictureBox1.Height;
                    fill_col = colbitmap.GetPixel((int)(e.X * stretch_X), (int)(e.Y * stretch_Y));


                    Fill(bmp, new Point(e.X, e.Y), fill_col, select_color);
                }


            }

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {


            if (select_tool == 3)
            {
                risch = false;
                //пользователь выделил фрагмент и отпустил мышь?
                if (mousePos1 != mousePos2)
                {
                    //создаем CutFrame
                    var rect = GetRect(mousePos1, mousePos2);
                    cutframe = new CutFrame() { SourceRect = rect, Location = rect.Location };
                }
                else
                {
                    //пользователь сдвинул фрагмент и отпутил мышь?
                    if (cutframe != null)
                    {
                        //фиксируем изменения в исходном изображении
                        cutframe.Fix(pictureBox1.Image);
                        //уничтожаем фрагмент
                        cutframe = null;
                    }
                }
                pictureBox1.Invalidate();


            }
            else
            {
                pictureBox1.Image = (Bitmap)bmp.Clone();
                risch = false;

            }


        }

        public void pen_d(int x1, int y1, int x2, int y2)
        {
            Point l;
            Graphics graph = Graphics.FromImage(bmp);
            pen = new Pen(select_color, p_size);
            float d = dist(x1, y1, x2, y2);
            l = seredina(x1, y1, x2, y2);
            graph.DrawEllipse(pen, l.X, l.Y, p_size, p_size);
            if (d > 1)
            {
                l = seredina(x1, y1, x2, y2);
                pen_d(x1, y1, l.X, l.Y);
                graph.DrawEllipse(pen, l.X, l.Y, p_size, p_size);
                pen_d(l.X, l.Y, x2, y2);
                graph.DrawEllipse(pen, l.X, l.Y, p_size, p_size);
            }
            pictureBox1.Image = bmp;
        }

        int dist(int x1, int y1, int x2, int y2)
        {
            int x, y;//lenght catets
            x = Math.Abs(x1 - x2);
            y = Math.Abs(y1 - y2);
            return (int)Math.Sqrt(x * x + y * y);
        }     

        Point seredina(int x1, int y1, int x2, int y2)
        {
            return new Point((x1 + x2) / 2, (y1 + y2) / 2);
        }

       
        public void eraser(int x1, int y1, int x2, int y2)
        {
            Point l;
            Graphics graph = Graphics.FromImage(bmp);
            eraser_sel = new Pen(Color.White, p_size);
            float d = dist(x1, y1, x2, y2);
            l = seredina(x1, y1, x2, y2);
            graph.DrawEllipse(eraser_sel, l.X, l.Y, p_size, p_size);
            if (d > 1)
            {
                l = seredina(x1, y1, x2, y2);
                pen_d(x1, y1, l.X, l.Y);
                graph.DrawEllipse(eraser_sel, l.X, l.Y, p_size, p_size);
                pen_d(l.X, l.Y, x2, y2);
                graph.DrawEllipse(eraser_sel, l.X, l.Y, p_size, p_size);
            }
            pictureBox1.Image = bmp;
        }

        void rec_d(int x1, int y1, int x2, int y2)
        {
            int t;
            bmp = (Bitmap)bitmap.Clone();
            Graphics graph = Graphics.FromImage(bmp);
            Pen pen = new Pen(select_color, p_size);

            if (x2 < x1)
            {
                t = x1;
                x1 = x2;
                x2 = t;
                x2 -= x1;
            }
            else
            {
                x2 -= x1;
            }
            if (y2 < y1)
            {
                t = y1;
                y1 = y2;
                y2 = t;

                y2 -= y1;
            }
            else
            {
                y2 -= y1;
            }
            graph.DrawRectangle(pen, x1, y1, x2, y2);
            pictureBox1.Image = bmp;
        }

        void ell_d(int x1, int y1, int x2, int y2)
        {
            int t;
            bmp = (Bitmap)bitmap.Clone();
            Graphics graph = Graphics.FromImage(bmp);
            Pen pen = new Pen(select_color, p_size);
            if (x2 < x1)
            {
                t = x1;
                x1 = x2;
                x2 = t;
                x2 -= x1;
            }
            else
            {
                x2 -= x1;
            }
            if (y2 < y1)
            {
                t = y1;
                y1 = y2;
                y2 = t;

                y2 -= y1;
            }
            else
            {
                y2 -= y1;
            }
            graph.DrawEllipse(pen, x1, y1, x2, y2);
            pictureBox1.Image = bmp;
        }

        void line_d(int x1, int y1, int x2, int y2)
        {
            int t;
            bmp = (Bitmap)bitmap.Clone();
            Graphics graph = Graphics.FromImage(bmp);
            Pen pen = new Pen(select_color, p_size);
            graph.DrawLine(pen, x1, y1, x2, y2);
            pictureBox1.Image = bmp;
        }


        class CutFrame
        {
            public Rectangle SourceRect;//прямоугольник фрагмента в исходном изображении
            public Point Location;//положение сдвинутого фрагмента

            //прямогульник сдвинутого фрагмента
            public Rectangle Rect
            {
                get { return new Rectangle(Location, SourceRect.Size); }
            }

            //фиксация измнений в исх изображении
            public void Fix(Image image)
            {
                using (var clone = (Image)image.Clone())
                using (var gr = Graphics.FromImage(image))
                {
                    //рисуем вырезанное белое место
                    gr.SetClip(SourceRect);
                    gr.Clear(Color.White);

                    //рисуем сдвинутый фрагмент
                    gr.SetClip(Rect);
                    gr.DrawImage(clone, Location.X - SourceRect.X, Location.Y - SourceRect.Y);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ereas_select = true;
            select_tool = 1;
            select_color = Color.White;

            cutframe = null;
            mousePos1 = mousePos2;
            pictureBox1.Invalidate();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filed.IsFileSaved)//если файл сохранен
            {
                Bitmap btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                using (var g = Graphics.FromImage(btm))
                    g.Clear(Color.White);
                pictureBox1.Image = btm;
                filed.InitializeNewFile();

                update();
            }
            else
            {
                DialogResult result = MessageBox.Show("Save changes?", "Paint", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (filed.Filename.Contains("Un_name")) //если файл еще не сохранялся
                    {
                        SaveFileDialog newFileSave = new SaveFileDialog();
                        newFileSave.Filter = "JPEG Image (.jpeg)|*.jpeg |Png Image (.png)|*.png";
                        if (newFileSave.ShowDialog() == DialogResult.OK)
                        {
                            //file is ti be saved for the first time
                            filed.SaveFile(newFileSave.FileName, (Bitmap)pictureBox1.Image.Clone(), newFileSave.FilterIndex);
                            //update(); 
                        }

                        Bitmap btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        using (var g = Graphics.FromImage(btm))
                            g.Clear(Color.White);
                        pictureBox1.Image = btm;
                        filed.InitializeNewFile();
         
                        update();

                    }
                    else
                    {
                        //file ready saved. use name from filed
                        filed.SaveFile(filed.FileLocation, (Bitmap)pictureBox1.Image.Clone(),
                            1);

                        Bitmap btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                        using (var g = Graphics.FromImage(btm))
                            g.Clear(Color.White);
                        pictureBox1.Image = btm;
                        filed.InitializeNewFile();
           
                        update();
                    }
                }
                else if (result == DialogResult.No)
                {
                    //if user select no to save, create new file
                    Bitmap btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    using (var g = Graphics.FromImage(btm))
                        g.Clear(Color.White);
                    pictureBox1.Image = btm;
                    filed.InitializeNewFile();
        
                    update();
                }
            }
        }
    

        private static bool ColorMatch(Color a, Color b)
        {
            return (a.ToArgb() & 0xffffff) == (b.ToArgb() & 0xffffff);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!filed.IsFileSaved) //если меняли файл
            {
                if (!this.Text.Contains("Un_name"))
                {
                    var newBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    pictureBox1.DrawToBitmap(newBitmap, pictureBox1.ClientRectangle);

                    openbitmap.Dispose();

                    filed.SaveFile(filed.FileLocation, newBitmap, 1);

                    pictureBox1.Image = newBitmap;
                    update();
                }
                else//если сохраняем в первый раз
                {
                    save();
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        static void Fill(Bitmap bmp, Point pt, Color targetColor, Color replacementColor)
        {
            Queue<Point> q = new Queue<Point>();
            q.Enqueue(pt);

            while (q.Count > 0)
            {
                Point n = q.Dequeue();

                if (!ColorMatch(bmp.GetPixel(n.X, n.Y), targetColor))
                    continue;

                Point w = n, e = new Point(n.X + 1, n.Y);

                while ((w.X >= 0) && ColorMatch(bmp.GetPixel(w.X, w.Y), targetColor))
                {
                    bmp.SetPixel(w.X, w.Y, replacementColor);
                    if ((w.Y > 0) && ColorMatch(bmp.GetPixel(w.X, w.Y - 1), targetColor))
                        q.Enqueue(new Point(w.X, w.Y - 1));

                    if ((w.Y < bmp.Height - 1) && ColorMatch(bmp.GetPixel(w.X, w.Y + 1), targetColor))
                        q.Enqueue(new Point(w.X, w.Y + 1));

                    w.X--;
                }

                while ((e.X <= bmp.Width - 1) && ColorMatch(bmp.GetPixel(e.X, e.Y), targetColor))
                {
                    bmp.SetPixel(e.X, e.Y, replacementColor);
                    if ((e.Y > 0) && ColorMatch(bmp.GetPixel(e.X, e.Y - 1), targetColor))
                        q.Enqueue(new Point(e.X, e.Y - 1));

                    if ((e.Y < bmp.Height - 1) && ColorMatch(bmp.GetPixel(e.X, e.Y + 1), targetColor))
                        q.Enqueue(new Point(e.X, e.Y + 1));

                    e.X++;
                }
            }
        }

        Rectangle GetRect(Point p1, Point p2)
        {
            var x1 = Math.Min(p1.X, p2.X);
            var x2 = Math.Max(p1.X, p2.X);
            var y1 = Math.Min(p1.Y, p2.Y);
            var y2 = Math.Max(p1.Y, p2.Y);

            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ereas_select) select_color = label4.BackColor;
            select_tool = 20;

            cutframe = null;
            mousePos1 = mousePos2;
            pictureBox1.Invalidate();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (ereas_select) select_color = label4.BackColor;
            select_tool = 2;
            select_color = label4.BackColor;

            cutframe = null;
            mousePos1 = mousePos2;
            pictureBox1.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            select_tool = 3;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (ereas_select) select_color = label4.BackColor;
            select_tool = 7;
            select_color = label4.BackColor;

            cutframe = null;
            mousePos1 = mousePos2;
            pictureBox1.Invalidate();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            Bitmap btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (var g = Graphics.FromImage(btm))
                g.Clear(Color.White);
            pictureBox1.Image = btm;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ereas_select) select_color = label4.BackColor;
            select_tool = 8;
            select_color = label4.BackColor;

            cutframe = null;
            mousePos1 = mousePos2;
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            //если есть сдвигаемый фрагмент
            if (cutframe != null)
            {
                //рисуем вырезанное белое место
                e.Graphics.SetClip(cutframe.SourceRect);//устанавливаем границы у рамки
                e.Graphics.Clear(Color.White);

                //рисуем сдвинутый фрагмент
                e.Graphics.SetClip(cutframe.Rect);
                e.Graphics.DrawImage(pictureBox1.Image, cutframe.Location.X - cutframe.SourceRect.X, cutframe.Location.Y - cutframe.SourceRect.Y);

                //рисуем рамку
                e.Graphics.ResetClip();//удаляем границы у рамки
                ControlPaint.DrawFocusRectangle(e.Graphics, cutframe.Rect);
            }
            else
            {
                //если выделена область
                if (mousePos1 != mousePos2)
                    ControlPaint.DrawFocusRectangle(e.Graphics, GetRect(mousePos1, mousePos2));//рисуем рамку
            }


        }
    
        
    }
}