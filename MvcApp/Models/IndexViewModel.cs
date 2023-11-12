namespace MvcApp.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Cloth> Clothes { get; }
        public PageViewModel PageViewModel { get; }
        public FilterViewModel FilterViewModel { get; }
        public IndexViewModel(IEnumerable<Cloth> clothes, PageViewModel pageViewModel,
            FilterViewModel filterViewModel)
        {
            Clothes = clothes;
            PageViewModel = pageViewModel;
            FilterViewModel = filterViewModel;
        }
    }
}
