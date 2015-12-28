using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Abp.Dependency;
using AbpWpfDemo.People;
using AbpWpfDemo.People.Dto;

namespace AbpWpfDemo.UI_WinForms
{
    public partial class MainForm : Form, ITransientDependency
    {
        private readonly IPersonAppService _personAppService;

        public MainForm(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
            InitializeComponent();
        }

        private async void btnLoadAllPeople_Click(object sender, System.EventArgs e)
        {
            await LoadAllPeopleAsync();
        }

        private async Task LoadAllPeopleAsync()
        {
            lstPeople.Items.Clear();

            var result = await _personAppService.GetAllPeopleAsync();
            foreach (var person in result.People)
            {
                lstPeople.Items.Add(person.Name);
            }
        }

        private async void btnAddPerson_Click(object sender, System.EventArgs e)
        {
            try
            {
                await _personAppService.AddNewPerson(new AddNewPersonInput
                {
                    Name = txtPersonName.Text
                });

                await LoadAllPeopleAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
