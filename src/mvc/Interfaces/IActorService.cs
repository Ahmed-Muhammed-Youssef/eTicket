using Microsoft.AspNetCore.Mvc.ViewFeatures;
using mvc.Data.Base;
using mvc.Models;

namespace mvc.Interfaces
{
    public interface IActorService : IEntityBaseRepository<Actor>
    {

    }
}
