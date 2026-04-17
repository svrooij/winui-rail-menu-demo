using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace RailMenuDemo
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetTitleBar();
            NavView.Loaded += (s, e) => NavFrame.Navigate(typeof(Pages.AboutPage));
        }

        // Handle navigation when a menu item is clicked
        // Navigation is based on the Tag property of the NavigationViewItem, which is set in the xaml
        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var tag = args.InvokedItemContainer?.Tag?.ToString();
            switch (tag)
            {
                case "Home": NavFrame.Navigate(typeof(Pages.AboutPage)); break;
                case "Browse": NavFrame.Navigate(typeof(Pages.EmptyPage)); break;
                case "Models": NavFrame.Navigate(typeof(Pages.EmptyPage)); break;
                case "Settings": NavFrame.Navigate(typeof(Pages.EmptyPage)); break;
            }
        }

        // This is not strictly needed for the menu, but the AI Dev Gallery has child pages that you can navigate to, and without this code the correct menu item would not be highlighted when you navigate back to the main pages, so I added this to keep the correct item highlighted after back-navigation.
        private void NavFrame_Navigated(object sender, Microsoft.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            // Keep the correct item highlighted after back-navigation
            foreach (var item in NavView.MenuItems.OfType<NavigationViewItem>())
            {
                if (item.Tag?.ToString() == GetTagForPage(e.SourcePageType))
                {
                    NavView.SelectedItem = item;
                    break;
                }
            }
        }

        // This method is used to get the tag for a given page type, this is used in the NavFrame_Navigated method to keep the correct item highlighted after back-navigation, you can adjust this method to match your own page types and tags
        private static string? GetTagForPage(Type page) => page.Name switch
        {
            nameof(Pages.AboutPage) => "Home",
            //nameof(Pages.EmptyPage) => "Browse",
            //nameof(Pages.ModelsPage) => "Models",
            //nameof(Pages.SettingsPage) => "Settings",
            _ => null
        };

        // Not strictly needed for the menu, but this sets up the title bar with an icon and a title, you can customize this to your liking, or remove it if you don't want a custom title bar
        private void SetTitleBar()
        {
            this.ExtendsContentIntoTitleBar = true;
            this.SetTitleBar(titleBar);
            this.AppWindow.TitleBar.PreferredHeightOption = TitleBarHeightOption.Tall;
            this.AppWindow.SetIcon("Assets/AppIcon/Icon.ico");

            this.Title = Windows.ApplicationModel.Package.Current.DisplayName;
        }
    }
}
