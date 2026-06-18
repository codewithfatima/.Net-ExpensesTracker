//reposity 
// the The "Data Warehouse."
//This is where the code lives that saves/fetches data.
//It hides the complexity of the database from the controller.

using WebApp.Interface;
using WebApp.Models;

namespace WebApp.Data
{
    public class ExpenseRepository:IExpenseRepository
    {
        // Our "In-memory database"
        private readonly ExpenseDbContext _context;
       public ExpenseRepository(ExpenseDbContext context)
        {
            _context = context;
        }

        //get all expense
        public List<Expense> GetAll()
        {
            return _context.Expenses.ToList();
        }
        
        //add expense
        public void Add(Expense expense)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();
        }

        //get expens eby id 
       public Expense GetById(int id)
        {
            return _context.Expenses.Find(id);
        }

       //edit expense by id
       public void Update(Expense expense)
        {
            _context.Expenses.Update(expense);
            _context.SaveChanges();
        }

        //delete expense by id
        public void Delete(int id)
        {
            var expense = _context.Expenses.Find(id);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                _context.SaveChanges();
            }
        }
    }
}

