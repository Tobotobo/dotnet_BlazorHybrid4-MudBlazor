using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorHybrid.Forms;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        var blazorWebView1 = new BlazorWebView();
        blazorWebView1.Dock = DockStyle.Fill;
        this.Controls.Add(blazorWebView1);

        var services = new ServiceCollection();
        services.AddWindowsFormsBlazorWebView();
        BlazorHybrid.View.Initializer.Initialize(services);
        blazorWebView1.HostPage = "wwwroot\\index.html";
        blazorWebView1.Services = services.BuildServiceProvider();
        blazorWebView1.RootComponents.Add<BlazorHybrid.View.Components.Routes>("#app");
    }
}
