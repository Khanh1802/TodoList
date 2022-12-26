using AutoMapper;
using ToDoList.Data.Models;
using ToDoList.Dtos.CategoryDto;
using ToDoList.Services;

namespace WinFormsToDoList
{
    public partial class FormCategory : Form
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private bool _loadingDone = false;
        private CategoryDto _categoryDto;

        public FormCategory(ICategoryService categoryService, IMapper mapper)
        {
            InitializeComponent();
            _categoryService = categoryService;
            _mapper = mapper;
        }

        private async void BtAdd_Click(object sender, EventArgs e)
        {
            if (_loadingDone)
            {
                if (!string.IsNullOrEmpty(TbName.Text))
                {
                    var item = new CreateCategoryDto();
                    item.Name = TbName.Text;
                    //var entity = _mapper.Map<CategoryDto, CreateCategoryDto>(_categoryDto);
                    await _categoryService.AddAsync(item);
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
                _categoryDto = null;
                return;
            }
            else
            {
                // Dtg.Rows[e.RowIndex] lấy hàng đang CellClick hiện tại
                var row = Dtg.Rows[e.RowIndex];
                // row.Cells[0].Value.ToString() lấy id rồi convert
                int id = Convert.ToInt32(row.Cells[0].Value.ToString());
                _categoryDto = await _categoryService.GetByIdAsync(id);
                TbName.Text = _categoryDto.Name;
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
            //var listCategory = await _categoryService.GetAllAsync();
            //var result = listCategory.Where(x => x.IsDeleted != true).ToList();
            Dtg.DataSource = await _categoryService.GetAllAsync();
            // Ẩn colums
            Dtg.Columns["IsDeleted"].Visible = false;
            //Dtg.Columns["Jobs"].Visible = false;
            TbName.Text = string.Empty;
            BtRemove.Enabled = false;
            BtUpdate.Enabled = false;
            BtAdd.Enabled = true;
            _categoryDto = null;
            _loadingDone = true;
        }

        private async void BtUpdate_Click(object sender, EventArgs e)
        {
            if (_loadingDone)
            {
                if (_categoryDto is not null)
                {
                    if (!string.IsNullOrEmpty(TbName.Text))
                    {
                        _categoryDto.Name = TbName.Text;
                        //var item = _mapper.Map<CategoryDto, UpdateCategoryDto>(_categoryDto);
                        var updateItem = new UpdateCategoryDto()
                        {
                            Id = _categoryDto.Id,
                            Name = _categoryDto.Name
                        };
                        await _categoryService.UpdateAsync(updateItem);
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
                if (_categoryDto is not null)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure want to delete this category", "Delete record", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        TbName.Text = string.Empty;
                        await _categoryService.DeleteAsync(_categoryDto.Id);
                        await RefreshDataGridView();
                        MessageBox.Show("Record has been successfully deleted", "Done", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private async void BtFind_Click(object sender, EventArgs e)
        {
            if (_loadingDone)
            {
                if (!string.IsNullOrEmpty(TbFind.Text))
                {
                    var filter = new FilterCategoryDto()
                    {
                        Name = TbFind.Text,
                    };
                    Dtg.DataSource = await _categoryService.FilterAsync(filter);
                }
                else
                {
                    await RefreshDataGridView();
                }
            }
        }
    }
}
