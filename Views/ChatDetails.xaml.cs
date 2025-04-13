using System.Diagnostics;
using TutorLinkClient.ViewModels;

namespace TutorLinkClient.Views;

public partial class ChatDetails : ContentPage
{
    public ChatDetails(ChatDetailsViewModel vm)
    {
        this.BindingContext = vm;
        InitializeComponent();

        // Subscribe to scroll to bottom message
        MessagingCenter.Subscribe<ChatDetailsViewModel>(this, "ScrollToBottom", _ =>
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    // Wait for UI to update
                    await Task.Delay(100);
                    await messagesScrollView.ScrollToAsync(0, double.MaxValue, true);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error scrolling: {ex.Message}");
                }
            });
        });
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        MessagingCenter.Unsubscribe<ChatDetailsViewModel>(this, "ScrollToBottom");
    }
}
