using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.DAL.Interfaces
{
    public interface IStoreDbContext
    {
        DbSet<AgeType> AgeTypes { get; set; }
        DbSet<AmountOfSize> AmountOfSizes { get; set; }
        DbSet<Brand> Brands { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Color> Colors { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<Factory> Factories { get; set; }
        DbSet<Gender> Genders { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<Model> Models { get; set; }
        DbSet<ModelData> ModelData { get; set; }
        DbSet<Season> Seasons { get; set; }
        DbSet<Size> Sizes { get; set; }
        DbSet<SubCategory> SubCategories { get; set; }
        DbSet<MainImage> MainImages { get; set; }
        DbSet<City> Cities { get; set; }
        DbSet<Address> Addresses { get; set; }

        DbSet<Order> Orders { get; set; }
        DbSet<BuyModel> BuyModels { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new());
    }
}