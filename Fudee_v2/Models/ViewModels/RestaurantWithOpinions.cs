using static System.Net.Mime.MediaTypeNames;

namespace Fudee_v2.Models.ViewModels
{
    public class RestaurantWithOpinions
    {
        public Restaurant SelectedRestaurant { get; set; }

        public int CommentsNumber { get; set; }
        public int OpinionsNumber { get; set; }
        public float AverageScore { get; set; }
        public string Description { get; set; }

        public RestaurantWithOpinions()
        {
            CommentsNumber = 0;
            OpinionsNumber = 0;
            AverageScore = 0f;
        }
    }
}
