using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcApp.Models
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Cloth_type> cloth_types, int cloth_type, string cloth_size)
        {
            cloth_types.Insert(0, new Cloth_type { Name_cloth_type = "Все", Id = 0 });
            Cloth_types = new SelectList(cloth_types, "Id", "Name_cloth_type", cloth_type);
            Selected_Cloth_type = cloth_type;
            SelectedName = cloth_size;
        }
        public SelectList Cloth_types { get; } // список всех видов одежды
        public int Selected_Cloth_type { get; } // выбранная одежда
        public string SelectedName { get; } // выбор сортировки
    }
}
