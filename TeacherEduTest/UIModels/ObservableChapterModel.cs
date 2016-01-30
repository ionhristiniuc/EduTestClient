using System.Collections.ObjectModel;

namespace TeacherEduTest.UIModels
{
    public class ObservableChapterModel
    {
        public int ModuleId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public ObservableCollection<ObservableTopicModel> Topics { get; set; }
        //public ObservableCollection<TestModel> Tests { get; set; }
    }
}
