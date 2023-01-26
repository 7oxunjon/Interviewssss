namespace DATA.Model
{
    public class SuhbatOluvchi
    {

        public int Id { get; set; }
        public string Yunalish { get; set; }
        public string Fullname { get; set; }
        public string Darajasi { get; set; }
        public string Loyxasi { get; set; }
        public string Tajribasi { get; set; }
        public List<SuhbatTopshiruvchi> suhbatTopshiruvchis { get; set; }
    }
}
