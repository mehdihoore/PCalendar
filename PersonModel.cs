namespace cal_endar
{
    internal class PersonModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fullname
        {
            get
            {
                return $"{Firstname}{Lastname}";
            }
        }
    }
}