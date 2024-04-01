namespace TreningProject.Abstractions
{
    /// <summary>
    /// Состояние погоды
    /// </summary>
    public class WeatherCondition : BaseEntity
    {
        /// <summary>
        /// Дата, время
        /// </summary>
        public DateTimeOffset DateTime { get; set; }

        /// <summary>
        /// Температура воздуха
        /// </summary>
        public double AirTemperature { get; set; }

        /// <summary>
        /// Относительная влажность
        /// </summary>
        public double RelativeHumidity { get; set; }

        /// <summary>
        /// Точка расы
        /// </summary>
        public double RacePoint { get; set; }

        /// <summary>
        /// Атмосферное давление
        /// </summary>
        public double? AtmosphericPressure { get; set; }

        /// <summary>
        /// Направление ветра
        /// </summary>
        public string? WindDirection { get; set; }

        /// <summary>
        /// Скорость ветра
        /// </summary>
        public int? WindSpeed { get; set; }

        /// <summary>
        /// Облачность
        /// </summary>
        public int? CloudCover { get; set; }

        /// <summary>
        /// Нижняя граница облачности
        /// </summary>
        public int? LowerBound { get; set; }

        /// <summary>
        /// Горизонтальная видимость
        /// </summary>
        public int? HorizontalVisibility { get; set; }

        /// <summary>
        /// Погодное явление
        /// </summary>
        public string? WeatherPhenomenon { get; set; }
    }
}