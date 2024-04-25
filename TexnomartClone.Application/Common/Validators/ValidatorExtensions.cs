using FluentValidation.Results;
using System.Text;

namespace TexnomartClone.Application.Common.Validators;

public static class ValidatorExtensions 
{
    public static string GetErrorMessages(this ValidationResult result)
    {
        var resultMessage = new StringBuilder();
        foreach (var error in result.Errors)
        {
            resultMessage.Append(error.ErrorMessage);
        }
        return resultMessage.ToString();
    }
}