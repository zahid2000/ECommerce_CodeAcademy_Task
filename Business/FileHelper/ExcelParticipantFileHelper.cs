namespace Business.FileHelper
{
    public class ExcelParticipantFileHelper
    {
        //public static List<ExcelParticipant> GetExcelParticipantFromExcel(IFormFile file)
        //{
        //    List<ExcelParticipant> excelParticipants = new List<ExcelParticipant>();
        //    using (var stream = new MemoryStream())
        //    {
        //        file.CopyTo(stream);
        //        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        //        using (var package = new ExcelPackage(stream))
        //        {
        //            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
        //            var rowCount = worksheet.Dimension.Rows;
        //            for (int row = 2; row <= rowCount; row++)
        //            {
        //                if (worksheet.Cells[row, 1].Value == null && worksheet.Cells[row, 2].Value ==null && worksheet.Cells[row, 3].Value == null && worksheet.Cells[row, 4].Value == null && worksheet.Cells[row, 5].Value == null && worksheet.Cells[row, 6].Value == null && worksheet.Cells[row, 7].Value == null && worksheet.Cells[row, 8].Value == null)
        //                {
        //                    break;
        //                }
        //                excelParticipants.Add(new ExcelParticipant
        //                {
                           
        //                    CommissionCode =worksheet.Cells[row, 1].Value.ToString().Trim(),
        //                    JobNo = worksheet.Cells[row, 2].Value.ToString().Trim(),
        //                    LastName = worksheet.Cells[row, 3].Value.ToString().Trim(),
        //                    FirstName = worksheet.Cells[row, 4].Value.ToString().Trim(),
        //                    FatherName = worksheet.Cells[row, 5].Value.ToString().Trim(),
        //                    SpecialtyCode = worksheet.Cells[row, 6].Value.ToString().Trim(),
        //                    GroupNumber =worksheet.Cells[row, 7].Value.ToString().Trim(),
        //                    ExamName = worksheet.Cells[row, 8].Value.ToString().Trim(),
        //                    ExamDate =worksheet.Cells[row, 9].Value.ToString().Trim(),
        //                    RoomNo =worksheet.Cells[row,10].Value.ToString().Trim(),
        //                    ExamPlace=worksheet.Cells[row,11].Value.ToString().Trim(),
        //                    ExamLocation=worksheet.Cells[row,12].Value.ToString().Trim()

        //                }) ;
        //            }
        //        }
        //    }
        //    return excelParticipants;

        //}

    }
}
