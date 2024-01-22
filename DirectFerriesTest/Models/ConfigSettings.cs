namespace DirectFerriesTest.Models
{
    public class ConfigSettings
    {

        public int TotalWeeks { get; private set; }
        public string HistoryURLFormat { get; private set; }
        private readonly IConfiguration Configuration;

        public ConfigSettings(IConfiguration configuration)
        {
            Configuration = configuration;
            PopulateSettings();
        }

        private void PopulateSettings()
        {
            TotalWeeks = Convert.ToInt32(Configuration["TotalWeeks"]);
            HistoryURLFormat = Configuration["HistoryURLFormat"].ToString();
        }

    }
}
