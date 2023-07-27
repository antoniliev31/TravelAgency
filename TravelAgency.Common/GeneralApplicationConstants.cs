namespace TravelAgency.Common
{
    
    public static class GeneralApplicationConstants
    {
        public const int ReleaseYear = 2021;
        
        public const int DefaultPage = 1;
        public const int EntitiesPerPage = 6;

        public static string MinDate => DateTime.Today.ToString();
        public static string MaxDate => DateTime.Today.AddYears(1).ToString();
    }
}