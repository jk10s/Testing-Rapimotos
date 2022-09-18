using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RapiMoto.Models;
using RapiMoto.Data;
using Microsoft.EntityFrameworkCore;

namespace RapiMoto.Controllers;

public class HomeController : Controller
{
    private readonly AppDBContext _contexto; 

    public HomeController(AppDBContext contexto) 
    {
        _contexto = contexto;
    }

     [HttpGet]
    public async Task<IActionResult> Index() // 6 Instruccion
    {
        return View(await _contexto.Tecnico.ToListAsync());
    }
    
    // Crear 
    
    [HttpGet]
    public IActionResult Crear() 
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Crear(Tecnico tecnico) // 7 Instruccion
    {
        if (ModelState.IsValid)
        {
            //  Metodo Add lo utilizamo para crear registros en la base de datos (INSERT INTO contacto VALUES ()
            _contexto.Tecnico.Add(tecnico);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View();
    }

    
     // Editar

    [HttpGet]
    public IActionResult Editar(int? id) 
    {
        if(id == null)
        {
            return NotFound();
        }

        var tecnico = _contexto.Tecnico.Find(id); // SQL (SELECT * FROM Contacto WHERE id = 1)

        if(tecnico == null)
        {
            return NotFound();
        }

        return View(tecnico);
    }
   
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(Tecnico tecnico) //
    {
        if (ModelState.IsValid)
        {
            _contexto.Tecnico.Update(tecnico); 
        
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View();
    }  

    // Detalle
    [HttpGet]
    public IActionResult Detalle(int? id) 
    {
        if(id == null)
        {
            return NotFound();
        }

        var tecnico = _contexto.Tecnico.Find(id); // SQL (SELECT * FROM Contacto WHERE id = 1)

        if(tecnico == null)
        {
            return NotFound();
        }

        return View(tecnico);
    }

    // Borrar
    [HttpGet]
    public IActionResult Borrar(int? id) 
    {
        if(id == null)
        {
            return NotFound();
        }
        var tecnico = _contexto.Tecnico.Find(id);

        if(tecnico == null)
        {
            return NotFound();
        }

        return View(tecnico);

    }


    [HttpPost, ActionName("Borrar")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> BorrarContacto(int? id)
    {
        var tecnico = await _contexto.Tecnico.FindAsync(id);

        if (tecnico == null)
        {
            return View();
        }

        _contexto.Tecnico.Remove(tecnico); 
        await _contexto.SaveChangesAsync();
        
        return RedirectToAction(nameof(Index));

    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

