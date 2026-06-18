//interface  
//The "Rules/Contracts."
//(Often named IExpenseRepository)
//It defines what actions are possible without saying how they are done.

using WebApp.Models;

namespace WebApp.Interface
{
    public interface IExpenseRepository
    {
        List<Expense> GetAll();
        void Add(Expense expense);
         Expense GetById(int id);
        void Delete(int id);

        void Update(Expense expense);

    }
}

//Request: User hits the API.

//Controller: It receives the data. It doesn't know how to save it, so it asks the Repository.

//Repository: It knows how to "talk" to the database. It takes the Model, formats it, and stores it.

//Response: The repository tells the controller "Done," and the controller sends an Ok() back to the user.