namespace Business.Constants
{
    public static class Messages

    {
        public static string[] ValidImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".TIF", ".TIFF", ".GIF", ".BMP", ".ICO" };
        public static string InvalidImageExtension = "Geçersiz dosya uzantısı, fotoğraf için kabul edilen uzantılar" + string.Join(",", ValidImageFileTypes);


        public static string ParticipantAdded = "Namizəd  əlavə edildi";
        public static string ParticipantDeleted = "Namizəd  silindi";
        public static string ParticipantListed= "Namizədlər  listələndi";
        public static string ParticipantUpdated= "Namizəd  yeniləndi";
        public static string ParticipantDoesNotExists = "Namizəd  bazada mövcud deyil";
        public static string ParticipantExists = "Namizəd  bazada mövcuddur";

        public static string ImageAdded="Şəkil əlavə edildi";
        public static string ImageDeleted="Şəkil silindi";
        public static string ImageUpdated="Şəkil yeniləndi";
        public static string ImagesListed="Şəkillər listələndi";


        public static string ImageMustBeExists = "Bu şəkil tapılmadı";            
        public static string ImageExists="Bu istifadəçinin şəkli artıq mövcuddur";


        public static string ExamAdded = "İmtahan əlavə edildi";
        public static string ExamDeleted = "İmtahan silindi";
        public static string ExamLisTed = "İmtahanlar listələndi";
        public static string ExamUpdated = "İmtahan güncəlləndi";

        public static string RoleAdded = "Rol əlavə edildi";
        public static string RoleDeleted= "Rol silindi";
        public static string RolesListed="Rollar listələndi";
        public static string RoleUpdated="Rol güncəlləndi";
        
        public static string CommissionAdded="Komissiya kodu əlavə edildi";
        public static string CommissionDeleted="Komissiya kodu silindi";
        public static string CommissionUpdated="Komissiya kodu yeniləndi";
        public static string CommissionsListed = " Komissiyalar listələndi";


        public static string RegionAdded="Region əlavə edildi";
        public static string RegionDeleted="Region silindi";
        public static string RegionsListed="Regionlar listələndi";
        public static string RegionUpdated = "Region güncəlləndi";

        public static string CreatedExamAdded="İmtahan Yaradıldı";
        public static string CreatedExamDeleted="Yaradılmış imtahan silindi";
        public static string CreatedExamsListed= "Yaradılmış imtahanlar listələndi";
        public static string CreatedExamUpdated= "Yaradılmış imtahan güncəlləndi";

        public static string ExamParticipantAdded="";
        public static string ExamParticipantDeleted="";
        public static string ExamParticipantsListed="";
        public static string ExamParticipantUpdated="";
        public static string ParticipantExistsThisExam="Namizəd bu imtahana bir dəfə əlavə edilib";
        public static string ExamParticipantsAdded="Namizədlər İmtahanlara əlavə edildi";
        public static string DoesNotExists="Bazada Mövcud deyil";
        public static string ExamParticipantsExists= "Namizədlər bu imtahana bir dəfə əlavə edilib";
        public static string ExamParticipantsDoesNotExist="Bu imtahanda heç bir namizəd tapılmadı";
    }
}
