namespace Fudee_v2.Models.ViewModels
{
	public class RestaurantsView
	{
		public RestaurantsView(int pageSize = 5)
		{
			PageSize = pageSize;
		}

		public int RestaurantCount { get; set; }
		public int PageSize { get; set; }
		public int PageNumber { get; set; }
		public int PageCount => (int)Math.Ceiling((decimal)RestaurantCount / PageSize);
		public int? Category { get; set; }
		public string? Restaurator { get; set; } 
		public string? Phrase { get; set; }
	}
}
