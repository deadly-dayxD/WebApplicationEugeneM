using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplicationEugeneM.Models
{
    public class IndexViewModel
    {
        public IEnumerable<User> Users { get; set; } = new List<User>();
        public PageViewModel PageViewModel { get; }
        public FilterViewModel FilterViewModel { get; }
        public SortViewModel SortViewModel { get; set; } = new SortViewModel(SortState.NameAsc);
        public SelectList Companies { get; set; } = new SelectList(new List<Company>(), "Id", "Name");
        public string? Name { get; set; }
        public IndexViewModel(IEnumerable<User> users, PageViewModel pageViewModel, FilterViewModel filterViewModel, SortViewModel sortViewModel)
        {
            Users = users;
            PageViewModel = pageViewModel;
            FilterViewModel = filterViewModel;
            SortViewModel = sortViewModel;
        }
    }
}
