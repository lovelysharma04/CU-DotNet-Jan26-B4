using Microsoft.AspNetCore.Mvc;
using WebAppDemo3.Models.ViewModels;

public class CalculatorController : Controller
{
    public ActionResult DoSum()
    {
        SumModel sumModel = new SumModel();

        return View(sumModel);
    }

    [HttpPost]
    public ActionResult DoSum(SumModel sumModel)
    {
        if (ModelState.IsValid)
        {
            int num1 = sumModel.Num1;
            int num2 = sumModel.Num2;

            sumModel.Sum = num1 + num2;
            //ModelState.Clear() is used to clear errors but
            //it is also used to force the MVC engine to rebuild the model to be passed to your View.
            //So call ModelState.Clear() right before you pass the model to your View.
            ModelState.Clear();
            return View(sumModel);
        }
        else
        {
            return View(sumModel);
        }
    }
}
