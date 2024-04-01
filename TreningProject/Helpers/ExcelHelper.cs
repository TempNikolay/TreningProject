using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using TreningProject.Abstractions;

namespace TreningProject.Helpers
{
    /// <summary>
    /// Хелпер для работы с Excel-файлами
    /// </summary>
    public class ExcelHelper
    {
        /// <summary>
        /// Валидация аргумента
        /// </summary>
        private static void ArgumentValidation(string[] pathes)
        {
            if (pathes == null)
                throw new ArgumentNullException("Пути до файлов не должены быть пустыми.", nameof(pathes));

            if (pathes.Length == 0)
                throw new ArgumentException("Необходимо передать файлы.");
        }

        /// <summary>
        /// Спарсить состояние погоды из строки Excel
        /// </summary>
        /// <param name="row">Строка Excel</param>
        /// <returns></returns>
        private static WeatherCondition ParseWeatherConditionFromRow(IRow? row)
        {
            ICell tempCell = null;

            var result = new WeatherCondition();
            result.DateTime = DateTimeOffset.Parse($"{row.GetCell(0).StringCellValue} {row.GetCell(1).StringCellValue}").ToUniversalTime();
            result.AirTemperature = row.GetCell(2).NumericCellValue;
            result.RelativeHumidity = row.GetCell(3).NumericCellValue;
            result.RacePoint = row.GetCell(4).NumericCellValue;

            tempCell = row.GetCell(5);
            result.AtmosphericPressure = tempCell.CellType == CellType.Numeric ? tempCell.NumericCellValue : null;
            
            result.WindDirection = row.GetCell(6)?.StringCellValue;

            tempCell = row.GetCell(7);
            result.WindSpeed = tempCell.CellType == CellType.Numeric ? (int)tempCell.NumericCellValue : null;

            tempCell = row.GetCell(8);
            result.CloudCover = tempCell.CellType == CellType.Numeric ? (int)tempCell.NumericCellValue : null;

            tempCell = row.GetCell(9);
            result.LowerBound = tempCell.CellType == CellType.Numeric ? (int)tempCell.NumericCellValue : null;

            tempCell = row.GetCell(10);
            result.HorizontalVisibility = tempCell.CellType == CellType.Numeric ? (int)tempCell.NumericCellValue : null;
            result.WeatherPhenomenon = row.GetCell(11)?.StringCellValue;

            return result;
        }

        /// <summary>
        /// Получить состояния погоды из файлов
        /// </summary>
        /// <param name="pathes">Пути до Excel-файлов</param>
        /// <returns></returns>
        public static List<WeatherCondition> GetWeatherConditions(string[] pathes)
        {
            ArgumentValidation(pathes);

            var weatherConditions = new List<WeatherCondition>();

            for (int i = 0; i < pathes.Length; i++)
            {
                using (var file = new FileStream(pathes[i], FileMode.Open, FileAccess.Read))
                {
                    using (var workbook = new XSSFWorkbook(file))
                    {
                        foreach (var sheet in workbook)
                        {
                            for (int j = 4; j <= sheet.LastRowNum; j++) // пропускаем заголовки
                            {
                                var row = sheet.GetRow(j);

                                var weatherCondition = ParseWeatherConditionFromRow(row);

                                weatherConditions.Add(weatherCondition);
                            }
                        }
                    }
                }
            }

            return weatherConditions;
        }
    }
}
