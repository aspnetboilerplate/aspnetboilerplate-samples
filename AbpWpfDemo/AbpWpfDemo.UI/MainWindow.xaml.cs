using System;
using System.Threading.Tasks;
using System.Windows;
using Abp.Dependency;
using AbpWpfDemo.People;
using AbpWpfDemo.People.Dto;

namespace AbpWpfDemo.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ISingletonDependency
    {
        private readonly IPersonAppService _personAppService;

        public MainWindow(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
            InitializeComponent();
        }

        private async void LoadAllPeopleButton_Click(object sender, RoutedEventArgs e)
        {
            await LoadAllPeopleAsync();
        }

        private async Task LoadAllPeopleAsync()
        {
            PeopleList.Items.Clear();
            var result = await _personAppService.GetAllPeopleAsync();
            foreach (var person in result.People)
            {
                PeopleList.Items.Add(person.Name);
            }
        }

        private async void AddNewPersonButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await _personAppService.AddNewPerson(new AddNewPersonInput
                {
                    Name = NameTextBox.Text
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
