namespace Kiosco.App.Services
{
    public class ViewOptionService
    {
        private bool _navBarVisible;

        public Action OnChanged { get; set; }

        //Change state by click on the button
        public void Toggle(bool navBarVisible)
        {
            _navBarVisible = navBarVisible;
            //_navBarVisible = !_navBarVisible;//Change
            if (OnChanged != null) OnChanged();//Callback for reload
        }

        //get additional css class for nav bar div
        //No additional css class for show nav bar : d-none class will hide the div
        public string NavBarClass => !_navBarVisible? String.Empty : "d-none";
    }
}
