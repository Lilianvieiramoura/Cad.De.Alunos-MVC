using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers;

public class AlunosController : Controller
{
  private static List<Aluno> alunos = new List<Aluno>();

  // GET: Aluno
  [HttpGet]
  public IActionResult Index()
  {
    return View(alunos);
  }

  //GET: Cadastrar
  public IActionResult Cadastrar()
  {
    return View();
  }

  //POST: Cadastrar
  [HttpPost]
  public IActionResult Cadastrar(Aluno aluno)
  {
    if (ModelState.IsValid)
    {
      aluno.Id = alunos.Count + 1;
      aluno.DataCadastro = DateTime.Now;
      alunos.Add(aluno);
      return RedirectToAction("Index");
    }

    return View(aluno);
  }

  // GET: Aluno/Editar/5
  public IActionResult Editar(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }

    Aluno aluno = alunos.FirstOrDefault(a => a.Id == id)!;
    if (aluno == null)
    {
      return NotFound();
    }

    return View(aluno);
  }

  // POST: Aluno/Editar/5
  [HttpPost]
  public IActionResult Editar(int id, Aluno aluno)
  {
    if (id != aluno.Id)
    {
      return NotFound();
    }

    if (ModelState.IsValid)
    {
      Aluno alunoExistente = alunos.FirstOrDefault(a => a.Id == id)!;
      if (alunoExistente != null)
      {
        alunoExistente.Nome = aluno.Nome;
        alunoExistente.Email = aluno.Email;
        alunoExistente.Ativo = aluno.Ativo;

        return RedirectToAction("Index");
      }
    }

    return View(aluno);
  }

  // GET: Aluno/Excluir/5
  public IActionResult Excluir(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }

    Aluno aluno = alunos.FirstOrDefault(a => a.Id == id)!;
    if (aluno == null)
    {
      return NotFound();
    }

    return View(aluno);
  }

  // POST: Aluno/Excluir/5
  [HttpPost, ActionName("Excluir")]
  public IActionResult ConfirmarExclusao(int id)
  {
    Aluno aluno = alunos.FirstOrDefault(a => a.Id == id)!;
    if (aluno != null)
    {
      alunos.Remove(aluno);
    }

    return RedirectToAction("Index");
  }
}

// ❤