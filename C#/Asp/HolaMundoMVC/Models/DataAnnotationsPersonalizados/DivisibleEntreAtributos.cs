namespace HolaMundoMVC.Models.DataAnnotationsPersonalizados
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class DivisibleEntreAtributos : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                var mensajeError = FormatErrorMessage(validationContext.DisplayName);

                if (!Regex.IsMatch(value.ToString(), expresion)) /// Indica si la expresión regular especificada encuentra una coincidencia en una cadena de entrada especificada.
                {
                    return new ValidationResult(mensajeError);
                }
            }

            return ValidationResult.Success;
        }

    }
}