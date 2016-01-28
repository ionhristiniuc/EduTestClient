using System.Collections.Generic;

namespace EduTestServiceClient.DTO
{
    public class Items<T>
    {
        public List<T> data { get; set; }
        public int page { get; set; }
        public int total_pages { get; set; }
        public int total_elements { get; set; }
    }
}
