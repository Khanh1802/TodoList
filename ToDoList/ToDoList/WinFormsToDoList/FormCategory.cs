using ToDoList.Data.Models;
using ToDoList.Services;

namespace WinFormsToDoList
{
    public partial class FormCategory : Form
    {
        private readonly ICategoryService _categoryService;
        private bool _loadingDone = false;
        private Category _category;

        public FormCategory(ICategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;
        }

        private async void BtAdd_Click(object sender, EventArgs e)
        {
            if (_loadingDone)
            {
                if (!string.IsNullOrEmpty(TbName.Text))
                {
                    _category = new Category();
                    _category.Name = TbName.Text;
                    _category.CreationTime = DateTime.Now;
                    await _categoryService.AddAsync(_category);
                    MessageBox.Show("Create new category completed", "Done", MessageBoxButtons.OK);
                    await RefreshDataGridView();
                }
                else
                {
                    MessageBox.Show("Name is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void Dtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                TbName.Text = string.Empty;
                BtRemove.Enabled = false;
                BtUpdate.Enabled = false;
                BtAdd.Enabled = true;
                _category = null;
                return;
            }
            else
            {
                // Dtg.Rows[e.RowIndex] lấy hàng đang CellClick hiện tại
                var row = Dtg.Rows[e.RowIndex];
                // row.Cells[0].Value.ToString() lấy id rồi convert
                int id = Convert.ToInt32(row.Cells[0].Value.ToString());
                _category = await _categoryService.GetByIdAsync(id);
                TbName.Text = _category.Name;
                BtAdd.Enabled = false;
                BtRemove.Enabled = true;
                BtUpdate.Enabled = true;
            }
        }

        private async void FormCategory_Load(object sender, EventArgs e)
        {
            await RefreshDataGridView();
        }

        private async Task RefreshDataGridView()
        {
            _loadingDone = false;
            var listCategory = await _categoryService.GetAllAsync();
            var result = listCategory.Where(x => x.IsDeleted != true).ToList();
            Dtg.DataSource = result;
            // Ẩn colums
            Dtg.Columns["IsDeleted"].Visible = false;
            Dtg.Columns["Jobs"].Visible = false;
            TbName.Text = string.Empty;
            BtRemove.Enabled = false;
            BtUpdate.Enabled = false;
            BtAdd.Enabled = true;
            _category = null;
            _loadingDone = true;
        }

        private async void BtUpdate_Click(object sender, EventArgs e)
        {
            if (_loadingDone)
            {
                if (_category is not null)
                {
                    if (!string.IsNullOrEmpty(TbName.Text))
                    {
                        _category.Name = TbName.Text;
                        _category.LastModificationTime = DateTime.Now;
                        await _categoryService.UpdateAsync(_category);
                        await RefreshDataGridView();
                        MessageBox.Show("Change category completed", "Done", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Name is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void BtRemove_Click(object sender, EventArgs e)
        {
            if (_loadingDone)
            {
                if (_category is not null)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure want to delete this category", "Delete record", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        TbName.Text = string.Empty;
                        _category.DeletetionTime = DateTime.Now;
                        await _categoryService.RemoveAsync(_category);
                        await RefreshDataGridView();
                        MessageBox.Show("Record has been successfully deleted", "Done", MessageBoxButtons.OK);
                    }
                }
            }
        }
    }
}
