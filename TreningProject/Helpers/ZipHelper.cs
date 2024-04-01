using System.IO.Compression;

namespace TreningProject.Helpers
{
    /// <summary>
    /// Хелпер для работы с Zip-архивами
    /// </summary>
    public class ZipHelper
    {
        /// <summary>
        /// Валидация аргументов
        /// </summary>
        private static void ArgumentValidation(string path, string unzipToDir)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("Путь до архива не должен быть пустым.", nameof(path));

            if (!File.Exists(path))
                throw new ArgumentException("Файлов не существует.");

            if (!path.EndsWith(".zip"))
                throw new ArgumentException("Архив должен иметь расширение \".zip\".");

            if (string.IsNullOrEmpty(unzipToDir))
                throw new ArgumentNullException("Путь до директории не должен быть пустым.", nameof(unzipToDir));

            if (!Directory.Exists(unzipToDir))
                throw new ArgumentException("Файлов не существует.");
        }

        /// <summary>
        /// Разархивировать
        /// </summary>
        /// <param name="path">Путь до архива</param>
        /// <param name="unzipToDir">Путь до директории куда разархивировать</param>
        /// <returns>Коллекция путей разархивированный файлов</returns>
        public static string[] Unzip(string path, string unzipToDir)
        {
            ArgumentValidation(path, unzipToDir);
            ZipFile.ExtractToDirectory(path, unzipToDir, true);
            string fileName = Path.GetFileNameWithoutExtension(path);
            unzipToDir = unzipToDir + "\\" + fileName;

            return Directory.GetFiles(unzipToDir);
        }
    }
}
