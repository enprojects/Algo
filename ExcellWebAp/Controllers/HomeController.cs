using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExcellWebAp.Models;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using System.Drawing;
using System.Text.RegularExpressions;

namespace ExcellWebAp.Controllers
{
    public class HomeController : Controller
    {

        public interface IBase { }

        public class Order : IBase
        {
            public string Name { get; } = "My Name";
            public string SeconfNAme { get; } = "My seconde name";
        }

        public class Order2 : IBase
        {
            public string Name { get; } = "My Name ord 2";
            public string SeconfNAme { get; } = "My seconde name ord2";
        }


        public class Person
        {

            public decimal salery { get; set; }
            public string Name { get; set; }
            public string NoId { get; set; }

        }

        public IActionResult Index()
        {
            //var stupidList = new List<IBase> { new Order { } , new Order2 { } };

            //foreach (var item in stupidList)
            //{

            //}

            string str = null;
            var test = $"{str}";

            var lst = new List<Person> {
               new Person {  salery =50.99M, Name ="name 1", NoId ="2"},
                new Person {  salery =300555.34M, Name ="mohamad", NoId ="2"},
               new Person {  salery =76889.88M, Name ="david", NoId ="1"},
                new Person {  salery =30000, Name ="moshe222222", NoId ="1"},
                 new Person {  salery =33.88M, Name ="david4444", NoId ="1"},
                new Person {  salery =53.90M, Name ="moshe", NoId ="1"}

           };


            //var grp = lst.GroupBy(x => x.NoId).ToDictionary(x => x.Key, x => x.ToList());
             
            //foreach (var item in grp)
            //{
            //    foreach (var p in item.Value)
            //    {
                      
            //    }
                 
            //}
            ////
            //var var1 = grp.SelectMany(x => x.Value);

         
             

            var bytes = ReturnExcell(lst, new List<string> { "salery", "Name", "NoId" });

            return File(bytes, "application/vnd.ms-excel", "mytestfile.xlsx");
        }

        private static string GetPerson(Person y)
        {
            return $"{y.NoId}- {y.Name}";
        }

        private void SetCaption(ExcelWorksheet ws, int fromRow, int fromCol, int toRow, int toCcol)
        {
             var title = ws.Cells[ fromRow, fromCol];
           title.Value = "No chart to display";
            title.Style.Font.Size = 16;


            var mergeTitle = ws.Cells[fromRow, fromCol, toRow, toCcol];
            mergeTitle.Merge = true;
            mergeTitle.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

       
            mergeTitle.Style.Fill.PatternType = ExcelFillStyle.Solid;
            mergeTitle.Style.Fill.BackgroundColor.SetColor(Color.Gray);


          


        }

        private byte[] ReturnExcell(List<Person> lst, List<string> columns)
        {
            ExcelPackage pck = new ExcelPackage();
            var ws = pck.Workbook.Worksheets.Add("Sample1");

            var startFomRow = 10;

           

            SetCaption(ws, startFomRow - 2, 1, startFomRow - 1, columns.Count);

           // var title = ws.Cells[startFomRow - 2, 1, startFomRow - 1, columns.Count];
            //title.Merge = true;
            //title.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            //title.Value = "No chart to display";
            //title.Style.Font.Size = 16;
            //title.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //title.Style.Fill.BackgroundColor.SetColor(Color.Gray);



            //https://tedgustaf.com/blog/2012/create-excel-20072010-spreadsheets-with-c-and-epplus/


            // Columns name 
            for (int i = 0; i < columns.Count; i++)
            {
                var row = startFomRow;
                var col = i+1;

                ws.Cells[row, col].Value = columns[i];
                ws.Cells[row, col].Style.Font.Bold = true;
                ws.Cells[row, col].Style.Font.Size = 18;

              





                foreach (var item in lst)
                {
                    var type = item.GetType();
                    var propInfo = type.GetProperties().Where(x => x.Name == columns[i]).FirstOrDefault();
                    var val  = propInfo.GetValue(item);
                    var rng = ws.Cells[++row, col];
                    rng.Value = val;

                    Regex regex = new Regex(@"\d+");
                    Match match = regex.Match(@"\d+(\.\d{1,2})?");
                    if (match.Success)
                    {
                       rng.Style.Numberformat.Format = "#,##0.00";
                    }


                }

            }
    
            using (ExcelRange Rng = ws.Cells[startFomRow, 1, lst.Count+ startFomRow, columns.Count])
            {


                ExcelTableCollection tblcollection = ws.Tables;
                ExcelTable table = tblcollection.Add(Rng, "data");
                table.ShowHeader = true;
                table.ShowFilter = true;
                //  table.TableStyle = TableStyles.Medium2;
                ws.View.ShowGridLines = false;
                Rng.AutoFitColumns();

               
                Rng.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                Rng.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                 Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


                //var modelCells = ws.Cells[startFomRow, 1, lst.Count + startFomRow, columns.Count];
                //var border = Rng.Style.Border.Top.Style = Rng.Style.Border.Left.Style = Rng.Style.Border.Right.Style = Rng.Style.Border.Bottom.Style = ExcelBorderStyle.Medium;

            }
            return pck.GetAsByteArray();
         



       // ws.View.ShowGridLines = true;
            //ws.Cells["A1"].Value = "Sample 1";
            //ws.Cells["A1"].Style.Font.Bold = true;
            //var shape = ws.Drawings.AddShape("Shape1", eShapeStyle. );
            //shape.SetPosition(50, 200);
            //shape.SetSize(200, 100);
            //shape.Text = "Sample 1 text text text";

           
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
