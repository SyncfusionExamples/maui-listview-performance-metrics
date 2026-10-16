using Syncfusion.Maui.ListView;
using System.Collections.ObjectModel;
using System.Diagnostics;


namespace Sample;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            switch (button.Text)
            {
                case "SfListView":
                    Navigation.PushAsync(new MainPage());
                    break;
                case "ListViewFiltering":
                    Navigation.PushAsync(new ListViewFiltering());
                    break;
                case "ListViewSorting":
                    Navigation.PushAsync(new ListViewSorting());
                    break;
                case "ListViewGrouping":
                    Navigation.PushAsync(new ListViewGrouping());
                    break;
               

            }
        }
    }

    private void Button_Clicked1(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            switch (button.Text)
            {
                case "100":
                    StaticClass.SetNumberOfRec(100);
                    break;
                case "1000":
                    StaticClass.SetNumberOfRec(1000);
                    break;
                case "10K":
                    StaticClass.SetNumberOfRec(10000);
                    break;
                case "1L":
                    StaticClass.SetNumberOfRec(100000);
                    break;
                case "10L":
                    StaticClass.SetNumberOfRec(1000000);
                    break;
            }
        }
    }
}

public class AGrid : Grid
{
    public AGrid()
    {
        StaticClass.SetMyInt(StaticClass.GetMyInt() + 1);
    }

    protected override Size ArrangeOverride(Rect bounds)
    {
        var a = base.ArrangeOverride(bounds);
        StaticClass.SetSec();
        StaticClass.SetMillSec();
        return a;
    }
}

public class List : SfListView
{
    public List()
    {
        StaticClass.Reset();
        StaticClass.Start();
    }
}


public class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
}

public class GroupingViewModel
{
    public ObservableCollection<Grouping<string, Product>> GroupedProducts { get; set; }
    public ObservableCollection<Product> Products { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public GroupingViewModel()
    {
        Products = GenerateProducts();
    }

    private ObservableCollection<Product> GenerateProducts()
    {
        // Generates fake data
        var categories = new[] { "Electronics", "Groceries", "Clothing", "Books" };
        var random = new Random();
        var products = new ObservableCollection<Product>();

        for (int i = 0; i < StaticClass.GetNumberOfRec() - 1; i++)
        {
            products.Add(new Product { Name = "iPhone" + i, Category = "Electronics", Price = 999.99m });
        }

        return products;
    }
}

public class Grouping<K, T> : ObservableCollection<T>
{
    public K Key { get; private set; }

    public Grouping(K key, IEnumerable<T> items)
    {
        Key = key;
        foreach (var item in items)
            this.Items.Add(item);
    }
}
public static class StaticClass
{
    private static int _myInt;
    private static double _sec;
    private static long _millsec;
    private static double _numberofRec;

    public static int GetMyInt()
    {
        return _myInt;
    }

    public static double GetNumberOfRec()
    {
        return _numberofRec;
    }
    public static double GetSec()
    {
        return _sec;
    }

    public static long GetMillSec()
    {
        return _millsec;
    }

    public static void SetSec()
    {
        _sec = _watcher.Elapsed.TotalSeconds;
    }
    public static void SetNumberOfRec(double value)
    {
        _numberofRec = value;
    }
    public static void SetMillSec()
    {
        _millsec = _watcher.ElapsedMilliseconds;
    }

    public static void SetMyInt(int value)
    {
        _myInt = value;
    }

    private static Stopwatch _watcher = new Stopwatch();

    public static void Start()
    {
        _watcher.Start();
    }

    public static void Stop()
    {
        _watcher.Stop();
    }

    public static void Reset()
    {
        _watcher.Reset();
    }

    public static void Resume()
    {
        _watcher.Start(); // Resume is the same as start if it was previously stopped.
    }

    public static double Elapsed()
    {
        return _watcher.Elapsed.TotalSeconds;
    }

    public static long ElapsedMilliseconds()
    {
        return _watcher.ElapsedMilliseconds;
    }

    public static bool IsRunning()
    {
        return _watcher.IsRunning;
    }
}