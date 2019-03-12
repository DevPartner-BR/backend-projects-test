using System.Configuration;

namespace Data
{
    public abstract class BaseRepository
    {
        public string Connstring = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
    }
}