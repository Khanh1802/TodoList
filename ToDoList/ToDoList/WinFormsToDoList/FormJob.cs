using ToDoList.Data.Models;
using ToDoList.Dtos.Jobs;
using ToDoList.Services;

namespace WinFormsToDoList
{
    public partial class FormJob : Form
    {
        private readonly IJobService _jobService;
        private bool _loadingDone = false;
        private int? selectJobId = null;

        public FormJob(IJobService jobService)
        {
            InitializeComponent();
            _jobService = jobService;
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
                if (selectJobId is not null)
                {
                    if (!string.IsNullOrEmpty(TbName.Text))
                    {
                        try
                        {
                            //await _stateService.UpdateAsync(_state);
                            await _jobService.UpdateAsync(new UpdateJobDto()
                            {
                                CategoryId = ((Category)CbbCategory.SelectedItem).Id,
                                //StateId = 111,
                                StateId = ((ToDoList.Data.Models.State)CbbState.SelectedItem).Id,
                                FromDate = DTPFrom.Value,
                                ToDate = DTPTo.Value,
                                Name = TbName.Text,
                                Id = selectJobId!.Value
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
                if (selectJobId is not null)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure want to delete this job", "Delete record", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        TbName.Text = string.Empty;
                        await _jobService.DeleteAsync(selectJobId);
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
            selectJobId = null;
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
                selectJobId = null;
            }
            else
            {
                // Dtg.Rows[e.RowIndex] lấy hàng đang CellClick hiện tại
                var row = Dtg.Rows[e.RowIndex];
                if (Dtg.Rows[e.RowIndex].DataBoundItem is JobDto jobDto)
                {
                    selectJobId = jobDto.Id;
                    TbName.Text = jobDto.NameJob;
                    BtAdd.Enabled = false;
                    BtRemove.Enabled = true;
                    BtUpdate.Enabled = true;
                }
            }
        }
    }
}
