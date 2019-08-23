using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using gorillatree.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gorillatree.Controllers {
    public class HomeController : Controller {
        private HomeContext dbContext;

        public HomeController (HomeContext context) {
            dbContext = context;
        }

        [HttpGet ("")]
        public IActionResult Index () {
            return View ();
        }

        [HttpPost ("register")]
        public IActionResult Register (User newUser) {
            if (ModelState.IsValid) {
                if (dbContext.Users.Any (u => u.Email == newUser.Email)) //checking the database to see if any dbcontext users emails exist
                {
                    ModelState.AddModelError ("Email", "Email already in use!"); //if password exists this is the error
                    return View ("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User> ();
                newUser.Password = Hasher.HashPassword (newUser, newUser.Password);
                dbContext.Users.Add (newUser);
                dbContext.SaveChanges ();
                HttpContext.Session.SetInt32 ("UserId", newUser.UserId);
                return RedirectToAction ("Dashboard");

            } else {
                return View ("Index");
            }
        }

        [HttpPost ("login")]

        public IActionResult Login (LogUser loginuser) {
            if (ModelState.IsValid) {
                User userInDB = dbContext.Users.FirstOrDefault (u => u.Email == loginuser.LoginEmail);
                if (userInDB == null) {
                    ModelState.AddModelError ("LoginEmail", "That Email isnt signed up yet, FIX IT");
                    return View ("Index");
                }
                var hasher = new PasswordHasher<LogUser> ();
                var result = hasher.VerifyHashedPassword (loginuser, userInDB.Password, loginuser.LoginPassword); // if your hover over the verifyhashedpassword it tells you what it means

                if (result == 0) {
                    ModelState.AddModelError ("LoginPassword", "Not Correct");
                    return View ("Index");
                }
                HttpContext.Session.SetInt32 ("UserId", userInDB.UserId);
                return RedirectToAction ("Dashboard");
            } else {
                return View ("Index");
            }
        }

        [HttpGet ("dashboard")]
        public IActionResult Dashboard () {
            Console.WriteLine("HEOEOELELELLELEOOOOO");
            if (HttpContext.Session.GetInt32 ("UserId") == null) {
                HttpContext.Session.Clear ();
                return RedirectToAction ("Index");

            } else {
                List<Tree> alltrees = dbContext.Trees.Include (a => a.Planter).ToList ();
                ViewBag.alltrees = alltrees;
                User dbUser = dbContext.Users.FirstOrDefault (u => u.UserId == HttpContext.Session.GetInt32 ("UserId"));
                ViewBag.User = dbUser;
                ViewBag.background = "background.png";
                ViewBag.ImgAlt = "background";
                return View ("dashboard", alltrees);
            }
        }

        [HttpGet]
        [Route ("AddTree")]
        public IActionResult AddTree () {
            if (HttpContext.Session.GetInt32 ("UserId") == null) {
                return RedirectToAction ("Logout");
            }

            return View ("AddTree");
        }

        [HttpPost]
        [Route ("planttree")]
        public IActionResult Planttree (Tree AddTree) {

            Console.WriteLine (AddTree);
            if (ModelState.IsValid) {

                Console.WriteLine ("MAKIN A TREE");
                AddTree.UserId = HttpContext.Session.GetInt32 ("UserId").GetValueOrDefault ();
                dbContext.Trees.Add (AddTree);
                dbContext.SaveChanges ();

                return RedirectToAction ("Dashboard");
            } else {
                Console.WriteLine ("NOPE");
                return View ("AddTree");
            }

        }

        [HttpGet]
        [Route ("TreeDetail/{TreeId}")]
        //TreeId matches the int specified below to match just the tree clicked.
        public IActionResult TreeDetail (int TreeId) {

            Tree aTree = dbContext.Trees.FirstOrDefault (a => a.TreeId == TreeId);
            if (aTree.TreeType == "Weeping Willow") {
                ViewBag.TreeImg = "Weeping_Willow.png";
                ViewBag.ImgAlt = "Weeping Willow";

            }
            if (aTree.TreeType == "River Birch") {
                ViewBag.TreeImg = "river_birch.png";
                ViewBag.ImgAlt = "River Birch";
            }
            if (aTree.TreeType == "Apple Tree") {
                ViewBag.TreeImg = "apple_tree.png";
                ViewBag.ImgAlt = "Apple Tree";
            }
            if (aTree.TreeType == "Red Maple") {
                ViewBag.TreeImg = "Red_Maple.png";
                ViewBag.ImgAlt = "Red Maple";
            }
            return View ("TreeDetail", aTree);

        }

        [HttpGet ("/DeleteTree/{TreeId}")]
        public IActionResult DeleteTree (int TreeId) {
            // Like Update, we will need to query for a single user from our Context object
            Tree Deletedtree = dbContext.Trees.SingleOrDefault (tree => tree.TreeId == TreeId);

            // Then pass the object we queried for to .Remove() on Users
            dbContext.Trees.Remove (Deletedtree);

            // Finally, .SaveChanges() will remove the corresponding row representing this User from DB 
            dbContext.SaveChanges ();
            return RedirectToAction ("Dashboard");

        }

        [HttpGet ("logout")]
        public IActionResult Logout () {
            HttpContext.Session.Clear ();
            return RedirectToAction ("Index");
        }

        [HttpPost ("search")]

        public IActionResult Search(string treeType) 
        {

            
            Console.WriteLine(treeType);
            if(treeType == "All Trees")
            {

                Console.WriteLine("#####################################");
                return RedirectToAction("Dashboard");
            }
            else
            {
                Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
                List<Tree> SameTrees = dbContext.Trees.Include( t => t.Planter).Where( x => x.TreeType == treeType).ToList();
                User dbUser = dbContext.Users.FirstOrDefault (u => u.UserId == HttpContext.Session.GetInt32 ("UserId"));
                ViewBag.User = dbUser;
                dbContext.SaveChanges();

                return View("Dashboard", SameTrees);

            }
        }


            // [HttpPost("searchloc")]
            // public string SearchLoc(string treeLoc)
            // {
            //     List<Tree> alltrees = dbContext.Trees.Include(a => a.Location == "treeLoc").ToList();
            //     ViewBag.alltrees = alltrees;
            //     return View("dashboard",string treeLoc);
            
            // }




            // Console.WriteLine(treeType);
            // if(treeType == "Weeping Willow")//this user selects "Weeping Willow"
            // {
            //     List<Tree> SameTrees = dbContext.Trees.Where (a => a.TreeType.Contains("Weeping Willow")).ToList();
            //     ViewBag.SameTrees = SameTrees;
            //     return RedirectToAction("dashboard");
            // }
            // if(treeType == "River Birch")
            // {
            //     List<Tree> SameTrees = dbContext.Trees.Where (a => a.TreeType.Contains("River Birch")).ToList();
            //     ViewBag.SameTrees = SameTrees;
            //     return View ("Dashboard", SameTrees);
            // }
            // if()
            // {
            //     List<Tree> SameTrees = dbContext.Trees.Where (a => a.TreeType.Contains("Apple Trees")).ToList();
            //     ViewBag.SameTrees = SameTrees;
            //     return RedirectToAction ("dashboard");
            // }
            // if ()
            // {
            //     List<Tree> SameTrees = dbContext.Trees.Where (a => a.TreeType.Contains("Red Maple")).ToList();
            //     ViewBag.SameTrees = SameTrees;
            //     return RedirectToAction ("dashboard");
            // }
            

            

        }

        






    }
