using System.Reflection;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Refugee.Models.Entities;

namespace Refugee.Services;

public class DriverModelValidation
{

    public List<string> ModelError(ModelStateDictionary modelState)
    {
        List<string> modelError = new List<string>();
        foreach (string key in modelState.Keys)
        {
            modelError.Add(RenameFieldToColumnName(key));
        }
        return modelError;
    }

    public string RenameFieldToColumnName(string key)
    {
        List<string> result = new List<string>();

        for (int i = 0; i < key.Length; i++)
        {
            result.Add($"{char.ToLower(key[i])}");
            if (i != key.Length-1)
            {
                if (char.IsUpper(key[i+1]))
                {
                    result.Add("_");
                }
            }
        }
        return String.Join("",result);
    }

    public bool IsModelValid(Driver model)
    {
        bool isValid = true;
        
        foreach (PropertyInfo prop in typeof(Driver).GetProperties())
        {
            var propValue = prop.GetValue(model);
            if (propValue is null)
            {
                isValid = false;
            }
        }

        return isValid;
    }
}