using System.IO;

namespace TreningProject.Helpers
{
    /// <summary>
    /// Хелпер для работы с файлами
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// Сохранить файл (асинхронно)
        /// </summary>
        /// <param name="file">Файл для сохранения</param>
        /// <param name="pathToDir">Директория для сохранения</param>
        /// <returns></returns>
        public static async Task<string> SaveFileAsync(IFormFile file, string pathToDir)
        {
            var filePath = Path.Combine(pathToDir, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }

        /// <summary>
        /// Удалить файл
        /// </summary>
        /// <param name="path">Путь до файла</param>
        /// <returns></returns>
        public static void DeleteFile(string path)
        {
            File.Delete(path);
        }

        /// <summary>
        /// Удалить файлы
        /// </summary>
        /// <param name="pathes">Пути до файлов</param>
        /// <returns></returns>
        public static void DeleteFiles(string[] pathes)
        {
            for (int i = 0; i < pathes.Length; i++) 
            {
                File.Delete(pathes[i]);
            }
        }
    }
}
