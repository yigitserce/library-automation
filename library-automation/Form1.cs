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
            listView1.Columns.Add("Kitap Ýsmi", 135);
            listView1.Columns.Add("Yazar Ýsmi", 135);
            listView1.Columns.Add("Durumu", 135);
            listView1.Columns.Add("Sayfa Sayýsý", 135);
            listView1.Columns.Add("Ödünç Alan", 135);
            listView1.Columns.Add("Toplam Ödünç Alýnma", 135);
            comboBox1.SelectedIndex = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            updateListView();
        }

        private void updateListView() 
        {
            listView1.Items.Clear();
            List<BookDto> books = repository.GetAll();
            books.ForEach(book => {
                ListViewItem item = new ListViewItem(book.getName(), 0);
                item.Checked = true;
                item.SubItems.Add(book.getAuthor());
                item.SubItems.Add(book.getStatus());
                item.SubItems.Add(book.getPageCount().ToString());
                item.SubItems.Add(book.getBarrowCount().ToString());
                listView1.Items.Add(item);
            });
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            try
            {
                string name = textBox1.Text;
                string author = textBox2.Text;
                int pageCount = Convert.ToInt32(textBox7.Text);
                BookEntitiy book = new BookEntitiy(name, author, pageCount);
                bool result = repository.AddBook(book);
                if (result)
                {
                    MessageBox.Show("Kitabiniz Eklendi");
                    updateListView();
                }
                else
                {
                    MessageBox.Show("Kitap Mevcut");
                }
            }

            catch {
                MessageBox.Show("Lütfen Alanlarý Ýlgili Verileri Ýle Doldurunuz");
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox3.Text;
                bool result = repository.DeleteBook(name);
                if (result)
                {
                    updateListView();
                    MessageBox.Show("Kitap Silindi");
                }

                else
                {
                    MessageBox.Show("Kitap Bulunamadi");
                }
            }

            catch
            {
                MessageBox.Show("Lütfen Alanlarý Ýlgili Verileri Ýle Doldurunuz");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}