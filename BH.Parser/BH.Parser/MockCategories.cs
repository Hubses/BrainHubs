namespace BH.Parser
{
    class MockCategories
    {
        public Categories[] GetCategories()
        {
            Categories[] categories = new Categories[5] { new Categories(1, "Экономика"), new Categories(2, "Политика"), new Categories(3, "Общество"),
                new Categories(4, "Спорт"), new Categories(5, "В мире")};

            //categories[0].Id = 1;
            //categories[0].Category = "Экономика";

            //categories[1].Id = 2;
            //categories[1].Category = "Политика";

            //categories[2].Id = 3;
            //categories[2].Category = "Общество";

            //categories[3].Id = 4;
            //categories[3].Category = "Спорт";

            //categories[4].Id = 5;
            //categories[4].Category = "В мире";

            return categories;
        }
    }
}
