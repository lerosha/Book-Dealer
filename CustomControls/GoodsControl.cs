using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookDealer.CustomControls
{
    public partial class GoodsControl : UserControl
    {
        public GoodsControl()
        {
            InitializeComponent();
        }

        private void genresBtn_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            this.Visible = false;
            Genres genres = parentForm.Controls.Find("genres1", true).FirstOrDefault() as Genres;
            genres.Visible = true;
        }

        private void BooksBtn_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            this.Visible = false;
            Books books = parentForm.Controls.Find("books1", true).FirstOrDefault() as Books;
            books.Visible = true;
        }

        private void StorageBtn_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            this.Visible = false;
            Storage storage = parentForm.Controls.Find("storage1", true).FirstOrDefault() as Storage;
            storage.Visible = true;
        }

        private void ListOfBooksBtn_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            this.Visible = false;
            ListOfBooks listOfBooks = parentForm.Controls.Find("listOfBooks1", true).FirstOrDefault() as ListOfBooks;
            listOfBooks.Visible = true;
        }

        private void SetsOfBooksBtn_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            this.Visible = false;
            SetsOfBooks setsOfBooks = parentForm.Controls.Find("setsOfBooks1", true).FirstOrDefault() as SetsOfBooks;
            setsOfBooks.Visible = true;
        }

        private void OrdersBtn_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            this.Visible = false;
            Orders orders = parentForm.Controls.Find("orders1", true).FirstOrDefault() as Orders;
            orders.Visible = true;
        }
    }
}
