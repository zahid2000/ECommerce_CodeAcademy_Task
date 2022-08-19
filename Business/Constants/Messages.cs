using Entities;

namespace Business.Constants
{
    public static class Messages

    {
        public static string[] ValidImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".TIF", ".TIFF", ".GIF", ".BMP", ".ICO" };

        public static string InvalidImageExtension = "Etibarsiz fayl uzantısı, şəkil üçün uyğun olan fayl uzantıları" + string.Join(",", ValidImageFileTypes);
        public static string[] ValidExcelFileTypes= { ".XLS", ".XLSX" };
        public static string InvalidExcelExtension = "Etibarsiz fayl uzantısı, excel faylı üçün uyğun olan  uzantılar" + string.Join(",", ValidExcelFileTypes);
        public static string FileMemorySizeIsLong="Yüklənmiş faylın yaddaşı 5 mb dan böyükdür!";


        public static string Added = "Sistemə yükləndi";
        public static string Updated = "Məlumat yeniləndi";
        public static string Deleted = "Məlumat silindi";
        public static string Listed = "Məlumatlar listələndi";
        public static string NotFound="Məlumat tapılmadı";
    }
}
