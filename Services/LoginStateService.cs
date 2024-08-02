
namespace VillageRMS.Services
{
    public class LoginStateService
    {
        public event Action OnChange;

        private bool isLoggedIn;

        public bool IsLoggedIn
        {
            get => isLoggedIn;
            set
            {
                if (isLoggedIn != value)
                {
                    isLoggedIn = value;
                    NotifyStateChanged();
                }
            }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
