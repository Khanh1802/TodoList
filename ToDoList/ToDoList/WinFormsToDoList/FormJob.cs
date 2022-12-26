using System.Xml.Linq;
using ToDoList.Data.Models;
using static System.Windows.Forms.AxHost;
using ToDoList.Services;
using ToDoList.Dtos.Jobs;

namespace WinFormsToDoList
{
    public partial class FormJob : Form
    {
        private readonly IJobService _jobService;
        private readonly ICategoryService _categoryService;
        private readonly IStateService _stateService;
        private Job _job;
        private JobDto _jobDto;
        private bool _loadingDone = false;
        public FormJob(IJobService jobService, ICategoryService categoryService, IStateService stateService)
        {
            InitializeComponent();
            _jobService = jobService;
            _categoryService = categoryService;
            _stateService = stateService;
        }

        private async void BtAdd_Click(object sender, EventArgs e)
        {
            if (_loadingDone)
            {
                if (!string.IsNullOrEmpty(TbName.Text)
                    && CbbState.SelectedItem != null
                    && CbbCategory.SelectedItem != null)
                {
                    //_job = new Job();
                    //_job.Name = TbName.Text;
                    //_job.CategoryId = CbbCategory.SelectedIndex;
                    //_job.StateId = CbbState.SelectedIndex;
                    //_job.FromDate = DTPFrom.Value;
                    //_job.ToDate = DTPTo.Value;
                    //await _jobService.AddAsync(_job);
                    try
                    {
                        var jobDto = await _jobService.AddAsync(new ToDoList.Dtos.Jobs.CreateJobDto
                        {
                            //CategoryId = 190,
                            CategoryId = ((Category)CbbCategory.SelectedItem).Id,
                            //StateId = 111,
                            StateId = ((ToDoList.Data.Models.State)CbbState.SelectedItem).Id,
                            FromDate = DTPFrom.Value,
                            ToDate = DTPTo.Value,
                            Name = TbName.Text,
                        });
                        MessageBox.Show($"Create new job completed {jobDto.Id}", "Done", MessageBoxButtons.OK);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        await RefreshDataGridView();
                    }
                }
                else if (string.IsNullOrEmpty(TbName.Text))
                {
                    MessageBox.Show("Name is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (CbbState.SelectedItem == null)
                {
                    MessageBox.Show("State is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (CbbCategory.SelectedItem == null)
                {
                    MessageBox.Show("Category is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void BtUpdate_Click(object sender, EventArgs e)
        {
            if (_loadingDone)
            {
                if (_jobDto is not null)
                {
                    if (!string.IsNullOrEmpty(TbName.Text))
                    {
                        try
                        {
                            _jobDto.NameJob = TbName.Text;
                            _jobDto.LastModificationTime = DateTime.Now;
                            //await _stateService.UpdateAsync(_state);
                            await _jobService.UpdateAsync(new UpdateJobDto()
                            {
                                CategoryId = ((Category)CbbCategory.SelectedItem).Id,
                                //StateId = 111,
                                StateId = ((ToDoList.Data.Models.State)CbbState.SelectedItem).Id,
                                FromDate = DTPFrom.Value,
                                ToDate = DTPTo.Value,
                                Name = TbName.Text,
                                Id = _jobDto.Id,
                            });
                            MessageBox.Show("Change state completed", "Done", MessageBoxButtons.OK);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            await RefreshDataGridView();
                        }
                    }
                }
            }
        }

        private async void BtRemove_Click(object sender, EventArgs e)
        {
            if (_loadingDone)
            {
                if (_jobDto is not null)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure want to delete this job", "Delete record", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        TbName.Text = string.Empty;
                        await _jobService.DeleteAsync(_jobDto.Id);
                        await RefreshDataGridView();
                        MessageBox.Show("Record has been successfully deleted", "Done", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private async void FormJob_Load(object sender, EventArgs e)
        {
            await RefreshDataGridView();
        }

        private async Task RefreshDataGridView()
        {
            _loadingDone = false;
            var listJob = await _jobService.GetAllAsync();
            var a = listJob;
            Dtg.DataSource = listJob;
            // Ẩn colums
            Dtg.Columns["IsDeleted"].Visible = false;
            Dtg.Columns["StateId"].Visible = false;
            Dtg.Columns["CategoryId"].Visible = false;
            //Dtg.Columns["Category"].Visible = false;
            //Dtg.Columns["State"].Visible = false;

            BtRemove.Enabled = false;
            BtUpdate.Enabled = false;
            BtAdd.Enabled = true;
            _job = null;
            //var listCategory = await _categoryService.GetAllAsync();
            //var resultCategory = listCategory.Where(x => x.IsDeleted != true).ToList();
            //CbbCategory.DataSource = resultCategory;
            CbbCategory.DisplayMember = "Name";
            // var listState = await _stateService.GetAllAsync();
            //  var resultState = listState.Where(x => x.IsDeleted != true).ToList();
            //   CbbState.DataSource = resultState;
            CbbState.DisplayMember = "Name";
            _loadingDone = true;
        }

        private async void Dtg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                TbName.Text = string.Empty;
                BtRemove.Enabled = false;
                BtUpdate.Enabled = false;
                BtAdd.Enabled = true;
                _job = null;
                return;
            }
            else
            {
                // Dtg.Rows[e.RowIndex] lấy hàng đang CellClick hiện tại
                var row = Dtg.Rows[e.RowIndex];
                // row.Cells[0].Value.ToString() lấy id rồi convert
                int id = Convert.ToInt32(row.Cells[0].Value.ToString());
                _jobDto = await _jobService.GetByIdAsync(id);
                TbName.Text = _jobDto.NameJob;
                BtAdd.Enabled = false;
                BtRemove.Enabled = true;
                BtUpdate.Enabled = true;
            }
        }
    }
}
