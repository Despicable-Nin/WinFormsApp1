namespace WinForms.Service
{
    public static class InventoryManager
    {
        static ICollection<Item>? _items;

        public static ICollection<Item> Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new List<Item>();
                }

                return _items;
            }
        }


    }

    public class Item
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Code { get; set; }
    }
}
