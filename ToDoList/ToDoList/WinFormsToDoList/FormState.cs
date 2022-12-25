﻿using ToDoList.Data.Models;
using ToDoList.Services;

namespace WinFormsToDoList
{
    public partial class FormState : Form
    {
        private readonly IStateService _stateService;
        private bool _loadingDone = false;
        private State _state;
        public FormState(IStateService stateService)
        {
            InitializeComponent();
            _stateService = stateService;
        }

        private async void BtAdd_Click(object sender, EventArgs e)
        {
            if (_loadingDone)
            {
                if (!string.IsNullOrEmpty(TbName.Text))
                {
                    _state = new State();
                    _state.Name = TbName.Text;
                    await _stateService.AddAsync(_state);
                    MessageBox.Show("Create new state completed", "Done", MessageBoxButtons.OK);
                    await RefreshDataGridView();
                }
                else
                {
                    MessageBox.Show("Name is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void BtUpdate_Click(object sender, EventArgs e)
        {
            if (_loadingDone)
            {
                if (_state is not null)
                {
                    if (!string.IsNullOrEmpty(TbName.Text))
                    {
                        _state.Name = TbName.Text;
                        _state.LastModificationTime = DateTime.Now;
                        await _stateService.UpdateAsync(_state);
                        await RefreshDataGridView();
                        MessageBox.Show("Change state completed", "Done", MessageBoxButtons.OK);
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
                if (_state is not null)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure want to delete this state", "Delete record", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        TbName.Text = string.Empty;
                        await _stateService.RemoveAsync(_state);
                        await RefreshDataGridView();
                        MessageBox.Show("Record has been successfully deleted", "Done", MessageBoxButtons.OK);
                    }

                }
            }
        }

        private async void FormState_Load(object sender, EventArgs e)
        {
            await RefreshDataGridView();
        }

        private async Task RefreshDataGridView()
        {
            _loadingDone = false;
            var listState = await _stateService.GetAllAsync();
            var result = listState.Where(x => x.IsDeleted != true).ToList();
            Dtg.DataSource = result;
            // Ẩn colums
            Dtg.Columns["IsDeleted"].Visible = false;
            Dtg.Columns["Jobs"].Visible = false;
            TbName.Text = string.Empty;
            BtRemove.Enabled = false;
            BtUpdate.Enabled = false;
            BtAdd.Enabled = true;
            _state = null;
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
                _state = null;
                return;
            }
            else
            {
                // Dtg.Rows[e.RowIndex] lấy hàng đang CellClick hiện tại
                var row = Dtg.Rows[e.RowIndex];
                // row.Cells[0].Value.ToString() lấy id rồi convert
                int id = Convert.ToInt32(row.Cells[0].Value.ToString());
                _state = await _stateService.GetByIdAsync(id);
                TbName.Text = _state.Name;
                BtAdd.Enabled = false;
                BtRemove.Enabled = true;
                BtUpdate.Enabled = true;
            }
        }
    }
}
