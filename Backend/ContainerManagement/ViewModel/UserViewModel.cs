namespace ContainerManagement.ViewModel
{
    public class UserViewModel
    {
        public string username { get; set; }

        public string password { get; set; }

        public UserViewModel(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
