using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using usuarios.Models;
using usuarios.Repository;

namespace usuarios.Controllers{
    
public class UsuariosController: Controller{

        SqliteUsuariosRepository repo;
        public UsuariosController(){
            repo = new SqliteUsuariosRepository();
        }
        public IActionResult Index(){
            var usuarios = repo.getUsers();
            return View(usuarios);
        }

        public IActionResult Details(int id){
            var model = repo.getUserById(id);
            return View(model.convertToViewModel());
        }

        public IActionResult Edit(int id){
            var model = repo.getUserById(id);
            if(model!=null)
                return View(model.convertToViewModel());  
            return NotFound();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UsuarioViewModel user){
            var response = repo.editUser(user.convertToUser());
            if(response)
                return RedirectToAction(nameof(Index));
            return View();
        }


           public IActionResult Create(){
            var model = new UsuarioViewModel();
            return View(model);  

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UsuarioViewModel user){
            var response = repo.createUser(user.convertToUser());
            if(response)
                return RedirectToAction(nameof(Index));
            return View();
        }
        
 
        public IActionResult Delete(int id){

            var model = repo.getUserById(id).convertToViewModel();
            if(model!=null)
                return View(model);  
            return NotFound();

        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(UsuarioViewModel user){
            var response = repo.deleteUser(user.Id);
            if(response)
                return RedirectToAction(nameof(Index));
            return View();
        }


    }
}