using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using Nancy.RestModule.Exceptions;
using Nancy.RestModule.Models;
using Nancy.Validation;

namespace Nancy.RestModule
{
    public abstract class AbstractRestModule : NancyModule
    {
        private const string APPLICATION_JSON = "application/json";

        protected AbstractRestModule(string path)
            : base(path)
        {
        }

        protected virtual MediaRange DefaultMediaRange
        {
            get { return new MediaRange(APPLICATION_JSON); }
        }

        protected virtual MediaRange DefaultContentType
        {
            get { return APPLICATION_JSON; }
        }

        protected virtual TRequest DoBind<TRequest>()
        {
            try
            {
                return this.Bind<TRequest>();
            }
            catch (ModelBindingException ex)
            {
                string message = string.Join(
                    "\n",
                    ex.PropertyBindingExceptions.Select(
                        e => string.Format(CultureInfo.InvariantCulture, "{0} - {1}", e.PropertyName, e.Message)));

                throw new ModelBindingFailedException(message, ex);
            }
            catch (TargetInvocationException ex)
            {
                throw new ModelBindingFailedException(ex.Message, ex);
            }
            catch (SerializationException ex)
            {
                throw new ModelBindingFailedException(ex.Message, ex);
            }
        }

        protected virtual void DoValidate<TRequest>(TRequest model)
        {
            this.Validate(model);

            if (!ModelValidationResult.IsValid)
            {
                throw new ApiValidationException(ModelValidationResult);
            }
        }

        protected virtual Negotiator DoNegotiate(ResponseModel response)
        {
            return Negotiate
                .WithModel(response.Model)
                .WithStatusCode(response.StatusCode)
                .WithAllowedMediaRange(response.AllowedMediaRange ?? DefaultMediaRange)
                .WithContentType(response.AllowedContentType ?? DefaultContentType);
        }
    }
}