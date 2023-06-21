namespace SportsStore.Web.Models;

public interface IStoreRepository
{
	IQueryable<Product> Products { get; }
}
