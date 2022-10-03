namespace Calculator.Pages;

public partial class Themes : ContentPage
{
	public Themes()
	{
		InitializeComponent();
	}
    void OnSelectonpurpleColor(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        var themeName = button.Text;
        Preferences.Set("Theme", themeName);

        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            foreach (ResourceDictionary dictionaries in mergedDictionaries)
            {
                var primaryFound = dictionaries.TryGetValue(themeName + "Primary", out var primary);
                if (primaryFound)
                    dictionaries["Primary"] = primary;

                var secondaryFound = dictionaries.TryGetValue(themeName + "Secondary", out var secondary);
                if (secondaryFound)
                    dictionaries["Secondary"] = secondary;

                var tertiaryFound = dictionaries.TryGetValue(themeName + "Tertiary", out var tertiary);
                if (tertiaryFound)
                    dictionaries["Tertiary"] = tertiary;

                var accentFound = dictionaries.TryGetValue(themeName + "Accent", out var accent);
                if (accentFound)
                    dictionaries["Accent"] = accent;

                var darkAccentFound = dictionaries.TryGetValue(themeName + "DarkAccent", out var darkAccent);
                if (darkAccentFound)
                    dictionaries["DarkAccent"] = darkAccent;


            }
        }

    }


}