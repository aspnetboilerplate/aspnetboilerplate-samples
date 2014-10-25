using Abp.Application.Services.Dto;

namespace AbpjTable.Cities
{
    public class ComboboxItemDto : IDto //TODO: Move to ABP!
    {
        public string Value { get; set; }

        public string DisplayText { get; set; }

        public ComboboxItemDto()
        {
            
        }

        public ComboboxItemDto(string value, string displayText)
        {
            Value = value;
            DisplayText = displayText;
        }
    }
}