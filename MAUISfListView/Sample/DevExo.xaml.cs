using DevExpress.Maui.CollectionView;
using Syncfusion.Maui.Toolkit.Popup;
using System.Collections;
using System.Diagnostics;

namespace Sample;

public partial class DevExo : ContentPage
{
    public DevExo()
    {
        StaticClass.SetMyInt(0);
        StaticClass.Stop();
        StaticClass.Reset();
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        DataTemplate MyTemplate = new DataTemplate(() =>
        {
            var contentView = new ContentView();

            var verticalStackLayout = new VerticalStackLayout();

            var myIntLabel = new Label();
            var secLabel = new Label();
            var millsecLabel = new Label();
            var itemCountLabel = new Label();

            verticalStackLayout.Children.Add(myIntLabel);
            verticalStackLayout.Children.Add(secLabel);
            verticalStackLayout.Children.Add(millsecLabel);
            verticalStackLayout.Children.Add(itemCountLabel);

            contentView.Content = verticalStackLayout;

            //Seting default text info even before
            myIntLabel.Text = $"MyInt: {StaticClass.GetMyInt()}";
            secLabel.Text = $"Sec: {StaticClass.GetSec()}";
            millsecLabel.Text = $"Millsec: {StaticClass.GetMillSec()}";

            //ItemCount need to be updated
            itemCountLabel.Text = $"Item Count: {StaticClass.GetMyInt()}";// default is 0

            return contentView;
        });

        new SfPopup() { PopupStyle = new PopupStyle { OverlayColor = new SolidColorBrush(Colors.Red), CornerRadius = 0 }, ContentTemplate = MyTemplate, ShowFooter = false, ShowHeader = false }.Show(0, 0);
        StaticClass.Stop();
        StaticClass.Reset();
    }

    Stopwatch _watcher = new Stopwatch();
    private void Button_Clicked(object sender, EventArgs e)
    {
        var items = (IList)listView.ItemsSource;
        int lastIndex =(int) items.Count - 1;
        _watcher.Reset();
        _watcher.Start();
        listView.ScrollTo(lastIndex, DevExpress.Maui.Core.DXScrollToPosition.End);

    }

    private void listView_Scrolled(object sender, DXCollectionViewScrolledEventArgs e)
    {

        var items = (IList)listView.ItemsSource;
        if (items != null && items.Count > 0)
        {
            var lastIndex = items.Count - 1;
            //if (e.LastVisibleItemIndex >= lastIndex)
            {

                var _sec = _watcher.Elapsed.TotalSeconds;

                System.Diagnostics.Debug.WriteLine("DevExpress scrolled" + _sec);
            }
        }
    }
}