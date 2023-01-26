namespace DATA.Model
{
    public class SuhbatTopshiruvchi
    {

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Daraja { get; set; }
        public string Tajriba { get; set; }
        public string Tel { get; set; }
        public int OluvchiId { get; set; }
        public SuhbatOluvchi suhbatOluvchi { get; set; }
    }
}
