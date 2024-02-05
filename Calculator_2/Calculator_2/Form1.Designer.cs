namespace Calculator_2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            panel1 = new Panel();
            label1 = new Label();
            button_angle = new Button();
            button10 = new Button();
            button_erase_all = new Button();
            button12 = new Button();
            button1 = new Button();
            panel2 = new Panel();
            button19 = new Button();
            button22 = new Button();
            button23 = new Button();
            button24 = new Button();
            button25 = new Button();
            button26 = new Button();
            button27 = new Button();
            button28 = new Button();
            button14 = new Button();
            button15 = new Button();
            button16 = new Button();
            button17 = new Button();
            button18 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button2 = new Button();
            button4 = new Button();
            button_percent = new Button();
            button3 = new Button();
            button_negative = new Button();
            button_0 = new Button();
            button_3 = new Button();
            button_1 = new Button();
            button_2 = new Button();
            button_6 = new Button();
            button_8 = new Button();
            button_9 = new Button();
            button_4 = new Button();
            button_5 = new Button();
            button_7 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 51);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(110, 23);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 11);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(110, 23);
            textBox2.TabIndex = 1;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button_angle);
            panel1.Controls.Add(button10);
            panel1.Controls.Add(button_erase_all);
            panel1.Controls.Add(button12);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(textBox2);
            panel1.Location = new Point(10, 9);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(362, 94);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(133, 14);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 14;
            // 
            // button_angle
            // 
            button_angle.Location = new Point(267, 54);
            button_angle.Margin = new Padding(3, 2, 3, 2);
            button_angle.Name = "button_angle";
            button_angle.Size = new Size(82, 22);
            button_angle.TabIndex = 13;
            button_angle.Text = "Угол";
            button_angle.UseVisualStyleBackColor = true;
            button_angle.Click += button11_Click;
            // 
            // button10
            // 
            button10.Location = new Point(133, 46);
            button10.Margin = new Padding(3, 2, 3, 2);
            button10.Name = "button10";
            button10.Size = new Size(35, 30);
            button10.TabIndex = 12;
            button10.Text = "=";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button_erase_all
            // 
            button_erase_all.Location = new Point(222, 46);
            button_erase_all.Margin = new Padding(3, 2, 3, 2);
            button_erase_all.Name = "button_erase_all";
            button_erase_all.Size = new Size(35, 30);
            button_erase_all.TabIndex = 11;
            button_erase_all.Text = "C";
            button_erase_all.UseVisualStyleBackColor = true;
            button_erase_all.Click += button_erase_all_Click;
            // 
            // button12
            // 
            button12.Location = new Point(222, 11);
            button12.Margin = new Padding(3, 2, 3, 2);
            button12.Name = "button12";
            button12.Size = new Size(35, 30);
            button12.TabIndex = 10;
            button12.Text = "<-";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // button1
            // 
            button1.Location = new Point(267, 11);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(82, 22);
            button1.TabIndex = 0;
            button1.Text = "Режим";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(button19);
            panel2.Controls.Add(button22);
            panel2.Controls.Add(button23);
            panel2.Controls.Add(button24);
            panel2.Controls.Add(button25);
            panel2.Controls.Add(button26);
            panel2.Controls.Add(button27);
            panel2.Controls.Add(button28);
            panel2.Controls.Add(button14);
            panel2.Controls.Add(button15);
            panel2.Controls.Add(button16);
            panel2.Controls.Add(button17);
            panel2.Controls.Add(button18);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button6);
            panel2.Controls.Add(button7);
            panel2.Controls.Add(button8);
            panel2.Controls.Add(button9);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button_percent);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button_negative);
            panel2.Controls.Add(button_0);
            panel2.Controls.Add(button_3);
            panel2.Controls.Add(button_1);
            panel2.Controls.Add(button_2);
            panel2.Controls.Add(button_6);
            panel2.Controls.Add(button_8);
            panel2.Controls.Add(button_9);
            panel2.Controls.Add(button_4);
            panel2.Controls.Add(button_5);
            panel2.Controls.Add(button_7);
            panel2.Location = new Point(10, 116);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(362, 188);
            panel2.TabIndex = 3;
            // 
            // button19
            // 
            button19.Location = new Point(267, 4);
            button19.Margin = new Padding(3, 2, 3, 2);
            button19.Name = "button19";
            button19.Size = new Size(39, 30);
            button19.TabIndex = 34;
            button19.Text = "sin";
            button19.UseVisualStyleBackColor = true;
            button19.Visible = false;
            button19.Click += button19_Click;
            // 
            // button22
            // 
            button22.Location = new Point(267, 74);
            button22.Margin = new Padding(3, 2, 3, 2);
            button22.Name = "button22";
            button22.Size = new Size(39, 30);
            button22.TabIndex = 31;
            button22.Text = "cos";
            button22.UseVisualStyleBackColor = true;
            button22.Visible = false;
            button22.Click += button22_Click;
            // 
            // button23
            // 
            button23.Location = new Point(267, 39);
            button23.Margin = new Padding(3, 2, 3, 2);
            button23.Name = "button23";
            button23.Size = new Size(39, 30);
            button23.TabIndex = 30;
            button23.Text = "tan";
            button23.UseVisualStyleBackColor = true;
            button23.Visible = false;
            button23.Click += button23_Click;
            // 
            // button24
            // 
            button24.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            button24.Location = new Point(222, 4);
            button24.Margin = new Padding(3, 2, 3, 2);
            button24.Name = "button24";
            button24.Size = new Size(39, 30);
            button24.TabIndex = 29;
            button24.Text = "mod";
            button24.UseVisualStyleBackColor = true;
            button24.Visible = false;
            button24.Click += button24_Click;
            // 
            // button25
            // 
            button25.Location = new Point(222, 142);
            button25.Margin = new Padding(3, 2, 3, 2);
            button25.Name = "button25";
            button25.Size = new Size(39, 30);
            button25.TabIndex = 28;
            button25.Text = "e^x";
            button25.UseVisualStyleBackColor = true;
            button25.Visible = false;
            button25.Click += button25_Click;
            // 
            // button26
            // 
            button26.Location = new Point(222, 108);
            button26.Margin = new Padding(3, 2, 3, 2);
            button26.Name = "button26";
            button26.Size = new Size(39, 30);
            button26.TabIndex = 27;
            button26.Text = "e";
            button26.UseVisualStyleBackColor = true;
            button26.Visible = false;
            button26.Click += button26_Click;
            // 
            // button27
            // 
            button27.Location = new Point(222, 74);
            button27.Margin = new Padding(3, 2, 3, 2);
            button27.Name = "button27";
            button27.Size = new Size(39, 30);
            button27.TabIndex = 26;
            button27.Text = "Pi";
            button27.UseVisualStyleBackColor = true;
            button27.Visible = false;
            button27.Click += button27_Click;
            // 
            // button28
            // 
            button28.Location = new Point(222, 39);
            button28.Margin = new Padding(3, 2, 3, 2);
            button28.Name = "button28";
            button28.Size = new Size(39, 30);
            button28.TabIndex = 25;
            button28.Text = "|x|";
            button28.UseVisualStyleBackColor = true;
            button28.Visible = false;
            button28.Click += button28_Click;
            // 
            // button14
            // 
            button14.Location = new Point(178, 4);
            button14.Margin = new Padding(3, 2, 3, 2);
            button14.Name = "button14";
            button14.Size = new Size(39, 30);
            button14.TabIndex = 24;
            button14.Text = "x^y";
            button14.UseVisualStyleBackColor = true;
            button14.Visible = false;
            button14.Click += button14_Click;
            // 
            // button15
            // 
            button15.Location = new Point(178, 142);
            button15.Margin = new Padding(3, 2, 3, 2);
            button15.Name = "button15";
            button15.Size = new Size(39, 30);
            button15.TabIndex = 23;
            button15.Text = "n!";
            button15.UseVisualStyleBackColor = true;
            button15.Visible = false;
            button15.Click += button15_Click;
            // 
            // button16
            // 
            button16.Location = new Point(178, 108);
            button16.Margin = new Padding(3, 2, 3, 2);
            button16.Name = "button16";
            button16.Size = new Size(39, 30);
            button16.TabIndex = 22;
            button16.Text = "Ln";
            button16.UseVisualStyleBackColor = true;
            button16.Visible = false;
            button16.Click += button16_Click;
            // 
            // button17
            // 
            button17.Location = new Point(178, 74);
            button17.Margin = new Padding(3, 2, 3, 2);
            button17.Name = "button17";
            button17.Size = new Size(39, 30);
            button17.TabIndex = 21;
            button17.Text = "Log";
            button17.UseVisualStyleBackColor = true;
            button17.Visible = false;
            button17.Click += button17_Click;
            // 
            // button18
            // 
            button18.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point);
            button18.Location = new Point(178, 39);
            button18.Margin = new Padding(3, 2, 3, 2);
            button18.Name = "button18";
            button18.Size = new Size(39, 30);
            button18.TabIndex = 20;
            button18.Text = "10^X";
            button18.UseVisualStyleBackColor = true;
            button18.Visible = false;
            button18.Click += button18_Click;
            // 
            // button5
            // 
            button5.Location = new Point(133, 4);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(39, 30);
            button5.TabIndex = 19;
            button5.Text = "x^2";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(133, 142);
            button6.Margin = new Padding(3, 2, 3, 2);
            button6.Name = "button6";
            button6.Size = new Size(39, 30);
            button6.TabIndex = 18;
            button6.Text = "+";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(133, 108);
            button7.Margin = new Padding(3, 2, 3, 2);
            button7.Name = "button7";
            button7.Size = new Size(39, 30);
            button7.TabIndex = 17;
            button7.Text = "-";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(133, 74);
            button8.Margin = new Padding(3, 2, 3, 2);
            button8.Name = "button8";
            button8.Size = new Size(39, 30);
            button8.TabIndex = 16;
            button8.Text = "*";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click_1;
            // 
            // button9
            // 
            button9.Location = new Point(133, 39);
            button9.Margin = new Padding(3, 2, 3, 2);
            button9.Name = "button9";
            button9.Size = new Size(39, 30);
            button9.TabIndex = 15;
            button9.Text = "/";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button2
            // 
            button2.Location = new Point(52, 4);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(35, 30);
            button2.TabIndex = 14;
            button2.Text = "1/x";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(93, 4);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(35, 30);
            button4.TabIndex = 13;
            button4.Text = "sqrt";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button_percent
            // 
            button_percent.Location = new Point(12, 4);
            button_percent.Margin = new Padding(3, 2, 3, 2);
            button_percent.Name = "button_percent";
            button_percent.Size = new Size(35, 30);
            button_percent.TabIndex = 12;
            button_percent.Text = "%";
            button_percent.UseVisualStyleBackColor = true;
            button_percent.Click += button_percent_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 142);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(35, 30);
            button3.TabIndex = 11;
            button3.Text = ",";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button_negative
            // 
            button_negative.Location = new Point(93, 142);
            button_negative.Margin = new Padding(3, 2, 3, 2);
            button_negative.Name = "button_negative";
            button_negative.Size = new Size(35, 30);
            button_negative.TabIndex = 10;
            button_negative.Text = "+\\-";
            button_negative.UseVisualStyleBackColor = true;
            button_negative.Click += button_negative_Click;
            // 
            // button_0
            // 
            button_0.Location = new Point(52, 142);
            button_0.Margin = new Padding(3, 2, 3, 2);
            button_0.Name = "button_0";
            button_0.Size = new Size(35, 30);
            button_0.TabIndex = 9;
            button_0.Text = "0";
            button_0.UseVisualStyleBackColor = true;
            button_0.Click += button_0_Click;
            // 
            // button_3
            // 
            button_3.Location = new Point(93, 108);
            button_3.Margin = new Padding(3, 2, 3, 2);
            button_3.Name = "button_3";
            button_3.Size = new Size(35, 30);
            button_3.TabIndex = 8;
            button_3.Text = "3";
            button_3.UseVisualStyleBackColor = true;
            button_3.Click += button_3_Click;
            // 
            // button_1
            // 
            button_1.Location = new Point(12, 108);
            button_1.Margin = new Padding(3, 2, 3, 2);
            button_1.Name = "button_1";
            button_1.Size = new Size(35, 30);
            button_1.TabIndex = 7;
            button_1.Text = "1";
            button_1.UseVisualStyleBackColor = true;
            button_1.Click += button_1_Click;
            // 
            // button_2
            // 
            button_2.Location = new Point(52, 108);
            button_2.Margin = new Padding(3, 2, 3, 2);
            button_2.Name = "button_2";
            button_2.Size = new Size(35, 30);
            button_2.TabIndex = 6;
            button_2.Text = "2";
            button_2.UseVisualStyleBackColor = true;
            button_2.Click += button_2_Click;
            // 
            // button_6
            // 
            button_6.Location = new Point(93, 74);
            button_6.Margin = new Padding(3, 2, 3, 2);
            button_6.Name = "button_6";
            button_6.Size = new Size(35, 30);
            button_6.TabIndex = 5;
            button_6.Text = "6";
            button_6.UseVisualStyleBackColor = true;
            button_6.Click += button_6_Click;
            // 
            // button_8
            // 
            button_8.Location = new Point(52, 39);
            button_8.Margin = new Padding(3, 2, 3, 2);
            button_8.Name = "button_8";
            button_8.Size = new Size(35, 30);
            button_8.TabIndex = 4;
            button_8.Text = "8";
            button_8.UseVisualStyleBackColor = true;
            button_8.Click += button_8_Click;
            // 
            // button_9
            // 
            button_9.Location = new Point(93, 39);
            button_9.Margin = new Padding(3, 2, 3, 2);
            button_9.Name = "button_9";
            button_9.Size = new Size(35, 30);
            button_9.TabIndex = 3;
            button_9.Text = "9";
            button_9.UseVisualStyleBackColor = true;
            button_9.Click += button_9_Click;
            // 
            // button_4
            // 
            button_4.Location = new Point(12, 74);
            button_4.Margin = new Padding(3, 2, 3, 2);
            button_4.Name = "button_4";
            button_4.Size = new Size(35, 30);
            button_4.TabIndex = 2;
            button_4.Text = "4";
            button_4.UseVisualStyleBackColor = true;
            button_4.Click += button_4_Click;
            // 
            // button_5
            // 
            button_5.Location = new Point(52, 74);
            button_5.Margin = new Padding(3, 2, 3, 2);
            button_5.Name = "button_5";
            button_5.Size = new Size(35, 30);
            button_5.TabIndex = 1;
            button_5.Text = "5";
            button_5.UseVisualStyleBackColor = true;
            button_5.Click += button_5_Click;
            // 
            // button_7
            // 
            button_7.Location = new Point(12, 39);
            button_7.Margin = new Padding(3, 2, 3, 2);
            button_7.Name = "button_7";
            button_7.Size = new Size(35, 30);
            button_7.TabIndex = 0;
            button_7.Text = "7";
            button_7.UseVisualStyleBackColor = true;
            button_7.Click += button_7_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(383, 312);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Калькулятор";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Panel panel1;
        private Label label1;
        private Button button_angle;
        private Button button10;
        private Button button_erase_all;
        private Button button12;
        private Button button1;
        private Panel panel2;
        private Button button19;
        private Button button22;
        private Button button23;
        private Button button24;
        private Button button25;
        private Button button26;
        private Button button27;
        private Button button28;
        private Button button14;
        private Button button15;
        private Button button16;
        private Button button17;
        private Button button18;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button2;
        private Button button4;
        private Button button_percent;
        private Button button3;
        private Button button_negative;
        private Button button_0;
        private Button button_3;
        private Button button_1;
        private Button button_2;
        private Button button_6;
        private Button button_8;
        private Button button_9;
        private Button button_4;
        private Button button_5;
        private Button button_7;
    }
}