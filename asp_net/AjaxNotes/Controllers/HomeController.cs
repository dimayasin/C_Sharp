using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AjaxNotes.Models;
using DBConnection;

namespace AjaxNotes.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string query = "SELECT * FROM notes";
            var notes = DBConnector.Query(query);
            ViewBag.notes = notes;
            return View();
        }

         [HttpPost]
        [Route("/add")]
        public IActionResult Add(string title, string noteMsg)
        {
            string query = $"INSERT INTO notes (title, description, createdAt, updatedAt) VALUES('{title}', '{noteMsg}', NOW(), NOW())";
            DBConnector.Execute(query);
            return Redirect("/");
        }

        [Route("/update/{nid}")]
        public IActionResult Update(int nid, string title, string noteMsg)
        {
            string query=$"UPDATE notes SET title='{title}', description='{noteMsg}', updatedAt=NOW() WHERE id={nid};";
            DBConnector.Execute(query);
            return Redirect("/");
        }
              [Route("/delete/{nid}")]
        public IActionResult delete(int nid)
        {
            if((nid > 1) && (nid < 3000))
            {
                string query=$"DELETE FROM notes WHERE id='{nid}';";
                DBConnector.Execute(query);
                return Redirect("/");
            }
            else
            {
                ViewBag.Error = "invalid entry";
                return Redirect("/");
            }
        }
    }
}
