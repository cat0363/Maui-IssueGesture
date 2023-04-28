using Microsoft.Maui.ApplicationModel;

namespace Maui_IssueGesture;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private void btnShowGrid_Clicked(object sender, EventArgs e)
    {
        frm1.IsVisible = true;
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        ShowMessage("Tap Gesture");
    }

    private void PinchGestureRecognizer_PinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
    {
        ShowMessage("Pinch Gesture");
    }

    private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
    {
        ShowMessage("Pan Gesture");
    }

    private void ShowMessage(string message)
    {
        if (string.IsNullOrEmpty(lblMessage.Text))
        {
            lblMessage.Text = message;

            IDispatcherTimer timer;
            timer = Dispatcher.CreateTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            timer.Tick += (s, e) =>
            {
                timer.Stop();

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    lblMessage.Text = string.Empty;
                });
            };
            timer.Start();
        }
    }
}

