using Syncfusion.Maui.Toolkit.Popup;

namespace Sample;

public partial class ListViewSorting : ContentPage
{
	public ListViewSorting()
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
}