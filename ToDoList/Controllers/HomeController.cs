using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {

        [HttpGet("/")]
        public ActionResult Index()
        {
            List<Item> allItems = Item.GetAll();
            return View(allItems);
        }

        [HttpGet("/new")]
        public ActionResult ItemsCreateForm()
        {
            return View();
        }

        [HttpPost("/")]
        public ActionResult Create()
        {
            Item newItem = new Item(Request.Form["Item-name"]);
            List<Item> allItems = Item.GetAll();
            return View("Index", allItems);
        }
    }
}
