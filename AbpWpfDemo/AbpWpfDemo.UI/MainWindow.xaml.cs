using System;
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

        private void LoadAllPeopleButton_Click(object sender, RoutedEventArgs e)
        {
            LoadAllPeople();
        }

        private void LoadAllPeople()
        {
            PeopleList.Items.Clear();
            var result = _personAppService.GetAllPeople();
            foreach (var person in result.People)
            {
                PeopleList.Items.Add(person.Name);
            }
        }

        private void AddNewPersonButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _personAppService.AddNewPerson(new AddNewPersonInput
                {
                    Name = NameTextBox.Text
                });

                LoadAllPeople();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
