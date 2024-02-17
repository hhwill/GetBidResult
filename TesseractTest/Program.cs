using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace TesseractTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Bitmap bmp = new Bitmap(@"D:\temp\ocr\panavi\image1.bmp");
            Bitmap bmp = new Bitmap(@"Z:\dev\interne\cs\tesseract\tesseract-2.03\eurotext.tif");
            tessnet2.Tesseract ocr = new tessnet2.Tesseract();
            // ocr.SetVariable("tessedit_char_whitelist", "0123456789");
            ocr.Init(null, "fra", false);
            // List<tessnet2.Word> r1 = ocr.DoOCR(bmp, new Rectangle(792, 247, 130, 54));
            List<tessnet2.Word> r1 = ocr.DoOCR(bmp, Rectangle.Empty);
            int lc = tessnet2.Tesseract.LineCount(r1);
            for (int i = 0; i < lc; i++)
            {
                List<tessnet2.Word> lineWords = tessnet2.Tesseract.GetLineWords(r1, i);
                Console.WriteLine("Line {0} = {1}", i, tessnet2.Tesseract.GetLineText(r1, i));
            }
            foreach (tessnet2.Word word in r1)
                Console.WriteLine("{0}:{1}", word.Confidence, word.Text);
            /*
            Dictionary<string, object> v1 = new Dictionary<string, object>();
            foreach (string var in vars.Keys)
                v1.Add(var, ocr.GetVariable(var));
            List<tessnet2.Word> r2 = ocr.DoOCR(bmp, Rectangle.Empty);
            Dictionary<string, object> v2 = new Dictionary<string, object>();
            foreach (string var in vars.Keys)
                v2.Add(var, ocr.GetVariable(var));
            if (r1.Count == r2.Count)
            {
                for (int i = 0; i < r1.Count; i++)
                {
                    if (r1[i].Text != r2[i].Text || r1[i].Confidence != r2[i].Confidence)
                        Console.WriteLine("Diff {0}:{1} et {2}:{3}", r1[i].Text, r1[i].Confidence, r2[i].Text, r2[i].Confidence);
                }
            }
            foreach (string var in vars.Keys)
            {
                if (!v1[var].Equals(v2[var]))
                    Console.WriteLine("Var {0}:{1}:{2}", var, v1[var], v2[var]);
            }
            */
        }
    }
}
