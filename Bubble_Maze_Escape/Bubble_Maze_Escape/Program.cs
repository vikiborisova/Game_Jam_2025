namespace Bubble_Maze_Escape
{
    internal static class Program
    {
        public static ApplicationContext AppContext { get; set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Program.AppContext = new ApplicationContext(new Bubble_Maze_Escape_Easy());
            Application.Run(AppContext);
        }

        public static void SwitchMainForm(Form newForm)
        {
            var oldMainForm = AppContext.MainForm;
            AppContext.MainForm = newForm;
            oldMainForm?.Close();
            newForm.Show();
        }
    }
}