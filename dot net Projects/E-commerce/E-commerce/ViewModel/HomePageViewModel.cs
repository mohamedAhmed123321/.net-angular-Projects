using Domains.SpResult;
using Domains.Tables;
namespace E_commerce.ViewModel
{
    public class HomePageViewModel
    {
        public List<Sp_GetHomePageData_Result> AllItems { get; set; }
        public List<Sp_GetHomePageData_Result> RecommendedItems { get; set; }
        public List<Sp_GetHomePageData_Result> FreeDelevired { get; set; }
        public List<TbCategory> Categorys { get; set; }
        public List<TbSlider> Sliders { get; set; }


    }
}
