using FocusRandonGenerator.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FocusRandonGenerator.WebApp.Service.Interface
{
    public interface INumberService
    {
        GeneratedRandonNumber GetNumbersByColor();

        GeneratedRandonNumber GetCustomNumbersByColor(int id);

        List<GeneratedRandonNumber> GetAllCustomNumbers();

    }
}
