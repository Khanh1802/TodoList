using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Data.Data;

namespace WinFormsToDoList
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void BtCreateCategory_Click(object sender, EventArgs e)
        {
            //using var context = new ToDoListDbContext();
            //    var jobs = context.Jobs
            //    .Include(x=> x.Category)
            //    .Include(x=> x.State).ThenInclude(x => x.Jobs)
            //    .ToList(); 
            var categoryPage = Program.ServiceProvider.GetRequiredService<FormCategory>();
            categoryPage.ShowDialog();
        }

        private void BtCreateJob_Click(object sender, EventArgs e)
        {
            var jobPage = Program.ServiceProvider.GetRequiredService<FormJob>();
            jobPage.ShowDialog();
        }

        private void BtState_Click(object sender, EventArgs e)
        {
            var statePage = Program.ServiceProvider.GetRequiredService<FormState>();
            statePage.ShowDialog();
        }
    }
}