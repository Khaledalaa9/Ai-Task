namespace puzzle
{
    public partial class Form1 : Form
    {
        List<puzzle> puzzls = new List<puzzle>();
        public Form1()
        {
            InitializeComponent();
            init();
            shuffle();
        }
        void init()
        {
            puzzls.Add(button1);
            puzzls.Add(button2);
            puzzls.Add(button3);
            puzzls.Add(button4);
            puzzls.Add(button5);
            puzzls.Add(button6);
            puzzls.Add(button7);
            puzzls.Add(button8);
            puzzls.Add(button9);
            place(puzzls[0], null, button2, null, button4);
            place(puzzls[1], button1, button3, null, button5);
            place(puzzls[2], button2, null, null, button6);
            place(puzzls[3], null, button5, button1, button7);
            place(puzzls[4], button4, button6, button2, button8);
            place(puzzls[5], button5, null,button3, button9);
            place(puzzls[6], null, button8, button4, null);
            place(puzzls[7], button7, button9, button5, null);
            place(puzzls[8],  button8, null, button6, null);

        }
        void place(puzzle x,puzzle left, puzzle right, puzzle up, puzzle down)
        {
            x.left = left;
            x.right = right;
            x.up = up;
            x.down = down;

        }
        void shuffle()
        {
            List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Random r = new Random();
            nums = nums.OrderBy(x => r.Next()).ToList();
            for( int i = 0; i < puzzls.Count; i++)
            {
                if (nums[i]==9)
                {
                    puzzls[i].Text = "";
                }
                else
                {
                    puzzls[i].Text = nums[i].ToString();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (((puzzle)sender).left!=null&&((puzzle)sender).left.Text=="")
            {
                swap(((puzzle)sender).left, (puzzle)sender);
            }
           else if (((puzzle)sender).right!=null&&((puzzle)sender).right.Text == "")
            {
                swap(((puzzle)sender).right, (puzzle)sender);
            }
            else if (((puzzle)sender).up!=null&&((puzzle)sender).up.Text == "")
            {
                swap(((puzzle)sender).up, (puzzle)sender);
            }
            else if (((puzzle)sender).down!=null&&((puzzle)sender).down.Text == "")
            {
                swap(((puzzle)sender).down, (puzzle)sender);
            }
            if (goal())
            {
                MessageBox.Show("you win");
            }
        }
        void swap(puzzle a,puzzle b)
        {
            string temp = a.Text;
            a.Text = b.Text;
            b.Text = temp;
        }
        bool goal()
        {
            for (int i = 0; i < puzzls.Count; i++)
            {
                if (!(i < 8 && puzzls[i].Text==(i+1).ToString()||i==8&&puzzls[i].Text==""))
                {
                    return false;

                }
            }
            return true;
        }  
      
    }
}