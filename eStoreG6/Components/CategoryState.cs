namespace eStoreG6.Components
{
    public class CategoryState
    {
        public event Action? OnChange;
        private int? _selectedCategoryId;

        public int? SelectedCategoryId
        {
            get => _selectedCategoryId;
            set
            {
                if (_selectedCategoryId != value)
                {
                    _selectedCategoryId = value;
                    OnChange?.Invoke();
                }
            }
        }
    }
}
