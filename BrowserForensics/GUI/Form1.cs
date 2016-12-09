using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;


namespace GUI {
    public partial class Form1 : Form {
        private Controller.Controller first;
        private Controller.Controller c;
        public Form1() {
            InitializeComponent();
            first = new Controller.Controller();
            c = first;

            locationLabel.Text = "";
            labelFound.Text = "";
        }

        private void helpfulMethodDataGrid()
        {

            foreach (DataGridViewColumn column in dataGridView1.Columns) column.SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.AutoResizeColumns();

            // Configure the details DataGridView so that its columns automatically
            // adjust their widths when the data changes.
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            //for (int i = 0; i < dataGridView1.Columns.Count; i++)
            //{
            //    var column = dataGridView1.Columns[i];
            //    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //    column.Width = 10;
            //}

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Width > 540)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 540;
                }
                //Console.WriteLine(column.Width);
                //column.FillWeight = 100;
            }
            dataGridView1.AllowUserToResizeColumns = true;
        }

        private void button1_Click(object sender, EventArgs e) {
            Output.Text = c.getDownloads();
            var Lstemp = c.getDownloadsDTOList();

            //DataTable table = new DataTable();
            //table.Columns.Add("ID", typeof(string));
            //table.Columns.Add("NAME", typeof(string));
            //table.Columns.Add("CITY", typeof(string));

            ////table.Rows.Add(111, "Devesh", "Ghaziabad");
            ////table.Rows.Add(222, "ROLI", "KANPUR");
            ////table.Rows.Add(102, "ROLI", "MAINPURI");
            ////table.Rows.Add(212, "DEVESH", "KANPUR");

            //var columns = from t in Lstemp
            //              //orderby t.Name
            //              select new
            //              {
            //                  Date = t.getTime(),
            //                  Path = t.getInfo(),
            //                  Type = t.getType()
            //              };


            //dataGridView1.DataSource = columns.ToList();

            SortableBindingList<DownloadsDTO> downloads = new SortableBindingList<DownloadsDTO>(Lstemp);
            labelFound.Text = "Found " + Lstemp.Count + " entries";

            var bindingList = new BindingList<DownloadsDTO>(Lstemp);
            var source = new BindingSource(downloads, null);

           
            dataGridView1.DataSource = source;
            helpfulMethodDataGrid();


        }

        private void passwords_Button_Click(object sender, EventArgs e) {
            Output.Text = c.getPasswords();

            var Lstemp = c.getPasswordsDTOList();
            SortableBindingList<PasswordDTO> downloads = new SortableBindingList<PasswordDTO>(Lstemp);
            labelFound.Text = "Found " + Lstemp.Count + " entries";

            var bindingList = new BindingList<PasswordDTO>(Lstemp);
            var source = new BindingSource(downloads, null);


            dataGridView1.DataSource = source;
            helpfulMethodDataGrid();
        }

        private void cookies_Button_Click(object sender, EventArgs e) {
            Output.Text = c.getCookies();

            var Lstemp = c.getCookiesDTOList();
            SortableBindingList<CookiesDTO> downloads = new SortableBindingList<CookiesDTO>(Lstemp);
            labelFound.Text = "Found " + Lstemp.Count + " entries";

            var bindingList = new BindingList<CookiesDTO>(Lstemp);
            var source = new BindingSource(downloads, null);

            dataGridView1.DataSource = source;
            helpfulMethodDataGrid();

        }

        private void searches_Button_Click(object sender, EventArgs e) {
            Output.Text = c.getSearches();

            var Lstemp = c.getSearchesDTOList();
            SortableBindingList<SearchDTO> downloads = new SortableBindingList<SearchDTO>(Lstemp);
            labelFound.Text = "Found " + Lstemp.Count + " entries";

            var bindingList = new BindingList<SearchDTO>(Lstemp);
            var source = new BindingSource(downloads, null);

            dataGridView1.DataSource = source;
            helpfulMethodDataGrid();
        }

        private void browsing_Button_Click(object sender, EventArgs e) {
            Output.Text = c.getHistory();

            var Lstemp = c.getHistoryDTOList();
            SortableBindingList<HistoryDTO> downloads = new SortableBindingList<HistoryDTO>(Lstemp);
            labelFound.Text = "Found " + Lstemp.Count + " entries";

            var bindingList = new BindingList<HistoryDTO>(Lstemp);
            var source = new BindingSource(downloads, null);

            dataGridView1.DataSource = source;
            helpfulMethodDataGrid();
        }

        private void autofills_Button_Click(object sender, EventArgs e) {
            Output.Text = c.getAutofills();

            var Lstemp = c.getAutofillsDTOList();
            SortableBindingList<AutofillDTO> downloads = new SortableBindingList<AutofillDTO>(Lstemp);
            labelFound.Text = "Found " + Lstemp.Count + " entries";

            var bindingList = new BindingList<AutofillDTO>(Lstemp);
            var source = new BindingSource(downloads, null);

            dataGridView1.DataSource = source;
            helpfulMethodDataGrid();
        }

        private void all_Button_Click(object sender, EventArgs e) {
            Output.Text = c.getAllInfo();
            dataGridView1.DataSource = null;
        }

        private void timelineButton_Click(object sender, EventArgs e) {
            Output.Text = c.getTimeline();
            dataGridView1.DataSource = null;
        }

        private void incoherenciesButton_Click(object sender, EventArgs e) {
            Output.Text = c.detectIncoherencies();
            dataGridView1.DataSource = null;
        }
        private void domainButton_Click(object sender, EventArgs e) {
            Output.Text = c.getAllDomains();
            dataGridView1.DataSource = null;
        }

        private void chooseLocationButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                locationLabel.Text = "Custom Location: " + folderBrowserDialog1.SelectedPath;
                c = new Controller.Controller(folderBrowserDialog1.SelectedPath);
                if (locationLabel.Right > this.Width)
                    locationLabel.Left = this.Width - locationLabel.Width - 20;
            }
             

        }

        private void resetLocationButton_Click(object sender, EventArgs e)
        {
            locationLabel.Text = "";
            c = first;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            //if (dataGridView1.SortOrder.ToString() == "Ascending") // Check if sorting is Ascending
            //{
            //    dataGridView1.Sort(dataGridView1.Columns[dataGridView1.SortedColumn.Name], ListSortDirection.Descending);
            //}
            //else
            //{
            //    dataGridView1.Sort(dataGridView1.Columns[dataGridView1.SortedColumn.Name], ListSortDirection.Ascending);
            //}

        }
    }

    public class SortableBindingList<T> : BindingList<T>
    {
        private bool isSortedValue;
        ListSortDirection sortDirectionValue;
        PropertyDescriptor sortPropertyValue;

        public SortableBindingList()
        {
        }

        public SortableBindingList(IList<T> list)
        {
            foreach (object o in list)
            {
                this.Add((T)o);
            }
        }

        protected override void ApplySortCore(PropertyDescriptor prop,
            ListSortDirection direction)
        {
            Type interfaceType = prop.PropertyType.GetInterface("IComparable");

            if (interfaceType == null && prop.PropertyType.IsValueType)
            {
                Type underlyingType = Nullable.GetUnderlyingType(prop.PropertyType);

                if (underlyingType != null)
                {
                    interfaceType = underlyingType.GetInterface("IComparable");
                }
            }

            if (interfaceType != null)
            {
                sortPropertyValue = prop;
                sortDirectionValue = direction;

                IEnumerable<T> query = base.Items;

                if (direction == ListSortDirection.Ascending)
                {
                    query = query.OrderBy(i => prop.GetValue(i));
                }
                else
                {
                    query = query.OrderByDescending(i => prop.GetValue(i));
                }

                int newIndex = 0;
                foreach (object item in query)
                {
                    this.Items[newIndex] = (T)item;
                    newIndex++;
                }

                isSortedValue = true;
                this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
            else
            {
                throw new NotSupportedException("Cannot sort by " + prop.Name +
                    ". This" + prop.PropertyType.ToString() +
                    " does not implement IComparable");
            }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get { return sortPropertyValue; }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get { return sortDirectionValue; }
        }

        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        protected override bool IsSortedCore
        {
            get { return isSortedValue; }
        }
    }
}
