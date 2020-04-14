using BlabberApp.Domain;
using System.Collections;

namespace BlabberApp.Services
{
    public interface IBlabService
    {
       void AddBlab(Blab blab);

       IEnumerable GetAll(); 
    }
}