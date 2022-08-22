using Entities;

namespace Business.Constants
{
    public static class Messages

    {
        public static string[] ValidImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".TIF", ".TIFF", ".GIF", ".BMP", ".ICO" };

        public static string InvalidImageExtension = "Etibarsiz fayl uzantısı, şəkil üçün uyğun olan fayl uzantıları" + string.Join(",", ValidImageFileTypes);
        public static string[] ValidExcelFileTypes= { ".xls", ".xlsx" };
        public static string InvalidExcelExtension = "Etibarsiz fayl uzantısı, excel faylı üçün uyğun olan  uzantılar" + string.Join(",", ValidExcelFileTypes);
        public static string FileMemorySizeIsLong="Yüklənmiş faylın yaddaşı 5 mb dan böyükdür!";


        public static string Added = "Sistemə yükləndi";
        public static string Updated = "Məlumat yeniləndi";
        public static string Deleted = "Məlumat silindi";
        public static string Listed = "Məlumatlar listələndi";
        public static string NotFound="Məlumat tapılmadı";
        public static string ReportTypeDoesNotExists="Bu tipdə hesabat növü mövcud deyil";
        public static string SendedReport="Hesabat göndərildi";
        public static string IncorrectEmailType="Email dogru deyil";
        public static string EmailIsNull="Email siyahısı boşdur";
        public static string EmailIsNotEqual="Email 'code.edu.az' sablonuna uygun deyil";
        public static string DateMustBeExists="Tarix boş ola bilməz";
        public static string IsSameDate = "Girilən tarixlər eynidir";
        public static string IncorrectDateTime= "Girilən tarixlər dogru deyil";
        public static string UploadData="Yükləndi";
    }
}
