namespace lab2
{
    struct FilmLibrary
    {
        private string name;
        private string genre;
        private string country;
        private int price1;
        private int price2;
        private int price3;

        public string Name { get => name; set => name = value; }
        public string Genre { get => genre; set => genre = value; }
        public string Country { get => country; set => country = value; }
        public int Price1 { get => price1; set => price1 = value; }
        public int Price2 { get => price2; set => price2 = value; }
        public int Price3 { get => price3; set => price3 = value; }
    }
}
