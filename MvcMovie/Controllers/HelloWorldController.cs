using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // /[Controller]/[ActionName]/[Parameters] - 3 сегмента
        // GET: /HelloWorld/

        public IActionResult Index() // вместо строки вернет представление View
        {
            return View();
        }

        // GET: /HelloWorld/Welcome

        public string Welcome()        
        {
            return "This is he welcome action method";
        }

        // GET: /HelloWorld/Parametr/ 
        // Requires using System.Text.Encodings.Web;
        //Отлавливает элементы с GET /HelloWorld/NoParametr?name=Tom&numtimes=4 , без третьего сегмента
        public string NoParametr(string name, int numTimes = 1) 
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes: {numTimes}");
            // HtmlEncoder.Default.Encode - защита от иньекций
            // $"Hello {name} - интерполированные строки
            // Выведет Hello Tom, NumTimes is: 4
        }

        // /HelloWorld/Parametr/4?name=TOM  /4 - третий сегмент
        public string Parametr(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
            // Выведет Hello Tom, ID: 4
        }
    } 
}
