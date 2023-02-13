namespace Asp.net_core_API.Core.Exceptions
{
    public class ProjectAlreadyStartedException : Exception
    {
        public ProjectAlreadyStartedException(): base("Project is already in Started status")
        {
            
        }
    }
}
