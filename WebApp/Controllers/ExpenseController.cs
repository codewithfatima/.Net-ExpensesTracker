//CONTROLLERS:_--
//The traffic control 
//it recive http  requuest like get post talks to the reposity and returs a resposne 
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Models;
using System.Linq;
using WebApp.Interface;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseRepository _repo;
        public ExpenseController (IExpenseRepository repo)
        {
            _repo = repo;
        }


        //add expense in 
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult AddExpense([FromBody] Expense expense)
        {
            _repo.Add(expense);
            return CreatedAtAction(nameof(GetAllExpenses), new { id = expense.Id }, expense);

        }

        //get all expenses
        [HttpGet]
        public IActionResult GetAllExpenses()
        {
            return Ok(_repo.GetAll());
        }
        

        //get expense by id
        [HttpGet("{id}")]
        public IActionResult GetExpenseById(int id)
        {
           var expense = _repo.GetById(id);
            if (expense == null) return NotFound();
            return Ok(expense);
        }


        //update expens eby id
        [HttpPut("{id}")]
        public IActionResult UpdateExpense(int id , [FromBody] Expense updatedExpense)
        {
            var existingExpense = _repo.GetById(id);
            if (existingExpense == null) return NotFound();

            existingExpense.Category = updatedExpense.Category;
            existingExpense.Amount = updatedExpense.Amount;
            _repo.Update(existingExpense);

            return NoContent();
        }

        //delet expen by id
        [HttpDelete("{id}")]
        public IActionResult DeleteExpense(int id)
        {
            var expense = _repo.GetById(id);

            if (expense == null) return NotFound();

            _repo.Delete(id);
            return NoContent();
        }


    }
}