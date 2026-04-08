using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace RailMenuDemo.Pages;
/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class AboutPage : Page
{
    private const string GithubUri = "https://github.com/svrooij";
    private const string LinkedinUri = "https://linkedin.com/in/stephanvanrooij";
    private const string BlogUri = "https://svrooij.io";
    public AboutPage()
    {
        InitializeComponent();
    }

    private async void BtnLinkedIn_Click(object sender, RoutedEventArgs e)
    {
        await Windows.System.Launcher.LaunchUriAsync(new Uri(LinkedinUri), new Windows.System.LauncherOptions { ContentType = "text/html" });

    }

    private async void BtnGithub_Click(object sender, RoutedEventArgs e)
    {
        await Windows.System.Launcher.LaunchUriAsync(new Uri(GithubUri), new Windows.System.LauncherOptions { ContentType = "text/html" });

    }

    private async void BtnBlog_Click(object sender, RoutedEventArgs e)
    {

        await Windows.System.Launcher.LaunchUriAsync(new Uri(BlogUri), new Windows.System.LauncherOptions { ContentType = "text/html" });
    }
}
