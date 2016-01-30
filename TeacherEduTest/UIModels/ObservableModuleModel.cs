using System.Collections.ObjectModel;

namespace TeacherEduTest.UIModels
{
    public class ObservableModuleModel
    {
        public int CourseId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public ObservableCollection<ObservableChapterModel> Chapters { get; set; }
        //public ObservableCollection<TestModel> Tests { get; set; }
    }
}
