namespace Calculator;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
        settheme();
	}
    public void settheme()
    {
        String themename;
        var isFirtsload = Preferences.Get("FirstLoad", true);
        if (isFirtsload)
        {
            var currtheme = Application.Current.RequestedTheme;
            if (currtheme == AppTheme.Dark)
                themename = "Royalty";
            else
                themename = "nuatical";
        }
        else
        {
            themename = Preferences.Get("Theme", "Nuatical");
        }
        Preferences.Set("FirstLoad", false);

        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            foreach (ResourceDictionary dictioneries in mergedDictionaries)
            {
                var primaryFound = dictioneries.TryGetValue(themename + "Primary", out var primary);
                if (primaryFound)
                    dictioneries["Primary"] = primary;
                var secondaryFound = dictioneries.TryGetValue(themename + "Secondary", out var secondary);
                if (secondaryFound)
                    dictioneries["Secondary"] = secondary;
                var teritiartfound = dictioneries.TryGetValue(themename + "Tertiary", out var teritiart);
                if (teritiartfound)
                    dictioneries["Tertiary"] = teritiart;
                var accentfound = dictioneries.TryGetValue(themename + "Accent", out var accent);
                if (accentfound)
                    dictioneries["Accent"] = accent;
                var darkAccentFound = dictioneries.TryGetValue(themename + "DarkAccent", out var darkAccent);
                if (darkAccentFound)
                    dictioneries["DarkAccent"] = darkAccent;


            }
        }
    }
}
