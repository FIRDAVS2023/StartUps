namespace Calculator_2
{
    public partial class Form1 : Form
    {
        bool mode = false;

        bool input = true;
        //char trig_mode;

        char last_operation = ' ';
        string last_operand = "";

        double PI = Math.Acos(-1); //number Pi

        public struct Leksema
        {
            public char type; //0 for number, "+" for add, ...
            public double value;
        }

        public Form1()
        {
            InitializeComponent();



            textBox1.MaxLength = 16;
            textBox2.MaxLength = 16;
            textBox1.Text = "0";
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;


        }

        public int getRang(char ch) // get rang of operation
        {
            if (ch == 's' || ch == 'c' || ch == 't' || ch == 'e' || ch == 'g')
                return 4;
            if (ch == '^')
                return 3;
            if (ch == '+' || ch == '-')
                return 1;
            if (ch == '*' || ch == '/')
                return 2;

            return 0;
        }

        public bool Maths(ref Stack<Leksema> Stack_n, ref Stack<Leksema> Stack_o, ref Leksema item) //calculation
        {
            double a, b, c;
            a = Stack_n.Pop().value;         //takes top number
            switch (Stack_o.Pop().type)
            {
                case '+':
                    b = Stack_n.Pop().value; // takes top operation
                    c = a + b;               //result of operation

                    item.type = '0';
                    item.value = c;
                    Stack_n.Push(item);      // to add result in stack

                    break;

                case '-':
                    b = Stack_n.Pop().value;
                    c = b - a;

                    item.type = '0';
                    item.value = c;
                    Stack_n.Push(item);

                    break;

                case '*':
                    b = Stack_n.Pop().value;
                    c = a * b;

                    item.type = '0';
                    item.value = c;
                    Stack_n.Push(item);

                    break;

                case '/':
                    b = Stack_n.Pop().value;
                    if (a == 0)
                    {
                        MessageBox.Show("Division by zero!");
                        textBox1.Text = "0";
                        textBox2.Text = "";
                        input = true;
                        last_operand = "";
                        last_operation = ' ';
                        label1.Text = "";
                        return false;
                    }
                    c = b / a;
                    item.type = '0';
                    item.value = c;
                    Stack_n.Push(item);

                    break;

                case '^':
                    b = Stack_n.Pop().value;
                    c = Math.Pow(b, a);

                    item.type = '0';
                    item.value = c;
                    Stack_n.Push(item);

                    break;

                case 's':

                    if (button_angle.Text == "Угол")
                    {
                        a = a * Math.PI / 180;
                    }

                    c = Math.Round(Math.Sin(a), 10);

                    item.type = '0';
                    item.value = c;
                    Stack_n.Push(item);

                    break;

                case 'c':

                    if (button_angle.Text == "Угол")
                    {
                        a = a * Math.PI / 180;
                    }

                    c = Math.Round(Math.Cos(a), 10);

                    item.type = '0';
                    item.value = c;
                    Stack_n.Push(item);

                    break;

                case 'e':

                    c = Math.Exp(a);

                    item.type = '0';
                    item.value = c;
                    Stack_n.Push(item);

                    break;
                case 't':

                    if (button_angle.Text == "Угол")
                    {
                        a = a * Math.PI / 180;
                    }

                    double tmp = Math.Cos(a);

                    if ((Math.Cos(a) >= -3.491481338843555E-15 && Math.Cos(a) <= -3.4914813388E-15) || (Math.Cos(a) >= -1.8369701987210297E-16 && Math.Cos(a) <= -1.83697019872E-16))
                    {
                        MessageBox.Show("Not correct argument for tan!");
                        textBox1.Text = "0";
                        textBox2.Text = "";
                        input = true;
                        last_operand = "";
                        last_operation = ' ';
                        label1.Text = "";
                        return false;
                    }


                    double bc = Math.Sin(a);
                    if (bc < 0.00000000001 && bc > 0)
                    {
                        bc = 0;
                    }


                    c = bc / tmp;

                    item.type = '0';
                    item.value = c;
                    Stack_n.Push(item);

                    break;

                case 'm':
                    b = Stack_n.Pop().value;
                    if (a == 0) c = b;
                    else c = b % a;

                    item.type = '0';
                    item.value = c;
                    Stack_n.Push(item);

                    break;

                default:
                    MessageBox.Show("Error!");
                    textBox1.Text = "0";
                    textBox2.Text = "";
                    input = true;
                    last_operand = "";
                    last_operation = ' ';
                    label1.Text = "";
                    return false;

            }
            return true;
        }

        public void Arifmetic()
        {
            Stack<Leksema> Stack_n = new Stack<Leksema>();
            Stack<Leksema> Stack_o = new Stack<Leksema>();

            Leksema item = new Leksema();

            string ch = textBox2.Text;

            int i = 0;

            bool flag = true;
            bool error = false;
            while (i < ch.Length)
            {

                if (ch[i] == ' ')
                {
                    i++;
                    continue;
                }

                if (ch[i] == 's' || ch[i] == 'c' || ch[i] == 't' || ch[i] == 'e')
                {
                    string foo = "";
                    for (int j = 0; j < 3; j++)
                    {
                        foo += ch[i];
                        i++;
                    }



                    if (foo == "sin")
                    {
                        item.type = 's';
                        item.value = 0;
                        Stack_o.Push(item);

                        continue;
                    }

                    if (foo == "cos")
                    {
                        item.type = 'c';
                        item.value = 0;
                        Stack_o.Push(item);

                        continue;
                    }

                    if (foo == "tan")
                    {
                        item.type = 't';
                        item.value = 0;
                        Stack_o.Push(item);

                        continue;
                    }

                    if (foo == "ctg")
                    {
                        item.type = 'g';
                        item.value = 0;
                        Stack_o.Push(item);

                        continue;
                    }

                    if (foo == "exp")
                    {
                        item.type = 'e';
                        item.value = 0;
                        Stack_o.Push(item);

                        continue;
                    }
                }

                if (ch[i] == 'p')
                {
                    item.type = '0';
                    item.value = PI;
                    Stack_n.Push(item);
                    flag = false;
                    i += 2;
                    continue;

                }
                if (ch[i] >= '0' && ch[i] <= '9' || ch[i] == '-' && flag == true) // if a number is read
                {

                    string value_tmp = "";
                    while ((i < ch.Length && (Char.IsDigit(ch[i]) || ch[i] == ',')) || (i < ch.Length && ch[i] == '-' && flag == true))
                    {
                        flag = false;
                        value_tmp += ch[i];
                        i++;
                    }
                    item.type = '0';

                    item.value = Double.Parse(value_tmp);
                    Stack_n.Push(item);
                    flag = false;
                    continue;

                }
                if (ch[i] == '+' || ch[i] == '-' && flag == false || ch[i] == '*' || ch[i] == '/' || ch[i] == '^' || ch[i] == 'm') // if a operation is read
                {
                    if (Stack_o.Count == 0) // if stack with operation is empty
                    {
                        item.type = ch[i];
                        item.value = 0;

                        Stack_o.Push(item);
                        i++;
                        continue;
                    }
                    if (Stack_o.Count != 0 && getRang(ch[i]) > getRang(Stack_o.Peek().type)) //if stack with operation is not emtry and rang o1 > o2
                    {
                        item.type = ch[i];
                        item.value = 0;

                        Stack_o.Push(item);
                        i++;
                        continue;
                    }
                    if (Stack_o.Count != 0 && getRang(ch[i]) <= getRang(Stack_o.Peek().type))
                        if (!Maths(ref Stack_n, ref Stack_o, ref item))
                        {
                            label1.Text = "Error";
                            error = true;
                            break;
                        }
                    continue;
                }
                if (ch[i] == '(')
                {
                    item.type = ch[i];
                    item.value = 0;
                    Stack_o.Push(item);
                    i++;
                    flag = true;
                    continue;
                }
                if (ch[i] == ')')
                {
                    while (Stack_o.Peek().type != '(')
                    {
                        if (!Maths(ref Stack_n, ref Stack_o, ref item))
                        {
                            label1.Text = "Error";
                            error = true;
                            break;
                        }
                        else continue;
                    }
                    Stack_o.Pop();
                    i++;
                    continue;
                }
                else
                {
                    MessageBox.Show("Выход из диапазона допустимых чисел!");
                    textBox1.Text = "0";
                    textBox2.Text = "";
                    input = true;
                    last_operand = "";
                    last_operation = ' ';
                    error = true;
                    break;
                }
                i++;


            }

            if (error)
            {

                return;
            }
            else
            {
                while (Stack_o.Count != 0)
                {
                    if (!Maths(ref Stack_n, ref Stack_o, ref item))
                    {
                        return;
                    }

                    else continue;

                }

                if (Stack_n.Count != 0 && (Stack_n.Peek().value > 10000000000000000000 || Stack_n.Peek().value < -1000000000000000000) || (Stack_n.Peek().value < 0.000000000000000001 && Stack_n.Peek().value > 0))
                {
                    MessageBox.Show("Выход из диапазона допустимых чисел!");
                    textBox1.Text = "0";
                    textBox2.Text = "";
                    input = true;
                    last_operand = "";
                    last_operation = ' ';

                }
                else
                {

                    textBox1.Text = Decimal.Round((decimal)Stack_n.Peek().value, 28).ToString();
                    textBox2.Text = "";




                    int count = 0;
                    int a = textBox1.Text.IndexOf(',');
                    bool all_null = true;
                    if (a != -1)
                    {
                        string tmp = textBox1.Text.Substring(a + 1);
                        foreach (char k in tmp)
                        {

                            if (k != '0')
                            {

                                all_null = false;
                                break;
                            }
                        }

                    }
                    if (all_null && a != -1)
                    {
                        textBox1.Text = textBox1.Text[0..a];
                    }

                }

            }
        }


        void binar_operation(char operation)
        {
            List<char> operations = new List<char> { '+', '-', '*', '/', 'm', '^' };

            if (textBox2.Text == "")
            {
                textBox2.Text = textBox1.Text + operation;
                input = true;
            }
            else if (textBox2.Text[textBox2.Text.Length - 1] >= '0' && textBox2.Text[textBox2.Text.Length - 1] <= '9')
            {
                if (input)
                {
                    textBox2.Text += operation;
                    input = true;
                }
                else
                {
                    textBox2.Text = textBox1.Text + operation;
                    input = true;
                }
            }
            else if (operations.Contains(textBox2.Text[textBox2.Text.Length - 1]))
            {
                //input = true;
                if (!input || textBox1.Text == "0")
                {
                    if (operation == '^')
                    {
                        if (Convert.ToDouble(textBox2.Text.Remove(textBox2.Text.Length - 1)) < 0 && Convert.ToDouble(textBox1.Text) < 1 && Convert.ToDouble(textBox1.Text) > 0)
                        {
                            
                           
                            
                            MessageBox.Show("Возведение в степень не возможна");
                            button_erase_all_Click1();
                            return;
                        }

                        if (Convert.ToDouble(textBox1.Text) < 0)
                        {
                            textBox2.Text += $"({textBox1.Text})";
                        }
                        else
                        {
                            textBox2.Text += textBox1.Text;
                        }
                        //textBox2.Text += textBox1.Text;


                        Arifmetic();
                        textBox2.Text = textBox1.Text + "^";
                        input = true;
                    }
                    else if (operation == '/')
                    {

                        if (textBox1.Text == "0")
                        {
                            MessageBox.Show("Division by zero!!!");
                            button_erase_all_Click1();
                            return;
                        }

                        if (Convert.ToDouble(textBox1.Text) < 0)
                        {
                            textBox2.Text += $"({textBox1.Text})";
                        }
                        else
                        {
                            textBox2.Text += textBox1.Text;
                        }
                        //textBox2.Text += textBox1.Text;



                        Arifmetic();
                        textBox2.Text = textBox1.Text + "/";
                        input = true;
                    }
                    else
                    {
                        if (Convert.ToDouble(textBox1.Text) < 0)
                        {
                            textBox2.Text += $"({textBox1.Text})";
                        }
                        else
                        {
                            textBox2.Text += textBox1.Text;
                        }
                        //textBox2.Text += textBox1.Text;
                        Arifmetic();
                        textBox2.Text = textBox1.Text + operation;
                        input = true;
                    }

                }
                else if (input)
                {
                    textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
                    textBox2.Text += operation;

                }

            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && (textBox2.Text[textBox2.Text.Length - 1] == '-' || textBox2.Text[textBox2.Text.Length - 1] == '+' || textBox2.Text[textBox2.Text.Length - 1] == '*' ||
                textBox2.Text[textBox2.Text.Length - 1] == '/' || textBox2.Text[textBox2.Text.Length - 1] == '^' || textBox2.Text[textBox2.Text.Length - 1] == 'm'))
            {
                char op = textBox2.Text[textBox2.Text.Length - 1];

                if (textBox1.Text == "0" && op == '/')
                {
                    MessageBox.Show("Division by zero!!!");
                    button_erase_all_Click(sender, e);
                    return;
                }
                int tmp;
                if (op == '^' && Convert.ToDouble(textBox2.Text.Remove(textBox2.Text.Length - 1)) < 0 && (!Int32.TryParse(textBox1.Text, out tmp)))
                {
                    MessageBox.Show("Возведение в степень невозможна");
                    button_erase_all_Click(sender, e);
                    return;
                }

                //double operand1 = Convert.ToDouble(textBox2.Text.Substring(0, textBox2.Text.IndexOf(op)));
                double operand2 = Convert.ToDouble(textBox1.Text);

                if (operand2 < 0)
                {
                    textBox2.Text += $"({operand2})";
                }
                else
                {
                    textBox2.Text += $"{operand2}";
                }

                //last operation and operand
                last_operation = op;
                last_operand = operand2.ToString();
                label1.Text = $"Last: {last_operation} {last_operand}";

                Arifmetic();
                input = true;
            }
            else
            {
                if (last_operation != ' ' && last_operand != "")
                {

                    textBox2.Text = textBox1.Text + last_operation + $"({last_operand})";
                    Arifmetic();
                    input = true;
                }
                else
                {
                    textBox2.Text = textBox1.Text;
                    input = true;
                }

            }
        }

        void button_erase_all_Click1()
        {
            textBox1.Text = "0";
            textBox2.Text = "";
            input = true;
            label1.Text = "";
            last_operand = "";
            last_operation = ' ';
        }
        private void button_erase_all_Click(object sender, EventArgs e)
        {
            button_erase_all_Click1();
        }


        private void button7_Click(object sender, EventArgs e)
        {
            binar_operation('-');
        }

        private void button6_Click(object sender, EventArgs e)
        {
            binar_operation('+');
        }

        private void button9_Click(object sender, EventArgs e)
        {
            binar_operation('/');
        }

        private void button14_Click(object sender, EventArgs e)
        {
            binar_operation('^');
        }

        private void button12_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length == 1)
            {
                textBox1.Text = "0";

                input = true;
            }
            else
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);

            if (textBox1.Text == "-")
            {
                textBox1.Text = "0";
                input = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mode = !mode;
            button_erase_all_Click1();
            button_percent.Visible = !button_percent.Visible;
            button14.Visible = !button14.Visible;
            button24.Visible = !button24.Visible;
            button27.Visible = !button27.Visible;
            button18.Visible = !button18.Visible;
            button17.Visible = !button17.Visible;
            button16.Visible = !button16.Visible;
            button15.Visible = !button15.Visible;
            button28.Visible = !button28.Visible;
            button26.Visible = !button26.Visible;
            button25.Visible = !button25.Visible;
            button19.Visible = !button19.Visible;
            button23.Visible = !button23.Visible;
            button22.Visible = !button22.Visible;

        }

        private void button27_Click(object sender, EventArgs e)
        {
            textBox1.Text = $"{Math.PI}";
            input = false;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            textBox1.Text = $"{Math.E}";
            input = false;
        }

        private void button25_Click(object sender, EventArgs e)
        {

            if (textBox2.Text == "" || (textBox2.Text[textBox2.Text.Length - 1] >= '0' &&
                textBox2.Text[textBox2.Text.Length - 1] <= '9'))
            {
                textBox2.Text = $"{Math.Exp(Double.Parse(textBox1.Text))}";
                Arifmetic();
                input = true;
            }
            else if (textBox2.Text.Length != 0 && (textBox2.Text[textBox2.Text.Length - 1] == '+' || textBox2.Text[textBox2.Text.Length - 1] == '-' || textBox2.Text[textBox2.Text.Length - 1] == '*' ||
                     textBox2.Text[textBox2.Text.Length - 1] == '/' || textBox2.Text[textBox2.Text.Length - 1] == '^' || textBox2.Text[textBox2.Text.Length - 1] == 'm'))
            {


                last_operation = textBox2.Text[textBox2.Text.Length - 1];
                last_operand = $"{Math.Exp(Double.Parse(textBox1.Text))}";

                label1.Text = $"{last_operation} {last_operand}";

                textBox2.Text += $"{last_operand}";
                Arifmetic();
                input = true;

            }
        }

        private void button_percent_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && (textBox2.Text[textBox2.Text.Length - 1] == '-' || textBox2.Text[textBox2.Text.Length - 1] == '+' || textBox2.Text[textBox2.Text.Length - 1] == '*' ||
                textBox2.Text[textBox2.Text.Length - 1] == '/' || textBox2.Text[textBox2.Text.Length - 1] == '^' || textBox2.Text[textBox2.Text.Length - 1] == 'm'))
            {
                char op = textBox2.Text[textBox2.Text.Length - 1];

                int ind = textBox2.Text.IndexOf(textBox2.Text[textBox2.Text.Length - 1]);

                string tmp1 = textBox2.Text[0..(textBox2.Text.Length - 1)];

                double res = Double.Parse(tmp1) * Double.Parse(textBox1.Text) / 100;

                if (res == 0 && op == '/')
                {
                    MessageBox.Show("Division by zero!!!");
                    button_erase_all_Click(sender, e);
                    return;
                }

                if (op == '^' && Convert.ToDouble(textBox2.Text.Remove(textBox2.Text.Length - 1)) < 0 && res < 1 && res > 0)
                {
                    MessageBox.Show("Возведение в степень не возможна");
                    button_erase_all_Click(sender, e);
                    return;
                }

                //double operand1 = Convert.ToDouble(textBox2.Text.Substring(0, textBox2.Text.IndexOf(op)));
                double operand2 = res;

                if (operand2 < 0)
                {
                    textBox2.Text += $"({operand2})";
                }
                else
                {
                    textBox2.Text += $"{operand2}";
                }

                //last operation and operand
                last_operation = op;
                last_operand = operand2.ToString();
                label1.Text = $"Last: {last_operation} {last_operand}";

                Arifmetic();
                input = true;
            }
            else
            {
                button_erase_all_Click(sender, e);
            }
        }

        private void button_7_Click(object sender, EventArgs e)
        {
            if (input == true)
            {
                input = false;
                //first_input = true;
                textBox1.Text = "7";
            }
            else if (!input)
            {
                textBox1.Text += "7";
            }
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            if (input == true)
            {
                input = false;
                //first_input = true;
                textBox1.Text = "8";
            }
            else if (!input)
            {
                textBox1.Text += "8";
            }
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            if (input == true)
            {
                input = false;
                //first_input = true;
                textBox1.Text = "1";
            }
            else if (!input)
            {
                textBox1.Text += "1";
            }
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            if (input == true)
            {
                input = false;
                //first_input = true;
                textBox1.Text = "2";
            }
            else if (!input)
            {
                textBox1.Text += "2";
            }
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            if (input == true)
            {
                input = false;
                //first_input = true;
                textBox1.Text = "3";
            }
            else if (!input)
            {
                textBox1.Text += "3";
            }
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            if (input == true)
            {
                input = false;
                //first_input = true;
                textBox1.Text = "4";
            }
            else if (!input)
            {
                textBox1.Text += "4";
            }
        }

        private void button_5_Click(object sender, EventArgs e)
        {
            if (input == true)
            {
                input = false;
                //first_input = true;
                textBox1.Text = "5";
            }
            else if (!input)
            {
                textBox1.Text += "5";
            }
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            if (input == true)
            {
                input = false;
                //first_input = true;
                textBox1.Text = "6";
            }
            else if (!input)
            {
                textBox1.Text += "6";
            }
        }

        private void button_9_Click(object sender, EventArgs e)
        {
            if (input == true)
            {
                input = false;
                //first_input = true;
                textBox1.Text = "9";
            }
            else if (!input)
            {
                textBox1.Text += "9";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                MessageBox.Show("Делить на ноль нельзя");
                button_erase_all_Click(sender, e);
                return;
            }

            if (textBox2.Text == "" || (textBox2.Text[textBox2.Text.Length - 1] >= '0' &&
                textBox2.Text[textBox2.Text.Length - 1] <= '9'))
            {
                textBox2.Text = $"1/({textBox1.Text})";
                Arifmetic();
                input = true;
            }
            else if (textBox2.Text.Length != 0 && (textBox2.Text[textBox2.Text.Length - 1] == '+' || textBox2.Text[textBox2.Text.Length - 1] == '-' || textBox2.Text[textBox2.Text.Length - 1] == '*' ||
                     textBox2.Text[textBox2.Text.Length - 1] == '/' || textBox2.Text[textBox2.Text.Length - 1] == '^' || textBox2.Text[textBox2.Text.Length - 1] == 'm'))
            {


                last_operation = textBox2.Text[textBox2.Text.Length - 1];
                last_operand = $"{1 / Double.Parse(textBox1.Text)}";

                label1.Text = $"Last: {last_operation} {last_operand}";

                textBox2.Text += $"({last_operand})";
                Arifmetic();
                input = true;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || (textBox2.Text[textBox2.Text.Length - 1] >= '0' &&
               textBox2.Text[textBox2.Text.Length - 1] <= '9'))
            {
                textBox2.Text = $"{textBox1.Text}^2";
                Arifmetic();
                input = true;
            }
            else if (textBox2.Text.Length != 0 && (textBox2.Text[textBox2.Text.Length - 1] == '+' || textBox2.Text[textBox2.Text.Length - 1] == '-' || textBox2.Text[textBox2.Text.Length - 1] == '*' ||
                     textBox2.Text[textBox2.Text.Length - 1] == '/' || textBox2.Text[textBox2.Text.Length - 1] == '^' || textBox2.Text[textBox2.Text.Length - 1] == 'm'))
            {


                last_operation = textBox2.Text[textBox2.Text.Length - 1];
                last_operand = $"({textBox1.Text})^2";

                label1.Text = $"Last: {last_operation} ({textBox1.Text})^2";

                textBox2.Text += $"({textBox1.Text})^2";
                Arifmetic();
                input = true;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.IndexOf('-') != -1)
            {
                MessageBox.Show("Найти корень от отрицательного числа нельзя");
                button_erase_all_Click(sender, e);
                return;
            }

            if (textBox2.Text == "" || (textBox2.Text[textBox2.Text.Length - 1] >= '0' &&
                textBox2.Text[textBox2.Text.Length - 1] <= '9'))
            {
                textBox2.Text = $"{textBox1.Text}^(1/2)";
                Arifmetic();
                input = true;
            }
            else if (textBox2.Text.Length != 0 && (textBox2.Text[textBox2.Text.Length - 1] == '+' || textBox2.Text[textBox2.Text.Length - 1] == '-' || textBox2.Text[textBox2.Text.Length - 1] == '*' ||
                     textBox2.Text[textBox2.Text.Length - 1] == '/' || textBox2.Text[textBox2.Text.Length - 1] == '^' || textBox2.Text[textBox2.Text.Length - 1] == 'm'))
            {


                last_operation = textBox2.Text[textBox2.Text.Length - 1];
                last_operand = $"({Math.Sqrt(Double.Parse(textBox1.Text))}";

                label1.Text = $"Last: {last_operation} {last_operand}";

                textBox2.Text += $"({textBox1.Text})^(1/2)";
                Arifmetic();
                input = true;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains(','))
            {
                textBox1.Text += ',';
                input = false;
            }
        }

        private void button_negative_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || Double.Parse(textBox1.Text) == 0)
            {
                return;
            }
            input = false;
            if (textBox1.Text.IndexOf("-") == -1)
            {
                textBox1.Text = '-' + textBox1.Text;
            }
            else
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.IndexOf("-"), 1);
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || (textBox2.Text[textBox2.Text.Length - 1] >= '0' &&
                textBox2.Text[textBox2.Text.Length - 1] <= '9'))
            {
                textBox2.Text = $"cos({textBox1.Text})";
                Arifmetic();
                input = true;
            }
            else if (textBox2.Text.Length != 0 && (textBox2.Text[textBox2.Text.Length - 1] == '+' || textBox2.Text[textBox2.Text.Length - 1] == '-' || textBox2.Text[textBox2.Text.Length - 1] == '*' ||
                     textBox2.Text[textBox2.Text.Length - 1] == '/' || textBox2.Text[textBox2.Text.Length - 1] == '^' || textBox2.Text[textBox2.Text.Length - 1] == 'm'))
            {


                last_operation = textBox2.Text[textBox2.Text.Length - 1];
                last_operand = $"cos({textBox1.Text})";

                label1.Text = $"Last: {last_operation} {last_operand}";

                textBox2.Text += $"({last_operand})";
                Arifmetic();
                input = true;

            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || (textBox2.Text[textBox2.Text.Length - 1] >= '0' &&
                textBox2.Text[textBox2.Text.Length - 1] <= '9'))
            {
                textBox2.Text = $"tan({textBox1.Text})";
                Arifmetic();
                input = true;
            }
            else if (textBox2.Text.Length != 0 && (textBox2.Text[textBox2.Text.Length - 1] == '+' || textBox2.Text[textBox2.Text.Length - 1] == '-' || textBox2.Text[textBox2.Text.Length - 1] == '*' ||
                     textBox2.Text[textBox2.Text.Length - 1] == '/' || textBox2.Text[textBox2.Text.Length - 1] == '^' || textBox2.Text[textBox2.Text.Length - 1] == 'm'))
            {


                last_operation = textBox2.Text[textBox2.Text.Length - 1];
                last_operand = $"tan({textBox1.Text})";

                label1.Text = $"Last: {last_operation} {last_operand}";

                textBox2.Text += $"({last_operand})";
                Arifmetic();
                input = true;

            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || (textBox2.Text[textBox2.Text.Length - 1] >= '0' &&
                textBox2.Text[textBox2.Text.Length - 1] <= '9'))
            {
                textBox2.Text = $"sin({textBox1.Text})";
                Arifmetic();
                input = true;
            }
            else if (textBox2.Text.Length != 0 && (textBox2.Text[textBox2.Text.Length - 1] == '+' || textBox2.Text[textBox2.Text.Length - 1] == '-' || textBox2.Text[textBox2.Text.Length - 1] == '*' ||
                     textBox2.Text[textBox2.Text.Length - 1] == '/' || textBox2.Text[textBox2.Text.Length - 1] == '^'))
            {


                last_operation = textBox2.Text[textBox2.Text.Length - 1];
                last_operand = $"sin({textBox1.Text})";

                label1.Text = $"Last: {last_operation} {last_operand}";

                textBox2.Text += $"({last_operand})";
                Arifmetic();
                input = true;

            }
        }

        Decimal Factorial(Decimal n)
        {
            if (n == 0) return 1;

            return n * Factorial(n - 1);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (Decimal.Parse(textBox1.Text) > 24 || Double.Parse(textBox1.Text) < 0 || Double.Parse(textBox1.Text) != (int)Double.Parse(textBox1.Text))
            {
                MessageBox.Show("Factirial error!");
                button_erase_all_Click(sender, e);
                return;
            }
            input = true;

            if (textBox2.Text == "" || (textBox2.Text[textBox2.Text.Length - 1] >= '0' &&
                textBox2.Text[textBox2.Text.Length - 1] <= '9'))
            {
                textBox2.Text = $"{Factorial(Decimal.Parse(textBox1.Text))}";
                Arifmetic();
                input = true;
            }
            else if (textBox2.Text.Length != 0 && (textBox2.Text[textBox2.Text.Length - 1] == '+' || textBox2.Text[textBox2.Text.Length - 1] == '-' || textBox2.Text[textBox2.Text.Length - 1] == '*' ||
                     textBox2.Text[textBox2.Text.Length - 1] == '/' || textBox2.Text[textBox2.Text.Length - 1] == '^' || textBox2.Text[textBox2.Text.Length - 1] == 'm'))
            {


                last_operation = textBox2.Text[textBox2.Text.Length - 1];
                last_operand = $"{Factorial(Int32.Parse(textBox1.Text))}";

                label1.Text = $"Last: {last_operation} {last_operand}";

                textBox2.Text += $"{last_operand}";
                Arifmetic();
                input = true;

            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            input = true;

            if (textBox1.Text.IndexOf("-") != -1)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.IndexOf("-"), 1);
            }

            if (textBox2.Text == "" || (textBox2.Text[textBox2.Text.Length - 1] >= '0' &&
                textBox2.Text[textBox2.Text.Length - 1] <= '9'))
            {
                textBox2.Text = $"{textBox1.Text}";
                //Arifmetic();
                input = true;
            }
            else if (textBox2.Text.Length != 0 && (textBox2.Text[textBox2.Text.Length - 1] == '+' || textBox2.Text[textBox2.Text.Length - 1] == '-' || textBox2.Text[textBox2.Text.Length - 1] == '*' ||
                     textBox2.Text[textBox2.Text.Length - 1] == '/' || textBox2.Text[textBox2.Text.Length - 1] == '^'))
            {

                last_operation = textBox2.Text[textBox2.Text.Length - 1];
                last_operand = textBox1.Text;

                label1.Text = $"Last: {last_operation} {textBox1.Text}";

                textBox2.Text += $"{textBox1.Text}";
                Arifmetic();
                input = true;

            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (Double.Parse(textBox1.Text) <= 0)
            {
                MessageBox.Show("Ln error!");
                button_erase_all_Click(sender, e);
                return;
            }

            if (textBox2.Text == "" || (textBox2.Text[textBox2.Text.Length - 1] >= '0' &&
                textBox2.Text[textBox2.Text.Length - 1] <= '9'))
            {
                textBox2.Text = $"{Math.Log(Double.Parse(textBox1.Text))}";
                Arifmetic();
                input = true;
            }
            else if (textBox2.Text.Length != 0 && (textBox2.Text[textBox2.Text.Length - 1] == '+' || textBox2.Text[textBox2.Text.Length - 1] == '-' || textBox2.Text[textBox2.Text.Length - 1] == '*' ||
                     textBox2.Text[textBox2.Text.Length - 1] == '/' || textBox2.Text[textBox2.Text.Length - 1] == '^' || textBox2.Text[textBox2.Text.Length - 1] == 'm'))
            {


                last_operation = textBox2.Text[textBox2.Text.Length - 1];
                last_operand = $"({Math.Log(Double.Parse(textBox1.Text))})";

                label1.Text = $"Last: {last_operation} {last_operand}";

                textBox2.Text += $"{last_operand}";
                Arifmetic();
                input = true;

            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || (textBox2.Text[textBox2.Text.Length - 1] >= '0' &&
                textBox2.Text[textBox2.Text.Length - 1] <= '9'))
            {
                textBox2.Text = $"10^({textBox1.Text})";
                Arifmetic();
                input = true;
            }
            else if (textBox2.Text.Length != 0 && (textBox2.Text[textBox2.Text.Length - 1] == '+' || textBox2.Text[textBox2.Text.Length - 1] == '-' || textBox2.Text[textBox2.Text.Length - 1] == '*' ||
                     textBox2.Text[textBox2.Text.Length - 1] == '/' || textBox2.Text[textBox2.Text.Length - 1] == '^' || textBox2.Text[textBox2.Text.Length - 1] == 'm'))
            {


                last_operation = textBox2.Text[textBox2.Text.Length - 1];
                last_operand = $"{Math.Pow(10, Double.Parse(textBox1.Text))}";

                label1.Text = $"Last: {last_operation} {last_operand}";

                textBox2.Text += $"({last_operand})";
                Arifmetic();
                input = true;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (Double.Parse(textBox1.Text) <= 0)
            {
                MessageBox.Show("Log error!");
                button_erase_all_Click(sender, e);
                return;
            }

            if (textBox2.Text == "" || (textBox2.Text[textBox2.Text.Length - 1] >= '0' &&
                textBox2.Text[textBox2.Text.Length - 1] <= '9'))
            {
                textBox2.Text = $"{Math.Log10(Double.Parse(textBox1.Text))}";
                Arifmetic();
                input = true;
            }
            else if (textBox2.Text.Length != 0 && (textBox2.Text[textBox2.Text.Length - 1] == '+' || textBox2.Text[textBox2.Text.Length - 1] == '-' || textBox2.Text[textBox2.Text.Length - 1] == '*' ||
                     textBox2.Text[textBox2.Text.Length - 1] == '/' || textBox2.Text[textBox2.Text.Length - 1] == '^' || textBox2.Text[textBox2.Text.Length - 1] == 'm'))
            {


                last_operation = textBox2.Text[textBox2.Text.Length - 1];
                last_operand = $"{Math.Log10(Double.Parse(textBox1.Text))}";

                label1.Text = $"Last: {last_operation} {last_operand}";

                textBox2.Text += $"{last_operand}";
                Arifmetic();
                input = true;

            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = textBox1.Text + "m";
                input = true;
            }
            else if (textBox2.Text[textBox2.Text.Length - 1] >= '0' && textBox2.Text[textBox2.Text.Length - 1] <= '9')
            {
                if (input)
                {
                    textBox2.Text += "m";
                    input = true;
                }
                else
                {
                    textBox2.Text = textBox1.Text + "m";
                    input = true;
                }

            }
            else if (textBox2.Text[textBox2.Text.Length - 1] == '-' || textBox2.Text[textBox2.Text.Length - 1] == '+' || textBox2.Text[textBox2.Text.Length - 1] == '*' ||
                textBox2.Text[textBox2.Text.Length - 1] == '/' || textBox2.Text[textBox2.Text.Length - 1] == '^')
            {
                //input = true;
                if (!input || textBox1.Text == "0")
                {
                    if (Convert.ToDouble(textBox1.Text) < 0)
                    {
                        textBox2.Text += $"({textBox1.Text})";
                    }
                    else
                    {
                        textBox2.Text += textBox1.Text;
                    }
                    //textBox2.Text += textBox1.Text;
                    Arifmetic();
                    textBox2.Text = textBox1.Text + "m";
                    input = true;
                }
                else if (input)
                {
                    textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
                    textBox2.Text += 'm';

                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (button_angle.Text == "Угол")
            {
                button_angle.Text = "Радианы";

            }
            else
            {
                button_angle.Text = "Угол";

            }
        }

        private void button_0_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                return;
            }

            if (input == true)
            {
                //zero_click = true;
                //input = false;
                //first_input = true;
                textBox1.Text = "0";
            }
            else if (!input)
            {
                textBox1.Text += "0";
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            binar_operation('*');
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}