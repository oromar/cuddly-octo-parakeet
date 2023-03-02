namespace WorkSchedule.Domain.Common
{
    public interface ITextSearcheable
    {
        public string SearchText { get; set; }
        void CreateSearchText();
    }
}
