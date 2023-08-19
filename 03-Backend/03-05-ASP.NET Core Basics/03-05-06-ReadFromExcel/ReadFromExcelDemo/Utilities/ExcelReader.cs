using OfficeOpenXml;

namespace ReadFromExcelDemo.Utilities;

public class ExcelReader<T>
{
    private readonly string _filePath;

    public ExcelReader(string filePath)
    {
        _filePath = filePath;
        ExcelPackage.LicenseContext = LicenseContext.Commercial;
    }

    public List<T> ReadData(Func<ExcelWorksheet, int, T> mapFunction)
    {
        var dataList = new List<T>();

        using (var package = new ExcelPackage(new FileInfo(_filePath)))
        {
            var worksheet = package.Workbook.Worksheets[0];
            int rows = worksheet.Dimension.Rows;

            // Skip the header row
            for (int row = 2; row <= rows; row++)
            {
                var data = mapFunction(worksheet, row);
                dataList.Add(data);
            }
        }

        return dataList;
    }
}