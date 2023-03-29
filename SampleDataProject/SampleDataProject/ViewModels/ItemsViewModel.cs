using SampleDataProject.Models;
using SampleDataProject.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleDataProject.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        #region Fields

        private Datum _selectedItem;
        private string note;
        private int customersCount;
        #endregion

        public ItemsViewModel()
        {
            Title = "Customer Details";
            Items = new ObservableCollection<Datum>();
            ExecuteLoadItemsCommand();
            ItemTapped = new Command<Datum>(OnItemSelected);
        }

        #region Prop
        public Datum SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }
        public string Note
        {
            get => note;
            set => SetProperty(ref note, value);
        }
        public int CustomersCount
        {
            get => customersCount;
            set => SetProperty(ref customersCount, value);
        }
        public ObservableCollection<Datum> Items { get; set; }
        public Command LoadItemsCommand { get; }
       
        public Command<Datum> ItemTapped { get; }

        #endregion

        #region Methods
        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items.Data)
                {
                    Items.Add(item);
                }
                Note = items.Support.Text;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
            IsBusy = false;
        }
    
       public async void OnItemSelected(Datum item)
        {
            if (item == null)
                return;


            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }

        #endregion
    }
}