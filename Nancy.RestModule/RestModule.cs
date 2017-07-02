using System;
using Nancy.RestModule.Models;

namespace Nancy.RestModule
{
    public abstract class RestModule : AbstractRestModule
    {
        protected RestModule(string path)
            : base(path)
        {
        }

        #region Protected Handler

        protected void GetHandler(
            string path,
            Func<ResponseModel> controllerAction)
        {
            Get[path] = context => RequestHandler(controllerAction);
        }

        protected void GetHandler<TGetRequest>(
            string path,
            Func<TGetRequest, ResponseModel> controllerAction)
        {
            Get[path] = context => RequestHandler(controllerAction);
        }

        protected void PostHandler<TPostRequest>(
            string path,
            Func<TPostRequest, ResponseModel> controllerAction)
        {
            Post[path] = context => RequestHandler(controllerAction);
        }

        protected void PostHandler(
            string path,
            Func<ResponseModel> controllerAction)
        {
            Post[path] = context => RequestHandler(controllerAction);
        }

        protected void PutHandler<TPutRequest>(
            string path,
            Func<TPutRequest, ResponseModel> controllerAction)
        {
            Put[path] = context => RequestHandler(controllerAction);
        }


        protected void DeleteHandler<TDeleteRequest>(
            string path,
            Func<TDeleteRequest, ResponseModel> controllerAction)
        {
            Delete[path] = context => RequestHandler(controllerAction);
        }

        #endregion

        #region Private Handler

        private object RequestHandler(
            Func<ResponseModel> controllerAction)
        {
            ResponseModel response = controllerAction();

            return DoNegotiate(response);
        }

        private object RequestHandler<TRequest>(
            Func<TRequest, ResponseModel> controllerAction)
        {
            return ExecuteControllerAction(controllerAction);
        }

        #endregion

        protected virtual object ExecuteControllerAction<TRequest>(
            Func<TRequest, ResponseModel> controllerAction)
        {
            var model = DoBind<TRequest>();

            DoValidate(model);

            ResponseModel response = controllerAction(model);

            return DoNegotiate(response);
        }
    }
}