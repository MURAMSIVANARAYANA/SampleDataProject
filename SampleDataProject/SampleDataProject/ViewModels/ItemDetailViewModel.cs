using System;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SampleDataProject.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        #region Fileds

        private string itemId;
        private string firstName;
        private string lastName;
        private string avatar;
        private string email;
        private string url;
        private string about;
        private int id;
        #endregion

        public ItemDetailViewModel()
        {
            CancelCommand = new Command(OnCancel);
            OpenUrlCommand = new Command(OpenUrl);

        }

        #region Prop
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }
        public string FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }
        public string About
        {
            get => about;
            set => SetProperty(ref about, value);
        }
        public string Url
        {
            get => url;
            set => SetProperty(ref url, value);
        }
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        public string Avatar
        {
            get => avatar;
            set => SetProperty(ref avatar, value);
        }

        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }       
        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }
        public Command CancelCommand { get; }
        public Command OpenUrlCommand { get; }

        #endregion

        #region Methods

        private async void OnCancel()
        {
            IsBusy = true;
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
            IsBusy = false;
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items.Data)
                {
                    if (item.Id.ToString() == itemId)
                    {
                        FirstName = item.FirstName;
                        Id = item.Id;
                        LastName = item.LastName;
                        Email = item.Email;
                        Avatar = item.Avatar;
                    }
                }
                Url = items.Support.Url;
                About = items.Support.Text;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        private async void OpenUrl()
        {
            await Browser.OpenAsync("https://reqres.in");
        }

        #endregion
    }
}
