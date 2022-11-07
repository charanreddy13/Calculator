using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using questions_assignment.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace questions_assignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class questionsController : Controller
    {
      
        [HttpGet]
        public IEnumerable questions()
        {
            int a, b, c=0;
            List<question> questions = new List<question>();
            var operatoratsList = new List<string> { "+","-","×", "/" };
            Random rnd = new Random();
            for (int i=0;i<10; i++)
            {
                a = rnd.Next(0, 100);
                b = rnd.Next(0, 100);
                int ope = rnd.Next(0, 4);
                switch (ope)
                {
                    case 0:
                        c = a + b;
                        break;
                    case 1:
                        c = a - b;
                        break;
                    case 2:
                        c = a * b;
                        break;
                    case 3:
                        c = a / b;
                        break;
                }
                questions.Add( new question {operand1=a, operand2=b, oper= operatoratsList[ope], answer = c, randanswer1=c+2, randanswer2=c+3 });
            }

            return questions;
        }

    }
}
