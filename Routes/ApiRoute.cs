namespace vanb.Routes
{
    public static class ApiRoute
    {
        public const string Root = "api";
        public const string Version = "v1";

        public const string Base = $"{Root}/{Version}";

        public static class PostRoute 
        {
            public const string FindDiffInPar = Base + "/findDiffInPar";
        }
    }
}