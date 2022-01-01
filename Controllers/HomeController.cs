using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ATM_MVC.Models;

namespace ATM_MVC.Controllers
{
    public class HomeController : Controller
    {
        public static int b=0;
        public static AcountInfo acc;


        private readonly Connect connect;
        public HomeController(Connect Connect)
        {
            connect = Connect;
        }
        public IActionResult Index()
        {

            if (b==1)
            {
                return RedirectToAction("Menu");
            }
            return View();

        }

        public IActionResult Login(string AcountNumber, string pass)
        {
            var p = connect.acountInfos.Where(b => b.Password == pass && b.AcountNumber == AcountNumber).SingleOrDefault();
            if (p != null)
            {
                b = 1;
                acc = p;
            }
            else b = 0;
            return RedirectToAction("Index");

        }
        public IActionResult Menu()
        {
            b=3;
            return View();
        }
        public IActionResult bardasht()
        {
            if (b == 0)
            {
                ViewBag.m = "موجودی کافی نیست";
            }
            return View();
        }
        public IActionResult amaliatbardasht(int m)
        {
            var x = connect.acountInfos.Where(b => b.AcountNumber == acc.AcountNumber && b.Password == acc.Password).SingleOrDefault();
            if (x.Mojodi - m >= 0)
            {
                x.Mojodi -= m;
                b = 1;
                connect.acountInfos.Update(x);
                connect.SaveChanges();
                acc.Mojodi = x.Mojodi;
                return RedirectToAction("menu");
            }
            else
            {

                b = 0;
                return RedirectToAction("bardasht");
            }


        }
        public IActionResult variz()
        {
            return View();
        }

        public IActionResult changepass()
        {

            if (b == 1)
            {
                ViewBag.m = "انحام شد";
            }
            else if(b==0)
            {
                ViewBag.m = "رمز نادرست";
            }
            return View();
        }

        public IActionResult amaliatchangepass(string oldpass, string newpass)
        {
            var a = connect.acountInfos.Where(b => b.AcountNumber == acc.AcountNumber).SingleOrDefault();
            if (a.Password == oldpass)
            {
                a.Password = newpass;
                connect.acountInfos.Update(a);
                connect.SaveChanges();
                acc.Password = a.Password;
                b = 1;
                return RedirectToAction("changepass");

            }
            else
            {
                b = 0;
                return RedirectToAction("changepass");
            }
        }
        public IActionResult mojodi()
        {

            ViewBag.mojod = acc;
            return View();
        }


    }
}
