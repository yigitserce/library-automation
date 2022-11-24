namespace library_automation
{
    public partial class Form1 : Form
    {
        Repository repository = new Repository();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Kitap Ýsmi", 170);
            listView1.Columns.Add("Yazar Ýsmi", 170);
            listView1.Columns.Add("Durumu", 170);
            listView1.Columns.Add("Sayfa Sayýsý", 170);
            listView1.Columns.Add("Toplam Ödünç Alýnma", 170);

            List<BookDto> books = repository.GetAll();

            books.ForEach(book => {
                ListViewItem item = new ListViewItem(book.Name, 0);
                item.Checked = true;
                item.SubItems.Add(book.Author);
                item.SubItems.Add(book.Status);
                item.SubItems.Add(book.PageCount.ToString());
                item.SubItems.Add(book.BarrowCount.ToString());
                listView1.Items.Add(item);
            });

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string author = textBox2.Text;
            int pageCount = Convert.ToInt32(textBox7.Text);
            BookEntitiy book = new BookEntitiy(name, author, pageCount);
            bool result = repository.AddBook(book);
            if (result)
            {
                MessageBox.Show("Kitabiniz Eklendi");
            }
            else {
                MessageBox.Show("Kitap Mevcut");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
    }
}