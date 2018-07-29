using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreDraw.Models;

namespace NetCoreDraw.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GetImg()
        {
            _logger.LogInformation($"{DateTime.Now:yyyy-MM-dd HH:mm:ss:fff}, start create image");

            string msg = $"{DateTime.Now:HH:mm:ss}, 您好 drawing from .NET Core";

            Image image = new Bitmap(400, 200);
            Graphics graph = Graphics.FromImage(image);
            graph.Clear(Color.Azure);
            Pen pen = new Pen(Brushes.Black);
            graph.DrawLines(pen, new Point[] { new Point(10, 10), new Point(380, 180) });
            graph.DrawString(msg, new Font(new FontFamily("微软雅黑"), 12, FontStyle.Bold), Brushes.Blue, new PointF(10, 90));

            //把图片保存到内存文件流
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Png); ;
            byte[] buf = ms.GetBuffer();

            _logger.LogInformation($"{DateTime.Now:yyyy-MM-dd HH:mm:ss:fff}, finish create image");

            return File(buf, "image/png");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
