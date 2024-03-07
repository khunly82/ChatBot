using System.ComponentModel.DataAnnotations;

namespace ChatBot.API.Validators
{
    public class ExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _validExtensions;

        public ExtensionsAttribute(params string[] validExtensions)
        {
            _validExtensions = validExtensions;
            ErrorMessage = "Le type de fichier est invalide";
        }

        public override bool IsValid(object? value)
        {
            IFormFile? file = value as IFormFile;
            if(file is null)
            {
                return true;
            }

            return _validExtensions.Contains(file.ContentType);
        }
    }
}
