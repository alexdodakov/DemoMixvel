namespace DemoMixvel.Database.Seeder
{
    public static class RouteSeedData
    {
        public static readonly object[,] Routes = new object[,]
        {
            // Moscow directions
            { Guid.NewGuid(), "Moscow", "Saint-Petersburg", new DateTime(2025, 3, 15, 8, 0, 0), new DateTime(2025, 3, 15, 14, 30, 0), 2500m, new DateTime(2025, 1, 15) },
            { Guid.NewGuid(), "Moscow", "Kazan", new DateTime(2025, 3, 17, 7, 0, 0), new DateTime(2025, 3, 17, 13, 0, 0), 3200m, new DateTime(2025, 1, 17) },
            { Guid.NewGuid(), "Moscow", "Sochi", new DateTime(2025, 4, 1, 6, 0, 0), new DateTime(2025, 4, 1, 16, 0, 0), 5500m, new DateTime(2025, 2, 1) },
            { Guid.NewGuid(), "Moscow", "Sochi", new DateTime(2025, 3, 20, 5, 0, 0), new DateTime(2025, 3, 21, 8, 0, 0), 7500m, new DateTime(2025, 2, 20) },
            { Guid.NewGuid(), "Moscow", "Sochi", new DateTime(2025, 3, 20, 5, 0, 0), new DateTime(2025, 3, 21, 8, 0, 0), 7600m, new DateTime(2025, 1, 25) },
            { Guid.NewGuid(), "Moscow", "Novosibirsk", new DateTime(2025, 3, 20, 5, 0, 0), new DateTime(2025, 3, 21, 8, 0, 0), 7500m, new DateTime(2025, 1, 20) },
            { Guid.NewGuid(), "Moscow", "Novosibirsk", new DateTime(2025, 3, 21, 5, 0, 0), new DateTime(2025, 3, 21, 8, 0, 0), 6500m, new DateTime(2025, 2, 20) },
            { Guid.NewGuid(), "Moscow", "Novosibirsk", new DateTime(2025, 3, 21, 5, 0, 0), new DateTime(2025, 3, 21, 8, 0, 0), 8500m, new DateTime(2025, 2, 20) },

            // Saint-Petersburg directions
            { Guid.NewGuid(), "Saint-Petersburg", "Moscow", new DateTime(2025, 3, 16, 10, 0, 0), new DateTime(2025, 3, 16, 16, 30, 0), 2600m, new DateTime(2025, 3, 16) },
            { Guid.NewGuid(), "Saint-Petersburg", "Kazan", new DateTime(2025, 3, 19, 10, 0, 0), new DateTime(2025, 3, 19, 18, 0, 0), 4000m, new DateTime(2025, 3, 19) },
            { Guid.NewGuid(), "Saint-Petersburg", "Sochi", new DateTime(2025, 4, 10, 7, 0, 0), new DateTime(2025, 4, 10, 19, 0, 0), 6500m, new DateTime(2025, 1, 10) },

            // Kazan directions
            { Guid.NewGuid(), "Kazan", "Moscow", new DateTime(2025, 3, 18, 9, 0, 0), new DateTime(2025, 3, 18, 15, 0, 0), 3300m, new DateTime(2025, 1, 18) },
            { Guid.NewGuid(), "Kazan", "Saint-Petersburg", new DateTime(2025, 3, 22, 12, 0, 0), new DateTime(2025, 3, 22, 20, 0, 0), 4100m, new DateTime(2025, 2, 22) },
            { Guid.NewGuid(), "Kazan", "Novosibirsk", new DateTime(2025, 3, 23, 6, 0, 0), new DateTime(2025, 3, 24, 6, 0, 0), 6000m, new DateTime(2025, 3, 23) },

            // Sochi directions
            { Guid.NewGuid(), "Sochi", "Moscow", new DateTime(2025, 4, 5, 8, 0, 0), new DateTime(2025, 4, 5, 18, 0, 0), 5700m, new DateTime(2025, 1, 5) },
            { Guid.NewGuid(), "Sochi", "Saint-Petersburg", new DateTime(2025, 4, 15, 9, 0, 0), new DateTime(2025, 4, 15, 21, 0, 0), 6700m, new DateTime(2025, 2, 15) },

            // Novosibirsk directions
            { Guid.NewGuid(), "Novosibirsk", "Moscow", new DateTime(2025, 3, 25, 7, 0, 0), new DateTime(2025, 3, 26, 10, 0, 0), 7700m, new DateTime(2025, 2, 25) },
            { Guid.NewGuid(), "Novosibirsk", "Kazan", new DateTime(2025, 3, 28, 8, 0, 0), new DateTime(2025, 3, 29, 8, 0, 0), 6200m, new DateTime(2025, 1, 28) },

            // Additional
            { Guid.NewGuid(), "Moscow", "Kazan", new DateTime(2025, 4, 5, 9, 0, 0), new DateTime(2025, 4, 5, 15, 0, 0), 3500m, new DateTime(2025, 1, 5) },
            { Guid.NewGuid(), "Saint-Petersburg", "Novosibirsk", new DateTime(2025, 4, 12, 6, 0, 0), new DateTime(2025, 4, 13, 6, 0, 0), 8000m, new DateTime(2025, 1, 12) },
            { Guid.NewGuid(), "Sochi", "Kazan", new DateTime(2025, 4, 20, 10, 0, 0), new DateTime(2025, 4, 20, 20, 0, 0), 5000m, new DateTime(2025, 1, 20) },
            { Guid.NewGuid(), "Novosibirsk", "Sochi", new DateTime(2025, 4, 25, 5, 0, 0), new DateTime(2025, 4, 26, 5, 0, 0), 7000m, new DateTime(2025, 1, 25) },
            { Guid.NewGuid(), "Kazan", "Sochi", new DateTime(2025, 5, 1, 8, 0, 0), new DateTime(2025, 5, 1, 18, 0, 0), 4800m, new DateTime(2025, 1, 1) }
        };
    }
}