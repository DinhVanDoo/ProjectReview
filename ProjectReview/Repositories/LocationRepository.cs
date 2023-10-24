using ProjectReview.Interfaces;
using ProjectReview.Models;

namespace ProjectReview.Repositories
{
    public interface ILocationRepository
    {

    }
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(PROJECTREVIEWContext dbContext) : base(dbContext)
        {
        }
    }
}
