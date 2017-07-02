using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Nancy.RestModule.Exceptions
{
    [Serializable]
    public class ModelBindingFailedException : Exception
    {
        public ModelBindingFailedException()
        {
        }

        public ModelBindingFailedException([Localizable(false)] string message)
            : base(message)
        {
        }

        public ModelBindingFailedException([Localizable(false)] string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ModelBindingFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}