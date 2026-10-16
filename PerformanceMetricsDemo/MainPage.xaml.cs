using Syncfusion.Maui.ListView;
using Syncfusion.Maui.ListView.Helpers;
using Syncfusion.Maui.Toolkit.Popup;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Sample
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
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
            _watcher.Reset();
            
            var lastDisplayIndex = listView.DataSource.DisplayItems.Count - 1;
            _watcher.Start();
            listView.ItemsLayout.ScrollToRowIndex(lastDisplayIndex, ScrollToPosition.End, true); // disable animation => true

        }

        private void listView_ScrollStateChanged(object sender, ScrollStateChangedEventArgs e)
        {

           

            if (e.ScrollState == ListViewScrollState.Idle)
            {
                var lastDisplayIndex = listView.DataSource.DisplayItems.Count - 1;
                var lastVisible = listView.GetVisualContainer().ScrollRows.LastBodyVisibleLineIndex;
               // if (lastVisible >= lastDisplayIndex)
                {
                    var _sec = _watcher.Elapsed.TotalSeconds;
                    System.Diagnostics.Debug.WriteLine("SfListview scrolled" + _sec);
                }
            }
        }
    }
}
