using static System.Net.Mime.MediaTypeNames;

namespace Fudee_v2.Models.ViewModels
{
	public class RestaurantsViewModel
	{
		public IEnumerable<Restaurant>? Restaurants { get; set; }
		public RestaurantsView? RestaurantsView { get; set; }
	}
}
