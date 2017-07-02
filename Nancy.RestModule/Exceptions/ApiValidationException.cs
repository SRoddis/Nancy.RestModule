using System;
using Nancy.Validation;

namespace Nancy.RestModule.Exceptions
{
    [Serializable]
    public class ApiValidationException : Exception
    {
        private readonly ModelValidationResult _validationResult;

        public ApiValidationException(ModelValidationResult validationResult)
        {
            _validationResult = validationResult;
        }

        public ModelValidationResult ModelValidationResult()
        {
            return _validationResult;
        }
    }
}